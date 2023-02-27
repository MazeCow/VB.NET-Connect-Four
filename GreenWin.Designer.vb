<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinPopup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ok_Button = New System.Windows.Forms.PictureBox()
        CType(Me.ok_Button, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ok_Button
        '
        Me.ok_Button.Image = Global.Connect_Four.My.Resources.Resources.ok_button
        Me.ok_Button.Location = New System.Drawing.Point(52, 56)
        Me.ok_Button.Name = "ok_Button"
        Me.ok_Button.Size = New System.Drawing.Size(156, 66)
        Me.ok_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ok_Button.TabIndex = 1
        Me.ok_Button.TabStop = False
        '
        'WinPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Connect_Four.My.Resources.Resources.nobody_wins
        Me.ClientSize = New System.Drawing.Size(263, 140)
        Me.Controls.Add(Me.ok_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WinPopup"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Winner!"
        CType(Me.ok_Button, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ok_Button As PictureBox
End Class
