'------------------------------------------------------------------------------
' <copyright file="smbranc.sdo.vb" company="Microsoft">
'     Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'------------------------------------------------------------------------------

'VBTools Converter Version: 7.0.51129.0
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module sdoBRANC
	
	Public Class smBranch
			Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=30) _
        > _
        Public Property Addr1() As String

            Get
                Return Me.GetPropertyValue("Addr1")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Addr1", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=30) _
        > _
        Public Property Addr2() As String

            Get
                Return Me.GetPropertyValue("Addr2")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Addr2", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=2, StringSize:=30) _
        > _
        Public Property Attn() As String

            Get
                Return Me.GetPropertyValue("Attn")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Attn", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=3, StringSize:=10) _
        > _
        Public Property BranchId() As String

            Get
                Return Me.GetPropertyValue("BranchId")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("BranchId", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=4, StringSize:=30) _
        > _
        Public Property City() As String

            Get
                Return Me.GetPropertyValue("City")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("City", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=5, StringSize:=3) _
        > _
        Public Property Country() As String

            Get
                Return Me.GetPropertyValue("Country")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Country", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=6, StringSize:=10) _
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
        DataBinding(PropertyIndex:=7) _
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
        DataBinding(PropertyIndex:=8, StringSize:=8) _
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
        DataBinding(PropertyIndex:=9, StringSize:=10) _
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
        DataBinding(PropertyIndex:=10, StringSize:=15) _
        > _
        Public Property FaxNbr() As String

            Get
                Return Me.GetPropertyValue("FaxNbr")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("FaxNbr", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=11) _
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
        DataBinding(PropertyIndex:=12, StringSize:=8) _
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
        DataBinding(PropertyIndex:=13, StringSize:=10) _
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
        DataBinding(PropertyIndex:=14, StringSize:=30) _
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
        DataBinding(PropertyIndex:=15) _
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
        DataBinding(PropertyIndex:=16, StringSize:=15) _
        > _
        Public Property Phone() As String

            Get
                Return Me.GetPropertyValue("Phone")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Phone", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=17, StringSize:=30) _
        > _
        Public Property SB_ID01() As String

            Get
                Return Me.GetPropertyValue("SB_ID01")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SB_ID01", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=18, StringSize:=30) _
        > _
        Public Property SB_ID02() As String

            Get
                Return Me.GetPropertyValue("SB_ID02")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SB_ID02", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=19, StringSize:=20) _
        > _
        Public Property SB_ID03() As String

            Get
                Return Me.GetPropertyValue("SB_ID03")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SB_ID03", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=20, StringSize:=20) _
        > _
        Public Property SB_ID04() As String

            Get
                Return Me.GetPropertyValue("SB_ID04")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SB_ID04", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=21, StringSize:=10) _
        > _
        Public Property SB_ID05() As String

            Get
                Return Me.GetPropertyValue("SB_ID05")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SB_ID05", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=22, StringSize:=10) _
        > _
        Public Property SB_ID06() As String

            Get
                Return Me.GetPropertyValue("SB_ID06")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SB_ID06", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=23, StringSize:=4) _
        > _
        Public Property SB_ID07() As String

            Get
                Return Me.GetPropertyValue("SB_ID07")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("SB_ID07", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=24) _
        > _
        Public Property SB_ID08() As Double

            Get
                Return Me.GetPropertyValue("SB_ID08")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("SB_ID08", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=25) _
        > _
        Public Property SB_ID09() As Integer

            Get
                Return Me.GetPropertyValue("SB_ID09")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("SB_ID09", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=26) _
        > _
        Public Property SB_ID10() As Short

            Get
                Return Me.GetPropertyValue("SB_ID10")
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("SB_ID10", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=27, StringSize:=3) _
        > _
        Public Property ShortKey() As String

            Get
                Return Me.GetPropertyValue("ShortKey")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ShortKey", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=28, StringSize:=3) _
        > _
        Public Property StateID() As String

            Get
                Return Me.GetPropertyValue("StateID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("StateID", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=29, StringSize:=30) _
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
        DataBinding(PropertyIndex:=30, StringSize:=30) _
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
        DataBinding(PropertyIndex:=31) _
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
        DataBinding(PropertyIndex:=32) _
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
        DataBinding(PropertyIndex:=33, StringSize:=10) _
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
        DataBinding(PropertyIndex:=34, StringSize:=10) _
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
        DataBinding(PropertyIndex:=35) _
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
        DataBinding(PropertyIndex:=36) _
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
        DataBinding(PropertyIndex:=37, StringSize:=9) _
        > _
        Public Property Zip() As String

            Get
                Return Me.GetPropertyValue("Zip")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Zip", setval)
            End Set

        End Property

	End Class
Public bsmBranch As smBranch = New smBranch, nsmBranch As smBranch = New smBranch
End Module
