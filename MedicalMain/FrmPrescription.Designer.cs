namespace MedicalManage
{
    partial class FrmPrescription
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtKeys = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblMoneySum = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.cmbEmployees = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvServePats = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServePats)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtKeys);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblNum);
            this.panel1.Controls.Add(this.lblMoneySum);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpBegin);
            this.panel1.Controls.Add(this.chkDate);
            this.panel1.Controls.Add(this.cmbEmployees);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 67);
            this.panel1.TabIndex = 0;
            // 
            // txtKeys
            // 
            this.txtKeys.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeys.Location = new System.Drawing.Point(538, 19);
            this.txtKeys.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtKeys.Name = "txtKeys";
            this.txtKeys.Size = new System.Drawing.Size(110, 26);
            this.txtKeys.TabIndex = 9;
            this.txtKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeys_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label2.Location = new System.Drawing.Point(490, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "关键字";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.BackColor = System.Drawing.Color.Transparent;
            this.lblNum.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblNum.ForeColor = System.Drawing.Color.Maroon;
            this.lblNum.Location = new System.Drawing.Point(786, 18);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(56, 17);
            this.lblNum.TabIndex = 7;
            this.lblNum.Text = "门诊量：";
            // 
            // lblMoneySum
            // 
            this.lblMoneySum.AutoSize = true;
            this.lblMoneySum.BackColor = System.Drawing.Color.Transparent;
            this.lblMoneySum.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblMoneySum.ForeColor = System.Drawing.Color.Maroon;
            this.lblMoneySum.Location = new System.Drawing.Point(786, 46);
            this.lblMoneySum.Name = "lblMoneySum";
            this.lblMoneySum.Size = new System.Drawing.Size(68, 17);
            this.lblMoneySum.TabIndex = 6;
            this.lblMoneySum.Text = "显示总额：";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(664, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 31);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查  询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(192, 20);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(110, 24);
            this.dtpEnd.TabIndex = 4;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBegin.Location = new System.Drawing.Point(77, 20);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(110, 24);
            this.dtpBegin.TabIndex = 3;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chkDate.Location = new System.Drawing.Point(20, 23);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(51, 21);
            this.chkDate.TabIndex = 2;
            this.chkDate.Text = "时间";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployees.FormattingEnabled = true;
            this.cmbEmployees.Location = new System.Drawing.Point(349, 19);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(121, 27);
            this.cmbEmployees.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(311, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "医生";
            // 
            // dgvServePats
            // 
            this.dgvServePats.AllowUserToAddRows = false;
            this.dgvServePats.BackgroundColor = System.Drawing.Color.White;
            this.dgvServePats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServePats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServePats.Location = new System.Drawing.Point(0, 67);
            this.dgvServePats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvServePats.Name = "dgvServePats";
            this.dgvServePats.RowHeadersWidth = 20;
            this.dgvServePats.RowTemplate.Height = 23;
            this.dgvServePats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServePats.Size = new System.Drawing.Size(1005, 550);
            this.dgvServePats.TabIndex = 1;
            this.dgvServePats.DoubleClick += new System.EventHandler(this.dgvServePats_DoubleClick);
            // 
            // FrmPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvServePats);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrescription";
            this.Size = new System.Drawing.Size(1005, 617);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServePats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvServePats;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.ComboBox cmbEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblMoneySum;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtKeys;
        private System.Windows.Forms.Label label2;
    }
}
