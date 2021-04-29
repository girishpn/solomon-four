Option Explicit On
Option Strict Off
Public Class FrmMultiDeletes
    Dim SQLstmt As String
    Private Sub btnDelReturn_Click(sender As System.Object, e As System.EventArgs) Handles btnDelReturn.Click
        If Not (IsMultiDelete) Then
            If bTotDel.Total > 1 Then
                Call MessBox("Please select only one line item to be processed", 48, "Massupdate Msg")
                Exit Sub
            Else
                If bTotDel.Total = 0 Then
                    Call MessBox("No line item was selected to be processed." + vbCrLf + "Are you sure you wish to Return", vbQuestion + vbYesNo, "MassUpdate Msg")
                    If MessResponse = vbNo Then
                        Exit Sub
                    End If
                End If
            End If
        End If
        Call SetLevelChg(LEVEL3, NOTCHANGED)
        Call HideForm(Me)
    End Sub


    Private Sub DslGrid3_LineChkEvent(ByRef Action As System.Int16, ByRef MaintFlg As System.Int16, ByRef RetVal As System.Int16) Handles DslGrid3.LineChkEvent
        If Action <> 5 And bDelselected.Value = 1 And IsMultiDelete Then
            If bXMULTIDELETES.EffectDate = 0 Then
                Call MessBox("Effect Date Omitted", 48, "MassUpdate Msg")
                RetVal = ErrNoMess
                Call ApplSetfocus(txteffectdateD)
            ElseIf bXMULTIDELETES.CancelCode.Trim = "" Then
                Call MessBox("Cancel Code Omitted", 48, "MassUpdate Msg")
                RetVal = ErrNoMess
                Call ApplSetfocus(txtcancelcodeD)
            ElseIf gReversalWarning("this Deletion", bXMULTIDELETES.EffectDate, 1) Then
                RetVal = ErrNoMess
            End If
        End If
    End Sub

    Private Sub DslGrid3_LineGotFocusEvent(ByRef maintflg As Short, ByRef retval As Short) Handles DslGrid3.LineGotFocusEvent
        If bDelselected.Value = 0 Then
            Call SetProps(Me, txteffectdateD, txtcancelcodeD, PROP_BLANKERR, False)
            Call SetProps(Me, txteffectdateD, txtcancelcodeD, PROP_ENABLED, False)
        Else
            Call SetProps(Me, txteffectdateD, txtcancelcodeD, PROP_ENABLED, True)
            Call SetProps(Me, txteffectdateD, txtcancelcodeD, PROP_BLANKERR, True)
        End If

    End Sub

    Private Sub txtdelselected_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txtdelselected.ChkEvent
        Dim CurRow As Short, MaintFlag As Short, NumCnt As Short
        Select Case ChkStrg
            Case 0
                Call SetProps(Me, txteffectdateD, txtcancelcodeD, PROP_BLANKERR, False)
                Call SetProps(Me, txteffectdateD, txtcancelcodeD, PROP_ENABLED, False)
            Case 1
                Call SetProps(Me, txteffectdateD, txtcancelcodeD, PROP_ENABLED, True)
                Call SetProps(Me, txteffectdateD, txtcancelcodeD, PROP_BLANKERR, True)
                CurRow = MGetRowNum(DelGridHandle)
                bDelselected.Value = 1
                serr5 = MFirst(DelGridHandle, MaintFlag)
                NumCnt = 0
                Do While serr5 = 0
                    If (bDelselected.Value = 1 Or MGetRowNum(DelGridHandle) = CurRow) And bXMULTIDELETES.RMRAmt > 0 Then NumCnt += 1
                    serr5 = MNext(DelGridHandle, MaintFlag)
                Loop
                Call MSetRow(DelGridHandle, CurRow)
                If NumCnt = NumRecsWithAmts Then
                    Call MessBox("This is the last item on the contract with Dollar amounts " + vbCrLf + "IF you need to Add an item, Process the Add first" + vbCrLf + "then the Cancel", 48, "MassUpdate Msg")
                End If
        End Select
    End Sub


    Private Sub txteffectdateD_ChkEvent(ByRef ChkStrg As System.String, ByRef retval As System.Int16) Handles txteffectdateD.ChkEvent
        Dim Effectdate As Integer
        Dim SqlStmt As String
        Dim NumWarrantyDate As Integer   '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
        NumWarrantyDate = 0              '11/13/2019  Display a message if the Delete item is before Warranty Start Date.

        Dim xWarrItem_CSR As Short                      '4/10/2020 Warranty Items added to Table.
        Dim xWarr_Flg As Short                          '4/10/2020 Warranty Items added to Table.
        Dim xWarrItem As Boolean                        '4/10/2020 Warranty Items added to Table.
        'xWarrItem = False                               '4/10/2020 Warranty Items added to Table.
        'Call SqlCursorEx(xWarrItem_CSR, NOLEVEL, "xWarrItem_CSR", "xWarrantyItem", "")                                 '4/10/2020 Warranty Items added to Table.
        'xWarr_Flg = SqlFetch1(xWarrItem_CSR, "xWarrantyItem_All" + SParm(Trim$(bXMULTIDELETES.ServItemID)), bxWarrantyItem)   '4/10/2020 Warranty Items added to Table.
        'If xWarr_Flg <> NOTFOUND Then                                                                                  '4/10/2020 Warranty Items added to Table.
        '    xWarrItem = True                                                                                           '4/10/2020 Warranty Items added to Table.
        'End If                                                                                                         '4/10/2020 Warranty Items added to Table.
        'Call SqlFree(xWarrItem_CSR)                                                                                    '4/10/2020 Warranty Items added to Table.

        'mod 6/11/17
        Call StrToDate(ChkStrg, Effectdate)
        If bsmContract.ExpireDate < Effectdate Then
            Call MessBox("Contract's End Date is earlier than EffectDate", 48, "MassUpdae Msg")
            retval = ErrNoMess
        ElseIf (bsmContract.BillStartDate > Effectdate Or bsmContract.AmortStartDate > Effectdate Or bsmContract.StartDate > Effectdate) Then
            Call MessBox("Contract or Revenue or Billing Start Date later than EffectDate", 48, "MassUpdate Msg")
            retval = ErrNoMess
        ElseIf (Trim$(bXMULTIDELETES.ServItemID) = "C OPTION A" Or Trim$(bXMULTIDELETES.ServItemID) = "CP OPTION A" Or Trim$(bXMULTIDELETES.ServItemID) = "CP OPTION D" Or Trim$(bXMULTIDELETES.ServItemID) = "CP OPTION D 4 HOUR" Or Trim$(bXMULTIDELETES.ServItemID) = "CP OPTION D") Then  '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
            'ElseIf xWarrItem = True Then  '11/13/2019  Display a message if the Delete item is before Warranty Start Date. '4/10/2020 Warranty Items added to Table.
            SqlStmt = "XSVCU00_First_ServItem_WarrantyDate" + SParm(bsmContract.ContractID) + SParm(bXMULTIDELETES.ServItemID) + DParm(Effectdate)  '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
            Call sql(c4, SqlStmt)                      '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
            serr3 = SGroupFetch1(c4, NumWarrantyDate)  '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
            If NumWarrantyDate = 0 Then                '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
                Call MessBox("Contract or Revenue or Billing Start Date later than EffectDate", 48, "MassUpdate Msg")  '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
                retval = ErrNoMess                     '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
            End If                                     '11/13/2019  Display a message if the Delete item is before Warranty Start Date.
        End If
    End Sub
    Private Sub FrmMultiDeletes_Enter(sender As Object, e As System.EventArgs) Handles Me.Enter
        NumRecsWithAmts = 0
        SQLstmt = "XServItems_withAmts" + SParm(bXSVCFILTER.ContractID)
        serr3 = SqlFetch1(c3, SQLstmt, NumRecsWithAmts)
        Call MessBox(NumRecsWithAmts, 48, "")
    End Sub


End Class