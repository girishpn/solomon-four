Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Module XINVENTORY_DH

      Public Class XINVENTORY
           Inherits SolomonDataObject
< _
DataBinding(PropertyIndex:=0) _
> _
Public Property crtd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("crtd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("crtd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=1, StringSize:=8) _
> _
Public Property crtd_prog As STRING

Get
    Return Me.GetPropertyValue("crtd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=2, StringSize:=10) _
> _
Public Property crtd_user As STRING

Get
    Return Me.GetPropertyValue("crtd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=3, StringSize:=10) _
> _
Public Property DistID As STRING

Get
    Return Me.GetPropertyValue("DistID")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("DistID", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=4, StringSize:=30) _
> _
Public Property DistName As STRING

Get
    Return Me.GetPropertyValue("DistName")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("DistName", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=5, StringSize:=30) _
> _
Public Property Invtid As STRING

Get
    Return Me.GetPropertyValue("Invtid")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Invtid", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=6) _
> _
Public Property lupd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("lupd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("lupd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=7, StringSize:=8) _
> _
Public Property lupd_prog As STRING

Get
    Return Me.GetPropertyValue("lupd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=8, StringSize:=10) _
> _
Public Property lupd_user As STRING

Get
    Return Me.GetPropertyValue("lupd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=9, StringSize:=30) _
> _
Public Property ManufPartNbr As STRING

Get
    Return Me.GetPropertyValue("ManufPartNbr")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("ManufPartNbr", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=10, StringSize:=30) _
> _
Public Property S4Future01 As STRING

Get
    Return Me.GetPropertyValue("S4Future01")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future01", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=11, StringSize:=30) _
> _
Public Property S4Future02 As STRING

Get
    Return Me.GetPropertyValue("S4Future02")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future02", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=12) _
> _
Public Property S4Future03 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future03")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future03", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=13) _
> _
Public Property S4Future04 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future04")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future04", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=14) _
> _
Public Property S4Future05 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future05")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future05", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=15) _
> _
Public Property S4Future06 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future06")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future06", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=16) _
> _
Public Property S4Future07 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future07")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future07", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=17) _
> _
Public Property S4Future08 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future08")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future08", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=18) _
> _
Public Property S4Future09 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future09")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future09", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=19) _
> _
Public Property S4Future10 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future10")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future10", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=20, StringSize:=10) _
> _
Public Property S4Future11 As STRING

Get
    Return Me.GetPropertyValue("S4Future11")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future11", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=21, StringSize:=10) _
> _
Public Property S4Future12 As STRING

Get
    Return Me.GetPropertyValue("S4Future12")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future12", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=22) _
> _
Public Property Serviceable As SHORT

Get
    Return Me.GetPropertyValue("Serviceable")
End Get

Set(Byval setval as SHORT )
   Me.SetPropertyValue("Serviceable", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=23, StringSize:=30) _
> _
Public Property user1 As STRING

Get
    Return Me.GetPropertyValue("user1")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user1", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=24, StringSize:=30) _
> _
Public Property user2 As STRING

Get
    Return Me.GetPropertyValue("user2")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user2", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=25) _
> _
Public Property user3 As DOUBLE

Get
    Return Me.GetPropertyValue("user3")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user3", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=26) _
> _
Public Property user4 As DOUBLE

Get
    Return Me.GetPropertyValue("user4")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user4", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=27) _
> _
Public Property user5 As INTEGER

Get
    Return Me.GetPropertyValue("user5")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user5", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=28) _
> _
Public Property user6 As INTEGER

Get
    Return Me.GetPropertyValue("user6")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user6", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=29, StringSize:=10) _
> _
Public Property user7 As STRING

Get
    Return Me.GetPropertyValue("user7")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user7", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=30, StringSize:=10) _
> _
Public Property user8 As STRING

Get
    Return Me.GetPropertyValue("user8")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user8", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=31, StringSize:=255) _
> _
Public Property BAANFreightAllow As STRING

