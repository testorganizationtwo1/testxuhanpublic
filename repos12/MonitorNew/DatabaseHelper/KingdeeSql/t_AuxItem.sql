  --辅助资料信息表
INSERT INTO [dbo].[t_AuxItem]
           ([FItemID] --内码
           ,[FItemClassID] --辅助属性类别内码
           ,[FNumber] --编码
           ,[FName]  --名称
           ,[FParentID]  --上级内码
           ,[FUnUsed]  --是否使用
           ,[FFullNumber]  --长编码（与编码相同）
           ,[FDeleted]  --是否已删除
           ,[FShortNumber] --短编码（与编码相同）
           ,[FFullName]  --全名（与名称相同）
           )
     VALUES
           ({0}-- 22 --内码
           ,{1}-- 3007 --辅助属性类别内码
           ,'{2}'-- 'BT001' --编码
           ,'{3}'--'产品变体' --名称
           ,{4}--0 --上级内码
           ,{5}--0 --是否使用
           ,'{6}'--'null' --长编码（与编码相同)
           ,{7}-- 0 --是否已删除
           ,'{8}'--'null' --短编码（与编码相同）
           ,'{9}'-- 'null' --全名（与名称相同）
           )