Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports VB = Microsoft.VisualBasic
Module ORDTPL

    Public CSR_xORDTPL As Short, CSR_XCONTACTS As Short
    Public CSR_xProjex, CSR_PJProj As Short, CSR_PJCont As Short, CSR_PJAddr As Short, CSR_PJProjEDD As Short

    Dim SQLstmt As String
    Sub doORDProcess()

        'compile cursor
        Call sql(CSR_XCONTACTS, "select top 1 *  from XCONTACTS")
        Call sql(CSR_PJAddr, "select top 1 *  from PJADDR")
        Call sql(CSR_PJProjEDD, "select top 1 * from PJPROJEDD")
        SQLstmt = "xORDTPL_ALL" + SParm(bpes.UserId)
        serr5 = SqlFetch1(c5, SQLstmt, bxOrdtpl)
        If serr5 = 0 Then 'and it should be based upon count stmt in main
            bxProjex.ProposalDate = bxOrdtpl.Proposaldate
            bxProjex.SignDate = bxOrdtpl.SignDate
            bxProjex.OrderRcvdDate = bxOrdtpl.OrderRcvdDate
            If DateCmp(bxOrdtpl.BookedDate, NULLDATE) <> 0 Then bxProjex.BookedDate = bxOrdtpl.BookedDate
            bxProjex.CustExpSDate = bxOrdtpl.CustExpSDate
            bxProjex.CustExpCDate = bxOrdtpl.CustExpCDate
            If Not (iSDSS) Then  'mod 10/18/18
                bPJPROJ.contract = bXORDTPL.Contract
                If bPJPROJ.contract.Trim > "" Then
                    SQLstmt = "pjcont_sall" + SParm(bPJPROJ.contract)
                    serr6 = SqlFetch1(CSR_PJCont, SQLstmt, bPJCONT)
                    If serr6 Then
                        bPJCONT.crtd_datetime = bPJPROJ.crtd_datetime
                        bPJCONT.crtd_prog = bPJPROJ.crtd_prog
                        bPJCONT.crtd_user = bPJPROJ.crtd_user
                        bPJCONT.lupd_datetime = bPJPROJ.lupd_datetime
                        bPJCONT.lupd_prog = bPJPROJ.lupd_prog
                        bPJCONT.lupd_user = bPJPROJ.lupd_user
                        bPJCONT.contract = bPJPROJ.contract
                        bPJCONT.contract_desc = bCustomer.Name
                        Call SInsert1(CSR_PJCont, "PJCONT", bPJCONT)
                    End If
                End If
            End If
            bPJPROJ.purchase_order_num = bXORDTPL.PONbr
            bXPROJEX.ProductType = bXORDTPL.ProductType
            bXPROJEX.InstallType = bXORDTPL.InstallType
            bPJPROJ.pm_id01 = bXORDTPL.EndUserID
            bPJPROJ.pm_id02 = bXORDTPL.BMQuoteID
            If bXORDTPL.Slsman1.Trim > "" Then bPJPROJ.slsperid = bXORDTPL.Slsman1
            If bXORDTPL.Slsman1Pct <> 0 Then bPJPROJ.pm_id07 = bXORDTPL.Slsman1Pct
            If bXORDTPL.Slsman2.Trim > "" Then bPJPROJ.user1 = bXORDTPL.Slsman2
            If bXORDTPL.Slsman2Pct <> 0 Then bPJPROJ.pm_id38 = bXORDTPL.Slsman2Pct
            If bXORDTPL.Slsman3.Trim > "" Then bXPROJEX.Slsman3 = bXORDTPL.Slsman3
            If bXORDTPL.Slsman3Pct <> 0 Then bXPROJEX.Slsman3Pct = bXORDTPL.Slsman3Pct
            If bXORDTPL.Slsman4.Trim > "" Then bXPROJEX.Slsman4 = bXORDTPL.Slsman4
            If bXORDTPL.Slsman4Pct <> 0 Then bXPROJEX.Slsman4Pct = bXORDTPL.Slsman4Pct

            Dim totpct As Double = 100

            totpct = FPSub(totpct, bPJPROJ.pm_id07, 2)

            If bPJPROJ.pm_id38 > totpct Then
                bPJPROJ.pm_id38 = totpct
                bXPROJEX.Slsman3Pct = 0
                bXPROJEX.Slsman4Pct = 0
                totpct = 0
            Else
                totpct = FPSub(totpct, bPJPROJ.pm_id38, 2)
            End If
            If bXPROJEX.Slsman3Pct > totpct Then
                bXPROJEX.Slsman3Pct = totpct
                bXPROJEX.Slsman4Pct = 0
                totpct = 0
            Else
                totpct = FPSub(totpct, bXPROJEX.Slsman3Pct, 2)
            End If
            If bXPROJEX.Slsman4Pct > totpct Then
                bXPROJEX.Slsman4Pct = totpct
            End If

            'mod 8/11/14
            bXPROJEX.JobType = bXORDTPL.JobType
            bXPROJEX.SystemType = bXORDTPL.SystemType

            If bXORDTPL.NoteId > 0 Then
                bPJPROJ.noteid = NoteCopy(bXORDTPL.NoteId, "PJPROJ")
            End If

            'mod 1/23/15
            bXPROJEX.BillTerms = bXORDTPL.BillTerms
            If Not (iSDSS) Then bPJPROJ.contract_type = bXORDTPL.Contract_type '&&&&
            bXPROJEX.DelivTerms = bXORDTPL.DelivTerms

            'moved call to this sub before pjproj and xprojex are inserted
            '  Call SUpdate1(CSR_PJProj, "PJPROJ", bPJPROJ)
            ' Call SUpdate1(CSR_xProjex, "XPROJEX", bxProjex)

            If bXORDTPL.ContactName.Trim <> "" Then
                bxContacts.ContactType = "INSTALL"
                bxContacts.Name = bXORDTPL.ContactName
                bxContacts.EmailAddr = bXORDTPL.ContactEmail
                bxContacts.PhoneMain = bXORDTPL.ContactPhone
                bxContacts.crtd_datetime = bPJPROJ.crtd_datetime
                bxContacts.crtd_user = bPJPROJ.crtd_user
                bxContacts.crtd_prog = bPJPROJ.crtd_prog
                bxContacts.lupd_datetime = bPJPROJ.lupd_datetime
                bxContacts.lupd_user = bPJPROJ.lupd_user
                bxContacts.lupd_prog = bPJPROJ.lupd_prog
                bxContacts.Project = bPJPROJ.project
                Call SInsert1(CSR_XCONTACTS, "XCONTACTS", bxContacts)
            End If
            'mod 7/7/15
            With bPJADDR
                .addr_key_cd = "PR"
                .addr_key = bPJPROJ.project
                .addr_type_cd = "BI" 'mod 7/5/15 "PR"
                .comp_name = bXORDTPL.BillCpnyName
                .individual = bXORDTPL.BillFirstName.Trim + " " + bXORDTPL.BillLastName.Trim
                .addr1 = bXORDTPL.BillAddr1
                .addr2 = bXORDTPL.BillAddr2
                .phone = bXORDTPL.BillPhone
                .fax = bXORDTPL.BillFax
                .email = bXORDTPL.BillEmail
                .city = bXORDTPL.BillCity
                .state = bXORDTPL.BillState
                .zip = bXORDTPL.BillZip
                .crtd_datetime = bPJPROJ.crtd_datetime
                .crtd_user = bPJPROJ.crtd_user
                .crtd_prog = bPJPROJ.crtd_prog
                .lupd_datetime = bPJPROJ.lupd_datetime
                .lupd_user = bPJPROJ.lupd_user
                .lupd_prog = bPJPROJ.lupd_prog
                Call SInsert1(CSR_PJAddr, "PJADDR", bPJADDR)
            End With
            'pjprojedd

            If bXORDTPL.QSOpt = "Y" Then
                Call sql(c9, SQLstmt)
                With bPJProjEDD
                    .Project = bPJPROJ.project
                    .DocType = "P1"
                    .EDD = "1"
                    .DeliveryMethod = "E"
                    .Priority = "N"
                    .RequestorsEmail = bXORDTPL.QSEmail
                    .EmailFileType = "0"
                    .Crtd_DateTime = bPJPROJ.crtd_datetime
                    .Crtd_Prog = bPJPROJ.crtd_prog
                    .Crtd_User = bPJPROJ.crtd_user
                    .LUpd_DateTime = bPJPROJ.lupd_datetime
                    .LUpd_Prog = bPJPROJ.lupd_prog
                    .LUpd_User = bPJPROJ.lupd_user
                    .FaxComment = "0"
                    .FaxCover = "0"
                    .FaxRecycle = "0"
                    .FaxReply = "0"
                    .FaxReview = "0"
                    .FaxUrgent = "0"
                    'mod 10/13/15
                    .SubjectText = "Securitas ES Invoice"
                    .BodyText = "Hello <Customer Name>, Invoice # <Reference Number>, Amount <Document Amount>.  Have a nice day."
                    Call SInsert1(CSR_PJProjEDD, "PJPROJEDD", bPJProjEDD)
                End With
            End If

        End If
    End Sub
End Module