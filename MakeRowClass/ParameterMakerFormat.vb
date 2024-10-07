Namespace DataBase

    ''' <summary>
    ''' パラメータクエリーに引き渡すパラメータマーカを生成する　クラス
    ''' </summary>
    ''' <remarks>
    ''' ※　ACCESSをを使用時には、SQL文中のパラメータの順序とcommand.Parameters.Addの順序を一致させること
    ''' </remarks>
    Public Class ParameterMakerFormat

#Region "メンバー変数"

        ''' <summary>
        ''' プロバイダーの種類
        ''' </summary>
        ''' <remarks></remarks>
        Private menmProvider As enmProvider

#End Region

#Region "コンストラクタ"

        ''' <summary>
        '''  コンストラクタです。
        ''' </summary>
        ''' <param name="Provider">プロバイダーの種類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Provider As enmProvider)

            menmProvider = Provider

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="cnn">コネクション</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal cnn As Connection)

            menmProvider = cnn.Provider

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' パラメータマーカを生成します
        ''' </summary>
        ''' <param name="strParameterName">パラーメーター名</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetParameterMakerFormat(ByVal strParameterName As String) As String

            Select Case menmProvider
                Case enmProvider.MDB
                    Return "?"
                Case enmProvider.SQLServer
                    Return strParameterName
                Case Else
                    Return strParameterName
            End Select

        End Function

#End Region

    End Class

End Namespace