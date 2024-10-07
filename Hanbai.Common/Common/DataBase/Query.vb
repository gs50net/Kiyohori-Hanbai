Namespace DataBase

    ''' <summary>
    ''' Queryの概要の説明です。
    ''' </summary>
    ''' <remarks>クエリーの抽象基本クラスです。
    ''' 必ず usingを使用すること</remarks>
    ''' <example>
    ''' <code>
    ''' Using qry As New Query(cnn)
    '''      qry.Open("SELECT * FROM T030_利用者")
    '''      While qry.Read
    '''         ･･････
    '''      end while
    ''' end using
    ''' </code>
    ''' <code>
    ''' Using qry As New Query(cnn, "SELECT * FROM T030_利用者")
    '''       While qry.Read
    '''            ･･････
    '''       end while
    ''' end using
    ''' </code>
    ''' </example>
    Public Class Query : Inherits DataReader

#Region "プロパティ"

        ''' <summary>
        ''' 1 行以上の行が格納されているかどうかを示す値を取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property HasRows() As Boolean
            Get
                Return DataReader.HasRows
            End Get
        End Property
        ''' <summary>
        ''' 列数を取得します
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property FieldCount() As Integer
            Get
                Return DataReader.FieldCount
            End Get
        End Property
        ''' <summary>
        ''' 項目値(i)を取得します
        ''' </summary>
        ''' <param name="intIndex">インデックス(0～Count-1)</param>
        ''' <value></value>
        ''' <returns>Object</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Item(ByVal intIndex As Integer) As Object
            Get
                Return DataReader.Item(intIndex)
            End Get
        End Property
        ''' <summary>
        ''' 項目値(name)を取得します
        ''' </summary>
        ''' <param name="strName">列名</param>
        ''' <value></value>
        ''' <returns>Object</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Item(ByVal strName As String) As Object
            Get
                Return DataReader.Item(strName)
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
        ''' <remarks>
        ''' クラスの新しいインスタンスを初期化します。
        ''' </remarks>
        Public Sub New(ByVal strConnStr As String, ByVal enmProvider As enmProvider)
            MyBase.New(strConnStr, enmProvider)
        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="cnn">コネクション</param>
        ''' <remarks>クラスの新しいインスタンスを初期化します。</remarks>
        Public Sub New(ByVal cnn As Connection)
            MyBase.New(cnn)
        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="strConnStr">接続文字列</param>
        ''' <param name="strSql">SQL文</param>
        ''' <param name="enmProvider">プロパイダーの種類</param>
        ''' <remarks>クラスの新しいインスタンスを初期化します。</remarks>
        Public Sub New(ByVal strConnStr As String, ByVal strSql As String, ByVal enmProvider As enmProvider)

            MyBase.New(strConnStr, enmProvider)

            Open(strSql)

        End Sub

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <param name="cnn">コネクション</param>
        ''' <param name="strSql">SQL文</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal cnn As Connection, ByVal strSql As String)

            MyBase.New(cnn)

            Open(strSql)

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 次の行を読み込みます
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Read() As Boolean

            If Not _ValidOpen Then
                Return False
            End If

            Dim blnRet As Boolean = DataReader.Read()

            Return blnRet

        End Function

#End Region

#Region "オーバーライド可能　メソッド"

        ''' <summary>
        ''' オープンします
        ''' </summary>
        ''' <param name="strSql">SQL文</param>
        ''' <remarks></remarks>
        Public Overloads Sub Open(ByVal strSql As String, Optional ByVal blnSequentialAccess As Boolean = False, Optional ByVal blnShowErrorMessage As Boolean = True)

            MyBase.Open(strSql, blnSequentialAccess, blnShowErrorMessage)

        End Sub

#End Region

    End Class

End Namespace