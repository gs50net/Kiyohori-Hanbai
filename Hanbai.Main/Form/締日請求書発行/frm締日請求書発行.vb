Namespace Form

    Public Class ListData
        ''' <summary>
        ''' ページ
        ''' 1:顧客名
        ''' 2:請求書 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PAGE As Integer
        Public Property ID As Integer
        Public Property 得意先コード As String
        Public Property 枝番 As Integer
        Public Property 得意先名 As String
        Public Property 郵便番号 As String
        Public Property 住所１ As String
        Public Property 住所２ As String
    End Class

    Friend Class frm締日請求書発行

#Region "定数"

        Private Const LAYOUT_NAME As String = "frm締日請求書発行_grdMain.xml"

        Private Const CLM_印刷FLG As String = "印刷FLG"

#End Region

#Region "子クラス"

        Private Class ViewData : Inherits MyDBViewGateway

            Public Sub Fill()

                Dim strSql As String = "SELECT DISTINCT " & _
                                        " ID," & _
                                        " 得意先コード," & _
                                        " 枝番," & _
                                        " 得意先名," & _
                                        " 郵便番号," & _
                                        " 住所１," & _
                                        " 住所２," & _
                                        " 請求開始日," & _
                                        " 請求終了日," & _
                                        " 前回請求金額," & _
                                        " 入金金額," & _
                                        " 前回繰越金額," & _
                                        " 今回売上金額," & _
                                        " 消費税," & _
                                        " 今回請求金額," & _
                                        " 締日," & _
                                        " 合計売上件数" & _
                                        " FROM v601_締日請求書印刷 v601" & _
                                        " WHERE 合計売上件数 <= 18" & _
                                        " ORDER BY 得意先コード,枝番"

                FillData(strSql)

            End Sub

            Public Overrides Sub AfterFillData()

                'FillDataの後処理をここに記述する
                Table.Columns.Add(New DataColumn(CLM_印刷FLG, GetType(Boolean)))

                For Each row As DataRow In Table.Rows
                    row(CLM_印刷FLG) = False
                Next

            End Sub

        End Class

#End Region

#Region "メンバー変数"

        Private mvwData As ViewData
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

            検索処理()

            mprc全選択解除(True)

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

        Private Sub btn一覧印刷_Click(sender As System.Object, e As System.EventArgs) Handles btn一覧印刷.Click
            Dim grd As GridControl = grdMain
            Dim strTitle As String = "請求一覧"

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

        Private Sub btn全選択_Click(sender As System.Object, e As System.EventArgs) Handles btn全選択.Click
            mprc全選択解除(True)
        End Sub

        Private Sub btn全解除_Click(sender As System.Object, e As System.EventArgs) Handles btn全解除.Click
            mprc全選択解除(False)
        End Sub

        Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
            If CFncMessage.MessageBox(My.Resources.MSG_レイアウトリセット, My.Resources.CAP_KAKUNIN, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                '先にCloseしないと削除できない
                Me.Close()
                'レイアウト削除
                CClsLayoutSetting.Delete(LAYOUT_NAME)
            End If
        End Sub

        Private Sub btn印刷_Click(sender As System.Object, e As System.EventArgs) Handles btn印刷.Click

            If mprcCount選択() = 0 Then
                CFncMessage.ErrorMessage("印刷する得意先を1件以上選択して下さい。")
                Return
            End If

            If CFncMessage.MessageBox("印刷を行います。ハガキ用紙を準備して下さい？", My.Resources.CAP_APPLICATION, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                Return
            End If

            Dim lstData As New List(Of ListData)

            With viewMain
                .BeginUpdate()
                For i As Integer = 0 To .RowCount - 1
                    Dim row As DataRow = .GetDataRow(i)
                    If Not IsNothing(row) Then
                        If (CFncCommon.ObjToBool(row(CLM_印刷FLG))) Then
                            With lstData
                                Dim item As New ListData
                                With item
                                    .PAGE = 1
                                    .ID = CFncCommon.ObjToInt(row("ID"))
                                    .得意先コード = CFncCommon.ObjToStr(row("得意先コード"))
                                    .枝番 = CFncCommon.ObjToInt(row("枝番"))
                                    .得意先名 = CFncCommon.ObjToStr(row("得意先名"))
                                    .郵便番号 = CFncCommon.ObjToStr(row("郵便番号"))
                                    .住所１ = CFncCommon.ObjToStr(row("住所１"))
                                    .住所２ = CFncCommon.ObjToStr(row("住所２"))
                                End With
                                .Add(item)
                                .Add(New ListData() With {.PAGE = 2, .ID = CFncCommon.ObjToInt(row("ID"))})
                            End With
                        End If
                    End If
                Next i
                .EndUpdate()
            End With

            Using rpt As New rpt締日請求書(lstData)
                Using dlg As New dlgPrintPreview(gfrmMain, rpt, "締日請求書")
                    dlg.ShowDialog()
                End Using
            End Using

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

#End Region

#Region "プライベート　メソッド"

        ''' <summary>
        ''' データゲートウェイの初期化
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcInitDataGateway()
            mvwData = New ViewData
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

            '読込み
            mvwData.Fill()
            With viewMain
                .BeginUpdate()
                .GridControl.DataSource = mvwData.Table
                .GridControl.RefreshDataSource()
                .ExpandAllGroups()
                If .RowCount > 0 Then
                    .FocusedRowHandle = 0
                End If
                .EndUpdate()
            End With

        End Sub

        Private Sub mprc全選択解除(ByVal value As Boolean)
            If Not IsNothing(mvwData.Table) Then
                With viewMain
                    .BeginUpdate()
                    For i As Integer = 0 To .RowCount - 1
                        Dim row As DataRow = .GetDataRow(i)
                        If Not IsNothing(row) Then
                            row(CLM_印刷FLG) = value
                        End If
                    Next i
                    .EndUpdate()
                End With
            End If
        End Sub

        Private Function mprcCount選択() As Integer
            Dim cnt As Integer = 0

            If Not IsNothing(mvwData.Table) Then
                With viewMain
                    .BeginUpdate()
                    For i As Integer = 0 To .RowCount - 1
                        Dim row As DataRow = .GetDataRow(i)
                        If Not IsNothing(row) Then
                            If (CFncCommon.ObjToBool(row(CLM_印刷FLG))) Then
                                cnt += 1
                            End If
                        End If
                    Next i
                    .EndUpdate()
                End With
            End If
            Return cnt
        End Function
#End Region

    End Class

End Namespace
