Imports System.Runtime.InteropServices

Namespace Functions

    Public Class Win32API

        Public Enum MessageBoxCheckFlags
            MB_OK = &H0
            MB_OKCANCEL = &H1
            MB_YESNO = &H4
            MB_ICONHAND = &H10
            MB_ICONQUESTION = &H20
            MB_ICONEXCLAMATION = &H30
            MB_ICONINFORMATION = &H40
        End Enum

        ''' <summary>
        ''' チェックボックス付　メッセージボックス
        ''' </summary>
        ''' <param name="hwnd"></param>
        ''' <param name="pszText"></param>
        ''' <param name="pszTitle"></param>
        ''' <param name="uType"></param>
        ''' <param name="iDefault"></param>
        ''' <param name="pszRegVal"></param>
        ''' <returns></returns>
        ''' <remarks>実行環境にWindows 2000を含まない場合
        ''' http://blog.livedoor.jp/akf0/archives/51447811.html#more
        ''' </remarks>
        Public Declare Function SHMessageBoxCheck Lib "shlwapi.dll" Alias "SHMessageBoxCheckA" (ByVal hwnd As IntPtr,
                                                                                                <MarshalAs(UnmanagedType.LPStr)> ByVal pszText As String,
                                                                                                <MarshalAs(UnmanagedType.LPStr)> ByVal pszTitle As String,
                                                                                                ByVal uType As UInt32,
                                                                                                ByVal iDefault As Integer,
                                                                                               <MarshalAs(UnmanagedType.LPStr)> ByVal pszRegVal As String) As Long

    End Class

End Namespace
