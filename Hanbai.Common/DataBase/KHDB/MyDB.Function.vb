Namespace DataBase.MyDB

    Public Class CMyDBFunction

        ''' <summary>
        ''' SQL Serverの日付を取得する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDataBaseDate(Optional ByVal blnWithTime As Boolean = True) As DateTime

            Using qry As New MyDBQuery("SELECT GETDATE()")
                If qry.Read() Then
                    Dim dt As Date = CDate(qry.Item(0))
                    Select Case blnWithTime
                        Case True
                            Return dt
                        Case False
                            Return New Date(dt.Year, dt.Month, dt.Day)
                    End Select
                End If
            End Using

            Return Nothing

        End Function

        ''' <summary>
        ''' テーブル　レコード件数取得
        ''' </summary>
        ''' <param name="strTableName">テーブル名</param>
        ''' <param name="strWhere">where句</param>
        ''' <returns>件数</returns>
        ''' <remarks></remarks>
        Public Shared Function GetTableCount(ByVal strTableName As String, Optional ByVal strWhere As String = "") As Integer

            Dim intCount As Integer = 0

            Dim strSql As String = String.Format("SELECT COUNT(*) As Count FROM {0}", strTableName)
            If strWhere <> "" Then
                strSql &= " WHERE " & strWhere
            End If

            Using qry As New MyDBQuery(strSql)
                If qry.Read() Then
                    intCount = CInt(qry.Item(0))
                End If
            End Using

            Return intCount

        End Function

        ' ''' <summary>
        ' ''' リンクサーバー削除
        ' ''' </summary>
        ' ''' <param name="strLinkServer">リンクサーバー名</param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Shared Function DropLinkServer(ByVal strLinkServer As String) As Boolean

        '    Dim strFmt As String = "use master" + vbCr +
        '                            "GO" + vbCr +
        '                            "if (select COUNT(*) from sys.servers WHERE name=N'{0}') = 1" + vbCr +
        '                            "BEGIN" + vbCr +
        '                            "EXEC sp_dropserver @server=N'{0}', @droplogins='droplogins'" + vbCr +
        '                            "END"
        '    Dim strSQL As String = String.Format(strFmt, strLinkServer)

        '    Try
        '        Using sp As New MyDBStoredProcedure()
        '            sp.ExecuteSQL(strSQL, True)
        '        End Using
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '        Return False
        '    End Try

        '    Return True
        'End Function

        ' ''' <summary>
        ' ''' リンクサーバー　追加
        ' ''' </summary>
        ' ''' <param name="strLinkServer">リンクサーバー名</param>
        ' ''' <param name="strDataSrc">データ ソース名</param> 
        ' ''' <returns></returns>
        ' ''' <remarks>
        ' ''' http://msdn.microsoft.com/ja-jp/library/ms190479(v=sql.105).aspx
        ' ''' </remarks>
        'Public Shared Function AddLinkServer(ByVal strLinkServer As String, ByVal strDataSrc As String) As Boolean

        '    Dim strFmt As String = "use master" + vbCr +
        '                            "GO" + vbCr +
        '                            "EXEC sp_addlinkedserver" + vbCr +
        '                            "@server=N'{0}'," + vbCr +
        '                            "@srvproduct=N''," + vbCr +
        '                            "@provider=N'SQLNCLI'," + vbCr +
        '                            "@datasrc=N'{1}'" + vbCr +
        '                            "GO"
        '    Dim strSQL As String = String.Format(strFmt, strLinkServer, strDataSrc)

        '    Try
        '        Using sp As New MyDBStoredProcedure()
        '            sp.ExecuteSQL(strSQL, True)
        '        End Using
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '        Return False
        '    End Try

        '    Return True

        'End Function

        ' ''' <summary>
        ' ''' リンクサーバーログイン　追加
        ' ''' </summary>
        ' ''' <param name="strLinkServer">リンクサーバー名</param>
        ' ''' <param name="strLogin">ログイン</param>
        ' ''' <returns></returns>
        ' ''' <remarks>
        ' ''' http://msdn.microsoft.com/ja-jp/library/ms189811(v=sql.105).aspx
        ' ''' </remarks>
        'Public Overloads Shared Function AddLinkServerLogin(ByVal strLinkServer As String, ByVal strLogin As String) As Boolean

        '    Dim strFmt As String = "use master" + vbCr +
        '                            "GO" + vbCr +
        '                            "EXEC sp_addlinkedsrvlogin" + vbCr +
        '                            "@rmtsrvname = '{0}'," + vbCr +
        '                            "@useself = 'TRUE'," + vbCr +
        '                            "@locallogin = '{1}'" + vbCr +
        '                            "GO"
        '    Dim strSQL As String = String.Format(strFmt, strLinkServer, strLogin)

        '    Try
        '        Using sp As New MyDBStoredProcedure()
        '            sp.ExecuteSQL(strSQL, True)
        '        End Using
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '        Return False
        '    End Try

        '    Return True

        'End Function

        ' ''' <summary>
        ' ''' リンクサーバーログイン　追加
        ' ''' </summary>
        ' ''' <param name="strLinkServer">リンクサーバー名</param>
        ' ''' <param name="strUser">ユーザー名</param>
        ' ''' <param name="strPassword">パスワード</param>
        ' ''' <returns></returns>
        ' ''' <remarks>
        ' ''' http://msdn.microsoft.com/ja-jp/library/ms189811(v=sql.105).aspx
        ' ''' </remarks>
        'Public Overloads Shared Function AddLinkServerLogin(ByVal strLinkServer As String, ByVal strUser As String, ByVal strPassword As String) As Boolean

        '    Dim strFmt As String = "use master" + vbCr +
        '                            "GO" + vbCr +
        '                            "EXEC sp_addlinkedsrvlogin" + vbCr +
        '                            "@rmtsrvname = '{0}'," + vbCr +
        '                            "@useself = 'FALSE'," + vbCr +
        '                            "@rmtuser  = '{1}'," + vbCr +
        '                            "@rmtpassword = '{2}'" + vbCr +
        '                            "GO"
        '    Dim strSQL As String = String.Format(strFmt, strLinkServer, strUser, strPassword)

        '    Try
        '        Using sp As New MyDBStoredProcedure()
        '            sp.ExecuteSQL(strSQL, True)
        '        End Using
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '        Return False
        '    End Try

        '    Return True

        'End Function

End Class

End Namespace
