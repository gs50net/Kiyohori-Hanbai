Imports System.Collections.Generic
Imports Hanbai.Common.Functions


Namespace DataBase

    ''' <summary>
    ''' �^�w�� DataRow/DataRowView ���ۃN���X
    ''' </summary>
    ''' <remarks>DataRow�܂���DataRowView�̂����ꂩ��������g�p����</remarks>
    Public MustInherit Class CDataRowBase

#Region "�����o�[�ϐ�"

        ''' <summary>
        ''' �I�u�W�F�N�g�ɕύX�������������H
        ''' </summary>
        ''' <remarks></remarks>
        Private mHasChange As Boolean
        Public ReadOnly Property HasChange() As Boolean
            Get
                Return mHasChange
            End Get
        End Property

#End Region

#Region "�v���p�e�B"

        ''' <summary>
        ''' ����
        ''' </summary>
        ''' <param name="strName"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Default Public Property Item(ByVal strName As String) As Object
            Get
                Return DataRow.Item(strName)
            End Get
            Set(ByVal value As Object)
                DataRow.Item(strName) = value
            End Set
        End Property

        Private mDataRow As DataRow
        ''' <summary>
        ''' DataRow
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataRow() As DataRow
            Get
                If Not IsNothing(mDataRow) Then
                    Return mDataRow
                End If
                If Not IsNothing(mDataRowView) Then
                    Return mDataRowView.Row
                End If
                Return Nothing
            End Get
            Set(ByVal value As DataRow)
                If Not IsNothing(mDataRowView) Then
                    Throw New Exception("Already DataRowView")
                End If
                mDataRow = value
            End Set
        End Property

        Private mDataRowView As DataRowView
        ''' <summary>
        ''' DataRowView
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataRowView() As DataRowView
            Get
                Return mDataRowView
            End Get
            Set(ByVal value As DataRowView)
                If Not IsNothing(mDataRow) Then
                    Throw New Exception("Already DataRow")
                End If
                mDataRowView = value
            End Set
        End Property

        ''' <summary>
        ''' DataRowState
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property RowState() As DataRowState
            Get
                If Not IsNothing(mDataRow) Then
                    Return mDataRow.RowState
                End If
                If Not IsNothing(mDataRowView) Then
                    Return mDataRowView.Row.RowState
                End If
                Debug.WriteLine("RowState Error")
                Return DataRowState.Unchanged
            End Get
        End Property

#End Region

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub New()

        End Sub

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <param name="row">DataRow</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal row As DataRow)
            mDataRow = row
        End Sub

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <param name="row">DataRowView</param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal row As DataRowView)
            mDataRowView = row
        End Sub

#End Region

