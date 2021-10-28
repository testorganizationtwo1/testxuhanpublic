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
			,[FInterID]--必填项，非文档要求，主键，要求手动插入最大ID
			,[FEntryID]--必填项，非文档要求，主键，要求手动插入最大ID
			,[FConsignPrice] --代销单价 
			,[FConsignAmount] --代销金额
			,[FProcessCost] --加工费
			,[FProcessPrice] --委外加工入库单增加加工单价
			,[FAuxQtyMust]--辅助账存数量
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
			)