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
Option Explicit On
Option Strict Off
Imports Solomon.Kernel
Imports vb = Microsoft.VisualBasic
Imports Microsoft.Dynamics.SL.ObjectModel
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Core

'mod 1/23/18 - delete revenues re:every period posted
Friend Class Form1
    Inherits System.Windows.Forms.Form

    Protected m_IsInitializing As Boolean
    Protected ReadOnly Property IsInitializing() As Boolean
        Get
            Return m_IsInitializing
        End Get
    End Property
    Class ProfileFreq
        Inherits SolomonDataObject
        < _
  DataBinding(PropertyIndex:=0) _
             > _
        Public Property FromFreq() As Short

            Get
                Return Me.GetPropertyValue("FromFreq")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("FromFreq", setval)
            End Set

        End Property
        < _
DataBinding(PropertyIndex:=1) _
     > _
        Public Property ToFreq() As Short

            Get
                Return Me.GetPropertyValue("ToFreq")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("ToFreq", setval)
            End Set

        End Property
        < _
DataBinding(PropertyIndex:=2) _
> _
        Public Property BillFreq() As Short

            Get
                Return Me.GetPropertyValue("BillFreq")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("BillFreq", setval)
            End Set

        End Property
    End Class
    Public bProfileFreq As ProfileFreq = New ProfileFreq
    Class Cust
        Inherits SolomonDataObject
        < _
    DataBinding(PropertyIndex:=0, StringSize:=15) _
    > _
        Public Property ID() As String

            Get
                Return Me.GetPropertyValue("ID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ID", setval)
            End Set

        End Property
    End Class
    Dim bcust As Cust = New Cust, ncust As Cust = New Cust  'mod 4/6/17 for profile when user enters cotract'For
    'For Renewals Grid Refresh

    Class WarrantyDur   '8/29/2019 - RMR Changes to add Warranty Duration End Date.
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0) _
        > _
        Public Property User7() As Integer

            Get
                Return Me.GetPropertyValue("User7")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("User7", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=30) _
        > _
        Public Property User1() As String

            Get
                Return Me.GetPropertyValue("User1")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("User1", setval)
            End Set

        End Property
    End Class
    Dim bWarrantyDur As WarrantyDur = New WarrantyDur, nWarrantyDur As WarrantyDur = New WarrantyDur ''8/29/2019 - RMR Changes to add Warranty Duration End Date.
    'For Warranty Duration Grid Refresh  '8/29/2019 - RMR Changes to add Warranty Duration End Date.


    Class RMRContract
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
        > _
        Public Property ID As String

            Get
                Return Me.GetPropertyValue("ID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ID", setval)
            End Set

        End Property
    End Class
    Dim bRMRContract As RMRContract = New RMRContract, nRMRContract As RMRContract = New RMRContract

    Class SelGrid
        Inherits SolomonDataObject
        < _