#Region "�v���e�N�g�@���\�b�h"

        ''' <summary>
        ''' �J���������݂��邩�H
        ''' </summary>
        ''' <param name="strClmNam"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function IsColumn(ByVal strClmNam As String) As Boolean

            Dim clms As DataColumnCollection = Nothing
            If Not IsNothing(mDataRow) Then
                clms = mDataRow.Table.Columns
            End If
            If Not IsNothing(mDataRowView) Then
                clms = mDataRowView.Row.Table.Columns
            End If

            If Not IsNothing(clms) Then
                Return clms.Contains(strClmNam)
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' ������ �擾
        ''' </summary>
        ''' <param name="strItemName">���ږ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetString(ByVal strItemName As String) As String

            Return CFncCommon.ObjToStr(mprcGetObject(strItemName))

        End Function

        ''' <summary>
        ''' ������ �擾
        ''' </summary>
        ''' <param name="intItemID">����ID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetString(ByVal intItemID As Integer) As String

            Return CFncCommon.ObjToStr(mprcGetObject(intItemID))

        End Function

        ''' <summary>
        ''' Integer�^ �擾
        ''' </summary>
        ''' <param name="strItemName">���ږ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetInteger(ByVal strItemName As String) As Integer

            Return CFncCommon.ObjToInt(mprcGetObject(strItemName))

        End Function

        ''' <summary>
        ''' Integer�^ �擾
        ''' </summary>
        ''' <param name="intItemID">����ID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetInteger(ByVal intItemID As Integer) As Integer

            Return CFncCommon.ObjToInt(mprcGetObject(intItemID))

        End Function


        ''' <summary>
        ''' Short�^ �擾
        ''' </summary>
        ''' <param name="strItemName">���ږ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetShort(ByVal strItemName As String) As Short

            Return CFncCommon.ObjToSht(mprcGetObject(strItemName))

        End Function

        ''' <summary>
        ''' Short�^ �擾
        ''' </summary>
        ''' <param name="intItemID">����ID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetShort(ByVal intItemID As Integer) As Short

            Return CFncCommon.ObjToSht(mprcGetObject(intItemID))

        End Function

        ''' <summary>
        ''' Byte�^ �擾
        ''' </summary>
        ''' <param name="strItemName">���ږ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetByte(ByVal strItemName As String) As Byte

            Return CFncCommon.ObjToByt(mprcGetObject(strItemName))

        End Function

        ''' <summary>
        ''' Byte�^ �擾
        ''' </summary>
        ''' <param name="intItemID">����ID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetByte(ByVal intItemID As Integer) As Byte

            Return CFncCommon.ObjToByt(mprcGetObject(intItemID))

        End Function

        ''' <summary>
        ''' Single�^ �擾
        ''' </summary>
        ''' <param name="strItemName">���ږ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetSingle(ByVal strItemName As String) As Single

            Return CFncCommon.ObjToSng(mprcGetObject(strItemName))

        End Function

        ''' <summary>
        ''' Single�^ �擾
        ''' </summary>
        ''' <param name="intItemID">����ID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetSingle(ByVal intItemID As Integer) As Single

            Return CFncCommon.ObjToSng(mprcGetObject(intItemID))

        End Function

        ''' <summary>
        ''' �\�i���^ �擾
        ''' </summary>
        ''' <param name="strItemName">���ږ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetDecimal(ByVal strItemName As String) As Decimal

            Return CFncCommon.ObjToDec(mprcGetObject(strItemName))

        End Function

        ''' <summary>
        ''' �\�i���^ �擾
        ''' </summary>
        ''' <param name="intItemID">����ID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overloads Function GetDecimal(ByVal intItemID As Integer) As Decimal

            Return CFncCommon.ObjToDec(mprcGetObject(intItemID))

        End Function

        ''' <summary>
        ''' �l�@�ݒ�
        ''' </summary>
        ''' <typeparam name="T">�^</typeparam>
        ''' <param name="strItemName">���ږ�</param>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Protected Overloads Sub SetValue(Of T)(ByVal strItemName As String, ByVal value As T)

            If Not IsNothing(mDataRow) Then
                mDataRow.Item(strItemName) = value
                Return
            End If

            If Not IsNothing(mDataRowView) Then
                mDataRowView.Item(strItemName) = value
                Return
            End If

        End Sub

        ''' <summary>
        ''' �l�@�ݒ�
        ''' </summary>
        ''' <typeparam name="T">�^</typeparam>
        ''' <param name="intItemID">����ID</param>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Protected Overloads Sub SetValue(Of T)(ByVal intItemID As Integer, ByVal value As T)

            If Not IsNothing(mDataRow) Then
                mDataRow.Item(intItemID) = value
                Return
            End If

            If Not IsNothing(mDataRowView) Then
                mDataRowView.Item(intItemID) = value
                Return
            End If

        End Sub

#End Region

