Namespace Functions

    ''' <summary>
    ''' �b�r�u�֌W�̃N���X
    ''' </summary>
    ''' <remarks>���̃N���X�̓C���X�^���X���ł��܂���B</remarks>
    Public Class CFncCSV

#Region "�萔"

        'UniCode�̋�
        Private Const SPACE As Char = " "c

#End Region

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <remarks>���̃R���X�g���N�^�͂��̃N���X���C���X�^���X�����ł��Ȃ��悤�ɂ��܂��B</remarks>
        Private Sub New()
        End Sub

#End Region

#Region "���\�b�h"

        ''' <summary>
        ''' CSV������𕪉�����
        ''' </summary>
        ''' <param name="csvText">������</param>
        ''' <returns>������̕�����z��</returns>
        ''' <remarks>���̊֐��́u,�v��؂�̂b�r�u�̓ǂݍ��݂ł��B
        ''' TSV�́uSplit�v���g�p���邱��</remarks>
        Public Shared Function SplitCSVString(ByVal csvText As String) As String()

            '�O��̉��s���폜���Ă���
            csvText = csvText.Trim(New Char() {ControlChars.Cr, ControlChars.Lf})

            Dim csvRecords As New System.Collections.ArrayList
            Dim csvFields As New System.Collections.ArrayList

            Dim csvTextLength As Integer = csvText.Length
            Dim startPos As Integer = 0
            Dim endPos As Integer = 0
            Dim field As String = String.Empty

            While True
                '�󔒂��΂�
                While startPos < csvTextLength _
                    AndAlso (csvText.Chars(startPos) = SPACE OrElse csvText.Chars(startPos) = ControlChars.Tab)
                    startPos += 1
                End While

                '�f�[�^�̍Ō�̈ʒu���擾
                If startPos < csvTextLength AndAlso csvText.Chars(startPos) = ControlChars.Quote Then
                    '"�ň͂܂�Ă���Ƃ�
                    '�Ō��"��T��
                    endPos = startPos
                    While True
                        endPos = csvText.IndexOf(ControlChars.Quote, endPos + 1)
                        If endPos < 0 Then
                            Throw New ApplicationException("""���s��")
                        End If
                        '"��2�����Ȃ����͏I��
                        If endPos + 1 = csvTextLength OrElse csvText.Chars((endPos + 1)) <> ControlChars.Quote Then
                            Exit While
                        End If
                        '"��2����
                        endPos += 1
                    End While

                    '��̃t�B�[���h�����o��
                    field = csvText.Substring(startPos, endPos - startPos + 1)
                    '""��"�ɂ���
                    field = field.Substring(1, field.Length - 2).Replace("""""", """")

                    endPos += 1
                    '�󔒂��΂�
                    While endPos < csvTextLength AndAlso _
                        csvText.Chars(endPos) <> ","c AndAlso _
                        csvText.Chars(endPos) <> ControlChars.Lf
                        endPos += 1
                    End While
                Else
                    '"�ň͂܂�Ă��Ȃ�
                    '�J���}�����s�̈ʒu
                    endPos = startPos
                    While endPos < csvTextLength AndAlso _
                        csvText.Chars(endPos) <> ","c AndAlso _
                        csvText.Chars(endPos) <> ControlChars.Lf
                        endPos += 1
                    End While

                    '��̃t�B�[���h�����o��
                    field = csvText.Substring(startPos, endPos - startPos)
                    '��̋󔒂��폜
                    field = field.TrimEnd()
                End If

                '�t�B�[���h�̒ǉ�
                csvFields.Add(field)

                '�s�̏I�������ׂ�
                If endPos >= csvTextLength OrElse csvText.Chars(endPos) = ControlChars.Lf Then
                    '�s�̏I��
                    '���R�[�h�̒ǉ�
                    csvFields.TrimToSize()
                    csvRecords.Add(csvFields)
                    csvFields = New System.Collections.ArrayList(csvFields.Count)

                    If endPos >= csvTextLength Then
                        '�I��
                        Exit While
                    End If
                End If

                '���̃f�[�^�̊J�n�ʒu
                startPos = endPos + 1
            End While

            csvRecords.TrimToSize()

            Return DirectCast(CType(csvRecords.Item(0), System.Collections.ArrayList).ToArray(GetType(String)), String())

        End Function

#End Region

    End Class

End Namespace
