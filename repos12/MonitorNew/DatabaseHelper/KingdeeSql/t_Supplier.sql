      --t_Supplier供应商
INSERT INTO [dbo].[t_Supplier]
           ([FName]--供应商
		   ,[FItemID]--必填项，非文档要求，主键，要求手动插入最大ID
           ,[FNumber] --编码
           )
     VALUES
           ('{0}'--'腾讯控股'--res.partner.company_name   目前均未空
		   ,{1}--293625
           ,'{2}'--'111'
           )