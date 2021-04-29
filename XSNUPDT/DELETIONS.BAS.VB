Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports VB = Microsoft.VisualBasic
Module Deletions
    Dim NumMonths As Short, Frequency As String, Linenbr As Short, TotalAmt As Double
    Dim Curamt As Double, Balance As Double, Maint As Boolean, FirstPeriodAmt As Double, MaxBilldate As Integer, Warranty As Boolean
    Dim RMRAmt As Double = 0  'mod 12/6/16
    Dim IsArrears As Boolean
    Dim FirstPeriodAmtAdj As Double    '6/14/2019 - 6/26/2019
    Dim RMR_Current_StartDate As Integer '6/14/2019

    Class Equip
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
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
    Dim bEquip As Equip = New Equip

    Class RMRAmt_Adj
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0) _
        > _
        Public Property RMRAmt_Adj() As Double

            Get
                Return Me.GetPropertyValue("RMRAmt_Adj")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("RMRAmt_Adj", setval)
            End Set

        End Property
    End Class
    Dim bRMRAmt_Adj As RMRAmt_Adj = New RMRAmt_Adj

    Sub gProcessDeletions(Multi As Boolean, XTB_Linenbr As Short)
        'mod 5/23/17 major change to Postings and C/M
        Dim Effectdate As Date, EndDate As Date, DayNum As Short, NumDays As Short
        Dim NextPeriodAmts As Double, LastPeriodAmt As Double, DailyAmt As Double, Numrecs As Integer = 0
        Dim PostWarranty As Integer = 0, ActualEffectDate As Integer, Datstr As String = DateToStr(bMassUp.EffectDate), DY As Short = 0
        Dim NumOpenMonths As Integer = 0 'mod 6/4/17
        Dim DailyAmtAdjustment As Double   '6/14/2019
        'Dim FirstPeriodAmtAdj As Double    '6/14/2019 - 6/26/2019
        Dim NumMonthAdj As Short           '6/14/2019
        Dim NumMonthAdjRemainder As Short  '6/14/2019 - 6/26/2019
        Dim NextPeriodAmtAdj As Double     '6/14/2019
        Dim Prior_RMRAmt_Flg As Short      '6/14/2019
        Dim RMRAmt_Diff As Double          '6/14/2019
        Dim CSR_xtb_ServicesWrk As Short   '6/14/2019
        Dim DayOfWeek As String             '6/14/2019 - 6/26/2019
        Call SqlCursorEx(CSR_xtb_ServicesWrk, NOLEVEL, "CSR_xtb_ServicesWrk", "xtb_ServicesWrk", "")  '6/14/2019
        If Not Multi Then Call TranBeg(True)
        IsArrears = False

        Numrecs = 0
        SQLstmt = "xAdd_WarTest" + SParm(bMassUp.ServItemSel)
        Call sql(c3, SQLstmt)
        serr3 = SGroupFetch1(c3, Numrecs)
        If Numrecs Then
            Warranty = True
        Else
            Warranty = False
        End If

        Call sql(CSR_xSvcUpdHist, "select top 1 * from  xSvcUpdHist") 'compile cursor

        SQLstmt = "smcancellation_all" + SParm(bMassUp.CancelCode)
        serr1 = SqlFetch1(c1, SQLstmt, bsmCancellation)

        SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr1 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)

        'mod 7/24/17
        bMassUp.EffectDate = Math.Max(bMassUp.EffectDate, bsmContract.StartDate) 'from XSNUPDT


        gGetWarBilldate(bXSVCGRID.ContractID) 'mod 7/17/17 get warbilldate moved from above to obtain smcontract.billingfreq


        'Populate XTB_SERVICES  - This all needs to change since not inserting records.
        With bXTB_SERVICES
            SQLstmt = "xDELCHG_FindServItem" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + SParm(XTB_Linenbr)
            serr5 = SqlFetch1(CSR_XTB_Services, SQLstmt, bXTB_SERVICES)

            '6/14/2019 - Second Round of Change for Canceling Contracts where RMRAmt has changed.
            SQLstmt = "XSVCUPD_xtb_ServicesWrk_Prior_Rcd" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + SParm(XTB_Linenbr) + SParm(bpes.UserId) + DParm(bXTB_SERVICES.StatusDate) 'SCOTT 6/14/2019
            Prior_RMRAmt_Flg = SqlFetch1(CSR_xtb_ServicesWrk, SQLstmt, bxtb_ServicesWrk)  'SCOTT 6/14/2019
            If Prior_RMRAmt_Flg <> NOTFOUND Then
                bMassUp.EffectDate = Math.Max(bMassUp.EffectDate, bxtb_ServicesWrk.StatusDate)   '6/14/2019
            Else
                bMassUp.EffectDate = Math.Max(bMassUp.EffectDate, bXTB_SERVICES.StatusDate)   'mod 7/25/17
            End If

            'mod 12/6/16
            If bMassUp.RMRAmt = 0 Then
                RMRAmt = .MonthAmt
            Else
                RMRAmt = bMassUp.RMRAmt
            End If

            RMR_Current_StartDate = .user8

            .GroupCode = bXTB_SERVICES.GroupCode
            If .GroupCode.Trim = "MAINT" Then
                Maint = True
            Else
                Maint = False
            End If
            .Status = "C"

            ' .user7 = bMassUp.EffectDate  'user7 = end date
            .user7 = Math.Min(bMassUp.EffectDate, bsmContract.ExpireDate)  '  mod 7/21/18  for xsnupdt xtra date past expire date
            .user8 = .user7 'mod 10/29/17
            .StatusReason = "DELETE Part -" + bpes.UserId.Trim + " " + DateToStrSep(Curdate)
            .user5 = "Deletion"

            .lupd_datetime = Curdate
            .lupd_prog = CurProg
            .lupd_user = CurUser


            ' bMassUp.EffectDate = Math.Min(bMassUp.EffectDate, bXTB_SERVICES.StatusDate) 'mod 4/23/17
            Effectdate = DateToStrSep(bMassUp.EffectDate)

            EndDate = DateToStrSep(bsmContract.ExpireDate)
            NumMonths = GetMonths(bMassUp.EffectDate, bsmContract.ExpireDate) + 1   'Total Duration
            'Calculate 1st month amt

            'MOD 7/22/17
            ' DayNum = Math.Min(Effectdate.Day, 30)
            DayNum = Effectdate.Day
            NumDays = 30 - DayNum + 1
            ''mod 7/20/18 don't give credit
            If bMassUp.EffectDate = bsmContract.ExpireDate Then
                NumDays = 0
            End If
            DailyAmt = FPDiv(-RMRAmt, 30, 6)
            FirstPeriodAmt = FPMult(NumDays, DailyAmt, 2)
            TotalAmt = FirstPeriodAmt

            '6/14/2019 - Change for Canceling Contracts where RMRAmt has changed.
            SQLstmt = "XSVCUPD_xtb_ServicesWrk_Orig_RMRAmt" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + SParm(XTB_Linenbr) + SParm(bpes.UserId) 'SCOTT 6/14/2019
            Prior_RMRAmt_Flg = SqlFetch1(CSR_xtb_ServicesWrk, SQLstmt, bxtb_ServicesWrk)  '6/14/2019
            If Prior_RMRAmt_Flg <> NOTFOUND Then                                          '6/14/2019
                RMRAmt_Diff = FPSub(RMRAmt, bxtb_ServicesWrk.MonthAmt, 2)                 '6/14/2019
                DailyAmtAdjustment = (FPDiv(RMRAmt_Diff, 30, 6))                          '6/14/2019

                Dim NbrOfDays As Integer    ' 7/11/2019 Need to see if the whole contract is being cancelled.
                NbrOfDays = DateMinusDate(bsmContract.StartDate, bMassUp.EffectDate)      ' 7/11/2019 Need to see if the whole contract is being cancelled.
                If NbrOfDays <= 0 Then   ' 7/11/2019 Need to see if the whole contract is being cancelled.
                    'Cancelling the whole contract                                        ' 7/11/2019 Need to see if the whole contract is being cancelled.
                    FirstPeriodAmtAdj = FPMult(NumDays, DailyAmtAdjustment, 2)                '6/14/2019
                    TotalAmt = FPAdd(TotalAmt, FirstPeriodAmtAdj, 2)                          '6/14/2019
                    NumMonthAdj = DateMinusDate(bxtb_ServicesWrk.user8, RMR_Current_StartDate) '6/14/2019
                    If NumMonthAdj > 0 Then                                                   '6/14/2019
                        'NumMonthAdj = FPDiv(NumMonthAdj, 30, 0) - 1                              '6/14/2019 - 6/26/20169
                        'Since the first Adjustment might not be for the full month since the date may not have been the first day of the month '6/14/2019 - 6/26/2019
                        DayOfWeek = Val(Mid(DateToStr(bsmContract.StartDate), 3, 2)).ToString   '6/14/2019 - 6/26/2019
                        If Trim$(DayOfWeek) = "01" Or DayOfWeek = "1" Then                                           '6/14/2019 - 6/26/2019
                            NumMonthAdj = FPDiv(NumMonthAdj, 30, 2) - 1                           '6/14/2019 - 6/26/2019
                        Else
                            'Getting the Remainder to determine if we need to do additional months.
                            NumMonthAdjRemainder = NumMonthAdj Mod 30
                            If NumMonthAdjRemainder >= 1 And NumMonthAdjRemainder < 15 Then
                                NumMonthAdj = FPDiv(NumMonthAdj, 30, 2)                            '6/14/2019 - 6/26/2019
                            Else
                                NumMonthAdj = FPDiv(NumMonthAdj, 30, 2) - 1                           '6/14/2019 - 6/26/2019
                            End If
                        End If
                    End If
                Else                                                                         ' 7/11/2019 Need to see if the whole contract is being cancelled.
                    Dim NbrOfDays2 As Integer                                                ' 7/11/2019 Need to see if the whole contract is being cancelled.
                    NbrOfDays2 = DateMinusDate(bMassUp.EffectDate, bxtb_ServicesWrk.user7)   ' 7/11/2019 Need to see if the whole contract is being cancelled.
                    If NbrOfDays2 >= 0 Then                                                  ' 7/11/2019 Need to see if the whole contract is being cancelled.
                        FirstPeriodAmtAdj = FPMult(NbrOfDays2, DailyAmtAdjustment, 2)        ' 7/11/2019 Need to see if the whole contract is being cancelled.
                        TotalAmt = FPAdd(TotalAmt, FirstPeriodAmtAdj, 2)                     ' 7/11/2019 Need to see if the whole contract is being cancelled.
                    End If                                                                   ' 7/11/2019 Need to see if the whole contract is being cancelled.
                    NumMonthAdj = 0                                                          ' 7/11/2019 Need to see if the whole contract is being cancelled.
                End If ' 7/11/2019 Need to see if the whole contract is being cancelled.
            Else                                                                          '6/14/2019
                RMRAmt_Diff = 0                                                           '6/14/2019
                DailyAmtAdjustment = 0                                                    '6/14/2019
                FirstPeriodAmtAdj = 0                                                     '6/14/2019
                NumMonthAdj = 0                                                           '6/14/2019
            End If

            'Balance of months excluding 1st and last month
            NumMonths = NumMonths - 2
            NextPeriodAmts = FPMult(NumMonths, -RMRAmt, 2)
            TotalAmt += NextPeriodAmts
            Call SqlFree(CSR_xtb_ServicesWrk)

            '6/14/2019 - Change for Canceling Contracts where RMRAmt has changed.
            If Prior_RMRAmt_Flg <> NOTFOUND And NumMonthAdj > 0 Then                     '6/14/2019
                NextPeriodAmtAdj = FPMult(NumMonthAdj, RMRAmt_Diff, 2)                   '6/14/2019
                TotalAmt = TotalAmt + NextPeriodAmtAdj                                   '6/14/2019
            End If

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


            Call SUpdate1(CSR_XTB_Services, "XTB_Services", bXTB_SERVICES)
            With bXSVCUPDHIST
                'mod 12/4/16 get cancel descr
                .Descr = bsmCancellation.CancellationDesc
                .Contractid = bXSVCGRID.ContractID
                .ServItemID = bMassUp.ServItemSel
                .OrigRMRAmt = bXTB_SERVICES.MonthAmt 'mod 1/18/17
                .NewRMRAmt = 0 'mod 1/18/17
                .lupd_datetime = Curdate
                .lupd_prog = CurProg
                .lupd_user = CurUser
                .UpdateType = "D"
                'mod 6/6/19 Add Effective Date to User5 - Solomon Cloud Solutions
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
        End With  'xtb_services

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


        If bMassUp.EffectDate < bsmContract.ExpireDate Then   'don't do billings or revenues if expire date = effectdate

            Numrecs = 0
            SQLstmt = "select count(*) from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID)
            Call sql(c5, SQLstmt)
            serr5 = SGroupFetch1(c5, Numrecs)
            If Numrecs Then doRevenues()

            ActualEffectDate = bMassUp.EffectDate 'mod 7/26/17 ' this is the comment date in case of arrears

            'mod 6/3/17 
            SQLstmt = "xtb_smcontract_all" + SParm(bXSVCGRID.ContractID)
            serr1 = SqlFetch1(c3, SQLstmt, bXTB_SMCONTRACT)
            If bXTB_SMCONTRACT.InvoicingRule.Trim = "ARREARS" Then
                IsArrears = True
                DY = Mid(Datstr, 3, 2)
                Call DatePlusMonthSetDay(bMassUp.EffectDate, 1, DY, bMassUp.EffectDate)
            End If

            doBillings(ActualEffectDate)

            bMassUp.EffectDate = ActualEffectDate
        End If
        If Not Multi Then Call TranEnd()

    End Sub
    Private Sub doRevenues()
        Dim LastPostDate As Integer, FirstRevDate As Integer, NumMonths As Short, CurRevDate As Integer, EffectDate As Integer, WarrantyDate As Integer = 0
        Dim CommentPerEndDate As Integer = 0
        Dim RMR_Difference As Double = 0
        Dim CSR_xtb_ServicesWrk As Short
        Dim xtbServWrkFlg As Short         '6/14/2019
        Dim xtbServWrkFlg2 As Short         '6/14/2019 - 6/26/2019
        Call SqlCursorEx(CSR_xtb_ServicesWrk, NOLEVEL, "CSR_xtb_ServicesWrk", "xtb_ServicesWrk", "")   '6/14/2019
        With bsmContractRev
            .Lupd_User = CurUser
            .Lupd_DateTime = Curdate
            .Lupd_Prog = CurProg
            EffectDate = bMassUp.EffectDate

            Balance = TotalAmt

            SQLstmt = "xAdd_MaxRevPostDate" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate)
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

            If FirstRevDate >= bsmContract.ExpireDate Then
                NumMonths = GetMonths(EffectDate, FirstRevDate) - 1
                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)
                If Curamt > 0 Then  'mod 7/21/18
                    bsmContractRev.User3 = 0 : bsmContractRev.User4 = 0
                    SQLstmt = "smcontractrev_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FirstRevDate) + DParm(FirstRevDate)
                    serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                    With bsmContractRev
                        If Maint Then
                            .User3 = FPAdd(.User3, Curamt, 2)
                        Else
                            .User4 = FPAdd(.User4, Curamt, 2)
                        End If
                        If serr1 Then
                            SQLstmt = "smbranch_all" + SParm(bsmContract.BranchID)
                            serr4 = SqlFetch1(c4, SQLstmt, bsmBranch)
                            .RevAmount = Curamt
                            .RevDate = FirstRevDate
                            .ContractID = bXSVCGRID.ContractID
                            .CpnyID = bpes.CpnyID
                            .Status = "O"
                            .SalesAcct = "310000" 'mod 10/17/16
                            'mod 1/9/17, mod 8/10/18 expanded subacct by 5 add'l digits
                            If bsmBranch.User1.Trim > "" Then
                                .SalesSub = "0110600" + VB.Right(bsmBranch.User1.Trim, 14)
                            Else
                                .SalesSub = "011060000000000000000"
                            End If
                            .Comment = gGetComment(EffectDate, (FirstRevDate - 1))
                            .Lupd_DateTime = Curdate
                            .Lupd_User = CurUser
                            .Lupd_Prog = CurProg
                            .Crtd_DateTime = Curdate
                            .Crtd_User = CurUser
                            .Crtd_Prog = CurProg
                            .LineNbr = -32767
                            .Crtd_DateTime = Curdate
                            .Crtd_User = CurUser
                            .Crtd_Prog = CurProg
                            Call SInsert1(CSR_SMContractRev, "SMcontractrev", bsmContractRev)
                        Else
                            .RevAmount = FPAdd(.RevAmount, Curamt, 2)
                            .Lupd_DateTime = Curdate
                            .Lupd_User = CurUser
                            .Lupd_Prog = CurProg
                            Call SUpdate1(CSR_SMContractRev, "SMcontractrev", bsmContractRev)
                        End If
                    End With
                End If
                Exit Sub
            End If

            'mod 7/14/17
            If serr1 Then
                SQLstmt = "smcontractrev_contractid" + SParm(bXSVCGRID.ContractID) + DParm(bXTB_SERVICES.StatusDate) + DParm(bXTB_SERVICES.StatusDate)
                serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                EffectDate = bXTB_SERVICES.StatusDate
                If serr1 Then 'mod 7/17/17
                    SQLstmt = "select top 1 * from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID) + " and revdate > " + DParm(bXTB_SERVICES.StatusDate)
                    serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                    If serr1 Then Exit Sub 'mod 9/26/17 where all subsequent line items have been deleted
                End If
            End If

            'mod 12/19/16
            If WarBillDate <> gMaxDate And WarBillDate > FirstRevDate Then   'where posting date > warbilldate
                If Warranty Then
                    If FirstRevDate = .RevDate Then
                        WarrantyDate = .RevDate 'mod 12/9/16
                    Else
                        WarrantyDate = EffectDate
                    End If
                    'mod 7/22/17  now look to >=warrantydate
                    SQLstmt = "select * from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID) + " and revdate > =" + DParm(WarrantyDate)
                    serr5 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                    If serr5 Then Exit Sub 'mod 9/26/17  where all subsequent line items have been deleted
                End If
            End If

            NumMonths = GetMonths(EffectDate, .RevDate)
            Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)

            '6/14/2019 - Change for Canceling Contracts where RMRAmt has changed.
            RMR_Difference = 0                                                             '6/14/2019 - 6/26/2019
            'SQLstmt = "XSVCUPD_xtb_ServicesWrk_Get_RMRAmt" + SParm(bXSVCGRID.ContractID) + SParm(bXTB_SERVICES.ServItemID) + SParm(bpes.UserId) + DParm(bsmContractRev.RevDate) '6/14/2019 - 6/26/2019
            'xtbServWrkFlg = SqlFetch1(CSR_xtb_ServicesWrk, SQLstmt, bxtb_ServicesWrk)      '6/14/2019 - 6/26/2019
            If NumMonths = 0 Then    '6/14/2019
                SQLstmt = "XSVCUPD_xtb_ServicesWrk_Get_RMRAmt" + SParm(bXSVCGRID.ContractID) + SParm(bXTB_SERVICES.ServItemID) + SParm(bpes.UserId) + DParm(bsmContractRev.RevDate) '6/14/2019  '6/14/2019 - 6/26/2019
                xtbServWrkFlg = SqlFetch1(CSR_xtb_ServicesWrk, SQLstmt, bxtb_ServicesWrk)   '6/14/2019  '6/14/2019 - 6/26/2019
                If xtbServWrkFlg <> NOTFOUND Then                                           '6/14/2019
                    RMR_Difference = FPSub(RMRAmt, bxtb_ServicesWrk.MonthAmt, 2)            '6/14/2019 - 6/26/2019
                    Curamt = FPAdd(Curamt, RMR_Difference, 2)                               '6/14/2019 - 6/26/2019
                End If
            Else
                SQLstmt = "XSNUPDT_RMRAmt_Sum_SmContractRev" + SParm(bXSVCGRID.ContractID) + SParm(bXTB_SERVICES.ServItemID) + SParm(bpes.UserId) + DParm(bsmContractRev.RevDate) + FParm(RMRAmt) + DParm(bsmContract.StartDate) '6/14/2019 - 6/25/2019
                xtbServWrkFlg2 = SqlFetch1(c8, SQLstmt, RMR_Difference)         '6/14/2019
                If xtbServWrkFlg <> NOTFOUND Then                              '6/14/2019
                    Curamt = FPAdd(Curamt, RMR_Difference, 2)                  '6/14/2019
                End If
            End If

            If xtbServWrkFlg <> NOTFOUND And RMR_Difference <> 0 And FirstPeriodAmtAdj <> 0 Then                                '6/14/2019 - 6/26/2019
                'If the RevDate is not on the 1st Day, then the first record is prorated by day.                                '6/14/2019 - 6/26/2019
                'Need to adjust for that difference, since it was adjusted for the full month with the calculations above.      '6/14/2019 - 6/26/2019
                Curamt = FPAdd(Curamt, FirstPeriodAmtAdj, 2)                                                                    '6/14/2019 - 6/26/2019
            End If

            'ScottX Call SqlFree(c8)
            Curamt = Math.Max(Curamt, Balance)

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

            Balance -= Curamt

            Call DatePlusDays(.RevDate, 1, CurRevDate)  'so it will find next not current

            SQLstmt = "xAdd_smcontractRev" + SParm(bXSVCGRID.ContractID) + DParm(CurRevDate)
            serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
            Do While serr1 = 0
                Curamt = -RMRAmt
                '6/14/2019 - Change for Canceling Contracts where RMRAmt has changed.
                SQLstmt = "XSVCUPD_xtb_ServicesWrk_Get_RMRAmt" + SParm(bXSVCGRID.ContractID) + SParm(bXTB_SERVICES.ServItemID) + SParm(bpes.UserId) + DParm(bsmContractRev.RevDate)  '6/14/2019
                xtbServWrkFlg = SqlFetch1(CSR_xtb_ServicesWrk, SQLstmt, bxtb_ServicesWrk)   '6/14/2019
                If xtbServWrkFlg <> NOTFOUND Then                                           '6/14/2019
                    Curamt = FPAdd(Curamt, FPSub(RMRAmt, bxtb_ServicesWrk.MonthAmt, 2), 2)  '6/14/2019
                End If

                Curamt = Math.Max(Curamt, Balance)
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
        Call SqlFree(CSR_xtb_ServicesWrk)
        '  SQLstmt = "delete from smcontractrev where revamount = 0  and contractid = " + SParm(bXSVCGRID.ContractID)  'mod 4/23/17
        SQLstmt = "delete from smcontractrev where revamount = 0  and status = 'O' and contractid = " + SParm(bXSVCGRID.ContractID)  'mod 1/10/18

        Call sql(c9, SQLstmt)
    End Sub

    Private Sub doBillings(CommentEffectDate As Integer)
        Dim LastPostDate As Integer, FirstBillDate As Integer, DD As Short, NumMonths As Short, EffectDate As Integer
        Dim CommentStartDate As Integer = 0, CommentEndDate As Integer = 0
        '6/14/2019 - Change for Canceling Contracts where RMRAmt has changed.
        Dim NumMonthAdj As Short           '6/14/2019
        Dim Prior_RMRAmt_Flg As Short      '6/14/2019
        Dim RMRAmt_Diff As Double          '6/14/2019
        Dim CSR_xtb_ServicesWrk As Short   '6/14/2019
        Dim DayOfWeek As String            '6/14/2019 - 6/26/2019
        Dim NumMonthAdjRemainder As Short  '6/14/2019 - 6/26/2019
        Call SqlCursorEx(CSR_xtb_ServicesWrk, NOLEVEL, "CSR_xtb_ServicesWrk", "xtb_ServicesWrk", "")  '6/14/2019

        With bsmContractBill
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
                'mod 4/23/17  
                SQLstmt = "select max(billdate) from smcontractbill where contractid = " + SParm(bXSVCGRID.ContractID)
                serr6 = SqlFetch1(c6, SQLstmt, MaxBilldate)
                EffectDate = Math.Min(MaxBilldate, EffectDate)
            End If

            SQLstmt = "xAdd_MaxBillPostDate" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate)
            serr1 = SqlFetch1(c1, SQLstmt, LastPostDate)

            'special rule -- client wants on separate line the credit amount related to posting - goes to date 4
            'mod 7/23/17 - eliminate the two separate billings for Posting
            If LastPostDate <> NULLDATE Then

                CommentEndDate = gGetEndDate(LastPostDate, bXSVCGRID.ContractID)

                Call DatePlusMonthSetDay(LastPostDate, 1, 1, FirstBillDate)
                If Frequency = 1 Then
                    FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, LastPostDate, Frequency)
                Else
                    FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                End If

                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))

                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period

                '6/14/2019 - Change for Canceling Contracts where RMRAmt has changed.
                SQLstmt = "XSVCUPD_xtb_ServicesWrk_Orig_RMRAmt" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel) + SParm(bXTB_SERVICES.Linenbr) + SParm(bpes.UserId) 'SCOTT 6/14/2019
                Prior_RMRAmt_Flg = SqlFetch1(CSR_xtb_ServicesWrk, SQLstmt, bxtb_ServicesWrk)  '6/14/2019
                If Prior_RMRAmt_Flg <> NOTFOUND Then                                          '6/14/2019
                    RMRAmt_Diff = FPSub(RMRAmt, bxtb_ServicesWrk.MonthAmt, 2)                 '6/14/2019
                    NumMonthAdj = DateMinusDate(bxtb_ServicesWrk.user8, RMR_Current_StartDate) '6/14/2019

                    If RMRAmt_Diff <> 0 And FirstPeriodAmtAdj <> 0 Then                                '6/14/2019 - 6/26/2019
                        'If the RevDate is not on the 1st Day, then the first record is prorated by day.                                '6/14/2019 - 6/26/2019
                        'Need to adjust for that difference, since it was adjusted for the full month with the calculations above.      '6/14/2019 - 6/26/2019
                        'Adjusting for the first period.
                        Curamt = FPAdd(Curamt, FirstPeriodAmtAdj, 2)                                                                    '6/14/2019 - 6/26/2019
                    End If                                                                                                              '6/14/2019 - 6/26/2019

                    If NumMonthAdj > 0 Then                                                    '6/14/2019
                        DayOfWeek = Val(Mid(DateToStr(bsmContract.StartDate), 3, 2)).ToString     '6/14/2019 - 6/26/2019

                        'NumMonthAdj = FPDiv(NumMonthAdj, 30, 0)                                  '6/14/2019 - 6/26/2019
                        If Trim$(DayOfWeek) = "01" Or Trim$(DayOfWeek) = "1" Then                 '6/14/2019 - 6/26/2019
                            NumMonthAdj = FPDiv(NumMonthAdj, 30, 2) - 1                           '6/14/2019 - 6/26/2019
                        Else                                                                      '6/14/2019 - 6/26/2019
                            'Getting the Remainder to determine if we need to do additional months.
                            NumMonthAdjRemainder = NumMonthAdj Mod 30                              '6/14/2019 - 6/26/2019
                            If NumMonthAdjRemainder >= 1 And NumMonthAdjRemainder < 15 Then        '6/14/2019 - 6/26/2019
                                NumMonthAdj = FPDiv(NumMonthAdj, 30, 2)                            '6/14/2019 - 6/26/2019
                            Else                                                                   '6/14/2019 - 6/26/2019
                                NumMonthAdj = FPDiv(NumMonthAdj, 30, 2) - 1                        '6/14/2019 - 6/26/2019
                            End If                                                                 '6/14/2019 - 6/26/2019
                        End If                                                                     '6/14/2019 - 6/26/2019
                    End If
                    Curamt = Curamt + FPMult(RMRAmt_Diff, NumMonthAdj, 2)                      '6/14/2019
                Else                                                                           '6/14/2019
                    RMRAmt_Diff = 0                                                            '6/14/2019
                    NumMonthAdj = 0                                                            '6/14/2019
                End If
                Call SqlFree(CSR_xtb_ServicesWrk)
                Curamt = Math.Max(Curamt, Balance)
                Balance -= Curamt

                'insert a record
                .User3 = 0 : .User4 = 0
                Call DatePlusMonthSetDay(FirstBillDate, 0, 4, FirstBillDate)
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FirstBillDate) + DParm(FirstBillDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                'mod 11/11/16
                If bMassUp.InvPrintSuppress Then
                    .User5 = "1"
                Else
                    .User5 = "0"
                End If
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
                    .NoteID = gAddNote("Cancelled", bXTB_SERVICES.user7) 'mod 10/29/17
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    'mod 7/6/17 -for comment
                    'want the smaller of the existing comment start date or the current effect date.  Make sure to keep comment enddate
                    .Comment = gGetUpdateComment()  'mod 11/1/17
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    .NoteID = gAddNote("Cancelled", bXTB_SERVICES.user7) 'mod 10/29/17
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If

            Else  'no Posted amounts found
                FirstBillDate = EffectDate
                FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)
                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))
                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period
                CommentStartDate = CommentEffectDate   'needs to be reduced by 1 month?????????????


                Curamt = Math.Max(Curamt, Balance)
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
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate) + DParm(.BillDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                'mod 11/11/16
                If bMassUp.InvPrintSuppress Then
                    .User5 = "1"
                Else
                    .User5 = "0"
                End If
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
                    .NoteID = gAddNote("Cancelled", bXTB_SERVICES.user7) 'mod 10/29/17
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    .Comment = gGetUpdateComment()  'mod 11/1/17
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    .NoteID = gAddNote("Cancelled", bXTB_SERVICES.user7) 'mod 10/29/17
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If
            End If
            Dim dy As Short = 0
            SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate) + DParm(gMaxDate)  'mod 12/15/16
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
            Do While serr1 = 0
                dy = Mid(DateToStr(.BillDate), 3, 2)
                If (Not (Warranty) And WarBillDate = .BillDate) Or dy = 4 Then
                    'do nothing
                Else
                    'mod 5/15/17  wasn't limiting curamt to balance
                    Curamt = FPMult(-RMRAmt, Frequency, 2)
                    Curamt = Math.Max(Curamt, Balance)
                    Balance -= Curamt

                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    If Maint Then
                        .User3 = FPAdd(.User3, Curamt, 2)
                    Else
                        .User4 = FPAdd(.User4, Curamt, 2)
                    End If
                    If bMassUp.InvPrintSuppress Then
                        .User5 = "1"
                    Else
                        .User5 = "0"
                    End If
                    Call SUpdate1(CSR_SMContractBill, "smcontractbill", bsmContractBill)

                    If Balance = 0 Then Exit Do
                End If
                serr1 = SFetch1(CSR_SMContractBill, bsmContractBill)
            Loop
        End With

        'mod 12/31/16
        SQLstmt = "xSvcUpd_DeleteBlankLines" + SParm(bXSVCGRID.ContractID)
        Call sql(c9, SQLstmt)
    End Sub

    Private Sub doBillings_Reversals(CommentEffectDate As Integer)
        '*************************Special rules where there are open post dates between the first and last post dates due to reversals
        Dim FirstBillDate As Integer, DD As Short, NumMonths As Short, EffectDate As Integer
        Dim CommentStartDate As Integer = 0, CommentEndDate As Integer = 0
        Dim FirstPerAmtAvail As Short = 1, CreditAmt As Double = 0, TestDate As Integer = 0
        Dim Datstr As String = "", Dy As Short = 0



        With bsmContractBill
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
                'mod 4/23/17 
                SQLstmt = "select max(billdate) from smcontractbill where contractid = " + SParm(bXSVCGRID.ContractID)
                serr6 = SqlFetch1(c6, SQLstmt, MaxBilldate)
                EffectDate = Math.Min(MaxBilldate, EffectDate)
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
                    'mod  5/14/17, 6/4/17
                    Dim statusdate As Integer = 0
                    Datstr = DateToStr(bXTB_SERVICES.StatusDate) : Dy = Mid(Datstr, 3, 2)
                    Call DatePlusMonthSetDay(bXTB_SERVICES.StatusDate, IIf(IsArrears, 1, 0), Dy, statusdate)
                    '   NumMonths = GetMonths(bCreditInfo.FirstPostDate, bXTB_SERVICES.StatusDate)
                    NumMonths = GetMonths(bCreditInfo.FirstPostDate, statusdate)
                    If NumMonths = -1 Then    'where partial month from previous month included in current month
                        Curamt = FirstPeriodAmt + FPMult(-RMRAmt, (Frequency * bCreditInfo.NumMonths), 2)
                        FirstPerAmtAvail = 0
                    Else
                        Curamt = FPMult(-RMRAmt, (Frequency * bCreditInfo.NumMonths), 2)
                        FirstPerAmtAvail = 1
                    End If
                End If

                Curamt = Math.Max(Curamt, Balance) 'mod 5/13/17
                Balance -= Curamt

                CreditAmt = Curamt

                .User3 = 0 : .User4 = 0
                Call DatePlusMonthSetDay(bCreditInfo.LastPostDate, 0, 4, bCreditInfo.LastPostDate)
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(bCreditInfo.LastPostDate) + DParm(bCreditInfo.LastPostDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                'mod 11/11/16
                If bMassUp.InvPrintSuppress Then
                    .User5 = "1"
                Else
                    .User5 = "0"
                End If
                .Status = "O"
                If serr3 Then
                    .BillAmount = Curamt
                    .BillDate = bCreditInfo.LastPostDate
                    .ContractID = bXSVCGRID.ContractID
                    .CB_ID07 = 0
                    .LineNbr = 1
                    .User6 = "Delete"  'mod 12/31/16
                    If Frequency = 1 Then
                        Call DatePlusMonthSetDay(.BillDate, IIf(IsArrears, -1, 0), 31, CommentEndDate) 'mod 6/4/17
                    Else
                        CommentEndDate = GetFreqStartDate(bXSVCGRID.ContractID, .BillDate - 3, (Frequency - 1))
                        Call DatePlusMonthSetDay(CommentEndDate, 0, 31, CommentEndDate)
                    End If
                    'mod 6/4/17
                    ' .Comment = gGetComment(bCreditInfo.FirstPostDate, CommentEndDate) 
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
                    'mod 6/4/17
                    '   CommentStartDate = FirstBillDate  
                    Datstr = DateToStr(FirstBillDate) : Dy = Mid(Datstr, 3, 2)
                    Call DatePlusMonthSetDay(FirstBillDate, IIf(IsArrears, -1, 0), Dy, CommentStartDate)
                End If
            Else  'no Posted amounts found
                FirstBillDate = EffectDate
                FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)  'mod 12/14/16
                NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))  'mod 12/23/16
                Curamt = FirstPeriodAmt + FPMult(-RMRAmt, NumMonths, 2)  'current period
                CommentStartDate = CommentEffectDate 'mod 6/4/17
            End If

            Curamt = Math.Max(Curamt, Balance) 'mod 5/12/17
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
            If bMassUp.InvPrintSuppress Then
                .User5 = "1"
            Else
                .User5 = "0"
            End If
            .Status = "O"

            .BillAmount = FPAdd(.BillAmount, Curamt, 2)
            Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)

            SQLstmt = "xDelChg_Smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate)  'mod 12/15/16
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
            Do While serr1 = 0
                If Not (Warranty) And WarBillDate = .BillDate Then '????
                    'do nothing
                Else
                    'mod 5/15/17  wasn't limiting curamt to balance
                    Curamt = FPMult(-RMRAmt, Frequency, 2)
                    Curamt = Math.Max(Curamt, Balance)
                    Balance -= Curamt

                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    If Maint Then
                        .User3 = FPAdd(.User3, Curamt, 2)
                    Else
                        .User4 = FPAdd(.User4, Curamt, 2)
                    End If
                    If bMassUp.InvPrintSuppress Then
                        .User5 = "1"
                    Else
                        .User5 = "0"
                    End If
                    Call SUpdate1(CSR_SMContractBill, "smcontractbill", bsmContractBill)

                    If Balance = 0 Then Exit Do
                End If
                serr1 = SFetch1(CSR_SMContractBill, bsmContractBill)
            Loop
        End With

        'mod 12/31/16
        SQLstmt = "xSvcUpd_DeleteBlankLines" + SParm(bXSVCGRID.ContractID)
        Call sql(c9, SQLstmt)

    End Sub

End Module