 --保税监管类型表
INSERT INTO [dbo].[t_BaseBondedManageType]
           ([FID] --内码
           ,[FName] --保税监管名称
           ,[FNumber] --保税监管代码
           ,[FParentID] --父级内码
           ,[FLogic] --菜单控制
           ,[FDetail] --是否明细
           ,[FDiscontinued] --状态
           ,[FLevels] --级次
           ,[FFullNumber] --保税监管全名
           ,[FClassTypeID] --类别
           )
     VALUES
           ({0}--1007 --内码 
           ,'{1}'--'测试' --保税监管名称
           ,'{2}'--'8' --保税监管代码
           ,{3}--0 --父级内码
           ,{4}-- -1 --菜单控制
           ,{5}--1 --是否明细
           ,{6}--0 --状态
           ,{7}--1 --级次
           ,'{7}'--'NULL' --保税监管全名
           ,'{8}'--'1003501' --类别
           )