namespace UI
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
            this.tmsLookPat = new System.Windows.Forms.ToolStripButton();
            this.btnStaticsSearch = new System.Windows.Forms.ToolStripButton();
            this.sbtnMedicine = new System.Windows.Forms.ToolStripButton();
            this.sbtnEmployee = new System.Windows.Forms.ToolStripButton();
            this.btnPations = new System.Windows.Forms.ToolStripButton();
            this.tsmSettingMenues = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCheckSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPws = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmThemes = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.tbContent = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.skinEngine = new Sunisoft.IrisSkin.SkinEngine();
            this.pnlThemes = new System.Windows.Forms.Panel();
            this.btnCloseTheme = new System.Windows.Forms.Button();
            this.lstbThemes = new System.Windows.Forms.ListBox();
            this.btnThemeOrigal = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tsButtons.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlThemes.SuspendLayout();
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
            this.tsButtons.BackColor = System.Drawing.Color.Transparent;
            this.tsButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsButtons.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsButtons.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.tsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsLookPat,
            this.btnStaticsSearch,
            this.sbtnMedicine,
            this.sbtnEmployee,
            this.btnPations,
            this.tsmSettingMenues});
            this.tsButtons.Location = new System.Drawing.Point(83, 0);
            this.tsButtons.Name = "tsButtons";
            this.tsButtons.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tsButtons.Size = new System.Drawing.Size(1221, 58);
            this.tsButtons.TabIndex = 1;
            this.tsButtons.Text = "门诊";
            this.tsButtons.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsButtons_ItemClicked);
            // 
            // tmsLookPat
            // 
            this.tmsLookPat.BackColor = System.Drawing.Color.Transparent;
            this.tmsLookPat.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.tmsLookPat.ForeColor = System.Drawing.Color.Black;
            this.tmsLookPat.Image = global::UI.Properties.Resources.heart;
            this.tmsLookPat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmsLookPat.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.tmsLookPat.Name = "tmsLookPat";
            this.tmsLookPat.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tmsLookPat.Size = new System.Drawing.Size(75, 50);
            this.tmsLookPat.Text = "门诊";
            this.tmsLookPat.Click += new System.EventHandler(this.tsBtnLookPat_Click);
            // 
            // btnStaticsSearch
            // 
            this.btnStaticsSearch.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnStaticsSearch.ForeColor = System.Drawing.Color.Black;
            this.btnStaticsSearch.Image = global::UI.Properties.Resources.Statistics;
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
            this.sbtnMedicine.ForeColor = System.Drawing.Color.Black;
            this.sbtnMedicine.Image = global::UI.Properties.Resources.Home;
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
            this.sbtnEmployee.ForeColor = System.Drawing.Color.Black;
            this.sbtnEmployee.Image = global::UI.Properties.Resources.ManageUsers;
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
            this.btnPations.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPations.ForeColor = System.Drawing.Color.Black;
            this.btnPations.Image = global::UI.Properties.Resources.System_monitoring;
            this.btnPations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPations.Name = "btnPations";
            this.btnPations.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnPations.Size = new System.Drawing.Size(99, 49);
            this.btnPations.Text = "患者管理";
            this.btnPations.Click += new System.EventHandler(this.btnPations_Click);
            // 
            // tsmSettingMenues
            // 
            this.tsmSettingMenues.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSetting,
            this.tsmCheckSetting,
            this.tsmPws,
            this.tsmThemes});
            this.tsmSettingMenues.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.tsmSettingMenues.ForeColor = System.Drawing.Color.Black;
            this.tsmSettingMenues.Image = global::UI.Properties.Resources.System;
            this.tsmSettingMenues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmSettingMenues.Name = "tsmSettingMenues";
            this.tsmSettingMenues.Size = new System.Drawing.Size(78, 49);
            this.tsmSettingMenues.Text = "设置";
            // 
            // tsmSetting
            // 
            this.tsmSetting.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tsmSetting.Name = "tsmSetting";
            this.tsmSetting.Size = new System.Drawing.Size(137, 22);
            this.tsmSetting.Text = "基础设置";
            this.tsmSetting.Click += new System.EventHandler(this.基础设置ToolStripMenuItem_Click);
            // 
            // tsmCheckSetting
            // 
            this.tsmCheckSetting.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tsmCheckSetting.Name = "tsmCheckSetting";
            this.tsmCheckSetting.Size = new System.Drawing.Size(137, 22);
            this.tsmCheckSetting.Text = "检查费调整";
            this.tsmCheckSetting.Click += new System.EventHandler(this.检查费调整ToolStripMenuItem_Click);
            // 
            // tsmPws
            // 
            this.tsmPws.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tsmPws.Name = "tsmPws";
            this.tsmPws.Size = new System.Drawing.Size(137, 22);
            this.tsmPws.Text = "密码修改";
            this.tsmPws.Click += new System.EventHandler(this.密码修改ToolStripMenuItem_Click);
            // 
            // tsmThemes
            // 
            this.tsmThemes.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tsmThemes.Name = "tsmThemes";
            this.tsmThemes.Size = new System.Drawing.Size(137, 22);
            this.tsmThemes.Text = "主题更换";
            this.tsmThemes.Click += new System.EventHandler(this.tsmThemes_Click);
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
            // tbContent
            // 
            this.tbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContent.Location = new System.Drawing.Point(0, 58);
            this.tbContent.Name = "tbContent";
            this.tbContent.SelectedIndex = 0;
            this.tbContent.Size = new System.Drawing.Size(1304, 527);
            this.tbContent.TabIndex = 4;
            this.tbContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbContent_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // skinEngine
            // 
            this.skinEngine.@__DrawButtonFocusRectangle = true;
            this.skinEngine.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine.MenuFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinEngine.SerialNumber = "";
            this.skinEngine.SkinFile = null;
            this.skinEngine.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // pnlThemes
            // 
            this.pnlThemes.Controls.Add(this.btnCloseTheme);
            this.pnlThemes.Controls.Add(this.lstbThemes);
            this.pnlThemes.Controls.Add(this.btnThemeOrigal);
            this.pnlThemes.Controls.Add(this.btnSave);
            this.pnlThemes.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlThemes.Location = new System.Drawing.Point(1033, 58);
            this.pnlThemes.Name = "pnlThemes";
            this.pnlThemes.Size = new System.Drawing.Size(271, 527);
            this.pnlThemes.TabIndex = 5;
            this.pnlThemes.Visible = false;
            // 
            // btnCloseTheme
            // 
            this.btnCloseTheme.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnCloseTheme.Location = new System.Drawing.Point(186, 143);
            this.btnCloseTheme.Name = "btnCloseTheme";
            this.btnCloseTheme.Size = new System.Drawing.Size(73, 35);
            this.btnCloseTheme.TabIndex = 7;
            this.btnCloseTheme.Text = "关  闭";
            this.btnCloseTheme.UseVisualStyleBackColor = true;
            this.btnCloseTheme.Click += new System.EventHandler(this.btnCloseTheme_Click);
            // 
            // lstbThemes
            // 
            this.lstbThemes.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstbThemes.FormattingEnabled = true;
            this.lstbThemes.ItemHeight = 19;
            this.lstbThemes.Location = new System.Drawing.Point(0, 0);
            this.lstbThemes.Name = "lstbThemes";
            this.lstbThemes.Size = new System.Drawing.Size(180, 527);
            this.lstbThemes.TabIndex = 6;
            this.lstbThemes.SelectedIndexChanged += new System.EventHandler(this.lstbThemes_SelectedIndexChanged);
            // 
            // btnThemeOrigal
            // 
            this.btnThemeOrigal.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnThemeOrigal.Location = new System.Drawing.Point(186, 83);
            this.btnThemeOrigal.Name = "btnThemeOrigal";
            this.btnThemeOrigal.Size = new System.Drawing.Size(73, 35);
            this.btnThemeOrigal.TabIndex = 5;
            this.btnThemeOrigal.Text = "恢复默认";
            this.btnThemeOrigal.UseVisualStyleBackColor = true;
            this.btnThemeOrigal.Click += new System.EventHandler(this.btnThemeOrigal_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnSave.Location = new System.Drawing.Point(186, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 608);
            this.Controls.Add(this.pnlThemes);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊管理系统";
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
            this.pnlThemes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsButtons;
        private System.Windows.Forms.ToolStripButton tmsLookPat;
        private System.Windows.Forms.ToolStripButton btnPations;
        private System.Windows.Forms.ToolStripButton sbtnMedicine;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolStripButton btnStaticsSearch;
        private System.Windows.Forms.ToolStripButton sbtnEmployee;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripDropDownButton tsmSettingMenues;
        private System.Windows.Forms.ToolStripMenuItem tsmSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmCheckSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmPws;
        private System.Windows.Forms.TabControl tbContent;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ToolStripMenuItem tsmThemes;
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        private System.Windows.Forms.Panel pnlThemes;
        private System.Windows.Forms.ListBox lstbThemes;
        private System.Windows.Forms.Button btnThemeOrigal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCloseTheme;
    }
}