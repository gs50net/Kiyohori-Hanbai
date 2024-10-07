#Region "参照"

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections
Imports System.Configuration

#End Region

Namespace DataBase

    ''' <summary>
    ''' DataSetGateway の概要の説明です。
    ''' </summary>
    ''' <remarks>
    ''' データーセットゲートウェイのクラスです。
    ''' </remarks>
    Public Class DataSetGateway

#Region "メンバー変数"

        Private _Data As DataSet = New DataSet                  'データーセット
        Private _dataAdapters As Hashtable = New Hashtable      'データアダプターのハッシュテーブル
        Private _Cnn As Connection                              'コネクション

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="enmProvider">プロパイダーの種類</param> 
        ''' <param name="EnforceConstraints">制約規則？</param>
        ''' <remarks>
        ''' クラスの新しいインスタンスを初期化します。
        ''' </remarks>
        Public Sub New(ByVal strConnStr As String, ByVal enmProvider As enmProvider, Optional ByVal EnforceConstraints As Boolean = True)

            '初期処理
            mprcInit(EnforceConstraints)

            'コネクション
            _Cnn = New Connection(strConnStr, enmProvider)

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="cnn">コネクション</param>
        ''' <param name="EnforceConstraints">制約規則？</param>
        ''' <remarks>※最後にはコネクションはクローズします</remarks>
        Public Sub New(ByVal cnn As Connection, Optional ByVal EnforceConstraints As Boolean = True)

            '初期処理
            mprcInit(EnforceConstraints)

            'コネクション
            _Cnn = cnn

        End Sub

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' 対象となるデータテーブルを取得します。
        ''' </summary>
        ''' <param name="tableName">テーブル名</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Default Public ReadOnly Property Item(ByVal tableName As String) As DataTable
            Get
                Return _Data.Tables(tableName)
            End Get
        End Property
        ''' <summary>
        ''' データーセットを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataSet() As DataSet
            Get
                Return _Data
            End Get
        End Property
        ''' <summary>
        ''' データーアダプターを取得します。
        ''' </summary>
        ''' <param name="tableName">テーブル名</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataAdapter(ByVal tableName As String) As DbDataAdapter
            Get
                Dim adapter As DbDataAdapter
                adapter = DirectCast(_dataAdapters(tableName), DbDataAdapter)
                Return adapter
            End Get
        End Property
        ''' <summary>
        ''' DBコネクションを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DBConnection() As DbConnection
            Get
                Return _Cnn.Connection
            End Get
        End Property
        ''' <summary>
        ''' コネクションを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Connection() As Connection
            Get
                Return _Cnn
            End Get
        End Property

        Private mConflictOption As ConflictOption = ConflictOption.CompareAllSearchableValues
        ''' <summary>
        ''' データ ソースに対する変更が競合していることを検出して解決する方法
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pConflictOption() As ConflictOption
            Get
                Return mConflictOption
            End Get
            Set(ByVal value As ConflictOption)
                mConflictOption = value
            End Set
        End Property

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 対象テーブルにデータを読み込みます。
        ''' </summary>
        ''' <param name="tableName">テーブル名</param>
        ''' <param name="commandText">クエリ文字列</param>
        ''' <remarks>
        ''' 指定したテーブルから指定したクエリ文字列によって取得されるデータを読み込みます。
        ''' データ読み込みの行われたテーブルは内部で登録されます。
        ''' </remarks>
        Public Overloads Function FillData(ByVal tableName As String, ByVal commandText As String) As Boolean

            Dim cmd As DbCommand = _Cnn.CreateCommand(commandText)
            Return FillData(tableName, cmd)

        End Function

        ''' <summary>
        ''' 対象テーブルにデータを読み込みます。
        ''' </summary>
        ''' <param name="tableName">テーブル名</param>
        ''' <param name="selectCommand">データ読み込み用のコマンド</param>
        ''' <remarks>
        ''' 指定したテーブルから指定した
        ''' <see cref="System.Data.SqlClient.SqlCommand">SqlCommand</see>クラスのインスタンス
        ''' によって取得されるデータを読み込みます。
        ''' データ読み込みの行われたテーブルは内部で登録されます。
        ''' </remarks>
        Public Overloads Function FillData(ByVal tableName As String, ByVal selectCommand As DbCommand) As Boolean

            '既にDataTableが存在する場合はClearする
            If _dataAdapters.Contains(tableName) Then
                'Throw New MultipleLoadException(My.Resources.ERR_MULTIPLE_LOAD)
                Dim tbl As DataTable = _Data.Tables(tableName)
                tbl.Clear()
            End If

            Dim bln As Boolean = False

            Try
                _Cnn.Connection.Open()
                selectCommand.Connection = _Cnn.Connection
                mprcFillDataSet(tableName, selectCommand)
                bln = True
            Catch ex As Exception
                Message.ErrorMessage(ex.Message, "DataSetGateway.FillData")
            Finally
                _Cnn.Connection.Close()
            End Try

            Return bln

        End Function

        ''' <summary>
        ''' データーセット内の全テーブルを更新します。
        ''' </summary>
        ''' <param name="intBatchSize">バッチサイズ(バッチ更新の場合は100ぐらいを指定するとよい)</param>
        ''' <remarks>
        ''' 登録されている全てのテーブルに対して、更新処理を実行します。
        ''' 更新時にはローカルトランザクションが使用されます。
        ''' </remarks>
        Public Sub Update(Optional ByVal intBatchSize As Integer = 1)

            'Updateの前処理
            BeforeUpdate()

            Try
                _Cnn.Connection.Open()

                Dim transaction As DbTransaction = _Cnn.Connection.BeginTransaction(IsolationLevel.ReadCommitted)

                Try
                    'データーセット内の全テーブルを更新します
                    UpdateDataSet(transaction, intBatchSize)

                    transaction.Commit()
                    DataSet.AcceptChanges()
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try

            Finally
                _Cnn.Connection.Close()
            End Try

            'Updateの後処理
            AfterUpdate()

        End Sub

        ''' <summary>
        ''' データーテーブルを削除します
        ''' </summary>
        ''' <param name="strTblName">テーブル名</param>
        ''' <remarks></remarks>
        Public Sub RemoveTable(ByVal strTblName As String)

            If _dataAdapters.Contains(strTblName) Then
                _Data.Tables.Remove(strTblName)
                _dataAdapters.Remove(strTblName)
            End If

        End Sub

        ''' <summary>
        ''' リレーションを削除します
        ''' </summary>
        ''' <param name="strRelationName">リレーション名</param>
        ''' <remarks></remarks>
        Public Sub RemoveRelation(ByVal strRelationName As String)

            If _Data.Relations.Contains(strRelationName) Then
                _Data.Relations.Remove(strRelationName)
            End If

        End Sub

        ''' <summary>
        ''' リレーションを追加する
        ''' </summary>
        ''' <param name="strRelationName">リレーション名</param>
        ''' <param name="clmParent">親カラム</param>
        ''' <param name="clmChild">子カラム</param>
        ''' <remarks></remarks>
        Public Sub AddRelation(ByVal strRelationName As String, _
                               ByVal clmParent As DataColumn, _
                               ByVal clmChild As DataColumn)

            Dim rel As New DataRelation(strRelationName, clmParent, clmChild)
            _Data.Relations.Add(rel)

        End Sub

        ''' <summary>
        ''' 主キーを生成する
        ''' </summary>
        ''' <param name="strTblName">テーブル名</param>
        ''' <param name="aclmName">カラム名配列</param>
        ''' <remarks></remarks>
        Public Sub CreatePrimaryKey(ByVal strTblName As String, ByVal aclmName() As String)

            If _Data.Tables.Contains(strTblName) Then

                Dim tbl As DataTable = _Data.Tables(strTblName)
                If Not IsNothing(tbl) Then
                    Dim aClm(aclmName.Length - 1) As DataColumn
                    For i As Integer = 0 To aclmName.Length - 1
                        aClm(i) = tbl.Columns.Item(aclmName(i))
                    Next i
                    tbl.PrimaryKey = aClm
                Else
                    Message.ErrorMessage(strTblName & " Error", "DataSetGateway.CreatePrimaryKey")
                End If

            End If

        End Sub

        ''' <summary>
        ''' 対象テーブルにデータを読み込みます。(ViewGateway用)
        ''' </summary>
        ''' <param name="tableName">テーブル名</param>
        ''' <param name="commandText">クエリ文字列</param>
        ''' <remarks>
        ''' 指定したテーブルから指定したクエリ文字列によって取得されるデータを読み込みます。
        ''' データ読み込みの行われたテーブルは内部で登録されます。
        ''' PrimaryKey等の制約は生成しません
        ''' </remarks>
        Public Sub FillViewData(ByVal tableName As String, ByVal commandText As String)

            Dim selectCommand As DbCommand = _Cnn.CreateCommand()
            selectCommand.CommandText = commandText

            Try
                _Cnn.Connection.Open()
                selectCommand.Connection = _Cnn.Connection

                'データアダプターを生成する
                Dim adapter As DbDataAdapter = _Cnn.CreateDbDataAdapter(selectCommand)

                'PrimaryKeyを生成しないようにする
                'adapter.FillSchema(Data, SchemaType.Mapped, tableName)
                adapter.Fill(_Data, tableName)

                If Not _dataAdapters.Contains(tableName) Then
                    _dataAdapters.Add(tableName, adapter)
                End If

            Catch ex As Exception
                '2013/12/26 
                'Message.ErrorMessage(ex.Message, "DataSetGateway.FillViewData")
            Finally
                _Cnn.Connection.Close()
            End Try

        End Sub

        ''' <summary>
        ''' DbCommandオブジェクトを生成します
        ''' </summary>
        ''' <param name="strCommandText">コマンドテキスト</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateCommand(ByVal strCommandText As String) As DbCommand

            Return _Cnn.CreateCommand(strCommandText)

        End Function

        'Public Function FillStoredPruceduer(ByVal tableName As String, ByVal selectCommand As DbCommand) As Boolean

        '    '既にDataTableが存在する場合はClearする
        '    If _dataAdapters.Contains(tableName) Then
        '        'Throw New MultipleLoadException(My.Resources.ERR_MULTIPLE_LOAD)
        '        Dim tbl As DataTable = _Data.Tables(tableName)
        '        tbl.Clear()
        '    End If

        '    Dim bln As Boolean = False

        '    Try
        '        _Cnn.Connection.Open()
        '        selectCommand.Connection = _Cnn.Connection

        '        'データアダプターを生成する
        '        Dim adapter As DbDataAdapter = _Cnn.CreateDbDataAdapter(selectCommand)

        '        'スキーマーを正しく読み込む為にFillSchemaを行う
        '        adapter.FillSchema(_Data, SchemaType.Mapped, tableName)
        '        adapter.Fill(_Data, tableName)
        '        If Not _dataAdapters.Contains(tableName) Then
        '            _dataAdapters.Add(tableName, adapter)
        '        End If

        '        bln = True
        '    Catch ex As Exception
        '        Message.ErrorMessage(ex.Message, "DataSetGateway.FillStoredPruceduer")
        '    Finally
        '        _Cnn.Connection.Close()
        '    End Try

        '    Return bln

        'End Function

#End Region

#Region "プロテクト　メソッド"

        ''' <summary>
        ''' テーブルアダプターを取得します
        ''' </summary>
        ''' <param name="strTblName">テーブル名</param>
        ''' <param name="transaction">トランザクション</param>
        ''' <returns>テーブルアダプター</returns>
        ''' <remarks></remarks>
        Protected Function GetAdapter(ByVal strTblName As String, ByVal transaction As DbTransaction, Optional ByVal intBatchSize As Integer = 1) As DbDataAdapter

            'トランザクション処理をしているのでコマンドとコマンドビルダーを再作成する
            Dim sda As DbDataAdapter = DataAdapter(strTblName)
            mprcReCommandBuilder(sda, transaction, intBatchSize)
            Return sda

        End Function

        ''' <summary>
        ''' テーブルアダプターからテーブルを更新します
        ''' </summary>
        ''' <param name="tbl">データテーブル</param>
        ''' <param name="sda">テーブルアダプター</param>
        ''' <param name="rowState">DataRowState</param>
        ''' <remarks></remarks>
        Protected Sub UpdateDataTable(ByVal tbl As DataTable, ByVal sda As DbDataAdapter, ByVal rowState As DataRowState)

            '
            'リレーションがある場合にエラーが発生するのでエラー処理をしない
            '
            Try
                Dim stb As DataTable = tbl.GetChanges(rowState)
                If stb IsNot Nothing Then
                    sda.Update(stb)
                    stb.Dispose()
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                Throw ex
                'Throw New DataException(ex.Message)
            End Try

        End Sub

#End Region

#Region "プライベート　メソッド"

        ''' <summary>
        ''' 初期処理
        ''' </summary>
        ''' <param name="EnforceConstraints"></param>
        ''' <remarks></remarks>
        Private Sub mprcInit(ByVal EnforceConstraints As Boolean)

            '制約規則
            Me.DataSet.EnforceConstraints = EnforceConstraints

            'オブジェクト内の文字列比較で大文字と小文字を区別する
            Me.DataSet.CaseSensitive = EnforceConstraints

        End Sub

        Private Sub mprcFillDataSet(ByVal tableName As String, ByVal selectCommand As DbCommand)

            'データアダプターを生成する
            Dim adapter As DbDataAdapter = _Cnn.CreateDbDataAdapter(selectCommand)
            'トランザクション処理をしないときは必要
            'Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)

            'スキーマーを正しく読み込む為にFillSchemaを行う
            adapter.FillSchema(_Data, SchemaType.Mapped, tableName)
            adapter.Fill(_Data, tableName)
            If Not _dataAdapters.Contains(tableName) Then
                _dataAdapters.Add(tableName, adapter)
            End If

        End Sub

        ''' <summary>
        ''' ＳＱＬ文よりコマンドビルダーを再作成する
        ''' </summary>
        ''' <param name="adapter">テーブルアダプター</param>
        ''' <param name="transaction">トランザクション</param>
        ''' <remarks></remarks>
        Private Sub mprcReCommandBuilder(ByVal adapter As DbDataAdapter, ByVal transaction As DbTransaction, Optional ByVal intBatchSize As Integer = 1)

            Dim strSelect As String = adapter.SelectCommand.CommandText.ToUpper
            If strSelect.IndexOf("WHERE") <> -1 Then
                strSelect = strSelect.Remove(strSelect.IndexOf("WHERE"))
            End If
            'If strSelect.IndexOf("ORDER BY") <> -1 Then
            '    strSelect = strSelect.Remove(strSelect.IndexOf("ORDER BY"))
            'End If

            Dim cmd As DbCommand = _Cnn.CreateCommand(strSelect, transaction)
            'タイムアウト(既定値は30秒)
            cmd.CommandTimeout = 600    '10分
            adapter.SelectCommand = cmd
            'バッチサイズ(バッチ更新の場合は100ぐらいがよい)
            adapter.UpdateBatchSize = intBatchSize

            Dim builder As DbCommandBuilder = _Cnn.CreateCommandBuilder()
            builder.DataAdapter = adapter
            builder.ConflictOption = pConflictOption

            '日本語列名対策(一文字目数字の列名はエラーになる対策）
            'http://support.microsoft.com/kb/932994/ja
            'http://msdn.microsoft.com/ja-jp/library/system.data.sqlclient.sqlcommandbuilder.quotesuffix(VS.80).aspx
            builder.QuotePrefix = "["
            builder.QuoteSuffix = "]"

        End Sub

#End Region

#Region "オーバーライド可能　メソッド"

        ''' <summary>
        ''' データーセット内の全テーブルを更新します
        ''' </summary>
        ''' <param name="transaction">トランザクション</param>
        ''' <remarks>リレーションテーブルがある場合はDataSetGatewayを継承してこの処理をオーバーライドする事</remarks>
        Protected Overridable Sub UpdateDataSet(ByVal transaction As DbTransaction, Optional ByVal intBatchSize As Integer = 1)

            Dim adapter As DbDataAdapter

            For Each tableName As String In _dataAdapters.Keys

                adapter = DirectCast(_dataAdapters(tableName), DbDataAdapter)

                'トランザクション処理をしているのでコマンドとコマンドビルダーを再作成する
                mprcReCommandBuilder(adapter, transaction, intBatchSize)

                '更新
                adapter.Update(_Data, tableName)

            Next

        End Sub

        ''' <summary>
        ''' Updateの前処理
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overridable Sub BeforeUpdate()
        End Sub

        ''' <summary>
        ''' Updateの後処理　
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overridable Sub AfterUpdate()
        End Sub

#End Region

    End Class
End Namespace
