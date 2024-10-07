Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase
Imports Hanbai.Common.Functions
Imports Hanbai.Common.MyConst

Namespace DataBase.MyDB

    ''' <summary>
    ''' T200_納品入力 Table クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T200Table : Inherits MyDBDataGateway

#Region "定数"

        ''' <summary>テーブル名</summary>
        Public Const TABLE_NAME As String = "T200_納品入力"
        Public Const MAX_枝番 As Integer = 5

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

        Public Function FillByPK(ByVal str納品番号 As String, ByVal str納品枝番 As String) As DataRow

            Dim strWhere As String = String.Format("納品番号 = '{0}' AND 納品枝番 = '{1}'", str納品番号, str納品枝番)
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
    ''' T200_納品入力 Row クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T200Row : Inherits CDataRowBase

#Region "カラム"

        Public Const CON_納品番号 As String = "納品番号"
        Public Const CON_納品枝番 As String = "納品枝番"
        Public Const CON_得意先コード As String = "得意先コード"
        Public Const CON_枝番 As String = "枝番"
        Public Const CON_得意先名 As String = "得意先名"
        Public Const CON_納品日 As String = "納品日"
        Public Const CON_注文番号 As String = "注文番号"
        Public Const CON_追番 As String = "追番"
        Public Const CON_品名 As String = "品名"
        Public Const CON_棚番 As String = "棚番"
        Public Const CON_材料区分コード As String = "材料区分コード"
        Public Const CON_数量 As String = "数量"
        Public Const CON_単位 As String = "単位"
        Public Const CON_単価 As String = "単価"
        Public Const CON_金額 As String = "金額"
        Public Const CON_受注番号 As String = "受注番号"
        Public Const CON_IPAD受注番号 As String = "IPAD受注番号"
        Public Const CON_発注部門コード As String = "発注部門コード"
        Public Const CON_科目区分 As String = "科目区分"
        Public Const CON_詳細区分 As String = "詳細区分"
        Public Const CON_赤黒区分 As String = "赤黒区分"
        Public Const CON_一括印刷完了 As String = "一括印刷完了"
        Public Const CON_Sコンピュータ名 As String = "Sコンピュータ名"
        Public Const CON_面積 As String = "面積"
        Public Const CON_完成済 As String = "完成済"
        Public Const CON_完成日付 As String = "完成日付"
        Public Const CON_引取済 As String = "引取済"
        Public Const CON_引取日付 As String = "引取日付"
        Public Const CON_訂正回数 As String = "訂正回数"
        Public Const CON_作成日付 As String = "作成日付"
        Public Const CON_未受領 As String = "未受領"
        Public Const CON_外注金額 As String = "外注金額"
        Public Const CON_外注検収 As String = "外注検収"
        Public Const CON_納期1 As String = "納期1"
        Public Const CON_納期2 As String = "納期2"
        Public Const CON_値引 As String = "値引"
        Public Const CON_備考 As String = "備考"
        Public Const CON_送付方法 As String = "送付方法"
        Public Const CON_代引郵便 As String = "代引郵便"
        Public Const CON_代引佐川 As String = "代引佐川"
        Public Const CON_引取金種 As String = "引取金種"
        Public Const CON_キャンセル理由 As String = "キャンセル理由"
        Public Const CON_再販 As String = "再販"

        Public Property clm納品番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_納品番号))
            End Get
            Set(ByVal value As String)
                Me(CON_納品番号) = value
            End Set
        End Property

        Public Property clm納品枝番() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_納品枝番))
            End Get
            Set(ByVal value As String)
                Me(CON_納品枝番) = value
            End Set
        End Property

        Public Property clm枝番() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_枝番))
            End Get
            Set(ByVal value As String)
                Me(CON_枝番) = value
            End Set
        End Property

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

        Public Property clm納品日() As Object
            Get
                Return Me(CON_納品日)
            End Get
            Set(ByVal value As Object)
                Me(CON_納品日) = value
            End Set
        End Property

        Public Property clm注文番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_注文番号))
            End Get
            Set(ByVal value As String)
                Me(CON_注文番号) = value
            End Set
        End Property

        Public Property clm追番() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_追番))
            End Get
            Set(ByVal value As String)
                Me(CON_追番) = value
            End Set
        End Property

        Public Property clm品名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_品名))
            End Get
            Set(ByVal value As String)
                Me(CON_品名) = value
            End Set
        End Property

        Public Property clm棚番() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_棚番))
            End Get
            Set(ByVal value As String)
                Me(CON_棚番) = value
            End Set
        End Property

        Public Property clm材料区分コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_材料区分コード))
            End Get
            Set(ByVal value As String)
                Me(CON_材料区分コード) = value
            End Set
        End Property

        Public Property clm数量() As Integer
            Get
                Return CFncCommon.ObjToInt(Me(CON_数量))
            End Get
            Set(ByVal value As Integer)
                Me(CON_数量) = value
            End Set
        End Property

        Public Property clm単位() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_単位))
            End Get
            Set(ByVal value As String)
                Me(CON_単位) = value
            End Set
        End Property

        Public Property clm単価() As Decimal
            Get
                Return CFncCommon.ObjToDec(Me(CON_単価))
            End Get
            Set(ByVal value As Decimal)
                Me(CON_単価) = value
            End Set
        End Property

        Public Property clm金額() As Decimal
            Get
                Return CFncCommon.ObjToDec(Me(CON_金額))
            End Get
            Set(ByVal value As Decimal)
                Me(CON_金額) = value
            End Set
        End Property

        Public Property clm受注番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_受注番号))
            End Get
            Set(ByVal value As String)
                Me(CON_受注番号) = value
            End Set
        End Property

        Public Property clmIPAD受注番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_IPAD受注番号))
            End Get
            Set(ByVal value As String)
                Me(CON_IPAD受注番号) = value
            End Set
        End Property

        Public Property clm発注部門コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_発注部門コード))
            End Get
            Set(ByVal value As String)
                Me(CON_発注部門コード) = value
            End Set
        End Property

        Public Property clm科目区分() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_科目区分))
            End Get
            Set(ByVal value As String)
                Me(CON_科目区分) = value
            End Set
        End Property

        Public Property clm詳細区分() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_詳細区分))
            End Get
            Set(ByVal value As String)
                Me(CON_詳細区分) = value
            End Set
        End Property

        Public Property clm赤黒区分() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_赤黒区分))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_赤黒区分) = value
            End Set
        End Property

        Public Property clm一括印刷完了() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_一括印刷完了))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_一括印刷完了) = value
            End Set
        End Property

        Public Property clmSコンピュータ名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_Sコンピュータ名))
            End Get
            Set(ByVal value As String)
                Me(CON_Sコンピュータ名) = value
            End Set
        End Property

        Public Property clm面積() As Integer
            Get
                Return CFncCommon.ObjToInt(Me(CON_面積))
            End Get
            Set(ByVal value As Integer)
                Me(CON_面積) = value
            End Set
        End Property

        Public Property clm完成済() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_完成済))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_完成済) = value
            End Set
        End Property

        Public Property clm完成日付() As Object
            Get
                Return Me(CON_完成日付)
            End Get
            Set(ByVal value As Object)
                Me(CON_完成日付) = value
            End Set
        End Property

        Public Property clm引取済() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_引取済))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_引取済) = value
            End Set
        End Property

        Public Property clm引取日付() As Object
            Get
                Return Me(CON_引取日付)
            End Get
            Set(ByVal value As Object)
                Me(CON_引取日付) = value
            End Set
        End Property

        Public Property clm作成日付() As Object
            Get
                Return Me(CON_作成日付)
            End Get
            Set(ByVal value As Object)
                Me(CON_作成日付) = value
            End Set
        End Property

        Public Property clm訂正回数() As Integer
            Get
                Return CFncCommon.ObjToInt(Me(CON_訂正回数))
            End Get
            Set(ByVal value As Integer)
                Me(CON_訂正回数) = value
            End Set
        End Property

        Public Property clm未受領() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_未受領))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_未受領) = value
            End Set
        End Property

        Public Property clm外注金額() As Decimal
            Get
                Return CFncCommon.ObjToDec(Me(CON_外注金額))
            End Get
            Set(ByVal value As Decimal)
                Me(CON_外注金額) = value
            End Set
        End Property

        Public Property clm外注検収() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_外注検収))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_外注検収) = value
            End Set
        End Property

        Public Property clm納期1() As Object
            Get
                Return Me(CON_納期1)
            End Get
            Set(ByVal value As Object)
                Me(CON_納期1) = value
            End Set
        End Property

        Public Property clm納期2() As Object
            Get
                Return Me(CON_納期2)
            End Get
            Set(ByVal value As Object)
                Me(CON_納期2) = value
            End Set
        End Property

        Public Property clm値引() As Decimal
            Get
                Return CFncCommon.ObjToDec(Me(CON_値引))
            End Get
            Set(ByVal value As Decimal)
                Me(CON_値引) = value
            End Set
        End Property

        Public Property clm備考() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_備考))
            End Get
            Set(ByVal value As String)
                Me(CON_備考) = value
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

        Public Property clm代引郵便() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_代引郵便))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_代引郵便) = value
            End Set
        End Property

        Public Property clm代引佐川() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_代引佐川))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_代引佐川) = value
            End Set
        End Property

        Public Property clm引取金種() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_引取金種))
            End Get
            Set(ByVal value As String)
                Me(CON_引取金種) = value
            End Set
        End Property

        Public Property clmキャンセル理由() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_キャンセル理由))
            End Get
            Set(ByVal value As String)
                Me(CON_キャンセル理由) = value
            End Set
        End Property

        Public Property clm再販() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_再販))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_再販) = value
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