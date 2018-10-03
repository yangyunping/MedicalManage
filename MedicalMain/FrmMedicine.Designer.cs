namespace UI
{
    partial class FrmMedicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedicine));
            this.trButton = new System.Windows.Forms.ToolStrip();
            this.SbtnAddMed = new System.Windows.Forms.ToolStripButton();
            this.sBtnMedSearch = new System.Windows.Forms.ToolStripButton();
            this.sbtnCreate = new System.Windows.Forms.ToolStripButton();
            this.tbContent = new System.Windows.Forms.TabControl();
            this.trButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // trButton
            // 
            this.trButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.trButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.trButton.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.trButton.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.trButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbtnAddMed,
            this.sBtnMedSearch,
            this.sbtnCreate});
            this.trButton.Location = new System.Drawing.Point(0, 0);
            this.trButton.Name = "trButton";
            this.trButton.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.trButton.Size = new System.Drawing.Size(109, 515);
            this.trButton.TabIndex = 0;
            this.trButton.Text = "toolStrip1";
            this.trButton.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.trButton_ItemClicked);
            // 
            // SbtnAddMed
            // 
            this.SbtnAddMed.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SbtnAddMed.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.SbtnAddMed.Image = ((System.Drawing.Image)(resources.GetObject("SbtnAddMed.Image")));
            this.SbtnAddMed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SbtnAddMed.Name = "SbtnAddMed";
            this.SbtnAddMed.Padding = new System.Windows.Forms.Padding(3);
            this.SbtnAddMed.Size = new System.Drawing.Size(102, 45);
            this.SbtnAddMed.Text = "药品查询";
            this.SbtnAddMed.ToolTipText = "库存新增";
            this.SbtnAddMed.Click += new System.EventHandler(this.SbtnAddMed_Click);
            // 
            // sBtnMedSearch
            // 
            this.sBtnMedSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sBtnMedSearch.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.sBtnMedSearch.Image = global::UI.Properties.Resources.Statistics_PieChart;
            this.sBtnMedSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sBtnMedSearch.Name = "sBtnMedSearch";
            this.sBtnMedSearch.Padding = new System.Windows.Forms.Padding(3);
            this.sBtnMedSearch.Size = new System.Drawing.Size(102, 45);
            this.sBtnMedSearch.Text = "库存查询";
            this.sBtnMedSearch.ToolTipText = "库存查询";
            this.sBtnMedSearch.Click += new System.EventHandler(this.sBtnMedSearch_Click);
            // 
            // sbtnCreate
            // 
            this.sbtnCreate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sbtnCreate.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.sbtnCreate.Image = global::UI.Properties.Resources.Pencil;
            this.sbtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbtnCreate.Name = "sbtnCreate";
            this.sbtnCreate.Size = new System.Drawing.Size(102, 39);
            this.sbtnCreate.Text = "创建药品";
            this.sbtnCreate.Visible = false;
            this.sbtnCreate.Click += new System.EventHandler(this.sbtnCreate_Click);
            // 
            // tbContent
            // 
            this.tbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContent.Location = new System.Drawing.Point(109, 0);
            this.tbContent.Name = "tbContent";
            this.tbContent.SelectedIndex = 0;
            this.tbContent.Size = new System.Drawing.Size(884, 515);
            this.tbContent.TabIndex = 1;
            this.tbContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbContent_MouseDoubleClick);
            // 
            // FrmMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.trButton);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMedicine";
            this.Size = new System.Drawing.Size(993, 515);
            this.trButton.ResumeLayout(false);
            this.trButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip trButton;
        private System.Windows.Forms.ToolStripButton SbtnAddMed;
        private System.Windows.Forms.ToolStripButton sBtnMedSearch;
        private System.Windows.Forms.TabControl tbContent;
        private System.Windows.Forms.ToolStripButton sbtnCreate;
    }
}
