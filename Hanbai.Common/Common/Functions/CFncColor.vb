Namespace Functions

    Public Class CFncColor

        Public Shared Function ColorSettingValueParse(ByVal val As String) As System.Drawing.Color

            If val Is Nothing OrElse val.Equals(String.Empty) Then
                Return Color.Empty
            End If

            If val.Substring(0, 1).Equals("#") Then
                Return ColorSettingValueHex(val)
            ElseIf val.Split(","c).Length = 3 Then
                Return ColorSettingValueRGB(val)
            Else
                Return ColorSettingValueName(val)
            End If

        End Function

        Public Shared Function ColorSettingValueHex(ByVal val As String) As System.Drawing.Color

            If Not val Is Nothing OrElse Not (val.Trim.Length = 7) OrElse Not (val.Trim.Substring(0, 1).Equals("#")) Then
                Dim hexVal As String = val.Trim.Substring(1, 6)
                If IsNumeric(hexVal) Then
                    Return ColorFromArgbColl(CInt(hexVal.Substring(0, 2)), CInt(hexVal.Substring(2, 2)), CInt(hexVal.Substring(4, 2)))
                Else
                    Return Color.Empty
                End If
            Else
                Return Color.Empty
            End If

        End Function

        Public Shared Function ColorSettingValueRGB(ByVal val As String) As System.Drawing.Color

            If Not val Is Nothing OrElse val.Split(","c).Length = 3 Then
                Dim spString() As String = val.Split(","c)
                If IsNumeric(spString(0)) AndAlso IsNumeric(spString(1)) AndAlso IsNumeric(spString(2)) Then
                    Return ColorFromArgbColl(CInt(spString(0)), CInt(spString(1)), CInt(spString(2)))
                Else
                    Return Color.Empty
                End If
            Else
                Return Color.Empty
            End If

        End Function

        Private Shared Function ColorFromArgbColl(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Color

            If (0 <= R AndAlso R <= 255) AndAlso (0 <= G AndAlso G <= 255) AndAlso (0 <= B AndAlso B <= 255) Then
                Return Color.FromArgb(R, G, B)
            Else
                Return Color.Empty
            End If

        End Function

        Public Shared Function ColorSettingValueName(ByVal val As String) As System.Drawing.Color

            If Not val Is Nothing Then
                Return Color.FromName(val)
            Else
                Return Color.Empty
            End If

        End Function

    End Class

End Namespace