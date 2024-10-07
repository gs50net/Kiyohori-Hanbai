#Region "参照"

Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase

#End Region

Namespace DataBase.MyDB

    ''' <summary>
    ''' ViewGateway抽象クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MyDBViewGateway : Inherits ViewGateway

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <remarks>クラスの新しいインスタンスを初期化します。</remarks>
        Protected Sub New()
            MyBase.New(CClsSetting.GetInstance.pstrKHDBConn, enmProvider.SQLServer)
        End Sub

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' RowをIndexにより取得する.
        ''' </summary>
        ''' <param name="index"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Default Public ReadOnly Property Item(ByVal index As Integer) As DataRow
            Get
                Return Me.Table.Rows(index)
            End Get
        End Property

#End Region

    End Class

End Namespace