#Region "���\�b�h"

        ''' <summary>
        ''' Null�H
        ''' </summary>
        ''' <param name="strClmName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsNull(ByVal strClmName As String) As Boolean

            If ExistRow() Then
                Return IsDBNull(Me.Item(strClmName))
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' Row�͑��݂��邩�H
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExistRow() As Boolean

            If IsNothing(Me.DataRow) Then
                Return False
            Else
                Return True
            End If

        End Function

        ''' <summary>
        ''' �ύX������Ԃ��N���A����
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearHasChange()

            mHasChange = False

        End Sub

        ''' <summary>
        ''' BeginEdit
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub BeginEdit()

            If Not IsNothing(mDataRow) Then
                mDataRow.BeginEdit()
            End If

            If Not IsNothing(mDataRowView) Then
                mDataRowView.BeginEdit()
            End If

        End Sub

        ''' <summary>
        ''' EndEdit
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub EndEdit()

            If Not IsNothing(mDataRow) Then
                mDataRow.EndEdit()
            End If

            If Not IsNothing(mDataRowView) Then
                'EndEdit�オmDataRowView�̒l���s���ɂȂ�̂Œ��ӂ��邱��
                mDataRowView.EndEdit()
            End If

        End Sub

        ''' <summary>
        ''' Cancel Edit
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CancelEdit()

            If Not IsNothing(mDataRow) Then
                mDataRow.CancelEdit()
            End If

            If Not IsNothing(mDataRowView) Then
                mDataRowView.CancelEdit()
            End If

        End Sub

        ''' <summary>
        ''' Delete
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Delete()

            If Not IsNothing(mDataRow) Then
                mDataRow.Delete()
            End If

            If Not IsNothing(mDataRowView) Then
                mDataRowView.Delete()
            End If

        End Sub

        ''' <summary>
        ''' row�֎������R�s�[����
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Public Overloads Sub ToRow(ByVal row As DataRowView)

            ToRow(row.Row)

        End Sub

        ''' <summary>
        ''' row�֎������R�s�[����
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Public Overloads Sub ToRow(ByVal row As DataRow)

            Dim rowdst As DataRow = row

            Dim rowsrc As DataRow = Nothing
            If Not IsNothing(Me.DataRow) Then
                rowsrc = Me.DataRow
            End If
            If Not IsNothing(Me.DataRowView) Then
                rowsrc = Me.DataRowView.Row
            End If

            mprcCopyRow(rowdst, rowsrc)

        End Sub

        ''' <summary>
        ''' Src�������փR�s�[����
        ''' </summary>
        ''' <param name="src"></param>
        ''' <remarks></remarks>
        Public Overloads Sub CopyRow(ByVal src As CDataRowBase)

            Dim rowdst As DataRow = Nothing
            If Not IsNothing(Me.DataRow) Then
                rowdst = Me.DataRow
            End If
            If Not IsNothing(Me.DataRowView) Then
                rowdst = Me.DataRowView.Row
            End If

            Dim rowsrc As DataRow = Nothing
            If Not IsNothing(src.DataRow) Then
                rowsrc = src.DataRow
            End If
            If Not IsNothing(src.DataRowView) Then
                rowsrc = src.DataRowView.Row
            End If

            mprcCopyRow(rowdst, rowsrc)

        End Sub

        ''' <summary>
        ''' Src�������փR�s�[����
        ''' </summary>
        ''' <param name="src"></param>
        ''' <remarks></remarks>
        Public Overloads Sub CopyRow(ByVal src As DataRowView)

            Dim rowdst As DataRow = Nothing
            If Not IsNothing(Me.DataRow) Then
                rowdst = Me.DataRow
            End If
            If Not IsNothing(Me.DataRowView) Then
                rowdst = Me.DataRowView.Row
            End If

            Dim rowsrc As DataRow = src.Row

            mprcCopyRow(rowdst, rowsrc)

        End Sub

        ''' <summary>
        ''' �v���p�e�B�ɒl��ݒ肷��
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="obj"></param>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Overloads Sub SetValue(Of T)(ByRef obj As T, ByVal value As T)
            Try
                If mprcIsChange(obj, value) Then
                    obj = value
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        ''' <summary>
        ''' �v���p�e�B�ɒl��ݒ肷��
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <param name="strDate"></param>
        ''' <remarks>SW ���t���ڗp</remarks>
        Public Overloads Sub SetValueDate(ByRef obj As Object, ByVal strDate As String)

            Dim objValue As Object
            If strDate = String.Empty OrElse String.Compare(strDate, "        ") = 0 Then
                objValue = DBNull.Value
            Else
                Try
                    strDate = strDate.Substring(0, 4) & "/" & strDate.Substring(4, 2) & "/" & strDate.Substring(6, 2)
                    objValue = CDate(strDate)
                Catch ex As Exception
                    objValue = DBNull.Value
                End Try
            End If

            SetValue(obj, objValue)

        End Sub


#End Region

#Region "�v���C�x�[�g�@���\�b�h"

        Private Sub mprcCopyRow(ByVal rowdst As DataRow, ByVal rowsrc As DataRow)

            If IsNothing(rowdst) OrElse IsNothing(rowsrc) Then
                Throw New Exception("CopyItem")
                Return
            End If

            rowdst.BeginEdit()

            For i As Integer = 0 To rowdst.Table.Columns.Count - 1
                If Not rowdst.Table.Columns.Item(i).ReadOnly Then
                    rowdst.Item(i) = rowsrc.Item(i)
                End If
            Next i

            rowdst.EndEdit()

        End Sub

        ''' <summary>
        ''' �I�u�W�F�N�g���擾����
        ''' </summary>
        ''' <param name="strItemName">���ږ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Overloads Function mprcGetObject(ByVal strItemName As String) As Object

            If Not IsNothing(mDataRow) Then
                Return mDataRow.Item(strItemName)
            End If

            If Not IsNothing(mDataRowView) Then
                Return mDataRowView.Item(strItemName)
            End If

            Return Nothing

        End Function

        Private Overloads Function mprcGetObject(ByVal intItemID As Integer) As Object

            If Not IsNothing(mDataRow) Then
                Return mDataRow.Item(intItemID)
            End If

            If Not IsNothing(mDataRowView) Then
                Return mDataRowView.Item(intItemID)
            End If

            Return Nothing

        End Function

        Private Function mprcIsChange(ByVal objOldValue As Object, ByVal objNewValue As Object) As Boolean

            Dim blnRet As Boolean = False

            Try
                If IsNothing(objOldValue) Then
                    If Not IsNothing(objNewValue) Then
                        blnRet = True
                    End If
                Else
                    '������̎��͌��̋󔒂���菜���Ĕ�r����
                    If TypeOf objOldValue Is String AndAlso TypeOf objNewValue Is String Then
                        If String.Compare(CStr(objOldValue).TrimEnd, CStr(objNewValue).TrimEnd) <> 0 Then
                            blnRet = True
                        End If
                    Else
                        blnRet = Not objOldValue.Equals(objNewValue)
                    End If
                End If
                If blnRet Then
                    mHasChange = True
                End If
                Return blnRet
            Catch ex As Exception
                Throw ex
            End Try

        End Function

#End Region

    End Class

End Namespace