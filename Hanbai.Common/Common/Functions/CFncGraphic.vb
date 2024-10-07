#Region "�Q��"

Imports System.IO

#End Region

Namespace Functions

    ''' <summary>
    ''' �O���t�B�b�N�֌W�̃N���X
    ''' </summary>
    ''' <remarks>���̃N���X�̓C���X�^���X���ł��܂���B</remarks>
    Public Class CFncGraphic

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <remarks>���̃R���X�g���N�^�͂��̃N���X���C���X�^���X�����ł��Ȃ��悤�ɂ��܂��B</remarks>
        Private Sub New()
        End Sub

#End Region

        ''' <summary>
        ''' �C���[�W�t�@�C����ǂݍ���Image�𐶐�����
        ''' </summary>
        ''' <param name="strFileName">�C���[�W�t�@�C����</param>
        ''' <returns>��������� Image ���Ԃ�܂��B���s����� Nothing ���Ԃ�܂��B</returns>
        ''' <remarks></remarks>
        Public Shared Function LoadImageFile(ByVal strFileName As String) As Image

            Dim img As Image = Nothing

            If File.Exists(strFileName) Then
                Try
                    img = New Bitmap(strFileName)
                Catch ex As Exception
                    Debug.WriteLine(strFileName, "CFncGraphic.LoadImageFile Error")
                End Try
            Else
                Debug.WriteLine(strFileName, "CFncGraphic.LoadImageFile Error")
            End If

            Return img

        End Function

    End Class

End Namespace