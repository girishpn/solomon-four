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
'------------------------------------------------------------------------------
' <copyright file="custclass.sdo.vb" company="Microsoft">
'     Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'------------------------------------------------------------------------------
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module sdocustclass
	
	Public Class CustClass
			Inherits SolomonDataObject
        < _
    DataBinding(PropertyIndex:=0, StringSize:=10) _
    > _
    Public Property ARAcct() As String

            Get
                Return Me.GetPropertyValue("ARAcct")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ARAcct", setval)
            End Set

        End Property

    < _
    DataBinding(PropertyIndex:=1, StringSize:=24) _
    > _
    Public Property ARSub() As String

        Get
            Return Me.GetPropertyValue("ARSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("ARSub", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=2, StringSize:=6) _
    > _
    Public Property ClassId() As String

        Get
            Return Me.GetPropertyValue("ClassId")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("ClassId", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=3) _
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
    DataBinding(PropertyIndex:=4, StringSize:=8) _
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
    DataBinding(PropertyIndex:=5, StringSize:=10) _
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
    DataBinding(PropertyIndex:=6, StringSize:=30) _
    > _
    Public Property Descr() As String

        Get
            Return Me.GetPropertyValue("Descr")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("Descr", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=7) _
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
    DataBinding(PropertyIndex:=8, StringSize:=8) _
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
    DataBinding(PropertyIndex:=9, StringSize:=10) _
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
    DataBinding(PropertyIndex:=10) _
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
    DataBinding(PropertyIndex:=11, StringSize:=10) _
    > _
    Public Property PrcLvlID() As String

        Get
            Return Me.GetPropertyValue("PrcLvlID")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("PrcLvlID", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=12, StringSize:=10) _
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
    DataBinding(PropertyIndex:=13, StringSize:=24) _
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
    DataBinding(PropertyIndex:=14, StringSize:=6) _
    > _
    Public Property PriceClass() As String

        Get
            Return Me.GetPropertyValue("PriceClass")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("PriceClass", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=15, StringSize:=30) _
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
    DataBinding(PropertyIndex:=16, StringSize:=30) _
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
    DataBinding(PropertyIndex:=17) _
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
    DataBinding(PropertyIndex:=18) _
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
    DataBinding(PropertyIndex:=19) _
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
    DataBinding(PropertyIndex:=20) _
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
    DataBinding(PropertyIndex:=21) _
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
    DataBinding(PropertyIndex:=22) _
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
    DataBinding(PropertyIndex:=23) _
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
    DataBinding(PropertyIndex:=24) _
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
    DataBinding(PropertyIndex:=25, StringSize:=10) _
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
    DataBinding(PropertyIndex:=26, StringSize:=10) _
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
    DataBinding(PropertyIndex:=27, StringSize:=10) _
    > _
    Public Property SlsAcct() As String

        Get
            Return Me.GetPropertyValue("SlsAcct")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("SlsAcct", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=28, StringSize:=24) _
    > _
    Public Property SlsSub() As String

        Get
            Return Me.GetPropertyValue("SlsSub")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("SlsSub", setval)
        End Set

    End Property

        < _
        DataBinding(PropertyIndex:=29, StringSize:=2) _
        > _
        Public Property Terms() As String

            Get
                Return Me.GetPropertyValue("Terms")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Terms", setval)
            End Set

        End Property

    < _
    DataBinding(PropertyIndex:=30) _
    > _
    Public Property TradeDisc() As Double

        Get
            Return Me.GetPropertyValue("TradeDisc")
        End Get

        Set(ByVal setval As Double)
            Me.SetPropertyValue("TradeDisc", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=31, StringSize:=30) _
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
    DataBinding(PropertyIndex:=32, StringSize:=30) _
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
    DataBinding(PropertyIndex:=33) _
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
    DataBinding(PropertyIndex:=34) _
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
    DataBinding(PropertyIndex:=35, StringSize:=10) _
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
    DataBinding(PropertyIndex:=36, StringSize:=10) _
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
    DataBinding(PropertyIndex:=37) _
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
    DataBinding(PropertyIndex:=38) _
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
Public bCustClass As CustClass = New CustClass, nCustClass As CustClass = New CustClass
End Module
