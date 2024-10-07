Imports System.IO
Imports System.Environment
Imports Hanbai.Common.Functions

Namespace Classes

    ''' <summary>
    ''' アプリケーション設定　クラス
    ''' </summary>
    ''' <remarks>Singletonクラス</remarks>
    Public Class CClsAppSetting

#Region "定数"

        'Ｉｎｉファイル名
        Private Const ROOT_FOLDER As String = "Kiyohori\Hanbai"
        Private Const INI_FILENAME As String = "Setting\Hanbai.ini"

        'セクション名
        Public Const SEC_CONFIG As String = "Config"
        Private Const SEC_FORM As String = "Form"

        'キー名
        Private Const KEY_SCREENSIZE As String = "ScreenSize"                       '画面サイズ
        Private Const KEY_SCALE As String = "Scale"                                 'スケール
        Private Const KEY_WINDOW_STATE As String = "WindowState"                    'ウィンドウ状態
        Public Const KEY_TMP_PATH As String = "TempPath"                            'テンポラリー　フォルダー　パス名
        Public Const KEY_LOG_PATH As String = "LogPath"                             'ログ　フォルダー　パス名
        Public Const KEY_KHWSDB_CONNECTSTR As String = "KHWSDB_ConnectStr"          'KHWSDB 接続文字列
        Public Const KEY_KHDB_CONNECTSTR As String = "KHDB_ConnectStr"              'KHDB   接続文字列
        Public Const KEY_SKIN As String = "Skin"                                    'スキン

        Public Const KEY_DB_BACKUP_FOLDER As String = "DataBaseBackupFolder"        'バックアップフォルダー
        Public Const KEY_DB_FOLDER As String = "DataBaseFolder"                     'データ格納フォルダー
        Public Const KEY_DB_EVERYBACKUP = "EveryBackup"                             '終了時にバックアップ
        'Public Const KEY_DB_RESTORE_DONE = "DataBaseRestore_Done"                   'リストアー済

        Private Const KEY_LICENCE_CHECK_PASS As String = "LicenceCheckPass"         'ライセンス　チェック　パス

        'メッセージ
        Private Const ERR_MYDB_CONN As String = "環境設定に「MyDB接続文字列」が設定されていません"
        Private Const ERR_NOT_INIFILE As String = "環境設定ファイル「{0}」が見つかりません。"
        Private Const ERR_TMP_PATH As String = "環境設定に「TmpPath」が設定されていません"

        Private Const DEFAULT_SKIN As String = "Lilian"

#End Region

#Region "メンバー変数"

        ''' <summary>
        ''' 唯一のインスタンス
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared _singleton As CClsAppSetting = New CClsAppSetting()

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' メインフォーム
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pForm As Windows.Forms.Form

        Private mstrIniFileName As String
        ''' <summary>
        ''' Ｉｎｉファイル名
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property pstrIniFileName() As String
            Get
                Return mstrIniFileName
            End Get
        End Property

        ''' <summary>
        ''' KHWSDB 接続文字列
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrKHWSDBConn As String
        ''' <summary>
        ''' KHDB 接続文字列
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrKHDBConn As String
        ''' <summary>
        ''' スキン名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrSkin As String
        ''' <summary>
        ''' グリッドスタイル
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrGridStyle As String
        ''' <summary>
        ''' 終了時にバックアップを行う？
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pblnEveryBackup As Boolean
        ''' <summary>
        ''' データーベース格納先
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrDatabaseFolder As String

#Region "パス名"

        ''' <summary>
        ''' テンポラリー　フォルダー　パス名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrTmpPath As String
        ''' <summary>
        ''' ログ　フォルダー　パス名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrLogPath As String
        ''' <summary>
        ''' ホーム　パス名
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property pstrHomePath() As String
            Get
                Return Path.Combine(GetFolderPath(SpecialFolder.Personal), ROOT_FOLDER)
            End Get
        End Property

#End Region

#Region "インフォメーション"

        Public Property pblnInformationVisible As Boolean
        Public Property pstrUpdateInformationURL As String
        Public Property pstrRemoteMentenanceURL As String
        Public Property pstrELearningURL As String

