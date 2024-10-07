<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTblName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClsTbl = New System.Windows.Forms.TextBox()
        Me.txtClsRow = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(161, 257)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(155, 45)
        Me.btnCreate.TabIndex = 0
        Me.btnCreate.Text = "生成"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "テーブル"
        '
        'txtTblName
        '
        Me.txtTblName.Location = New System.Drawing.Point(134, 59)
        Me.txtTblName.Name = "txtTblName"
        Me.txtTblName.Size = New System.Drawing.Size(412, 19)
        Me.txtTblName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "テーブル ｸﾗｽ名"
        '
        'txtClsTbl
        '
        Me.txtClsTbl.Location = New System.Drawing.Point(134, 104)
        Me.txtClsTbl.Name = "txtClsTbl"
        Me.txtClsTbl.Size = New System.Drawing.Size(412, 19)
        Me.txtClsTbl.TabIndex = 3
        Me.txtClsTbl.Text = "MyTable"
        '
        'txtClsRow
        '
        Me.txtClsRow.Location = New System.Drawing.Point(134, 146)
        Me.txtClsRow.Name = "txtClsRow"
        Me.txtClsRow.Size = New System.Drawing.Size(412, 19)
        Me.txtClsRow.TabIndex = 3
        Me.txtClsRow.Text = "MyRow"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Row ｸﾗｽ名"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(134, 187)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(412, 19)
        Me.txtFileName.TabIndex = 3
        Me.txtFileName.Text = "TempRow.txt"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "ファイル名"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 332)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.txtClsRow)
        Me.Controls.Add(Me.txtClsTbl)
        Me.Controls.Add(Me.txtTblName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCreate)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MakeRowClass"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTblName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClsTbl As System.Windows.Forms.TextBox
    Friend WithEvents txtClsRow As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
