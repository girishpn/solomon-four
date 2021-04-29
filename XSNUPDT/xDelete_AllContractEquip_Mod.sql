if exists (select * from sysobjects where id = object_id('dbo.XDelete_AllContractEquip_Mod') and sysstat & 0xf = 4)
		drop proc XDelete_AllContractEquip_Mod
GO
create Proc XDelete_AllContractEquip_Mod @contractid varchar(10), @effectdate smalldatetime  as

if (SELECT COUNT(*) FROM XTB_Services WHERE contractid = @contractid AND @effectdate <= SYSDATETIME()) > 0 
AND (select count(*) from smcontractbill where status = 'O' and contractid =@contractid)=0
AND (select count(*) from smcontractrev where status = 'O' and contractid =@contractid)=0

BEGIN
	With SvcUpdate_View AS (
		SELECT TOP 1 * FROM smSvcEquipment
		WHERE ContractID = @contractid
		ORDER BY Crtd_DateTime DESC)

	UPDATE SvcUpdate_View SET ContractID = ''
	delete from smconequipment where contractid = @contractid 
END

delete from XTB_EQUIPREVIEW where equipid in (select equipid from smconequipment where contractid = @contractid)
delete from XTB_INSTALLBASE where equipid in (select equipid from smconequipment where contractid = @contractid)
GO 

if exists (select * from sysusers where name='07718158D19D4f5f9D23B55DBF5DF1')
begin
       GRANT EXECUTE on [XDelete_AllContractEquip_Mod] to [07718158D19D4f5f9D23B55DBF5DF1]
end
if exists (select * from sysusers where name='E8F575915A2E4897A517779C0DD7CE')
begin
       GRANT EXECUTE on [XDelete_AllContractEquip_Mod] to [E8F575915A2E4897A517779C0DD7CE]
end
if exists (select * from sysusers where name='MSDSL')
begin
       GRANT CONTROL on [XDelete_AllContractEquip_Mod] to [MSDSL]
End
if exists (select * from sysusers where name='TrustedWebService')
begin
       GRANT EXECUTE on [XDelete_AllContractEquip_Mod] to [TrustedWebService]
End
GO 
