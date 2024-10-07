#Region "参照"

Imports System.IO

#End Region

Namespace Functions

    ''' <summary>
    ''' グラフィック関係のクラス
    ''' </summary>
    ''' <remarks>このクラスはインスタンス化できません。</remarks>
    Public Class CFncGraphic

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks>このコンストラクタはこのクラスをインスタンス化をできないようにします。</remarks>
        Private Sub New()
        End Sub

#End Region

        ''' <summary>
        ''' イメージファイルを読み込みImageを生成する
        ''' </summary>
        ''' <param name="strFileName">イメージファイル名</param>
        ''' <returns>成功すると Image が返ります。失敗すると Nothing が返ります。</returns>
        ''' <remarks></remarks>
        Public Shared Function LoadImageFile(ByVal strFileName As String) As Image

            Dim img As Image = Nothing

            If File.Exists(strFileName) Then
                Try
                    img = New Bitmap(strFileName)
                Catch ex As Exception
                    Debug.WriteLine(strFileName, "CFncGraphic.LoadImageFile Error")
                End Try
            Else
                Debug.WriteLine(strFileName, "CFncGraphic.LoadImageFile Error")
            End If

            Return img

        End Function

    End Class

End Namespace