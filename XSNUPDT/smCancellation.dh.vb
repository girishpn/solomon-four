'------------------------------------------------------------------------------
' <copyright file="smcance.sdo.vb" company="Microsoft">
'     Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'------------------------------------------------------------------------------

'VBTools Converter Version: 7.0.51129.0
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module sdoCANCE
	
	Public Class smCancellation
			Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=10) _
        > _
        Public Property CancellationCode() As String

            Get
                Return Me.GetPropertyValue("CancellationCode")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CancellationCode", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=30) _
        > _
        Public Property CancellationDesc() As String

            Get
                Return Me.GetPropertyValue("CancellationDesc")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("CancellationDesc", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=2) _
        > _
        Public Property Crtd_dateTime() As Integer

            Get
                Return Me.GetPropertyValue("Crtd_dateTime")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("Crtd_dateTime", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=3, StringSize:=8) _
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
        DataBinding(PropertyIndex:=4, StringSize:=10) _
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
        DataBinding(PropertyIndex:=5) _
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
        DataBinding(PropertyIndex:=6, StringSize:=8) _
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
        DataBinding(PropertyIndex:=7, StringSize:=10) _
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
        DataBinding(PropertyIndex:=8, StringSize:=30) _
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
        DataBinding(PropertyIndex:=9, StringSize:=30) _
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
        DataBinding(PropertyIndex:=10) _
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
        DataBinding(PropertyIndex:=11) _
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
        DataBinding(PropertyIndex:=12, StringSize:=10) _
        > _
        Public Property user5() As String

            Get
                Return Me.GetPropertyValue("user5")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("user5", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=13, StringSize:=10) _
        > _
        Public Property user6() As String

            Get
                Return Me.GetPropertyValue("user6")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("user6", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=14) _
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
        DataBinding(PropertyIndex:=15) _
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
Public bsmCancellation As smCancellation = New smCancellation, nsmCancellation As smCancellation = New smCancellation
End Module
