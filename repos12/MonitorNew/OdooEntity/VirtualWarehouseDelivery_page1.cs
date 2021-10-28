using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{   
    /// <summary>
    /// 虚仓出库
    /// </summary>
    public class VirtualWarehouseDelivery_page1
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
        //制单机构_FNumber
        //制单机构_FName
        //红蓝字
        //事务类型
        //单据号
        /// <summary>
        /// 客户_FNumber;--供应商_FNumber;	
        /// </summary>
        public string res_partner_id { get; set; }
        /// <summary>
        /// 客户_FName;--供应商_FName;	
        /// </summary>
        public string res_partner_commercial_company_name { get; set; }
        /// <summary>
        /// 部门_FNumber
        /// </summary>
        public string hr_department_id { get; set; }
        /// <summary>
        /// 部门_FName	
        /// </summary>
        public string hr_department_name { get; set; }
        /// <summary>
        /// res_users.id--领料_FNumber--领料_FName
        /// </summary>
        public string stock_picking_picker_picking { get; set; }
        //发货_FNumber
        //发货_FName
        /// <summary>
        /// 源单类型
        /// </summary>
        public string stock_picking_type_name { get; set; }
       
        /// <summary>
        /// res_users.id--业务员_FNumber;--业务员_FName
        /// </summary>
        public string stock_picking_business_user { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string stock_picking_summary { get; set; }

        public List<VirtualWarehouseDelivery_page1> GetEntity(DataTable dt)
        {
            List<VirtualWarehouseDelivery_page1> list = new List<VirtualWarehouseDelivery_page1>();
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                VirtualWarehouseDelivery_page1 oew = new VirtualWarehouseDelivery_page1();
                oew.audit_data = Convert.ToDateTime(dt.Rows[i]["audit_data"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["audit_data"]));
                oew.stock_picking_date_done = Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"]));
                oew.stock_picking_maker = dt.Rows[i]["stock_picking_maker"].ToString();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.stock_picking_audit = dt.Rows[i]["stock_picking_audit"].ToString();
                oew.res_partner_id = dt.Rows[i]["res_partner_id"].ToString();
                oew.res_partner_commercial_company_name = dt.Rows[i]["res_partner_commercial_company_name"].ToString();
                oew.hr_department_id = dt.Rows[i]["hr_department_id"].ToString();
                oew.hr_department_name = dt.Rows[i]["hr_department_name"].ToString();
                oew.stock_picking_picker_picking = dt.Rows[i]["stock_picking_picker_picking"].ToString();
                oew.stock_picking_type_name = dt.Rows[i]["stock_picking_type_name"].ToString();
                oew.stock_picking_business_user = dt.Rows[i]["stock_picking_business_user"].ToString();
                oew.stock_picking_summary = dt.Rows[i]["stock_picking_summary"].ToString();

                list.Add(oew);
            }
            return list;
        }
    }
    //oew.qty_done = Convert.ToDecimal(dt.Rows[i]["qty_done"] == DBNull.Value? 0 : dt.Rows[i]["qty_done"]); //修改
}
