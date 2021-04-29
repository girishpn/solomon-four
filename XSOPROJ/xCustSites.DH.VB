Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module xCUSTSites_DH

       Public Class xCustSites
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=16) _
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
        DataBinding(PropertyIndex:=1, StringSize:=10) _
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
     DataBinding(PropertyIndex:=2, StringSize:=10) _
     > _
     Public Property UserID() As String

            Get
                Return Me.GetPropertyValue("UserID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("UserID", setval)
            End Set
        End Property

    End Class

    Public bxCustSites As xCustSites = New xCustSites, nxCustSites As xCustSites = New xCustSites
End Module