Get
    Return Me.GetPropertyValue("BAANFreightAllow")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("BAANFreightAllow", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=32, StringSize:=255) _
> _
Public Property BAANInstallAllow As STRING

Get
    Return Me.GetPropertyValue("BAANInstallAllow")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("BAANInstallAllow", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=33, StringSize:=255) _
> _
Public Property CableType As STRING

Get
    Return Me.GetPropertyValue("CableType")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("CableType", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=34, StringSize:=1) _
> _
Public Property Category As STRING

Get
    Return Me.GetPropertyValue("Category")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Category", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=35, StringSize:=255) _
> _
Public Property CountryAvailability As STRING

Get
    Return Me.GetPropertyValue("CountryAvailability")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("CountryAvailability", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=36, StringSize:=255) _
> _
Public Property CutsheetURL As STRING

Get
    Return Me.GetPropertyValue("CutsheetURL")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("CutsheetURL", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=37, StringSize:=255) _
> _
Public Property IMGThumbnailFileName As STRING

Get
    Return Me.GetPropertyValue("IMGThumbnailFileName")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("IMGThumbnailFileName", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=38, StringSize:=1) _
> _
Public Property IncludeinPrcgBook As STRING

Get
    Return Me.GetPropertyValue("IncludeinPrcgBook")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("IncludeinPrcgBook", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=39, StringSize:=3) _
> _
Public Property Manufacturer As STRING

Get
    Return Me.GetPropertyValue("Manufacturer")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Manufacturer", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=40, StringSize:=1) _
> _
Public Property Material_Service As STRING

Get
    Return Me.GetPropertyValue("Material_Service")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Material_Service", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=41, StringSize:=255) _
> _
Public Property OGS As STRING

Get
    Return Me.GetPropertyValue("OGS")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("OGS", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=42, StringSize:=1) _
> _
Public Property Organization As STRING

Get
    Return Me.GetPropertyValue("Organization")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Organization", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=43, StringSize:=1) _
> _
Public Property PartEngReviewReq As STRING

Get
    Return Me.GetPropertyValue("PartEngReviewReq")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("PartEngReviewReq", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=44, StringSize:=255) _
> _
Public Property PartInsert_UpdReqBy As STRING

Get
    Return Me.GetPropertyValue("PartInsert_UpdReqBy")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("PartInsert_UpdReqBy", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=45) _
> _
Public Property PartLaborHours As DOUBLE

Get
    Return Me.GetPropertyValue("PartLaborHours")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("PartLaborHours", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=46, StringSize:=1) _
> _
Public Property PartPrimaryCategory As STRING

Get
    Return Me.GetPropertyValue("PartPrimaryCategory")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("PartPrimaryCategory", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=47, StringSize:=3) _
> _
Public Property PartSubCategory As STRING

Get
    Return Me.GetPropertyValue("PartSubCategory")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("PartSubCategory", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=48, StringSize:=1) _
> _
Public Property PartType As STRING

Get
    Return Me.GetPropertyValue("PartType")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("PartType", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=49, StringSize:=1) _
> _
Public Property ServiceablePart As STRING

Get
    Return Me.GetPropertyValue("ServiceablePart")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("ServiceablePart", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=50, StringSize:=1) _
> _
Public Property StatusCode As STRING

Get
    Return Me.GetPropertyValue("StatusCode")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("StatusCode", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=51, StringSize:=255) _
> _
Public Property TechnicalDataURL As STRING

Get
    Return Me.GetPropertyValue("TechnicalDataURL")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("TechnicalDataURL", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=52, StringSize:=255) _
> _
Public Property WiringDiagramFileNam As STRING

Get
    Return Me.GetPropertyValue("WiringDiagramFileNam")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("WiringDiagramFileNam", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=53, StringSize:=255) _
> _
Public Property DirectBuy As STRING

Get
    Return Me.GetPropertyValue("DirectBuy")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("DirectBuy", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=54, StringSize:=255) _
> _
Public Property Descr1 As STRING

