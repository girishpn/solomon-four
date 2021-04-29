'------------------------------------------------------------------------------
' <copyright file="arsetup.sdo.vb" company="Microsoft">
'     Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module sdoARSETUP
	
	Public Class ARSetup
			Inherits SolomonDataObject
    < _
    DataBinding(PropertyIndex:=0) _
    > _
    Public Property AnnFinChrg() As Double

        Get
            Return Me.GetPropertyValue("AnnFinChrg")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("AnnFinChrg", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=1, StringSize:=10) _
    > _
    Public Property ArAcct() As String

        Get
            Return Me.GetPropertyValue("ArAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("ArAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=2, StringSize:=24) _
    > _
    Public Property ArSub() As String

        Get
            Return Me.GetPropertyValue("ArSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("ArSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=3) _
    > _
    Public Property AutoApplyWO() As Short

        Get
            Return Me.GetPropertyValue("AutoApplyWO")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("AutoApplyWO", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=4) _
    > _
    Public Property AutoBatRpt() As Short

        Get
            Return Me.GetPropertyValue("AutoBatRpt")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("AutoBatRpt", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=5) _
    > _
    Public Property AutoNSF() As Short

        Get
            Return Me.GetPropertyValue("AutoNSF")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("AutoNSF", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=6) _
    > _
    Public Property AutoRef() As Short

        Get
            Return Me.GetPropertyValue("AutoRef")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("AutoRef", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=7, StringSize:=10) _
    > _
    Public Property ChkAcct() As String

        Get
            Return Me.GetPropertyValue("ChkAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("ChkAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=8, StringSize:=24) _
    > _
    Public Property ChkSub() As String

        Get
            Return Me.GetPropertyValue("ChkSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("ChkSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=9) _
    > _
    Public Property ChrgMin() As Short

        Get
            Return Me.GetPropertyValue("ChrgMin")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("ChrgMin", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=10) _
    > _
    Public Property CompdFinChrg() As Short

        Get
            Return Me.GetPropertyValue("CompdFinChrg")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("CompdFinChrg", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=11, StringSize:=1) _
    > _
    Public Property CreditHoldType() As String

        Get
            Return Me.GetPropertyValue("CreditHoldType")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("CreditHoldType", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=12) _
    > _
    Public Property Crtd_DateTime() As Integer

        Get
            Return Me.GetPropertyValue("Crtd_DateTime")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("Crtd_DateTime", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=13, StringSize:=8) _
    > _
    Public Property Crtd_Prog() As String

        Get
            Return Me.GetPropertyValue("Crtd_Prog")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("Crtd_Prog", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=14, StringSize:=10) _
    > _
    Public Property Crtd_User() As String

        Get
            Return Me.GetPropertyValue("Crtd_User")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("Crtd_User", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=15, StringSize:=6) _
    > _
    Public Property CurrPerNbr() As String

        Get
            Return Me.GetPropertyValue("CurrPerNbr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("CurrPerNbr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=16, StringSize:=1) _
    > _
    Public Property CustViewDflt() As String

        Get
            Return Me.GetPropertyValue("CustViewDflt")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("CustViewDflt", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=17) _
    > _
    Public Property DaysPastDue() As Short

        Get
            Return Me.GetPropertyValue("DaysPastDue")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("DaysPastDue", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=18) _
    > _
    Public Property DecPlPrcCst() As Short

        Get
            Return Me.GetPropertyValue("DecPlPrcCst")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("DecPlPrcCst", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=19) _
    > _
    Public Property DecPlQty() As Short

        Get
            Return Me.GetPropertyValue("DecPlQty")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("DecPlQty", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=20) _
    > _
    Public Property DfltAutoApply() As Short

        Get
            Return Me.GetPropertyValue("DfltAutoApply")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("DfltAutoApply", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=21, StringSize:=6) _
    > _
    Public Property DfltClass() As String

        Get
            Return Me.GetPropertyValue("DfltClass")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltClass", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=22, StringSize:=10) _
    > _
    Public Property DfltNSFAcct() As String

        Get
            Return Me.GetPropertyValue("DfltNSFAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltNSFAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=23, StringSize:=24) _
    > _
    Public Property DfltNSFSub() As String

        Get
            Return Me.GetPropertyValue("DfltNSFSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltNSFSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=24, StringSize:=10) _
    > _
    Public Property DfltSBWOAcct() As String

        Get
            Return Me.GetPropertyValue("DfltSBWOAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltSBWOAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=25, StringSize:=24) _
    > _
    Public Property DfltSBWOSub() As String

        Get
            Return Me.GetPropertyValue("DfltSBWOSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltSBWOSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=26, StringSize:=10) _
    > _
    Public Property DfltSCWOAcct() As String

        Get
            Return Me.GetPropertyValue("DfltSCWOAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltSCWOAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=27, StringSize:=24) _
    > _
    Public Property DfltSCWOSub() As String

        Get
            Return Me.GetPropertyValue("DfltSCWOSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltSCWOSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=28, StringSize:=2) _
    > _
    Public Property DfltStmtCycle() As String

        Get
            Return Me.GetPropertyValue("DfltStmtCycle")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltStmtCycle", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=29, StringSize:=1) _
    > _
    Public Property DfltStmtType() As String

        Get
            Return Me.GetPropertyValue("DfltStmtType")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DfltStmtType", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=30, StringSize:=10) _
    > _
    Public Property DiscAcct() As String

        Get
            Return Me.GetPropertyValue("DiscAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DiscAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=31, StringSize:=24) _
    > _
    Public Property DiscSub() As String

        Get
            Return Me.GetPropertyValue("DiscSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("DiscSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=32) _
    > _
    Public Property DiscCpnyFromInvc() As Short

        Get
            Return Me.GetPropertyValue("DiscCpnyFromInvc")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("DiscCpnyFromInvc", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=33, StringSize:=10) _
    > _
    Public Property FinChrgAcct() As String

        Get
            Return Me.GetPropertyValue("FinChrgAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("FinChrgAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=34, StringSize:=1) _
    > _
    Public Property FinChrgFirst() As String

        Get
            Return Me.GetPropertyValue("FinChrgFirst")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("FinChrgFirst", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=35, StringSize:=24) _
    > _
    Public Property FinChrgSub() As String

        Get
            Return Me.GetPropertyValue("FinChrgSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("FinChrgSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=36, StringSize:=1) _
    > _
    Public Property GLPostOpt() As String

        Get
            Return Me.GetPropertyValue("GLPostOpt")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("GLPostOpt", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=37, StringSize:=10) _
    > _
    Public Property IncAcct() As String

        Get
            Return Me.GetPropertyValue("IncAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("IncAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=38, StringSize:=24) _
    > _
    Public Property IncSub() As String

        Get
            Return Me.GetPropertyValue("IncSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("IncSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=39) _
    > _
    Public Property Init() As Short

        Get
            Return Me.GetPropertyValue("Init")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("Init", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=40, StringSize:=10) _
    > _
    Public Property LastBatNbr() As String

        Get
            Return Me.GetPropertyValue("LastBatNbr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("LastBatNbr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=41, StringSize:=10) _
    > _
    Public Property LastCrMemoNbr() As String

        Get
            Return Me.GetPropertyValue("LastCrMemoNbr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("LastCrMemoNbr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=42, StringSize:=10) _
    > _
    Public Property LastDrMemoNbr() As String

        Get
            Return Me.GetPropertyValue("LastDrMemoNbr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("LastDrMemoNbr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=43, StringSize:=10) _
    > _
    Public Property LastFinChrgRefNbr() As String

        Get
            Return Me.GetPropertyValue("LastFinChrgRefNbr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("LastFinChrgRefNbr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=44, StringSize:=10) _
    > _
    Public Property LastRefNbr() As String

        Get
            Return Me.GetPropertyValue("LastRefNbr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("LastRefNbr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=45, StringSize:=10) _
    > _
    Public Property LastWORefNbr() As String

        Get
            Return Me.GetPropertyValue("LastWORefNbr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("LastWORefNbr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=46) _
    > _
    Public Property LUpd_DateTime() As Integer

        Get
            Return Me.GetPropertyValue("LUpd_DateTime")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("LUpd_DateTime", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=47, StringSize:=8) _
    > _
    Public Property LUpd_Prog() As String

        Get
            Return Me.GetPropertyValue("LUpd_Prog")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("LUpd_Prog", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=48, StringSize:=10) _
    > _
    Public Property LUpd_User() As String

        Get
            Return Me.GetPropertyValue("LUpd_User")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("LUpd_User", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=49) _
    > _
    Public Property MCuryBatRpt() As Short

        Get
            Return Me.GetPropertyValue("MCuryBatRpt")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("MCuryBatRpt", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=50) _
    > _
    Public Property MinFinChrg() As Double

        Get
            Return Me.GetPropertyValue("MinFinChrg")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("MinFinChrg", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=51) _
    > _
    Public Property Nbr0803Docs() As Short

        Get
            Return Me.GetPropertyValue("Nbr0803Docs")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("Nbr0803Docs", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=52) _
    > _
    Public Property NoteId() As Integer

        Get
            Return Me.GetPropertyValue("NoteId")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("NoteId", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=53) _
    > _
    Public Property NSFChrg() As Double

        Get
            Return Me.GetPropertyValue("NSFChrg")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("NSFChrg", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=54) _
    > _
    Public Property OverLimitAmt() As Double

        Get
            Return Me.GetPropertyValue("OverLimitAmt")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("OverLimitAmt", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=55, StringSize:=1) _
    > _
    Public Property OverLimitType() As String

        Get
            Return Me.GetPropertyValue("OverLimitType")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("OverLimitType", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=56, StringSize:=1) _
    > _
    Public Property PASortDflt() As String

        Get
            Return Me.GetPropertyValue("PASortDflt")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("PASortDflt", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=57, StringSize:=6) _
    > _
    Public Property PerNbr() As String

        Get
            Return Me.GetPropertyValue("PerNbr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("PerNbr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=58) _
    > _
    Public Property PerRetHist() As Short

        Get
            Return Me.GetPropertyValue("PerRetHist")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("PerRetHist", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=59) _
    > _
    Public Property PerRetStmtDtl() As Short

        Get
            Return Me.GetPropertyValue("PerRetStmtDtl")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("PerRetStmtDtl", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=60) _
    > _
    Public Property PerRetTran() As Short

        Get
            Return Me.GetPropertyValue("PerRetTran")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("PerRetTran", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=61, StringSize:=10) _
    > _
    Public Property PrePayAcct() As String

        Get
            Return Me.GetPropertyValue("PrePayAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("PrePayAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=62, StringSize:=24) _
    > _
    Public Property PrePaySub() As String

        Get
            Return Me.GetPropertyValue("PrePaySub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("PrePaySub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=63, StringSize:=10) _
    > _
    Public Property RetAllowAcct() As String

        Get
            Return Me.GetPropertyValue("RetAllowAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("RetAllowAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=64, StringSize:=24) _
    > _
    Public Property RetAllowSub() As String

        Get
            Return Me.GetPropertyValue("RetAllowSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("RetAllowSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=65) _
    > _
    Public Property RetAvgDay() As Short

        Get
            Return Me.GetPropertyValue("RetAvgDay")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("RetAvgDay", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=66, StringSize:=10) _
    > _
    Public Property RfndAcct() As String

        Get
            Return Me.GetPropertyValue("RfndAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("RfndAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=67, StringSize:=24) _
    > _
    Public Property RfndSub() As String

        Get
            Return Me.GetPropertyValue("RfndSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("RfndSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=68, StringSize:=30) _
    > _
    Public Property S4Future01() As String

        Get
            Return Me.GetPropertyValue("S4Future01")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("S4Future01", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=69, StringSize:=30) _
    > _
    Public Property S4Future02() As String

        Get
            Return Me.GetPropertyValue("S4Future02")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("S4Future02", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=70) _
    > _
    Public Property S4Future03() As Double

        Get
            Return Me.GetPropertyValue("S4Future03")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("S4Future03", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=71) _
    > _
    Public Property S4Future04() As Double

        Get
            Return Me.GetPropertyValue("S4Future04")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("S4Future04", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=72) _
    > _
    Public Property S4Future05() As Double

        Get
            Return Me.GetPropertyValue("S4Future05")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("S4Future05", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=73) _
    > _
    Public Property S4Future06() As Double

        Get
            Return Me.GetPropertyValue("S4Future06")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("S4Future06", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=74) _
    > _
    Public Property S4Future07() As Integer

        Get
            Return Me.GetPropertyValue("S4Future07")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("S4Future07", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=75) _
    > _
    Public Property S4Future08() As Integer

        Get
            Return Me.GetPropertyValue("S4Future08")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("S4Future08", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=76) _
    > _
    Public Property S4Future09() As Integer

        Get
            Return Me.GetPropertyValue("S4Future09")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("S4Future09", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=77) _
    > _
    Public Property S4Future10() As Integer

        Get
            Return Me.GetPropertyValue("S4Future10")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("S4Future10", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=78, StringSize:=10) _
    > _
    Public Property S4Future11() As String

        Get
            Return Me.GetPropertyValue("S4Future11")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("S4Future11", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=79, StringSize:=10) _
    > _
    Public Property S4Future12() As String

        Get
            Return Me.GetPropertyValue("S4Future12")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("S4Future12", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=80, StringSize:=10) _
    > _
    Public Property S4Future13() As String

        Get
            Return Me.GetPropertyValue("S4Future13")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("S4Future13", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=81) _
    > _
    Public Property SBLimit() As Double

        Get
            Return Me.GetPropertyValue("SBLimit")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("SBLimit", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=82, StringSize:=2) _
    > _
    Public Property SetupId() As String

        Get
            Return Me.GetPropertyValue("SetupId")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("SetupId", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=83) _
    > _
    Public Property SlsTax() As Short

        Get
            Return Me.GetPropertyValue("SlsTax")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("SlsTax", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=84, StringSize:=1) _
    > _
    Public Property SlsTaxDflt() As String

        Get
            Return Me.GetPropertyValue("SlsTaxDflt")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("SlsTaxDflt", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=85, StringSize:=1) _
    > _
    Public Property TranDescDflt() As String

        Get
            Return Me.GetPropertyValue("TranDescDflt")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("TranDescDflt", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=86, StringSize:=30) _
    > _
    Public Property User1() As String

        Get
            Return Me.GetPropertyValue("User1")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("User1", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=87, StringSize:=30) _
    > _
    Public Property User2() As String

        Get
            Return Me.GetPropertyValue("User2")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("User2", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=88) _
    > _
    Public Property User3() As Double

        Get
            Return Me.GetPropertyValue("User3")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("User3", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=89) _
    > _
    Public Property User4() As Double

        Get
            Return Me.GetPropertyValue("User4")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("User4", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=90, StringSize:=10) _
    > _
    Public Property User5() As String

        Get
            Return Me.GetPropertyValue("User5")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("User5", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=91, StringSize:=10) _
    > _
    Public Property User6() As String

        Get
            Return Me.GetPropertyValue("User6")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("User6", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=92) _
    > _
    Public Property User7() As Integer

        Get
            Return Me.GetPropertyValue("User7")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("User7", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=93) _
    > _
    Public Property User8() As Integer

        Get
            Return Me.GetPropertyValue("User8")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("User8", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=94) _
    > _
    Public Property WarningLvlLimit() As Short

        Get
            Return Me.GetPropertyValue("WarningLvlLimit")
        End Get

        Set(ByVal setval As Short)
            Me.SetPropertyValue("WarningLvlLimit", setval)
        End Set

    End Property

	End Class
Public bARSetup As ARSetup = New ARSetup, nARSetup As ARSetup = New ARSetup
End Module
