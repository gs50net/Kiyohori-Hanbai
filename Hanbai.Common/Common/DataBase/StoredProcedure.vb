#Region "参照"

Imports System
Imports System.Data
Imports System.Data.Common

#End Region

Namespace DataBase

    ''' <summary>
    ''' ストアドプロシジャー　クラス
    ''' </summary>
    ''' <remarks>クエリーの抽象基本クラスです。
    ''' 必ず usingを使用すること</remarks>
    ''' <example>
    ''' <code>
    ''' Using sp As New StoredProcedure("select * from T001")
    '''      dim rdr as SqlDataReader = sp.ExecuteReader
    '''      While rdr.Read
    '''         ･･････
    '''      end while
    ''' end using
    ''' </code>
    ''' <code>
    ''' Using sp As New StoredProcedure("sp_Test")
    '''      dim rdr as SqlDataReader = sp.ExecuteReader
    '''      While rdr.Read
    '''         ･･････
    '''      end while
    ''' end using
    ''' </code>
    ''' <code>
    ''' Using sp As New StoredProcedure("sp_Test")
    ''' 
    '''       sp.Execute
    '''       ･･････
    '''       ･･････
    ''' 
    ''' end using
    ''' </code>
    ''' </example>
    Public Class StoredProcedure

#Region "Dispose"

        Implements IDisposable

        Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    '明示的に呼び出されたときにマネージ リソースを解放します
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

#Region "定数"

        Private SQL_BATCH_COMMAND() As String = {"GO"}

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
        ''' エラーメッセージ
        ''' </summary>
        ''' <remarks></remarks>
        Private mstrErrorMessage As String
        ''' <summary>
        ''' エラーメッセージを表示？
        ''' </summary>
        ''' <remarks></remarks>
        Private mblnShowErrorMessage As Boolean

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' コマンド
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property cmd() As DbCommand
            Get
                Return _cmd
            End Get
        End Property
        ''' <summary>
        ''' エラーメッセージ
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return mstrErrorMessage
            End Get
        End Property
        ''' <summary>
        ''' エラーメッセージを表示？(既定値はTrue)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShowErrorMessage() As Boolean
            Get
                Return mblnShowErrorMessage
            End Get
            Set(ByVal value As Boolean)
                mblnShowErrorMessage = value
            End Set
        End Property

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="cnn">コネクション</param>
        ''' <param name="blnShowErrorMessage">エラーメッセージを表示？</param>
        ''' <remarks>※最後にはコネクションはクローズします</remarks>
        Public Sub New(ByVal cnn As Connection, Optional ByVal blnShowErrorMessage As Boolean = True)

            'コネクション
            _cnn = cnn

            '初期処理
            mprcInit(blnShowErrorMessage)

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="enmProvider">プロパイダーの種類</param>
        ''' <param name="blnShowErrorMessage">エラーメッセージを表示？</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strConnStr As String, ByVal enmProvider As enmProvider, Optional ByVal blnShowErrorMessage As Boolean = True)

            'コネクション
            _cnn = New Connection(strConnStr, enmProvider)

            '初期処理
            mprcInit(blnShowErrorMessage)

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strText">コマンドテキスト</param>
        ''' <param name="cnn">コネクション</param> 
        ''' <param name="blnShowErrorMessage">エラーメッセージを表示？</param>
        ''' <remarks>※最後にはコネクションはクローズします</remarks>
        Public Sub New(ByVal strText As String, _
                       ByVal cnn As Connection, _
                       Optional ByVal blnShowErrorMessage As Boolean = True)

            'コネクション
            _cnn = cnn

            '初期処理
            mprcInit(blnShowErrorMessage)

            With _cmd
                .CommandType = CommandType.Text
                .CommandText = strText
            End With

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strText">コマンドテキスト</param>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="enmProvider">プロパイダーの種類</param>
        ''' <param name="blnShowErrorMessage">エラーメッセージを表示？</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strText As String, _
                       ByVal strConnStr As String, _
                       Optional ByVal enmProvider As enmProvider = enmProvider.MDB, _
                       Optional ByVal blnShowErrorMessage As Boolean = True)

            'コネクション
            _cnn = New Connection(strConnStr, enmProvider)

            '初期処理
            mprcInit(blnShowErrorMessage)

            With _cmd
                .CommandType = CommandType.Text
                .CommandText = strText
            End With

        End Sub

#End Region

#Region "プライベート　メソッド"

        ''' <summary>
        ''' 初期処理
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcInit(ByVal blnShowErrorMessage As Boolean)

            _cmd = _cnn.CreateCommand

            With _cmd
                .Connection = _cnn.Connection
            End With

            mblnShowErrorMessage = blnShowErrorMessage

        End Sub

        ''' <summary>
        ''' エラーメッセージ処理
        ''' </summary>
        ''' <param name="ex"></param>
        ''' <remarks></remarks>
        Private Sub mprcErrorMessage(ByVal ex As Exception)

            mstrErrorMessage = ex.Message

            If mblnShowErrorMessage Then
                Message.ErrorMessage(ex.Message, "StoredProcedure")
            End If

        End Sub

        ''' <summary>
        ''' コネクションをオープンする
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcOpenConnection()

            With _cnn.Connection
                If .State = ConnectionState.Closed Then
                    .Open()
                End If
            End With

        End Sub

        ''' <summary>
        ''' ExecuteReader
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcExecuteReader() As DbDataReader

            Try
                mprcOpenConnection()
                Dim rdr As DbDataReader = _cmd.ExecuteReader
                Return rdr
            Catch ex As Exception
                mprcErrorMessage(ex)
                Return Nothing
            End Try

        End Function

        ''' <summary>
        ''' ExecuteNonQuery
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcExecNonQuery() As Boolean

            Try
                mprcOpenConnection()
                _cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception(ex.Message)
                'mprcErrorMessage(ex)
                'Return False
            End Try

            Return True

        End Function

        ''' <summary>
        ''' SQL文を実行する
        ''' </summary>
        ''' <param name="strSQL"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcExecSQL(ByVal strSQL As String) As Boolean

            With _cmd
                .CommandType = CommandType.Text
                .CommandText = strSQL
            End With

            Return mprcExecNonQuery()

        End Function

#End Region

#Region "メソッド"

        ''' <summary>
        ''' ストアドプロシジャーを実行し、DataReaderを取得します
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecuteReader() As DbDataReader

            Return mprcExecuteReader()

        End Function

        ''' <summary>
        ''' ストアドプロシジャーを実行
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Execute() As Boolean

            Return mprcExecNonQuery()

        End Function

        ''' <summary>
        ''' ＳＱＬ文を実行
        ''' </summary>
        ''' <param name="strSQL">SQL文</param>
        ''' <param name="blnGo">Go文を解析する</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecuteSQL(ByVal strSQL As String, _
                                   Optional ByVal blnGo As Boolean = False) As Boolean

            Dim blnRet As Boolean
            If blnGo Then
                'Go文が含まれている場合
                Dim strText() As String = strSQL.Split(SQL_BATCH_COMMAND, StringSplitOptions.RemoveEmptyEntries)
                For i As Integer = 0 To strText.Length - 1
                    blnRet = mprcExecSQL(strText(i))
                    If Not blnRet Then
                        Exit For
                    End If
                Next i
            Else
                blnRet = mprcExecSQL(strSQL)
            End If

            Return blnRet

        End Function

#End Region

    End Class

End Namespace