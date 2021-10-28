  --采购订单表
  INSERT INTO [dbo].[POOrder]
           ([FTranType] --事务类型
           ,[FInterID]  --单据号
           ,[FBillNo]  --编    号
           ,[FSupplyID]  --供应商   外键，要求手动插入供应商表（t_Supplier）最大ID
           ,[FDate]  --日期
           ,[FEmpID]  --业务员    外键，要求手动插入职员表（t_Base_Emp）最大ID
           ,[FDeptID]  --部门   外键，要求手动插入部门表（t_Department）最大ID
           ,[FCurrencyID]  --币    别
           ,[FCheckerID]  --审核人  外键，要求手动插入系统用户表（t_Base_User）最大ID
           ,[FBillerID]  --制单人  外键，要求手动插入系统用户表（t_Base_User）最大ID
           ,[FMangerID]  --主管   外键，要求手动插入职员表（t_Base_Emp）最大ID  
           ,[FPOStyle]  --采购方式  外键，要求手动插入辅助资料表（t_SubMessage）最大ID
           ,[FRelateBrID]  --供货机构
           ,[FCheckDate]  --审核日期
           ,[FExplanation]  --摘要
           ,[FSettleDate]  --结算日期
           ,[FSettleID]  --结算方式
           ,[FSelTranType]  --源单类型
           ,[FBrID]  --制单机构
           ,[FPOOrdBillNo]  --分销订单号
           ,[FAreaPS]  --采购范围
           ,[FManageType]  --保税监管类型
           ,[FSysStatus] --系统设置
           ,[FValidaterName]  --确认人
           ,[FConsignee]  --收 货 方
           ,[FPrintCount] --打印次数
           ,[FExchangeRateType]  --汇率类型
           ,[FDeliveryPlace]  --交货地点
           ,[FAccessoryCount]  --附件数
           ,[FPOMode]  --采购模式  外键，要求手动插入辅助资料表（t_SubMessage）最大ID
           ,[FPlanCategory]  --计划类别
           ,[FLastAlterBillNo]  --最新变更单编号
           )

     VALUES
     
           ({0}--71 
           ,{1}--131064
           ,'{2}'--'POORD129213'
           ,{3}--1000435  --stock_picking.partner_id
           ,'{4}'--'2008-01-02 00:00:00.000'  --stock.picking.date_done
           ,{5}--1320091215  --stock.picking.business_user   
           ,{6}--241  --stock.picking.department
           ,{7}--1  --人名币 
           ,{8}--1  --审核人  stock.picking.audit 
           ,{9}--1  --制单人  stock.picking	maker
           ,{10}--143  --主管  
           ,{11}--252  --采购方式	
           ,{12}--0  --stock_picking	partner_id
           ,'{13}'--'2008-01-02 00:00:00.000'  --stock.picking.audit_data
           ,'{14}'--'摘要'  --stock.picking.summary
           ,'{15}'--'2008-01-02 00:00:00.000'  --结算日期
           ,{16}--0 --
           ,{17}--0 --源单类型  stock.picking.type.name
           ,{18}--0 --
           ,'{19}'--'NULL'
           ,{20}--0
           ,{21}--0
           ,'{22}'--'2'
           ,'{23}'--'NULL'  --
           ,'{24}'--'null'  --
           ,'{25}'--'0'
           ,{26}--1
           ,'{27}'--'NULL'
           ,{28}--NULL
           ,{29}--36680
           ,{30}--1
           ,'{31}'--'NULL'
           )
