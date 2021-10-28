   --出入库单据
INSERT INTO [dbo].[ICStockBill]
           ([FDate]--日期
           ,[FCancellation]--作废标志
		   ,[FBillNo]--单据编号，非空
		   ,[FBackFlushed]--倒冲标志
		   ,[FBrNo]--必填项，非文档要求
		   ,[FInterID]--必填项，非文档要求，主键，要求手动插入最大ID
		   ,[FStatus]--状态
		   ,[FUse]-- "生产领用" 领料用途
		   ,[FCheckDate] --审核日期
		   ,[FROB] --红蓝字
		   ,[FTranType] --事物类型
		   ,[FSelTranType] --源单类型
		   ,[FPrintCount] --打印次数
		   ,[FVchInterID] --凭证字号
		   ,[FBillerID] --制单人  必填项，外键，要求手动插入系统用户表（t_Base_User）最大ID
		   ,[FCheckerID] --审核人  必填项，外键，要求手动插入系统用户表（t_Base_User）最大ID
		   ,[FBrID] -- 必填项，外键，要求手动插入分支机构表（t_SonCompany）最大ID
		   ,[FDeptID] --交货单位  必填项，外键，要求手动插入部门表（t_Department）最大ID
		   ,[FFManagerID] --验收人  必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
		   ,[FSManagerID] --保管人  必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
		   ,[FManageType] --保税监管类型 
		   ,[FPOStyle] --采购方式   外键，要求手动插入辅助资料表（t_SubMessage）最大ID
		   ,[FSupplyID] --供应商   外键，要求手动插入供应商表（t_Supplier）最大ID    （客户表t_Organization	FItemID）
		   ,[FRelateBrID] --供货机构
		   ,[FOrgBillInterID] --源单内码
		   ,[FExplanation] --摘要
		   ,[FManagerID] --负责人  外键，要求手动插入职员表（t_Base_Emp）最大ID
		   ,[FEmpID] --业务员  外键，要求手动插入职员表（t_Base_Emp）最大ID
		   ,[FCussentAcctID] --往来科目  外键，要求手动插入科目表（t_Account）最大ID
		   ,[FSettleDate] --付款日期
		   ,[FRefType] --调拨类型
		   ,[FPurposeID] --委外类型
		   ,[FPOOrdBillNo] --对方单据号
		   ,[FBillTypeID] --入库类型
		   ,[FObjectItem] --工程项目
		   --,[FHeadSelfD0134] （数据库表中没找到这个字段） --客户
		   --,[FHeadSelfA0537] （数据库表中没找到这个字段） 委外出库单号
		   )
     VALUES
           ('{0}'--'2009-01-12 00:00:00.000'stock.picking.date_done   2021-08-19 03:32:13
           ,'{1}'--'0'
		   ,'{2}'--'WIN000004'
		   ,{3}--1
		   ,'{4}'--'必填项'
		   ,{5}--856939
		   ,'{6}'--'1'
		   ,'{7}'--"生产领用"
		   ,'{8}' --stock.picking.audit_data
		   ,'{9}' --枚举:蓝(1)  红(-1)
		   ,'{10}' --'1'  事物类型
		   ,'{11}' --'0' 源单类型
		   ,'{12}' --'0' 打印次数
		   ,'{13}' --'0' 凭证字号
		   ,{14} --16398 制单人 stock_picking.maker
		   ,{15} --16399 审核人 stock_picking.maker
		   ,{16} --NULL
		   ,{17} -- 交货单位  stock.picking.department
		   ,{18} --10 验收人 stock_picking	keeping_user
		   ,{19} --11 保管人 stock_move.keeping_user
		   ,{20} --0
           ,{21} --252 (赊购)
           ,{22} --415  stock_picking.partner_id
           ,{23}  --NULL stock_picking.partner_id
           ,{24} --0
           ,'{25}'  --'摘要'  stock.picking.summary
           ,{26}  --0  
           ,{27}  --NULL  stock.picking.business_user
           ,{28}  --1045 科目
           ,'{29}'  --'2008-01-02 00:00:00.000'   
           ,{30}  --0
           ,{31} --0 
           ,{32} --NULL
           ,{33}  --NULL  stock_picking.picking_type_id
           ,{34} --0   (select FItemID,FNumber,FName,FItemClassID from t_Item)
		   --{35} （数据库表中没找到这个字段）  stock_picking	partner_id
		   --,'{36}' --（数据库表中没找到这个字段）委外出库单号
           
           
           )