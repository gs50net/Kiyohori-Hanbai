Imports System.Text
Imports System.IO

Namespace Classes

    Public Class clsSQL

        Private Const CLICK_ONCE_FOLDER As String = "\Apps\2.0"
        Private Const SQL_PATH As String = "\SQL"

        Public Shared Function LoadSQL(ByVal strName As String) As String

            Dim strFileName As String = String.Empty

            Try
                '実行時のパスを取得
                Dim asm As Reflection.Assembly = Reflection.Assembly.GetEntryAssembly()
                Dim ExecPath As String = asm.Location
                'MessageBox.Show(ExecPath)
                If ExecPath.IndexOf(CLICK_ONCE_FOLDER) > 0 Then
                    'Click Onceの場合
                    Dim DataPath As String = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory
                    strFileName = Path.Combine(DataPath & SQL_PATH, strName)
                Else
                    'Click Onceで無い場合
                    strFileName = Path.Combine(Path.GetDirectoryName(ExecPath) & SQL_PATH, strName)
                End If

                Dim strSql As String = Nothing
                Using sr As New StreamReader(strFileName, Encoding.GetEncoding("Shift_JIS"))
                    strSql = sr.ReadToEnd
                End Using

                Return strSql
            Catch ex As Exception
                CFncMessage.ErrorMessage(ex.Message)
                Return Nothing
            End Try

        End Function


    End Class

End Namespace