Get
    Return Me.GetPropertyValue("Descr1")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Descr1", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=55, StringSize:=255) _
> _
Public Property Descr2 As STRING

Get
    Return Me.GetPropertyValue("Descr2")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Descr2", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=56) _
> _
Public Property USPrice As DOUBLE

Get
    Return Me.GetPropertyValue("USPrice")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("USPrice", setval)
End Set

End Property


   End Class
Public bXINVENTORY As XINVENTORY = New XINVENTORY, nXINVENTORY As XINVENTORY = New XINVENTORY


      Public Class XCUSTOMER
           Inherits SolomonDataObject
< _
DataBinding(PropertyIndex:=0, StringSize:=30) _
> _
Public Property BillTerms As STRING

Get
    Return Me.GetPropertyValue("BillTerms")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("BillTerms", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=1, StringSize:=30) _
> _
Public Property CCMF As STRING

Get
    Return Me.GetPropertyValue("CCMF")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("CCMF", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=2) _
> _
Public Property crtd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("crtd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("crtd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=3, StringSize:=8) _
> _
Public Property crtd_prog As STRING

Get
    Return Me.GetPropertyValue("crtd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=4, StringSize:=10) _
> _
Public Property crtd_user As STRING

Get
    Return Me.GetPropertyValue("crtd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=5, StringSize:=10) _
> _
Public Property InvFmt As STRING

Get
    Return Me.GetPropertyValue("InvFmt")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("InvFmt", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=6, StringSize:=15) _
> _
Public Property Custid As STRING

Get
    Return Me.GetPropertyValue("Custid")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Custid", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=7, StringSize:=30) _
> _
Public Property CustTypeF As STRING

Get
    Return Me.GetPropertyValue("CustTypeF")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("CustTypeF", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=8, StringSize:=10) _
> _
Public Property InstallCoord As STRING

Get
    Return Me.GetPropertyValue("InstallCoord")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("InstallCoord", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=9) _
> _
Public Property lupd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("lupd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("lupd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=10, StringSize:=8) _
> _
Public Property lupd_prog As STRING

Get
    Return Me.GetPropertyValue("lupd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=11, StringSize:=10) _
> _
Public Property lupd_user As STRING

Get
    Return Me.GetPropertyValue("lupd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=12, StringSize:=10) _
> _
Public Property Parent As STRING

Get
    Return Me.GetPropertyValue("Parent")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Parent", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=13, StringSize:=20) _
> _
Public Property Party As STRING

Get
    Return Me.GetPropertyValue("Party")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Party", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=14, StringSize:=10) _
> _
Public Property ProgramMgr As STRING

Get
    Return Me.GetPropertyValue("ProgramMgr")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("ProgramMgr", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=15, StringSize:=10) _
> _
Public Property ProjectMgr As STRING

Get
    Return Me.GetPropertyValue("ProjectMgr")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("ProjectMgr", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=16, StringSize:=80) _
> _
Public Property QSEmail As STRING

Get
    Return Me.GetPropertyValue("QSEmail")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("QSEmail", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=17, StringSize:=10) _
> _
Public Property RegionDir As STRING

Get
    Return Me.GetPropertyValue("RegionDir")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("RegionDir", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=18, StringSize:=30) _
> _
Public Property S4Future01 As STRING

Get
    Return Me.GetPropertyValue("S4Future01")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future01", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=19, StringSize:=30) _
> _
Public Property S4Future02 As STRING

Get
    Return Me.GetPropertyValue("S4Future02")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future02", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=20) _
> _
Public Property S4Future03 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future03")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future03", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=21) _
> _
Public Property S4Future04 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future04")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future04", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=22) _
> _
Public Property S4Future05 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future05")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future05", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=23) _
> _
Public Property S4Future06 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future06")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future06", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=24) _
> _
Public Property S4Future07 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future07")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future07", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=25) _
> _
Public Property S4Future08 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future08")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future08", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=26) _
> _
Public Property S4Future09 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future09")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future09", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=27) _
> _
Public Property S4Future10 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future10")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future10", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=28, StringSize:=10) _
> _
Public Property S4Future11 As STRING

