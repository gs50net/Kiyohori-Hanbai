#Region "参照"

Imports System
Imports System.io
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

#End Region

Namespace Classes

    ''' <summary>
    ''' ini ファイルを使用するための基本クラス
    ''' </summary>
    Public Class CClsIni

#Region "コンストラクタ"

        ''' <summary>
        ''' クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="fileName">ini ファイル名。</param>
        Public Sub New(ByVal fileName As String)
            _fileName = fileName
        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' ini ファイルから値を取得します。
        ''' </summary>
        ''' <param name="section">セクション名。</param>
        ''' <param name="key">キー名。</param>
        ''' <param name="defaultValue">保存された値がない場合の既定の文字列。</param>
        Public Function GetValue(ByVal section As String, ByVal key As String, ByVal defaultValue As String) As String
            Const BUFFER_SIZE As Integer = 256
            Dim buffer As StringBuilder = New StringBuilder(BUFFER_SIZE)
            GetPrivateProfileString(section, key, defaultValue, buffer, BUFFER_SIZE, _fileName)
            Return buffer.ToString()
        End Function

        ''' <summary>
        ''' ini ファイルに値を書き込みます。
        ''' </summary>
        ''' <param name="section">セクション名。</param>
        ''' <param name="key">キー名。</param>
        ''' <param name="saveValue">書き込む値。</param>
        Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal saveValue As String)
            If saveValue = String.Empty Then
                WritePrivateProfileString(section, key, String.Empty, _fileName)
            Else
                saveValue = saveValue.Trim()
                If WritePrivateProfileString(section, key, saveValue, _fileName) = 0 Then
                    MessageBox.Show(section & " : " & key, "CClsIni.WriteValue")
                End If
            End If
        End Sub

#End Region

#Region "プロパティ"

        Private _fileName As String
        Public ReadOnly Property pstrFileName() As String
            Get
                Return _fileName
            End Get
        End Property

#End Region

#Region "API"

        '-------------------------
        ' GetPrivateProfileString
        '-------------------------
        ''' <summary>
        ''' 指定された .ini ファイル（初期化ファイル）の指定されたセクション内にある、指定されたキーに関連付けられている文字列を取得します。
        ''' 関数が成功すると、バッファに格納された文字数が返ります（終端の NULL 文字は含まない）。
        ''' </summary>
        ''' <remarks><code>
        ''' DWORD GetPrivateProfileString(
        '''  LPCTSTR lpAppName,                  // セクション名
        '''  LPCTSTR lpKeyName,                  // キー名
        '''  LPCTSTR lpDefault,                  // 既定の文字列
        '''  LPTSTR lpReturnedString,            // 情報が格納されるバッファ
        '''  DWORD nSize,                        // 情報バッファのサイズ
        '''  LPCTSTR lpFileName                  // .ini ファイルの名前
        ''' );
        ''' </code></remarks>
        <DllImport("kernel32.dll", EntryPoint:="GetPrivateProfileStringA")> _
        Private Shared Function GetPrivateProfileString( _
            ByVal lpAppNameas As String, _
            ByVal lpkeyName As String, _
            ByVal lpDefault As String, _
            ByVal lpReturnedstringas As StringBuilder, _
            ByVal nSize As Integer, _
            ByVal lpFileName As String _
        ) As Integer
        End Function


        '-------------------------
        ' WritePrivateProfileString
        '-------------------------
        ''' <summary>
        ''' 指定された .ini ファイル（初期化ファイル）の、指定されたセクション内に、指定されたキー名とそれに関連付けられた文字列を格納します。
        ''' 関数が文字列を .ini ファイルに格納することに成功すると、0 以外の値が返ります。
        ''' 関数が失敗するか、直前にアクセスした .ini ファイルをキャッシュからディスク上のファイルへフラッシュする（書き込む）と、0 が返ります。
        ''' </summary>
        ''' <remarks><code>
        ''' BOOL WritePrivateProfileString(
        '''  LPCTSTR lpAppName,                  // セクション名
        '''  LPCTSTR lpKeyName,                  // キー名
        '''  LPCTSTR lpString,                   // 追加するべき文字列
        '''  LPCTSTR lpFileName                  // .ini ファイル
        ''' );
        ''' </code></remarks>
        <DllImport("kernel32.dll", EntryPoint:="WritePrivateProfileStringA")> _
        Private Shared Function WritePrivateProfileString( _
            ByVal lpApplicationName As String, _
            ByVal lpkeyName As String, _
            ByVal lpstring As String, _
            ByVal lpFileName As String _
        ) As Integer
        End Function

#End Region

    End Class

End Namespace
