      --ICStockBillEntry出入库单据分录表
INSERT INTO [dbo].[ICStockBillEntry]
			([FQtyMust]--应收数量--基本单位应收数量
			,[FAuxQty]--实收数量
			,[FAuxPrice]--单价
			,[Famount]--金额
			,[FBatchNo]--批号
			,[FNote]--备注
			,[FSourceBillNo]--源单单号
			,[FSourceTranType]--源单类型
			,[FQty]--基本单位实收数量
			,[FAuxPlanPrice]--计划单价
			,[FPlanAmount]--计划价金额
			,[FKFPeriod]--保质期(天)
			,[FKFDate]--生产/采购日期
			,[FPositionNo]--位置号
			,[FItemSize]--坯料尺寸
			,[FItemSuite]--坯料数
			,[FBrNo]--必填项，非文档要求
			,[FInterID]--单据号  必填项，非文档要求，主键，要求手动插入最大ID（ICStockBill	FInterID）
			,[FEntryID]--行号  必填项，非文档要求，主键，要求手动插入最大ID
			,[FConsignPrice] --代销单价 
			,[FConsignAmount] --代销金额
			,[FProcessCost] --加工费
			,[FProcessPrice] --委外加工入库单增加加工单价
			,[FAuxQtyMust]--辅助账存数量
			,[FSNListID] --序列号内码
			,[FPeriodDate] --有效期至
			,[FSecCoefficient] --换算率
			,[FSecQty] --辅助数量
			,[FSourceInterId] --源单内码
			,[FSourceEntryID] --源单分录
			,[FICMOBillNo] --生产任务单号
			,[FICMOInterID] --任务单内码
			,[FPPBomEntryID] --投料单分录
			,[FMTONo] --计划跟踪号
			,[FChkPassItem] --检验是否良品
			,[FItemID] --物料编码
			,[FAuxPropID] --辅助属性
			,[FUnitID] --单位
			,[FDCStockID] --收货仓库
			,[FDCSPID] --仓位
			,[FOrderBillNo] --订单号
			,[FOrderEntryID] --订单行号
			,[FOrderInterID] --订单行内码
			,[FMapNumber] --对应代码
			,[FMapName] --对应名称
			,[FOrgBillEntryID] --拆单源单行号
			,[FSecInvoiceQty] --辅助单位开票数量
			,[FPlanMode] --计划模式
			,[FDeliveryNoticeFID] --交货通知单内码
			,[FDeliveryNoticeEntryID] --交货通知单分录
			,[FAuxPriceRef] --调拨单价
			,[FAmtRef] --调拨金额
			,[FSCStockID] --调出仓库
			,[FSCSPID] --调出仓位
			,[FMaterialCostPrice] --单位材料费
			,[FMaterialCost] --材料费
			,[FEntrySupply] --供应商
			,[FIsVMI] -- 是否VMI
			)

	VALUES 
			({0}--22			--stock.move.line.product_uom_qty   1.00
			,{1}--60.0000000000		--stock.move.line.qty_done   0.00
			,{2}--34.4400000000		--stock.move.price_unit 100
			,{3}--2066.15		--stock.move.total_amount
			,'{4}'--'CustBOM000003'
			,'{5}'--'备注11'--stock.picking.note   null
			,'{6}'--'123321'--stock.picking.origin   P00198
			,{7}--111
			,{8}--22--stock.move.line.qty_done            0.00
			,{9}--11
			,{10}--33
			,{11}--365
			,'{12}'--'2009-01-12 00:00:00.000'
			,'{13}'--'12'
			,'{14}'--'3'
			,'{15}'--'5'
			,'{16}'--'1'
			,{17}--856936
			,{18}--3774
			,{19}--3773
			,{20}--3772
			,{21}--3771
			,{22}--3770
			,{23}--37745
			,{24}--0
			,'{25}' --''
			,'{26}' --'0'
			,'{27}' --'0'
			,{28} --0
			,{29} --0
			,'{30}' --'0' stock.picking.name
			,{31} --0
			,{32} --0
			,'{33}' --'NULL'
			,{34}  --枚举：是   否  （1058  0）
			,{35}  --530    外键，要求手动插入物料表（t_ICItem）最大ID   stock_picking.product_id
			,{36}  --0  (SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)
			,{37}  --171 (select t2.FItemID,t1.FName FNumber,t2.Fname from   t_UnitGroup t1,t_MeasureUnit t2 where t1.FUnitGroupID=t2.FUnitGroupID)      stock.move.product_uom
			,{38} --336 外键，要求手动插入仓库表（t_Stock）最大ID     stock.warehouse.id
			,{39} --0  (select t2.FSPID,t2.Fname,t1.FName FGroupName from   t_StockPlaceGroup t1,t_StockPlace t2 where t1.FSPGroupID=t2.FSPGroupID AND t2.FSPID>0)
			,'{40}' --'POORD000001'  stock.picking.name
			,{41}  --1
			,{42}  --0
			,'{43}' --'0'
			,'{44}'  --'0'
			,{45} --0
			,'{46}'  --'0.0000000000'
			,{47} --14036
			,{48} --NULL
			,{49} --NULL
			,'{50}' --'52'
			,'{51}' --'100'
			,{52} --0
			,{53} --NULL
			,'{54}' --'0.0000000000'
			,'{55}' --'0.00'
			,{56} --5122
			,{57} -- 0
			
			
			)      
           