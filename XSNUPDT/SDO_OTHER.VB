Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports vb = Microsoft.VisualBasic
Module sdoOTHER


    Public Class Keyid
        Inherits SolomonDataObject
        < _
   DataBinding(PropertyIndex:=0) _
   > _
        Public Property ID() As Short

            Get
                Return Me.GetPropertyValue("ID")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("ID", setval)
            End Set

        End Property
    End Class
    Public bKeyid As Keyid = New Keyid, nkeyid As Keyid = New Keyid
    Public Class MassUp
        Inherits SolomonDataObject
        < _
                      DataBinding(PropertyIndex:=0, StringSize:=30) _
              > _
        Public Property ServItemSel() As String

            Get
                Return Me.GetPropertyValue("ServItemSel")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ServItemSel", setval)
            End Set

        End Property
        < _
        DataBinding(PropertyIndex:=1) _
        > _
        Public Property EffectDate() As Integer

            Get
                Return Me.GetPropertyValue("EffectDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("EffectDate", setval)
            End Set

        End Property
        < _
        DataBinding(PropertyIndex:=2) _
        > _
        Public Property RevDate() As Integer

            Get
                Return Me.GetPropertyValue("RevDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("RevDate", setval)
            End Set

        End Property
        < _
         DataBinding(PropertyIndex:=3, StringSize:=10) _
 > _
        Public Property CancelCode() As String

            Get
                Return Me.GetPropertyValue("CancelCode")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CancelCode", setval)
            End Set

        End Property
        < _
DataBinding(PropertyIndex:=4) _
> _
        Public Property InvPrintSuppress() As Integer

            Get
                Return Me.GetPropertyValue("InvPrintSuppress")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("InvPrintSuppress", setval)
            End Set

        End Property
        < _
       DataBinding(PropertyIndex:=5) _
       > _
        Public Property RMRAmt() As Double

            Get
                Return Me.GetPropertyValue("RMRAmt")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("RMRAmt", setval)
            End Set

        End Property
    End Class
    Public bMassUp As MassUp = New MassUp, nMassUp As MassUp = New MassUp



    Public Class StatusChange
        Inherits SolomonDataObject
        < _
               DataBinding(PropertyIndex:=0) _
               > _
        Public Property DBDExpCDate() As Integer

            Get
                Return Me.GetPropertyValue("DBDExpCDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("DBDExpCDate", setval)
            End Set

        End Property
        < _
              DataBinding(PropertyIndex:=1) _
              > _
        Public Property ActualComplDate() As Integer

            Get
                Return Me.GetPropertyValue("ActualComplDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("ActualComplDate", setval)
            End Set

        End Property
        < _
               DataBinding(PropertyIndex:=2, StringSize:=16) _
               > _
        Public Property PM_ID04() As String

            Get
                Return Me.GetPropertyValue("PM_ID04")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CuryPM_ID04RateType", setval)
            End Set

        End Property

    End Class
    Public bStatusChange As StatusChange = New StatusChange
    Public Class bselectedCls
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0)> Public Property Value() As Short
            Get
                Return Me.GetPropertyValue("Value")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("Value", Value)
            End Set
        End Property
    End Class
    Public bselected As bselectedCls = New bselectedCls
    Public Class bselectedRenewalsCls
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0)> Public Property Value() As Short
            Get
                Return Me.GetPropertyValue("Value")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("Value", Value)
            End Set
        End Property
    End Class
    Public bselectedRenewals As bselectedRenewalsCls = New bselectedRenewalsCls

    Public Class ServAbbrev
        Inherits SolomonDataObject
        < _
                     DataBinding(PropertyIndex:=0, StringSize:=10) _
             > _
        Public Property Contractid() As String

            Get
                Return Me.GetPropertyValue("Contractid")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Contractid", setval)
            End Set

        End Property
        < _
                        DataBinding(PropertyIndex:=1, StringSize:=255) _
                > _
        Public Property User7() As String

            Get
                Return Me.GetPropertyValue("User7")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("User7", setval)
            End Set

        End Property
    End Class
    Public bServAbbrev As ServAbbrev = New ServAbbrev
    Public Class xRenewGroup
        Inherits SolomonDataObject
        < _
       DataBinding(PropertyIndex:=0) _
       > _
        Public Property NumContracts() As Integer

            Get
                Return Me.GetPropertyValue("NumContracts")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("NumContracts", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=10) _
                > _
        Public Property Contractid() As String

            Get
                Return Me.GetPropertyValue("Contractid")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Contractid", setval)
            End Set

        End Property
        < _
         DataBinding(PropertyIndex:=2, StringSize:=15) _
                        > _
        Public Property Custid() As String

            Get
                Return Me.GetPropertyValue("Custid")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Custid", setval)
            End Set

        End Property
        < _
        DataBinding(PropertyIndex:=3, StringSize:=60) _
                        > _
        Public Property Name() As String

            Get
                Return Me.GetPropertyValue("Name")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Name", setval)
            End Set

        End Property
        < _
              DataBinding(PropertyIndex:=4) _
              > _
        Public Property RenewalDate() As Integer

            Get
                Return Me.GetPropertyValue("RenewalDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("RenewalDate", setval)
            End Set

        End Property
        < _
           DataBinding(PropertyIndex:=5) _
           > _
        Public Property Duration() As Short

            Get
                Return Me.GetPropertyValue("Duration")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("Duration", setval)
            End Set

        End Property

        < _
         DataBinding(PropertyIndex:=6, StringSize:=10) _
                        > _
        Public Property Frequency() As String

            Get
                Return Me.GetPropertyValue("Frequency")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Frequency", setval)
            End Set

        End Property
        < _
        DataBinding(PropertyIndex:=7, StringSize:=10) _
                        > _
        Public Property InvoicingRule() As String

            Get
                Return Me.GetPropertyValue("InvoicingRule")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("InvoicingRule", setval)
            End Set

        End Property
        < _
         DataBinding(PropertyIndex:=8, StringSize:=2000) _
                        > _
        Public Property Services() As String

            Get
                Return Me.GetPropertyValue("Services")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Services", setval)
            End Set

        End Property

    End Class
    Public bxRenewGroup As xRenewGroup = New xRenewGroup
    Public Class ProfileExpireDate
        Inherits SolomonDataObject
        < _
                     DataBinding(PropertyIndex:=0, StringSize:=10) _
             > _
        Public Property Contractid() As String

            Get
                Return Me.GetPropertyValue("Contractid")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Contractid", setval)
            End Set

        End Property
        < _
              DataBinding(PropertyIndex:=1) _
              > _
        Public Property ExpireDate() As Integer

            Get
                Return Me.GetPropertyValue("ExpireDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("ExpireDate", setval)
            End Set

        End Property
    End Class
    Public bProfileExpireDate As ProfileExpireDate = New ProfileExpireDate
    Public Class Contract
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
    Public bContract As Contract = New Contract
    Class User7
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
                > _
        Public Property Abbrev() As String

            Get
                Return Me.GetPropertyValue("Abbrev")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Abbrev", setval)
            End Set

        End Property
    End Class
    Dim bUser7 As User7 = New User7

    'mod 3/20/17
    Public Class XMULTIDELETES
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
        > _
        Public Property CancelCode As String

            Get
                Return Me.GetPropertyValue("CancelCode")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CancelCode", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=30) _
        > _
        Public Property ServItemID As String

            Get
                Return Me.GetPropertyValue("ServItemID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ServItemID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=2, StringSize:=60) _
        > _
        Public Property Descr As String

            Get
                Return Me.GetPropertyValue("Descr")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Descr", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=3) _
        > _
        Public Property ActiveDate As Integer

            Get
                Return Me.GetPropertyValue("ActiveDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("ActiveDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=4) _
        > _
        Public Property EffectDate As Integer

            Get
                Return Me.GetPropertyValue("EffectDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("EffectDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=5) _
        > _
        Public Property RMRAmt As Double

            Get
                Return Me.GetPropertyValue("RMRAmt")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("RMRAmt", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=6) _
        > _
        Public Property InvPrintSuppress As Short

            Get
                Return Me.GetPropertyValue("InvPrintSuppress")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("InvPrintSuppress", setval)
            End Set

        End Property


    End Class
    Public bXMULTIDELETES As XMULTIDELETES = New XMULTIDELETES, nXMULTIDELETES As XMULTIDELETES = New XMULTIDELETES
    'mod 4/16/17  
    Public Class WarDuration
        Inherits SolomonDataObject
        < _
                        DataBinding(PropertyIndex:=0, StringSize:=10) _
                > _
        Public Property Duration() As String

            Get
                Return Me.GetPropertyValue("Duration")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Duration", setval)
            End Set

        End Property
    End Class
    Public bWarDuration As WarDuration = New WarDuration, nWarduration As WarDuration = New WarDuration

    'mod 3/20/17
    Public Class bDelselectedCls
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0)> Public Property Value() As Short
            Get
                Return Me.GetPropertyValue("Value")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("Value", Value)
            End Set
        End Property
    End Class
    Public bDelselected As bDelselectedCls = New bDelselectedCls
    'mom 3/20/17
    Public Class TotDel
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0)> Public Property Total() As Double
            Get
                Return Me.GetPropertyValue("Total")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("Total", setval)
            End Set
        End Property
    End Class
    Public bTotDel As TotDel = New TotDel

    Public Class XMULTIADDS
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=30) _
        > _
        Public Property ServItemID As String

            Get
                Return Me.GetPropertyValue("ServItemID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ServItemID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=60) _
        > _
        Public Property Descr As String

            Get
                Return Me.GetPropertyValue("Descr")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Descr", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=2, StringSize:=30) _
        > _
        Public Property Duration As String

            Get
                Return Me.GetPropertyValue("Duration")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Duration", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=3) _
        > _
        Public Property EffectDate As Integer

            Get
                Return Me.GetPropertyValue("EffectDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("EffectDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=4) _
        > _
        Public Property WarrantyEndDate As Integer

            Get
                Return Me.GetPropertyValue("WarrantyEndDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("WarrantyEndDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=5) _
        > _
        Public Property WarrantyStartDate As Integer

            Get
                Return Me.GetPropertyValue("WarrantyStartDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("WarrantyStartDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=6) _
        > _
        Public Property RMRAmt As Double

            Get
                Return Me.GetPropertyValue("RMRAmt")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("RMRAmt", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=7) _
        > _
        Public Property InvPrintSuppress As Short

            Get
                Return Me.GetPropertyValue("InvPrintSuppress")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("InvPrintSuppress", setval)
            End Set

        End Property
        < _
      DataBinding(PropertyIndex:=8, StringSize:=30) _
      > _
        Public Property SystemType As String

            Get
                Return Me.GetPropertyValue("SystemType")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SystemType", setval)
            End Set

        End Property

    End Class
    Public bXMULTIADDS As XMULTIADDS = New XMULTIADDS, nXMULTIADDS As XMULTIADDS = New XMULTIADDS
    'used by changes and deletes  mod 5/6/17
    Public Class CreditInfo
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0)
        > Public Property NumMonths() As Integer
            Get
                Return Me.GetPropertyValue("NumMonths")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("NumMonths", setval)
            End Set
        End Property
        < _
      DataBinding(PropertyIndex:=1)
    > Public Property FirstPostDate() As Integer
            Get
                Return Me.GetPropertyValue("FirstPostDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("FirstPostDate", setval)
            End Set
        End Property
        < _
        DataBinding(PropertyIndex:=2)
      > Public Property LastPostDate() As Integer
            Get
                Return Me.GetPropertyValue("LastPostDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("LastPostDate", setval)
            End Set
        End Property
    End Class
    Public bCreditInfo As CreditInfo = New CreditInfo, nCreditInfo As CreditInfo = New CreditInfo

    'mod 7/18/17
    Public Class Comment
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=30) _
        > _
        Public Property ID As String

            Get
                Return Me.GetPropertyValue("ID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ID", setval)
            End Set

        End Property
    End Class
    Dim bComment As Comment = New Comment

    Public Class MultiSite
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
        > _
        Public Property Contractid As String

            Get
                Return Me.GetPropertyValue("Contractid")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Contractid", setval)
            End Set
        End Property
        < _
   DataBinding(PropertyIndex:=1)
 > Public Property StartDate() As Integer
            Get
                Return Me.GetPropertyValue("StartDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("StartDate", setval)
            End Set
        End Property
    End Class
    Public bMultiSite As MultiSite = New MultiSite, nMultisite As MultiSite = New MultiSite


    Public Class DupeDates
        Inherits SolomonDataObject

        <DataBinding(PropertyIndex:=0, StringSize:=10)> _
        Public Property ContractID As String

            Get
                Return Me.GetPropertyValue("ContractID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ContractID", setval)
            End Set
        End Property

        <DataBinding(PropertyIndex:=1)> _
        Public Property DupeDate() As Integer
            Get
                Return Me.GetPropertyValue("DupeDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("DupeDate", setval)
            End Set
        End Property

        <DataBinding(PropertyIndex:=2, StringSize:=1)> _
        Public Property BorR As String

            Get
                Return Me.GetPropertyValue("BorR")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BorR", setval)
            End Set
        End Property

        <DataBinding(PropertyIndex:=3)> _
        Public Property BadCount() As Integer
            Get
                Return Me.GetPropertyValue("BadCount")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("BadCount", setval)
            End Set
        End Property
    End Class
    Public bDupeDates As DupeDates = New DupeDates, nDupeDates As DupeDates = New DupeDates

    Public Class BadComments
        Inherits SolomonDataObject

        <DataBinding(PropertyIndex:=0, StringSize:=10)> _
        Public Property ContractID As String

            Get
                Return Me.GetPropertyValue("ContractID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ContractID", setval)
            End Set
        End Property

        <DataBinding(PropertyIndex:=1)> _
        Public Property CommentDate() As Integer
            Get
                Return Me.GetPropertyValue("CommentDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("CommentDate", setval)
            End Set
        End Property

        <DataBinding(PropertyIndex:=2, StringSize:=1)> _
        Public Property BorR As String

            Get
                Return Me.GetPropertyValue("BorR")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BorR", setval)
            End Set
        End Property

        <DataBinding(PropertyIndex:=3)> _
        Public Property LineNbr() As Integer
            Get
                Return Me.GetPropertyValue("LineNbr")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("LineNbr", setval)
            End Set
        End Property

        <DataBinding(PropertyIndex:=4, StringSize:=60)> _
        Public Property Comment As String

            Get
                Return Me.GetPropertyValue("Comment")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Comment", setval)
            End Set
        End Property
    End Class
    Public bBadComments As BadComments = New BadComments, nBadComments As BadComments = New BadComments

    Public DelGridHandle As Short = 0, AddGridHandle As Short = 0
    Public gMaxDate As Integer = 57344 '01/01/2057
    Public WarBillDate As Integer = 0, FreqStartDate As Integer = 0
    Public RevARDate As Integer = 0, BillARDate As Integer = 0
    Public ChangeRMRAmtOpt As Short = 0
    Public SQLstmt As String
    Public Curdate As Integer, CurProg As String, CurUser As String
    Public CSR_SMContract, CSR_SMContractBill, CSR_SMContractRev, CSR_XTB_SMContract, CSR_XTB_Services As Short, CSR_xMultiDeletes As Short, CSR_xSvcUpdHist As Short
    Public CSR_xMultiAdds As Short
    Public MonthlyRMRAmt As Double 'for smcontract.user3
    Public CSR_CreditMonths As Short
    Public Frequency As Short = 0
    Public IsArrears As Boolean  'mod 6/24/17 made field public so that it's available for stored proc XSNUPDT_FinalAdj


    Public Function gGetComment(PeriodStartDate As Integer, PeriodEndDate As Integer) As String
        Dim BegPerCovered, EndPerCovered As String, DD, YY, MM As Short
        'mod 2/18/17
        BegPerCovered = DateToStrSep(PeriodStartDate)
        YY = Mid(BegPerCovered, 7, 4) : MM = vb.Left(BegPerCovered, 2) : DD = Mid(BegPerCovered, 4, 2)
        BegPerCovered = MM.ToString + "/" + DD.ToString + "/" + YY.ToString

        EndPerCovered = DateToStrSep(PeriodEndDate)
        YY = Mid(EndPerCovered, 7, 4) : MM = vb.Left(EndPerCovered, 2) : DD = Mid(EndPerCovered, 4, 2)
        EndPerCovered = MM.ToString + "/" + DD.ToString + "/" + YY.ToString
        gGetComment = BegPerCovered + "-" + EndPerCovered
    End Function
    Public Function gGetEndDate(PostDate As Integer, Contractid As String) As Integer
        'mod 7/23/17
        Dim Pos As Short, DatStr As String
        gGetEndDate = 0
        SQLstmt = "select comment from smcontractbill where contractid = " + SParm(Contractid) + " and billdate = " + DParm(PostDate)
        serr5 = SqlFetch1(c5, SQLstmt, bComment)
        Pos = InStr(bComment.ID, "-")
        DatStr = Mid(bComment.ID, Pos + 1).Trim
        Call StrToDate(DatStr, gGetEndDate)
    End Function
    Public Sub gGetWarBilldate(Contractid As String)
        'mod 7/17/17  r:warranties not treated as warranties and Tribridge combining warranties with regular when statusdate on the 1st
        Dim dd As Short, Tempdate As Integer, numrecs As Integer = 0, MonthAmt As Double = 0, WarrantyAmt As Double, Billamt As Double
        Dim BillFreq As Short
        WarBillDate = 0
        Tempdate = 0
        SQLstmt = "XaddDel_GetWarStartDate" + SParm(Contractid)
        serr5 = SqlFetch1(c5, SQLstmt, Tempdate)
        'getting xtb_services.statusdate for the warranty item
        If Tempdate = 0 Then
            WarBillDate = gMaxDate
        Else
            'mod 6/30/17
            numrecs = 0
            SQLstmt = "select count(*) from smcontractrev where revamount <> 0 and contractid = " + SParm(Contractid) + " and revdate = " + DParm(Tempdate) 'mod 7/2/17
            Call sql(c5, SQLstmt)
            serr5 = SGroupFetch1(c5, numrecs)
            If numrecs = 0 Then
                WarBillDate = gMaxDate
            Else
                'billing tests
                dd = Mid(DateToStr(Tempdate), 3, 2)
                'mod 7/1/17
                If dd = 1 Then
                    numrecs = 0
                    SQLstmt = "select count(*) from smcontractbill where contractid = " + SParm(Contractid) + " and billdate between " + DParm(Tempdate + 1) + " and " + DParm(Tempdate + 2)
                    Call sql(c5, SQLstmt)
                    serr5 = SGroupFetch1(c5, numrecs)
                    'only for billings
                    'Test whether user added a warranty but did not complete the warranty info -- thus treating servitem as a non-warranty item
                    If numrecs = 0 Then  'no 2nd or 3rd to indicate a warranty
                        SQLstmt = "select isnull(monthamt,0)from  xtb_services (nolock) where contractid = " + SParm(Contractid) + "and status = 'A'and servitemid in ('C OPTION A', 'CP OPTION A', 'CP OPTION D','CP OPTION D 4 HOUR')"  ''4/10/2020 Warranty Items added to Table.
                        'SQLstmt = "xWarrantyItem_in_xtb_Services_MonthAmt" + SParm(Contractid)   '4/10/2020 Warranty Items added to Table.
                        serr5 = SqlFetch1(c5, SQLstmt, MonthAmt)
                        'on next set of updates move this to form1 for all billingfreq selections
                        Select Case bsmContract.BillingFreq.Trim
                            Case "M"
                                BillFreq = 1
                            Case "Q"
                                BillFreq = 3
                            Case "S"
                                BillFreq = 6
                            Case "A"
                                BillFreq = 12
                        End Select
                        WarrantyAmt = FPMult(MonthAmt, BillFreq, 2) 'mod 7/17/17
                        SQLstmt = "select billamount from smcontractbill where contractid = " + SParm(Contractid) + " and billdate = " + DParm(Tempdate)
                        serr5 = SqlFetch1(c5, SQLstmt, Billamt)
                        If Billamt > WarrantyAmt Then
                            WarBillDate = gMaxDate
                            Exit Sub
                        End If
                    End If
                End If
                If dd <> 1 Then Call DatePlusMonthSetDay(Tempdate, 1, 1, Tempdate)

                SQLstmt = "XaddDel_GetWarBillDate" + SParm(Contractid) + DParm(Tempdate) + DParm(Tempdate + 1)
                serr1 = SqlFetch1(c5, SQLstmt, WarBillDate)
                If WarBillDate = 0 Then WarBillDate = gMaxDate
            End If
        End If
    End Sub
    Public Function GetFreqStartDate(Contractid As String, FirstBillDate As Integer, Frequency As Short) As Integer
        'purpose is to get actual next date based upon smcontract.startdate(or multisite startdate) + frequency.  Always starts with smcontract.startdate and loops to firstbilldate
        Dim startdate As Integer = 0, TestDate As Integer = 0, Pos As Short = 0, DatStr As String = "", EndCommentDate As Integer = 0

        'the multisite stored proc is called in each of the processes in XSVCUPDHIST so that XSVCUPDHIST.user7 reflects the MultiSite contract, if any
        If bMultiSite.StartDate Then 'is a mutisite contract
            'Is there a billing record for current smcontract.startdate. If so, get it's comment.  If comment enddate <=FirstBilldate then next billdate
            '  should be comment enddate +1.  Test for that and if found -- then that's the next frequency date.
            bComment.ID = ""

            startdate = bMultiSite.StartDate
            If Mid(DateToStr(startdate), 3, 2) <> 1 Then
                Call DatePlusMonthSetDay(startdate, 1, 1, startdate)  'this is exactly what tribridge does.  Then frequency goes from that date.
            End If

            TestDate = bsmContract.StartDate
            If Mid(DateToStr(TestDate), 3, 2) <> 1 Then
                Call DatePlusMonthSetDay(TestDate, 1, 1, TestDate)  'this is exactly what tribridge does.  Then frequency goes from that date.
            End If

            SQLstmt = "select top 1 comment from smcontractbill where contractid = " + SParm(Contractid) + " and billdate >= " + DParm(TestDate)
            serr5 = SqlFetch1(c5, SQLstmt, bComment)
            If serr5 = 0 Then
                Pos = InStr(bComment.ID, "-")
                DatStr = Mid(bComment.ID, Pos + 1).Trim
                Call StrToDate(DatStr, EndCommentDate)
                If FirstBillDate <= EndCommentDate Then
                    SQLstmt = "select billdate from smcontractbill where contractid = " + SParm(Contractid) + " and billdate = " + DParm(EndCommentDate + 1)
                    serr5 = SqlFetch1(c5, SQLstmt, FreqStartDate)
                    If serr5 = 0 Then
                        GetFreqStartDate = FreqStartDate
                        Exit Function
                    End If
                Else
                    SQLstmt = "select billdate from smcontractbill where contractid = " + SParm(Contractid) + " and billdate = " + DParm(EndCommentDate + 1)
                    serr5 = SqlFetch1(c5, SQLstmt, FreqStartDate)
                    If serr5 = 0 And FirstBillDate = FreqStartDate Then
                        GetFreqStartDate = FreqStartDate
                        Exit Function
                    End If
                End If
            End If  'not a multisite contract
        Else 'not multisite
            startdate = bsmContract.StartDate
        End If  'end of multisite test

        If Mid(DateToStr(startdate), 3, 2) <> 1 Then
            Call DatePlusMonthSetDay(startdate, 1, 1, startdate)  'this is exactly what tribridge does.  Then frequency goes from that date.
        End If

        Dim NextFreqDate As DateTime

        FreqStartDate = startdate
        Do While FirstBillDate >= FreqStartDate
            NextFreqDate = DateTime.Parse(DateToStrSep(FreqStartDate)).AddMonths(Frequency)
            Call StrToDate(NextFreqDate, FreqStartDate)
        Loop
        GetFreqStartDate = FreqStartDate
    End Function
    Public Function GetMonths(StartDate As Integer, EndDate As Integer) As Short
        Dim Date1 As Date, Date2 As Date
        Date1 = DateToStrSep(StartDate)
        Date2 = DateToStrSep(EndDate)
        GetMonths = DateDiff(DateInterval.Month, Date1, Date2)
    End Function
    Public Function gAddNote(ByVal Kind As String, ByVal EffectDate As Integer) As Integer
        'Mod 10/29/17 for billings
        'Kind = Added, Changed,Deleted
        Dim Maxnid As Integer, CSR_Snote As Short, CSR_MaxNid As Short, NoteText As String, EffectDateStr As String = DateToStrSep(EffectDate)
        Dim DD, YY, MM As Short

        Call SqlCursorEx(CSR_Snote, NOLEVEL, "CSR_Snote", "SNote", "SNote")
        Call SqlCursor(CSR_MaxNid, NOLEVEL)



        Call sql(CSR_Snote, "select top 1 * from  SNote")

        YY = Mid(EffectDateStr, 7, 4) : MM = vb.Left(EffectDateStr, 2) : DD = Mid(EffectDateStr, 4, 2)
        '  NoteText = Kind + " item " + bXTB_SERVICES.ServItemID.Trim + " - Effective Date - " + MM.ToString + "/" + DD.ToString + "/" + YY.ToString
        NoteText = Kind + " item " + bXTB_SERVICES.Descr.Trim + " - Effective Date - " + MM.ToString + "/" + DD.ToString + "/" + YY.ToString  'mod 11/9/17
        With bSnote
            SQLstmt = "snote_all" + IParm(bsmContractBill.NoteID) + IParm(bsmContractBill.NoteID)
            serr2 = SqlFetch1(CSR_Snote, SQLstmt, bSnote)
            If serr2 = 0 Then
                gAddNote = bSnote.nID
                Call GetSysDate(.dtRevisedDate)
                .sNoteText = .sNoteText.Trim + vbCrLf + NoteText
                Call SUpdate1(CSR_Snote, "SNOTE", bSnote)
            Else
                Call GetSysDate(.dtRevisedDate)
                .sLevelName = "Billing"
                .sTableName = "smcontractbill"
                .sNoteText = NoteText
                Call SInsert1(CSR_Snote, "snote", bSnote)
                SQLstmt = "select max(nid) from snote"
                Call sql(CSR_MaxNid, SQLstmt)
                serr10 = SGroupFetch1(CSR_MaxNid, Maxnid)
                gAddNote = Maxnid
            End If
        End With
        Call SqlFree(CSR_Snote)
        Call SqlFree(CSR_MaxNid)
    End Function
    Public Function GAddContractNote(ByVal Kind As String, ByVal EffectDate As Integer) As Integer
        'Mod 10/29/17
        'Kind = Added, Changed,Deleted
        Dim Maxnid As Integer, CSR_Snote As Short, CSR_MaxNid As Short, NoteText As String, EffectDateStr As String = DateToStrSep(EffectDate)
        Dim DD, YY, MM As Short

        Call SqlCursorEx(CSR_Snote, NOLEVEL, "CSR_Snote", "SNote", "SNote")
        Call SqlCursor(CSR_MaxNid, NOLEVEL)



        Call sql(CSR_Snote, "select top 1 * from  SNote")

        YY = Mid(EffectDateStr, 7, 4) : MM = vb.Left(EffectDateStr, 2) : DD = Mid(EffectDateStr, 4, 2)
        NoteText = Kind + " " + bXTB_SERVICES.Descr.Trim + " " + MM.ToString + "/" + DD.ToString + "/" + YY.ToString + " " + bpes.UserId
        With bSnote
            SQLstmt = "snote_all" + IParm(bsmContract.NoteId) + IParm(bsmContract.NoteId)
            serr2 = SqlFetch1(CSR_Snote, SQLstmt, bSnote)
            If serr2 = 0 Then
                GAddContractNote = bSnote.nID
                Call GetSysDate(.dtRevisedDate)
                .sNoteText = .sNoteText.Trim + vbCrLf + NoteText
                Call SUpdate1(CSR_Snote, "SNOTE", bSnote)
            Else
                Call GetSysDate(.dtRevisedDate)
                .sLevelName = "Contract"
                .sTableName = "smcontract"
                .sNoteText = NoteText
                Call SInsert1(CSR_Snote, "snote", bSnote)
                SQLstmt = "select max(nid) from snote"
                Call sql(CSR_MaxNid, SQLstmt)
                serr10 = SGroupFetch1(CSR_MaxNid, Maxnid)
                GAddContractNote = Maxnid
            End If
        End With
        Call SqlFree(CSR_Snote)
        Call SqlFree(CSR_MaxNid)
    End Function
    Public Function gGetUpdateComment() As String
        'mod 10/30/17 
        Dim Pos As Short, CommentStartDate As Integer, CommentStartDateStr As String, CommentEndDate As Integer, CommentEndDateStr As String, EarliestStartDate As Integer
        Pos = InStr(bsmContractBill.Comment, "-")
        If Pos = 0 Or bsmContractBill.Comment.Trim = "" Then
            gGetUpdateComment = ""
            Exit Function
        End If
        'Get Comment Star Date
        CommentStartDateStr = Left(bsmContractBill.Comment, Pos - 1)
        Call StrToDate(CommentStartDateStr, CommentStartDate)
        EarliestStartDate = Math.Min(CommentStartDate, bXTB_SERVICES.user8)

        'Get Comment EndDate from existing comment
        CommentEndDateStr = Mid(bsmContractBill.Comment, Pos + 1).Trim
        Call StrToDate(CommentEndDateStr, CommentEndDate)

        gGetUpdateComment = gGetComment(EarliestStartDate, CommentEndDate)
    End Function
    Public Function gReversalWarning(ByVal kind As String, EffectDate As Integer, DispMsg As Short) As Boolean
        'mod 11/4/17
        Exit Function
        Dim StartDate As Integer = 0, Contractid As String = bXSVCGRID.ContractID.Trim, Numrecs As Integer = 0, TestBilldate As Integer

        SQLstmt = "select top 1 billdate from smcontractbill(nolock) where billdate <= " + DParm(EffectDate) + " and contractid = " + SParm(Contractid) + " order by billdate desc"
        serr10 = SqlFetch1(c10, SQLstmt, StartDate)

        'any reversals starting that date
        SQLstmt = "select billdate from smcontractbill(nolock) where contractid = " + SParm(Contractid) + "  and billdate >=" + DParm(StartDate) + " and status = 'O' and crtd_prog = 'XSVCREV' "
        serr1 = SqlFetch1(c10, SQLstmt, TestBilldate)
        If TestBilldate > 0 Then
            SQLstmt = "select count(*) from smcontractbill(nolock) where contractid = " + SParm(Contractid) + " and billdate > " + DParm(TestBilldate) + " and status = 'P' and crtd_prog <> 'XSVCREV'"
            serr11 = SqlFetch1(c11, SQLstmt, Numrecs)
            If Numrecs Then
                'any billdates not reversed after that date
                Numrecs = 0
                SQLstmt = "select count(distinct billdate) from smcontractbill(nolock) where contractid = " + SParm(Contractid) + " and billdate >= " + DParm(StartDate) + " and status = 'P' and crtd_prog <> 'XSVCREV'"
                serr11 = SqlFetch1(c11, SQLstmt, Numrecs)
                If Numrecs Then
                    gReversalWarning = True
                    If DispMsg Then Call MessBox("For Contract " + Contractid + vbCrLf + "Cannot process " + kind.Trim + " as there have been reversals on or after" + vbCrLf + "Effect Date AND not all subsequent Processed Invoices" + vbCrLf + "have been reversed", 48, "Mass Update Msg")
                Else
                    gReversalWarning = False
                End If
            End If
        End If
    End Function
End Module