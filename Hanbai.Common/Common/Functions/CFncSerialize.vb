Namespace Functions

    ''' <summary>
    ''' �V���A���C�Y�֌W�̃N���X
    ''' </summary>
    ''' <remarks>���̃N���X�̓C���X�^���X���ł��܂���B</remarks>
    Public Class CFncSerialize

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
        ''' �N���X���V���A���C�Y������
        ''' </summary>
        ''' <param name="strFileName">�t�@�C����</param>
        ''' <param name="typClass">�N���X�̃^�C�v</param>
        ''' <param name="objClass">�V���A���C�Y����N���X</param>
        ''' <remarks></remarks>
        ''' <example>
        ''' SerializeClassToXML(strFileName, GetType(ClsCareCard), clsCard)
        ''' </example>
        Public Shared Sub SerializeClassToXML(ByVal strFileName As String, ByVal typClass As Type, ByVal objClass As Object)

            Try
                'XmlSerializer�I�u�W�F�N�g���쐬
                '�������ރI�u�W�F�N�g�̌^���w�肷��
                Dim serializer As New System.Xml.Serialization.XmlSerializer(typClass)
                '�t�@�C�����J��
                Dim fs As New System.IO.FileStream(strFileName, System.IO.FileMode.Create)
                '�V���A�������AXML�t�@�C���ɕۑ�����
                serializer.Serialize(fs, objClass)
                '����
                fs.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CFncSerialize.SerializeClassToXML")
            End Try

        End Sub

        ''' <summary>
        ''' XML����N���X���t�V���A���C�Y������
        ''' </summary>
        ''' <param name="strFileName">�t�@�C����</param>
        ''' <param name="typClass">�N���X�̃^�C�v</param>
        ''' <returns>�N���X�̃I�u�W�F�N�g</returns>
        ''' <remarks></remarks>
        Public Shared Function DeSerializeXMLToClass(ByVal strFileName As String, ByVal typClass As Type) As Object

            Dim obj As Object = Nothing

            Try
                'XmlSerializer�I�u�W�F�N�g�̍쐬
                Dim serializer As New System.Xml.Serialization.XmlSerializer(typClass)
                '�t�@�C�����J��
                Dim fs As New System.IO.FileStream(strFileName, System.IO.FileMode.Open)
                'XML�t�@�C������ǂݍ��݁A�t�V���A��������
                obj = serializer.Deserialize(fs)
                '����
                fs.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CFncSerialize.DeSerializeXMLToClass")
            End Try

            Return obj

        End Function

#End Region

    End Class

End Namespace
