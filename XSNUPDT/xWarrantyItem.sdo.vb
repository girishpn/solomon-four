' Solomon Cloud Solutions SDO Generation 1.0 
Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module sdoXWARRANTYITEM

    Public Class xWarrantyItem
        Inherits SolomonDataObject
        < _
              DataBinding(PropertyIndex:=0) _
        > _
        Public Property BeginDate() As Integer
            Get
                Return Me.GetPropertyValue("BeginDate")
            End Get
            Set(ByVal setval As Integer)
                Me.SetPropertyValue("BeginDate", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=1, StringSize:=2) _
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
              DataBinding(PropertyIndex:=2) _
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
        Public Property EndDate() As Integer
            Get
                Return Me.GetPropertyValue("EndDate")
            End Get
            Set(ByVal setval As Integer)
                Me.SetPropertyValue("EndDate", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=6, StringSize:=4) _
        > _
        Public Property EndTime() As String
            Get
                Return Me.GetPropertyValue("EndTime")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("EndTime", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=7, StringSize:=1) _
        > _
        Public Property Hours() As String
            Get
                Return Me.GetPropertyValue("Hours")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("Hours", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=8) _
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
              DataBinding(PropertyIndex:=9, StringSize:=8) _
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
              DataBinding(PropertyIndex:=10, StringSize:=10) _
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
              DataBinding(PropertyIndex:=11, StringSize:=4) _
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
              DataBinding(PropertyIndex:=12, StringSize:=30) _
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
              DataBinding(PropertyIndex:=13, StringSize:=30) _
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
              DataBinding(PropertyIndex:=14) _
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
              DataBinding(PropertyIndex:=15) _
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
              DataBinding(PropertyIndex:=16) _
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
              DataBinding(PropertyIndex:=17) _
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
              DataBinding(PropertyIndex:=18) _
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
              DataBinding(PropertyIndex:=19) _
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
              DataBinding(PropertyIndex:=20) _
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
              DataBinding(PropertyIndex:=21) _
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
              DataBinding(PropertyIndex:=22, StringSize:=10) _
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
              DataBinding(PropertyIndex:=23, StringSize:=10) _
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
              DataBinding(PropertyIndex:=24, StringSize:=60) _
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
              DataBinding(PropertyIndex:=25, StringSize:=4) _
        > _
        Public Property StartTime() As String
            Get
                Return Me.GetPropertyValue("StartTime")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("StartTime", setval)
            End Set
        End Property

        < _
              DataBinding(PropertyIndex:=26, StringSize:=1) _
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
              DataBinding(PropertyIndex:=27, StringSize:=30) _
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
              DataBinding(PropertyIndex:=28, StringSize:=30) _
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
              DataBinding(PropertyIndex:=29) _
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
              DataBinding(PropertyIndex:=30) _
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
              DataBinding(PropertyIndex:=31, StringSize:=10) _
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
              DataBinding(PropertyIndex:=32, StringSize:=10) _
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
              DataBinding(PropertyIndex:=33) _
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
              DataBinding(PropertyIndex:=34) _
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
              DataBinding(PropertyIndex:=35, StringSize:=30) _
        > _
        Public Property WarrantyItem() As String
            Get
                Return Me.GetPropertyValue("WarrantyItem")
            End Get
            Set(ByVal setval As String)
                Me.SetPropertyValue("WarrantyItem", setval)
            End Set
        End Property

    End Class

    Public bxWarrantyItem As xWarrantyItem = New xWarrantyItem, nxWarrantyItem As xWarrantyItem = New xWarrantyItem
End Module
