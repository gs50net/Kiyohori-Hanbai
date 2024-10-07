#Region "参照"

Imports System
Imports System.Data
Imports System.Data.Common

#End Region

Namespace DataBase

    ''' <summary>
    ''' DataReaderの概要の説明です。
    ''' </summary>
    ''' <remarks>DataReaderの抽象基本クラスです。
    ''' 終了時には必ず　Dispose()すること</remarks>
    Public MustInherit Class DataReader

#Region "Dispose"

        Implements IDisposable

        Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    '明示的に呼び出されたときにマネージ リソースを解放します
                End If

                If Not IsNothing(_rdr) Then
                    _rdr.Close()
                End If

                If _cnn.Connection.State = ConnectionState.Open Then
                    _cnn.Connection.Close()
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

#Region "メンバー変数"

        ''' <summary>
        ''' コネクション
        ''' </summary>
        ''' <remarks></remarks>
        Private _cnn As Connection
        ''' <summary>
        ''' コマンド
        ''' </summary>
        ''' <remarks></remarks>
        Private _cmd As DbCommand
        ''' <summary>
        ''' データリーダー
        ''' </summary>
        ''' <remarks></remarks>
        Private _rdr As DbDataReader

#End Region

#Region "プロテクト　メンバー変数"

        ''' <summary>
        ''' オープン成功
        ''' </summary>
        ''' <remarks></remarks>
        Protected _ValidOpen As Boolean = False

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' データリーダー
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property DataReader() As DbDataReader
            Get
                Return _rdr
            End Get
        End Property
        
#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="enmProvider">プロパイダーの種類</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal strConnStr As String, ByVal enmProvider As enmProvider)

            _cnn = New Connection(strConnStr, enmProvider)
            _cmd = _cnn.CreateCommand

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="cnn">コネクション</param>
        ''' <remarks>※最後にはコネクションはクローズします</remarks>
        Protected Sub New(ByVal cnn As Connection)

            _cnn = cnn
            _cmd = _cnn.CreateCommand

        End Sub

#End Region

#Region "プロテクト　メソッド"

        ''' <summary>
        ''' コネクションを生成します
        ''' </summary>
        ''' <param name="strConnStr"></param>
        ''' <param name="enmProvider"></param>
        ''' <remarks></remarks>
        Protected Sub CreateConnection(ByVal strConnStr As String, ByVal enmProvider As enmProvider)

            _cnn = New Connection(strConnStr, enmProvider)
            _cmd = _cnn.CreateCommand

        End Sub

        ''' <summary>
        ''' DataReaderをオープンします。
        ''' </summary>
        ''' <param name="strSql">SQL文</param>
        ''' <remarks></remarks>
        Protected Sub Open(ByVal strSql As String, Optional ByVal blnSequentialAccess As Boolean = False, Optional ByVal blnShowErrorMessage As Boolean = True)

            _cmd.Connection = _cnn.Connection

            Try
                _cnn.Connection.Open()
                _cmd.CommandText = strSql
                If blnSequentialAccess Then
                    _rdr = _cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                Else
                    _rdr = _cmd.ExecuteReader()
                End If
                _ValidOpen = True
            Catch ex As Exception
                If blnShowErrorMessage Then
                    MessageBox.Show(ex.Message, "DataReader.Open")
                End If
            End Try

        End Sub

#End Region

    End Class

End Namespace