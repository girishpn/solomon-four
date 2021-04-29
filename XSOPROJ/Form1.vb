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
Imports VB = Microsoft.VisualBasic
Imports Solomon.Kernel
Friend Class Form1
    Inherits System.Windows.Forms.Form

    Protected m_IsInitializing As Boolean
    Protected ReadOnly Property IsInitializing() As Boolean
        Get
            Return m_IsInitializing
        End Get
    End Property
    Private Class Misc
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
    Private bMisc As Misc = New Misc, nMisc As Misc = New Misc
    Private Class Roles
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=60) _
        > _
        Public Property RoleID() As String

            Get
                Return Me.GetPropertyValue("RoleID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("RoleID", setval)
            End Set

        End Property
        < _
    DataBinding(PropertyIndex:=1, StringSize:=10) _
    > _
    Public Property Employee() As String

            Get
                Return Me.GetPropertyValue("Employee")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Employee", setval)
            End Set

        End Property
    End Class
    Private bRoles As Roles = New Roles, nroles As Roles = New Roles

    Private Class BranchSub
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=24) _
        > _
        Public Property Subacct() As String

            Get
                Return Me.GetPropertyValue("Subacct")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Subacct", setval)
            End Set

        End Property
    End Class
    Private bBranchSub As BranchSub = New BranchSub, nBranchSub As BranchSub = New BranchSub

    'CSR_PJPROJ AND csr_XPROJEX declared as Public in ORDTPL.BAS
    Private bPJPROJ1 As PJPROJ = New PJPROJ, nPJPROJ1 As PJPROJ = New PJPROJ
    Private bPJPENT1 As PJPENT = New PJPENT, nPJPENT1 As PJPENT = New PJPENT
    Public bPJPROJEX1 As PJPROJEX = New PJPROJEX, nPJPROJEX1 As PJPROJEX = New PJPROJEX
    Public bPJPROJEM1 As PJPROJEM = New PJPROJEM, nPJPROJEM1 As PJPROJEM = New PJPROJEM
    Dim TemplateID As String, SQLstmt As String, Prog As String, UserID As String, CurDate As Integer
    Dim CustSite As String, ProjName As String
    Dim CSR_PJcode As Short, CSR_PJprojex, CSR_PJprojem, CSR_PJpent As Short
    Dim CSR_PJpentex, CSR_PJBill, CSR_xCustSites As Short, CSR_Xprojadd As Short 'mod 9/11/16 sqlcursorex/sqlfree used if xordtpl.mastercontractid >""
    Dim ContCntr As String, SiteCntr As Integer, CtrChk As Integer, FirstProj As String = ""
    Dim CallStatus As Boolean = True  'mod 7/27/14
    'mod 4/15/15 recompiled only as changed XBUDGTPL structure
    Dim CSR_Roles As Short 'mod 6/26/15


    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'mod 1/21/16 changing acct 315000 to 300001
        'mod 1/28/17 -- recompiled because of XSUS fields added to sprojadd
        Dim Numrecs As Integer, NumFound As Integer, Numchks As Integer, Passit As String = ""

        ' Initialize the application as a Solomon Application
        Call ApplInit()

        Call SqlCursorEx(CSR_PJcode, NOLEVEL, "CSR_PJcode", "PJcode", "PJcode")
        Call SqlCursorEx(CSR_PJProj, NOLEVEL, "CSR_PJproj", "PJproj", "PJproj")
        Call SqlCursorEx(CSR_PJprojex, NOLEVEL, "CSR_PJprojex", "PJprojex", "PJprojex")
        Call SqlCursorEx(CSR_PJprojem, NOLEVEL, "CSR_PJprojem", "PJprojem", "PJprojem")
        Call SqlCursorEx(CSR_PJpent, NOLEVEL, "CSR_PJPent", "PJPent", "PJPent")
        Call SqlCursorEx(CSR_PJpentex, NOLEVEL, "CSR_PJPentex", "PJPentex", "PJPentex")
        Call SqlCursorEx(CSR_xProjex, NOLEVEL, "CSR_xProjex", "xProjex", "xProjex")
        Call SqlCursorEx(CSR_PJBill, NOLEVEL, "CSR_PJBill", "PJBill", "PJBill")
        Call SqlCursorEx(CSR_xCustSites, NOLEVEL, "CSR_xCustSites", "xCustSites", "xCustSites")
        Call SqlCursorEx(CSR_xrmrHdr, NOLEVEL, "CSR_xrmrhdr", "xrmrhdr", "xrmrhdr")
        Call SqlCursorEx(CSR_xrmrLine, NOLEVEL, "CSR_xrmrline", "xrmrline", "xrmrline")
        Call SqlCursorEx(CSR_xrmrTPLHdr, NOLEVEL, "CSR_xrmrTPLHdr", "xrmrTPLHdr", "xrmrTPLHdr")
        Call SqlCursorEx(CSR_xrmrTPLLine, NOLEVEL, "CSR_xRMRTPLLine", "xRMRTPLLine", "xRMRTPLLine")
        'added 7/4/14
        Call SqlCursorEx(CSR_PJRevHdr, NOLEVEL, "CSR_PJRevHdr", "PJRevHdr", "PJRevHdr")
        Call SqlCursorEx(CSR_PJRevTsk, NOLEVEL, "CSR_PJRevTsk", "PJRevTsk", "PJRevTsk")
        Call SqlCursorEx(CSR_PJRevCat, NOLEVEL, "CSR_PJRevCat", "PJRevCat", "PJRevCat")
        'added 7/12/14
        Call SqlCursorEx(CSR_XCONTACTS, NOLEVEL, "CSR_XCONTACTS", "XCONTACTS", "XCONTACTS")
        Call SqlCursorEx(CSR_PJCont, NOLEVEL, "CSR_PJCONT", "PJCONT", "PJCONT")
        'mod 6/26/15
        Call SqlCursorEx(CSR_Roles, NOLEVEL + SqlFastReadOnly, "CSR_roles", "bRoles", "")
        'mod 7/7/15
        Call SqlCursorEx(CSR_PJAddr, NOLEVEL, "CSR_PJAddr", "PJAddr", "PJAddr")
        Call SqlCursorEx(CSR_PJProjEDD, NOLEVEL, "CSR_PJProjEDD", "PJProjEDD", "PJProjEDD")
        'mod 12/3/16
        Call SqlCursorEx(CSR_XPROJINV, NOLEVEL, "CSR_Xprojinv", "xprojinv", "xprojinv")

        'getting template and the custid
        ' Call the screen init function
        TemplateID = ApplGetParms().Trim
        'TemplateID = "CO123002"
        '  TemplateID = "C999999999" '&&&
        If TemplateID = "" Then
            Call MessBox("No template ID passed to program", 48, "SOProj Message")
            Call ScreenExit("", "")
        Else
            SQLstmt = "pjproj_sall" + SParm(TemplateID)
            serr1 = SqlFetch1(c1, SQLstmt, bPJPROJ)
            If serr1 = NOTFOUND Then
                Call MessBox("Unable to find Template ID", 48, "SOProj Message")
                Call ScreenExit("", "")
            End If
        End If
        bCustomer.CustId = Trim(ApplGetParms())
        '  bCustomer.CustId = "0002" '&&& 
        'bCustomer.CustId = "C315"
        ProjName = Trim(ApplGetParms())
        'ProjName = "   "
        'mod 7/27/14
        If ProjName = "XBMUPLD" Then
            CallStatus = False
            ProjName = ""
        End If


        ContCntr = Trim(ApplGetParms())
        'ContCntr = "   "

        'MOD 10/18/18

        DSS = Val(ApplGetParms().Trim)
        'DSS = 0 '&&&
        iSDSS = Convert.ToBoolean(DSS)

        SQLstmt = "Customer_all" + SParm(bCustomer.CustId)
        serr1 = SqlFetch1(c1, SQLstmt, bCustomer)

        'Editing
        Numrecs = 0
        SQLstmt = "select count(*) from sysobjects where id = object_id('dbo.xSOProj_DupChk')"
        Call sql(c2, SQLstmt)
        serr2 = SGroupFetch1(c2, Numrecs)
        If Numrecs = 0 Then
            Call MessBox("Unable to find stored proc 'xSOPROJ_DupChk'", 48, "SOProj Message")
            Call ScreenExit("", "")
        Else
            Numrecs = 0
            SQLstmt = "select count(*) from sysobjects where id = object_id('dbo.xcustomer_all')"
            Call sql(c2, SQLstmt)
            serr2 = SGroupFetch1(c2, Numrecs)
            If Numrecs = 0 Then
                Call MessBox("Unable to find stored proc 'xSOPROJ_DupChk'", 48, "SOProj Message")
                Call ScreenExit("", "")
            End If
        End If

        getCRTD()

        If ContCntr.Trim > "" Then  'user wants to continue with an existing pjcode 0typ.
            SQLstmt = "xOpenContracts_LastSite" + SParm(bCustomer.CustId) + SParm(ContCntr)
            serr1 = SqlFetch1(c1, SQLstmt, SiteCntr)
            'now make sure there are no duplicates for that next sitecntr
            CtrChk = SiteCntr + 1
            Passit = ContCntr + Format(CtrChk, "000") + "%"
            NumFound = 0
            SQLstmt = "xsoproj_DupChk" + SParm(Passit)
            Call sql(c2, SQLstmt)
            serr2 = SGroupFetch1(c2, NumFound)

            If NumFound Then
                Call MessBox("One or more project tables contains the next site counter for contract " + SParm(ContCntr), 48, "SOProj Message")
                Call ScreenExit("", "")
            End If
        Else
            Numchks = 0
            SQLstmt = "PJcode_Spk0" + SParm("0TYP") + SParm("C")
            serr1 = SqlFetch1(CSR_PJcode, SQLstmt, bPJCODE)
            If serr1 = NOTFOUND Then
                Call MessBox("Unable to find a non existent Counter for ProjectID in PJCODE - '0TYP' - Commercial", 48, "SOProj Message")
                Call ScreenExit("", "")
            End If

            Call TranBeg(True)
            NumFound = 1
            ' Do Until NumFound = 0  mod 4/16/14
            Do Until Numchks = 200
                Numchks += 1
                SQLstmt = "PJcode_Spk0" + SParm("0TYP") + SParm("C")
                serr1 = SqlFetch1(CSR_PJcode, SQLstmt, bPJCODE)
                Call IncrStrg(bPJCODE.data1, 7, 1)
                'mod 4/24/17
                If InStr(UCase(bpes.DBName), "CANADA") Then
                    Passit = "J" + VB.Left(bPJCODE.data1, 7) + "%"
                Else
                    Passit = "C" + VB.Left(bPJCODE.data1, 7) + "%"
                End If
                SQLstmt = "xsoproj_DupChk" + SParm(Passit)
                Call sql(c2, SQLstmt)
                serr2 = SGroupFetch1(c2, NumFound)
                bPJCODE.lupd_user = UserID
                bPJCODE.lupd_datetime = CurDate
                bPJCODE.lupd_prog = Prog
                Call SUpdate1(CSR_PJcode, "PJcode", bPJCODE)
                If NumFound = 0 Then Exit Do 'mod 4/16/14
            Loop

            Call TranEnd()
            If Numchks = 200 Then
                Call TranAbort()
                Call MessBox("Unable to find a non duplicate project for code type '0TYP' Commercial - " + vbCrLf + "After 200 attempts.  Last Search =" + SParm(bPJCODE.data1.Trim), 48, "SOProj Message")
                Call ScreenExit("", "")
            End If
            SiteCntr = 0
            'mod 4/25/17
            If InStr(UCase(bpes.DBName), "CANADA") Then
                ContCntr = "J" + bPJCODE.data1.Trim
            Else
                ContCntr = "C" + bPJCODE.data1.Trim
            End If
        End If

        SQLstmt = "xcustomer_all" + SParm(bCustomer.CustId)
        serr2 = SqlFetch1(c2, SQLstmt, bXCUSTOMER)

        Call ScreenInit()

        CreateProjects()
        Call ScreenExit(APPLICRETURNPARMS, "1" + FirstProj)  '=Success  

    End Sub
    Sub CreateProjects()
        Dim Numrecs As Integer = 0

        If CallStatus Then Call Status(StartProcess, False, "", 0)
        Call TranBeg(True)
        Call sql(CSR_PJproj, "select top 1 * from pjproj")
        Call sql(CSR_PJprojex, "select top 1 * from pjprojex")
        Call sql(CSR_PJprojem, "select top 1 * from pjprojem")
        Call sql(CSR_PJpent, "select top 1 * from pjpent")
        Call sql(CSR_PJpentex, "select top 1 * from pjpentex")
        Call sql(CSR_PJBill, "select top 1 * from pjbill")
        Call sql(CSR_xprojex, "select top 1 * from xprojex")
        Call sql(CSR_xrmrHdr, "select top 1 * from xrmrhdr")
        Call sql(CSR_xrmrLine, "select top 1 * from xrmrline")
        Call sql(CSR_PJProjEDD, "select top 1 * from PJPROJEDD")
        'get the template   
        SQLstmt = "pjproj_sall" + SParm(TemplateID)
        serr1 = SqlFetch1(c1, SQLstmt, bPJPROJ1)
        'copy template
        SQLstmt = "xcustsites_all" + SParm(bpes.UserId)
        serr1 = SqlFetch1(CSR_xCustSites, SQLstmt, bxCustSites)

        Do While serr1 = 0
            'mod 8/4/18           
            ' If Not (IsDSS) Then 'MOD 10/18/18, mod 10/19/18 need the zip for the DSS project
            SQLstmt = "soaddress_custid_shiptoid" + SParm(bCustomer.CustId) + SParm(bxCustSites.SiteID)
            serr3 = SqlFetch1(c3, SQLstmt, bSOAddress)
            If Not (iSDSS) Then 'MOD 10/18/18
                'is bsoaddress.zip in smareazips
                Numrecs = 0
                'mod 8/15/18 for Canada
                If InStr(UCase(bpes.DBName), "CANADA") Then
                    SQLstmt = "select count(*) from smareazips where areazipcode = " + SParm(VB.Left(bSOAddress.Zip, 3))
                Else
                    SQLstmt = "select count(*) from smareazips where areazipcode = " + SParm(bSOAddress.Zip)
                End If
                serr10 = SqlFetch1(c10, SQLstmt, Numrecs)
            End If

            If Not (iSDSS) And (bSOAddress.Zip.Trim = "" Or Numrecs = 0) Then
                Call MessBox("PROJECT NOT created for SITEID" + SParm(bxCustSites.SiteID.Trim) + vbCrLf + "as ZIPCODE " + SParm(bSOAddress.Zip.Trim) + " is not assigned to a GEOCODE", 48, "Project Create Template Msg")
                Call Status(SaveGoodArgVals, False, vbCrLf, DISP_ONLY)  'to skip a line in process status msgs
                'need to delete as 40.100.00 checks for any xcustsites without assigned projects.  If found - aborts process.
                SQLstmt = "delete from xcustsites where siteid = " + SParm(bxCustSites.SiteID) + " and userid = " + SParm(bpes.UserId)
                Call sql(c12, SQLstmt)
                ' Call TranAbort()
            Else
                Numrecs = 0
                SiteCntr += 1
                bPJPROJ.CopyClass(bPJPROJ1)
                '    If CallStatus Then Call Status(SaveGoodArgVals, False, "Creating project " + SParm(bPJPROJ.project), DISP_ONLY) 'mod 7/27/14
                CustSite = VB.Left(bxCustSites.SiteID, 2)

                '***PJPROJ
                GetProjectID()
                If FirstProj.Trim = "" Then
                    FirstProj = bPJPROJ.project   'mod 12/11/13
                End If
                If CallStatus Then Call Status(SaveGoodArgVals, False, "Creating project " + SParm(bPJPROJ.project), DISP_ONLY) 'mod 7/27/14

                bPJPROJ.crtd_datetime = CurDate
                bPJPROJ.crtd_prog = Prog
                bPJPROJ.crtd_user = UserID
                '   bPJPROJ.CuryId = bpes.BaseCuryID  'mod 8/31/17 take from projtemplate
                bPJPROJ.customer = bCustomer.CustId
                bPJPROJ.lupd_datetime = CurDate
                bPJPROJ.lupd_prog = Prog
                bPJPROJ.lupd_user = UserID

                bPJPROJ.status_pa = "A"  'otherwise it's a template
                bPJPROJ.shiptoid = bxCustSites.SiteID
                bPJPROJ.pm_id04 = "01"  'project status field
                ''mod 1/24/14
                If bXCUSTOMER.InvFmt.Trim = "D2" Then
                    bPJPROJ.status_16 = "B"
                Else
                    ' bPJPROJ.status_16 = "S"
                    'mod 2/4/14
                    bPJPROJ.status_16 = "O"
                End If
                bPJPROJ.status_19 = "1" 'mod 1/24/14
                'mod 3/18/16 fields added in SL2015
                ' bPJPROJ.ProjCuryId = bpes.BaseCuryID  mod 8/31/17 take from proj template
                bPJPROJ.ProjCuryBudEffDate = bPJPROJ.lupd_datetime
                bPJPROJ.ProjCuryRevenueRec = "B"
                bPJPROJ.ProjCuryBudMultiDiv = "M"
                ' bPJPROJ.billcuryid = bpes.BaseCuryID 'mod 8/31/17 take from proj template

                '***PJPROJEX
                SQLstmt = "pjprojex_sall" + SParm(TemplateID)
                serr2 = SqlFetch1(c2, SQLstmt, bPJPROJEX1)
                bPJPROJEX.CopyClass(bPJPROJEX1)
                bPJPROJEX.project = bPJPROJ.project
                bPJPROJEX.crtd_datetime = CurDate
                bPJPROJEX.crtd_prog = Prog
                bPJPROJEX.crtd_user = UserID
                bPJPROJEX.lupd_datetime = CurDate
                bPJPROJEX.lupd_prog = Prog
                bPJPROJEX.lupd_user = UserID

                bPJPROJEX.pm_id13 = "EATY"         'mod 8/3/17 mod 8/31/17 temporarily comment out needed change until users test it - mod 1/5/17 reinstated 8/3/17 code

                'mod 11/30/13
                If bPJPROJ.contract_type.Trim = "PB" Then
                    ' bPJPROJEX.pm_id13 = "EATY" ' mod 8/3/17 to comment out   'mod 8/3/17 mod 8/31/17 temporarily comment out needed change until users test it - mod 1/5/17 reinstated 8/3/17 code
                    bPJPROJEX.rev_type = "PC"
                    bPJPROJEX.entered_pc = 0
                End If

                'mod 10/18/18
                If iSDSS Then
                    bPJPROJ.contract = ""
                    bPJPROJ.contract_type = "DSS"
                    bPJPROJEX.rev_type = " "
                    bPJPROJ.alloc_method_cd = ""
                End If

                If Trim$(bPJPROJ.contract_type) = "DSS" Then '2/19/2019 Set Rev_Flag to Blank where PJPROJ.Contract_Type = 'DSS' and REV_FLAG = 'Y'
                    bPJPROJEX.rev_flag = ""                  '2/19/2019 Set Rev_Flag to Blank where PJPROJ.Contract_Type = 'DSS' and REV_FLAG = 'Y'
                End If                                       '2/19/2019 Set Rev_Flag to Blank where PJPROJ.Contract_Type = 'DSS' and REV_FLAG = 'Y'

                Call SInsert1(CSR_PJprojex, "pjprojex", bPJPROJEX)
                'moved pjprojem to role section
                '*** XPROJEX
                bXPROJEX.CopyClass(nXPROJEX)
                bXPROJEX.Project = bPJPROJ.project
                bXPROJEX.crtd_datetime = CurDate
                bXPROJEX.crtd_prog = Prog
                bXPROJEX.crtd_user = UserID
                bXPROJEX.lupd_datetime = CurDate
                bXPROJEX.lupd_prog = Prog
                bXPROJEX.lupd_user = UserID
                'bxProjex.CCMF = bxCustomer.CCMF  mod 5/29/14 assign based upon soaddress.user1 below
                bXPROJEX.BillTerms = bXCUSTOMER.BillTerms
                bXPROJEX.ClassID = bCustomer.ClassId
                bXPROJEX.Site = bPJPROJ.shiptoid   'based upon bxcustsites.siteid

                'mod 5/5/14, mod 5/20/14
                If bXCUSTOMER.InstallCoord.Trim > "" Then
                    bPJPROJ.manager2 = bXCUSTOMER.InstallCoord
                    InsertPJPROJEM(bPJPROJ.manager2)
                End If
                If bXCUSTOMER.ProjectMgr.Trim > "" Then
                    bPJPROJ.manager1 = bXCUSTOMER.ProjectMgr
                    InsertPJPROJEM(bPJPROJ.manager1)
                End If
                If bXCUSTOMER.RegionDir.Trim > "" Then
                    bXPROJEX.RegionDir = bXCUSTOMER.RegionDir
                    InsertPJPROJEM(bXPROJEX.RegionDir)
                End If

                'SQLstmt = "soaddress_custid_shiptoid" + SParm(bCustomer.CustId) + SParm(bxCustSites.SiteID)
                'serr3 = SqlFetch1(c3, SQLstmt, bSOAddress)

                bXPROJEX.CCMF = bSOAddress.User1 'mod 5/29/14

                'sls reps and commissions%
                bPJPROJ.slsperid = bXCUSTOMER.Slsman1
                'mod 7/13/14
                bPJPROJ.pm_id07 = bXCUSTOMER.Slsman1Pct
                bPJPROJ.user1 = bXCUSTOMER.Slsman2
                bPJPROJ.pm_id38 = bXCUSTOMER.Slsman2Pct
                bXPROJEX.Slsman3 = bXCUSTOMER.Slsman3
                bXPROJEX.Slsman3Pct = bXCUSTOMER.Slsman3Pct
                bXPROJEX.Slsman4 = bXCUSTOMER.Slsman4
                bXPROJEX.Slsman4Pct = bXCUSTOMER.Slsman4Pct

                If Not (iSDSS) Then
                    'mod 3/16/17 re: canadian change
                    If InStr(UCase(bpes.DBName), "CANADA") Then  'mod 7/19/17
                        SQLstmt = "xEntityZip_CanadaZip" + SParm(VB.Left(bSOAddress.Zip, 3))
                    Else
                        SQLstmt = "xentityzip_zip" + SParm(bSOAddress.Zip)
                    End If
                    serr3 = SqlFetch1(c3, SQLstmt, bxEntityzip)
                End If
                If Not (iSDSS) And serr3 Then
                    If CallStatus Then Call Status(SaveGoodArgVals, False, "For Project: " + SParm(bPJPROJ.project.Trim) + " unable to find soaddress.zipcode of  " + SParm(bSOAddress.Zip.Trim) + " in table xEntityZip", LOG_AND_DISP)
                Else
                    'MOD 10/18/18
                    If iSDSS Then
                        'bXPROJEX.Zip = bxEntityzip.ZipID
                        bXPROJEX.Branch = "SES-DSS"
                        bXPROJEX.Region = "DT03"
                        bXPROJEX.Area = "NORTHEAST"
                        bXPROJEX.Zip = bSOAddress.Zip 'mod 10/19/18
                        'mod 10/19/18
                        bPJPROJ.gl_subacct = "011050010102002130061"
                    Else
                        bXPROJEX.Zip = bxEntityzip.ZipID
                        bXPROJEX.Branch = bxEntityzip.BranchID
                        bXPROJEX.Region = bxEntityzip.RegionID
                        bXPROJEX.Area = bxEntityzip.AreaID
                        'mod 7/24/18  now comes from smbranch.user1
                        bBranchSub.CopyClass(nBranchSub)
                        SQLstmt = "xsoproj_getSub" + SParm(bXPROJEX.Zip)
                        serr3 = SqlFetch1(c3, SQLstmt, bBranchSub)
                        If serr3 = 0 Then
                            bPJPROJ.gl_subacct = bBranchSub.Subacct
                        End If
                    End If
                    SQLstmt = "xclasstype" + SParm(bCustomer.ClassId)
                    '***select user5 from custclass where ClassId = @Classid
                    serr5 = SqlFetch1(c5, SQLstmt, bMisc)

                    SQLstmt = "XROLES_xSOPROJ" + SParm(bMisc.ID) + SParm(bXPROJEX.Branch) + SParm(bPJPROJ.customer)  'classType mod 1/30/14 - mod 6/22/15 added customer (xroles.user2)

                    serr4 = SqlFetch1(CSR_Roles, SQLstmt, bRoles)
                    Do While serr4 = 0
                        Select Case bRoles.RoleID.Trim
                            ' Case "INSTALL COORD"
                            Case "INSTALL SCHEDULER"  'MOD 10/6/18
                                If bPJPROJ.manager2.Trim = "" Then
                                    bPJPROJ.manager2 = bRoles.Employee 'mod 5/1/14
                                Else
                                    bRoles.Employee = ""  'so wont call InsertPJPROJEM
                                End If
                                ' Case "INSTALL MGR"
                            Case "DISTRICT INSTALL MGR"  'MOD 10/6/18
                                bXPROJEX.InstallMgr = bRoles.Employee
                                'MOD 10/6/18
                                'Case "OPERATIONS MGR"
                                '    bXPROJEX.OperationsMgr = bRoles.Employee
                            Case "PROJECT MGR"  'mod 6/27/15
                                If bXCUSTOMER.ProjectMgr.Trim = "" Then  'initially this is set from the template.  But then it's set by xcutomer.  So if xcustomer blank --then roles
                                    '   If bPJPROJ.manager1.Trim = "" Then
                                    bPJPROJ.manager1 = bRoles.Employee 'mod 5/1/14
                                Else
                                    bRoles.Employee = "" 'so wont call InsertPJPROJEM
                                End If
                                ' Case "REGIONAL DIRECTOR"
                            Case "DISTRICT GNRL MGR"  'MOD 10/6/18
                                If bXPROJEX.RegionDir.Trim = "" Then
                                    bXPROJEX.RegionDir = bRoles.Employee 'mod 5/1/14
                                Else
                                    bRoles.Employee = "" 'so wont call InsertPJPROJEM
                                End If
                        End Select
                        If bRoles.Employee.Trim > "" Then InsertPJPROJEM(bRoles.Employee)
                        serr4 = SFetch1(CSR_Roles, bRoles)
                    Loop
                End If

                'mod 1/30/14
                'assignments for ProgramMgr
                'MOD 6/27/15 added if clause
                If bXCUSTOMER.ProgramMgr.Trim > "" Then
                    bXPROJEX.user7 = bXCUSTOMER.ProgramMgr  'mod 1/30/14
                    InsertPJPROJEM(bXPROJEX.user7)
                End If

                'mod 10/6/18 (sales order support coord)
                ''assignment for sales ord spec
                'SQLstmt = "xSalesOrdSpec" + SParm(bpes.UserId)
                'serr5 = SqlFetch1(c5, SQLstmt, bMisc)
                ''MOD 6/27/15  -- ADDED IF clause
                'If bMisc.ID.Trim > "" Then
                '    bXPROJEX.user8 = bMisc.ID
                '    InsertPJPROJEM(bXPROJEX.user8)
                'End If

                'Mod 10/6/18
                'If bXCUSTOMER.user7.Trim > "" Then
                '    bXPROJEX.FinanceCoord = bXCUSTOMER.user7
                '    InsertPJPROJEM(bXPROJEX.FinanceCoord)
                'End If

                bPJPROJ.project_desc = Trim(VB.Left(bCustomer.Name, 30)) + "-" + bXPROJEX.Branch.Trim + "-" + bSOAddress.City  'mod 11/11
                bXPROJEX.ProjName = ProjName
                bXPROJEX.DelivTerms = "D&I"
                bXPROJEX.BookedDate = CurDate 'mod 12/10/13

                bXORDTPL.CopyClass(nXORDTPL) 'mod 9/11/16
                'moved before xprojex/pjproj gets inserted  
                SQLstmt = "xORDtpl_count" + SParm(bpes.UserId)
                Call sql(c1, SQLstmt)
                serr1 = SGroupFetch1(c1, Numrecs)
                If Numrecs > 0 Then doORDProcess()

                'mod 9/11/16

                If bXORDTPL.MasterContractID.Trim > "" Or bXORDTPL.S4Future09 = 1 Then
                    Call SqlCursor(CSR_Xprojadd, NOLEVEL)
                    Call sql(CSR_Xprojadd, "Select top 1 * from xprojadd") 'compile cursor
                    With bXPROJADD
                        .Crtd_datetime = CurDate
                        .Crtd_user = UserID
                        .Crtd_prog = Prog
                        .Lupd_datetime = CurDate
                        .Lupd_user = UserID
                        .Lupd_prog = Prog
                        .Project = bPJPROJ.project
                        .user11 = bXORDTPL.S4Future09  'do not create service contract mod 10/2/16
                        .MasterContractID = bXORDTPL.MasterContractID 'mod 9/9/16
                        Call SInsert1(CSR_Xprojadd, "XPROJADD", bXPROJADD)
                    End With
                    Call SqlFree(CSR_Xprojadd)
                End If

                'mod 4/29/15
                If bXORDTPL.WarrantyDuration.Trim > "" Then
                    bXPROJEX.user2 = bXORDTPL.WarrantyDuration
                Else
                    bXPROJEX.user2 = bXCUSTOMER.user2 'warrantyduration
                End If

                Call SInsert1(CSR_xProjex, "XPROJEX", bXPROJEX)
                Call SInsert1(CSR_PJProj, "PJPROJ", bPJPROJ)

                '*** PJBILL
                bPJBILL.project = bPJPROJ.project
                bPJBILL.project_billwith = bPJBILL.project
                Select Case Trim(bXCUSTOMER.InvFmt)
                    Case "D1"
                        bPJBILL.inv_format_cd = "PBD1"
                    Case "D2"
                        bPJBILL.inv_format_cd = "PBD2"
                    Case "S1"
                        bPJBILL.inv_format_cd = "PBS1"
                End Select
                bPJBILL.bill_type_cd = "PB"
                bPJBILL.approval_sw = "Y"
                bPJBILL.approver = "HAMB-YOH"
                bPJBILL.biller = bPJBILL.approver
                bPJBILL.crtd_datetime = CurDate
                bPJBILL.crtd_user = UserID
                bPJBILL.crtd_prog = Prog
                bPJBILL.lupd_datetime = CurDate
                bPJBILL.lupd_user = UserID
                bPJBILL.lupd_prog = Prog
                '  bPJBILL.billcuryid = bpes.BaseCuryID
                bPJBILL.billcuryid = bPJPROJ.billcuryid  'mod 8/31/17
                'mod 9/11/16
                bPJBILL.pb_id04 = bXORDTPL.ServBillInvType
                bPJBILL.user1 = bXORDTPL.S4Future11  'mod 10/2/16 Bill Address Type
                ' bPJBILL.user2 = bXORDTPL.BillGroupServMonitor 'mod 10/1/16
                Call SInsert1(CSR_PJBill, "PJBILL", bPJBILL)
                '** PJPENT
                SQLstmt = "Pjpent_sall" + SParm(TemplateID) + SParm(SQLWILDSTRING)
                serr2 = SqlFetch1(c2, SQLstmt, bPJPENT1)
                Do While serr2 = 0
                    bPJPENT.CopyClass(bPJPENT1)
                    bPJPENT.project = bPJPROJ.project
                    bPJPENT.crtd_datetime = CurDate
                    bPJPENT.crtd_user = UserID
                    bPJPENT.crtd_prog = Prog
                    bPJPENT.lupd_datetime = CurDate
                    bPJPENT.lupd_user = UserID
                    bPJPENT.lupd_prog = Prog
                    bPJPENT.pe_id01 = bPJPROJ.gl_subacct 'MOD 10/16/14
                    Call SInsert1(CSR_PJpent, "PJPENT", bPJPENT)
                    '*** PJPENTEX
                    bPJPENTEX.PROJECT = bPJPENT.project
                    bPJPENTEX.PJT_ENTITY = bPJPENT.pjt_entity
                    bPJPENTEX.crtd_datetime = CurDate
                    bPJPENTEX.crtd_user = UserID
                    bPJPENTEX.crtd_prog = Prog
                    bPJPENTEX.lupd_datetime = CurDate
                    bPJPENTEX.lupd_user = UserID
                    bPJPENTEX.lupd_prog = Prog
                    'mod 11/30/13
                    If bPJPROJ.contract_type.Trim = "PB" Then
                        bPJPENTEX.PE_ID20 = 0
                        bPJPENTEX.REVISION_DATE = NULLDATE
                        bPJPENTEX.ENTERED_PC = 0
                        ''mod 2/13/14
                        'If bPJPENTEX.PJT_ENTITY.Trim = "CEQUIPMENT" Then
                        '    bPJPENTEX.PE_ID24 = "300000" '"40014"
                        'Else
                        '    bPJPENTEX.PE_ID24 = "300001" 'mod 1/21/16 "315000" ' "40010"
                        'End If
                    End If  'MOD 10/18/18
                    'mod 8/4/17 forany contract_type(which should only be %complete and comp contract)
                    If Not (iSDSS) Then
                        If bPJPENTEX.PJT_ENTITY.Trim = "CEQUIPMENT" Then
                            bPJPENTEX.PE_ID24 = "300000" '"40014"
                        Else
                            bPJPENTEX.PE_ID24 = "300001" 'mod 1/21/16 "315000" ' "40010"
                        End If
                    End If
                    Call SInsert1(CSR_PJpentex, "pjpentex", bPJPENTEX)
                    serr2 = SFetch1(c2, bPJPENT1)
                Loop
                'only if xcustomer.xx is populated

                If bXORDTPL.QSOpt <> "Y" And bXCUSTOMER.QSEmail.Trim > "" Then  'mod 7/7/15   -- if there's an order default template -- then projedd will be populated there if qsopt = 'Y'
                    With bPJProjEDD
                        .Project = bPJPROJ.project
                        .DocType = "P1"
                        .EDD = "1"
                        .DeliveryMethod = "E"
                        .Priority = "N"
                        .RequestorsEmail = bXCUSTOMER.QSEmail
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
                bxCustSites.ProjectID = bPJPROJ.project
                Call SUpdate1(CSR_xCustSites, "XCUSTSITES", bxCustSites)

                SQLstmt = "xrmrtpl_count" + SParm(bpes.UserId)
                Call sql(c1, SQLstmt)
                serr1 = SGroupFetch1(c1, Numrecs)
                If Numrecs > 0 Then doRMRProcess()

                Numrecs = 0
                SQLstmt = "xbudgtpl_count" + SParm(bpes.UserId)
                Call sql(c1, SQLstmt)
                serr1 = SGroupFetch1(c1, Numrecs)
                If Numrecs > 0 Then doBUDGProcess()

                Numrecs = 0
                SQLstmt = "XINBASETPL_Count" + SParm(bpes.UserId)
                Call sql(c1, SQLstmt)
                serr1 = SGroupFetch1(c1, Numrecs)
                If Numrecs Then doINBASEProcess()
                'mod 4/23/17 moved from doInbase since now user does not have to enter inbase in the project template
                SQLstmt = "xSYSTEMTYPES_xpjsystypes" + SParm(bpes.UserId) + SParm(bPJPROJ.project)
                Call sql(c9, SQLstmt)
            End If  'test for zipcode in smareazips
            Call TranEnd()
            Call TranBeg(True)

            serr1 = SFetch1(CSR_xCustSites, bxCustSites)
        Loop
        Call TranEnd()
        If CallStatus Then Call Status(StopProcess, False, "", 0) 'mod 7/27/14

    End Sub
    Sub InsertPJPROJEM(ByVal Roleemployee As String)
        SQLstmt = "select * from pjprojem where project = " + SParm(bPJPROJ.project) + "and Employee = " + SParm(Roleemployee)
        serr2 = SqlFetch1(CSR_PJprojem, SQLstmt, bPJPROJEM1)
        bPJPROJEM.project = bPJPROJ.project
        bPJPROJEM.crtd_datetime = CurDate
        bPJPROJEM.crtd_prog = Prog
        bPJPROJEM.crtd_user = UserID
        bPJPROJEM.lupd_datetime = CurDate
        bPJPROJEM.lupd_prog = Prog
        bPJPROJEM.lupd_user = UserID
        bPJPROJEM.employee = Roleemployee
        If serr2 Then  'in the unlikely event there is a duplicat
            Call SInsert1(CSR_PJprojem, "pjprojem", bPJPROJEM)
        Else
            Call SUpdate1(CSR_PJprojem, "pjprojem", bPJPROJEM)
        End If
    End Sub
    Sub GetProjectID()
        Dim CtrStr As String
        CtrStr = Format(SiteCntr, "000")
        bPJPROJ.project = ContCntr + CtrStr + "01"
    End Sub
    Sub getCRTD()
        Call GetSysDate(CurDate)
        Prog = "XSOPROJ"
        UserID = bpes.UserId
    End Sub
    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'Standard Screen Exit Call
        Call ScreenExit("", "")

    End Sub

End Class
