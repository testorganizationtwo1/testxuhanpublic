  --虚仓出入库单据表
INSERT INTO [dbo].[ZPStockBill]
           ([FInterID]  --单据号
           ,[FTranType]  --事务类型
           ,[FROB]  --红蓝字
           ,[FDate]  --日期
           ,[FBillNo]  --编    号
           ,[FCheckerID]  --审核人  必填项，外键，要求手动插入系统用户表（t_Base_User）最大ID
           ,[FFManagerID]  --领料   必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
           ,[FSManagerID]  --发货
           ,[FBillerID]  --制单人  必填项，外键，要求手动插入系统用户表（t_Base_User）最大ID
           ,[FDeptID]  --部门   外键，要求手动插入供应商表（t_Department）最大ID
           ,[FCustID]  --客户   外键，要求手动插入供应商表（t_Organization）最大ID
           ,[FSupplyID]  --供应商  外键，要求手动插入供应商表（t_Supplier）最大ID
           ,[FCheckDate]  --审核日期
           ,[FEmpID]  --业务员  必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
           ,[FExplanation]  --摘要
           ,[FManagerID]  --负责人  必填项，外键，要求手动插入职员表（t_Base_Emp）最大ID
           ,[FSelTranType]  --源单类型
           ,[FBillTypeID]  --单据类型
           ,[FBrID]  --制单机构
           ,[FPrintCount]  --打印次数

           )

     VALUES
           ({0}--0  --单据号 
           ,'{1}'--'26'  --事务类型
           ,'{2}'--'1'  --红蓝字  枚举:蓝(1)  红(-1)
           ,'{3}'--'2008-02-27 00:00:00.000'  --日期 stock.picking	date_done
           ,'{4}'--'ZIN000001'  --编    号  stock.picking.name
           ,{5}--16394  --审核人  stock.picking.audit 
           ,{6}--263  --领料  stock.picking.picker_picking 
           ,{7}--263  --发货 
           ,{8}--16394  --制单人  stock.picking.maker 
           ,{9}2--34  --部门  stock.picking.department
           ,{10}--0  --客户  stock_picking.partner_id
           ,{11}--410  --供应商  stock_picking.partner_id
           ,'{12}'--'2010-11-27 00:00:00.000'  --审核日期  stock.picking.audit_data
           ,{13}--0  --业务员  stock.picking.business_user
           ,'{14}'--'摘要'  --摘要  stock.picking.summary
           ,{15}--0  --负责人  
           ,{16}--0  --源单类型   stock.picking.type	name
           ,{17}--12551  --单据类型
           ,{18}--NULL  --制单机构
           ,{19}--0 --打印次数

           )




