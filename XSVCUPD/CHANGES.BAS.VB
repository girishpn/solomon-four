Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports VB = Microsoft.VisualBasic
Module Change

    Dim NumMonths As Short, Frequency As String, Linenbr As Short, TotalAmt As Double
    Dim Curamt As Double, Balance As Double, Maint As Boolean, FirstPeriodAmt As Double, MaxBilldate As Integer, Warranty As Boolean = False
    Dim RMRAmt As Double = 0  'mod 12/6/16
    Dim IsArrears As Boolean
    Dim origEffectiveDate As Integer 'mod 9/9/19


    Sub gProcessChanges(XTB_Linenbr As Short, Optional ItemType As String = "")
        Dim Effectdate As Date, EndDate As Date, DayNum As Short, NumDays As Short, DD As Short = 0
        Dim CommentPeriodEndDate As Integer = 0
        Dim NextPeriodAmts As Double, LastPeriodAmt As Double, DailyAmt As Double, Numrecs As Integer = 0
        Dim ChangeRMRAmt As Double = bMassUp.RMRAmt  'mod 5/8/17   'need to store massup.rmramt due to net amt and reflecting the rmramt as the add/subtract for that adjust
        Dim NumOpenMonths As Integer = 0 'mod 6/4/17
        Dim ActualEffectDate As Integer 'mod 6/11/17
        Dim Datstr As String = DateToStr(bMassUp.EffectDate), DY As Short = 0
        '7/11/2019 - should create one always. Dim RevsProcessedCount As Integer '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        Dim BillingsPriorDateCount As Integer '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        Dim XTB_SERVICES_Insert As XTB_SERVICES = New XTB_SERVICES
        Dim MixedWarranty As String        '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
        Dim NumNonWarranty As Integer      '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
        Dim MultiSiteDate As Integer       '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
        Dim MultiSiteFlg As Short          '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.

        If bKeyid.ID = 15 Then
            If Trim(ItemType) = "MONITORING" Then
                ChangeRMRAmt = bMassUp.MonitAmt
            Else
                ChangeRMRAmt = bMassUp.MaintAmt
            End If
        End If

        Call TranBeg(True)

        IsArrears = False  'mod 6/12/17

        Call sql(CSR_xSvcUpdHist, "select top 1 * from  xSvcUpdHist") 'compile cursor

        Numrecs = 0
        SQLstmt = "xAdd_WarTest" + SParm(bMassUp.ServItemSel)
        Call sql(c3, SQLstmt)
        serr3 = SGroupFetch1(c3, Numrecs)
        If Numrecs Then
            Warranty = True
        Else
            Warranty = False
        End If

        MixedWarranty = "Y"                                             '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
        If Warranty = True Then                                         '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
            MixedWarranty = "N"                                         '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
            Numrecs = 0                                                 '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
            SQLstmt = "xNonWarrantyCount" + SParm(bXSVCGRID.ContractID) '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
            Call sql(c3, SQLstmt)                                       '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
            serr3 = SGroupFetch1(c3, NumNonWarranty)                    '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
            If NumNonWarranty Then                                      '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
                MixedWarranty = "Y"                                     '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
            End If                                                      '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
        End If                                                          '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
        SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr1 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)
        'Call MsgBox("gProcessChange 1 - MixedWarranty = " + MixedWarranty + "   Warranty = " + Warranty.ToString)  '11/12/2019 - Debug logic for testing on Securitas Site.
        gGetWarBilldate(bXSVCGRID.ContractID) 'mod 7/17/17 get warbilldate moved from above to obtain smcontract.billingfreq

        '7/11/2019 - should create one always. RevsProcessedCount = 0                                                   '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        '7/11/2019 - should create one always. SQLstmt = "XSVCUPD_RevSchedProcessedCount" + SParm(bXSVCGRID.ContractID) '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        '7/11/2019 - should create one always. Call sql(c4, SQLstmt)                                                    '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        '7/11/2019 - should create one always. Call SGroupFetch1(c4, RevsProcessedCount)                                '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        '7/11/2019 - should create one always.If RevsProcessedCount = 0 Then
        '7/11/2019 - should create one always. SQLstmt = "XSVCUPD_BillSchedProcessedCount" + SParm(bXSVCGRID.ContractID) '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        '7/11/2019 - should create one always. Call sql(c4, SQLstmt)                                                     '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        '7/11/2019 - should create one always. Call SGroupFetch1(c4, RevsProcessedCount)                                 '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        '7/11/2019 - should create one always. End If

        BillingsPriorDateCount = 0                                                                            '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        SQLstmt = "XSVCUPD_BillSchedPriorDateCount" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate) '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        Call SqlFree(c4)
        Call SqlFree(c3)
        Call sql(c4, SQLstmt)                                                                                 '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        Call SGroupFetch1(c4, BillingsPriorDateCount)                                                         '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        'Populate XTB_SERVICES
        Call sql(CSR_XTB_Services, "Select top 1 * from xtb_services") 'compile cursor
        With bXTB_SERVICES
            SQLstmt = "xDELCHG_FindServItem" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + IParm(XTB_Linenbr)
            serr5 = SqlFetch1(CSR_XTB_Services, SQLstmt, bXTB_SERVICES)

            '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
            If bKeyid.ID = 3 Or bKeyid.ID = 15 Then  '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.

                'If RevsProcessedCount > 0 Or BillingsPriorDateCount > 0 Then         '7/11/2019 - should create one always. '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
                SQLstmt = "XSVCUPD_xtb_ServicesHistInsert" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + _
                     IParm(XTB_Linenbr) + DParm(bMassUp.EffectDate) + SParm(CurProg) + SParm(CurUser) '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
                Call sql(c3, SQLstmt)                                            '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
                '.Status = "X"  8/15/2019 New Status but wrong record.           '08/09/2019 - Solomon Cloud SOlutions - Change status to X (Changed) if KeyID = 3
                'End If                                                               '7/11/2019 - should create one always. '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
            End If                                                                   '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.

            .GroupCode = bXTB_SERVICES.GroupCode
            If .GroupCode.Trim = "MONITORING" Then
                Maint = False
            Else
                Maint = True
            End If

            bXSVCUPDHIST.OrigRMRAmt = bXTB_SERVICES.MonthAmt
            'mod 3/19/17
            Select Case ChangeRMRAmtOpt
                Case 1
                    .MonthAmt = FPAdd(bXTB_SERVICES.MonthAmt, ChangeRMRAmt, 2)
                Case 2
                    .MonthAmt = ChangeRMRAmt
                Case 3 'Mod 9/10/2019 - Solomon Cloud Solutions - Change by pct amount
                    'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                    .MonthAmt = FPAdd(.MonthAmt, FPMult(bXTB_SERVICES.MonthAmt, FPDiv(ChangeRMRAmt, 100, 4), 4), 4)
                    .MonthAmt = FPRnd(.MonthAmt, 2)
                    '.MonthAmt = Truncate(.MonthAmt)
            End Select
            .StatusReason = "Change Part -" + bpes.UserId.Trim + " " + DateToStrSep(Curdate)
            .user5 = "Change"

            '9/9/19 - Issue where updating the status date was not allowing the system to properly calculate 
            '   Processed Billing Lines Adjustment
            origEffectiveDate = bMassUp.EffectDate

            'mod 6/11/17, 10/29/17
            If bMassUp.EffectDate < bXTB_SERVICES.StatusDate Then
                bMassUp.EffectDate = bXTB_SERVICES.StatusDate
            End If

            .user8 = bMassUp.EffectDate 'mod 10/29/17
            .lupd_datetime = Curdate
            .lupd_prog = CurProg
            .lupd_user = CurUser
            .user7 = NULLDATE 'end date
            .StatusDate = bMassUp.EffectDate
            Call SUpdate1(CSR_XTB_Services, "XTB_Services", bXTB_SERVICES)

            With bXSVCUPDHIST
                .Contractid = bXSVCGRID.ContractID
                .ServItemID = bMassUp.ServItemSel
                '.OrigRMRAmt = bXTB_SERVICES.MonthAmt assigned in xtb_services before the monthly amt changes.
                ' .NewRMRAmt = FPAdd(.OrigRMRAmt, ChangeRMRAmt, 2)
                .NewRMRAmt = bXTB_SERVICES.MonthAmt
                .lupd_datetime = Curdate
                .lupd_prog = CurProg
                .lupd_user = CurUser
                .UpdateType = "C"
                'mod 6/6/19 Add Effective date to User5 - Solomon Cloud Solutions
                .user5 = bMassUp.EffectDate
                'mod 7/19/17
                bMultiSite.CopyClass(nMultisite)
                SQLstmt = "xMultiSite_StartDate" + SParm(bXSVCGRID.ContractID)
                serr3 = SqlFetch1(c3, SQLstmt, bMultiSite)
                If serr3 = 0 Then
                    .user7 = bMultiSite.Contractid 'mod 7/18/17
                    If bKeyid.ID = 3 Or bKeyid.ID = 15 Then                                                                '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
                        SQLstmt = "xMultiSite_StartDate_FromBillDate" + SParm(bMultiSite.Contractid) + DParm(bsmContract.StartDate) + DParm(bsmContract.User7) + SParm(MixedWarranty) '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
                        MultiSiteFlg = SqlFetch1(c3, SQLstmt, MultiSiteDate)                               '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
                        If MultiSiteFlg <> NOTFOUND Then                                                   '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
                            bMultiSite.StartDate = MultiSiteDate                                           '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
                        End If                                                                             '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
                    End If                                                                                 '10/18/2019  Issue 6.06 MultiSite Issue where FreqStartDate is not correct.
                Else
                    .user7 = ""
                End If
                Call SInsert1(CSR_xSvcUpdHist, "XSVCUPDHIST", bXSVCUPDHIST)
            End With

            Call sql(c10, "UPDATE xtb_services SET lupd_datetime = " + SParm(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "WHERE contractid = " + SParm(bXSVCUPDHIST.Contractid) + " AND ServItemID = " + SParm(bXSVCUPDHIST.ServItemID) + " AND LineNbr = " + SParm(bXSVCUPDHIST.Recordid))

            'mod 5/5/17
            Select Case ChangeRMRAmtOpt
                Case 1  '-adj
                    'no change to bmassup.rmramt
                Case 2
                    ChangeRMRAmt = FPSub(ChangeRMRAmt, bXSVCUPDHIST.OrigRMRAmt, 2)
                Case 3 '-pct
                    ChangeRMRAmt = FPMult(FPMult(ChangeRMRAmt, 0.01, 4), bXSVCUPDHIST.OrigRMRAmt, 2)
                    'ChangeRMRAmt = Truncate(ChangeRMRAmt)
            End Select
            Effectdate = DateToStrSep(bMassUp.EffectDate)

            EndDate = DateToStrSep(bsmContract.ExpireDate)
            'Call MsgBox("gProcessChange 2 - Effectdate = " + Effectdate.ToString() + "       EndDate = " + EndDate.ToString())  '11/12/2019 - Debug logic for testing on Securitas Site.
            'Dim EndDate2 As Integer
            'Call SqlFetch1(c5, "SELECT MAX(BillDate) FROM smcontractbill WHERE contractid = " + SParm(bXSVCGRID.ContractID), EndDate2)
            'EndDate2 = gGetEndDate(EndDate2, bXSVCGRID.ContractID)
            'Call SqlFree(c5)
            'TEST GET MONTHS BELOW
            'NumMonths = GetMonths(bMassUp.EffectDate, EndDate2) + 1   'Total Duration
            'TEST GET MONTHS ABOVE
            'Call MsgBox("NUMMONTHS CALCULATED: " + SParm(NumMonths))
            NumMonths = GetMonths(bMassUp.EffectDate, bsmContract.ExpireDate) + 1   'Total Duration
            'Call MsgBox("gProcessChange 3 - NumMonths = " + NumMonths.ToString())     '11/12/2019 - Debug logic for testing on Securitas Site.           
            'Calculate 1st month amt
            'MOD 7/22/17
            ' DayNum = Math.Min(Effectdate.Day, 30)
            DayNum = Effectdate.Day
            NumDays = 30 - DayNum + 1
            DailyAmt = FPDiv(ChangeRMRAmt, 30, 6)
            'Call MsgBox("gProcessChange 4 - DayNum = " + DayNum.ToString() + "    DailyAmt = " + DailyAmt.ToString())  '11/12/2019 - Debug logic for testing on Securitas Site.
            FirstPeriodAmt = FPMult(NumDays, DailyAmt, 2)
            'Call MsgBox("gProcessChange 5 - FirstPeriodAmt = " + FirstPeriodAmt.ToString())  '11/12/2019 - Debug logic for testing on Securitas Site.
            'FirstPeriodAmt = Truncate(FirstPeriodAmt) 
            TotalAmt = FirstPeriodAmt
            'Call MsgBox("TOTALAMT: " + SParm(TotalAmt))
            'Balance of months excluding 1st and last month
            NumMonths = NumMonths - 2
            'Call MsgBox("NumMonths (Minus 1st and last): " + SParm(NumMonths))
            NextPeriodAmts = FPMult(NumMonths, ChangeRMRAmt, 2)
            'Call MsgBox("gProcessChange 6 - NextPeriodAmts = " + NextPeriodAmts.ToString())   '11/12/2019 - Debug logic for testing on Securitas Site.
            'Call MsgBox("NEXTPERIODAMTS: " + SParm(NextPeriodAmts))
            'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
            TotalAmt = FPAdd(TotalAmt, NextPeriodAmts, 2)
            'Call MsgBox("NEW TOTALAMT: " + SParm(TotalAmt))
            'Last month
            'mod 12/31/16
            DayNum = Math.Min(EndDate.Day, 30)

            If EndDate.Month = 2 Then
                Dim testdate As Integer
                Call DatePlusMonthSetDay(bsmContract.ExpireDate, 0, 31, testdate)
                If testdate = bsmContract.ExpireDate Then DayNum = 30
            End If
            NumDays = DayNum   '11/5/2019
            LastPeriodAmt = FPMult(NumDays, DailyAmt, 2)
            'Call MsgBox("gProcessChange 7 - LastPeriodAmt = " + LastPeriodAmt.ToString())  '11/12/2019 - Debug logic for testing on Securitas Site.
            'Call MsgBox("LASTPERIODAMT: " + SParm(LastPeriodAmt))
            'LastPeriodAmt = Truncate(LastPeriodAmt)
            'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
            TotalAmt = FPAdd(TotalAmt, LastPeriodAmt, 2)
            'Call MsgBox("TOTALAMT + LASTPERIODAMT: " + SParm(TotalAmt))
        End With  'xtb_services

        Call sql(c10, "UPDATE xtb_services SET lupd_datetime = " + SParm(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "WHERE contractid = " + SParm(bXTB_SERVICES.ContractID) + " AND ServItemID = " + SParm(bXTB_SERVICES.ServItemID) + " AND LineNbr = " + SParm(bXTB_SERVICES.Linenbr))
        Call SqlFree(c10)
        With bsmContract
            'Call MsgBox("bsmContract.TotalAmt: " + SParm(bsmContract.TotalAmt))
            bsmContract.TotalAmt = FPAdd(.TotalAmt, TotalAmt, 2)
            'Call MsgBox("bsmContract.TotalAmt + TotalAmt: " + SParm(bsmContract.TotalAmt))
            bsmContract.OrigContractAmt = .TotalAmt
            bsmContract.NewContractAmt = .TotalAmt
            SQLstmt = "XSvcUPD_MonthlyRMRAmt" + SParm(bXSVCGRID.ContractID)
            serr3 = SqlFetch1(c3, SQLstmt, MonthlyRMRAmt)
            .User3 = MonthlyRMRAmt
            .Lupd_dateTime = Curdate
            .Lupd_Prog = CurProg
            .Lupd_User = CurUser
            .NoteId = GAddContractNote("Changed", bXTB_SERVICES.user8)  'mod 11/3/17
            Call SUpdate1(CSR_SMContract, "SMCONTRACT", bsmContract)
        End With

        doRevenues(ChangeRMRAmt)

        'mod 6/7/17
        'SQLstmt = "xDelChg_ReversalOpenMonths" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate)
        'serr7 = SqlFetch1(c7, SQLstmt, NumOpenMonths)

        'mod 6/12/17 
        ActualEffectDate = bMassUp.EffectDate 'mod 7/26/17 ' this is the comment date in case of arrears

        SQLstmt = "xtb_smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr1 = SqlFetch1(c3, SQLstmt, bXTB_SMCONTRACT)
        If bXTB_SMCONTRACT.InvoicingRule.Trim = "ARREARS" Then
            IsArrears = True
            DY = Mid(Datstr, 3, 2)
            Call DatePlusMonthSetDay(bMassUp.EffectDate, 1, DY, bMassUp.EffectDate)
            '10/3/2019 Fixed Arrears by Updating Eff Date
            Call DatePlusMonthSetDay(origEffectiveDate, 1, DY, origEffectiveDate)  '10/3/2019 Fixed Arrears by Updating Eff Date  (OrigEffectiveDate).  
        End If

        'If NumOpenMonths Then
        '    doBillings_Reversals(ChangeRMRAmt, ActualEffectDate)
        'Else
        'Call MsgBox("gProcessChange 8 - ChangeRMRAmt = " + ChangeRMRAmt.ToString() + "   ActualEffectDate = " + DateToStrSep(ActualEffectDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
        doBillings(ChangeRMRAmt, ActualEffectDate)
        '  End If
        bMassUp.EffectDate = ActualEffectDate
        Call TranEnd()
    End Sub
    Private Sub doRevenues(ChangeRMRAmt As Double)
        Dim LastPostDate As Integer, FirstRevDate As Integer, NumMonths As Short, CurRevDate As Integer, EffectDate As Integer
        Dim RMRAmt As Double, WarrantyDate As Integer

        RMRAmt = IIf(ChangeRMRAmt > 0, -ChangeRMRAmt, Math.Abs(ChangeRMRAmt))
        FreqStartDate = 0
        With bsmContractRev
            .Lupd_User = CurUser
            .Lupd_DateTime = Curdate
            .Lupd_Prog = CurProg
            EffectDate = bMassUp.EffectDate

            Balance = TotalAmt

            SQLstmt = "xAdd_MaxRevPostDate" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate)
            'select top 1 * from smcontractrev where contractid = @contractid and month(revdate)=month(@firstdate)and year(revdate)=year(@firstdate)
            serr1 = SqlFetch1(c1, SQLstmt, LastPostDate)

            If LastPostDate <> NULLDATE Then
                Call DatePlusMonthSetDay(LastPostDate, 1, 1, FirstRevDate)
            Else
                FirstRevDate = EffectDate
            End If

            'looks for the 1st of month for effectdate or smcontract.amortstartdate (start date appearing on revenues)
            SQLstmt = "xAdd_revFirstDate" + SParm(bXSVCGRID.ContractID) + DParm(FirstRevDate)
            'select top 1 * from smcontractrev where contractid = @contractid and month(revdate)=month(@firstdate)and year(revdate)=year(@firstdate)
            serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)

            'mod 7/14/17
            If serr1 Then
                SQLstmt = "smcontractrev_contractid" + SParm(bXSVCGRID.ContractID) + DParm(bXTB_SERVICES.StatusDate) + DParm(bXTB_SERVICES.StatusDate)
                serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                EffectDate = bXTB_SERVICES.StatusDate
                If serr1 Then 'mod 7/17/17
                    SQLstmt = "select top 1 * from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID) + " and revdate > " + DParm(bXTB_SERVICES.StatusDate)
                    serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                End If
            End If


            'mod 12/19/16
            If WarBillDate <> gMaxDate And WarBillDate > FirstRevDate Then   'where posting date > warbilldate
                If Warranty Then
                    If FirstRevDate = .RevDate Then
                        'WarrantyDate = .RevDate + 1
                        WarrantyDate = .RevDate 'mod 12/9/16
                    Else
                        WarrantyDate = EffectDate
                    End If
                    'mod 7/22/17  now look to >=warrantydate
                    SQLstmt = "select * from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID) + " and revdate > =" + DParm(WarrantyDate)
                    serr5 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                End If
            End If

            'mod 7/22/17 moved from above due to potential .revdate change from warranty item
            NumMonths = GetMonths(EffectDate, .RevDate)
            'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
            Curamt = FPAdd(FirstPeriodAmt, FPMult(ChangeRMRAmt, NumMonths, 4), 2)
            'Curamt = Truncate(Curamt)
            If ChangeRMRAmt > 0 Then
                Curamt = Math.Min(Curamt, Balance)
            Else
                Curamt = Math.Max(Curamt, Balance)
            End If
            .RevAmount = FPAdd(.RevAmount, Curamt, 2)
            If Maint Then
                .User3 = FPAdd(.User3, Curamt, 2)
            Else
                .User4 = FPAdd(.User4, Curamt, 2)
            End If
            .Lupd_User = CurUser
            .Lupd_DateTime = Curdate
            .Lupd_Prog = CurProg

            Call SUpdate1(CSR_SMContractRev, "smcontractrev", bsmContractRev)

            'mod 7/31/2019 - Solomon Cloud Solutions - Store revision date change in User1 field of modified record
            If bKeyid.ID = 3 Or bKeyid.ID = 15 Then
                Call sql(c2, "XTB_RevDate" + SParm(bXSVCGRID.ContractID) + Trim(SParm(bXTB_SERVICES.ServItemID)) + SParm(DateToStrSep(bsmContractRev.RevDate)))
            End If
            'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
            Balance = FPSub(Balance, Curamt, 2)
            Call DatePlusDays(.RevDate, 1, CurRevDate)  'so it will find next not current

            SQLstmt = "xAdd_smcontractRev" + SParm(bXSVCGRID.ContractID) + DParm(CurRevDate)
            'select * from smcontractrev where contractid = @contractid and revdate >= @RevDate
            serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
            Do While serr1 = 0
                Curamt = ChangeRMRAmt
                Curamt = IIf(Curamt > 0, Math.Min(Curamt, Balance), Math.Max(Curamt, Balance))
                'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                Balance = FPSub(Balance, Curamt, 2)
                .RevAmount = FPAdd(.RevAmount, Curamt, 2)
                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                Call SUpdate1(CSR_SMContractRev, "smcontractrev", bsmContractRev)
                If Balance = 0 Then Exit Do
                serr1 = SFetch1(CSR_SMContractRev, bsmContractRev)

            Loop
        End With
    End Sub
    Private Sub doBillings(ChangeRMRAmt As Double, CommentEffectDate As Integer)
        Dim LastPostDate As Integer, FirstBillDate As Integer, DD As Short, NumMonths As Short, EffectDate As Integer
        Dim CommentStartDate As Integer = 0, RMRAmt As Double, CommentEndDate As Integer = 0
        '7/9/2019   - Since Tribridge calculates the SMContractBill BillDate based on Dates and frequency, there is a screen that could generate smcontractBill BillDate to keep the Bill Dates in sync between contracts. 
        '    For Example Start Date 4/20/2019 and quarterly, then the next one for SMContractBill would be 7/1/2019 for Tribridge, but the screen would say 5/1/2019 as the next one. This causes issue with GetFreqStartDate
        Dim OriginalBalance As Double                                                 '7/9/2019
        Dim CommentPos As Short                                                       '7/9/2019   -
        Dim CommentsStartDate As Integer                                              '7/9/2019   -
        Dim CommentsStartDateStr As String                                            '7/9/2019   -
        Dim CommentsEndDate As Integer                                                '7/9/2019   -
        Dim CommentsEndDateStr As String                                              '7/9/2019   -
        Dim CommentGetMonths As Short                                                 '7/9/2019   -
        Dim StartDate1 As Date                                                        '7/9/2019   -
        Dim EndDate2 As Date                                                          '7/9/2019   -
        Dim FreqStartDateChk As Integer                                               '7/9/2019   - 
        Dim bMinStatusDate As Integer
        Dim IsBillAmtNeg As Double                                                    '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
        Dim OrigBillDate As Integer                                                   '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
        Dim SearchDate As Integer = 0
        Dim DD_ContractStart As Short                                                 '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
        Dim xSubtractOneMonth As Boolean                                              '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
        Dim xMinBilldate As Integer                                                   '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.

        RMRAmt = IIf(ChangeRMRAmt > 0, -ChangeRMRAmt, Math.Abs(ChangeRMRAmt))
        'Call MsgBox("doBillings 1 - RMRAmt = " + RMRAmt.ToString())   '11/12/2019 - Debug logic for testing on Securitas Site.
        With bsmContractBill
            .Lupd_User = CurUser
            .Lupd_DateTime = Curdate
            .Lupd_Prog = CurProg

            '9/9/19
            EffectDate = origEffectiveDate
            'EffectDate = bMassUp.EffectDate

            SQLstmt = "SELECT MIN(StatusDate) FROM xtb_Services WHERE Status IN ('A','X','E') AND contractid = " + SParm(bXSVCGRID.ContractID) + " and ServItemID = " + SParm(bMassUp.ServItemSel) '9/17/2019 - Issue where the Effective Date is less than Start Date of ServiceItem because of Warranty Items and Change Service Items.
            Call sql(c7, SQLstmt)                      '9/17/2019 - Issue where the Effective Date is less than Start Date of ServiceItem because of Warranty Items and Change Service Items.
            serr1 = SGroupFetch1(c7, bMinStatusDate)   '9/17/2019 - Issue where the Effective Date is less than Start Date of ServiceItem because of Warranty Items and Change Service Items.
            If serr1 <> NOTFOUND Then                  '9/17/2019 - Issue where the Effective Date is less than Start Date of ServiceItem because of Warranty Items and Change Service Items.
                If EffectDate < bMinStatusDate Then  '9/17/2019 - Issue where the Effective Date is less than Start Date of ServiceItem because of Warranty Items and Change Service Items.
                    EffectDate = bMinStatusDate        '9/17/2019 - Issue where the Effective Date is less than Start Date of ServiceItem because of Warranty Items and Change Service Items.
                End If                                 '9/17/2019 - Issue where the Effective Date is less than Start Date of ServiceItem because of Warranty Items and Change Service Items.
            End If                                     '9/17/2019 - Issue where the Effective Date is less than Start Date of ServiceItem because of Warranty Items and Change Service Items.

            Select Case bsmContract.BillingFreq.Trim
                Case "M"
                    Frequency = 1
                Case "Q"
                    Frequency = 3
                Case "S"
                    Frequency = 6
                Case "A"
                    Frequency = 12
            End Select
            Balance = TotalAmt
            DD = Mid(DateToStr(EffectDate), 3, 2)
            'Call MsgBox("doBillings 2 - EffectDate = " + DateToStrSep(EffectDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
            'Where need to insert new month since effect date not on day 1.
            If DD <> 1 Then
                Call DatePlusMonthSetDay(EffectDate, 1, 1, EffectDate)
                'mod 4/23/17  
                SQLstmt = "select max(billdate) from smcontractbill where contractid = " + SParm(bXSVCGRID.ContractID)
                serr6 = SqlFetch1(c6, SQLstmt, MaxBilldate)
                Call SqlFree(c6)
                EffectDate = Math.Min(MaxBilldate, EffectDate)
                'Call MsgBox("doBillings 3 - EffectDate Changed = " + DateToStrSep(EffectDate))   '11/12/2019 - Debug logic for testing on Securitas Site.
            End If

            SQLstmt = "xAdd_MaxBillPostDate" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate)
            serr1 = SqlFetch1(c1, SQLstmt, LastPostDate)

            'special rule -- client wants on separate line the credit amount related to posting - goes to date 4
            'mod 7/23/17 - eliminate the two separate billings for Posting
            If LastPostDate <> NULLDATE Then
                'Call MsgBox("doBillings 4 - SHOULD NOT GO IN HERE SINCE NOTHING POSTED")   '11/12/2019 - Debug logic for testing on Securitas Site.
                CommentEndDate = gGetEndDate(LastPostDate, bXSVCGRID.ContractID)

                Call DatePlusMonthSetDay(LastPostDate, 1, 1, FirstBillDate)
                If Frequency = 1 Then
                    FreqStartDate = GetFreqStartDate_Mod(bXSVCGRID.ContractID, LastPostDate, Frequency)
                Else
                    FreqStartDate = GetFreqStartDate_Mod(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                End If

                '7/9/2019   - Since Tribridge calculates the SMContractBill BillDate based on Dates and frequency, there is a screen that could generate smcontractBill BillDate to keep the Bill Dates in sync between contracts. 
                '    For Example Start Date 4/20/2019 and quarterly, then the next one for SMContractBill would be 7/1/2019 for Tribridge, but the screen would say 5/1/2019 as the next one. This causes issue with GetFreqStartDate
                If Trim$(bsmContract.BillingFreq) = "Q" Then   '7/9/2019   -
                    If bMultiSite.StartDate Then               '7/9/2019   -
                        'Let it process as before with dates.
                        '{xMultiSite_StartDate} - xcusconmaster on MasterID where servbillinvctype = 'MS-SB' and billingFreq <> 'M'
                    Else                                                                                                        '7/9/2019   -
                        SQLstmt = "smContractBill_ContractID_ChkBillDate" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate)  '7/9/2019   -
                        serr5 = SqlFetch1(c5, SQLstmt, FreqStartDateChk)  '7/9/2019   -
                        If serr5 = NOTFOUND Then              '7/9/2019   -
                            'Get the Next Bill Date 
                            SQLstmt = "smContractBill_ContractID_ChkBillDate2" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate)  '7/9/2019   -
                            serr5 = SqlFetch1(c5, SQLstmt, FreqStartDateChk)  '7/9/2019   -
                            FreqStartDate = FreqStartDateChk      '7/9/2019   -
                        End If                                 '7/9/2019   -
                    End If                                     '7/9/2019   -
                End If                                         '7/9/2019   -
                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))
                '10/3/2019 Fixed Arrears by Updating Eff Date.  If IsArrears = True And NumMonths > 0 Then                                          '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date.    'Dim Datstr As String = DateToStr(bMassUp.EffectDate), DY As Short = 0          '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date.    'IsArrears = True                                                                '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month 
                '10/3/2019 Fixed Arrears by Updating Eff Date.    'DY = Mid(Datstr, 3, 2)                                                         '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date.    'Call DatePlusMonthSetDay(bMassUp.EffectDate, 1, DY, bMassUp.EffectDate)        '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date. NumMonths = NumMonths - 1                                                       '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date. End If                                                                              '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                Curamt = FPAdd(FirstPeriodAmt, FPMult(-RMRAmt, NumMonths, 4), 2)  'current period
                'Curamt = Truncate(Curamt)

                If ChangeRMRAmt > 0 Then
                    Curamt = Math.Min(Curamt, Balance)
                Else
                    Curamt = Math.Max(Curamt, Balance)
                End If
                'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                Balance = FPSub(Balance, Curamt, 2)

                'insert a record
                .User3 = 0 : .User4 = 0

                If LastPostDate <> NULLDATE Then
                    Call DatePlusMonthSetDay(LastPostDate, 1, 3, FirstBillDate)    '9/23/2019 Want the date to be on the 3rd.
                Else
                    Call DatePlusMonthSetDay(FirstBillDate, 0, 3, FirstBillDate)   '9/23/2019 Want the date to be on the 3rd.
                End If

                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FirstBillDate) + DParm(FirstBillDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                'mod 11/11/16
                'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice suppress at 0
                'If bMassUp.InvPrintSuppress Then
                '.User5 = "1"
                'Else
                .User5 = "0"
                'End If
                .Status = "O"
                If serr3 Then
                    .BillAmount = Curamt
                    .BillDate = FirstBillDate
                    .ContractID = bXSVCGRID.ContractID
                    .CB_ID07 = 0
                    .LineNbr = 1
                    'mod 7/6/17 for comment
                    .Comment = gGetComment(CommentEffectDate, CommentEndDate) 'mod 6/4/17
                    .Crtd_DateTime = Curdate
                    .Crtd_User = CurUser
                    .Crtd_Prog = CurProg
                    .User6 = "Delete"  'mod 12/31/16
                    .CpnyID = bpes.CpnyID 'mod 09/25/17
                    .NoteID = GAddNote("Changed", bMassUp.EffectDate) 'mod 10/29/17
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    'want the smaller of the existing comment start date or the current effect date.  Make sure to keep comment enddate
                    .Comment = gGetUpdateComment()  'mod 10/30/17
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    .NoteID = GAddNote("Changed", bMassUp.EffectDate) 'mod 10/29/17
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If

            Else  'no Posted amounts found
                FirstBillDate = EffectDate
                'Call MsgBox("doBillings 5 - FirstBillDate/EffectDate = " + DateToStrSep(FirstBillDate))   '11/12/2019 - Debug logic for testing on Securitas Site.
                If (bKeyid.ID = 3 Or bKeyid.ID = 15) And DD <> 1 And Warranty = False Then   '11/5/2019 Added ()  -- If bKeyid.ID = 3 Or bKeyid.ID = 15 And DD <> 1 Then
                    '10/18/2019 If we are doing a Service Item Change
                    '     And it is not on the first of the month
                    '     Then we need to set the FirstBillDate
                    '     Back to the previous month on the 1st

                    '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                    'There is one exception to this rule. If the Contract Start Date is not the first, And the First Bill Date is eqaul to the FirstBillDate of the contract already, then do not subtract one.  '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                    xSubtractOneMonth = True                                        '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                    DD_ContractStart = Mid(DateToStr(bsmContract.StartDate), 3, 2)  '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                    If DD_ContractStart <> 1 Then                                   '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                        SQLstmt = "select min(billdate) from smcontractbill WITH(NOLOCK) where contractid = " + SParm(bXSVCGRID.ContractID)  '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                        serr6 = SqlFetch1(c6, SQLstmt, xMinBilldate)                '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                        Call SqlFree(c6)                                            '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                        If serr6 <> NOTFOUND Then                                   '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                            'If the FirstBillDate is the First True BillDate from SMContractBill, then do not subtract 1 Month since this is the First Bill Date that includes the Partial Amount from the Start of the Contract.
                            If FirstBillDate = xMinBilldate Then                    '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                                xSubtractOneMonth = False                           '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                            End If                                                  '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                        End If                                                      '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                    End If                                                          '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                    If xSubtractOneMonth = True Then                                '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                        Call DatePlusMonthSetDay(FirstBillDate, -1, 1, FirstBillDate)
                    End If                                                        '11/19/2019 Go Live Defect 1 - Change Service Item and Billing Schedule not correct.
                    'Call MsgBox("doBillings 6 - FirstBillDate = " + DateToStrSep(FirstBillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                End If

                FreqStartDate = GetFreqStartDate_Mod(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                'Call MsgBox("doBillings 7 - FirstBillDate = " + DateToStrSep(FirstBillDate) + "   Frequency = " + Frequency)  '11/12/2019 - Debug logic for testing on Securitas Site.
                'Call MsgBox("FirstBillDate: " + SParm(DateToStrSep(FirstBillDate)))
                'Call MsgBox("Frequency: " + SParm(Frequency))
                'Call MsgBox("FreqStartDate: " + SParm(DateToStrSep(FreqStartDate)))
                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))
                'Call MsgBox("doBillings 8 = NumMonths = " + NumMonths.ToString())   '11/12/2019 - Debug logic for testing on Securitas Site.
                'Call MsgBox("NUMMONTHS (Should be 3): " + SParm(NumMonths))
                'If IsArrears = True And bKeyid.ID <> 15 Then    '11/5/2019 
                '    NumMonths = NumMonths + 1                   '11/5/2019 
                'End If                                          '11/5/2019 
                'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                'Call MsgBox("FIRSTPERIODAMT: " + SParm(FirstPeriodAmt))
                'Call MsgBox("RMRAmt: " + SParm(RMRAmt))
                'Call MsgBox("NumMonths: " + SParm(NumMonths))
                Curamt = FPAdd(FirstPeriodAmt, FPMult(-RMRAmt, NumMonths, 4), 2)  'current period
                'Call MsgBox("doBillings 9 - FirstPeriodAmt = " + FirstPeriodAmt.ToString() + "   CuryAmt = " + Curamt.ToString())  '11/12/2019 - Debug logic for testing on Securitas Site.
                'Call MsgBox("CURAMT: " + SParm(Curamt))
                Curamt = Truncate(Curamt)
                CommentStartDate = CommentEffectDate

                '7/9/2019 Need to keep track of original balance
                OriginalBalance = Balance     '7/9/2019
                If ChangeRMRAmt > 0 Then
                    'Call MsgBox("CHANGERMRAMT > 0")
                    Curamt = Math.Min(Curamt, Balance)
                    'Call MsgBox("CURAMT: " + SParm(Curamt))
                Else
                    'Call MsgBox("CHANGERMRAMT <= 0")
                    Curamt = Math.Max(Curamt, Balance)
                    'Call MsgBox("CURAMT: " + SParm(Curamt))
                End If
                'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                Balance = FPSub(Balance, Curamt, 2)

                If WarBillDate <> gMaxDate And WarBillDate > FirstBillDate Then   'where posting date > warbilldate
                    If Warranty Then
                        If FirstBillDate = WarBillDate Or FirstBillDate + 1 = WarBillDate Then
                            .BillDate = WarBillDate 'where warrantydate was on the 1st or 2nd
                            'Call MsgBox("doBillings 10 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                        End If
                    Else  'servitemid not a warranty
                        If FirstBillDate = WarBillDate Then
                            .BillDate = WarBillDate + 2  'where warrantydate was on 1st -- so non-warranty had to go to the 3rd
                            'Call MsgBox("doBillings 11 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))   '11/12/2019 - Debug logic for testing on Securitas Site.
                        Else
                            .BillDate = FirstBillDate
                            'Call MsgBox("doBillings 12 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                        End If
                    End If
                Else
                    .BillDate = FirstBillDate
                    'Call MsgBox("doBillings 13 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                End If

                .User3 = 0 : .User4 = 0
                OrigBillDate = .BillDate
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate) + DParm(.BillDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                '7/9/2019   - Since Tribridge calculates the SMContractBill BillDate based on Dates and frequency, there is a screen that could generate smcontractBill BillDate to keep the Bill Dates in sync between contracts. 
                '    For Example Start Date 4/20/2019 and quarterly, then the next one for SMContractBill would be 7/1/2019 for Tribridge, but the screen would say 5/1/2019 as the next one. This causes issue with GetFreqStartDate
                If Trim$(bsmContract.BillingFreq) = "Q" And serr3 = NOTFOUND And NumMonths = 0 And RMRAmt <> 0 Then  '7/9/2019   -
                    'Call MsgBox("doBillings 14 - Inside IF")  '11/12/2019 - Debug logic for testing on Securitas Site.
                    'Fetch the record based on BillDate between Comments.
                    SQLstmt = "smContractBill_ContractID_ByCommentDate" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate)  '7/9/2019   -
                    serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)                       '7/9/2019   -
                    If serr3 <> NOTFOUND Then                                                             '7/9/2019   -
                        'Call MsgBox("doBillings 14.5 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                        CommentPos = InStr(bsmContractBill.Comment, "-")                                  '7/9/2019   -
                        If CommentPos <> 0 Then                                                           '7/9/2019   -
                            If Mid(bsmContractBill.Comment, CommentPos - 1, 1) = " " Then                 '7/9/2019   -
                                CommentsStartDateStr = Left(bsmContractBill.Comment, CommentPos - 1)      '7/9/2019   -
                            Else                                                                          '7/9/2019   -
                                CommentsStartDateStr = Left(bsmContractBill.Comment, CommentPos)          '7/9/2019   -
                            End If                                                                        '7/9/2019   -
                            CommentsEndDateStr = Mid(bsmContractBill.Comment, CommentPos + 1)             '7/9/2019   -
                            Call StrToDate(CommentsStartDateStr, CommentsStartDate)                       '7/9/2019   -
                            Call StrToDate(CommentsEndDateStr, CommentsEndDate)                           '7/9/2019   -
                            Call DatePlusDays(CommentsEndDate, 1, CommentsEndDate)                        '7/9/2019   -
                            StartDate1 = DateToStrSep(EffectDate)                                         '7/9/2019   -
                            EndDate2 = DateToStrSep(CommentsEndDate)                                      '7/9/2019   -
                            CommentGetMonths = Math.Max(0, DateDiff(DateInterval.Month, StartDate1, EndDate2) - IIf(DD = 1, 1, 0)) '7/9/2019   -
                            If CommentGetMonths <> 0 Then                                                 '7/9/2019   -
                                'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                                Curamt = FPAdd(FirstPeriodAmt, FPMult(-RMRAmt, CommentGetMonths, 4), 2)   '7/9/2019   -
                                'Curamt = Truncate(Curamt)
                                If ChangeRMRAmt > 0 Then                                                  '7/9/2019   -
                                    Curamt = Math.Min(Curamt, OriginalBalance)                            '7/9/2019   -
                                Else                                                                      '7/9/2019   -
                                    Curamt = Math.Max(Curamt, OriginalBalance)                            '7/9/2019   -
                                End If                                                                    '7/9/2019   -
                                'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                                Balance = FPSub(OriginalBalance, Curamt, 2)                               '7/9/2019   -
                            End If                                                                        '7/9/2019   -
                        Else
                            'Refetch the record and let it process how it did before.                     '7/9/2019   -
                            .User3 = 0 : .User4 = 0                                                       '7/9/2019   -
                            SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(OrigBillDate) + DParm(OrigBillDate) '7/9/2019   -
                            serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)                                           '7/9/2019   -
                            'Call MsgBox("doBillings 14.75 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                        End If                                                                            '7/9/2019   -
                    End If                                                                                '7/9/2019   -
                Else                                                                                                              '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                    'Call MsgBox("doBillings 15 - Inside ELSE")  '11/12/2019 - Debug logic for testing on Securitas Site.
                    If serr3 = NOTFOUND And RMRAmt <> 0 Then '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        SQLstmt = "smContractBill_ContractID_ByCommentDate" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate)      '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)                                           '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        'Call MsgBox("doBillings 15.5 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                        If serr3 <> NOTFOUND Then                                                                                 '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                            IsBillAmtNeg = FPAdd(bsmContractBill.BillAmount, Curamt, 2)                                           '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                            'If the amount is going to be negative, then they want it on a seperate line.
                            If IsBillAmtNeg <= 0 Then                                                                             '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                                serr3 = NOTFOUND                                                                                  '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                                .User3 = 0 : .User4 = 0                                                                           '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                                .BillDate = OrigBillDate                                                                          '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                                'Call MsgBox("doBillings 15.75 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                            End If                                                                                                '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        End If                                                                                                    '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                    End If                                                                                                        '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                    If serr3 = NOTFOUND Then                                                                                      '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        Call DatePlusMonthSetDay(.BillDate, 0, 3, .BillDate)                                                      '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        'Refetch the record and let it process how it did before.                                                 '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        .User3 = 0 : .User4 = 0                                                                                   '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate) + DParm(.BillDate) '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)                                           '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        'Call MsgBox("doBillings 16 - BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                    End If                                                                                                        '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                End If

                If Maint Then
                    'Call MsgBox(".User3 = " + SParm(.User3))
                    'Call MsgBox("CurAmt = " + SParm(Curamt))
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    'Call MsgBox(".User3 = " + SParm(.User3))
                    'Call MsgBox("CurAmt = " + SParm(Curamt))
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                'mod 11/11/16
                'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep Invoice print suppress at 0
                'If bMassUp.InvPrintSuppress Then
                '.User5 = "1"
                'Else
                .User5 = "0"
                'End If
                .Status = "O"
                If serr3 Then
                    .BillAmount = Curamt
                    .ContractID = bXSVCGRID.ContractID
                    .CB_ID07 = 0
                    .LineNbr = 1
                    'mod 6/4/17
                    'CommentEndDate = Math.Min(FreqStartDate - 1, bsmContract.ExpireDate)  
                    Call DatePlusMonthSetDay(FreqStartDate, IIf(IsArrears, -2, -1), 31, CommentEndDate)
                    CommentEndDate = Math.Min(CommentEndDate, bsmContract.ExpireDate)
                    .Comment = gGetComment(CommentStartDate, CommentEndDate) 'mod 12/1516  CommentStartDate computed above
                    .Crtd_DateTime = Curdate
                    .Crtd_User = CurUser
                    .Crtd_Prog = CurProg
                    .User6 = "Delete" 'mod 12/31/16
                    .CpnyID = bpes.CpnyID 'mod 09/25/17
                    .NoteID = GAddNote("Changed", bMassUp.EffectDate) 'mod 10/29/17
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    'want the smaller of the existing comment start date or the current effect date.  Make sure to keep comment enddate
                    .Comment = gGetUpdateComment()  'mod 10/30/17
                    'Call MsgBox("doBillings 17 - BillAmount = " + bsmContractBill.BillAmount.ToString())  '11/12/2019 - Debug logic for testing on Securitas Site.
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    .NoteID = GAddNote("Changed", bMassUp.EffectDate) 'mod 10/29/17
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If
            End If

            If bKeyid.ID = 3 Or bKeyid.ID = 15 Then
                Call sql(c2, "XTB_BillDate" + SParm(bXSVCGRID.ContractID) + Trim(SParm(bXTB_SERVICES.ServItemID)) + SParm(DateToStrSep(bsmContractBill.BillDate)))
            End If

            'Call MsgBox("doBillings 18 - FreqStartDate = " + DateToStrSep(FreqStartDate) + "   gMaxDate = " + DateToStrSep(gMaxDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
            Dim dy As Short = 0
            SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate) + DParm(gMaxDate)  'mod 12/15/16
            'If IsArrears = True And bKeyid.ID <> 15 Then   '11/5/2019  Issue 1.05 SmContractBill is off.
            '    Dim ArrearDate As Date                     '11/5/2019  Issue 1.05 SmContractBill is off.
            '    Dim TempDate As Integer                    '11/5/2019  Issue 1.05 SmContractBill is off.
            '    ArrearDate = DateToStrSep(FreqStartDate)   '11/5/2019  Issue 1.05 SmContractBill is off.
            '    ArrearDate = ArrearDate.AddMonths(1)       '11/5/2019  Issue 1.05 SmContractBill is off.
            '    Call StrToDate(CStr(ArrearDate), TempDate) '11/5/2019  Issue 1.05 SmContractBill is off.
            '    SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(TempDate) + DParm(gMaxDate)  '11/5/2019  Issue 1.05 SmContractBill is off.
            'End If                                         '11/5/2019  Issue 1.05 SmContractBill is off.
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
            If serr1 = 9 Then
                SQLstmt = "xtb_findnextbilldate" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate) + DParm(EffectDate)
                serr1 = SqlFetch1(c10, SQLstmt, SearchDate)
                Call SqlFree(c10)
                'Call MsgBox("doBillings 19 - SearchDate = ")  '11/12/2019 - Debug logic for testing on Securitas Site.
                If serr1 = 0 Then
                    'Call MsgBox("doBillings 20 - SearchDate = " + DateToStrSep(SearchDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
                    SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(SearchDate) + DParm(gMaxDate)
                    serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
                End If
            End If
            'If serr1 <> NOTFOUND Then  '11/12/2019 - Debug logic for testing on Securitas Site.
            'Call MsgBox("doBillings 21 - bsmContractBill.BillDate = " + DateToStrSep(bsmContractBill.BillDate))  '11/12/2019 - Debug logic for testing on Securitas Site.
            'End If  '11/12/2019 - Debug logic for testing on Securitas Site.
            Do While serr1 = 0
                dy = Mid(DateToStr(.BillDate), 3, 2)
                If (Not (Warranty) And WarBillDate = .BillDate) Or dy = 4 Or dy = 3 Then   '10/2/2019  Since we changed the Change date to 3, then we need to add this day as an exception too. (Could have added Variable above to check which date was updated and don't update it again instead of dy = 3.)
                    'do nothing
                Else
                    '7/9/2019   - Since Tribridge calculates the SMContractBill BillDate based on Dates and frequency, there is a screen that could generate smcontractBill BillDate to keep the Bill Dates in sync between contracts. 
                    '    For Example Start Date 4/20/2019 and quarterly, then the next one for SMContractBill would be 7/1/2019 for Tribridge, but the screen would say 5/1/2019 as the next one. This causes issue with GetFreqStartDate
                    'Take Comment to determine frequency for Quarterly.
                    CommentGetMonths = 0                                                                  '7/9/2019   -
                    'If Trim$(bsmContract.BillingFreq) = "Q" Then                                          '7/9/2019   -
                    CommentPos = InStr(bsmContractBill.Comment, "-")                                  '7/9/2019   -
                    If CommentPos <> 0 Then                                                           '7/9/2019   -
                        If Mid(bsmContractBill.Comment, CommentPos - 1, 1) = " " Then                 '7/9/2019   -
                            CommentsStartDateStr = Left(bsmContractBill.Comment, CommentPos - 1)      '7/9/2019   -
                        Else                                                                          '7/9/2019   -
                            CommentsStartDateStr = Left(bsmContractBill.Comment, CommentPos)          '7/9/2019   -
                        End If                                                                        '7/9/2019   -
                        CommentsEndDateStr = Mid(bsmContractBill.Comment, CommentPos + 1)             '7/9/2019   -
                        Call StrToDate(CommentsStartDateStr, CommentsStartDate)                       '7/9/2019   -
                        Call StrToDate(CommentsEndDateStr, CommentsEndDate)                           '7/9/2019   -
                        Call DatePlusDays(CommentsEndDate, 1, CommentsEndDate)                        '7/9/2019   -
                        StartDate1 = DateToStrSep(CommentsStartDate)                                  '7/9/2019   -
                        EndDate2 = DateToStrSep(CommentsEndDate)                                      '7/9/2019   -
                        CommentGetMonths = DateDiff(DateInterval.Month, StartDate1, EndDate2)         '7/9/2019   -
                    End If
                    'End If

                    ''7/9/2019 - Was going to add this logic to caculate properly, but the balance method below will correct it since I corrected issue above.
                    ''If Trim$(bsmContract.BillingFreq) = "Q" And CommentGetMonths <> 0 And CommentGetMonths < Frequency Then '7/9/2019   -
                    ''Curamt = FPMult(-RMRAmt, CommentGetMonths, 2)                                                       '7/9/2019   -
                    ''Else                                                                                                    '7/9/2019   -
                    'Curamt = FPMult(-RMRAmt, Frequency, 2)
                    ''End If                                                                                                  '7/9/2019   -
                    ''mod 5/15/17  wasn't limiting curamt to balance
                    'If ChangeRMRAmt > 0 Then
                    '    Curamt = Math.Min(Curamt, Balance)
                    'Else
                    '    Curamt = Math.Max(Curamt, Balance)
                    'End If

                    'Balance -= Curamt

                    '.BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    'If Maint Then
                    '    .User3 = FPAdd(.User3, Curamt, 2)
                    'Else
                    '    .User4 = FPAdd(.User4, Curamt, 2)
                    'End If




                    If CommentGetMonths < 1 Then
                        CommentGetMonths = 1
                    End If
                    Curamt = FPMult(-RMRAmt, CommentGetMonths, 2)
                    'Curamt = Truncate(Curamt)
                    'End If                                                                                                  '7/9/2019   -
                    'mod 5/15/17  wasn't limiting curamt to balance
                    If ChangeRMRAmt > 0 Then
                        Curamt = Math.Min(Curamt, Balance)
                    Else
                        Curamt = Math.Max(Curamt, Balance)
                    End If
                    'mod 10/22/2019 - Solomon Cloud Solutions - Replacing calculations with FP calcs
                    Balance = FPSub(Balance, Curamt, 2)
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    If Maint Then
                        .User3 = FPAdd(.User3, Curamt, 2)
                    Else
                        .User4 = FPAdd(.User4, Curamt, 2)
                    End If


                    'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice suppress at 0
                    'If bMassUp.InvPrintSuppress Then
                    '.User5 = "1"
                    'Else
                    .User5 = "0"
                    'End If
                    Call SUpdate1(CSR_SMContractBill, "smcontractbill", bsmContractBill)
                    If Balance = 0 Then Exit Do
                End If
                serr1 = SFetch1(CSR_SMContractBill, bsmContractBill)
            Loop
        End With

        'in case there was a 4th of the month and now it's 0
        SQLstmt = "delete from smcontractbill where billamount = 0 and contractid = " + SParm(bXSVCGRID.ContractID)
        Call sql(CSR_SMContractBill, SQLstmt)
    End Sub
    Private Sub doBillings_Reversals(ChangeRMRAmt As Double, CommentEffectDate As Integer)
        '*************************Special rules where there are open post dates between the first and last post dates due to reversals
        Dim FirstBillDate As Integer, DD As Short, NumMonths As Short, EffectDate As Integer
        Dim CommentStartDate As Integer = 0, RMRAmt As Double, CommentEndDate As Integer = 0
        Dim FirstPerAmtAvail As Short = 1, CreditAmt As Double = 0, TestDate As Integer = 0
        Dim Datstr As String = "", Dy As Short = 0

        RMRAmt = IIf(ChangeRMRAmt > 0, -ChangeRMRAmt, Math.Abs(ChangeRMRAmt))
        FreqStartDate = 0

        With bsmcontractbill
            .Lupd_User = CurUser
            .Lupd_DateTime = Curdate
            .Lupd_Prog = CurProg

            EffectDate = bMassUp.EffectDate

            Select Case bsmContract.BillingFreq.Trim
                Case "M"
                    Frequency = 1
                Case "Q"
                    Frequency = 3
                Case "S"
                    Frequency = 6
                Case "A"
                    Frequency = 12
            End Select
            Balance = TotalAmt
            DD = Mid(DateToStr(EffectDate), 3, 2)
            'Where need to insert new month since effect date not on day 1.
            If DD <> 1 Then
                Call DatePlusMonthSetDay(EffectDate, 1, 1, EffectDate)
            End If

            '****************Insert C/M or ADJ
            SQLstmt = "xDelChg_CreditMonths" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate)
            Call sql(CSR_CreditMonths, SQLstmt)
            serr6 = SGroupFetch1(CSR_CreditMonths, bCreditInfo)

            'special rule -- client wants on separate line the credit amount related to posting - goes to date 4
            If bCreditInfo.NumMonths > 0 Then
                If bMassUp.EffectDate > bCreditInfo.FirstPostDate Then
                    Curamt = FirstPeriodAmt + FPMult(-RMRAmt, (Frequency * bCreditInfo.NumMonths) - 1, 2)
                    'Curamt = Truncate(Curamt)
                    FirstPerAmtAvail = 0
                Else
                    'mod  6/12/17
                    Dim statusdate As Integer = 0
                    Datstr = DateToStr(bXTB_SERVICES.StatusDate) : Dy = Mid(Datstr, 3, 2)
                    Call DatePlusMonthSetDay(bXTB_SERVICES.StatusDate, IIf(IsArrears, 1, 0), Dy, statusdate)

                    NumMonths = GetMonths(bCreditInfo.FirstPostDate, bXTB_SERVICES.StatusDate)
                    If NumMonths = -1 Then    'where partial month from previous month included in current month
                        Curamt = FirstPeriodAmt + FPMult(-RMRAmt, (Frequency * bCreditInfo.NumMonths), 2)
                        'Curamt = Truncate(Curamt)
                        FirstPerAmtAvail = 0
                    Else
                        Curamt = FPMult(-RMRAmt, (Frequency * bCreditInfo.NumMonths), 2)
                        'Curamt = Truncate(Curamt)
                        FirstPerAmtAvail = 1
                    End If
                End If

                .User3 = 0 : .User4 = 0
                Call DatePlusMonthSetDay(bCreditInfo.LastPostDate, 0, 4, bCreditInfo.LastPostDate)
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(bCreditInfo.LastPostDate) + DParm(bCreditInfo.LastPostDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmcontractbill)

                If ChangeRMRAmt > 0 Then
                    Curamt = Math.Min(Curamt, Balance)
                Else
                    Curamt = Math.Max(Curamt, Balance)
                End If
                Balance -= Curamt

                CreditAmt = Curamt

                'insert a record
                .User3 = 0 : .User4 = 0
                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                'mod 11/11/16
                'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice print suppress at 0
                'If bMassUp.InvPrintSuppress Then
                '.User5 = "1"
                'Else
                .User5 = "0"
                'End If
                .Status = "O"
                If serr3 Then
                    .BillAmount = Curamt
                    .BillDate = bCreditInfo.LastPostDate
                    .ContractID = bXSVCGRID.ContractID
                    .CB_ID07 = 0
                    .LineNbr = 1
                    If Frequency = 1 Then
                        Call DatePlusMonthSetDay(.BillDate, IIf(IsArrears, -1, 0), 31, CommentEndDate) 'mod 6/4/17
                    Else
                        CommentEndDate = GetFreqStartDate(bXSVCGRID.ContractID, .BillDate - 3, (Frequency - 1))
                        Call DatePlusMonthSetDay(CommentEndDate, 0, 31, CommentEndDate)
                    End If
                    'mod 6/12/17 for comment
                    Datstr = DateToStr(bCreditInfo.FirstPostDate) : Dy = Mid(Datstr, 3, 2)
                    Call DatePlusMonthSetDay(bCreditInfo.FirstPostDate, IIf(IsArrears, -1, 0), Dy, CommentStartDate)
                    .Comment = gGetComment(CommentStartDate, CommentEndDate)
                    .Crtd_DateTime = Curdate
                    .Crtd_User = CurUser
                    .Crtd_Prog = CurProg
                    .CpnyID = bpes.CpnyID 'mod 09/25/17
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else  'if the 4th exists already
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If

                'Return to 1st open billdate
                SQLstmt = "xDelChg_Smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)


                'Recalc Curamt
                FirstBillDate = bsmContractBill.BillDate
                FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                If FirstBillDate > bCreditInfo.LastPostDate And bCreditInfo.LastPostDate > 0 Then
                    Call DatePlusMonthSetDay(bMassUp.EffectDate, 0, 1, TestDate)
                    If TestDate = bCreditInfo.LastPostDate - 3 Then
                        Curamt = FPMult(-RMRAmt, Frequency, 2)
                        'Curamt = Truncate(Curamt)
                    Else
                        If bMassUp.EffectDate <> EffectDate Then
                            FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                        Else
                            FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, bCreditInfo.LastPostDate, Frequency)
                        End If
                        NumMonths = GetMonths(EffectDate, FreqStartDate)
                        Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period
                        Curamt = FPSub(Curamt, CreditAmt, 2)
                        'Curamt = Truncate(Curamt)
                    End If
                    FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                Else
                    'mod 5/14/17
                    If FirstBillDate < bCreditInfo.LastPostDate Then  'can't count months from effectdate if there are open months before last postdate
                        NumMonths = Math.Max(0, GetMonths(FirstBillDate, FreqStartDate) - IIf(DD = 1, 1, 0))
                    Else
                        NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))
                    End If
                    Curamt = (FirstPeriodAmt * FirstPerAmtAvail) + FPMult(-RMRAmt, NumMonths, 2)
                    'Curamt = Truncate(Curamt)
                    Datstr = DateToStr(FirstBillDate) : Dy = Mid(Datstr, 3, 2)
                    Call DatePlusMonthSetDay(FirstBillDate, IIf(IsArrears, -1, 0), Dy, CommentStartDate)
                End If
            Else  'no Posted amounts found
                FirstBillDate = EffectDate
                FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)  'mod 12/14/16
                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))  'mod 12/23/16
                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period
                'Curamt = Truncate(Curamt)
                CommentStartDate = CommentEffectDate 'mod 6/12/17
            End If

            If ChangeRMRAmt > 0 Then
                Curamt = Math.Min(Curamt, Balance)
            Else
                Curamt = Math.Max(Curamt, Balance)
            End If
            Balance -= Curamt

            If WarBillDate <> gMaxDate And WarBillDate > FirstBillDate Then   'where posting date > warbilldate
                If Warranty Then
                    If FirstBillDate = WarBillDate Or FirstBillDate + 1 = WarBillDate Then
                        .BillDate = WarBillDate 'where warrantydate was on the 1st or 2nd
                    End If
                Else  'servitemid not a warranty
                    If FirstBillDate = WarBillDate Then
                        .BillDate = WarBillDate + 2  'where warrantydate was on 1st -- so non-warranty had to go to the 3rd
                    Else
                        .BillDate = FirstBillDate
                    End If
                End If
            Else
                .BillDate = FirstBillDate
            End If

            .User3 = 0 : .User4 = 0
            SQLstmt = "xDelChg_Smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate)
            serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

            If Maint Then
                .User3 = FPAdd(.User3, Curamt, 2)
            Else
                .User4 = FPAdd(.User4, Curamt, 2)
            End If
            'mod 11/11/16
            'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice suppress at 0
            'If bMassUp.InvPrintSuppress Then
            '.User5 = "1"
            'Else
            .User5 = "0"
            'End If
            .Status = "O"
            If serr3 Then
                .BillAmount = Curamt
                .ContractID = bXSVCGRID.ContractID
                .CB_ID07 = 0
                .LineNbr = 1
                'mod 6/12/17
                If Frequency = 1 Then
                    Call DatePlusMonthSetDay(.BillDate, IIf(IsArrears, -1, 0), 31, CommentEndDate) 'mod 6/4/17
                Else
                    CommentEndDate = Math.Min(FreqStartDate - 1, bsmContract.ExpireDate)
                    .Comment = gGetComment(CommentStartDate, CommentEndDate) 'mod 12/1516
                End If
                .Crtd_DateTime = Curdate
                .Crtd_User = CurUser
                .Crtd_Prog = CurProg
                .CpnyID = bpes.CpnyID 'mod 09/25/17
                Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
            Else
                .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
            End If

            SQLstmt = "xDelChg_Smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate)  'mod 12/15/16
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
            Do While serr1 = 0
                If Not (Warranty) And WarBillDate = .BillDate Then '????
                    'do nothing
                Else
                    Curamt = FPMult(-RMRAmt, Frequency, 2)
                    'Curamt = Truncate(Curamt)
                    If ChangeRMRAmt > 0 Then
                        Curamt = Math.Min(Curamt, Balance)
                    Else
                        Curamt = Math.Max(Curamt, Balance)
                    End If
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    If Maint Then
                        .User3 = FPAdd(.User3, Curamt, 2)
                    Else
                        .User4 = FPAdd(.User4, Curamt, 2)
                    End If
                    'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice print suppress at 0
                    'If bMassUp.InvPrintSuppress Then
                    '.User5 = "1"
                    'Else
                    .User5 = "0"
                    'End If
                    Call SUpdate1(CSR_SMContractBill, "smcontractbill", bsmContractBill)

                    Balance -= Curamt

                    If Balance = 0 Then Exit Do
                End If
                serr1 = SFetch1(CSR_SMContractBill, bsmContractBill)
            Loop
        End With


        'in case there was a 4th of the month and now it's 0
        SQLstmt = "delete from smcontractbill where billamount = 0 and contractid = " + SParm(bXSVCGRID.ContractID)
        Call sql(c9, SQLstmt)
    End Sub

    Sub gRecalcBillings()           '5/30/2019 Change Start and End Dates 
        Dim XTB_SERVICES_Insert As XTB_SERVICES = New XTB_SERVICES
        Dim xCusConMasterFlg As Short    '7/17/2019 - Need to set other dates.
        Dim NumRecs As Integer           '7/17/2019 - Need to set other dates.
        Dim duration As Short            '7/17/2019 - Need to set other dates.
        Dim NbrOfDays As Integer         '10/8/2019 - Warranty Date is prior to Start Date.
        Dim HasWarrantyDate As Boolean   '10/8/2019 - Warranty Date is prior to Start Date.
        Dim OrigStartDateCom As Integer  '10/11/2019 - Want to have Original Start Date.

        Call TranBeg(True)

        If bKeyid.ID = 4 Then                   '10/10/2019  - Moved up incase this was causing an locking issue. And committed the transaction before starting the original changes.
            'Populate XTB_SERVICES
            'Call sql(CSR_XTB_Services, "Select top 1 * from xtb_services") 'compile cursor
            SQLstmt = "XSVCU00_ChangeStartDate" + SParm(bXSVCGRID.ContractID) + SParm(CurUser) + SParm(CurProg) + DParm(Curdate) + DParm(bMassUp.ContractStartDate)  '10/10/2019  - Moved up incase this was causing an locking issue. And committed the transaction before starting the original changes.
            Call sql(CSR_XTB_Services, SQLstmt) 'compile cursor                                                                                                      '10/10/2019  - Moved up incase this was causing an locking issue. And committed the transaction before starting the original changes.

            'Call sql(CSR_XTB_Services, "UPDATE xtb_Services SET user8 = '5/1/2019', user7 = '1/1/1900' WHERE ContractID = 'BR10000006'") 'compile cursor
            'User8 - Effective Change Amount Date
            'User7 - End Date
            'User5 - Update Type
            'With bXTB_SERVICES
            '    .user8 = bMassUp.ContractStartDate
            '    .lupd_datetime = Curdate
            '    .lupd_prog = CurProg
            '    .lupd_user = CurUser
            '    .user7 = NULLDATE    'end date
            '    Call SUpdate1(CSR_XTB_Services, "XTB_Services", bXTB_SERVICES)
            'End With  'xtb_services
        End If                               '10/10/2019  - Moved up incase this was causing an locking issue. And committed the transaction before starting the original changes.

        Call TranEnd()                       '10/10/2019  - Moved up incase this was causing an locking issue. And committed the transaction before starting the original changes.
        Call TranBeg(True)                   '10/10/2019  - Moved up incase this was causing an locking issue. And committed the transaction before starting the original changes.

        SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr1 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)

        Call sql(CSR_xSvcUpdHist, "select top 1 * from  xSvcUpdHist") 'compile cursor   


        With bXSVCUPDHIST
            .Contractid = bXSVCGRID.ContractID
            'START DATE
            If bKeyid.ID = 4 Then
                .UpdateType = "SD"
                .user5 = bsmContract.StartDate
                .user6 = bMassUp.ContractStartDate
            End If
            'END DATE
            If bKeyid.ID = 5 Then
                .UpdateType = "ED"
                .user5 = bsmContract.ExpireDate
                .user6 = bMassUp.ContractEndDate
            End If
            'If bKeyid.ID = "" Then
            '    .UpdateType = "BR"
            '    .user5 = bsmContract.ExpireDate
            '    .user6 = bMassUp.ContractEndDate
            'End If
            .lupd_datetime = Curdate
            .lupd_prog = CurProg
            .lupd_user = CurUser
            Call SInsert1(CSR_xSvcUpdHist, "XSVCUPDHIST", bXSVCUPDHIST)
        End With

        With bsmContract
            'START DATE
            If bKeyid.ID = 4 Then
                'Check to see if Warranty Date is Null Date 1/1/1900
                NbrOfDays = DateCmp(.User7, NULLDATE)                                     '10/8/2019 - Warranty Date is prior to Start Date.
                HasWarrantyDate = False                                                   '10/8/2019 - Warranty Date is prior to Start Date.
                If NbrOfDays <> 0 Then                                                    '10/8/2019 - Warranty Date is prior to Start Date.
                    NbrOfDays = DateMinusDate(.StartDate, .User7)                         '10/8/2019 - Warranty Date is prior to Start Date.
                    HasWarrantyDate = True                                                '10/8/2019 - Warranty Date is prior to Start Date.
                End If                                                                    '10/8/2019 - Warranty Date is prior to Start Date.

                If NbrOfDays <> 0 And HasWarrantyDate = True Then                          '10/8/2019 - Warranty Date is prior to Start Date.
                    Call DatePlusDays(bMassUp.ContractStartDate, NbrOfDays, .User7)       '10/8/2019 - Warranty Date is prior to Start Date.
                End If                                                                    '10/8/2019 - Warranty Date is prior to Start Date.
                If NbrOfDays = 0 And HasWarrantyDate = True Then                          '10/8/2019 - Warranty Date is prior to Start Date.
                    If DateMinusDate(.StartDate, .User7) = 0 Then                         '10/8/2019 - Warranty Date is prior to Start Date.
                        .User7 = bMassUp.ContractStartDate                                '10/8/2019 - Warranty Date is prior to Start Date.
                    End If                                                                '10/8/2019 - Warranty Date is prior to Start Date.
                End If                                                                    '10/8/2019 - Warranty Date is prior to Start Date.

                OrigStartDateCom = .StartDate
                .StartDate = bMassUp.ContractStartDate
                .EffectiveDate = bMassUp.ContractStartDate                                                         '7/17/2019 - Need to set other dates.
                .AmortStartDate = bMassUp.ContractStartDate                                                        '7/17/2019 - Need to set other dates.
                .BillStartDate = bMassUp.ContractStartDate                                                         '7/17/2019 - Need to set other dates.


                '10/11/2019 Setting User7 Above based on Date Change. duration = -1                                                                                      '7/17/2019 - Need to set other dates.  (Initialize it to -1, since Warrenty Date should be 1 less than Start date if no Warrenty Duration.)
                '10/11/2019 Setting User7 Above based on Date Change. SQLstmt = "XCUSCONMASTER_MasterIDCustid" + SParm(bsmContract.MasterID) + SParm(bsmContract.Custid) '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. xCusConMasterFlg = SqlFetch1(c3, SQLstmt, bXCUSCONMASTER)                                          '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. If xCusConMasterFlg <> NOTFOUND Then                                                               '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. If bXCUSCONMASTER.WarrantyDuration > 0 Then                                                    '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. NumRecs = 0                                                                                '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. SQLstmt = "XSVCU00_CountCPOptionItems" + SParm(bsmContract.ContractID)                     '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. serr12 = SqlFetch1(c12, SQLstmt, NumRecs)                                                  '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. If serr12 <> NOTFOUND Then                                                                 '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. If NumRecs > 0 Then                                                                    '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. duration = Val(bXCUSCONMASTER.WarrantyDuration)                                    '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. Call DatePlusDays(bMassUp.ContractStartDate, duration, .User7)                     '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. End If                                                                                 '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. End If                                                                                     '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. End If                                                                                         '7/17/2019 - Need to set other dates.
                '10/11/2019 Setting User7 Above based on Date Change. End If                                                                                             '7/17/2019 - Need to set other dates.
            End If
            'END DATE
            If bKeyid.ID = 5 Then
                .ExpireDate = bMassUp.ContractEndDate
                .NoteId = GAddContractStartEndNote("New Change End Date is", bMassUp.ContractEndDate)
            End If
            If bKeyid.ID = 4 Then
                .NoteId = GAddContractStartDateChangeNote("Orig Start Date is ", " New Change Start Date is", bMassUp.ContractStartDate, OrigStartDateCom)
            End If
            .Lupd_dateTime = Curdate
            .Lupd_Prog = CurProg
            .Lupd_User = CurUser
            Call SUpdate1(CSR_SMContract, "SMCONTRACT", bsmContract)
        End With

        Call TranEnd()
        Call TranBeg(True)

        SQLstmt = "xOthChanges_WarrantyChgs" + SParm(bXSVCGRID.ContractID) + DParm(bsmContract.User7) + DParm(bsmContract.StartDate)
        Call sql(CSR_XTB_Services, SQLstmt)

        Call TranEnd()

        NumRecs = 0
        SQLstmt = "xWarrChk" + SParm(bXSVCGRID.ContractID)
        Call sql(c3, SQLstmt)
        serr3 = SGroupFetch1(c3, NumRecs)
        If NumRecs Then
            Warranty = True
        Else
            Warranty = False
        End If

        Call TranBeg(True)
        'doRevenues
        'doBillings
        If Warranty = False Then
            SQLstmt = "XSVCUPD_ReCreateRevBillSchedules" + SParm(bXSVCGRID.ContractID) + SParm(CurUser)
            Call sql(c4, SQLstmt)
        Else
            SQLstmt = "XSVCUPD_ReCreateRevBillSchedulesWarranty" + SParm(bXSVCGRID.ContractID) + SParm(CurUser)
            Call sql(c4, SQLstmt)
        End If
        'SQLstmt = "xOthChanges_WarrantyChgs" + SParm(bXSVCGRID.ContractID) + DParm(bsmContract.User7)
        'Call sql(CSR_XTB_Services, SQLstmt) 'compile cursor
        'If bKeyid.ID = 4 Then
        '    SQLstmt = "UPDATE xtb_Services SET statusdate = " + DParm(bMassUp.ContractStartDate) + "WHERE ContractID = " + SParm(bXSVCGRID.ContractID)
        '    Call sql(c4, SQLstmt)
        'End If
        Call TranEnd()

    End Sub

End Module