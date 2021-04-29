' Solomon Cloud Solutions SDO Generation 1.0 
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module sdoXPROJINV

    Public Class XPROJINV
        Inherits SolomonDataObject
        < _
              DataBinding(PropertyIndex:=0) _
        > _
        Public Property Crtd_datetime() As Integer
            Get
                Return Me.GetPropertyValue("Crtd_datetime")
            End Get
            Set(ByVal setval As Integer)
                Me.SetPropertyValue("Crtd_datetime", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=1, StringSize:=8) _
        > _
        Public Property Crtd_prog() As String
            Get
                Return Me.GetPropertyValue("Crtd_prog")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("Crtd_prog", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=2, StringSize:=10) _
        > _
        Public Property Crtd_user() As String
            Get
                Return Me.GetPropertyValue("Crtd_user")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("Crtd_user", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=3, StringSize:=60) _
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
              DataBinding(PropertyIndex:=4, StringSize:=30) _
        > _
        Public Property Invtid() As String
            Get
                Return Me.GetPropertyValue("Invtid")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("Invtid", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=5) _
        > _
        Public Property Linenbr() As Short
            Get
                Return Me.GetPropertyValue("Linenbr")
            End Get
            Set(ByVal setval As Short)
                Me.SetPropertyValue("Linenbr", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=6, StringSize:=15) _
        > _
        Public Property Ordnbr() As String
            Get
                Return Me.GetPropertyValue("Ordnbr")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("Ordnbr", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=7, StringSize:=26) _
        > _
        Public Property Project() As String
            Get
                Return Me.GetPropertyValue("Project")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("Project", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=8) _
        > _
        Public Property QtyShip() As Double
            Get
                Return Me.GetPropertyValue("QtyShip")
            End Get
            Set(ByVal setval As Double)
                Me.SetPropertyValue("QtyShip", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=9, StringSize:=30) _
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
              DataBinding(PropertyIndex:=10, StringSize:=30) _
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
              DataBinding(PropertyIndex:=11) _
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
              DataBinding(PropertyIndex:=12) _
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
              DataBinding(PropertyIndex:=13) _
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
              DataBinding(PropertyIndex:=14) _
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
              DataBinding(PropertyIndex:=15) _
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
              DataBinding(PropertyIndex:=16) _
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
              DataBinding(PropertyIndex:=17) _
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
              DataBinding(PropertyIndex:=18) _
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
              DataBinding(PropertyIndex:=19, StringSize:=10) _
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
              DataBinding(PropertyIndex:=20, StringSize:=10) _
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
              DataBinding(PropertyIndex:=21) _
        > _
        Public Property ShipDateAct() As Integer
            Get
                Return Me.GetPropertyValue("ShipDateAct")
            End Get
            Set(ByVal setval As Integer)
                Me.SetPropertyValue("ShipDateAct", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=22, StringSize:=5) _
        > _
        Public Property ShipLineRef() As String
            Get
                Return Me.GetPropertyValue("ShipLineRef")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("ShipLineRef", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=23, StringSize:=15) _
        > _
        Public Property ShipperID() As String
            Get
                Return Me.GetPropertyValue("ShipperID")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("ShipperID", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=24, StringSize:=30) _
        > _
        Public Property SystemType() As String
            Get
                Return Me.GetPropertyValue("SystemType")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("SystemType", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=25) _
        > _
        Public Property TKO() As Short
            Get
                Return Me.GetPropertyValue("TKO")
            End Get
            Set(ByVal setval As Short)
                Me.SetPropertyValue("TKO", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=26, StringSize:=30) _
        > _
        Public Property user1() As String
            Get
                Return Me.GetPropertyValue("user1")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("user1", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=27, StringSize:=30) _
        > _
        Public Property user2() As String
            Get
                Return Me.GetPropertyValue("user2")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("user2", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=28) _
        > _
        Public Property user3() As Double
            Get
                Return Me.GetPropertyValue("user3")
            End Get
            Set(ByVal setval As Double)
                Me.SetPropertyValue("user3", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=29) _
        > _
        Public Property user4() As Double
            Get
                Return Me.GetPropertyValue("user4")
            End Get
            Set(ByVal setval As Double)
                Me.SetPropertyValue("user4", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=30) _
        > _
        Public Property user5() As Integer
            Get
                Return Me.GetPropertyValue("user5")
            End Get
            Set(ByVal setval As Integer)
                Me.SetPropertyValue("user5", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=31) _
        > _
        Public Property user6() As Integer
            Get
                Return Me.GetPropertyValue("user6")
            End Get
            Set(ByVal setval As Integer)
                Me.SetPropertyValue("user6", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=32, StringSize:=10) _
        > _
        Public Property user7() As String
            Get
                Return Me.GetPropertyValue("user7")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("user7", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=33, StringSize:=10) _
        > _
        Public Property user8() As String
            Get
                Return Me.GetPropertyValue("user8")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("user8", setval)
            End Set
        End Property

    End Class

    Public bXPROJINV As XPROJINV = New XPROJINV, nXPROJINV As XPROJINV = New XPROJINV
End Module
