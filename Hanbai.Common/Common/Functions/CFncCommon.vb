#Region "�Q��"

Imports System.IO
Imports System.Globalization

#End Region

Namespace Functions

    ''' <summary>
    ''' ����
    ''' </summary>
    ''' <remarks>���̃N���X�̓C���X�^���X���ł��܂���B</remarks>
    Public Class CFncCommon

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <remarks>���̃R���X�g���N�^�͂��̃N���X���C���X�^���X�����ł��Ȃ��悤�ɂ��܂��B</remarks>
        Private Sub New()
        End Sub

#End Region

#Region "���\�b�h�|�I�u�W�F�N�g�ϊ�"

        ''' <summary>
        ''' Obj����String�ւ̕ϊ� 
        ''' </summary>
        ''' <param name="obj">�I�u�W�F�N�g</param>
        ''' <returns>String</returns>
        ''' <remarks>�f�[�^�[�x�[�X���ڂ̕ϊ��Ɏg�p����</remarks>
        Public Shared Function ObjToStr(ByVal obj As Object) As String

            If Not IsDBNull(obj) Then
                Return CStr(obj)
            End If

            Return String.Empty

        End Function

        ''' <summary>
        ''' Obj����Integer�ւ̕ϊ�
        ''' </summary>
        ''' <param name="obj">�I�u�W�F�N�g</param>
        ''' <returns>Integer</returns>
        ''' <remarks>�f�[�^�[�x�[�X���ڂ̕ϊ��Ɏg�p����</remarks>
        Public Shared Function ObjToInt(ByVal obj As Object) As Integer

            If IsDBNull(obj) OrElse CStr(obj) = String.Empty Then
                Return 0
            Else
                Return CInt(obj)
            End If

        End Function

        ''' <summary>
        ''' Obj����Boolean�ւ̕ϊ�
        ''' </summary>
        ''' <param name="obj">�I�u�W�F�N�g</param>
        ''' <returns>Boolean</returns>
        ''' <remarks>�f�[�^�[�x�[�X���ڂ̕ϊ��Ɏg�p����</remarks>
        Public Shared Function ObjToBool(ByVal obj As Object) As Boolean

            If ObjToInt(obj) = 0 Then
                Return False
            Else
                Return True
            End If

        End Function

        ''' <summary>
        ''' Obj����Short�ւ̕ϊ�
        ''' </summary>
        ''' <param name="obj">�I�u�W�F�N�g</param>
        ''' <returns>Short</returns>
        ''' <remarks>�f�[�^�[�x�[�X���ڂ̕ϊ��Ɏg�p����</remarks>
        Public Shared Function ObjToSht(ByVal obj As Object) As Short

            If IsDBNull(obj) OrElse CStr(obj) = String.Empty Then
                Return 0
            Else
                Return CShort(obj)
            End If

        End Function

        ''' <summary>
        ''' Obj����Byte�ւ̕ϊ�
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
        ''' Obj����Single�ւ̕ϊ�
        ''' </summary>
        ''' <param name="obj">�I�u�W�F�N�g</param>
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
        ''' Obj����Double�ւ̕ϊ�
        ''' </summary>
        ''' <param name="obj">�I�u�W�F�N�g</param>
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
        ''' Obj����Decimal�ւ̕ϊ�
        ''' </summary>
        ''' <param name="obj">�I�u�W�F�N�g</param>
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
        ''' Obj����GUID�ւ̕ϊ�
        ''' </summary>
        ''' <param name="obj">�I�u�W�F�N�g</param>
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

#Region "���\�b�h�|���t"

        ''' <summary>
        ''' �����񂩂���t�֕ϊ�����(yyyyMMdd)
        ''' </summary>
        ''' <param name="strDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ToStrDate(ByVal strDate As String) As Date

            Return Date.Parse(Format(CInt(strDate), "0000/00/00"))

        End Function

        ''' <summary>
        ''' ���t�𕶎���֕ϊ�����(yyyyMMdd)
        ''' </summary>
        ''' <param name="dt">���t�^</param>
        ''' <returns>yyyymmdd������</returns>
        ''' <remarks></remarks>
        Public Shared Function ToDateStr(ByVal dt As Date) As String

            Return String.Format("{0:yyyyMMdd}", dt)

        End Function

        '''' <summary>
        '''' Today�擾
        '''' </summary>
        '''' <param name="blnWithTime">true:�������� false:�����Ȃ�(00:00)</param>
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
        ''' �a��ҏW
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <param name="strFmt"></param>
        ''' <returns></returns>
        ''' <remarks>�� strFmt:"gy�NM��d��(ddd)"</remarks>
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
        ''' ���t���N���̂ݎ擾����
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
        ''' ������r�i�b���j
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

        Public Shared Function compute�o�ߌ�(ByVal date1 As DateTime, date2 As DateTime) As String
            '����CaltureInfo���o���Ă���
            Dim originalCalture As Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture

            '���݂̃X���b�h�̃J���`�����J���`���Ɉˑ����Ȃ�CultureInfo�ɍ����ւ���
            Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture

            Dim a As Date = #1/1/1985#  '1985�N1��1���i���a60�N1��1���j
            Dim b As Date = #1/1/2000#  '2000�N1��1���i����12�N1��1���j

            Dim mm As Integer = CInt(DateDiff(DateInterval.Month, date1, date2))

            '���ɉe�����o�Ȃ��悤�Ɍ���CaltureInfo�ɖ߂�
            Threading.Thread.CurrentThread.CurrentCulture = originalCalture

            If mm <= 12 Then
                Return String.Format("{0}����", mm)
            Else
                Dim yy As Integer = CInt(Math.Floor(mm / 12))
                mm = mm - yy * 12
                Return String.Format("{0}�N{1}����", yy, mm)
            End If

        End Function

#End Region

#Region "���\�b�h�|������"

        ''' -----------------------------------------------------------------------------------
        ''' <summary>
        '''     ������̍��[����w�肳�ꂽ���������̕������Ԃ��܂��B</summary>
        ''' <param name="stTarget">
        '''     ���o�����ɂȂ镶����B</param>
        ''' <param name="iLength">
        '''     ���o���������B</param>
        ''' <returns>
        '''     ���[����w�肳�ꂽ���������̕�����B
        '''     �������𒴂����ꍇ�́A������S�̂��Ԃ���܂��B</returns>
        ''' -----------------------------------------------------------------------------------
        Public Shared Function Left(ByVal stTarget As String, ByVal iLength As Integer) As String
            If iLength <= stTarget.Length Then
                Return stTarget.Substring(0, iLength)
            End If

            Return stTarget
        End Function

        ''' -----------------------------------------------------------------------------------
        ''' <summary>
        '''     ������̎w�肳�ꂽ�ʒu�ȍ~�̂��ׂĂ̕������Ԃ��܂��B</summary>
        ''' <param name="stTarget">
        '''     ���o�����ɂȂ镶����B</param>
        ''' <param name="iStart">
        '''     ���o�����J�n����ʒu�B</param>
        ''' <returns>
        '''     �w�肳�ꂽ�ʒu�ȍ~�̂��ׂĂ̕�����B</returns>
        ''' -----------------------------------------------------------------------------------
        Public Overloads Shared Function Mid(ByVal stTarget As String, ByVal iStart As Integer) As String
            If iStart <= stTarget.Length Then
                Return stTarget.Substring(iStart)
            End If

            Return String.Empty
        End Function

        ''' -----------------------------------------------------------------------------------
        ''' <summary>
        '''     ������̎w�肳�ꂽ�ʒu����A�w�肳�ꂽ���������̕������Ԃ��܂��B</summary>
        ''' <param name="stTarget">
        '''     ���o�����ɂȂ镶����B</param>
        ''' <param name="iStart">
        '''     ���o�����J�n����ʒu�B</param>
        ''' <param name="iLength">
        '''     ���o���������B</param>
        ''' <returns>
        '''     �w�肳�ꂽ�ʒu����w�肳�ꂽ���������̕�����B
        '''     �������𒴂����ꍇ�́A�w�肳�ꂽ�ʒu���炷�ׂĂ̕����񂪕Ԃ���܂��B</returns>
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
        '''     ������̉E�[����w�肳�ꂽ���������̕������Ԃ��܂��B</summary>
        ''' <param name="stTarget">
        '''     ���o�����ɂȂ镶����B</param>
        ''' <param name="iLength">
        '''     ���o���������B</param>
        ''' <returns>
        '''     �E�[����w�肳�ꂽ���������̕�����B
        '''     �������𒴂����ꍇ�́A������S�̂��Ԃ���܂��B</returns>
        ''' -----------------------------------------------------------------------------------
        Public Shared Function Right(ByVal stTarget As String, ByVal iLength As Integer) As String
            If iLength <= stTarget.Length Then
                Return stTarget.Substring(stTarget.Length - iLength)
            End If

            Return stTarget
        End Function

#End Region

#Region "���\�b�h�|���̑�"

        ''' <summary>
        ''' �A�v���P�[�V�����̃J�[�\����ҋ@�J�[�\���ɐݒ肷��
        ''' </summary>
        ''' <param name="bln">true:�\�� false:��\��</param>
        ''' <remarks></remarks>
        Public Shared Sub SetUseWaitCursor(ByVal bln As Boolean)

            Application.UseWaitCursor = bln
            If bln Then
                '���b�Z�[�W �L���[�Ɍ��݂��� Windows ���b�Z�[�W�����ׂď�������
                Application.DoEvents()
            End If

        End Sub

        ''' <summary>
        ''' ���t���J���`���[�����t�H�[�}�b�g����
        ''' </summary>
        ''' <param name="dteDate">���t</param>
        ''' <param name="blnKanji">���� true:���� false:�p��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function FormatDate(ByVal dteDate As DateTime, Optional ByVal blnKanji As Boolean = False) As String

            If dteDate.ToOADate = 0 Then
                Return String.Empty
            End If

            Dim strFmt As String
            '�J���`���[���
            'strFmt = "ggy�NM��d��"
            'Dim culture As CultureInfo = New CultureInfo("ja-JP", True)
            'culture.DateTimeFormat.Calendar = New JapaneseCalendar()
            'culture.DateTimeFormat.LongDatePattern = strFmt
            'Return dteDate.ToString(strFmt, culture)
            Dim jpn As JapaneseCalendar = New JapaneseCalendar()
            Dim aGengo As String()
            If blnKanji Then
                aGengo = New String() {"����", "�吳", "���a", "����"}
                strFmt = "{0}{1,2:00}�N{2,2:00}��{3,2:00}��"
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

#Region "���\�b�h ���l�܂��"

        ''' <summary>
        ''' �w�肵�����x�̐��l�ɐ؂�̂Ă��܂��B
        ''' </summary>
        ''' <param name="dValue">�ۂߑΏۂ̔{���x���������_���B</param>
        ''' <param name="iDigits">�߂�l�̗L�������̐��x�B</param>
        ''' <returns>iDigits �ɓ��������x�̐��l�ɐ؂�̂Ă�ꂽ���l�B</returns>
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

#Region "���\�b�h �R���o�[�g"

        Public Shared Function ConvertIntegerObj(ByVal obj As Object) As Object
            If IsDBNull(obj) Then
                Return DBNull.Value
            End If

            Dim str As String = CFncCommon.ObjToStr(obj)
            Dim arChar() As Char = str.ToCharArray

            '�S�ċ󔒂����ׂ�
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

        '�o�C�g�z���Image�I�u�W�F�N�g�֕ϊ�
        Public Shared Function ByteArrayToImage(ByVal b As Byte()) As Image
            Dim imgconv As New ImageConverter()
            Dim img As Image = CType(imgconv.ConvertFrom(b), Image)
            Return img
        End Function

        'Image���o�C�g�z����֕ϊ�
        Public Shared Function ImageToByteArray(ByVal img As Image) As Byte()
            Dim imgconv As New ImageConverter()
            Dim byt As Byte() = CType(imgconv.ConvertTo(img, GetType(Byte())), Byte())
            Return byt
        End Function

#End Region

    End Class

End Namespace
