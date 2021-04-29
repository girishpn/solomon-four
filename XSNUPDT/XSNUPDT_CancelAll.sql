if exists (select * from sysobjects where id = object_id('dbo.XSNUPDT_CancelALL') and sysstat & 0xf = 4)
		drop proc XSNUPDT_CancelALL
GO

create Proc XSNUPDT_CancelALL @contractid varchar(10), @effectdate smalldatetime as
select count(*) from smcontract where
startdate >= @effectdate
and contractid = @contractid
And not exists (select * from smcontractbill where contractid = @contractid and status = 'P')  -- billing must be all opened
And not exists (select * from smcontractrev where contractid = @contractid and status = 'P')  --revenue must be all opened
GO

if exists (select * from sysusers where name='07718158D19D4f5f9D23B55DBF5DF1')
begin
       GRANT EXECUTE on [XSNUPDT_CancelALL] to [07718158D19D4f5f9D23B55DBF5DF1]
end
if exists (select * from sysusers where name='E8F575915A2E4897A517779C0DD7CE')
begin
       GRANT EXECUTE on [XSNUPDT_CancelALL] to [E8F575915A2E4897A517779C0DD7CE]
end
if exists (select * from sysusers where name='MSDSL')
begin
       GRANT CONTROL on [XSNUPDT_CancelALL] to [MSDSL]
End
if exists (select * from sysusers where name='TrustedWebService')
begin
       GRANT EXECUTE on [XSNUPDT_CancelALL] to [TrustedWebService]
End
GO 
