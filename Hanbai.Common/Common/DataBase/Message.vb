Imports Hanbai.Common.Classes

Namespace DataBase

    Public Class Message

        ''' <summary>
        ''' エラーメッセージを表示します
        ''' </summary>
        ''' <param name="strMsg"></param>
        ''' <param name="strCaption"></param>
        ''' <remarks></remarks>
        Public Shared Sub ErrorMessage(ByVal strMsg As String, Optional ByVal strCaption As String = "")

            Select Case CClsSetting.GetInstance.pblnOutputWindow
                Case True
                    MessageBox.Show(strMsg, strCaption)
                Case False
                    If strCaption <> String.Empty Then
                        Console.WriteLine(strCaption & " - " & strMsg)
                    Else
                        Console.WriteLine(strMsg)
                    End If

            End Select
        End Sub

    End Class

End Namespace
