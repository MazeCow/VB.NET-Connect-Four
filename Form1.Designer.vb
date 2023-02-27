<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GameBoardFLP = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblPinkWins = New System.Windows.Forms.Label()
        Me.lblGreenWins = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GameBoardFLP
        '
        Me.GameBoardFLP.BackColor = System.Drawing.Color.Transparent
        Me.GameBoardFLP.Location = New System.Drawing.Point(45, 137)
        Me.GameBoardFLP.Name = "GameBoardFLP"
        Me.GameBoardFLP.Size = New System.Drawing.Size(714, 612)
        Me.GameBoardFLP.TabIndex = 0
        '
        'lblPinkWins
        '
        Me.lblPinkWins.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblPinkWins.Font = New System.Drawing.Font("Helvetica LT Std", 38.0!, System.Drawing.FontStyle.Bold)
        Me.lblPinkWins.ForeColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblPinkWins.Location = New System.Drawing.Point(103, 59)
        Me.lblPinkWins.Name = "lblPinkWins"
        Me.lblPinkWins.Size = New System.Drawing.Size(204, 59)
        Me.lblPinkWins.TabIndex = 2
        Me.lblPinkWins.Text = "0"
        Me.lblPinkWins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGreenWins
        '
        Me.lblGreenWins.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblGreenWins.Font = New System.Drawing.Font("Helvetica LT Std", 38.0!, System.Drawing.FontStyle.Bold)
        Me.lblGreenWins.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblGreenWins.Location = New System.Drawing.Point(504, 59)
        Me.lblGreenWins.Name = "lblGreenWins"
        Me.lblGreenWins.Size = New System.Drawing.Size(209, 59)
        Me.lblGreenWins.TabIndex = 3
        Me.lblGreenWins.Text = "0"
        Me.lblGreenWins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Connect_Four.My.Resources.Resources.Header
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(812, 118)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(810, 768)
        Me.Controls.Add(Me.lblGreenWins)
        Me.Controls.Add(Me.lblPinkWins)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GameBoardFLP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connect Four"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GameBoardFLP As FlowLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblPinkWins As Label
    Friend WithEvents lblGreenWins As Label
End Class
