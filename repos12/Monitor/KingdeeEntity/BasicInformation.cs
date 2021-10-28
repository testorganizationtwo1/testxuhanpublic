using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdeeEntity
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class t_Department { 
    
        /// <summary>
        /// 部门名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FItemID { get; set; }
    }
    /// <summary>
    /// 仓库表
    /// </summary>
    public class t_Stock
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string  FName { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FItemID { get; set; }
    }
    /// <summary>
    /// 物料表
    /// </summary>
    public class t_ICItemCore
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string FNumber { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string FModel { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int  FItemID { get; set; }
    }
    /// <summary>
    /// 计量单位表
    /// </summary>
    public class t_MeasureUnit
    {
        /// <summary>
        /// 单位名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FNumber {  get; set; }

        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FMeasureUnitID { get; set; }
    }
    /// <summary>
    /// 供应商表
    /// </summary>
    public class t_Supplier
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
     public string FName { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FItemID { get; set; }
    }
    /// <summary>
    /// 客户表
    /// </summary>
    public class t_Organization
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FItemID { get; set; }
    }
    /// <summary>
    /// 职员表
    /// </summary>
    public class t_Base_Emp
    {
        /// <summary>
        /// 职员名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FItemID { get; set; }
    }
    /// <summary>
    /// 系统用户表
    /// </summary>
    public class t_Base_User
    {
        /// <summary>
        /// 用户名 不能重复
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 必填项，非文档要求
        /// </summary>
        public string FPrimaryGroup { get; set; }
        
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FUserID { get; set; }
        
    }
    /// <summary>
    /// 仓位表
    /// </summary>
    public class t_StockPlace
    {
        /// <summary>
        /// 仓位名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 必填项，非文档要求
        /// </summary>
        public string FDetail { get; set; }
        /// <summary>
        /// 仓位编码
        /// </summary>
        public string FNumber { get; set; }
        /// <summary>
        /// 必填项，非文档要求
        /// </summary>
        public string  FParentID { get; set; }
        /// <summary>
        ///  必填项，非文档要求
        /// </summary>
        public string FFullNumber { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FSPID { get; set; }
    }

}
