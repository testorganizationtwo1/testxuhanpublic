using Monitor.DatabaseHelper;
using Monitor.Enums;
using MonitorNew.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorNew
{
    public partial class OdooToKingdee : Form
    {
        public OdooToKingdee()
        {
            InitializeComponent();
        }

        private void OdooToKingdeeTimer_Tick(object sender, EventArgs e)
        {
            LabelStartTime.Text = "定时任务已启动，最新同步时间：\r\n" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            if (ListBoxKingdeeTaskList.Items.Count > 300)
                ListBoxKingdeeTaskList.Items.Clear();

            OdooToKingdeeTimer_BeginTask();
            /*var t = new Thread(()=> OdooToKingdeeTimer_BeginTask());
            t.Start();*/
        }

        private void OdooToKingdeeTimer_BeginTask()
        {
            lock (this)
            {
                new DataCenter().BeginTask();
            }
        }

        private void ButtonStartTask_Click(object sender, EventArgs e)
        {
            labelSpeed.Text = string.Format("{0}毫秒/条", GlobalConstant.Speed);
            string BtnStartTaskText = ButtonStartTask.Text;
            if (BtnStartTaskText == MonitorTaskStatus.StartPush)
            {
                LabelStartTime.Text = "首次任务即时启动，最新同步时间：\r\n" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                #region 启动定时器之前先执行一次
                OdooToKingdeeTimer_BeginTask();
                #endregion

                OdooToKingdeeTimer.Enabled = true;
                OdooToKingdeeTimer.Start();
                ListBoxKingdeeTaskList.Items.Add("开始推送......");
                ButtonStartTask.Text = MonitorTaskStatus.StopPush;
            }
            else if (BtnStartTaskText == MonitorTaskStatus.StopPush)
            {
                OdooToKingdeeTimer.Stop();
                OdooToKingdeeTimer.Enabled = false;
                ListBoxKingdeeTaskList.Items.Add("停止推送......");
                ButtonStartTask.Text = MonitorTaskStatus.StartPush;
            }
        }
        /// <summary>
        /// 测试连接Odoo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectOdoo_Click(object sender, EventArgs e)
        {
            string infoStr = new PgsqlHelper().TestConnectSql();
            string serverName = PgsqlHelper.connStr.Substring(PgsqlHelper.connStr.IndexOf("HOST=") + 5, PgsqlHelper.connStr.IndexOf(";PASSWORD") - PgsqlHelper.connStr.IndexOf("HOST=") - 5);
            string dbName = PgsqlHelper.connStr.Substring(PgsqlHelper.connStr.IndexOf("E=") + 2, PgsqlHelper.connStr.IndexOf(";H") - PgsqlHelper.connStr.IndexOf("E=") - 2);
            ListBoxKingdeeTaskList.Items.Add("");
            ListBoxKingdeeTaskList.Items.Add(string.Format("{0} 主机：{1}; 数据库：{2};", infoStr, serverName, dbName));
        }
        /// <summary>
        /// 测试连接Kingdee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectKingdee_Click(object sender, EventArgs e)
        {
            SqlHelper sh = new SqlHelper();
            string infoStr = sh.TestConnectSql();
            string serverName = SqlHelper.constr.Substring(SqlHelper.constr.IndexOf("=")+1, SqlHelper.constr.IndexOf(";") - SqlHelper.constr.IndexOf("=")-1);
            string dbName = SqlHelper.constr.Substring(SqlHelper.constr.IndexOf("g=") + 2, SqlHelper.constr.IndexOf(";U") - SqlHelper.constr.IndexOf("g=") - 2);
            ListBoxKingdeeTaskList.Items.Add("");
            ListBoxKingdeeTaskList.Items.Add(string.Format("{0} 主机：{1}; 数据库：{2};", infoStr, serverName, dbName));
        }
    }
}
