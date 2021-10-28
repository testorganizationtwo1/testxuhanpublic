using MonitorUpdateData.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorUpdateData
{
    public partial class OdooToKingdee : Form
    {
        public OdooToKingdee()
        {
            InitializeComponent();
        }

        private void BtnStartTask_Click(object sender, EventArgs e)
        {
            string BtnStartTaskText = BtnStartTask.Text;
            if (BtnStartTaskText== MonitorTaskStatus.StartPush)
                BtnStartTask.Text = MonitorTaskStatus.StopPush;
            else if (BtnStartTaskText == MonitorTaskStatus.StopPush)
                BtnStartTask.Text = MonitorTaskStatus.StartPush;

        }

        private void OdooToKingdeeTimer_Tick(object sender, EventArgs e)
        {
            ConnectDatabase();

            LabelStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            if (ListBoxOdooTaskList.Items.Count > 1000)
                ListBoxOdooTaskList.Items.Clear();
            if (ListBoxKingdeeTaskList.Items.Count > 1000)
                ListBoxKingdeeTaskList.Items.Clear();
            if (ListBoxExceptionList.Items.Count > 5)
                ListBoxExceptionList.Items.Clear();


        }

        private void ConnectDatabase()
        {
            bool OdooConnectStatus = false;
            bool KingdeeConnectStatus = false;
            // 连接odoo数据库

            // 连接kingdee数据库
            if (!OdooConnectStatus)
            {
                MessageBox.Show("odoo数据库连接异常，数据同步已失效，请检查");
                return;
            }
            else
            if (!KingdeeConnectStatus)
            {
                MessageBox.Show("Kingdee数据库连接异常，数据同步已失效，请检查");
                return;
            }
        }
    }
}
