  --单据类型表 
INSERT INTO [dbo].[ICBillType]
           ([FID] --内码
           ,[FNumber] --代码
           ,[FName] --名称
           ,[FAcctID] --会计科目
           ,[FNote] --备注
           ,[FSystemic] --是否系统预设
           )
     VALUES
           ({0}--10 --内码
           ,'{1}'--'test' --代码
           ,'{2}'--'测试' --名称
           ,{3}--NULL --会计科目
           ,'{4}'--'备注'
           ,{5}--0 --是否系统预设
           )