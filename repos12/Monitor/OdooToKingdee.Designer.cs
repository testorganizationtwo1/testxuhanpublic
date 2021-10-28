
namespace Monitor
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
            this.ListBoxExceptionList = new System.Windows.Forms.ListBox();
            this.LabelListBoxKingdeeTaskList = new System.Windows.Forms.Label();
            this.LabelListBoxExceptionList = new System.Windows.Forms.Label();
            this.ButtonStartTask = new System.Windows.Forms.Button();
            this.OdooToKingdeeTimer = new System.Windows.Forms.Timer(this.components);
            this.LabelStartTime = new System.Windows.Forms.Label();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.开始任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxKingdeeTaskList
            // 
            this.ListBoxKingdeeTaskList.FormattingEnabled = true;
            this.ListBoxKingdeeTaskList.ItemHeight = 18;
            this.ListBoxKingdeeTaskList.Location = new System.Drawing.Point(39, 80);
            this.ListBoxKingdeeTaskList.Name = "ListBoxKingdeeTaskList";
            this.ListBoxKingdeeTaskList.Size = new System.Drawing.Size(386, 454);
            this.ListBoxKingdeeTaskList.TabIndex = 1;
            // 
            // ListBoxExceptionList
            // 
            this.ListBoxExceptionList.FormattingEnabled = true;
            this.ListBoxExceptionList.HorizontalScrollbar = true;
            this.ListBoxExceptionList.ItemHeight = 18;
            this.ListBoxExceptionList.Location = new System.Drawing.Point(449, 80);
            this.ListBoxExceptionList.Name = "ListBoxExceptionList";
            this.ListBoxExceptionList.Size = new System.Drawing.Size(555, 454);
            this.ListBoxExceptionList.TabIndex = 2;
            // 
            // LabelListBoxKingdeeTaskList
            // 
            this.LabelListBoxKingdeeTaskList.AutoSize = true;
            this.LabelListBoxKingdeeTaskList.Location = new System.Drawing.Point(36, 56);
            this.LabelListBoxKingdeeTaskList.Name = "LabelListBoxKingdeeTaskList";
            this.LabelListBoxKingdeeTaskList.Size = new System.Drawing.Size(98, 18);
            this.LabelListBoxKingdeeTaskList.TabIndex = 4;
            this.LabelListBoxKingdeeTaskList.Text = "任务记录：";
            // 
            // LabelListBoxExceptionList
            // 
            this.LabelListBoxExceptionList.AutoSize = true;
            this.LabelListBoxExceptionList.Location = new System.Drawing.Point(446, 56);
            this.LabelListBoxExceptionList.Name = "LabelListBoxExceptionList";
            this.LabelListBoxExceptionList.Size = new System.Drawing.Size(98, 18);
            this.LabelListBoxExceptionList.TabIndex = 5;
            this.LabelListBoxExceptionList.Text = "出错记录：";
            // 
            // ButtonStartTask
            // 
            this.ButtonStartTask.Font = new System.Drawing.Font("宋体", 9F);
            this.ButtonStartTask.Location = new System.Drawing.Point(897, 552);
            this.ButtonStartTask.Name = "ButtonStartTask";
            this.ButtonStartTask.Size = new System.Drawing.Size(107, 37);
            this.ButtonStartTask.TabIndex = 6;
            this.ButtonStartTask.Text = "开始推送";
            this.ButtonStartTask.UseVisualStyleBackColor = true;
            this.ButtonStartTask.Click += new System.EventHandler(this.ButtonStartTask_Click);
            // 
            // OdooToKingdeeTimer
            // 
            this.OdooToKingdeeTimer.Interval = 10000;
            this.OdooToKingdeeTimer.Tick += new System.EventHandler(this.OdooToKingdeeTimer_Tick);
            // 
            // LabelStartTime
            // 
            this.LabelStartTime.AutoSize = true;
            this.LabelStartTime.Location = new System.Drawing.Point(446, 561);
            this.LabelStartTime.Name = "LabelStartTime";
            this.LabelStartTime.Size = new System.Drawing.Size(62, 18);
            this.LabelStartTime.TabIndex = 7;
            this.LabelStartTime.Text = "未开始";

            // 
            // OdooToKingdee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1043, 610);
            this.Controls.Add(this.LabelStartTime);
            this.Controls.Add(this.ButtonStartTask);
            this.Controls.Add(this.LabelListBoxExceptionList);
            this.Controls.Add(this.LabelListBoxKingdeeTaskList);
            this.Controls.Add(this.ListBoxExceptionList);
            this.Controls.Add(this.ListBoxKingdeeTaskList);
            this.Controls.Add(this.TopMenuStrip);
            this.MainMenuStrip = this.TopMenuStrip;
            this.Name = "OdooToKingdee";
            this.Text = "OdooToKingdee";
            this.Load += new System.EventHandler(this.OdooToKingdee_Load);
            this.SizeChanged += new System.EventHandler(this.OdooToKingdee_SizeChanged);
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox ListBoxKingdeeTaskList;
        private System.Windows.Forms.ListBox ListBoxExceptionList;
        private System.Windows.Forms.Label LabelListBoxKingdeeTaskList;
        private System.Windows.Forms.Label LabelListBoxExceptionList;
        private System.Windows.Forms.Button ButtonStartTask;
        private System.Windows.Forms.Timer OdooToKingdeeTimer;
        private System.Windows.Forms.Label LabelStartTime;
        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 开始任务ToolStripMenuItem;
    }
}