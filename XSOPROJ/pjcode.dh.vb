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
' <copyright file="pjcode.sdo.vb" company="Microsoft">
'     Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'------------------------------------------------------------------------------
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module sdoPJCODE
	
	Public Class PJCODE
			Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=4) _
        > _
        Public Property code_type() As String

            Get
                Return Me.GetPropertyValue("code_type")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("code_type", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=1, StringSize:=30) _
        > _
        Public Property code_value() As String

            Get
                Return Me.GetPropertyValue("code_value")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("code_value", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=2, StringSize:=30) _
        > _
        Public Property code_value_desc() As String

            Get
                Return Me.GetPropertyValue("code_value_desc")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("code_value_desc", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=3) _
        > _
        Public Property crtd_datetime() As Integer

            Get
                Return Me.GetPropertyValue("crtd_datetime")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("crtd_datetime", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=4, StringSize:=8) _
        > _
        Public Property crtd_prog() As String

            Get
                Return Me.GetPropertyValue("crtd_prog")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("crtd_prog", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=5, StringSize:=10) _
        > _
        Public Property crtd_user() As String

            Get
                Return Me.GetPropertyValue("crtd_user")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("crtd_user", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=6, StringSize:=30) _
        > _
        Public Property data1() As String

            Get
                Return Me.GetPropertyValue("data1")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("data1", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=7, StringSize:=16) _
        > _
        Public Property data2() As String

            Get
                Return Me.GetPropertyValue("data2")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("data2", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=8) _
        > _
        Public Property data3() As Integer

            Get
                Return Me.GetPropertyValue("data3")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("data3", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=9) _
        > _
        Public Property data4() As Double

            Get
                Return Me.GetPropertyValue("data4")
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("data4", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=10) _
        > _
        Public Property lupd_datetime() As Integer

            Get
                Return Me.GetPropertyValue("lupd_datetime")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("lupd_datetime", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=11, StringSize:=8) _
        > _
        Public Property lupd_prog() As String

            Get
                Return Me.GetPropertyValue("lupd_prog")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("lupd_prog", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=12, StringSize:=10) _
        > _
        Public Property lupd_user() As String

            Get
                Return Me.GetPropertyValue("lupd_user")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("lupd_user", setval)
            End Set

        End Property

        < _
        DataBinding(PropertyIndex:=13) _
        > _
        Public Property noteId() As Integer

            Get
                Return Me.GetPropertyValue("noteId")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("noteId", setval)
            End Set

        End Property

	End Class
Public bPJCODE As PJCODE = New PJCODE, nPJCODE As PJCODE = New PJCODE
End Module
