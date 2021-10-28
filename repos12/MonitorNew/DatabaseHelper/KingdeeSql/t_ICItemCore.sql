--t_ICItem 物料表
INSERT INTO [dbo].[t_ICItemCore]
           ([FNumber]--物料代码
		   ,[FName]--物料名称
		   ,[FModel]--规格型号
		   ,[FItemID]--必填项，非文档要求，主键，要求手动插入最大ID
           )
     VALUES
           ('{0}'--'原材料'--product.product.material_code    800499990001
		   ,'{1}'--'螺丝'--product.product.name    V12发动机
		   ,'{2}'--'6mm'--product.product.product_model    RPCE-NM-FE-7-275(550+40)x680-B-F9-VR1-NA-1P220
		   ,{3}--293872
		   )