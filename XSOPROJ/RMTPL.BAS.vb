Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports VB = Microsoft.VisualBasic
Module RMRTPL
    Private Class RMRNbr
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
        > _
        Public Property Last() As String

            Get
                Return Me.GetPropertyValue("Last")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Last", setval)
            End Set

        End Property
    End Class
    Private bRMRNbr As RMRNbr = New RMRNbr, nRMRNbr As RMRNbr = New RMRNbr
    'mod 2/7/15
    Private Class ServItemDescr
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=60) _
        > _
        Public Property Descr() As String

            Get
                Return Me.GetPropertyValue("Descr")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Descr", setval)
            End Set

        End Property
    End Class
    Private bServItemDescr As ServItemDescr = New ServItemDescr
    Public CSR_xrmrHdr, CSR_xrmrLine, CSR_xrmrTPLHdr, CSR_xrmrTPLLine As Short
    Dim SQLstmt As String
    Sub doRMRProcess()
        Dim dat As Integer, Datstr As String, i As Short, Linenbr As Short = IntMin
        SQLstmt = "xrmrtplhdr_all" + SParm(bpes.UserId)
        serr7 = SqlFetch1(CSR_xrmrTPLHdr, SQLstmt, bxRmrtplhdr)
        'mod 6/6/14

        GetNextRMANbr()
        With bxRmrhdr
            .BillFrequency = bxRmrtplhdr.BillFrequency
            .BMContractValue = bxRmrtplhdr.BMContractValue
            .ContractDuration = bxRmrtplhdr.ContractDuration
            .CustID = bPJPROJ.customer
            GetSysDate(bxRmrhdr.crtd_datetime)
            .crtd_prog = "XSOPROJ"
            .crtd_user = bpes.UserId
            .Evergreen = bxRmrtplhdr.Evergreen  'mod 5/8/14
            .lupd_datetime = .crtd_datetime
            .lupd_user = .crtd_user
            .lupd_prog = .crtd_prog
            .Project = bPJPROJ.project
            .RMRAmt = bxRmrtplhdr.RMRAmt
            .RMREscPct = 9
            .RMRPriceEsc = "Y"
            .Status = "BAC"
            GetSysDate(dat)
            Datstr = DateToStr(dat)
            .OrigBACPeriod = VB.Right(Datstr, 4) & VB.Left(Datstr, 2)
            .WarrantyDuration = bXPROJEX.user2 'mod 4/24/15
        End With
        Call SUpdate1(CSR_xrmrHdr, "XRMRHDR", bxRmrhdr)

        SQLstmt = "xrmrtplline_all" + SParm(bpes.UserId) + IParm(IntMin) + IParm(IntMax)
        serr8 = SqlFetch4(CSR_xrmrTPLLine, SQLstmt, bxRmrtplline, bServItemDescr, PNULL, PNULL)  'mod 2/7/15  added description from xserviceitems
        Do While serr8 = 0
            bxRmrline.CopyClass(nxRmrline)
            With bxRmrline
                .crtd_datetime = bxRmrhdr.crtd_datetime
                .crtd_user = bpes.UserId
                .crtd_prog = "XSOPROJ"
                .Evergreen = 1
                i += 1
                .LineItem = bxRmrhdr.RMRNbr.Trim + "-" + CStr(i)
                .Linenbr = Linenbr
                Linenbr += 256
                .lupd_datetime = bxRmrhdr.lupd_datetime
                .lupd_user = bpes.UserId
                .lupd_prog = "XSOPROJ"
                .MonthAmt = bxRmrtplline.MonthAmt
                .ContractAmt = bxRmrtplline.ContractAmt
                .Project = bxRmrhdr.Project

                .RMRNbr = bxRmrhdr.RMRNbr
                .ServItemID = bXRMRTPLLINE.ServItemID    'mod 9/21/16 should never have blanked this out
                .SiteID = bxRmrhdr.SiteID
                .Status = "BAC"
                .StartPeriod = bxRmrtplline.StartPeriod
                .UseDefaults = bxRmrtplline.UseDefaults
                If .UseDefaults = 0 Then
                    .ContractDuration = bxRmrtplline.ContractDuration
                    .StartPeriod = bxRmrtplline.StartPeriod
                    .RMREscPct = bxRmrtplline.RMREscPct
                End If
                'mod 5/18/16
                .S4Future02 = bXRMRTPLLINE.SystemType
                .S4Future12 = bXRMRTPLLINE.ServBillID
            End With
            Call SInsert1(CSR_xrmrLine, "XRMRLINE", bxRmrline)
            serr8 = SFetch4(CSR_xrmrTPLLine, bxRmrtplline, bServItemDescr, PNULL, PNULL)
        Loop
    End Sub
    Private Sub GetNextRMANbr()
        Call SqlErrException(EXCEPTION_ON, DUPLICATE)
        SQLstmt = "xrmrtpl_getLastrmrnbr"
        serr9 = SqlFetch1(c1, SQLstmt, bRMRNbr)
        If serr9 Then
            bRMRNbr.Last = "0000000000"
        End If
        bxRmrhdr.CopyClass(nxRmrhdr)
        Do
            Call IncrStrg(bRMRNbr.Last, 10, 1)
            bxRmrhdr.RMRNbr = bRMRNbr.Last
            bxRmrhdr.Project = bPJPROJ.project
            bxRmrhdr.SiteID = bxCustSites.SiteID
            bxRmrhdr.CustID = bPJPROJ.customer
            Call SInsert1(CSR_xrmrHdr, "XRMRHDR", bxRmrhdr)
        Loop While SqlErr() = DUPLICATE
        Call SqlErrException(EXCEPTION_OFF, DUPLICATE)
        'to avoid err 226
        SQLstmt = "xrmrhdr_all" + SParm(bPJPROJ.project) + SParm(bxRmrhdr.RMRNbr)
        serr5 = SqlFetch1(CSR_xrmrHdr, SQLstmt, bxRmrhdr)
    End Sub
End Module
