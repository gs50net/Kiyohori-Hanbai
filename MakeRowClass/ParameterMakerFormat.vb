Namespace DataBase

    ''' <summary>
    ''' �p�����[�^�N�G���[�Ɉ����n���p�����[�^�}�[�J�𐶐�����@�N���X
    ''' </summary>
    ''' <remarks>
    ''' ���@ACCESS�����g�p���ɂ́ASQL�����̃p�����[�^�̏�����command.Parameters.Add�̏�������v�����邱��
    ''' </remarks>
    Public Class ParameterMakerFormat

#Region "�����o�[�ϐ�"

        ''' <summary>
        ''' �v���o�C�_�[�̎��
        ''' </summary>
        ''' <remarks></remarks>
        Private menmProvider As enmProvider

#End Region

#Region "�R���X�g���N�^"

        ''' <summary>
        '''  �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="Provider">�v���o�C�_�[�̎��</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Provider As enmProvider)

            menmProvider = Provider

        End Sub

        ''' <summary>
        ''' �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="cnn">�R�l�N�V����</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal cnn As Connection)

            menmProvider = cnn.Provider

        End Sub

#End Region

#Region "���\�b�h"

        ''' <summary>
        ''' �p�����[�^�}�[�J�𐶐����܂�
        ''' </summary>
        ''' <param name="strParameterName">�p���[���[�^�[��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetParameterMakerFormat(ByVal strParameterName As String) As String

            Select Case menmProvider
                Case enmProvider.MDB
                    Return "?"
                Case enmProvider.SQLServer
                    Return strParameterName
                Case Else
                    Return strParameterName
            End Select

        End Function

#End Region

    End Class

End Namespace