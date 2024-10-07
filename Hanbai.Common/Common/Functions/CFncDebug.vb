Namespace Functions

    ''' <summary>
    ''' デバッグ関係のクラス
    ''' </summary>
    ''' <remarks>このクラスはインスタンス化できません。</remarks>
    Public Class CFncDebug

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks>このコンストラクタはこのクラスをインスタンス化をできないようにします。</remarks>
        Private Sub New()
        End Sub

#End Region

#Region "メソッド－時間計測"

        ''' <summary>
        ''' 時間計測開始
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function StartStopWatch() As Stopwatch

            Dim sw As New Stopwatch
            sw.Start()
            Return sw

        End Function

        ''' <summary>
        ''' 時間計測終了
        ''' </summary>
        ''' <param name="sw"></param>
        ''' <param name="strMsg"></param>
        ''' <remarks></remarks>
        Public Shared Sub StopStopWatch(ByVal sw As Stopwatch, Optional ByVal strMsg As String = "")

            sw.Stop()
            Dim millisec As Long = sw.ElapsedMilliseconds
            Debug.WriteLine(strMsg & " " & millisec)

        End Sub

#End Region

    End Class

End Namespace