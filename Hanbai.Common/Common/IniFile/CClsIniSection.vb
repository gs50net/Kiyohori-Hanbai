Namespace Classes

    ''' <summary>
    ''' 初期化ファイルのセクション用クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CClsIniSection

#Region "メンバー変数"

        Private _ini As CClsIni

        Private mstrSectName As String   'セクション名

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="fileName">ini ファイル名。</param>
        ''' <param name="sectName">使用セクション名</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal fileName As String, ByVal sectName As String)

            _ini = New CClsIni(fileName)

            mstrSectName = sectName

        End Sub

#End Region

#Region "プロパティ"

#End Region

#Region "メソッド"

        ''' <summary>キーの値を取得</summary>
        ''' <param name="key">キー</param>
        ''' <param name="value">既定値</param>
        ''' <returns>値</returns>
        ''' <remarks>
        ''' 初期化ファイル内にキーが存在しない場合は、既定値が返される。
        ''' 配列は１次元のみ、添え字は0から、既定値なし。
        '''     String     ""
        '''     Short      0
        '''     Integer    0
        '''     Single     0
        '''     Boolean    False
        '''     DateTime   読み込み時点
        ''' </remarks>
        Public Overloads Function ReadKey(ByVal key As String, ByVal value As String) As String
            Return _ini.GetValue(mstrSectName, key, value)
        End Function
        'Short
        Public Overloads Function ReadKey(ByVal key As String, ByVal value As Short) As Short
            Return Short.Parse(_ini.GetValue(mstrSectName, key, value.ToString))
        End Function
        'Integer
        Public Overloads Function ReadKey(ByVal key As String, ByVal value As Integer) As Integer
            Return Integer.Parse(_ini.GetValue(mstrSectName, key, value.ToString))
        End Function
        'Single
        Public Overloads Function ReadKey(ByVal key As String, ByVal value As Single) As Single
            Return Single.Parse(_ini.GetValue(mstrSectName, key, value.ToString))
        End Function
        'Boolean
        Public Overloads Function ReadKey(ByVal key As String, ByVal value As Boolean) As Boolean
            Return Boolean.Parse(_ini.GetValue(mstrSectName, key, value.ToString))
        End Function
        'DateTime
        Public Overloads Function ReadKey(ByVal key As String, ByVal value As DateTime) As DateTime
            Return DateTime.Parse(_ini.GetValue(mstrSectName, key, value.ToString))
        End Function
        'Stringの配列
        Public Overloads Sub ReadKey(ByVal key As String, ByVal value() As String)
            Try
                Dim count As Integer = ReadKey(key & "Count", 0%)
                If count > value.Length Then count = value.Length
                For i As Integer = 0 To count - 1
                    value(i) = ReadKey(key & i, "")
                Next
            Catch ex As Exception
            End Try
        End Sub
        'Shortの配列
        Public Overloads Sub ReadKey(ByVal key As String, ByVal value() As Short)
            Try
                Dim count As Integer = ReadKey(key & "Count", 0%)
                If count > value.Length Then count = value.Length
                For i As Integer = 0 To count - 1
                    value(i) = ReadKey(key & i, 0S)
                Next
            Catch ex As Exception
            End Try
        End Sub
        'Integerの配列
        Public Overloads Sub ReadKey(ByVal key As String, ByVal value() As Integer)
            Try
                Dim count As Integer = ReadKey(key & "Count", 0%)
                If count > value.Length Then count = value.Length
                For i As Integer = 0 To count - 1
                    value(i) = ReadKey(key & i, 0%)
                Next
            Catch ex As Exception
            End Try
        End Sub
        'Singleの配列
        Public Overloads Sub ReadKey(ByVal key As String, ByVal value() As Single)
            Try
                Dim count As Integer = ReadKey(key & "Count", 0%)
                If count > value.Length Then count = value.Length
                For i As Integer = 0 To count - 1
                    value(i) = ReadKey(key & i, 0.0!)
                Next
            Catch ex As Exception
            End Try
        End Sub
        'Booleanの配列
        Public Overloads Sub ReadKey(ByVal key As String, ByVal value() As Boolean)
            Try
                Dim count As Integer = ReadKey(key & "Count", 0%)
                If count > value.Length Then count = value.Length
                For i As Integer = 0 To count - 1
                    value(i) = ReadKey(key & i, False)
                Next
            Catch ex As Exception
            End Try
        End Sub
        'DateTimeの配列
        Public Overloads Sub ReadKey(ByVal key As String, ByVal value() As DateTime)
            Try
                Dim count As Integer = ReadKey(key & "Count", 0%)
                If count > value.Length Then count = value.Length
                For i As Integer = 0 To count - 1
                    value(i) = ReadKey(key & i, Now)
                Next
            Catch ex As Exception
            End Try
        End Sub

        ''' <summary>キーの値を保存</summary>
        ''' <param name="key">キー</param>
        ''' <param name="value">値</param>
        ''' <remarks>
        ''' 配列は１次元のみ、添え字は0から。
        ''' </remarks>
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value As String)
            _ini.WriteValue(mstrSectName, key, value)
        End Sub
        'Short
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value As Short)
            _ini.WriteValue(mstrSectName, key, value.ToString)
        End Sub
        'Integer
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value As Integer)
            _ini.WriteValue(mstrSectName, key, value.ToString)
        End Sub
        'Single
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value As Single)
            _ini.WriteValue(mstrSectName, key, value.ToString)
        End Sub
        'Boolean
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value As Boolean)
            _ini.WriteValue(mstrSectName, key, value.ToString)
        End Sub
        'DateTime
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value As DateTime)
            _ini.WriteValue(mstrSectName, key, value.ToString)
        End Sub
        'Stringの配列
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As String)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'Shortの配列
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As Short)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'Integerの配列
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As Integer)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'Singleの配列
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As Single)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'Booleanの配列
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As Boolean)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'DateTimeの配列
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As DateTime)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub

#End Region

    End Class

End Namespace