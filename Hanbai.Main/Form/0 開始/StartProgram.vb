Imports System
Imports System.Runtime.InteropServices
Imports Daikoro.Main.Form

'#If DEBUG Then
'Imports EnvDTE
'Imports EnvDTE80
'#End If

#Region "グローバル"

Module modGlobal

    ''' <summary>
    ''' メイン　フォーム
    ''' </summary>
    ''' <remarks></remarks>
    Public gfrmMain As frmMain

End Module

#End Region

Friend Class StartProgram
    Private Sub New()
    End Sub
    <STAThread()> _
    Shared Sub Main(ByVal arguments As String())


        '#If DEBUG Then
        '        '方法 : "アプリケーションがビジーです。" エラーと "呼び出し先が呼び出しを拒否しました。" エラーを修正する
        '        'http://msdn.microsoft.com/ja-jp/library/ms228772(v=vs.100).aspx
        '        '
        '        Dim dte As EnvDTE80.DTE2
        '        Dim obj As Object = Nothing
        '        Dim t As System.Type = Nothing
        '        'Get the ProgID for DTE 8.0.
        '        t = System.Type.GetTypeFromProgID("VisualStudio.DTE.10.0", True)
        '        'Create a new instance of the IDE.
        '        obj = System.Activator.CreateInstance(t, True)
        '        'Cast the instance to DTE2 and assign to variable dte.
        '        dte = DirectCast(obj, EnvDTE80.DTE2)
        '        'Register the IOleMessageFilter to handle any threading 
        '        'errors.
        '        MessageFilter.Register()
        '        'Display the Visual Studio IDE.
        '        dte.MainWindow.Activate()
        '#End If

        '===== 二重起動をチェックする =====
        If Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
            'すでに起動していると判断して終了
            MessageBox.Show("多重起動はできません。", My.Resources.CAP_APPLICATION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        '====== フォーム　スタイル設定 =====
        'スキンをレジスト
        DevExpress.UserSkins.BonusSkins.Register()
        'スキンをEnableにする。
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged()
        DevExpress.Skins.SkinManager.EnableMdiFormSkins()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        '===== メイン　アプリケーション =====
        Application.Run(New frmMain())

        '#If DEBUG Then
        '        'All done, so shut down the IDE...
        '        dte.Quit()
        '        'and turn off the IOleMessageFilter.
        '        MessageFilter.Revoke()
        '#End If

    End Sub

End Class

#Region "MessageFilter"

#If DEBUG Then

Public Class MessageFilter
    Implements IOleMessageFilter
    '
    ' Class containing the IOleMessageFilter
    ' thread error-handling functions.

    ' Start the filter.
    Public Shared Sub Register()
        Dim newFilter As IOleMessageFilter = New MessageFilter()
        Dim oldFilter As IOleMessageFilter = Nothing
        CoRegisterMessageFilter(newFilter, oldFilter)
    End Sub

    ' Done with the filter, close it.
    Public Shared Sub Revoke()
        Dim oldFilter As IOleMessageFilter = Nothing
        CoRegisterMessageFilter(Nothing, oldFilter)
    End Sub

    '
    ' IOleMessageFilter functions.
    ' Handle incoming thread requests.
    Private Function IOleMessageFilter_HandleInComingCall(dwCallType As Integer, hTaskCaller As System.IntPtr, dwTickCount As Integer, lpInterfaceInfo As System.IntPtr) As Integer Implements IOleMessageFilter.HandleInComingCall
        'Return the flag SERVERCALL_ISHANDLED.
        Return 0
    End Function

    ' Thread call was rejected, so try again.
    Private Function IOleMessageFilter_RetryRejectedCall(hTaskCallee As System.IntPtr, dwTickCount As Integer, dwRejectType As Integer) As Integer Implements IOleMessageFilter.RetryRejectedCall
        If dwRejectType = 2 Then
            ' flag = SERVERCALL_RETRYLATER.
            ' Retry the thread call immediately if return >=0 & 
            ' <100.
            Return 99
        End If
        ' Too busy; cancel call.
        Return -1
    End Function

    Private Function IOleMessageFilter_MessagePending(hTaskCallee As System.IntPtr, dwTickCount As Integer, dwPendingType As Integer) As Integer Implements IOleMessageFilter.MessagePending
        'Return the flag PENDINGMSG_WAITDEFPROCESS.
        Return 2
    End Function

    ' Implement the IOleMessageFilter interface.
    <DllImport("Ole32.dll")> _
    Private Shared Function CoRegisterMessageFilter(newFilter As IOleMessageFilter, ByRef oldFilter As IOleMessageFilter) As Integer
    End Function
End Class

<ComImport(), Guid("00000016-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
Interface IOleMessageFilter
    <PreserveSig()> _
    Function HandleInComingCall(dwCallType As Integer, hTaskCaller As IntPtr, dwTickCount As Integer, lpInterfaceInfo As IntPtr) As Integer

    <PreserveSig()> _
    Function RetryRejectedCall(hTaskCallee As IntPtr, dwTickCount As Integer, dwRejectType As Integer) As Integer

    <PreserveSig()> _
    Function MessagePending(hTaskCallee As IntPtr, dwTickCount As Integer, dwPendingType As Integer) As Integer
End Interface

#End If

#End Region