DataBinding(PropertyIndex:=0) _
   > _
        Public Property Sel() As Short

            Get
                Return Me.GetPropertyValue("Sel")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("Sel", setval)
            End Set

        End Property
    End Class
    Dim bSelGrid As SelGrid = New SelGrid

    ''mod 6/27/2019 - Gridhandle3 for Escalations tab - Solomon Cloud Solutions

    Dim GridHandle1 As Short, Gridhandle2 As Short, GridHandle3 As Short, Maintflag As Short

    'mod 6/27/2019 - Excel Import Button - Solomon Cloud Solutions
    Private Const FirstDataRow As Integer = 14
    Private Const FirstPivotDataRow As Integer = 6
    Private MyServerName As String
    Private MySysDBName As String
    Private MyCoID As String
    Private MyUserID As String
    Private MyPwd As String

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'mod 03/28/17 Process button was not static when shrinking grid
        'mod 7/16/17 - modified getFreqStartDate where Tribridge synched multi contracts and thus start date <> smcontract.startdate
        'mod 7/22/17 - Changes/Deletions for revs.  When warranty item, expecting effect date to update.
        'mod 6/14/18 - changed contractid PV to list only active contracts
        ' Load all the forms needed for this application
        Call LoadForm(FrmMultiDeletes)
        Call LoadForm(FrmMultiAdds)

        ' Initialize the application as a Microsoft Dynamics SL Application
        Call ApplInit()
        Call SetAddr(NOLEVEL, "bkeyid", bKeyid, bKeyid)
        Call SetAddr(NOLEVEL, "bmassup", bMassUp, bMassUp)
        Call SetAddr(NOLEVEL, "bSelected", bselected, PNULL)
        Call SetAddr(NOLEVEL, "bdelSelected", bDelselected, PNULL)
        Call SetAddr(LEVEL0, "bXSVCFILTER", bXSVCFILTER, nXSVCFILTER)
        Call SetAddr(LEVEL1, "bXSVCGrid", bXSVCGRID, nXSVCGRID)   'gridhandle1
        Call SetAddr(LEVEL2, "bXRenew", bXRENEW, nXRENEW) 'gridhandle2
        Call SetAddr(NOLEVEL, "bSelectedRenewals", bselectedRenewals, PNULL)
        Call SetAddr(LEVEL3, "bXMULTIDELETES", bXMULTIDELETES, nXMULTIDELETES)  'mod 3/20/17
        Call SetAddr(NOLEVEL, "btotdel", bTotDel, PNULL)
        Call SetAddr(LEVEL4, "bXMULTIADDS", bXMULTIADDS, nXMULTIADDS)  'mod 3/20/17
        Call SetAddr(NOLEVEL, "bSelGrid", bSelGrid, PNULL)  'mod 3/20/17

        'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
        Call SetAddr(LEVEL5, "bxEscalate", bxEscalate, nxEscalate) 'gridhandle3
        Call SetAddr(NOLEVEL, "bSelectedEscal", bSelectedEscal, PNULL)

        Call SqlCursorEx(CSR_XSVCGrid, LEVEL1 + SqlList + SqlFastReadOnly, "CSR_XSVCGrid", "XSVCGRID", "")
        Call SqlCursorEx(CSR_xRenew, LEVEL2 + SqlList + SqlFastReadOnly, "CSR_XRenew", "XRenew", "")
        Call SqlCursorEx(CSR_xMultiDeletes, LEVEL3 + SqlList, "CSR_xMultiDeletes", "xMultiDeletes", "")
        Call SqlCursorEx(CSR_xMultiAdds, LEVEL4 + SqlList, "CSR_xMultiADDS", "", "")
        Call SqlCursorEx(CSR_SMContract, NOLEVEL, "CSR_SMContract", "SMContract", "SMContract")
        Call SqlCursorEx(CSR_SMContractBill, NOLEVEL, "CSR_SMContractBill", "SMContractBill", "SMContractBill")
        Call SqlCursorEx(CSR_SMContractRev, NOLEVEL, "CSR_SMContractRev", "SMContractRev", "SMContractRev")
        Call SqlCursorEx(CSR_XTB_SMContract, NOLEVEL, "CSR_XTB_SMContract", "XTB_SMContract", "XTB_SMContract")
        Call SqlCursorEx(CSR_XTB_Services, NOLEVEL, "CSR_XTB_Services", "XTB_Services", "XTB_Services")
        Call SqlCursorEx(CSR_Xrenewcontracts, NOLEVEL, "CSR_Xrenewcontracts", "XRENEWCONTRACTS", "XRENEWCONTRACTS")
        Call SqlCursorEx(CSR_XrenewContSvc, NOLEVEL, "CSR_Xrenewcontsvc", "XRENEWCONTsvc", "XRENEWCONTsvc")
        Call SqlCursorEx(CSR_XTBServUpdate, NOLEVEL, "CSR_XTBServUpdate", "", "")

        Call SqlCursorEx(CSR_xSvcUpdHist, NOLEVEL, "CSR_xSrvUpdHist", "XSVCUPDHIST", "XSVCUPDHIST")
        Call SqlCursorEx(CSR_InsertContract, NOLEVEL, "CSR_InsertContract", "", "")
        Call SqlCursorEx(CSR_InsertSvc, NOLEVEL, "CSR_InsertSvs", "", "")
        Call SqlCursorEx(CSR_SynchComment, NOLEVEL + SqlFastReadOnly, "CSR_SynchComment", "", "")

        'mod 4/8/17 for smcontract equipment
        Call SqlCursorEx(CSR_SMSvcEquipment, NOLEVEL, "CSR_SMSvcEquipment", "SMSvcEquipment", "SMSvcEquipment")
        Call SqlCursorEx(CSR_SMConEquipment, NOLEVEL, "CSR_SMConEquipment", "SMConEquipment", "SMConEquipment")
        Call SqlCursorEx(CSR_XTB_InstallBase, NOLEVEL, "CSR_XTB_InstallBase", "XTB_InstallBase", "XTB_InstallBase")
        Call SqlCursorEx(CSR_XTB_EquipReview, NOLEVEL, "CSR_XTB_EquipReview", "XTB_EquipReview", "XTB_EquipReview")
        Call SqlCursorEx(CSR_CreditMonths, NOLEVEL + SqlFastReadOnly, "CSR_CreditMonths", "", "")

        'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
        Call SqlCursorEx(CSR_xEscalate, LEVEL5 + SqlList + SqlFastReadOnly, "CSR_xEscalate", "xEscalate", "")

        Call ScreenInit()

        '  Call SetProps(Me, TabControl1, TabControl1, "TabVisible(1)", False)

        GridHandle1 = DetailSetup(CSR_XSVCGrid, DslGrid1, PNULL, bXSVCGRID, bselected, PNULL, PNULL)
        Gridhandle2 = DetailSetup(CSR_xRenew, DslGrid2, PNULL, bXRENEW, bselectedRenewals, PNULL, PNULL)
        'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
        GridHandle3 = DetailSetup(CSR_xEscalate, sprdEscalate, PNULL, bxEscalate, bSelectedEscal, PNULL, PNULL)

        DelGridHandle = DetailSetup(CSR_xMultiDeletes, FrmMultiDeletes.DslGrid3, PNULL, bXMULTIDELETES, bDelselected, PNULL, PNULL)
        AddGridHandle = DetailSetup(CSR_xMultiAdds, FrmMultiAdds.DslGrid4, PNULL, bXMULTIADDS, PNULL, PNULL, PNULL) 'mod 6/10/11 added linenbr

        Call SetProps(Me, lblservitemsel, txtfrequencyM, PROP_VISIBLE, False)
        Call SetProps(Me, txtInvcFormat, txtInvcFormat, PROP_VISIBLE, False)
        Call SetProps(Me, txtInvoiceRule, txtInvoiceRule, PROP_VISIBLE, False)

        Call SetProps(Me, chkMaintAmt, chkMaintAmt, PROP_VISIBLE, False)
        Call SetProps(Me, chkMonitAmt, chkMonitAmt, PROP_VISIBLE, False)

        Call SetProps(Me, txtMaintAmt, txtMaintAmt, PROP_VISIBLE, False)
        Call SetProps(Me, txtMonitAmt, txtMonitAmt, PROP_VISIBLE, False)

        Call SetButton(TbInsertButton + TbDeleteButton + TbSaveButton, AllLevels, False)
        Call SetButton(TbInsertButton + TbDeleteButton, LEVEL4, True)
        Call SetProps(Me, lbldelinfo, lbldelinfo, PROP_VISIBLE, False)
        Call SetProps(Me, BtnAddDel, BtnAddDel, PROP_VISIBLE, False)
        Call GetSysDate(Curdate)
        CurUser = bpes.UserId
        CurProg = "XSVCUPD"

        'mod 1/4/17  - for other changes Posting Date Mod
        Dim CSR_arsetup As Short, YY, MM As String, TestDatestr As String = ""
        Call SqlCursor(CSR_arsetup, NOLEVEL)
        SQLstmt = "arsetup_all"
        serr1 = SqlFetch1(c1, SQLstmt, bARSetup)
        Call SqlFree(CSR_arsetup)

        YY = vb.Left(bARSetup.CurrPerNbr, 4)
        MM = vb.Right(bARSetup.CurrPerNbr.Trim, 2)
        Call StrToDate(MM + "/01/" + YY, RevARDate)
        Call DatePlusMonthSetDay(RevARDate, 0, 4, BillARDate)
        Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)


        'Create an instance of the S4DBConnect class
        Dim SysDatabase As New Microsoft.Dynamics.SL.AS.DevObj.S4DBConnect
        'Obtain connection information for the System Database
        SysDatabase.S4Server = bpes.DBServer
        SysDatabase.S4Database = bpes.DBNameSystem
        SysDatabase.S4Company = bpes.CpnyID
        SysDatabase.S4User = bpes.UserId
        SysDatabase.S4Password = ""
        SysDatabase.S4DBOpen()

        'mod 5/24/19 - Add app server compatability - Solomon Cloud Solutions
        If IS_AppServer <> 0 Then
            Call SetObjectValue(txtkeyid, 10)
            Call SetObjectValue(txtexpiredatebeg, Date.Today)
            Call SetObjectValue(txtexpiredateend, Date.Today)
            Call SetObjectValue(txtrenewaltype, "MY")
            btnRefreshGrid_Click(eventSender, eventArgs)
            btnselect_Click(eventSender, eventArgs)
            cBegProcessing_Click(eventSender, eventArgs)
            Call ScreenExit("", "")
        End If

    End Sub
    Private Sub txtkeyid_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtkeyid.ChkEvent
        ' doRefresh()
        bXSVCFILTER.CopyClass(nXSVCFILTER)  'mod 11/14/16
        Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)
        lblrefresh.Text = ""
        txtrmramtM.Min = 0
        lblprofile.Text = ""  'mod 4/6/17
        lblRefreshWarn.Text = ""
        '  lblsystemtype.Text = ""
        Call SetProps(Me, txtsiteid, txtservitemid, PROP_ENABLED, True)  'mod 4/6/17
        Call SetProps(Me, txtSystemType, txtSystemType, PROP_VISIBLE, False) 'mod 4/8/17
        lblsystemtype.Text = ""
        Call SetProps(Me, lblhide, lblhide, PROP_VISIBLE, False) 'had to add this dummy label to hide the grpchangeservitem.  Could not hide grpbox during screen init
        Call SetProps(Me, lbldelinfo, lbldelinfo, PROP_VISIBLE, False)
        Call SetProps(Me, lblservitemsel, txtfrequencyM, PROP_VISIBLE, False)
        Call SetProps(Me, txtInvcFormat, txtInvcFormat, PROP_VISIBLE, False)
        Call SetProps(Me, txtInvoiceRule, txtInvoiceRule, PROP_VISIBLE, False)
        Call SetProps(Me, txtBranch, txtContractProfile, PROP_VISIBLE, False)  'mod 3/18/17
        Call SetProps(Me, grpChangeServItem, grpChangeServItem, PROP_VISIBLE, False)  'mod 3/19/17
        Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_ENABLED, True)
        Call SetProps(Me, BtnAddDel, BtnAddDel, PROP_VISIBLE, False)
        'mod 6/27/2019 - Excel Import Button - Solomon Cloud Solutions
        Call SetProps(Me, btnImport, btnImport, PROP_VISIBLE, False)
        Call SetProps(Me, btnImport, btnImport, PROP_ENABLED, False)
        'mod 7/11/2019 - Enable refresh button on key id change - Solomon Cloud Solutions
        Call SetProps(Me, btnRefreshGrid, btnRefreshGrid, PROP_ENABLED, LTRUE)

        Call SetProps(Me, chkMaintAmt, chkMaintAmt, PROP_VISIBLE, False)
        Call SetProps(Me, chkMaintAmt, chkMaintAmt, PROP_ENABLED, False)
        Call SetProps(Me, chkMonitAmt, chkMonitAmt, PROP_VISIBLE, False)
        Call SetProps(Me, chkMonitAmt, chkMonitAmt, PROP_ENABLED, False)

        Call SetProps(Me, txtMaintAmt, txtMaintAmt, PROP_VISIBLE, False)
        Call SetProps(Me, txtMaintAmt, txtMaintAmt, PROP_ENABLED, False)
        Call SetProps(Me, txtMonitAmt, txtMonitAmt, PROP_VISIBLE, False)
        Call SetProps(Me, txtMonitAmt, txtMonitAmt, PROP_ENABLED, False)

        Call MClear(DelGridHandle)
        lblcancel.Text = ""
        lblbranchdesc.Text = ""
        '   Call SetProps(Me, txtexpiredatebeg, txtexpiredateend, PROP_BLANKERR, False)   'NOT WORKING
        Call SetProps(Me, GrpContEndDate, GrpContEndDate, PROP_CAPTION, "Contract End Date")
        bKeyid.ID = ChkStrg
        lblMassAmt.Text = "Monthly RMR Amount"
        GrpFilters.Text = "Filters && Options  (press F5 to clear a field)"
        bXSVCFILTER.RenewalType = "" 'mod 10/17/17
        Call SetProps(Me, txtrenewaltype, txtrenewaltype, PROP_ENABLED, False)
        Select Case ChkStrg
            Case 1   'ADD
                '   btnRefreshGrid.PerformClick()
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, True)
                'Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, True)
                Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, True)
                bMassUp.CopyClass(nMassUp)
                lblprofile.Text = "Enter ContractID for Multiple Additions"
                Call SetProps(Me, txtSystemType, txtSystemType, PROP_VISIBLE, True)
                lblsystemtype.Text = "System Type (Required)"
            Case 2 'DELETE
                Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, True)
                'Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, True)
                Call SetProps(Me, lblcancelA, lblcancel, PROP_VISIBLE, True)
                Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, False)
                bMassUp.CopyClass(nMassUp)
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Existing
                lblprofile.Text = "Enter ContractID for Multiple Deletion(s)"
                BtnAddDel.Text = "Delete Multiple Service Items" 'mod 10/28/17
            Case 3 'CHANGE
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, grpChangeServItem, grpChangeServItem, PROP_VISIBLE, True)  'mod 3/19/17
                Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, True)
                'Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, True)
                Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, True)
                Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_ENABLED, False)
                bMassUp.CopyClass(nMassUp)
                lblMassAmt.Text = ""  'mod 12/5/16
            Case 4  'START DATE
                'Call MessBox("Feature in Process", 48, "MassUpdate Message")              '5/30/2019 Change Start and End Dates
                MClear(GridHandle1)                                                        '5/30/2019 Change Start and End Dates
                Me.TabControl1.SelectedTab = Existing                                      '5/30/2019 Change Start and End Dates
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, True)     '5/30/2019 Change Start and End Dates
                Call SetProps(Me, txtcontractstartdate, txtcontractstartdate, PROP_VISIBLE, True)
                bMassUp.CopyClass(nMassUp)                                                 '5/30/2019 Change Start and End Dates
                lblChange.Text = "Contract Start Date"                                     '5/30/2019 Change Start and End Dates
            Case 5 'END DATE 
                'Call MessBox("Feature in Process", 48, "MassUpdate Message")              '5/30/2019 Change Start and End Dates
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, True)
                Call SetProps(Me, txtcontractEndDate, txtcontractEndDate, PROP_VISIBLE, True)
                bMassUp.CopyClass(nMassUp)
                lblChange.Text = "Contract End Date"
            Case 6 'FREQUENCY
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, True)
                Call SetProps(Me, txtfrequencyM, txtfrequencyM, PROP_VISIBLE, True)
                'Call SetProps(Me, lbleffectdate, txteffectdateM, PROP_VISIBLE, True) 'mod 2/17/17         '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                bMassUp.CopyClass(nMassUp)
                lblChange.Text = "Bill Frequency"
            Case 7 'BRANCH
                MClear(GridHandle1)
                lblChange.Text = "Destination Branch ID"
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, True)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, txtBranch, lblbranchdesc, PROP_VISIBLE, True)
            Case 8 'Billwith Contract Profile
                MClear(GridHandle1)
                'mod 4/6/17
                lblprofile.Text = "Please enter CustomerID OR ContractID"
                Call SetProps(Me, txtsiteid, txtservitemid, PROP_ENABLED, False)
                Call SetProps(Me, contidlbl, txtcontid, PROP_ENABLED, True)
                lblChange.Text = "To Billwith Contract Profile - enter NONE to remove the profile"
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, True)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, txtBillwithContractProfile, txtBillwithContractProfile, PROP_VISIBLE, True)
            Case 9 'Contract Profile           
                MClear(GridHandle1)
                'mod 4/6/17
                lblprofile.Text = "Please enter CustomerID OR ContractID"
                Call SetProps(Me, txtsiteid, txtservitemid, PROP_ENABLED, False)
                Call SetProps(Me, contidlbl, txtcontid, PROP_ENABLED, True)
                lblChange.Text = "To Contract Profile"
                'mod 3/18/17
                Me.TabControl1.SelectedTab = Existing
                '   If bXSVCFILTER.Custid.Trim > "" Then   mod 4/3/17             
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, True)
                Call SetProps(Me, txtContractProfile, txtContractProfile, PROP_VISIBLE, True)
                ' End If
            Case 10 'RENEWALS 
                'mod 6/9/17
                SQLstmt = "xRenewDelete_byuserid" + SParm(bpes.UserId) '&&&&
                Call sql(c8, SQLstmt)
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Renewals
                Call SetProps(Me, GrpContEndDate, GrpContEndDate, PROP_CAPTION, "Contract End Date (Required)")
                'mod 10/17/17
                bMassUp.CopyClass(nMassUp)
                bXSVCFILTER.RenewalType = "MY" 'mod 10/17/17
                Call SetProps(Me, txtrenewaltype, txtrenewaltype, PROP_ENABLED, True)
            Case 11 'Invoice Format
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, True)
                Call SetProps(Me, txtInvcFormat, txtInvcFormat, PROP_VISIBLE, True)
                bMassUp.CopyClass(nMassUp)
                lblChange.Text = "Service Billing Invoice Type"
            Case 12 'Invoice Rules
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, True)
                Call SetProps(Me, txtInvoiceRule, txtInvoiceRule, PROP_VISIBLE, True)
                bMassUp.CopyClass(nMassUp)
                lblChange.Text = "Invoicing Rule Type"
            Case 13 'Warranty Duration
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Existing
                Call SetProps(Me, lblChange, lblChange, PROP_VISIBLE, False)
                lblprofile.Text = ""
                Call SetProps(Me, grpWarranty, grpWarranty, PROP_VISIBLE, True)
                Call SetProps(Me, Label36, Label36, PROP_VISIBLE, True)
                Call SetProps(Me, Label38, Label38, PROP_VISIBLE, True)
                Call SetProps(Me, Label37, Label37, PROP_VISIBLE, True)
                Call SetProps(Me, txtwarrantystartdate, txtwarrantystartdate, PROP_VISIBLE, True)
                Call SetProps(Me, txtdurationA, txtdurationA, PROP_VISIBLE, True)
                Call SetProps(Me, txtwarrantyenddate, txtwarrantyenddate, PROP_VISIBLE, True)
                bMassUp.CopyClass(nMassUp)
                lblChange.Text = ""
                'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
            Case 14 'Escalations
                'mod 6/9/17
                SQLstmt = "xRenewDelete_byuserid" + SParm(bpes.UserId) '&&&&
                Call sql(c8, SQLstmt)
                MClear(GridHandle1)
                Me.TabControl1.SelectedTab = Escalations
                Call SetProps(Me, GrpContEndDate, GrpContEndDate, PROP_CAPTION, "Contract End Date (Required)")
                Call SetProps(Me, btnImport, btnImport, PROP_VISIBLE, True)
                'mod 10/17/17
                bMassUp.CopyClass(nMassUp)
                Call SetProps(Me, txtrenewaltype, txtrenewaltype, PROP_ENABLED, True)
                Call SetProps(Me, txtrenewaltype, txtrenewaltype, PROP_ENABLED, False)
            Case 15 'Change All Monitor/Maint Items
                Me.TabControl1.SelectedTab = Existing
                MClear(GridHandle1)
                Call SetProps(Me, chkMaintAmt, chkMaintAmt, PROP_VISIBLE, True)
                Call SetProps(Me, chkMaintAmt, chkMaintAmt, PROP_ENABLED, True)
                Call SetProps(Me, chkMonitAmt, chkMonitAmt, PROP_VISIBLE, True)
                Call SetProps(Me, chkMonitAmt, chkMonitAmt, PROP_ENABLED, True)

                Call SetProps(Me, txtMaintAmt, txtMaintAmt, PROP_VISIBLE, True)
                Call SetProps(Me, txtMaintAmt, txtMaintAmt, PROP_ENABLED, False)
                Call SetProps(Me, txtMonitAmt, txtMonitAmt, PROP_VISIBLE, True)
                Call SetProps(Me, txtMonitAmt, txtMonitAmt, PROP_ENABLED, False)

                Call SetProps(Me, grpChangeServItem, grpChangeServItem, PROP_VISIBLE, True)
                Call SetProps(Me, lbleffectdate, txteffectdateM, PROP_VISIBLE, True)

                bMassUp.CopyClass(nMassUp)
                lblMassAmt.Text = ""
        End Select

        Call DispFields(Me, PNULL, PNULL)
        Call SetButton(TbInsertButton + TbDeleteButton, LEVEL3, False)
    End Sub


    Private Sub btnRefreshGrid_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshGrid.Click

        Dim Custid, SiteID, ContractID, BranchID, ServItemID, MasterID As String, TBMasterid As String, Parentid As String
        Dim StartDateBeg, StartDateEnd, EndDateBeg, EndDateEnd As Integer, UpdateType As String = "", RMRNewAmt As Double
        Dim MaintNewAmt As Double, MonitNewAmt As Double  '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
        Dim numrecs As Integer = 0, Contract As String = "", NumContracts As Short
        Dim InvFormatID As String
        Dim InvRule As String
        Dim SumMaint As Double, SumMonit As Double, RMRMaintNew As Double, RMRMonitNew As Double
        Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)
        Call MClear(GridHandle1)
        Call MClear(Gridhandle2)
        Dim xtbServiceAmtPct As Double
        Dim xtbServGroupCode As String
        Dim AddNewRMRAmtMaint As String  '10/14/2019 NewRMRAmt, NewMaintAmt and NewMonitAmt not calculating Properly.

        Dim xWarrItem_CSR As Short                      '4/10/2020 Warranty Items added to Table.
        Dim xWarr_Flg As Short                          '4/10/2020 Warranty Items added to Table.

        MaintNewAmt = 0
        MonitNewAmt = 0
        xtbServGroupCode = ""
        'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
        Call MClear(GridHandle3)
        lblRefreshWarn.Text = ""
        If bKeyid.ID = 0 Then
            Call MessBox("Please select a Key ID", 48, "MassUpdate Message")
            Exit Sub
        ElseIf bKeyid.ID = 1 Then 'adds
            If MArrayCnt(AddGridHandle) = 0 Then
                If (bMassUp.EffectDate = 0) Then
                    Call MessBox("Please enter EffectDate", 48, "Massupdate Msg")
                    Exit Sub
                ElseIf bMassUp.SystemType.Trim = "" Then
                    Call MessBox("Please enter System Type", 48, "Massupdate Msg")
                    Exit Sub
                ElseIf bMassUp.ServItemSel.Trim = "" Then
                    Call MessBox("Please enter Service Item", 48, "Massupdate Msg")
                    Exit Sub
                End If
            End If
        ElseIf bKeyid.ID = 2 Then  'delete
            'mods 11/9/17
            bMassUp.RMRAmt = 0 'mod 6/8/17 insure that amt is blank for recalcs of New RMRAmt
            With bXSVCFILTER
                If .BranchID.Trim = "" And .ContractID.Trim = "" And .Custid.Trim = "" And .ExpireDateBeg = 0 And .ExpireDateEnd = 0 And .MasterID.Trim = "" _
                And .ParentID.Trim = "" And .ServItemID.Trim = "" And .Siteid.Trim = "" And .StartDateBeg = 0 And .StartDateEnd = 0 And .TBMasterid.Trim = "" Then
                    Call MessBox("For Deletes - Please enter at least one filter", 48, "Massupdate Msg")
                    Exit Sub
                End If
                If bTotDel.Total = 0 And (bMassUp.EffectDate = 0 Or bMassUp.CancelCode.Trim = "" Or bMassUp.ServItemSel.Trim = "") Then
                    Call MessBox("Please enter Service Item, EffectDate and Cancellation Code", 48, "Massupdate Msg")
                    Exit Sub
                End If
            End With
            'mod 11/10/17
        ElseIf bKeyid.ID = 3 Then 'changes
            If bMassUp.ServItemSel.Trim = "" Or bMassUp.RMRAmt = 0 Or bMassUp.EffectDate = 0 Then
                Call MessBox("Please enter Service Item, RMR Amount and Effective Date", 48, "Massupdate Msg")
                Exit Sub
            End If
        ElseIf bKeyid.ID = 7 And bMassUp.Branch.Trim = "" Then
            Call MessBox("Please enter the Destination Branch ID", 48, "Massupdate Msg")
            Exit Sub
        ElseIf bKeyid.ID = 8 And bMassUp.BillwithContractProfile.Trim = "" Then
            Call MessBox("Please enter the To Billwith Contract Profile", 48, "Massupdate Msg")
            Exit Sub
        ElseIf (bKeyid.ID = 8 Or bKeyid.ID = 9) And (bXSVCFILTER.Custid.Trim = "" And bXSVCFILTER.ContractID.Trim = "") Then
            Call MessBox("Please enter Customer ID or Contract ID", 48, "Massupdate Msg")
            Exit Sub
        ElseIf bKeyid.ID = 9 And bMassUp.ContractProfile.Trim = "" Then
            Call MessBox("Please enter the To Contract Profile", 48, "Massupdate Msg")
            Exit Sub
        ElseIf bKeyid.ID = 10 And (DateCmp(bXSVCFILTER.ExpireDateBeg, NULLDATE) = 0 Or DateCmp(bXSVCFILTER.ExpireDateEnd, NULLDATE) = 0) Then
            Call MessBox("Please enter Contract End Date", 48, "Massupdate Msg")
            Exit Sub
        ElseIf bKeyid.ID = 11 And txtInvcFormat.Text.Trim = "" Then
            Call MessBox("Please enter Invoice Format", 48, "Massupdate Msg")
            Exit Sub
        ElseIf bKeyid.ID = 12 And bMassUp.InvoicingRule.Trim = "" Then
            Call MessBox("Please enter Invoice Rule", 48, "Massupdate Msg")
            Exit Sub
        ElseIf bKeyid.ID = 13 And (bMassUp.Duration.Trim = "" Or bMassUp.WarrantyStartDate = 0) Then
            Call MessBox("Please enter Warranty Duration and Start Date", 48, "Massupdate Msg")
            Exit Sub
        ElseIf bKeyid.ID = 14 And (DateCmp(bXSVCFILTER.ExpireDateBeg, NULLDATE) = 0 Or DateCmp(bXSVCFILTER.ExpireDateEnd, NULLDATE) = 0) Then
            Call MessBox("Please enter Contract End Date", 48, "Massupdate Msg")
            Exit Sub
        ElseIf bKeyid.ID = 15 Then 'Change Maint/Monit
            If (chkMaintAmt.Checked = True And bMassUp.MaintAmt = 0) Or (chkMonitAmt.Checked = True And bMassUp.MonitAmt = 0) Or bMassUp.EffectDate = 0 Then
                Call MessBox("Please enter RMR Amount(s) and Effective Date", 48, "Massupdate Msg")
                Exit Sub
            End If
        End If
        Call SetProps(Me, lblrefresh, lblrefresh, PROP_CAPTION, "")

        MSet(txtselected, 0)

        If (bXSVCFILTER.Custid.Trim = "") Then
            Custid = SQLWILDSTRING
        Else
            Custid = bXSVCFILTER.Custid
        End If

        If (bXSVCFILTER.Siteid.Trim = "") Then
            SiteID = SQLWILDSTRING
        Else
            SiteID = bXSVCFILTER.Siteid
        End If

        If (bXSVCFILTER.ContractID.Trim = "") Then
            ContractID = SQLWILDSTRING
        Else
            ContractID = bXSVCFILTER.ContractID
        End If

        If (bXSVCFILTER.BranchID.Trim = "") Then
            BranchID = SQLWILDSTRING
        Else
            BranchID = bXSVCFILTER.BranchID
        End If

        If DateCmp(bXSVCFILTER.StartDateBeg, NULLDATE) = 0 Then
            StartDateBeg = NULLDATE
        Else
            StartDateBeg = bXSVCFILTER.StartDateBeg
        End If

        If DateCmp(bXSVCFILTER.StartDateEnd, NULLDATE) = 0 Then
            Call StrToDate("01/01/2057", StartDateEnd)
        Else
            StartDateEnd = bXSVCFILTER.StartDateEnd
        End If

        If DateCmp(bXSVCFILTER.ExpireDateBeg, NULLDATE) = 0 Then
            EndDateBeg = NULLDATE
        Else
            EndDateBeg = bXSVCFILTER.ExpireDateBeg
        End If
        If DateCmp(bXSVCFILTER.ExpireDateEnd, NULLDATE) = 0 Then
            Call StrToDate("01/01/2057", EndDateEnd)
        Else
            EndDateEnd = bXSVCFILTER.ExpireDateEnd
        End If

        If (bXSVCFILTER.ServItemID.Trim = "") Then
            ServItemID = SQLWILDSTRING
        Else
            ServItemID = bXSVCFILTER.ServItemID
        End If

        If (bXSVCFILTER.MasterID.Trim = "") Then
            MasterID = SQLWILDSTRING
        Else
            MasterID = bXSVCFILTER.MasterID
        End If
        If (bXSVCFILTER.TBMasterid.Trim = "") Then
            TBMasterid = SQLWILDSTRING
        Else
            TBMasterid = bXSVCFILTER.TBMasterid
        End If
        If (bXSVCFILTER.ParentID.Trim = "") Then
            Parentid = SQLWILDSTRING
        Else
            Parentid = bXSVCFILTER.ParentID
        End If
        If (bMassUp.InvoiceFormatID.Trim = "") Then
            InvFormatID = ""
        Else
            InvFormatID = bMassUp.InvoiceFormatID.Trim
        End If
        If (bMassUp.InvoicingRule.Trim = "") Then
            InvRule = ""
        Else
            InvRule = bMassUp.InvoicingRule.Trim
        End If

        Select Case bKeyid.ID
            Case 1 To 3
                RMRNewAmt = bMassUp.RMRAmt 'mod 6/4/17

                If Trim$(bMassUp.ServItemSel) = "" Then
                    MaintNewAmt = 0
                    MonitNewAmt = 0
                Else
                    SQLstmt = "XSVCUPD_Get_GroupCode_NOContract" + SParm(bMassUp.ServItemSel)                  '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                    serr6 = SqlFetch1(c6, SQLstmt, xtbServGroupCode)                                           '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                    If Trim$(xtbServGroupCode) = "MONITORING" Then                                             '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                        MonitNewAmt = bMassUp.RMRAmt                                                           '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                    Else
                        MaintNewAmt = bMassUp.RMRAmt
                    End If                                                                                     '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                End If

                Select Case bKeyid.ID
                    Case 1
                        UpdateType = "A"
                        'mod 6/4/17
                        If MArrayCnt(AddGridHandle) > 0 Then
                            RMRNewAmt = 0
                            MaintNewAmt = 0
                            MonitNewAmt = 0
                            serr1 = MFirst(AddGridHandle, Maintflag)
                            Do While serr1 = 0
                                RMRNewAmt = FPAdd(RMRNewAmt, bXMULTIADDS.RMRAmt, 2)
                                SQLstmt = "XSVCUPD_Get_GroupCode_NOContract" + SParm(bXMULTIADDS.ServItemID)               '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                                serr6 = SqlFetch1(c6, SQLstmt, xtbServGroupCode)                                           '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.                                                                 
                                If Trim$(xtbServGroupCode) = "MONITORING" Then                                             '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                                    MonitNewAmt = FPAdd(MonitNewAmt, bXMULTIADDS.RMRAmt, 2)                                '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                                Else
                                    MaintNewAmt = FPAdd(MaintNewAmt, bXMULTIADDS.RMRAmt, 2)
                                End If                                                                                     '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                                serr1 = MNext(AddGridHandle, Maintflag)
                            Loop
                            serr1 = MFirst(AddGridHandle, Maintflag)
                            Call MDisplay(AddGridHandle)
                        End If
                    Case 2
                        UpdateType = "D"
                    Case 3
                        UpdateType = "C"
                End Select

                If bKeyid.ID = 2 And bTotDel.Total > 0 Then
                    'get NewRMRAMt mod 6/4/17
                    RMRNewAmt = 0
                    MaintNewAmt = 0  '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                    MonitNewAmt = 0  '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                    serr1 = MFirst(DelGridHandle, Maintflag)
                    Do While serr1 = 0
                        If bDelselected.Value = 1 Then
                            SQLstmt = "XSVCUPD_Get_GroupCode_NOContract" + SParm(bXMULTIDELETES.ServItemID)  '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                            serr6 = SqlFetch1(c6, SQLstmt, xtbServGroupCode)                                 '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                            RMRNewAmt = FPAdd(RMRNewAmt, bXMULTIDELETES.RMRAmt, 2)                                                                        '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                            If Trim$(xtbServGroupCode) = "MONITORING" Then                                   '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                                MonitNewAmt = FPAdd(MonitNewAmt, bXMULTIDELETES.RMRAmt, 2)                   '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                            Else
                                MaintNewAmt = FPAdd(MaintNewAmt, bXMULTIDELETES.RMRAmt, 2)
                            End If                                                                           '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                        End If
                        serr1 = MNext(DelGridHandle, Maintflag)
                    Loop
                    serr1 = MFirst(DelGridHandle, Maintflag)
                    Call MDisplay(DelGridHandle)
                    'SQLstmt = "XSVCUPD_AddDel_byContract" + SParm(ContractID) + FParm(RMRNewAmt)                                                  '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                    SQLstmt = "XSVCUPD_AddDel_byContract_NewAmts" + SParm(ContractID) + FParm(RMRNewAmt) + FParm(MaintNewAmt) + FParm(MonitNewAmt) '10/4/2019  Calculationg NewMonitoring and NewMaintAmt fields.
                    Call sql(CSR_XSVCGrid, SQLstmt)
                    Call MLoad(GridHandle1, CSR_XSVCGrid)
                    Me.TabControl1.SelectedTab = Existing
                    Call MDisplay(GridHandle1)
                Else
                    '10/4/2019 Changing Stored proc from XSVCUPD_ALL to XSVCUPD_ALL2
                    'SQLstmt = "XSVCUPD_ALL2" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                    '    + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid) + SParm(bMassUp.ServItemSel) + SParm(UpdateType) + FParm(RMRNewAmt) 'Mod 11/11/16, 11/20/16
                    'SQLstmt = "XSVCUPD_ALL2" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                    '    + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid) + SParm(bMassUp.ServItemSel) + SParm(UpdateType) + FParm(RMRNewAmt) + FParm(MaintNewAmt) + FParm(MonitNewAmt) 'Mod 11/11/16, 11/20/16
                    If (bKeyid.ID = 3 And ChangeRMRAmtOpt = 2) Or (bKeyid.ID = 3 And ChangeRMRAmtOpt = 3) Then  '10/14/2019 NewRMRAmt, NewMaintAmt and NewMonitAmt not calculating Properly.
                        AddNewRMRAmtMaint = "N"                                                                 '10/14/2019 NewRMRAmt, NewMaintAmt and NewMonitAmt not calculating Properly.
                    Else                                                                                        '10/14/2019 NewRMRAmt, NewMaintAmt and NewMonitAmt not calculating Properly.
                        AddNewRMRAmtMaint = "Y"                                                                 '10/14/2019 NewRMRAmt, NewMaintAmt and NewMonitAmt not calculating Properly.
                    End If                                                                                      '10/14/2019 NewRMRAmt, NewMaintAmt and NewMonitAmt not calculating Properly.
                    SQLstmt = "XSVCUPD_ALL2" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                        + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) _
                        + SParm(Parentid) + SParm(bMassUp.ServItemSel) + SParm(UpdateType) + FParm(RMRNewAmt) + FParm(MaintNewAmt) + FParm(MonitNewAmt) + SParm(AddNewRMRAmtMaint) '10/14/2019 NewRMRAmt, NewMaintAmt and NewMonitAmt not calculating Properly. 'Mod 11/11/16, 11/20/16 
                    Call sql(CSR_XSVCGrid, SQLstmt)
                    Call MLoad(GridHandle1, CSR_XSVCGrid)
                    Me.TabControl1.SelectedTab = Existing
                    Call MDisplay(GridHandle1)
                    If bKeyid.ID = 2 Or bKeyid.ID = 3 Or bKeyid.ID = 15 Then
                        Call SetProps(Me, lbldelinfo, lbldelinfo, PROP_VISIBLE, True)
                    Else
                        Call SetProps(Me, lbldelinfo, lbldelinfo, PROP_VISIBLE, False)
                    End If
                    ''mod 11/11/17   THIS IS ONLY FOR REVERSALS -- UNCOMMENT WHEN REVERSALS IN PLACE
                    If bKeyid.ID = 2 Or (bKeyid.ID = 1 And MArrayCnt(AddGridHandle) = 0) Or (bKeyid.ID = 2 And bTotDel.Total = 0) Then
                        Dim ActualEffectDate As Integer = Math.Max(bMassUp.EffectDate, IIf(Val(bMassUp.Duration) > 0, bMassUp.WarrantyEndDate + 1, 0))
                        Dim kind As String = ""
                        lblRefreshWarn.Text = ""
                        Contract = ""
                        serr1 = MFirst(GridHandle1, Maintflag)
                        Do While serr1 = 0
                            numrecs = 0
                            Select Case bKeyid.ID
                                Case 1
                                    If gReversalWarning("Additions", ActualEffectDate, 0) Then Contract += bXSVCGRID.ContractID.Trim + ","
                                    kind = "Additions"
                                Case 2
                                    If gReversalWarning("Cancels", ActualEffectDate, 0) Then Contract += bXSVCGRID.ContractID.Trim + ","
                                    kind = "Cancels"
                                Case 3
                                    If gReversalWarning("Changes", ActualEffectDate, 0) Then Contract += bXSVCGRID.ContractID.Trim + ","
                                    kind = "Changes"
                            End Select
                            serr1 = MNext(GridHandle1, Maintflag)
                        Loop
                        If Contract.Trim > "" Then
                            Contract = Contract.Trim
                            Contract = vb.Left(Contract, Len(Contract) - 1)
                            lblRefreshWarn.Text = "These contracts cannot process " + kind.Trim + " as there are reversals on or after Effect Date AND not all subsequent processed Invoices have been reversed:" + vbCrLf + Contract
                        End If
                        serr1 = MFirst(GridHandle1, Maintflag)
                        Call MDisplay(GridHandle1)
                    End If
                    'mod 6/7/17
                    If bKeyid.ID = 2 Or (bKeyid.ID = 3 And ChangeRMRAmtOpt = 2) Or (bKeyid.ID = 3 And ChangeRMRAmtOpt = 3) Then
                        SQLstmt = "XSVCUPD_Get_GroupCode" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel)
                        serr6 = SqlFetch1(c6, SQLstmt, xtbServGroupCode)

                        'note deletes (2) would have 0 bmassup.rmramt
                        serr1 = MFirst(GridHandle1, Maintflag)
                        Do While serr1 = 0
                            SQLstmt = "xGet_NewRMRAmt" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel)
                            serr5 = SqlFetch1(c5, SQLstmt, RMRNewAmt)
                            If serr5 <> NOTFOUND Then
                                xtbServiceAmtPct = RMRNewAmt
                            Else
                                xtbServiceAmtPct = 0
                            End If
                            RMRNewAmt = FPSub(bMassUp.RMRAmt, RMRNewAmt, 2)
                            If ChangeRMRAmtOpt <> 3 Then
                                bXSVCGRID.NewRMRAmt = FPAdd(bXSVCGRID.CurRMRAmt, RMRNewAmt, 2)
                                If Trim$(xtbServGroupCode) = "MONITORING" Then
                                    bXSVCGRID.NewMonitAmt = FPAdd(bXSVCGRID.NewMonitAmt, RMRNewAmt, 2)
                                Else
                                    bXSVCGRID.NewMaintAmt = FPAdd(bXSVCGRID.NewMaintAmt, RMRNewAmt, 2)
                                End If
                            Else
                                bXSVCGRID.NewRMRAmt = FPAdd(bXSVCGRID.CurRMRAmt, FPMult(xtbServiceAmtPct, FPMult(bMassUp.RMRAmt, 0.01, 2), 2), 2)
                                If Trim$(xtbServGroupCode) = "MONITORING" Then
                                    bXSVCGRID.NewMonitAmt = FPAdd(bXSVCGRID.NewMonitAmt, FPMult(xtbServiceAmtPct, FPMult(bMassUp.RMRAmt, 0.01, 2), 2), 2)
                                Else
                                    bXSVCGRID.NewMaintAmt = FPAdd(bXSVCGRID.NewMaintAmt, FPMult(xtbServiceAmtPct, FPMult(bMassUp.RMRAmt, 0.01, 2), 2), 2)
                                End If
                            End If
                            Call MUpdate(GridHandle1)
                            serr1 = MNext(GridHandle1, Maintflag)
                        Loop
                        serr1 = MFirst(GridHandle1, Maintflag)
                        Call MDisplay(GridHandle1)
                    End If
                End If
            Case 4 To 9, 11, 12, 13
                SQLstmt = "XSVCUPD_OtherChanges2" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                   + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid)
                Call sql(CSR_XSVCGrid, SQLstmt)
                Call MLoad(GridHandle1, CSR_XSVCGrid)
                Me.TabControl1.SelectedTab = Existing
                Call MDisplay(GridHandle1)
            Case 10  'RENEWALS
                'mod 7/11/2019 - Filter based on termination date if renewal type is do not renew - Solomon Cloud Solutions
                If bXSVCFILTER.RenewalType.Trim = "QT" Then
                    Dim LastContractid As String = ""
                    Dim User7 As String = ""
                    Dim LastGroup As String = ""
                    Dim LastCustid, LastName, LastInvoicingRule, LastFrequency As String, LastRenewaldate As Integer, LastDuration As Short, LastServices As String
                    Dim LastProfile As String, LastPctMaint, LastPctMonitor As Double  'mod10/15/17
                    '9/26/2019 Putting Renewal Back as before. Dim LastTermDate As Integer 'Mod 9/9/2019 - Solomon Cloud Solutions

                    Call Status(StartProcess, False, "", 0)
                    Call Status(SaveGoodArgVals, False, "Populating Renewal  Grid...", DISP_ONLY)
                    Call sql(c9, "delete from XRenewServicesAbbrev where userid = " + SParm(bpes.UserId))

                    'mod 10/29/16
                    'mod 7/11/2019 - Filter based on termination date if renewal type is do not renew - Solomon Cloud Solutions
                    SQLstmt = "V_xrenewals_Contract_TermDate" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                        + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid) + SParm(bXSVCFILTER.RenewalType) 'mod 10/17/17
                    serr3 = SqlFetch1(c3, SQLstmt, bRMRContract)

                    'The following sqlstmt and process needs to change .. Affecting performance significantly
                    Do While serr3 = 0
                        SQLstmt = "XRENEWALS_XSVCABBREV" + SParm(bRMRContract.ID) + SParm(bpes.UserId)
                        Call sql(c4, SQLstmt)
                        serr3 = SFetch1(c3, bRMRContract)
                    Loop

                    'mod 10/15/17 added profile to grouping
                    'mod 7/11/2019 - Filter based on termination date if renewal type is do not renew - Solomon Cloud Solutions
                    SQLstmt = "V_xRenewals_Grouping_TermDate" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                        + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid) + SParm(bXSVCFILTER.RenewalType)
                    Call sql(c3, SQLstmt)
                    serr3 = SGroupFetch1(c3, bxRenewGroup)
                    LastGroup = bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim  'mod 10/15/17
                    LastCustid = bxRenewGroup.Custid.Trim : LastName = bxRenewGroup.Name.Trim : LastInvoicingRule = bxRenewGroup.InvoicingRule.Trim : LastFrequency = bxRenewGroup.Frequency.Trim : LastRenewaldate = bxRenewGroup.RenewalDate : LastDuration = bxRenewGroup.Duration : LastServices = bxRenewGroup.Services : LastContractid = bxRenewGroup.Contractid
                    LastProfile = bxRenewGroup.Profile : LastPctMaint = bxRenewGroup.PctMaint : LastPctMonitor = bxRenewGroup.PctMonitor 'mod 10/15/17
                    '9/26/2019 Putting Renewal Back as before. Call SqlFetch1(c12, "SELECT User6 FROM xCusConMaster WHERE MasterID = " + SParm(Trim(LastProfile)), LastTermDate) 'Mod 9/9/2019 - Fetch TermDate - Solomon Cloud Solutions
                    '9/26/2019 Putting Renewal Back as before. Call SqlFree(c12) 'Mod 9/9/2019 - Fetch TermDate - Solomon Cloud Solutions
                    If serr3 = 0 Then
                        Do While serr3 = 0
                            If bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim <> LastGroup Then
                                With bXRENEW
                                    .Custid = LastCustid
                                    .Name = LastName
                                    .NumContracts = NumContracts
                                    .InvoicingRule = LastInvoicingRule
                                    .Frequency = LastFrequency
                                    .RenewalDate = LastRenewaldate
                                    '9/26/2019 Putting Renewal Back as before.  .TerminationDate = LastTermDate 'Mod 9/9/2019 - Fetch TermDate - Solomon Cloud Solutions
                                    .Duration = LastDuration
                                    .Profile = LastProfile
                                    .PctMaint = LastPctMaint
                                    .PctMonitor = LastPctMonitor
                                    If numrecs > 1 Then
                                        .SameServices = "N"
                                    Else
                                        .SameServices = "Y"
                                    End If
                                    .MinContractid = LastContractid
                                End With
                                NumContracts = bxRenewGroup.NumContracts
                                numrecs = 1
                                LastGroup = bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim 'mod 10/15/17
                                LastCustid = bxRenewGroup.Custid.Trim : LastName = bxRenewGroup.Name.Trim : LastInvoicingRule = bxRenewGroup.InvoicingRule.Trim : LastFrequency = bxRenewGroup.Frequency.Trim : LastRenewaldate = bxRenewGroup.RenewalDate : LastDuration = bxRenewGroup.Duration : LastServices = bxRenewGroup.Services : LastContractid = bxRenewGroup.Contractid
                                LastProfile = bxRenewGroup.Profile : LastPctMaint = bxRenewGroup.PctMaint : LastPctMonitor = bxRenewGroup.PctMonitor 'mod 10/15/17
                                Call MInsert(Gridhandle2)
                            Else
                                NumContracts += bxRenewGroup.NumContracts
                                numrecs += 1
                            End If
                            serr3 = SGroupFetch1(c3, bxRenewGroup)
                        Loop
                        With bXRENEW
                            .Custid = LastCustid
                            .Name = LastName
                            .NumContracts = NumContracts
                            .InvoicingRule = LastInvoicingRule
                            .Frequency = LastFrequency
                            .RenewalDate = LastRenewaldate
                            '9/26/2019 Putting Renewal Back as before.  .TerminationDate = LastTermDate 'Mod 9/9/2019 - Fetch TermDate - Solomon Cloud Solutions
                            .Duration = LastDuration
                            .Profile = LastProfile
                            .PctMaint = LastPctMaint
                            .PctMonitor = LastPctMonitor
                            If numrecs > 1 Then
                                .SameServices = "N"
                            Else
                                .SameServices = "Y"
                            End If
                            .MinContractid = LastContractid
                        End With
                        Call MInsert(Gridhandle2)
                    End If
                    Me.TabControl1.SelectedTab = Renewals
                    Call MFirst(Gridhandle2, Maintflag)
                    Call MDisplay(Gridhandle2)
                    Call Status(EndProcess, False, "", 0)
                Else
                    Dim LastContractid As String = ""
                    Dim User7 As String = ""
                    Dim LastGroup As String = ""
                    Dim LastCustid, LastName, LastInvoicingRule, LastFrequency As String, LastRenewaldate As Integer, LastDuration As Short, LastServices As String
                    Dim LastProfile As String, LastPctMaint, LastPctMonitor As Double  'mod10/15/17
                    '9/26/2019 Putting Renewal Back as before.  Dim LastTermDate As Integer 'Mod 9/9/2019 - Solomon Cloud Solutions

                    Call Status(StartProcess, False, "", 0)
                    Call Status(SaveGoodArgVals, False, "Populating Renewal  Grid...", DISP_ONLY)
                    Call sql(c9, "delete from XRenewServicesAbbrev where userid = " + SParm(bpes.UserId))

                    'mod 10/29/16
                    SQLstmt = "V_xrenewals_Contract" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                        + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid) + SParm(bXSVCFILTER.RenewalType) 'mod 10/17/17
                    serr3 = SqlFetch1(c3, SQLstmt, bRMRContract)

                    'The following sqlstmt and process needs to change .. Affecting performance significantly
                    Do While serr3 = 0
                        SQLstmt = "XRENEWALS_XSVCABBREV" + SParm(bRMRContract.ID) + SParm(bpes.UserId)
                        Call sql(c4, SQLstmt)
                        serr3 = SFetch1(c3, bRMRContract)
                    Loop

                    'mod 10/15/17 added profile to grouping
                    SQLstmt = "V_xRenewals_Grouping" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                        + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid) + SParm(bXSVCFILTER.RenewalType)
                    Call sql(c3, SQLstmt)
                    serr3 = SGroupFetch1(c3, bxRenewGroup)
                    LastGroup = bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim  'mod 10/15/17
                    LastCustid = bxRenewGroup.Custid.Trim : LastName = bxRenewGroup.Name.Trim : LastInvoicingRule = bxRenewGroup.InvoicingRule.Trim : LastFrequency = bxRenewGroup.Frequency.Trim : LastRenewaldate = bxRenewGroup.RenewalDate : LastDuration = bxRenewGroup.Duration : LastServices = bxRenewGroup.Services : LastContractid = bxRenewGroup.Contractid
                    LastProfile = bxRenewGroup.Profile : LastPctMaint = bxRenewGroup.PctMaint : LastPctMonitor = bxRenewGroup.PctMonitor 'mod 10/15/17
                    '9/26/2019 Putting Renewal Back as before. Call SqlFetch1(c12, "SELECT User6 FROM xCusConMaster WHERE MasterID = " + SParm(Trim(LastProfile)), LastTermDate) 'Mod 9/9/2019 - Fetch TermDate - Solomon Cloud Solutions
                    '9/26/2019 Putting Renewal Back as before. Call SqlFree(c12) 'Mod 9/9/2019 - Fetch TermDate - Solomon Cloud Solutions
                    If serr3 = 0 Then
                        Do While serr3 = 0
                            If bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim <> LastGroup Then
                                With bXRENEW
                                    .Custid = LastCustid
                                    .Name = LastName
                                    .NumContracts = NumContracts
                                    .InvoicingRule = LastInvoicingRule
                                    .Frequency = LastFrequency
                                    .RenewalDate = LastRenewaldate
                                    '9/26/2019 Putting Renewal Back as before.  .TerminationDate = LastTermDate 'Mod 9/9/2019 - Fetch TermDate - Solomon Cloud Solutions
                                    .Duration = LastDuration
                                    .Profile = LastProfile
                                    .PctMaint = LastPctMaint
                                    .PctMonitor = LastPctMonitor
                                    If numrecs > 1 Then
                                        .SameServices = "N"
                                    Else
                                        .SameServices = "Y"
                                    End If
                                    .MinContractid = LastContractid
                                End With
                                NumContracts = bxRenewGroup.NumContracts
                                numrecs = 1
                                LastGroup = bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim 'mod 10/15/17
                                LastCustid = bxRenewGroup.Custid.Trim : LastName = bxRenewGroup.Name.Trim : LastInvoicingRule = bxRenewGroup.InvoicingRule.Trim : LastFrequency = bxRenewGroup.Frequency.Trim : LastRenewaldate = bxRenewGroup.RenewalDate : LastDuration = bxRenewGroup.Duration : LastServices = bxRenewGroup.Services : LastContractid = bxRenewGroup.Contractid
                                LastProfile = bxRenewGroup.Profile : LastPctMaint = bxRenewGroup.PctMaint : LastPctMonitor = bxRenewGroup.PctMonitor 'mod 10/15/17
                                Call MInsert(Gridhandle2)
                            Else
                                NumContracts += bxRenewGroup.NumContracts
                                numrecs += 1
                            End If
                            serr3 = SGroupFetch1(c3, bxRenewGroup)
                        Loop
                        With bXRENEW
                            .Custid = LastCustid
                            .Name = LastName
                            .NumContracts = NumContracts
                            .InvoicingRule = LastInvoicingRule
                            .Frequency = LastFrequency
                            .RenewalDate = LastRenewaldate
                            '9/26/2019 Putting Renewal Back as before.  .TerminationDate = LastTermDate 'Mod 9/9/2019 - Fetch TermDate - Solomon Cloud Solutions
                            .Duration = LastDuration
                            .Profile = LastProfile
                            .PctMaint = LastPctMaint
                            .PctMonitor = LastPctMonitor
                            If numrecs > 1 Then
                                .SameServices = "N"
                            Else
                                .SameServices = "Y"
                            End If
                            .MinContractid = LastContractid
                        End With
                        Call MInsert(Gridhandle2)
                    End If
                    Me.TabControl1.SelectedTab = Renewals
                    Call MFirst(Gridhandle2, Maintflag)
                    Call MDisplay(Gridhandle2)
                    Call Status(EndProcess, False, "", 0)
                End If
                'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
            Case 14
                Dim LastContractid As String = ""
                Dim User7 As String = ""
                Dim LastGroup As String = ""
                Dim LastCustid, LastName, LastInvoicingRule, LastFrequency As String, LastRenewaldate As Integer, LastDuration As Short, LastServices As String
                Dim LastProfile As String, LastPctMaint, LastPctMonitor As Double  'mod10/15/17

                Call Status(StartProcess, False, "", 0)
                Call Status(SaveGoodArgVals, False, "Populating Escalation Grid...", DISP_ONLY)
                Call sql(c9, "delete from XRenewServicesAbbrev where userid = " + SParm(bpes.UserId))

                'mod 10/29/16
                SQLstmt = "V_xrenewals_Contract" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                    + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid) + SParm("%") 'mod 10/17/17
                serr3 = SqlFetch1(c3, SQLstmt, bRMRContract)
                'The following sqlstmt and process needs to change .. Affecting performance significantly
                Do While serr3 = 0
                    SQLstmt = "XRENEWALS_XSVCABBREV" + SParm(bRMRContract.ID) + SParm(bpes.UserId)
                    Call sql(c4, SQLstmt)
                    serr3 = SFetch1(c3, bRMRContract)
                Loop
                'mod 10/15/17 added profile to grouping
                SQLstmt = "V_xRenewals_Grouping" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                    + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid) + SParm("%")
                Call sql(c3, SQLstmt)
                serr3 = SGroupFetch1(c3, bxRenewGroup)
                LastGroup = bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim  'mod 10/15/17
                LastCustid = bxRenewGroup.Custid.Trim : LastName = bxRenewGroup.Name.Trim : LastInvoicingRule = bxRenewGroup.InvoicingRule.Trim : LastFrequency = bxRenewGroup.Frequency.Trim : LastRenewaldate = bxRenewGroup.RenewalDate : LastDuration = bxRenewGroup.Duration : LastServices = bxRenewGroup.Services : LastContractid = bxRenewGroup.Contractid
                LastProfile = bxRenewGroup.Profile : LastPctMaint = bxRenewGroup.PctMaint : LastPctMonitor = bxRenewGroup.PctMonitor 'mod 10/15/17
                If serr3 = 0 Then
                    Do While serr3 = 0
                        If bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim <> LastGroup Then
                            With bxEscalate
                                .Custid = LastCustid
                                .Name = LastName
                                .NumContracts = NumContracts
                                .InvoicingRule = LastInvoicingRule
                                .Frequency = LastFrequency
                                .EscalationDate = LastRenewaldate
                                .Duration = LastDuration
                                .Profile = LastProfile
                                .PctMaint = LastPctMaint
                                .PctMonitor = LastPctMonitor
                                If numrecs > 1 Then
                                    .SameServices = "N"
                                Else
                                    .SameServices = "Y"
                                End If
                                .MinContractid = LastContractid
                            End With
                            NumContracts = bxRenewGroup.NumContracts
                            numrecs = 1
                            LastGroup = bxRenewGroup.Custid.Trim + DParm(bxRenewGroup.RenewalDate).Trim + IParm(bxRenewGroup.Duration).Trim + bxRenewGroup.Frequency.Trim + bxRenewGroup.InvoicingRule.Trim + bxRenewGroup.Profile.Trim 'mod 10/15/17
                            LastCustid = bxRenewGroup.Custid.Trim : LastName = bxRenewGroup.Name.Trim : LastInvoicingRule = bxRenewGroup.InvoicingRule.Trim : LastFrequency = bxRenewGroup.Frequency.Trim : LastRenewaldate = bxRenewGroup.RenewalDate : LastDuration = bxRenewGroup.Duration : LastServices = bxRenewGroup.Services : LastContractid = bxRenewGroup.Contractid
                            LastProfile = bxRenewGroup.Profile : LastPctMaint = bxRenewGroup.PctMaint : LastPctMonitor = bxRenewGroup.PctMonitor 'mod 10/15/17
                            Call MInsert(GridHandle3)
                        Else
                            NumContracts += bxRenewGroup.NumContracts
                            numrecs += 1
                        End If
                        serr3 = SGroupFetch1(c3, bxRenewGroup)
                    Loop
                    With bxEscalate
                        .Custid = LastCustid
                        .Name = LastName
                        .NumContracts = NumContracts
                        .InvoicingRule = LastInvoicingRule
                        .Frequency = LastFrequency
                        .EscalationDate = LastRenewaldate
                        .Duration = LastDuration
                        .Profile = LastProfile
                        .PctMaint = LastPctMaint
                        .PctMonitor = LastPctMonitor
                        If numrecs > 1 Then
                            .SameServices = "N"
                        Else
                            .SameServices = "Y"
                        End If
                        .MinContractid = LastContractid
                    End With
                    Call MInsert(GridHandle3)
                End If
                Me.TabControl1.SelectedTab = Escalations
                Call MFirst(GridHandle3, Maintflag)
                Call MDisplay(GridHandle3)
                Call SetProps(Me, btnImport, btnImport, PROP_ENABLED, True)
                Call Status(EndProcess, False, "", 0)

            Case 15 'mod 09/17/2019 - Solomon Cloud Solutions - Add Mass Monit/Maint changes
                UpdateType = "C"

                SQLstmt = "XSVCUPD_OtherChanges" + SParm(Custid) + SParm(SiteID) + SParm(ContractID) + SParm(BranchID) + DParm(StartDateBeg) _
                    + DParm(StartDateEnd) + DParm(EndDateBeg) + DParm(EndDateEnd) + SParm(ServItemID) + SParm(MasterID) + SParm(TBMasterid) + SParm(Parentid)
                Call sql(CSR_XSVCGrid, SQLstmt)
                Call MLoad(GridHandle1, CSR_XSVCGrid)
                Me.TabControl1.SelectedTab = Existing
                Call MDisplay(GridHandle1)

                serr1 = MFirst(GridHandle1, Maintflag)


                Do While serr1 = 0

                    SumMaint = 0
                    SumMonit = 0
                    SQLstmt = "xGet_NewRMRAmtMaint" + SParm(bXSVCGRID.ContractID)
                    serr5 = SqlFetch1(c5, SQLstmt, SumMaint)
                    SQLstmt = "xGet_NewRMRAmtMonit" + SParm(bXSVCGRID.ContractID)
                    serr6 = SqlFetch1(c6, SQLstmt, SumMonit)

                    RMRMaintNew = SumMaint
                    RMRMonitNew = SumMonit

                    Do While serr5 = 0 Or serr6 = 0
                        If serr5 = 0 Then
                            SumMaint = FPAdd(SumMaint, bMassUp.MaintAmt, 2)
                        End If
                        If serr6 = 0 Then
                            SumMonit = FPAdd(SumMonit, bMassUp.MonitAmt, 2)
                        End If
                        If ChangeRMRAmtOpt = 2 Then
                            If serr5 = 0 Then
                                bXSVCGRID.NewMaintAmt = FPAdd(bXSVCGRID.NewMaintAmt, bMassUp.MaintAmt, 2)
                            End If
                            If serr6 = 0 Then
                                bXSVCGRID.NewMonitAmt = FPAdd(bXSVCGRID.NewMonitAmt, bMassUp.MonitAmt, 2)
                            End If
                        ElseIf ChangeRMRAmtOpt = 3 Then
                            If serr5 = 0 Then
                                bXSVCGRID.NewMaintAmt = FPAdd(bXSVCGRID.NewMaintAmt, FPAdd(RMRMaintNew, FPMult(RMRMaintNew, FPDiv(bMassUp.MaintAmt, 100, 4), 4), 4), 2)
                                'bXSVCGRID.NewMaintAmt = Truncate(bXSVCGRID.NewMaintAmt)
                            End If
                            If serr6 = 0 Then
                                bXSVCGRID.NewMonitAmt = FPAdd(bXSVCGRID.NewMonitAmt, FPAdd(RMRMonitNew, FPMult(RMRMonitNew, FPDiv(bMassUp.MonitAmt, 100, 4), 4), 4), 2)
                                'bXSVCGRID.NewMonitAmt = Truncate(bXSVCGRID.NewMonitAmt)
                            End If
                            Call SqlFree(c4)
                        ElseIf ChangeRMRAmtOpt = 1 Then
                            If serr5 = 0 Then
                                bXSVCGRID.NewMaintAmt = FPAdd(bXSVCGRID.NewMaintAmt, SumMaint, 2)
                            End If
                            If serr6 = 0 Then
                                bXSVCGRID.NewMonitAmt = FPAdd(bXSVCGRID.NewMonitAmt, SumMonit, 2)
                            End If
                        End If
                        serr5 = SFetch1(c5, SumMaint)
                        serr6 = SFetch1(c6, SumMonit)

                        RMRMaintNew = SumMaint
                        RMRMonitNew = SumMonit
                    Loop

                    bXSVCGRID.NewRMRAmt = FPAdd(bXSVCGRID.NewMaintAmt, bXSVCGRID.NewMonitAmt, 2)

                    'Call sql(c4, "xtb_EstRmrAmtTrunc" + SParm(bXSVCGRID.ContractID) + FParm(bMassUp.MaintAmt) + FParm(bMassUp.MonitAmt))
                    'Call SFetch1(c4, bXSVCGRID.NewRMRAmt)
                    'Call SqlFree(c4)
                    Call MUpdate(GridHandle1)
                    serr1 = MNext(GridHandle1, Maintflag)
                Loop
                serr1 = MFirst(GridHandle1, Maintflag)
                Call MDisplay(GridHandle1)

        End Select

        If bKeyid.ID = 1 And MArrayCnt(AddGridHandle) = 0 Then

            'Dim WarrantyItems As New List(Of String)        '4/10/2020 Warranty Items added to Table.
            'Call SqlCursorEx(xWarrItem_CSR, NOLEVEL, "xWarrItem_CSR", "xWarrantyItem", "")                '4/10/2020 Warranty Items added to Table.
            'xWarr_Flg = SqlFetch1(xWarrItem_CSR, "xWarrantyItem_All" + SParm("%"), bxWarrantyItem)        '4/10/2020 Warranty Items added to Table.
            'Do While xWarr_Flg = 0                                                                        '4/10/2020 Warranty Items added to Table.
            '    WarrantyItems.Add(Trim$(bxWarrantyItem.WarrantyItem))                                     '4/10/2020 Warranty Items added to Table.

            '    'Check for another Warranty Item                                                          '4/10/2020 Warranty Items added to Table.
            '    xWarr_Flg = SFetch1(xWarrItem_CSR, bxWarrantyItem)                                        '4/10/2020 Warranty Items added to Table.
            'Loop                                                                                          '4/10/2020 Warranty Items added to Table.
            'Call SqlFree(xWarrItem_CSR)                                                                   '4/10/2020 Warranty Items added to Table.

            Contract = ""
            serr1 = MFirst(GridHandle1, Maintflag)
            Do While serr1 = 0
                numrecs = 0
                'If WarrantyItems.Contains(bMassUp.ServItemSel.Trim) Then                                  '4/10/2020 Warranty Items added to Table.
                Select Case bMassUp.ServItemSel.Trim                                                 '4/10/2020 Warranty Items added to Table.
                    Case "C OPTION A", "CP OPTION A", "CP OPTION D", "CP OPTION D 4 HOUR"            '4/10/2020 Warranty Items added to Table.
                        SQLstmt = "xadd_warrantyLimit" + SParm(bXSVCGRID.ContractID.Trim)
                        serr7 = SqlFetch1(c7, SQLstmt, numrecs)
                        If numrecs Then  'mod 11/12/17 'was if = 1
                            Contract += bXSVCGRID.ContractID.Trim + ","
                        End If
                End Select                                                                           '4/10/2020 Warranty Items added to Table.
                'End If                                                                                    '4/10/2020 Warranty Items added to Table.
                serr1 = MNext(GridHandle1, Maintflag)
            Loop
            If Contract.Trim > "" Then
                lblRefreshWarn.Text = ""
                Contract = Contract.Trim
                Contract = vb.Left(Contract, Len(Contract) - 1)
                lblRefreshWarn.Text = "These contract(s) already have a Warranty covered Maintenance Item:" + vbCrLf + Contract
            End If
            serr1 = MFirst(GridHandle1, Maintflag)
            Call MDisplay(GridHandle1)
        End If
        'mod 9/30/17
        If bKeyid.ID = 2 And bTotDel.Total = 0 Then
            Contract = ""
            serr1 = MFirst(GridHandle1, Maintflag)
            Do While serr1 = 0
                numrecs = 0
                SQLstmt = "select count(*) from xtb_services where contractid = " + SParm(bXSVCGRID.ContractID) + " and status = 'A' and monthamt > 0"
                Call sql(c7, SQLstmt)
                Call SGroupFetch1(c7, numrecs)
                If numrecs = 1 Then
                    Contract += bXSVCGRID.ContractID.Trim + ","
                End If
                serr1 = MNext(GridHandle1, Maintflag)
            Loop
            If Contract.Trim > "" Then
                lblRefreshWarn.Text = ""
                Contract = Contract.Trim
                Contract = vb.Left(Contract, Len(Contract) - 1)
                lblRefreshWarn.Text = "This is the last item with dollar amounts on contract(s): " + Contract + vbCrLf + "If you need to Add an item, Process the Add first - then the Cancel"
            End If
            serr1 = MFirst(GridHandle1, Maintflag)
            Call MDisplay(GridHandle1)
        End If
        If MArrayCnt(GridHandle1) = 1 And bXSVCFILTER.ContractID.Trim > "" Then
            serr9 = MFirst(GridHandle1, Maintflag)
            Call ApplSetfocus(txtselected)
            bselected.Value = 1
            Call DispField(txtselected)
            Call CallChks(Me, txtselected, txtselected, True, True)
            Call MUpdate(GridHandle1)
        ElseIf MArrayCnt(Gridhandle2) = 1 And bXSVCFILTER.ContractID.Trim > "" Then
            serr9 = MFirst(Gridhandle2, Maintflag)
            Call ApplSetfocus(txtSelectedRenewals)
            bselectedRenewals.Value = 1
            Call DispField(txtSelectedRenewals)
            Call CallChks(Me, txtSelectedRenewals, txtSelectedRenewals, True, True)
            Call MUpdate(Gridhandle2)
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'prevent user from moving to another tab
        If bKeyid.ID > 0 Then
            Select Case bKeyid.ID
                Case 1 To 9
                    Me.TabControl1.SelectedTab = Existing
                Case 10
                    Me.TabControl1.SelectedTab = Renewals
                    'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
                Case 14
                    Me.TabControl1.SelectedTab = Escalations
            End Select
        End If
    End Sub

    Private Sub btnselect_Click(sender As System.Object, e As System.EventArgs) Handles btnselect.Click
        Dim Numrecs As Integer = 0
        Dim ActualEffectDate As Integer = Math.Max(bMassUp.EffectDate, IIf(Val(bMassUp.Duration) > 0, bMassUp.WarrantyEndDate + 1, 0))
        Dim xWarrItem_CSR As Short                      '4/10/2020 Warranty Items added to Table.
        Dim xWarr_Flg As Short                          '4/10/2020 Warranty Items added to Table.

        'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
        If bKeyid.ID <> 10 And bKeyid.ID <> 14 Then
            'Dim WarrantyItems As New List(Of String)        '4/10/2020 Warranty Items added to Table.
            'Call SqlCursorEx(xWarrItem_CSR, NOLEVEL, "xWarrItem_CSR", "xWarrantyItem", "")                '4/10/2020 Warranty Items added to Table.
            'xWarr_Flg = SqlFetch1(xWarrItem_CSR, "xWarrantyItem_All" + SParm("%"), bxWarrantyItem)        '4/10/2020 Warranty Items added to Table.
            'Do While xWarr_Flg = 0                                                                        '4/10/2020 Warranty Items added to Table.
            '    WarrantyItems.Add(Trim$(bxWarrantyItem.WarrantyItem))                                     '4/10/2020 Warranty Items added to Table.

            '    'Check for another Warranty Item                                                          '4/10/2020 Warranty Items added to Table.
            '    xWarr_Flg = SFetch1(xWarrItem_CSR, bxWarrantyItem)                                        '4/10/2020 Warranty Items added to Table.
            'Loop                                                                                          '4/10/2020 Warranty Items added to Table.
            'Call SqlFree(xWarrItem_CSR)                                                                   '4/10/2020 Warranty Items added to Table.

            MSet(txtselected, 1)
            bSelGrid.Sel = MArrayCnt(GridHandle1)
            serr1 = MFirst(GridHandle1, Maintflag)
            Do While serr1 = 0
                If bKeyid.ID = 1 Then
                    'If WarrantyItems.Contains(bMassUp.ServItemSel.Trim) Then                                  '4/10/2020 Warranty Items added to Table.
                    Select Case bMassUp.ServItemSel.Trim                                                 '4/10/2020 Warranty Items added to Table.
                        Case "C OPTION A", "CP OPTION A", "CP OPTION D", "CP OPTION D 4 HOUR"            '4/10/2020 Warranty Items added to Table.
                            SQLstmt = "xadd_warrantyLimit" + SParm(bXSVCGRID.ContractID.Trim)
                            serr5 = SqlFetch1(c5, SQLstmt, Numrecs)
                            If Numrecs Then
                                bselected.Value = 0
                                MUpdate(GridHandle1)
                                bSelGrid.Sel -= 1
                            End If
                    End Select                                                                           '4/10/2020 Warranty Items added to Table.
                    'End If                                                                                    '4/10/2020 Warranty Items added to Table.
                End If
                Numrecs = 0
                Select Case bKeyid.ID
                    Case 1
                        If gReversalWarning("Additions", ActualEffectDate, 0) Then
                            bselected.Value = 0
                            MUpdate(GridHandle1)
                            bSelGrid.Sel -= 1
                        End If
                    Case 2
                        If gReversalWarning("Cancels", ActualEffectDate, 0) Then
                            bselected.Value = 0
                            MUpdate(GridHandle1)
                            bSelGrid.Sel -= 1
                        End If
                    Case 3
                        If gReversalWarning("Changes", ActualEffectDate, 0) Then
                            bselected.Value = 0
                            MUpdate(GridHandle1)
                            bSelGrid.Sel -= 1

                        End If
                End Select
                If bKeyid.ID = 5 Then                                                         '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    SQLstmt = "XSVCU00_MasterContractID" + SParm(bXSVCGRID.ContractID.Trim)   '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    serr5 = SqlFetch1(c5, SQLstmt, Numrecs)                                   '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    If Numrecs Then                                                           '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                        bselected.Value = 0                                                   '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                        MUpdate(GridHandle1)                                                  '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                        bSelGrid.Sel -= 1                                                     '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    End If                                                                    '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                End If                                                                        '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                serr1 = MNext(GridHandle1, Maintflag)
            Loop
            serr1 = MFirst(GridHandle1, Maintflag)
            Call MDisplay(GridHandle1)
            If bSelGrid.Sel > 0 Then Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, True)
        ElseIf bKeyid.ID = 10 Then
            MSet(txtSelectedRenewals, 1)
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, True)
            bSelGrid.Sel = MArrayCnt(Gridhandle2)
        ElseIf bKeyid.ID = 14 Then
            MSet(txtSelectedEscalations, 1)
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, True)
            bSelGrid.Sel = MArrayCnt(GridHandle3)
        End If
        'mod 11/10/17
        'If bKeyid.ID < 10 Then
        '    bSelGrid.Sel = MArrayCnt(GridHandle1)
        'Else
        '    bSelGrid.Sel = MArrayCnt(Gridhandle2)
        'End If
        Call DispField(txtSel1)
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        If bKeyid.ID <> 10 And bKeyid.ID <> 14 Then
            MSet(txtselected, 0)
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)
            'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
        ElseIf bKeyid.ID = 10 Then
            MSet(txtSelectedRenewals, 0)
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)
        ElseIf bKeyid.ID = 14 Then
            MSet(txtSelectedEscalations, 0)
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)
        End If
        bSelGrid.Sel = 0
        Call DispField(txtSel1)
    End Sub
    Private Sub btnViewSC_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSC.Click
        'mod 11/29/16 added contractid for xsvcupd contractid filter
        Dim contractid As String = IIf(bXSVCFILTER.ContractID.Trim > "", bXSVCFILTER.ContractID, "%")
        Dim parms As String = ""
        Call MUpdate(Gridhandle2)
        With bXRENEW
            SQLstmt = "delete from xrenewpassit where userid = " + SParm(bpes.UserId)
            Call sql(c8, SQLstmt)
            SQLstmt = "Insert into xrenewpassit Values(" + SParm(.Custid) + "," + SParm(.Name) + "," + IParm(.Duration) + "," + SParm(.InvoicingRule) + "," + SParm(.Frequency) + "," + FParm(bMassUp.RMRAmt) + "," + DParm(.RenewalDate) + "," + SParm(.SameServices) + "," + SParm(bpes.UserId) + "," + SParm(contractid) + "," + FParm(.PctMaint) + "," + FParm(.PctMonitor) + "," + SParm(.Profile) + ",NULL)"
            Call sql(c8, SQLstmt)
            Call SqlFree(c8)
        End With

        SQLstmt = "UPDATE_xRenewContracts_EscRen" + FParm(bXRENEW.PctMaint) + FParm(bXRENEW.PctMonitor) + IParm(bXRENEW.Duration) + SParm(bpes.UserId)  '10/18/2019 Issue 6.06 Correcting View Service Contracts for Review
        Call sql(c10, SQLstmt)                                                                                                '10/18/2019 Issue 6.06 Correcting View Service Contracts for Review
        Call SqlFree(c10)
        Call CallApplicWait("XSVCUPV ", "")
    End Sub

    Private Sub cBegProcessing_Click(sender As System.Object, e As System.EventArgs) Handles cBegProcessing.Click
        Dim BillDups, RevDups As Integer, ZeroAmtCount As Integer, ActualEffectDate As Integer, ChkEffectDate As Integer
        Dim NumProcessed As Integer, StartDateLater As Integer, EndDateEarlier As Integer 'for keyid changes
        Dim ProfileFreqNotSynched As Boolean = False, ProfileFreqFrom As Short = 0
        Dim Numrecs As Integer = 0, NumSel As Short = 0, NotSame As Boolean = False, i As Short = 0, Start As Boolean = False, Firsteffectdate As Integer = 0, FirstCancelCode As String = "" 'mod for last servid 4/29/17
        Dim BillwithContProfile As String = ""
        Dim XTB_Linenbr As Short 'mod 6/10/17
        Dim NoRevs As Integer 'mod 8/5/17
        Dim AllRevsProcessed As Integer 'mod 6/14/18
        Dim BillingsProcessed As Integer '5/30/2019 Change Start and End Dates
        Dim ServicesChanged As Integer
        Dim RevSched As Integer = -1
        Dim BillSched As Integer = -1
        Dim xInvPrintSuppress As String    '8/20/2019
        Dim DelFlag As Boolean
        Dim WarrantyEndedDate As Integer     '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
        Dim DatePriorStartDate As Boolean    '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
        Dim DatePrWarStartDate As Boolean
        Dim MasterContractCnt As Integer     '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
        Dim NumWarrantyDate As Integer '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
        'MOD 3/11/17, mod 5/24/17
        'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
        'If bXSVCGRID.ContractID.Trim = "" And bKeyid.ID <> 14 Then Exit Sub

        Call SqlFree(c1) : Call SqlFree(c2) : Call SqlFree(c3) : Call SqlFree(c4) : Call SqlFree(c5) : Call SqlFree(c6) : Call SqlFree(c7) : Call SqlFree(c8) : Call SqlFree(c9) : Call SqlFree(c10) : Call SqlFree(c11)

        Dim xWarrItem_CSR As Short                      '4/10/2020 Warranty Items added to Table.
        Dim xWarr_Flg As Short                          '4/10/2020 Warranty Items added to Table.

        'Dim WarrantyItems As New List(Of String)        '4/10/2020 Warranty Items added to Table.
        'Call SqlCursorEx(xWarrItem_CSR, NOLEVEL, "xWarrItem_CSR", "xWarrantyItem", "")                '4/10/2020 Warranty Items added to Table.
        'xWarr_Flg = SqlFetch1(xWarrItem_CSR, "xWarrantyItem_All" + SParm("%"), bxWarrantyItem)        '4/10/2020 Warranty Items added to Table.
        'Do While xWarr_Flg = 0                                                                        '4/10/2020 Warranty Items added to Table.
        '    WarrantyItems.Add(Trim$(bxWarrantyItem.WarrantyItem))                                     '4/10/2020 Warranty Items added to Table.

        '    'Check for another Warranty Item                                                          '4/10/2020 Warranty Items added to Table.
        '    xWarr_Flg = SFetch1(xWarrItem_CSR, bxWarrantyItem)                                        '4/10/2020 Warranty Items added to Table.
        'Loop                                                                                          '4/10/2020 Warranty Items added to Table.
        'Call SqlFree(xWarrItem_CSR)                                                                   '4/10/2020 Warranty Items added to Table.

        Select Case bKeyid.ID
            Case 1, 3
                If MArrayCnt(AddGridHandle) > 0 Then   'mod 3/22/17
                    'do nothing
                Else
                    If bMassUp.ServItemSel.Trim = "" Or IIf(bKeyid.ID = 3, bMassUp.RMRAmt = 0, False) Or bMassUp.EffectDate = NULLDATE Then
                        Call MessBox("Please Enter " + vbCrLf + "ServiceItem, RMR Amount and Effective Date", 48, "Massup Message")
                        Exit Sub
                    End If
                End If
                serr7 = MFirst(GridHandle1, Maintflag)
                If serr7 = 0 Then
                    Call Status(StartProcess, False, "", 0)
                    Do While serr7 = 0
                        If bselected.Value = 1 Then
                            If MArrayCnt(AddGridHandle) = 0 Then
                                ActualEffectDate = Math.Max(bMassUp.EffectDate, IIf(Val(bMassUp.Duration) > 0, bMassUp.WarrantyEndDate + 1, 0))  'mod 9/15/17

                                SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
                                serr2 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)

                                ZeroAmtCount = 0
                                If bMassUp.RMRAmt < 0 And bKeyid.ID = 3 And ChangeRMRAmtOpt <> 3 Then
                                    SQLstmt = "XCANCEL_chkforZero" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + FParm(Math.Abs(bMassUp.RMRAmt))
                                    Call sql(c3, SQLstmt)
                                    Call SGroupFetch1(c3, ZeroAmtCount)
                                End If

                                RevDups = 0
                                SQLstmt = "XADDDEL_DupRevDate" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate)
                                Call sql(c3, SQLstmt)
                                Call SGroupFetch1(c3, RevDups)

                                BillDups = 0
                                SQLstmt = "XADDDEL_DupBillDate" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate)
                                Call sql(c3, SQLstmt)
                                Call SGroupFetch1(c3, BillDups)
                                'mod 8/5/17
                                NoRevs = 0
                                SQLstmt = "select count(*) from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID)
                                Call sql(c5, SQLstmt)
                                serr5 = SGroupFetch1(c5, NoRevs)
                                'mod 6/14/18
                                AllRevsProcessed = 0
                                SQLstmt = "XSVCUPD_AllRevsProcessed" + SParm(bXSVCGRID.ContractID)
                                Call sql(c3, SQLstmt)
                                Call SGroupFetch1(c3, AllRevsProcessed)

                                If RevDups Then
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Contains duplicate Revenue Date(s) on or after Effect Date", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                    '   ElseIf BillDups Then  mod 5/3/17
                                ElseIf BillDups And bKeyid.ID = 1 Then
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Contains duplicate Bill Date(s) on or after Effect Date", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                    'mod 6/11/17 limited to adds only
                                ElseIf bKeyid.ID = 1 And (bsmContract.BillStartDate > ActualEffectDate Or bsmContract.AmortStartDate > ActualEffectDate Or bsmContract.StartDate > ActualEffectDate) Then
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Has a Contract or Revenue or Billing Start Date later than EffectDate", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                ElseIf bsmContract.ExpireDate < bMassUp.EffectDate Then
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Has a Contract End Date earlier than EffectDate", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                ElseIf bsmContract.ExpireDate < bMassUp.WarrantyEndDate AndAlso bMassUp.WarrantyEndDate <> 0 Then
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Has a Contract End Date earlier than Warranty End Date", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                ElseIf ZeroAmtCount Then
                                    Call Status(SaveGoodArgVals, False, "Mass Update Service Item would be reduced to 0 or less for Contract " + SParm(bXSVCGRID.ContractID.Trim), LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                ElseIf NoRevs = 0 Then
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Contains no Revenue Lines. Please Cancel, then Create a new contract.Split C/", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                ElseIf bsmContract.Status.Trim <> "A" Then   'mod 6/14/18
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Is not Active", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                ElseIf AllRevsProcessed = 1 Then   'mod 6/14/18
                                    Call Status(SaveGoodArgVals, False, "All Revenues have been processed for Contract " + SParm(bXSVCGRID.ContractID.Trim), LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                Else
                                    If bKeyid.ID = 1 Then
                                        gProcessAdditions(False)
                                    Else
                                        'mod 6/10/17 are there multiple records for same service item?
                                        XTB_Linenbr = 0
                                        SQLstmt = "xDELCHG_SingleChangeDelete" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel)
                                        serr3 = SqlFetch1(c3, SQLstmt, XTB_Linenbr)
                                        If XTB_Linenbr = -1 Then
                                            XTB_Linenbr = GetXTB_LineNbr("Changed")
                                        End If
                                        If XTB_Linenbr Then gProcessChanges(XTB_Linenbr)
                                    End If
                                    serr7 = MDelete(GridHandle1, Maintflag)
                                End If
                            Else  'multi adds   mod 3/22/17
                                serr8 = MFirst(AddGridHandle, Maintflag)
                                Call TranBeg(True)
                                Do While serr8 = 0
                                    bMassUp.ServItemSel = bXMULTIADDS.ServItemID
                                    bMassUp.EffectDate = bXMULTIADDS.EffectDate
                                    bMassUp.RMRAmt = bXMULTIADDS.RMRAmt
                                    bMassUp.InvPrintSuppress = bXMULTIADDS.InvPrintSuppress
                                    bMassUp.WarrantyEndDate = bXMULTIADDS.WarrantyEndDate
                                    bMassUp.Duration = bXMULTIADDS.Duration 'mod 9/15/17  needed to test if it was set to 0
                                    bMassUp.SystemType = bXMULTIADDS.SystemType  'mod 4/9/17
                                    gProcessAdditions(True)
                                    serr8 = MNext(AddGridHandle, Maintflag)
                                Loop
                                Call TranEnd()
                                bMassUp.ServItemSel = "" 'mod 5/19/17.  Needed when more than 1 multi-adds for same contract and refreshing grid. Multi should send down blank servitemsel
                                Call MClear(AddGridHandle)
                                '  serr7 = MNext(GridHandle1, Maintflag)
                                serr7 = MDelete(GridHandle1, Maintflag)  'mod 4/11/17
                            End If
                        Else
                            serr7 = MNext(GridHandle1, Maintflag)
                        End If
                    Loop
                    serr7 = MFirst(GridHandle1, Maintflag)
                    Call MDisplay(GridHandle1)
                    Call Status(EndProcess, False, "", 0)
                End If
            Case 2
                'Editing
                If bTotDel.Total > 0 Then
                    'do nothing
                ElseIf bMassUp.ServItemSel.Trim = "" Or bMassUp.EffectDate = NULLDATE Or bMassUp.CancelCode.Trim = "" Then
                    Call MessBox("Please Enter " + vbCrLf + "ServiceItem,   Effective Date and Cancellation Code", 48, "Massup Message")
                    Exit Sub
                End If
                'mod 10/30/17 removed all code for non-multideletes
                nMassUp.EffectDate = bMassUp.EffectDate
                serr7 = MFirst(GridHandle1, Maintflag) 'there will only be one record here from the contract with the multideletes.
                If serr7 = 0 Then
                    Call Status(StartProcess, False, "", 0)
                    Do While serr7 = 0
                        If bselected.Value = 1 Then
                            SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
                            serr2 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)
                            serr8 = MFirst(DelGridHandle, Maintflag)
                            Numrecs = 0 : NumSel = 0 : Start = False : NotSame = False : Firsteffectdate = 0 : FirstCancelCode = ""
                            NumWarrantyDate = 1 '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
                            If Trim$(bMassUp.ServItemSel) <> "" Then
                                If (Trim$(bMassUp.ServItemSel) = "C OPTION A" Or Trim$(bMassUp.ServItemSel) = "CP OPTION A" Or Trim$(bMassUp.ServItemSel) = "CP OPTION D" Or Trim$(bMassUp.ServItemSel) = "CP OPTION D 4 HOUR" Or Trim$(bMassUp.ServItemSel) = "CP OPTION D") Then  '11/13/2019  Display a message if the Delete item is before Warranty Start Date. '4/10/2020 Warranty Items added to Table.
                                    'If WarrantyItems.Contains(Trim$(bMassUp.ServItemSel)) Then  '11/13/2019  Display a message if the Delete item is before Warranty Start Date. '4/10/2020 Warranty Items added to Table.
                                    SQLstmt = "XSVCU00_First_ServItem_WarrantyDate" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + DParm(bMassUp.EffectDate)  '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
                                    Call sql(c4, SQLstmt)                      '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
                                    serr3 = SGroupFetch1(c4, NumWarrantyDate)  '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
                                End If
                            End If
                            '8/20/2019 - Canceling a Service Item on the Contract.
                            SQLstmt = "XSNUPDT_xtb_ServicesWrk_Insert" + SParm(bXSVCGRID.ContractID) + SParm(bpes.UserId) '8/20/2019
                            Call sql(c8, SQLstmt)   '6/14/2019

                            If bTotDel.Total = 0 Then  'mod 3/21/17                           
                                ChkEffectDate = 0
                                SQLstmt = "xDELCHG_ChkEffectDate" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + DParm(bMassUp.EffectDate)
                                Call sql(c3, SQLstmt)
                                Call SGroupFetch1(c3, ChkEffectDate)
                                If bsmContract.ExpireDate < bMassUp.EffectDate Then
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " End Date is earlier than EffectDate", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                    'mod 11/11/17
                                ElseIf bsmContract.BillStartDate > bMassUp.EffectDate Or bsmContract.AmortStartDate > bMassUp.EffectDate Or bsmContract.StartDate > bMassUp.EffectDate Then
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Revenue or Billing Start Date later than EffectDate", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                ElseIf bsmContract.Status.Trim <> "A" Then   'mod 6/14/18
                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Is not Active", LOG_AND_DISP)
                                    serr7 = MNext(GridHandle1, Maintflag)
                                ElseIf ((Trim$(bMassUp.ServItemSel) = "C OPTION A" Or Trim$(bMassUp.ServItemSel) = "CP OPTION A" Or Trim$(bMassUp.ServItemSel) = "CP OPTION D" Or Trim$(bMassUp.ServItemSel) = "CP OPTION D 4 HOUR" Or Trim$(bMassUp.ServItemSel) = "CP OPTION D")) And NumWarrantyDate = 0 Then   '4/10/2020 Warranty Items added to Table.
                                    'ElseIf WarrantyItems.Contains(Trim$(bMassUp.ServItemSel)) And NumWarrantyDate = 0 Then   '4/10/2020 Warranty Items added to Table.
                                    If NumWarrantyDate = 0 Then                '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
                                        Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Revenue or Billing Start Date later than EffectDate", LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                    End If
                                Else
                                    'mod 6/10/17 are there multiple records for same service item?
                                    XTB_Linenbr = 0
                                    SQLstmt = "xDELCHG_SingleChangeDelete" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) 'either returns the servitem linenbr or -1 to reflect duplicates
                                    serr3 = SqlFetch1(c3, SQLstmt, XTB_Linenbr)
                                    'mod 7/29/17 is this the last active service item
                                    Numrecs = 0
                                    SQLstmt = "XDEL_LastServItem" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel)
                                    Call sql(c3, SQLstmt)
                                    serr3 = SGroupFetch1(c3, Numrecs)
                                    If Numrecs = 1 And XTB_Linenbr <> -1 Then
                                        Call ApplSetParmValue(PRMSECTION_VBRDT, "Contractid", bXSVCGRID.ContractID)
                                        Call ApplSetParmValue(PRMSECTION_VBRDT, "Effectdate", DateToStr(bMassUp.EffectDate))
                                        Call ApplSetParmValue(PRMSECTION_VBRDT, "CancelCode", bMassUp.CancelCode)
                                        Call CallApplicWait("XSNUPDT ", "")
                                    Else
                                        'mod 6/10/17
                                        If XTB_Linenbr = -1 Then 'then there are duplicates
                                            XTB_Linenbr = GetXTB_LineNbr("Deleted")
                                        End If
                                        If XTB_Linenbr Then
                                            'gProcessDeletions(False, XTB_Linenbr)     '8/20/2019 
                                            gProcessDeletionsSome(False, XTB_Linenbr)  '8/20/2019
                                            If bMassUp.InvPrintSuppress Then           '8/20/2019
                                                xInvPrintSuppress = "1"                '8/20/2019
                                            Else                                       '8/20/2019
                                                xInvPrintSuppress = "0"                '8/20/2019
                                            End If                                     '8/20/2019
                                            SQLstmt = "XSNUPDT_Delete_SmContractRevAndBillServItem" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + DParm(bMassUp.EffectDate) + SParm(bpes.UserId) + SParm("N") + SParm(bpes.CpnyID) + SParm(xInvPrintSuppress) '8/20/2019
                                            Call sql(c3, SQLstmt)                      '8/20/2019
                                        End If                                         '8/20/2019
                                    End If
                                    serr7 = MDelete(GridHandle1, Maintflag)
                                    bMassUp.EffectDate = nMassUp.EffectDate  'set it back
                                End If
                            Else 'Multi delete grid
                                Do While serr8 = 0
                                    Numrecs += 1
                                    If bDelselected.Value = 1 Then
                                        If Not (Start) Then
                                            Firsteffectdate = bXMULTIDELETES.EffectDate
                                            FirstCancelCode = bXMULTIDELETES.CancelCode
                                            Start = True
                                        Else
                                            If bXMULTIDELETES.EffectDate <> Firsteffectdate Or bXMULTIDELETES.CancelCode <> FirstCancelCode Then
                                                NotSame = True
                                            End If
                                        End If
                                        NumSel += 1
                                    End If
                                    serr8 = MNext(DelGridHandle, Maintflag)
                                Loop
                                'Process through XSNUPDT if all records have same effectdate and cancelcode
                                If NumSel = Numrecs And Not (NotSame) Then
                                    Call ApplSetParmValue(PRMSECTION_VBRDT, "Contractid", bXSVCGRID.ContractID)
                                    Call ApplSetParmValue(PRMSECTION_VBRDT, "Effectdate", DateToStr(bXMULTIDELETES.EffectDate))
                                    Call ApplSetParmValue(PRMSECTION_VBRDT, "CancelCode", bXMULTIDELETES.CancelCode)
                                    Call CallApplicWait("XSNUPDT ", "")
                                Else
                                    'if effectdate and/or cancelcode are not the same - process all but the last one through XSVCUPD.  The last one process through XSNUPDT
                                    Call TranBeg(True)
                                    serr8 = MFirst(DelGridHandle, Maintflag)
                                    Do While serr8 = 0
                                        If bDelselected.Value = 1 Then
                                            bMassUp.ServItemSel = bXMULTIDELETES.ServItemID
                                            bMassUp.EffectDate = bXMULTIDELETES.EffectDate
                                            bMassUp.InvPrintSuppress = bXMULTIDELETES.InvPrintSuppress
                                            bMassUp.CancelCode = bXMULTIDELETES.CancelCode
                                            If NumSel = Numrecs And MGetRowNum(DelGridHandle) = Numrecs Then  'this is the last record
                                                Call TranEnd()
                                                Call ApplSetParmValue(PRMSECTION_VBRDT, "Contractid", bXSVCGRID.ContractID)
                                                Call ApplSetParmValue(PRMSECTION_VBRDT, "Effectdate", DateToStr(bXMULTIDELETES.EffectDate))
                                                Call ApplSetParmValue(PRMSECTION_VBRDT, "CancelCode", bXMULTIDELETES.CancelCode)
                                                Call CallApplicWait("XSNUPDT ", "")
                                                Call TranBeg(True)
                                            Else
                                                gProcessDeletionsSome(True, bXMULTIDELETES.XTB_LineNbr)  '8/20/2019
                                                If bMassUp.InvPrintSuppress Then           '8/20/2019
                                                    xInvPrintSuppress = "1"                '8/20/2019
                                                Else                                       '8/20/2019
                                                    xInvPrintSuppress = "0"                '8/20/2019
                                                End If                                     '8/20/2019
                                                SQLstmt = "XSNUPDT_Delete_SmContractRevAndBillServItem" + SParm(bXSVCGRID.ContractID) + SParm(bXMULTIDELETES.ServItemID) + DParm(bMassUp.EffectDate) + SParm(bpes.UserId) + SParm("N") + SParm(bpes.CpnyID) + SParm(xInvPrintSuppress) '8/20/2019
                                                Call sql(c3, SQLstmt)                      '8/20/2019
                                                'gProcessDeletions(True, bXMULTIDELETES.XTB_LineNbr) '8/20/2019 'mod 6/10/17 added linenbr
                                            End If
                                        End If
                                        serr8 = MNext(DelGridHandle, Maintflag)
                                    Loop
                                    Call TranEnd()
                                End If
                                Call MClear(DelGridHandle)
                                serr7 = MDelete(GridHandle1, Maintflag)
                                bMassUp.ServItemSel = "" 'mod 5/19/17.  Needed when more than 1 multi-deletes for same contract and refreshing grid. Multi should send down blank servitemsel
                                bTotDel.Total = 0 'mod 2/23/18 to allow the grid to repopulate
                            End If
                        Else 'bselected.value = 9
                            serr7 = MNext(GridHandle1, Maintflag)
                        End If
                    Loop
                    serr7 = MFirst(GridHandle1, Maintflag)
                    Call MDisplay(GridHandle1)
                    Call Status(EndProcess, False, "", 0)
                End If
            Case 4 To 9, 11, 12, 13
                Select Case bKeyid.ID
                    'Case 4 To 5
                    Case 4                                                                             '5/30/2019 Change Start and End Dates 
                        If bMassUp.ContractStartDate = 0 Then                                          '5/30/2019 Change Start and End Dates
                            Call MessBox("Please enter Contract Start Date", 48, "Massup Messsage")    '5/30/2019 Change Start and End Dates
                            Exit Sub                                                                   '5/30/2019 Change Start and End Dates
                        End If                                                                         '5/30/2019 Change Start and End Dates
                    Case 5                                                                             '5/30/2019 Change Start and End Dates
                        If bMassUp.ContractEndDate = 0 Then                                            '5/30/2019 Change Start and End Dates
                            Call MessBox("Please enter Contract End Date", 48, "Massup Messsage")      '5/30/2019 Change Start and End Dates
                            Exit Sub                                                                   '5/30/2019 Change Start and End Dates
                        End If                                                                         '5/30/2019 Change Start and End Dates
                    Case 6
                        If bMassUp.Frequency.Trim = "" Then
                            Call MessBox("Please enter Billing Frequency", 48, "Massup Messsage")
                            Exit Sub
                            'ElseIf bMassUp.EffectDate = 0 Then                                    '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                            '    Call MessBox("Please enter Effect Date", 48, "Massup Message")    '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                            '    Exit Sub                                                          '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                        End If
                    Case 7
                        If bMassUp.Branch.Trim = "" Then
                            Call MessBox("Please enter Destination Branch ID", 48, "Massup Message")
                            Exit Sub
                        End If
                    Case 8
                        If bMassUp.BillwithContractProfile.Trim = "" Then
                            Call MessBox("Please enter the To Billwith Contract Profile", 48, "Massup Message")
                            Exit Sub
                        End If
                    Case 9
                        If bMassUp.ContractProfile.Trim = "" Then
                            Call MessBox("Please enter the Contract Profile", 48, "Massup Message")
                            Exit Sub
                        End If
                    Case 11
                        If bMassUp.InvoiceFormatID.Trim = "" Then
                            Call MessBox("Please enter Invoice Format ID", 48, "Massup Message")
                            Exit Sub
                        End If
                    Case 12
                        If bMassUp.InvoicingRule.Trim = "" Then
                            Call MessBox("Please enter Invoicing Rule", 48, "Massup Message")
                            Exit Sub
                        End If
                    Case 13
                        If bMassUp.WarrantyStartDate = 0 Then
                            Call MessBox("Please enter Warranty Start Date", 48, "Massup Message")
                            Exit Sub
                        ElseIf bMassUp.Duration.Trim = "" Then
                            Call MessBox("Please enter Warranty Duration", 48, "Massup Message")
                            Exit Sub
                        End If
                End Select
                serr7 = MFirst(GridHandle1, Maintflag)
                If serr7 = 0 Then
                    Call Status(StartProcess, False, "", 0)
                    Do While serr7 = 0
                        'mod 6/14/18 added for active contract test
                        SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
                        serr2 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)
                        If bselected.Value = 1 Then
                            If bsmContract.Status.Trim <> "A" Then   'mod 6/14/18
                                Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Is not Active", LOG_AND_DISP)
                                serr7 = MNext(GridHandle1, Maintflag)
                            Else
                                StartDateLater = 0
                                If bKeyid.ID = 4 Then
                                    SQLstmt = "xOthChanges_TestStartDate" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.ContractStartDate)
                                    Call sql(c3, SQLstmt)
                                    Call SGroupFetch1(c3, StartDateLater)
                                ElseIf bKeyid.ID = 5 Then
                                    EndDateEarlier = 0
                                    SQLstmt = "xOthChanges_TestEndDate" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.ContractEndDate)
                                    Call sql(c3, SQLstmt)
                                    Call SGroupFetch1(c3, EndDateEarlier)
                                End If

                                'Check to see if any billings for Revenue Schedule or Billing Schedule.       '5/30/2019 Change Start and End Dates
                                BillingsProcessed = 0                                                         '5/30/2019 Change Start and End Dates
                                SQLstmt = "XSVCUPD_RevSchedProcessedCount" + SParm(bXSVCGRID.ContractID)      '5/30/2019 Change Start and End Dates
                                Call sql(c4, SQLstmt)                                                         '5/30/2019 Change Start and End Dates
                                Call SGroupFetch1(c4, BillingsProcessed)                                      '5/30/2019 Change Start and End Dates
                                If BillingsProcessed = 0 Then                                                 '5/30/2019 Change Start and End Dates
                                    SQLstmt = "XSVCUPD_BillSchedProcessedCount" + SParm(bXSVCGRID.ContractID) '5/30/2019 Change Start and End Dates
                                    Call sql(c4, SQLstmt)                                                     '5/30/2019 Change Start and End Dates
                                    Call SGroupFetch1(c4, BillingsProcessed)                                  '5/30/2019 Change Start and End Dates
                                End If

                                'Check to see if any service items have beem modified.       
                                ServicesChanged = 0
                                SQLstmt = "XSVCUPD_ServiceChangedCount" + SParm(bXSVCGRID.ContractID)
                                Call sql(c4, SQLstmt)
                                Call SGroupFetch1(c4, ServicesChanged)

                                'This Contract is tied to a Master Customer Contract and the End Date cannot be changed.
                                MasterContractCnt = 0                                                         '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                                If bKeyid.ID = 5 Then                                                         '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                                    SQLstmt = "XSVCU00_MasterContractID" + SParm(bXSVCGRID.ContractID.Trim)   '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                                    Call sql(c5, SQLstmt)                                                     '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                                    Call SGroupFetch1(c5, MasterContractCnt)                                  '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                                End If                                                                        '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.

                                Select Case bKeyid.ID
                                    'mod 3/18/17
                                    Case 4 To 5                                              '5/30/2019 Change Start and End Dates
                                        If bKeyid.ID = 4 And StartDateLater Then
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " End Date is earlier than the Mass Contract Start Date", LOG_AND_DISP) '5/30/2019 Change Start and End Dates
                                        ElseIf bKeyid.ID = 5 And EndDateEarlier Then         '5/30/2019 Change Start and End Dates
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Start Date is later than the Mass Contract End Date", LOG_AND_DISP)   '5/30/2019 Change Start and End Dates
                                        ElseIf bKeyid.ID = 4 And BillingsProcessed > 0 Then  '5/30/2019 Change Start and End Dates
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " have Billings already Processed. The Mass Contract Start Date cannot be modified.", LOG_AND_DISP)   '5/30/2019 Change Start and End Dates
                                        ElseIf bKeyid.ID = 5 And BillingsProcessed > 0 Then  '5/30/2019 Change Start and End Dates
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " have Billings already Processed. The Mass Contract End Date cannot be modified.", LOG_AND_DISP)   '5/30/2019 Change Start and End Dates
                                        ElseIf bKeyid.ID = 5 And MasterContractCnt > 0 Then                                                                                                                                    '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " is tied to a Master Customer Contract and the End Date cannot be changed.", LOG_AND_DISP)   '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                                        Else                                                 '5/30/2019 Change Start and End Dates
                                            gRecalcBillings()                                '5/30/2019 Change Start and End Dates
                                        End If                                               '5/30/2019 Change Start and End Dates
                                    Case 6
                                        If BillingsProcessed > 0 Then   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " have Revenue Schedules or Billings Schedules already Processed. The Billing Frequency cannot be modified.", LOG_AND_DISP)   '5/30/2019 Change Start and End Dates
                                        ElseIf ServicesChanged > 0 Then
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " have Service Changes that are already processed. The Billing Frequency cannot be modified.", LOG_AND_DISP)
                                        Else                            '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
                                            gFrequencyChange()          '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
                                        End If                          '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
                                    Case 7
                                        SQLstmt = "XOthChanges_Branch" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.Branch)
                                        Call sql(c9, SQLstmt)
                                    Case 8
                                        'mod 4/6/17 mod 5/6/17
                                        BillwithContProfile = bMassUp.BillwithContractProfile
                                        If bMassUp.BillwithContractProfile.Trim <> "NONE" Then
                                            'mod 5/6/17
                                            SQLstmt = "xcusconmaster_all" + SParm(bMassUp.BillwithContractProfile)
                                            serr3 = SqlFetch1(c3, SQLstmt, bXCUSCONMASTER)

                                            'mod 6/3/19 - Change condition from frequency to billing/rev schedules - Solomon Cloud Solutions
                                            SQLstmt = "XSVCUPD_RevSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                            serr3 = SqlFetch1(c3, SQLstmt, RevSched)
                                            SQLstmt = "XSVCUPD_BillSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                            serr3 = SqlFetch1(c3, SQLstmt, BillSched)
                                            'If bXCUSCONMASTER.ServBillInvType.Trim = "SS-SB" Then
                                            If RevSched <> 0 Or BillSched <> 0 Then
                                                BillwithContProfile = "NONE"
                                            Else
                                                ProfileFreqNotSynched = False
                                                SQLstmt = "XBillwithContractProfile_Frequency" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.BillwithContractProfile)
                                                serr3 = SqlFetch1(c3, SQLstmt, bProfileFreq)
                                                If bProfileFreq.FromFreq = 0 Then
                                                    ProfileFreqFrom = bProfileFreq.BillFreq
                                                Else
                                                    ProfileFreqFrom = bProfileFreq.FromFreq
                                                End If
                                                If RevSched <> 0 Or BillSched <> 0 Then
                                                    Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Already has Billings Present in System. Therefore, cannot do update.", LOG_AND_DISP)
                                                    ProfileFreqNotSynched = True
                                                End If
                                            End If
                                        End If
                                        If RevSched = 0 AndAlso BillSched = 0 Then
                                            SQLstmt = "XOthChanges_BillwithContractProfile" + SParm(bXSVCGRID.ContractID) + SParm(BillwithContProfile) + SParm(bMassUp.BillwithContractProfile)
                                            Call sql(c9, SQLstmt)
                                        End If
                                    Case 9  'mod 3/19/17
                                        'mod 5/17/17 get the To invoiceformat
                                        SQLstmt = "xcusconmaster_all" + SParm(bMassUp.ContractProfile)
                                        serr3 = SqlFetch1(c3, SQLstmt, bXCUSCONMASTER)
                                        ProfileFreqNotSynched = False
                                        SQLstmt = "XContractProfile_Frequency" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ContractProfile)
                                        serr3 = SqlFetch1(c3, SQLstmt, bProfileFreq)

                                        'mod 6/3/19 - Change condition from frequency to billing/rev schedules - Solomon Cloud Solutions
                                        SQLstmt = "XSVCUPD_RevSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                        serr3 = SqlFetch1(c3, SQLstmt, RevSched)
                                        SQLstmt = "XSVCUPD_BillSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                        serr3 = SqlFetch1(c3, SQLstmt, BillSched)

                                        'If bProfileFreq.FromFreq <> bProfileFreq.ToFreq Then
                                        If RevSched <> 0 Or BillSched <> 0 Then
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Already has Billings Present in System. Therefore, cannot do update.", LOG_AND_DISP)
                                            ProfileFreqNotSynched = True
                                        Else
                                            'mod 5/17/17
                                            SQLstmt = "XOthChanges_ContractProfile" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ContractProfile) + SParm(bXCUSCONMASTER.ServBillInvType)
                                            Call sql(c9, SQLstmt)
                                        End If
                                    Case 11
                                        'mod 5/17/17 get the To invoiceformat
                                        SQLstmt = "xcusconmaster_all" + SParm(bMassUp.ContractProfile)
                                        serr3 = SqlFetch1(c3, SQLstmt, bXCUSCONMASTER)
                                        ProfileFreqNotSynched = False
                                        SQLstmt = "XContractProfile_Frequency" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ContractProfile)
                                        serr3 = SqlFetch1(c3, SQLstmt, bProfileFreq)

                                        'mod 6/3/19 - Change condition from frequency to billing/rev schedules - Solomon Cloud Solutions
                                        SQLstmt = "XSVCUPD_RevSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                        serr3 = SqlFetch1(c3, SQLstmt, RevSched)
                                        SQLstmt = "XSVCUPD_BillSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                        serr3 = SqlFetch1(c3, SQLstmt, BillSched)

                                        'If bProfileFreq.FromFreq <> bProfileFreq.ToFreq Then
                                        If RevSched <> 0 Or BillSched <> 0 Then
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Already has Billings Present in System. Therefore, cannot do update.", LOG_AND_DISP)
                                            ProfileFreqNotSynched = True
                                        Else
                                            'mod 5/17/17
                                            SQLstmt = "XOthChanges_InvoiceFormat" + SParm(bXSVCGRID.ContractID) + SParm(Trim(bMassUp.InvoiceFormatID))
                                            Call sql(c9, SQLstmt)
                                        End If
                                    Case 12
                                        'mod 5/17/17 get the To invoiceformat
                                        SQLstmt = "xcusconmaster_all" + SParm(bMassUp.ContractProfile)
                                        serr3 = SqlFetch1(c3, SQLstmt, bXCUSCONMASTER)
                                        ProfileFreqNotSynched = False
                                        SQLstmt = "XContractProfile_Frequency" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ContractProfile)
                                        serr3 = SqlFetch1(c3, SQLstmt, bProfileFreq)

                                        'mod 6/3/19 - Change condition from frequency to billing/rev schedules - Solomon Cloud Solutions
                                        SQLstmt = "XSVCUPD_RevSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                        serr3 = SqlFetch1(c3, SQLstmt, RevSched)
                                        SQLstmt = "XSVCUPD_BillSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                        serr3 = SqlFetch1(c3, SQLstmt, BillSched)

                                        'If bProfileFreq.FromFreq <> bProfileFreq.ToFreq Then
                                        If RevSched <> 0 Or BillSched <> 0 Then
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Already has Billings Present in System. Therefore, cannot do update.", LOG_AND_DISP)
                                            ProfileFreqNotSynched = True
                                        Else
                                            'mod 5/17/17
                                            TranBeg(True)
                                            SQLstmt = "XOthChanges_InvoiceRules" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.InvoiceFormatID)
                                            Call sql(c9, SQLstmt)
                                            TranEnd()
                                            'SOLOMON CLOUD SOLUTIONS - RECALC BILLING & REVENUE SCHEDULES HERE
                                            'Only update if there are service items that start with CP (Warranty Items)
                                            serr4 = SqlFetch1(CSR_XTB_Services, "SELECT * FROM xtb_services WHERE ContractID = " + SParm(bXSVCGRID.ContractID) + " AND ServItemID IN ('C OPTION A', 'CP OPTION A', 'CP OPTION D', 'CP OPTION D 4 HOUR', 'CP OPTION D')", bXTB_SERVICES)  '4/10/2020 Warranty Items added to Table.
                                            'serr4 = SqlFetch1(CSR_XTB_Services, "xWarrantyItem_in_xtb_Services" + SParm(bXSVCGRID.ContractID), bXTB_SERVICES)   '4/10/2020 Warranty Items added to Table.
                                            If serr4 = 0 Then
                                                SQLstmt = "XSVCUPD_ReCreateRevBillSchedules" + SParm(bXSVCGRID.ContractID) + SParm(CurUser)
                                                Call sql(c4, SQLstmt)
                                            End If
                                        End If
                                    Case 13
                                        'mod 5/17/17 get the To invoiceformat
                                        SQLstmt = "xcusconmaster_all" + SParm(bMassUp.ContractProfile)
                                        serr3 = SqlFetch1(c3, SQLstmt, bXCUSCONMASTER)
                                        ProfileFreqNotSynched = False
                                        SQLstmt = "XContractProfile_Frequency" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ContractProfile)
                                        serr3 = SqlFetch1(c3, SQLstmt, bProfileFreq)

                                        'mod 6/3/19 - Change condition from frequency to billing/rev schedules - Solomon Cloud Solutions
                                        SQLstmt = "XSVCUPD_RevSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                        serr3 = SqlFetch1(c3, SQLstmt, RevSched)
                                        SQLstmt = "XSVCUPD_BillSchedProcessedCount" + SParm(bXSVCGRID.ContractID)
                                        serr3 = SqlFetch1(c3, SQLstmt, BillSched)

                                        DatePriorStartDate = False                                        '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                        Call DatePlusDays(bMassUp.WarrantyEndDate, 1, WarrantyEndedDate)  '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                        If bsmContract.StartDate > WarrantyEndedDate Then                 '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                            DatePriorStartDate = True                                     '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                        End If                                                            '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.

                                        DatePrWarStartDate = False                                        '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                        If bsmContract.StartDate > bMassUp.WarrantyStartDate Then         '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                            DatePrWarStartDate = True                                     '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                        End If                                                            '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.

                                        'If bProfileFreq.FromFreq <> bProfileFreq.ToFreq Then
                                        If RevSched <> 0 Or BillSched <> 0 Then
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Already has Billings Present in System. Therefore, cannot do update.", LOG_AND_DISP)
                                            ProfileFreqNotSynched = True
                                        ElseIf DatePriorStartDate = True Then     '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " New Warranty End Date is prior to contract Start Date. Therefore, cannot do update.", LOG_AND_DISP)  '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                            ProfileFreqNotSynched = True          '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                        ElseIf DatePrWarStartDate = True Then     '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                            Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " New Warranty Start Date is prior to contract Start Date. Therefore, cannot do update.", LOG_AND_DISP)  '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                            ProfileFreqNotSynched = True          '9/18/2019 - Warranty End Date cannot be prior to the contract Start Date.
                                        Else
                                            'Update warranty duration and end date
                                            SQLstmt = "SELECT * FROM smcontract WHERE ContractID = " + SParm(bXSVCGRID.ContractID)
                                            Call SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)
                                            bsmContract.User7 = bMassUp.WarrantyEndDate
                                            bsmContract.User1 = bMassUp.Duration
                                            TranBeg(True)
                                            bsmContract.NoteId = GAddContractWarrantyNote("New Warranty End Date is", bMassUp.WarrantyEndDate)
                                            Call SUpdate1(CSR_SMContract, "smContract", bsmContract)

                                            SQLstmt = "xOthChanges_WarrantyChgs" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.WarrantyEndDate) + DParm(bMassUp.WarrantyStartDate)
                                            Call sql(c3, SQLstmt)
                                            Call TranEnd()
                                            'SOLOMON CLOUD SOLUTIONS - RECALC BILLING & REVENUE SCHEDULES HERE
                                            'Only update if there are service items that start with CP (Warranty Item)
                                            serr4 = SqlFetch1(CSR_XTB_Services, "SELECT * FROM xtb_services WHERE ContractID = " + SParm(bXSVCGRID.ContractID) + " AND ServItemID IN ('C OPTION A', 'CP OPTION A', 'CP OPTION D', 'CP OPTION D 4 HOUR', 'CP OPTION D')", bXTB_SERVICES) '4/10/2020 Warranty Items added to Table.
                                            'serr4 = SqlFetch1(CSR_XTB_Services, "xWarrantyItem_in_xtb_Services" + SParm(bXSVCGRID.ContractID), bXTB_SERVICES)  '4/10/2020 Warranty Items added to Table.
                                            If serr4 = 0 Then
                                                SQLstmt = "XSVCUPD_ReCreateRevBillSchedulesWarranty" + SParm(bXSVCGRID.ContractID) + SParm(CurUser)
                                                Call sql(c4, SQLstmt)
                                            End If
                                        End If
                                End Select
                                If NumProcessed Or StartDateLater Or EndDateEarlier Or ProfileFreqNotSynched Then
                                    serr7 = MNext(GridHandle1, Maintflag)
                                Else
                                    serr7 = MDelete(GridHandle1, Maintflag)
                                End If
                            End If   'not an expired contract mod 6/14/18
                        Else
                            serr7 = MNext(GridHandle1, Maintflag)
                        End If
                    Loop
                    serr7 = MFirst(GridHandle1, Maintflag)
                    Call MDisplay(GridHandle1)
                    Call Status(EndProcess, False, "", 0)
                End If
            Case 10
                serr7 = MFirst(Gridhandle2, Maintflag)
                If serr7 = 0 Then
                    Call Status(StartProcess, False, "", 0)
                    Do While serr7 = 0
                        If bselectedRenewals.Value = 1 Then
                            gProcessRenewals()
                            serr7 = MDelete(Gridhandle2, Maintflag)
                        Else
                            serr7 = MNext(Gridhandle2, Maintflag)
                        End If
                    Loop
                    serr7 = MFirst(Gridhandle2, Maintflag)
                    Call MDisplay(Gridhandle2)
                    Call Status(EndProcess, False, "", 0)
                End If
                'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
            Case 14
                serr7 = MFirst(GridHandle3, Maintflag)
                If serr7 = 0 Then
                    Call Status(StartProcess, False, "", 0)
                    Do While serr7 = 0
                        If bSelectedEscal.Value = 1 Then
                            gProcessEscalations()
                            serr7 = MDelete(GridHandle3, Maintflag)
                        Else
                            serr7 = MNext(GridHandle3, Maintflag)
                        End If
                    Loop
                    serr7 = MFirst(GridHandle3, Maintflag)
                    Call MDisplay(GridHandle3)
                    Call Status(EndProcess, False, "", 0)
                End If
            Case 15
                If MArrayCnt(AddGridHandle) > 0 Then   'mod 3/22/17
                    'do nothing
                Else
                    If bMassUp.EffectDate = NULLDATE Then
                        Call MessBox("Please Enter " + vbCrLf + "ServiceItem, RMR Amount and Effective Date", 48, "Massup Message")
                        Exit Sub
                    End If
                End If
                serr7 = MFirst(GridHandle1, Maintflag)
                If serr7 = 0 Then
                    Call Status(StartProcess, False, "", 0)
                    Do While serr7 = 0
                        If bselected.Value = 1 Then
                            If MArrayCnt(AddGridHandle) = 0 Then
                                ActualEffectDate = Math.Max(bMassUp.EffectDate, IIf(Val(bMassUp.Duration) > 0, bMassUp.WarrantyEndDate + 1, 0))  'mod 9/15/17

                                SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
                                serr2 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)

                                If bMassUp.MaintChange = 1 And bMassUp.MonitChange = 0 Then
                                    SQLstmt = "SELECT GroupCode, ServItemID FROM xtb_services WHERE GroupCode <> 'MONITORING' AND Status = 'A' AND ContractID = " + SParm(bXSVCGRID.ContractID)
                                ElseIf bMassUp.MaintChange = 0 And bMassUp.MonitChange = 1 Then
                                    SQLstmt = "SELECT GroupCode, ServItemID FROM xtb_services WHERE GroupCode = 'MONITORING' AND Status = 'A' AND ContractID = " + SParm(bXSVCGRID.ContractID)
                                ElseIf bMassUp.MaintChange = 1 And bMassUp.MonitChange = 1 Then
                                    SQLstmt = "SELECT GroupCode, ServItemID FROM xtb_services WHERE Status = 'A' AND ContractID = " + SParm(bXSVCGRID.ContractID)
                                End If

                                Call sql(c8, SQLstmt)
                                serr6 = SFetch1(c8, bxServItem)

                                Do While serr6 = 0
                                    bMassUp.ServItemSel = bxServItem.ServItemID
                                    ZeroAmtCount = 0
                                    If (bMassUp.MaintAmt < 0 And ChangeRMRAmtOpt <> 3) Or (bMassUp.MonitAmt < 0 And ChangeRMRAmtOpt <> 3) Then
                                        SQLstmt = "XCANCEL_chkforZero" + SParm(bXSVCGRID.ContractID) + SParm(bxServItem.ServItemID) + FParm(Math.Abs(bMassUp.RMRAmt))
                                        Call sql(c3, SQLstmt)
                                        Call SGroupFetch1(c3, ZeroAmtCount)
                                    End If

                                    RevDups = 0
                                    SQLstmt = "XADDDEL_DupRevDate" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate)
                                    Call sql(c3, SQLstmt)
                                    Call SGroupFetch1(c3, RevDups)

                                    BillDups = 0
                                    SQLstmt = "XADDDEL_DupBillDate" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate)
                                    Call sql(c3, SQLstmt)
                                    Call SGroupFetch1(c3, BillDups)
                                    'mod 8/5/17
                                    NoRevs = 0
                                    SQLstmt = "select count(*) from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID)
                                    Call sql(c5, SQLstmt)
                                    serr5 = SGroupFetch1(c5, NoRevs)
                                    'mod 6/14/18
                                    AllRevsProcessed = 0
                                    SQLstmt = "XSVCUPD_AllRevsProcessed" + SParm(bXSVCGRID.ContractID)
                                    Call sql(c3, SQLstmt)
                                    Call SGroupFetch1(c3, AllRevsProcessed)

                                    If RevDups Then
                                        Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Contains duplicate Revenue Date(s) on or after Effect Date", LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                        '   ElseIf BillDups Then  mod 5/3/17
                                    ElseIf BillDups And bKeyid.ID = 1 Then
                                        Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Contains duplicate Bill Date(s) on or after Effect Date", LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                        'mod 6/11/17 limited to adds only
                                    ElseIf bKeyid.ID = 1 And (bsmContract.BillStartDate > ActualEffectDate Or bsmContract.AmortStartDate > ActualEffectDate Or bsmContract.StartDate > ActualEffectDate) Then
                                        Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Has a Contract or Revenue or Billing Start Date later than EffectDate", LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                    ElseIf bsmContract.ExpireDate < bMassUp.EffectDate Then
                                        Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Has a Contract End Date earlier than EffectDate", LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                    ElseIf ZeroAmtCount Then
                                        Call Status(SaveGoodArgVals, False, "Mass Update Service Item would be reduced to 0 or less for Contract " + SParm(bXSVCGRID.ContractID.Trim), LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                    ElseIf NoRevs = 0 Then
                                        Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Contains no Revenue Lines. Please Cancel, then Create a new contract.Split C/", LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                    ElseIf bsmContract.Status.Trim <> "A" Then   'mod 6/14/18
                                        Call Status(SaveGoodArgVals, False, "Contract " + SParm(bXSVCGRID.ContractID.Trim) + " Is not Active", LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                    ElseIf AllRevsProcessed = 1 Then   'mod 6/14/18
                                        Call Status(SaveGoodArgVals, False, "All Revenues have been processed for Contract " + SParm(bXSVCGRID.ContractID.Trim), LOG_AND_DISP)
                                        serr7 = MNext(GridHandle1, Maintflag)
                                    Else
                                        'mod 6/10/17 are there multiple records for same service item?
                                        XTB_Linenbr = 0
                                        SQLstmt = "xDELCHG_SingleChangeDelete" + SParm(bXSVCGRID.ContractID) + SParm(bxServItem.ServItemID)
                                        serr3 = SqlFetch1(c11, SQLstmt, XTB_Linenbr)
                                        If XTB_Linenbr = -1 Then
                                            XTB_Linenbr = GetXTB_LineNbr("Changed")
                                        End If
                                        If XTB_Linenbr Then gProcessChanges(XTB_Linenbr, bxServItem.GroupCode)
                                        DelFlag = True
                                    End If
                                    serr6 = SFetch1(c8, bxServItem)
                                Loop

                                Call SqlFree(c8)
                                If DelFlag = True Then
                                    serr7 = MDelete(GridHandle1, Maintflag)
                                    DelFlag = False
                                End If
                            End If
                        Else
                            serr7 = MNext(GridHandle1, Maintflag)
                        End If
                    Loop
                    serr7 = MFirst(GridHandle1, Maintflag)
                    Call MDisplay(GridHandle1)
                    Call Status(EndProcess, False, "", 0)
                End If
        End Select

    End Sub
    Function GetXTB_LineNbr(kind As String) As Short
        'mod 6/10/17
        'When Changes or Single Deletes contain multiple records for a service item -- user chooses one to process
        Call Status(StopProcess, False, "", 0)
        IsMultiDelete = False
        Call MClear(DelGridHandle)
        SQLstmt = "XMultiDeletes_Insert" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) 'mod 6/10 added servitemid as parm for single delete/change duplicate pop up box
        Call sql(CSR_xMultiDeletes, SQLstmt)
        Call MLoad(DelGridHandle, CSR_xMultiDeletes)
        FrmMultiDeletes.Text = "For Contractid " + SParm(bXSVCGRID.ContractID.Trim) + " Please select only 1 line item to be " + kind
        Call SetProps(FrmMultiDeletes, FrmMultiDeletes.btnDelReturn, FrmMultiDeletes.btnDelReturn, PROP_CAPTION, "Process") 'mod 11/12/17
        Call MDisplay(DelGridHandle)
        Call SetProps(FrmMultiDeletes, FrmMultiDeletes.Label40D, FrmMultiDeletes.txtinvprintsuppressD, PROP_VISIBLE, False)
        Call SetProps(FrmMultiDeletes, FrmMultiDeletes.lbldelsel, FrmMultiDeletes.txttotald, PROP_VISIBLE, False)
        Call DispForm(FrmMultiDeletes, True)
        ' need to tell the grid this is coming from process not multideltes need to traverse the grid, they can only select one.  What if they select nothing'&&&&&
        serr8 = MFirst(DelGridHandle, Maintflag)
        Dim linenbr As Short = 0  'mod 11/11/17 it's always assigned the multideletes.xtb_linenbr whether user selects of not
        Do While serr8 = 0
            If bDelselected.Value = 1 Then
                linenbr = bXMULTIDELETES.XTB_LineNbr
                Exit Do
            Else
                serr8 = MNext(DelGridHandle, Maintflag)
            End If
        Loop
        '   GetXTB_LineNbr = bXMULTIDELETES.XTB_LineNbr
        GetXTB_LineNbr = linenbr
        Call MClear(DelGridHandle)
        Call Status(StartProcess, False, "", 0)
    End Function

    Sub doRefresh()
        Call SetProps(Me, lblrefresh, lblrefresh, PROP_CAPTION, "(Grid Needs Refreshing)")
    End Sub

    Private Sub txtcustid_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtcustid.ChkEvent
        bMassUp.CopyClass(nMassUp) 'mod 6/7/17
        bMassUp.EffectDate = NULLDATE 'mod 6/7/17
        bXSVCFILTER.Siteid = ""
        lblRefreshWarn.Text = ""
        lblcancel.Text = ""
        Call DispFields(Me, PNULL, PNULL)
        doRefresh()
        'mod 4/6/17
        If bKeyid.ID = 8 Or bKeyid.ID = 9 Then
            bXSVCFILTER.ContractID = "" : Call DispField(txtcontid)
            bMassUp.BillwithContractProfile = "" : Call DispField(txtBillwithContractProfile)
            bMassUp.ContractProfile = "" : Call DispField(txtContractProfile)
        ElseIf bKeyid.ID = 3 Then
            Call SetProps(Me, txtrmramtM, txtrmramtM, PROP_ENABLED, False) 'mod 6/7/17
        End If
    End Sub

    Private Sub txtsiteid_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtsiteid.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtcontid_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtcontid.ChkEvent
        'Contractid
        Dim AllRevsProcessed As Integer = 0
        bMassUp.CopyClass(nMassUp) 'mod 5/23/17
        bMassUp.EffectDate = NULLDATE 'mod 6/3/17
        lblcancel.Text = ""
        lblbranchdesc.Text = ""
        lblRefreshWarn.Text = ""
        If bKeyid.ID <> 13 Then
            Call SetProps(Me, grpWarranty, txtwarrantyenddate, PROP_VISIBLE, False)
        End If
        If bKeyid.ID = 15 Then
            Call SetProps(Me, txtMaintAmt, txtMaintAmt, PROP_ENABLED, False)
            Call SetProps(Me, txtMonitAmt, txtMonitAmt, PROP_ENABLED, False)
        End If
        Call DispFields(Me, PNULL, PNULL)
        Call MClear(GridHandle1)
        Call MClear(Gridhandle2)

        doRefresh()

        ''mod 4/6/17
        If bKeyid.ID = 8 Or bKeyid.ID = 9 Then
            bXSVCFILTER.Custid = "" : Call DispField(txtcustid)
            SQLstmt = "select custid from smcontract where contractid = " + SParm(ChkStrg)
            serr2 = SqlFetch1(c2, SQLstmt, bcust)
            bXSVCFILTER.Custid = bcust.ID
            bMassUp.BillwithContractProfile = ""
            Call DispField(txtBillwithContractProfile)
            bMassUp.ContractProfile = ""
            Call DispField(txtContractProfile)
        End If

        If bKeyid.ID = 1 Or bKeyid.ID = 3 Then 'mod 6/14/18
            AllRevsProcessed = 0
            SQLstmt = "XSVCUPD_AllRevsProcessed" + SParm(ChkStrg)
            Call sql(c3, SQLstmt)
            Call SGroupFetch1(c3, AllRevsProcessed)
            If AllRevsProcessed Then
                Call MessBox("All Revenues have been processed for" + vbCrLf + "Contract " + SParm(ChkStrg), 48, "MassUpdate Message")
                RetVal = ErrNoMess
                Exit Sub
            End If
        End If


        If bKeyid.ID < 3 Then  'mod 3/28/17
            bXSVCGRID.ContractID = ChkStrg 'mod 3/22/17
            If bKeyid.ID <> 2 Then Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, True)
            If ChkStrg.Trim = "" Then
                'Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, True)
                Call SetProps(Me, BtnAddDel, BtnAddDel, PROP_VISIBLE, False)
                If bKeyid.ID = 1 Then
                    Call MClear(AddGridHandle)
                    lblsystemtype.Text = "System Type (Required)"
                    Call SetProps(Me, txtSystemType, txtSystemType, PROP_VISIBLE, True)
                ElseIf bKeyid.ID = 2 Then
                    Call MClear(DelGridHandle)
                    Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, False)
                    Call SetProps(Me, lblcancelA, lblcancel, PROP_VISIBLE, True)
                End If
            Else
                'Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, True)
                Call SetProps(Me, BtnAddDel, BtnAddDel, PROP_VISIBLE, True)

                If bKeyid.ID = 1 Then
                    Call MClear(AddGridHandle)
                    BtnAddDel.Text = "Add Multiple Service Items"
                    Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, True)
                    lblsystemtype.Text = "System Type (Required)"
                    Call SetProps(Me, txtSystemType, txtSystemType, PROP_VISIBLE, True)
                ElseIf bKeyid.ID = 2 Then
                    bXSVCFILTER.ContractID = ChkStrg
                    Call MClear(DelGridHandle)
                    BtnAddDel.PerformClick()
                End If
            End If
        ElseIf bKeyid.ID = 3 Then
            Call SetProps(Me, txtrmramtM, txtrmramtM, PROP_ENABLED, False) 'mod 6/8/17
        End If

        If bKeyid.ID = 13 Then                                                                                              '8/29/2019 - RMR Changes to add Warranty Duration End Date.
            If bMassUp.WarrantyEndDate <= 0 And bMassUp.WarrantyStartDate <= 0 And Trim$(bMassUp.Duration) = "" Then        '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                SQLstmt = "select User7, User1 from smcontract where contractid = " + SParm(ChkStrg)                        '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                serr2 = SqlFetch1(c2, SQLstmt, bWarrantyDur)                                                                '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                If serr2 <> NOTFOUND Then                                                                                   '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                    If Trim$(bWarrantyDur.User1) <> "" And bWarrantyDur.User7 > 0 Then                                      '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                        bMassUp.WarrantyEndDate = bWarrantyDur.User7                                                        '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                        bMassUp.Duration = bWarrantyDur.User1                                                               '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                        Call DatePlusDays(bMassUp.WarrantyEndDate, -(bMassUp.Duration - IIf(bMassUp.Duration = 0, 0, 1)), bMassUp.WarrantyStartDate)  '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                        Call DispField(txtwarrantystartdate)                                                                '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                        Call DispField(txtwarrantyenddate)                                                                  '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                        Call DispField(txtdurationA)                                                                        '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                    End If                                                                                                  '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                End If                                                                                                      '8/29/2019 - RMR Changes to add Warranty Duration End Date.
            End If                                                                                                          '8/29/2019 - RMR Changes to add Warranty Duration End Date.
        End If                                                                                                              '8/29/2019 - RMR Changes to add Warranty Duration End Date.

    End Sub

    Private Sub txtbranchid_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtbranchid.ChkEvent
        doRefresh()
    End Sub
    Private Sub txtContractProfile_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtContractProfile.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtBillwithContractProfile_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtBillwithContractProfile.ChkEvent
        doRefresh()
        If ChkStrg.Trim = "NONE" Then RetVal = NoAutoChk
    End Sub
    Private Sub txtstartdatebeg_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtstartdatebeg.ChkEvent
        doRefresh()
    End Sub
    Private Sub txtstartdateend_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtstartdateend.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtexpiredatebeg_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtexpiredatebeg.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtexpiredateend_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtexpiredateend.ChkEvent
        doRefresh()
    End Sub
    Private Sub txtservitemid_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtservitemid.ChkEvent
        doRefresh()
    End Sub

    Private Sub txttbmasterid_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txttbmasterid.ChkEvent
        doRefresh()
    End Sub
    Private Sub txtservitemSelM_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtservitemSelM.ChkEvent
        Dim Numrecs As Integer = 0
        bMassUp.RMRAmt = 0
        Call DispField(txtrmramtM)
        If bKeyid.ID = 1 Then
            SQLstmt = "xAdd_WarTest" + SParm(ChkStrg)
            Call sql(c3, SQLstmt)
            serr3 = SGroupFetch1(c3, Numrecs)
            If Numrecs Then
                Call SetProps(Me, grpWarranty, txtwarrantyenddate, PROP_VISIBLE, True)
            Else
                'mod 12/9/16
                bMassUp.WarrantyEndDate = nMassUp.WarrantyEndDate
                bMassUp.WarrantyStartDate = nMassUp.WarrantyStartDate
                bMassUp.Duration = nMassUp.Duration
                Call DispFields(Me, txtwarrantystartdate, txtwarrantyenddate)
                Call SetProps(Me, grpWarranty, txtwarrantyenddate, PROP_VISIBLE, False)
            End If
        End If

        doRefresh()
    End Sub

    Private Sub txtrmramtM_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtrmramtM.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtRetroM_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16)
        doRefresh()
    End Sub

    Private Sub txtgoingforwardM_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16)
        doRefresh()
    End Sub

    Private Sub txteffectdateM_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txteffectdateM.ChkEvent
        doRefresh()
    End Sub
    Private Sub txtmasterid_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtmasterid.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtparent_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtparent.ChkEvent
        doRefresh()
    End Sub
    Private Sub txtinvprintsuppress_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtinvprintsuppress.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtcancelcode_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtcancelcode.ChkEvent
        RetVal = PVChkFetch1(txtcancelcode, c3, ChkStrg, bsmCancellation)
        lblcancel.Text = bsmCancellation.CancellationDesc
        doRefresh()
    End Sub

    Private Sub txtrenewaltype_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtrenewaltype.ChkEvent
        doRefresh()
    End Sub
    Private Sub cmdClearFilters_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearFilters.Click
        bXSVCFILTER.CopyClass(nXSVCFILTER)
        Call SetProps(Me, lblrefresh, lblrefresh, PROP_CAPTION, "")
        MClear(GridHandle1)
        MClear(Gridhandle2)
        bMassUp.CopyClass(nMassUp)
        lblcancel.Text = ""
        lblbranchdesc.Text = ""
        lblRefreshWarn.Text = ""
        Call DispFields(Me, PNULL, PNULL)
        'mod /23/17
        If bKeyid.ID = 1 Or bKeyid.ID = 2 Then
            Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, True)
            'Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, True)
            Call SetProps(Me, BtnAddDel, BtnAddDel, PROP_VISIBLE, False)
            If bKeyid.ID = 1 Then
                Call MClear(AddGridHandle)
            ElseIf bKeyid.ID = 2 Then
                Call MClear(DelGridHandle)
                Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, False)
                Call SetProps(Me, lblcancelA, lblcancel, PROP_VISIBLE, True)
            End If
        ElseIf bKeyid.ID = 3 Then
            Call SetProps(Me, txtrmramtM, txtrmramtM, PROP_ENABLED, False) 'mod 6/7/17
        ElseIf bKeyid.ID = 10 Then
            bXSVCFILTER.RenewalType = "MY" 'mod 10/17/17
            Call DispField(txtrenewaltype) 'mod 3/23/18
            Call SetProps(Me, txtrenewaltype, txtrenewaltype, PROP_ENABLED, True)
        End If
    End Sub


    Private Sub txtdurationA_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtdurationA.ChkEvent
        Dim duration As Short = Val(ChkStrg)
        If bMassUp.WarrantyStartDate > 0 Then
            Call DatePlusDays(bMassUp.WarrantyStartDate, (duration - IIf(duration = 0, 0, 1)), bMassUp.WarrantyEndDate) 'mod 7/7/17
            Call DispField(txtwarrantyenddate)
        Else                                         '8/29/2019 - RMR Changes to add Warranty Duration End Date.
            If bMassUp.WarrantyEndDate > 0 Then      '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                Call DatePlusDays(bMassUp.WarrantyEndDate, -(duration - IIf(duration = 0, 0, 1)), bMassUp.WarrantyStartDate) '8/29/2019 - RMR Changes to add Warranty Duration End Date.
                Call DispField(txtwarrantystartdate) '8/29/2019 - RMR Changes to add Warranty Duration End Date.                                          
            End If                                   '8/29/2019 - RMR Changes to add Warranty Duration End Date.
        End If
        doRefresh()
    End Sub

    Private Sub txtwarrantystartdate_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtwarrantystartdate.ChkEvent
        If bMassUp.Duration.Trim > "" Then
            Dim duration As Short = Val(bMassUp.Duration), dat As Integer
            Call StrToDate(ChkStrg, dat)
            Call DatePlusDays(dat, (duration - IIf(duration = 0, 0, 1)), bMassUp.WarrantyEndDate)  'mod 7/7/17
            Call DispField(txtwarrantyenddate)
            bMassUp.WarrantyStartDate = dat
        End If
        doRefresh()
    End Sub


    Private Sub txtfrequencyM_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtfrequencyM.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtcontractstartdate_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtcontractstartdate.ChkEvent
        doRefresh()
    End Sub

    'mod 7/11/2019 - Disallow entry of mid-month dates. Disable refresh button until valid date entry/key id change - Solomon Cloud Solutions
    Private Sub txtcontractEndDate_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtcontractEndDate.ChkEvent
        Dim Numrecs As Integer = 0

        If IsLastDay(txtcontractEndDate.Value()) = True Then
            If bKeyid.ID = 5 And Trim$(bXSVCFILTER.ContractID) <> "" Then                          '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                SQLstmt = "XSVCU00_MasterContractID" + SParm(bXSVCFILTER.ContractID.Trim)          '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                serr5 = SqlFetch1(c5, SQLstmt, Numrecs)                                            '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                If Numrecs Then                                                                    '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    Call MsgBox("This Contract is tied to a Master Customer Contract and the End Date cannot be changed.")  '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    Call SetProps(Me, btnRefreshGrid, btnRefreshGrid, PROP_ENABLED, LFALSE)        '11/05/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    Exit Sub
                End If
            End If
            doRefresh()
            Call SetProps(Me, btnRefreshGrid, btnRefreshGrid, PROP_ENABLED, LTRUE)
        Else
            retval = 0
            Call MessBox("Please enter a month-ending date", 48, "Massup Messsage")
            Call SetProps(Me, btnRefreshGrid, btnRefreshGrid, PROP_ENABLED, LFALSE)
        End If
    End Sub
    'mod 7/11/2019 - Check if date is last day of month - Solomon Cloud Solutions
    Function IsLastDay(ByVal myDate As Date) As Boolean
        Return myDate.Day = Date.DaysInMonth(myDate.Year, myDate.Month)
    End Function

    Private Sub txtBranch_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtBranch.ChkEvent
        doRefresh()
        If ChkStrg.Trim = "" Then
            RetVal = NoAutoChk
            lblbranchdesc.Text = ""
        Else
            RetVal = PVChkFetch1(txtBranch, c3, ChkStrg, bsmBranch)
            lblbranchdesc.Text = bsmBranch.Name
        End If
    End Sub

    Private Sub OptDummy_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles OptDummy.ChkEvent
        Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_ENABLED, True)
        bMassUp.RMRAmt = 0
        Call DispField(txtrmramtM)
        Select Case ChkStrg
            Case 1
                ChangeRMRAmtOpt = 1
                txtrmramtM.Min = -9999999999.99
            Case 2
                ChangeRMRAmtOpt = 2
                txtrmramtM.Min = 0.01
            Case 3 'Mod 9/10/2019 - Solomon Cloud Solutions - Change by pct amount
                ChangeRMRAmtOpt = 3
                txtrmramtM.Min = -100
        End Select
    End Sub

    Private Sub GrpFilters_Enter(sender As System.Object, e As System.EventArgs) Handles GrpFilters.Enter
        'mod 3/20/17
        If bKeyid.ID = 0 Then
            Call MessBox("Please Select a keyid", 48, "MassUpdate Message")
            Call ApplSetfocus(txtkeyid)
        End If
    End Sub

    Private Sub BtnAddDel_Click(sender As System.Object, e As System.EventArgs) Handles BtnAddDel.Click
        SQLstmt = "smcontract_all" + SParm(bXSVCFILTER.ContractID)
        serr8 = SqlFetch1(c8, SQLstmt, bsmContract)
        Select Case bKeyid.ID
            Case 1
                Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, False)
                Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, False)
                Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, False)
                Call SetProps(Me, txtSystemType, txtSystemType, PROP_VISIBLE, False)
                lblsystemtype.Text = ""
                Call DispForm(FrmMultiAdds, True)
                'mod 10/30/17
                If MArrayCnt(AddGridHandle) = 0 Then
                    'display single add
                    Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, True)
                    'Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, True)
                    Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, True)
                    Call SetProps(Me, txtSystemType, txtSystemType, PROP_VISIBLE, True)
                    lblsystemtype.Text = "System Type (Required)"
                End If
            Case 2
                Call DispField(FrmMultiDeletes.txttotald)
                Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, False)
                Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, False)
                Call SetProps(Me, lblcancelA, lblcancel, PROP_VISIBLE, False)
                Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, False)
                If bTotDel.Total = 0 Then  'don't clear grid if there are any selected records from the last time grid was populated
                    IsMultiDelete = True  'differentiate between when it is multi deletes and grid used for duplicate servitems for changes & single deletes
                    SQLstmt = "XMultiDeletes_Insert" + SParm(bXSVCFILTER.ContractID) + SParm(SQLWILDSTRING) 'mod 6/10 added servitemid as parm for single delete/change duplicate pop up box
                    Call sql(CSR_xMultiDeletes, SQLstmt)
                    Call MLoad(DelGridHandle, CSR_xMultiDeletes)
                    FrmMultiDeletes.Text = "Delete Service Items"
                    'Call SetProps(FrmMultiDeletes, FrmMultiDeletes.Label40D, FrmMultiDeletes.txtinvprintsuppressD, PROP_VISIBLE, True)
                    Call SetProps(FrmMultiDeletes, FrmMultiDeletes.lbldelsel, FrmMultiDeletes.txttotald, PROP_VISIBLE, True)
                    Call SetProps(FrmMultiDeletes, FrmMultiDeletes.btnDelReturn, FrmMultiDeletes.btnDelReturn, PROP_CAPTION, "Return")
                    Call MDisplay(DelGridHandle)
                End If
                NumRecsWithAmts = 0
                SQLstmt = "XServItems_withAmts" + SParm(bXSVCFILTER.ContractID)
                serr3 = SqlFetch1(c3, SQLstmt, NumRecsWithAmts)
                Call DispForm(FrmMultiDeletes, True)
                'mod 11/9/17 display single delete
                If bTotDel.Total = 0 Then
                    Call SetProps(Me, lblservitemsel, txteffectdateM, PROP_VISIBLE, True)
                    'Call SetProps(Me, txtinvprintsuppress, txtinvprintsuppress, PROP_VISIBLE, True)
                    Call SetProps(Me, lblcancelA, lblcancel, PROP_VISIBLE, True)
                    Call SetProps(Me, lblMassAmt, txtrmramtM, PROP_VISIBLE, False) 'mod 11/13/17
                End If
        End Select
    End Sub

    Private Sub Update1_UpdateEvent(Level As System.Int16, InsertFlg As System.Int16, LevelsDone As System.Int16, LevelsLeft As System.Int16, ByRef RetVal As System.Int16) Handles Update1.UpdateEvent
        RetVal = NoAction
    End Sub
    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'mod 6/9/17
        SQLstmt = "xRenewDelete_byuserid" + SParm(bpes.UserId) '&&&&
        Call sql(c8, SQLstmt)
        'Standard Screen Exit Call
        Call ScreenExit("", "")

    End Sub

    Private Sub txtselected_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtselected.ChkEvent
        Dim Numrecs As Integer = 0
        Dim ActualEffectDate As Integer = Math.Max(bMassUp.EffectDate, IIf(Val(bMassUp.Duration) > 0, bMassUp.WarrantyEndDate + 1, 0))
        Dim xWarrItem_CSR As Short                      '4/10/2020 Warranty Items added to Table.
        Dim xWarr_Flg As Short                          '4/10/2020 Warranty Items added to Table.

        If ChkStrg = 1 Then
            'mod 11/13/17
            If bKeyid.ID = 1 Then

                'Call SqlCursorEx(xWarrItem_CSR, NOLEVEL, "xWarrItem_CSR", "xWarrantyItem", "")                                 '4/10/2020 Warranty Items added to Table.
                'xWarr_Flg = SqlFetch1(xWarrItem_CSR, "xWarrantyItem_All" + SParm(bMassUp.ServItemSel.Trim), bxWarrantyItem)    '4/10/2020 Warranty Items added to Table.
                'If xWarr_Flg <> NOTFOUND Then                                                                                  '4/10/2020 Warranty Items added to Table.

                Select Case bMassUp.ServItemSel.Trim                                                                      '4/10/2020 Warranty Items added to Table.
                    Case "C OPTION A", "CP OPTION A", "CP OPTION D", "CP OPTION D 4 HOUR"                                 '4/10/2020 Warranty Items added to Table.
                        SQLstmt = "xadd_warrantyLimit" + SParm(bXSVCGRID.ContractID.Trim)
                        serr5 = SqlFetch1(c5, SQLstmt, Numrecs)
                        If Numrecs Then
                            retval = ErrNoMess
                            Call SqlFree(xWarrItem_CSR)                                                                            '4/10/2020 Warranty Items added to Table.
                            Exit Sub
                        End If
                End Select                                                                                                '4/10/2020 Warranty Items added to Table.
                'End If                                                                                                         '4/10/2020 Warranty Items added to Table.
                Call SqlFree(xWarrItem_CSR)                                                                                    '4/10/2020 Warranty Items added to Table.
            End If
            Numrecs = 0
            Select Case bKeyid.ID
                Case 1
                    If gReversalWarning("Additions", ActualEffectDate, 0) Then
                        retval = ErrNoMess
                        Exit Sub
                    End If
                Case 2
                    If gReversalWarning("Cancels", ActualEffectDate, 0) Then
                        retval = ErrNoMess
                        Exit Sub
                    End If
                Case 3
                    If gReversalWarning("Changes", ActualEffectDate, 0) Then
                        retval = ErrNoMess
                        Exit Sub
                    End If
            End Select
            If bKeyid.ID = 5 Then                         '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                SQLstmt = "XSVCU00_MasterContractID" + SParm(bXSVCGRID.ContractID.Trim)  '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                serr5 = SqlFetch1(c5, SQLstmt, Numrecs)                                  '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                If Numrecs Then                                                          '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    Call MsgBox("This Contract is tied to a Master Customer Contract and the End Date cannot be changed.")  '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                    retval = ErrNoMess                                                   '6/27/2019 - RMR Changes - If Master Contract Exists, then user cannot change End Date.
                End If
            End If
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, True)
        ElseIf bSelGrid.Sel < 2 Then
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)
        End If
    End Sub

    Private Sub txtSelectedRenewals_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtSelectedRenewals.ChkEvent
        If ChkStrg = 1 Then
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, True)
        ElseIf bSelGrid.Sel < 2 Then
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)
        End If
    End Sub

    Private Sub txtInvcFormat_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtInvcFormat.ChkEvent
        doRefresh()
    End Sub

    Private Sub txtInvoiceRule_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtInvoiceRule.ChkEvent
        doRefresh()
    End Sub

    'mod 6/27/2019 - Escalations tab - Solomon Cloud Solutions
    Private Sub txtSelectedEscalations_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtSelectedEscalations.ChkEvent
        If ChkStrg = 1 Then
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, True)
        ElseIf bSelGrid.Sel < 2 Then
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, False)
        End If
    End Sub
    'mod 6/27/2019 - Excel Import Button - Solomon Cloud Solutions
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim WBName As String = ""
        Dim WBPath As String = ""
        OpenWB(WBName, WBPath)

        ExcelImport(WBName, WBPath)

        If bSelGrid.Sel <> 0 Then
            Call SetProps(Me, cBegProcessing, cBegProcessing, PROP_ENABLED, True)
        End If
    End Sub
    'mod 6/27/2019 - Excel Import Button - Solomon Cloud Solutions
    Private Sub ExcelImport(WBName As String, WBPath As String)
        Dim objApp As Microsoft.Office.Interop.Excel.Application
        Dim objBooks As Microsoft.Office.Interop.Excel.Workbooks
        Dim WB As Workbook
        Dim WS As Worksheet
        Dim CurrRow As Integer = 2
        Dim OrigRowNum As Short
        Dim Selected As String
        Try

            Call Status(StartProcess, False, "", 0)
            Call Status(SaveGoodArgVals, False, "Importing Escalations Grid from Excel...", DISP_ONLY)

            'Set bSelGrid.Sel to 0
            bSelGrid.Sel = 0

            ' Create a new instance of Excel and start a new workbook.
            objApp = New Microsoft.Office.Interop.Excel.Application()
            objBooks = objApp.Workbooks

            WB = objBooks.Open(WBPath)
            'RowCount = WB.Worksheets("XSVCU").Range("B1:B" & Cells(Rows.Count, "B").End(xlUp).Row).Rows.Count
            WS = WB.Worksheets("XSVCU")
            OrigRowNum = MGetRowNum(GridHandle3)
            Call MFirst(GridHandle3, Maintflag)

            Do While WS.Cells(CurrRow, 1).Value <> ""
                Selected = WS.Cells(CurrRow, 1).Value
                Selected = Selected.ToUpper()
                If Selected.Trim = "YES" Then
                    bSelectedEscal.Value = 1
                    bSelGrid.Sel = bSelGrid.Sel + 1
                Else
                    bSelectedEscal.Value = 0
                End If
                bxEscalate.PctMaint = WS.Cells(CurrRow, 9).Value
                bxEscalate.PctMonitor = WS.Cells(CurrRow, 10).Value

                CurrRow = CurrRow + 1
                Call MUpdate(GridHandle3)
                Call MNext(GridHandle3, Maintflag)
            Loop


            'Call MDisplay(GridHandle3)
            Call MSetRow(GridHandle3, OrigRowNum)
            'Call MUpdate(GridHandle3)
            Call MDisplay(GridHandle3)

            Call Status(EndProcess, False, "Import Complete.", DISP_ONLY)

        Catch ex As Exception
            Call Status(EndProcess, False, "Error Importing from Excel. Process Aborted.", DISP_ONLY)
        Finally
            If Not WB Is Nothing Then
                WB.Close()
                'Clean up a little.
                WB = Nothing
            End If
        End Try
    End Sub
    'mod 6/27/2019 - Excel Import Button - Solomon Cloud Solutions
    <STAThread()> _
    Private Sub OpenWB(ByRef WBName As String, ByRef WBPath As String)
        Dim strFileToOpen As String
        Dim CharNum As Integer
        Dim OpenFileDialog1 As New OpenFileDialog
        'strFileToOpen = XLSApp.GetOpenFilename(Title:="Choose Excel Workbook to Import", FileFilter:="Excel Files *.xls* (*.xls*),")
        OpenFileDialog1.Title = "Choose Excel Workbook to Import"
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Filter = "Excel Files|*.xls*"
        OpenFileDialog1.ShowHelp = True
        OpenFileDialog1.ShowDialog()
        strFileToOpen = OpenFileDialog1.FileName

        If strFileToOpen = Nothing Or strFileToOpen = "" Or Not strFileToOpen Like "*.xls*" Then
            MsgBox("Invalid File Selected.", vbExclamation, "Error")
            Exit Sub
        Else
            WBPath = strFileToOpen
            CharNum = InStrRev(Trim(strFileToOpen), "\", -1, vbTextCompare)
            CharNum = strFileToOpen.Length - CharNum
            WBName = Trim(Strings.Right(strFileToOpen, CharNum))
        End If
        OpenFileDialog1 = Nothing
    End Sub

    Private Sub btnViewSC_Esc_Click(sender As Object, e As EventArgs) Handles btnViewSC_Esc.Click
        'mod 11/29/16 added contractid for xsvcupd contractid filter
        Dim contractid As String = IIf(bXSVCFILTER.ContractID.Trim > "", bXSVCFILTER.ContractID, "%")
        Dim parms As String = ""
        Call MUpdate(GridHandle3)
        With bxEscalate
            SQLstmt = "delete from xrenewpassit where userid = " + SParm(bpes.UserId)
            Call sql(c8, SQLstmt)
            SQLstmt = "Insert into xrenewpassit Values(" + SParm(.Custid) + "," + SParm(.Name) + "," + IParm(.Duration) + "," + SParm(.InvoicingRule) + "," + SParm(.Frequency) + "," + FParm(bMassUp.RMRAmt) + "," + DParm(.EscalationDate) + "," + SParm(.SameServices) + "," + SParm(bpes.UserId) + "," + SParm(contractid) + "," + FParm(.PctMaint) + "," + FParm(.PctMonitor) + "," + SParm(.Profile) + ",NULL)"
            Call sql(c8, SQLstmt)
            Call SqlFree(c8)
        End With

        SQLstmt = "UPDATE_xRenewContracts_EscRen" + FParm(bxEscalate.PctMaint) + FParm(bxEscalate.PctMonitor) + IParm(bxEscalate.Duration) + SParm(bpes.UserId)               '10/18/2019 Issue 6.06 Correcting View Service Contracts for Review
        Call sql(c10, SQLstmt)                                                                                                                   '10/18/2019 Issue 6.06 Correcting View Service Contracts for Review
        'Call sql(c10, "UPDATE xRenewContracts SET PctMaint =" + IParm(bxEscalate.PctMaint) + ", PctMonitor = " + IParm(bxEscalate.PctMonitor))  '10/18/2019 Issue 6.06 Correcting View Service Contracts for Review
        Call SqlFree(c10)
        Call CallApplicWait("XSVCUPV", "")
    End Sub

    Private Sub txtwarrantyenddate_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtwarrantyenddate.ChkEvent   '8/29/2019 - RMR Changes to add Warranty Duration End Date.
        If bMassUp.Duration.Trim > "" Then                                                            '8/29/2019 - RMR Changes to add Warranty Duration End Date.
            Dim duration As Short = Val(bMassUp.Duration), dat As Integer                             '8/29/2019 - RMR Changes to add Warranty Duration End Date.
            Call StrToDate(ChkStrg, dat)                                                              '8/29/2019 - RMR Changes to add Warranty Duration End Date.
            Call DatePlusDays(dat, -(duration - IIf(duration = 0, 0, 1)), bMassUp.WarrantyStartDate)  '8/29/2019 - RMR Changes to add Warranty Duration End Date.
            Call DispField(txtwarrantystartdate)                                                      '8/29/2019 - RMR Changes to add Warranty Duration End Date.
            bMassUp.WarrantyEndDate = dat                                                             '8/29/2019 - RMR Changes to add Warranty Duration End Date.
        End If                                                                                        '8/29/2019 - RMR Changes to add Warranty Duration End Date.
        doRefresh()                                                                                   '8/29/2019 - RMR Changes to add Warranty Duration End Date.
    End Sub                                                                                           '8/29/2019 - RMR Changes to add Warranty Duration End Date.

    Private Sub chkMaintAmt_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles chkMaintAmt.ChkEvent
        If ChkStrg = 1 Then
            Call SetProps(Me, txtMaintAmt, txtMaintAmt, PROP_ENABLED, True)
        Else
            Call SetProps(Me, txtMaintAmt, txtMaintAmt, PROP_ENABLED, False)
        End If
    End Sub

    Private Sub chkMonitAmt_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles chkMonitAmt.ChkEvent
        If ChkStrg = 1 Then
            Call SetProps(Me, txtMonitAmt, txtMonitAmt, PROP_ENABLED, True)
        Else
            Call SetProps(Me, txtMonitAmt, txtMonitAmt, PROP_ENABLED, False)
        End If
    End Sub

    Private Sub txtMaintAmt_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtMaintAmt.ChkEvent
        If CDec(ChkStrg) <> 0 And Math.Abs(CDec(ChkStrg)) < 1 And ChangeRMRAmtOpt = 3 Then
            retval = ErrNoMess
            Call MessBox("Maintenance Percentage cannot be smaller than 1%", 48, "Massupdate Msg")
        Else
            doRefresh()
        End If
    End Sub

    Private Sub txtMonitAmt_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtMonitAmt.ChkEvent
        If CDec(ChkStrg) <> 0 And Math.Abs(CDec(ChkStrg)) < 1 And ChangeRMRAmtOpt = 3 Then
            retval = ErrNoMess
            Call MessBox("Monitoring Percentage cannot be smaller than 1%", 48, "Massupdate Msg")
        Else
            doRefresh()
        End If
    End Sub

    Private Sub txtpctmaint_Esc_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtpctmaint_Esc.ChkEvent
        If CDec(ChkStrg) <> 0 And Math.Abs(CDec(ChkStrg)) < 1 Then
            retval = ErrNoMess
            Call MessBox("Maintenance Percentage cannot be smaller than 1%", 48, "Massupdate Msg")
        Else
            bXRENEWCONTRACTS.PctMaint = CInt(ChkStrg)
        End If
    End Sub

    Private Sub txtpctmonitor_Esc_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtpctmonitor_Esc.ChkEvent
        If CDec(ChkStrg) <> 0 And Math.Abs(CDec(ChkStrg)) < 1 Then
            retval = ErrNoMess
            Call MessBox("Monitoring Percentage cannot be smaller than 1%", 48, "Massupdate Msg")
        Else
            bXRENEWCONTRACTS.PctMonitor = CInt(ChkStrg)
        End If
    End Sub

    Private Sub txtpctmaint_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtpctmaint.ChkEvent
        If CDec(ChkStrg) <> 0 And Math.Abs(CDec(ChkStrg)) < 1 Then
            retval = ErrNoMess
            Call MessBox("Maintenance Percentage cannot be smaller than 1%", 48, "Massupdate Msg")
        End If
    End Sub

    Private Sub txtpctmonitor_ChkEvent(ByRef ChkStrg As String, ByRef retval As Short) Handles txtpctmonitor.ChkEvent
        If CDec(ChkStrg) <> 0 And Math.Abs(CDec(ChkStrg)) < 1 Then
            retval = ErrNoMess
            Call MessBox("Monitoring Percentage cannot be smaller than 1%", 48, "Massupdate Msg")
        End If
    End Sub
End Class
