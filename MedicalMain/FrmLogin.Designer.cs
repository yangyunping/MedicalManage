namespace UI
{
    partial class FrmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblClose = new System.Windows.Forms.Label();
            this.cmbEmpID = new System.Windows.Forms.ComboBox();
            this.chkRemenber = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(137, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "门诊管理系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(76, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "账  号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(76, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "密  码";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtPassword.Location = new System.Drawing.Point(127, 135);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(144, 24);
            this.txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnLogin.Location = new System.Drawing.Point(80, 192);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(191, 35);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登       录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picLogo.Location = new System.Drawing.Point(59, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(60, 60);
            this.picLogo.TabIndex = 6;
            this.picLogo.TabStop = false;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.Location = new System.Drawing.Point(318, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(32, 31);
            this.lblClose.TabIndex = 7;
            this.lblClose.Text = "×";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // cmbEmpID
            // 
            this.cmbEmpID.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.cmbEmpID.FormattingEnabled = true;
            this.cmbEmpID.Location = new System.Drawing.Point(127, 96);
            this.cmbEmpID.Name = "cmbEmpID";
            this.cmbEmpID.Size = new System.Drawing.Size(144, 27);
            this.cmbEmpID.TabIndex = 9;
            // 
            // chkRemenber
            // 
            this.chkRemenber.AutoSize = true;
            this.chkRemenber.Checked = true;
            this.chkRemenber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemenber.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chkRemenber.Location = new System.Drawing.Point(144, 165);
            this.chkRemenber.Name = "chkRemenber";
            this.chkRemenber.Size = new System.Drawing.Size(75, 21);
            this.chkRemenber.TabIndex = 10;
            this.chkRemenber.Text = "记住账号";
            this.chkRemenber.UseVisualStyleBackColor = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(350, 240);
            this.Controls.Add(this.chkRemenber);
            this.Controls.Add(this.cmbEmpID);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医疗系统";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmLogin_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.ComboBox cmbEmpID;
        private System.Windows.Forms.CheckBox chkRemenber;
    }
}

