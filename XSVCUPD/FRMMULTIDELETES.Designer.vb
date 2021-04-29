<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMultiDeletes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMultiDeletes))
        Me.btnDelReturn = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblactivedateD = New System.Windows.Forms.Label()
        Me.txtactivedateD = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.lblMassAmtD = New System.Windows.Forms.Label()
        Me.txtrmramtD = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.txtinvprintsuppressD = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.txtcancelcodeD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label2D = New System.Windows.Forms.Label()
        Me.Label40D = New System.Windows.Forms.Label()
        Me.txteffectdateD = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.txtdescrD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label1D = New System.Windows.Forms.Label()
        Me.txtdelselected = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.txtservitemidD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.lblservitemselD = New System.Windows.Forms.Label()
        Me.DslGrid3 = New Microsoft.Dynamics.SL.Controls.DSLGrid()
        Me.txttotald = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.lbldelsel = New System.Windows.Forms.Label()
        Me.GroupBox6.SuspendLayout()
        CType(Me.DslGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDelReturn
        '
        Me.btnDelReturn.Location = New System.Drawing.Point(434, 311)
        Me.btnDelReturn.Name = "btnDelReturn"
        Me.btnDelReturn.Size = New System.Drawing.Size(100, 23)
        Me.btnDelReturn.TabIndex = 622
        Me.btnDelReturn.Text = "Return"
        Me.btnDelReturn.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblactivedateD)
        Me.GroupBox6.Controls.Add(Me.txtactivedateD)
        Me.GroupBox6.Controls.Add(Me.lblMassAmtD)
        Me.GroupBox6.Controls.Add(Me.txtrmramtD)
        Me.GroupBox6.Controls.Add(Me.txtinvprintsuppressD)
        Me.GroupBox6.Controls.Add(Me.txtcancelcodeD)
        Me.GroupBox6.Controls.Add(Me.Label2D)
        Me.GroupBox6.Controls.Add(Me.Label40D)
        Me.GroupBox6.Controls.Add(Me.txteffectdateD)
        Me.GroupBox6.Controls.Add(Me.txtdescrD)
        Me.GroupBox6.Controls.Add(Me.Label1D)
        Me.GroupBox6.Controls.Add(Me.txtdelselected)
        Me.GroupBox6.Controls.Add(Me.txtservitemidD)
        Me.GroupBox6.Controls.Add(Me.lblservitemselD)
        Me.GroupBox6.Controls.Add(Me.DslGrid3)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 35)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(946, 271)
        Me.GroupBox6.TabIndex = 600
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Press F4 for Grid/Form View       ( ***Note: If you check Suppress Inv Print, the" & _
    "n ALL lines need to be checked as well)"
        '
        'lblactivedateD
        '
        Me.lblactivedateD.AutoSize = True
        Me.lblactivedateD.Location = New System.Drawing.Point(269, 49)
        Me.lblactivedateD.Name = "lblactivedateD"
        Me.lblactivedateD.Size = New System.Drawing.Size(63, 13)
        Me.lblactivedateD.TabIndex = 613
        Me.lblactivedateD.Text = "Active Date"
        '
        'txtactivedateD
        '
        Me.txtactivedateD.Enabled = False
        Me.txtactivedateD.FieldName = """bxmultideletes.activedate""; 200; 3; 4"
        Me.txtactivedateD.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtactivedateD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtactivedateD.Heading = "Active Date"
        Me.txtactivedateD.Level = "3"
        Me.txtactivedateD.Location = New System.Drawing.Point(270, 62)
        Me.txtactivedateD.Name = "txtactivedateD"
        Me.txtactivedateD.Size = New System.Drawing.Size(85, 18)
        Me.txtactivedateD.TabIndex = 614
        '
        'lblMassAmtD
        '
        Me.lblMassAmtD.AutoSize = True
        Me.lblMassAmtD.Location = New System.Drawing.Point(145, 49)
        Me.lblMassAmtD.Name = "lblMassAmtD"
        Me.lblMassAmtD.Size = New System.Drawing.Size(111, 13)
        Me.lblMassAmtD.TabIndex = 611
        Me.lblMassAmtD.Text = "Monthly RMR Amount"
        '
        'txtrmramtD
        '
        Me.txtrmramtD.Blankerr = True
        Me.txtrmramtD.Enabled = False
        Me.txtrmramtD.FieldName = """bxmultideletes.rmramt""; 208; 2; 8"
        Me.txtrmramtD.Heading = "Monthly,RMR Amt"
        Me.txtrmramtD.Level = "3"
        Me.txtrmramtD.Location = New System.Drawing.Point(151, 65)
        Me.txtrmramtD.Min = 0.0R
        Me.txtrmramtD.Name = "txtrmramtD"
        Me.txtrmramtD.Separator = True
        Me.txtrmramtD.Size = New System.Drawing.Size(82, 18)
        Me.txtrmramtD.TabIndex = 612
        Me.txtrmramtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtinvprintsuppressD
        '
        Me.txtinvprintsuppressD.Enabled = False
        Me.txtinvprintsuppressD.FieldName = """bxmultideletes.sinvPrintSuppress""; 216; 1; 2"
        Me.txtinvprintsuppressD.Heading = "Suppress,Inv Print"
        Me.txtinvprintsuppressD.Level = "3"
        Me.txtinvprintsuppressD.Location = New System.Drawing.Point(7, 62)
        Me.txtinvprintsuppressD.Name = "txtinvprintsuppressD"
        Me.txtinvprintsuppressD.Size = New System.Drawing.Size(135, 20)
        Me.txtinvprintsuppressD.TabIndex = 610
        Me.txtinvprintsuppressD.Text = "Suppress Invoice Print"
        Me.txtinvprintsuppressD.UseVisualStyleBackColor = True
        Me.txtinvprintsuppressD.Visible = False
        '
        'txtcancelcodeD
        '
        Me.txtcancelcodeD.Blankerr = True
        Me.txtcancelcodeD.Default = ""
        Me.txtcancelcodeD.FieldName = """bxmultideletes.cancelcode""; 0; 0; 10"
        Me.txtcancelcodeD.Heading = "Cancellation,Code"
        Me.txtcancelcodeD.Level = "3"
        Me.txtcancelcodeD.Location = New System.Drawing.Point(669, 29)
        Me.txtcancelcodeD.Mask = "UUUUUUUUUUUUUUUUUUUUUUUUUUUUUU"
        Me.txtcancelcodeD.Name = "txtcancelcodeD"
        Me.txtcancelcodeD.PV = """smcancellation_all"", "
        Me.txtcancelcodeD.Size = New System.Drawing.Size(64, 19)
        Me.txtcancelcodeD.TabIndex = 609
        Me.txtcancelcodeD.TextLength = 30
        '
        'Label2D
        '
        Me.Label2D.AutoSize = True
        Me.Label2D.Location = New System.Drawing.Point(666, 14)
        Me.Label2D.Name = "Label2D"
        Me.Label2D.Size = New System.Drawing.Size(93, 13)
        Me.Label2D.TabIndex = 608
        Me.Label2D.Text = "Cancellation Code"
        '
        'Label40D
        '
        Me.Label40D.AutoSize = True
        Me.Label40D.Location = New System.Drawing.Point(581, 16)
        Me.Label40D.Name = "Label40D"
        Me.Label40D.Size = New System.Drawing.Size(61, 13)
        Me.Label40D.TabIndex = 606
        Me.Label40D.Text = "Effect Date"
        '
        'txteffectdateD
        '
        Me.txteffectdateD.Blankerr = True
        Me.txteffectdateD.FieldName = """bxmultideletes.effectdate""; 204; 3; 4"
        Me.txteffectdateD.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txteffectdateD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txteffectdateD.Heading = "Effect Date"
        Me.txteffectdateD.Level = "3"
        Me.txteffectdateD.Location = New System.Drawing.Point(582, 29)
        Me.txteffectdateD.Name = "txteffectdateD"
        Me.txteffectdateD.Size = New System.Drawing.Size(85, 18)
        Me.txteffectdateD.TabIndex = 607
        '
        'txtdescrD
        '
        Me.txtdescrD.Default = ""
        Me.txtdescrD.Enabled = False
        Me.txtdescrD.FieldName = """bxmultideletes.descr""; 80; 0; 60"
        Me.txtdescrD.Heading = "Service Item ID"
        Me.txtdescrD.Level = "3"
        Me.txtdescrD.Location = New System.Drawing.Point(214, 27)
        Me.txtdescrD.Mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.txtdescrD.Name = "txtdescrD"
        Me.txtdescrD.Size = New System.Drawing.Size(312, 19)
        Me.txtdescrD.TabIndex = 605
        Me.txtdescrD.TextLength = 60
        '
        'Label1D
        '
        Me.Label1D.AutoSize = True
        Me.Label1D.Location = New System.Drawing.Point(217, 12)
        Me.Label1D.Name = "Label1D"
        Me.Label1D.Size = New System.Drawing.Size(60, 13)
        Me.Label1D.TabIndex = 604
        Me.Label1D.Text = "Description"
        '
        'txtdelselected
        '
        Me.txtdelselected.Default = ""
        Me.txtdelselected.FieldName = """bdelselected""; 0; 1; 2"
        Me.txtdelselected.Heading = "Select"
        Me.txtdelselected.Level = "3"
        Me.txtdelselected.Location = New System.Drawing.Point(9, 25)
        Me.txtdelselected.Name = "txtdelselected"
        Me.txtdelselected.Size = New System.Drawing.Size(68, 22)
        Me.txtdelselected.TabIndex = 601
        Me.txtdelselected.Text = "Selected"
        '
        'txtservitemidD
        '
        Me.txtservitemidD.Default = ""
        Me.txtservitemidD.Enabled = False
        Me.txtservitemidD.FieldName = """bxmultideletes.servitemid""; 20; 0; 30"
        Me.txtservitemidD.Heading = "Service Item ID"
        Me.txtservitemidD.Level = "3"
        Me.txtservitemidD.Location = New System.Drawing.Point(80, 27)
        Me.txtservitemidD.Mask = "UUUUUUUUUUUUUUUUUUUUUUUUUUUUUU"
        Me.txtservitemidD.Name = "txtservitemidD"
        Me.txtservitemidD.Size = New System.Drawing.Size(126, 19)
        Me.txtservitemidD.TabIndex = 603
        Me.txtservitemidD.TextLength = 30
        '
        'lblservitemselD
        '
        Me.lblservitemselD.AutoSize = True
        Me.lblservitemselD.Location = New System.Drawing.Point(82, 12)
        Me.lblservitemselD.Name = "lblservitemselD"
        Me.lblservitemselD.Size = New System.Drawing.Size(80, 13)
        Me.lblservitemselD.TabIndex = 602
        Me.lblservitemselD.Text = "Service Item ID"
        '
        'DslGrid3
        '
        Me.DslGrid3.Location = New System.Drawing.Point(526, 203)
        Me.DslGrid3.Name = "DslGrid3"
        Me.DslGrid3.OcxState = CType(resources.GetObject("DslGrid3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DslGrid3.Size = New System.Drawing.Size(34, 22)
        Me.DslGrid3.TabIndex = 615
        '
        'txttotald
        '
        Me.txttotald.DecimalPlaces = 0
        Me.txttotald.Enabled = False
        Me.txttotald.FieldName = """btotdel.total""; 0; 2; 8"
        Me.txttotald.Location = New System.Drawing.Point(99, 317)
        Me.txttotald.Name = "txttotald"
        Me.txttotald.Size = New System.Drawing.Size(84, 18)
        Me.txttotald.TabIndex = 621
        Me.txttotald.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotald.Trigger = "bdelselected;C;I"
        '
        'lbldelsel
        '
        Me.lbldelsel.AutoSize = True
        Me.lbldelsel.Location = New System.Drawing.Point(4, 319)
        Me.lbldelsel.Name = "lbldelsel"
        Me.lbldelsel.Size = New System.Drawing.Size(76, 13)
        Me.lbldelsel.TabIndex = 620
        Me.lbldelsel.Text = "Total Selected"
        '
        'FrmMultiDeletes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 340)
        Me.Controls.Add(Me.lbldelsel)
        Me.Controls.Add(Me.txttotald)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnDelReturn)
        Me.Name = "FrmMultiDeletes"
        Me.Text = "Delete Service Items"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.DslGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDelReturn As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents DslGrid3 As Microsoft.Dynamics.SL.Controls.DSLGrid
    Friend WithEvents lblservitemselD As System.Windows.Forms.Label
    Friend WithEvents txtservitemidD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Public WithEvents txtdelselected As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents txtdescrD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label1D As System.Windows.Forms.Label
    Friend WithEvents txtcancelcodeD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label2D As System.Windows.Forms.Label
    Friend WithEvents Label40D As System.Windows.Forms.Label
    Public WithEvents txteffectdateD As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents txtinvprintsuppressD As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents lblactivedateD As System.Windows.Forms.Label
    Public WithEvents txtactivedateD As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents lblMassAmtD As System.Windows.Forms.Label
    Friend WithEvents txtrmramtD As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents txttotald As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents lbldelsel As System.Windows.Forms.Label
End Class
