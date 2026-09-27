<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.lblEnterTExt = New System.Windows.Forms.Label()
        Me.lblEncode = New System.Windows.Forms.Label()
        Me.btnCheckEncoding = New System.Windows.Forms.Button()
        Me.txtEncodingScheme = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtInput
        '
        Me.txtInput.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.Location = New System.Drawing.Point(15, 90)
        Me.txtInput.Multiline = True
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(554, 142)
        Me.txtInput.TabIndex = 0
        '
        'lblEnterTExt
        '
        Me.lblEnterTExt.AutoSize = True
        Me.lblEnterTExt.Font = New System.Drawing.Font("Jokerman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnterTExt.Location = New System.Drawing.Point(12, 9)
        Me.lblEnterTExt.Name = "lblEnterTExt"
        Me.lblEnterTExt.Size = New System.Drawing.Size(558, 70)
        Me.lblEnterTExt.TabIndex = 1
        Me.lblEnterTExt.Text = "Enter Your ASCII Text"
        '
        'lblEncode
        '
        Me.lblEncode.AutoSize = True
        Me.lblEncode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncode.Location = New System.Drawing.Point(16, 334)
        Me.lblEncode.Name = "lblEncode"
        Me.lblEncode.Size = New System.Drawing.Size(280, 45)
        Me.lblEncode.TabIndex = 2
        Me.lblEncode.Text = "Encoding Scheme:"
        '
        'btnCheckEncoding
        '
        Me.btnCheckEncoding.Font = New System.Drawing.Font("Comic Sans MS", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckEncoding.Location = New System.Drawing.Point(21, 252)
        Me.btnCheckEncoding.Name = "btnCheckEncoding"
        Me.btnCheckEncoding.Size = New System.Drawing.Size(549, 67)
        Me.btnCheckEncoding.TabIndex = 3
        Me.btnCheckEncoding.Text = "IsUnicodeText?"
        Me.btnCheckEncoding.UseVisualStyleBackColor = True
        '
        'txtEncodingScheme
        '
        Me.txtEncodingScheme.BackColor = System.Drawing.SystemColors.Window
        Me.txtEncodingScheme.Font = New System.Drawing.Font("Cooper Black", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEncodingScheme.Location = New System.Drawing.Point(328, 331)
        Me.txtEncodingScheme.Name = "txtEncodingScheme"
        Me.txtEncodingScheme.Size = New System.Drawing.Size(241, 44)
        Me.txtEncodingScheme.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(583, 389)
        Me.Controls.Add(Me.txtEncodingScheme)
        Me.Controls.Add(Me.btnCheckEncoding)
        Me.Controls.Add(Me.lblEncode)
        Me.Controls.Add(Me.lblEnterTExt)
        Me.Controls.Add(Me.txtInput)
        Me.Name = "Form1"
        Me.Text = "IsUnicodeText?"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtInput As TextBox
    Friend WithEvents lblEnterTExt As Label
    Friend WithEvents lblEncode As Label
    Friend WithEvents btnCheckEncoding As Button
    Friend WithEvents txtEncodingScheme As TextBox
End Class
