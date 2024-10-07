#Region "�Q��"

Imports System
Imports System.io
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

#End Region

Namespace Classes

    ''' <summary>
    ''' ini �t�@�C�����g�p���邽�߂̊�{�N���X
    ''' </summary>
    Public Class CClsIni

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �N���X�̐V�����C���X�^���X�����������܂��B
        ''' </summary>
        ''' <param name="fileName">ini �t�@�C�����B</param>
        Public Sub New(ByVal fileName As String)
            _fileName = fileName
        End Sub

#End Region

#Region "���\�b�h"

        ''' <summary>
        ''' ini �t�@�C������l���擾���܂��B
        ''' </summary>
        ''' <param name="section">�Z�N�V�������B</param>
        ''' <param name="key">�L�[���B</param>
        ''' <param name="defaultValue">�ۑ����ꂽ�l���Ȃ��ꍇ�̊���̕�����B</param>
        Public Function GetValue(ByVal section As String, ByVal key As String, ByVal defaultValue As String) As String
            Const BUFFER_SIZE As Integer = 256
            Dim buffer As StringBuilder = New StringBuilder(BUFFER_SIZE)
            GetPrivateProfileString(section, key, defaultValue, buffer, BUFFER_SIZE, _fileName)
            Return buffer.ToString()
        End Function

        ''' <summary>
        ''' ini �t�@�C���ɒl���������݂܂��B
        ''' </summary>
        ''' <param name="section">�Z�N�V�������B</param>
        ''' <param name="key">�L�[���B</param>
        ''' <param name="saveValue">�������ޒl�B</param>
        Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal saveValue As String)
            If saveValue = String.Empty Then
                WritePrivateProfileString(section, key, String.Empty, _fileName)
            Else
                saveValue = saveValue.Trim()
                If WritePrivateProfileString(section, key, saveValue, _fileName) = 0 Then
                    MessageBox.Show(section & " : " & key, "CClsIni.WriteValue")
                End If
            End If
        End Sub

#End Region

#Region "�v���p�e�B"

        Private _fileName As String
        Public ReadOnly Property pstrFileName() As String
            Get
                Return _fileName
            End Get
        End Property

#End Region

#Region "API"

        '-------------------------
        ' GetPrivateProfileString
        '-------------------------
        ''' <summary>
        ''' �w�肳�ꂽ .ini �t�@�C���i�������t�@�C���j�̎w�肳�ꂽ�Z�N�V�������ɂ���A�w�肳�ꂽ�L�[�Ɋ֘A�t�����Ă��镶������擾���܂��B
        ''' �֐�����������ƁA�o�b�t�@�Ɋi�[���ꂽ���������Ԃ�܂��i�I�[�� NULL �����͊܂܂Ȃ��j�B
        ''' </summary>
        ''' <remarks><code>
        ''' DWORD GetPrivateProfileString(
        '''  LPCTSTR lpAppName,                  // �Z�N�V������
        '''  LPCTSTR lpKeyName,                  // �L�[��
        '''  LPCTSTR lpDefault,                  // ����̕�����
        '''  LPTSTR lpReturnedString,            // ��񂪊i�[�����o�b�t�@
        '''  DWORD nSize,                        // ���o�b�t�@�̃T�C�Y
        '''  LPCTSTR lpFileName                  // .ini �t�@�C���̖��O
        ''' );
        ''' </code></remarks>
        <DllImport("kernel32.dll", EntryPoint:="GetPrivateProfileStringA")> _
        Private Shared Function GetPrivateProfileString( _
            ByVal lpAppNameas As String, _
            ByVal lpkeyName As String, _
            ByVal lpDefault As String, _
            ByVal lpReturnedstringas As StringBuilder, _
            ByVal nSize As Integer, _
            ByVal lpFileName As String _
        ) As Integer
        End Function


        '-------------------------
        ' WritePrivateProfileString
        '-------------------------
        ''' <summary>
        ''' �w�肳�ꂽ .ini �t�@�C���i�������t�@�C���j�́A�w�肳�ꂽ�Z�N�V�������ɁA�w�肳�ꂽ�L�[���Ƃ���Ɋ֘A�t����ꂽ��������i�[���܂��B
        ''' �֐���������� .ini �t�@�C���Ɋi�[���邱�Ƃɐ�������ƁA0 �ȊO�̒l���Ԃ�܂��B
        ''' �֐������s���邩�A���O�ɃA�N�Z�X���� .ini �t�@�C�����L���b�V������f�B�X�N��̃t�@�C���փt���b�V������i�������ށj�ƁA0 ���Ԃ�܂��B
        ''' </summary>
        ''' <remarks><code>
        ''' BOOL WritePrivateProfileString(
        '''  LPCTSTR lpAppName,                  // �Z�N�V������
        '''  LPCTSTR lpKeyName,                  // �L�[��
        '''  LPCTSTR lpString,                   // �ǉ�����ׂ�������
        '''  LPCTSTR lpFileName                  // .ini �t�@�C��
        ''' );
        ''' </code></remarks>
        <DllImport("kernel32.dll", EntryPoint:="WritePrivateProfileStringA")> _
        Private Shared Function WritePrivateProfileString( _
            ByVal lpApplicationName As String, _
            ByVal lpkeyName As String, _
            ByVal lpstring As String, _
            ByVal lpFileName As String _
        ) As Integer
        End Function

#End Region

    End Class

End Namespace
