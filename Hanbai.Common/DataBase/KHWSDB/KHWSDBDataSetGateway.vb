#Region "参照"

Imports Hanbai.Common.Functions
Imports Hanbai.Common.Classes
Imports Hanbai.Common.DataBase
Imports System.Data.Common

#End Region

Namespace DataBase.MyDB

    ''' <summary>
    ''' DataSetGateway抽象クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class KHWSDBDataSetGateway : Inherits DataSetGateway

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタです。
        ''' </summary>
        ''' <remarks>クラスの新しいインスタンスを初期化します。</remarks>
        Public Sub New(Optional ByVal EnforceConstraints As Boolean = True)
            MyBase.new(CClsSetting.GetInstance.pstrKHWSDBConn, enmProvider.SQLServer, EnforceConstraints)
        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' コミット
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Commit(Optional ByVal blnMsg As Boolean = False) As Boolean
            If Me.DataSet.HasChanges() Then

                '保存しますか？
                If CFncMessage.MessageBox(My.Resources.MSG_COMMIT, My.Resources.CAP_APPLICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                    'データーセットの内容をデーターベースへ書き込みます
                    Try
                        '更新をコミットする
                        Me.Update()
                        '更新確定は成功しました。
                        If blnMsg Then
                            CFncMessage.MessageBox(My.Resources.MSG_COMMIT_OK, My.Resources.CAP_APPLICATION)
                        End If
                    Catch ex As Exception
                        '保存は失敗しました
                        CFncMessage.MessageBox(ex.Message, My.Resources.MSG_COMMIT_FAIL, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End Try
                Else
                    Return False
                End If
            End If

            Return True

        End Function

        ''' <summary>
        ''' ロールバック
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RollBack()
            If Me.DataSet.HasChanges() Then
                '取消しますか？
                If CFncMessage.MessageBox(My.Resources.MSG_ROLLBACK, My.Resources.CAP_APPLICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                    '更新をロールバックする
                    Me.DataSet.RejectChanges()
                    '取消しました
                    CFncMessage.MessageBox(My.Resources.MSG_ROLLBACK_SUCCESS, My.Resources.CAP_APPLICATION, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If


        End Sub
#End Region

    End Class

End Namespace

