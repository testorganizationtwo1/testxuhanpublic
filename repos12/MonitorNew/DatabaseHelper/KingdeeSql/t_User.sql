--t_User系统用户信息表
INSERT INTO [dbo].[t_Base_User]
           ([FName]-- 制单--审核人
		   ,[FPrimaryGroup]--必填项，非文档要求
		   ,[FUserID]--必填项，非文档要求，主键，要求手动插入最大ID
           )
     VALUES
           ('{0}'--'毛爷爷'	--res.users.name   
		   ,{1}--11
		   ,{2}--16615
		   )
