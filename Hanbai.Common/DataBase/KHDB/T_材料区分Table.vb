Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase
Imports Hanbai.Common.Functions
Imports Hanbai.Common.MyConst

Namespace DataBase.MyDB

    ''' <summary>
    ''' T_材料区分マスター Table クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_材料区分Table : Inherits MyDBDataGateway

#Region "定数"

        ''' <summary>テーブル名</summary>
        Public Const TABLE_NAME As String = "T_材料区分マスター"

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

#End Region

    End Class

    ''' <summary>
    ''' T_材料区分マスター Row クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_材料区分Row : Inherits CDataRowBase

#Region "カラム"

        Public Const CON_材料区分コード As String = "材料区分コード"
        Public Const CON_材料名 As String = "材料名"
        Public Const CON_外注発注区分 As String = "外注発注区分"

        Public Property clm材料区分コード() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_材料区分コード))
            End Get
            Set(ByVal value As String)
                Me(CON_材料区分コード) = value
            End Set
        End Property

        Public Property clm材料名() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_材料名))
            End Get
            Set(ByVal value As String)
                Me(CON_材料名) = value
            End Set
        End Property

        Public Property clm外注発注区分() As Boolean
            Get
                Return CFncCommon.ObjToBool(Me(CON_外注発注区分))
            End Get
            Set(ByVal value As Boolean)
                Me(CON_外注発注区分) = value
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
