
namespace MonitorNew
{
    partial class OdooToKingdee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ListBoxKingdeeTaskList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonStartTask = new System.Windows.Forms.Button();
            this.LabelStartTime = new System.Windows.Forms.Label();
            this.OdooToKingdeeTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ConnectOdoo = new System.Windows.Forms.Button();
            this.ConnectKingdee = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListBoxKingdeeTaskList
            // 
            this.ListBoxKingdeeTaskList.BackColor = System.Drawing.SystemColors.Info;
            this.ListBoxKingdeeTaskList.FormattingEnabled = true;
            this.ListBoxKingdeeTaskList.HorizontalScrollbar = true;
            this.ListBoxKingdeeTaskList.ItemHeight = 18;
            this.ListBoxKingdeeTaskList.Location = new System.Drawing.Point(57, 65);
            this.ListBoxKingdeeTaskList.Name = "ListBoxKingdeeTaskList";
            this.ListBoxKingdeeTaskList.Size = new System.Drawing.Size(902, 490);
            this.ListBoxKingdeeTaskList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "任务记录：";
            // 
            // ButtonStartTask
            // 
            this.ButtonStartTask.Location = new System.Drawing.Point(855, 577);
            this.ButtonStartTask.Name = "ButtonStartTask";
            this.ButtonStartTask.Size = new System.Drawing.Size(104, 35);
            this.ButtonStartTask.TabIndex = 3;
            this.ButtonStartTask.Text = "开始推送";
            this.ButtonStartTask.UseVisualStyleBackColor = true;
            this.ButtonStartTask.Click += new System.EventHandler(this.ButtonStartTask_Click);
            // 
            // LabelStartTime
            // 
            this.LabelStartTime.AutoSize = true;
            this.LabelStartTime.Location = new System.Drawing.Point(605, 20);
            this.LabelStartTime.Name = "LabelStartTime";
            this.LabelStartTime.Size = new System.Drawing.Size(98, 18);
            this.LabelStartTime.TabIndex = 6;
            this.LabelStartTime.Text = "未开始同步";
            // 
            // OdooToKingdeeTimer
            // 
            this.OdooToKingdeeTimer.Interval = 1800000;
            this.OdooToKingdeeTimer.Tick += new System.EventHandler(this.OdooToKingdeeTimer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(605, 588);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "运行速度：";
            // 
            // ConnectOdoo
            // 
            this.ConnectOdoo.Location = new System.Drawing.Point(57, 582);
            this.ConnectOdoo.Name = "ConnectOdoo";
            this.ConnectOdoo.Size = new System.Drawing.Size(135, 31);
            this.ConnectOdoo.TabIndex = 9;
            this.ConnectOdoo.Text = "测试连接odoo";
            this.ConnectOdoo.UseVisualStyleBackColor = true;
            this.ConnectOdoo.Click += new System.EventHandler(this.ConnectOdoo_Click);
            // 
            // ConnectKingdee
            // 
            this.ConnectKingdee.Location = new System.Drawing.Point(210, 582);
            this.ConnectKingdee.Name = "ConnectKingdee";
            this.ConnectKingdee.Size = new System.Drawing.Size(161, 31);
            this.ConnectKingdee.TabIndex = 10;
            this.ConnectKingdee.Text = "测试连接kingdee";
            this.ConnectKingdee.UseVisualStyleBackColor = true;
            this.ConnectKingdee.Click += new System.EventHandler(this.ConnectKingdee_Click);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(694, 588);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(98, 18);
            this.labelSpeed.TabIndex = 11;
            this.labelSpeed.Text = "500毫秒/条";
            // 
            // OdooToKingdee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1013, 633);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.ConnectKingdee);
            this.Controls.Add(this.ConnectOdoo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelStartTime);
            this.Controls.Add(this.ButtonStartTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBoxKingdeeTaskList);
            this.Name = "OdooToKingdee";
            this.Text = "OdooToKingdee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox ListBoxKingdeeTaskList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonStartTask;
        private System.Windows.Forms.Label LabelStartTime;
        private System.Windows.Forms.Timer OdooToKingdeeTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ConnectOdoo;
        private System.Windows.Forms.Button ConnectKingdee;
        private System.Windows.Forms.Label labelSpeed;
    }
}