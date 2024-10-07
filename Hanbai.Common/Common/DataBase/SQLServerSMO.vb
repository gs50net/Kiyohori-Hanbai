Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common
Imports Hanbai.Common.Functions

Namespace DataBase

    ''' <summary>
    ''' SQL Server 2008用 SQL Server管理
    ''' </summary>
    ''' <remarks>
    ''' (参照設定)
    '''  Microsoft.SQlServer.Smo
    '''  Microsoft.SQlServer.Smo.Extended
    '''  Microsoft.SQlServer.SqlEnum
    '''  Microsoft.SQlServer.Mnagement.Sdk.Sfc
    ''' </remarks>
    Public Class SQLServerSMO

        ''' <summary>
        ''' バックアップ処理
        ''' </summary>
        ''' <param name="strServerInstance">インスタンス名</param>
        ''' <param name="strDBName">DB名</param>
        ''' <param name="strBackupFile">バックアップファイル名</param>
        ''' <param name="blnLoginSecure">true:Windows認証 false:SQL Server認証</param>
        ''' <param name="strLogin"></param>
        ''' <param name="strPassword"></param>
        ''' <returns></returns>
        ''' <remarks>http://blog.livedoor.jp/akf0/archives/51482490.html</remarks>
        Public Shared Function BackupDataBase(ByVal strServerInstance As String, _
                                              ByVal strDBName As String, _
                                              ByVal strBackupFile As String, _
                                              ByVal blnLoginSecure As Boolean, _
                                              Optional ByVal strLogin As String = "", _
                                              Optional ByVal strPassword As String = "") As Boolean


            Try
                'サーバへの接続情報を設定
                Dim srv As New Server
                With srv.ConnectionContext
                    .ServerInstance = strServerInstance
                    '認証の種類
                    .LoginSecure = blnLoginSecure
                    'SQL Server認証の場合
                    If Not blnLoginSecure Then
                        .Login = strLogin
                        .Password = strPassword
                    End If
                End With

                'バックアップの動作を決める
                Dim bk As New Backup
                With bk
                    .Action = BackupActionType.Database
                    'バックアップ対象のデータベースを指定
                    .Database = strDBName
                    '完全バックアップにする
                    .Incremental = False
                    .Initialize = True
                    .LogTruncation = BackupTruncateLogType.Truncate
                End With

                'バックアップ装置の設定
                'バックアップをファイルに出力する
                Dim Device As New BackupDeviceItem(strBackupFile, DeviceType.File)
                bk.Devices.Add(Device)
                bk.PercentCompleteNotification = 10

                'バックアップの実行
                bk.SqlBackup(srv)

                'CFncMessage.MessageBox("バックアップは完了しました", "BackupDataBase")
                Return True
            Catch smoex As SmoException
                CFncMessage.ErrorMessage(mprcGetInnerException(smoex), MessageBoxIcon.Exclamation, smoex.Message)
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
            End Try

            Return False

        End Function

        ''' <summary>
        ''' リストア処理
        ''' </summary>
        ''' <param name="strServerInstance">インスタンス名</param>
        ''' <param name="strDBName">DB名</param>
        ''' <param name="strBackupFile">バックアップファイル名</param>
        ''' <param name="strDBFolder"></param>
        ''' <param name="blnLoginSecure">true:Windows認証 false:SQL Server認証</param>
        ''' <param name="strLogin"></param>
        ''' <param name="strPassword"></param>
        ''' <returns></returns>
        ''' <remarks>http://blog.livedoor.jp/akf0/archives/51625065.html</remarks>
        Public Shared Function RestoreDataBase(ByVal strServerInstance As String, _
                                               ByVal strDBName As String, _
                                               ByVal strBackupFile As String, _
                                               ByVal strDBFolder As String, _
                                               ByVal blnLoginSecure As Boolean, _
                                               Optional ByVal strLogin As String = "", _
                                               Optional ByVal strPassword As String = "") As Boolean

            Try
                'サーバへの接続情報を設定
                Dim srv As New Server
                With srv.ConnectionContext
                    .ServerInstance = strServerInstance
                    '認証の種類
                    .LoginSecure = blnLoginSecure
                    'SQL Server認証の場合
                    If Not blnLoginSecure Then
                        .Login = strLogin
                        .Password = strPassword
                    End If
                End With

                '復元に利用するバックアップを指定
                Dim res As New Restore

                'バックアップ装置を指定する
                Dim Device As New BackupDeviceItem(strBackupFile, DeviceType.File)
                res.Devices.Add(Device)

                'バックアップが破損していないかどうかを確認する
                '破損している場合は、エラーメッセージを表示して終了
                Dim strMsg As String = String.Empty
                If res.SqlVerify(srv, strMsg) = False Then
                    CFncMessage.ErrorMessage(strMsg)
                    Return False
                End If

                '復元するデータベースの指定
                Dim db As Microsoft.SqlServer.Management.Smo.Database
                db = srv.Databases(strDBName)

                '復元するデータベースの論理名を取得する
                Dim buckupFiles As DataTable
                buckupFiles = res.ReadFileList(srv)

                Dim relocateData As New RelocateFile()
                Dim relocateLog As New RelocateFile()

                For Each buckupFilesRow As DataRow In buckupFiles.Rows
                    If "D".Equals(buckupFilesRow(2)) Then
                        relocateData.LogicalFileName = CStr(buckupFilesRow(0))
                        relocateData.PhysicalFileName = strDBFolder & "\" & CStr(buckupFilesRow(0)) + "_1" + ".mdf"
                    ElseIf "L".Equals(buckupFilesRow(2)) Then
                        relocateLog.LogicalFileName = CStr(buckupFilesRow(0))
                        relocateLog.PhysicalFileName = strDBFolder & "\" + CStr(buckupFilesRow(0)) + "_1" + ".ldf"
                    End If
                Next

                res.RelocateFiles.Add(relocateData)
                res.RelocateFiles.Add(relocateLog)

                '復元（リストア）の動作を決める
                res.Action = RestoreActionType.Database
                res.Database = strDBName
                res.PercentCompleteNotification = 10

                'このパラメータを追加
                res.ReplaceDatabase = True

                '復元（リストア）の実行
                res.SqlRestore(srv)

                'CFncMessage.MessageBox("リストアは完了しました", "RestoreDataBase")
                Return True
            Catch smoex As SmoException
                CFncMessage.ErrorMessage(mprcGetInnerException(smoex), MessageBoxIcon.Exclamation, smoex.Message)
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
            End Try

            Return False

        End Function

        ''' <summary>
        ''' データーベースは存在するか？
        ''' </summary>
        ''' <param name="strServerInstance"></param>
        ''' <param name="strDBName"></param>
        ''' <param name="blnLoginSecure"></param>
        ''' <param name="strLogin"></param>
        ''' <param name="strPassword"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ExistDataBase(ByVal strServerInstance As String, _
                                            ByVal strDBName As String, _
                                            ByVal blnLoginSecure As Boolean, _
                                            Optional ByVal strLogin As String = "", _
                                            Optional ByVal strPassword As String = "") As Boolean

            Try
                'サーバへの接続情報を設定
                Dim srv As New Server
                With srv.ConnectionContext
                    .ServerInstance = strServerInstance
                    '認証の種類
                    .LoginSecure = blnLoginSecure
                    'SQL Server認証の場合
                    If Not blnLoginSecure Then
                        .Login = strLogin
                        .Password = strPassword
                    End If
                End With

                Dim db As Microsoft.SqlServer.Management.Smo.Database = srv.Databases(strDBName)
                If IsNothing(db) Then
                    Return False
                Else
                    Return True
                End If
            Catch smoex As SmoException
                CFncMessage.ErrorMessage(mprcGetInnerException(smoex), MessageBoxIcon.Exclamation, smoex.Message)
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
            End Try

            Return False

        End Function

        ''' <summary>
        ''' データーベース削除処理
        ''' </summary>
        ''' <param name="strServerInstance"></param>
        ''' <param name="strDBName"></param>
        ''' <param name="blnLoginSecure"></param>
        ''' <param name="strLogin"></param>
        ''' <param name="strPassword"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function DropDataBase(ByVal strServerInstance As String, _
                                            ByVal strDBName As String, _
                                            ByVal blnLoginSecure As Boolean, _
                                            Optional ByVal strLogin As String = "", _
                                            Optional ByVal strPassword As String = "") As Boolean

            Try
                'サーバへの接続情報を設定
                Dim srv As New Server
                With srv.ConnectionContext
                    .ServerInstance = strServerInstance
                    '認証の種類
                    .LoginSecure = blnLoginSecure
                    'SQL Server認証の場合
                    If Not blnLoginSecure Then
                        .Login = strLogin
                        .Password = strPassword
                    End If
                End With

                Dim db As Microsoft.SqlServer.Management.Smo.Database = srv.Databases(strDBName)
                If IsNothing(db) Then
                    Throw New Exception(String.Format("{0}は存在しません", strDBName))
                End If
                db.Drop()

                Return True
            Catch smoex As SmoException
                CFncMessage.ErrorMessage(mprcGetInnerException(smoex), MessageBoxIcon.Exclamation, smoex.Message)
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
            End Try

            Return False

        End Function

        Private Shared Function mprcGetInnerException(ByVal smoex As SmoException) As String

            Dim strMsg As String = String.Empty
            Dim ex As Exception
            ex = smoex.InnerException
            Do While ex.InnerException IsNot (Nothing)
                strMsg &= ex.InnerException.Message & vbCrLf
                ex = ex.InnerException
            Loop

            Return strMsg

        End Function

    End Class

End Namespace
