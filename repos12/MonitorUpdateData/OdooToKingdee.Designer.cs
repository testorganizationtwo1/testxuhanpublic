
namespace MonitorUpdateData
{
    partial class OdooToKingdee
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LabelOdooTaskList = new System.Windows.Forms.Label();
            this.ListBoxOdooTaskList = new System.Windows.Forms.ListBox();
            this.ListBoxKingdeeTaskList = new System.Windows.Forms.ListBox();
            this.LabelKingdeeTaskList = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnStartTask = new System.Windows.Forms.Button();
            this.ListBoxExceptionList = new System.Windows.Forms.ListBox();
            this.LabelExceptionList = new System.Windows.Forms.Label();
            this.OdooToKingdeeTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.LabelStartTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelOdooTaskList
            // 
            this.LabelOdooTaskList.AutoSize = true;
            this.LabelOdooTaskList.Location = new System.Drawing.Point(41, 39);
            this.LabelOdooTaskList.Name = "LabelOdooTaskList";
            this.LabelOdooTaskList.Size = new System.Drawing.Size(224, 18);
            this.LabelOdooTaskList.TabIndex = 0;
            this.LabelOdooTaskList.Text = "odoo task list(top 1000)";
            // 
            // ListBoxOdooTaskList
            // 
            this.ListBoxOdooTaskList.FormattingEnabled = true;
            this.ListBoxOdooTaskList.ItemHeight = 18;
            this.ListBoxOdooTaskList.Location = new System.Drawing.Point(44, 73);
            this.ListBoxOdooTaskList.Name = "ListBoxOdooTaskList";
            this.ListBoxOdooTaskList.Size = new System.Drawing.Size(224, 526);
            this.ListBoxOdooTaskList.TabIndex = 1;
            // 
            // ListBoxKingdeeTaskList
            // 
            this.ListBoxKingdeeTaskList.FormattingEnabled = true;
            this.ListBoxKingdeeTaskList.ItemHeight = 18;
            this.ListBoxKingdeeTaskList.Location = new System.Drawing.Point(310, 73);
            this.ListBoxKingdeeTaskList.Name = "ListBoxKingdeeTaskList";
            this.ListBoxKingdeeTaskList.Size = new System.Drawing.Size(224, 526);
            this.ListBoxKingdeeTaskList.TabIndex = 3;
            // 
            // LabelKingdeeTaskList
            // 
            this.LabelKingdeeTaskList.AutoSize = true;
            this.LabelKingdeeTaskList.Location = new System.Drawing.Point(307, 39);
            this.LabelKingdeeTaskList.Name = "LabelKingdeeTaskList";
            this.LabelKingdeeTaskList.Size = new System.Drawing.Size(251, 18);
            this.LabelKingdeeTaskList.TabIndex = 2;
            this.LabelKingdeeTaskList.Text = "Kingdee task list(top 1000)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(276, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "->";
            // 
            // BtnStartTask
            // 
            this.BtnStartTask.Location = new System.Drawing.Point(1154, 568);
            this.BtnStartTask.Name = "BtnStartTask";
            this.BtnStartTask.Size = new System.Drawing.Size(104, 31);
            this.BtnStartTask.TabIndex = 5;
            this.BtnStartTask.Text = "开始推送";
            this.BtnStartTask.UseVisualStyleBackColor = true;
            this.BtnStartTask.Click += new System.EventHandler(this.BtnStartTask_Click);
            // 
            // ListBoxExceptionList
            // 
            this.ListBoxExceptionList.ForeColor = System.Drawing.Color.Red;
            this.ListBoxExceptionList.FormattingEnabled = true;
            this.ListBoxExceptionList.ItemHeight = 18;
            this.ListBoxExceptionList.Location = new System.Drawing.Point(582, 73);
            this.ListBoxExceptionList.Name = "ListBoxExceptionList";
            this.ListBoxExceptionList.Size = new System.Drawing.Size(257, 526);
            this.ListBoxExceptionList.TabIndex = 7;
            // 
            // LabelExceptionList
            // 
            this.LabelExceptionList.AutoSize = true;
            this.LabelExceptionList.Location = new System.Drawing.Point(579, 39);
            this.LabelExceptionList.Name = "LabelExceptionList";
            this.LabelExceptionList.Size = new System.Drawing.Size(197, 18);
            this.LabelExceptionList.TabIndex = 6;
            this.LabelExceptionList.Text = "Exception list(top 5)";
            // 
            // OdooToKingdeeTimer
            // 
            this.OdooToKingdeeTimer.Enabled = true;
            this.OdooToKingdeeTimer.Interval = 1000;
            this.OdooToKingdeeTimer.Tick += new System.EventHandler(this.OdooToKingdeeTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(871, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "同步时间:";
            // 
            // LabelStartTime
            // 
            this.LabelStartTime.AutoSize = true;
            this.LabelStartTime.Location = new System.Drawing.Point(966, 73);
            this.LabelStartTime.Name = "LabelStartTime";
            this.LabelStartTime.Size = new System.Drawing.Size(62, 18);
            this.LabelStartTime.TabIndex = 9;
            this.LabelStartTime.Text = "未开始";
            // 
            // OdooToKingdee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 643);
            this.Controls.Add(this.LabelStartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBoxExceptionList);
            this.Controls.Add(this.LabelExceptionList);
            this.Controls.Add(this.BtnStartTask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ListBoxKingdeeTaskList);
            this.Controls.Add(this.LabelKingdeeTaskList);
            this.Controls.Add(this.ListBoxOdooTaskList);
            this.Controls.Add(this.LabelOdooTaskList);
            this.Name = "OdooToKingdee";
            this.Text = "OdooToKingdee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelOdooTaskList;
        private System.Windows.Forms.ListBox ListBoxOdooTaskList;
        private System.Windows.Forms.ListBox ListBoxKingdeeTaskList;
        private System.Windows.Forms.Label LabelKingdeeTaskList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnStartTask;
        private System.Windows.Forms.ListBox ListBoxExceptionList;
        private System.Windows.Forms.Label LabelExceptionList;
        private System.Windows.Forms.Timer OdooToKingdeeTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelStartTime;
    }
}

