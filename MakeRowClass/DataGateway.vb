#Region "�Q��"

Imports System
Imports System.Data
Imports System.Data.Common

#End Region

Namespace DataBase

    ''' <summary>
    ''' DataGateway �̊T�v�̐����ł��B
    ''' </summary>
    ''' <remarks>
    ''' �e�[�u���f�[�^�Q�[�g�E�F�C�̒��ۊ�{�N���X�ł��B
    ''' </remarks>
    Public MustInherit Class DataGateway

#Region "�����o�[�ϐ�"

        ''' <summary>
        ''' �e�[�u����
        ''' </summary>
        ''' <remarks></remarks>
        Private mstrTableName As String
        ''' <summary>
        ''' �p�����[�^�N�G���[�Ɉ����n���p�����[�^�}�[�J�𐶐�����@�N���X
        ''' </summary>
        ''' <remarks></remarks>
        Private mpmf As ParameterMakerFormat

#End Region

#Region "�v���e�N�g�@�����o�[�ϐ�"

        ''' <summary>
        ''' �f�[�^�[�Z�b�g�Q�[�g�E�F�C
        ''' </summary>
        ''' <remarks></remarks>
        Protected mdsg As DataSetGateway
        ''' <summary>
        ''' ���e�[�u����
        ''' </summary>
        ''' <remarks></remarks>
        Protected mstrTrueTableName As String
        ''' <summary>
        ''' �ǉ��s
        ''' </summary>
        ''' <remarks></remarks>
        Protected mblnInsertRow As Boolean

#End Region

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="strConnStr">�ڑ�������</param>
        ''' <param name="enmProvider">�v���p�C�_�[�̎��</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal strConnStr As String, Optional ByVal enmProvider As enmProvider = enmProvider.MDB)

            mdsg = New DataSetGateway(strConnStr, enmProvider)

            mstrTrueTableName = GetTableName()

            TableName = mstrTrueTableName

            '�p�����[�^�}�[�J�𐶐�����@�N���X
            pclsPMF = New ParameterMakerFormat(mdsg.Connection)

        End Sub

        ''' <summary>
        ''' �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="cnn">�R�l�N�V����</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal cnn As Connection)

            mdsg = New DataSetGateway(cnn)

            mstrTrueTableName = GetTableName()

            TableName = mstrTrueTableName

            '�p�����[�^�}�[�J�𐶐�����@�N���X
            pclsPMF = New ParameterMakerFormat(mdsg.Connection)

        End Sub

        ''' <summary>
        ''' �R���X�g���N�^�ł��B
        ''' </summary>
        ''' <param name="dstGateway"> DataSetGateway�N���X�̃C���X�^���X
        ''' </param>
        ''' <remarks>
        ''' ���̃N���X�̃C���X�^���X�͒��ڍ쐬�ł��܂���B
        ''' </remarks>
        Protected Sub New(ByVal dstGateway As DataSetGateway, Optional ByVal strTableName As String = "")

            If dstGateway Is Nothing Then
                MessageBox.Show("dstGateway is Nothing", "DataGateway.New")
            End If

            mdsg = dstGateway

            mstrTrueTableName = GetTableName()
            If strTableName = String.Empty Then
                TableName = mstrTrueTableName
            Else
                TableName = strTableName
            End If

            '�p�����[�^�}�[�J�𐶐�����@�N���X
            pclsPMF = New ParameterMakerFormat(mdsg.Connection)

        End Sub

#End Region

#Region "�v���p�e�B"

        ''' <summary>
        ''' �f�[�^�Z�b�g���擾���܂��B
        ''' </summary>
        ''' <remarks>
        ''' <see cref="System.Data.DataSet">DataSet</see>�N���X�̃C���X�^���X���擾���܂��B
        ''' </remarks>
        Public ReadOnly Property Data() As DataSet
            Get
                Return mdsg.DataSet
            End Get
        End Property
        ''' <summary>
        ''' �f�[�^�[�Z�b�g�Q�[�g�E�F�C���擾���܂��B
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataSetGateWay() As DataSetGateway
            Get
                Return mdsg
            End Get
        End Property
        ''' <summary>
        ''' �f�[�^�[�A�_�v�^�[���擾���܂��B
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataAdapter() As DbDataAdapter
            Get
                Return mdsg.DataAdapter(TableName)
            End Get
        End Property
        ''' <summary>
        ''' �f�[�^�e�[�u�����擾���܂��B
        ''' </summary>
        ''' <remarks>
        ''' <see cref="System.Data.DataTable">DataTable</see>�N���X�̃C���X�^���X���擾���܂��B
        ''' </remarks>
        Public ReadOnly Property Table() As DataTable
            Get
                Return mdsg.Item(TableName)
            End Get
        End Property
        ''' <summary>
        ''' �e�[�u����
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TableName() As String
            Get
                Return mstrTableName
            End Get
            Set(ByVal value As String)
                mstrTableName = value
            End Set
        End Property
        ''' <summary>
        ''' �p�����[�^�}�[�J�𐶐�����@�N���X
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property pclsPMF() As ParameterMakerFormat
            Get
                Return mpmf
            End Get
            Set(ByVal value As ParameterMakerFormat)
                mpmf = value
            End Set
        End Property
        ''' <summary>
        ''' Rows
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Rows() As DataRowCollection
            Get
                Return Table.Rows
            End Get
        End Property

#End Region

#Region "���\�b�h"

        ''' <summary>
        ''' �S�Ẵ��R�[�h��ǂݍ��݂܂��B
        ''' </summary>
        ''' <param name="strSql">SQL��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FillSql(ByVal strSql As String) As DataRowCollection

            If FillData(TableName, strSql) Then
                If Table.Rows.Count = 0 Then
                    Return Nothing
                Else
                    Return Table.Rows
                End If
            Else
                Return Nothing
            End If

        End Function

        ''' <summary>
        ''' �S�Ẵ��R�[�h��ǂݍ��݂܂��B
        ''' </summary>
        ''' <param name="strWhere">where��</param>
        ''' <param name="strOrder">order��</param>
        ''' <remarks>���̓�(�u'�v���܂܂��̂�)�̌����ɂ�Where����g�p���Ȃ��ŉ������B�p�����[�^���g�p���鎖</remarks>
        Public Function Fill(Optional ByVal strWhere As String = "", _
                             Optional ByVal strOrder As String = "") As DataRowCollection

            Dim sql As String = String.Format("SELECT * FROM {0}", mstrTrueTableName)
            If strWhere <> String.Empty Then
                sql &= " WHERE " & strWhere
            End If
            If strOrder <> String.Empty Then
                sql &= " ORDER BY " & strOrder
            End If

            If FillData(TableName, sql) Then
                If Table.Rows.Count = 0 Then
                    Return Nothing
                Else
                    Return Table.Rows
                End If
            Else
                Return Nothing
            End If

        End Function

        ''' <summary>
        ''' �A�ԏ��ɑS�Ẵ��R�[�h��ǂݍ��݂܂��B
        ''' </summary>
        ''' <param name="strWhere">where��</param>
        ''' <remarks></remarks>
        Public Function FillOrderByNumber(Optional ByVal strWhere As String = "") As DataRowCollection

            Return Fill(strWhere, "�A��")

        End Function

        ''' <summary>
        ''' �f�[�^�[�e�[�u���̍s�����擾���܂�
        ''' </summary>
        ''' <returns>�s��</returns>
        ''' <remarks></remarks>
        Public Function RowsCount() As Integer

            Dim tbl As DataTable = mdsg.Item(TableName)
            Return tbl.Rows.Count

        End Function

        ''' <summary>
        ''' �f����(Proposed)�̍s��S��EndEdit����
        ''' </summary>
        ''' <remarks>BindinSource��EndEdit()�̓����[�V�����e�[�u���ɂ͐��������삵�Ȃ��̂ŁA
        ''' �����[�V�����e�[�u�����g�p���Ă���ꍇ�͂��̃��\�b�h�𗘗p���邱��</remarks>
        Public Sub EndEdit()

            For Each row As DataRow In Table.Rows
                If row.HasVersion(DataRowVersion.Proposed) Then
                    row.EndEdit()
                End If
            Next

        End Sub

        ''' <summary>
        ''' Item�͑S��DBNull�H
        ''' </summary>
        ''' <param name="drv"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsItemDBNull(ByVal drv As DataRowView) As Boolean

            For Each item As Object In drv.Row.ItemArray
                If Not IsDBNull(item) Then
                    Return False
                End If
            Next

            Return True

        End Function

        ''' <summary>
        ''' ��̃e�[�u�����쐬���܂�
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CreateEmptyTable()
            Dim sql As String
            sql = String.Format("SELECT * FROM {0} WHERE 1=0", mstrTrueTableName)
            FillData(TableName, sql)
        End Sub

        ''' <summary>
        ''' DbCommand�I�u�W�F�N�g�𐶐����܂�
        ''' </summary>
        ''' <param name="strCommandText">�R�}���h�e�L�X�g</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateCommand(ByVal strCommandText As String) As DbCommand

            Return DataSetGateWay.CreateCommand(strCommandText)

        End Function

        ''' <summary>
        ''' �p�����[�^��ݒ肵�܂�
        ''' </summary>
        ''' <param name="cmd">�R�}���h</param>
        ''' <param name="strPrmName">�p�����[�^�[��</param>
        ''' <param name="objValue">�p�����[�^�[�l</param>
        ''' <remarks>SELECT���̃p�����[�^�̏o�����Ԃƃp�����[�^���̏��Ԃ�K�����킹�邱��</remarks>
        Public Overloads Sub SetParameter(ByVal cmd As DbCommand, ByVal strPrmName As String, ByVal objValue As Object)

            Dim prm As DbParameter = DataSetGateWay.Connection.CreateDbParameter
            mprcSetParameter(prm, strPrmName, objValue)
            cmd.Parameters.Add(prm)

        End Sub

        ''' <summary>
        ''' �p�����[�^��ݒ肵�܂�
        ''' </summary>
        ''' <param name="cmd">�R�}���h</param>
        ''' <param name="astrPrmName">�p�����[�^�[��()</param>
        ''' <param name="aobjValue">�p�����[�^�[�l()</param>
        ''' <remarks>SELECT���̃p�����[�^�̏o�����Ԃƃp�����[�^��()�̏��Ԃ�K�����킹�邱��</remarks>
        Public Overloads Sub SetParameter(ByVal cmd As DbCommand, ByVal astrPrmName() As String, ByVal aobjValue() As Object)

            For i As Integer = 0 To astrPrmName.Length - 1
                SetParameter(cmd, astrPrmName(i), aobjValue(i))
            Next i

        End Sub

        ''' <summary>
        ''' �R�s�[������R�s�[��֓������ڂ��R�s�[����
        ''' </summary>
        ''' <param name="rowTerget">�R�s�[��</param>
        ''' <param name="src">�R�s�[��</param>
        ''' <remarks></remarks>
        Public Shared Sub CopyItem(ByVal rowTerget As DataRow, ByVal src As DataRow)

            Dim tblTerget As DataTable = rowTerget.Table

            For i As Integer = 0 To tblTerget.Columns.Count - 1
                Dim strColumnName As String = tblTerget.Columns.Item(i).ColumnName
                If src.Table.Columns.Contains(strColumnName) Then
                    rowTerget.Item(i) = src.Item(strColumnName)
                End If
            Next i

        End Sub

#End Region

#Region "�v���C�x�[�g�@���\�b�h"

        Public Sub mprcSetParameter(ByVal prm As DbParameter, ByVal strPrmName As String, ByVal objValue As Object)

            With prm

                .ParameterName = strPrmName
                .Value = objValue

                If TypeOf .Value Is Integer Then
                    .DbType = DbType.Int32
                End If
                If TypeOf .Value Is String Then
                    .DbType = DbType.String
                    .Size = CStr(.Value).Length
                End If
                If TypeOf .Value Is Single Then
                    .DbType = DbType.Single
                End If
                If TypeOf .Value Is Double Then
                    .DbType = DbType.Double
                End If

            End With

        End Sub

#End Region

#Region "�v���e�N�g�@���\�b�h"

        ''' <summary>
        ''' SqlCommand�ɂ�背�R�[�h��ǂݍ��݂܂��B
        ''' </summary>
        ''' <param name="strTblName">�e�[�u����</param>
        ''' <param name="selectCommand">SqlCommand</param>
        ''' <remarks></remarks>
        Protected Overloads Function FillData(ByVal strTblName As String, ByVal selectCommand As DbCommand) As Boolean

            '�Ώۃe�[�u���Ƀf�[�^��ǂݍ��݂܂��B
            If mdsg.FillData(strTblName, selectCommand) Then
                'FillData�̌㏈��
                AfterFillData()
                Return True
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' SQL���ɂ�背�R�[�h��ǂݍ��݂܂��B
        ''' </summary>
        ''' <param name="strTblName">�e�[�u����</param>
        ''' <param name="strSql">SQL��</param>
        ''' <remarks></remarks>
        Protected Overloads Function FillData(ByVal strTblName As String, ByVal strSql As String) As Boolean

            '�Ώۃe�[�u���Ƀf�[�^��ǂݍ��݂܂��B
            If mdsg.FillData(strTblName, strSql) Then
                'FillData�̌㏈��
                AfterFillData()
                Return True
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' �J�����𐶐�����
        ''' </summary>
        ''' <param name="strColumnName">�J����</param>
        ''' <param name="typ">�^�C�v</param>
        ''' <param name="intLength">�ő咷</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function NewColumn(ByVal strColumnName As String, ByVal typ As Type, Optional ByVal intLength As Integer = 0) As DataColumn

            Dim clm As New DataColumn(strColumnName, typ)
            If typ.Equals(GetType(String)) Then
                If intLength = 0 Then
                    Throw New Exception("NewColumn Length")
                End If
                clm.MaxLength = intLength
            End If

            Return clm

        End Function

#End Region

#Region "�I�[�o�[���C�h�\�@���\�b�h"

        ''' <summary>
        ''' �e�[�u����
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public MustOverride Function GetTableName() As String

        ''' <summary>
        ''' FillData�̌㏈��
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub AfterFillData()
        End Sub

#End Region

    End Class

End Namespace
