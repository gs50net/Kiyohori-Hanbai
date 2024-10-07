#Region "�Q��"

Imports System
Imports System.Data
Imports System.Data.Common

#End Region

Namespace DataBase

    ''' <summary>
    ''' �X�g�A�h�v���V�W���[�@�N���X
    ''' </summary>
    ''' <remarks>�N�G���[�̒��ۊ�{�N���X�ł��B
    ''' �K�� using���g�p���邱��</remarks>
    ''' <example>
    ''' <code>
    ''' Using sp As New StoredProcedure("select * from T001")
    '''      dim rdr as SqlDataReader = sp.ExecuteReader
    '''      While rdr.Read
    '''         ������
    '''      end while
    ''' end using
    ''' </code>
    ''' <code>
    ''' Using sp As New StoredProcedure("sp_Test")
    '''      dim rdr as SqlDataReader = sp.ExecuteReader
    '''      While rdr.Read
    '''         ������
    '''      end while
    ''' end using
    ''' </code>
    ''' <code>
    ''' Using sp As New StoredProcedure("sp_Test")
    ''' 
    '''       sp.Execute
    '''       ������
    '''       ������
    ''' 
    ''' end using
    ''' </code>
    ''' </example>
    Public Class StoredProcedure

#Region "Dispose"

        Implements IDisposable

        Private disposedValue As Boolean = False        ' �d������Ăяo�������o����ɂ�

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    '�����I�ɌĂяo���ꂽ�Ƃ��Ƀ}�l�[�W ���\�[�X��������܂�
                End If

                If _cnn.Connection.State = ConnectionState.Open Then
                    _cnn.Connection.Close()
                End If

            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' ���̃R�[�h�́A�j���\�ȃp�^�[���𐳂��������ł���悤�� Visual Basic �ɂ���Ēǉ�����܂����B
        Public Sub Dispose() Implements IDisposable.Dispose
            ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(ByVal disposing As Boolean) �ɋL�q���܂��B
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#End Region

#Region "�萔"

        Private SQL_BATCH_COMMAND() As String = {"GO"}

#End Region

#Region "�����o�[�ϐ�"

        ''' <summary>
        ''' �R�l�N�V����
        ''' </summary>
        ''' <remarks></remarks>
        Private _cnn As Connection
        ''' <summary>
        ''' �R�}���h
        ''' </summary>
        ''' <remarks></remarks>
        Private _cmd As DbCommand
        ''' <summary>
        ''' �G���[���b�Z�[�W
        ''' </summary>
        ''' <remarks></remarks>
        Private mstrErrorMessage As String
        ''' <summary>
        ''' �G���[���b�Z�[�W��\���H
        ''' </summary>
        ''' <remarks></remarks>
        Private mblnShowErrorMessage As Boolean

#End Region

#Region "�v���p�e�B"

        ''' <summary>
        ''' �R�}���h
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property cmd() As DbCommand
            Get
                Return _cmd
            End Get
        End Property
        ''' <summary>
        ''' �G���[���b�Z�[�W
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ErrorMessage() As String
            Get
                Return mstrErrorMessage
            End Get
        End Property
        ''' <summary>
        ''' �G���[���b�Z�[�W��\���H(����l��True)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShowErrorMessage() As Boolean
            Get
                Return mblnShowErrorMessage
            End Get
            Set(ByVal value As Boolean)
                mblnShowErrorMessage = value
            End Set
        End Property

#End Region

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="cnn">�R�l�N�V����</param>
        ''' <param name="blnShowErrorMessage">�G���[���b�Z�[�W��\���H</param>
        ''' <remarks>���Ō�ɂ̓R�l�N�V�����̓N���[�Y���܂�</remarks>
        Public Sub New(ByVal cnn As Connection, Optional ByVal blnShowErrorMessage As Boolean = True)

            '�R�l�N�V����
            _cnn = cnn

            '��������
            mprcInit(blnShowErrorMessage)

        End Sub

        ''' <summary>
        ''' �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="strConnStr">�ڑ�������</param>
        ''' <param name="enmProvider">�v���p�C�_�[�̎��</param>
        ''' <param name="blnShowErrorMessage">�G���[���b�Z�[�W��\���H</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strConnStr As String, ByVal enmProvider As enmProvider, Optional ByVal blnShowErrorMessage As Boolean = True)

            '�R�l�N�V����
            _cnn = New Connection(strConnStr, enmProvider)

            '��������
            mprcInit(blnShowErrorMessage)

        End Sub

        ''' <summary>
        ''' �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="strText">�R�}���h�e�L�X�g</param>
        ''' <param name="cnn">�R�l�N�V����</param> 
        ''' <param name="blnShowErrorMessage">�G���[���b�Z�[�W��\���H</param>
        ''' <remarks>���Ō�ɂ̓R�l�N�V�����̓N���[�Y���܂�</remarks>
        Public Sub New(ByVal strText As String, _
                       ByVal cnn As Connection, _
                       Optional ByVal blnShowErrorMessage As Boolean = True)

            '�R�l�N�V����
            _cnn = cnn

            '��������
            mprcInit(blnShowErrorMessage)

            With _cmd
                .CommandType = CommandType.Text
                .CommandText = strText
            End With

        End Sub

        ''' <summary>
        ''' �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="strText">�R�}���h�e�L�X�g</param>
        ''' <param name="strConnStr">�ڑ�������</param>
        ''' <param name="enmProvider">�v���p�C�_�[�̎��</param>
        ''' <param name="blnShowErrorMessage">�G���[���b�Z�[�W��\���H</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strText As String, _
                       ByVal strConnStr As String, _
                       Optional ByVal enmProvider As enmProvider = enmProvider.MDB, _
                       Optional ByVal blnShowErrorMessage As Boolean = True)

            '�R�l�N�V����
            _cnn = New Connection(strConnStr, enmProvider)

            '��������
            mprcInit(blnShowErrorMessage)

            With _cmd
                .CommandType = CommandType.Text
                .CommandText = strText
            End With

        End Sub

#End Region

#Region "�v���C�x�[�g�@���\�b�h"

        ''' <summary>
        ''' ��������
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcInit(ByVal blnShowErrorMessage As Boolean)

            _cmd = _cnn.CreateCommand

            With _cmd
                .Connection = _cnn.Connection
            End With

            mblnShowErrorMessage = blnShowErrorMessage

        End Sub

        ''' <summary>
        ''' �G���[���b�Z�[�W����
        ''' </summary>
        ''' <param name="ex"></param>
        ''' <remarks></remarks>
        Private Sub mprcErrorMessage(ByVal ex As Exception)

            mstrErrorMessage = ex.Message

            If mblnShowErrorMessage Then
                Message.ErrorMessage(ex.Message, "StoredProcedure")
            End If

        End Sub

        ''' <summary>
        ''' �R�l�N�V�������I�[�v������
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub mprcOpenConnection()

            With _cnn.Connection
                If .State = ConnectionState.Closed Then
                    .Open()
                End If
            End With

        End Sub

        ''' <summary>
        ''' ExecuteReader
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcExecuteReader() As DbDataReader

            Try
                mprcOpenConnection()
                Dim rdr As DbDataReader = _cmd.ExecuteReader
                Return rdr
            Catch ex As Exception
                mprcErrorMessage(ex)
                Return Nothing
            End Try

        End Function

        ''' <summary>
        ''' ExecuteNonQuery
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcExecNonQuery() As Boolean

            Try
                mprcOpenConnection()
                _cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw New Exception(ex.Message)
                'mprcErrorMessage(ex)
                'Return False
            End Try

            Return True

        End Function

        ''' <summary>
        ''' SQL�������s����
        ''' </summary>
        ''' <param name="strSQL"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function mprcExecSQL(ByVal strSQL As String) As Boolean

            With _cmd
                .CommandType = CommandType.Text
                .CommandText = strSQL
            End With

            Return mprcExecNonQuery()

        End Function

#End Region

#Region "���\�b�h"

        ''' <summary>
        ''' �X�g�A�h�v���V�W���[�����s���ADataReader���擾���܂�
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecuteReader() As DbDataReader

            Return mprcExecuteReader()

        End Function

        ''' <summary>
        ''' �X�g�A�h�v���V�W���[�����s
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Execute() As Boolean

            Return mprcExecNonQuery()

        End Function

        ''' <summary>
        ''' �r�p�k�������s
        ''' </summary>
        ''' <param name="strSQL">SQL��</param>
        ''' <param name="blnGo">Go������͂���</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecuteSQL(ByVal strSQL As String, _
                                   Optional ByVal blnGo As Boolean = False) As Boolean

            Dim blnRet As Boolean
            If blnGo Then
                'Go�����܂܂�Ă���ꍇ
                Dim strText() As String = strSQL.Split(SQL_BATCH_COMMAND, StringSplitOptions.RemoveEmptyEntries)
                For i As Integer = 0 To strText.Length - 1
                    blnRet = mprcExecSQL(strText(i))
                    If Not blnRet Then
                        Exit For
                    End If
                Next i
            Else
                blnRet = mprcExecSQL(strSQL)
            End If

            Return blnRet

        End Function

#End Region

    End Class

End Namespace