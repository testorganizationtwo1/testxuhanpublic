          -- t_Base_Emp：职员表       
INSERT INTO [AIS20210817105740].[dbo].[t_Base_Emp]           
            ([FName] --职员名称
            ,[FItemID] --必填项，非文档要求，主键，要求手动插入最大ID
            )
      VALUES
            ('{0}'--'张三' --res.users.name
            ,{1}--293657
            )