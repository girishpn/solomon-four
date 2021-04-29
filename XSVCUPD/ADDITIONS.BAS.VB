Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports VB=Microsoft.VisualBasic
Module Additions

    Dim NumMonths As Short, Frequency As String, Linenbr As Short, TotalAmt As Double
    Dim Curamt As Double, Balance As Double, Maint As Boolean, FirstPeriodAmt As Double, RegOrWarEffectDate As Integer, Warranty As Boolean
    Dim IsArrears As Boolean
    Public CSR_SMSvcEquipment, CSR_SMConEquipment, CSR_XTB_EquipReview, CSR_XTB_InstallBase, CSR_SMEquipSetup As Short  'mod 4/8/17
    Class cust
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=60) _
        > _
        Public Property Name() As String

            Get
                Return Me.GetPropertyValue("Name")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Name", setval)
            End Set

        End Property
    End Class
    Dim bCust As cust = New cust
    'mod 4/13/18
    Class Equip
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
        > _
        Public Property id() As String

            Get
                Return Me.GetPropertyValue("id")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("id", setval)
            End Set

        End Property

    End Class
    Dim bEquip As Equip = New Equip
    'mod 11/13/18
    Class SvcPMCode
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
        > _
        Public Property id() As String

            Get
                Return Me.GetPropertyValue("id")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("id", setval)
            End Set

        End Property

    End Class
    Dim bSvcPMCode As SvcPMCode = New SvcPMCode

    Sub gProcessAdditions(Multi As Boolean)
        Dim Effectdate As Date, EndDate As Date, DayNum As Short, NumDays As Short
        Dim NextPeriodAmts As Double, LastPeriodAmt As Double, DailyAmt As Double
        Dim PostWarranty As Integer = 0, Numrecs As Integer = 0
        Dim EquipType As String() = {"Access", "Audio", "Fire", "Intrusion", "Video", "Integrated", "Embedded", "Other", "Physical"} 'mod 4/8/17
        Dim Datstr As String, DY As Short = 0, ActualEffectDate As Integer = 0
        Dim NumOpenMonths As Integer = 0 'mod 6/12/17
        Dim PMCode As String, PMFlag As String, SysType As String = "", DoUpdate As Boolean = False 'mod 11/1/17

        Dim xWarrItem_CSR As Short                      '4/10/2020 Warranty Items added to Table.
        Dim xWarr_Flg As Short                          '4/10/2020 Warranty Items added to Table.
        Dim xWarrtyItem As Boolean                      '4/10/2020 Warranty Items added to Table.

        If Not Multi Then Call TranBeg(True)

        'gGetWarBilldate(bXSVCGRID.ContractID) 'mod 12/11/16 get warbilldate

        'mod 10/19/16, mod 9/15/17 re:bmassup.duration
        '   If bMassUp.WarrantyEndDate > 0 And (bMassUp.WarrantyEndDate + 1 > bMassUp.EffectDate) Then
        If bMassUp.WarrantyEndDate > 0 And Val(bMassUp.Duration.Trim) > 0 And (bMassUp.WarrantyEndDate + 1 > bMassUp.EffectDate) Then
            PostWarranty = bMassUp.WarrantyEndDate + 1
            Warranty = True
            RegOrWarEffectDate = PostWarranty
        Else
            Warranty = False
            RegOrWarEffectDate = bMassUp.EffectDate
        End If

        ActualEffectDate = RegOrWarEffectDate 'mod 6/16/17

        Call SqlCursorEx(CSR_SMEquipSetup, NOLEVEL, "CSR_SMEquipSetup", "SMEquipSetup", "SMEquipSetup")
        Call sql(CSR_SMConEquipment, "select top 1 * from SMConEquipment") 'compile cursor
        Call sql(CSR_SMSvcEquipment, "select top 1 * from SMSvcEquipment") 'compile cursor
        Call sql(CSR_XTB_InstallBase, "select top 1 * from XTB_InstallBase") 'compile cursor
        Call sql(CSR_XTB_EquipReview, "select top 1  *from XTB_EquipReview") 'compile cursor



        Call sql(CSR_xSvcUpdHist, "select top 1 * from  xSvcUpdHist") 'compile cursor

        SQLstmt = "smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr1 = SqlFetch1(CSR_SMContract, SQLstmt, bsmContract)

        gGetWarBilldate(bXSVCGRID.ContractID) 'mod 7/17/17 get warbilldate moved from above to obtain smcontract.billingfreq

        'Populate XTB_SERVICES
        Call sql(CSR_XTB_Services, "Select top 1 * from xtb_services") 'compile cursor
        With bXTB_SERVICES
            SQLstmt = "select max(linenbr) from xtb_services where contractid = " + SParm(bXSVCGRID.ContractID)
            serr5 = SqlFetch1(c5, SQLstmt, Linenbr)
            .ContractID = bXSVCGRID.ContractID
            .ServItemID = bMassUp.ServItemSel
            .MonthAmt = bMassUp.RMRAmt
            SQLstmt = "xserviceitems_all" + SParm(.ServItemID)
            serr5 = SqlFetch1(c5, SQLstmt, bxServiceitems)
            .GroupCode = bxServiceitems.GroupCode
            If .GroupCode.Trim = "MONITORING" Then
                Maint = False
            Else
                Maint = True
            End If
            .Descr = bxServiceitems.Descr
            .Status = "A"
            '    .StatusDate = bMassUp.EffectDate  'MOD 11/11/16
            .StatusDate = RegOrWarEffectDate  'MOD 11/19/16
            .user8 = .StatusDate 'mod 10/29/17
            .StatusReason = "ADD Part -" + bpes.UserId.Trim + " " + DateToStrSep(Curdate)
            .user5 = "Addition"
            Linenbr += 32
            .Linenbr = Linenbr
            .crtd_user = CurUser
            .crtd_datetime = Curdate
            .crtd_prog = CurProg
            .lupd_datetime = Curdate
            .lupd_prog = CurProg
            .lupd_user = CurUser
            .user7 = NULLDATE 'end date
            Call SInsert1(CSR_XTB_Services, "XTB_Services", bXTB_SERVICES)
            With bXSVCUPDHIST
                .Contractid = bXSVCGRID.ContractID
                .ServItemID = bMassUp.ServItemSel
                .OrigRMRAmt = 0  'mod 1/18/17
                .NewRMRAmt = bMassUp.RMRAmt
                .lupd_datetime = Curdate
                .lupd_prog = CurProg
                .lupd_user = CurUser
                .UpdateType = "A"
                'mod 6/6/19 Add Effective Date to user5 - Solomon Cloud Solutions
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

            Effectdate = DateToStrSep(RegOrWarEffectDate)

            EndDate = DateToStrSep(bsmContract.ExpireDate)
            NumMonths = GetMonths(RegOrWarEffectDate, bsmContract.ExpireDate) + 1   'Total Duration


            'Calculate 1st month amt


            'DayNum = Math.Min(Effectdate.Day, 30)  mod 8/5/17 always a 30 day calc even for a 31 day month
            DayNum = Effectdate.Day
            NumDays = 30 - DayNum + 1

            DailyAmt = FPDiv(bMassUp.RMRAmt, 30, 6)
            FirstPeriodAmt = FPMult(NumDays, DailyAmt, 2)
            TotalAmt = FirstPeriodAmt

            'Balance of months excluding 1st and last month
            NumMonths = NumMonths - 2
            NextPeriodAmts = FPMult(NumMonths, bMassUp.RMRAmt, 2)
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

        With bsmContract
            If TotalAmt > 0 Then
                .TotalAmt = FPAdd(.TotalAmt, TotalAmt, 2)
            End If
            .OrigContractAmt = .TotalAmt
            .NewContractAmt = .TotalAmt
            SQLstmt = "XSvcUPD_MonthlyRMRAmt" + SParm(bXSVCGRID.ContractID)
            serr3 = SqlFetch1(c3, SQLstmt, MonthlyRMRAmt)
            .User3 = MonthlyRMRAmt
            .Lupd_dateTime = Curdate
            .Lupd_Prog = CurProg
            .Lupd_User = CurUser

            'xWarrtyItem = False                                                                                '4/10/2020 Warranty Items added to Table.
            'Call SqlCursorEx(xWarrItem_CSR, NOLEVEL, "xWarrItem_CSR", "xWarrantyItem", "")                     '4/10/2020 Warranty Items added to Table.
            'xWarr_Flg = SqlFetch1(xWarrItem_CSR, "xWarrantyItem_All" + SParm(bMassUp.ServItemSel.Trim), bxWarrantyItem)    '4/10/2020 Warranty Items added to Table.
            'If xWarr_Flg <> NOTFOUND Then                                                                      '4/10/2020 Warranty Items added to Table.
            '    xWarrtyItem = True                                                                             '4/10/2020 Warranty Items added to Table.
            '    .Response = bxWarrantyItem.Response                                                            '4/10/2020 Warranty Items added to Table.
            '    .ContractType = bxWarrantyItem.ContractType                                                    '4/10/2020 Warranty Items added to Table.
            '    For i = 0 To 6
            '        .Hours24(i) = "N"
            '        .StartTime(i) = ""
            '        .EndTime(i) = ""
            '        .StartAMPM(i) = "AM"
            '        .EndAMPM(i) = "PM"
            '        .StartTimeMilitary(i) = "1200"
            '    Next
            '    If Trim$(bxWarrantyItem.StartTime <> "") Then                                                  '4/10/2020 Warranty Items added to Table.
            '        For i = 0 To 4                                                                             '4/10/2020 Warranty Items added to Table.
            '            .StartTime(i) = bxWarrantyItem.StartTime                                               '4/10/2020 Warranty Items added to Table.
            '            .EndTime(i) = bxWarrantyItem.EndTime                                                   '4/10/2020 Warranty Items added to Table.
            '        Next                                                                                       '4/10/2020 Warranty Items added to Table.
            '    End If                                                                                         '4/10/2020 Warranty Items added to Table.
            '    If Trim$(bxWarrantyItem.Hours = "Y") Then                                                      '4/10/2020 Warranty Items added to Table.
            '        For i = 0 To 6                                                                             '4/10/2020 Warranty Items added to Table.
            '            .Hours24(i) = "Y"                                                                      '4/10/2020 Warranty Items added to Table.
            '        Next                                                                                       '4/10/2020 Warranty Items added to Table.
            '    End If                                                                                         '4/10/2020 Warranty Items added to Table.
            'Else                                                                                               '4/10/2020 Warranty Items added to Table.
            '    .ContractType = "01"                                                                           '4/10/2020 Warranty Items added to Table.
            'End If                                                                                             '4/10/2020 Warranty Items added to Table.
            'Call SqlFree(xWarrItem_CSR)                                                                        '4/10/2020 Warranty Items added to Table.

            If Multi = True Then                           '10/9/2019 - Issue 7.06 Retest2. Added Warranty End Date to SMContract when adding Multiple Items 
                If bMassUp.ServItemSel.Trim = "C OPTION A" Or bMassUp.ServItemSel.Trim = "CP OPTION A" Or bMassUp.ServItemSel.Trim = "CP OPTION D" Or bMassUp.ServItemSel.Trim = "CP OPTION D 4 HOUR" Then  '10/9/2019 - Issue 7.06 Retest2. Added Warranty End Date to SMContract when adding Multiple Items  '4/10/2020 Warranty Items added to Table.
                    'If xWarrtyItem = True Then  '10/9/2019 - Issue 7.06 Retest2. Added Warranty End Date to SMContract when adding Multiple Items   '4/10/2020 Warranty Items added to Table.
                    .User7 = bMassUp.WarrantyEndDate       '10/9/2019 - Issue 7.06 Retest2. Added Warranty End Date to SMContract when adding Multiple Items 
                    .User1 = bMassUp.Duration              '10/9/2019 - Issue 7.06 Retest2. Added Warranty End Date to SMContract when adding Multiple Items 
                End If                                     '10/9/2019 - Issue 7.06 Retest2. Added Warranty End Date to SMContract when adding Multiple Items 
            End If                                         '10/9/2019 - Issue 7.06 Retest2. Added Warranty End Date to SMContract when adding Multiple Items 

            'mod 4/7/17 adding coverage for warranty                                                       '4/10/2020 Warranty Items added to Table.
            Select Case bMassUp.ServItemSel.Trim                                                           '4/10/2020 Warranty Items added to Table.
                Case "C OPTION A", "CP OPTION A", "CP OPTION D", "CP OPTION D 4 HOUR"                      '4/10/2020 Warranty Items added to Table.
                    .Response = ""                                                                         '4/10/2020 Warranty Items added to Table.
                    For i = 0 To 6                                                                         '4/10/2020 Warranty Items added to Table.
                        .Hours24(i) = "N"                                                                  '4/10/2020 Warranty Items added to Table.
                        .StartTime(i) = ""                                                                 '4/10/2020 Warranty Items added to Table.
                        .EndTime(i) = ""                                                                   '4/10/2020 Warranty Items added to Table.
                        .StartAMPM(i) = "AM"                                                               '4/10/2020 Warranty Items added to Table.
                        .EndAMPM(i) = "PM"                                                                 '4/10/2020 Warranty Items added to Table.
                        .StartTimeMilitary(i) = "1200"                                                     '4/10/2020 Warranty Items added to Table.
                    Next                                                                                   '4/10/2020 Warranty Items added to Table.
                    Select Case bMassUp.ServItemSel.Trim                                                   '4/10/2020 Warranty Items added to Table.
                        Case "C OPTION A", "CP OPTION A"                                                   '4/10/2020 Warranty Items added to Table.
                            .Response = "0800"                                                             '4/10/2020 Warranty Items added to Table.
                            For i = 0 To 4                                                                 '4/10/2020 Warranty Items added to Table.
                                .StartTime(i) = "0800"                                                     '4/10/2020 Warranty Items added to Table.
                                .EndTime(i) = "0500"                                                       '4/10/2020 Warranty Items added to Table.
                            Next                                                                           '4/10/2020 Warranty Items added to Table.
                            If bMassUp.ServItemSel = "C OPTION A" Then                                     '4/10/2020 Warranty Items added to Table.
                                .ContractType = "04"                                                       '4/10/2020 Warranty Items added to Table.
                            Else                                                                           '4/10/2020 Warranty Items added to Table.
                                .ContractType = "01"                                                       '4/10/2020 Warranty Items added to Table.
                            End If                                                                         '4/10/2020 Warranty Items added to Table.
                        Case "CP OPTION D", "CP OPTION D 4 HOUR"                                           '4/10/2020 Warranty Items added to Table.
                            .Response = "0800"                                                             '4/10/2020 Warranty Items added to Table.
                            .ContractType = "02"                                                           '4/10/2020 Warranty Items added to Table.
                            For i = 0 To 6                                                                 '4/10/2020 Warranty Items added to Table.
                                .Hours24(i) = "Y"                                                          '4/10/2020 Warranty Items added to Table.
                            Next                                                                           '4/10/2020 Warranty Items added to Table.
                            If bMassUp.ServItemSel = "CP OPTION D" Then                                    '4/10/2020 Warranty Items added to Table.
                                .Response = "0800"                                                         '4/10/2020 Warranty Items added to Table.
                                .ContractType = "02"                                                       '4/10/2020 Warranty Items added to Table.
                            Else                                                                           '4/10/2020 Warranty Items added to Table.
                                .Response = "0400"                                                         '4/10/2020 Warranty Items added to Table.
                                .ContractType = "03"                                                       '4/10/2020 Warranty Items added to Table.
                            End If                                                                         '4/10/2020 Warranty Items added to Table.
                        Case Else                                                                          '4/10/2020 Warranty Items added to Table.
                            .ContractType = "01"                                                           '4/10/2020 Warranty Items added to Table.
                    End Select                                                                             '4/10/2020 Warranty Items added to Table.
            End Select                                                                                     '4/10/2020 Warranty Items added to Table.
            .NoteId = GAddContractNote("Added", bXTB_SERVICES.user8)  'mod 11/3/17
            Call SUpdate1(CSR_SMContract, "SMCONTRACT", bsmContract)
            If .User7 = 0 Then
                WarBillDate = gMaxDate
            End If
        End With
        'mod 4/7/17


        'mod 05/18/17 - mod 11/1/17 added exceptions for updating
        Dim ReplacePMCode As Boolean = False, OldPMCode As String = ""
        SysType = bMassUp.SystemType.Trim
        Numrecs = 0

        ' NEW CHANGE Select from smpmheader where user1 = Service item
        ' then get pmcode from buffer.
        SQLstmt = "Select * from SMPMHEADER where User1 = " + SParm(bMassUp.ServItemSel)
        serr7 = SqlFetch1(c7, SQLstmt, bsmPMHeader)
        If serr7 = 0 Then
            PMCode = bsmPMHeader.PMType
            PMFlag = "Y"  'mod 6/1/17
        Else
            PMCode = "00"
            PMFlag = "N" 'mod 6/1/17
        End If

        PMCode = PMCode.Trim
        SQLstmt = "select name from customer where custid = " + SParm(bsmContract.Custid)
        serr3 = SqlFetch1(c3, SQLstmt, bCust)

        Numrecs = 0
        SQLstmt = "xADD_equipTest" + SParm(bsmContract.ContractID) + SParm(SysType)
        serr7 = SqlFetch1(c7, SQLstmt, Numrecs)
        If Numrecs > 0 And PMCode <> "00" Then  'mod 1/12/17 was if = 1
            'mod 11/13/18
            '  SQLstmt = "select *from smsvcequipment (nolock) where contractid = " + SParm(bsmContract.ContractID) + "and descr like '%'+" + SParm(SysType)

            'New change modify code to select from smconequipment
            'modify logic to look at EquipmentType = system type
            SQLstmt = "smSvcType_SystemType" + SParm(SysType)
            serr8 = SqlFetch1(c7, SQLstmt, bsmSvcType)
            If serr8 = NOTFOUND Then

            End If

            SQLstmt = "Select top 1 *  from SMCONEQUIPMENT(nolock) where pmcode <> '00' and contractid = " _
                        + SParm(bsmContract.ContractID) _
                        + " and EquipTypeID = " + SParm(bsmSvcType.EquipmentTypeID)
            serr10 = SqlFetch1(c10, SQLstmt, bsmConEquipment)
            If serr10 = 0 And bsmConEquipment.PmCode.Trim <> PMCode Then
                'just going to replace with new PMCODE- where there are two different plans but same systype
                ReplacePMCode = True
                OldPMCode = bsmConEquipment.PmCode.Trim
            End If
        End If

        Dim CSR_Equip As Short, EquipTypeID As String = "" 'mod 4/14/18
        Call SqlCursorEx(CSR_Equip, NOLEVEL + SqlFastReadOnly, "csr_equipment", "", "")

        SQLstmt = "XSvcEquip_Update" + SParm(bsmContract.ContractID) + SParm(SysType) + SParm(PMCode) + SParm(bpes.UserId)
        serr12 = SqlFetch1(CSR_Equip, SQLstmt, bEquip)

        Debug.Print(SQLstmt + "  " + bEquip.id)
        Call SqlFree(CSR_Equip)

        If bEquip.id.Trim = "NEW" Then
            With bsmConEquipment
                'mod 4/8/17
                SQLstmt = "XRMACONT_smEquipSetup"
                serr5 = SqlFetch1(CSR_SMEquipSetup, SQLstmt, bsmEquipSetup)
                bsmEquipSetup.LastEquipmentNbr = (Val(bsmEquipSetup.LastEquipmentNbr) + 1).ToString
                Call SUpdate1(CSR_SMEquipSetup, "SMEQUIPSETUP", bsmEquipSetup)
                .EquipID = bsmEquipSetup.LastEquipmentNbr
                .ContractId = bsmContract.ContractID
                .Crtd_DateTime = Curdate
                .Crtd_Prog = CurProg
                .Crtd_User = CurUser
                .Lupd_DateTime = Curdate
                .Lupd_Prog = CurProg
                .Lupd_User = CurUser
                .Descr = bCust.Name.Trim + "-" + SysType
                .EndWarranty = bsmContract.User7
                .PmCode = PMCode
                .PMFlag = PMFlag
                .PrimaryKey = bsmContract.ContractID.Trim + .EquipID
                .StartWarranty = bsmContract.StartDate
                .EquipTypeID = ""
                For i = 0 To 8
                    If SysType = EquipType(i) Then
                        .EquipTypeID = "0" + CStr(i + 1)
                        Exit For
                    End If
                Next
                .ScreenID = "SN00100"
                .Status = "A"
                Call SInsert1(CSR_SMConEquipment, "SMConEquipment", bsmConEquipment)
            End With

            With bsmSvcEquipment
                .BranchId = bsmContract.BranchID
                .ContractID = bsmContract.ContractID
                .CpnyID = bpes.CpnyID
                .Crtd_DateTime = Curdate
                .Crtd_Prog = CurProg
                .Crtd_User = CurUser
                .Lupd_DateTime = Curdate
                .Lupd_Prog = CurProg
                .Lupd_User = CurUser
                .CustId = bsmContract.Custid
                .DateInstalled = bXTB_SERVICES.StatusDate
                .Descr = bCust.Name.Trim + "-" + SysType
                .EquipID = bsmEquipSetup.LastEquipmentNbr
                .EquipTypeID = bsmConEquipment.EquipTypeID
                .FuelType = "R"
                .ManufId = "01"
                .PMCode = PMCode
                .SiteId = bsmContract.SiteID
                .Status = "A"
                .StatusDate = .DateInstalled
                .WarrEndDate = bsmContract.User7
                .WarrStartDate = .StatusDate
                Call SInsert1(CSR_SMSvcEquipment, "SMSVCEQUIPMENT", bsmSvcEquipment)
            End With

            With bXTB_EQUIPREVIEW
                .Crtd_DateTime = Curdate
                .Crtd_Prog = CurProg
                .Crtd_User = CurUser
                .Lupd_DateTime = Curdate
                .Lupd_Prog = CurProg
                .Lupd_User = CurUser
                .CustID = bsmContract.Custid
                .EquipDesc = bCust.Name.Trim + "-" + SysType
                .EquipId = bsmEquipSetup.LastEquipmentNbr
                .InstallDate = bsmContract.StartDate
                .ManufID = "01"
                .SiteId = bsmContract.SiteID
                .Status = "A"
                .SystemType = SysType
                .User9 = 1
                .user2 = bsmContract.ContractID
                Call SInsert1(CSR_XTB_EquipReview, "XTB_EquipReview", bXTB_EQUIPREVIEW)
            End With

            Dim Recid As Short 'mod 6/19/18
            With bXTB_INSTALLBASE
                .crtd_datetime = Curdate
                .Crtd_Prog = CurProg
                .Crtd_User = CurUser
                .Lupd_DateTime = Curdate
                .Lupd_Prog = CurProg
                .Lupd_User = CurUser
                .EquipId = bsmEquipSetup.LastEquipmentNbr
                .InstallDate = bsmContract.StartDate
                .PartPrimaryCategory = SysType
                .Status = "A"
                ' .StatusDate = bXINBASETPL.ShipDateAct
                .user2 = bsmContract.ContractID
                'mod 6/19/18
                SQLstmt = "select max(recordid) from xtb_installbase where equipid = " + SParm(.EquipId) + " and invtid  = " + SParm("")
                serr11 = SqlFetch1(c11, SQLstmt, Recid)
                If Recid = 0 Then
                    .RecordID = IntMin
                Else
                    .RecordID = Recid + 1
                End If
                Call SInsert1(CSR_XTB_InstallBase, "XTB_InstallBase", bXTB_INSTALLBASE)
            End With
        Else
            bsmConEquipment.EquipID = bEquip.id  'needed for smconpmtask
        End If 'update or insert

        'Create  SMConPMTask records 11/1/17
        Dim CalCode As String, CalInterval As Double, NewPMDate As Date, PMDate As Integer, CSR_SMConPMTask As Short

       
        If PMCode <> "00" Then
            If ReplacePMCode Then
                SQLstmt = "delete SMCONPMTASK  where contractid = " + SParm(bsmContract.ContractID) + " and equipid = " + SParm(bsmConEquipment.EquipID) _
                    + " and pmcode = " + SParm(OldPMCode)
                Call sql(c9, SQLstmt)
            End If
            Call SqlCursor(CSR_SMConPMTask, NOLEVEL)
            SQLstmt = "select * from SMCONPMTASK where contractid = " + SParm(bsmContract.ContractID) + " and PMcode  = " + SParm(PMCode) + " and equipid = " + SParm(bsmConEquipment.EquipID)
            serr5 = SqlFetch1(CSR_SMConPMTask, SQLstmt, bsmConPMTask)
            If serr5 = NOTFOUND Then
                SQLstmt = "Select *  from SMCONEQUIPMENT(nolock) where pmcode =" + SParm(PMCode) + " And contractid = " + SParm(bsmContract.ContractID) + " and equipid = " + SParm(bsmConEquipment.EquipID)
                serr4 = SqlFetch1(CSR_SMConEquipment, SQLstmt, bsmConEquipment)

                'get CalCode,CalInterval
                SQLstmt = "SMPMHEADER_all" + SParm(bsmConEquipment.PmCode)
                serr5 = SqlFetch1(c5, SQLstmt, bsmPMHeader)
                CalCode = VB.Left(bsmPMHeader.CalendarCode, 1)
                If CalCode.Trim = "" Then CalCode = "D" 'mod 3/23/18 added trim
                CalInterval = bsmPMHeader.CalendarInterval
                NewPMDate = DateToStrSep(bXTB_SERVICES.StatusDate)
                While PMDate <= bsmContract.ExpireDate
                    With bsmConPMTask
                        .ContractId = bsmContract.ContractID
                        .Crtd_DateTime = Curdate
                        .Crtd_Prog = CurProg
                        .Crtd_User = CurUser
                        .EquipId = bsmConEquipment.EquipID
                        .Lupd_DateTime = Curdate
                        .Lupd_Prog = CurProg
                        .Lupd_User = CurUser
                        .PMCode = PMCode
                        .SchedDate = NULLDATE 'mod 10/27/17
                        Call StrToDate(NewPMDate, .PMDate)
                        If .PMDate > bsmContract.ExpireDate Then Exit While
                        Call SInsert1(CSR_SMConPMTask, "SMCONPMTASK", bsmConPMTask)
                        NewPMDate = DateAdd(CalCode, CalInterval, NewPMDate)
                    End With
                End While
            End If  'no records exist for Contractid/PMCODE - so insert them
            Call SqlFree(CSR_SMConPMTask)
        End If   'PMCode <> '00'

        doRevenues()
        'mod 6/12/17 
        SQLstmt = "xtb_smcontract_all" + SParm(bXSVCGRID.ContractID)
        serr1 = SqlFetch1(c3, SQLstmt, bXTB_SMCONTRACT)

        If bXTB_SMCONTRACT.InvoicingRule.Trim = "ARREARS" Then
            IsArrears = True
            Datstr = DateToStr(RegOrWarEffectDate)
            DY = Mid(Datstr, 3, 2)
            Call DatePlusMonthSetDay(RegOrWarEffectDate, 1, DY, RegOrWarEffectDate)
        End If
        SQLstmt = "xDelChg_ReversalOpenMonths" + SParm(bXSVCGRID.ContractID) + DParm(bMassUp.EffectDate)
        serr7 = SqlFetch1(c7, SQLstmt, NumOpenMonths)

        'RegorWarEffectDate =bmassup.effectdate unless it's a warranty.  Then 1 day is added.. ActualEffectDate = RegorWarEffectDate unless arrears then 1 month later.
        ' ActualEffectDate holds the original value of RegorWarEffectDate for comments.
        'If NumOpenMonths Then
        '    doBillings_Reversals(ActualEffectDate)
        'Else
        If ActualEffectDate <= bsmContract.ExpireDate Then
            doBillings(ActualEffectDate)
        End If
        '    End If

        If Not Multi Then Call TranEnd()
        Call SqlFree(CSR_SMEquipSetup)
    End Sub
    Private Sub doRevenues()
        Dim LastPostDate As Integer, FirstRevAddDate As Integer, NumMonths As Short, CurRevDate As Integer, EffectDate As Integer, WarrantyDate As Integer
        Dim CommentPerEndDate As Integer, Numrecs As Integer
        Dim LastDate As Integer = 0 'mod 11/7/17 Last revenue date based expire date  
        Dim FirstDate As Integer = 0 'mod 11/7/17 first smcontractrev date (would differ if 1st servitem a warranty)
        Dim LastInsertDate As Integer = 0 'mod 11/7/17 -- last revenue date for which records need to be inserted
        Dim TestDate As Integer = 0, InsertedNewRevs As Boolean = False

        'Warranty always inserts a new date either the 2nd of the month or the postwarranty enddate
        'however, if there are multiple adds with warranties then need to check if existing 2nd of month or postwarranty enddate in which case an update
        With bsmContractRev
            EffectDate = RegOrWarEffectDate

            Balance = TotalAmt

            SQLstmt = "xAdd_MaxRevPostDate" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate)
            'select top 1 * from smcontractrev where contractid = @contractid and month(revdate)=month(@firstdate)and year(revdate)=year(@firstdate)
            serr1 = SqlFetch1(c1, SQLstmt, LastPostDate)

            If LastPostDate <> NULLDATE Then
                Call DatePlusMonthSetDay(LastPostDate, 1, 1, FirstRevAddDate)
            Else
                FirstRevAddDate = EffectDate
            End If

            'mod 11/7/17  First test to insure that all future records exist and not deleted 
            Call DatePlusMonthSetDay(bsmContract.ExpireDate, 0, 1, LastDate)
            Numrecs = 0
            SQLstmt = "select count(*) from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID) + " and revdate = " + DParm(LastDate)
            serr2 = SqlFetch1(c2, SQLstmt, Numrecs)
            If Numrecs = 0 Then  'records were deleted
                Exit Sub
            End If

            'mod 11/7/17 is effect date < 1st rev date -- if so insert records 
            If LastPostDate = 0 Then
                'mod 11/7/17 is effect date < 1st rev date -- if so insert records 
                SQLstmt = "select min(revdate) from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID)
                serr3 = SqlFetch1(c3, SQLstmt, FirstDate)
                If FirstDate > FirstRevAddDate Then   'where 1st smcontractrev.revdate = warranty date and not smcontract.startdate
                    'find the first date for which there's a regular smcontractract.revdate on the 1st of the month
                    Call DatePlusMonthSetDay(FirstRevAddDate, 0, 1, TestDate)
                    SQLstmt = "smcontractrev_contractid" + SParm(bXSVCGRID.ContractID) + DParm(TestDate) + DParm(TestDate)
                    serr3 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                    If serr3 Then
                        Do Until TestDate = bsmContractRev.RevDate
                            Call DatePlusMonthSetDay(TestDate, 1, 1, TestDate)
                            SQLstmt = "smcontractrev_contractid" + SParm(bXSVCGRID.ContractID) + DParm(TestDate) + DParm(TestDate)
                            serr3 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                        Loop
                        LastInsertDate = bsmContractRev.RevDate
                    End If
                    With bsmContractRev
                        .RevAmount = FirstPeriodAmt
                        Call DatePlusMonthSetDay(FirstRevAddDate, 0, 1, .RevDate)
                        Do Until .RevDate = LastInsertDate
                            'all constant values are included in the last sqlstmt for smcontractrev
                            Call DatePlusMonthSetDay(.RevDate, 0, 31, CommentPerEndDate)
                            .Comment = gGetComment(.RevDate, CommentPerEndDate)
                            If Maint Then
                                .User3 = .RevAmount
                            Else
                                .User4 = .RevAmount
                            End If
                            .LineNbr = VB.Left(DateToStr(.RevDate), 2)
                            .Lupd_DateTime = Curdate
                            .Lupd_User = CurUser
                            .Lupd_Prog = CurProg
                            .Crtd_DateTime = Curdate
                            .Crtd_User = CurUser
                            .Crtd_Prog = CurProg
                            Call SInsert1(CSR_SMContractRev, "smcontractrev", bsmContractRev)
                            Call DatePlusMonthSetDay(bsmContractRev.RevDate, 1, 1, .RevDate)
                            .RevAmount = bMassUp.RMRAmt
                            Balance -= .RevAmount
                        Loop
                        InsertedNewRevs = True
                        CurRevDate = .RevDate
                    End With
                End If
            End If
            If Not (InsertedNewRevs) Then
                'looks for the 1st of month for effectdate or contract start date (since if contract start date <> 1st then neither will rev start date)
                SQLstmt = "xAdd_revFirstDate" + SParm(bXSVCGRID.ContractID) + DParm(FirstRevAddDate)
                serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)

                'mod 7/14/17
                If serr1 Then
                    SQLstmt = "smcontractrev_contractid" + SParm(bXSVCGRID.ContractID) + DParm(bXTB_SERVICES.StatusDate) + DParm(bXTB_SERVICES.StatusDate)
                    serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                    EffectDate = bXTB_SERVICES.StatusDate
                    If serr1 Then 'mod 7/17/17
                        SQLstmt = "select top 1 * from smcontractrev where contractid = " + SParm(bXSVCGRID.ContractID) + " and revdate > " + DParm(bXTB_SERVICES.StatusDate)
                        serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
                        If serr1 Then Exit Sub 'mod 9/26/17 where all susequent lines have been deleted
                    End If
                End If

                NumMonths = GetMonths(EffectDate, .RevDate)
                Curamt = FirstPeriodAmt + FPMult(bMassUp.RMRAmt, NumMonths, 2)

                Curamt = Math.Min(Curamt, Balance)

                'mod 11/19/16
                If Warranty Then
                    If FirstRevAddDate = .RevDate Then
                        'WarrantyDate = .RevDate + 1
                        WarrantyDate = .RevDate 'mod 12/9/16
                    Else
                        WarrantyDate = RegOrWarEffectDate
                    End If
                    'should not have an existing record for the warranty.  However
                    .User3 = 0 : .User4 = 0
                    SQLstmt = "smcontractrev_contractid" + SParm(bXSVCGRID.ContractID) + DParm(WarrantyDate) + DParm(WarrantyDate)
                    serr5 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
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
                If Warranty Then
                    If serr5 Then
                        .RevAmount = Curamt
                        .RevDate = WarrantyDate
                        .ContractID = bXSVCGRID.ContractID
                        .LineNbr = 0
                        .Status = "O"
                        SQLstmt = "xAdd_RevCommentEndPer" + SParm(bXSVCGRID.ContractID) + DParm(.RevDate)
                        'select top 1 Revdate-1 from smcontractRev where contractid = @contractid and Revdate >  @Revdate and day(Revdate)=1 --mod 11/19/16 re: don't want Revdates other than 1st of month re:warranties order by Revdate
                        serr4 = SqlFetch1(c4, SQLstmt, CommentPerEndDate)
                        If CommentPerEndDate = 0 Then CommentPerEndDate = bsmContract.ExpireDate
                        .Comment = gGetComment(RegOrWarEffectDate, CommentPerEndDate)
                        .Crtd_DateTime = Curdate
                        .Crtd_User = CurUser
                        .Crtd_Prog = CurProg
                        .CpnyID = bpes.CpnyID 'mod 9/20/17
                        Call SInsert1(CSR_SMContractRev, "SMcontractrev", bsmContractRev)
                    Else
                        Call SUpdate1(CSR_SMContractRev, "smcontractrev", bsmContractRev)
                    End If
                Else
                    Call SUpdate1(CSR_SMContractRev, "smcontractrev", bsmContractRev)
                End If
                Balance -= Curamt

                Call DatePlusDays(.RevDate, 1, CurRevDate)  'so it will find next not current
            End If
            SQLstmt = "xAdd_smcontractRev" + SParm(bXSVCGRID.ContractID) + DParm(CurRevDate)
            'select * from smcontractrev where contractid = @contractid and revdate >= @RevDate
            serr1 = SqlFetch1(CSR_SMContractRev, SQLstmt, bsmContractRev)
            Do While serr1 = 0
                Curamt = bMassUp.RMRAmt
                Curamt = Math.Min(Curamt, Balance)
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
    Private Sub doBillings(CommentEffectDate As Integer)
        Dim LastPostDate As Integer, FirstBillDate As Integer, DD As Short, NumMonths As Short, EffectDate As Integer
        Dim WarrantyDate As Integer, Numrecs As Integer, CommentEndDate As Integer = 0, CommentStartDate As Integer
        Dim MaxBillDate As Integer, FloorDate As Integer
        'mod 12/14/16 major modification re: getting freq end date

        With bsmContractBill
            .Lupd_User = CurUser
            .Lupd_DateTime = Curdate
            .Lupd_Prog = CurProg

            EffectDate = RegOrWarEffectDate

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
            Call DatePlusMonthSetDay(EffectDate, 0, 1, FloorDate)
            'SQLstmt = "select count(billdate) from smcontractbill where contractid = " + SParm(bXSVCGRID.ContractID) + " and billdate = " + DParm(FloorDate)
            'serr6 = SqlFetch1(c6, SQLstmt, Numrecs)
            'Call SqlFree(c6)

            'Check if an existing billing line with same date exists
            'TEST
            'If DD <> 1 Then

            '    'Call DatePlusMonthSetDay(EffectDate, 0, 1, EffectDate)
            '    'mod 4/23/17  
            '    SQLstmt = "select max(billdate) from smcontractbill where contractid = " + SParm(bXSVCGRID.ContractID)
            '    serr6 = SqlFetch1(c6, SQLstmt, MaxBillDate)
            '    Call SqlFree(c6)
            '    EffectDate = Math.Min(MaxBillDate, EffectDate)
            'End If
            'If DD <> 1 Then
            '    Call DatePlusMonthSetDay(EffectDate, 1, 1, EffectDate)
            'End If

            SQLstmt = "xAdd_MaxBillPostDate" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate)
            'select isnull(max(Billdate),'01/01/1900') from smcontractBill where contractid = @contractid and status = 'P'and Billdate >= @firstdate
            serr1 = SqlFetch1(c1, SQLstmt, LastPostDate)

            If LastPostDate <> NULLDATE Then
                Call DatePlusMonthSetDay(LastPostDate, 0, 1, FirstBillDate)
            Else
                FirstBillDate = EffectDate
            End If

            FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)  'mod 12/14/16
            'If Frequency = 1 Or FloorDate = EffectDate Then
            '    DD = Mid(DateToStr(EffectDate), 3, 2)
            'End If
            '  NumMonths = GetMonths(EffectDate, FreqStartDate)
            'NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))  'mod 12/23/16
            NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - 1)
            '10/4/2019 Resolve a specific issue 6.01 found during testing. 
            If bMultiSite.StartDate And Frequency <> 1 And NumMonths = 0 Then                                                                                 '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                '           FirstBillDate = FreqStartDate    AND         FirstBillDate <> WarBillDate    AND          FirstBillDate = EffectDate              '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                If Warranty = False Then                                                                                                                      '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                    If DateCmp(FirstBillDate, FreqStartDate) = 0 And DateCmp(FirstBillDate, WarBillDate) <> 0 And DateCmp(FirstBillDate, EffectDate) = 0 Then '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                        Dim NextFreqDate As DateTime                                                                                                          '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                        Do While FirstBillDate >= FreqStartDate  '9/1/2019         6/1/2019  9/1/2019   12/1/2019                                             '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                            NextFreqDate = DateTime.Parse(DateToStrSep(FreqStartDate)).AddMonths(Frequency)                                                   '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                            Call StrToDate(NextFreqDate, FreqStartDate)                                                                                       '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                            'Call MsgBox("MultiSite LOOP 10: NextFreqDate = " + NextFreqDate.ToString)                                                        '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                        Loop                                                                                                                                  '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                        NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))                                                     '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                    End If                                                                                                                                    '10/4/2019 Resolve a specific issue 6.01 found during testing. 
                End If
            End If
            Curamt = FirstPeriodAmt + FPMult(bMassUp.RMRAmt, NumMonths, 2)  'current period

            If bMassUp.RMRAmt > 0 Then
                Curamt = Math.Min(Curamt, Balance)
            End If

            Balance -= Curamt

            bsmContractBill.BillDate = NULLDATE
            SQLstmt = "xAdd_smcontractBill" + SParm(bXSVCGRID.ContractID) + DParm(FirstBillDate) + DParm(WarBillDate)
            'select * from smcontractBill where contractid = @contractid and Billdate >= @billdate order by contractid, billdate
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

            CommentStartDate = CommentEffectDate   'Regorwarbilldate
            If Warranty Then
                If FirstBillDate = bsmContractBill.BillDate Then
                    WarrantyDate = .BillDate + 1  '2nd
                Else
                    'Mod 11/19/2019 - Solomon Cloud Solutions - Set Warranty date to Floordate + 1 instead of firstbilldate
                    'WarrantyDate = FirstBillDate
                    WarrantyDate = FloorDate + 1
                End If
                'should not have an existing record for the warranty.  However
                .User3 = 0 : .User4 = 0
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(WarrantyDate) + DParm(WarrantyDate)
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
                If WarrantyDate < bsmContract.ExpireDate Then
                    If serr5 Then
                        .BillDate = WarrantyDate
                        .BillAmount = Curamt
                        .ContractID = bXSVCGRID.ContractID
                        .CB_ID07 = 0
                        .LineNbr = 1
                        .Status = "O" 'mod 12/16/16
                        'mod 6/12/17
                        Call DatePlusMonthSetDay(FreqStartDate, IIf(IsArrears, -2, -1), 31, CommentEndDate)
                        CommentEndDate = Math.Min(CommentEndDate, bsmContract.ExpireDate)
                        .Comment = gGetComment(CommentStartDate, CommentEndDate) 'mod 12/1516  CommentStartDate computed above
                        .Crtd_DateTime = Curdate
                        .Crtd_User = CurUser
                        .Crtd_Prog = CurProg
                        .User6 = "Add"  'mod 12/31/16
                        .CpnyID = bpes.CpnyID   'mod 9/20/17
                        .NoteID = GAddNote("Added", bXTB_SERVICES.StatusDate) 'mod 10/29/17
                        Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                    Else
                        'want the smaller of the existing comment start date or the current effect date.  Make sure to keep comment enddate
                        .Comment = gGetUpdateComment()  'mod 10/30/17
                        .NoteID = GAddNote("Added", bXTB_SERVICES.StatusDate) 'mod 10/29/17
                        Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                    End If
                End If
            Else   'not warranty
                .User3 = 0 : .User4 = 0
                SQLstmt = "xsmcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FirstBillDate + 2) + DParm(WarBillDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

                SQLstmt = "SELECT COUNT(*) FROM smcontractbill WHERE contractid = " + SParm(bXSVCGRID.ContractID) + " AND BillDate = " + DParm(FloorDate) + " AND Status = 'O'"
                serr4 = SqlFetch1(c9, SQLstmt, Numrecs)
                Call SqlFree(c9)
                If Numrecs <> 0 Then
                    .BillDate = FloorDate + 2
                Else
                    'TEST
                    Call DatePlusMonthSetDay(FirstBillDate, 1, 3, .BillDate)
                    '.BillDate = FirstBillDate
                End If
                'Doublecheck to make sure the modified date will not have a duped key
                SQLstmt = "xsmcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(.BillDate) + DParm(WarBillDate)
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
                        'mod 11/2/17
                        If Maint Then
                            .User3 = FPAdd(.User3, Curamt, 2)
                        Else
                            .User4 = FPAdd(.User4, Curamt, 2)
                        End If
                    End If
                End If
                If serr3 Then
                    .BillAmount = Curamt
                    .ContractID = bXSVCGRID.ContractID
                    .CB_ID07 = 0
                    .LineNbr = 1
                    .Status = "O" 'mod 12/16/16
                    'mod 6/12/17
                    Call DatePlusMonthSetDay(FreqStartDate, IIf(IsArrears, -2, -1), 31, CommentEndDate)
                    CommentEndDate = Math.Min(CommentEndDate, bsmContract.ExpireDate)
                    .Comment = gGetComment(CommentStartDate, CommentEndDate) 'mod 12/1516  CommentStartDate computed above
                    .Crtd_DateTime = Curdate
                    .Crtd_User = CurUser
                    .Crtd_Prog = CurProg
                    .User6 = "Add"  'mod 12/31/16
                    .CpnyID = bpes.CpnyID  'mod 9/20/17
                    .NoteID = GAddNote("Added", bXTB_SERVICES.StatusDate) 'mod 10/29/17
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    .NoteID = GAddNote("Added", bXTB_SERVICES.StatusDate) 'mod 10/29/17
                    .Comment = gGetUpdateComment()  'mod 10/30/17
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If
            End If

            SQLstmt = "xAdd_smcontractBill" + SParm(bXSVCGRID.ContractID) + DParm(FreqStartDate) + DParm(WarBillDate)
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

            Do While serr1 = 0
                If Mid(DateToStr(.BillDate), 3, 2) <> 4 Then   'mod 12/16/16- day 4 reserved for amt applied against postings
                    Curamt = FPMult(bMassUp.RMRAmt, Frequency, 2)
                    Curamt = Math.Min(Curamt, Balance)
                    .BillAmount = FPAdd(.BillAmount, Curamt, 2)
                    If Maint Then
                        .User3 = FPAdd(.User3, Curamt, 2)
                    Else
                        .User4 = FPAdd(.User4, Curamt, 2)
                    End If
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
    End Sub

    Private Sub doBillings_Reversals(CommentEffectDate As Integer)
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        Dim LastPostDate As Integer, FirstBillDate As Integer, DD As Short, NumMonths As Short, EffectDate As Integer
        Dim WarrantyDate As Integer, Numrecs As Integer, CommentEndDate As Integer = 0, CommentStartDate As Integer

        'mod 12/14/16 major modification re: getting freq end date

        With bsmContractBill
            .Lupd_User = CurUser
            .Lupd_DateTime = Curdate
            .Lupd_Prog = CurProg

            EffectDate = RegOrWarEffectDate

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

            'now load the billingstatus table mod 11/12/17
            SQLstmt = "XReversal_Add_GetBillStatus" + SParm(bXSVCGRID.ContractID) + DParm(EffectDate) + DParm(WarBillDate) + SParm(bpes.UserId)
            serr1 = SqlFetch1(c1, SQLstmt, bxBillingStatus)

            SQLstmt = "XReversal_maxpostdate" + DParm(EffectDate) + SParm(bpes.UserId)
            ''select isnull(max(Billdate),'01/01/1900') from smcontractBill where contractid = @contractid and status = 'P'and Billdate >= @firstdate
            serr1 = SqlFetch1(c1, SQLstmt, LastPostDate)  'find the next open billdate

            If LastPostDate <> NULLDATE Then
                Call DatePlusMonthSetDay(LastPostDate, 1, 1, FirstBillDate)
            Else
                FirstBillDate = EffectDate
            End If

            FreqStartDate = GetFreqStartDate(bXSVCGRID.ContractID, FirstBillDate, Frequency)  'mod 12/14/16

            '  NumMonths = GetMonths(EffectDate, FreqStartDate)
            NumMonths = Math.Max(0, GetMonths(EffectDate, FreqStartDate) - IIf(DD = 1, 1, 0))  'mod 12/23/16
            Curamt = FirstPeriodAmt + FPMult(bMassUp.RMRAmt, NumMonths, 2)  'current period

            If bMassUp.RMRAmt > 0 Then
                Curamt = Math.Min(Curamt, Balance)
            End If

            Balance -= Curamt

            bsmContractBill.BillDate = NULLDATE
            SQLstmt = "xAdd_smcontractBill" + SParm(bXSVCGRID.ContractID) + DParm(FirstBillDate) + DParm(WarBillDate)
            'select * from smcontractBill where contractid = @contractid and Billdate >= @billdate order by contractid, billdate
            serr1 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)

            CommentStartDate = CommentEffectDate   'Regorwarbilldate
            If Warranty Then
                If FirstBillDate = bsmContractBill.BillDate Then
                    WarrantyDate = .BillDate + 1  '2nd
                Else
                    WarrantyDate = FirstBillDate
                End If
                'should not have an existing record for the warranty.  However
                .User3 = 0 : .User4 = 0
                '&&&&&&&&&&&&&&&&&&&&&&
                SQLstmt = "smcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(WarrantyDate) + DParm(WarrantyDate)
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
                    'mod 6/12/17
                    Call DatePlusMonthSetDay(FreqStartDate, IIf(IsArrears, -2, -1), 31, CommentEndDate)
                    CommentEndDate = Math.Min(CommentEndDate, bsmContract.ExpireDate)
                    .Comment = gGetComment(CommentStartDate, CommentEndDate) 'mod 12/1516  CommentStartDate computed above
                    .Crtd_DateTime = Curdate
                    .Crtd_User = CurUser
                    .Crtd_Prog = CurProg
                    .User6 = "Add"  'mod 12/31/16
                    .CpnyID = bpes.CpnyID   'mod 9/20/17
                    .NoteID = GAddNote("Added", bXTB_SERVICES.StatusDate) 'mod 10/29/17
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    'want the smaller of the existing comment start date or the current effect date.  Make sure to keep comment enddate
                    .Comment = gGetUpdateComment()  'mod 10/30/17
                    .NoteID = GAddNote("Added", bXTB_SERVICES.StatusDate) 'mod 10/29/17
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If
            Else   'not warranty
                .User3 = 0 : .User4 = 0
                SQLstmt = "xsmcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(FirstBillDate) + DParm(WarBillDate)
                serr3 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
                .BillDate = FirstBillDate
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
                    '&&&&&&&&&&
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
                        'mod 11/2/17
                        If Maint Then
                            .User3 = FPAdd(.User3, Curamt, 2)
                        Else
                            .User4 = FPAdd(.User4, Curamt, 2)
                        End If
                    End If
                End If
                If serr3 Then
                    .BillAmount = Curamt
                    .ContractID = bXSVCGRID.ContractID
                    .CB_ID07 = 0
                    .LineNbr = 1
                    .Status = "O" 'mod 12/16/16
                    'mod 6/12/17
                    Call DatePlusMonthSetDay(FreqStartDate, IIf(IsArrears, -2, -1), 31, CommentEndDate)
                    CommentEndDate = Math.Min(CommentEndDate, bsmContract.ExpireDate)
                    .Comment = gGetComment(CommentStartDate, CommentEndDate) 'mod 12/1516  CommentStartDate computed above
                    .Crtd_DateTime = Curdate
                    .Crtd_User = CurUser
                    .Crtd_Prog = CurProg
                    .User6 = "Add"  'mod 12/31/16
                    .CpnyID = bpes.CpnyID  'mod 9/20/17
                    .NoteID = GAddNote("Added", bXTB_SERVICES.StatusDate) 'mod 10/29/17
                    Call SInsert1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                Else
                    .NoteID = GAddNote("Added", bXTB_SERVICES.StatusDate) 'mod 10/29/17
                    .Comment = gGetUpdateComment()  'mod 10/30/17
                    Call SUpdate1(CSR_SMContractBill, "SMcontractbill", bsmContractBill)
                End If
            End If

            'mod 11/12/17
            Dim Date1, Date2 As Integer, StatusP As Boolean = False
            Dim Pos As Short, CommentEndDateStr As String
            SQLstmt = "select * from xbillingstatus where billdate >= " + DParm(FreqStartDate) + " and userid = " + SParm(bpes.UserId)
            serr2 = SqlFetch1(c2, SQLstmt, bxBillingStatus)

            Do While serr2 = 0
                StatusP = False
                If Mid(DateToStr(bxBillingStatus.BillDate), 3, 2) <> 4 Then
                    If bxBillingStatus.Status = "P" Then
                        StatusP = True
                        Date1 = bxBillingStatus.BillDate
                        SQLstmt = "XReversal_NextOpenDate" + DParm(Date1) + SParm(bpes.UserId)
                        serr11 = SqlFetch1(c11, SQLstmt, Date2)
                        NumMonths = GetMonths(Date1, Date2) + Frequency
                    Else
                        NumMonths = Frequency
                        Date2 = bxBillingStatus.BillDate
                    End If
                    'get correct smcontractbill record to update
                    SQLstmt = "xsmcontractbill_contractid" + SParm(bXSVCGRID.ContractID) + DParm(Date2) + DParm(WarBillDate)
                    serr4 = SqlFetch1(CSR_SMContractBill, SQLstmt, bsmContractBill)
                    If StatusP Then
                        Pos = InStr(.Comment, "-")
                        If Pos <> 0 Then
                            CommentEndDateStr = Mid(.Comment, Pos + 1).Trim
                            Call StrToDate(CommentEndDateStr, CommentEndDate)
                            .Comment = gGetComment(Date1, CommentEndDate)
                        End If
                    End If
                    Curamt = FPMult(bMassUp.RMRAmt, NumMonths, 2)
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
                    Call SUpdate1(CSR_SMContractBill, "smcontractbill", bsmContractBill)

                    Balance -= Curamt

                    If Balance = 0 Then Exit Do
                    If StatusP Then  'move the sfetch to date2
                        SQLstmt = "select * from xbillingstatus where billdate >=" + DParm(Date2) + " and userid = " + SParm(bpes.UserId)
                        serr2 = SqlFetch1(c2, SQLstmt, bxBillingStatus)
                    End If
                End If
                serr2 = SFetch1(c2, bxBillingStatus)
            Loop

        End With
    End Sub
End Module