Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports Hanbai.Common.Functions
Imports Hanbai.Common.DataBase
Imports Hanbai.Common.DataBase.MyDB

Namespace Classes

    ''' <summary>
    ''' コントロール　ヘルパー　クラス
    ''' </summary>
    ''' <remarks>このクラスはインスタンス化できません。</remarks>
    Public Class ControllHelper

        Private Const MAX_DropDownRows As Integer = 20

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks>このコンストラクタはこのクラスをインスタンス化をできないようにします。</remarks>
        Private Sub New()
        End Sub

#End Region

#Region "メソッド"

#Region "CheckedComboBoxEdit"

        Public Overloads Shared Sub LoadItems(ByVal cbe As CheckedComboBoxEdit,
                                              ByVal strTableName As String,
                                              ByVal strDisplayMember As String,
                                              ByVal strValueMember As String,
                                              Optional ByVal strWhere As String = "")

            Dim dtgTbl As MyDBDataGateway = mprcGetTable(strTableName, strWhere)
            If Not IsNothing(dtgTbl) Then
                With cbe.Properties.Items
                    .Clear()
                    For Each row As DataRow In dtgTbl.Rows
                        Dim i As Integer = .Add(row.Item(strValueMember))
                        With .Item(i)
                            .CheckState = CheckState.Unchecked
                            .Description = CFncCommon.ObjToStr(row.Item(strDisplayMember))
                        End With
                    Next
                End With
            End If

            With cbe.Properties
                .ShowPopupCloseButton = True
                .ShowButtons = True

                If .Items.Count > MAX_DropDownRows Then
                    .DropDownRows = MAX_DropDownRows
                Else
                    .DropDownRows = .Items.Count + 1
                End If
            End With

        End Sub

        Public Overloads Shared Sub LoadItems(ByVal cbe As CheckedComboBoxEdit,
                                              ByVal tbl As DataTable,
                                              ByVal strDisplayMember As String,
                                              ByVal strValueMember As String)

            With cbe.Properties
                .Items.Clear()
                With .Items
                    For Each row As DataRow In tbl.Rows
                        Dim i As Integer = .Add(row.Item(strValueMember))
                        With .Item(i)
                            .CheckState = CheckState.Unchecked
                            .Description = CFncCommon.ObjToStr(row.Item(strDisplayMember))
                        End With
                    Next
                End With

                .ShowPopupCloseButton = True
                .ShowButtons = True

                If .Items.Count > MAX_DropDownRows Then
                    .DropDownRows = MAX_DropDownRows
                Else
                    .DropDownRows = .Items.Count + 1
                End If
            End With

        End Sub

        ''' <summary>
        ''' 全てのCheckStateを設定する
        ''' </summary>
        ''' <param name="ctr"></param>
        ''' <param name="state"></param>
        ''' <remarks></remarks>
        Public Shared Sub SetAllCheckState(ByVal ctr As CheckedComboBoxEdit, ByVal state As CheckState)
            For Each chk As DevExpress.XtraEditors.Controls.CheckedListBoxItem In ctr.Properties.Items
                chk.CheckState = state
            Next
        End Sub

        ''' <summary>
        ''' Check件数を取得する
        ''' </summary>
        ''' <param name="ctr"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetCheckItemCount(ByVal ctr As CheckedComboBoxEdit) As Integer

            Dim ret As Integer = 0
            With ctr.Properties.Items
                For i As Integer = 0 To .Count - 1
                    If .Item(i).CheckState = CheckState.Checked Then
                        ret += 1
                    End If
                Next i
            End With

            Return ret

        End Function

        ''' <summary>
        ''' Checkされた値の配列を取得する
        ''' </summary>
        ''' <param name="ctr"></param>
        ''' <param name="lst"></param>
        ''' <remarks></remarks>
        Public Shared Sub CheckedItem(ByVal ctr As CheckedComboBoxEdit, ByRef lst As ArrayList)

            With ctr.Properties.Items
                For i As Integer = 0 To .Count - 1
                    If .Item(i).CheckState = CheckState.Checked Then
                        lst.Add(.Item(i).Value)
                    End If
                Next i
            End With

        End Sub

        ''' <summary>
        ''' CheckedComboBoxEditよりIN句を生成する
        ''' </summary>
        ''' <param name="chk"></param>
        ''' <param name="strFieldName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function MakeInStatement(ByVal chk As CheckedComboBoxEdit, ByVal strFieldName As String) As String

            Dim strFilter As String = String.Empty

            With chk.Properties.Items
                For i As Integer = 0 To .Count - 1
                    If .Item(i).CheckState = CheckState.Checked Then
                        If strFilter = String.Empty Then
                            strFilter = String.Format(" AND {0} IN(", strFieldName)
                        End If
                        If TypeOf .Item(i).Value Is System.Guid Then
                            strFilter &= "'" & DirectCast(.Item(i).Value, System.Guid).ToString() & "',"
                        Else
                            strFilter &= "'" & CStr(.Item(i).Value) & "',"
                        End If
                    End If
                Next i
                If strFilter <> String.Empty Then
                    strFilter = strFilter.Remove(strFilter.Length() - 1, 1) & ")"
                End If
            End With

            Return strFilter

        End Function

#End Region

#Region "ComboBoxEdit"

        Public Overloads Shared Function DataBindings(ByVal ctr As ComboBoxEdit,
                                                      ByVal tbl As DataTable,
                                                      ByVal strDisplayMember As String) As Integer

            With ctr.Properties
                .Items.Clear()
                With .Items
                    For Each row As DataRow In tbl.Rows
                        Dim i As Integer = .Add(row.Item(strDisplayMember))
                    Next
                End With

                If .Items.Count > MAX_DropDownRows Then
                    .DropDownRows = MAX_DropDownRows
                Else
                    .DropDownRows = .Items.Count + 1
                End If
            End With

            Return ctr.Properties.Items.Count

        End Function

#End Region

#Region "LookUpEdit"

        Public Overloads Shared Function DataBindings(ByVal ctr As LookUpEdit,
                                                      ByVal vw As MyDBDataGateway,
                                                      ByVal strDisplayMember As String,
                                                      ByVal strValueMember As String,
                                                      Optional ByVal objBindingSource As Object = Nothing,
                                                      Optional ByVal strClmName As String = "") As Integer

            mprcDataBindingsSub(ctr, objBindingSource, vw.Table, strClmName, strValueMember, strDisplayMember)

            Return vw.Count

        End Function

        Public Overloads Shared Function DataBindings(ByVal ctr As LookUpEdit,
                                                      ByVal tbl As DataTable,
                                                      ByVal strDisplayMember As String,
                                                      ByVal strValueMember As String,
                                                      Optional ByVal objBindingSource As Object = Nothing,
                                                      Optional ByVal strClmName As String = "") As Integer

            mprcDataBindingsSub(ctr, objBindingSource, tbl, strClmName, strValueMember, strDisplayMember)

            Return tbl.Rows.Count

        End Function

        Public Overloads Shared Function DataBindings(ByVal ctr As Repository.RepositoryItemLookUpEdit,
                                                      ByVal strTableName As String,
                                                      ByVal strDisplayMember As String,
                                                      ByVal strValueMember As String,
                                                      Optional ByVal strWhere As String = "") As Integer

            Dim dtgTbl As MyDBDataGateway = mprcGetTable(strTableName, strWhere)
            If Not IsNothing(dtgTbl) Then
                mprcDataBindingsSub(ctr, dtgTbl.Table, strValueMember, strDisplayMember)
                Return dtgTbl.Count
            Else
                Return 0
            End If

        End Function

        Public Overloads Shared Function DataBindings(ByVal ctr As LookUpEdit,
                                                      ByVal strTableName As String,
                                                      ByVal strDisplayMember As String,
                                                      ByVal strValueMember As String,
                                                      Optional ByVal objBindingSource As Object = Nothing,
                                                      Optional ByVal strClmName As String = "",
                                                      Optional ByVal strWhere As String = "") As Integer

            Dim dtgTbl As MyDBDataGateway = mprcGetTable(strTableName, strWhere)
            If Not IsNothing(dtgTbl) Then
                mprcDataBindingsSub(ctr, objBindingSource, dtgTbl.Table, strClmName, strValueMember, strDisplayMember)
                Return dtgTbl.Count
            Else
                Return 0
            End If

        End Function

        Public Overloads Shared Function DataBindings(ByVal ctr As Repository.RepositoryItemLookUpEdit,
                                                      ByVal Table As DataTable,
                                                      ByVal strDisplayMember As String,
                                                      ByVal strValueMember As String,
                                                      Optional ByVal objBindingSource As Object = Nothing,
                                                      Optional ByVal strClmName As String = "",
                                                      Optional ByVal strWhere As String = "") As Integer

            mprcDataBindingsSub(ctr, Table, strValueMember, strDisplayMember)

            Return Table.Rows.Count

        End Function

        Public Overloads Shared Function DataBindings(ByVal ctr As Repository.RepositoryItemLookUpEdit,
                                                   ByVal View As DataView,
                                                   ByVal strDisplayMember As String,
                                                   ByVal strValueMember As String,
                                                   Optional ByVal objBindingSource As Object = Nothing,
                                                   Optional ByVal strClmName As String = "",
                                                   Optional ByVal strWhere As String = "") As Integer

            mprcDataBindingsSub(ctr, View, strValueMember, strDisplayMember)

            Return View.Count

        End Function

#End Region

#Region "CheckedListBoxControl"

        Public Shared Sub SetAllCheckState(ByVal ctr As CheckedListBoxControl, ByVal state As CheckState)
            For Each chk As DevExpress.XtraEditors.Controls.CheckedListBoxItem In ctr.Items
                chk.CheckState = state
            Next
        End Sub

        Public Shared Sub ClearItems(ByVal ctr As CheckedListBoxControl)
            With ctr
                While (.ItemCount > 0)
                    .Items.Remove(.Items(0))
                End While
            End With
        End Sub

        Public Shared Function GetCheckItemCount(ByVal ctr As CheckedListBoxControl) As Integer

            Dim ret As Integer = 0
            With ctr.Items
                For i As Integer = 0 To .Count - 1
                    If .Item(i).CheckState = CheckState.Checked Then
                        ret += 1
                    End If
                Next i
            End With

            Return ret

        End Function

#End Region

#End Region

#Region "プライベート　メソッド"

        Private Overloads Shared Sub mprcDataBindingsSub( _
                                           ByVal ctr As LookUpEdit, _
                                           ByVal objBindingSource As Object, _
                                           ByVal objDataSource As Object, _
                                           ByVal strClmName As String, _
                                           ByVal strValueMember As String, _
                                           ByVal strDisplayMember As String)

            With ctr.Properties
                .TextEditStyle = Controls.TextEditStyles.DisableTextEditor
                .NullText = String.Empty
                .DataSource = objDataSource
                .DisplayMember = strDisplayMember
                .ValueMember = strValueMember
                If Not IsNothing(objBindingSource) AndAlso strClmName <> String.Empty Then
                    'ctr.DataBindings.Add("SelectedValue", objBindingSource, strClmName, True)
                    ctr.DataBindings.Add("EditValue", objBindingSource, strClmName, True)
                End If
                If .Columns.Count < 2 Then
                    .ShowHeader = False
                End If
                .AppearanceDropDownHeader.Font = New System.Drawing.Font(My.Resources.APP_FONT_NAME, 9)
                .AppearanceDropDown.Font = New System.Drawing.Font(My.Resources.APP_FONT_NAME, 9)
                If TypeOf objDataSource Is DataTable Then
                    If DirectCast(objDataSource, DataTable).Rows.Count > MAX_DropDownRows Then
                        .DropDownRows = MAX_DropDownRows
                    Else
                        .DropDownRows = DirectCast(objDataSource, DataTable).Rows.Count
                    End If
                End If
            End With

        End Sub

        Private Overloads Shared Sub mprcDataBindingsSub( _
                                           ByVal ctr As Repository.RepositoryItemLookUpEdit, _
                                           ByVal objDataSource As Object, _
                                           ByVal strValueMember As String, _
                                           ByVal strDisplayMember As String)

            With ctr
                .TextEditStyle = Controls.TextEditStyles.DisableTextEditor
                .NullText = String.Empty
                .DataSource = objDataSource
                .DisplayMember = strDisplayMember
                .ValueMember = strValueMember
                If .Columns.Count < 2 Then
                    .ShowHeader = False
                End If
                .AppearanceDropDownHeader.Font = New System.Drawing.Font(My.Resources.APP_FONT_NAME, 9)
                .AppearanceDropDown.Font = New System.Drawing.Font(My.Resources.APP_FONT_NAME, 9)

                If TypeOf objDataSource Is DataTable Then
                    If DirectCast(objDataSource, DataTable).Rows.Count > MAX_DropDownRows Then
                        .DropDownRows = MAX_DropDownRows
                    Else
                        .DropDownRows = DirectCast(objDataSource, DataTable).Rows.Count
                    End If
                End If
            End With

        End Sub

        Private Shared Function mprcGetTable(ByVal strTableName As String, ByVal strWhere As String) As MyDBDataGateway

            Dim dtgTbl As MyDBDataGateway = Nothing
            Dim strOrder As String = Nothing

            Select Case strTableName
                Case T_材料区分Table.TABLE_NAME
                    dtgTbl = New T_材料区分Table
                    strOrder = T_材料区分Row.CON_材料区分コード
                Case Else
                    CFncMessage.ErrorMessage("ControllHelper.mprcGetTable Table Name Error")
            End Select

            dtgTbl.Fill(strWhere, strOrder)

            Return dtgTbl

        End Function

#End Region

    End Class

End Namespace
