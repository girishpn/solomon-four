<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMultiAdds
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMultiAdds))
        Me.btnAddReturn = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtSystemTypeA = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.LabelST = New System.Windows.Forms.Label()
        Me.grpWarrantyA = New System.Windows.Forms.GroupBox()
        Me.Label38A = New System.Windows.Forms.Label()
        Me.txtdurationAA = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.Label37A = New System.Windows.Forms.Label()
        Me.txtwarrantyenddateA = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.Label36A = New System.Windows.Forms.Label()
        Me.txtwarrantystartdateA = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.txtinvprintsuppressA = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.lblMassAmtA = New System.Windows.Forms.Label()
        Me.txtrmramtA = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label40A = New System.Windows.Forms.Label()
        Me.txteffectdateA = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.txtdescrA = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label1A = New System.Windows.Forms.Label()
        Me.txtservitemidA = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.lblservitemselA = New System.Windows.Forms.Label()
        Me.DslGrid4 = New Microsoft.Dynamics.SL.Controls.DSLGrid()
        Me.GroupBox7.SuspendLayout()
        Me.grpWarrantyA.SuspendLayout()
        CType(Me.DslGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddReturn
        '
        Me.btnAddReturn.Location = New System.Drawing.Point(430, 264)
        Me.btnAddReturn.Name = "btnAddReturn"
        Me.btnAddReturn.Size = New System.Drawing.Size(113, 25)
        Me.btnAddReturn.TabIndex = 520
        Me.btnAddReturn.Text = "Return"
        Me.btnAddReturn.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtSystemTypeA)
        Me.GroupBox7.Controls.Add(Me.LabelST)
        Me.GroupBox7.Controls.Add(Me.grpWarrantyA)
        Me.GroupBox7.Controls.Add(Me.txtinvprintsuppressA)
        Me.GroupBox7.Controls.Add(Me.lblMassAmtA)
        Me.GroupBox7.Controls.Add(Me.txtrmramtA)
        Me.GroupBox7.Controls.Add(Me.Label40A)
        Me.GroupBox7.Controls.Add(Me.txteffectdateA)
        Me.GroupBox7.Controls.Add(Me.txtdescrA)
        Me.GroupBox7.Controls.Add(Me.Label1A)
        Me.GroupBox7.Controls.Add(Me.txtservitemidA)
        Me.GroupBox7.Controls.Add(Me.lblservitemselA)
        Me.GroupBox7.Controls.Add(Me.DslGrid4)
        Me.GroupBox7.Location = New System.Drawing.Point(1, 16)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(1038, 242)
        Me.GroupBox7.TabIndex = 500
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Press F4 for Grid/Form View       ( ***Note: If you check Suppress Inv Print, the" &
    "n ALL lines need to be checked as well)"
        '
        'txtSystemTypeA
        '
        Me.txtSystemTypeA.Blankerr = True
        Me.txtSystemTypeA.FieldName = """bxmultiadds.systemtype""; 262; 0; 30"
        Me.txtSystemTypeA.FormattingEnabled = True
        Me.txtSystemTypeA.Heading = "System,Type"
        Me.txtSystemTypeA.Level = "4"
        Me.txtSystemTypeA.List = resources.GetString("txtSystemTypeA.List")
        Me.txtSystemTypeA.Location = New System.Drawing.Point(675, 31)
        Me.txtSystemTypeA.Name = "txtSystemTypeA"
        Me.txtSystemTypeA.Size = New System.Drawing.Size(119, 21)
        Me.txtSystemTypeA.TabIndex = 510
        '
        'LabelST
        '
        Me.LabelST.AutoSize = True
        Me.LabelST.Location = New System.Drawing.Point(675, 18)
        Me.LabelST.Name = "LabelST"
        Me.LabelST.Size = New System.Drawing.Size(68, 13)
        Me.LabelST.TabIndex = 509
        Me.LabelST.Text = "System Type"
        '
        'grpWarrantyA
        '
        Me.grpWarrantyA.Controls.Add(Me.Label38A)
        Me.grpWarrantyA.Controls.Add(Me.txtdurationAA)
        Me.grpWarrantyA.Controls.Add(Me.Label37A)
        Me.grpWarrantyA.Controls.Add(Me.txtwarrantyenddateA)
        Me.grpWarrantyA.Controls.Add(Me.Label36A)
        Me.grpWarrantyA.Controls.Add(Me.txtwarrantystartdateA)
        Me.grpWarrantyA.Location = New System.Drawing.Point(159, 56)
        Me.grpWarrantyA.Name = "grpWarrantyA"
        Me.grpWarrantyA.Size = New System.Drawing.Size(271, 50)
        Me.grpWarrantyA.TabIndex = 512
        Me.grpWarrantyA.TabStop = False
        Me.grpWarrantyA.Text = "Warranty"
        '
        'Label38A
        '
        Me.Label38A.AutoSize = True
        Me.Label38A.Location = New System.Drawing.Point(81, 9)
        Me.Label38A.Name = "Label38A"
        Me.Label38A.Size = New System.Drawing.Size(47, 13)
        Me.Label38A.TabIndex = 515
        Me.Label38A.Text = "Duration"
        '
        'txtdurationAA
        '
        Me.txtdurationAA.FieldName = """bxmultiadds.duration""; 180; 0; 30"
        Me.txtdurationAA.FormattingEnabled = True
        Me.txtdurationAA.Heading = "Duration"
        Me.txtdurationAA.Level = "4"
        Me.txtdurationAA.List = "0;0 Days,30;30 Days,90;90 Days,180;180 Days,365;365 Days"
        Me.txtdurationAA.Location = New System.Drawing.Point(82, 25)
        Me.txtdurationAA.Name = "txtdurationAA"
        Me.txtdurationAA.Size = New System.Drawing.Size(106, 21)
        Me.txtdurationAA.TabIndex = 516
        '
        'Label37A
        '
        Me.Label37A.AutoSize = True
        Me.Label37A.Location = New System.Drawing.Point(191, 11)
        Me.Label37A.Name = "Label37A"
        Me.Label37A.Size = New System.Drawing.Size(52, 13)
        Me.Label37A.TabIndex = 517
        Me.Label37A.Text = "End Date"
        '
        'txtwarrantyenddateA
        '
        Me.txtwarrantyenddateA.Enabled = False
        Me.txtwarrantyenddateA.FieldName = """bxmultiadds.warrantyenddate""; 244; 3; 4"
        Me.txtwarrantyenddateA.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtwarrantyenddateA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtwarrantyenddateA.Heading = "Warranty,End Date"
        Me.txtwarrantyenddateA.Level = "4"
        Me.txtwarrantyenddateA.Location = New System.Drawing.Point(189, 25)
        Me.txtwarrantyenddateA.Name = "txtwarrantyenddateA"
        Me.txtwarrantyenddateA.Size = New System.Drawing.Size(78, 18)
        Me.txtwarrantyenddateA.TabIndex = 518
        Me.txtwarrantyenddateA.TabStop = False
        '
        'Label36A
        '
        Me.Label36A.AutoSize = True
        Me.Label36A.Location = New System.Drawing.Point(14, 14)
        Me.Label36A.Name = "Label36A"
        Me.Label36A.Size = New System.Drawing.Size(55, 13)
        Me.Label36A.TabIndex = 513
        Me.Label36A.Text = "Start Date"
        '
        'txtwarrantystartdateA
        '
        Me.txtwarrantystartdateA.FieldName = """bxmultiadds.warrantystartdate""; 248; 3; 4"
        Me.txtwarrantystartdateA.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtwarrantystartdateA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtwarrantystartdateA.Heading = "Warranty,Start Date"
        Me.txtwarrantystartdateA.Level = "4"
        Me.txtwarrantystartdateA.Location = New System.Drawing.Point(4, 27)
        Me.txtwarrantystartdateA.Name = "txtwarrantystartdateA"
        Me.txtwarrantystartdateA.Size = New System.Drawing.Size(77, 18)
        Me.txtwarrantystartdateA.TabIndex = 514
        '
        'txtinvprintsuppressA
        '
        Me.txtinvprintsuppressA.Enabled = False
        Me.txtinvprintsuppressA.FieldName = """bxmultiadds.sinvPrintSuppress""; 260; 1; 2"
        Me.txtinvprintsuppressA.Heading = "Suppress,Inv Print"
        Me.txtinvprintsuppressA.Level = "4"
        Me.txtinvprintsuppressA.Location = New System.Drawing.Point(16, 77)
        Me.txtinvprintsuppressA.Name = "txtinvprintsuppressA"
        Me.txtinvprintsuppressA.Size = New System.Drawing.Size(135, 20)
        Me.txtinvprintsuppressA.TabIndex = 511
        Me.txtinvprintsuppressA.Text = "Suppress Invoice Print"
        Me.txtinvprintsuppressA.UseVisualStyleBackColor = True
        Me.txtinvprintsuppressA.Visible = False
        '
        'lblMassAmtA
        '
        Me.lblMassAmtA.AutoSize = True
        Me.lblMassAmtA.Location = New System.Drawing.Point(454, 18)
        Me.lblMassAmtA.Name = "lblMassAmtA"
        Me.lblMassAmtA.Size = New System.Drawing.Size(111, 13)
        Me.lblMassAmtA.TabIndex = 505
        Me.lblMassAmtA.Text = "Monthly RMR Amount"
        '
        'txtrmramtA
        '
        Me.txtrmramtA.Blankerr = True
        Me.txtrmramtA.FieldName = """bxmultiadds.rmramt""; 252; 2; 8"
        Me.txtrmramtA.Heading = "Monthly,RMR Amt"
        Me.txtrmramtA.Level = "4"
        Me.txtrmramtA.Location = New System.Drawing.Point(460, 34)
        Me.txtrmramtA.Min = 0R
        Me.txtrmramtA.Name = "txtrmramtA"
        Me.txtrmramtA.Separator = True
        Me.txtrmramtA.Size = New System.Drawing.Size(74, 18)
        Me.txtrmramtA.TabIndex = 506
        Me.txtrmramtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40A
        '
        Me.Label40A.AutoSize = True
        Me.Label40A.Location = New System.Drawing.Point(573, 17)
        Me.Label40A.Name = "Label40A"
        Me.Label40A.Size = New System.Drawing.Size(61, 13)
        Me.Label40A.TabIndex = 507
        Me.Label40A.Text = "Effect Date"
        '
        'txteffectdateA
        '
        Me.txteffectdateA.Blankerr = True
        Me.txteffectdateA.FieldName = """bxmultiadds.effectdate""; 240; 3; 4"
        Me.txteffectdateA.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txteffectdateA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txteffectdateA.Heading = "Effect,Date"
        Me.txteffectdateA.Level = "4"
        Me.txteffectdateA.Location = New System.Drawing.Point(574, 32)
        Me.txteffectdateA.Name = "txteffectdateA"
        Me.txteffectdateA.Size = New System.Drawing.Size(79, 18)
        Me.txteffectdateA.TabIndex = 508
        '
        'txtdescrA
        '
        Me.txtdescrA.Default = ""
        Me.txtdescrA.Enabled = False
        Me.txtdescrA.FieldName = """bxmultiadds.descr""; 60; 0; 60"
        Me.txtdescrA.Heading = "Service Item ID"
        Me.txtdescrA.Level = "4"
        Me.txtdescrA.Location = New System.Drawing.Point(145, 33)
        Me.txtdescrA.Mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.txtdescrA.Name = "txtdescrA"
        Me.txtdescrA.Size = New System.Drawing.Size(280, 19)
        Me.txtdescrA.TabIndex = 504
        Me.txtdescrA.TextLength = 60
        '
        'Label1A
        '
        Me.Label1A.AutoSize = True
        Me.Label1A.Location = New System.Drawing.Point(148, 18)
        Me.Label1A.Name = "Label1A"
        Me.Label1A.Size = New System.Drawing.Size(60, 13)
        Me.Label1A.TabIndex = 503
        Me.Label1A.Text = "Description"
        '
        'txtservitemidA
        '
        Me.txtservitemidA.Blankerr = True
        Me.txtservitemidA.Default = ""
        Me.txtservitemidA.FieldName = """bxmultiadds.servitemid""; 0; 0; 30"
        Me.txtservitemidA.Heading = "Service Item ID"
        Me.txtservitemidA.Level = "4"
        Me.txtservitemidA.Location = New System.Drawing.Point(11, 33)
        Me.txtservitemidA.Mask = "UUUUUUUUUUUUUUUUUUUUUUUUUUUUUU"
        Me.txtservitemidA.Name = "txtservitemidA"
        Me.txtservitemidA.PV = """xserviceitems_all"","
        Me.txtservitemidA.Size = New System.Drawing.Size(112, 19)
        Me.txtservitemidA.TabIndex = 502
        Me.txtservitemidA.TextLength = 30
        '
        'lblservitemselA
        '
        Me.lblservitemselA.AutoSize = True
        Me.lblservitemselA.Location = New System.Drawing.Point(13, 18)
        Me.lblservitemselA.Name = "lblservitemselA"
        Me.lblservitemselA.Size = New System.Drawing.Size(80, 13)
        Me.lblservitemselA.TabIndex = 501
        Me.lblservitemselA.Text = "Service Item ID"
        '
        'DslGrid4
        '
        Me.DslGrid4.Location = New System.Drawing.Point(545, 196)
        Me.DslGrid4.Name = "DslGrid4"
        Me.DslGrid4.OcxState = CType(resources.GetObject("DslGrid4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DslGrid4.Size = New System.Drawing.Size(64, 29)
        Me.DslGrid4.TabIndex = 519
        '
        'FrmMultiAdds
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 292)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.btnAddReturn)
        Me.Name = "FrmMultiAdds"
        Me.Text = "Add Multiple Service Items"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.grpWarrantyA.ResumeLayout(False)
        Me.grpWarrantyA.PerformLayout()
        CType(Me.DslGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAddReturn As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents DslGrid4 As Microsoft.Dynamics.SL.Controls.DSLGrid
    Friend WithEvents Label40A As System.Windows.Forms.Label
    Public WithEvents txteffectdateA As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents txtdescrA As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label1A As System.Windows.Forms.Label
    Friend WithEvents txtservitemidA As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents lblservitemselA As System.Windows.Forms.Label
    Friend WithEvents lblMassAmtA As System.Windows.Forms.Label
    Friend WithEvents txtrmramtA As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents txtinvprintsuppressA As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents grpWarrantyA As System.Windows.Forms.GroupBox
    Friend WithEvents Label38A As System.Windows.Forms.Label
    Friend WithEvents txtdurationAA As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents Label37A As System.Windows.Forms.Label
    Public WithEvents txtwarrantyenddateA As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents Label36A As System.Windows.Forms.Label
    Public WithEvents txtwarrantystartdateA As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents LabelST As System.Windows.Forms.Label
    Friend WithEvents txtSystemTypeA As Microsoft.Dynamics.SL.Controls.DSLCombo
End Class
