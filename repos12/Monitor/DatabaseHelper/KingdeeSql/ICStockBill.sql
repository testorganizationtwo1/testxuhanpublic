   --出入库单据 --已正确插入
INSERT INTO [dbo].[ICStockBill]
           ([FDate]--日期
           ,[FCheckerID]--审核标志
           ,[FCancellation]--作废标志
		   ,[FBillNo]--单据编号，非空
		   ,[FBackFlushed]--倒冲标志
		   ,[FBrNo]--必填项，非文档要求
		   ,[FInterID]--必填项，非文档要求，主键，要求手动插入最大ID
		   ,[FStatus]--状态
		   ,[FUse]-- "生产领用" 领料用途
		   )
     VALUES
           ('{0}'--'2009-01-12 00:00:00.000'stock.picking.date_done   2021-08-19 03:32:13
           ,{1}--1111
           ,'{2}'--'0'
		   ,'{3}'--'WIN000004'
		   ,{4}--1
		   ,'{5}'--'必填项'
		   ,{6}--856939
		   ,'{7}'--'1'
		   ,'{8}'--"生产领用"
           )