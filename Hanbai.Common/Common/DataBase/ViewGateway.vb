#Region "参照"

Imports System
Imports System.Data
Imports System.Data.Common

#End Region

Namespace DataBase

#Region "グローバル変数"

    ''' <summary>
    ''' グローバル変数の定義
    ''' </summary>
    ''' <remarks></remarks>
    Module modGlobalViewGateway

        ''' <summary>
        ''' 一時的ビュー名のカウンター
        ''' </summary>
        ''' <remarks></remarks>
        Public gintViewNo As Integer = 0

    End Module

#End Region

    ''' <summary>
    ''' ViewGateway の概要の説明です。
    ''' </summary>
    ''' <remarks>
    ''' ビューゲートウェイの抽象基本クラスです。
    ''' ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
    ''' PrimaryKeyは生成しないので必要な場合は自分で作成する事
    ''' ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
    ''' </remarks>
    Public MustInherit Class ViewGateway

#Region "メンバー変数"

        ''' <summary>
        ''' データーセットゲートウェイ
        ''' </summary>
        ''' <remarks></remarks>
        Private mdsg As DataSetGateway
        ''' <summary>
        ''' ビュー名
        ''' </summary>
        ''' <remarks></remarks>
        Private mstrViewName As String
        ''' <summary>
        ''' パラメータクエリーに引き渡すパラメータマーカを生成する　クラス
        ''' </summary>
        ''' <remarks></remarks>
        Private mpmf As ParameterMakerFormat

#End Region

#Region "プロパティ"

        ''' <summary>
        ''' データテーブルを取得します。
        ''' </summary>
        ''' <remarks>
        ''' <see cref="System.Data.DataTable">DataTable</see>クラスのインスタンスを取得します。
        ''' </remarks>
        Public ReadOnly Property Table() As DataTable
            Get
                Return mdsg.Item(mstrViewName)
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
        ''' ビュー名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ViewName() As String
            Get
                Return mstrViewName
            End Get
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

        ''' <summary>
        ''' レコード件数
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Count() As Integer
            Get
                If Not IsNothing(Table) Then
                    Return Table.Rows.Count
                Else
                    Return 0
                End If
            End Get
        End Property

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="enmProvider">プロパイダーの種類</param>
        ''' <param name="strViewName">ビュー名</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal strConnStr As String, ByVal enmProvider As enmProvider, Optional ByVal strViewName As String = "")

            Init(strConnStr, enmProvider, strViewName)

        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="cnn">コネクション</param>
        ''' <param name="strViewName">ビュー名</param>
        ''' <remarks>※最後にはコネクションはクローズします</remarks>
        Protected Sub New(ByVal cnn As Connection, Optional ByVal strViewName As String = "")

            'データーセットゲートウェイ
            mdsg = New DataSetGateway(cnn)

            mprcInitSub(strViewName)

        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="dst"></param>
        ''' <param name="strViewName">ビュー名</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal dst As DataSetGateway, Optional ByVal strViewName As String = "")

            'データーセットゲートウェイ
            If IsNothing(dst) Then
                Throw New Exception("ViewGateway New Error")
            End If

            mdsg = dst

            mprcInitSub(strViewName)

        End Sub

#End Region

#Region "プロテクト メソッド"

        ''' <summary>
        ''' 初期処理
        ''' </summary>
        ''' <param name="strConnStr"></param>
        ''' <param name="enmProvider"></param>
        ''' <param name="strViewName"></param>
        ''' <remarks></remarks>
        Protected Sub Init(ByVal strConnStr As String, ByVal enmProvider As enmProvider, Optional ByVal strViewName As String = "")

            'データーセットゲートウェイ
            mdsg = New DataSetGateway(strConnStr, enmProvider)

            mprcInitSub(strViewName)

        End Sub

        ''' <summary>
        ''' 対象テーブルにデータを読み込みます。
        ''' </summary>
        ''' <param name="strSql">SQL文</param>
        ''' <remarks></remarks>
        Protected Overloads Sub FillData(ByVal strSql As String)

            'データ　テーブルを消去します
            RemoveView(mstrViewName)

            '対象テーブルにデータを読み込みます。
            ' PrimaryKeyは生成しない
            mdsg.FillViewData(mstrViewName, strSql)

            'FillDataの後処理
            AfterFillData()

        End Sub

        ''' <summary>
        ''' 対象テーブルにデータを読み込みます。
        ''' </summary>
        ''' <param name="selectCommand">データ読み込み用のコマンド</param>
        ''' <remarks></remarks>
        Protected Overloads Sub FillData(ByVal selectCommand As DbCommand)

            mdsg.FillData(mstrViewName, selectCommand)

        End Sub

        ''' <summary>
        ''' データ　テーブルを消去します
        ''' </summary>
        ''' <param name="strViewName"></param>
        ''' <remarks></remarks>
        Protected Sub RemoveView(ByVal strViewName As String)

            mdsg.DataSet.Relations.Clear()

            mdsg.RemoveTable(strViewName)

        End Sub

        ''' <summary>
        ''' DbCommandオブジェクトを生成します
        ''' </summary>
        ''' <param name="strCommandText">コマンドテキスト</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function CreateCommand(ByVal strCommandText As String) As DbCommand

            Return DataSetGateWay.CreateCommand(strCommandText)

        End Function

        ''' <summary>
        ''' パラメータを設定します
        ''' </summary>
        ''' <param name="cmd">コマンド</param>
        ''' <param name="strPrmName">パラメーター名</param>
        ''' <param name="objValue">パラメーター値</param>
        ''' <remarks>SELECT文のパラメータの出現順番とパラメータ名の順番を必ず合わせること</remarks>
        Protected Overloads Sub SetParameter(ByVal cmd As DbCommand, ByVal strPrmName As String, ByVal objValue As Object)

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
        Protected Overloads Sub SetParameter(ByVal cmd As DbCommand, ByVal astrPrmName() As String, ByVal aobjValue() As Object)

            For i As Integer = 0 To astrPrmName.Length - 1
                SetParameter(cmd, astrPrmName(i), aobjValue(i))
            Next i

        End Sub

#End Region

#Region "オーバーライド可能　メソッド"

        ''' <summary>
        ''' FillDataの後処理　オーバーライド可能
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub AfterFillData()

            'FillDataの後処理をここに記述する
            'CreateIntegerToDateColumn("生年月日")

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 文字列に含まれる単一引用符を２個の単一引用符に置換する
        ''' </summary>
        ''' <param name="strCond"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ReplaceQuotation(ByVal strCond As String) As String

            Dim ret As String = strCond.Replace("'", "''")
            Return ret

        End Function

#End Region

#Region "プライベート　メソッド"

        Private Sub mprcInitSub(ByVal strViewName As String)

            'ビュー名
            mprcSetViewName(strViewName)

            'PrimaryKeyの制約違反があるので必ずOffにする事
            '制約規則 Off
            mdsg.DataSet.EnforceConstraints = False

            'パラメータマーカを生成する　クラス
            pclsPMF = New ParameterMakerFormat(mdsg.Connection)

        End Sub

        Private Sub mprcSetViewName(ByVal strViewName As String)

            If strViewName = String.Empty Then
                gintViewNo += 1
                mstrViewName = String.Format("VW_{0}", gintViewNo)
            Else
                mstrViewName = strViewName
            End If

        End Sub

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

    End Class

End Namespace