namespace MedicalManage
{
    partial class FrmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsButtons = new System.Windows.Forms.ToolStrip();
            this.tsBtnLookPat = new System.Windows.Forms.ToolStripButton();
            this.btnStaticsSearch = new System.Windows.Forms.ToolStripButton();
            this.sbtnMedicine = new System.Windows.Forms.ToolStripButton();
            this.sbtnEmployee = new System.Windows.Forms.ToolStripButton();
            this.btnPations = new System.Windows.Forms.ToolStripButton();
            this.tsmSetting = new System.Windows.Forms.ToolStripDropDownButton();
            this.基础设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查费调整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.密码修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.dgvMedInfo = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbContent = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tsButtons.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedInfo)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tsButtons);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1304, 58);
            this.panel1.TabIndex = 0;
            // 
            // tsButtons
            // 
            this.tsButtons.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tsButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsButtons.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsButtons.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.tsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnLookPat,
            this.btnStaticsSearch,
            this.sbtnMedicine,
            this.sbtnEmployee,
            this.btnPations,
            this.tsmSetting});
            this.tsButtons.Location = new System.Drawing.Point(83, 0);
            this.tsButtons.Name = "tsButtons";
            this.tsButtons.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tsButtons.Size = new System.Drawing.Size(1221, 58);
            this.tsButtons.TabIndex = 1;
            this.tsButtons.Text = "门诊";
            this.tsButtons.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsButtons_ItemClicked);
            // 
            // tsBtnLookPat
            // 
            this.tsBtnLookPat.BackColor = System.Drawing.Color.Transparent;
            this.tsBtnLookPat.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.tsBtnLookPat.ForeColor = System.Drawing.Color.White;
            this.tsBtnLookPat.Image = global::MedicalManage.Properties.Resources.heart;
            this.tsBtnLookPat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLookPat.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.tsBtnLookPat.Name = "tsBtnLookPat";
            this.tsBtnLookPat.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tsBtnLookPat.Size = new System.Drawing.Size(75, 50);
            this.tsBtnLookPat.Text = "门诊";
            this.tsBtnLookPat.Click += new System.EventHandler(this.tsBtnLookPat_Click);
            // 
            // btnStaticsSearch
            // 
            this.btnStaticsSearch.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnStaticsSearch.ForeColor = System.Drawing.Color.White;
            this.btnStaticsSearch.Image = global::MedicalManage.Properties.Resources.Statistics;
            this.btnStaticsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStaticsSearch.Name = "btnStaticsSearch";
            this.btnStaticsSearch.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnStaticsSearch.Size = new System.Drawing.Size(109, 49);
            this.btnStaticsSearch.Text = "统计查询";
            this.btnStaticsSearch.Click += new System.EventHandler(this.btnStaticsSearch_Click);
            // 
            // sbtnMedicine
            // 
            this.sbtnMedicine.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.sbtnMedicine.ForeColor = System.Drawing.Color.White;
            this.sbtnMedicine.Image = global::MedicalManage.Properties.Resources.Home;
            this.sbtnMedicine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbtnMedicine.Name = "sbtnMedicine";
            this.sbtnMedicine.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sbtnMedicine.Size = new System.Drawing.Size(109, 49);
            this.sbtnMedicine.Text = "药品管理";
            this.sbtnMedicine.Click += new System.EventHandler(this.sbtnMedicine_Click);
            // 
            // sbtnEmployee
            // 
            this.sbtnEmployee.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.sbtnEmployee.ForeColor = System.Drawing.Color.White;
            this.sbtnEmployee.Image = global::MedicalManage.Properties.Resources.ManageUsers;
            this.sbtnEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbtnEmployee.Name = "sbtnEmployee";
            this.sbtnEmployee.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sbtnEmployee.Size = new System.Drawing.Size(109, 49);
            this.sbtnEmployee.Text = "人员管理";
            this.sbtnEmployee.Click += new System.EventHandler(this.sbtnEmployee_Click);
            // 
            // btnPations
            // 
            this.btnPations.BackColor = System.Drawing.Color.Transparent;
            this.btnPations.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnPations.ForeColor = System.Drawing.Color.White;
            this.btnPations.Image = global::MedicalManage.Properties.Resources.System_monitoring;
            this.btnPations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPations.Name = "btnPations";
            this.btnPations.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnPations.Size = new System.Drawing.Size(103, 49);
            this.btnPations.Text = "患者管理";
            this.btnPations.Click += new System.EventHandler(this.btnPations_Click);
            // 
            // tsmSetting
            // 
            this.tsmSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基础设置ToolStripMenuItem,
            this.检查费调整ToolStripMenuItem,
            this.密码修改ToolStripMenuItem});
            this.tsmSetting.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tsmSetting.ForeColor = System.Drawing.Color.White;
            this.tsmSetting.Image = global::MedicalManage.Properties.Resources.System;
            this.tsmSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmSetting.Name = "tsmSetting";
            this.tsmSetting.Size = new System.Drawing.Size(80, 49);
            this.tsmSetting.Text = "设置";
            // 
            // 基础设置ToolStripMenuItem
            // 
            this.基础设置ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.基础设置ToolStripMenuItem.Name = "基础设置ToolStripMenuItem";
            this.基础设置ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.基础设置ToolStripMenuItem.Text = "基础设置";
            this.基础设置ToolStripMenuItem.Click += new System.EventHandler(this.基础设置ToolStripMenuItem_Click);
            // 
            // 检查费调整ToolStripMenuItem
            // 
            this.检查费调整ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.检查费调整ToolStripMenuItem.Name = "检查费调整ToolStripMenuItem";
            this.检查费调整ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.检查费调整ToolStripMenuItem.Text = "检查费调整";
            this.检查费调整ToolStripMenuItem.Click += new System.EventHandler(this.检查费调整ToolStripMenuItem_Click);
            // 
            // 密码修改ToolStripMenuItem
            // 
            this.密码修改ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.密码修改ToolStripMenuItem.Name = "密码修改ToolStripMenuItem";
            this.密码修改ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.密码修改ToolStripMenuItem.Text = "密码修改";
            this.密码修改ToolStripMenuItem.Click += new System.EventHandler(this.密码修改ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.picShow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(83, 58);
            this.panel2.TabIndex = 2;
            // 
            // picShow
            // 
            this.picShow.BackColor = System.Drawing.Color.Transparent;
            this.picShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picShow.Location = new System.Drawing.Point(0, 0);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(83, 58);
            this.picShow.TabIndex = 0;
            this.picShow.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWelcome.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblWelcome.ForeColor = System.Drawing.Color.Maroon;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(61, 19);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "人员信息";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTime);
            this.panel3.Controls.Add(this.lblWeather);
            this.panel3.Controls.Add(this.lblWelcome);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 585);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1304, 23);
            this.panel3.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblTime.Location = new System.Drawing.Point(96, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 19);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "时间";
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.BackColor = System.Drawing.Color.Transparent;
            this.lblWeather.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWeather.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblWeather.ForeColor = System.Drawing.Color.Maroon;
            this.lblWeather.Location = new System.Drawing.Point(61, 0);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(35, 19);
            this.lblWeather.TabIndex = 5;
            this.lblWeather.Text = "天气";
            // 
            // dgvMedInfo
            // 
            this.dgvMedInfo.AllowUserToAddRows = false;
            this.dgvMedInfo.AllowUserToDeleteRows = false;
            this.dgvMedInfo.AllowUserToOrderColumns = true;
            this.dgvMedInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvMedInfo.Name = "dgvMedInfo";
            this.dgvMedInfo.ReadOnly = true;
            this.dgvMedInfo.RowHeadersWidth = 5;
            this.dgvMedInfo.RowTemplate.Height = 23;
            this.dgvMedInfo.Size = new System.Drawing.Size(214, 527);
            this.dgvMedInfo.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvMedInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1090, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(214, 527);
            this.panel4.TabIndex = 3;
            // 
            // tbContent
            // 
            this.tbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContent.Location = new System.Drawing.Point(0, 58);
            this.tbContent.Name = "tbContent";
            this.tbContent.SelectedIndex = 0;
            this.tbContent.Size = new System.Drawing.Size(1090, 527);
            this.tbContent.TabIndex = 4;
            this.tbContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbContent_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 608);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医疗管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsButtons.ResumeLayout(false);
            this.tsButtons.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedInfo)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsButtons;
        private System.Windows.Forms.ToolStripButton tsBtnLookPat;
        private System.Windows.Forms.ToolStripButton btnPations;
        private System.Windows.Forms.ToolStripButton sbtnMedicine;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolStripButton btnStaticsSearch;
        private System.Windows.Forms.ToolStripButton sbtnEmployee;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvMedInfo;
        private System.Windows.Forms.ToolStripDropDownButton tsmSetting;
        private System.Windows.Forms.ToolStripMenuItem 基础设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查费调整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 密码修改ToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tbContent;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label lblTime;
    }
}