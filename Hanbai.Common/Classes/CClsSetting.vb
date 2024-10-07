Namespace Classes

    ''' <summary>
    ''' 設定情報クラス
    ''' </summary>
    ''' <remarks>Singletonクラス</remarks>
    Public Class CClsSetting

#Region "メンバー変数"

        ''' <summary>
        ''' 唯一のインスタンス
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared _singleton As CClsSetting = New CClsSetting()

#End Region

#Region "プロパティ"

        Private mstrIniFileName As String
        ''' <summary>
        ''' IniFile ファイル名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrIniFileName() As String
            Get
                Return mstrIniFileName
            End Get
            Set(ByVal value As String)
                mstrIniFileName = value
            End Set
        End Property

        Private mstrKHWSDBConn As String
        ''' <summary>
        ''' MyDB 接続文字列
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrKHWSDBConn() As String
            Get
                Return mstrKHWSDBConn
            End Get
            Set(ByVal value As String)
                mstrKHWSDBConn = value
            End Set
        End Property

        Private mstrKHDBConn As String
        ''' <summary>
        ''' KHDB 接続文字列
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrKHDBConn() As String
            Get
                Return mstrKHDBConn
            End Get
            Set(ByVal value As String)
                mstrKHDBConn = value
            End Set
        End Property

        Private mblnOutputWindow As Boolean = True
        ''' <summary>
        ''' メッセージをウインドーに表示する？
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pblnOutputWindow() As Boolean
            Get
                Return mblnOutputWindow
            End Get
            Set(ByVal value As Boolean)
                mblnOutputWindow = value
            End Set
        End Property

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 唯一のインスタンスを取得する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetInstance() As CClsSetting
            Return _singleton
        End Function

#End Region

    End Class

End Namespace

