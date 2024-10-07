#Region "参照"

Imports System
Imports System.Data
Imports System.Data.Common

#End Region

Namespace DataBase

    ''' <summary>
    ''' DataGateway の概要の説明です。
    ''' </summary>
    ''' <remarks>
    ''' テーブルデータゲートウェイの抽象基本クラスです。
    ''' </remarks>
    Public MustInherit Class DataGateway

#Region "メンバー変数"

        ''' <summary>
        ''' テーブル名
        ''' </summary>
        ''' <remarks></remarks>
        Private mstrTableName As String
        ''' <summary>
        ''' パラメータクエリーに引き渡すパラメータマーカを生成する　クラス
        ''' </summary>
        ''' <remarks></remarks>
        Private mpmf As ParameterMakerFormat

#End Region

#Region "プロテクト　メンバー変数"

        ''' <summary>
        ''' データーセットゲートウェイ
        ''' </summary>
        ''' <remarks></remarks>
        Protected mdsg As DataSetGateway
        ''' <summary>
        ''' 実テーブル名
        ''' </summary>
        ''' <remarks></remarks>
        Protected mstrTrueTableName As String
        ''' <summary>
        ''' 追加行
        ''' </summary>
        ''' <remarks></remarks>
        Protected mblnInsertRow As Boolean

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="enmProvider">プロパイダーの種類</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal strConnStr As String, Optional ByVal enmProvider As enmProvider = enmProvider.MDB)

            mdsg = New DataSetGateway(strConnStr, enmProvider)

            mstrTrueTableName = GetTableName()

            TableName = mstrTrueTableName

            'パラメータマーカを生成する　クラス
            pclsPMF = New ParameterMakerFormat(mdsg.Connection)

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="cnn">コネクション</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal cnn As Connection)

            mdsg = New DataSetGateway(cnn)

            mstrTrueTableName = GetTableName()

            TableName = mstrTrueTableName

            'パラメータマーカを生成する　クラス
            pclsPMF = New ParameterMakerFormat(mdsg.Connection)

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="dstGateway"> DataSetGatewayクラスのインスタンス
        ''' </param>
        ''' <remarks>
        ''' このクラスのインスタンスは直接作成できません。
        ''' </remarks>
        Protected Sub New(ByVal dstGateway As DataSetGateway, Optional ByVal strTableName As String = "")

            If dstGateway Is Nothing Then
                MessageBox.Show("dstGateway is Nothing", "DataGateway.New")
            End If

            mdsg = dstGateway

            mstrTrueTableName = GetTableName()
            If strTableName = String.Empty Then
                TableName = mstrTrueTableName
            Else
                TableName = strTableName
            End If

            'パラメータマーカを生成する　クラス
            pclsPMF = New ParameterMakerFormat(mdsg.Connection)

        End Sub

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' データセットを取得します。
        ''' </summary>
        ''' <remarks>
        ''' <see cref="System.Data.DataSet">DataSet</see>クラスのインスタンスを取得します。
        ''' </remarks>
        Public ReadOnly Property Data() As DataSet
            Get
                Return mdsg.DataSet
            End Get
        End Property
        ''' <summary>
        ''' データーセットゲートウェイを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataSetGateWay() As DataSetGateway
            Get
                Return mdsg
            End Get
        End Property
        ''' <summary>
        ''' データーアダプターを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataAdapter() As DbDataAdapter
            Get
                Return mdsg.DataAdapter(TableName)
            End Get
        End Property
        ''' <summary>
        ''' データテーブルを取得します。
        ''' </summary>
        ''' <remarks>
        ''' <see cref="System.Data.DataTable">DataTable</see>クラスのインスタンスを取得します。
        ''' </remarks>
        Public ReadOnly Property Table() As DataTable
            Get
                Return mdsg.Item(TableName)
            End Get
        End Property
        ''' <summary>
        ''' テーブル名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TableName() As String
            Get
                Return mstrTableName
            End Get
            Set(ByVal value As String)
                mstrTableName = value
            End Set
        End Property
        ''' <summary>
        ''' パラメータマーカを生成する　クラス
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pclsPMF() As ParameterMakerFormat
            Get
                Return mpmf
            End Get
            Set(ByVal value As ParameterMakerFormat)
                mpmf = value
            End Set
        End Property
        ''' <summary>
        ''' Rows
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Rows() As DataRowCollection
            Get
                Return Table.Rows
            End Get
        End Property

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 全てのレコードを読み込みます。
        ''' </summary>
        ''' <param name="strSql">SQL文</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FillSql(ByVal strSql As String) As DataRowCollection

            If FillData(TableName, strSql) Then
                If Table.Rows.Count = 0 Then
                    Return Nothing
                Else
                    Return Table.Rows
                End If
            Else
                Return Nothing
            End If

        End Function

        ''' <summary>
        ''' 全てのレコードを読み込みます。
        ''' </summary>
        ''' <param name="strWhere">where句</param>
        ''' <param name="strOrder">order句</param>
        ''' <remarks>名称等(「'」が含まれるので)の検索にはWhere句を使用しないで下さい。パラメータを使用する事</remarks>
        Public Function Fill(Optional ByVal strWhere As String = "", _
                             Optional ByVal strOrder As String = "") As DataRowCollection

            Dim sql As String = String.Format("SELECT * FROM {0}", mstrTrueTableName)
            If strWhere <> String.Empty Then
                sql &= " WHERE " & strWhere
            End If
            If strOrder <> String.Empty Then
                sql &= " ORDER BY " & strOrder
            End If

            If FillData(TableName, sql) Then
                If Table.Rows.Count = 0 Then
                    Return Nothing
                Else
                    Return Table.Rows
                End If
            Else
                Return Nothing
            End If

        End Function

        ''' <summary>
        ''' 連番順に全てのレコードを読み込みます。
        ''' </summary>
        ''' <param name="strWhere">where句</param>
        ''' <remarks></remarks>
        Public Function FillOrderByNumber(Optional ByVal strWhere As String = "") As DataRowCollection

            Return Fill(strWhere, "連番")

        End Function

        ''' <summary>
        ''' データーテーブルの行数を取得します
        ''' </summary>
        ''' <returns>行数</returns>
        ''' <remarks></remarks>
        Public Function RowsCount() As Integer

            Dim tbl As DataTable = mdsg.Item(TableName)
            Return tbl.Rows.Count

        End Function

        ''' <summary>
        ''' 掲示中(Proposed)の行を全てEndEditする
        ''' </summary>
        ''' <remarks>BindinSourceのEndEdit()はリレーションテーブルには正しく動作しないので、
        ''' リレーションテーブルを使用している場合はこのメソッドを利用すること</remarks>
        Public Sub EndEdit()

            For Each row As DataRow In Table.Rows
                If row.HasVersion(DataRowVersion.Proposed) Then
                    row.EndEdit()
                End If
            Next

        End Sub

        ''' <summary>
        ''' Itemは全てDBNull？
        ''' </summary>
        ''' <param name="drv"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsItemDBNull(ByVal drv As DataRowView) As Boolean

            For Each item As Object In drv.Row.ItemArray
                If Not IsDBNull(item) Then
                    Return False
                End If
            Next

            Return True

        End Function

        ''' <summary>
        ''' 空のテーブルを作成します
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CreateEmptyTable()
            Dim sql As String
            sql = String.Format("SELECT * FROM {0} WHERE 1=0", mstrTrueTableName)
            FillData(TableName, sql)
        End Sub

        ''' <summary>
        ''' DbCommandオブジェクトを生成します
        ''' </summary>
        ''' <param name="strCommandText">コマンドテキスト</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateCommand(ByVal strCommandText As String) As DbCommand

            Return DataSetGateWay.CreateCommand(strCommandText)

        End Function

        ''' <summary>
        ''' パラメータを設定します
        ''' </summary>
        ''' <param name="cmd">コマンド</param>
        ''' <param name="strPrmName">パラメーター名</param>
        ''' <param name="objValue">パラメーター値</param>
        ''' <remarks>SELECT文のパラメータの出現順番とパラメータ名の順番を必ず合わせること</remarks>
        Public Overloads Sub SetParameter(ByVal cmd As DbCommand, ByVal strPrmName As String, ByVal objValue As Object)

            Dim prm As DbParameter = DataSetGateWay.Connection.CreateDbParameter
            mprcSetParameter(prm, strPrmName, objValue)
            cmd.Parameters.Add(prm)

        End Sub

        ''' <summary>
        ''' パラメータを設定します
        ''' </summary>
        ''' <param name="cmd">コマンド</param>
        ''' <param name="astrPrmName">パラメーター名()</param>
        ''' <param name="aobjValue">パラメーター値()</param>
        ''' <remarks>SELECT文のパラメータの出現順番とパラメータ名()の順番を必ず合わせること</remarks>
        Public Overloads Sub SetParameter(ByVal cmd As DbCommand, ByVal astrPrmName() As String, ByVal aobjValue() As Object)

            For i As Integer = 0 To astrPrmName.Length - 1
                SetParameter(cmd, astrPrmName(i), aobjValue(i))
            Next i

        End Sub

        ''' <summary>
        ''' コピー元からコピー先へ同じ項目をコピーする
        ''' </summary>
        ''' <param name="rowTerget">コピー先</param>
        ''' <param name="src">コピー元</param>
        ''' <remarks></remarks>
        Public Shared Sub CopyItem(ByVal rowTerget As DataRow, ByVal src As DataRow)

            Dim tblTerget As DataTable = rowTerget.Table

            For i As Integer = 0 To tblTerget.Columns.Count - 1
                Dim strColumnName As String = tblTerget.Columns.Item(i).ColumnName
                If src.Table.Columns.Contains(strColumnName) Then
                    rowTerget.Item(i) = src.Item(strColumnName)
                End If
            Next i

        End Sub

#End Region

#Region "プライベート　メソッド"

        Public Sub mprcSetParameter(ByVal prm As DbParameter, ByVal strPrmName As String, ByVal objValue As Object)

            With prm

                .ParameterName = strPrmName
                .Value = objValue

                If TypeOf .Value Is Integer Then
                    .DbType = DbType.Int32
                End If
                If TypeOf .Value Is String Then
                    .DbType = DbType.String
                    .Size = CStr(.Value).Length
                End If
                If TypeOf .Value Is Single Then
                    .DbType = DbType.Single
                End If
                If TypeOf .Value Is Double Then
                    .DbType = DbType.Double
                End If

            End With

        End Sub

#End Region

#Region "プロテクト　メソッド"

        ''' <summary>
        ''' SqlCommandによりレコードを読み込みます。
        ''' </summary>
        ''' <param name="strTblName">テーブル名</param>
        ''' <param name="selectCommand">SqlCommand</param>
        ''' <remarks></remarks>
        Protected Overloads Function FillData(ByVal strTblName As String, ByVal selectCommand As DbCommand) As Boolean

            '対象テーブルにデータを読み込みます。
            If mdsg.FillData(strTblName, selectCommand) Then
                'FillDataの後処理
                AfterFillData()
                Return True
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' SQL文によりレコードを読み込みます。
        ''' </summary>
        ''' <param name="strTblName">テーブル名</param>
        ''' <param name="strSql">SQL文</param>
        ''' <remarks></remarks>
        Protected Overloads Function FillData(ByVal strTblName As String, ByVal strSql As String) As Boolean

            '対象テーブルにデータを読み込みます。
            If mdsg.FillData(strTblName, strSql) Then
                'FillDataの後処理
                AfterFillData()
                Return True
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' カラムを生成する
        ''' </summary>
        ''' <param name="strColumnName">カラム</param>
        ''' <param name="typ">タイプ</param>
        ''' <param name="intLength">最大長</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function NewColumn(ByVal strColumnName As String, ByVal typ As Type, Optional ByVal intLength As Integer = 0) As DataColumn

            Dim clm As New DataColumn(strColumnName, typ)
            If typ.Equals(GetType(String)) Then
                If intLength = 0 Then
                    Throw New Exception("NewColumn Length")
                End If
                clm.MaxLength = intLength
            End If

            Return clm

        End Function

#End Region

#Region "オーバーライド可能　メソッド"

        ''' <summary>
        ''' テーブル名
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public MustOverride Function GetTableName() As String

        ''' <summary>
        ''' FillDataの後処理
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub AfterFillData()
        End Sub

#End Region

    End Class

End Namespace
