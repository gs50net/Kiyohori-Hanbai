Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI

Namespace Form

    Friend Class dlgPrintPreview

#Region "メンバー変数"

        ''' <summary>
        ''' キャプション
        ''' </summary>
        ''' <remarks></remarks>
        Private mstrCaption As String
        ''' <summary>
        ''' 印刷オブジェクト
        ''' </summary>
        ''' <remarks></remarks>
        Private mobj As Object

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' コンポーネントリンク
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property pComponentLink() As DevExpress.XtraPrinting.PrintableComponentLink
            Get
                Return Me.PrintableComponentLink
            End Get
        End Property

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ XtraReport用
        ''' </summary>
        ''' <param name="frmParent"></param>
        ''' <param name="obj"></param>
        ''' <param name="strCaption"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal frmParent As frmMain, ByVal obj As XtraReport, ByVal strCaption As String)

            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。
            mfrmMain = frmParent
            mobj = obj

            'Wait Form表示
            ShowWaitForm(mfrmMain)

            'キャプション
            mstrCaption = strCaption

            'ドキュメント
            With obj
                Me.PrintControl.PrintingSystem = .PrintingSystem
                .CreateDocument()
            End With

        End Sub

        ''' <summary>
        ''' コンストラクタ XtraGrid.GridControl用
        ''' </summary>
        ''' <param name="frmParent"></param>
        ''' <param name="obj"></param>
        ''' <param name="strCaption"></param>
        ''' <remarks>ドキュメント生成は呼び出し元で行う</remarks>
        Public Sub New(ByVal frmParent As frmMain, ByVal obj As DevExpress.XtraGrid.GridControl, ByVal strCaption As String)

            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。
            mfrmMain = frmParent
            mobj = obj

            'Wait Form表示
            ShowWaitForm(mfrmMain)

            'キャプション
            mstrCaption = strCaption

            'ドキュメント
            pComponentLink.Component = DirectCast(mobj, DevExpress.XtraGrid.GridControl)

            'ヘッダー
            Dim leftColumn As String = ""
            Dim middleColumn As String = strCaption
            Dim rightColumn As String = "日付:[印刷日付] PAGE:[ページ番号 / 合計ページ数]　"
            Dim phf As PageHeaderFooter = TryCast(pComponentLink.PageHeaderFooter, PageHeaderFooter)
            With phf.Header
                .Content.Clear()
                .Content.AddRange(New String() {leftColumn, middleColumn, rightColumn})
                .Font = New System.Drawing.Font("MS UI Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                .LineAlignment = BrickAlignment.Center
            End With

            'デフォルト用紙設定
            With pComponentLink
                .PaperKind = System.Drawing.Printing.PaperKind.A4
                .Landscape = False
                .Margins = New System.Drawing.Printing.Margins(20, 20, 40, 20)
            End With

        End Sub

#End Region

#Region "イベントハンドラ(フォーム)"

        Private Sub dlgPrintPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'キャプション
            If mstrCaption <> String.Empty Then
                Me.Text = mstrCaption
            End If


            'メニュー　カスタマイズ
            With Me.PrintControl.PrintingSystem
                .SetCommandVisibility(PrintingSystemCommand.EditPageHF, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.Save, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.Open, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.HandTool, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.Magnifier, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.Scale, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.FillBackground, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.SendFile, CommandVisibility.None)

                '.SetCommandVisibility(PrintingSystemCommand.ClosePreview, CommandVisibility.Menu)
                'CSV以外はだめ
                '.SetCommandVisibility(PrintingSystemCommand.ExportFile, CommandVisibility.None)
                '.SetCommandVisibility(PrintingSystemCommand.ExportTxt, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.ExportRtf, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.ExportGraphic, CommandVisibility.None)

                'XtraGrid　コントロールの以外の時は、Mht/Htm/Xlsはだめ
                If Not TypeOf mobj Is DevExpress.XtraGrid.GridControl Then
                    .SetCommandVisibility(PrintingSystemCommand.ExportHtm, CommandVisibility.None)
                    .SetCommandVisibility(PrintingSystemCommand.ExportMht, CommandVisibility.None)
                    '.SetCommandVisibility(PrintingSystemCommand.ExportXls, CommandVisibility.None)
                End If
            End With

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' ドキュメント生成
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CreateDocument()

            If Not IsNothing(pComponentLink) Then
                pComponentLink.CreateDocument()
            End If

        End Sub

#End Region

    End Class

End Namespace