Get
    Return Me.GetPropertyValue("S4Future11")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future11", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=29, StringSize:=10) _
> _
Public Property S4Future12 As STRING

Get
    Return Me.GetPropertyValue("S4Future12")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future12", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=30, StringSize:=2) _
> _
Public Property RevRecType As STRING

Get
    Return Me.GetPropertyValue("RevRecType")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("RevRecType", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=31, StringSize:=10) _
> _
Public Property Slsman1 As STRING

Get
    Return Me.GetPropertyValue("Slsman1")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Slsman1", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=32, StringSize:=10) _
> _
Public Property Slsman2 As STRING

Get
    Return Me.GetPropertyValue("Slsman2")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Slsman2", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=33, StringSize:=10) _
> _
Public Property Slsman3 As STRING

Get
    Return Me.GetPropertyValue("Slsman3")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Slsman3", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=34, StringSize:=10) _
> _
Public Property Slsman4 As STRING

Get
    Return Me.GetPropertyValue("Slsman4")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Slsman4", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=35) _
> _
Public Property Slsman1Pct As DOUBLE

Get
    Return Me.GetPropertyValue("Slsman1Pct")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("Slsman1Pct", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=36) _
> _
Public Property Slsman2Pct As DOUBLE

Get
    Return Me.GetPropertyValue("Slsman2Pct")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("Slsman2Pct", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=37) _
> _
Public Property Slsman3Pct As DOUBLE

Get
    Return Me.GetPropertyValue("Slsman3Pct")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("Slsman3Pct", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=38) _
> _
Public Property Slsman4Pct As DOUBLE

Get
    Return Me.GetPropertyValue("Slsman4Pct")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("Slsman4Pct", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=39, StringSize:=30) _
> _
Public Property SubClassID As STRING

Get
    Return Me.GetPropertyValue("SubClassID")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("SubClassID", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=40, StringSize:=30) _
> _
Public Property user1 As STRING

Get
    Return Me.GetPropertyValue("user1")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user1", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=41, StringSize:=30) _
> _
Public Property user2 As STRING

Get
    Return Me.GetPropertyValue("user2")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user2", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=42) _
> _
Public Property user3 As DOUBLE

Get
    Return Me.GetPropertyValue("user3")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user3", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=43) _
> _
Public Property user4 As DOUBLE

Get
    Return Me.GetPropertyValue("user4")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user4", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=44) _
> _
Public Property user5 As INTEGER

Get
    Return Me.GetPropertyValue("user5")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user5", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=45) _
> _
Public Property user6 As INTEGER

Get
    Return Me.GetPropertyValue("user6")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user6", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=46, StringSize:=10) _
> _
Public Property user7 As STRING

Get
    Return Me.GetPropertyValue("user7")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user7", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=47, StringSize:=10) _
> _
Public Property user8 As STRING

Get
    Return Me.GetPropertyValue("user8")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user8", setval)
End Set

End Property


   End Class
Public bXCUSTOMER As XCUSTOMER = New XCUSTOMER, nXCUSTOMER As XCUSTOMER = New XCUSTOMER


      Public Class XVENDOR
           Inherits SolomonDataObject
< _
DataBinding(PropertyIndex:=0) _
> _
Public Property crtd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("crtd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("crtd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=1, StringSize:=8) _
> _
Public Property crtd_prog As STRING

