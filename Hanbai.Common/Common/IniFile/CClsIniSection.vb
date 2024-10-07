Namespace Classes

    ''' <summary>
    ''' �������t�@�C���̃Z�N�V�����p�N���X
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CClsIniSection

#Region "�����o�[�ϐ�"

        Private _ini As CClsIni

        Private mstrSectName As String   '�Z�N�V������

#End Region

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �N���X�̐V�����C���X�^���X�����������܂��B
        ''' </summary>
        ''' <param name="fileName">ini �t�@�C�����B</param>
        ''' <param name="sectName">�g�p�Z�N�V������</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal fileName As String, ByVal sectName As String)

            _ini = New CClsIni(fileName)

            mstrSectName = sectName

        End Sub

#End Region

#Region "�v���p�e�B"

#End Region

#Region "���\�b�h"

        ''' <summary>�L�[�̒l���擾</summary>
        ''' <param name="key">�L�[</param>
        ''' <param name="value">����l</param>
        ''' <returns>�l</returns>
        ''' <remarks>
        ''' �������t�@�C�����ɃL�[�����݂��Ȃ��ꍇ�́A����l���Ԃ����B
        ''' �z��͂P�����̂݁A�Y������0����A����l�Ȃ��B
        '''     String     ""
        '''     Short      0
        '''     Integer    0
        '''     Single     0
        '''     Boolean    False
        '''     DateTime   �ǂݍ��ݎ��_
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
        'String�̔z��
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
        'Short�̔z��
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
        'Integer�̔z��
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
        'Single�̔z��
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
        'Boolean�̔z��
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
        'DateTime�̔z��
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

        ''' <summary>�L�[�̒l��ۑ�</summary>
        ''' <param name="key">�L�[</param>
        ''' <param name="value">�l</param>
        ''' <remarks>
        ''' �z��͂P�����̂݁A�Y������0����B
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
        'String�̔z��
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As String)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'Short�̔z��
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As Short)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'Integer�̔z��
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As Integer)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'Single�̔z��
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As Single)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'Boolean�̔z��
        Public Overloads Sub WriteKey(ByVal key As String, ByVal value() As Boolean)
            Dim count As Integer = value.Length
            WriteKey(key & "Count", count)
            For i As Integer = 0 To count - 1
                WriteKey(key & i, value(i))
            Next
        End Sub
        'DateTime�̔z��
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