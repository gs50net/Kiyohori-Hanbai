Namespace Functions

    ''' <summary>
    ''' �R���g���[���֌W�̃N���X
    ''' </summary>
    ''' <remarks>���̃N���X�̓C���X�^���X���ł��܂���B</remarks>
    Public Class CFncControl

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
        ''' �e�R���g���[���Ɋ܂܂��S�ẴR���g���[�����擾���܂�
        ''' </summary>
        ''' <param name="top">�e�R���g���[��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetAllControls(ByVal top As Control) As Control()

            Dim buf As ArrayList = New ArrayList
            For Each c As Control In top.Controls
                buf.Add(c)
                buf.AddRange(GetAllControls(c))
            Next

            Return DirectCast(buf.ToArray(GetType(Control)), Control())

        End Function

        ''' <summary>
        ''' �e�R���g���[���Ɋ܂܂��S�Ă�SplitContainer�R���g���[�����擾���܂�
        ''' </summary>
        ''' <param name="top"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetAppSplitContainer(ByVal top As Control) As SplitContainer()

            Dim buf As ArrayList = New ArrayList
            Dim actr As Control() = CFncControl.GetAllControls(top)
            For Each c As Control In actr
                If TypeOf c Is SplitContainer Then
                    buf.Add(c)
                End If
            Next

            Return DirectCast(buf.ToArray(GetType(SplitContainer)), SplitContainer())

        End Function

        ''' <summary>
        ''' �e�R���g���[���Ɋ܂܂��S�Ă�UserControl�R���g���[�����擾���܂�
        ''' </summary>
        ''' <param name="top"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetAppUserControl(ByVal top As Control) As UserControl()

            Dim buf As ArrayList = New ArrayList
            Dim actr As Control() = CFncControl.GetAllControls(top)
            For Each c As Control In actr
                If TypeOf c Is UserControl Then
                    buf.Add(c)
                End If
            Next

            Return DirectCast(buf.ToArray(GetType(UserControl)), UserControl())

        End Function

        ''' <summary>
        ''' �e�R���g���[���Ɋ܂܂��S�Ẵ{�^���̕\����ݒ肵�܂�
        ''' </summary>
        ''' <param name="ctrTarget">�e�R���g���[��</param>
        ''' <param name="blnVisible">Visible�ɐݒ肷��l</param>
        ''' <remarks></remarks>
        Public Shared Sub VisibleAllButton(ByVal ctrTarget As Control, ByVal blnVisible As Boolean)

            Dim actr As Control() = CFncControl.GetAllControls(ctrTarget)
            For Each ctr As Control In actr
                If TypeOf ctr Is Button Then
                    ctr.Visible = blnVisible
                End If
            Next

        End Sub

        ''' <summary>
        '''  �e�R���g���[���Ɋ܂܂��S�ẴR���g���[���̗L���E������ݒ肵�܂�
        ''' </summary>
        ''' <param name="ctrTarget">�e�R���g���[��</param>
        ''' <param name="blnEnabled">Enabled�ɐݒ肷��l</param>
        ''' <param name="actl">��O�R���g���[��()</param>
        ''' <remarks></remarks>
        Public Shared Sub EnabledAllControl(ByVal ctrTarget As Control, ByVal blnEnabled As Boolean, Optional ByVal actl() As Control = Nothing)

            Dim actr As Control() = CFncControl.GetAllControls(ctrTarget)
            For Each ctr As Control In actr
                If actl IsNot Nothing Then
                    If Array.IndexOf(actl, ctr) >= 0 Then
                        Continue For
                    End If
                End If
                ctr.Enabled = blnEnabled
            Next

        End Sub

        ''' <summary>
        ''' �o�C���h����Ă��鍀�ڂ̓��e�����͂���Ă���΃o�C���h�t�B�[���h���擾����
        ''' </summary>
        ''' <param name="ctr">�R���g���[��</param>
        ''' <param name="row">DataRow</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function GetChangeItem(ByVal ctr As Control, ByVal row As DataRow) As String

            Dim ret As String = String.Empty

            '�o�C���h����Ă��邩�H
            If ctr.DataBindings.Count > 0 Then
                Dim item As String = ctr.DataBindings.Item(0).BindingMemberInfo.BindingField
                ''�o�C���h����Ă��鍀�ڂ̓��e�����͂��ꂽ���H
                'If row.HasVersion(DataRowVersion.Proposed) Then
                '    ret = item
                'End If
                If row.Table.Columns.Contains(item) Then
                    If row.HasVersion(DataRowVersion.Current) AndAlso row.HasVersion(DataRowVersion.Default) Then
                        If Not row.Item(item, DataRowVersion.Current).Equals(row.Item(item, DataRowVersion.Default)) Then
                            ret = item
                        End If
                    End If
                End If
            End If

            Return ret

        End Function

        ''' <summary>
        ''' �o�C���h����Ă��鍀�ڂ̓��e�����͂���Ă���΃o�C���h�t�B�[���h���擾����
        ''' </summary>
        ''' <param name="ctr">�R���g���[��</param>
        ''' <param name="drv">DataRowView</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function GetChangeItem(ByVal ctr As Control, ByVal drv As DataRowView) As String

            Return GetChangeItem(ctr, drv.Row)

        End Function

        ''' <summary>
        ''' �������`�悷��Ƃ��̑傫�����v������
        ''' </summary>
        ''' <param name="str">������</param>
        ''' <param name="ctr">�`�悷��R���g���[��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function GetStringSize(ByVal str As String, ByVal ctr As Control) As Size

            Dim size As Size = GetStringSize(str, ctr, ctr.Font)
            Return size

        End Function

        Public Overloads Shared Function GetStringSize(ByVal str As String, ByVal ctr As Control, ByVal fnt As Font) As Size

            Dim g As Graphics = ctr.CreateGraphics()

            '�����̊O�ڂ���l�p�`�̃T�C�Y
            Dim proposedSize As New Size(Integer.MaxValue, Integer.MaxValue)
            '�]������菜��
            Dim flags As TextFormatFlags = TextFormatFlags.NoPadding
            '�T�C�Y�̌v��
            Dim size As Size = TextRenderer.MeasureText(g, str, fnt, proposedSize, flags)

            g.Dispose()

            Return size

        End Function

#End Region

    End Class

End Namespace