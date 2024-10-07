Namespace Form

    ''' <summary>
    ''' フォーム　基本抽象クラス
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class BaseXtraForm

        Private mbtnItem As SimpleButton
        Private mblnHideTitleBar As Boolean = True

#Region "プロパティ"

#End Region

#Region "プロテクト　メンバー変数"

        ''' <summary>
        ''' メイン　フォーム
        ''' </summary>
        ''' <remarks></remarks>
        Protected mfrmMain As frmMain
        ''' <summary>
        ''' アプリケーション設定　クラス
        ''' </summary>
        ''' <remarks></remarks>
        Protected mclsAppSetting As CClsAppSetting = CClsAppSetting.GetInstance
        'フォームロード済？
        Protected mblnFormLoaded As Boolean = False

        Protected mintTopRowIndex As Integer
        Protected mintFocucedHandle As Integer

        'ナビゲーション　イメージリスト
        Protected mlstNavigatorImageList As ImageList

#End Region

#Region "コンストラクタ"

        Public Sub New()

            ' この呼び出しはデザイナーで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

        End Sub

        Protected Sub New(ByVal blnShowWaitForm As Boolean)
            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            'Wait Form表示
            If blnShowWaitForm Then
                ShowWaitForm(mfrmMain)
            End If
        End Sub

        Protected Sub New(ByVal look As DevExpress.LookAndFeel.UserLookAndFeel, Optional ByVal blnShowWaitForm As Boolean = True)
            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            'ルックアンドフィール
            Me.LookAndFeel.ParentLookAndFeel = look

            'Wait Form表示
            If blnShowWaitForm Then
                ShowWaitForm(mfrmMain)
            End If
        End Sub

        Protected Sub New(ByVal frmMain As frmMain, Optional ByVal blnShowWaitForm As Boolean = True)

            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。
            mfrmMain = frmMain

            'Wait Form表示
            If blnShowWaitForm Then
                ShowWaitForm(mfrmMain)
            End If
        End Sub

        ''' <summary>
        ''' MDI Childの場合
        ''' </summary>
        ''' <param name="frmMain"></param>
        ''' <param name="enmScreen">画面定義ID</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal frmMain As frmMain, _
                          ByVal enmScreen As frmMain.enmScreen, _
                          ByVal btnItem As SimpleButton, _
                          Optional ByVal blnShowWaitForm As Boolean = True)

            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。
            mfrmMain = frmMain

            Me.MdiParent = mfrmMain
            Me.mbtnItem = btnItem

            'Wait Form表示
            If blnShowWaitForm Then
                ShowWaitForm(mfrmMain)
            End If

            'Tagに画面定義IDを設置する
            Me.Tag = enmScreen

            'タイトルバーを消す
            If mblnHideTitleBar Then
                Me.WindowState = FormWindowState.Maximized
            End If

            Me.AutoScroll = True

        End Sub

#End Region

#Region "イベントハンドラ(フォーム)"

        Private Sub BaseXtraForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                'MDI Childの場合
                If Not IsNothing(Me.MdiParent) Then
                    mfrmMain.pnlMain.Visible = False
                    'タイトルバーを消す
                    If mblnHideTitleBar Then
                        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    Else
                        Me.Location = New Point(0, 0)
                        Me.MaximizeBox = False
                        Me.MinimizeBox = False
                    End If
                    'ボタン制御
                    Me.mbtnItem.Enabled = False
                Else
                    'ダイアログの場合
                    If Not IsNothing(mfrmMain) Then
                        Me.Size = mfrmMain.Size
                        Me.Location = mfrmMain.Location
                        Me.MinimizeBox = False
                        Me.MaximizeBox = False
                    End If
                End If
            Catch ex As Exception

            Finally
                'Wait Form非表示
                If SplashScreenManager.IsSplashFormVisible Then
                    SplashScreenManager.CloseWaitForm()
                End If
            End Try

        End Sub

        Private Sub BaseXtraForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
            If Not IsNothing(Me.MdiParent) Then
                mfrmMain.pnlMain.Visible = True
            End If

            If Not IsNothing(mbtnItem) Then
                mbtnItem.Enabled = True
            End If
        End Sub

#End Region

#Region "プロテクト　メソッド"

        Protected Sub ShowWaitForm(ByVal parent As Windows.Forms.Form)
            Dim x As Integer = CInt(parent.Location.X + (parent.Width - 246) / 2)
            Dim y As Integer = CInt(parent.Location.Y + (parent.Height - 67) / 2)
            With Me.SplashScreenManager
                .SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual
                .SplashFormLocation = New System.Drawing.Point(x, y)
                .ShowWaitForm()
            End With
        End Sub

        ' ''' <summary>
        ' ''' 画面印刷
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'Protected Sub PrintForm()

        '    Dim dlgPreview As New PrintPreviewDialog
        '    Dim printDocument As New System.Drawing.Printing.PrintDocument
        '    AddHandler printDocument.PrintPage, New System.Drawing.Printing.PrintPageEventHandler(AddressOf PrintDocument_PrintPage)

        '    CaptureScreen()

        '    With dlgPreview
        '        .StartPosition = FormStartPosition.CenterParent
        '        .SetBounds(0, 0, 800, 800)
        '        .Document = printDocument
        '        .ShowDialog()
        '    End With

        '    RemoveHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage

        'End Sub

        'Private Declare Function BitBlt Lib "gdi32.dll" Alias "BitBlt" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, _
        '                                                           ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, _
        '                                                           ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Long

        'Private memoryImage As Bitmap

        'Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        '    e.Graphics.DrawImage(memoryImage, 0, 0)
        'End Sub

        'Private Sub CaptureScreen()
        '    Dim mygraphics As Graphics = Me.CreateGraphics()
        '    Dim s As Size = Me.Size
        '    memoryImage = New Bitmap(s.Width, s.Height, mygraphics)
        '    Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        '    Dim dc1 As IntPtr = mygraphics.GetHdc
        '    Dim dc2 As IntPtr = memoryGraphics.GetHdc
        '    BitBlt(dc2, 0, 0, Me.ClientRectangle.Width, _
        '        Me.ClientRectangle.Height, dc1, 0, 0, 13369376)
        '    mygraphics.ReleaseHdc(dc1)
        '    memoryGraphics.ReleaseHdc(dc2)
        'End Sub

        ' ''' <summary>
        ' ''' フォームを移動できないようにする
        ' ''' </summary>
        ' ''' <param name="msg"></param>
        ' ''' <remarks></remarks>
        'Protected Overrides Sub WndProc(ByRef msg As System.Windows.Forms.Message)

        '    Const WM_SYSCOMMAND As Integer = &H112
        '    Const SC_MOVE As Integer = &HF010

        '    If Me.IsMdiChild Then
        '        If msg.Msg = WM_SYSCOMMAND AndAlso _
        '      (msg.WParam.ToInt32() And &HFFF0) = SC_MOVE Then
        '            msg.Result = IntPtr.Zero
        '            Return
        '        End If
        '    End If

        '    MyBase.WndProc(msg)

        'End Sub

        ''' <summary>
        ''' コントロールにエラーメッセージを設定します
        ''' </summary>
        ''' <param name="ctr">コントロール</param>
        ''' <param name="strMsg">エラーメッセージ</param>
        ''' <param name="blnFocus">エラー時にFocusする？</param>
        ''' <remarks></remarks>
        Protected Overloads Sub SetErrorText(ByVal ctr As BaseEdit, ByVal strMsg As String, Optional ByVal blnFocus As Boolean = True)

            Beep()
            ctr.ErrorText = strMsg
            ctr.Focus()

        End Sub

        ''' <summary>
        ''' TabHeaderを制御する
        ''' </summary>
        ''' <param name="tbc"></param>
        ''' <remarks></remarks>
        Protected Sub ControlShowTabHeader(ByVal tbc As DevExpress.XtraTab.XtraTabControl)

            Dim intVisiblePage As Integer = 0
            For Each tab As DevExpress.XtraTab.XtraTabPage In tbc.TabPages
                If tab.PageVisible Then
                    intVisiblePage += 1
                End If
            Next
            If intVisiblePage > 1 Then
                tbc.ShowTabHeader = DevExpress.Utils.DefaultBoolean.Default
            Else
                tbc.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
            End If

        End Sub

        Protected Sub ControlEnable(ByVal top As Control, ByVal aReadOnly As Control(), ByVal blnReadOnly As Boolean)

            Dim actr As Control() = CFncControl.GetAllControls(top)
            For Each ctr As Control In actr
                If TypeOf ctr Is BaseEdit Then
                    If Not IsNothing(aReadOnly) Then
                        If Array.IndexOf(aReadOnly, ctr) = -1 Then
                            With DirectCast(ctr, BaseEdit)
                                .Properties.ReadOnly = blnReadOnly
                            End With
                        End If
                    Else
                        With DirectCast(ctr, BaseEdit)
                            .Properties.ReadOnly = blnReadOnly
                        End With
                    End If
                End If

                If TypeOf ctr Is DevExpress.XtraGrid.GridControl Then
                    Dim grd As DevExpress.XtraGrid.GridControl = DirectCast(ctr, DevExpress.XtraGrid.GridControl)
                    If TypeOf grd.FocusedView Is DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView Then
                        With DirectCast(grd.FocusedView, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
                            .OptionsBehavior.Editable = Not blnReadOnly
                        End With
                    End If
                End If

            Next

        End Sub

        Protected Overloads Sub InitGridView(ByVal view As Views.BandedGrid.AdvBandedGridView,
                                             ByVal blnReadOnly As Boolean,
                                             Optional ByVal blnAllowAddRow As Boolean = True,
                                             Optional ByVal blnAllowDeleteRow As Boolean = True,
                                             Optional ByVal pos As Views.Grid.NewItemRowPosition = Views.Grid.NewItemRowPosition.Top)

            With view
                If Not blnReadOnly Then
                    '編集許可
                    .OptionsBehavior.Editable = True
                    If blnAllowAddRow Then
                        '行追加する
                        .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                        '追加は先頭行
                        .OptionsView.NewItemRowPosition = pos
                    Else
                        '行追加しない
                        .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    End If
                    If blnAllowDeleteRow Then
                        '行削除する
                        .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
                    Else
                        '行削除しない
                        .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    End If
                    'フォーカス　スタイル　セル
                    .FocusRectStyle = Views.Grid.DrawFocusRectStyle.CellFocus
                Else
                    '編集不可
                    .OptionsBehavior.Editable = False
                    '行追加しない
                    .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    '行削除しない
                    .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    'フォーカス　スタイル　Row
                    .FocusRectStyle = Views.Grid.DrawFocusRectStyle.RowFocus
                End If
                'Enter時NextColumn
                .OptionsNavigation.EnterMoveNextColumn = True
                'カラムを非表示にはしない
                .OptionsCustomization.AllowQuickHideColumns = False
                'バンド　カスタマイズなし
                .OptionsCustomization.ShowBandsInCustomizationForm = False
                'プリントバンド　ヘッダーなし
                .OptionsPrint.PrintBandHeader = False
                '行の色分け
                .OptionsView.EnableAppearanceEvenRow = True
                .OptionsView.EnableAppearanceOddRow = True
                'カラム　移動・リサイズ許可
                .OptionsCustomization.AllowColumnMoving = True
                .OptionsCustomization.AllowColumnResizing = True
                .OptionsCustomization.AllowChangeColumnParent = True
                'バンド　移動・リサイズ許可
                .OptionsCustomization.AllowBandMoving = True
                .OptionsCustomization.AllowBandResizing = True
                '.OptionsCustomization.AllowChangeBandParent = True
                'メニュー
                .OptionsMenu.EnableColumnMenu = True
                .OptionsMenu.EnableGroupPanelMenu = False
            End With

            'ナビゲーター
            If view.GridControl.UseEmbeddedNavigator Then
                mprcInitEmbeddedNavigator(view.GridControl)
            End If

            'アピアランス設定
            'XtraGridXAppearances.SetStyleScheme(view)

        End Sub

        Protected Overloads Sub InitGridView(ByVal view As Views.Grid.GridView,
                                             ByVal blnReadOnly As Boolean,
                                             Optional ByVal blnAllowAddRow As Boolean = True,
                                             Optional ByVal blnAllowDeleteRow As Boolean = True,
                                             Optional ByVal pos As Views.Grid.NewItemRowPosition = Views.Grid.NewItemRowPosition.Top)

            With view
                If Not blnReadOnly Then
                    '編集許可
                    .OptionsBehavior.Editable = True
                    If blnAllowAddRow Then
                        '行追加する
                        .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                        '追加は先頭行
                        .OptionsView.NewItemRowPosition = pos
                    Else
                        '行追加しない
                        .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    End If
                    If blnAllowDeleteRow Then
                        '行削除する
                        .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
                    Else
                        '行削除しない
                        .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    End If
                    'フォーカス　スタイル　セル
                    .FocusRectStyle = Views.Grid.DrawFocusRectStyle.CellFocus
                Else
                    '編集不可
                    .OptionsBehavior.Editable = False
                    '行追加しない
                    .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    '行削除しない
                    .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    'フォーカス　スタイル　Row
                    .FocusRectStyle = Views.Grid.DrawFocusRectStyle.RowFocus
                End If
                'Enter時NextColumn
                .OptionsNavigation.EnterMoveNextColumn = True
                'カラムを非表示にはしない
                .OptionsCustomization.AllowQuickHideColumns = False
                '行の色分け
                .OptionsView.EnableAppearanceEvenRow = True
                .OptionsView.EnableAppearanceOddRow = True
                'カラム　移動・リサイズ許可
                .OptionsCustomization.AllowColumnMoving = True
                .OptionsCustomization.AllowColumnResizing = True
                'メニュー
                .OptionsMenu.EnableColumnMenu = True
                .OptionsMenu.EnableGroupPanelMenu = False
            End With

            'ナビゲーター
            If view.GridControl.UseEmbeddedNavigator Then
                mprcInitEmbeddedNavigator(view.GridControl)
            End If

            'アピアランス設定
            'XtraGridXAppearances.SetStyleScheme(view)

        End Sub

        ''' <summary>
        ''' 行の高さを計算し、レイアウトを変更する
        ''' </summary>
        ''' <remarks>AdvBandedGridViewには無効、GridView・BandedGridViewにすること
        ''' 行の高さを自動にするにはカラムの属性をメモにすること</remarks>
        Protected Sub CalcRowHeight(ByVal view As Views.Grid.GridView)

            With view
                .OptionsView.RowAutoHeight = True
                .LayoutChanged()
            End With

        End Sub

        ''' <summary>
        ''' カレント行を退避
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub SaveCurrentRowIndex(ByVal view As Views.Grid.GridView)

            mintFocucedHandle = view.FocusedRowHandle
            mintTopRowIndex = view.TopRowIndex

        End Sub

        ''' <summary>
        ''' カレント行へ復帰
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub RestoreCurrentRowIndex(ByVal view As Views.Grid.GridView)

            With view
                If .RowCount > 0 Then
                    If .RowCount > mintTopRowIndex Then
                        .TopRowIndex = mintTopRowIndex
                    Else
                        .TopRowIndex = .RowCount - 1
                    End If

                    If .RowCount > mintFocucedHandle Then
                        .FocusedRowHandle = mintFocucedHandle
                    Else
                        .FocusedRowHandle = .RowCount - 1
                    End If
                End If
            End With

        End Sub

        ''' <summary>
        ''' データーナビゲータ　初期設定
        ''' </summary>
        ''' <param name="nav"></param>
        ''' <param name="objDataSource"></param>
        ''' <remarks></remarks>
        Protected Sub InitNavigator(ByVal nav As DataNavigator, ByVal objDataSource As Object)

            With nav
                .DataSource = objDataSource
                With .Buttons
                    .Append.Hint = "行を追加します"
                    .CancelEdit.Hint = "変更を取消します"
                    .EndEdit.Hint = "変更を確定します"
                    .First.Hint = "先頭へ移動します"
                    .Last.Hint = "最後へ移動します"
                    .Next.Hint = "次へ移動します"
                    .NextPage.Hint = "次頁へ移動します"
                    .Prev.Hint = "前へ移動します"
                    .PrevPage.Hint = "前頁へ移動します"
                    .Remove.Hint = "行を削除します"
                End With
                .ShowToolTips = True
                '.TextLocation = NavigatorButtonsTextLocation.Center
                '.TextStringFormat = "{1}"
            End With

            AddHandler nav.ButtonClick, New DevExpress.XtraEditors.NavigatorButtonClickEventHandler(AddressOf Navigator_ButtonClick)

        End Sub

        '全てのカラムを検索カラムにする
        Protected Sub SetAutoFilter(ByVal view As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
            With view
                .BeginUpdate()

                .OptionsView.ShowAutoFilterRow = True
                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
                Next i

                .EndUpdate()
            End With
        End Sub

#End Region

        Private Sub mprcInitEmbeddedNavigator(ByVal grd As GridControl)
            With grd

                mprcLoadNavigateImageList()
                With .EmbeddedNavigator
                    .ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
                    With .Buttons
                        '.ImageList = mlstNavigatorImageList
                        .Append.Hint = "行を追加します"
                        '.Append.ImageIndex = 6
                        .CancelEdit.Hint = "変更を取消します"
                        '.CancelEdit.ImageIndex = 9
                        .EndEdit.Hint = "変更を確定します"
                        '.EndEdit.ImageIndex = 8
                        .First.Hint = "先頭へ移動します"
                        '.First.ImageIndex = 0
                        .Last.Hint = "最後へ移動します"
                        '.Last.ImageIndex = 5
                        .Next.Hint = "次へ移動します"
                        '.Next.ImageIndex = 3
                        .NextPage.Hint = "次頁へ移動します"
                        '.NextPage.ImageIndex = 4
                        .Prev.Hint = "前へ移動します"
                        '.Prev.ImageIndex = 2
                        .PrevPage.Hint = "前頁へ移動します"
                        '.PrevPage.ImageIndex = 1
                        .Remove.Hint = "行を削除します"
                        '.Remove.ImageIndex = 7
                        .Edit.Hint = "編集します"
                        '.Edit.ImageIndex = 10
                    End With
                    .ShowToolTips = True
                    .TextLocation = NavigatorButtonsTextLocation.Center
                    .TextStringFormat = "{0}/{1}"
                    .Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
                    .Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
                    .AutoSize = True

                    AddHandler .ButtonClick, New DevExpress.XtraEditors.NavigatorButtonClickEventHandler(AddressOf Navigator_ButtonClick)
                End With
            End With
        End Sub

        Private Sub mprcLoadNavigateImageList()
            'If IsNothing(mlstNavigatorImageList) Then
            '    mlstNavigatorImageList = New ImageList
            '    With mlstNavigatorImageList
            '        .ImageSize = New System.Drawing.Size(20, 20)
            '        .Images.Add(My.Resources.go_first_view)
            '        .Images.Add(My.Resources.go_first_2)
            '        .Images.Add(My.Resources.go_previous_7)
            '        .Images.Add(My.Resources.go_next_7)
            '        .Images.Add(My.Resources.go_last_2)
            '        .Images.Add(My.Resources.go_last_view)
            '        .Images.Add(My.Resources.list_add)
            '        .Images.Add(My.Resources.edit_remove_3)
            '        .Images.Add(My.Resources.dialog_ok_5)
            '        .Images.Add(My.Resources.dialog_no_2)
            '        .Images.Add(My.Resources.arrow_up_3)
            '    End With
            'End If
        End Sub

#Region "デリゲード　メソッド"

        Protected Sub Navigator_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
            If e.Button.ButtonType = NavigatorButtonType.Remove Then
                If CFncMessage.MessageBox(My.Resources.MSG_削除OK, My.Resources.CAP_APPLICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    e.Handled = True
                End If
            End If
        End Sub

#End Region

#Region "メソッド"

        Public Sub ResizeMdiWindow(ByVal intSize As Integer, ByVal intHeight As Integer)
            Me.Size = New Size(Me.Width + intSize, Me.Height + intHeight)
        End Sub

#End Region

    End Class

End Namespace
