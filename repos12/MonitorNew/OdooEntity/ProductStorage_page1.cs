using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{   
    /// <summary>
    /// 产品入库
    /// </summary>
    public class ProductStorage_page1
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
        //FBrID_FNumber				** 模板数据为空 => xh
        //FBrID_FName
        //红蓝字
        //事务类型
        //单据号
        //交货单位_FNumber
        /// <summary>
        /// 交货单位_FName
        /// </summary>
        public string stock_picking_delivery_department { get; set; }
        /// <summary>
        /// res_users.id --验收_FNumber;--验收_FName
        /// </summary>
        public string stock_picking_keeping_user { get; set; }
        /// <summary>
        /// res_users.id--保管_FNumber;--保管_FName
        /// </summary>
        public string stock_move_keeping_user { get; set; }
        /// <summary>
        /// 入库类型_FName--源单类型
        /// </summary>
        public string stock_picking_type_name { get; set; }
        //保税监管类型_FNumber** 模板数据为空 => xh
        //保税监管类型_FName** 模板数据为空 => xh
        //打印次数
        //凭证字号

        public List<ProductStorage_page1> GetEntity(DataTable dt)
        {
            List<ProductStorage_page1> list = new List<ProductStorage_page1>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductStorage_page1 oew = new ProductStorage_page1();
                oew.audit_data = Convert.ToDateTime(dt.Rows[i]["audit_data"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["audit_data"]));
                oew.stock_picking_date_done = Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"]));
                oew.stock_picking_maker = dt.Rows[i]["stock_picking_maker"].ToString();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.stock_picking_audit = dt.Rows[i]["stock_picking_audit"].ToString();
                oew.stock_picking_delivery_department = dt.Rows[i]["delivery_department"].ToString();
                oew.stock_picking_keeping_user = dt.Rows[i]["stock_picking_keeping_user"].ToString();
                oew.stock_move_keeping_user = dt.Rows[i]["stock_move_keeping_user"].ToString();
                oew.stock_picking_type_name = dt.Rows[i]["stock_picking_type_name"].ToString();
                list.Add(oew);
            }
            return list;
        }
    }
}
