  --基础资料主表
INSERT INTO [dbo].[t_Item]
           ([FItemID] --ID号  必填项，非文档要求，主键，要求手动插入最大ID
           ,[FItemClassID] --类型ID号
           ,[FNumber] --编码
           ,[FParentID] --父ID
           ,[FName] --名称
           ,[FDetail] --是否明细
           )
     VALUES
           ({0}--2576 
           ,{1}--1  --类型ID号
           ,'{2}'--'6.08' --编码
           ,{3}--513  --父ID
           ,'{4}'--'山西地区' --名称
           ,{5}--0  --是否明细
           )