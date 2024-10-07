#Region "参照"

Imports System.IO
Imports System.Globalization

#End Region

Namespace Functions

    ''' <summary>
    ''' 共通
    ''' </summary>
    ''' <remarks>このクラスはインスタンス化できません。</remarks>
    Public Class CFncCommon

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks>このコンストラクタはこのクラスをインスタンス化をできないようにします。</remarks>
        Private Sub New()
        End Sub

#End Region

#Region "メソッド－オブジェクト変換"

        ''' <summary>
        ''' ObjからStringへの変換 
        ''' </summary>
        ''' <param name="obj">オブジェクト</param>
        ''' <returns>String</returns>
        ''' <remarks>データーベース項目の変換に使用する</remarks>
        Public Shared Function ObjToStr(ByVal obj As Object) As String

            If Not IsDBNull(obj) Then
                Return CStr(obj)
            End If

            Return String.Empty

        End Function

        ''' <summary>
        ''' ObjからIntegerへの変換
        ''' </summary>
        ''' <param name="obj">オブジェクト</param>
        ''' <returns>Integer</returns>
        ''' <remarks>データーベース項目の変換に使用する</remarks>
        Public Shared Function ObjToInt(ByVal obj As Object) As Integer

            If IsDBNull(obj) OrElse CStr(obj) = String.Empty Then
                Return 0
            Else
                Return CInt(obj)
            End If

        End Function

        ''' <summary>
        ''' ObjからBooleanへの変換
        ''' </summary>
        ''' <param name="obj">オブジェクト</param>
        ''' <returns>Boolean</returns>
        ''' <remarks>データーベース項目の変換に使用する</remarks>
        Public Shared Function ObjToBool(ByVal obj As Object) As Boolean

            If ObjToInt(obj) = 0 Then
                Return False
            Else
                Return True
            End If

        End Function

        ''' <summary>
        ''' ObjからShortへの変換
        ''' </summary>
        ''' <param name="obj">オブジェクト</param>
        ''' <returns>Short</returns>
        ''' <remarks>データーベース項目の変換に使用する</remarks>
        Public Shared Function ObjToSht(ByVal obj As Object) As Short

            If IsDBNull(obj) OrElse CStr(obj) = String.Empty Then
                Return 0
            Else
                Return CShort(obj)
            End If

        End Function

        ''' <summary>
        ''' ObjからByteへの変換
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns>Byte</returns>
        ''' <remarks></remarks>
        Public Shared Function ObjToByt(ByVal obj As Object) As Byte

            If IsDBNull(obj) OrElse CStr(obj) = String.Empty Then
                Return 0
            Else
                Return CByte(obj)
            End If

        End Function

        ''' <summary>
        ''' ObjからSingleへの変換
        ''' </summary>
        ''' <param name="obj">オブジェクト</param>
        ''' <returns>Single</returns>
        ''' <remarks></remarks>
        Public Shared Function ObjToSng(ByVal obj As Object) As Single

            If IsDBNull(obj) OrElse CStr(obj) = String.Empty Then
                Return 0
            Else
                Return CSng(obj)
            End If

        End Function

        ''' <summary>
        ''' ObjからDoubleへの変換
        ''' </summary>
        ''' <param name="obj">オブジェクト</param>
        ''' <returns>Single</returns>
        ''' <remarks></remarks>
        Public Shared Function ObjToDbl(ByVal obj As Object) As Double

            If IsDBNull(obj) OrElse CStr(obj) = String.Empty Then
                Return 0
            Else
                Return CDbl(obj)
            End If

        End Function

        ''' <summary>
        ''' ObjからDecimalへの変換
        ''' </summary>
        ''' <param name="obj">オブジェクト</param>
        ''' <returns>Decimal</returns>
        ''' <remarks></remarks>
        Public Shared Function ObjToDec(ByVal obj As Object) As Decimal

            If IsDBNull(obj) OrElse CStr(obj) = String.Empty Then
                Return 0
            Else
                Return CDec(obj)
            End If

        End Function

        ''' <summary>
        ''' ObjからGUIDへの変換
        ''' </summary>
        ''' <param name="obj">オブジェクト</param>
        ''' <returns>GUID</returns>
        ''' <remarks></remarks>
        Public Shared Function ObjToGuid(ByVal obj As Object) As System.Guid

            If IsDBNull(obj) Then
                Return System.Guid.Empty
            Else
                Return DirectCast(obj, System.Guid)
            End If

        End Function

#End Region

#Region "メソッド－日付"

        ''' <summary>
        ''' 文字列から日付へ変換する(yyyyMMdd)
        ''' </summary>
        ''' <param name="strDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ToStrDate(ByVal strDate As String) As Date

            Return Date.Parse(Format(CInt(strDate), "0000/00/00"))

        End Function

        ''' <summary>
        ''' 日付を文字列へ変換する(yyyyMMdd)
        ''' </summary>
        ''' <param name="dt">日付型</param>
        ''' <returns>yyyymmdd文字列</returns>
        ''' <remarks></remarks>
        Public Shared Function ToDateStr(ByVal dt As Date) As String

            Return String.Format("{0:yyyyMMdd}", dt)

        End Function

        '''' <summary>
        '''' Today取得
        '''' </summary>
        '''' <param name="blnWithTime">true:時刻あり false:時刻なし(00:00)</param>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Shared Function GetToday(Optional ByVal blnWithTime As Boolean = True) As Date

        '    Dim dt As Date = Today

        '    Select Case blnWithTime
        '        Case True
        '            Return dt
        '        Case False
        '            Return New Date(dt.Year, dt.Month, dt.Day)
        '    End Select

        'End Function

        ''' <summary>
        ''' 和暦編集
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <param name="strFmt"></param>
        ''' <returns></returns>
        ''' <remarks>例 strFmt:"gy年M月d日(ddd)"</remarks>
        Public Shared Function ToWarekiStr(ByVal obj As Object, ByVal strFmt As String) As String

            If IsDBNull(obj) Then
                Return String.Empty
            End If

            Dim dt As Date = CDate(obj)
            Dim jc As New JapaneseCalendar
            Dim jp As New CultureInfo("ja-JP")
            jp.DateTimeFormat.Calendar = jc

            Dim str As String = String.Format(jp, "{0:" & strFmt & "}", dt)

            Return str

        End Function

        ''' <summary>
        ''' 日付より年月のみ取得する
        ''' </summary>
        ''' <param name="dte"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function ToDateYearMonth(ByVal dte As DateTime) As DateTime
            Dim ret As New DateTime(dte.Year, dte.Month, 1)
            Return ret
        End Function

        Public Overloads Shared Function ToDateYearMonth(ByVal dte As Object) As DateTime
            Dim ret As New DateTime(CDate(dte).Year, CDate(dte).Month, 1)
            Return ret
        End Function

        ''' <summary>
        ''' 日時比較（秒迄）
        ''' </summary>
        ''' <param name="time1"></param>
        ''' <param name="time2"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CompareDatetime(ByVal time1 As DateTime, ByVal time2 As DateTime) As Integer
            Dim lngtime1 As Long = time1.Year * 10000000000 +
                                   time1.Month * 100000000 +
                                   time1.Day * 1000000 +
                                   time1.Hour * 10000 +
                                   time1.Minute * 100 +
                                   time1.Second
            Dim lngtime2 As Long = time2.Year * 10000000000 +
                                   time2.Month * 100000000 +
                                   time2.Day * 1000000 +
                                   time2.Hour * 10000 +
                                   time2.Minute * 100 +
                                   time2.Second
            If lngtime1 = lngtime2 Then
                Return 0
            End If
            If lngtime1 > lngtime2 Then
                Return 1
            Else
                Return -1
            End If
        End Function

        Public Shared Function compute経過月(ByVal date1 As DateTime, date2 As DateTime) As String
            '元のCaltureInfoを覚えておく
            Dim originalCalture As Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture

            '現在のスレッドのカルチャをカルチャに依存しないCultureInfoに差し替える
            Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture

            Dim a As Date = #1/1/1985#  '1985年1月1日（昭和60年1月1日）
            Dim b As Date = #1/1/2000#  '2000年1月1日（平成12年1月1日）

            Dim mm As Integer = CInt(DateDiff(DateInterval.Month, date1, date2))

            '他に影響が出ないように元のCaltureInfoに戻す
            Threading.Thread.CurrentThread.CurrentCulture = originalCalture

            If mm <= 12 Then
                Return String.Format("{0}ヶ月", mm)
            Else
                Dim yy As Integer = CInt(Math.Floor(mm / 12))
                mm = mm - yy * 12
                Return String.Format("{0}年{1}ヶ月", yy, mm)
            End If

        End Function

