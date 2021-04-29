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
        m_IsInitializing = True
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
        Me.txtkeyid = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GrpFilters = New System.Windows.Forms.GroupBox()
        Me.txtrenewaltype = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtparent = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lbldelinfo = New System.Windows.Forms.Label()
        Me.txtmasterid = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GRPMassUp = New System.Windows.Forms.GroupBox()
        Me.txtMonitAmt = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.chkMonitAmt = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.txtMaintAmt = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.chkMaintAmt = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.txtInvoiceRule = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.txtInvcFormat = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.lblsystemtype = New System.Windows.Forms.Label()
        Me.txtSystemType = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.BtnAddDel = New System.Windows.Forms.Button()
        Me.lblMassAmt = New System.Windows.Forms.Label()
        Me.grpChangeServItem = New System.Windows.Forms.GroupBox()
        Me.lblhide = New System.Windows.Forms.Label()
        Me.OptPct = New Microsoft.Dynamics.SL.Controls.DSLOption()
        Me.optEndAmt = New Microsoft.Dynamics.SL.Controls.DSLOption()
        Me.OptPlusMinus = New Microsoft.Dynamics.SL.Controls.DSLOption()
        Me.OptDummy = New Microsoft.Dynamics.SL.Controls.DSLOption()
        Me.grpWarranty = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtdurationA = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtwarrantyenddate = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtwarrantystartdate = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.txtContractProfile = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.txtBillwithContractProfile = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.lblbranchdesc = New System.Windows.Forms.Label()
        Me.txtBranch = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.txtfrequencyM = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.txtcontractstartdate = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.txtcontractEndDate = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.txtcancelcode = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.txtinvprintsuppress = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.txteffectdateM = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.lblcancelA = New System.Windows.Forms.Label()
        Me.lbleffectdate = New System.Windows.Forms.Label()
        Me.txtrmramtM = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.lblcancel = New System.Windows.Forms.Label()
        Me.txtservitemSelM = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.lblservitemsel = New System.Windows.Forms.Label()
        Me.lblempnameM = New System.Windows.Forms.Label()
        Me.lbltype = New System.Windows.Forms.Label()
        Me.lblrefresh = New System.Windows.Forms.Label()
        Me.GrpContEndDate = New System.Windows.Forms.GroupBox()
        Me.txtexpiredateend = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtexpiredatebeg = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtstartdateend = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtstartdatebeg = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.txttbmasterid = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtservitemid = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtbranchid = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcontid = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.contidlbl = New System.Windows.Forms.Label()
        Me.txtsiteid = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcustid = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.txtcontidD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdClearFilters = New System.Windows.Forms.Button()
        Me.btnRefreshGrid = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnselect = New System.Windows.Forms.Button()
        Me.cBegProcessing = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Existing = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtNewMonit = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtNewMaint = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txtCurMonit = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txtCurMaint = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.DslFloat2 = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.DslFloat1 = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.xinvrules = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtbillfrequency = New Microsoft.Dynamics.SL.Controls.DSLCombo()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.DslDate2 = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.DslDate1 = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.DslMaskedText2 = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtcustname = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtselected = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.txttotalamt = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.txtcontractidD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.txtsitezipD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtsitestateD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtsitecityD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtsiteaddr2d = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtsiteaddr1D = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtsiteidD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtsitenameD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DslMasketxtcustidDdText2 = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtbranchidD = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DslGrid1 = New Microsoft.Dynamics.SL.Controls.DSLGrid()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Renewals = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtpctmonitor = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtpctmaint = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtContProfile = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnViewSC = New System.Windows.Forms.Button()
        Me.txtServices = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtDuration = New Microsoft.Dynamics.SL.Controls.DSLInteger()
        Me.txtSelectedRenewals = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.txtInvoicingRuleA = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtFrequency = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtsameservicesa = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtrenewaldate = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtnumcontractsA = New Microsoft.Dynamics.SL.Controls.DSLInteger()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtnameA = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtustidA = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.DslGrid2 = New Microsoft.Dynamics.SL.Controls.DSLGrid()
        Me.Escalations = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.sprdEscalate = New Microsoft.Dynamics.SL.Controls.DSLGrid()
        Me.txtSelectedEscalations = New Microsoft.Dynamics.SL.Controls.DSLCheck()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtpctmonitor_Esc = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtustidA_Esc = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.txtServices_Esc = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.btnViewSC_Esc = New System.Windows.Forms.Button()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtpctmaint_Esc = New Microsoft.Dynamics.SL.Controls.DSLFloat()
        Me.txtsameservicesa_Esc = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txtnameA_Esc = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.txtContProfile_Esc = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtEscalationDate = New Microsoft.Dynamics.SL.Controls.DSLDate()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txtFrequency_Esc = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.txtDuration_Esc = New Microsoft.Dynamics.SL.Controls.DSLInteger()
        Me.txtnumcontractsA_Esc = New Microsoft.Dynamics.SL.Controls.DSLInteger()
        Me.txtInvoicingRuleA_Esc = New Microsoft.Dynamics.SL.Controls.DSLMaskedText()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lblprofile = New System.Windows.Forms.Label()
        Me.txtSel1 = New Microsoft.Dynamics.SL.Controls.DSLInteger()
        Me.lblRefreshWarn = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        CType(Me.Update1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFilters.SuspendLayout()
        Me.GRPMassUp.SuspendLayout()
        Me.grpChangeServItem.SuspendLayout()
        Me.grpWarranty.SuspendLayout()
        Me.GrpContEndDate.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Existing.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DslGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Renewals.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DslGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Escalations.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.sprdEscalate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Update1
        '
        Me.Update1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Update1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Update1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Update1.Image = CType(resources.GetObject("Update1.Image"), System.Drawing.Image)
        Me.Update1.Levels = "Filters;L,Existing;DA,Renewal;DA,MultiDel;DA,MultiAdd;DA,Escalation;DA"
        Me.Update1.Location = New System.Drawing.Point(891, 8)
        Me.Update1.Name = "Update1"
        Me.Update1.Size = New System.Drawing.Size(25, 25)
        Me.Update1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Update1.TabIndex = 0
        Me.Update1.TabStop = False
        Me.Update1.Visible = False
        '
        'txtkeyid
        '
        Me.txtkeyid.Default = ""
        Me.txtkeyid.FieldName = """bkeyid.id""; 0; 1; 2"
        Me.txtkeyid.Level = ""
        Me.txtkeyid.List = resources.GetString("txtkeyid.List")
        Me.txtkeyid.Location = New System.Drawing.Point(49, 9)
        Me.txtkeyid.Name = "txtkeyid"
        Me.txtkeyid.Size = New System.Drawing.Size(275, 21)
        Me.txtkeyid.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Key ID"
        '
        'GrpFilters
        '
        Me.GrpFilters.Controls.Add(Me.txtrenewaltype)
        Me.GrpFilters.Controls.Add(Me.Label47)
        Me.GrpFilters.Controls.Add(Me.txtparent)
        Me.GrpFilters.Controls.Add(Me.Label35)
        Me.GrpFilters.Controls.Add(Me.lbldelinfo)
        Me.GrpFilters.Controls.Add(Me.txtmasterid)
        Me.GrpFilters.Controls.Add(Me.Label34)
        Me.GrpFilters.Controls.Add(Me.GRPMassUp)
        Me.GrpFilters.Controls.Add(Me.lblrefresh)
        Me.GrpFilters.Controls.Add(Me.GrpContEndDate)
        Me.GrpFilters.Controls.Add(Me.GroupBox3)
        Me.GrpFilters.Controls.Add(Me.txttbmasterid)
        Me.GrpFilters.Controls.Add(Me.Label9)
        Me.GrpFilters.Controls.Add(Me.txtservitemid)
        Me.GrpFilters.Controls.Add(Me.Label8)
        Me.GrpFilters.Controls.Add(Me.txtbranchid)
        Me.GrpFilters.Controls.Add(Me.Label5)
        Me.GrpFilters.Controls.Add(Me.txtcontid)
        Me.GrpFilters.Controls.Add(Me.contidlbl)
        Me.GrpFilters.Controls.Add(Me.txtsiteid)
        Me.GrpFilters.Controls.Add(Me.Label1)
        Me.GrpFilters.Controls.Add(Me.txtcustid)
        Me.GrpFilters.Controls.Add(Me.txtcontidD)
        Me.GrpFilters.Controls.Add(Me.Label3)
        Me.GrpFilters.Controls.Add(Me.cmdClearFilters)
        Me.GrpFilters.Location = New System.Drawing.Point(5, 43)
        Me.GrpFilters.Name = "GrpFilters"
        Me.GrpFilters.Size = New System.Drawing.Size(1060, 223)
        Me.GrpFilters.TabIndex = 2
        Me.GrpFilters.TabStop = False
        Me.GrpFilters.Text = "Filters && Options  (press F5 to clear a field)"
        '
        'txtrenewaltype
        '
        Me.txtrenewaltype.Blankerr = True
        Me.txtrenewaltype.Default = ""
        Me.txtrenewaltype.FieldName = """bXSVCfilter.renewaltype""; 0; 0; 0"
        Me.txtrenewaltype.FormattingEnabled = True
        Me.txtrenewaltype.Heading = "Renewal,Type"
        Me.txtrenewaltype.List = "QT;Do No Renew,MY;EverGreen,NO;Not Standard Renewal"
        Me.txtrenewaltype.Location = New System.Drawing.Point(931, 29)
        Me.txtrenewaltype.Name = "txtrenewaltype"
        Me.txtrenewaltype.Size = New System.Drawing.Size(118, 21)
        Me.txtrenewaltype.TabIndex = 19
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(930, 12)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(75, 13)
        Me.Label47.TabIndex = 305
        Me.Label47.Text = "Renewal Type"
        '
        'txtparent
        '
        Me.txtparent.Default = ""
        Me.txtparent.FieldName = """bXSVCfilter.Parentid""; 0; 0; 0"
        Me.txtparent.Location = New System.Drawing.Point(265, 77)
        Me.txtparent.Mask = "UUUUUUUUUU"
        Me.txtparent.Name = "txtparent"
        Me.txtparent.PV = "xparent_all"
        Me.txtparent.Size = New System.Drawing.Size(87, 19)
        Me.txtparent.TabIndex = 24
        Me.txtparent.TextLength = 10
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(265, 62)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 13)
        Me.Label35.TabIndex = 23
        Me.Label35.Text = "Parent ID"
        '
        'lbldelinfo
        '
        Me.lbldelinfo.AutoSize = True
        Me.lbldelinfo.ForeColor = System.Drawing.Color.Red
        Me.lbldelinfo.Location = New System.Drawing.Point(292, 203)
        Me.lbldelinfo.Name = "lbldelinfo"
        Me.lbldelinfo.Size = New System.Drawing.Size(387, 13)
        Me.lbldelinfo.TabIndex = 304
        Me.lbldelinfo.Text = "(Grid only displays contracts that contain the Active Mass Update Service Item)"
        '
        'txtmasterid
        '
        Me.txtmasterid.Default = ""
        Me.txtmasterid.FieldName = """bXSVCfilter.masterid""; 0; 0; 0"
        Me.txtmasterid.Location = New System.Drawing.Point(133, 77)
        Me.txtmasterid.Mask = "UUUUUUUUUU"
        Me.txtmasterid.Name = "txtmasterid"
        Me.txtmasterid.PV = """smConMaster_CpnyID"", ""bpes.cpnyid""; 0; 0; 0; 0,"
        Me.txtmasterid.Size = New System.Drawing.Size(96, 19)
        Me.txtmasterid.TabIndex = 22
        Me.txtmasterid.TextLength = 10
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(10, 61)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(82, 13)
        Me.Label34.TabIndex = 306
        Me.Label34.Text = "Contract Profile"
        '
        'GRPMassUp
        '
        Me.GRPMassUp.Controls.Add(Me.txtMonitAmt)
        Me.GRPMassUp.Controls.Add(Me.chkMonitAmt)
        Me.GRPMassUp.Controls.Add(Me.txtMaintAmt)
        Me.GRPMassUp.Controls.Add(Me.chkMaintAmt)
        Me.GRPMassUp.Controls.Add(Me.txtInvoiceRule)
        Me.GRPMassUp.Controls.Add(Me.txtInvcFormat)
        Me.GRPMassUp.Controls.Add(Me.lblsystemtype)
        Me.GRPMassUp.Controls.Add(Me.txtSystemType)
        Me.GRPMassUp.Controls.Add(Me.BtnAddDel)
        Me.GRPMassUp.Controls.Add(Me.lblMassAmt)
        Me.GRPMassUp.Controls.Add(Me.grpChangeServItem)
        Me.GRPMassUp.Controls.Add(Me.grpWarranty)
        Me.GRPMassUp.Controls.Add(Me.txtContractProfile)
        Me.GRPMassUp.Controls.Add(Me.txtBillwithContractProfile)
        Me.GRPMassUp.Controls.Add(Me.lblbranchdesc)
        Me.GRPMassUp.Controls.Add(Me.txtBranch)
        Me.GRPMassUp.Controls.Add(Me.txtfrequencyM)
        Me.GRPMassUp.Controls.Add(Me.txtcontractstartdate)
        Me.GRPMassUp.Controls.Add(Me.lblChange)
        Me.GRPMassUp.Controls.Add(Me.txtcontractEndDate)
        Me.GRPMassUp.Controls.Add(Me.txtcancelcode)
        Me.GRPMassUp.Controls.Add(Me.txtinvprintsuppress)
        Me.GRPMassUp.Controls.Add(Me.txteffectdateM)
        Me.GRPMassUp.Controls.Add(Me.lblcancelA)
        Me.GRPMassUp.Controls.Add(Me.lbleffectdate)
        Me.GRPMassUp.Controls.Add(Me.txtrmramtM)
        Me.GRPMassUp.Controls.Add(Me.lblcancel)
        Me.GRPMassUp.Controls.Add(Me.txtservitemSelM)
        Me.GRPMassUp.Controls.Add(Me.lblservitemsel)
        Me.GRPMassUp.Controls.Add(Me.lblempnameM)
        Me.GRPMassUp.Controls.Add(Me.lbltype)
        Me.GRPMassUp.Location = New System.Drawing.Point(3, 105)
        Me.GRPMassUp.Name = "GRPMassUp"
        Me.GRPMassUp.Size = New System.Drawing.Size(1025, 97)
        Me.GRPMassUp.TabIndex = 104
        Me.GRPMassUp.TabStop = False
        Me.GRPMassUp.Text = "Mass Update"
        '
        'txtMonitAmt
        '
        Me.txtMonitAmt.FieldName = """bmassup.MonitAmt""; 396; 2; 8"
        Me.txtMonitAmt.Level = "1"
        Me.txtMonitAmt.Location = New System.Drawing.Point(683, 22)
        Me.txtMonitAmt.Name = "txtMonitAmt"
        Me.txtMonitAmt.Separator = True
        Me.txtMonitAmt.Size = New System.Drawing.Size(82, 18)
        Me.txtMonitAmt.TabIndex = 140
        Me.txtMonitAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkMonitAmt
        '
        Me.chkMonitAmt.FieldName = """bmassup.MonitChange""; 384; 1; 2"
        Me.chkMonitAmt.Location = New System.Drawing.Point(600, 20)
        Me.chkMonitAmt.Name = "chkMonitAmt"
        Me.chkMonitAmt.Size = New System.Drawing.Size(77, 24)
        Me.chkMonitAmt.TabIndex = 139
        Me.chkMonitAmt.Text = "Monitoring"
        Me.chkMonitAmt.UseVisualStyleBackColor = True
        '
        'txtMaintAmt
        '
        Me.txtMaintAmt.FieldName = """bmassup.MaintAmt""; 388; 2; 8"
        Me.txtMaintAmt.Level = "1"
        Me.txtMaintAmt.Location = New System.Drawing.Point(504, 22)
        Me.txtMaintAmt.Name = "txtMaintAmt"
        Me.txtMaintAmt.Separator = True
        Me.txtMaintAmt.Size = New System.Drawing.Size(82, 18)
        Me.txtMaintAmt.TabIndex = 138
        Me.txtMaintAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkMaintAmt
        '
        Me.chkMaintAmt.FieldName = """bmassup.MaintChange""; 380; 1; 2"
        Me.chkMaintAmt.Location = New System.Drawing.Point(413, 20)
        Me.chkMaintAmt.Name = "chkMaintAmt"
        Me.chkMaintAmt.Size = New System.Drawing.Size(91, 24)
        Me.chkMaintAmt.TabIndex = 137
        Me.chkMaintAmt.Text = "Maintenance"
        Me.chkMaintAmt.UseVisualStyleBackColor = True
        '
        'txtInvoiceRule
        '
        Me.txtInvoiceRule.FieldName = """bmassup.InvoicingRule""; 322; 0; 30"
        Me.txtInvoiceRule.FormattingEnabled = True
        Me.txtInvoiceRule.List = "ARREARS;ARREARS,ADVANCE;ADVANCE"
        Me.txtInvoiceRule.Location = New System.Drawing.Point(11, 64)
        Me.txtInvoiceRule.Name = "txtInvoiceRule"
        Me.txtInvoiceRule.Size = New System.Drawing.Size(192, 21)
        Me.txtInvoiceRule.TabIndex = 136
        '
        'txtInvcFormat
        '
        Me.txtInvcFormat.FieldName = """bmassup.InvoiceFormatID""; 302; 0; 10"
        Me.txtInvcFormat.FormattingEnabled = True
        Me.txtInvcFormat.List = "MS-SB;Multi Site Single Invoice,SS-SB;Single Site Single Invoice"
        Me.txtInvcFormat.Location = New System.Drawing.Point(10, 62)
        Me.txtInvcFormat.Name = "txtInvcFormat"
        Me.txtInvcFormat.Size = New System.Drawing.Size(192, 21)
        Me.txtInvcFormat.TabIndex = 135
        '
        'lblsystemtype
        '
        Me.lblsystemtype.AutoSize = True
        Me.lblsystemtype.Location = New System.Drawing.Point(399, 49)
        Me.lblsystemtype.Name = "lblsystemtype"
        Me.lblsystemtype.Size = New System.Drawing.Size(0, 13)
        Me.lblsystemtype.TabIndex = 134
        '
        'txtSystemType
        '
        Me.txtSystemType.Blankerr = True
        Me.txtSystemType.FieldName = """bmassup.SystemType""; 238; 0; 30"
        Me.txtSystemType.FormattingEnabled = True
        Me.txtSystemType.List = "Access;Access,AES Radio;AES Radio,Audio;Audio,BAS;BAS,EAS System;EAS System,Embedded;Embedded,Fire;Fire,Integrated;Integrat" &
    "ed,Intrusion;Intrusion,Nurse Call;Nurse Call,DSSI;DSSI,Physical;Physical,VAT;VAT" &
    ",Vault;Vault,Video;Video,Other;Other"
        Me.txtSystemType.Location = New System.Drawing.Point(401, 62)
        Me.txtSystemType.Name = "txtSystemType"
        Me.txtSystemType.Size = New System.Drawing.Size(158, 21)
        Me.txtSystemType.TabIndex = 111
        '
        'BtnAddDel
        '
        Me.BtnAddDel.Location = New System.Drawing.Point(5, 22)
        Me.BtnAddDel.Name = "BtnAddDel"
        Me.BtnAddDel.Size = New System.Drawing.Size(182, 21)
        Me.BtnAddDel.TabIndex = 133
        Me.BtnAddDel.UseVisualStyleBackColor = True
        '
        'lblMassAmt
        '
        Me.lblMassAmt.AutoSize = True
        Me.lblMassAmt.Location = New System.Drawing.Point(181, 47)
        Me.lblMassAmt.Name = "lblMassAmt"
        Me.lblMassAmt.Size = New System.Drawing.Size(110, 13)
        Me.lblMassAmt.TabIndex = 107
        Me.lblMassAmt.Text = "Monthly RMR Amount"
        '
        'grpChangeServItem
        '
        Me.grpChangeServItem.Controls.Add(Me.lblhide)
        Me.grpChangeServItem.Controls.Add(Me.OptPct)
        Me.grpChangeServItem.Controls.Add(Me.optEndAmt)
        Me.grpChangeServItem.Controls.Add(Me.OptPlusMinus)
        Me.grpChangeServItem.Controls.Add(Me.OptDummy)
        Me.grpChangeServItem.Location = New System.Drawing.Point(172, 7)
        Me.grpChangeServItem.Name = "grpChangeServItem"
        Me.grpChangeServItem.Size = New System.Drawing.Size(204, 38)
        Me.grpChangeServItem.TabIndex = 131
        Me.grpChangeServItem.TabStop = False
        Me.grpChangeServItem.Text = "Change RMR Amt Option"
        '
        'lblhide
        '
        Me.lblhide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblhide.Location = New System.Drawing.Point(-4, 1)
        Me.lblhide.Name = "lblhide"
        Me.lblhide.Size = New System.Drawing.Size(214, 42)
        Me.lblhide.TabIndex = 132
        '
        'OptPct
        '
        Me.OptPct.FieldName = """bmassup.ChangeServItemOpt""; 298; 1; 2"
        Me.OptPct.Location = New System.Drawing.Point(136, 14)
        Me.OptPct.Name = "OptPct"
        Me.OptPct.Size = New System.Drawing.Size(64, 16)
        Me.OptPct.TabIndex = 135
        Me.OptPct.Text = "Pct +/-"
        Me.OptPct.TrueText = "3"
        Me.OptPct.UseVisualStyleBackColor = True
        '
        'optEndAmt
        '
        Me.optEndAmt.FieldName = """bmassup.ChangeServItemOpt""; 298; 1; 2"
        Me.optEndAmt.Location = New System.Drawing.Point(73, 14)
        Me.optEndAmt.Name = "optEndAmt"
        Me.optEndAmt.Size = New System.Drawing.Size(73, 16)
        Me.optEndAmt.TabIndex = 134
        Me.optEndAmt.Text = "End Amt "
        Me.optEndAmt.TrueText = "2"
        Me.optEndAmt.UseVisualStyleBackColor = True
        '
        'OptPlusMinus
        '
        Me.OptPlusMinus.FieldName = """bmassup.ChangeServItemOpt""; 298; 1; 2"
        Me.OptPlusMinus.Location = New System.Drawing.Point(9, 14)
        Me.OptPlusMinus.Name = "OptPlusMinus"
        Me.OptPlusMinus.Size = New System.Drawing.Size(112, 18)
        Me.OptPlusMinus.TabIndex = 133
        Me.OptPlusMinus.Text = "Adj +/- "
        Me.OptPlusMinus.UseVisualStyleBackColor = True
        '
        'OptDummy
        '
        Me.OptDummy.FieldName = """bmassup.ChangeServItemOpt""; 238; 1; 2"
        Me.OptDummy.Location = New System.Drawing.Point(304, 16)
        Me.OptDummy.Name = "OptDummy"
        Me.OptDummy.Size = New System.Drawing.Size(12, 15)
        Me.OptDummy.TabIndex = 132
        Me.OptDummy.TrueText = "0"
        Me.OptDummy.UseVisualStyleBackColor = True
        '
        'grpWarranty
        '
        Me.grpWarranty.Controls.Add(Me.Label38)
        Me.grpWarranty.Controls.Add(Me.txtdurationA)
        Me.grpWarranty.Controls.Add(Me.Label37)
        Me.grpWarranty.Controls.Add(Me.txtwarrantyenddate)
        Me.grpWarranty.Controls.Add(Me.Label36)
        Me.grpWarranty.Controls.Add(Me.txtwarrantystartdate)
        Me.grpWarranty.Location = New System.Drawing.Point(727, 30)
        Me.grpWarranty.Name = "grpWarranty"
        Me.grpWarranty.Size = New System.Drawing.Size(297, 50)
        Me.grpWarranty.TabIndex = 115
        Me.grpWarranty.TabStop = False
        Me.grpWarranty.Text = "Warranty"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(98, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(48, 13)
        Me.Label38.TabIndex = 118
        Me.Label38.Text = "Duration"
        '
        'txtdurationA
        '
        Me.txtdurationA.FieldName = """bmassup.duration""; 104; 0; 30"
        Me.txtdurationA.FormattingEnabled = True
        Me.txtdurationA.List = "0;0 Days,30;30 Days,90;90 Days,180;180 Days,365;365 Days"
        Me.txtdurationA.Location = New System.Drawing.Point(99, 25)
        Me.txtdurationA.Name = "txtdurationA"
        Me.txtdurationA.Size = New System.Drawing.Size(106, 21)
        Me.txtdurationA.TabIndex = 119
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(218, 12)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(51, 13)
        Me.Label37.TabIndex = 120
        Me.Label37.Text = "End Date"
        '
        'txtwarrantyenddate
        '
        Me.txtwarrantyenddate.FieldName = """bmassup.warrantyenddate""; 100; 3; 4"
        Me.txtwarrantyenddate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtwarrantyenddate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtwarrantyenddate.Location = New System.Drawing.Point(216, 26)
        Me.txtwarrantyenddate.Name = "txtwarrantyenddate"
        Me.txtwarrantyenddate.Size = New System.Drawing.Size(78, 18)
        Me.txtwarrantyenddate.TabIndex = 121
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(17, 13)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(57, 13)
        Me.Label36.TabIndex = 116
        Me.Label36.Text = "Start Date"
        '
        'txtwarrantystartdate
        '
        Me.txtwarrantystartdate.FieldName = """bmassup.WarrantyStartDate"";96; 3; 4"
        Me.txtwarrantystartdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtwarrantystartdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtwarrantystartdate.Location = New System.Drawing.Point(7, 26)
        Me.txtwarrantystartdate.Name = "txtwarrantystartdate"
        Me.txtwarrantystartdate.Size = New System.Drawing.Size(85, 18)
        Me.txtwarrantystartdate.TabIndex = 117
        '
        'txtContractProfile
        '
        Me.txtContractProfile.FieldName = """bmassup.ContractProfile""; 218; 0; 10"
        Me.txtContractProfile.Location = New System.Drawing.Point(9, 61)
        Me.txtContractProfile.Mask = "UUUUUUUUUU"
        Me.txtContractProfile.Name = "txtContractProfile"
        Me.txtContractProfile.PV = """XCUSCONMASTER_PV"", ""bXSVCfilter.custid""; 0; 0; 0; 0, "
        Me.txtContractProfile.Size = New System.Drawing.Size(110, 23)
        Me.txtContractProfile.TabIndex = 129
        Me.txtContractProfile.TextLength = 10
        '
        'txtBillwithContractProfile
        '
        Me.txtBillwithContractProfile.FieldName = """bmassup.BillwithContractProfile""; 198; 0; 10"
        Me.txtBillwithContractProfile.Location = New System.Drawing.Point(11, 62)
        Me.txtBillwithContractProfile.Mask = "UUUUUUUUUU"
        Me.txtBillwithContractProfile.Name = "txtBillwithContractProfile"
        Me.txtBillwithContractProfile.PV = """XCUSCONMASTER_PV"", ""bXSVCfilter.custid""; 0; 0; 0; 0, "
        Me.txtBillwithContractProfile.Size = New System.Drawing.Size(110, 23)
        Me.txtBillwithContractProfile.TabIndex = 128
        Me.txtBillwithContractProfile.TextLength = 10
        '
        'lblbranchdesc
        '
        Me.lblbranchdesc.AutoSize = True
        Me.lblbranchdesc.Location = New System.Drawing.Point(135, 65)
        Me.lblbranchdesc.Name = "lblbranchdesc"
        Me.lblbranchdesc.Size = New System.Drawing.Size(0, 13)
        Me.lblbranchdesc.TabIndex = 127
        '
        'txtBranch
        '
        Me.txtBranch.FieldName = """bmassup.branch""; 178; 0; 10"
        Me.txtBranch.Location = New System.Drawing.Point(11, 64)
        Me.txtBranch.Mask = "UUUUUUUUUU"
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.PV = """smbranch_all"","
        Me.txtBranch.Size = New System.Drawing.Size(110, 23)
        Me.txtBranch.TabIndex = 126
        Me.txtBranch.TextLength = 10
        '
        'txtfrequencyM
        '
        Me.txtfrequencyM.FieldName = """bmassup.frequency""; 176; 0; 1"
        Me.txtfrequencyM.FormattingEnabled = True
        Me.txtfrequencyM.List = "M;Monthly,Q;Quarterly,A;Annual,S;Semi-Annual"
        Me.txtfrequencyM.Location = New System.Drawing.Point(10, 62)
        Me.txtfrequencyM.Name = "txtfrequencyM"
        Me.txtfrequencyM.Size = New System.Drawing.Size(192, 21)
        Me.txtfrequencyM.TabIndex = 130
        '
        'txtcontractstartdate
        '
        Me.txtcontractstartdate.Blankerr = True
        Me.txtcontractstartdate.FieldName = """bmassup.contractstartDate""; 164; 3; 4"
        Me.txtcontractstartdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtcontractstartdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtcontractstartdate.Location = New System.Drawing.Point(11, 64)
        Me.txtcontractstartdate.Name = "txtcontractstartdate"
        Me.txtcontractstartdate.Size = New System.Drawing.Size(78, 18)
        Me.txtcontractstartdate.TabIndex = 126
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Location = New System.Drawing.Point(12, 49)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(0, 13)
        Me.lblChange.TabIndex = 125
        '
        'txtcontractEndDate
        '
        Me.txtcontractEndDate.Blankerr = True
        Me.txtcontractEndDate.FieldName = """bmassup.contractendDate""; 168; 3; 4"
        Me.txtcontractEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtcontractEndDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtcontractEndDate.Location = New System.Drawing.Point(11, 64)
        Me.txtcontractEndDate.Name = "txtcontractEndDate"
        Me.txtcontractEndDate.Size = New System.Drawing.Size(78, 18)
        Me.txtcontractEndDate.TabIndex = 127
        '
        'txtcancelcode
        '
        Me.txtcancelcode.Blankerr = True
        Me.txtcancelcode.FieldName = """bmassup.cancelcode""; 76; 0; 10"
        Me.txtcancelcode.Location = New System.Drawing.Point(404, 62)
        Me.txtcancelcode.Mask = "UUUUUUUUUU"
        Me.txtcancelcode.Name = "txtcancelcode"
        Me.txtcancelcode.PV = """smcancellation_all"", "
        Me.txtcancelcode.Size = New System.Drawing.Size(60, 20)
        Me.txtcancelcode.TabIndex = 123
        Me.txtcancelcode.TextLength = 10
        '
        'txtinvprintsuppress
        '
        Me.txtinvprintsuppress.Enabled = False
        Me.txtinvprintsuppress.FieldName = """bmassup.invprintsuppress""; 172; 1; 2"
        Me.txtinvprintsuppress.Location = New System.Drawing.Point(600, 61)
        Me.txtinvprintsuppress.Name = "txtinvprintsuppress"
        Me.txtinvprintsuppress.Size = New System.Drawing.Size(135, 20)
        Me.txtinvprintsuppress.TabIndex = 124
        Me.txtinvprintsuppress.Text = "Suppress Invoice Print"
        Me.txtinvprintsuppress.UseVisualStyleBackColor = True
        '
        'txteffectdateM
        '
        Me.txteffectdateM.Blankerr = True
        Me.txteffectdateM.FieldName = """bmassup.effectdate""; 72; 3; 4"
        Me.txteffectdateM.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txteffectdateM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txteffectdateM.Location = New System.Drawing.Point(305, 63)
        Me.txteffectdateM.Name = "txteffectdateM"
        Me.txteffectdateM.Size = New System.Drawing.Size(78, 18)
        Me.txteffectdateM.TabIndex = 110
        '
        'lblcancelA
        '
        Me.lblcancelA.AutoSize = True
        Me.lblcancelA.Location = New System.Drawing.Point(401, 48)
        Me.lblcancelA.Name = "lblcancelA"
        Me.lblcancelA.Size = New System.Drawing.Size(93, 13)
        Me.lblcancelA.TabIndex = 122
        Me.lblcancelA.Text = "Cancellation Code"
        '
        'lbleffectdate
        '
        Me.lbleffectdate.AutoSize = True
        Me.lbleffectdate.Location = New System.Drawing.Point(304, 47)
        Me.lbleffectdate.Name = "lbleffectdate"
        Me.lbleffectdate.Size = New System.Drawing.Size(76, 13)
        Me.lbleffectdate.TabIndex = 109
        Me.lbleffectdate.Text = "Effective Date"
        '
        'txtrmramtM
        '
        Me.txtrmramtM.Blankerr = True
        Me.txtrmramtM.FieldName = """bmassup.rmramt""; 60; 2; 8"
        Me.txtrmramtM.Heading = "Amount"
        Me.txtrmramtM.Level = "1"
        Me.txtrmramtM.Location = New System.Drawing.Point(187, 63)
        Me.txtrmramtM.Min = 0R
        Me.txtrmramtM.Name = "txtrmramtM"
        Me.txtrmramtM.Separator = True
        Me.txtrmramtM.Size = New System.Drawing.Size(82, 18)
        Me.txtrmramtM.TabIndex = 108
        Me.txtrmramtM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblcancel
        '
        Me.lblcancel.AutoSize = True
        Me.lblcancel.Location = New System.Drawing.Point(468, 64)
        Me.lblcancel.Name = "lblcancel"
        Me.lblcancel.Size = New System.Drawing.Size(0, 13)
        Me.lblcancel.TabIndex = 124
        '
        'txtservitemSelM
        '
        Me.txtservitemSelM.Blankerr = True
        Me.txtservitemSelM.Default = ""
        Me.txtservitemSelM.FieldName = """bmassup.servitemsel""; 0; 0; 30"
        Me.txtservitemSelM.Location = New System.Drawing.Point(10, 63)
        Me.txtservitemSelM.Mask = "UUUUUUUUUUUUUUUUUUUUUUUUUUUUUU"
        Me.txtservitemSelM.Name = "txtservitemSelM"
        Me.txtservitemSelM.PV = """xserviceitems_all"","
        Me.txtservitemSelM.Size = New System.Drawing.Size(159, 19)
        Me.txtservitemSelM.TabIndex = 106
        Me.txtservitemSelM.TextLength = 30
        '
        'lblservitemsel
        '
        Me.lblservitemsel.AutoSize = True
        Me.lblservitemsel.Location = New System.Drawing.Point(18, 48)
        Me.lblservitemsel.Name = "lblservitemsel"
        Me.lblservitemsel.Size = New System.Drawing.Size(81, 13)
        Me.lblservitemsel.TabIndex = 105
        Me.lblservitemsel.Text = "Service Item ID"
        '
        'lblempnameM
        '
        Me.lblempnameM.AutoSize = True
        Me.lblempnameM.Location = New System.Drawing.Point(7, 91)
        Me.lblempnameM.Name = "lblempnameM"
        Me.lblempnameM.Size = New System.Drawing.Size(0, 13)
        Me.lblempnameM.TabIndex = 64
        '
        'lbltype
        '
        Me.lbltype.AutoSize = True
        Me.lbltype.Location = New System.Drawing.Point(214, 67)
        Me.lbltype.Name = "lbltype"
        Me.lbltype.Size = New System.Drawing.Size(0, 13)
        Me.lbltype.TabIndex = 0
        '
        'lblrefresh
        '
        Me.lblrefresh.BackColor = System.Drawing.SystemColors.Control
        Me.lblrefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrefresh.ForeColor = System.Drawing.Color.Red
        Me.lblrefresh.Location = New System.Drawing.Point(691, 79)
        Me.lblrefresh.Name = "lblrefresh"
        Me.lblrefresh.Size = New System.Drawing.Size(155, 17)
        Me.lblrefresh.TabIndex = 27
        '
        'GrpContEndDate
        '
        Me.GrpContEndDate.Controls.Add(Me.txtexpiredateend)
        Me.GrpContEndDate.Controls.Add(Me.Label7)
        Me.GrpContEndDate.Controls.Add(Me.Label22)
        Me.GrpContEndDate.Controls.Add(Me.txtexpiredatebeg)
        Me.GrpContEndDate.Location = New System.Drawing.Point(696, 18)
        Me.GrpContEndDate.Name = "GrpContEndDate"
        Me.GrpContEndDate.Size = New System.Drawing.Size(228, 38)
        Me.GrpContEndDate.TabIndex = 102
        Me.GrpContEndDate.TabStop = False
        Me.GrpContEndDate.Text = "Contract End Date"
        '
        'txtexpiredateend
        '
        Me.txtexpiredateend.FieldName = """bXSVCfilter.expiredateend""; 0; 0; 0"
        Me.txtexpiredateend.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtexpiredateend.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtexpiredateend.Location = New System.Drawing.Point(143, 14)
        Me.txtexpiredateend.Name = "txtexpiredateend"
        Me.txtexpiredateend.Size = New System.Drawing.Size(78, 18)
        Me.txtexpiredateend.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(125, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "To"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(8, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "From"
        '
        'txtexpiredatebeg
        '
        Me.txtexpiredatebeg.FieldName = """bXSVCfilter.expiredatebeg""; 0; 0; 0"
        Me.txtexpiredatebeg.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtexpiredatebeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtexpiredatebeg.Location = New System.Drawing.Point(42, 15)
        Me.txtexpiredatebeg.Name = "txtexpiredatebeg"
        Me.txtexpiredatebeg.Size = New System.Drawing.Size(78, 18)
        Me.txtexpiredatebeg.TabIndex = 17
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.txtstartdateend)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtstartdatebeg)
        Me.GroupBox3.Location = New System.Drawing.Point(507, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(186, 38)
        Me.GroupBox3.TabIndex = 101
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Contract Start Date"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(83, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(19, 13)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "To"
        '
        'txtstartdateend
        '
        Me.txtstartdateend.FieldName = """bXSVCfilter.startdateend""; 0; 0; 0"
        Me.txtstartdateend.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtstartdateend.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtstartdateend.Location = New System.Drawing.Point(104, 15)
        Me.txtstartdateend.Name = "txtstartdateend"
        Me.txtstartdateend.Size = New System.Drawing.Size(78, 18)
        Me.txtstartdateend.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(436, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "From"
        '
        'txtstartdatebeg
        '
        Me.txtstartdatebeg.FieldName = """bXSVCfilter.startdatebeg""; 0; 0; 0"
        Me.txtstartdatebeg.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtstartdatebeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtstartdatebeg.Location = New System.Drawing.Point(4, 15)
        Me.txtstartdatebeg.Name = "txtstartdatebeg"
        Me.txtstartdatebeg.Size = New System.Drawing.Size(78, 18)
        Me.txtstartdatebeg.TabIndex = 13
        '
        'txttbmasterid
        '
        Me.txttbmasterid.Default = ""
        Me.txttbmasterid.FieldName = """bXSVCfilter.tbmasterid""; 0; 0; 0"
        Me.txttbmasterid.Location = New System.Drawing.Point(7, 75)
        Me.txttbmasterid.Mask = "UUUUUUUUUU"
        Me.txttbmasterid.Name = "txttbmasterid"
        Me.txttbmasterid.PV = """smConMaster_CpnyID"", ""bpes.cpnyid""; 0; 0; 0; 0,"
        Me.txttbmasterid.Size = New System.Drawing.Size(96, 19)
        Me.txttbmasterid.TabIndex = 20
        Me.txttbmasterid.TextLength = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(133, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Contract Profile Billwith"
        '
        'txtservitemid
        '
        Me.txtservitemid.Default = ""
        Me.txtservitemid.FieldName = """bXSVCfilter.servitemid""; 0; 0; 0"
        Me.txtservitemid.Location = New System.Drawing.Point(403, 77)
        Me.txtservitemid.Mask = "UUUUUUUUUUUUUUUUUUUUUUUUUUUUUU"
        Me.txtservitemid.Name = "txtservitemid"
        Me.txtservitemid.PV = """xserviceitems_all"","
        Me.txtservitemid.Size = New System.Drawing.Size(175, 19)
        Me.txtservitemid.TabIndex = 26
        Me.txtservitemid.TextLength = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(403, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Service Item ID"
        '
        'txtbranchid
        '
        Me.txtbranchid.Default = ""
        Me.txtbranchid.FieldName = """bXSVCfilter.branchID""; 0; 0; 0"
        Me.txtbranchid.Location = New System.Drawing.Point(402, 34)
        Me.txtbranchid.Mask = "UUUUUUUUUU"
        Me.txtbranchid.Name = "txtbranchid"
        Me.txtbranchid.PV = """smbranch_CpnyID"", ""bpes.cpnyid""; 0; 0; 0; 0,"
        Me.txtbranchid.Size = New System.Drawing.Size(87, 19)
        Me.txtbranchid.TabIndex = 10
        Me.txtbranchid.TextLength = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(402, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Branch ID"
        '
        'txtcontid
        '
        Me.txtcontid.Default = ""
        Me.txtcontid.FieldName = """bXSVCfilter.contractID""; 0; 0; 0"
        Me.txtcontid.Location = New System.Drawing.Point(261, 35)
        Me.txtcontid.Mask = "UUUUUUUUUU"
        Me.txtcontid.Name = "txtcontid"
        Me.txtcontid.PV = """xsmcontract_Cpnyid"", ""bpes.cpnyid""; 0; 0; 0; 0,"
        Me.txtcontid.Size = New System.Drawing.Size(87, 19)
        Me.txtcontid.TabIndex = 8
        Me.txtcontid.TextLength = 10
        '
        'contidlbl
        '
        Me.contidlbl.AutoSize = True
        Me.contidlbl.Location = New System.Drawing.Point(261, 22)
        Me.contidlbl.Name = "contidlbl"
        Me.contidlbl.Size = New System.Drawing.Size(63, 13)
        Me.contidlbl.TabIndex = 7
        Me.contidlbl.Text = "Contract ID"
        '
        'txtsiteid
        '
        Me.txtsiteid.Default = ""
        Me.txtsiteid.FieldName = """bXSVCfilter.siteid""; 0; 0; 0"
        Me.txtsiteid.Location = New System.Drawing.Point(134, 36)
        Me.txtsiteid.Mask = "UUUUUUUUUU"
        Me.txtsiteid.Name = "txtsiteid"
        Me.txtsiteid.PV = """SOAddress_CustId_ShipToID"", ""bXSVCfilter.custid""; 0; 0; 0; 0, "
        Me.txtsiteid.Size = New System.Drawing.Size(87, 19)
        Me.txtsiteid.TabIndex = 6
        Me.txtsiteid.TextLength = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(134, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Site ID"
        '
        'txtcustid
        '
        Me.txtcustid.Default = ""
        Me.txtcustid.FieldName = """bXSVCfilter.custid""; 0; 0; 0"
        Me.txtcustid.Location = New System.Drawing.Point(6, 36)
        Me.txtcustid.Mask = "UUUUUUUUUUUUUUU"
        Me.txtcustid.Name = "txtcustid"
        Me.txtcustid.PV = """customer_all"","
        Me.txtcustid.Size = New System.Drawing.Size(121, 19)
        Me.txtcustid.TabIndex = 4
        Me.txtcustid.TextLength = 15
        '
        'txtcontidD
        '
        Me.txtcontidD.Default = ""
        Me.txtcontidD.Enabled = False
        Me.txtcontidD.FieldName = """bXSVCgrid.contractID""; 0; 0; 0"
        Me.txtcontidD.Heading = "Contract ID"
        Me.txtcontidD.Level = "1"
        Me.txtcontidD.Location = New System.Drawing.Point(11, 204)
        Me.txtcontidD.Mask = "UUUUUUUUUU"
        Me.txtcontidD.Name = "txtcontidD"
        Me.txtcontidD.Size = New System.Drawing.Size(87, 19)
        Me.txtcontidD.TabIndex = 10
        Me.txtcontidD.TextLength = 10
        Me.txtcontidD.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Customer ID"
        '
        'cmdClearFilters
        '
        Me.cmdClearFilters.Location = New System.Drawing.Point(889, 69)
        Me.cmdClearFilters.Name = "cmdClearFilters"
        Me.cmdClearFilters.Size = New System.Drawing.Size(122, 24)
        Me.cmdClearFilters.TabIndex = 28
        Me.cmdClearFilters.Text = "Clear Filters"
        Me.cmdClearFilters.UseVisualStyleBackColor = True
        '
        'btnRefreshGrid
        '
        Me.btnRefreshGrid.Location = New System.Drawing.Point(383, 265)
        Me.btnRefreshGrid.Name = "btnRefreshGrid"
        Me.btnRefreshGrid.Size = New System.Drawing.Size(212, 20)
        Me.btnRefreshGrid.TabIndex = 150
        Me.btnRefreshGrid.Text = "Refresh Grid"
        Me.btnRefreshGrid.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(339, 645)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(118, 21)
        Me.btnClear.TabIndex = 301
        Me.btnClear.Text = "Clear All"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnselect
        '
        Me.btnselect.Location = New System.Drawing.Point(199, 645)
        Me.btnselect.Name = "btnselect"
        Me.btnselect.Size = New System.Drawing.Size(120, 21)
        Me.btnselect.TabIndex = 300
        Me.btnselect.Text = "Select All"
        Me.btnselect.UseVisualStyleBackColor = True
        '
        'cBegProcessing
        '
        Me.cBegProcessing.Location = New System.Drawing.Point(570, 646)
        Me.cBegProcessing.Name = "cBegProcessing"
        Me.cBegProcessing.Size = New System.Drawing.Size(171, 21)
        Me.cBegProcessing.TabIndex = 302
        Me.cBegProcessing.Text = "Process"
        Me.cBegProcessing.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Existing)
        Me.TabControl1.Controls.Add(Me.Renewals)
        Me.TabControl1.Controls.Add(Me.Escalations)
        Me.TabControl1.Location = New System.Drawing.Point(1, 321)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1067, 318)
        Me.TabControl1.TabIndex = 303
        '
        'Existing
        '
        Me.Existing.BackColor = System.Drawing.SystemColors.Control
        Me.Existing.Controls.Add(Me.GroupBox2)
        Me.Existing.Location = New System.Drawing.Point(4, 22)
        Me.Existing.Name = "Existing"
        Me.Existing.Padding = New System.Windows.Forms.Padding(3)
        Me.Existing.Size = New System.Drawing.Size(1059, 292)
        Me.Existing.TabIndex = 0
        Me.Existing.Text = "Add/Delete/Update/Other Changes"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNewMonit)
        Me.GroupBox2.Controls.Add(Me.Label64)
        Me.GroupBox2.Controls.Add(Me.txtNewMaint)
        Me.GroupBox2.Controls.Add(Me.Label63)
        Me.GroupBox2.Controls.Add(Me.txtCurMonit)
        Me.GroupBox2.Controls.Add(Me.Label62)
        Me.GroupBox2.Controls.Add(Me.txtCurMaint)
        Me.GroupBox2.Controls.Add(Me.Label61)
        Me.GroupBox2.Controls.Add(Me.DslFloat2)
        Me.GroupBox2.Controls.Add(Me.Label45)
        Me.GroupBox2.Controls.Add(Me.DslFloat1)
        Me.GroupBox2.Controls.Add(Me.Label44)
        Me.GroupBox2.Controls.Add(Me.xinvrules)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Controls.Add(Me.txtbillfrequency)
        Me.GroupBox2.Controls.Add(Me.Label42)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.DslDate2)
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.DslDate1)
        Me.GroupBox2.Controls.Add(Me.DslMaskedText2)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.txtcustname)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtselected)
        Me.GroupBox2.Controls.Add(Me.txttotalamt)
        Me.GroupBox2.Controls.Add(Me.txtcontractidD)
        Me.GroupBox2.Controls.Add(Me.txtsitezipD)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtsitestateD)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtsitecityD)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtsiteaddr2d)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtsiteaddr1D)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtsiteidD)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtsitenameD)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.DslMasketxtcustidDdText2)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtbranchidD)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.DslGrid1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(-2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1027, 287)
        Me.GroupBox2.TabIndex = 201
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Press F4 for grid/form view"
        '
        'txtNewMonit
        '
        Me.txtNewMonit.Enabled = False
        Me.txtNewMonit.FieldName = """bxsvcgrid.NewMonitAmt""; 0; 0; 0"
        Me.txtNewMonit.Heading = "New,Monitoring Amt"
        Me.txtNewMonit.Level = "1"
        Me.txtNewMonit.Location = New System.Drawing.Point(656, 136)
        Me.txtNewMonit.Name = "txtNewMonit"
        Me.txtNewMonit.Separator = True
        Me.txtNewMonit.Size = New System.Drawing.Size(119, 20)
        Me.txtNewMonit.TabIndex = 226
        Me.txtNewMonit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(660, 117)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(103, 13)
        Me.Label64.TabIndex = 225
        Me.Label64.Text = "New Monitoring Amt"
        '
        'txtNewMaint
        '
        Me.txtNewMaint.Enabled = False
        Me.txtNewMaint.FieldName = """bxsvcgrid.NewMaintAmt""; 0; 0; 0"
        Me.txtNewMaint.Heading = "New,Maint Amt"
        Me.txtNewMaint.Level = "1"
        Me.txtNewMaint.Location = New System.Drawing.Point(528, 136)
        Me.txtNewMaint.Name = "txtNewMaint"
        Me.txtNewMaint.Separator = True
        Me.txtNewMaint.Size = New System.Drawing.Size(119, 20)
        Me.txtNewMaint.TabIndex = 222
        Me.txtNewMaint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(532, 117)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(79, 13)
        Me.Label63.TabIndex = 221
        Me.Label63.Text = "New Maint Amt"
        '
        'txtCurMonit
        '
        Me.txtCurMonit.Enabled = False
        Me.txtCurMonit.FieldName = """bxsvcgrid.CurMonitAmt""; 0; 0; 0"
        Me.txtCurMonit.Heading = "Current,Monitoring Amt"
        Me.txtCurMonit.Level = "1"
        Me.txtCurMonit.Location = New System.Drawing.Point(656, 85)
        Me.txtCurMonit.Name = "txtCurMonit"
        Me.txtCurMonit.Separator = True
        Me.txtCurMonit.Size = New System.Drawing.Size(119, 20)
        Me.txtCurMonit.TabIndex = 224
        Me.txtCurMonit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(652, 66)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(119, 13)
        Me.Label62.TabIndex = 223
        Me.Label62.Text = "Current Monitoring Amt"
        '
        'txtCurMaint
        '
        Me.txtCurMaint.Enabled = False
        Me.txtCurMaint.FieldName = """bxsvcgrid.CurMaintAmt""; 0; 0; 0"
        Me.txtCurMaint.Heading = "Current,Maint Amt"
        Me.txtCurMaint.Level = "1"
        Me.txtCurMaint.Location = New System.Drawing.Point(528, 85)
        Me.txtCurMaint.Name = "txtCurMaint"
        Me.txtCurMaint.Separator = True
        Me.txtCurMaint.Size = New System.Drawing.Size(119, 20)
        Me.txtCurMaint.TabIndex = 220
        Me.txtCurMaint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(532, 66)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(95, 13)
        Me.Label61.TabIndex = 219
        Me.Label61.Text = "Current Maint Amt"
        '
        'DslFloat2
        '
        Me.DslFloat2.Enabled = False
        Me.DslFloat2.FieldName = """bxsvcgrid.NewRMRAmt""; 0; 0; 0"
        Me.DslFloat2.Heading = "New,RMR Amt"
        Me.DslFloat2.Level = "1"
        Me.DslFloat2.Location = New System.Drawing.Point(403, 85)
        Me.DslFloat2.Name = "DslFloat2"
        Me.DslFloat2.Separator = True
        Me.DslFloat2.Size = New System.Drawing.Size(119, 20)
        Me.DslFloat2.TabIndex = 218
        Me.DslFloat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(407, 66)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(75, 13)
        Me.Label45.TabIndex = 217
        Me.Label45.Text = "New RMR Amt"
        '
        'DslFloat1
        '
        Me.DslFloat1.Enabled = False
        Me.DslFloat1.FieldName = """bxsvcgrid.CurRMRAmt""; 0; 0; 0"
        Me.DslFloat1.Heading = "Current,RMR Amt"
        Me.DslFloat1.Level = "1"
        Me.DslFloat1.Location = New System.Drawing.Point(195, 85)
        Me.DslFloat1.Name = "DslFloat1"
        Me.DslFloat1.Separator = True
        Me.DslFloat1.Size = New System.Drawing.Size(119, 20)
        Me.DslFloat1.TabIndex = 216
        Me.DslFloat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(199, 66)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(91, 13)
        Me.Label44.TabIndex = 215
        Me.Label44.Text = "Current RMR Amt"
        '
        'xinvrules
        '
        Me.xinvrules.Blankerr = True
        Me.xinvrules.Enabled = False
        Me.xinvrules.FieldName = """bXSVCgrid.invoicingrule""; 0; 0; 0"
        Me.xinvrules.FormattingEnabled = True
        Me.xinvrules.Heading = "Invoicing,Rules"
        Me.xinvrules.Level = "1"
        Me.xinvrules.List = "ARREARS;ARREARS,ADVANCE;ADVANCE"
        Me.xinvrules.Location = New System.Drawing.Point(15, 84)
        Me.xinvrules.Name = "xinvrules"
        Me.xinvrules.Size = New System.Drawing.Size(132, 21)
        Me.xinvrules.TabIndex = 214
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(13, 66)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(79, 13)
        Me.Label43.TabIndex = 213
        Me.Label43.Text = "Invoicing Rules"
        '
        'txtbillfrequency
        '
        Me.txtbillfrequency.Blankerr = True
        Me.txtbillfrequency.Enabled = False
        Me.txtbillfrequency.FieldName = """bXSVCgrid.billingfreq""; 0; 0; 0"
        Me.txtbillfrequency.FormattingEnabled = True
        Me.txtbillfrequency.Heading = "Billing,Frequency"
        Me.txtbillfrequency.Level = "1"
        Me.txtbillfrequency.List = "M;Monthly,Q;Quarterly,S;Semi-Annual,A;Annual"
        Me.txtbillfrequency.Location = New System.Drawing.Point(834, 33)
        Me.txtbillfrequency.Name = "txtbillfrequency"
        Me.txtbillfrequency.Size = New System.Drawing.Size(97, 21)
        Me.txtbillfrequency.TabIndex = 212
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(834, 18)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(87, 13)
        Me.Label42.TabIndex = 211
        Me.Label42.Text = "Billing Frequency"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(724, 20)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(96, 13)
        Me.Label41.TabIndex = 209
        Me.Label41.Text = "Contract End Date"
        '
        'DslDate2
        '
        Me.DslDate2.Enabled = False
        Me.DslDate2.FieldName = """bXSVCgrid.contractend""; 0; 0; 0"
        Me.DslDate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.DslDate2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DslDate2.Heading = "Contract End Date"
        Me.DslDate2.Level = "1"
        Me.DslDate2.Location = New System.Drawing.Point(726, 36)
        Me.DslDate2.Name = "DslDate2"
        Me.DslDate2.Size = New System.Drawing.Size(85, 18)
        Me.DslDate2.TabIndex = 210
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(616, 23)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(102, 13)
        Me.Label40.TabIndex = 207
        Me.Label40.Text = "Contract Start Date"
        '
        'DslDate1
        '
        Me.DslDate1.Enabled = False
        Me.DslDate1.FieldName = """bXSVCgrid.contractstart""; 0; 0; 0"
        Me.DslDate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.DslDate1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DslDate1.Heading = "Contract Start Date"
        Me.DslDate1.Level = "1"
        Me.DslDate1.Location = New System.Drawing.Point(617, 36)
        Me.DslDate1.Name = "DslDate1"
        Me.DslDate1.Size = New System.Drawing.Size(85, 18)
        Me.DslDate1.TabIndex = 208
        '
        'DslMaskedText2
        '
        Me.DslMaskedText2.Default = ""
        Me.DslMaskedText2.Enabled = False
        Me.DslMaskedText2.FieldName = """bXSVCgrid.parentname""; 0; 0; 0"
        Me.DslMaskedText2.Heading = "Parent,Name"
        Me.DslMaskedText2.Level = "1"
        Me.DslMaskedText2.Location = New System.Drawing.Point(403, 35)
        Me.DslMaskedText2.Mask = "UUUUUUUUUUUUUUU"
        Me.DslMaskedText2.Name = "DslMaskedText2"
        Me.DslMaskedText2.PV = " "
        Me.DslMaskedText2.Size = New System.Drawing.Size(184, 19)
        Me.DslMaskedText2.TabIndex = 206
        Me.DslMaskedText2.TextLength = 15
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(404, 19)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 13)
        Me.Label39.TabIndex = 205
        Me.Label39.Text = "Parent Name"
        '
        'txtcustname
        '
        Me.txtcustname.Default = ""
        Me.txtcustname.Enabled = False
        Me.txtcustname.FieldName = """bxsvcgrid.CustName""; 0; 0; 0"
        Me.txtcustname.Heading = "Customer, Name"
        Me.txtcustname.Level = "1"
        Me.txtcustname.Location = New System.Drawing.Point(194, 35)
        Me.txtcustname.Mask = "UUUUUUUUUUUUUUU"
        Me.txtcustname.Name = "txtcustname"
        Me.txtcustname.PV = " "
        Me.txtcustname.Size = New System.Drawing.Size(184, 19)
        Me.txtcustname.TabIndex = 204
        Me.txtcustname.TextLength = 15
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(195, 20)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 13)
        Me.Label24.TabIndex = 240
        Me.Label24.Text = "Customer Name"
        '
        'txtselected
        '
        Me.txtselected.Default = ""
        Me.txtselected.FieldName = """bselected""; 0; 1; 2"
        Me.txtselected.Heading = "Select"
        Me.txtselected.Level = "1"
        Me.txtselected.Location = New System.Drawing.Point(10, 39)
        Me.txtselected.Name = "txtselected"
        Me.txtselected.Size = New System.Drawing.Size(68, 22)
        Me.txtselected.TabIndex = 201
        Me.txtselected.Text = "Selected"
        '
        'txttotalamt
        '
        Me.txttotalamt.FieldName = """bxsvcgrid.totalamt""; 0; 0; 0"
        Me.txttotalamt.Heading = "Amount"
        Me.txttotalamt.Level = "1"
        Me.txttotalamt.Location = New System.Drawing.Point(308, 221)
        Me.txttotalamt.Name = "txttotalamt"
        Me.txttotalamt.Separator = True
        Me.txttotalamt.Size = New System.Drawing.Size(133, 20)
        Me.txttotalamt.TabIndex = 246
        Me.txttotalamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotalamt.Visible = False
        '
        'txtcontractidD
        '
        Me.txtcontractidD.Default = ""
        Me.txtcontractidD.Enabled = False
        Me.txtcontractidD.FieldName = """bXSVCgrid.contractid""; 0; 0; 0"
        Me.txtcontractidD.Heading = "Contract ID"
        Me.txtcontractidD.Level = "1"
        Me.txtcontractidD.Location = New System.Drawing.Point(89, 35)
        Me.txtcontractidD.Mask = "UUUUUUUUUU"
        Me.txtcontractidD.Name = "txtcontractidD"
        Me.txtcontractidD.Size = New System.Drawing.Size(89, 19)
        Me.txtcontractidD.TabIndex = 203
        Me.txtcontractidD.TextLength = 10
        '
        'txtsitezipD
        '
        Me.txtsitezipD.Default = ""
        Me.txtsitezipD.Enabled = False
        Me.txtsitezipD.FieldName = """bXSVCgrid.sitezip""; 0; 0; 0"
        Me.txtsitezipD.Heading = "Site,Zip"
        Me.txtsitezipD.Level = "1"
        Me.txtsitezipD.Location = New System.Drawing.Point(204, 222)
        Me.txtsitezipD.Mask = "UUUUUUUUUU"
        Me.txtsitezipD.Name = "txtsitezipD"
        Me.txtsitezipD.Size = New System.Drawing.Size(89, 19)
        Me.txtsitezipD.TabIndex = 244
        Me.txtsitezipD.TextLength = 10
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(310, 205)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 245
        Me.Label20.Text = "Amount"
        Me.Label20.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(204, 207)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 13)
        Me.Label19.TabIndex = 243
        Me.Label19.Text = "Site Zip"
        '
        'txtsitestateD
        '
        Me.txtsitestateD.Default = ""
        Me.txtsitestateD.Enabled = False
        Me.txtsitestateD.FieldName = """bXSVCgrid.sitestate""; 0; 0; 0"
        Me.txtsitestateD.Heading = "Site,State"
        Me.txtsitestateD.Level = "1"
        Me.txtsitestateD.Location = New System.Drawing.Point(20, 224)
        Me.txtsitestateD.Mask = "UUU"
        Me.txtsitestateD.Name = "txtsitestateD"
        Me.txtsitestateD.Size = New System.Drawing.Size(46, 19)
        Me.txtsitestateD.TabIndex = 242
        Me.txtsitestateD.TextLength = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(20, 209)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 241
        Me.Label18.Text = "Site State"
        '
        'txtsitecityD
        '
        Me.txtsitecityD.Default = ""
        Me.txtsitecityD.Enabled = False
        Me.txtsitecityD.FieldName = """bXSVCgrid.sitecity""; 0; 0; 0"
        Me.txtsitecityD.Heading = "Site,City"
        Me.txtsitecityD.Level = "1"
        Me.txtsitecityD.Location = New System.Drawing.Point(852, 176)
        Me.txtsitecityD.Mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.txtsitecityD.Name = "txtsitecityD"
        Me.txtsitecityD.Size = New System.Drawing.Size(134, 19)
        Me.txtsitecityD.TabIndex = 240
        Me.txtsitecityD.TextLength = 30
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(852, 161)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 239
        Me.Label17.Text = "SiteCity"
        '
        'txtsiteaddr2d
        '
        Me.txtsiteaddr2d.Default = ""
        Me.txtsiteaddr2d.Enabled = False
        Me.txtsiteaddr2d.FieldName = """bXSVCgrid.siteaddr2""; 0; 0; 0"
        Me.txtsiteaddr2d.Heading = "Site,Addr2"
        Me.txtsiteaddr2d.Level = "1"
        Me.txtsiteaddr2d.Location = New System.Drawing.Point(608, 176)
        Me.txtsiteaddr2d.Mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.txtsiteaddr2d.Name = "txtsiteaddr2d"
        Me.txtsiteaddr2d.Size = New System.Drawing.Size(178, 19)
        Me.txtsiteaddr2d.TabIndex = 238
        Me.txtsiteaddr2d.TextLength = 60
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(608, 161)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 237
        Me.Label16.Text = "Site Addr2"
        '
        'txtsiteaddr1D
        '
        Me.txtsiteaddr1D.Default = ""
        Me.txtsiteaddr1D.Enabled = False
        Me.txtsiteaddr1D.FieldName = """bXSVCgrid.siteaddr1""; 0; 0; 0"
        Me.txtsiteaddr1D.Heading = "Site,Addr1"
        Me.txtsiteaddr1D.Level = "1"
        Me.txtsiteaddr1D.Location = New System.Drawing.Point(396, 176)
        Me.txtsiteaddr1D.Mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.txtsiteaddr1D.Name = "txtsiteaddr1D"
        Me.txtsiteaddr1D.Size = New System.Drawing.Size(180, 19)
        Me.txtsiteaddr1D.TabIndex = 236
        Me.txtsiteaddr1D.TextLength = 60
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(396, 161)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 235
        Me.Label15.Text = "Site Addr1"
        '
        'txtsiteidD
        '
        Me.txtsiteidD.Default = ""
        Me.txtsiteidD.Enabled = False
        Me.txtsiteidD.FieldName = """bXSVCgrid.siteid""; 0; 0; 0"
        Me.txtsiteidD.Heading = "Site ID"
        Me.txtsiteidD.Level = "1"
        Me.txtsiteidD.Location = New System.Drawing.Point(13, 176)
        Me.txtsiteidD.Mask = "UUUUUUUUUUUUUUU"
        Me.txtsiteidD.Name = "txtsiteidD"
        Me.txtsiteidD.Size = New System.Drawing.Size(87, 19)
        Me.txtsiteidD.TabIndex = 232
        Me.txtsiteidD.TextLength = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 161)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 231
        Me.Label14.Text = "Site ID"
        '
        'txtsitenameD
        '
        Me.txtsitenameD.Default = ""
        Me.txtsitenameD.Enabled = False
        Me.txtsitenameD.FieldName = """bXSVCgrid.sitename""; 0; 0; 0"
        Me.txtsitenameD.Heading = "Site,Name"
        Me.txtsitenameD.Level = "1"
        Me.txtsitenameD.Location = New System.Drawing.Point(198, 176)
        Me.txtsitenameD.Mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.txtsitenameD.Name = "txtsitenameD"
        Me.txtsitenameD.Size = New System.Drawing.Size(157, 19)
        Me.txtsitenameD.TabIndex = 234
        Me.txtsitenameD.TextLength = 60
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(198, 161)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 233
        Me.Label13.Text = "Site Name"
        '
        'DslMasketxtcustidDdText2
        '
        Me.DslMasketxtcustidDdText2.Default = ""
        Me.DslMasketxtcustidDdText2.Enabled = False
        Me.DslMasketxtcustidDdText2.FieldName = """bXSVCgrid.custid""; 0; 0; 0"
        Me.DslMasketxtcustidDdText2.Heading = "Customer ID"
        Me.DslMasketxtcustidDdText2.Level = "1"
        Me.DslMasketxtcustidDdText2.Location = New System.Drawing.Point(904, 96)
        Me.DslMasketxtcustidDdText2.Mask = "UUUUUUUUUUUUUUU"
        Me.DslMasketxtcustidDdText2.Name = "DslMasketxtcustidDdText2"
        Me.DslMasketxtcustidDdText2.Size = New System.Drawing.Size(87, 19)
        Me.DslMasketxtcustidDdText2.TabIndex = 230
        Me.DslMasketxtcustidDdText2.TextLength = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(906, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 229
        Me.Label12.Text = "Customer ID"
        '
        'txtbranchidD
        '
        Me.txtbranchidD.Default = ""
        Me.txtbranchidD.Enabled = False
        Me.txtbranchidD.FieldName = """bXSVCgrid.branchID""; 0; 0; 0"
        Me.txtbranchidD.Heading = "Branch ID"
        Me.txtbranchidD.Level = "1"
        Me.txtbranchidD.Location = New System.Drawing.Point(793, 96)
        Me.txtbranchidD.Mask = "UUUUUUUUUU"
        Me.txtbranchidD.Name = "txtbranchidD"
        Me.txtbranchidD.Size = New System.Drawing.Size(87, 19)
        Me.txtbranchidD.TabIndex = 228
        Me.txtbranchidD.TextLength = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(795, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 227
        Me.Label11.Text = "Branch ID"
        '
        'DslGrid1
        '
        Me.DslGrid1.Location = New System.Drawing.Point(898, 242)
        Me.DslGrid1.Name = "DslGrid1"
        Me.DslGrid1.OcxState = CType(resources.GetObject("DslGrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DslGrid1.Size = New System.Drawing.Size(93, 28)
        Me.DslGrid1.TabIndex = 247
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(90, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 202
        Me.Label10.Text = "Contract ID"
        '
        'Renewals
        '
        Me.Renewals.BackColor = System.Drawing.SystemColors.Control
        Me.Renewals.Controls.Add(Me.GroupBox1)
        Me.Renewals.Location = New System.Drawing.Point(4, 22)
        Me.Renewals.Name = "Renewals"
        Me.Renewals.Padding = New System.Windows.Forms.Padding(3)
        Me.Renewals.Size = New System.Drawing.Size(1059, 292)
        Me.Renewals.TabIndex = 1
        Me.Renewals.Text = "Renewals"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtpctmonitor)
        Me.GroupBox1.Controls.Add(Me.Label46)
        Me.GroupBox1.Controls.Add(Me.txtpctmaint)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtContProfile)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnViewSC)
        Me.GroupBox1.Controls.Add(Me.txtServices)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.txtDuration)
        Me.GroupBox1.Controls.Add(Me.txtSelectedRenewals)
        Me.GroupBox1.Controls.Add(Me.txtInvoicingRuleA)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.txtFrequency)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.txtsameservicesa)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.txtrenewaldate)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.txtnumcontractsA)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtnameA)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.txtustidA)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.DslGrid2)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1057, 285)
        Me.GroupBox1.TabIndex = 427
        Me.GroupBox1.TabStop = False
        '
        'txtpctmonitor
        '
        Me.txtpctmonitor.FieldName = """bxRenew.PctMonitor""; 0; 0; 0"
        Me.txtpctmonitor.Heading = "%,Monitoring"
        Me.txtpctmonitor.Level = "2"
        Me.txtpctmonitor.Location = New System.Drawing.Point(700, 90)
        Me.txtpctmonitor.Name = "txtpctmonitor"
        Me.txtpctmonitor.Size = New System.Drawing.Size(57, 20)
        Me.txtpctmonitor.TabIndex = 421
        Me.txtpctmonitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(693, 74)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(71, 13)
        Me.Label46.TabIndex = 420
        Me.Label46.Text = "% Monitoring"
        '
        'txtpctmaint
        '
        Me.txtpctmaint.FieldName = """bxRenew.PctMaint""; 0; 0; 0"
        Me.txtpctmaint.Heading = "%,Maintenance"
        Me.txtpctmaint.Level = "2"
        Me.txtpctmaint.Location = New System.Drawing.Point(569, 90)
        Me.txtpctmaint.Name = "txtpctmaint"
        Me.txtpctmaint.Size = New System.Drawing.Size(60, 20)
        Me.txtpctmaint.TabIndex = 419
        Me.txtpctmaint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(562, 74)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 13)
        Me.Label25.TabIndex = 418
        Me.Label25.Text = "% Maintenance"
        '
        'txtContProfile
        '
        Me.txtContProfile.Default = ""
        Me.txtContProfile.Enabled = False
        Me.txtContProfile.FieldName = """bxRenew.Profile""; 0; 0; 0"
        Me.txtContProfile.Heading = "Contract,Profile"
        Me.txtContProfile.Level = "2"
        Me.txtContProfile.Location = New System.Drawing.Point(277, 86)
        Me.txtContProfile.Mask = "UUUUUUUUUUUUUUU"
        Me.txtContProfile.Name = "txtContProfile"
        Me.txtContProfile.PV = " "
        Me.txtContProfile.Size = New System.Drawing.Size(63, 19)
        Me.txtContProfile.TabIndex = 417
        Me.txtContProfile.TextLength = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(277, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 416
        Me.Label4.Text = "Contract Profile"
        '
        'btnViewSC
        '
        Me.btnViewSC.Location = New System.Drawing.Point(25, 191)
        Me.btnViewSC.Name = "btnViewSC"
        Me.btnViewSC.Size = New System.Drawing.Size(120, 20)
        Me.btnViewSC.TabIndex = 428
        Me.btnViewSC.Text = "View Service Contract"
        Me.btnViewSC.UseVisualStyleBackColor = True
        '
        'txtServices
        '
        Me.txtServices.Default = ""
        Me.txtServices.Enabled = False
        Me.txtServices.FieldName = """bxRenew.Services""; 0; 0; 0"
        Me.txtServices.Heading = "Services"
        Me.txtServices.Level = "2"
        Me.txtServices.Location = New System.Drawing.Point(680, 186)
        Me.txtServices.Mask = "UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU" &
    "UUUUUUUUUUUUUUU"
        Me.txtServices.Name = "txtServices"
        Me.txtServices.Size = New System.Drawing.Size(57, 19)
        Me.txtServices.TabIndex = 427
        Me.txtServices.TextLength = 96
        Me.txtServices.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(682, 174)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 13)
        Me.Label33.TabIndex = 426
        Me.Label33.Text = "Services"
        Me.Label33.Visible = False
        '
        'txtDuration
        '
        Me.txtDuration.Enabled = False
        Me.txtDuration.FieldName = """bxRenew.Duration""; 0; 0; 0"
        Me.txtDuration.Heading = "Duration,(in Mos)"
        Me.txtDuration.Level = "2"
        Me.txtDuration.Location = New System.Drawing.Point(151, 92)
        Me.txtDuration.Max = 2147483647.0R
        Me.txtDuration.Min = -2147483648.0R
        Me.txtDuration.Name = "txtDuration"
        Me.txtDuration.Size = New System.Drawing.Size(39, 18)
        Me.txtDuration.SpinIncrement = CType(0, Short)
        Me.txtDuration.TabIndex = 415
        Me.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSelectedRenewals
        '
        Me.txtSelectedRenewals.Default = ""
        Me.txtSelectedRenewals.FieldName = """bSelectedRenewals""; 0; 1; 2"
        Me.txtSelectedRenewals.Heading = "Select for,Processing"
        Me.txtSelectedRenewals.Level = "2"
        Me.txtSelectedRenewals.Location = New System.Drawing.Point(25, 43)
        Me.txtSelectedRenewals.Name = "txtSelectedRenewals"
        Me.txtSelectedRenewals.Size = New System.Drawing.Size(89, 22)
        Me.txtSelectedRenewals.TabIndex = 401
        Me.txtSelectedRenewals.Text = "Selected"
        '
        'txtInvoicingRuleA
        '
        Me.txtInvoicingRuleA.Default = ""
        Me.txtInvoicingRuleA.Enabled = False
        Me.txtInvoicingRuleA.FieldName = """bxRenew.InvoicingRule""; 0; 0; 0"
        Me.txtInvoicingRuleA.Heading = "Invoicing,Rule"
        Me.txtInvoicingRuleA.Level = "2"
        Me.txtInvoicingRuleA.Location = New System.Drawing.Point(256, 142)
        Me.txtInvoicingRuleA.Mask = "UUUUUUUUUUUUUUU"
        Me.txtInvoicingRuleA.Name = "txtInvoicingRuleA"
        Me.txtInvoicingRuleA.Size = New System.Drawing.Size(62, 19)
        Me.txtInvoicingRuleA.TabIndex = 425
        Me.txtInvoicingRuleA.TextLength = 15
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(258, 129)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(74, 13)
        Me.Label32.TabIndex = 424
        Me.Label32.Text = "Invoicing Rule"
        '
        'txtFrequency
        '
        Me.txtFrequency.Default = ""
        Me.txtFrequency.Enabled = False
        Me.txtFrequency.FieldName = """bxRenew.Frequency""; 0; 0; 0"
        Me.txtFrequency.Heading = "Frequency"
        Me.txtFrequency.Level = "2"
        Me.txtFrequency.Location = New System.Drawing.Point(150, 142)
        Me.txtFrequency.Mask = "UUUUUUUUUUUUUUU"
        Me.txtFrequency.Name = "txtFrequency"
        Me.txtFrequency.Size = New System.Drawing.Size(69, 19)
        Me.txtFrequency.TabIndex = 423
        Me.txtFrequency.TextLength = 15
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(152, 129)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 422
        Me.Label31.Text = "Frequency"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(149, 77)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(105, 13)
        Me.Label30.TabIndex = 414
        Me.Label30.Text = "Duration (in Months)"
        '
        'txtsameservicesa
        '
        Me.txtsameservicesa.Default = ""
        Me.txtsameservicesa.Enabled = False
        Me.txtsameservicesa.FieldName = """bxRenew.sameservices""; 0; 0; 0"
        Me.txtsameservicesa.Heading = "Same,Services"
        Me.txtsameservicesa.Level = "2"
        Me.txtsameservicesa.Location = New System.Drawing.Point(896, 55)
        Me.txtsameservicesa.Mask = "UUUUUUUUUUUUUUU"
        Me.txtsameservicesa.Name = "txtsameservicesa"
        Me.txtsameservicesa.PV = """customer_all"","
        Me.txtsameservicesa.Size = New System.Drawing.Size(34, 19)
        Me.txtsameservicesa.TabIndex = 413
        Me.txtsameservicesa.TextLength = 15
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(896, 40)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(76, 13)
        Me.Label29.TabIndex = 412
        Me.Label29.Text = "Same Services"
        '
        'txtrenewaldate
        '
        Me.txtrenewaldate.Enabled = False
        Me.txtrenewaldate.FieldName = """bxRenew.renewaldate""; 0; 0; 0"
        Me.txtrenewaldate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtrenewaldate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtrenewaldate.Heading = "Renewal,Date"
        Me.txtrenewaldate.Level = "2"
        Me.txtrenewaldate.Location = New System.Drawing.Point(694, 51)
        Me.txtrenewaldate.Name = "txtrenewaldate"
        Me.txtrenewaldate.Size = New System.Drawing.Size(72, 18)
        Me.txtrenewaldate.TabIndex = 409
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(691, 36)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(74, 13)
        Me.Label28.TabIndex = 408
        Me.Label28.Text = "Renewal Date"
        '
        'txtnumcontractsA
        '
        Me.txtnumcontractsA.Enabled = False
        Me.txtnumcontractsA.FieldName = """bxRenew.numcontracts""; 0; 0; 0"
        Me.txtnumcontractsA.Heading = "# of,Contracts"
        Me.txtnumcontractsA.Level = "2"
        Me.txtnumcontractsA.Location = New System.Drawing.Point(574, 53)
        Me.txtnumcontractsA.Max = 2147483647.0R
        Me.txtnumcontractsA.Min = -2147483648.0R
        Me.txtnumcontractsA.Name = "txtnumcontractsA"
        Me.txtnumcontractsA.Separator = True
        Me.txtnumcontractsA.Size = New System.Drawing.Size(56, 17)
        Me.txtnumcontractsA.SpinIncrement = CType(0, Short)
        Me.txtnumcontractsA.TabIndex = 407
        Me.txtnumcontractsA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(563, 39)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(78, 13)
        Me.Label27.TabIndex = 406
        Me.Label27.Text = "# of Contracts"
        '
        'txtnameA
        '
        Me.txtnameA.Default = ""
        Me.txtnameA.Enabled = False
        Me.txtnameA.FieldName = """bxRenew.Name""; 0; 0; 0"
        Me.txtnameA.Heading = "Customer, Name"
        Me.txtnameA.Level = "2"
        Me.txtnameA.Location = New System.Drawing.Point(277, 49)
        Me.txtnameA.Mask = "UUUUUUUUUUUUUUU"
        Me.txtnameA.Name = "txtnameA"
        Me.txtnameA.PV = " "
        Me.txtnameA.Size = New System.Drawing.Size(187, 19)
        Me.txtnameA.TabIndex = 405
        Me.txtnameA.TextLength = 15
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(278, 32)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(86, 13)
        Me.Label26.TabIndex = 404
        Me.Label26.Text = "Customer  Name"
        '
        'txtustidA
        '
        Me.txtustidA.Default = ""
        Me.txtustidA.Enabled = False
        Me.txtustidA.FieldName = """bxRenew.Custid""; 0; 0; 0"
        Me.txtustidA.Heading = "Customer,ID"
        Me.txtustidA.Level = "2"
        Me.txtustidA.Location = New System.Drawing.Point(148, 49)
        Me.txtustidA.Mask = "UUUUUUUUUUUUUUU"
        Me.txtustidA.Name = "txtustidA"
        Me.txtustidA.PV = " "
        Me.txtustidA.Size = New System.Drawing.Size(69, 19)
        Me.txtustidA.TabIndex = 403
        Me.txtustidA.TextLength = 15
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(148, 34)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 13)
        Me.Label23.TabIndex = 402
        Me.Label23.Text = "Customer ID"
        '
        'DslGrid2
        '
        Me.DslGrid2.Location = New System.Drawing.Point(898, 102)
        Me.DslGrid2.Name = "DslGrid2"
        Me.DslGrid2.OcxState = CType(resources.GetObject("DslGrid2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DslGrid2.Size = New System.Drawing.Size(64, 29)
        Me.DslGrid2.TabIndex = 422
        '
        'Escalations
        '
        Me.Escalations.BackColor = System.Drawing.SystemColors.Control
        Me.Escalations.Controls.Add(Me.GroupBox4)
        Me.Escalations.Location = New System.Drawing.Point(4, 22)
        Me.Escalations.Name = "Escalations"
        Me.Escalations.Padding = New System.Windows.Forms.Padding(3)
        Me.Escalations.Size = New System.Drawing.Size(1059, 292)
        Me.Escalations.TabIndex = 2
        Me.Escalations.Text = "Escalations"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.sprdEscalate)
        Me.GroupBox4.Controls.Add(Me.txtSelectedEscalations)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.txtpctmonitor_Esc)
        Me.GroupBox4.Controls.Add(Me.Label53)
        Me.GroupBox4.Controls.Add(Me.txtustidA_Esc)
        Me.GroupBox4.Controls.Add(Me.txtServices_Esc)
        Me.GroupBox4.Controls.Add(Me.btnViewSC_Esc)
        Me.GroupBox4.Controls.Add(Me.Label56)
        Me.GroupBox4.Controls.Add(Me.txtpctmaint_Esc)
        Me.GroupBox4.Controls.Add(Me.txtsameservicesa_Esc)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.Label54)
        Me.GroupBox4.Controls.Add(Me.txtnameA_Esc)
        Me.GroupBox4.Controls.Add(Me.txtContProfile_Esc)
        Me.GroupBox4.Controls.Add(Me.Label58)
        Me.GroupBox4.Controls.Add(Me.Label55)
        Me.GroupBox4.Controls.Add(Me.txtEscalationDate)
        Me.GroupBox4.Controls.Add(Me.Label59)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.txtFrequency_Esc)
        Me.GroupBox4.Controls.Add(Me.txtDuration_Esc)
        Me.GroupBox4.Controls.Add(Me.txtnumcontractsA_Esc)
        Me.GroupBox4.Controls.Add(Me.txtInvoicingRuleA_Esc)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.Label57)
        Me.GroupBox4.Location = New System.Drawing.Point(2, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1057, 285)
        Me.GroupBox4.TabIndex = 443
        Me.GroupBox4.TabStop = False
        '
        'sprdEscalate
        '
        Me.sprdEscalate.Location = New System.Drawing.Point(912, 120)
        Me.sprdEscalate.Name = "sprdEscalate"
        Me.sprdEscalate.OcxState = CType(resources.GetObject("sprdEscalate.OcxState"), System.Windows.Forms.AxHost.State)
        Me.sprdEscalate.Size = New System.Drawing.Size(75, 23)
        Me.sprdEscalate.TabIndex = 540
        '
        'txtSelectedEscalations
        '
        Me.txtSelectedEscalations.FieldName = """bselectedescal""; 0; 1; 2"
        Me.txtSelectedEscalations.Heading = "Select for,Processing"
        Me.txtSelectedEscalations.Level = "5"
        Me.txtSelectedEscalations.Location = New System.Drawing.Point(8, 32)
        Me.txtSelectedEscalations.Name = "txtSelectedEscalations"
        Me.txtSelectedEscalations.Size = New System.Drawing.Size(72, 24)
        Me.txtSelectedEscalations.TabIndex = 501
        Me.txtSelectedEscalations.Text = "Selected"
        Me.txtSelectedEscalations.UseVisualStyleBackColor = True
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(120, 33)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(67, 13)
        Me.Label52.TabIndex = 413
        Me.Label52.Text = "Customer ID"
        '
        'txtpctmonitor_Esc
        '
        Me.txtpctmonitor_Esc.FieldName = """bxEscalate.PctMonitor""; 0; 0; 0"
        Me.txtpctmonitor_Esc.Heading = "%,Monitoring"
        Me.txtpctmonitor_Esc.Level = "5"
        Me.txtpctmonitor_Esc.Location = New System.Drawing.Point(728, 104)
        Me.txtpctmonitor_Esc.Name = "txtpctmonitor_Esc"
        Me.txtpctmonitor_Esc.Size = New System.Drawing.Size(57, 20)
        Me.txtpctmonitor_Esc.TabIndex = 519
        Me.txtpctmonitor_Esc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(721, 88)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(71, 13)
        Me.Label53.TabIndex = 433
        Me.Label53.Text = "% Monitoring"
        '
        'txtustidA_Esc
        '
        Me.txtustidA_Esc.Default = ""
        Me.txtustidA_Esc.Enabled = False
        Me.txtustidA_Esc.FieldName = """bxEscalate.Custid""; 0; 0; 0"
        Me.txtustidA_Esc.Heading = "Customer,ID"
        Me.txtustidA_Esc.Level = "5"
        Me.txtustidA_Esc.Location = New System.Drawing.Point(120, 48)
        Me.txtustidA_Esc.Mask = "UUUUUUUUUUUUUUU"
        Me.txtustidA_Esc.Name = "txtustidA_Esc"
        Me.txtustidA_Esc.PV = " "
        Me.txtustidA_Esc.Size = New System.Drawing.Size(69, 19)
        Me.txtustidA_Esc.TabIndex = 503
        Me.txtustidA_Esc.TextLength = 15
        '
        'txtServices_Esc
        '
        Me.txtServices_Esc.Default = ""
        Me.txtServices_Esc.Enabled = False
        Me.txtServices_Esc.FieldName = """bxEscalate.Services""; 0; 0; 0"
        Me.txtServices_Esc.Heading = "Services"
        Me.txtServices_Esc.Level = "5"
        Me.txtServices_Esc.Location = New System.Drawing.Point(696, 200)
        Me.txtServices_Esc.Mask = "UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU" &
    "UUUUUUUUUUUUUUU"
        Me.txtServices_Esc.Name = "txtServices_Esc"
        Me.txtServices_Esc.Size = New System.Drawing.Size(57, 19)
        Me.txtServices_Esc.TabIndex = 525
        Me.txtServices_Esc.TextLength = 96
        Me.txtServices_Esc.Visible = False
        '
        'btnViewSC_Esc
        '
        Me.btnViewSC_Esc.Location = New System.Drawing.Point(16, 208)
        Me.btnViewSC_Esc.Name = "btnViewSC_Esc"
        Me.btnViewSC_Esc.Size = New System.Drawing.Size(120, 20)
        Me.btnViewSC_Esc.TabIndex = 527
        Me.btnViewSC_Esc.Text = "View Service Contract"
        Me.btnViewSC_Esc.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(698, 188)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(47, 13)
        Me.Label56.TabIndex = 439
        Me.Label56.Text = "Services"
        Me.Label56.Visible = False
        '
        'txtpctmaint_Esc
        '
        Me.txtpctmaint_Esc.FieldName = """bxEscalate.PctMaint""; 0; 0; 0"
        Me.txtpctmaint_Esc.Heading = "%,Maintenance"
        Me.txtpctmaint_Esc.Level = "5"
        Me.txtpctmaint_Esc.Location = New System.Drawing.Point(624, 104)
        Me.txtpctmaint_Esc.Name = "txtpctmaint_Esc"
        Me.txtpctmaint_Esc.Size = New System.Drawing.Size(60, 20)
        Me.txtpctmaint_Esc.TabIndex = 517
        Me.txtpctmaint_Esc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsameservicesa_Esc
        '
        Me.txtsameservicesa_Esc.Default = ""
        Me.txtsameservicesa_Esc.Enabled = False
        Me.txtsameservicesa_Esc.FieldName = """bxEscalate.sameservices""; 0; 0; 0"
        Me.txtsameservicesa_Esc.Heading = "Same,Services"
        Me.txtsameservicesa_Esc.Level = "5"
        Me.txtsameservicesa_Esc.Location = New System.Drawing.Point(816, 48)
        Me.txtsameservicesa_Esc.Mask = "UUUUUUUUUUUUUUU"
        Me.txtsameservicesa_Esc.Name = "txtsameservicesa_Esc"
        Me.txtsameservicesa_Esc.PV = """customer_all"","
        Me.txtsameservicesa_Esc.Size = New System.Drawing.Size(34, 19)
        Me.txtsameservicesa_Esc.TabIndex = 511
        Me.txtsameservicesa_Esc.TextLength = 15
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(257, 31)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(86, 13)
        Me.Label51.TabIndex = 415
        Me.Label51.Text = "Customer  Name"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(816, 33)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(76, 13)
        Me.Label48.TabIndex = 421
        Me.Label48.Text = "Same Services"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(617, 88)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(82, 13)
        Me.Label54.TabIndex = 431
        Me.Label54.Text = "% Maintenance"
        '
        'txtnameA_Esc
        '
        Me.txtnameA_Esc.Default = ""
        Me.txtnameA_Esc.Enabled = False
        Me.txtnameA_Esc.FieldName = """bxEscalate.Name""; 0; 0; 0"
        Me.txtnameA_Esc.Heading = "Customer, Name"
        Me.txtnameA_Esc.Level = "5"
        Me.txtnameA_Esc.Location = New System.Drawing.Point(256, 48)
        Me.txtnameA_Esc.Mask = "UUUUUUUUUUUUUUU"
        Me.txtnameA_Esc.Name = "txtnameA_Esc"
        Me.txtnameA_Esc.PV = " "
        Me.txtnameA_Esc.Size = New System.Drawing.Size(187, 19)
        Me.txtnameA_Esc.TabIndex = 505
        Me.txtnameA_Esc.TextLength = 15
        '
        'txtContProfile_Esc
        '
        Me.txtContProfile_Esc.Default = ""
        Me.txtContProfile_Esc.Enabled = False
        Me.txtContProfile_Esc.FieldName = """bxEscalate.Profile""; 0; 0; 0"
        Me.txtContProfile_Esc.Heading = "Contract,Profile"
        Me.txtContProfile_Esc.Level = "5"
        Me.txtContProfile_Esc.Location = New System.Drawing.Point(256, 96)
        Me.txtContProfile_Esc.Mask = "UUUUUUUUUUUUUUU"
        Me.txtContProfile_Esc.Name = "txtContProfile_Esc"
        Me.txtContProfile_Esc.PV = " "
        Me.txtContProfile_Esc.Size = New System.Drawing.Size(63, 19)
        Me.txtContProfile_Esc.TabIndex = 515
        Me.txtContProfile_Esc.TextLength = 15
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(122, 131)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(58, 13)
        Me.Label58.TabIndex = 435
        Me.Label58.Text = "Frequency"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(256, 81)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(82, 13)
        Me.Label55.TabIndex = 429
        Me.Label55.Text = "Contract Profile"
        '
        'txtEscalationDate
        '
        Me.txtEscalationDate.Enabled = False
        Me.txtEscalationDate.FieldName = """bxEscalate.Escalationdate""; 0; 0; 0"
        Me.txtEscalationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.txtEscalationDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEscalationDate.Heading = "Escalation,Date"
        Me.txtEscalationDate.Level = "5"
        Me.txtEscalationDate.Location = New System.Drawing.Point(720, 48)
        Me.txtEscalationDate.Name = "txtEscalationDate"
        Me.txtEscalationDate.Size = New System.Drawing.Size(72, 18)
        Me.txtEscalationDate.TabIndex = 509
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(118, 81)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(105, 13)
        Me.Label59.TabIndex = 427
        Me.Label59.Text = "Duration (in Months)"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(717, 33)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(81, 13)
        Me.Label49.TabIndex = 419
        Me.Label49.Text = "Escalation Date"
        '
        'txtFrequency_Esc
        '
        Me.txtFrequency_Esc.Default = ""
        Me.txtFrequency_Esc.Enabled = False
        Me.txtFrequency_Esc.FieldName = """bxEscalate.Frequency""; 0; 0; 0"
        Me.txtFrequency_Esc.Heading = "Frequency"
        Me.txtFrequency_Esc.Level = "5"
        Me.txtFrequency_Esc.Location = New System.Drawing.Point(120, 144)
        Me.txtFrequency_Esc.Mask = "UUUUUUUUUUUUUUU"
        Me.txtFrequency_Esc.Name = "txtFrequency_Esc"
        Me.txtFrequency_Esc.Size = New System.Drawing.Size(69, 19)
        Me.txtFrequency_Esc.TabIndex = 521
        Me.txtFrequency_Esc.TextLength = 15
        '
        'txtDuration_Esc
        '
        Me.txtDuration_Esc.Enabled = False
        Me.txtDuration_Esc.FieldName = """bxEscalate.Duration""; 0; 0; 0"
        Me.txtDuration_Esc.Heading = "Duration,(in Mos)"
        Me.txtDuration_Esc.Level = "5"
        Me.txtDuration_Esc.Location = New System.Drawing.Point(120, 96)
        Me.txtDuration_Esc.Max = 2147483647.0R
        Me.txtDuration_Esc.Min = -2147483648.0R
        Me.txtDuration_Esc.Name = "txtDuration_Esc"
        Me.txtDuration_Esc.Size = New System.Drawing.Size(39, 18)
        Me.txtDuration_Esc.SpinIncrement = CType(0, Short)
        Me.txtDuration_Esc.TabIndex = 513
        Me.txtDuration_Esc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtnumcontractsA_Esc
        '
        Me.txtnumcontractsA_Esc.Enabled = False
        Me.txtnumcontractsA_Esc.FieldName = """bxEscalate.numcontracts""; 0; 0; 0"
        Me.txtnumcontractsA_Esc.Heading = "# of,Contracts"
        Me.txtnumcontractsA_Esc.Level = "5"
        Me.txtnumcontractsA_Esc.Location = New System.Drawing.Point(624, 48)
        Me.txtnumcontractsA_Esc.Max = 2147483647.0R
        Me.txtnumcontractsA_Esc.Min = -2147483648.0R
        Me.txtnumcontractsA_Esc.Name = "txtnumcontractsA_Esc"
        Me.txtnumcontractsA_Esc.Separator = True
        Me.txtnumcontractsA_Esc.Size = New System.Drawing.Size(56, 17)
        Me.txtnumcontractsA_Esc.SpinIncrement = CType(0, Short)
        Me.txtnumcontractsA_Esc.TabIndex = 507
        Me.txtnumcontractsA_Esc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoicingRuleA_Esc
        '
        Me.txtInvoicingRuleA_Esc.Default = ""
        Me.txtInvoicingRuleA_Esc.Enabled = False
        Me.txtInvoicingRuleA_Esc.FieldName = """bxEscalate.InvoicingRule""; 0; 0; 0"
        Me.txtInvoicingRuleA_Esc.Heading = "Invoicing,Rule"
        Me.txtInvoicingRuleA_Esc.Level = "5"
        Me.txtInvoicingRuleA_Esc.Location = New System.Drawing.Point(256, 144)
        Me.txtInvoicingRuleA_Esc.Mask = "UUUUUUUUUUUUUUU"
        Me.txtInvoicingRuleA_Esc.Name = "txtInvoicingRuleA_Esc"
        Me.txtInvoicingRuleA_Esc.Size = New System.Drawing.Size(62, 19)
        Me.txtInvoicingRuleA_Esc.TabIndex = 523
        Me.txtInvoicingRuleA_Esc.TextLength = 15
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(613, 34)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(78, 13)
        Me.Label50.TabIndex = 417
        Me.Label50.Text = "# of Contracts"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(258, 131)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(74, 13)
        Me.Label57.TabIndex = 437
        Me.Label57.Text = "Invoicing Rule"
        '
        'lblprofile
        '
        Me.lblprofile.AutoSize = True
        Me.lblprofile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprofile.ForeColor = System.Drawing.Color.Teal
        Me.lblprofile.Location = New System.Drawing.Point(332, 11)
        Me.lblprofile.Name = "lblprofile"
        Me.lblprofile.Size = New System.Drawing.Size(0, 13)
        Me.lblprofile.TabIndex = 305
        '
        'txtSel1
        '
        Me.txtSel1.Enabled = False
        Me.txtSel1.FieldName = """bselgrid""; 0; 1; 2"
        Me.txtSel1.Location = New System.Drawing.Point(10, 640)
        Me.txtSel1.Max = 2147483647.0R
        Me.txtSel1.Min = -2147483648.0R
        Me.txtSel1.Name = "txtSel1"
        Me.txtSel1.Size = New System.Drawing.Size(38, 20)
        Me.txtSel1.SpinIncrement = CType(0, Short)
        Me.txtSel1.TabIndex = 307
        Me.txtSel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSel1.Trigger = "bselected;C;I,bSelectedRenewals;C;I"
        Me.txtSel1.Visible = False
        '
        'lblRefreshWarn
        '
        Me.lblRefreshWarn.ForeColor = System.Drawing.Color.Teal
        Me.lblRefreshWarn.Location = New System.Drawing.Point(1, 284)
        Me.lblRefreshWarn.Name = "lblRefreshWarn"
        Me.lblRefreshWarn.Size = New System.Drawing.Size(1055, 40)
        Me.lblRefreshWarn.TabIndex = 308
        '
        'btnImport
        '
        Me.btnImport.Enabled = False
        Me.btnImport.Location = New System.Drawing.Point(8, 296)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(118, 21)
        Me.btnImport.TabIndex = 309
        Me.btnImport.Text = "Import from Excel"
        Me.btnImport.UseVisualStyleBackColor = True
        Me.btnImport.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1064, 668)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.lblRefreshWarn)
        Me.Controls.Add(Me.txtSel1)
        Me.Controls.Add(Me.lblprofile)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnselect)
        Me.Controls.Add(Me.cBegProcessing)
        Me.Controls.Add(Me.btnRefreshGrid)
        Me.Controls.Add(Me.GrpFilters)
        Me.Controls.Add(Me.txtkeyid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Update1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Mass Update for Service Contracts V2.3K (XS.VCU.00)"
        CType(Me.Update1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFilters.ResumeLayout(False)
        Me.GrpFilters.PerformLayout()
        Me.GRPMassUp.ResumeLayout(False)
        Me.GRPMassUp.PerformLayout()
        Me.grpChangeServItem.ResumeLayout(False)
        Me.grpWarranty.ResumeLayout(False)
        Me.grpWarranty.PerformLayout()
        Me.GrpContEndDate.ResumeLayout(False)
        Me.GrpContEndDate.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Existing.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DslGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Renewals.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DslGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Escalations.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.sprdEscalate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SAFHelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents txtkeyid As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents txtcustid As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClearFilters As System.Windows.Forms.Button
    Friend WithEvents txtsiteid As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtbranchid As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcontid As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents contidlbl As System.Windows.Forms.Label
    Friend WithEvents txttbmasterid As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtservitemid As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshGrid As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnselect As System.Windows.Forms.Button
    Friend WithEvents cBegProcessing As System.Windows.Forms.Button
    Friend WithEvents txtcontidD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpContEndDate As System.Windows.Forms.GroupBox
    Public WithEvents txtexpiredateend As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents txtexpiredatebeg As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents txtstartdateend As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtstartdatebeg As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents lblrefresh As System.Windows.Forms.Label
    Friend WithEvents GRPMassUp As System.Windows.Forms.GroupBox
    Public WithEvents txteffectdateM As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents lbleffectdate As System.Windows.Forms.Label
    Friend WithEvents txtrmramtM As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents txtservitemSelM As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents lblservitemsel As System.Windows.Forms.Label
    Friend WithEvents lblempnameM As System.Windows.Forms.Label
    Friend WithEvents lbltype As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Existing As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents txtselected As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents txttotalamt As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents txtcontractidD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents txtsitezipD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtsitestateD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtsitecityD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtsiteaddr2d As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtsiteaddr1D As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtsiteidD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtsitenameD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DslMasketxtcustidDdText2 As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtbranchidD As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DslGrid1 As Microsoft.Dynamics.SL.Controls.DSLGrid
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Renewals As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInvoicingRuleA As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtFrequency As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtsameservicesa As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents txtrenewaldate As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtnumcontractsA As Microsoft.Dynamics.SL.Controls.DSLInteger
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtnameA As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtustidA As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DslGrid2 As Microsoft.Dynamics.SL.Controls.DSLGrid
    Public WithEvents txtSelectedRenewals As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents txtDuration As Microsoft.Dynamics.SL.Controls.DSLInteger
    Friend WithEvents txtServices As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnViewSC As System.Windows.Forms.Button
    Friend WithEvents txtmasterid As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtparent As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtinvprintsuppress As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents txtcancelcode As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents lblcancelA As System.Windows.Forms.Label
    Friend WithEvents lbldelinfo As System.Windows.Forms.Label
    Friend WithEvents grpWarranty As System.Windows.Forms.GroupBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtdurationA As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents txtwarrantyenddate As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents txtwarrantystartdate As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents lblcancel As System.Windows.Forms.Label
    Friend WithEvents txtcustname As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents DslDate1 As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents DslMaskedText2 As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents DslFloat2 As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents DslFloat1 As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents xinvrules As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtbillfrequency As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents DslDate2 As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents txtfrequencyM As Microsoft.Dynamics.SL.Controls.DSLCombo
    Public WithEvents txtcontractEndDate As Microsoft.Dynamics.SL.Controls.DSLDate
    Public WithEvents txtcontractstartdate As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents lblChange As System.Windows.Forms.Label
    Friend WithEvents txtBranch As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents lblbranchdesc As System.Windows.Forms.Label
    Friend WithEvents txtBillwithContractProfile As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents txtContractProfile As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents grpChangeServItem As System.Windows.Forms.GroupBox
    Friend WithEvents lblMassAmt As System.Windows.Forms.Label
    Friend WithEvents optEndAmt As Microsoft.Dynamics.SL.Controls.DSLOption
    Friend WithEvents OptPlusMinus As Microsoft.Dynamics.SL.Controls.DSLOption
    Friend WithEvents OptDummy As Microsoft.Dynamics.SL.Controls.DSLOption
    Friend WithEvents lblhide As System.Windows.Forms.Label
    Friend WithEvents BtnAddDel As System.Windows.Forms.Button
    Friend WithEvents lblprofile As System.Windows.Forms.Label
    Friend WithEvents txtSystemType As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents lblsystemtype As System.Windows.Forms.Label
    Friend WithEvents txtpctmonitor As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtpctmaint As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtContProfile As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtrenewaltype As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtSel1 As Microsoft.Dynamics.SL.Controls.DSLInteger
    Friend WithEvents lblRefreshWarn As System.Windows.Forms.Label
    Friend WithEvents txtInvcFormat As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents txtInvoiceRule As Microsoft.Dynamics.SL.Controls.DSLCombo
    Friend WithEvents Escalations As System.Windows.Forms.TabPage
    Friend WithEvents txtpctmonitor_Esc As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtpctmaint_Esc As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents txtContProfile_Esc As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents btnViewSC_Esc As System.Windows.Forms.Button
    Friend WithEvents txtServices_Esc As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtDuration_Esc As Microsoft.Dynamics.SL.Controls.DSLInteger
    Friend WithEvents txtInvoicingRuleA_Esc As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents txtFrequency_Esc As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtsameservicesa_Esc As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents txtEscalationDate As Microsoft.Dynamics.SL.Controls.DSLDate
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtnumcontractsA_Esc As Microsoft.Dynamics.SL.Controls.DSLInteger
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtnameA_Esc As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtustidA_Esc As Microsoft.Dynamics.SL.Controls.DSLMaskedText
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents txtSelectedEscalations As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents sprdEscalate As Microsoft.Dynamics.SL.Controls.DSLGrid
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents OptPct As Microsoft.Dynamics.SL.Controls.DSLOption
    Friend WithEvents txtMonitAmt As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents chkMonitAmt As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents txtMaintAmt As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents chkMaintAmt As Microsoft.Dynamics.SL.Controls.DSLCheck
    Friend WithEvents txtCurMaint As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtNewMonit As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtNewMaint As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtCurMonit As Microsoft.Dynamics.SL.Controls.DSLFloat
    Friend WithEvents Label62 As System.Windows.Forms.Label
#End Region
End Class
