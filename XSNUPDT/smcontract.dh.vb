'VBTools Converter Version: 7.0.51031.2
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module smContractDH
	
	Public Class smContract
			Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=1) _
        > _
        Public Property AccrualFlag() As String

            Get
                Return Me.GetPropertyValue("AccrualFlag")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("AccrualFlag", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=6) _
        > _
        Public Property AccrualPeriod() As String

            Get
                Return Me.GetPropertyValue("AccrualPeriod")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("AccrualPeriod", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=2, StringSize:=10) _
        > _
        Public Property AgeCode() As String

            Get
                Return Me.GetPropertyValue("AgeCode")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("AgeCode", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=3, StringSize:=1) _
        > _
        Public Property AmortFreq() As String

            Get
                Return Me.GetPropertyValue("AmortFreq")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("AmortFreq", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=4) _
        > _
        Public Property AmortStartDate() As Integer

            Get
                Return Me.GetPropertyValue("AmortStartDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("AmortStartDate", setval)
            End Set

        End Property

        < _
	    DataBinding(PropertyIndex:=5) _
	    > _
	    Public Property ASID() As Integer
	
	        Get
	            Return Me.GetPropertyValue("ASID")
	        End Get
	
	        Set(ByVal setval As Integer)
	            Me.SetPropertyValue("ASID", setval)
	        End Set
	
	    End Property
	    
        < _
        DataBinding(PropertyIndex:=6, StringSize:=60) _
        > _
        Public Property BillAddr1() As String

            Get
                Return Me.GetPropertyValue("BillAddr1")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillAddr1", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=7, StringSize:=60) _
        > _
        Public Property BillAddr2() As String

            Get
                Return Me.GetPropertyValue("BillAddr2")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillAddr2", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=8, StringSize:=30) _
        > _
        Public Property BillAttn() As String

            Get
                Return Me.GetPropertyValue("BillAttn")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillAttn", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=9, StringSize:=30) _
        > _
        Public Property BillCity() As String

            Get
                Return Me.GetPropertyValue("BillCity")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillCity", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=10, StringSize:=3) _
        > _
        Public Property BillCountry() As String

            Get
                Return Me.GetPropertyValue("BillCountry")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillCountry", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=11, StringSize:=15) _
        > _
        Public Property BillFax() As String

            Get
                Return Me.GetPropertyValue("BillFax")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillFax", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=12, StringSize:=1) _
        > _
        Public Property BillingFreq() As String

            Get
                Return Me.GetPropertyValue("BillingFreq")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillingFreq", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=13) _
        > _
        Public Property BillingsToDate() As Double

            Get
                Return Me.GetPropertyValue("BillingsToDate")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("BillingsToDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=14, StringSize:=1) _
        > _
        Public Property BillingType() As String

            Get
                Return Me.GetPropertyValue("BillingType")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillingType", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=15, StringSize:=60) _
        > _
        Public Property BillName() As String

            Get
                Return Me.GetPropertyValue("BillName")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillName", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=16, StringSize:=15) _
        > _
        Public Property BillPhone() As String

            Get
                Return Me.GetPropertyValue("BillPhone")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillPhone", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=17) _
        > _
        Public Property BillStartDate() As Integer

            Get
                Return Me.GetPropertyValue("BillStartDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("BillStartDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=18, StringSize:=3) _
        > _
        Public Property BillState() As String

            Get
                Return Me.GetPropertyValue("BillState")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillState", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=19, StringSize:=10) _
        > _
        Public Property BillZip() As String

            Get
                Return Me.GetPropertyValue("BillZip")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BillZip", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=20, StringSize:=10) _
        > _
        Public Property BranchID() As String

            Get
                Return Me.GetPropertyValue("BranchID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BranchID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=21, StringSize:=10) _
        > _
        Public Property CalcellationCode() As String

            Get
                Return Me.GetPropertyValue("CalcellationCode")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CalcellationCode", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=22, StringSize:=1) _
        > _
        Public Property CalculateBy() As String

            Get
                Return Me.GetPropertyValue("CalculateBy")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CalculateBy", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=23) _
        > _
        Public Property CalculatedAmount() As Double

            Get
                Return Me.GetPropertyValue("CalculatedAmount")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("CalculatedAmount", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=24, StringSize:=47) _
        > _
        Public Property CancelBy() As String

            Get
                Return Me.GetPropertyValue("CancelBy")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CancelBy", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=25) _
        > _
        Public Property CancelDate() As Integer

            Get
                Return Me.GetPropertyValue("CancelDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("CancelDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=26) _
        > _
        Public Property CapAmount() As Double

            Get
                Return Me.GetPropertyValue("CapAmount")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("CapAmount", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=27, StringSize:=1) _
        > _
        Public Property CapContract() As String

            Get
                Return Me.GetPropertyValue("CapContract")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CapContract", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=28) _
        > _
        Public Property CapTolerance() As Double

            Get
                Return Me.GetPropertyValue("CapTolerance")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("CapTolerance", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=29, StringSize:=1) _
        > _
        Public Property CapType() As String

            Get
                Return Me.GetPropertyValue("CapType")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CapType", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=30, StringSize:=30) _
        > _
        Public Property CO_ID01() As String

            Get
                Return Me.GetPropertyValue("CO_ID01")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID01", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=31, StringSize:=30) _
        > _
        Public Property CO_ID02() As String

            Get
                Return Me.GetPropertyValue("CO_ID02")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID02", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=32, StringSize:=20) _
        > _
        Public Property CO_ID03() As String

            Get
                Return Me.GetPropertyValue("CO_ID03")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID03", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=33, StringSize:=20) _
        > _
        Public Property CO_ID04() As String

            Get
                Return Me.GetPropertyValue("CO_ID04")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID04", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=34, StringSize:=10) _
        > _
        Public Property CO_ID05() As String

            Get
                Return Me.GetPropertyValue("CO_ID05")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID05", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=35, StringSize:=10) _
        > _
        Public Property CO_ID06() As String

            Get
                Return Me.GetPropertyValue("CO_ID06")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID06", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=36, StringSize:=4) _
        > _
        Public Property CO_ID07() As String

            Get
                Return Me.GetPropertyValue("CO_ID07")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID07", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=37) _
        > _
        Public Property CO_ID08() As Double

            Get
                Return Me.GetPropertyValue("CO_ID08")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("CO_ID08", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=38) _
        > _
        Public Property CO_ID09() As Integer

            Get
                Return Me.GetPropertyValue("CO_ID09")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("CO_ID09", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=39) _
        > _
        Public Property CO_ID10() As Short

            Get
                Return Me.GetPropertyValue("CO_ID10")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("CO_ID10", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=40, StringSize:=30) _
        > _
        Public Property CO_ID11() As String

            Get
                Return Me.GetPropertyValue("CO_ID11")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID11", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=41, StringSize:=30) _
        > _
        Public Property CO_ID12() As String

            Get
                Return Me.GetPropertyValue("CO_ID12")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID12", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=42, StringSize:=20) _
        > _
        Public Property CO_ID13() As String

            Get
                Return Me.GetPropertyValue("CO_ID13")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID13", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=43, StringSize:=20) _
        > _
        Public Property CO_ID14() As String

            Get
                Return Me.GetPropertyValue("CO_ID14")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID14", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=44, StringSize:=10) _
        > _
        Public Property CO_ID15() As String

            Get
                Return Me.GetPropertyValue("CO_ID15")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID15", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=45, StringSize:=10) _
        > _
        Public Property CO_ID16() As String

            Get
                Return Me.GetPropertyValue("CO_ID16")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID16", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=46, StringSize:=4) _
        > _
        Public Property CO_ID17() As String

            Get
                Return Me.GetPropertyValue("CO_ID17")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CO_ID17", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=47) _
        > _
        Public Property CO_ID18() As Double

            Get
                Return Me.GetPropertyValue("CO_ID18")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("CO_ID18", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=48) _
        > _
        Public Property CO_ID19() As Integer

            Get
                Return Me.GetPropertyValue("CO_ID19")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("CO_ID19", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=49) _
        > _
        Public Property CO_ID20() As Short

            Get
                Return Me.GetPropertyValue("CO_ID20")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("CO_ID20", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=50) _
        > _
        Public Property CommAmt() As Double

            Get
                Return Me.GetPropertyValue("CommAmt")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("CommAmt", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=51, StringSize:=10) _
        > _
        Public Property CommBatNbr() As String

            Get
                Return Me.GetPropertyValue("CommBatNbr")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CommBatNbr", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=52) _
        > _
        Public Property CommPaid() As Short

            Get
                Return Me.GetPropertyValue("CommPaid")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("CommPaid", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=53) _
        > _
        Public Property CommPrct() As Double

            Get
                Return Me.GetPropertyValue("CommPrct")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("CommPrct", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=54, StringSize:=1) _
        > _
        Public Property CommType() As String

            Get
                Return Me.GetPropertyValue("CommType")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CommType", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=55, StringSize:=10) _
        > _
        Public Property ContractID() As String

            Get
                Return Me.GetPropertyValue("ContractID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ContractID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=56, StringSize:=10) _
        > _
        Public Property ContractType() As String

            Get
                Return Me.GetPropertyValue("ContractType")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ContractType", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=57, StringSize:=10) _
        > _
        Public Property CpnyID() As String

            Get
                Return Me.GetPropertyValue("CpnyID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CpnyID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=58) _
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
        DataBinding(PropertyIndex:=59, StringSize:=8) _
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
        DataBinding(PropertyIndex:=60, StringSize:=10) _
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
        DataBinding(PropertyIndex:=61, StringSize:=15) _
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
        DataBinding(PropertyIndex:=62, StringSize:=15) _
        > _
        Public Property CustomerPO() As String

            Get
                Return Me.GetPropertyValue("CustomerPO")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CustomerPO", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=63) _
        > _
        Public Property EffectiveDate() As Integer

            Get
                Return Me.GetPropertyValue("EffectiveDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("EffectiveDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=64, StringSize:=1), _
        DataArray(Dimension:=0, UpperBound:=6) _
        > _
        Public Property EndAMPM(ByVal index0 As Short) As String

            Get
                Return Me.GetPropertyValue("EndAMPM", index0)
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("EndAMPM", setval, index0)
            End Set

        End Property

        < _
        DataArrayPropertyOverload(PropertyName:="EndAMPM") _
        > _
        Public Property EndAMPM() As String()

            Get
                Return Me.GetPropertyValue("EndAMPM")
            End Get

            Set(ByVal value As String())
                Me.SetPropertyValue("EndAMPM", value)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=65, StringSize:=4), _
        DataArray(Dimension:=0, UpperBound:=6) _
        > _
        Public Property EndTime(ByVal index0 As Short) As String

            Get
                Return Me.GetPropertyValue("EndTime", index0)
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("EndTime", setval, index0)
            End Set

        End Property

        < _
        DataArrayPropertyOverload(PropertyName:="EndTime") _
        > _
        Public Property EndTime() As String()

            Get
                Return Me.GetPropertyValue("EndTime")
            End Get

            Set(ByVal value As String())
                Me.SetPropertyValue("EndTime", value)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=66, StringSize:=4), _
        DataArray(Dimension:=0, UpperBound:=6) _
        > _
        Public Property EndTimeMilitary(ByVal index0 As Short) As String

            Get
                Return Me.GetPropertyValue("EndTimeMilitary", index0)
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("EndTimeMilitary", setval, index0)
            End Set

        End Property

        < _
        DataArrayPropertyOverload(PropertyName:="EndTimeMilitary") _
        > _
        Public Property EndTimeMilitary() As String()

            Get
                Return Me.GetPropertyValue("EndTimeMilitary")
            End Get

            Set(ByVal value As String())
                Me.SetPropertyValue("EndTimeMilitary", value)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=67, StringSize:=47) _
        > _
        Public Property EnteredBy() As String

            Get
                Return Me.GetPropertyValue("EnteredBy")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("EnteredBy", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=68, StringSize:=10) _
        > _
        Public Property EscCode() As String

            Get
                Return Me.GetPropertyValue("EscCode")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("EscCode", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=69) _
        > _
        Public Property ExpireDate() As Integer

            Get
                Return Me.GetPropertyValue("ExpireDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("ExpireDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=70) _
        > _
        Public Property Hours() As Double

            Get
                Return Me.GetPropertyValue("Hours")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("Hours", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=71, StringSize:=1), _
        DataArray(Dimension:=0, UpperBound:=6) _
        > _
        Public Property Hours24(ByVal index0 As Short) As String

            Get
                Return Me.GetPropertyValue("Hours24", index0)
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Hours24", setval, index0)
            End Set

        End Property

        < _
        DataArrayPropertyOverload(PropertyName:="Hours24") _
        > _
        Public Property Hours24() As String()

            Get
                Return Me.GetPropertyValue("Hours24")
            End Get

            Set(ByVal value As String())
                Me.SetPropertyValue("Hours24", value)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=72, StringSize:=10) _
        > _
        Public Property LabMarkupID() As String

            Get
                Return Me.GetPropertyValue("LabMarkupID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("LabMarkupID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=73) _
        > _
        Public Property LaborCost() As Double

            Get
                Return Me.GetPropertyValue("LaborCost")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("LaborCost", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=74) _
        > _
        Public Property LaborHrsTD() As Double

            Get
                Return Me.GetPropertyValue("LaborHrsTD")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("LaborHrsTD", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=75) _
        > _
        Public Property LaborPct() As Double

            Get
                Return Me.GetPropertyValue("LaborPct")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("LaborPct", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=76) _
        > _
        Public Property LastAmortDate() As Integer

            Get
                Return Me.GetPropertyValue("LastAmortDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("LastAmortDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=77) _
        > _
        Public Property LastBillDate() As Integer

            Get
                Return Me.GetPropertyValue("LastBillDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("LastBillDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=78) _
        > _
        Public Property LastCallDate() As Integer

            Get
                Return Me.GetPropertyValue("LastCallDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("LastCallDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=79, StringSize:=10) _
        > _
        Public Property LastContractID() As String

            Get
                Return Me.GetPropertyValue("LastContractID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("LastContractID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=80) _
        > _
        Public Property Lupd_dateTime() As Integer

            Get
                Return Me.GetPropertyValue("Lupd_dateTime")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("Lupd_dateTime", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=81, StringSize:=8) _
        > _
        Public Property Lupd_Prog() As String

            Get
                Return Me.GetPropertyValue("Lupd_Prog")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Lupd_Prog", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=82, StringSize:=10) _
        > _
        Public Property Lupd_User() As String

            Get
                Return Me.GetPropertyValue("Lupd_User")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Lupd_User", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=83, StringSize:=10) _
        > _
        Public Property MasterAgreement() As String

            Get
                Return Me.GetPropertyValue("MasterAgreement")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("MasterAgreement", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=84, StringSize:=15) _
        > _
        Public Property MasterID() As String

            Get
                Return Me.GetPropertyValue("MasterID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("MasterID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=85) _
        > _
        Public Property MaterialPct() As Double

            Get
                Return Me.GetPropertyValue("MaterialPct")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("MaterialPct", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=86, StringSize:=10) _
        > _
        Public Property MatMarkupID() As String

            Get
                Return Me.GetPropertyValue("MatMarkupID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("MatMarkupID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=87, StringSize:=10) _
        > _
        Public Property MediaID() As String

            Get
                Return Me.GetPropertyValue("MediaID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("MediaID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=88, StringSize:=4) _
        > _
        Public Property MilitaryEndTime() As String

            Get
                Return Me.GetPropertyValue("MilitaryEndTime")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("MilitaryEndTime", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=89) _
        > _
        Public Property MinHours() As Double

            Get
                Return Me.GetPropertyValue("MinHours")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("MinHours", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=90) _
        > _
        Public Property MinPerCall() As Double

            Get
                Return Me.GetPropertyValue("MinPerCall")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("MinPerCall", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=91) _
        > _
        Public Property MiscCost() As Double

            Get
                Return Me.GetPropertyValue("MiscCost")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("MiscCost", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=92) _
        > _
        Public Property NewContractAmt() As Double

            Get
                Return Me.GetPropertyValue("NewContractAmt")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("NewContractAmt", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=93, StringSize:=10) _
        > _
        Public Property NextContractId() As String

            Get
                Return Me.GetPropertyValue("NextContractId")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("NextContractId", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=94) _
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
        DataBinding(PropertyIndex:=95) _
        > _
        Public Property OrigContractAmt() As Double

            Get
                Return Me.GetPropertyValue("OrigContractAmt")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("OrigContractAmt", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=96, StringSize:=10) _
        > _
        Public Property OriginalContractId() As String

            Get
                Return Me.GetPropertyValue("OriginalContractId")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("OriginalContractId", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=97) _
        > _
        Public Property PartCost() As Double

            Get
                Return Me.GetPropertyValue("PartCost")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("PartCost", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=98) _
        > _
        Public Property PMLaborPct() As Double

            Get
                Return Me.GetPropertyValue("PMLaborPct")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("PMLaborPct", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=99) _
        > _
        Public Property PMMaterialPct() As Double

            Get
                Return Me.GetPropertyValue("PMMaterialPct")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("PMMaterialPct", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=100) _
        > _
        Public Property POEndDate() As Integer

            Get
                Return Me.GetPropertyValue("POEndDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("POEndDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=101) _
        > _
        Public Property POStartDate() As Integer

            Get
                Return Me.GetPropertyValue("POStartDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("POStartDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=102, StringSize:=10) _
        > _
        Public Property PrimaryTech() As String

            Get
                Return Me.GetPropertyValue("PrimaryTech")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("PrimaryTech", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=103, StringSize:=1) _
        > _
        Public Property Priority() As String

            Get
                Return Me.GetPropertyValue("Priority")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Priority", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=104, StringSize:=1) _
        > _
        Public Property ProcessType() As String

            Get
                Return Me.GetPropertyValue("ProcessType")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ProcessType", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=105) _
        > _
        Public Property QuoteExpDate() As Integer

            Get
                Return Me.GetPropertyValue("QuoteExpDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("QuoteExpDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=106) _
        > _
        Public Property RenewalAmount() As Double

            Get
                Return Me.GetPropertyValue("RenewalAmount")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("RenewalAmount", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=107) _
        > _
        Public Property RenewalBillDate() As Integer

            Get
                Return Me.GetPropertyValue("RenewalBillDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("RenewalBillDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=108) _
        > _
        Public Property RenewalBillFreq() As Short

            Get
                Return Me.GetPropertyValue("RenewalBillFreq")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("RenewalBillFreq", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=109, StringSize:=6) _
        > _
        Public Property RenewalPeriod() As String

            Get
                Return Me.GetPropertyValue("RenewalPeriod")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("RenewalPeriod", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=110) _
        > _
        Public Property RenewalRevDate() As Integer

            Get
                Return Me.GetPropertyValue("RenewalRevDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("RenewalRevDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=111) _
        > _
        Public Property RenewalRevFreq() As Short

            Get
                Return Me.GetPropertyValue("RenewalRevFreq")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("RenewalRevFreq", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=112) _
        > _
        Public Property Renewals() As Short

            Get
                Return Me.GetPropertyValue("Renewals")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("Renewals", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=113) _
        > _
        Public Property RenewalsUsed() As Short

            Get
                Return Me.GetPropertyValue("RenewalsUsed")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("RenewalsUsed", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=114, StringSize:=2) _
        > _
        Public Property RenewType() As String

            Get
                Return Me.GetPropertyValue("RenewType")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("RenewType", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=115, StringSize:=10) _
        > _
        Public Property Response() As String

            Get
                Return Me.GetPropertyValue("Response")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Response", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=116, StringSize:=10) _
        > _
        Public Property RevenueAcct() As String

            Get
                Return Me.GetPropertyValue("RevenueAcct")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("RevenueAcct", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=117, StringSize:=24) _
        > _
        Public Property RevenueSub() As String

            Get
                Return Me.GetPropertyValue("RevenueSub")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("RevenueSub", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=118, StringSize:=10) _
        > _
        Public Property SalesPerson() As String

            Get
                Return Me.GetPropertyValue("SalesPerson")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SalesPerson", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=119, StringSize:=10) _
        > _
        Public Property SecondTech() As String

            Get
                Return Me.GetPropertyValue("SecondTech")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SecondTech", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=120, StringSize:=10) _
        > _
        Public Property SiteID() As String

            Get
                Return Me.GetPropertyValue("SiteID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SiteID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=121, StringSize:=1), _
        DataArray(Dimension:=0, UpperBound:=6) _
        > _
        Public Property StartAMPM(ByVal index0 As Short) As String

            Get
                Return Me.GetPropertyValue("StartAMPM", index0)
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("StartAMPM", setval, index0)
            End Set

        End Property

        < _
        DataArrayPropertyOverload(PropertyName:="StartAMPM") _
        > _
        Public Property StartAMPM() As String()

            Get
                Return Me.GetPropertyValue("StartAMPM")
            End Get

            Set(ByVal value As String())
                Me.SetPropertyValue("StartAMPM", value)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=122) _
        > _
        Public Property StartDate() As Integer

            Get
                Return Me.GetPropertyValue("StartDate")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("StartDate", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=123, StringSize:=4), _
        DataArray(Dimension:=0, UpperBound:=6) _
        > _
        Public Property StartTime(ByVal index0 As Short) As String

            Get
                Return Me.GetPropertyValue("StartTime", index0)
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("StartTime", setval, index0)
            End Set

        End Property

        < _
        DataArrayPropertyOverload(PropertyName:="StartTime") _
        > _
        Public Property StartTime() As String()

            Get
                Return Me.GetPropertyValue("StartTime")
            End Get

            Set(ByVal value As String())
                Me.SetPropertyValue("StartTime", value)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=124, StringSize:=4), _
        DataArray(Dimension:=0, UpperBound:=6) _
        > _
        Public Property StartTimeMilitary(ByVal index0 As Short) As String

            Get
                Return Me.GetPropertyValue("StartTimeMilitary", index0)
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("StartTimeMilitary", setval, index0)
            End Set

        End Property

        < _
        DataArrayPropertyOverload(PropertyName:="StartTimeMilitary") _
        > _
        Public Property StartTimeMilitary() As String()

            Get
                Return Me.GetPropertyValue("StartTimeMilitary")
            End Get

            Set(ByVal value As String())
                Me.SetPropertyValue("StartTimeMilitary", value)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=125, StringSize:=1) _
        > _
        Public Property Status() As String

            Get
                Return Me.GetPropertyValue("Status")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Status", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=126) _
        > _
        Public Property Taxable() As Short

            Get
                Return Me.GetPropertyValue("Taxable")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("Taxable", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=127) _
        > _
        Public Property TotalAmort() As Double

            Get
                Return Me.GetPropertyValue("TotalAmort")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("TotalAmort", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=128) _
        > _
        Public Property TotalAmt() As Double

            Get
                Return Me.GetPropertyValue("TotalAmt")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("TotalAmt", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=129) _
        > _
        Public Property TotalBilled() As Double

            Get
                Return Me.GetPropertyValue("TotalBilled")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("TotalBilled", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=130) _
        > _
        Public Property TotalBills() As Double

            Get
                Return Me.GetPropertyValue("TotalBills")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("TotalBills", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=131) _
        > _
        Public Property TotalCalls() As Double

            Get
                Return Me.GetPropertyValue("TotalCalls")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("TotalCalls", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=132, StringSize:=30) _
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
        DataBinding(PropertyIndex:=133, StringSize:=30) _
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
        DataBinding(PropertyIndex:=134) _
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
        DataBinding(PropertyIndex:=135) _
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
        DataBinding(PropertyIndex:=136, StringSize:=10) _
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
        DataBinding(PropertyIndex:=137, StringSize:=10) _
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
        DataBinding(PropertyIndex:=138) _
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
        DataBinding(PropertyIndex:=139) _
        > _
        Public Property User8() As Integer

            Get
                Return Me.GetPropertyValue("User8")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("User8", setval)
            End Set

        End Property

	End Class
Public bsmContract As smContract = New smContract, nsmContract As smContract = New smContract
End Module
