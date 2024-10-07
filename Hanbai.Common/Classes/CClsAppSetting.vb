Imports System.IO
Imports System.Environment
Imports Hanbai.Common.Functions

Namespace Classes

    ''' <summary>
    ''' �A�v���P�[�V�����ݒ�@�N���X
    ''' </summary>
    ''' <remarks>Singleton�N���X</remarks>
    Public Class CClsAppSetting

#Region "�萔"

        '�h�����t�@�C����
        Private Const ROOT_FOLDER As String = "Kiyohori\Hanbai"
        Private Const INI_FILENAME As String = "Setting\Hanbai.ini"

        '�Z�N�V������
        Public Const SEC_CONFIG As String = "Config"
        Private Const SEC_FORM As String = "Form"

        '�L�[��
        Private Const KEY_SCREENSIZE As String = "ScreenSize"                       '��ʃT�C�Y
        Private Const KEY_SCALE As String = "Scale"                                 '�X�P�[��
        Private Const KEY_WINDOW_STATE As String = "WindowState"                    '�E�B���h�E���
        Public Const KEY_TMP_PATH As String = "TempPath"                            '�e���|�����[�@�t�H���_�[�@�p�X��
        Public Const KEY_LOG_PATH As String = "LogPath"                             '���O�@�t�H���_�[�@�p�X��
        Public Const KEY_KHWSDB_CONNECTSTR As String = "KHWSDB_ConnectStr"          'KHWSDB �ڑ�������
        Public Const KEY_KHDB_CONNECTSTR As String = "KHDB_ConnectStr"              'KHDB   �ڑ�������
        Public Const KEY_SKIN As String = "Skin"                                    '�X�L��

        Public Const KEY_DB_BACKUP_FOLDER As String = "DataBaseBackupFolder"        '�o�b�N�A�b�v�t�H���_�[
        Public Const KEY_DB_FOLDER As String = "DataBaseFolder"                     '�f�[�^�i�[�t�H���_�[
        Public Const KEY_DB_EVERYBACKUP = "EveryBackup"                             '�I�����Ƀo�b�N�A�b�v
        'Public Const KEY_DB_RESTORE_DONE = "DataBaseRestore_Done"                   '���X�g�A�[��

        Private Const KEY_LICENCE_CHECK_PASS As String = "LicenceCheckPass"         '���C�Z���X�@�`�F�b�N�@�p�X

        '���b�Z�[�W
        Private Const ERR_MYDB_CONN As String = "���ݒ�ɁuMyDB�ڑ�������v���ݒ肳��Ă��܂���"
        Private Const ERR_NOT_INIFILE As String = "���ݒ�t�@�C���u{0}�v��������܂���B"
        Private Const ERR_TMP_PATH As String = "���ݒ�ɁuTmpPath�v���ݒ肳��Ă��܂���"

        Private Const DEFAULT_SKIN As String = "Lilian"

#End Region

#Region "�����o�[�ϐ�"

        ''' <summary>
        ''' �B��̃C���X�^���X
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared _singleton As CClsAppSetting = New CClsAppSetting()

#End Region

#Region "�v���p�e�B"

        ''' <summary>
        ''' ���C���t�H�[��
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pForm As Windows.Forms.Form

        Private mstrIniFileName As String
        ''' <summary>
        ''' �h�����t�@�C����
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property pstrIniFileName() As String
            Get
                Return mstrIniFileName
            End Get
        End Property

        ''' <summary>
        ''' KHWSDB �ڑ�������
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrKHWSDBConn As String
        ''' <summary>
        ''' KHDB �ڑ�������
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrKHDBConn As String
        ''' <summary>
        ''' �X�L����
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrSkin As String
        ''' <summary>
        ''' �O���b�h�X�^�C��
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrGridStyle As String
        ''' <summary>
        ''' �I�����Ƀo�b�N�A�b�v���s���H
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pblnEveryBackup As Boolean
        ''' <summary>
        ''' �f�[�^�[�x�[�X�i�[��
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrDatabaseFolder As String

#Region "�p�X��"

        ''' <summary>
        ''' �e���|�����[�@�t�H���_�[�@�p�X��
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrTmpPath As String
        ''' <summary>
        ''' ���O�@�t�H���_�[�@�p�X��
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pstrLogPath As String
        ''' <summary>
        ''' �z�[���@�p�X��
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property pstrHomePath() As String
            Get
                Return Path.Combine(GetFolderPath(SpecialFolder.Personal), ROOT_FOLDER)
            End Get
        End Property

#End Region

#Region "�C���t�H���[�V����"

        Public Property pblnInformationVisible As Boolean
        Public Property pstrUpdateInformationURL As String
        Public Property pstrRemoteMentenanceURL As String
        Public Property pstrELearningURL As String

#End Region

#End Region

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <remarks>���̃R���X�g���N�^�͂��̃N���X���C���X�^���X�����ł��Ȃ��悤�ɂ��܂��B</remarks>
        Private Sub New()

            mstrIniFileName = Path.Combine(pstrHomePath, INI_FILENAME)
            Me.pstrGridStyle = "Blue Office"

        End Sub

#End Region

#Region "���\�b�h"

        ''' <summary>
        ''' �B��̃C���X�^���X���擾����
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetInstance() As CClsAppSetting
            Return _singleton
        End Function

        ''' <summary>
        ''' �h�����t�@�C���𐶐����܂�
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CreateIniFile() As Boolean

            Try
                Dim strDir As String = Path.GetDirectoryName(pstrIniFileName)
                If Not Directory.Exists(strDir) Then
                    Directory.CreateDirectory(strDir)
                End If
                Using sw As New StreamWriter(pstrIniFileName, False, System.Text.Encoding.GetEncoding("sjis"))
                    With sw
                        .WriteLine(";===================================================================")
                        .WriteLine(";")
                        .WriteLine("; �̔��Ǘ� ���ݒ�t�@�C��")
                        .WriteLine(";")
                        .WriteLine(String.Format("; Create Date:{0}", Now))
                        .WriteLine(";")
                        .WriteLine(";===================================================================")
                        .WriteLine("")
                        .WriteLine(";===================================================================")
                        .WriteLine(";��")
                        .WriteLine(";===================================================================")
                        .WriteLine("[Config]")
                        .WriteLine(";�ڑ�������")
                        .WriteLine(String.Format("{0}=Data Source=T130SRV1\SQL2016;Initial Catalog=KHWSDB;Integrated Security=False;User=sa;Password=sa", KEY_KHWSDB_CONNECTSTR))
                        .WriteLine(String.Format("{0}=Data Source=T130SRV1\SQL2016;Initial Catalog=KHDB;Integrated Security=False;User=sa;Password=sa", KEY_KHDB_CONNECTSTR))
                        .WriteLine(";====== �p�X�� =====")
                        .WriteLine(";�e���|�����[")
                        .WriteLine(String.Format("{0}={1}", KEY_TMP_PATH, Path.Combine(Me.pstrHomePath, "Temp")))
                        .WriteLine(";���O")
                        .WriteLine(String.Format("{0}={1}", KEY_LOG_PATH, Path.Combine(Me.pstrHomePath, "Log")))
                        .WriteLine(";====== �X�L�� =====")
                        .WriteLine("Skin=Office 2010 Silver")
                        .WriteLine("")
                        .WriteLine(";===================================================================")
                        .WriteLine(";�t�H�[���ʒu")
                        .WriteLine(";SXGA 1280X1024�̊���l Width 1240 Height 970")
                        .WriteLine(";===================================================================")
                        .WriteLine("[Form]")
                    End With
                End Using
                Return True
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' �h�����t�@�C���͑��݂��邩�H
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExistsFile(Optional ByVal blnMessage As Boolean = True) As Boolean

            If Not File.Exists(mstrIniFileName) Then
                If blnMessage Then
                    Dim strMsg As String = String.Format(ERR_NOT_INIFILE, pstrIniFileName)
                    CFncMessage.ErrorMessage(strMsg, MessageBoxIcon.Exclamation, My.Resources.CAP_APPLICATION)
                End If
                Return False
            Else
                Return True
            End If

        End Function

        ''' <summary>
        ''' �X�P�[�����擾����
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetScale() As Single

            Dim ini As New CClsIniSection(mstrIniFileName, SEC_CONFIG)
            Dim sngScale As Single = ini.ReadKey(KEY_SCALE, 1.0)
            Return sngScale

        End Function

        ''' <summary>
        ''' �E�C���h�[�̏�Ԃ𕜌����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RestoreWindowState()

            Dim ini As New CClsIniSection(mstrIniFileName, SEC_FORM)
            pForm.WindowState = DirectCast(ini.ReadKey(KEY_WINDOW_STATE, FormWindowState.Normal), FormWindowState)

        End Sub

        ''' <summary>
        ''' �E�C���h�[�̏�Ԃ�ۑ����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveWindowState()

            Dim ini As New CClsIniSection(mstrIniFileName, SEC_FORM)
            ini.WriteKey(KEY_WINDOW_STATE, pForm.WindowState.ToString("D"))

        End Sub

        ''' <summary>
        ''' �t�H�[���ʒu�𕜌����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RestoreLocation()

            Dim ini As New CClsFormSetting(mstrIniFileName)
            ini.RestoreLocation(pForm)
            ini.RestoreSize(pForm)

        End Sub

        ''' <summary>
        ''' �t�H�[���ʒu��ۑ����܂��B
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveLocation()

            Dim ini As New CClsFormSetting(mstrIniFileName)
            ini.SaveLocation(pForm)
            ini.SaveSize(pForm)

        End Sub

        Public Function IsLicenceCheckPass() As Boolean
            Dim ini As New CClsIniSection(mstrIniFileName, SEC_CONFIG)
            Return ini.ReadKey(KEY_LICENCE_CHECK_PASS, False)
        End Function

        ''' <summary>
        ''' ���@�����ݒ菈��
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Initial() As Boolean

            Dim ini As New CClsIniSection(mstrIniFileName, SEC_CONFIG)

            Try
                '�X�L����
                pstrSkin = ini.ReadKey(KEY_SKIN, DEFAULT_SKIN)
                '�p�X�����擾����
                If Not mprcGetPath(ini) Then
                    Return False
                End If

                '�ڑ���������擾����
                If Not mprcGetConnStr(ini) Then
                    Return False
                End If

                '�o�b�N�A�b�v
                pstrDatabaseFolder = ini.ReadKey(KEY_DB_FOLDER, String.Empty)
                pblnEveryBackup = ini.ReadKey(KEY_DB_EVERYBACKUP, True)
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message, MessageBoxIcon.Exclamation, My.Resources.CAP_APPLICATION)
                Return False
            End Try

            Return True

        End Function

        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As String)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        ''' <summary>
        ''' �ݒ�l����������
        ''' </summary>
        ''' <param name="section"></param>
        ''' <param name="KeyName"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Integer)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As DateTime)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Boolean)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        Public Overloads Sub WriteValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Single)
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            ini.WriteKey(KeyName, Value)
        End Sub

        ''' <summary>
        ''' �ݒ�l��ǂݍ���
        ''' </summary>
        ''' <param name="section"></param>
        ''' <param name="KeyName"></param>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As String) As String
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Integer) As Integer
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As DateTime) As DateTime
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Boolean) As Boolean
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

        Public Overloads Function ReadValue(ByVal section As String, ByVal KeyName As String, ByVal Value As Single) As Single
            Dim ini As New CClsIniSection(mstrIniFileName, section)
            Return ini.ReadKey(KeyName, Value)
        End Function

#End Region

#Region "�v���C�x�[�g�@���\�b�h"

        ''' <summary>
        ''' �ڑ���������擾����
        ''' </summary>
        ''' <param name="ini"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcGetConnStr(ByVal ini As CClsIniSection) As Boolean

            With ini
                Me.pstrKHWSDBConn = .ReadKey(KEY_KHWSDB_CONNECTSTR, String.Empty)
                Me.pstrKHDBConn = .ReadKey(KEY_KHDB_CONNECTSTR, String.Empty)
            End With

            Return True

        End Function

        ''' <summary>
        ''' �p�X�����擾����
        ''' </summary>
        ''' <param name="ini"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcGetPath(ByVal ini As CClsIniSection) As Boolean

            Me.pstrTmpPath = ini.ReadKey(KEY_TMP_PATH, String.Empty)
            Me.pstrLogPath = ini.ReadKey(KEY_LOG_PATH, String.Empty)

            '�t�H���_�[�쐬
            If Not Directory.Exists(Me.pstrTmpPath) Then
                Directory.CreateDirectory(Me.pstrTmpPath)
                Directory.CreateDirectory(Me.pstrLogPath)
            End If

            Return True

        End Function

#End Region

    End Class

End Namespace