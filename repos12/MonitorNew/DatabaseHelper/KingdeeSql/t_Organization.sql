         -- dbo.t_Organization:客户表
  INSERT INTO [dbo].[t_Organization]
              ([FName] --名称
               ,[FItemID] --必填项，非文档要求，主键，要求手动插入最大ID
               ,[FNumber] --编码
              )
       VALUES
             ('{0}'--'ADVANCED MOLDING COMPANY INC(菲律宾）'
              ,{1}--293670
              ,'{2}'--'002'
             )