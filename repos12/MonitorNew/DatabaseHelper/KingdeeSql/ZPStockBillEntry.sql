  --虚仓出入库单据分录表
INSERT INTO [dbo].[ZPStockBillEntry]
           ([FInterID]  --单据号
           ,[FEntryID]  --行号
           ,[FItemID]  --物料代码  外键，要求手动插入供应商表（t_ICItem）最大ID
           ,[FQty]  --基本单位数量
           ,[FBatchNo]  --批号
           ,[FNote]  --备注
           ,[FUnitID]  --单位  
           ,[FAuxQty]  --数量
           ,[FSourceEntryID]  --源单分录
           ,[FMapNumber]  --对应代码
           ,[FMapName]  --对应名称
           ,[FKFDate]  --生产/采购日期
           ,[FKFPeriod]  --保质期(天)
           ,[FDCSPID]  --仓位
           ,[FAuxPropID]  --辅助属性
           ,[FSecCoefficient]  --换算率
           ,[FSecQty]  --辅助数量
           ,[FSourceTranType]  --源单类型
           ,[FSourceInterId]  --源单内码
           ,[FSourceBillNo]  --源单单号
           ,[FDCStockID]  --仓库  外键，要求手动插入供应商表（t_Stock）最大ID
           ,[FPeriodDate]  --有效期至  --日期类型不能赋值给字符串
           )
     VALUES
           ({0}--5  --单据号  stock.picking	name
           ,{1}--1  --行号  
           ,{2}--2267  --物料代码  stock.picking	product_id. stock.picking	product_id
           ,'{4}'--'10.0000000000'  --基本单位数量
           ,'{5}'--'NULL'  --批号  stock.move.line.lot_name
           ,'{6}'--'null'  --备注  stock.picking.note
           ,{7}--232  --单位  (select t2.FItemID,t1.FName FNumber,t2.Fname from   t_UnitGroup t1,t_MeasureUnit t2 where t1.FUnitGroupID=t2.FUnitGroupID)  stock.move.product_uom
           ,'{8}'--'10.0000000000'  --数量  
           ,{9}--0  --源单分录
           ,'{10}'--'NULL'  --对应代码
           ,'{11}'--'null'  --对应名称
           ,'{12}'--'NULL'  --生产/采购日期  stock.move.date_deadline
          ,{13}--null  --保质期(天)
           ,{14}--0  --仓位  stock.warehouse.lot_stock_id
           ,{15}--0  --辅助属性  (SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)
           ,'{16}'--'0.0000000000'  --换算率
           ,'{17}'--'0.0000000000'  --辅助数量
           ,{18}--0  --源单类型  stock.picking.type.name
           ,{19}--0  --源单内码
           ,'{20}'--'NULL'  --源单单号
           ,{21}--2428  --仓库  stock.warehouse.name
           ,'{22}'--'NULL'  --有效期至   stock.move.line.expiration_date
           )



