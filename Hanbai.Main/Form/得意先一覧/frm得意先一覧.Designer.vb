﻿Namespace Form

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frm得意先一覧
        Inherits Main.Form.BaseXtraForm

        'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Windows フォーム デザイナーで必要です。
        Private components As System.ComponentModel.IContainer

        'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
        'Windows フォーム デザイナーを使用して変更できます。  
        'コード エディターを使って変更しないでください。
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.pnlFooter = New DevExpress.XtraEditors.PanelControl()
            Me.btn一覧印刷 = New DevExpress.XtraEditors.SimpleButton()
            Me.btn閉じる = New DevExpress.XtraEditors.SimpleButton()
            Me.lctMain = New DevExpress.XtraLayout.LayoutControl()
            Me.lue締日 = New DevExpress.XtraEditors.LookUpEdit()
            Me.btn検索 = New DevExpress.XtraEditors.SimpleButton()
            Me.grdMain = New DevExpress.XtraGrid.GridControl()
            Me.viewMain = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
            Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
            Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
            Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
            Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
            Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
            Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
            Me.repFLG = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
            Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
            Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
            CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFooter.SuspendLayout()
            CType(Me.lctMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.lctMain.SuspendLayout()
            CType(Me.lue締日.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.viewMain, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repFLG, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlFooter
            '
            Me.pnlFooter.Controls.Add(Me.btn一覧印刷)
            Me.pnlFooter.Controls.Add(Me.btn閉じる)
            Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlFooter.Location = New System.Drawing.Point(0, 568)
            Me.pnlFooter.Name = "pnlFooter"
            Me.pnlFooter.Size = New System.Drawing.Size(958, 50)
            Me.pnlFooter.TabIndex = 3
            '
            'btn一覧印刷
            '
            Me.btn一覧印刷.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btn一覧印刷.Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn一覧印刷.Appearance.Options.UseFont = True
            Me.btn一覧印刷.Image = Global.Hanbai.Main.My.Resources.Resources.PrintDirect
            Me.btn一覧印刷.Location = New System.Drawing.Point(701, 8)
            Me.btn一覧印刷.Name = "btn一覧印刷"
            Me.btn一覧印刷.Size = New System.Drawing.Size(115, 30)
            Me.btn一覧印刷.TabIndex = 3
            Me.btn一覧印刷.Text = "一覧印刷"
            '
            'btn閉じる
            '
            Me.btn閉じる.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btn閉じる.Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn閉じる.Appearance.Options.UseFont = True
            Me.btn閉じる.Image = Global.Hanbai.Main.My.Resources.Resources.close_16x16
            Me.btn閉じる.Location = New System.Drawing.Point(831, 8)
            Me.btn閉じる.Name = "btn閉じる"
            Me.btn閉じる.Size = New System.Drawing.Size(115, 30)
            Me.btn閉じる.TabIndex = 0
            Me.btn閉じる.Text = "閉じる"
            '
            'lctMain
            '
            Me.lctMain.AllowCustomizationMenu = False
            Me.lctMain.Controls.Add(Me.lue締日)
            Me.lctMain.Controls.Add(Me.btn検索)
            Me.lctMain.Controls.Add(Me.grdMain)
            Me.lctMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lctMain.Location = New System.Drawing.Point(0, 0)
            Me.lctMain.Name = "lctMain"
            Me.lctMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(740, 379, 770, 584)
            Me.lctMain.Root = Me.LayoutControlGroup1
            Me.lctMain.Size = New System.Drawing.Size(958, 568)
            Me.lctMain.TabIndex = 4
            Me.lctMain.Text = "LayoutControl1"
            '
            'lue締日
            '
            Me.lue締日.Location = New System.Drawing.Point(39, 12)
            Me.lue締日.Name = "lue締日"
            Me.lue締日.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.lue締日.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "締日"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("締日区分", 100, "締日区分")})
            Me.lue締日.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
            Me.lue締日.Size = New System.Drawing.Size(119, 18)
            Me.lue締日.StyleController = Me.lctMain
            Me.lue締日.TabIndex = 16
            '
            'btn検索
            '
            Me.btn検索.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btn検索.Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn検索.Appearance.Options.UseFont = True
            Me.btn検索.Image = Global.Hanbai.Main.My.Resources.Resources.Find_16x16
            Me.btn検索.Location = New System.Drawing.Point(847, 12)
            Me.btn検索.Name = "btn検索"
            Me.btn検索.Size = New System.Drawing.Size(99, 26)
            Me.btn検索.StyleController = Me.lctMain
            Me.btn検索.TabIndex = 4
            Me.btn検索.Text = "検索"
            '
            'grdMain
            '
            Me.grdMain.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.grdMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
            Me.grdMain.EmbeddedNavigator.Buttons.Edit.Visible = False
            Me.grdMain.EmbeddedNavigator.Buttons.EnabledAutoRepeat = False
            Me.grdMain.EmbeddedNavigator.Buttons.EndEdit.Visible = False
            Me.grdMain.EmbeddedNavigator.Buttons.Remove.Visible = False
            Me.grdMain.Location = New System.Drawing.Point(12, 42)
            Me.grdMain.MainView = Me.viewMain
            Me.grdMain.Name = "grdMain"
            Me.grdMain.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repFLG})
            Me.grdMain.Size = New System.Drawing.Size(934, 514)
            Me.grdMain.TabIndex = 13
            Me.grdMain.UseEmbeddedNavigator = True
            Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewMain})
            '
            'viewMain
            '
            Me.viewMain.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand6, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5})
            Me.viewMain.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn12, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn11})
            Me.viewMain.GridControl = Me.grdMain
            Me.viewMain.Name = "viewMain"
            Me.viewMain.OptionsBehavior.Editable = False
            Me.viewMain.OptionsBehavior.ReadOnly = True
            Me.viewMain.OptionsPrint.PrintBandHeader = False
            Me.viewMain.OptionsView.EnableAppearanceEvenRow = True
            Me.viewMain.OptionsView.EnableAppearanceOddRow = True
            Me.viewMain.OptionsView.ShowBands = False
            Me.viewMain.OptionsView.ShowGroupPanel = False
            '
            'gridBand6
            '
            Me.gridBand6.Caption = "gridBand6"
            Me.gridBand6.Columns.Add(Me.BandedGridColumn1)
            Me.gridBand6.Columns.Add(Me.BandedGridColumn2)
            Me.gridBand6.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Me.gridBand6.Name = "gridBand6"
            Me.gridBand6.Width = 275
            '
            'BandedGridColumn1
            '
            Me.BandedGridColumn1.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn1.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn1.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn1.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn1.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn1.Caption = "コード"
            Me.BandedGridColumn1.FieldName = "@得意先コード"
            Me.BandedGridColumn1.MinWidth = 70
            Me.BandedGridColumn1.Name = "BandedGridColumn1"
            Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
            Me.BandedGridColumn1.OptionsColumn.FixedWidth = True
            Me.BandedGridColumn1.OptionsColumn.TabStop = False
            Me.BandedGridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.[String]
            Me.BandedGridColumn1.Visible = True
            '
            'BandedGridColumn2
            '
            Me.BandedGridColumn2.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn2.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn2.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn2.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn2.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn2.Caption = "得意先名"
            Me.BandedGridColumn2.FieldName = "得意先名"
            Me.BandedGridColumn2.MinWidth = 200
            Me.BandedGridColumn2.Name = "BandedGridColumn2"
            Me.BandedGridColumn2.OptionsColumn.AllowEdit = False
            Me.BandedGridColumn2.OptionsColumn.FixedWidth = True
            Me.BandedGridColumn2.OptionsColumn.TabStop = False
            Me.BandedGridColumn2.Visible = True
            '
            'gridBand2
            '
            Me.gridBand2.Caption = "gridBand2"
            Me.gridBand2.Columns.Add(Me.BandedGridColumn3)
            Me.gridBand2.Columns.Add(Me.BandedGridColumn12)
            Me.gridBand2.Name = "gridBand2"
            Me.gridBand2.Width = 115
            '
            'BandedGridColumn3
            '
            Me.BandedGridColumn3.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn3.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn3.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn3.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn3.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn3.Caption = "カナ名"
            Me.BandedGridColumn3.FieldName = "得意先カナ名"
            Me.BandedGridColumn3.Name = "BandedGridColumn3"
            Me.BandedGridColumn3.Visible = True
            '
            'BandedGridColumn12
            '
            Me.BandedGridColumn12.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn12.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn12.AppearanceCell.Options.UseTextOptions = True
            Me.BandedGridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn12.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn12.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn12.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn12.Caption = "締日"
            Me.BandedGridColumn12.FieldName = "締日"
            Me.BandedGridColumn12.MinWidth = 40
            Me.BandedGridColumn12.Name = "BandedGridColumn12"
            Me.BandedGridColumn12.OptionsColumn.AllowEdit = False
            Me.BandedGridColumn12.OptionsColumn.FixedWidth = True
            Me.BandedGridColumn12.OptionsColumn.TabStop = False
            Me.BandedGridColumn12.Visible = True
            Me.BandedGridColumn12.Width = 40
            '
            'gridBand3
            '
            Me.gridBand3.Caption = "gridBand3"
            Me.gridBand3.Columns.Add(Me.BandedGridColumn4)
            Me.gridBand3.Columns.Add(Me.BandedGridColumn5)
            Me.gridBand3.Columns.Add(Me.BandedGridColumn6)
            Me.gridBand3.Name = "gridBand3"
            Me.gridBand3.Width = 225
            '
            'BandedGridColumn4
            '
            Me.BandedGridColumn4.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn4.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn4.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn4.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn4.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn4.Caption = "郵便番号"
            Me.BandedGridColumn4.FieldName = "郵便番号"
            Me.BandedGridColumn4.Name = "BandedGridColumn4"
            Me.BandedGridColumn4.Visible = True
            '
            'BandedGridColumn5
            '
            Me.BandedGridColumn5.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn5.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn5.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn5.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn5.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn5.Caption = "住所１"
            Me.BandedGridColumn5.FieldName = "住所１"
            Me.BandedGridColumn5.Name = "BandedGridColumn5"
            Me.BandedGridColumn5.Visible = True
            '
            'BandedGridColumn6
            '
            Me.BandedGridColumn6.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn6.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn6.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn6.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn6.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn6.Caption = "住所２"
            Me.BandedGridColumn6.FieldName = "住所２"
            Me.BandedGridColumn6.Name = "BandedGridColumn6"
            Me.BandedGridColumn6.Visible = True
            '
            'gridBand4
            '
            Me.gridBand4.Caption = "gridBand4"
            Me.gridBand4.Columns.Add(Me.BandedGridColumn7)
            Me.gridBand4.Columns.Add(Me.BandedGridColumn8)
            Me.gridBand4.Name = "gridBand4"
            Me.gridBand4.Width = 150
            '
            'BandedGridColumn7
            '
            Me.BandedGridColumn7.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn7.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn7.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn7.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn7.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn7.Caption = "電話番号"
            Me.BandedGridColumn7.FieldName = "電話番号"
            Me.BandedGridColumn7.Name = "BandedGridColumn7"
            Me.BandedGridColumn7.Visible = True
            '
            'BandedGridColumn8
            '
            Me.BandedGridColumn8.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn8.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn8.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn8.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn8.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn8.Caption = "FAX"
            Me.BandedGridColumn8.FieldName = "FAX"
            Me.BandedGridColumn8.Name = "BandedGridColumn8"
            Me.BandedGridColumn8.Visible = True
            '
            'gridBand5
            '
            Me.gridBand5.Caption = "gridBand5"
            Me.gridBand5.Columns.Add(Me.BandedGridColumn9)
            Me.gridBand5.Columns.Add(Me.BandedGridColumn11)
            Me.gridBand5.Name = "gridBand5"
            Me.gridBand5.Width = 150
            '
            'BandedGridColumn9
            '
            Me.BandedGridColumn9.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn9.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn9.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn9.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn9.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn9.Caption = "受注停止"
            Me.BandedGridColumn9.FieldName = "受注停止"
            Me.BandedGridColumn9.Name = "BandedGridColumn9"
            Me.BandedGridColumn9.Visible = True
            '
            'BandedGridColumn11
            '
            Me.BandedGridColumn11.AppearanceCell.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn11.AppearanceCell.Options.UseFont = True
            Me.BandedGridColumn11.AppearanceHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
            Me.BandedGridColumn11.AppearanceHeader.Options.UseFont = True
            Me.BandedGridColumn11.AppearanceHeader.Options.UseTextOptions = True
            Me.BandedGridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BandedGridColumn11.Caption = "倒産"
            Me.BandedGridColumn11.FieldName = "倒産"
            Me.BandedGridColumn11.Name = "BandedGridColumn11"
            Me.BandedGridColumn11.Visible = True
            '
            'repFLG
            '
            Me.repFLG.AutoHeight = False
            Me.repFLG.Name = "repFLG"
            '
            'LayoutControlGroup1
            '
            Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
            Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.LayoutControlGroup1.GroupBordersVisible = False
            Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem2})
            Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
            Me.LayoutControlGroup1.Size = New System.Drawing.Size(958, 568)
            Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
            Me.LayoutControlGroup1.TextVisible = False
            '
            'LayoutControlItem10
            '
            Me.LayoutControlItem10.Control = Me.grdMain
            Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10"
            Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 30)
            Me.LayoutControlItem10.Name = "LayoutControlItem10"
            Me.LayoutControlItem10.Size = New System.Drawing.Size(938, 518)
            Me.LayoutControlItem10.Text = "LayoutControlItem10"
            Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem10.TextToControlDistance = 0
            Me.LayoutControlItem10.TextVisible = False
            '
            'EmptySpaceItem1
            '
            Me.EmptySpaceItem1.AllowHotTrack = False
            Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
            Me.EmptySpaceItem1.Location = New System.Drawing.Point(150, 0)
            Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
            Me.EmptySpaceItem1.Size = New System.Drawing.Size(685, 30)
            Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
            Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
            '
            'LayoutControlItem1
            '
            Me.LayoutControlItem1.Control = Me.btn検索
            Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
            Me.LayoutControlItem1.Location = New System.Drawing.Point(835, 0)
            Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(103, 30)
            Me.LayoutControlItem1.MinSize = New System.Drawing.Size(103, 30)
            Me.LayoutControlItem1.Name = "LayoutControlItem1"
            Me.LayoutControlItem1.Size = New System.Drawing.Size(103, 30)
            Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
            Me.LayoutControlItem1.Text = "LayoutControlItem1"
            Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem1.TextToControlDistance = 0
            Me.LayoutControlItem1.TextVisible = False
            '
            'LayoutControlItem2
            '
            Me.LayoutControlItem2.Control = Me.lue締日
            Me.LayoutControlItem2.CustomizationFormText = "締日"
            Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(150, 30)
            Me.LayoutControlItem2.MinSize = New System.Drawing.Size(150, 30)
            Me.LayoutControlItem2.Name = "LayoutControlItem2"
            Me.LayoutControlItem2.Size = New System.Drawing.Size(150, 30)
            Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
            Me.LayoutControlItem2.Text = "締日"
            Me.LayoutControlItem2.TextSize = New System.Drawing.Size(24, 14)
            '
            'frm得意先一覧
            '
            Me.Appearance.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.ClientSize = New System.Drawing.Size(958, 618)
            Me.Controls.Add(Me.lctMain)
            Me.Controls.Add(Me.pnlFooter)
            Me.Name = "frm得意先一覧"
            Me.Text = "締日請求書発行"
            CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFooter.ResumeLayout(False)
            CType(Me.lctMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.lctMain.ResumeLayout(False)
            CType(Me.lue締日.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.viewMain, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repFLG, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

End Sub
        Friend WithEvents pnlFooter As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btn閉じる As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents lctMain As DevExpress.XtraLayout.LayoutControl
        Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
        Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
        Friend WithEvents viewMain As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
        Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents btn一覧印刷 As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents repFLG As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
        Friend WithEvents btn検索 As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Friend WithEvents lue締日 As DevExpress.XtraEditors.LookUpEdit
        Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand

    End Class

End Namespace