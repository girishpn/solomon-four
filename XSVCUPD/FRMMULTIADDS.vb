Option Explicit On
Option Strict Off
Public Class FrmMultiAdds

    Private Sub btnAddReturn_Click(sender As System.Object, e As System.EventArgs) Handles btnAddReturn.Click
        Call SetLevelChg(LEVEL4, NOTCHANGED)
        Call HideForm(Me)

    End Sub


    Private Sub txtservitemidA_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtservitemidA.ChkEvent
        Dim Numrecs As Integer

        Dim xWarrItem_CSR As Short                      '4/10/2020 Warranty Items added to Table.
        Dim xWarr_Flg As Short                          '4/10/2020 Warranty Items added to Table.

        'mod 11/9/17
        Numrecs = 0
        'Call SqlCursorEx(xWarrItem_CSR, NOLEVEL, "xWarrItem_CSR", "xWarrantyItem", "")                                 '4/10/2020 Warranty Items added to Table.
        'xWarr_Flg = SqlFetch1(xWarrItem_CSR, "xWarrantyItem_All" + SParm(ChkStrg.Trim), bxWarrantyItem)                '4/10/2020 Warranty Items added to Table.
        'If xWarr_Flg <> NOTFOUND Then                                                                                  '4/10/2020 Warranty Items added to Table.
        Select Case ChkStrg.Trim                                                                                  '4/10/2020 Warranty Items added to Table.
            Case "C OPTION A", "CP OPTION A", "CP OPTION D", "CP OPTION D 4 HOUR"                                 '4/10/2020 Warranty Items added to Table.
                SQLstmt = "xadd_warrantyLimit" + SParm(bXSVCFILTER.ContractID)
                serr5 = SqlFetch1(c5, SQLstmt, Numrecs)
                If Numrecs Then
                    Call MessBox("This contract already has a Warranty covered Maintenance Item.", 48, "MassUpdate Msg")
                    RetVal = ErrNoMess
                    Exit Sub
                End If
        End Select                                                                                                '4/10/2020 Warranty Items added to Table.
        'End If                                                                                                         '4/10/2020 Warranty Items added to Table.
        'Call SqlFree(xWarrItem_CSR)                                                                                    '4/10/2020 Warranty Items added to Table.
        Numrecs = 0
        RetVal = PVChkFetch1(txtservitemidA, c1, ChkStrg, bxServiceitems)
        bXMULTIADDS.Descr = bxServiceitems.Descr
        Call DispField(txtdescrA)
        Call ApplSetfocus(txtrmramtA)
        bXMULTIADDS.RMRAmt = 0
        Call DispField(txtrmramtA)
        SQLstmt = "xAdd_WarTest" + SParm(ChkStrg)
        Call sql(c3, SQLstmt)
        serr3 = SGroupFetch1(c3, Numrecs)
        If Numrecs Then
            'mod 4/16/17
            SQLstmt = "xget_warrantyduration" + SParm(bXSVCFILTER.ContractID)
            serr5 = SqlFetch1(c5, SQLstmt, bWarDuration)
            If serr5 = 0 And bWarDuration.Duration.Trim > "" Then
                bXMULTIADDS.Duration = bWarDuration.Duration
                Call DispField(txtdurationAA)
            End If
        Else
            'mod 12/9/16
            bXMULTIADDS.WarrantyEndDate = nXMULTIADDS.WarrantyEndDate
            bXMULTIADDS.WarrantyStartDate = nXMULTIADDS.WarrantyStartDate
            bXMULTIADDS.Duration = nXMULTIADDS.Duration
            Call DispFields(Me, txtwarrantystartdateA, txtwarrantyenddateA)
        End If

    End Sub

    Private Sub txteffectdateA_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txteffectdateA.ChkEvent
        Dim dat As Integer
        Call StrToDate(ChkStrg, dat)
        If (bsmContract.BillStartDate > dat Or bsmContract.AmortStartDate > dat Or bsmContract.StartDate > dat) Then
            Call MessBox("Contract or Revenue or Billing Start Date later than EffectDate", 48, "MassUpdate Msg")
            retval = ErrNoMess
        ElseIf bsmContract.ExpireDate < dat Then
            Call MessBox("Contract End Date earlier than EffectDate", 48, "MassUpdate Msg")
            retval = ErrNoMess
        End If
        'mod 4/16/17
        If bXMULTIADDS.Duration.Trim <> "" Then
            bXMULTIADDS.WarrantyStartDate = dat
            Call DispField(txtwarrantystartdateA)
            Call DatePlusDays(dat, (bXMULTIADDS.Duration - IIf(bXMULTIADDS.Duration = 0, 0, 1)), bXMULTIADDS.WarrantyEndDate) 'mod 7/7/17 for duration -1
            Call DispField(txtwarrantyenddateA)
        End If
    End Sub



    Private Sub txtwarrantystartdateA_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtwarrantystartdateA.ChkEvent
        'mod 6/1/17 --user can now override
        If bXMULTIADDS.Duration.Trim <> "" Then
            Dim duration As Short = Val(bXMULTIADDS.Duration), dat As Integer
            Call StrToDate(ChkStrg, dat)
            Call DatePlusDays(dat, (duration - IIf(duration = 0, 0, 1)), bXMULTIADDS.WarrantyEndDate) 'mod 7/7/17
            Call DispField(txtwarrantyenddateA)
            bXMULTIADDS.WarrantyStartDate = dat
        End If

    End Sub

    Private Sub txtdurationAA_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtdurationAA.ChkEvent
        'mod 6/1/17 --user can now override
        Dim duration As Short = Val(ChkStrg)
        If bXMULTIADDS.WarrantyStartDate > 0 Then
            Call DatePlusDays(bXMULTIADDS.WarrantyStartDate, (duration - IIf(duration = 0, 0, 1)), bXMULTIADDS.WarrantyEndDate) '7/7/17
            Call DispField(txtwarrantyenddateA)
        End If
    End Sub


    Private Sub DslGrid4_LineChkEvent(ByRef Action As System.Int16, ByRef MaintFlg As System.Int16, ByRef RetVal As System.Int16) Handles DslGrid4.LineChkEvent
        Dim ActualEffectDate As Integer
        If Action <> 5 And Action <> DELETED Then
            If bXMULTIADDS.EffectDate = 0 Then
                Call MessBox("Effect Date Omitted", 48, "MassUpdate Msg")
                RetVal = ErrNoMess
                Call ApplSetfocus(txteffectdateA)
            ElseIf bXMULTIADDS.ServItemID.Trim = "" Then
                Call MessBox("ServiceItem omitted", 48, "MassUpdate Msg")
                RetVal = ErrNoMess
            ElseIf bXMULTIADDS.SystemType.Trim = "" Then
                Call MessBox("System Type omitted", 48, "MassUpdate Msg")
                RetVal = ErrNoMess
            Else
                ActualEffectDate = Math.Max(bXMULTIADDS.EffectDate, IIf(Val(bXMULTIADDS.Duration) > 0, bXMULTIADDS.WarrantyEndDate + 1, 0))  'mod 9/15/17
                If gReversalWarning("this Addition", ActualEffectDate, 1) Then
                    RetVal = ErrNoMess
                End If
            End If
        End If
    End Sub



    Private Sub FrmMultiAdds_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class