Get
    Return Me.GetPropertyValue("crtd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=2, StringSize:=10) _
> _
Public Property crtd_user As STRING

Get
    Return Me.GetPropertyValue("crtd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=3) _
> _
Public Property lupd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("lupd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("lupd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=4, StringSize:=8) _
> _
Public Property lupd_prog As STRING

Get
    Return Me.GetPropertyValue("lupd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=5, StringSize:=10) _
> _
Public Property lupd_user As STRING

Get
    Return Me.GetPropertyValue("lupd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=6) _
> _
Public Property MinBusEnt As SHORT

Get
    Return Me.GetPropertyValue("MinBusEnt")
End Get

Set(Byval setval as SHORT )
   Me.SetPropertyValue("MinBusEnt", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=7, StringSize:=80) _
> _
Public Property RemitEmailAddr As STRING

Get
    Return Me.GetPropertyValue("RemitEmailAddr")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("RemitEmailAddr", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=8, StringSize:=30) _
> _
Public Property S4Future01 As STRING

Get
    Return Me.GetPropertyValue("S4Future01")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future01", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=9, StringSize:=30) _
> _
Public Property S4Future02 As STRING

Get
    Return Me.GetPropertyValue("S4Future02")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future02", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=10) _
> _
Public Property S4Future03 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future03")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future03", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=11) _
> _
Public Property S4Future04 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future04")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future04", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=12) _
> _
Public Property S4Future05 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future05")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future05", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=13) _
> _
Public Property S4Future06 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future06")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future06", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=14) _
> _
Public Property S4Future07 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future07")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future07", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=15) _
> _
Public Property S4Future08 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future08")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future08", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=16) _
> _
Public Property S4Future09 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future09")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future09", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=17) _
> _
Public Property S4Future10 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future10")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future10", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=18, StringSize:=10) _
> _
Public Property S4Future11 As STRING

Get
    Return Me.GetPropertyValue("S4Future11")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future11", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=19, StringSize:=10) _
> _
Public Property S4Future12 As STRING

Get
    Return Me.GetPropertyValue("S4Future12")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future12", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=20) _
> _
Public Property SmlBusEnt As SHORT

Get
    Return Me.GetPropertyValue("SmlBusEnt")
End Get

Set(Byval setval as SHORT )
   Me.SetPropertyValue("SmlBusEnt", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=21, StringSize:=30) _
> _
Public Property user1 As STRING

Get
    Return Me.GetPropertyValue("user1")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user1", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=22, StringSize:=30) _
> _
Public Property user2 As STRING

Get
    Return Me.GetPropertyValue("user2")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user2", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=23) _
> _
Public Property user3 As DOUBLE

Get
    Return Me.GetPropertyValue("user3")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user3", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=24) _
> _
Public Property user4 As DOUBLE

Get
    Return Me.GetPropertyValue("user4")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user4", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=25) _
> _
Public Property user5 As INTEGER

Get
    Return Me.GetPropertyValue("user5")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user5", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=26) _
> _
Public Property user6 As INTEGER

Get
    Return Me.GetPropertyValue("user6")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user6", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=27, StringSize:=10) _
> _
Public Property user7 As STRING

Get
    Return Me.GetPropertyValue("user7")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user7", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=28, StringSize:=10) _
> _
Public Property user8 As STRING

Get
    Return Me.GetPropertyValue("user8")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user8", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=29, StringSize:=15) _
> _
Public Property Vendid As STRING

Get
    Return Me.GetPropertyValue("Vendid")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Vendid", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=30) _
> _
Public Property VetOwned As SHORT

Get
    Return Me.GetPropertyValue("VetOwned")
End Get

Set(Byval setval as SHORT )
   Me.SetPropertyValue("VetOwned", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=31) _
> _
Public Property WmnOwned As SHORT

Get
    Return Me.GetPropertyValue("WmnOwned")
End Get

Set(Byval setval as SHORT )
   Me.SetPropertyValue("WmnOwned", setval)
End Set

End Property


   End Class
Public bXVENDOR As XVENDOR = New XVENDOR, nXVENDOR As XVENDOR = New XVENDOR


      Public Class XPJEMPLOY
           Inherits SolomonDataObject
< _
DataBinding(PropertyIndex:=0) _
> _
Public Property crtd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("crtd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("crtd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=1, StringSize:=8) _
> _
Public Property crtd_prog As STRING

