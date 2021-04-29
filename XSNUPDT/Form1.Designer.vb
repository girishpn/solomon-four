'*********************************************************
'
'    Copyright (c) Microsoft. All rights reserved.
'    This code is licensed under the Microsoft Public License.
'    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
'    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
'    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
'    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
'
'*********************************************************
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		m_IsInitializing = true
		InitializeComponent()
		m_IsInitializing = False
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Update1 As Microsoft.Dynamics.SL.Controls.DSLUpdate
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Update1 = New Microsoft.Dynamics.SL.Controls.DSLUpdate()
        Me.SAFHelpProvider = New System.Windows.Forms.HelpProvider()
        Me.GrpGrid = New System.Windows.Forms.GroupBox()
        Me.txtContractid = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DslGrid1 = New Microsoft.Dynamics.SL.Controls.DSLGrid()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.grpInput = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcontractstartdate = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.txtcancelcode = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.lblcancelA = New System.Windows.Forms.Label()
        Me.lbleffectdate = New System.Windows.Forms.Label()
        Me.txteffectdateM = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.btnclear = New System.Windows.Forms.Button()
        CType(Me.Update1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpGrid.SuspendLayout()
        CType(Me.DslGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInput.SuspendLayout()
        Me.SuspendLayout()
        '
        'Update1
        '
        Me.Update1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Update1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Update1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Update1.Image = CType(resources.GetObject("Update1.Image"), System.Drawing.Image)
        Me.Update1.Levels = "Input;L,Contracts;DA"
        Me.Update1.Location = New System.Drawing.Point(575, 12)
        Me.Update1.Name = "Update1"
        Me.Update1.Size = New System.Drawing.Size(25, 25)
        Me.Update1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Update1.TabIndex = 0
        Me.Update1.TabStop = False
        Me.Update1.Visible = False
        '
        'GrpGrid
        '
        Me.GrpGrid.Controls.Add(Me.txtContractid)
        Me.GrpGrid.Controls.Add(Me.Label1)
        Me.GrpGrid.Controls.Add(Me.DslGrid1)
        Me.GrpGrid.Location = New System.Drawing.Point(198, 89)
        Me.GrpGrid.Name = "GrpGrid"
        Me.GrpGrid.Size = New System.Drawing.Size(174, 496)
        Me.GrpGrid.TabIndex = 7
        Me.GrpGrid.TabStop = False
        '
        'txtContractid
        '
        Me.txtContractid.FieldName = """bxsvcgrid.contractid""; 0; 0; 0"
        Me.txtContractid.Heading = "Contractid"
        Me.txtContractid.Level = "1"
        Me.txtContractid.Location = New System.Drawing.Point(17, 43)
        Me.txtContractid.Mask = "UUUUUUUUUU"
        Me.txtContractid.Name = "txtContractid"
        Me.txtContractid.PV = """xsmcontract_Cpnyid"", ""bpes.cpnyid""; 0; 0; 0; 0,"
        Me.txtContractid.Size = New System.Drawing.Size(126, 25)
        Me.txtContractid.TabIndex = 9
        Me.txtContractid.TextLength = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Contractid"
        '
        'DslGrid1
        '
        Me.DslGrid1.Location = New System.Drawing.Point(54, 398)
        Me.DslGrid1.Name = "DslGrid1"
        Me.DslGrid1.OcxState = CType(resources.GetObject("DslGrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DslGrid1.Size = New System.Drawing.Size(76, 21)
        Me.DslGrid1.TabIndex = 10
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(188, 600)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(201, 27)
        Me.btnProcess.TabIndex = 20
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'grpInput
        '
        Me.grpInput.Controls.Add(Me.Label2)
        Me.grpInput.Controls.Add(Me.txtcontractstartdate)
        Me.grpInput.Controls.Add(Me.txtcancelcode)
        Me.grpInput.Controls.Add(Me.lblcancelA)
        Me.grpInput.Controls.Add(Me.lbleffectdate)
        Me.grpInput.Controls.Add(Me.txteffectdateM)
        Me.grpInput.Location = New System.Drawing.Point(130, 5)
        Me.grpInput.Name = "grpInput"
        Me.grpInput.Size = New System.Drawing.Size(366, 43)
        Me.grpInput.TabIndex = 100
        Me.grpInput.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, -2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "System  Date"
        '
        'txtcontractstartdate
        '
        Me.txtcontractstartdate.Blankerr = True
        Me.txtcontractstartdate.Default = "0; ""bpes.today""; 0; 0; 0"
        Me.txtcontractstartdate.FieldName = """bmassup.revdate""; 64; 3; 4"
        Me.txtcontractstartdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtcontractstartdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtcontractstartdate.Location = New System.Drawing.Point(133, 14)
        Me.txtcontractstartdate.Name = "txtcontractstartdate"
        Me.txtcontractstartdate.Size = New System.Drawing.Size(78, 18)
        Me.txtcontractstartdate.TabIndex = 4
        '
        'txtcancelcode
        '
        Me.txtcancelcode.Blankerr = True
        Me.txtcancelcode.FieldName = """bmassup.cancelcode""; 68; 0; 10"
        Me.txtcancelcode.Level = ""
        Me.txtcancelcode.Location = New System.Drawing.Point(240, 14)
        Me.txtcancelcode.Mask = "UUUUUUUUUU"
        Me.txtcancelcode.Name = "txtcancelcode"
        Me.txtcancelcode.PV = """smcancellation_all"", "
        Me.txtcancelcode.Size = New System.Drawing.Size(60, 20)
        Me.txtcancelcode.TabIndex = 6
        Me.txtcancelcode.TextLength = 10
        '
        'lblcancelA
        '
        Me.lblcancelA.AutoSize = True
        Me.lblcancelA.Location = New System.Drawing.Point(237, -1)
        Me.lblcancelA.Name = "lblcancelA"
        Me.lblcancelA.Size = New System.Drawing.Size(93, 13)
        Me.lblcancelA.TabIndex = 5
        Me.lblcancelA.Text = "Cancellation Code"
        '
        'lbleffectdate
        '
        Me.lbleffectdate.AutoSize = True
        Me.lbleffectdate.Location = New System.Drawing.Point(34, 0)
        Me.lbleffectdate.Name = "lbleffectdate"
        Me.lbleffectdate.Size = New System.Drawing.Size(76, 13)
        Me.lbleffectdate.TabIndex = 1
        Me.lbleffectdate.Text = "Effective Date"
        '
        'txteffectdateM
        '
        Me.txteffectdateM.Blankerr = True
        Me.txteffectdateM.FieldName = """bmassup.effectdate""; 60; 3; 4"
        Me.txteffectdateM.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txteffectdateM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txteffectdateM.Location = New System.Drawing.Point(34, 16)
        Me.txteffectdateM.Name = "txteffectdateM"
        Me.txteffectdateM.Size = New System.Drawing.Size(78, 18)
        Me.txteffectdateM.TabIndex = 2
        '
        'btnclear
        '
        Me.btnclear.Location = New System.Drawing.Point(445, 601)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(117, 27)
        Me.btnclear.TabIndex = 101
        Me.btnclear.Text = "Clear Grid Contents"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(612, 643)
        Me.Controls.Add(Me.btnclear)
        Me.Controls.Add(Me.grpInput)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.GrpGrid)
        Me.Controls.Add(Me.Update1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Mass Cancels of Service Contracts V1.1S - No Reversals    (XS.NUP.DT)"
        CType(Me.Update1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpGrid.ResumeLayout(False)
        Me.GrpGrid.PerformLayout()
        CType(Me.DslGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInput.ResumeLayout(False)
        Me.grpInput.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SAFHelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents GrpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents txtContractid As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DslGrid1 As Microsoft.Dynamics.SL.Controls.DSLGrid
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents grpInput As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents txtcontractstartdate As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents txtcancelcode As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents lblcancelA As System.Windows.Forms.Label
    Friend WithEvents lbleffectdate As System.Windows.Forms.Label
    Public WithEvents txteffectdateM As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents btnclear As System.Windows.Forms.Button
#End Region
End Class
