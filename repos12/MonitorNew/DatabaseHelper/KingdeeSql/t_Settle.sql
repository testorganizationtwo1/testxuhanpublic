 ---结算方式表
INSERT INTO .[dbo].[t_Settle]
           ([FBrNo] --公司代码
           ,[FItemID] --结算方式内码
           ,[FName]  --结算方式名称
           ,[FNumber] --结算方式代码
           )
     VALUES
           ({0}--0
           ,{1}--9
           ,'{2}'--'信用卡'
           ,'{3}'--'XYK01'
           )