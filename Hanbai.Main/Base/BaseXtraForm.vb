Namespace Form

    ''' <summary>
    ''' �t�H�[���@��{���ۃN���X
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class BaseXtraForm

        Private mbtnItem As SimpleButton
        Private mblnHideTitleBar As Boolean = True

#Region "�v���p�e�B"

#End Region

#Region "�v���e�N�g�@�����o�[�ϐ�"

        ''' <summary>
        ''' ���C���@�t�H�[��
        ''' </summary>
        ''' <remarks></remarks>
        Protected mfrmMain As frmMain
        ''' <summary>
        ''' �A�v���P�[�V�����ݒ�@�N���X
        ''' </summary>
        ''' <remarks></remarks>
        Protected mclsAppSetting As CClsAppSetting = CClsAppSetting.GetInstance
        '�t�H�[�����[�h�ρH
        Protected mblnFormLoaded As Boolean = False

        Protected mintTopRowIndex As Integer
        Protected mintFocucedHandle As Integer

        '�i�r�Q�[�V�����@�C���[�W���X�g
        Protected mlstNavigatorImageList As ImageList

#End Region

#Region "�R���X�g���N�^"

        Public Sub New()

            ' ���̌Ăяo���̓f�U�C�i�[�ŕK�v�ł��B
            InitializeComponent()

            ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B

        End Sub

        Protected Sub New(ByVal blnShowWaitForm As Boolean)
            ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
            InitializeComponent()

            ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B

            'Wait Form�\��
            If blnShowWaitForm Then
                ShowWaitForm(mfrmMain)
            End If
        End Sub

        Protected Sub New(ByVal look As DevExpress.LookAndFeel.UserLookAndFeel, Optional ByVal blnShowWaitForm As Boolean = True)
            ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
            InitializeComponent()

            ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B

            '���b�N�A���h�t�B�[��
            Me.LookAndFeel.ParentLookAndFeel = look

            'Wait Form�\��
            If blnShowWaitForm Then
                ShowWaitForm(mfrmMain)
            End If
        End Sub

        Protected Sub New(ByVal frmMain As frmMain, Optional ByVal blnShowWaitForm As Boolean = True)

            ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
            InitializeComponent()

            ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B
            mfrmMain = frmMain

            'Wait Form�\��
            If blnShowWaitForm Then
                ShowWaitForm(mfrmMain)
            End If
        End Sub

        ''' <summary>
        ''' MDI Child�̏ꍇ
        ''' </summary>
        ''' <param name="frmMain"></param>
        ''' <param name="enmScreen">��ʒ�`ID</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal frmMain As frmMain, _
                          ByVal enmScreen As frmMain.enmScreen, _
                          ByVal btnItem As SimpleButton, _
                          Optional ByVal blnShowWaitForm As Boolean = True)

            ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
            InitializeComponent()

            ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B
            mfrmMain = frmMain

            Me.MdiParent = mfrmMain
            Me.mbtnItem = btnItem

            'Wait Form�\��
            If blnShowWaitForm Then
                ShowWaitForm(mfrmMain)
            End If

            'Tag�ɉ�ʒ�`ID��ݒu����
            Me.Tag = enmScreen

            '�^�C�g���o�[������
            If mblnHideTitleBar Then
                Me.WindowState = FormWindowState.Maximized
            End If

            Me.AutoScroll = True

        End Sub

#End Region

#Region "�C�x���g�n���h��(�t�H�[��)"

        Private Sub BaseXtraForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                'MDI Child�̏ꍇ
                If Not IsNothing(Me.MdiParent) Then
                    mfrmMain.pnlMain.Visible = False
                    '�^�C�g���o�[������
                    If mblnHideTitleBar Then
                        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    Else
                        Me.Location = New Point(0, 0)
                        Me.MaximizeBox = False
                        Me.MinimizeBox = False
                    End If
                    '�{�^������
                    Me.mbtnItem.Enabled = False
                Else
                    '�_�C�A���O�̏ꍇ
                    If Not IsNothing(mfrmMain) Then
                        Me.Size = mfrmMain.Size
                        Me.Location = mfrmMain.Location
                        Me.MinimizeBox = False
                        Me.MaximizeBox = False
                    End If
                End If
            Catch ex As Exception

            Finally
                'Wait Form��\��
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

#Region "�v���e�N�g�@���\�b�h"

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
        ' ''' ��ʈ��
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
        ' ''' �t�H�[�����ړ��ł��Ȃ��悤�ɂ���
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
        ''' �R���g���[���ɃG���[���b�Z�[�W��ݒ肵�܂�
        ''' </summary>
        ''' <param name="ctr">�R���g���[��</param>
        ''' <param name="strMsg">�G���[���b�Z�[�W</param>
        ''' <param name="blnFocus">�G���[����Focus����H</param>
        ''' <remarks></remarks>
        Protected Overloads Sub SetErrorText(ByVal ctr As BaseEdit, ByVal strMsg As String, Optional ByVal blnFocus As Boolean = True)

            Beep()
            ctr.ErrorText = strMsg
            ctr.Focus()

        End Sub

        ''' <summary>
        ''' TabHeader�𐧌䂷��
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
                    '�ҏW����
                    .OptionsBehavior.Editable = True
                    If blnAllowAddRow Then
                        '�s�ǉ�����
                        .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                        '�ǉ��͐擪�s
                        .OptionsView.NewItemRowPosition = pos
                    Else
                        '�s�ǉ����Ȃ�
                        .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    End If
                    If blnAllowDeleteRow Then
                        '�s�폜����
                        .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
                    Else
                        '�s�폜���Ȃ�
                        .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    End If
                    '�t�H�[�J�X�@�X�^�C���@�Z��
                    .FocusRectStyle = Views.Grid.DrawFocusRectStyle.CellFocus
                Else
                    '�ҏW�s��
                    .OptionsBehavior.Editable = False
                    '�s�ǉ����Ȃ�
                    .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    '�s�폜���Ȃ�
                    .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    '�t�H�[�J�X�@�X�^�C���@Row
                    .FocusRectStyle = Views.Grid.DrawFocusRectStyle.RowFocus
                End If
                'Enter��NextColumn
                .OptionsNavigation.EnterMoveNextColumn = True
                '�J�������\���ɂ͂��Ȃ�
                .OptionsCustomization.AllowQuickHideColumns = False
                '�o���h�@�J�X�^�}�C�Y�Ȃ�
                .OptionsCustomization.ShowBandsInCustomizationForm = False
                '�v�����g�o���h�@�w�b�_�[�Ȃ�
                .OptionsPrint.PrintBandHeader = False
                '�s�̐F����
                .OptionsView.EnableAppearanceEvenRow = True
                .OptionsView.EnableAppearanceOddRow = True
                '�J�����@�ړ��E���T�C�Y����
                .OptionsCustomization.AllowColumnMoving = True
                .OptionsCustomization.AllowColumnResizing = True
                .OptionsCustomization.AllowChangeColumnParent = True
                '�o���h�@�ړ��E���T�C�Y����
                .OptionsCustomization.AllowBandMoving = True
                .OptionsCustomization.AllowBandResizing = True
                '.OptionsCustomization.AllowChangeBandParent = True
                '���j���[
                .OptionsMenu.EnableColumnMenu = True
                .OptionsMenu.EnableGroupPanelMenu = False
            End With

            '�i�r�Q�[�^�[
            If view.GridControl.UseEmbeddedNavigator Then
                mprcInitEmbeddedNavigator(view.GridControl)
            End If

            '�A�s�A�����X�ݒ�
            'XtraGridXAppearances.SetStyleScheme(view)

        End Sub

        Protected Overloads Sub InitGridView(ByVal view As Views.Grid.GridView,
                                             ByVal blnReadOnly As Boolean,
                                             Optional ByVal blnAllowAddRow As Boolean = True,
                                             Optional ByVal blnAllowDeleteRow As Boolean = True,
                                             Optional ByVal pos As Views.Grid.NewItemRowPosition = Views.Grid.NewItemRowPosition.Top)

            With view
                If Not blnReadOnly Then
                    '�ҏW����
                    .OptionsBehavior.Editable = True
                    If blnAllowAddRow Then
                        '�s�ǉ�����
                        .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                        '�ǉ��͐擪�s
                        .OptionsView.NewItemRowPosition = pos
                    Else
                        '�s�ǉ����Ȃ�
                        .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    End If
                    If blnAllowDeleteRow Then
                        '�s�폜����
                        .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
                    Else
                        '�s�폜���Ȃ�
                        .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    End If
                    '�t�H�[�J�X�@�X�^�C���@�Z��
                    .FocusRectStyle = Views.Grid.DrawFocusRectStyle.CellFocus
                Else
                    '�ҏW�s��
                    .OptionsBehavior.Editable = False
                    '�s�ǉ����Ȃ�
                    .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    '�s�폜���Ȃ�
                    .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    '�t�H�[�J�X�@�X�^�C���@Row
                    .FocusRectStyle = Views.Grid.DrawFocusRectStyle.RowFocus
                End If
                'Enter��NextColumn
                .OptionsNavigation.EnterMoveNextColumn = True
                '�J�������\���ɂ͂��Ȃ�
                .OptionsCustomization.AllowQuickHideColumns = False
                '�s�̐F����
                .OptionsView.EnableAppearanceEvenRow = True
                .OptionsView.EnableAppearanceOddRow = True
                '�J�����@�ړ��E���T�C�Y����
                .OptionsCustomization.AllowColumnMoving = True
                .OptionsCustomization.AllowColumnResizing = True
                '���j���[
                .OptionsMenu.EnableColumnMenu = True
                .OptionsMenu.EnableGroupPanelMenu = False
            End With

            '�i�r�Q�[�^�[
            If view.GridControl.UseEmbeddedNavigator Then
                mprcInitEmbeddedNavigator(view.GridControl)
            End If

            '�A�s�A�����X�ݒ�
            'XtraGridXAppearances.SetStyleScheme(view)

        End Sub

        ''' <summary>
        ''' �s�̍������v�Z���A���C�A�E�g��ύX����
        ''' </summary>
        ''' <remarks>AdvBandedGridView�ɂ͖����AGridView�EBandedGridView�ɂ��邱��
        ''' �s�̍����������ɂ���ɂ̓J�����̑����������ɂ��邱��</remarks>
        Protected Sub CalcRowHeight(ByVal view As Views.Grid.GridView)

            With view
                .OptionsView.RowAutoHeight = True
                .LayoutChanged()
            End With

        End Sub

        ''' <summary>
        ''' �J�����g�s��ޔ�
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub SaveCurrentRowIndex(ByVal view As Views.Grid.GridView)

            mintFocucedHandle = view.FocusedRowHandle
            mintTopRowIndex = view.TopRowIndex

        End Sub

        ''' <summary>
        ''' �J�����g�s�֕��A
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
        ''' �f�[�^�[�i�r�Q�[�^�@�����ݒ�
        ''' </summary>
        ''' <param name="nav"></param>
        ''' <param name="objDataSource"></param>
        ''' <remarks></remarks>
        Protected Sub InitNavigator(ByVal nav As DataNavigator, ByVal objDataSource As Object)

            With nav
                .DataSource = objDataSource
                With .Buttons
                    .Append.Hint = "�s��ǉ����܂�"
                    .CancelEdit.Hint = "�ύX��������܂�"
                    .EndEdit.Hint = "�ύX���m�肵�܂�"
                    .First.Hint = "�擪�ֈړ����܂�"
                    .Last.Hint = "�Ō�ֈړ����܂�"
                    .Next.Hint = "���ֈړ����܂�"
                    .NextPage.Hint = "���łֈړ����܂�"
                    .Prev.Hint = "�O�ֈړ����܂�"
                    .PrevPage.Hint = "�O�łֈړ����܂�"
                    .Remove.Hint = "�s���폜���܂�"
                End With
                .ShowToolTips = True
                '.TextLocation = NavigatorButtonsTextLocation.Center
                '.TextStringFormat = "{1}"
            End With

            AddHandler nav.ButtonClick, New DevExpress.XtraEditors.NavigatorButtonClickEventHandler(AddressOf Navigator_ButtonClick)

        End Sub

        '�S�ẴJ�����������J�����ɂ���
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
                        .Append.Hint = "�s��ǉ����܂�"
                        '.Append.ImageIndex = 6
                        .CancelEdit.Hint = "�ύX��������܂�"
                        '.CancelEdit.ImageIndex = 9
                        .EndEdit.Hint = "�ύX���m�肵�܂�"
                        '.EndEdit.ImageIndex = 8
                        .First.Hint = "�擪�ֈړ����܂�"
                        '.First.ImageIndex = 0
                        .Last.Hint = "�Ō�ֈړ����܂�"
                        '.Last.ImageIndex = 5
                        .Next.Hint = "���ֈړ����܂�"
                        '.Next.ImageIndex = 3
                        .NextPage.Hint = "���łֈړ����܂�"
                        '.NextPage.ImageIndex = 4
                        .Prev.Hint = "�O�ֈړ����܂�"
                        '.Prev.ImageIndex = 2
                        .PrevPage.Hint = "�O�łֈړ����܂�"
                        '.PrevPage.ImageIndex = 1
                        .Remove.Hint = "�s���폜���܂�"
                        '.Remove.ImageIndex = 7
                        .Edit.Hint = "�ҏW���܂�"
                        '.Edit.ImageIndex = 10
                    End With
                    .ShowToolTips = True
                    .TextLocation = NavigatorButtonsTextLocation.Center
                    .TextStringFormat = "{0}/{1}"
                    .Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!)
                    .Appearance.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!)
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

#Region "�f���Q�[�h�@���\�b�h"

        Protected Sub Navigator_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
            If e.Button.ButtonType = NavigatorButtonType.Remove Then
                If CFncMessage.MessageBox(My.Resources.MSG_�폜OK, My.Resources.CAP_APPLICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    e.Handled = True
                End If
            End If
        End Sub

#End Region

#Region "���\�b�h"

        Public Sub ResizeMdiWindow(ByVal intSize As Integer, ByVal intHeight As Integer)
            Me.Size = New Size(Me.Width + intSize, Me.Height + intHeight)
        End Sub

#End Region

    End Class

End Namespace
