Namespace Form

    Friend Class frmMain

#Region "列挙体"

        ''' <summary>
        ''' 画面定義ID
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum enmScreen
            締日請求書発行
        End Enum

#End Region

#Region "メンバー変数"

        Private mintBarHeight As Integer

        ''' <summary>
        ''' Form_Load処理中？
        ''' </summary>
        ''' <remarks></remarks>
        Private mblnFormLoading As Boolean = True
        ''' <summary>
        ''' Loadは成功したか？
        ''' </summary>
        ''' <remarks></remarks>
        Private mblnLoadSuccess As Boolean = False

#End Region

#Region "プロパティ"

        Private mclsSettings As CClsAppSetting
        ''' <summary>
        ''' アプリケーション設定　クラス
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend ReadOnly Property pclsSettings() As CClsAppSetting
            Get
                Return mclsSettings
            End Get
        End Property

#End Region

#Region "コンストラクタ"

        Public Sub New()

            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            Me.Text = My.Resources.CAP_APPLICATION

            gfrmMain = Me

        End Sub

#End Region

#Region "イベントハンドラ(フォーム)"

        ''' <summary>
        ''' フォームが初めて表示される直前に発生します。 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'アプリケーション設定　クラス
            mclsSettings = CClsAppSetting.GetInstance
            mclsSettings.pForm = Me
            If Not mclsSettings.ExistsFile Then
                mclsSettings.CreateIniFile()
                CFncMessage.MessageBox(My.Resources.MSG_CREATE_FILE, My.Resources.CAP_APPLICATION)
                'Me.Close()
                'Return
            End If

            'ＤＢの環境設定
            If Not mprcInitConfig() Then
                Me.Close()
                Return
            End If

            ''ログイン
            'If Not mprcLogin(FormStartPosition.CenterScreen) Then
            '    Me.Close()
            '    Return
            'End If

            'フォーム位置・レイアウトを復元します
            mprcRestoreSetting()

            'Loadは成功したか？
            mblnLoadSuccess = True

            'メニューバーの高さ
            'mintBarHeight = BarManager.DockControls.Item(0).ClientSize.Height

        End Sub

        ''' <summary>
        ''' フォームが初めて表示されるたびに発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub frmMain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

            '初期処理
            mprcInit()

            'ここに最初に表示するユーザーコントロールを呼び出す処理を記述する


            'Form_Load処理が終わればfalse
            mblnFormLoading = False

        End Sub

        ''' <summary>
        ''' フォームが閉じる前に発生します。
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

            'Loadは成功したか？
            If mblnLoadSuccess Then
                'フォーム位置・レイアウトを保存します
                mprcSaveSetting()
            End If

        End Sub

        ''' <summary>
        ''' フォーム　リサイズ
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub frmMain_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

            If Me.WindowState = FormWindowState.Maximized Then
                frmMain_ResizeEnd(Nothing, Nothing)
            End If

        End Sub

        ''' <summary>
        ''' フォーム　リサイズ終了後
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub frmMain_ResizeEnd(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.ResizeEnd

            If Not IsNothing(Me.ActiveMdiChild) Then
                ResizeForm(Me.ActiveMdiChild)
            End If

        End Sub

#End Region

#Region "イベントハンドラ(ボタン)"

        Private Sub btn終了_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn終了.Click
            Me.Close()
        End Sub

        Private Sub btn納品入力_Click(sender As System.Object, e As System.EventArgs) Handles btn締日請求書発行.Click
            mprcNewForm(enmScreen.締日請求書発行, DirectCast(sender, SimpleButton))
        End Sub

#End Region

#Region "プライベート　メソッド"

        ''' <summary>
        ''' フォーム位置・レイアウトを復元します
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcRestoreSetting()

            With mclsSettings
                'フォーム位置を復元します。
                .RestoreLocation()
                .RestoreWindowState()
            End With

        End Sub

        ''' <summary>
        ''' フォーム位置・レイアウトを保存します
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcSaveSetting()

            Try
                With mclsSettings
                    If .ExistsFile(False) Then
                        'フォームの位置とサイズを保存
                        .SaveLocation()
                        .SaveWindowState()
                    End If
                End With
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
            End Try

        End Sub

        ''' <summary>
        ''' 環境を設定する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcInitConfig() As Boolean

            '環境　初期設定処理
            If Not mclsSettings.Initial Then
                CFncMessage.ErrorMessage(My.Resources.ERR_INI_FILE)
                Return False
            End If

            Dim clsSetting As CClsSetting = CClsSetting.GetInstance
            With clsSetting
                .pstrIniFileName = mclsSettings.pstrIniFileName
                .pstrKHWSDBConn = mclsSettings.pstrKHWSDBConn
                .pstrKHDBConn = mclsSettings.pstrKHDBConn
            End With

            'データーベースの接続確認
            Dim cnn As Connection = Nothing
            Try
                cnn = New Connection(mclsSettings.pstrKHDBConn, enmProvider.SQLServer)
                cnn.Connection.Open()
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message, , My.Resources.ERR_OPEN_DATABASE)
                Return False
            Finally
                If Not IsNothing(cnn) Then
                    cnn.Dispose()
                    cnn = Nothing
                End If
            End Try

            Dim cnn2 As Connection = Nothing
            Try
                cnn2 = New Connection(mclsSettings.pstrKHWSDBConn, enmProvider.SQLServer)
                cnn2.Connection.Open()
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message, , My.Resources.ERR_OPEN_DATABASE)
                Return False
            Finally
                If Not IsNothing(cnn) Then
                    cnn2.Dispose()
                    cnn2 = Nothing
                End If
            End Try

            'バージョン
            Dim ver As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location)
            Me.Text = Me.Text + " (" + String.Format("Ver {0}", ver.FileVersion) + ")"

            Return True

        End Function

        ''' <summary>
        ''' 初期処理
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcInit()
        End Sub

        ''' <summary>
        ''' 新しいフォームを生成する
        ''' </summary>
        ''' <param name="enmScreen"></param>
        ''' <param name="btn"></param>
        ''' <remarks></remarks>
        Private Sub mprcNewForm(ByVal enmScreen As enmScreen, ByVal btn As SimpleButton)

            Dim frm As BaseXtraForm = Nothing
            Select Case enmScreen
                Case frmMain.enmScreen.締日請求書発行
                    frm = New frm締日請求書発行(Me, btn)
            End Select

            If Not IsNothing(frm) Then
                'フォーム表示
                frm.Show()
            End If

        End Sub

        Private Function mprcExecSQL(ByVal strFileName As String) As Boolean

            Try
                Dim strSQL As String = clsSQL.LoadSQL(strFileName)
                Using sp As New MyDBStoredProcedure
                    sp.ExecuteSQL(strSQL, True)
                End Using
                Return True
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
                Return False
            End Try

        End Function

#End Region

#Region "メソッド"

        Public Sub ResizeForm(ByVal frm As System.Windows.Forms.Form)
            With frm
                .Size = New Size(Me.ClientSize.Width - SystemInformation.FrameBorderSize.Width, _
                                 Me.ClientSize.Height - SystemInformation.FrameBorderSize.Height - mintBarHeight)
                .Location = New Point(0, 0)
            End With

        End Sub

#End Region

    End Class

End Namespace
