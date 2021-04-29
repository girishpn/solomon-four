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

        If bKeyid.ID = 15 Then
            If Trim(ItemType) = "MAINT" Then
                ChangeRMRAmt = bMassUp.MaintAmt
            ElseIf Trim(ItemType) = "MONITORING" Then
                ChangeRMRAmt = bMassUp.MonitAmt
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

        SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr1 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)

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
        Call sql(c4, SQLstmt)                                                                                 '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        Call SGroupFetch1(c4, BillingsPriorDateCount)                                                         '5/23/2019 - Amount is changed on Service Items with an effective date after the current active date of item.
        'Populate XTB_SERVICES
        'Change here
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
            If .GroupCode.Trim = "MAINT" Then
                Maint = True
            Else
                Maint = False
            End If

            bXSVCUPDHIST.OrigRMRAmt = bXTB_SERVICES.MonthAmt
            'mod 3/19/17
            Select Case ChangeRMRAmtOpt
                Case 1
                    .MonthAmt = FPAdd(bXTB_SERVICES.MonthAmt, ChangeRMRAmt, 2)
                Case 2
                    .MonthAmt = ChangeRMRAmt
                Case 3 'Mod 9/10/2019 - Solomon Cloud Solutions - Change by pct amount
                    .MonthAmt = .MonthAmt + FPMult(bXTB_SERVICES.MonthAmt, FPMult(ChangeRMRAmt, 0.01, 2), 2)
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
                    ChangeRMRAmt = FPMult(FPMult(ChangeRMRAmt, 0.01, 2), bXSVCUPDHIST.OrigRMRAmt, 2)
            End Select
            Effectdate = DateToStrSep(bMassUp.EffectDate)

            EndDate = DateToStrSep(bsmContract.ExpireDate)
            NumMonths = GetMonths(bMassUp.EffectDate, bsmContract.ExpireDate) + 1   'Total Duration
            'Calculate 1st month amt
            'MOD 7/22/17
            ' DayNum = Math.Min(Effectdate.Day, 30)
            Call Status(SaveGoodArgVals, False, "*****Calculate 1st Month Amount", LOG_AND_DISP)
            DayNum = Effectdate.Day
            Call Status(SaveGoodArgVals, False, "DayNum " + DayNum.ToString, LOG_AND_DISP)
            NumDays = 30 - DayNum + 1
            Call Status(SaveGoodArgVals, False, "NumDays = 30 - DayNum + 1", LOG_AND_DISP)

            Call Status(SaveGoodArgVals, False, "NumDays: " + NumDays.ToString, LOG_AND_DISP)

            Call Status(SaveGoodArgVals, False, "ChangeRMRAmt: " + ChangeRMRAmt.ToString, LOG_AND_DISP)

            Call Status(SaveGoodArgVals, False, "DailyAmt = ChangeRMRAmt / 30 to 6 decimal places", LOG_AND_DISP)
            DailyAmt = FPDiv(ChangeRMRAmt, 30, 6)

            Call Status(SaveGoodArgVals, False, "DailyAmt = " + DailyAmt.ToString, LOG_AND_DISP)

            Call Status(SaveGoodArgVals, False, "FirstPeriodAmt = NumDays * DailyAmt  to 2 decimal places", LOG_AND_DISP)

            FirstPeriodAmt = FPMult(NumDays, DailyAmt, 2)

            Call Status(SaveGoodArgVals, False, "FirstPeriodAmt = " + FirstPeriodAmt.ToString, LOG_AND_DISP)

            TotalAmt = FirstPeriodAmt

            'Balance of months excluding 1st and last month
            NumMonths = NumMonths - 2
            NextPeriodAmts = FPMult(NumMonths, ChangeRMRAmt, 2)
            TotalAmt += NextPeriodAmts

            'Last month
            'mod 12/31/16
            DayNum = Math.Min(EndDate.Day, 30)
            If EndDate.Month = 2 Then
                Dim testdate As Integer
                Call DatePlusMonthSetDay(bsmContract.ExpireDate, 0, 31, testdate)
                If testdate = bsmContract.ExpireDate Then DayNum = 30
            End If
            LastPeriodAmt = FPMult(DayNum, DailyAmt, 2)
            TotalAmt += LastPeriodAmt
        End With  'xtb_services

        Call sql(c10, "UPDATE xtb_services SET lupd_datetime = " + SParm(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "WHERE contractid = " + SParm(bXTB_SERVICES.ContractID) + " AND ServItemID = " + SParm(bXTB_SERVICES.ServItemID) + " AND LineNbr = " + SParm(bXTB_SERVICES.Linenbr))
        Call SqlFree(c10)
        With bsmContract
            bsmContract.TotalAmt = FPAdd(.TotalAmt, TotalAmt, 2)
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

        Call Status(SaveGoodArgVals, False, "Process Revenue Changes", LOG_AND_DISP)
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
        Call Status(SaveGoodArgVals, False, "Process Billing Changes", LOG_AND_DISP)
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
            Curamt = FirstPeriodAmt + FPMult(ChangeRMRAmt, NumMonths, 2)
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
            If bKeyid.ID = 3 Then
                Call sql(c2, "XTB_RevDate" + SParm(bXSVCGRID.ContractID) + Trim(SParm(bXTB_SERVICES.ServItemID)) + SParm(DateToStrSep(.RevDate)))
            End If

            Balance -= Curamt

            Call DatePlusDays(.RevDate, 1, CurRevDate)  'so it will find next not current

            SQLstmt = "xAdd_smcontractRev" + SParm(bXSVCGRID.ContractID) + DParm(CurRevDate)
            'select * from smcontractrev where contractid = @contractid and revdate >= @RevDate
            serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
            Do While serr1 = 0
                Curamt = ChangeRMRAmt
                Curamt = IIf(Curamt > 0, Math.Min(Curamt, Balance), Math.Max(Curamt, Balance))
                Balance -= Curamt

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

        RMRAmt = IIf(ChangeRMRAmt > 0, -ChangeRMRAmt, Math.Abs(ChangeRMRAmt))
        Call Status(SaveGoodArgVals, False, "RMR Amount: " + RMRAmt.ToString, LOG_AND_DISP)


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
            Call Status(SaveGoodArgVals, False, "Effective Date: " + DateToStrSep(EffectDate), LOG_AND_DISP)
            DD = Mid(DateToStr(EffectDate), 3, 2)
            Call Status(SaveGoodArgVals, False, "Effective Date Day Value: " + DD.ToString, LOG_AND_DISP)
            'Where need to insert new month since effect date not on day 1.
            If DD <> 1 Then
                Call DatePlusMonthSetDay(EffectDate, 1, 1, EffectDate)
                'mod 4/23/17  
                SQLstmt = "select max(billdate) from smcontractbill where contractid = " + SParm(bXSVCGRID.ContractID)
                serr6 = SqlFetch1(c6, SQLstmt, MaxBilldate)
                Call SqlFree(c6)

                Call Status(SaveGoodArgVals, False, "Max Bill Date: " + DateToStrSep(MaxBilldate), LOG_AND_DISP)
                EffectDate = Math.Min(MaxBilldate, EffectDate)
                Call Status(SaveGoodArgVals, False, "New Effective Date: " + DateToStrSep(EffectDate), LOG_AND_DISP)

            End If

            SQLstmt = "xAdd_MaxBillPostDate" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate)
            serr1 = SqlFetch1(c1, SQLstmt, LastPostDate)

            Call Status(SaveGoodArgVals, False, "******Early Insert/Update", LOG_AND_DISP)
            Call Status(SaveGoodArgVals, False, "Last Post Date is: " + DateToStrSep(LastPostDate), LOG_AND_DISP)

            'special rule -- client wants on separate line the credit amount related to posting - goes to date 4
            'mod 7/23/17 - eliminate the two separate billings for Posting
            If LastPostDate <> NULLDATE Then
                Call Status(SaveGoodArgVals, False, "Last Post Date is not NullDate", LOG_AND_DISP)

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


                Call Status(SaveGoodArgVals, False, "Frequency Start Date is: " + DateToStrSep(FreqStartDate), LOG_AND_DISP)

                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))
                '10/3/2019 Fixed Arrears by Updating Eff Date.  If IsArrears = True And NumMonths > 0 Then                                          '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date.    'Dim Datstr As String = DateToStr(bMassUp.EffectDate), DY As Short = 0          '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date.    'IsArrears = True                                                                '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month 
                '10/3/2019 Fixed Arrears by Updating Eff Date.    'DY = Mid(Datstr, 3, 2)                                                         '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date.    'Call DatePlusMonthSetDay(bMassUp.EffectDate, 1, DY, bMassUp.EffectDate)        '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date. NumMonths = NumMonths - 1                                                       '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month
                '10/3/2019 Fixed Arrears by Updating Eff Date. End If                                                                              '10/2/2019 Arrears is off by One Month Always. Could refetch it and do calcultion but subtracting 1 month

                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period

                If ChangeRMRAmt > 0 Then
                    Curamt = Math.Min(Curamt, Balance)
                Else
                    Curamt = Math.Max(Curamt, Balance)
                End If
                Balance -= Curamt

                'insert a record
                .User3 = 0 : .User4 = 0

                Call Status(SaveGoodArgVals, False, "CurAmt is: " + Balance.ToString, LOG_AND_DISP)

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

                Call Status(SaveGoodArgVals, False, "Bill Date: " + DateToStrSep(.BillDate), LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "Bill Amount: " + .BillAmount.ToString, LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "Comment: " + .Comment.Trim, LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "******END Early Insert/Update", LOG_AND_DISP)
            Else  'no Posted amounts found

                Call Status(SaveGoodArgVals, False, "Last Post Date is NullDate", LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "First Bill Date Before: " + DateToIntlStr(FirstBillDate), LOG_AND_DISP)
                FirstBillDate = EffectDate
                Call Status(SaveGoodArgVals, False, "First Bill Date After: " + DateToIntlStr(FirstBillDate), LOG_AND_DISP)

                If bKeyid.ID = 3 And DD <> 1 Then
                    Call Status(SaveGoodArgVals, False, "--We are doing a change because the day is not the first of the month.", LOG_AND_DISP)
                    Call DatePlusMonthSetDay(FirstBillDate, -1, 1, FirstBillDate)
                    Call Status(SaveGoodArgVals, False, "First Bill Date After Change: " + DateToIntlStr(FirstBillDate), LOG_AND_DISP)
                End If

                FreqStartDate = GetFreqStartDate_Mod(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                Call Status(SaveGoodArgVals, False, "Freq Start Date: " + DateToIntlStr(FreqStartDate), LOG_AND_DISP)

                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))
                If IsArrears = True Then
                    NumMonths = NumMonths + 1
                End If
                Call Status(SaveGoodArgVals, False, "Number Of Months: " + NumMonths.ToString, LOG_AND_DISP)

                Call Status(SaveGoodArgVals, False, "Current Amount Calculation: ", LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "First Period Amount: " + FirstPeriodAmt.ToString, LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "+ (-RMR Amount: " + (RMRAmt * -1).ToString, LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "* Number Of Months: " + NumMonths.ToString, LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "Rounded by 2 decimal Places) ", LOG_AND_DISP)

                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period
                Call Status(SaveGoodArgVals, False, "Current Amount: " + Curamt.ToString, LOG_AND_DISP)

                CommentStartDate = CommentEffectDate
                Call Status(SaveGoodArgVals, False, "Comment Start Date: " + DateToStrSep(CommentStartDate), LOG_AND_DISP)

                '7/9/2019 Need to keep track of original balance
                OriginalBalance = Balance     '7/9/2019
                Call Status(SaveGoodArgVals, False, "Original Stored Balance: " + OriginalBalance.ToString, LOG_AND_DISP)

                If ChangeRMRAmt > 0 Then
                    Curamt = Math.Min(Curamt, Balance)
                Else
                    Curamt = Math.Max(Curamt, Balance)
                End If

                Call Status(SaveGoodArgVals, False, "Calculation is Balance:" + Balance.ToString + " - CurrAmt:" + Curamt.ToString, LOG_AND_DISP)

                Balance -= Curamt

                Call Status(SaveGoodArgVals, False, "New Balance: " + Balance.ToString, LOG_AND_DISP)

                Call Status(SaveGoodArgVals, False, "WarBillDate: " + DateToStrSep(WarBillDate), LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "gMaxDate: " + DateToStrSep(gMaxDate), LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "FirstBillDate: " + DateToStrSep(FirstBillDate), LOG_AND_DISP)


                If WarBillDate <> gMaxDate And WarBillDate > FirstBillDate Then   'where posting date > warbilldate
                    Call Status(SaveGoodArgVals, False, "Posting Date > War Bill Date", LOG_AND_DISP)

                    If Warranty Then
                        Call Status(SaveGoodArgVals, False, "This is a Warranty", LOG_AND_DISP)

                        If FirstBillDate = WarBillDate Or FirstBillDate + 1 = WarBillDate Then
                            .BillDate = WarBillDate 'where warrantydate was on the 1st or 2nd
                        End If
                    Else  'servitemid not a warranty
                        Call Status(SaveGoodArgVals, False, "This is NOT a Warranty", LOG_AND_DISP)

                        If FirstBillDate = WarBillDate Then
                            .BillDate = WarBillDate + 2  'where warrantydate was on 1st -- so non-warranty had to go to the 3rd
                        Else
                            .BillDate = FirstBillDate
                        End If
                    End If
                Else
                    Call Status(SaveGoodArgVals, False, "Set Bill Date to First Bill Date", LOG_AND_DISP)
                    .BillDate = FirstBillDate
                End If

                Call Status(SaveGoodArgVals, False, "New Bill Date: " + DateToStrSep(.BillDate), LOG_AND_DISP)

                .User3 = 0 : .User4 = 0
                OrigBillDate = .BillDate
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate) + DParm(.BillDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                '7/9/2019   - Since Tribridge calculates the SMContractBill BillDate based on Dates and frequency, there is a screen that could generate smcontractBill BillDate to keep the Bill Dates in sync between contracts. 
                '    For Example Start Date 4/20/2019 and quarterly, then the next one for SMContractBill would be 7/1/2019 for Tribridge, but the screen would say 5/1/2019 as the next one. This causes issue with GetFreqStartDate
                If Trim$(bsmContract.BillingFreq) = "Q" And serr3 = NOTFOUND And NumMonths = 0 And RMRAmt <> 0 Then  '7/9/2019   -

                    Call Status(SaveGoodArgVals, False, "In Quarterly Area", LOG_AND_DISP)
                    'Fetch the record based on BillDate between Comments.
                    SQLstmt = "smContractBill_ContractID_ByCommentDate" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate)  '7/9/2019   -
                    serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)                       '7/9/2019   -
                    If serr3 <> NOTFOUND Then                                                             '7/9/2019   -

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
                                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, CommentGetMonths, 2)            '7/9/2019   -
                                If ChangeRMRAmt > 0 Then                                                  '7/9/2019   -
                                    Curamt = Math.Min(Curamt, OriginalBalance)                            '7/9/2019   -
                                Else                                                                      '7/9/2019   -
                                    Curamt = Math.Max(Curamt, OriginalBalance)                            '7/9/2019   -
                                End If                                                                    '7/9/2019   -
                                Balance = OriginalBalance - Curamt                                        '7/9/2019   -
                            End If                                                                        '7/9/2019   -
                        Else
                            'Refetch the record and let it process how it did before.                     '7/9/2019   -
                            .User3 = 0 : .User4 = 0                                                       '7/9/2019   -
                            SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(OrigBillDate) + DParm(OrigBillDate) '7/9/2019   -
                            serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)                                           '7/9/2019   -
                        End If                                                                            '7/9/2019   -
                    End If                                                                                '7/9/2019   -
                Else                                                                                                              '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                    Call Status(SaveGoodArgVals, False, "NOT in Quarterly Area", LOG_AND_DISP)
                    Call Status(SaveGoodArgVals, False, "Current RMR Amount: " + RMRAmt.ToString, LOG_AND_DISP)
                    Call Status(SaveGoodArgVals, False, "Current Bill Date: " + DateToStrSep(.BillDate), LOG_AND_DISP)
                    Call Status(SaveGoodArgVals, False, "Serr3: " + serr3.ToString, LOG_AND_DISP)

                    If serr3 = NOTFOUND And RMRAmt <> 0 Then '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        SQLstmt = "smContractBill_ContractID_ByCommentDate" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate)      '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)                                           '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        If serr3 <> NOTFOUND Then                                                                                 '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                            IsBillAmtNeg = FPAdd(bsmContractBill.BillAmount, Curamt, 2)                                           '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                            'If the amount is going to be negative, then they want it on a seperate line.
                            If IsBillAmtNeg <= 0 Then                                                                             '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                                serr3 = NOTFOUND                                                                                  '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                                .User3 = 0 : .User4 = 0                                                                           '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                                .BillDate = OrigBillDate                                                                          '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                            End If                                                                                                '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        End If                                                                                                    '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                    End If                                                                                                        '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.

                    If serr3 = NOTFOUND Then                                                                                      '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        Call DatePlusMonthSetDay(.BillDate, 0, 3, .BillDate)                                                      '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        'Refetch the record and let it process how it did before.                                                 '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        .User3 = 0 : .User4 = 0                                                                                   '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate) + DParm(.BillDate) '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                        serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)                                           '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                    End If                                                                                                        '9/23/2019 If there is an open line, then adjust the open line even though the Mass Effective Date does not match the Bill Date. If Amount will go negative together, then make a seperate line.
                End If

                Call Status(SaveGoodArgVals, False, "Current Bill Date: " + DateToStrSep(.BillDate), LOG_AND_DISP)

                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
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
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    .NoteID = GAddNote("Changed", bMassUp.EffectDate) 'mod 10/29/17
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If
                Call Status(SaveGoodArgVals, False, "Bill Date: " + DateToStrSep(.BillDate), LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "Bill Amount: " + .BillAmount.ToString, LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "Comment: " + .Comment.Trim, LOG_AND_DISP)
                Call Status(SaveGoodArgVals, False, "******END Early Insert/Update", LOG_AND_DISP)
            End If

            If bKeyid.ID = 3 Then
                Call sql(c2, "XTB_BillDate" + SParm(bXSVCGRID.ContractID) + Trim(SParm(bXTB_SERVICES.ServItemID)) + SParm(DateToStrSep(bsmContractBill.BillDate)))
            End If

            Dim dy As Short = 0
            SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate) + DParm(gMaxDate)  'mod 12/15/16
            If IsArrears = True Then
                Dim ArrearDate As Date
                Dim TempDate As Integer
                ArrearDate = DateToStrSep(FreqStartDate)
                ArrearDate = ArrearDate.AddMonths(1)
                Call StrToDate(CStr(ArrearDate), TempDate)
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(TempDate) + DParm(gMaxDate)
            End If
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

            If serr1 = 9 Then
                SQLstmt = "xtb_findnextbilldate" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate) + DParm(EffectDate)
                serr1 = SqlFetch1(c10, SQLstmt, SearchDate)
                Call SqlFree(c10)
                If serr1 = 0 Then
                    SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(SearchDate) + DParm(gMaxDate)
                    serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
                End If
            End If

            Call Status(SaveGoodArgVals, False, "******Start Loop Adjustment", LOG_AND_DISP)

            Do While serr1 = 0
                dy = Mid(DateToStr(.BillDate), 3, 2)
                If (Not (Warranty) And WarBillDate = .BillDate) Or dy = 4 Or dy = 3 Then   '10/2/2019  Since we changed the Change date to 3, then we need to add this day as an exception too. (Could have added Variable above to check which date was updated and don't update it again instead of dy = 3.)
                    'do nothing
                    Call Status(SaveGoodArgVals, False, "Doing Nothing", LOG_AND_DISP)
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





                    'TEST BLOCK
                    Curamt = FPMult(-RMRAmt, CommentGetMonths, 2)
                    'End If                                                                                                  '7/9/2019   -
                    'mod 5/15/17  wasn't limiting curamt to balance
                    If ChangeRMRAmt > 0 Then
                        Curamt = Math.Min(Curamt, Balance)
                    Else
                        Curamt = Math.Max(Curamt, Balance)
                    End If

                    Call Status(SaveGoodArgVals, False, "Bill Date is: " + DateToStrSep(.BillDate), LOG_AND_DISP)
                    Call Status(SaveGoodArgVals, False, "Comment: " + .Comment.ToString, LOG_AND_DISP)
                    Call Status(SaveGoodArgVals, False, "Current Amount: " + Curamt.ToString, LOG_AND_DISP)

                    Balance -= Curamt

                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    Call Status(SaveGoodArgVals, False, "Bill Amount: " + .BillAmount.ToString, LOG_AND_DISP)

                    If Maint Then
                        .User3 = FPAdd(.User3, Curamt, 2)
                        Call Status(SaveGoodArgVals, False, "Maint Amount: " + .User3.ToString, LOG_AND_DISP)
                    Else
                        .User4 = FPAdd(.User4, Curamt, 2)
                        Call Status(SaveGoodArgVals, False, "Monitor Amount: " + .User4.ToString, LOG_AND_DISP)
                    End If

                    'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice suppress at 0
                    'If bMassUp.InvPrintSuppress Then
                    '.User5 = "1"
                    'Else
                    .User5 = "0"
                    'End If
                    Call SUpdate1(CSR_SMContractBill, "smcontractbill", bsmContractBill)

                    Call Status(SaveGoodArgVals, False, "Record Updated. Balance Left: " + Balance.ToString, LOG_AND_DISP)

                    If Balance = 0 Then Exit Do
                End If
                serr1 = SFetch1(CSR_SMContractBill, bsmContractBill)
            Loop
        End With

        Call Status(SaveGoodArgVals, False, "******End Loop Adjustment", LOG_AND_DISP)

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
                    FirstPerAmtAvail = 0
                Else
                    'mod  6/12/17
                    Dim statusdate As Integer = 0
                    Datstr = DateToStr(bXTB_SERVICES.StatusDate) : Dy = Mid(Datstr, 3, 2)
                    Call DatePlusMonthSetDay(bXTB_SERVICES.StatusDate, IIf(IsArrears, 1, 0), Dy, statusdate)

                    NumMonths = GetMonths(bCreditInfo.FirstPostDate, bXTB_SERVICES.StatusDate)
                    If NumMonths = -1 Then    'where partial month from previous month included in current month
                        Curamt = FirstPeriodAmt + FPMult(-RMRAmt, (Frequency * bCreditInfo.NumMonths), 2)
                        FirstPerAmtAvail = 0
                    Else
                        Curamt = FPMult(-RMRAmt, (Frequency * bCreditInfo.NumMonths), 2)
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
                    Else
                        If bMassUp.EffectDate <> EffectDate Then
                            FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                        Else
                            FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, bCreditInfo.LastPostDate, Frequency)
                        End If
                        NumMonths = GetMonths(EffectDate, FreqStartDate)
                        Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period
                        Curamt = FPSub(Curamt, CreditAmt, 2)
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
                    Datstr = DateToStr(FirstBillDate) : Dy = Mid(Datstr, 3, 2)
                    Call DatePlusMonthSetDay(FirstBillDate, IIf(IsArrears, -1, 0), Dy, CommentStartDate)
                End If
            Else  'no Posted amounts found
                FirstBillDate = EffectDate
                FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)  'mod 12/14/16
                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))  'mod 12/23/16
                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period
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
        Call TranBeg(True)
        'doRevenues
        'doBillings
        SQLstmt = "XSVCUPD_ReCreateRevBillSchedules" + SParm(bXSVCGRID.ContractID) + SParm(CurUser)
        Call sql(c4, SQLstmt)

        'SQLstmt = "xOthChanges_WarrantyChgs" + SParm(bXSVCGRID.ContractID) + DParm(bsmContract.User7)
        'Call sql(CSR_XTB_Services, SQLstmt) 'compile cursor
        'If bKeyid.ID = 4 Then
        '    SQLstmt = "UPDATE xtb_Services SET statusdate = " + DParm(bMassUp.ContractStartDate) + "WHERE ContractID = " + SParm(bXSVCGRID.ContractID)
        '    Call sql(c4, SQLstmt)
        'End If
        Call TranEnd()

    End Sub

End Module