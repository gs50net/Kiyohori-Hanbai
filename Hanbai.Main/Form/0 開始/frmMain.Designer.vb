Namespace Form

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmMain
        Inherits DevExpress.XtraEditors.XtraForm

        'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Windows フォーム デザイナーで必要です。
        Private components As System.ComponentModel.IContainer

        'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
        'Windows フォーム デザイナーを使用して変更できます。  
        'コード エディターを使って変更しないでください。
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
            Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
            Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
            Me.btn終了 = New DevExpress.XtraEditors.SimpleButton()
            Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
            Me.btn締日請求書発行 = New DevExpress.XtraEditors.SimpleButton()
            Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.pnlMain = New DevExpress.XtraEditors.PanelControl()
            Me.btn得意先一覧 = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.LayoutControl1.SuspendLayout()
            CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.LayoutControl2.SuspendLayout()
            CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl2.SuspendLayout()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl1.SuspendLayout()
            CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupControl1.SuspendLayout()
            CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'LayoutControl1
            '
            Me.LayoutControl1.Controls.Add(Me.LayoutControl2)
            Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LayoutControl1.Location = New System.Drawing.Point(2, 2)
            Me.LayoutControl1.Name = "LayoutControl1"
            Me.LayoutControl1.Root = Me.LayoutControlGroup1
            Me.LayoutControl1.Size = New System.Drawing.Size(1162, 716)
            Me.LayoutControl1.TabIndex = 0
            Me.LayoutControl1.Text = "LayoutControl1"
            '
            'LayoutControl2
            '
            Me.LayoutControl2.Controls.Add(Me.PanelControl2)
            Me.LayoutControl2.Controls.Add(Me.PanelControl1)
            Me.LayoutControl2.Location = New System.Drawing.Point(12, 12)
            Me.LayoutControl2.Name = "LayoutControl2"
            Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(554, 508, 629, 348)
            Me.LayoutControl2.Root = Me.Root
            Me.LayoutControl2.Size = New System.Drawing.Size(1138, 692)
            Me.LayoutControl2.TabIndex = 4
            Me.LayoutControl2.Text = "LayoutControl2"
            '
            'PanelControl2
            '
            Me.PanelControl2.Controls.Add(Me.btn終了)
            Me.PanelControl2.Location = New System.Drawing.Point(12, 614)
            Me.PanelControl2.Name = "PanelControl2"
            Me.PanelControl2.Size = New System.Drawing.Size(1114, 66)
            Me.PanelControl2.TabIndex = 8
            '
            'btn終了
            '
            Me.btn終了.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btn終了.Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn終了.Appearance.Options.UseFont = True
            Me.btn終了.Image = Global.Hanbai.Main.My.Resources.Resources.close_32x32
            Me.btn終了.Location = New System.Drawing.Point(979, 11)
            Me.btn終了.Name = "btn終了"
            Me.btn終了.Size = New System.Drawing.Size(124, 44)
            Me.btn終了.TabIndex = 0
            Me.btn終了.Text = "終了"
            '
            'PanelControl1
            '
            Me.PanelControl1.Controls.Add(Me.GroupControl1)
            Me.PanelControl1.Location = New System.Drawing.Point(12, 12)
            Me.PanelControl1.Name = "PanelControl1"
            Me.PanelControl1.Size = New System.Drawing.Size(1114, 598)
            Me.PanelControl1.TabIndex = 7
            '
            'GroupControl1
            '
            Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupControl1.AppearanceCaption.Options.UseFont = True
            Me.GroupControl1.AppearanceCaption.Options.UseTextOptions = True
            Me.GroupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.GroupControl1.Controls.Add(Me.btn得意先一覧)
            Me.GroupControl1.Controls.Add(Me.btn締日請求書発行)
            Me.GroupControl1.Location = New System.Drawing.Point(14, 17)
            Me.GroupControl1.Name = "GroupControl1"
            Me.GroupControl1.Size = New System.Drawing.Size(513, 508)
            Me.GroupControl1.TabIndex = 0
            Me.GroupControl1.Text = "請求書発行業務"
            '
            'btn締日請求書発行
            '
            Me.btn締日請求書発行.Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn締日請求書発行.Appearance.Options.UseFont = True
            Me.btn締日請求書発行.Location = New System.Drawing.Point(59, 51)
            Me.btn締日請求書発行.Name = "btn締日請求書発行"
            Me.btn締日請求書発行.Size = New System.Drawing.Size(380, 50)
            Me.btn締日請求書発行.TabIndex = 0
            Me.btn締日請求書発行.Text = "締日ハガキ請求書発行"
            '
            'Root
            '
            Me.Root.AllowCustomizeChildren = False
            Me.Root.CustomizationFormText = "Root"
            Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.Root.GroupBordersVisible = False
            Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
            Me.Root.Location = New System.Drawing.Point(0, 0)
            Me.Root.Name = "Root"
            Me.Root.Size = New System.Drawing.Size(1138, 692)
            Me.Root.Text = "Root"
            Me.Root.TextVisible = False
            '
            'LayoutControlItem2
            '
            Me.LayoutControlItem2.Control = Me.PanelControl1
            Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
            Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControlItem2.Name = "LayoutControlItem2"
            Me.LayoutControlItem2.Size = New System.Drawing.Size(1118, 602)
            Me.LayoutControlItem2.Text = "LayoutControlItem2"
            Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem2.TextToControlDistance = 0
            Me.LayoutControlItem2.TextVisible = False
            '
            'LayoutControlItem3
            '
            Me.LayoutControlItem3.Control = Me.PanelControl2
            Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
            Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 602)
            Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 70)
            Me.LayoutControlItem3.MinSize = New System.Drawing.Size(104, 70)
            Me.LayoutControlItem3.Name = "LayoutControlItem3"
            Me.LayoutControlItem3.Size = New System.Drawing.Size(1118, 70)
            Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
            Me.LayoutControlItem3.Text = "LayoutControlItem3"
            Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem3.TextToControlDistance = 0
            Me.LayoutControlItem3.TextVisible = False
            '
            'LayoutControlGroup1
            '
            Me.LayoutControlGroup1.AllowCustomizeChildren = False
            Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
            Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.LayoutControlGroup1.GroupBordersVisible = False
            Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
            Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
            Me.LayoutControlGroup1.Size = New System.Drawing.Size(1162, 716)
            Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
            Me.LayoutControlGroup1.TextVisible = False
            '
            'LayoutControlItem1
            '
            Me.LayoutControlItem1.Control = Me.LayoutControl2
            Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
            Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControlItem1.Name = "LayoutControlItem1"
            Me.LayoutControlItem1.Size = New System.Drawing.Size(1142, 696)
            Me.LayoutControlItem1.Text = "LayoutControlItem1"
            Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem1.TextToControlDistance = 0
            Me.LayoutControlItem1.TextVisible = False
            '
            'pnlMain
            '
            Me.pnlMain.Controls.Add(Me.LayoutControl1)
            Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlMain.Location = New System.Drawing.Point(0, 0)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(1166, 720)
            Me.pnlMain.TabIndex = 9
            '
            'btn得意先一覧
            '
            Me.btn得意先一覧.Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn得意先一覧.Appearance.Options.UseFont = True
            Me.btn得意先一覧.Location = New System.Drawing.Point(59, 107)
            Me.btn得意先一覧.Name = "btn得意先一覧"
            Me.btn得意先一覧.Size = New System.Drawing.Size(380, 50)
            Me.btn得意先一覧.TabIndex = 1
            Me.btn得意先一覧.Text = "得意先一覧"
            '
            'frmMain
            '
            Me.Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(1166, 720)
            Me.Controls.Add(Me.pnlMain)
            Me.IsMdiContainer = True
            Me.Name = "frmMain"
            Me.Text = "請求書発行システム"
            CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.LayoutControl1.ResumeLayout(False)
            CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.LayoutControl2.ResumeLayout(False)
            CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl2.ResumeLayout(False)
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl1.ResumeLayout(False)
            CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupControl1.ResumeLayout(False)
            CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
        Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
        Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
        Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
        Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btn終了 As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
        Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents pnlMain As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btn締日請求書発行 As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btn得意先一覧 As DevExpress.XtraEditors.SimpleButton
    End Class


End Namespace
