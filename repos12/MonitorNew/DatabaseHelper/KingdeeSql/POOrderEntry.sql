  --采购订单分录表
  INSERT INTO [dbo].[POOrderEntry]
           ([FInterID]  --单据号
           ,[FEntryID]  --行号
           ,[FItemID]  --物料代码
           ,[FDate]  --交货日期
           ,[FAmount]  --不含税金额
           ,[FTaxRate]  --折扣率(%)
           ,[FTaxAmount]  --税额
           ,[FNote]  --备注
           ,[FUnitID]  --单位
           ,[FAuxPrice]  --不含税单价
           ,[FAuxQty]  --数量
           ,[FSourceEntryID]  --源单分录
           ,[FCess]  --税率(%)
           ,[FMapNumber]  --对应代码
           ,[FMapName]  --对应名称
           ,[FAllAmount]  --价税合计
           ,[FAuxPropID]  --辅助属性
           ,[FAuxPriceDiscount]  --实际含税单价
           ,[FAuxTaxPrice]  --含税单价
           ,[FReceiveAmountFor_Commit]  --付款关联金额
           ,[FSecCoefficient]  --换算率
           ,[FSecQty]  --辅助数量
           ,[FSourceTranType]  --源单类型
           ,[FSourceInterId]  --源单内码
           ,[FSourceBillNo]  --源单单号
           ,[FContractInterID]  --合同内码
           ,[FContractEntryID]  --合同分录
           ,[FContractBillNo]  --合同单号
           ,[FMRPLockFlag]  --MRP计算标记
           ,[FSecInvoiceQty]  --辅助单位开票数量
           ,[FPlanMode]  --计划模式
           ,[FMTONo]  --计划跟踪号
           ,[FDescount]  --折扣额
           --,[FSupConfirm]  --供应商确认标志
           --,[FSupConDate]  --供应商确认日期
           --,[FSupConQty]  --确认数量
           --,[FSupConMem]  --确认意见
           --,[FSupConFetchDate]  --供应商确认交货日期
           ,[FSupConfirmor]  --供应商确认人
           ,[FEntryAccessoryCount]  --表体附件数
           ,[FPRInterID]  --采购申请单内码
           ,[FPREntryID]  --采购申请单分录
           ,[FAuxReceiptQty]  --收料数量
           ,[FReceiptQty]  --基本单位收料数量
           ,[FAuxReturnQty]  --退料数量
           ,[FReturnQty]  --基本单位退料数量
           ,[FCheckMethod]  --检验方式

           )
     VALUES
           ({0}--12  --POORD129213  (采购订单表POOrder	FInterID)
           ,{1}--100  --
           ,{2}--530  --外键，要求手动插入物料表（t_ICItem）最大ID   stock.picking	product_id
           ,'{3}'--'2008-01-03 00:00:00.000'   --
           ,'{4}'--'56.00'  --
           ,'{5}'--'0.0000000000'  --
           ,'{6}'--'9.52'
           ,'{7}'--'备注'  --stock.picking.note
           ,{8}--171  --单位  stock.move.product_uom  
           ,'{9}'--'2.0000000000'  --不含税单价
           ,'{10}'--'28.0000000000'  --数量
           ,{11}--1  --源单分录
           ,'{12}'--'17.00'  --税率(%)
           ,'{13}'--'null'  --对应代码
           ,'{14}'--'NULL'  --对应名称
           ,'{15}'--'65.5200'  --价税合计
           ,{16}--0  --辅助属性  (SELECT t2.FName FClassName,t1.* FROM t_AuxItem t1 ,t_ItemClass t2 where t1.FItemClassID=t2.FItemClassID)
           ,'{17}'--'2.3400000000'  --实际含税单价
           ,'{18}'--'2.3400000000'  --含税单价
           ,'{19}'--'65.5200'  --付款关联金额
           ,'{20}'--'0.0000000000'   --换算率
           ,'{21}'--'0.0000000000'  --辅助数量
           ,'{22}'--0  --源单类型
           ,{23}--0  --源单内码
           ,'{24}'--'POREQ000001'  --源单单号  stock.picking.origin
           ,{25}--0  --合同内码
           ,{26}--0   --合同分录
           ,'{27}' --'NULL'  --合同单号
           ,{28}--0   --MRP计算标记
           ,'{29}'--'0.0000000000'   --辅助单位开票数量
           ,{30}--14036  --外键，要求手动插入辅助资料表（t_SubMessage）最大ID	
           ,'{31}'--'NULL'  --计划跟踪号
           ,'{32}'--'0.0000000000'  --折扣额
           --,'{33}'--'NULL'  --供应商确认标志
           --,{34}--null  --供应商确认日期
           --,'{35}'--'NULL'  --确认数量
           --,'{36}'--'NULL'  --确认意见
           --,'{37}'--'NULL'  --供应商确认交货日期
           ,{38}--NULL  --供应商确认人
           ,{39}--NULL  --表体附件数
           ,{40}--0  --采购申请单内码
           ,{41}--0  --采购申请单分录
           ,'{42}'--'28.0000000000'  --收料数量
           ,'{43}'--'28.0000000000'  --基本单位收料数量
           ,'{44}'--'0.0000000000'  --退料数量
           ,'{45}'--'0.0000000000'  --基本单位退料数量
           ,{46}--351  ----外键，要求手动插入辅助资料表（t_SubMessage）最大ID	
            )