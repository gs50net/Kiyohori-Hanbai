Imports DevExpress.XtraEditors
Imports System.Runtime.InteropServices

Namespace Functions

    ''' <summary>
    ''' ���b�Z�[�W�֌W�̃N���X
    ''' </summary>
    ''' <remarks>���̃N���X�̓C���X�^���X���ł��܂���B</remarks>
    Public Class CFncMessage

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
        ''' ���b�Z�[�W �{�b�N�X��\�����܂�
        ''' </summary>
        ''' <param name="strMsg">���b�Z�[�W</param>
        ''' <param name="strCaption">�L���v�V����</param>
        ''' <param name="buttons">�{�^��</param>
        ''' <param name="icon">�A�C�R��</param>
        ''' <param name="defaultButton">�K��{�^��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function MessageBox( _
                                            ByVal strMsg As String, _
                                            ByVal strCaption As String, _
                                            ByVal buttons As MessageBoxButtons, _
                                            ByVal icon As MessageBoxIcon, _
                                            ByVal defaultButton As MessageBoxDefaultButton _
                                            ) As DialogResult

            Microsoft.VisualBasic.Beep()

            Return XtraMessageBox.Show(strMsg, strCaption, buttons, icon, defaultButton)

        End Function

        ''' <summary>
        ''' ���b�Z�[�W �{�b�N�X��\�����܂�
        ''' </summary>
        ''' <param name="strMsg"></param>
        ''' <param name="strCaption"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function MessageBox( _
                                            ByVal strMsg As String, _
                                            ByVal strCaption As String, _
                                            ByVal buttons As MessageBoxButtons _
                                            ) As DialogResult

            Microsoft.VisualBasic.Beep()

            Return XtraMessageBox.Show(strMsg, strCaption, buttons)

        End Function

        ''' <summary>
        ''' ���b�Z�[�W �{�b�N�X��\�����܂�
        ''' </summary>
        ''' <param name="strMsg"></param>
        ''' <param name="strCaption"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function MessageBox( _
                                            ByVal strMsg As String, _
                                            ByVal strCaption As String _
                                            ) As DialogResult

            Microsoft.VisualBasic.Beep()

            Return XtraMessageBox.Show(strMsg, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Function

        ''' <summary>
        ''' ���b�Z�[�W �{�b�N�X��\�����܂�
        ''' </summary>
        ''' <param name="strMsg"></param>
        ''' <param name="strCaption"></param>
        ''' <param name="buttons"></param>
        ''' <param name="icon"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function MessageBox( _
                                            ByVal strMsg As String, _
                                            ByVal strCaption As String, _
                                            ByVal buttons As MessageBoxButtons, _
                                            ByVal icon As MessageBoxIcon _
                                            ) As DialogResult

            Microsoft.VisualBasic.Beep()

            Return XtraMessageBox.Show(strMsg, strCaption, buttons, icon)

        End Function

        '''' <summary>
        '''' ���b�Z�[�W �{�b�N�X��\�����܂�
        '''' </summary>
        '''' <param name="strMsg"></param>
        '''' <remarks></remarks>
        'Public Overloads Shared Sub MessageBox(ByVal strMsg As String)

        '    Microsoft.VisualBasic.Beep()

        '    Windows.Forms.MessageBox.Show(strMsg)

        'End Sub

        ''' <summary>
        ''' �G���[���b�Z�[�W
        ''' </summary>
        ''' <param name="strMsg">���b�Z�[�W</param>
        ''' <param name="strCaption">�L���v�V����</param>
        ''' <remarks></remarks>
        Public Shared Sub ErrorMessage( _
                                ByVal strMsg As String, _
                                Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.Error, _
                                Optional ByVal strCaption As String = "" _
                                )

            Microsoft.VisualBasic.Beep()

            If strCaption = String.Empty Then
                strCaption = My.Resources.MSG_ERROR
            End If

            XtraMessageBox.Show(strMsg, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Sub

#End Region

    End Class

End Namespace
