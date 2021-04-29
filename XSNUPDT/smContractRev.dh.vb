'------------------------------------------------------------------------------
' <copyright file="smconre.sdo.vb" company="Microsoft">
'     Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'------------------------------------------------------------------------------

'VBTools Converter Version: 7.0.51129.0
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module sdoContractRev
	
	Public Class smContractRev
			Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=60) _
        > _
        Public Property Comment() As String

            Get
                Return Me.GetPropertyValue("Comment")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Comment", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=10) _
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
        DataBinding(PropertyIndex:=2, StringSize:=10) _
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
        DataBinding(PropertyIndex:=3, StringSize:=30) _
        > _
        Public Property CR_ID01() As String

            Get
                Return Me.GetPropertyValue("CR_ID01")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CR_ID01", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=4, StringSize:=30) _
        > _
        Public Property CR_ID02() As String

            Get
                Return Me.GetPropertyValue("CR_ID02")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CR_ID02", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=5, StringSize:=20) _
        > _
        Public Property CR_ID03() As String

            Get
                Return Me.GetPropertyValue("CR_ID03")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CR_ID03", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=6, StringSize:=20) _
        > _
        Public Property CR_ID04() As String

            Get
                Return Me.GetPropertyValue("CR_ID04")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CR_ID04", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=7, StringSize:=10) _
        > _
        Public Property CR_ID05() As String

            Get
                Return Me.GetPropertyValue("CR_ID05")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CR_ID05", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=8, StringSize:=10) _
        > _
        Public Property CR_ID06() As String

            Get
                Return Me.GetPropertyValue("CR_ID06")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CR_ID06", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=9, StringSize:=4) _
        > _
        Public Property CR_ID07() As String

            Get
                Return Me.GetPropertyValue("CR_ID07")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CR_ID07", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=10) _
        > _
        Public Property CR_ID08() As Double

            Get
                Return Me.GetPropertyValue("CR_ID08")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("CR_ID08", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=11) _
        > _
        Public Property CR_ID09() As Integer

            Get
                Return Me.GetPropertyValue("CR_ID09")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("CR_ID09", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=12) _
        > _
        Public Property CR_ID10() As Short

            Get
                Return Me.GetPropertyValue("CR_ID10")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("CR_ID10", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=13) _
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
        DataBinding(PropertyIndex:=14, StringSize:=8) _
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
        DataBinding(PropertyIndex:=15, StringSize:=10) _
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
        DataBinding(PropertyIndex:=16, StringSize:=2) _
        > _
        Public Property DocType() As String

            Get
                Return Me.GetPropertyValue("DocType")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("DocType", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=17, StringSize:=10) _
        > _
        Public Property GLBatNbr() As String

            Get
                Return Me.GetPropertyValue("GLBatNbr")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("GLBatNbr", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=18) _
        > _
        Public Property LineNbr() As Short

            Get
                Return Me.GetPropertyValue("LineNbr")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("LineNbr", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=19) _
        > _
        Public Property Lupd_DateTime() As Integer

            Get
                Return Me.GetPropertyValue("Lupd_DateTime")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("Lupd_DateTime", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=20, StringSize:=8) _
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
        DataBinding(PropertyIndex:=21, StringSize:=10) _
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
        DataBinding(PropertyIndex:=22) _
        > _
        Public Property NoteID() As Integer

            Get
                Return Me.GetPropertyValue("NoteID")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("NoteID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=23, StringSize:=6) _
        > _
        Public Property PerPost() As String

            Get
                Return Me.GetPropertyValue("PerPost")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("PerPost", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=24, StringSize:=16) _
        > _
        Public Property ProjectID() As String

            Get
                Return Me.GetPropertyValue("ProjectID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ProjectID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=25) _
        > _
        Public Property RevAmount() As Double

            Get
                Return Me.GetPropertyValue("RevAmount")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("RevAmount", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=26) _
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
        DataBinding(PropertyIndex:=27) _
        > _
        Public Property RevFlag() As Short

            Get
                Return Me.GetPropertyValue("RevFlag")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("RevFlag", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=28, StringSize:=10) _
        > _
        Public Property SalesAcct() As String

            Get
                Return Me.GetPropertyValue("SalesAcct")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SalesAcct", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=29, StringSize:=24) _
        > _
        Public Property SalesSub() As String

            Get
                Return Me.GetPropertyValue("SalesSub")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SalesSub", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=30, StringSize:=1) _
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
        DataBinding(PropertyIndex:=31, StringSize:=32) _
        > _
        Public Property TaskID() As String

            Get
                Return Me.GetPropertyValue("TaskID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("TaskID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=32, StringSize:=30) _
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
        DataBinding(PropertyIndex:=33, StringSize:=30) _
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
        DataBinding(PropertyIndex:=34) _
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
        DataBinding(PropertyIndex:=35) _
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
        DataBinding(PropertyIndex:=36, StringSize:=10) _
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
        DataBinding(PropertyIndex:=37, StringSize:=10) _
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
        DataBinding(PropertyIndex:=38) _
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
        DataBinding(PropertyIndex:=39) _
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
Public bsmContractRev As smContractRev = New smContractRev, nsmContractRev As smContractRev = New smContractRev
End Module
