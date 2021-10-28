     --部门表
INSERT INTO [dbo].[t_Department]
           ([FName]--领料部门
		   ,[FItemID]--必填项，非文档要求，主键，要求手动插入最大ID
           )
     VALUES
           ('{0}'--'总经办'
		   ,{1}--1008696966
           )