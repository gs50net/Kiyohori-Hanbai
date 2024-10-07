#Region "参照"

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections
Imports System.Configuration

#End Region

Namespace DataBase

#Region "列挙体"

    ''' <summary>
    ''' プロバイダーの種類
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmProvider
        ''' <summary>
        ''' ACCESS OLE.DB プロバイダー(Jet 4.0 OLE DB)
        ''' </summary>
        ''' <remarks></remarks>
        MDB
        ''' <summary> 
        ''' SQL Server SQL Client.NET プロバイダー
        ''' </summary>
        ''' <remarks></remarks>
        SQLServer
    End Enum

#End Region

    ''' <summary>
    ''' Connectionの概要の説明です。
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Connection

#Region "Dispose"

        Implements IDisposable

        Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    '明示的に呼び出されたときにマネージ リソースを解放します
                End If

                If Not IsNothing(_Connection) Then
                    If _Connection.State = ConnectionState.Open Then
                        _Connection.Close()
                    End If
                    _Connection.Dispose()
                    _Connection = Nothing
                End If

            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
        Public Sub Dispose() Implements IDisposable.Dispose
            ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

#End Region

#End Region

        'プロバイダの定義
        Private Const MDB_PROVIDERNAME As String = "System.Data.OleDb"
        Private Const SQLSERVER_MDB_PROVIDERNAME As String = "System.Data.SqlClient"

#Region "メンバー変数"

        ''' <summary>
        ''' コネクション
        ''' </summary>
        ''' <remarks></remarks>
        Private _Connection As DbConnection
        ''' <summary>
        ''' DbProviderFactoryクラス
        ''' </summary>
        ''' <remarks></remarks>
        Private _Factory As DbProviderFactory
        ''' <summary>
        ''' 正常？
        ''' </summary>
        ''' <remarks></remarks>
        Private _Valid As Boolean = False

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' コネクションを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Connection() As DbConnection
            Get
                Return _Connection
            End Get
        End Property

        Private menmProvider As enmProvider
        ''' <summary>
        ''' プロパイダーの種類
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Provider() As enmProvider
            Get
                Return menmProvider
            End Get
        End Property

        ''' <summary>
        ''' 正常？
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>接続文字列が不正な場合はエラーになります</remarks>
        Public ReadOnly Property IsValid() As Boolean
            Get
                Return _Valid
            End Get
        End Property

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="enmProvider">プロパイダーの種類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strConnStr As String, ByVal enmProvider As enmProvider)

            menmProvider = enmProvider

            'プロパイダー
            Dim strProviderName As String = Nothing
            Select Case enmProvider
                Case enmProvider.MDB
                    strProviderName = MDB_PROVIDERNAME
                Case enmProvider.SQLServer
                    strProviderName = SQLSERVER_MDB_PROVIDERNAME
            End Select

            'DbProviderFactoryクラスを介してDbConnectionオブジェクト（接続）を取得
            Try
                _Factory = DbProviderFactories.GetFactory(strProviderName)
                _Connection = _Factory.CreateConnection()
                _Connection.ConnectionString = strConnStr
                _Valid = True
            Catch ex As Exception
                Message.ErrorMessage(ex.Message, "Connection.New")
            End Try

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' DbCommandオブジェクトを生成します
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CreateCommand() As DbCommand

            Dim cmd As DbCommand = _Factory.CreateCommand()
            Return cmd

        End Function

        ''' <summary>
        ''' DbCommandオブジェクトを生成します
        ''' </summary>
        ''' <param name="strCommandText">コマンドテキスト</param>
        ''' <param name="transaction">トランザクション</param>
        ''' <param name="cmdType">コマンドタイプ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CreateCommand(ByVal strCommandText As String, ByVal transaction As DbTransaction, Optional ByVal cmdType As System.Data.CommandType = CommandType.Text) As DbCommand

            Dim cmd As DbCommand = _Factory.CreateCommand()
            With cmd
                .CommandType = cmdType
                .CommandText = strCommandText
                .Transaction = transaction
                .Connection = _Connection
            End With

            Return cmd

        End Function

        ''' <summary>
        ''' DbCommandオブジェクトを生成します
        ''' </summary>
        ''' <param name="strCommandText">コマンドテキスト</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CreateCommand(ByVal strCommandText As String) As DbCommand

            Dim cmd As DbCommand = _Factory.CreateCommand()
            With cmd
                .CommandType = CommandType.Text
                .CommandText = strCommandText
                .Connection = _Connection
            End With

            Return cmd

        End Function

        ''' <summary>
        ''' DbCommandBuilderオブジェクトを生成します
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateCommandBuilder() As DbCommandBuilder

            Dim builder As DbCommandBuilder = _Factory.CreateCommandBuilder
            Return builder

        End Function

        ''' <summary>
        ''' DbDataAdapterオブジェクトを生成します
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CreateDbDataAdapter() As DbDataAdapter

            Dim adp As DbDataAdapter = _Factory.CreateDataAdapter
            Return adp

        End Function

        ''' <summary>
        ''' DbDataAdapterオブジェクトを生成します
        ''' </summary>
        ''' <param name="selectCommand">SelectCommand</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CreateDbDataAdapter(ByVal selectCommand As DbCommand) As DbDataAdapter

            Dim adp As DbDataAdapter = _Factory.CreateDataAdapter
            adp.SelectCommand = selectCommand

            Return adp

        End Function

        ''' <summary>
        ''' DbParameterオブジェクトを生成します
        ''' </summary>
        ''' <param name="strParameterName">パラメータ名</param>
        ''' <param name="obj">値</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CreateDbParameter(ByVal strParameterName As String, ByVal obj As Object) As DbParameter

            Dim prm As DbParameter = _Factory.CreateParameter
            With prm
                .ParameterName = strParameterName
                .Value = obj
            End With

            Return prm

        End Function

        ''' <summary>
        ''' DbParameterオブジェクトを生成します
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CreateDbParameter() As DbParameter

            Dim prm As DbParameter = _Factory.CreateParameter
            Return prm

        End Function

        ''' <summary>
        ''' クローズ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Close()

            Try
                If _Connection.State = ConnectionState.Open Then
                    _Connection.Close()
                End If
            Catch ex As Exception
                Message.ErrorMessage(ex.Message, "Connection.Close")
            End Try

        End Sub

#End Region

    End Class

End Namespace
