Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase
Imports Hanbai.Common.Functions
Imports Hanbai.Common.MyConst

Namespace DataBase.MyDB

    ''' <summary>
    ''' T_得意先マスター Table クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_得意先Table : Inherits MyDBDataGateway

#Region "定数"

        ''' <summary>テーブル名</summary>
        Public Const TABLE_NAME As String = "T_得意先マスター"
        Public Const ダイコロ_得意先コード As Integer = 91

#End Region

#Region "コンストラクタ"

        ''' <summary>コンストラクタ</summary>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>コンストラクタ</summary>
        ''' <remarks>更新する場合はこのコンストラクタを使用する</remarks>
        Public Sub New(ByVal dstGateway As MyDBDataSetGateway, Optional ByVal strTableName As String = "")
            MyBase.New(dstGateway, strTableName)
        End Sub

#End Region

#Region "オーバーライド　メソッド"

        ''' <summary>テーブル名を取得する</summary>
        Public Overrides Function GetTableName() As String
            Return TABLE_NAME
        End Function

#End Region

#Region "メソッド"

        Public Function FillDaikoro() As DataRow

            Dim strWhere As String = String.Format("得意先コード = {0}", ダイコロ_得意先コード)
            Dim row As DataRowCollection = Fill(strWhere)
            If IsNothing(row) Then
                Return Nothing
            Else
                Return row(0)
            End If

        End Function

#End Region

    End Class

    ''' <summary>
    ''' T_得意先マスター Row クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_得意先Row : Inherits CDataRowBase

