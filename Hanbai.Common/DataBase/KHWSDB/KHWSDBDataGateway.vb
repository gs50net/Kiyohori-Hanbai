#Region "参照"

Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase

#End Region

Namespace DataBase.MyDB

    ''' <summary>
    ''' DataGateway抽象クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class KHWSDBDataGateway : Inherits DataGateway

#Region "プロパティ"

        ''' <summary>
        ''' Rows件数
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Count() As Integer
            Get
                Return Me.Table.Rows.Count
            End Get
        End Property

        Private mstrTBLID As String
        ''' <summary>
        ''' TBLID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrTBLID() As String
            Get
                Return mstrTBLID
            End Get
            Set(ByVal value As String)
                mstrTBLID = value
            End Set
        End Property

        ''' <summary>
        ''' 項目
        ''' </summary>
        ''' <param name="intIndex"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Default Public ReadOnly Property Item(ByVal intIndex As Integer) As DataRow
            Get
                Return Me.Table.Rows(intIndex)
            End Get
        End Property

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <remarks>クラスの新しいインスタンスを初期化します。</remarks>
        Protected Sub New()
            MyBase.New(CClsSetting.GetInstance.pstrKHWSDBConn, enmProvider.SQLServer)
        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="dstGateway">DataSetGateway</param>
        ''' <remarks>更新する場合はこのコンストラクタを使用する</remarks>
        Protected Sub New(ByVal dstGateway As DataSetGateway, Optional ByVal strTableName As String = "")
            MyBase.New(dstGateway, strTableName)
        End Sub

#End Region

#Region "ID 自動生成"

        ''' <summary>
        ''' IDを自動生成するクラス
        ''' </summary>
        ''' <remarks></remarks>
        Private Genarator As IDGenerator = Nothing

        ''' <summary>
        ''' 次のIDを取得します。
        ''' </summary>
        ''' <returns>次のID</returns>
        ''' <remarks>
        ''' 一意フィールドとなるIDを取得します。
        ''' </remarks>
        Public Function GetNextId() As Integer

            If IsNothing(mstrTBLID) Then
                Throw New Exception("TBLIDが定義されていません")
            End If

            If (Genarator Is Nothing) Then
                Genarator = New IDGenerator(mstrTBLID, CClsSetting.GetInstance.pstrKHWSDBConn, enmProvider.SQLServer)
            End If

            Return Genarator.GetNextId

        End Function

        ''' <summary>
        ''' IDを初期値設定します（１に戻す）
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub InitId()

            If IsNothing(mstrTBLID) Then
                Throw New Exception("TBLIDが定義されていません")
            End If

            If (Genarator Is Nothing) Then
                Genarator = New IDGenerator(mstrTBLID, CClsSetting.GetInstance.pstrKHWSDBConn, enmProvider.SQLServer)
            End If

            Genarator.InitId()

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 新しい行を生成します
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function NewRow() As DataRow
            Return Me.Table.NewRow
        End Function

        ''' <summary>
        ''' 行を追加します
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Public Overloads Sub AddRow(ByVal row As CDataRowBase)

            If Not IsNothing(row.DataRow) Then
                Me.Rows.Add(row.DataRow)
            End If
            If Not IsNothing(row.DataRowView) Then
                Me.Rows.Add(row.DataRowView)
            End If

        End Sub

        Public Overloads Sub AddRow(ByVal row As DataRow)
            Me.Rows.Add(row)
        End Sub

        ''' <summary>
        ''' データーセット内の全テーブルを更新します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Update()

            Me.DataSetGateWay.Update()

        End Sub

        ''' <summary>
        ''' フィルターを設定し行を検索します
        ''' </summary>
        ''' <param name="strFilter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function SelectRows(ByVal strFilter As String, Optional ByVal strOrder As String = "", Optional ByVal state As DataViewRowState = DataViewRowState.CurrentRows) As DataRow()

            Dim row As DataRow() = Table.Select(strFilter, strOrder, state)

            Return row

        End Function

        ''' <summary>
        ''' 主キーより行を検索します
        ''' </summary>
        ''' <param name="objPrimaryKey"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function FindRow(ByVal objPrimaryKey As Object) As DataRow

            Dim row As DataRow = Table.Rows.Find(objPrimaryKey)

            Return row

        End Function

        ''' <summary>
        ''' 主キーより行を検索します
        ''' </summary>
        ''' <param name="objPrimaryKey"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function FindRow(ByVal objPrimaryKey() As Object) As DataRow

            Dim row As DataRow = Table.Rows.Find(objPrimaryKey)

            Return row

        End Function

#End Region

#Region "デリゲート　メソッド"

        ''' <summary>
        ''' TableNewRowイベント
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>テーブル追加時の初期値を設定する</remarks>
        Public Overridable Sub TableNewRow(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)

            e.Row("作成日付") = CMyDBFunction.GetDataBaseDate()

        End Sub

        ''' <summary>
        ''' Table.ColumnChangedイベント
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Overridable Sub ColumnChanged(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)

            '更新日付
            If e.Column.ColumnName <> "更新日付" Then
                'Originalがある時（変更の場合）
                If e.Row.HasVersion(DataRowVersion.Original) Then
                    e.Row("更新日付") = CMyDBFunction.GetDataBaseDate()
                End If
            End If

        End Sub

#End Region

    End Class

End Namespace