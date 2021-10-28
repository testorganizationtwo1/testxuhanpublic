using Monitor.DatabaseHelper;
using Monitor.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Monitor
{
    public partial class OdooToKingdee : Form
    {
        //AutoSizeForm asc = new AutoSizeForm();
        public OdooToKingdee()
        {
            InitializeComponent();
        }

        private void ButtonStartTask_Click(object sender, EventArgs e)
        {
            string BtnStartTaskText = ButtonStartTask.Text;
            if (BtnStartTaskText == MonitorTaskStatus.StartPush)
            {
                OdooToKingdeeTimer.Enabled = true;
                ListBoxKingdeeTaskList.Items.Add("开始推送......");
                ButtonStartTask.Text = MonitorTaskStatus.StopPush;
            }
            else if (BtnStartTaskText == MonitorTaskStatus.StopPush)
            {
                OdooToKingdeeTimer.Enabled = false;
                ListBoxKingdeeTaskList.Items.Add("停止推送......");
                ButtonStartTask.Text = MonitorTaskStatus.StartPush;
            }
        }

        private void OdooToKingdeeTimer_Tick(object sender, EventArgs e)
        {
            LabelStartTime.Text = "最新同步时间：\r\n" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            if (ListBoxKingdeeTaskList.Items.Count > 100)
                ListBoxKingdeeTaskList.Items.Clear();
            if (ListBoxExceptionList.Items.Count > 100)
                ListBoxExceptionList.Items.Clear();

            Dictionary<string, string> resultStr = new DataCenter().BeginTask();
            foreach (var item in resultStr)
            {
                if (item.Key.Contains("ok"))
                {
                    ListBoxKingdeeTaskList.Items.Add(item.Value);
                }
                else if (item.Key.Contains("bad"))
                {
                    ListBoxExceptionList.Items.Add(item.Value);
                }
            }
        }

        private void OdooToKingdee_Load(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this);
        }

        private void OdooToKingdee_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }
    }
}