#End Region

#Region "メソッド－文字列"

        ''' -----------------------------------------------------------------------------------
        ''' <summary>
        '''     文字列の左端から指定された文字数分の文字列を返します。</summary>
        ''' <param name="stTarget">
        '''     取り出す元になる文字列。</param>
        ''' <param name="iLength">
        '''     取り出す文字数。</param>
        ''' <returns>
        '''     左端から指定された文字数分の文字列。
        '''     文字数を超えた場合は、文字列全体が返されます。</returns>
        ''' -----------------------------------------------------------------------------------
        Public Shared Function Left(ByVal stTarget As String, ByVal iLength As Integer) As String
            If iLength <= stTarget.Length Then
                Return stTarget.Substring(0, iLength)
            End If

            Return stTarget
        End Function

        ''' -----------------------------------------------------------------------------------
        ''' <summary>
        '''     文字列の指定された位置以降のすべての文字列を返します。</summary>
        ''' <param name="stTarget">
        '''     取り出す元になる文字列。</param>
        ''' <param name="iStart">
        '''     取り出しを開始する位置。</param>
        ''' <returns>
        '''     指定された位置以降のすべての文字列。</returns>
        ''' -----------------------------------------------------------------------------------
        Public Overloads Shared Function Mid(ByVal stTarget As String, ByVal iStart As Integer) As String
            If iStart <= stTarget.Length Then
                Return stTarget.Substring(iStart)
            End If

            Return String.Empty
        End Function

        ''' -----------------------------------------------------------------------------------
        ''' <summary>
        '''     文字列の指定された位置から、指定された文字数分の文字列を返します。</summary>
        ''' <param name="stTarget">
        '''     取り出す元になる文字列。</param>
        ''' <param name="iStart">
        '''     取り出しを開始する位置。</param>
        ''' <param name="iLength">
        '''     取り出す文字数。</param>
        ''' <returns>
        '''     指定された位置から指定された文字数分の文字列。
        '''     文字数を超えた場合は、指定された位置からすべての文字列が返されます。</returns>
        ''' -----------------------------------------------------------------------------------
        Public Overloads Shared Function Mid(ByVal stTarget As String, ByVal iStart As Integer, ByVal iLength As Integer) As String
            If iStart <= stTarget.Length Then
                If iStart + iLength <= stTarget.Length Then
                    Return stTarget.Substring(iStart, iLength)
                End If

                Return stTarget.Substring(iStart)
            End If

            Return String.Empty
        End Function

        ''' -----------------------------------------------------------------------------------
        ''' <summary>
        '''     文字列の右端から指定された文字数分の文字列を返します。</summary>
        ''' <param name="stTarget">
        '''     取り出す元になる文字列。</param>
        ''' <param name="iLength">
        '''     取り出す文字数。</param>
        ''' <returns>
        '''     右端から指定された文字数分の文字列。
        '''     文字数を超えた場合は、文字列全体が返されます。</returns>
        ''' -----------------------------------------------------------------------------------
        Public Shared Function Right(ByVal stTarget As String, ByVal iLength As Integer) As String
            If iLength <= stTarget.Length Then
                Return stTarget.Substring(stTarget.Length - iLength)
            End If

            Return stTarget
        End Function

#End Region

#Region "メソッド－その他"

        ''' <summary>
        ''' アプリケーションのカーソルを待機カーソルに設定する
        ''' </summary>
        ''' <param name="bln">true:表示 false:非表示</param>
        ''' <remarks></remarks>
        Public Shared Sub SetUseWaitCursor(ByVal bln As Boolean)

            Application.UseWaitCursor = bln
            If bln Then
                'メッセージ キューに現在ある Windows メッセージをすべて処理する
                Application.DoEvents()
            End If

        End Sub

        ''' <summary>
        ''' 日付をカルチャー情報よりフォーマットする
        ''' </summary>
        ''' <param name="dteDate">日付</param>
        ''' <param name="blnKanji">元号 true:漢字 false:英字</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function FormatDate(ByVal dteDate As DateTime, Optional ByVal blnKanji As Boolean = False) As String

            If dteDate.ToOADate = 0 Then
                Return String.Empty
            End If

            Dim strFmt As String
            'カルチャー情報
            'strFmt = "ggy年M月d日"
            'Dim culture As CultureInfo = New CultureInfo("ja-JP", True)
            'culture.DateTimeFormat.Calendar = New JapaneseCalendar()
            'culture.DateTimeFormat.LongDatePattern = strFmt
            'Return dteDate.ToString(strFmt, culture)
            Dim jpn As JapaneseCalendar = New JapaneseCalendar()
            Dim aGengo As String()
            If blnKanji Then
                aGengo = New String() {"明治", "大正", "昭和", "平成"}
                strFmt = "{0}{1,2:00}年{2,2:00}月{3,2:00}日"
            Else
                aGengo = New String() {"M", "T", "S", "H"}
                strFmt = "{0}{1,2:00}/{2,2:00}/{3,2:00}"
            End If
            Dim strDate As String
            strDate = String.Format(strFmt, _
                                        aGengo(jpn.GetEra(dteDate) - 1), _
                                        jpn.GetYear(dteDate), _
                                        jpn.GetMonth(dteDate), _
                                        jpn.GetDayOfMonth(dteDate))
            Return strDate

        End Function

#End Region

#Region "メソッド 数値まるめ"

        ''' <summary>
        ''' 指定した精度の数値に切り捨てします。
        ''' </summary>
        ''' <param name="dValue">丸め対象の倍精度浮動小数点数。</param>
        ''' <param name="iDigits">戻り値の有効桁数の精度。</param>
        ''' <returns>iDigits に等しい精度の数値に切り捨てられた数値。</returns>
        ''' <remarks></remarks>
        Public Shared Function ToRoundDown(ByVal dValue As Double, ByVal iDigits As Integer) As Double
            Dim dCoef As Double = System.Math.Pow(10, iDigits)

            If dValue > 0 Then
                Return System.Math.Floor(dValue * dCoef) / dCoef
            Else
                Return System.Math.Ceiling(dValue * dCoef) / dCoef
            End If
        End Function

