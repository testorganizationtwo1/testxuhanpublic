select audit_data,--审核日期
stock_picking.date_done as stock_picking_date_done,--日期
stock_picking.maker as stock_picking_maker,--制单人_FName
stock_picking.name as stock_picking_name,--编    号
stock_picking.audit as stock_picking_audit,--审核人_FName
--FBrID_FNumber				** 模板数据为空 => xh
--FBrID_FName				** 模板数据为空 => xh
--红蓝字
--事务类型
--单据号
--交货单位_FNumber
stock_picking.delivery_department as stock_picking_delivery_department,--交货单位_FName
stock_picking.keeping_user as stock_picking_keeping_user,--res_users.id  验收_FNumber；验收_FName
stock_move.keeping_user as stock_move_keeping_user,--res_users.id  保管_FNumber；保管_FName
stock_picking_type.name--源单类型
--保税监管类型_FNumber			** 模板数据为空 => xh
--保税监管类型_FName			** 模板数据为空 => xh
--打印次数
--凭证字号
from stock_picking 
left join stock_move 
on stock_move.picking_id = stock_picking.id
left join stock_picking_type
on stock_picking_type.id=stock_picking.picking_type_id
where sequence_code='IN-CP'
limit 500

