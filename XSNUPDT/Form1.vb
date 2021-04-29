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
Imports System.Globalization

Friend Class Form1
    Inherits System.Windows.Forms.Form

    Protected m_IsInitializing As Boolean
    Protected ReadOnly Property IsInitializing() As Boolean
        Get
            Return m_IsInitializing
        End Get
    End Property
    Class GetCredits
        Inherits SolomonDataObject
        < _
              DataBinding(PropertyIndex:=0) _
              > _
        Public Property TotPostings() As Double

            Get
                Return Me.GetPropertyValue("TotPostings")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("TotPostings", setval)
            End Set

        End Property
        < _
          DataBinding(PropertyIndex:=1) _
          > _
        Public Property User3() As Double

            Get
                Return Me.GetPropertyValue("User3")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("User3", setval)
            End Set

        End Property
        < _
  DataBinding(PropertyIndex:=2) _
  > _
        Public Property User4() As Double

            Get
                Return Me.GetPropertyValue("User4")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("User4", setval)
            End Set

        End Property
        < _
               DataBinding(PropertyIndex:=3) _
               > _
        Public Property MaxPostDate() As Integer

            Get
                Return Me.GetPropertyValue("MaxPostDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("MaxPostDate", setval)
            End Set

        End Property
        < _
            DataBinding(PropertyIndex:=4) _
            > _
        Public Property CreditDate() As Integer

            Get
                Return Me.GetPropertyValue("CreditDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("CreditDate", setval)
            End Set

        End Property
    End Class
    Dim bGetCredits As GetCredits = New GetCredits, nGetCredits As GetCredits = New GetCredits

    'mod 7/1/17
    Class billfreq
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=1) _
        > _
        Public Property Freq() As String

            Get
                Return Me.GetPropertyValue("Freq")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Freq", setval)
            End Set

        End Property
    End Class
    Dim bBillfreq As billfreq = New billfreq


    Class FirstAdj
        Inherits SolomonDataObject
        < _
              DataBinding(PropertyIndex:=0) _
              > _
        Public Property OpenBillAmt() As Double

            Get
                Return Me.GetPropertyValue("OpenBillAmt")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("OpenBillAmt", setval)
            End Set

        End Property
        < _
          DataBinding(PropertyIndex:=1) _
          > _
        Public Property User3() As Double

            Get
                Return Me.GetPropertyValue("User3")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("User3", setval)
            End Set

        End Property
        < _
  DataBinding(PropertyIndex:=2) _
  > _
        Public Property User4() As Double

            Get
                Return Me.GetPropertyValue("User4")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("User4", setval)
            End Set

        End Property
        < _
               DataBinding(PropertyIndex:=3) _
               > _
        Public Property OpenBillDate() As Integer

            Get
                Return Me.GetPropertyValue("OpenBillDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("OpenBillDate", setval)
            End Set

        End Property
    End Class
    Dim bFirstAdj As FirstAdj = New FirstAdj, nFirstAdj As FirstAdj = New FirstAdj

    Dim Gridhandle As Short, Maintflag As Short, CSR_PriorRev As Short, PassedFromXSVCUPDT As Boolean = False
    Dim CSR_xsvcgrid As Short, HoldEffectDate As Integer = 0
    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'This is an old version, Version M. My current version emailed to Diebold is Version R.
        ' Load all the forms needed for this application
        'Call LoadForm(fSL01001)
        'mod 7/15/17
        'added code to conpensate for mass update use of 31 days in a 31 day month
        'added code to add (in memory) 1 add'l day to xtb_services.statusdate if date same as smcontract.user7
        'added code to determine whether a warranty item was treated as such
        'added code to revenues re: issue for finding first date -- when no record found for smcontract.startdate (i.e. warranty items only)

        ' Initialize the application as a Microsoft Dynamics SL Application
        Call ApplInit()


        Call SetAddr(LEVEL0, "bmassup", bMassUp, bMassUp)
        Call SetAddr(LEVEL1, "bXSVCGrid", bXSVCGRID, nXSVCGRID)   'gridhandle1

        Call SqlCursorEx(CSR_xsvcgrid, LEVEL1 + SqlList + SqlFastReadOnly, "CSR_XSVCGrid", "XSVCGRID", "")
        Call SqlCursorEx(CSR_SMContract, NOLEVEL, "CSR_SMContract", "SMContract", "SMContract")
        Call SqlCursorEx(CSR_SMContractBill, NOLEVEL, "CSR_SMContractBill", "SMContractBill", "SMContractBill")
        Call SqlCursorEx(CSR_SMContractRev, NOLEVEL, "CSR_SMContractRev", "SMContractRev", "SMContractRev")
        Call SqlCursorEx(CSR_XTB_SMContract, NOLEVEL, "CSR_XTB_SMContract", "XTB_SMContract", "XTB_SMContract")
        Call SqlCursorEx(CSR_XTB_Services, NOLEVEL, "CSR_XTB_Services", "XTB_Services", "XTB_Services")
        Call SqlCursorEx(CSR_xSvcUpdHist, NOLEVEL, "CSR_xSrvUpdHist", "XSVCUPDHIST", "XSVCUPDHIST")
        Call SqlCursorEx(CSR_PriorRev, NOLEVEL + SqlFastReadOnly, "CSR_priorRev", "", "")
        Call SqlCursorEx(CSR_CreditMonths, NOLEVEL + SqlFastReadOnly, "CSR_CreditMonths", "", "")
        ' Call the screen init function
        Call ScreenInit()

        Gridhandle = DetailSetup(CSR_xsvcgrid, DslGrid1, PNULL, bXSVCGRID, PNULL, PNULL, PNULL)
        Call SetButton(TbSaveButton, AllLevels, False)

        Call GetSysDate(Curdate)
        CurUser = bpes.UserId
        CurProg = "XSNUPDT"

        'mod 4/28/17 called by XSVCUPD
        bXSVCGRID.ContractID = ApplGetParmValue(PRMSECTION_VBRDT, "Contractid")
        If bXSVCGRID.ContractID.Trim > "" Then
            Dim effectdatestr As String = ApplGetParmValue(PRMSECTION_VBRDT, "EffectDate")
            Call StrToDate(effectdatestr, bMassUp.EffectDate)
            '  Call DatePlusMonthSetDay(bMassUp.EffectDate, 0, 1, bMassUp.EffectDate)
            bMassUp.CancelCode = ApplGetParmValue(PRMSECTION_VBRDT, "CancelCode")
            Call MInsert(Gridhandle)
            PassedFromXSVCUPDT = True
            btnProcess.PerformClick()
        End If
    End Sub

    Private Sub btnProcess_Click(sender As System.Object, e As System.EventArgs) Handles btnProcess.Click
        Dim EffectDate As Integer = 0, EffectDateDay1 As Integer = 0, Testdate As Integer = 0, Numrecs As Integer = 0
        Dim Contractid As String, ExpireDate As Integer
        Dim AllProcessed As Integer = 0
        Dim CurrDate As Integer
        Dim StartDate As Integer '7/16/2019 - Going to create new process if whole contract is being cancelled.
        Dim StartFlg As Short '7/16/2019 - Going to create new process if whole contract is being cancelled.
        Dim NbrOfDaysFrmStart As Integer    '7/16/2019 - Going to create new process if whole contract is being cancelled.
        Dim xInvPrintSuppress As String

        'mod 11/8/17
        If MArrayCnt(Gridhandle) = 0 Then
            Call MessBox("No records to process", 48, "")
            Exit Sub
        End If
        'mod 7/18/17
        Call StrToDate("01/01/2017", Testdate)

        If Not (PassedFromXSVCUPDT) Then
            Call Status(StartProcess, False, "", 0)
        End If

        HoldEffectDate = bMassUp.EffectDate
        serr1 = MFirst(Gridhandle, Maintflag)

        Do While serr1 = 0
            Contractid = bXSVCGRID.ContractID  'mod 11/19/17

            Call SqlFree(c1) : Call SqlFree(c2) : Call SqlFree(c3) : Call SqlFree(c4) : Call SqlFree(c5) : Call SqlFree(c6) : Call SqlFree(c7) : Call SqlFree(c8) : Call SqlFree(c9) : Call SqlFree(c10) : Call SqlFree(c11) : Call SqlFree(c12)

            SQLstmt = "select expiredate from smcontract where contractid = " + SParm(Contractid)
            serr12 = SqlFetch1(c12, SQLstmt, ExpireDate)

            If bMassUp.EffectDate > (ExpireDate + 1) Then  'mod 7/19/18
                '     If bMassUp.EffectDate > ExpireDate Then
                Call Status(SaveGoodArgVals, False, "Contract " + SParm(Contractid.Trim) + "Expiration date + 1 day " + DParm(ExpireDate + 1) + "is earlier than Effective Date" + DParm(bMassUp.EffectDate) + "- Cannot Process", LOG_AND_DISP)
            Else
                SQLstmt = "XSNUPDT_ServItems" + SParm(Contractid)
                serr2 = SqlFetch1(c2, SQLstmt, bXTB_SERVICES)

                If serr2 = 0 Then  'If there are any active service items
                    If Not (PassedFromXSVCUPDT) Then Call Status(SaveGoodArgVals, False, "Processsing Contractid " + SParm(Contractid), DISP_ONLY)
                    '6/14/2019 - Second Round of Change for Canceling Contracts where RMRAmt has changed.
                    SQLstmt = "XSNUPDT_xtb_ServicesWrk_Insert" + SParm(Contractid) + SParm(bpes.UserId) '6/14/2019
                    Call sql(c8, SQLstmt)   '6/14/2019
                    'ScottX Call SqlFree(c8)        '6/14/2019

                    'mod 11/19/17
                    Numrecs = 0
                    SQLstmt = "XSNUPDT_CancelALL" + SParm(Contractid) + DParm(bMassUp.EffectDate)
                    serr12 = SqlFetch1(c12, SQLstmt, Numrecs)
                    If Numrecs Then
                        doCancelAll()
                    Else
                        SQLstmt = "select startdate from smcontract where contractid = " + SParm(Contractid)                '7/16/2019 - Going to create new process if whole contract is being cancelled.
                        StartFlg = SqlFetch1(c12, SQLstmt, StartDate)                                                       '7/16/2019 - Going to create new process if whole contract is being cancelled.
                        If StartFlg <> NOTFOUND Then                                                                        '7/16/2019 - Going to create new process if whole contract is being cancelled.
                            'If the NbrOfDaysFrmStart is 0 or less than the whole contract is being cancelled.              '7/16/2019 - Going to create new process if whole contract is being cancelled.
                            NbrOfDaysFrmStart = DateMinusDate(StartDate, bMassUp.EffectDate)                                '7/16/2019 - Going to create new process if whole contract is being cancelled.
                        Else                                                                                                '7/16/2019 - Going to create new process if whole contract is being cancelled.
                            'Setting it to one so it does the standard calculation to determine the amount being cancelled. '7/16/2019 - Going to create new process if whole contract is being cancelled.
                            NbrOfDaysFrmStart = 1                                                                           '7/16/2019 - Going to create new process if whole contract is being cancelled.
                        End If                                                                                              '7/16/2019 - Going to create new process if whole contract is being cancelled.

                        Call TranBeg(True)
                        Do While serr2 = 0
                            bMassUp.ServItemSel = bXTB_SERVICES.ServItemID
                            bMassUp.RMRAmt = bXTB_SERVICES.MonthAmt
                            bMassUp.EffectDate = HoldEffectDate
                            If NbrOfDaysFrmStart <= 0 Then                                 '7/16/2019 - Going to create new process if whole contract is being cancelled.
                                gProcessDeletionsAll(False, bXTB_SERVICES.Linenbr)         '7/16/2019 - Going to create new process if whole contract is being cancelled.
                            Else                                                           '7/16/2019 - Going to create new process if whole contract is being cancelled.
                                gProcessDeletionsSome(False, bXTB_SERVICES.Linenbr)
                                'gProcessDeletions(False, bXTB_SERVICES.Linenbr)
                            End If                                                         '7/16/2019 - Going to create new process if whole contract is being cancelled.
                            serr2 = SFetch1(c2, bXTB_SERVICES)
                        Loop
                        If NbrOfDaysFrmStart <= 0 Then                                     '7/16/2019 - Going to create new process if whole contract is being cancelled.
                            bMassUp.EffectDate = HoldEffectDate 'mod 11/6/17 bmassup.effectdate gets changed in deletes where xtb_services.statusdate > bmassup.effectdate

                            SQLstmt = "XSNUPDT_RoundingIssue" + SParm(Contractid)
                            Call sql(c9, SQLstmt)
                            SQLstmt = "XSNUPDT_DelBlankLines" + SParm(Contractid)
                            Call sql(c9, SQLstmt)
                            'Call DatePlusMonthSetDay(bMassUp.EffectDate, 0, 1, EffectDateDay1)
                            Call DatePlusMonthSetDay(bMassUp.EffectDate, IIf(IsArrears, 1, 0), 1, EffectDateDay1)  'mod 6/24/17

                            'mod 11/5/17
                            Dim DelDate As Integer = 0

                            With bFirstAdj
                                SQLstmt = "select OpenBillAmt=isnull(round(sum(billamount),2),0) ,User3=round(sum(user3),2),User4=round(sum(user4),2),OpenBillDate = min(billdate) from smcontractbill where " _
                                    + " status = 'O'and billdate >=" + DParm(EffectDateDay1) + " and day(billdate)<> 4 and contractid = " + SParm(Contractid)
                                serr10 = SqlFetch1(c10, SQLstmt, bFirstAdj)
                                If .OpenBillAmt <> 0 Then
                                    SQLstmt = "update smcontractbill set billamount =" + FParm(.OpenBillAmt) + " ,user3=" + FParm(.User3) + ", user4=" + FParm(.User4) _
                                        + " where billdate = " + DParm(.OpenBillDate) + " and contractid = " + SParm(Contractid) + " and status = 'O' "
                                    Call sql(c11, SQLstmt)
                                    SQLstmt = " select isnull(billdate,'01/01/1900') from smcontractbill where billdate > " + DParm(.OpenBillDate) + " and status = 'O' and contractid = " + SParm(Contractid) + " and day(billdate)<> 4"
                                    serr10 = SqlFetch1(c10, SQLstmt, DelDate)
                                    If serr10 = 0 And DelDate > 0 Then
                                        Call TranBeg(True)
                                        SQLstmt = " delete from smcontractbill where billdate > " + DParm(.OpenBillDate) + " and status = 'O' and contractid = " + SParm(Contractid) + " and day(billdate)<> 4"
                                        Call sql(c10, SQLstmt)

                                        'Now for the notes for line items subsequently deleted for a service item -- but where some of their days are included in the above update
                                        SQLstmt = "smcontractbill_contractid" + SParm(Contractid) + DParm(.OpenBillDate) + DParm(.OpenBillDate)
                                        serr8 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                                        SQLstmt = "select * from xtb_services where contractid = " + SParm(Contractid) + " and statusdate <= " + DParm(bMassUp.EffectDate) + " and user7 = " + DParm(bMassUp.EffectDate) + " and day(" + DParm(bMassUp.EffectDate) + ") <> 1"
                                        serr11 = SqlFetch1(c11, SQLstmt, bXTB_SERVICES)
                                        Do While serr11 = 0
                                            bsmContractBill.NoteID = gAddNote("Cancel", bXTB_SERVICES.user7)
                                            Call SUpdate1(CSR_SMContractBill, "SMCONTRACTBILL", bsmContractBill)
                                            serr11 = SFetch1(c11, bXTB_SERVICES)
                                        Loop
                                    End If
                                End If
                            End With

                            SQLstmt = "XSNUPDT_FinalAdj" + SParm(Contractid) + DParm(EffectDateDay1)
                            Call sql(c9, SQLstmt)
                            'in case create a rounding difference
                            SQLstmt = "XSNUPDT_RoundingIssue" + SParm(Contractid)
                            Call sql(c9, SQLstmt)
                            'another odd one mod 7/17/17
                            Numrecs = 0
                            SQLstmt = "XSNUPDT_Delete_XtraBilling" + SParm(Contractid)
                            Call sql(c7, SQLstmt)
                            serr7 = SGroupFetch1(c7, Numrecs)
                            If Numrecs Then
                                SQLstmt = "delete from smcontractbill where contractid = " + SParm(Contractid) + " and status = 'O'"
                                Call sql(c9, SQLstmt)
                            End If
                            'mod 10/3/17
                            SQLstmt = "XSNUPDT_FinalRounding" + SParm(Contractid)
                            Call sql(c9, SQLstmt)
                            Call TranEnd()
                        Else
                            If bMassUp.InvPrintSuppress Then
                                xInvPrintSuppress = "1"
                            Else
                                xInvPrintSuppress = "0"
                            End If
                            Call TranEnd()

                            '11/8/2019 Code was added so it would cycle through the Service Items and cancel the items one at a time if there was a Cancel in the Future. 
                            'SQLstmt = "SELECT COUNT(*) FROM xtb_services WHERE contractid = " + SParm(Contractid) + " AND User7 >= " + DParm(bMassUp.EffectDate)
                            SQLstmt = "SELECT COUNT(*) FROM xtb_services WHERE contractid = " + SParm(Contractid) + " AND User7 > " + DParm(bMassUp.EffectDate) '11/20/2019 It is always going into the Delete Item Logic.  Mass Cancel Proc doesn't have an issue, but Serv Item does for Going Live # 6  where it created an entire billing schedule of credit memos.
                            serr8 = SqlFetch1(c5, SQLstmt, Numrecs)
                            If Numrecs = 0 And serr8 = 0 Then         '11/8/2019 Code was added so it would cycle through the Service Items and cancel the items one at a time if there was a Cancel in the Future.
                                Call TranBeg(True)
                                SQLstmt = "XSNUPDT_Delete_SmContractRevAndBill" + SParm(Contractid) + DParm(HoldEffectDate) + SParm(bpes.UserId) + SParm("N") + SParm(bpes.CpnyID) + SParm(xInvPrintSuppress)
                                Call sql(c3, SQLstmt)
                                Call TranEnd()
                            Else        '11/8/2019 Code was added so it would cycle through the Service Items and cancel the items one at a time if there was a Cancel in the Future.
                                SQLstmt = "SELECT * FROM xtb_services WHERE contractid = " + SParm(Contractid)  '11/8/2019 Code was added so it would cycle through the Service Items and cancel the items one at a time if there was a Cancel in the Future.
                                Call sql(c5, SQLstmt)  '11/8/2019 Code was added so it would cycle through the Service Items and cancel the items one at a time if there was a Cancel in the Future.

                                While SFetch1(c5, bXTB_SERVICES) = 0 '11/8/2019 Code was added so it would cycle through the Service Items and cancel the items one at a time if there was a Cancel in the Future.
                                    Call TranBeg(True)               '11/8/2019 Code was added so it would cycle through the Service Items and cancel the items one at a time if there was a Cancel in the Future.
                                    If bXTB_SERVICES.user7 = 0 Then  '11/8/2019 Code was added so it would cycle through the Service Items and cancel the items one at a time if there was a Cancel in the Future.
                                        SQLstmt = "XSNUPDT_Delete_SmContractRevAndBillServItem" + SParm(Contractid) + SParm(bXTB_SERVICES.ServItemID) + DParm(HoldEffectDate) + SParm(bpes.UserId) + SParm("N") + SParm(bpes.CpnyID) + SParm(xInvPrintSuppress)
                                        Call sql(c3, SQLstmt)
                                    Else
                                        SQLstmt = "XSNUPDT_Delete_SmContractRevAndBillServItem" + SParm(Contractid) + SParm(bXTB_SERVICES.ServItemID) + DParm(bXTB_SERVICES.user7) + SParm(bpes.UserId) + SParm("N") + SParm(bpes.CpnyID) + SParm(xInvPrintSuppress)
                                        Call sql(c3, SQLstmt)
                                    End If
                                    Call TranEnd()
                                End While
                            End If

                        End If                                                             '7/16/2019 - Going to create new process if whole contract is being cancelled.
                    End If
                End If
                'Mod 5/20/19 Call XSNCA00 (XSNCANC) IF Effective Date <= System Date - Solomon Cloud Solutions
                GetSysDate(CurrDate)
                'Call MsgBox("ABOUT TO DO CANCEL CALL CHECK")
                If DateCmp(bMassUp.EffectDate, CurrDate) < 0 Or DateCmp(bMassUp.EffectDate, CurrDate) = 0 Then
                    'Call MsgBox("CANCEL CALL CHECK SUCCESSFUL")
                    'Mod 6/6/2019 Modified delete all contract equip proc - Solomon Cloud Solutions
                    'Call MsgBox("ABOUT TO DO DELETE PROC")
                    SQLstmt = "XDelete_AllContractEquip_Mod" + SParm(Contractid) + DParm(bMassUp.EffectDate)
                    Call sql(c9, SQLstmt)
                    Call CallApplic("XSNCA00", Contractid)
                    'Call MsgBox("CANCEL CALL COMPLETE")
                Else
                    'Call MsgBox("CANCEL CALL CHECK UNSUCCESSFUL")
                End If
                bMassUp.EffectDate = HoldEffectDate
            End If
            serr1 = MNext(Gridhandle, Maintflag)
        Loop
        serr1 = MFirst(Gridhandle, Maintflag)
        Call MDisplay(Gridhandle)
        If Not (PassedFromXSVCUPDT) Then
            Call Status(EndProcess, False, "", 0)
        Else
            Call ScreenExit("", "")
        End If
    End Sub

    Private Sub btnclear_Click(sender As System.Object, e As System.EventArgs) Handles btnclear.Click
        Call MClear(Gridhandle)
    End Sub

    Private Sub grpInput_Leave(sender As Object, e As System.EventArgs) Handles grpInput.Leave
        If bMassUp.EffectDate = 0 Or bMassUp.RevDate = 0 Or bMassUp.CancelCode.Trim = "" Then
            Call MessBox("Please enter EffectDate, SystemDate and CancelCode", 48, "")
            Call ApplSetfocus(txteffectdateM)
        End If
    End Sub
    Private Sub doCancelAll()
        Call TranBeg(True)
        Call sql(CSR_xSvcUpdHist, "select top 1 * from  xSvcUpdHist") 'compile cursor
        SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr1 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)

        SQLstmt = "smcancellation_all" + SParm(bMassUp.CancelCode)
        serr1 = SqlFetch1(c1, SQLstmt, bsmCancellation)

        SQLstmt = "XSNUPDT_ServItems" + SParm(bXSVCGRID.ContractID)
        serr11 = SqlFetch1(CSR_XTB_Services, SQLstmt, bXTB_SERVICES)
        Do While serr11 = 0
            With bXTB_SERVICES
                '.user7 = bMassUp.EffectDate  'user7 = end date
                .user7 = Math.Max(bMassUp.EffectDate, bXTB_SERVICES.StatusDate)
                .user8 = .user7 'mod 10/29/17
                .StatusReason = "DELETE Part -" + bpes.UserId.Trim + " " + DateToStrSep(Curdate)
                .user5 = "Deletion"
                .lupd_datetime = Curdate
                .lupd_prog = CurProg
                .lupd_user = CurUser
                .Status = "C"
                Call SUpdate1(CSR_XTB_Services, "XTB_Services", bXTB_SERVICES)
            End With
            Call sql(c10, "UPDATE xtb_services SET lupd_datetime = " + SParm(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "WHERE contractid = " + SParm(bXTB_SERVICES.ContractID) + " AND ServItemID = " + SParm(bXTB_SERVICES.ServItemID) + " AND LineNbr = " + SParm(bXTB_SERVICES.Linenbr))

            With bXSVCUPDHIST
                'mod 12/4/16 get cancel descr
                .Descr = bsmCancellation.CancellationDesc
                .Contractid = bXSVCGRID.ContractID
                .ServItemID = bXTB_SERVICES.ServItemID
                .OrigRMRAmt = bXTB_SERVICES.MonthAmt 'mod 1/18/17
                .NewRMRAmt = 0 'mod 1/18/17
                .lupd_datetime = Curdate
                .lupd_prog = CurProg
                .lupd_user = CurUser
                .UpdateType = "D"
                'mod 7/19/17
                bMultiSite.CopyClass(nMultisite)
                SQLstmt = "xMultiSite_StartDate" + SParm(bXSVCGRID.ContractID)
                serr3 = SqlFetch1(c3, SQLstmt, bMultiSite)
                If serr3 = 0 Then
                    .user7 = bMultiSite.Contractid 'mod 7/18/17
                Else
                    .user7 = ""
                End If
                Call SInsert1(CSR_xSvcUpdHist, "XSVCUPDHIST", bXSVCUPDHIST)
            End With
            Call sql(c10, "UPDATE xtb_services SET lupd_datetime = " + SParm(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "WHERE contractid = " + SParm(bXSVCUPDHIST.Contractid) + " AND ServItemID = " + SParm(bXSVCUPDHIST.ServItemID) + " AND LineNbr = " + SParm(bXSVCUPDHIST.Recordid))
            Call SqlFree(c10)

            With bsmContract
                bsmContract.TotalAmt = 0
                bsmContract.OrigContractAmt = 0
                bsmContract.NewContractAmt = 0
                .User3 = 0
                .Lupd_dateTime = Curdate
                .Lupd_Prog = CurProg
                .Lupd_User = CurUser
                'mod 4/7/17
                Select Case bMassUp.ServItemSel.Trim
                    Case "C OPTION A", "CP OPTION A", "CP OPTION D", "CP OPTION D 4 HOUR", "CP OPTION D"
                        .Response = ""
                        For i = 0 To 4
                            .StartTime(i) = ""
                            .EndTime(i) = ""
                        Next
                        For i = 0 To 6
                            .Hours24(i) = "N"
                        Next
                        .ContractType = "01"
                End Select
                .NoteId = GAddContractNote("Cancelled", bXTB_SERVICES.user8)  'mod 11/3/17
                Call SUpdate1(CSR_SMContract, "SMCONTRACT", bsmContract)
            End With
            serr11 = SFetch1(CSR_XTB_Services, bXTB_SERVICES)
        Loop
        SQLstmt = "Delete from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID) + " delete from smcontractbill where contractid = " + SParm(bXSVCGRID.ContractID)
        Call sql(c9, SQLstmt)
        Call TranEnd()
    End Sub

    Private Sub txtContractid_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtContractid.ChkEvent

        bXSVCGRID.ContractID = ChkStrg
        If gReversalWarning("Deletions", bMassUp.EffectDate, 1) Then
            bXSVCGRID.ContractID = nXSVCGRID.ContractID
            Call DispField(txtContractid)
            RetVal = ErrNoMess
        End If

    End Sub
    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call SqlFree(CSR_xsvcgrid)
        Call SqlFree(CSR_SMContract)
        Call SqlFree(CSR_SMContractBill)
        Call SqlFree(CSR_SMContractRev)
        Call SqlFree(CSR_XTB_SMContract)
        Call SqlFree(CSR_XTB_Services)
        Call SqlFree(CSR_xSvcUpdHist)
        Call SqlFree(CSR_PriorRev)
        Call SqlFree(CSR_CreditMonths)

        'Standard Screen Exit Call
        Call ScreenExit("", "")

    End Sub
End Class
