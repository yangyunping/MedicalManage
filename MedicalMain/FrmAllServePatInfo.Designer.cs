namespace UI
{
    partial class FrmAllServePatInfo
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.trButton = new System.Windows.Forms.ToolStrip();
            this.btnServePatSearch = new System.Windows.Forms.ToolStripButton();
            this.tsMedBuyInfo = new System.Windows.Forms.ToolStripButton();
            this.btnNumSearch = new System.Windows.Forms.ToolStripButton();
            this.tbContent = new System.Windows.Forms.TabControl();
            this.trButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // trButton
            // 
            this.trButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.trButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.trButton.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.trButton.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.trButton.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.trButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnServePatSearch,
            this.tsMedBuyInfo,
            this.btnNumSearch});
            this.trButton.Location = new System.Drawing.Point(0, 0);
            this.trButton.Name = "trButton";
            this.trButton.Padding = new System.Windows.Forms.Padding(1);
            this.trButton.Size = new System.Drawing.Size(130, 569);
            this.trButton.TabIndex = 1;
            this.trButton.Text = "toolStrip1";
            this.trButton.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.trButton_ItemClicked);
            // 
            // btnServePatSearch
            // 
            this.btnServePatSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnServePatSearch.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnServePatSearch.Image = global::UI.Properties.Resources.bookmark;
            this.btnServePatSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnServePatSearch.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnServePatSearch.Name = "btnServePatSearch";
            this.btnServePatSearch.Padding = new System.Windows.Forms.Padding(1);
            this.btnServePatSearch.Size = new System.Drawing.Size(125, 41);
            this.btnServePatSearch.Text = "门诊药品使用";
            this.btnServePatSearch.Click += new System.EventHandler(this.btnServePatSearch_Click);
            // 
            // tsMedBuyInfo
            // 
            this.tsMedBuyInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tsMedBuyInfo.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.tsMedBuyInfo.Image = global::UI.Properties.Resources.SearchStatistics;
            this.tsMedBuyInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMedBuyInfo.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.tsMedBuyInfo.Name = "tsMedBuyInfo";
            this.tsMedBuyInfo.Padding = new System.Windows.Forms.Padding(1);
            this.tsMedBuyInfo.Size = new System.Drawing.Size(125, 41);
            this.tsMedBuyInfo.Text = "购买查询";
            this.tsMedBuyInfo.Click += new System.EventHandler(this.tsMedBuyInfo_Click);
            // 
            // btnNumSearch
            // 
            this.btnNumSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNumSearch.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNumSearch.Image = global::UI.Properties.Resources.Calculator_operations;
            this.btnNumSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNumSearch.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnNumSearch.Name = "btnNumSearch";
            this.btnNumSearch.Padding = new System.Windows.Forms.Padding(1);
            this.btnNumSearch.Size = new System.Drawing.Size(138, 41);
            this.btnNumSearch.Text = "医生问诊量查询";
            this.btnNumSearch.Visible = false;
            this.btnNumSearch.Click += new System.EventHandler(this.btnNumSearch_Click);
            // 
            // tbContent
            // 
            this.tbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContent.Location = new System.Drawing.Point(130, 0);
            this.tbContent.Name = "tbContent";
            this.tbContent.SelectedIndex = 0;
            this.tbContent.Size = new System.Drawing.Size(1014, 569);
            this.tbContent.TabIndex = 2;
            this.tbContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbContent_MouseDoubleClick);
            // 
            // FrmAllServePatInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.trButton);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAllServePatInfo";
            this.Size = new System.Drawing.Size(1144, 569);
            this.trButton.ResumeLayout(false);
            this.trButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip trButton;
        private System.Windows.Forms.ToolStripButton btnServePatSearch;
        private System.Windows.Forms.ToolStripButton btnNumSearch;
        private System.Windows.Forms.TabControl tbContent;
        private System.Windows.Forms.ToolStripButton tsMedBuyInfo;
    }
}
