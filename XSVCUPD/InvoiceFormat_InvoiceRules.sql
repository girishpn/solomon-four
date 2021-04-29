if exists (select * from sysobjects where id = object_id('dbo.XOthChanges_InvoiceFormat') and sysstat & 0xf = 4)
		drop proc XOthChanges_InvoiceFormat
GO

create Proc XOthChanges_InvoiceFormat @contractid varchar(10), @invFmt varchar(10) as
if @invfmt = 'SS-SB'
	begin
		update xtb_smcontract set invoiceformatid = 'SS-SB' where contractid = @contractid
	end
else
	begin
		update xtb_smcontract set invoiceformatid ='MS-SB' where contractid = @contractid
	end

	GO

if exists (select * from sysusers where name='07718158D19D4f5f9D23B55DBF5DF1')
begin
       GRANT EXECUTE on [XOthChanges_InvoiceFormat] to [07718158D19D4f5f9D23B55DBF5DF1]
end
if exists (select * from sysusers where name='E8F575915A2E4897A517779C0DD7CE')
begin
       GRANT EXECUTE on [XOthChanges_InvoiceFormat] to [E8F575915A2E4897A517779C0DD7CE]
end
if exists (select * from sysusers where name='MSDSL')
begin
       GRANT CONTROL on [XOthChanges_InvoiceFormat] to [MSDSL]
End
if exists (select * from sysusers where name='TrustedWebService')
begin
       GRANT EXECUTE on [XOthChanges_InvoiceFormat] to [TrustedWebService]
End
GO 

if exists (select * from sysobjects where id = object_id('dbo.XOthChanges_InvoiceRules') and sysstat & 0xf = 4)
		drop proc XOthChanges_InvoiceRules
GO
create Proc XOthChanges_InvoiceRules @contractid varchar(10), @invRls varchar(10) as
if @invRls = 'ARREARS'
	begin
		update xtb_smcontract set invoiceformatid = 'ARREARS' where contractid = @contractid
	end
else
	begin
		update xtb_smcontract set invoiceformatid ='ADVANCE' where contractid = @contractid
	end

	GO

if exists (select * from sysusers where name='07718158D19D4f5f9D23B55DBF5DF1')
begin
       GRANT EXECUTE on [XOthChanges_InvoiceRules] to [07718158D19D4f5f9D23B55DBF5DF1]
end
if exists (select * from sysusers where name='E8F575915A2E4897A517779C0DD7CE')
begin
       GRANT EXECUTE on [XOthChanges_InvoiceRules] to [E8F575915A2E4897A517779C0DD7CE]
end
if exists (select * from sysusers where name='MSDSL')
begin
       GRANT CONTROL on [XOthChanges_InvoiceRules] to [MSDSL]
End
if exists (select * from sysusers where name='TrustedWebService')
begin
       GRANT EXECUTE on [XOthChanges_InvoiceRules] to [TrustedWebService]
End
GO 