   --币别表
INSERT INTO [dbo].[t_Currency]
           ([FCurrencyID] --币别内码
           ,[FNumber] --币别代码
           ,[FName] --币别名称
           ,[FOperator] --运算符
           ,[FExchangeRate] --汇率
           ,[FScale] --小数位数
           ,[FFixRate] --换算率
           ,[FBrNo] --公司代码
           ,[FControl] --未知字段
           ,[FDeleted] --是否禁用
           ,[FSystemType] --未知字段
           ,[FClassTypeID] --未知字段
           )
     VALUES
           ({0} --1006 --币别内码
           ,'{1}' --'THB' --币别代码
           ,'{2}' --'泰铢' --币别名称
           ,'{3}' --'*' --运算符
           ,'{4}' --'1.0000000000' --汇率
           ,{5} --2 --小数位数
           ,{6} --0 --换算率
           ,'{7}'--'0' --公司代码
           ,{8} --0 --未知字段
           ,{9} --0 --是否禁用
           ,{10} --0 --未知字段
           ,{11} --1 --未知字段
           )