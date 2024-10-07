Namespace Functions

    ''' <summary>
    ''' ＣＳＶ関係のクラス
    ''' </summary>
    ''' <remarks>このクラスはインスタンス化できません。</remarks>
    Public Class CFncCSV

#Region "定数"

        'UniCodeの空白
        Private Const SPACE As Char = " "c

#End Region

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
        ''' CSV文字列を分解する
        ''' </summary>
        ''' <param name="csvText">文字列</param>
        ''' <returns>分解後の文字列配列</returns>
        ''' <remarks>この関数は「,」区切りのＣＳＶの読み込みです。
        ''' TSVは「Split」を使用すること</remarks>
        Public Shared Function SplitCSVString(ByVal csvText As String) As String()

            '前後の改行を削除しておく
            csvText = csvText.Trim(New Char() {ControlChars.Cr, ControlChars.Lf})

            Dim csvRecords As New System.Collections.ArrayList
            Dim csvFields As New System.Collections.ArrayList

            Dim csvTextLength As Integer = csvText.Length
            Dim startPos As Integer = 0
            Dim endPos As Integer = 0
            Dim field As String = String.Empty

            While True
                '空白を飛ばす
                While startPos < csvTextLength _
                    AndAlso (csvText.Chars(startPos) = SPACE OrElse csvText.Chars(startPos) = ControlChars.Tab)
                    startPos += 1
                End While

                'データの最後の位置を取得
                If startPos < csvTextLength AndAlso csvText.Chars(startPos) = ControlChars.Quote Then
                    '"で囲まれているとき
                    '最後の"を探す
                    endPos = startPos
                    While True
                        endPos = csvText.IndexOf(ControlChars.Quote, endPos + 1)
                        If endPos < 0 Then
                            Throw New ApplicationException("""が不正")
                        End If
                        '"が2つ続かない時は終了
                        If endPos + 1 = csvTextLength OrElse csvText.Chars((endPos + 1)) <> ControlChars.Quote Then
                            Exit While
                        End If
                        '"が2つ続く
                        endPos += 1
                    End While

                    '一つのフィールドを取り出す
                    field = csvText.Substring(startPos, endPos - startPos + 1)
                    '""を"にする
                    field = field.Substring(1, field.Length - 2).Replace("""""", """")

                    endPos += 1
                    '空白を飛ばす
                    While endPos < csvTextLength AndAlso _
                        csvText.Chars(endPos) <> ","c AndAlso _
                        csvText.Chars(endPos) <> ControlChars.Lf
                        endPos += 1
                    End While
                Else
                    '"で囲まれていない
                    'カンマか改行の位置
                    endPos = startPos
                    While endPos < csvTextLength AndAlso _
                        csvText.Chars(endPos) <> ","c AndAlso _
                        csvText.Chars(endPos) <> ControlChars.Lf
                        endPos += 1
                    End While

                    '一つのフィールドを取り出す
                    field = csvText.Substring(startPos, endPos - startPos)
                    '後の空白を削除
                    field = field.TrimEnd()
                End If

                'フィールドの追加
                csvFields.Add(field)

                '行の終了か調べる
                If endPos >= csvTextLength OrElse csvText.Chars(endPos) = ControlChars.Lf Then
                    '行の終了
                    'レコードの追加
                    csvFields.TrimToSize()
                    csvRecords.Add(csvFields)
                    csvFields = New System.Collections.ArrayList(csvFields.Count)

                    If endPos >= csvTextLength Then
                        '終了
                        Exit While
                    End If
                End If

                '次のデータの開始位置
                startPos = endPos + 1
            End While

            csvRecords.TrimToSize()

            Return DirectCast(CType(csvRecords.Item(0), System.Collections.ArrayList).ToArray(GetType(String)), String())

        End Function

#End Region

    End Class

End Namespace
