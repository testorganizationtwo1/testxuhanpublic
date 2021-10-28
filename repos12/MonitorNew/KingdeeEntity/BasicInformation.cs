using System;

namespace MonitorNew.KingdeeEntity
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
        /// <summary>
        /// 编码
        /// </summary>
        public string FNumber {  get; set; }
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
        /// <summary>
        /// 编码
        /// </summary>
        public string  FNumber {  get; set; }
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
        /// <summary>
        /// 编码
        /// </summary>
        public string FNumber {  get; set; }
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
        /// <summary>
        /// 编码
        /// </summary>
        public string FNumber {  get; set; }
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
        /// <summary>
        /// 职员编码
        /// </summary>
        public string FNumber {  get; set; }

    }
    /// <summary>
    /// 系统用户表
    /// </summary>
    public class t_Base_User
    {
        /// <summary>
        /// 用户名
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
        public int  FParentID { get; set; }
        /// <summary>
        ///  必填项，非文档要求
        /// </summary>
        public string FFullNumber { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FSPID { get; set; }
    }
    /// <summary>
    /// 仓位分组表
    /// </summary>
    public class t_StockPlaceGroup   
    {
        /// <summary>
        /// 仓位组ID
        /// </summary>
        public int FSPGroupID {  get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FNumber {  get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FName {  get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public int FDefaultSPID {  get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public int FDeleted {  get; set; }
        

    }
    /// <summary>
    /// 辅助资料表
    /// </summary>
    public class t_SubMessage
    {
        /// <summary>
        /// 公司代码
        /// </summary>
        public string FBrNo { get; set; }
        /// <summary>
        /// 必填项，非文档要求，主键，要求手动插入最大ID
        /// </summary>
        public int FInterID {  get; set; }
        /// <summary>
        /// 资料代码
        /// </summary>
        public string FID {  get; set; }
        /// <summary>
        /// 上级内码
        /// </summary>
        public int FParentID {  get; set; }
        /// <summary>
        /// 资料名称
        /// </summary>
        public string FName {  get; set; }
        /// <summary>
        /// 类型内码
        /// </summary>
        public int FTypeID {  get; set; }
        /// <summary>
        /// 是否明细
        /// </summary>
        public int FDetail {  get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public int FDeleted {  get; set; }
        /// <summary>
        /// 系统标示
        /// </summary>
        public int FSystemType {  get; set; }
        /// <summary>
        /// 未知字段
        /// </summary>
        public int FSpec { get; set; }
    }
    /// <summary>
    /// 单位类别表
    /// </summary>
    public class t_UnitGroup
    {
        /// <summary>
        /// 组别内码
        /// </summary>
        public int FUnitGroupID {  get; set; }
        /// <summary>
        /// 组别名称
        /// </summary>
        public string FName {  get; set; }
        /// <summary>
        /// 默认单位
        /// </summary>
        public int FDefaultUnitID {  get; set; }

    }
    /// <summary>
    /// --基础资料类别表
    /// </summary>
    public class t_ItemClass
    {
        /// <summary>
        /// 类别内码
        /// </summary>
        public int FItemClassID {  get; set; }
        /// <summary>
        /// 类别代码
        /// </summary>
        public string FNumber {  get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FName {  get; set; }
        /// <summary>
        /// 未知字段
        /// </summary>
        public string FName_en {  get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public int FVersion {  get; set; }
        /// <summary>
        /// 外部引入
        /// </summary>
        public int FImport {  get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        public string FBrNo {  get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public int FUserDefilast {  get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int FType {  get; set; }
        /// <summary>
        /// 集团控制类别
        /// </summary>
        public int FGRType {  get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string FRemark {  get; set; }
        /// <summary>
        /// 未知字段
        /// </summary>
        public int FGrControl {  get; set; }


    }
    /// <summary>
    /// 单据类型表
    /// </summary>
    public class ICBillType
    {
        /// <summary>
        /// 内码
        /// </summary>
        public int FID { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string FNumber {  get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FName {  get; set; }
        /// <summary>
        /// 会计科目
        /// </summary>
        public int FAcctID {  get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string FNote {  get; set; }
        /// <summary>
        /// 是否系统预设
        /// </summary>
        public int FSystemic {  get; set; }

    }
    /// <summary>
    /// 保税监管类型
    /// </summary>
    public class t_BaseBondedManageType
    {
        /// <summary>
        /// 内码
        /// </summary>
        public int FID {  get; set; }
        /// <summary>
        /// 保税监管名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 保税监管代码
        /// </summary>
        public string FNumber { get; set; }
        /// <summary>
        /// 父级内码
        /// </summary>
        public int FParentID {  get; set; }
        /// <summary>
        /// 菜单控制
        /// </summary>
        public int FLogic {  get; set; }
        /// <summary>
        /// 是否明细
        /// </summary>
        public int FDetail {  get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int FDiscontinued {  get; set; }
        /// <summary>
        /// 级次
        /// </summary>
        public int FLevels {  get; set; }
        /// <summary>
        /// 保税监管全名
        /// </summary>
        public string FFullNumber {  get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string FClassTypeID { get; set; }

    }
    /// <summary>
    /// 基础资料主表
    /// </summary>
    public class t_Item
    {
        /// <summary>
        /// ID号
        /// </summary>
        public int FItemID {  get; set; }
        /// <summary>
        /// 类型ID号
        /// </summary>
        public int FItemClassID {  get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FNumber {  get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int FParentID {  get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 是否明细
        /// </summary>
        public int FDetail {  get; set; }



    }
    /// <summary>
    /// 外销订单表
    /// </summary>
    public class SEOrder
    {
        /// <summary>
        /// 分支机构代码
        /// </summary>
        public string FBrNo {  get; set; }
        /// <summary>
        /// 内码
        /// </summary>
        public int FInterID {  get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string FBillNo {  get; set; }
        /// <summary>
        /// 币别
        /// </summary>
        public int FCurrencyID {  get; set; }
        /// <summary>
        /// 订单客户
        /// </summary>
        public int FCustID {  get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime FDate {  get; set; }
        /// <summary>
        /// 业务代码
        /// </summary>
        public int FTranType {  get; set; }


    }
    /// <summary>
    /// 辅助资料信息表
    /// </summary>
    public class t_AuxItem
    {
        /// <summary>
        /// 内码
        /// </summary>
        public int FItemID { get; set; }
        /// <summary>
        /// 辅助属性类别内码
        /// </summary>
        public int FItemClassID { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FNumber {  get; set; }
        /// <summary>
        /// -名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 上级内码
        /// </summary>
        public int FParentID {  get; set; }
        /// <summary>
        /// 是否使用
        /// </summary>
        public int FUnUsed {  get; set; }
        /// <summary>
        /// 长编码
        /// </summary>
        public string FFullNumber {  get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public int FDeleted {  get; set; }
        /// <summary>
        /// 短编码
        /// </summary>
        public string FShortNumber {  get; set; }
        /// <summary>
        /// 全名
        /// </summary>
        public string FFullName { get; set;  }


    }
    /// <summary>
    /// 科目表
    /// </summary>
    public class t_Account
    {
        /// <summary>
        /// 科目内码
        /// </summary>
        public int FAccountID {  get; set; }
        /// <summary>
        /// 科目代码
        /// </summary>
        public string FNumber {  get; set; }
        /// <summary>
        /// 科目名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 科目级次
        /// </summary>
        public int FLevel { get; set; }
        /// <summary>
        /// 核算项目内码
        /// </summary>
        public int FDetail {  get; set; }
        /// <summary>
        /// 科目类别内码
        /// </summary>
        public int FGroupID {  get; set; }
        /// <summary>
        /// 借贷方向
        /// </summary>
        public int FDC {  get; set; }


    }
    /// <summary>
    /// 结算方式表
    /// </summary>
    public class t_Settle
    {
        /// <summary>
        /// 公司代码
        /// </summary>
        public string FBrNo {  get; set; }
        /// <summary>
        /// 结算方式内码
        /// </summary>
        public int FItemID {  get; set; }
        /// <summary>
        /// 结算方式名称
        /// </summary>
        public string FName {  get; set; }
        /// <summary>
        /// 结算方式代码
        /// </summary>
        public string FNumber {  get; set; }


    }
    /// <summary>
    /// 币别表
    /// </summary>
    public class t_Currency
    {
        /// <summary>
        /// 币别内码
        /// </summary>
        public int FCurrencyID { get; set; }
        /// <summary>
        /// 币别代码
        /// </summary>
        public string FNumber {  get; set; }
        /// <summary>
        /// 币别名称
        /// </summary>
        public string FName {  get; set; }
        /// <summary>
        /// 运算符
        /// </summary>
        public string FOperator {  get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal FExchangeRate {  get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int FScale {  get; set; }
        /// <summary>
        /// 换算率
        /// </summary>
        public int FFixRate {  get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        public string FBrNo {  get; set; }
        /// <summary>
        /// 未知字段
        /// </summary>
        public int FControl {  get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public int FDeleted { get; set; }
        /// <summary>
        /// 未知字段
        /// </summary>
        public int FSystemType {  get; set; }
        /// <summary>
        /// 未知字段
        /// </summary>
        public int FClassTypeID {  get; set; }

    }

}
