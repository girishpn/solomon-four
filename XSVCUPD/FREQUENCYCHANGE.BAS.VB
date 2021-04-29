Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports VB=Microsoft.VisualBasic
Module FrequencyChange
 

    Dim NumMonths As Short, Frequency As String, Linenbr As Short, TotalAmt As Double, TotalPosted As Double
    Dim Curamt As Double, Balance As Double, Maint As Boolean, FirstPeriodAmt As Double
    Dim ActualEffectDate As Integer, ActualExpireDate As Integer, Warranty As Boolean
    Dim SalesSub, SalesAcct As String
    Dim BillStartDate As Integer = 0, PostStartDate As Integer = 0, PostEndDate As Integer = 0, NumBillStartMonths As Short = 0
    Dim bsmcontractbill1 As smContractBill = New smContractBill 'mod 2/21/17

    Sub gFrequencyChange()
        Dim DaysDiff As Short = 0, EndFreqDate As Integer = 0, Numrecs As Integer = 0, Start As Boolean = False, CommentPeriodEndDate As Integer = 0
        Dim AdjAmt As Double = 0
        Dim Pos As Short = 0, DatStr As String = "", FirstOrThirdBillDate As Integer = 0
        Dim bsmcontractbill2 As smContractBill = New smContractBill
        Dim CSR_EffDate As Short = 0
        'Dim PriorFrequency As String                  '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Dim PriorFrequencyNumMonthsInLine As Integer  '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Dim NewFrequencyNumMonthsInLine As Integer    '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Dim NeedToKeepExistingLine As Integer         '9/5/2019  Frequency is seperating the Lines.    '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Dim Prior_Year As Integer                     '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Dim Prior_Month As Integer                      '9/5/2019  Frequency is seperating the Lines. '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Dim Effect_Year As Integer                    '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Dim Effect_Month As Integer                     '9/5/2019  Frequency is seperating the Lines. '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.   
        'Dim FreqDayComment As String                  '9/5/2019  Frequency is seperating the Lines.    '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Dim FreqDayEndDate As Integer                 '9/5/2019  Frequency is seperating the Lines.    '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        Dim DD As Short
        'NeedToKeepExistingLine = False                '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  

        Call TranBeg(True)

        Warranty = False
        NumBillStartMonths = 0

        SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr9 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)

        'Need to set MassUp.EffectDate to Contract Start Date since the billing Frequency should always be changed from Contract Start Date. '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
        bMassUp.EffectDate = bsmContract.StartDate

        Call sql(CSR_xSvcUpdHist, "select top 1 * from  xSvcUpdHist") 'compile cursor   don't know what to do with history
        With bXSVCUPDHIST
            .Contractid = bXSVCGRID.ContractID
            .UpdateType = "BF"
            .OrigBillFreq = bsmContract.BillingFreq
            .NewBillFreq = bMassUp.Frequency

            .lupd_datetime = Curdate
            .lupd_prog = CurProg
            .lupd_user = CurUser
            Call SInsert1(CSR_xSvcUpdHist, "XSVCUPDHIST", bXSVCUPDHIST)
        End With

        'PriorFrequency = bsmContract.BillingFreq.Trim   '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  

        With bsmContract
            .BillingFreq = bMassUp.Frequency
            .Lupd_dateTime = Curdate
            .Lupd_Prog = CurProg
            .Lupd_User = CurUser
            .Lupd_dateTime = Curdate
            .Lupd_Prog = CurProg
            .Lupd_User = CurUser
            .NoteId = GAddContractFrequencyNote("Frequency changed to", bMassUp.Frequency, bMassUp.EffectDate)
            Call SUpdate1(CSR_SMContract, "smContract", bsmContract)
            Call SUpdate1(CSR_SMContract, "SMCONTRACT", bsmContract)
        End With

        'Mod 8/19/2019 - Solomon Cloud Solutions - Run proc with FastReadOnly Cursor
        Call SqlCursorEx(CSR_EffDate, NOLEVEL + SqlFastReadOnly, "CSR_EffDate", "", "")
        SQLstmt = "xOthChanges_MatchEffectDate" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate)
        serr1 = SqlFetch1(CSR_EffDate, SQLstmt, bsmcontractbill1)
        Call SqlFree(CSR_EffDate)

        If serr1 = 0 Then
            Pos = InStr(bsmcontractbill1.Comment, "-")
            DatStr = Left(bsmcontractbill1.Comment, Pos - 1)
            Call StrToDate(DatStr, PostStartDate)
            DatStr = Mid(bsmcontractbill1.Comment, Pos + 1).Trim
            Call StrToDate(DatStr, PostEndDate)

            DD = Mid(DateToStr(bMassUp.EffectDate), 3, 2)                            '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            If DD <> 1 Then                                                          '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
                Call DatePlusMonthSetDay(bMassUp.EffectDate, 1, 1, BillStartDate)    '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            Else                                                                     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
                Call DatePlusMonthSetDay(bMassUp.EffectDate, 0, 1, BillStartDate)    '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            End If                                                                   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.



            '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. '9/5/2019  Frequency is seperating the Lines.
            'If bsmcontractbill1.Status = "P" Then             '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '    'Do not need to do anything about this line.                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '    NeedToKeepExistingLine = False                                                               '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            'Else                                                                                             '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '    Select Case bsmContract.BillingFreq.Trim      '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Case "M"                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '            NewFrequencyNumMonthsInLine = 1       '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Case "Q"                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '            NewFrequencyNumMonthsInLine = 3       '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Case "S"                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '            NewFrequencyNumMonthsInLine = 6       '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Case "A"                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '            NewFrequencyNumMonthsInLine = 12      '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '    End Select                                                                                   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '    Select Case PriorFrequency.Trim               '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Case "M"                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '            PriorFrequencyNumMonthsInLine = 1     '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Case "Q"                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '            PriorFrequencyNumMonthsInLine = 3     '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Case "S"                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '            PriorFrequencyNumMonthsInLine = 6     '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Case "A"                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '            PriorFrequencyNumMonthsInLine = 12    '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '    End Select                                    '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '    If PriorFrequencyNumMonthsInLine > NewFrequencyNumMonthsInLine And DateCmp(bsmcontractbill1.BillDate, bMassUp.EffectDate) <> 0 Then  '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        'Date - Look at Year and then Month to determine if we need to keep the existing line for a percentage of the amount.  '9/5/2019  Frequency is seperating the Lines.            '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.
            '        Prior_Year = Microsoft.VisualBasic.DateAndTime.Year(DateToStrSep(PostStartDate))              '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.       
            '        Prior_Month = Microsoft.VisualBasic.DateAndTime.Month(DateToStrSep(PostStartDate))            '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '        Effect_Year = Microsoft.VisualBasic.DateAndTime.Year(DateToStrSep(bMassUp.EffectDate))        '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '        Effect_Month = Microsoft.VisualBasic.DateAndTime.Month(DateToStrSep(bMassUp.EffectDate))      '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '        If Prior_Year < Effect_Year Or (Prior_Year = Effect_Year And Prior_Month < Effect_Month) Then '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '            NeedToKeepExistingLine = True                                                             '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '        Else                                                                                          '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '            'Do Nothing                                                                               '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '            NeedToKeepExistingLine = False                                                            '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '        End If                                                                                        '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '    Else                                                                                              '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '        'Do Nothing                                                                                   '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '        NeedToKeepExistingLine = False                                                                '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '    End If                                                                                            '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            'End If                                                                                                '9/5/2019  Frequency is seperating the Lines.        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        Else
            Call Status(SaveGoodArgVals, False, "For contract " + SParm(bXSVCGRID.ContractID) + " No bill found which includes effect date", LOG_AND_DISP)
            Call TranAbort()
            Exit Sub
        End If

        'If NeedToKeepExistingLine = True Then                                                 '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        '    ' Stored Proc will keep existing BillDate (updating existing Amounts to 0, and filling in Comments) and the follow the existing logic to remove the other Billing Frequency after Mass Effective Date minus this BillDate.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        '    Call DatePlusDays(bMassUp.EffectDate, -1, FreqDayEndDate)                         '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        '    FreqDayComment = gGetComment(PostStartDate, FreqDayEndDate)                       '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        '    SQLstmt = "xOthChanges_DeleteBillings_FreqChg" + SParm(bXSVCGRID.ContractID) + DParm(bsmcontractbill1.BillDate) + SParm(FreqDayComment)   '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        'Else                                                                                  '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        SQLstmt = "xOthChanges_DeleteBillings" + SParm(bXSVCGRID.ContractID) + DParm(bsmcontractbill1.BillDate)
        'End If                                                                                '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
        Call sql(c9, SQLstmt)

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

        EndFreqDate = BillStartDate

        Call sql(CSR_SMContractBill, "select top 1 * from smcontractbill") 'compile cursor
        With bsmContractBill
            Do Until EndFreqDate >= bsmContract.ExpireDate
                .User6 = ""
                .User3 = 0
                .User4 = 0
                .ContractID = bXSVCGRID.ContractID
                .Crtd_Prog = CurProg
                .Crtd_DateTime = Curdate
                .Crtd_User = CurUser
                .Lupd_DateTime = Curdate
                .Lupd_Prog = CurProg
                .Lupd_User = CurUser
                .BillAmount = 0
                .BillDate = EndFreqDate
                If .BillDate = bsmcontractbill1.BillDate And bsmcontractbill1.Status = "P" Then .BillDate += 2
                Call DatePlusMonthSetDay(.BillDate, Frequency, 1, EndFreqDate)    'increment for next billdate
                Numrecs = 0
                CommentPeriodEndDate = Math.Min(EndFreqDate - 1, bsmContract.ExpireDate)
                If Not (Start) Then
                    FirstOrThirdBillDate = .BillDate 'For bill adjustment -- finding the 1st record in this loop
                    .Comment = gGetComment(PostStartDate, CommentPeriodEndDate)
                    Start = True
                Else
                    .Comment = gGetComment(.BillDate, CommentPeriodEndDate)
                End If
                .CB_ID07 = 0
                .LineNbr = 1
                .Status = "O"
                Call SInsert1(CSR_SMContractBill, "SMCONTRACTBILL", bsmContractBill)
            Loop
        End With
        Call TranEnd()
        Call TranBeg(True)
        'now populate   billings based upon xtb_services     
        SQLstmt = "XOTHCHG_SERVices" + SParm(bXSVCGRID.ContractID)
        serr6 = SqlFetch1(c6, SQLstmt, bXTB_SERVICES)
        bMassUp.WarrantyEndDate = 0
        WarBillDate = gMaxDate
        Do While serr6 = 0
            With bXTB_SERVICES
                If .MonthAmt > 0 Then

                    If bMassUp.EffectDate = 0 Then bMassUp.EffectDate = .StatusDate
                    'mod 2/15/17  - where the service is created by Tribridge from projects it always begins 1 day later than status date

                    bMassUp.RMRAmt = .MonthAmt

                    bMassUp.ServItemSel = .ServItemID

                    bMassUp.WarrantyEndDate = 0
                    SQLstmt = "XothChgs_GetWarEffectDate" + SParm(bXSVCGRID.ContractID) + SParm(bMassUp.ServItemSel)
                    serr5 = SqlFetch1(c5, SQLstmt, bMassUp.WarrantyEndDate)
                    'mod 2/15/17 mod 4/3/17 Tribeidge will fix
                    'If bMassUp.WarrantyEndDate Then
                    '    If .crtd_prog.Trim = "XT250" Then bMassUp.WarrantyEndDate += 1
                    'End If

                    If .GroupCode.Trim = "MONITORING" Then
                        Maint = False
                    Else
                        Maint = True
                    End If

                    'ProcessServices(NeedToKeepExistingLine, PostStartDate, bsmcontractbill1.BillDate)  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
                    ProcessServices()
                    'once a warranty record found -- then for next record --get the warbilldate which should stay through entire process
                    If Warranty Then
                        gGetWarBilldate(bXSVCGRID.ContractID) 'mod 12/11/16 get warbilldate
                    End If
                End If
                serr6 = SFetch1(c6, bXTB_SERVICES)
            End With
        Loop

        Call TranEnd()
        Call TranBeg(True)
        '9/12/2019 - Going to recalculate billing with Stored procedure since all lines are open. Currently an issue with Warranty Date causing problems.
        SQLstmt = "xtb_CreateBillingSchedulesFrequency" + SParm(bXSVCGRID.ContractID) + SParm(CurUser)  'mod 12/12/16
        Call sql(c4, SQLstmt)


        '***All xtb_services records have been processed -- now get the adjustment for Posting (if any)
        If bsmcontractbill1.BillDate And bsmcontractbill1.Status = "P" Then
            'switch dates
            With bsmContractBill
                'find 1st record and update it to the 4th.  Then use the this record for the C/M
                SQLstmt = "xOthChanges_smcontractbill" + SParm(bXSVCGRID.ContractID) + DParm(FirstOrThirdBillDate) + DParm(gMaxDate)
                serr5 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmcontractbill2)
                'now change the billdate on that record to the 4th 
                Call sql(CSR_SMContractBill, "select top 1 * from smcontractBill") 'compile cursor
                bsmContractBill.CopyClass(bsmcontractbill2)
                Call DatePlusMonthSetDay(bsmcontractbill2.BillDate, 0, 5, bsmContractBill.BillDate)
                Call SInsert1(CSR_SMContractBill, "smcontractBill", bsmContractBill)

                'Now do the C/M for that first record
                SQLstmt = "xOthChanges_smcontractbill" + SParm(bXSVCGRID.ContractID) + DParm(FirstOrThirdBillDate) + DParm(gMaxDate)
                serr5 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
                .User3 = 0 : .User4 = 0   'what to do about these is it maint or otherwise?????
                .ContractID = bXSVCGRID.ContractID
                .BillDate = BillStartDate
                If BillStartDate = PostStartDate Then .BillDate += 2
                .BillAmount = bsmcontractbill1.BillAmount
                .User3 = bsmcontractbill1.User3
                .User4 = bsmcontractbill1.User4
                'mod 2/21/17
                SQLstmt = "xOthChanges_ConversionRounding" + SParm(bXSVCGRID.ContractID) + DParm(bsmcontractbill1.BillDate)  'mod 2/27/17 was bcomment.billdate
                serr4 = SqlFetch1(c4, SQLstmt, bsmcontractbill2)
                If serr4 = 0 Then
                    .BillAmount = FPAdd(.BillAmount, bsmcontractbill2.BillAmount, 2)
                    .User3 = FPAdd(.User3, bsmcontractbill2.User3, 2)
                    .User4 = FPAdd(.User4, bsmcontractbill2.User4, 2)
                End If
                .BillAmount = -.BillAmount
                .User3 = -.User3
                .User4 = -.User4
                .Crtd_User = CurUser
                .Crtd_DateTime = Curdate
                .Crtd_Prog = CurProg
                .Lupd_User = CurUser
                .Lupd_DateTime = Curdate
                .Lupd_Prog = CurProg
                .CB_ID07 = 0
                .Status = "O"
                .User6 = "C/M"
                .LineNbr = 1
                .Comment = bsmcontractbill1.Comment
                Call SUpdate1(CSR_SMContractBill, "SMCONTRACTBILL", bsmContractBill)
            End With
        End If


        Call TranEnd()

    End Sub

    Sub ProcessServices()
        'Sub ProcessServices(ByRef NeedToKeepExistingLine As Boolean, ByRef FreqPostStartDate As Integer, ByRef OrigFreqBillDate As Integer) '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
        Dim Effectdate As Date, EndDate As Date, DayNum As Short, NumDays As Short
        Dim NextPeriodAmts As Double, LastPeriodAmt As Double, DailyAmt As Double

        If bMassUp.WarrantyEndDate > 0 Then
            Warranty = True
            ActualEffectDate = bMassUp.WarrantyEndDate
        Else
            Warranty = False
            ActualEffectDate = bXTB_SERVICES.StatusDate
        End If
        ActualEffectDate = Math.Max(ActualEffectDate, PostStartDate) 'what is included in the posting period.  If servitem starts later - the only include from that date

        '1)Actual effectdate set to servicedate
        '2)Actual effectdate set to > of statusdate or PostStartDate from comment ('01/01/2017-12/31/2017')
        'so if postdate =01/01/2017 and statusdae = 04/01/2017 then actual effectdate = 04/01/2017
        Effectdate = DateToStrSep(ActualEffectDate)

        EndDate = DateToStrSep(bsmContract.ExpireDate)
        NumMonths = GetMonths(ActualEffectDate, bsmContract.ExpireDate) + 1   'Total Duration
        'Calculate 1st month amt
        DayNum = Math.Min(Effectdate.Day, 30)
        NumDays = 30 - DayNum + 1
        DailyAmt = FPDiv(bMassUp.RMRAmt, 30, 6)
        FirstPeriodAmt = FPMult(NumDays, DailyAmt, 2)
        TotalAmt = FirstPeriodAmt

        'Balance of months excluding 1st and last month
        NumMonths = NumMonths - 2
        NextPeriodAmts = FPMult(NumMonths, bMassUp.RMRAmt, 2)
        TotalAmt += NextPeriodAmts


        'Last month
        DayNum = Math.Min(EndDate.Day, 30)
        If EndDate.Month = 2 Then
            Dim testdate As Integer
            Call DatePlusMonthSetDay(bsmContract.ExpireDate, 0, 31, testdate)
            If testdate = bsmContract.ExpireDate Then DayNum = 30
        End If
        LastPeriodAmt = FPMult(DayNum, DailyAmt, 2)
        TotalAmt += LastPeriodAmt

        '1st month reflected on the 4th - so if billstartdate = 6/2017 and actual effectdate = 04/2017 then 2 xtra month are added
        NumBillStartMonths = Math.Max(0, GetMonths(ActualEffectDate, BillStartDate)) 'mod 2/19/17

        With bsmContract
            .TotalAmt = FPAdd(.TotalAmt, TotalAmt, 2)
            .OrigContractAmt = .TotalAmt
            .NewContractAmt = .TotalAmt
            SQLstmt = "XSvcUPD_MonthlyRMRAmt" + SParm(bXSVCGRID.ContractID)
            serr3 = SqlFetch1(c3, SQLstmt, MonthlyRMRAmt)
            .User3 = MonthlyRMRAmt
        End With

        doBillings()
        'doBillings(NeedToKeepExistingLine, FreqPostStartDate, OrigFreqBillDate)  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 

    End Sub

    Private Sub doBillings()
        'Private Sub doBillings(ByRef NeedToKeepExistingLine As Boolean, ByRef FreqPostStartDate As Integer, ByRef OrigFreqBillDate As Integer)   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
        Dim FirstBillDate As Integer, DD As Short, NumMonths As Short, EffectDate As Integer
        Dim WarrantyDate As Integer, Numrecs As Integer, CommentPeriodEnddate As Integer = 0, SumBillPostings As Double = 0
        Dim XtraMonths As Short = 0
        'Dim DayNum As Short, NumDays As Short, FreqNumMonths As Short            '9/5/2019  Frequency is seperating the Lines.                            '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
        'Dim PriorFreqAmt As Double, NextFreqAmt As Double, LastFreqAmt As Double, TotalPriorFreq As Double '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
        'Dim DailyAmt As Double  '9/5/2019  Frequency is seperating the Lines.                                                                             '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
        'Dim FreqMaint As String '9/5/2019  Frequency is seperating the Lines.                                                                             '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
        'Dim FreqPos As Short = 0, FreqDatStr As String = ""  '9/5/2019  Frequency is seperating the Lines.                                                '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
        'Dim FreqEndDateComment As Integer                    '9/5/2019  Frequency is seperating the Lines.                                                '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 

        'mod 12/14/16 major modification re: getting freq end date

        With bsmContractBill
            .Lupd_User = CurUser
            .Lupd_DateTime = Curdate
            .Lupd_Prog = CurProg

            EffectDate = BillStartDate 'Billstartdate = effectdate on the 1st of the month
            EffectDate = Math.Max(BillStartDate, bXTB_SERVICES.StatusDate)
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

            'this would only apply if warrantyenddate <> 1
            DD = Mid(DateToStr(EffectDate), 3, 2)

            If DD <> 1 Then
                Call DatePlusMonthSetDay(EffectDate, 1, 1, EffectDate)
            End If

            Call StrToDate(DateTime.Parse(DateToStrSep(EffectDate)).AddMonths(Frequency), FreqStartDate)

            NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0)) + NumBillStartMonths  'numbillstartmonths computed in Processservices
            Curamt = FirstPeriodAmt + FPMult(bMassUp.RMRAmt, NumMonths, 2)  'current period

            If bMassUp.RMRAmt > 0 Then
                Curamt = Math.Min(Curamt, Balance)
            End If

            'PriorFreqAmt = 0                                    '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            'TotalPriorFreq = 0                                  '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            'If NeedToKeepExistingLine = True Then               '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    'Calculate 1st month amt                                                                        '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
            '    DayNum = Math.Min(Microsoft.VisualBasic.DateAndTime.Day(DateToStrSep(FreqPostStartDate)), 30)  '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    NumDays = 30 - DayNum + 1                       '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.              
            '    DailyAmt = FPDiv(bMassUp.RMRAmt, 30, 6)         '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    PriorFreqAmt = FPMult(NumDays, DailyAmt, 2)     '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    TotalPriorFreq += PriorFreqAmt '9/5/2019  Frequency is seperating the Lines.                    '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 

            '    'Total Duration                                                                                 '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    FreqNumMonths = GetMonths(FreqPostStartDate, EffectDate) + 1   '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    FreqNumMonths = FreqNumMonths - 2                              '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    NextFreqAmt = FPMult(FreqNumMonths, bMassUp.RMRAmt, 2)         '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    TotalPriorFreq += NextFreqAmt                 '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 

            '    'Last month                                                                                     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    DayNum = Math.Min(Microsoft.VisualBasic.DateAndTime.Day(DateToStrSep(EffectDate)), 30) - 1 '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    LastFreqAmt = FPMult(DayNum, DailyAmt, 2)                                                  '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    TotalPriorFreq += LastFreqAmt                                                              '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 

            'End If                                  '9/5/2019  Frequency is seperating the Lines.          '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.   


            FirstBillDate = EffectDate  'really don't need this field for frequency as always the effectdate
            Balance -= Curamt

            bsmContractBill.BillDate = NULLDATE
            SQLstmt = "xOthChanges_smcontractbill" + SParm(bXSVCGRID.ContractID) + DParm(FirstBillDate) + DParm(WarBillDate)
            'select * from smcontractBill where contractid = @contractid and status <> 'P' and Billdate >= @billdate order by contractid, billdate
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

            If Warranty And bXTB_SERVICES.StatusDate >= FirstBillDate Then
                If FirstBillDate = bsmContractBill.BillDate Then  'record akready exists
                    WarrantyDate = .BillDate + 1  '2nd
                ElseIf bsmcontractbill1.BillDate = FirstBillDate Then  '&&&&
                    WarrantyDate = FirstBillDate + 1  '2nd
                Else
                    WarrantyDate = FirstBillDate
                End If
                'should not have an existing record for the warranty.  However
                .User3 = 0 : .User4 = 0  'null out, in case serr5 =not found
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(WarrantyDate) + DParm(WarrantyDate)
                '  SQLstmt = "xOthChanges_smcontractbill" + SParm(bXSVCGRID.ContractID) + DParm(WarrantyDate) + DParm(gMaxDate)
                serr5 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If

                'mod 11/11/16
                'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice print suppress as 0
                'If bMassUp.InvPrintSuppress Then
                '.User5 = "1"
                'Else
                .User5 = "0"
                'End If
                If serr5 Then
                    .BillDate = WarrantyDate
                    .BillAmount = Curamt
                    .ContractID = bXSVCGRID.ContractID
                    .CB_ID07 = 0
                    .LineNbr = 1
                    .Status = "O" 'mod 12/16/16
                    CommentPeriodEnddate = Math.Min(FreqStartDate - 1, bsmContract.ExpireDate)
                    .Comment = gGetComment(ActualEffectDate, CommentPeriodEnddate) 'mod 11/17/16 was billdate vs effectdate   'could be a problem when posting
                    .Crtd_DateTime = Curdate
                    .Crtd_User = CurUser
                    .Crtd_Prog = CurProg
                    .User6 = "Add"  'mod 12/31/16
                    'If NeedToKeepExistingLine = True And TotalPriorFreq <> 0 Then   '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.   
                    '    .BillAmount = FPSub(.BillAmount, TotalPriorFreq, 2)         '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    If Maint Then                                               '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '        .User3 = FPSub(.User3, TotalPriorFreq, 2)               '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    Else                                                        '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '        .User4 = FPSub(.User4, TotalPriorFreq, 2)               '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    End If                                                      '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    FreqPos = InStr(.Comment, "-")                              '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    FreqDatStr = Mid(.Comment, FreqPos + 1).Trim                '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    Call StrToDate(FreqDatStr, FreqEndDateComment)              '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    .Comment = gGetComment(BillStartDate, FreqEndDateComment)   '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 

                    'End If                                                          '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    'If NeedToKeepExistingLine = True And TotalPriorFreq <> 0 Then   '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.   
                    '    .BillAmount = FPSub(.BillAmount, TotalPriorFreq, 2)         '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    If Maint Then                                               '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '        .User3 = FPSub(.User3, TotalPriorFreq, 2)               '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    Else                                                        '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '        .User4 = FPSub(.User4, TotalPriorFreq, 2)               '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    End If                                                      '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    FreqPos = InStr(.Comment, "-")                              '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    FreqDatStr = Mid(.Comment, FreqPos + 1).Trim                '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    Call StrToDate(FreqDatStr, FreqEndDateComment)              '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    .Comment = gGetComment(BillStartDate, FreqEndDateComment)   '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    'End If                                                          '9/5/2019  Frequency is seperating the Lines.   '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If
            Else   'not warranty
                .User3 = 0 : .User4 = 0 : .User6 = ""
                SQLstmt = "xOthChanges_smcontractbill" + SParm(bXSVCGRID.ContractID) + DParm(FirstBillDate) + DParm(WarBillDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                'mod 11/11/16
                'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice print suppress as 0
                'If bMassUp.InvPrintSuppress Then
                '.User5 = "1"
                'Else
                .User5 = "0"
                'End If
                .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                If WarBillDate = .BillDate Then  'if war billdate is on the 1st -- then make this the 3rd
                    Numrecs = 0
                    SQLstmt = "xAdd_InsertDateTest" + SParm(bXSVCGRID.ContractID) + DParm(WarBillDate + 2)  'mod 12/12/16
                    Call sql(c4, SQLstmt)
                    serr4 = SGroupFetch1(c4, Numrecs)
                    If Numrecs = 0 Then
                        .BillDate = WarBillDate + 2
                        serr3 = NOTFOUND  'so that record will be inserted below
                    Else
                        'mod 12/13/16
                        SQLstmt = "xsmcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(WarBillDate + 2) + DParm(WarBillDate)
                        serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
                        .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    End If
                End If

                If serr3 Then
                    .BillAmount = Curamt
                    .ContractID = bXSVCGRID.ContractID
                    .CB_ID07 = 0
                    .LineNbr = 1
                    .Status = "O" 'mod 12/16/16
                    CommentPeriodEnddate = Math.Min(FreqStartDate - 1, bsmContract.ExpireDate)
                    .Comment = gGetComment(ActualEffectDate, CommentPeriodEnddate) 'mod 11/17/16 was billdate vs effectdate
                    .Crtd_DateTime = Curdate
                    .Crtd_User = CurUser
                    .Crtd_Prog = CurProg

                    'If NeedToKeepExistingLine = True And TotalPriorFreq <> 0 Then   '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    .BillAmount = FPSub(.BillAmount, TotalPriorFreq, 2)         '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    If Maint Then                                               '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '        .User3 = FPSub(.User3, TotalPriorFreq, 2)               '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    Else                                                        '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '        .User4 = FPSub(.User4, TotalPriorFreq, 2)               '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    End If                                                      '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    FreqPos = InStr(.Comment, "-")                              '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    FreqDatStr = Mid(.Comment, FreqPos + 1).Trim                '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    Call StrToDate(FreqDatStr, FreqEndDateComment)              '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    .Comment = gGetComment(BillStartDate, FreqEndDateComment)      '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    'End If                                                          '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date.  
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    'If NeedToKeepExistingLine = True And TotalPriorFreq <> 0 Then   '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    .BillAmount = FPSub(.BillAmount, TotalPriorFreq, 2)         '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    If Maint Then                                               '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '        .User3 = FPSub(.User3, TotalPriorFreq, 2)               '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    Else                                                        '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '        .User4 = FPSub(.User4, TotalPriorFreq, 2)               '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    End If                                                      '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    FreqPos = InStr(.Comment, "-")                              '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    FreqDatStr = Mid(.Comment, FreqPos + 1).Trim                '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    Call StrToDate(FreqDatStr, FreqEndDateComment)              '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    '    .Comment = gGetComment(BillStartDate, FreqEndDateComment)      '9/5/2019  Frequency is seperating the Lines.  '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    'End If                                                          '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If

            End If
            'If NeedToKeepExistingLine = True And TotalPriorFreq <> 0 Then   '9/5/2019  Frequency is seperating the Lines.      '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    If Maint = True Then     '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '        FreqMaint = "USER3"  '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    Else                     '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '        FreqMaint = "USER4"  '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    End If                   '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    SQLstmt = "xOthChanges_UpdateBillings_FreqChg" + SParm(bXSVCGRID.ContractID) + DParm(OrigFreqBillDate) + FParm(TotalPriorFreq) + SParm(FreqMaint)  '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            '    Call sql(c5, SQLstmt)    '9/5/2019  Frequency is seperating the Lines.     '9/12/2019 - All Lines have to be open and Changing Frequency from Contract Start Date. 
            'End If


            SQLstmt = "xAdd_smcontractBill" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate) + DParm(WarBillDate)
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
            .User6 = ""
            Do While serr1 = 0
                Curamt = FPMult(bMassUp.RMRAmt, Frequency, 2)
                Curamt = Math.Min(Curamt, Balance)
                .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                If Maint Then
                    .User3 = FPAdd(.User3, Curamt, 2)
                Else
                    .User4 = FPAdd(.User4, Curamt, 2)
                End If
                'Mod 10/2/2019 - Solomon Cloud Solutions - Always keep invoice print suppress as 0
                'If bMassUp.InvPrintSuppress Then
                '.User5 = "1"
                'Else
                .User5 = "0"
                'End If
                Call SUpdate1(CSR_SMContractBill, "SMCONTRACTBILL", bsmContractBill)
                Balance -= Curamt
                If Balance = 0 Then Exit Do
                serr1 = SFetch1(CSR_SMContractBill, bsmContractBill)
            Loop
        End With
    End Sub

End Module