#Region "カラム"

        Public Const CON_得意先コード As String = "得意先コード"
        Public Const CON_枝番 As String = "枝番"
        Public Const CON_得意先名 As String = "得意先名"
        Public Const CON_得意先カナ名 As String = "得意先カナ名"
        Public Const CON_郵便番号 As String = "郵便番号"
        Public Const CON_住所１ As String = "住所１"
        Public Const CON_住所２ As String = "住所２"
        Public Const CON_電話番号 As String = "電話番号"
        Public Const CON_携帯電話番号 As String = "携帯電話番号"
        Public Const CON_FAX As String = "FAX"
        Public Const CON_メールアドレス As String = "メールアドレス"
        Public Const CON_送先得意先名 As String = "送先得意先名"
        Public Const CON_送先郵便番号 As String = "送先郵便番号"
        Public Const CON_送先住所１ As String = "送先住所１"
        Public Const CON_送先住所２ As String = "送先住所２"
        Public Const CON_送先電話番号 As String = "送先電話番号"
        Public Const CON_締日 As String = "締日"
        Public Const CON_担当コード As String = "担当コード"
        Public Const CON_業種区分 As String = "業種区分"
        Public Const CON_領収区分 As String = "領収区分"
        Public Const CON_集金日 As String = "集金日"
        Public Const CON_集金月 As String = "集金月"
        Public Const CON_支払条件 As String = "支払条件"
        Public Const CON_振込電信 As String = "振込電信"
        Public Const CON_手数料負担 As String = "手数料負担"
        Public Const CON_銀行コード As String = "銀行コード"
        Public Const CON_支店コード As String = "支店コード"
        Public Const CON_手形振出銀行コード As String = "手形振出銀行コード"
        Public Const CON_手形振出支店コード As String = "手形振出支店コード"
        Public Const CON_手形振出銀行支店名 As String = "手形振出銀行支店名"
        Public Const CON_値引 As String = "値引"
        Public Const CON_歩引 As String = "歩引"
        Public Const CON_受注連番 As String = "受注連番"
        Public Const CON_伝票区分 As String = "伝票区分"
        Public Const CON_画面区分 As String = "画面区分"
        Public Const CON_税区分 As String = "税区分"
        Public Const CON_枝番あり As String = "枝番あり"
        Public Const CON_宛名1 As String = "宛名1"
        Public Const CON_宛名2 As String = "宛名2"
        Public Const CON_入金用得意先名 As String = "入金用得意先名"
        Public Const CON_振込手数料区分 As String = "振込手数料区分"
        Public Const CON_請求得意先 As String = "請求得意先"
        Public Const CON_葉書敬称 As String = "葉書敬称"
        Public Const CON_葉書不要 As String = "葉書不要"
        Public Const CON_葉書要 As String = "葉書要"
        Public Const CON_葉書今回不要 As String = "葉書今回不要"
        Public Const CON_送付方法 As String = "送付方法"
        Public Const CON_請求書印刷順位 As String = "請求書印刷順位"
        Public Const CON_受注停止 As String = "受注停止"
        Public Const CON_集金担当コード As String = "集金担当コード"
        Public Const CON_作成日 As String = "作成日"
        Public Const CON_更新日 As String = "更新日"
        Public Const CON_支払条件計算 As String = "支払条件計算"
        Public Const CON_更新者 As String = "更新者"
        Public Const CON_作成者 As String = "作成者"
        Public Const CON_S得意先コンピュータ名 As String = "S得意先コンピュータ名"
        Public Const CON_倒産 As String = "倒産"

        Public Property clm得意先コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_得意先コード))
            End Get
            Set(ByVal value As String)
                Me(CON_得意先コード) = value
            End Set
        End Property

        Public Property clm得意先名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_得意先名))
            End Get
            Set(ByVal value As String)
                Me(CON_得意先名) = value
            End Set
        End Property

        Public Property clm得意先カナ名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_得意先カナ名))
            End Get
            Set(ByVal value As String)
                Me(CON_得意先カナ名) = value
            End Set
        End Property

        Public Property clm郵便番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_郵便番号))
            End Get
            Set(ByVal value As String)
                Me(CON_郵便番号) = value
            End Set
        End Property

        Public Property clm住所１() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_住所１))
            End Get
            Set(ByVal value As String)
                Me(CON_住所１) = value
            End Set
        End Property

        Public Property clm住所２() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_住所２))
            End Get
            Set(ByVal value As String)
                Me(CON_住所２) = value
            End Set
        End Property

        Public Property clm電話番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_電話番号))
            End Get
            Set(ByVal value As String)
                Me(CON_電話番号) = value
            End Set
        End Property

        Public Property clm携帯電話番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_携帯電話番号))
            End Get
            Set(ByVal value As String)
                Me(CON_携帯電話番号) = value
            End Set
        End Property

        Public Property clmFAX() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_FAX))
            End Get
            Set(ByVal value As String)
                Me(CON_FAX) = value
            End Set
        End Property

        Public Property clmメールアドレス() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_メールアドレス))
            End Get
            Set(ByVal value As String)
                Me(CON_メールアドレス) = value
            End Set
        End Property

        Public Property clm送先得意先名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_送先得意先名))
            End Get
            Set(ByVal value As String)
                Me(CON_送先得意先名) = value
            End Set
        End Property

        Public Property clm送先郵便番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_送先郵便番号))
            End Get
            Set(ByVal value As String)
                Me(CON_送先郵便番号) = value
            End Set
        End Property

        Public Property clm送先住所１() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_送先住所１))
            End Get
            Set(ByVal value As String)
                Me(CON_送先住所１) = value
            End Set
        End Property

        Public Property clm送先住所２() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_送先住所２))
            End Get
            Set(ByVal value As String)
                Me(CON_送先住所２) = value
            End Set
        End Property

        Public Property clm送先電話番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_送先電話番号))
            End Get
            Set(ByVal value As String)
                Me(CON_送先電話番号) = value
            End Set
        End Property

        Public Property clm担当コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_担当コード))
            End Get
            Set(ByVal value As String)
                Me(CON_担当コード) = value
            End Set
        End Property

        Public Property clm業種区分() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_業種区分))
            End Get
            Set(ByVal value As String)
                Me(CON_業種区分) = value
            End Set
        End Property

        Public Property clm領収区分() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_領収区分))
            End Get
            Set(ByVal value As String)
                Me(CON_領収区分) = value
            End Set
        End Property

        Public Property clm集金日() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_集金日))
            End Get
            Set(ByVal value As String)
                Me(CON_集金日) = value
            End Set
        End Property

        Public Property clm集金月() As Integer
            Get
                Return CFncCommon.ObjToInt(Me(CON_集金月))
            End Get
            Set(ByVal value As Integer)
                Me(CON_集金月) = value
            End Set
        End Property

        Public Property clm支払条件() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_支払条件))
            End Get
            Set(ByVal value As String)
                Me(CON_支払条件) = value
            End Set
        End Property

        Public Property clm振込電信() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_振込電信))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_振込電信) = value
            End Set
        End Property

        Public Property clm手数料負担() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_手数料負担))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_手数料負担) = value
            End Set
        End Property

        Public Property clm銀行コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_銀行コード))
            End Get
            Set(ByVal value As String)
                Me(CON_銀行コード) = value
            End Set
        End Property

        Public Property clm支店コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_支店コード))
            End Get
            Set(ByVal value As String)
                Me(CON_支店コード) = value
            End Set
        End Property

        Public Property clm手形振出銀行コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_手形振出銀行コード))
            End Get
            Set(ByVal value As String)
                Me(CON_手形振出銀行コード) = value
            End Set
        End Property

        Public Property clm手形振出支店コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_手形振出支店コード))
            End Get
            Set(ByVal value As String)
                Me(CON_手形振出支店コード) = value
            End Set
        End Property

        Public Property clm手形振出銀行支店名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_手形振出銀行支店名))
            End Get
            Set(ByVal value As String)
                Me(CON_手形振出銀行支店名) = value
            End Set
        End Property

        Public Property clm値引() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_値引))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_値引) = value
            End Set
        End Property

        Public Property clm歩引() As Decimal
            Get
                Return CFncCommon.ObjToDec(Me(CON_歩引))
            End Get
            Set(ByVal value As Decimal)
                Me(CON_歩引) = value
            End Set
        End Property

        Public Property clm受注連番() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_受注連番))
            End Get
            Set(ByVal value As String)
                Me(CON_受注連番) = value
            End Set
        End Property

        Public Property clm伝票区分() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_伝票区分))
            End Get
            Set(ByVal value As String)
                Me(CON_伝票区分) = value
            End Set
        End Property

        Public Property clm画面区分() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_画面区分))
            End Get
            Set(ByVal value As String)
                Me(CON_画面区分) = value
            End Set
        End Property

        Public Property clm税区分() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_税区分))
            End Get
            Set(ByVal value As String)
                Me(CON_税区分) = value
            End Set
        End Property

        Public Property clm枝番あり() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_枝番あり))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_枝番あり) = value
            End Set
        End Property

        Public Property clm宛名1() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_宛名1))
            End Get
            Set(ByVal value As String)
                Me(CON_宛名1) = value
            End Set
        End Property

        Public Property clm宛名2() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_宛名2))
            End Get
            Set(ByVal value As String)
                Me(CON_宛名2) = value
            End Set
        End Property

        Public Property clm入金用得意先名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_入金用得意先名))
            End Get
            Set(ByVal value As String)
                Me(CON_入金用得意先名) = value
            End Set
        End Property

        Public Property clm振込手数料区分() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_振込手数料区分))
            End Get
            Set(ByVal value As String)
                Me(CON_振込手数料区分) = value
            End Set
        End Property

        Public Property clm請求得意先() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_請求得意先))
            End Get
            Set(ByVal value As String)
                Me(CON_請求得意先) = value
            End Set
        End Property

        Public Property clm葉書敬称() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_葉書敬称))
            End Get
            Set(ByVal value As String)
                Me(CON_葉書敬称) = value
            End Set
        End Property

        Public Property clm葉書不要() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_葉書不要))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_葉書不要) = value
            End Set
        End Property

        Public Property clm葉書要() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_葉書要))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_葉書要) = value
            End Set
        End Property

        Public Property clm葉書今回不要() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_葉書今回不要))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_葉書今回不要) = value
            End Set
        End Property

        Public Property clm送付方法() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_送付方法))
            End Get
            Set(ByVal value As String)
                Me(CON_送付方法) = value
            End Set
        End Property

        Public Property clm請求書印刷順位() As Integer
            Get
                Return CFncCommon.ObjToInt(Me(CON_請求書印刷順位))
            End Get
            Set(ByVal value As Integer)
                Me(CON_請求書印刷順位) = value
            End Set
        End Property

        Public Property clm受注停止() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_受注停止))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_受注停止) = value
            End Set
        End Property

        Public Property clm集金担当コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_集金担当コード))
            End Get
            Set(ByVal value As String)
                Me(CON_集金担当コード) = value
            End Set
        End Property

        Public Property clm作成日() As Object
            Get
                Return Me(CON_作成日)
            End Get
            Set(ByVal value As Object)
                Me(CON_作成日) = value
            End Set
        End Property

        Public Property clm更新日() As Object
            Get
                Return Me(CON_更新日)
            End Get
            Set(ByVal value As Object)
                Me(CON_更新日) = value
            End Set
        End Property

        Public Property clm支払条件計算() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_支払条件計算))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_支払条件計算) = value
            End Set
        End Property

        Public Property clm更新者() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_更新者))
            End Get
            Set(ByVal value As String)
                Me(CON_更新者) = value
            End Set
        End Property

        Public Property clm作成者() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_作成者))
            End Get
            Set(ByVal value As String)
                Me(CON_作成者) = value
            End Set
        End Property

        Public Property clmS得意先コンピュータ名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_S得意先コンピュータ名))
            End Get
            Set(ByVal value As String)
                Me(CON_S得意先コンピュータ名) = value
            End Set
        End Property

        Public Property clm倒産() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_倒産))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_倒産) = value
            End Set
        End Property


#End Region


#Region "コンストラクタ"

        ''' <summary>コンストラクタ</summary>
        Public Sub New()
        End Sub

        ''' <summary>コンストラクタ</summary>
        Public Sub New(ByVal row As DataRow)
            Me.DataRow = row
        End Sub

        ''' <summary>コンストラクタ</summary>
        Public Sub New(ByVal row As DataRowView)
            Me.DataRowView = row
        End Sub

#End Region

    End Class

End Namespace