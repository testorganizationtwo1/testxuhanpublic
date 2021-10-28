--t_StockPlace：仓位表
INSERT INTO [dbo].[t_StockPlace]
           ([FName]-- 仓位
		   ,[FNumber]--必填项，非文档要求
		   ,[FDetail]--必填项，非文档要求
		   ,[FParentID]--必填项，非文档要求
		   ,[FFullNumber]--必填项，非文档要求
		   ,[FSPID]--必填项，非文档要求，主键，要求手动插入最大ID
           )
     VALUES
           ('{0}'--'一号仓位'--stock_location.name   Stock
		   ,'{1}'--'55'
		   ,{2}--0
		   ,{3}--33
		   ,'{4}'--'完整number'
		   ,{5}--1
		   )
