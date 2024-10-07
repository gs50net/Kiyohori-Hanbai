#Region "参照"

Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase

#End Region

Namespace DataBase.MyDB

    ''' <summary>
    ''' StoredProcedureクラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MyDBStoredProcedure : Inherits StoredProcedure

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <remarks>クラスの新しいインスタンスを初期化します。</remarks>
        Public Sub New()
            MyBase.New(CClsSetting.GetInstance.pstrKHDBConn, enmProvider.SQLServer)
        End Sub

#End Region

    End Class

End Namespace