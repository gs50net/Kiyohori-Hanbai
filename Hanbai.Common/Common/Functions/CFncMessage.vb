Imports DevExpress.XtraEditors
Imports System.Runtime.InteropServices

Namespace Functions

    ''' <summary>
    ''' メッセージ関係のクラス
    ''' </summary>
    ''' <remarks>このクラスはインスタンス化できません。</remarks>
    Public Class CFncMessage

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
        ''' メッセージ ボックスを表示します
        ''' </summary>
        ''' <param name="strMsg">メッセージ</param>
        ''' <param name="strCaption">キャプション</param>
        ''' <param name="buttons">ボタン</param>
        ''' <param name="icon">アイコン</param>
        ''' <param name="defaultButton">規定ボタン</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function MessageBox( _
                                            ByVal strMsg As String, _
                                            ByVal strCaption As String, _
                                            ByVal buttons As MessageBoxButtons, _
                                            ByVal icon As MessageBoxIcon, _
                                            ByVal defaultButton As MessageBoxDefaultButton _
                                            ) As DialogResult

            Microsoft.VisualBasic.Beep()

            Return XtraMessageBox.Show(strMsg, strCaption, buttons, icon, defaultButton)

        End Function

        ''' <summary>
        ''' メッセージ ボックスを表示します
        ''' </summary>
        ''' <param name="strMsg"></param>
        ''' <param name="strCaption"></param>
        ''' <param name="buttons"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function MessageBox( _
                                            ByVal strMsg As String, _
                                            ByVal strCaption As String, _
                                            ByVal buttons As MessageBoxButtons _
                                            ) As DialogResult

            Microsoft.VisualBasic.Beep()

            Return XtraMessageBox.Show(strMsg, strCaption, buttons)

        End Function

        ''' <summary>
        ''' メッセージ ボックスを表示します
        ''' </summary>
        ''' <param name="strMsg"></param>
        ''' <param name="strCaption"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function MessageBox( _
                                            ByVal strMsg As String, _
                                            ByVal strCaption As String _
                                            ) As DialogResult

            Microsoft.VisualBasic.Beep()

            Return XtraMessageBox.Show(strMsg, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Function

        ''' <summary>
        ''' メッセージ ボックスを表示します
        ''' </summary>
        ''' <param name="strMsg"></param>
        ''' <param name="strCaption"></param>
        ''' <param name="buttons"></param>
        ''' <param name="icon"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function MessageBox( _
                                            ByVal strMsg As String, _
                                            ByVal strCaption As String, _
                                            ByVal buttons As MessageBoxButtons, _
                                            ByVal icon As MessageBoxIcon _
                                            ) As DialogResult

            Microsoft.VisualBasic.Beep()

            Return XtraMessageBox.Show(strMsg, strCaption, buttons, icon)

        End Function

        '''' <summary>
        '''' メッセージ ボックスを表示します
        '''' </summary>
        '''' <param name="strMsg"></param>
        '''' <remarks></remarks>
        'Public Overloads Shared Sub MessageBox(ByVal strMsg As String)

        '    Microsoft.VisualBasic.Beep()

        '    Windows.Forms.MessageBox.Show(strMsg)

        'End Sub

        ''' <summary>
        ''' エラーメッセージ
        ''' </summary>
        ''' <param name="strMsg">メッセージ</param>
        ''' <param name="strCaption">キャプション</param>
        ''' <remarks></remarks>
        Public Shared Sub ErrorMessage( _
                                ByVal strMsg As String, _
                                Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.Error, _
                                Optional ByVal strCaption As String = "" _
                                )

            Microsoft.VisualBasic.Beep()

            If strCaption = String.Empty Then
                strCaption = My.Resources.MSG_ERROR
            End If

            XtraMessageBox.Show(strMsg, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Sub

#End Region

    End Class

End Namespace
