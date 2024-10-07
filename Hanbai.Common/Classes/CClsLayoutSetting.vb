Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraLayout
Imports System.IO
Imports DevExpress.XtraGrid

Namespace Classes

    Public Class CClsLayoutSetting

        ''' <summary>
        ''' レイアウトを削除します
        ''' </summary>
        ''' <param name="strFileName"></param>
        ''' <remarks></remarks>
        Public Shared Sub Delete(ByVal strFileName As String)

            strFileName = MakeLayoutFileName(strFileName)
            If File.Exists(strFileName) Then
                File.Delete(strFileName)
            End If

        End Sub

        ''' <summary>
        ''' GridControl レイアウトを保存します
        ''' </summary>
        ''' <param name="form"></param>
        ''' <param name="grid"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub SaveLayout(ByVal form As System.Windows.Forms.Form, ByVal grid As GridControl)

            Dim strFileName = String.Format("{0}_{1}.XML", form.Name, grid.Name)
            Dim strPath = MakeLayoutFileName(strFileName)
            grid.MainView.SaveLayoutToXml(strPath)

        End Sub

        Public Overloads Shared Sub SaveLayout(ByVal strFileName As String, ByVal grid As GridControl)
            Dim strPath = MakeLayoutFileName(strFileName)
            grid.MainView.SaveLayoutToXml(strPath)
        End Sub

        ''' <summary>
        ''' GridControl レイアウトを復元します
        ''' </summary>
        ''' <param name="form"></param>
        ''' <param name="grid"></param>param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Shared Function RestoreLayout(ByVal form As System.Windows.Forms.Form, ByVal grid As GridControl) As Boolean

            Dim strFileName = String.Format("{0}_{1}.XML", form.Name, grid.Name)
            Dim strPath = MakeLayoutFileName(strFileName)

            Try
                If File.Exists(strPath) Then
                    grid.MainView.RestoreLayoutFromXml(strPath)
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return False
            End Try

        End Function

        Public Overloads Shared Function RestoreLayout(ByVal strFileName As String, ByVal grid As GridControl) As Boolean
            Dim strPath = MakeLayoutFileName(strFileName)

            Try
                If File.Exists(strPath) Then
                    grid.MainView.RestoreLayoutFromXml(strPath)
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' DockManager レイアウトを保存します
        ''' </summary>
        ''' <param name="doc"></param>
        ''' <param name="strFileName"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub SaveLayout(ByVal doc As DockManager, ByVal strFileName As String)

            strFileName = MakeLayoutFileName(strFileName)
            doc.SaveLayoutToXml(strFileName)

        End Sub

        ''' <summary>
        ''' NavBarControl レイアウトを保存します
        ''' </summary>
        ''' <param name="bar"></param>
        ''' <param name="strFileName"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub SaveLayout(ByVal bar As NavBarControl, ByVal strFileName As String)

            strFileName = MakeLayoutFileName(strFileName)
            bar.SaveToXml(strFileName)

        End Sub

        ''' <summary>
        ''' LayoutControl レイアウトを保存します
        ''' </summary>
        ''' <param name="layout"></param>
        ''' <param name="strFileName"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub SaveLayout(ByVal layout As LayoutControl, ByVal strFileName As String)

            strFileName = MakeLayoutFileName(strFileName)
            layout.SaveLayoutToXml(strFileName)

        End Sub

        ''' <summary>
        ''' DockManager レイアウトを復元します
        ''' </summary>
        ''' <param name="doc"></param>
        ''' <param name="strFileName"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub RestoreLayout(ByVal doc As DockManager, ByVal strFileName As String)

            strFileName = MakeLayoutFileName(strFileName)

            If File.Exists(strFileName) Then
                doc.RestoreLayoutFromXml(strFileName)
            End If

        End Sub

        ''' <summary>
        ''' NavBarControl レイアウトを復元します
        ''' </summary>
        ''' <param name="bar"></param>
        ''' <param name="strFileName"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub RestoreLayout(ByVal bar As NavBarControl, ByVal strFileName As String)

            strFileName = MakeLayoutFileName(strFileName)

            If File.Exists(strFileName) Then
                bar.RestoreFromXml(strFileName)
            End If

        End Sub

        ''' <summary>
        ''' LayoutControl レイアウトを復元します
        ''' </summary>
        ''' <param name="layout"></param>
        ''' <param name="strFileName"></param>
        ''' <remarks></remarks>
        Public Overloads Shared Sub RestoreLayout(ByVal layout As LayoutControl, ByVal strFileName As String)

            strFileName = MakeLayoutFileName(strFileName)

            If File.Exists(strFileName) Then
                layout.RestoreLayoutFromXml(strFileName)
            End If

        End Sub

        ''' <summary>
        ''' DockManagerの初期値設定
        ''' </summary>
        ''' <param name="doc"></param>
        ''' <remarks></remarks>
        Public Shared Sub InitDocManager(ByVal doc As DockManager)

            With doc
                .DockMode = DevExpress.XtraBars.Docking.Helpers.DockMode.VS2005
                .DockModeVS2005FadeFramesCount = 5
                .DockModeVS2005FadeSpeed = 30000
                .AutoHideSpeed = 20
            End With

        End Sub

        Public Shared Function MakeLayoutFileName(ByVal strFileName As String) As String

            Dim Setting As CClsAppSetting = CClsAppSetting.GetInstance
            Return Path.Combine(Path.GetDirectoryName(Setting.pstrIniFileName), strFileName)

        End Function

    End Class

End Namespace