Get
    Return Me.GetPropertyValue("crtd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=2, StringSize:=10) _
> _
Public Property crtd_user As STRING

Get
    Return Me.GetPropertyValue("crtd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=3, StringSize:=10) _
> _
Public Property Employee As STRING

Get
    Return Me.GetPropertyValue("Employee")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Employee", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=4, StringSize:=10) _
> _
Public Property HomeArea As STRING

Get
    Return Me.GetPropertyValue("HomeArea")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("HomeArea", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=5, StringSize:=10) _
> _
Public Property HomeBranch As STRING

Get
    Return Me.GetPropertyValue("HomeBranch")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("HomeBranch", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=6, StringSize:=10) _
> _
Public Property HomeRegion As STRING

Get
    Return Me.GetPropertyValue("HomeRegion")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("HomeRegion", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=7) _
> _
Public Property lupd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("lupd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("lupd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=8, StringSize:=8) _
> _
Public Property lupd_prog As STRING

Get
    Return Me.GetPropertyValue("lupd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=9, StringSize:=10) _
> _
Public Property lupd_user As STRING

Get
    Return Me.GetPropertyValue("lupd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=10, StringSize:=30) _
> _
Public Property S4Future01 As STRING

Get
    Return Me.GetPropertyValue("S4Future01")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future01", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=11, StringSize:=30) _
> _
Public Property S4Future02 As STRING

Get
    Return Me.GetPropertyValue("S4Future02")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future02", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=12) _
> _
Public Property S4Future03 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future03")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future03", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=13) _
> _
Public Property S4Future04 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future04")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future04", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=14) _
> _
Public Property S4Future05 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future05")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future05", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=15) _
> _
Public Property S4Future06 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future06")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future06", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=16) _
> _
Public Property S4Future07 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future07")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future07", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=17) _
> _
Public Property S4Future08 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future08")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future08", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=18) _
> _
Public Property S4Future09 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future09")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future09", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=19) _
> _
Public Property S4Future10 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future10")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future10", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=20, StringSize:=10) _
> _
Public Property S4Future11 As STRING

Get
    Return Me.GetPropertyValue("S4Future11")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future11", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=21, StringSize:=10) _
> _
Public Property S4Future12 As STRING

Get
    Return Me.GetPropertyValue("S4Future12")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future12", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=22, StringSize:=30) _
> _
Public Property SlsTerritory As STRING

Get
    Return Me.GetPropertyValue("SlsTerritory")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("SlsTerritory", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=23, StringSize:=30) _
> _
Public Property SlsRegion As STRING

Get
    Return Me.GetPropertyValue("SlsRegion")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("SlsRegion", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=24, StringSize:=30) _
> _
Public Property SlsArea As STRING

Get
    Return Me.GetPropertyValue("SlsArea")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("SlsArea", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=25, StringSize:=30) _
> _
Public Property user1 As STRING

Get
    Return Me.GetPropertyValue("user1")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user1", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=26, StringSize:=30) _
> _
Public Property user2 As STRING

Get
    Return Me.GetPropertyValue("user2")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user2", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=27) _
> _
Public Property user3 As DOUBLE

Get
    Return Me.GetPropertyValue("user3")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user3", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=28) _
> _
Public Property user4 As DOUBLE

Get
    Return Me.GetPropertyValue("user4")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user4", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=29) _
> _
Public Property user5 As INTEGER

Get
    Return Me.GetPropertyValue("user5")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user5", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=30) _
> _
Public Property user6 As INTEGER

Get
    Return Me.GetPropertyValue("user6")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user6", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=31, StringSize:=10) _
> _
Public Property user7 As STRING

Get
    Return Me.GetPropertyValue("user7")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user7", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=32, StringSize:=10) _
> _
Public Property user8 As STRING

Get
    Return Me.GetPropertyValue("user8")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user8", setval)
End Set

End Property


   End Class
Public bXPJEMPLOY As XPJEMPLOY = New XPJEMPLOY, nXPJEMPLOY As XPJEMPLOY = New XPJEMPLOY


      Public Class XPARENT
           Inherits SolomonDataObject
