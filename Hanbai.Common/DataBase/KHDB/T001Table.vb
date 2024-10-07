Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase
Imports Hanbai.Common.Functions
Imports Hanbai.Common.MyConst

Namespace DataBase.MyDB

    ''' <summary>
    ''' T001_システム設定 Table クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T001Table : Inherits MyDBDataGateway

#Region "定数"

        ''' <summary>テーブル名</summary>
        Public Const TABLE_NAME As String = "T001_システム設定"

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

        Public Function FillByPK() As DataRow

            Dim strWhere As String = "ID = 98"
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
    ''' T001_システム設定 Row クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T001Row : Inherits CDataRowBase

#Region "カラム"

        Public Const CON_ID As String = "ID"
        Public Const CON_年 As String = "年"
        Public Const CON_月 As String = "月"
        Public Const CON_受注先頭文字 As String = "受注先頭文字"
        Public Const CON_受注番号 As String = "受注番号"
        Public Const CON_現金納品先頭文字 As String = "現金納品先頭文字"
        Public Const CON_現金納品番号 As String = "現金納品番号"
        Public Const CON_掛売納品先頭文字 As String = "掛売納品先頭文字"
        Public Const CON_掛売納品番号 As String = "掛売納品番号"
        Public Const CON_専用納品先頭文字 As String = "専用納品先頭文字"
        Public Const CON_専用納品番号 As String = "専用納品番号"
        Public Const CON_入金先頭文字 As String = "入金先頭文字"
        Public Const CON_入金番号 As String = "入金番号"
        Public Const CON_見積先頭文字 As String = "見積先頭文字"
        Public Const CON_見積番号 As String = "見積番号"
        Public Const CON_発注先頭文字 As String = "発注先頭文字"
        Public Const CON_発注番号 As String = "発注番号"
        Public Const CON_外注先頭文字 As String = "外注先頭文字"
        Public Const CON_外注番号 As String = "外注番号"
        Public Const CON_仕訳伝票NO As String = "仕訳伝票NO"
        Public Const CON_現金入金先頭文字 As String = "現金入金先頭文字"
        Public Const CON_現金入金番号 As String = "現金入金番号"
        Public Const CON_振込入金先頭文字 As String = "振込入金先頭文字"
        Public Const CON_振込入金番号 As String = "振込入金番号"
        Public Const CON_集金入金先頭文字 As String = "集金入金先頭文字"
        Public Const CON_集金入金番号 As String = "集金入金番号"

        Public Property clm年() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_年))
            End Get
            Set(ByVal value As String)
                Me(CON_年) = value
            End Set
        End Property

        Public Property clm月() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_月))
            End Get
            Set(ByVal value As String)
                Me(CON_月) = value
            End Set
        End Property

        Public Property clm受注先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_受注先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_受注先頭文字) = value
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

        Public Property clm現金納品先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_現金納品先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_現金納品先頭文字) = value
            End Set
        End Property

        Public Property clm現金納品番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_現金納品番号))
            End Get
            Set(ByVal value As String)
                Me(CON_現金納品番号) = value
            End Set
        End Property

        Public Property clm掛売納品先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_掛売納品先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_掛売納品先頭文字) = value
            End Set
        End Property

        Public Property clm掛売納品番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_掛売納品番号))
            End Get
            Set(ByVal value As String)
                Me(CON_掛売納品番号) = value
            End Set
        End Property

        Public Property clm専用納品先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_専用納品先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_専用納品先頭文字) = value
            End Set
        End Property

        Public Property clm専用納品番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_専用納品番号))
            End Get
            Set(ByVal value As String)
                Me(CON_専用納品番号) = value
            End Set
        End Property

        Public Property clm入金先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_入金先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_入金先頭文字) = value
            End Set
        End Property

        Public Property clm入金番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_入金番号))
            End Get
            Set(ByVal value As String)
                Me(CON_入金番号) = value
            End Set
        End Property

        Public Property clm見積先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_見積先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_見積先頭文字) = value
            End Set
        End Property

        Public Property clm見積番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_見積番号))
            End Get
            Set(ByVal value As String)
                Me(CON_見積番号) = value
            End Set
        End Property

        Public Property clm発注先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_発注先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_発注先頭文字) = value
            End Set
        End Property

        Public Property clm発注番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_発注番号))
            End Get
            Set(ByVal value As String)
                Me(CON_発注番号) = value
            End Set
        End Property

        Public Property clm外注先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_外注先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_外注先頭文字) = value
            End Set
        End Property

        Public Property clm外注番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_外注番号))
            End Get
            Set(ByVal value As String)
                Me(CON_外注番号) = value
            End Set
        End Property

        Public Property clm仕訳伝票NO() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_仕訳伝票NO))
            End Get
            Set(ByVal value As String)
                Me(CON_仕訳伝票NO) = value
            End Set
        End Property

        Public Property clm現金入金先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_現金入金先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_現金入金先頭文字) = value
            End Set
        End Property

        Public Property clm現金入金番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_現金入金番号))
            End Get
            Set(ByVal value As String)
                Me(CON_現金入金番号) = value
            End Set
        End Property

        Public Property clm振込入金先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_振込入金先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_振込入金先頭文字) = value
            End Set
        End Property

        Public Property clm振込入金番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_振込入金番号))
            End Get
            Set(ByVal value As String)
                Me(CON_振込入金番号) = value
            End Set
        End Property

        Public Property clm集金入金先頭文字() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_集金入金先頭文字))
            End Get
            Set(ByVal value As String)
                Me(CON_集金入金先頭文字) = value
            End Set
        End Property

        Public Property clm集金入金番号() As String
            Get
                Return CFncCommon.ObjToStr(Me(CON_集金入金番号))
            End Get
            Set(ByVal value As String)
                Me(CON_集金入金番号) = value
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
