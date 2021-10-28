      --t_Stock仓库表
INSERT INTO [dbo].[t_Stock]
           ([FName]--收料仓库
		   ,[FItemID]--必填项，非文档要求，主键，要求手动插入最大ID
           )
     VALUES
           ('{0}'--'原材料'--stock_location.name   库存
		   ,{1}--141191
           )