using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{   
    /// <summary>
    /// 其他出库
    /// </summary>
    public class OtherExWarehouse_page1
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
        //领料部门_FNumber
        /// <summary>
        /// 领料部门_FName
        /// </summary>
        public string picking_user { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        public string stock_picking_picking_use { get; set; }
        /// <summary>
        /// res_users.id--领料_FNumber--领料_FName
        /// </summary>
        public string stock_picking_picker_picking { get; set; }
        //发货_FNumber
        //发货_FName
        /// <summary>
        /// 客户_FNumber;--订货机构_FNumber
        /// </summary>
        public string res_partner_id { get; set; }
        /// <summary>
        /// 客户_FName;--订货机构_FName
        /// </summary>
        public string res_partner_commercial_company_name { get; set; }
        /// <summary>
        /// 出库类型_FNumber	
        /// </summary>
        public string stock_picking_type_id { get; set; }
        /// <summary>
        /// 出库类型_FName;--源单类型
        /// </summary>
        public string stock_picking_type_name { get; set; }
        //对方单据号
        //订货机构_FNumber
        //订货机构_FName
        // 源单类型
        //负责人_FNumber** 模板数据为空 => xh
        //负责人_FName
        /// <summary>
        /// res_users.id--业务员_FNumber;--业务员_FName
        /// </summary>
        public string stock_picking_business_user {  get; set; }
        //保税监管类型_FNumber** 模板数据为空 => xh
        //保税监管类型_FName** 模板数据为空 => xh
        //打印次数
        //工程项目_FNumber
        //工程项目_FName
        //工程项目_FItemClassID
        //凭证字号
        public List<OtherExWarehouse_page1> GetEntity(DataTable dt)
        {
            List<OtherExWarehouse_page1> list = new List<OtherExWarehouse_page1>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {  //oew.stock_picking_date_done = Convert.ToDateTime (dt.Rows[i]["date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["date_done"])); //修改
                OtherExWarehouse_page1 oew = new OtherExWarehouse_page1();
                
                oew.audit_data = Convert.ToDateTime(dt.Rows[i]["audit_data"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["audit_data"]));
                oew.stock_picking_date_done = Convert.ToDateTime (dt.Rows[i]["stock_picking_date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10): Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"]));
                oew.stock_picking_maker = dt.Rows[i]["stock_picking_maker"].ToString();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.stock_picking_audit = dt.Rows[i]["stock_picking_audit"].ToString();
                oew.picking_user = dt.Rows[i]["picking_user"].ToString();
                oew.stock_picking_picking_use = dt.Rows[i]["stock_picking_picking_use"].ToString();
                oew.stock_picking_picker_picking = dt.Rows[i]["stock_picking_picker_picking"].ToString();
                oew.res_partner_id = dt.Rows[i]["res_partner_id"].ToString();
                oew.res_partner_commercial_company_name = dt.Rows[i]["res_partner_commercial_company_name"].ToString();
                oew.stock_picking_type_id = dt.Rows[i]["stock_picking_type_id"].ToString();
                oew.stock_picking_type_name = dt.Rows[i]["stock_picking_type_name"].ToString();
                oew.stock_picking_business_user = dt.Rows[i]["stock_picking_business_user"].ToString();

                list.Add(oew);
            }

            return list;
        }
    }
}
