#Region "参照"

Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase

#End Region

Namespace DataBase.MyDB

    ''' <summary>
    ''' Query 抽象クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MyDBQuery : Inherits Query

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <remarks>クラスの新しいインスタンスを初期化します。</remarks>
        Public Sub New()
            MyBase.New(CClsSetting.GetInstance.pstrKHDBConn, enmProvider.SQLServer)
        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strSql">SQL文</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strSql As String)

            MyBase.New(CClsSetting.GetInstance.pstrKHDBConn, enmProvider.SQLServer)

            Open(strSql)

        End Sub

#End Region

    End Class

End Namespace