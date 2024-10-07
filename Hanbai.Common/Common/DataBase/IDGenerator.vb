#Region "参照"

Imports System
Imports System.Data
Imports System.Data.Common

#End Region

Namespace DataBase

    ''' <summary>
    ''' IDGeneratorの概要の説明です。
    ''' </summary>
    ''' <remarks>※ID値はInteger型です</remarks>
    Public Class IDGenerator

#Region "定数"

        Private Const TBLID_TABLE_NAME As String = "TBL_ID"

#End Region

#Region "メンバー変数"

        ''' <summary>
        ''' コネクション
        ''' </summary>
        ''' <remarks></remarks>
        Private mCnn As Connection
        ''' <summary>
        ''' テーブル番号
        ''' </summary>
        ''' <remarks></remarks>
        Private mstrTblID As String

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="strTblID">テーブル番号</param>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="enmProvider">プロパイダーの種類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strTblID As String, ByVal strConnStr As String, ByVal enmProvider As enmProvider)

            'コネクション
            mCnn = New Connection(strConnStr, enmProvider)

            'テーブル番号
            mstrTblID = strTblID

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 次のIDを取得します
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>NEXTIDの初期値は1です</remarks>
        Public Function GetNextId() As Integer

            Try
                mCnn.Connection.Open()

                Dim transaction As DbTransaction = mprcBeginTransaction()

                Try
                    If Not mprcExistId(transaction) Then
                        mprcAddId(transaction)
                    End If
                    Dim nextId As Integer = mprcGetNextIdFrom(transaction)
                    mprcUpdateNextId(nextId, transaction)
                    transaction.Commit()
                    Return nextId

                Catch ex As Exception
                    transaction.Rollback()
                    Message.ErrorMessage(ex.Message)
                    Return -1
                End Try

            Finally
                mCnn.Connection.Close()
            End Try

        End Function

        ''' <summary>
        ''' IDを初期値設定します（NEXTIDの初期値は1です）
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub InitId()

            Try
                mCnn.Connection.Open()

                Dim transaction As DbTransaction = mprcBeginTransaction()

                Try
                    If mprcExistId(transaction) Then
                        mprcUpdateNextId(0, transaction)
                    Else
                        mprcAddId(transaction)
                    End If
                    transaction.Commit()

                Catch ex As Exception
                    transaction.Rollback()
                    Message.ErrorMessage(ex.Message)
                End Try

            Finally
                mCnn.Connection.Close()
            End Try

        End Sub

#End Region

#Region "プライベート　メソッド"

        Private Function mprcBeginTransaction() As DbTransaction

            Dim transaction As DbTransaction = Nothing

            Select Case mCnn.Provider
                Case enmProvider.MDB
                    transaction = mCnn.Connection.BeginTransaction()
                Case enmProvider.SQLServer
                    transaction = mCnn.Connection.BeginTransaction(IsolationLevel.Serializable)
            End Select

            Return transaction

        End Function

        Private Function mprcExistId(ByVal transaction As DbTransaction) As Boolean

            Dim pmf As New ParameterMakerFormat(mCnn)
            Dim sql As String = String.Format("SELECT COUNT(*) FROM {0} WHERE TBLID = {1}", _
                                                TBLID_TABLE_NAME, _
                                                pmf.GetParameterMakerFormat("@TBLID"))

            Dim command As DbCommand = mCnn.CreateCommand(sql, transaction)
            command.Parameters.Add(mCnn.CreateDbParameter("@TBLID", mstrTblID))
            Dim obj As Object = command.ExecuteScalar()
            If IsNothing(obj) Then
                Dim strMsg As String = String.Format("TBLID={0}", mstrTblID)
                Throw New Exception(strMsg)
            End If

            If CInt(obj) = 0 Then
                Return False
            Else
                Return True
            End If

        End Function

        Private Sub mprcAddId(ByVal transaction As DbTransaction)

            Dim pmf As New ParameterMakerFormat(mCnn)
            Dim sql As String = String.Format("INSERT INTO {0} (TBLID, NEXTID) VALUES({1},1)", _
                                                TBLID_TABLE_NAME, _
                                                pmf.GetParameterMakerFormat("@TBLID"))

            Dim command As DbCommand = mCnn.CreateCommand(sql, transaction)
            command.Parameters.Add(mCnn.CreateDbParameter("@TBLID", mstrTblID))
            command.ExecuteNonQuery()

        End Sub

        Private Function mprcGetNextIdFrom(ByVal transaction As DbTransaction) As Integer

            Dim pmf As New ParameterMakerFormat(mCnn)
            Dim sql As String = String.Format("SELECT NEXTID FROM {0} WHERE TBLID = {1}", _
                                            TBLID_TABLE_NAME, _
                                            pmf.GetParameterMakerFormat("@TBLID"))

            Dim command As DbCommand = mCnn.CreateCommand(sql, transaction)
            command.Parameters.Add(mCnn.CreateDbParameter("@TBLID", mstrTblID))
            Dim obj As Object = command.ExecuteScalar()
            If IsNothing(obj) Then
                Dim strMsg As String = String.Format("TBLID={0}", mstrTblID)
                Throw New Exception(strMsg)
            End If

            Return CInt(obj)

        End Function

        Private Sub mprcUpdateNextId(ByVal nextId As Integer, ByVal transaction As DbTransaction)

            Dim pmf As New ParameterMakerFormat(mCnn)
            Dim sql As String = String.Format("UPDATE {0} SET NEXTID = {1} WHERE TBLID = {2}", _
                                                TBLID_TABLE_NAME, _
                                                pmf.GetParameterMakerFormat("@NEXTID"), _
                                                pmf.GetParameterMakerFormat("@TBLID"))

            Dim command As DbCommand = mCnn.CreateCommand(sql, transaction)
            command.Parameters.Add(mCnn.CreateDbParameter("@NEXTID", nextId + 1))
            command.Parameters.Add(mCnn.CreateDbParameter("@TBLID", mstrTblID))
            Dim ret As Integer = command.ExecuteNonQuery()

        End Sub

#End Region

    End Class

End Namespace