< _
DataBinding(PropertyIndex:=0) _
> _
Public Property crtd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("crtd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("crtd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=1, StringSize:=8) _
> _
Public Property crtd_prog As STRING

Get
    Return Me.GetPropertyValue("crtd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=2, StringSize:=10) _
> _
Public Property crtd_user As STRING

Get
    Return Me.GetPropertyValue("crtd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("crtd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=3, StringSize:=60) _
> _
Public Property Descr As STRING

Get
    Return Me.GetPropertyValue("Descr")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("Descr", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=4) _
> _
Public Property lupd_datetime As INTEGER

Get
    Return Me.GetPropertyValue("lupd_datetime")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("lupd_datetime", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=5, StringSize:=8) _
> _
Public Property lupd_prog As STRING

Get
    Return Me.GetPropertyValue("lupd_prog")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_prog", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=6, StringSize:=10) _
> _
Public Property lupd_user As STRING

Get
    Return Me.GetPropertyValue("lupd_user")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("lupd_user", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=7, StringSize:=10) _
> _
Public Property ParentID As STRING

Get
    Return Me.GetPropertyValue("ParentID")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("ParentID", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=8, StringSize:=30) _
> _
Public Property S4Future01 As STRING

Get
    Return Me.GetPropertyValue("S4Future01")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future01", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=9, StringSize:=30) _
> _
Public Property S4Future02 As STRING

Get
    Return Me.GetPropertyValue("S4Future02")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future02", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=10) _
> _
Public Property S4Future03 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future03")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future03", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=11) _
> _
Public Property S4Future04 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future04")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future04", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=12) _
> _
Public Property S4Future05 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future05")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future05", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=13) _
> _
Public Property S4Future06 As DOUBLE

Get
    Return Me.GetPropertyValue("S4Future06")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("S4Future06", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=14) _
> _
Public Property S4Future07 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future07")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future07", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=15) _
> _
Public Property S4Future08 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future08")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future08", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=16) _
> _
Public Property S4Future09 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future09")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future09", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=17) _
> _
Public Property S4Future10 As INTEGER

Get
    Return Me.GetPropertyValue("S4Future10")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("S4Future10", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=18, StringSize:=10) _
> _
Public Property S4Future11 As STRING

Get
    Return Me.GetPropertyValue("S4Future11")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future11", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=19, StringSize:=10) _
> _
Public Property S4Future12 As STRING

Get
    Return Me.GetPropertyValue("S4Future12")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("S4Future12", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=20, StringSize:=30) _
> _
Public Property user1 As STRING

Get
    Return Me.GetPropertyValue("user1")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user1", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=21, StringSize:=30) _
> _
Public Property user2 As STRING

Get
    Return Me.GetPropertyValue("user2")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user2", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=22) _
> _
Public Property user3 As DOUBLE

Get
    Return Me.GetPropertyValue("user3")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user3", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=23) _
> _
Public Property user4 As DOUBLE

Get
    Return Me.GetPropertyValue("user4")
End Get

Set(Byval setval as DOUBLE )
   Me.SetPropertyValue("user4", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=24) _
> _
Public Property user5 As INTEGER

Get
    Return Me.GetPropertyValue("user5")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user5", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=25) _
> _
Public Property user6 As INTEGER

Get
    Return Me.GetPropertyValue("user6")
End Get

Set(Byval setval as INTEGER )
   Me.SetPropertyValue("user6", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=26, StringSize:=10) _
> _
Public Property user7 As STRING

Get
    Return Me.GetPropertyValue("user7")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user7", setval)
End Set

End Property

< _
DataBinding(PropertyIndex:=27, StringSize:=10) _
> _
Public Property user8 As STRING

Get
    Return Me.GetPropertyValue("user8")
End Get

Set(Byval setval as STRING )
   Me.SetPropertyValue("user8", setval)
End Set

End Property


   End Class
Public bXPARENT As XPARENT = New XPARENT, nXPARENT As XPARENT = New XPARENT

End Module