#End Region

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks>このコンストラクタはこのクラスをインスタンス化をできないようにします。</remarks>
        Private Sub New()

            mstrIniFileName = Path.Combine(pstrHomePath, INI_FILENAME)
            Me.pstrGridStyle = "Blue Office"

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 唯一のインスタンスを取得する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetInstance() As CClsAppSetting
            Return _singleton
        End Function

        ''' <summary>
        ''' Ｉｎｉファイルを生成します
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CreateIniFile() As Boolean

            Try
                Dim strDir As String = Path.GetDirectoryName(pstrIniFileName)
                If Not Directory.Exists(strDir) Then
                    Directory.CreateDirectory(strDir)
                End If
                Using sw As New StreamWriter(pstrIniFileName, False, System.Text.Encoding.GetEncoding("sjis"))
                    With sw
                        .WriteLine(";===================================================================")
                        .WriteLine(";")
                        .WriteLine("; 販売管理 環境設定ファイル")
                        .WriteLine(";")
                        .WriteLine(String.Format("; Create Date:{0}", Now))
                        .WriteLine(";")
                        .WriteLine(";===================================================================")
                        .WriteLine("")
                        .WriteLine(";===================================================================")
                        .WriteLine(";環境")
                        .WriteLine(";===================================================================")
                        .WriteLine("[Config]")
                        .WriteLine(";接続文字列")
                        .WriteLine(String.Format("{0}=Data Source=T130SRV1\SQL2016;Initial Catalog=KHWSDB;Integrated Security=False;User=sa;Password=sa", KEY_KHWSDB_CONNECTSTR))
                        .WriteLine(String.Format("{0}=Data Source=T130SRV1\SQL2016;Initial Catalog=KHDB;Integrated Security=False;User=sa;Password=sa", KEY_KHDB_CONNECTSTR))
                        .WriteLine(";====== パス名 =====")
                        .WriteLine(";テンポラリー")
                        .WriteLine(String.Format("{0}={1}", KEY_TMP_PATH, Path.Combine(Me.pstrHomePath, "Temp")))
                        .WriteLine(";ログ")
                        .WriteLine(String.Format("{0}={1}", KEY_LOG_PATH, Path.Combine(Me.pstrHomePath, "Log")))
                        .WriteLine(";====== スキン =====")
                        .WriteLine("Skin=Office 2010 Silver")
                        .WriteLine("")
                        .WriteLine(";===================================================================")
                        .WriteLine(";フォーム位置")
                        .WriteLine(";SXGA 1280X1024の既定値 Width 1240 Height 970")
                        .WriteLine(";===================================================================")
                        .WriteLine("[Form]")
                    End With
                End Using
                Return True
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' Ｉｎｉファイルは存在するか？
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExistsFile(Optional ByVal blnMessage As Boolean = True) As Boolean

            If Not File.Exists(mstrIniFileName) Then
                If blnMessage Then
                    Dim strMsg As String = String.Format(ERR_NOT_INIFILE, pstrIniFileName)
                    CFncMessage.ErrorMessage(strMsg, MessageBoxIcon.Exclamation, My.Resources.CAP_APPLICATION)
                End If
                Return False
            Else
                Return True
            End If

        End Function

        ''' <summary>
        ''' スケールを取得する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetScale() As Single

            Dim ini As New CClsIniSection(mstrIniFileName, SEC_CONFIG)
            Dim sngScale As Single = ini.ReadKey(KEY_SCALE, 1.0)
            Return sngScale

        End Function

        ''' <summary>
        ''' ウインドーの状態を復元します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RestoreWindowState()

            Dim ini As New CClsIniSection(mstrIniFileName, SEC_FORM)
            pForm.WindowState = DirectCast(ini.ReadKey(KEY_WINDOW_STATE, FormWindowState.Normal), FormWindowState)

        End Sub

        ''' <summary>
        ''' ウインドーの状態を保存します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveWindowState()

            Dim ini As New CClsIniSection(mstrIniFileName, SEC_FORM)
            ini.WriteKey(KEY_WINDOW_STATE, pForm.WindowState.ToString("D"))

        End Sub

        ''' <summary>
        ''' フォーム位置を復元します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RestoreLocation()

            Dim ini As New CClsFormSetting(mstrIniFileName)
            ini.RestoreLocation(pForm)
            ini.RestoreSize(pForm)

        End Sub

        ''' <summary>
        ''' フォーム位置を保存します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveLocation()

            Dim ini As New CClsFormSetting(mstrIniFileName)
            ini.SaveLocation(pForm)
            ini.SaveSize(pForm)

        End Sub

        Public Function IsLicenceCheckPass() As Boolean
            Dim ini As New CClsIniSection(mstrIniFileName, SEC_CONFIG)
            Return ini.ReadKey(KEY_LICENCE_CHECK_PASS, False)
        End Function

        ''' <summary>
        ''' 環境　初期設定処理
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Initial() As Boolean

            Dim ini As New CClsIniSection(mstrIniFileName, SEC_CONFIG)

            Try
                'スキン名
                pstrSkin = ini.ReadKey(KEY_SKIN, DEFAULT_SKIN)
                'パス名を取得する
                If Not mprcGetPath(ini) Then
                    Return False
                End If

                '接続文字列を取得する
                If Not mprcGetConnStr(ini) Then
                    Return False
                End If

                'バックアップ
                pstrDatabaseFolder = ini.ReadKey(KEY_DB_FOLDER, String.Empty)
                pblnEveryBackup = ini.ReadKey(KEY_DB_EVERYBACKUP, True)
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message, MessageBoxIcon.Exclamation, My.Resources.CAP_APPLICATION)
                Return False
            End Try

            Return True

        End Function

        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As String)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        ''' <summary>
        ''' 設定値を書き込む
        ''' </summary>
        ''' <param name="section"></param>
        ''' <param name="KeyName"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Integer)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As DateTime)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Boolean)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Single)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        ''' <summary>
        ''' 設定値を読み込む
        ''' </summary>
        ''' <param name="section"></param>
        ''' <param name="KeyName"></param>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As String) As String
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Integer) As Integer
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As DateTime) As DateTime
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Boolean) As Boolean
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Single) As Single
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

#End Region

#Region "プライベート　メソッド"

        ''' <summary>
        ''' 接続文字列を取得する
        ''' </summary>
        ''' <param name="ini"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcGetConnStr(ByVal ini As CClsIniSection) As Boolean

            With ini
                Me.pstrKHWSDBConn = .ReadKey(KEY_KHWSDB_CONNECTSTR, String.Empty)
                Me.pstrKHDBConn = .ReadKey(KEY_KHDB_CONNECTSTR, String.Empty)
            End With

            Return True

        End Function

        ''' <summary>
        ''' パス名を取得する
        ''' </summary>
        ''' <param name="ini"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcGetPath(ByVal ini As CClsIniSection) As Boolean

            Me.pstrTmpPath = ini.ReadKey(KEY_TMP_PATH, String.Empty)
            Me.pstrLogPath = ini.ReadKey(KEY_LOG_PATH, String.Empty)

            'フォルダー作成
            If Not Directory.Exists(Me.pstrTmpPath) Then
                Directory.CreateDirectory(Me.pstrTmpPath)
                Directory.CreateDirectory(Me.pstrLogPath)
            End If

            Return True

        End Function

#End Region

    End Class

End Namespace