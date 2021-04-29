' Solomon Cloud Solutions SDO Generation 1.0 
Option Strict Off 
Option Explicit On 
Imports Solomon.Kernel 
Module sdoXTB_SERVICESWRK  
  
  Public Class xtb_ServicesWrk 
        Inherits SolomonDataObject 
            < _  
                  DataBinding(PropertyIndex:=0) _  
            > _  
            Public Property ContractAmt() As Double  
                  Get  
                        Return Me.GetPropertyValue("ContractAmt")  
                  End Get  
                  Set (ByVal setval As Double)  
                        Me.SetPropertyValue("ContractAmt", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=1, StringSize:=10) _  
            > _  
            Public Property ContractID() As String  
                  Get  
                        Return Me.GetPropertyValue("ContractID")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("ContractID", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=2) _  
            > _  
            Public Property crtd_datetime() As Integer  
                  Get  
                        Return Me.GetPropertyValue("crtd_datetime")  
                  End Get  
                  Set (ByVal setval As Integer)  
                        Me.SetPropertyValue("crtd_datetime", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=3, StringSize:=8) _  
            > _  
            Public Property crtd_prog() As String  
                  Get  
                        Return Me.GetPropertyValue("crtd_prog")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("crtd_prog", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=4, StringSize:=10) _  
            > _  
            Public Property crtd_user() As String  
                  Get  
                        Return Me.GetPropertyValue("crtd_user")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("crtd_user", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=5, StringSize:=60) _  
            > _  
            Public Property Descr() As String  
                  Get  
                        Return Me.GetPropertyValue("Descr")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("Descr", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=6, StringSize:=10) _  
            > _  
            Public Property GroupCode() As String  
                  Get  
                        Return Me.GetPropertyValue("GroupCode")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("GroupCode", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=7, StringSize:=20) _  
            > _  
            Public Property LineItem() As String  
                  Get  
                        Return Me.GetPropertyValue("LineItem")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("LineItem", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=8) _  
            > _  
            Public Property LineNbr() As Short  
                  Get  
                        Return Me.GetPropertyValue("LineNbr")  
                  End Get  
                  Set (ByVal setval As Short)  
                        Me.SetPropertyValue("LineNbr", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=9) _  
            > _  
            Public Property lupd_datetime() As Integer  
                  Get  
                        Return Me.GetPropertyValue("lupd_datetime")  
                  End Get  
                  Set (ByVal setval As Integer)  
                        Me.SetPropertyValue("lupd_datetime", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=10, StringSize:=8) _  
            > _  
            Public Property lupd_prog() As String  
                  Get  
                        Return Me.GetPropertyValue("lupd_prog")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("lupd_prog", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=11, StringSize:=10) _  
            > _  
            Public Property lupd_user() As String  
                  Get  
                        Return Me.GetPropertyValue("lupd_user")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("lupd_user", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=12) _  
            > _  
            Public Property MonthAmt() As Double  
                  Get  
                        Return Me.GetPropertyValue("MonthAmt")  
                  End Get  
                  Set (ByVal setval As Double)  
                        Me.SetPropertyValue("MonthAmt", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=13, StringSize:=16) _  
            > _  
            Public Property Project() As String  
                  Get  
                        Return Me.GetPropertyValue("Project")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("Project", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=14, StringSize:=10) _  
            > _  
            Public Property ServClassID() As String  
                  Get  
                        Return Me.GetPropertyValue("ServClassID")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("ServClassID", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=15, StringSize:=30) _  
            > _  
            Public Property ServiceBillingID() As String  
                  Get  
                        Return Me.GetPropertyValue("ServiceBillingID")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("ServiceBillingID", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=16, StringSize:=30) _  
            > _  
            Public Property ServItemID() As String  
                  Get  
                        Return Me.GetPropertyValue("ServItemID")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("ServItemID", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=17, StringSize:=1) _  
            > _  
            Public Property Status() As String  
                  Get  
                        Return Me.GetPropertyValue("Status")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("Status", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=18) _  
            > _  
            Public Property StatusDate() As Integer  
                  Get  
                        Return Me.GetPropertyValue("StatusDate")  
                  End Get  
                  Set (ByVal setval As Integer)  
                        Me.SetPropertyValue("StatusDate", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=19, StringSize:=60) _  
            > _  
            Public Property StatusReason() As String  
                  Get  
                        Return Me.GetPropertyValue("StatusReason")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("StatusReason", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=20, StringSize:=30) _  
            > _  
            Public Property SystemType() As String  
                  Get  
                        Return Me.GetPropertyValue("SystemType")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("SystemType", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=21, StringSize:=30) _  
            > _  
            Public Property user1() As String  
                  Get  
                        Return Me.GetPropertyValue("user1")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("user1", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=22, StringSize:=30) _  
            > _  
            Public Property user2() As String  
                  Get  
                        Return Me.GetPropertyValue("user2")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("user2", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=23) _  
            > _  
            Public Property user3() As Double  
                  Get  
                        Return Me.GetPropertyValue("user3")  
                  End Get  
                  Set (ByVal setval As Double)  
                        Me.SetPropertyValue("user3", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=24) _  
            > _  
            Public Property user4() As Double  
                  Get  
                        Return Me.GetPropertyValue("user4")  
                  End Get  
                  Set (ByVal setval As Double)  
                        Me.SetPropertyValue("user4", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=25, StringSize:=10) _  
            > _  
            Public Property user5() As String  
                  Get  
                        Return Me.GetPropertyValue("user5")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("user5", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=26, StringSize:=10) _  
            > _  
            Public Property user6() As String  
                  Get  
                        Return Me.GetPropertyValue("user6")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("user6", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=27) _  
            > _  
            Public Property user7() As Integer  
                  Get  
                        Return Me.GetPropertyValue("user7")  
                  End Get  
                  Set (ByVal setval As Integer)  
                        Me.SetPropertyValue("user7", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=28) _  
            > _  
            Public Property user8() As Integer  
                  Get  
                        Return Me.GetPropertyValue("user8")  
                  End Get  
                  Set (ByVal setval As Integer)  
                        Me.SetPropertyValue("user8", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=29, StringSize:=47) _  
            > _  
            Public Property UserID() As String  
                  Get  
                        Return Me.GetPropertyValue("UserID")  
                  End Get  
                  Set (ByVal setval As String)  
                        Me.SetPropertyValue("UserID", setval)  
                  End Set  
            End Property  
 
            < _  
                  DataBinding(PropertyIndex:=30) _  
            > _  
            Public Property Warranty() As Short  
                  Get  
                        Return Me.GetPropertyValue("Warranty")  
                  End Get  
                  Set (ByVal setval As Short)  
                        Me.SetPropertyValue("Warranty", setval)  
                  End Set  
            End Property  
 
  End Class  
  
  Public bxtb_ServicesWrk As xtb_ServicesWrk = New xtb_ServicesWrk, nxtb_ServicesWrk As xtb_ServicesWrk = New xtb_ServicesWrk  
End Module  
