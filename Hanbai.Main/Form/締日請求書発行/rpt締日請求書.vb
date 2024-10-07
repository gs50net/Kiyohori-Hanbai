Imports DevExpress.XtraPrinting
Imports Hanbai.Main.Form
Imports Hanbai.Common.Functions
Imports DevExpress.XtraReports.UI

Public Class rpt締日請求書

#Region "子クラス"

    Private Class VWDetail : Inherits MyDBViewGateway

        Public Sub Fill(ByVal ID As Integer)

            Dim strSql As String = "SELECT *" & _
                                    " FROM v601_締日請求書印刷 v601"
            strSql &= String.Format(" WHERE ID = {0}", ID)
            strSql &= " ORDER BY 納品日"

            FillData(strSql)

        End Sub

    End Class

#End Region

#Region "メンバー変数"

    Private mlstMain As List(Of ListData)

#End Region

#Region "コンストラクタ"

    Public Sub New(ByVal lst As List(Of ListData))

        MyBase.New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        mlstMain = lst

    End Sub

#End Region

#Region "イベントハンドラ(コントロール)"

    Private Sub rpt締日請求書_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint

        Me.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand

        Me.DataSource = mlstMain

        If mlstMain.Count = 0 Then
            e.Cancel = True
            Return
        End If

    End Sub

    Private Sub Detail_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

        pnl顧客名.Visible = False
        pnl請求書.Visible = False

        If (mlstMain.Count - 1) >= Me.CurrentRowIndex Then
            Dim data As ListData = mlstMain(Me.CurrentRowIndex)
            Select Case data.PAGE
                Case 1
                    mprc顧客名印刷(data)
                Case 2
                    mprc請求書印刷(data.ID)
            End Select
        End If

    End Sub

#End Region

#Region "プライベート　メソッド"

    Private Sub mprc顧客名印刷(ByVal list As ListData)
        pnl顧客名.Visible = True

        With list
            cell郵便番号.Text = String.Format("〒{0}", .郵便番号)
            cell住所1.Text = .住所１
            cell住所2.Text = .住所２
            cell得意先名.Text = .得意先名
        End With

    End Sub

    Private Sub mprc請求書印刷(ByVal ID As Integer)
        pnl請求書.Visible = True

        Dim detail As New VWDetail
        detail.Fill(ID)
        If detail.Count = 0 Then
            Return
        End If

        Dim row As DataRow = detail(0)

        lbl得意先コード.Text = CFncCommon.ObjToStr(row("得意先コード"))
        lbl得意先名.Text = String.Format("{0} 様", CFncCommon.ObjToStr(row("得意先名")).Trim)

        cell合計請求額.Text = String.Format("\{0:###,###,##0}", CFncCommon.ObjToDec(row("今回請求金額")))
        cell前月合計請求額.Text = String.Format("\{0:###,###,##0}", CFncCommon.ObjToDec(row("前回請求金額")))
        cell入金額.Text = String.Format("\{0:###,###,##0}", CFncCommon.ObjToDec(row("入金金額")))
        cell繰越残高.Text = String.Format("\{0:###,###,##0}", CFncCommon.ObjToDec(row("前回繰越金額")))
        cell当月売上.Text = String.Format("\{0:###,###,##0}", CFncCommon.ObjToDec(row("今回売上金額")))
        cell消費税.Text = String.Format("\{0:###,###,##0}", CFncCommon.ObjToDec(row("消費税")))
        Dim dec当月請求 As Decimal = CFncCommon.ObjToDec(row("今回売上金額")) + CFncCommon.ObjToDec(row("消費税"))
        cell当月請求.Text = String.Format("\{0:###,###,##0}", dec当月請求)

        Dim int合計件数 As Integer = 0
        Dim dec合計金額 As Decimal = 0
        Dim dec合計消費税 As Decimal = 0

        mprcClearDetail(tbl明細)

        Dim intMax件数 As Integer = detail.Count
        If intMax件数 > 18 Then
            intMax件数 = 18
            CFncMessage.MessageBox(String.Format("{0} 件数オーバー", cell得意先名.Text), My.Resources.CAP_ERROR)
        End If

        For idx As Integer = 0 To intMax件数 - 1
            row = detail(idx)
            If Not IsDBNull(row("納品日")) Then
                Dim xrRow As XRTableRow = tbl明細.Rows(idx)
                With xrRow
                    .Cells(String.Format("cell年月日{0}", idx + 1)).Text = String.Format("{0:yyyy/M/d}", row("納品日"))
                    .Cells(String.Format("cell伝票番号{0}", idx + 1)).Text = CFncCommon.ObjToStr(row("納品番号"))
                    .Cells(String.Format("cell枝番{0}", idx + 1)).Text = CFncCommon.ObjToStr(row("納品枝番"))
                    .Cells(String.Format("cell品名{0}", idx + 1)).Text = CFncCommon.ObjToStr(row("品名"))
                    .Cells(String.Format("cell材料区分{0}", idx + 1)).Text = CFncCommon.ObjToStr(row("材料名"))
                    .Cells(String.Format("cell個数{0}", idx + 1)).Text = CFncCommon.ObjToStr(row("数量"))
                    Dim dec金額 As Decimal = CFncCommon.ObjToDec(row("金額"))
                    .Cells(String.Format("cell金額{0}", idx + 1)).Text = String.Format("\{0:###,###,##0}", dec金額)
                    Dim dec消費税 As Decimal = CFncCommon.ObjToDec(row("消費税"))

                    int合計件数 += 1
                    dec合計金額 += dec金額
                    dec合計消費税 = dec消費税
                End With
            End If
        Next idx

        If int合計件数 > 0 Then
            Dim gtRow As XRTableRow = tbl明細.Rows(int合計件数 + 1)
            With gtRow
                Dim str合計 As String = String.Format("合計： {0}件　10%対象　　 \{1:###,###,##0}　　10%消費税　　　 \{2:###,###,##0}", int合計件数, dec合計金額, dec合計消費税)
                .Cells(3).Text = str合計
            End With
        End If

    End Sub

    Private Sub mprcClearDetail(ByVal tbl As XRTable)
        For i As Integer = 0 To tbl.Rows.Count - 1
            For j As Integer = 0 To tbl.Rows(i).Cells.Count - 1
                With tbl.Rows(i).Cells(j)
                    'If IsNothing(.Tag) OrElse CStr(.Tag) = String.Empty Then
                    .Text = String.Empty
                    'End If
                End With
            Next j
        Next i
    End Sub

#End Region

End Class

