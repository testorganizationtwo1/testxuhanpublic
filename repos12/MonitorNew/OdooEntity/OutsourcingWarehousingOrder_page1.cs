using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    /// <summary>
    /// 外购入库单
    /// </summary>
    public class OutsourcingWarehousingOrder_page1
    {
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime audit_data { get; set; }//audit_data
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime stock_picking_date_done { get; set; }//stock_picking.date_done
        /// <summary>
        /// 制单人_FName
        /// </summary>
        public string stock_picking_maker { get; set; }
        /// <summary>
        /// 编    号
        /// </summary>
        public string stock_picking_name { get; set; }
        /// <summary>
        /// 审核人_FName
        /// </summary>
        public string stock_picking_audit { get; set; }
        //制单机构_FNumber** 模板数据为空 => xh
        //制单机构_FName** 模板数据为空 => xh
        //红蓝字
        //事务类型
        //单据号
        /// <summary>
        /// 供应商_FNumber;--供货机构_FNumber
        /// </summary>
        public string res_partner_id { get; set; }
        /// <summary>
        /// 供应商_FName;--供货机构_FName
        /// </summary>
        public string res_partner_commercial_company_name { get; set; }
        /// <summary>
        /// res_users.id --验收_FNumber;--验收_FName
        /// </summary>
        public string stock_picking_keeping_user { get; set; }
        /// <summary>
        /// res_users.id--保管_FNumber;--保管_FName
        /// </summary>
        public string stock_move_keeping_user { get; set; }
        //采购方式_FID
        //采购方式_FName
        //采购方式_FTypeID
        /// <summary>
        /// 采购方式_FID,采购方式_FName,采购方式_FTypeID
        /// </summary>
        public string stock_picking_purchase_type { get; set; }
        //对方单据号** 模板数据为空 => xh
        //供货机构_FNumber** 模板数据为空 => xh
        //供货机构_FName** 模板数据为空 => xh
        //源单内码
        /// <summary>
        /// 出库类型_FName;--源单类型
        /// </summary>
        public string stock_picking_type_name { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string stock_picking_summary { get; set; }
        /// <summary>
        /// 部门_FNumber
        /// </summary>
        public string hr_department_id { get; set; }
        /// <summary>
        /// 部门_FName	
        /// </summary>
        public string hr_department_name { get; set; }
        //负责人_FNumber** 模板数据为空 => xh
        //负责人_FName
        /// <summary>
        /// res_users.id--业务员_FNumber;--业务员_FName
        /// </summary>
        public string stock_picking_business_user { get; set; }
        //往来科目_FNumber** 模板数据为空 => xh
        //往来科目_FName** 模板数据为空 => xh
        //保税监管类型_FNumber** 模板数据为空 => xh
        //保税监管类型_FName** 模板数据为空 => xh
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime stock_picking_payment_data { get; set; }
        //采购模式_FID
        //采购模式_FName
        //采购模式_FTypeID
        //打印次数
        //凭证字号
        //自定义项42
        public List<OutsourcingWarehousingOrder_page1> GetEntity(DataTable dt)
        {
            List<OutsourcingWarehousingOrder_page1> list = new List<OutsourcingWarehousingOrder_page1>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OutsourcingWarehousingOrder_page1 oew = new OutsourcingWarehousingOrder_page1();
                oew.audit_data = Convert.ToDateTime(dt.Rows[i]["audit_data"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["audit_data"]));
                oew.stock_picking_date_done = Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"]));
                oew.stock_picking_maker = dt.Rows[i]["stock_picking_maker"].ToString();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.stock_picking_audit = dt.Rows[i]["stock_picking_audit"].ToString();
                oew.stock_picking_purchase_type = dt.Rows[i]["stock_picking_purchase_type"].ToString();
                oew.res_partner_id = dt.Rows[i]["res_partner_id"].ToString();
                oew.res_partner_commercial_company_name = dt.Rows[i]["res_partner_commercial_company_name"].ToString();
                oew.stock_picking_keeping_user = dt.Rows[i]["stock_picking_keeping_user"].ToString();
                oew.stock_move_keeping_user = dt.Rows[i]["stock_move_keeping_user"].ToString();
                oew.stock_picking_type_name = dt.Rows[i]["stock_picking_type_name"].ToString();
                oew.stock_picking_summary = dt.Rows[i]["stock_picking_summary"].ToString();
                oew.hr_department_id = dt.Rows[i]["hr_department_id"].ToString();
                oew.hr_department_name = dt.Rows[i]["hr_department_name"].ToString();
                oew.stock_picking_business_user = dt.Rows[i]["stock_picking_business_user"].ToString();
                oew.stock_picking_payment_data = Convert.ToDateTime(dt.Rows[i]["stock_picking_payment_data"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["stock_picking_payment_data"]));

                list.Add(oew);
            }
            return list;
        }
    }
}