#End Region

#Region "メソッド コンバート"

        Public Shared Function ConvertIntegerObj(ByVal obj As Object) As Object
            If IsDBNull(obj) Then
                Return DBNull.Value
            End If

            Dim str As String = CFncCommon.ObjToStr(obj)
            Dim arChar() As Char = str.ToCharArray

            '全て空白か調べる
            Dim blnSpace As Boolean = True
            For Each c As Char In arChar
                If Not Char.IsWhiteSpace(c) Then
                    blnSpace = False
                    Exit For
                End If
            Next c

            If Not blnSpace Then
                Return CFncCommon.ObjToInt(str)
            Else
                Return DBNull.Value
            End If

        End Function

        Public Shared Function ConvertStringObj(ByVal obj As Object) As Object
            If IsDBNull(obj) Then
                Return DBNull.Value
            End If
            Dim str As String = CFncCommon.ObjToStr(obj)
            If str = String.Empty Then
                Return DBNull.Value
            Else
                Return str
            End If
        End Function

        Public Shared Function ConvertDateObj(ByVal obj As Object) As Object
            If IsDBNull(obj) Then
                Return DBNull.Value
            End If
            Dim str As String = CFncCommon.ObjToStr(obj)
            If str = String.Empty Then
                Return DBNull.Value
            Else
                Try
                    Dim dat As Date = CFncCommon.ToStrDate(str)
                    Return dat
                Catch ex As Exception
                    Return DBNull.Value
                End Try
            End If
        End Function

        'バイト配列をImageオブジェクトへ変換
        Public Shared Function ByteArrayToImage(ByVal b As Byte()) As Image
            Dim imgconv As New ImageConverter()
            Dim img As Image = CType(imgconv.ConvertFrom(b), Image)
            Return img
        End Function

        'Imageをバイト配列をへ変換
        Public Shared Function ImageToByteArray(ByVal img As Image) As Byte()
            Dim imgconv As New ImageConverter()
            Dim byt As Byte() = CType(imgconv.ConvertTo(img, GetType(Byte())), Byte())
            Return byt
        End Function

#End Region

    End Class

End Namespace
