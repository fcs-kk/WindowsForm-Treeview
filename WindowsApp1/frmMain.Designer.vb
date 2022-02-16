<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.treeView = New System.Windows.Forms.TreeView()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.lblInputTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'treeView
        '
        Me.treeView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeView.CheckBoxes = True
        Me.treeView.Location = New System.Drawing.Point(12, 149)
        Me.treeView.Name = "treeView"
        Me.treeView.Size = New System.Drawing.Size(482, 321)
        Me.treeView.TabIndex = 0
        '
        'txtInput
        '
        Me.txtInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInput.Location = New System.Drawing.Point(12, 28)
        Me.txtInput.Multiline = True
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(482, 84)
        Me.txtInput.TabIndex = 1
        Me.txtInput.Text = "A,A,A,1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A,A,A,2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A,B,C1,1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A,B,C2,1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A,B,C3,1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A,B,B,1"
        '
        'lblInputTitle
        '
        Me.lblInputTitle.AutoSize = True
        Me.lblInputTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblInputTitle.Name = "lblInputTitle"
        Me.lblInputTitle.Size = New System.Drawing.Size(57, 12)
        Me.lblInputTitle.TabIndex = 2
        Me.lblInputTitle.Text = "入力データ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "出力ツリービュー"
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(372, 118)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(121, 27)
        Me.btnConvert.TabIndex = 4
        Me.btnConvert.Text = "変換"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 482)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblInputTitle)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.treeView)
        Me.Name = "frmMain"
        Me.Text = "ツリービューサンプル"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents treeView As TreeView
    Friend WithEvents txtInput As TextBox
    Friend WithEvents lblInputTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnConvert As Button
End Class
