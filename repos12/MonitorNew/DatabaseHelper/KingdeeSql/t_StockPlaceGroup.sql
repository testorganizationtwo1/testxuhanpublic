--t_StockPlaceGroup：仓位分组表
INSERT INTO [dbo].[t_StockPlaceGroup]
           ([FSPGroupID] --仓位组ID
           ,[FNumber] --仓位代码
           ,[FName] --仓位名
           ,[FDefaultSPID] --必填项
           ,[FDeleted] --是否禁用

          
           )
     VALUES
           ({0}--7
           ,'{1}'--'05'
           ,'{2}'--'上工富怡一楼123'
           ,{3}--0
           ,{4}--0
          
           )
		   
