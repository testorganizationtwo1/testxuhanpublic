using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdooEntity
{
    /// <summary>
    /// 生产领料
    /// </summary>
    public class ProductionPicking_page1
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
        //FBrID_FNumber** 模板数据为空 => xh
        //BrID_FName
        //红蓝字
        //事务类型
        //单据号
        //领料部门_FNumber
        /// <summary>
        /// 领料部门_FName
        /// </summary>
        public string picking_user { get; set; }
        /// <summary>
        /// 领料用途
        /// </summary>
        public string stock_picking_picking_use { get; set; }
        /// <summary>
        /// res_users.id--领料_FNumber--领料_FName
        /// </summary>
        public string stock_picking_picker_picking { get; set; }
        //发料_FNumber
        //发料_FName
        //对方科目_FNumber** 模板数据为空 => xh
        //对方科目_FName** 模板数据为空 => xh
        //领料类型_FID
        //领料类型_FName
        //领料类型_FTypeID
        //工序计划单内码

        /// <summary>
        /// 源单类型
        /// </summary>
        public string stock_picking_type_name { get; set; }
        //倒冲标记
        //保税监管类型_FNumber** 模板数据为空 => xh
        //保税监管类型_FName** 模板数据为空 => xh
        //打印次数
        //凭证字号
        public List<ProductionPicking_page1> GetEntity(DataTable dt)
        {
            List<ProductionPicking_page1> list = new List<ProductionPicking_page1>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductionPicking_page1 oew = new ProductionPicking_page1();
                oew.audit_data = Convert.ToDateTime(dt.Rows[i]["audit_data"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["audit_data"]));
                oew.stock_picking_date_done = Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"] == DBNull.Value ? DateTime.Now.AddYears(-10) : Convert.ToDateTime(dt.Rows[i]["stock_picking_date_done"]));
                oew.stock_picking_maker = dt.Rows[i]["stock_picking_maker"].ToString();
                oew.stock_picking_name = dt.Rows[i]["stock_picking_name"].ToString();
                oew.stock_picking_audit = dt.Rows[i]["stock_picking_audit"].ToString();
                oew.picking_user = dt.Rows[i]["picking_user"].ToString();
                oew.stock_picking_picking_use = dt.Rows[i]["stock_picking_picking_use"].ToString();
                oew.stock_picking_picker_picking = dt.Rows[i]["stock_picking_picker_picking"].ToString();
                oew.stock_picking_type_name = dt.Rows[i]["stock_picking_type_name"].ToString();
                list.Add(oew);
            }
            return list;
        }
    }
}
