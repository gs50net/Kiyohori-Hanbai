Namespace Functions

    ''' <summary>
    ''' コントロール関係のクラス
    ''' </summary>
    ''' <remarks>このクラスはインスタンス化できません。</remarks>
    Public Class CFncControl

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks>このコンストラクタはこのクラスをインスタンス化をできないようにします。</remarks>
        Private Sub New()
        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' 親コントロールに含まれる全てのコントロールを取得します
        ''' </summary>
        ''' <param name="top">親コントロール</param>
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
        ''' 親コントロールに含まれる全てのSplitContainerコントロールを取得します
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
        ''' 親コントロールに含まれる全てのUserControlコントロールを取得します
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
        ''' 親コントロールに含まれる全てのボタンの表示を設定します
        ''' </summary>
        ''' <param name="ctrTarget">親コントロール</param>
        ''' <param name="blnVisible">Visibleに設定する値</param>
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
        '''  親コントロールに含まれる全てのコントロールの有効・無効を設定します
        ''' </summary>
        ''' <param name="ctrTarget">親コントロール</param>
        ''' <param name="blnEnabled">Enabledに設定する値</param>
        ''' <param name="actl">例外コントロール()</param>
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
        ''' バインドされている項目の内容が入力されていればバインドフィールドを取得する
        ''' </summary>
        ''' <param name="ctr">コントロール</param>
        ''' <param name="row">DataRow</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function GetChangeItem(ByVal ctr As Control, ByVal row As DataRow) As String

            Dim ret As String = String.Empty

            'バインドされているか？
            If ctr.DataBindings.Count > 0 Then
                Dim item As String = ctr.DataBindings.Item(0).BindingMemberInfo.BindingField
                ''バインドされている項目の内容が入力されたか？
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
        ''' バインドされている項目の内容が入力されていればバインドフィールドを取得する
        ''' </summary>
        ''' <param name="ctr">コントロール</param>
        ''' <param name="drv">DataRowView</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function GetChangeItem(ByVal ctr As Control, ByVal drv As DataRowView) As String

            Return GetChangeItem(ctr, drv.Row)

        End Function

        ''' <summary>
        ''' 文字列を描画するときの大きさを計測する
        ''' </summary>
        ''' <param name="str">文字列</param>
        ''' <param name="ctr">描画するコントロール</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function GetStringSize(ByVal str As String, ByVal ctr As Control) As Size

            Dim size As Size = GetStringSize(str, ctr, ctr.Font)
            Return size

        End Function

        Public Overloads Shared Function GetStringSize(ByVal str As String, ByVal ctr As Control, ByVal fnt As Font) As Size

            Dim g As Graphics = ctr.CreateGraphics()

            '初期の外接する四角形のサイズ
            Dim proposedSize As New Size(Integer.MaxValue, Integer.MaxValue)
            '余白を取り除く
            Dim flags As TextFormatFlags = TextFormatFlags.NoPadding
            'サイズの計測
            Dim size As Size = TextRenderer.MeasureText(g, str, fnt, proposedSize, flags)

            g.Dispose()

            Return size

        End Function

#End Region

    End Class

End Namespace