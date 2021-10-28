  --单位类别表
INSERT INTO [dbo].[t_UnitGroup]
           ([FUnitGroupID] --组别内码
           ,[FName] --组别名称
           ,[FDefaultUnitID] --默认单位
           )
     VALUES
           ({0}--520  --组别内码
           ,'{1}'--'数量组' --组别名称
           ,{2}--252 --默认单位
           )