Namespace Functions

    ''' <summary>
    ''' �f�o�b�O�֌W�̃N���X
    ''' </summary>
    ''' <remarks>���̃N���X�̓C���X�^���X���ł��܂���B</remarks>
    Public Class CFncDebug

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <remarks>���̃R���X�g���N�^�͂��̃N���X���C���X�^���X�����ł��Ȃ��悤�ɂ��܂��B</remarks>
        Private Sub New()
        End Sub

#End Region

#Region "���\�b�h�|���Ԍv��"

        ''' <summary>
        ''' ���Ԍv���J�n
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function StartStopWatch() As Stopwatch

            Dim sw As New Stopwatch
            sw.Start()
            Return sw

        End Function

        ''' <summary>
        ''' ���Ԍv���I��
        ''' </summary>
        ''' <param name="sw"></param>
        ''' <param name="strMsg"></param>
        ''' <remarks></remarks>
        Public Shared Sub StopStopWatch(ByVal sw As Stopwatch, Optional ByVal strMsg As String = "")

            sw.Stop()
            Dim millisec As Long = sw.ElapsedMilliseconds
            Debug.WriteLine(strMsg & " " & millisec)

        End Sub

#End Region

    End Class

End Namespace