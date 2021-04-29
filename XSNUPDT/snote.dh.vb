'------------------------------------------------------------------------------
' <copyright file="snote.sdo.vb" company="Microsoft">
'     Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'------------------------------------------------------------------------------
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module Snote_sdo
	
	Public Class Snote
			Inherits SolomonDataObject
    < _
    DataBinding(PropertyIndex:=0) _
    > _
    Public Property dtRevisedDate() As Integer

        Get
            Return Me.GetPropertyValue("dtRevisedDate")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("dtRevisedDate", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=1) _
    > _
    Public Property nID() As Integer

        Get
            Return Me.GetPropertyValue("nID")
        End Get

        Set(ByVal setval As Integer)
            Me.SetPropertyValue("nID", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=2, StringSize:=20) _
    > _
    Public Property sLevelName() As String

        Get
            Return Me.GetPropertyValue("sLevelName")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("sLevelName", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=3, StringSize:=20) _
    > _
    Public Property sTableName() As String

        Get
            Return Me.GetPropertyValue("sTableName")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("sTableName", setval)
        End Set

    End Property

    < _
    DataBinding(PropertyIndex:=4, StringSize:=10000) _
    > _
    Public Property sNoteText() As String

        Get
            Return Me.GetPropertyValue("sNoteText")
        End Get

        Set(ByVal setval As String)
            Me.SetPropertyValue("sNoteText", setval)
        End Set

    End Property

	End Class
Public bSnote As Snote = New Snote, nSnote As Snote = New Snote
End Module
