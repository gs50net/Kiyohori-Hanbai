Namespace Form

    Friend Class frm得意先一覧

#Region "定数"

        Private Const LAYOUT_NAME As String = "frm締日請求書発行_grdMain.xml"

        Private Const CLM_印刷FLG As String = "印刷FLG"

#End Region

#Region "子クラス"

        Private Class View締日区分 : Inherits MyDBViewGateway

            Public Sub Fill()

                Dim strSql As String = "SELECT " & _
                                        " ID, 締日区分" & _
                                        " FROM T_締日区分" & _
                                        " ORDER BY ID"

                FillData(strSql)

            End Sub

        End Class

        Private Class View得意先 : Inherits MyDBViewGateway

            Public Sub Fill(ByVal strWhere As String)
                Dim strFmt As String = "SELECT *" & _
                                       " FROM T_得意先マスター" & _
                                       " WHERE {0}" & _
                                       " ORDER BY 得意先コード, 枝番"
                Dim strSql As String = String.Format(strFmt, strWhere)
                FillData(strSql)
            End Sub

        End Class

#End Region

#Region "メンバー変数"

        Private mvwData As View得意先
        Private mGuid As System.Guid

#End Region

#Region "コンストラクタ"

        Public Sub New(ByVal frmMain As frmMain, _
                       ByVal btnItem As SimpleButton)


            MyBase.New(frmMain, frmMain.enmScreen.締日請求書発行, btnItem)

            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

        End Sub

#End Region

#Region "イベントハンドラ(フォーム)"

        Private Sub frm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

            'レイアウト復元
            'CClsLayoutSetting.RestoreLayout(LAYOUT_NAME, grdMain)

            'データゲートウェイの初期化
            mprcInitDataGateway()
            'コントロールにバインディングソースをバインドする
            mprcBindingControl()

            'フォームロード済？
            mblnFormLoaded = True

        End Sub

        Private Sub frm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
            'レイアウト保存
            'CClsLayoutSetting.SaveLayout(LAYOUT_NAME, grdMain)
        End Sub

#End Region

#Region "イベントハンドラ(ボタン)"

        Private Sub btn閉じる_Click(sender As System.Object, e As System.EventArgs) Handles btn閉じる.Click
            Me.Close()
        End Sub

        Private Sub btn検索_Click(sender As System.Object, e As System.EventArgs) Handles btn検索.Click
            If lue締日.ItemIndex = -1 Then
                Return
            End If

            検索処理()

        End Sub

        Private Sub btn一覧印刷_Click(sender As System.Object, e As System.EventArgs) Handles btn一覧印刷.Click
            Dim grd As GridControl = grdMain
            Dim strTitle As String = "得意先一覧"

            If Not IsNothing(grd) Then
                Using dlg As New dlgPrintPreview(mfrmMain, grd, strTitle)
                    With dlg
                        '用紙設定
                        With .pComponentLink
                            .PaperKind = System.Drawing.Printing.PaperKind.A3
                            .Landscape = True
                        End With
                        'ドキュメント生成
                        .CreateDocument()
                        .ShowDialog()
                    End With
                End Using
            End If
        End Sub

#End Region

#Region "イベントハンドラ(コントロール)"

        Private Sub viewMain_CustomUnboundColumnData(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles viewMain.CustomUnboundColumnData
            If e.IsGetData AndAlso e.Column.UnboundType <> DevExpress.Data.UnboundColumnType.Bound Then
                Dim vw As Views.Grid.GridView = DirectCast(sender, Views.Grid.GridView)
                Dim row As DataRow = DirectCast(e.Row, DataRowView).Row
                If Not IsNothing(row) Then
                    Select Case e.Column.FieldName
                        Case "@得意先コード"
                            'e.Value = String.Format("{0}-{1}", row("得意先コード"), row("枝番"))
                            e.Value = String.Format("{0}", row("得意先コード"))
                    End Select
                End If
            End If
        End Sub

        Private Sub lue締日_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles lue締日.EditValueChanged
            mprc検索条件クリア()
        End Sub

#End Region

#Region "プライベート　メソッド"

        ''' <summary>
        ''' データゲートウェイの初期化
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcInitDataGateway()

            Dim vw As New View締日区分
            vw.Fill()
            ControllHelper.DataBindings(lue締日, vw.Table, "ID", "ID")

            mvwData = New View得意先
        End Sub


        ''' <summary>
        ''' コントロールにバインディングソースをバインドする
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcBindingControl()

            mprc検索条件クリア()

            '全てのカラムを検索カラムにする
            SetAutoFilter(viewMain)

        End Sub

        Private Sub mprc検索条件クリア(Optional ByVal blnFirst As Boolean = False)

            With viewMain
                .BeginUpdate()
                .GridControl.DataSource = Nothing
                .GridControl.RefreshDataSource()
                .EndUpdate()
            End With

        End Sub

        Public Sub 検索処理()

            Dim strWhere As String = String.Format("締日 = {0}", lue締日.EditValue)

            '読込み
            mvwData.Fill(strWhere)
            With viewMain
                .BeginUpdate()
                .GridControl.DataSource = mvwData.Table
                .GridControl.RefreshDataSource()
                .ExpandAllGroups()
                If .RowCount > 0 Then
                    .FocusedRowHandle = 0
                End If
                .BestFitColumns()
                .EndUpdate()
            End With

        End Sub

#End Region

    End Class

End Namespace
