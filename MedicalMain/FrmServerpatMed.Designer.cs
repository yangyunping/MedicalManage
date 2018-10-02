namespace UI
{
    partial class FrmServerpatMed
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMedicines = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPations = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMoneySum = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.cmbEmployees = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMedsInfo = new System.Windows.Forms.DataGridView();
            this.cmsCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmbCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedsInfo)).BeginInit();
            this.cmsCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbMedicines);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbStyle);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbPations);
            this.panel1.Controls.Add(this.label2);
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
            this.panel1.Size = new System.Drawing.Size(1093, 107);
            this.panel1.TabIndex = 1;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(707, 65);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(118, 24);
            this.txtKey.TabIndex = 41;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "关键字";
            // 
            // cmbMedicines
            // 
            this.cmbMedicines.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbMedicines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicines.FormattingEnabled = true;
            this.cmbMedicines.Location = new System.Drawing.Point(498, 64);
            this.cmbMedicines.Name = "cmbMedicines";
            this.cmbMedicines.Size = new System.Drawing.Size(129, 27);
            this.cmbMedicines.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(428, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 38;
            this.label9.Text = "药品名称";
            // 
            // cmbStyle
            // 
            this.cmbStyle.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(498, 19);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(129, 27);
            this.cmbStyle.TabIndex = 37;
            this.cmbStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(427, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 19);
            this.label8.TabIndex = 36;
            this.label8.Text = "药品类别";
            // 
            // cmbPations
            // 
            this.cmbPations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPations.FormattingEnabled = true;
            this.cmbPations.Location = new System.Drawing.Point(278, 64);
            this.cmbPations.Name = "cmbPations";
            this.cmbPations.Size = new System.Drawing.Size(121, 27);
            this.cmbPations.TabIndex = 8;
            this.cmbPations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPations_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "病人";
            // 
            // lblMoneySum
            // 
            this.lblMoneySum.AutoSize = true;
            this.lblMoneySum.BackColor = System.Drawing.Color.Transparent;
            this.lblMoneySum.ForeColor = System.Drawing.Color.Maroon;
            this.lblMoneySum.Location = new System.Drawing.Point(921, 85);
            this.lblMoneySum.Name = "lblMoneySum";
            this.lblMoneySum.Size = new System.Drawing.Size(74, 19);
            this.lblMoneySum.TabIndex = 6;
            this.lblMoneySum.Text = "显示数量：";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(845, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 36);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查  询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(93, 65);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(109, 24);
            this.dtpEnd.TabIndex = 4;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBegin.Location = new System.Drawing.Point(93, 20);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(109, 24);
            this.dtpBegin.TabIndex = 3;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(31, 21);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(54, 23);
            this.chkDate.TabIndex = 2;
            this.chkDate.Text = "时间";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployees.FormattingEnabled = true;
            this.cmbEmployees.Location = new System.Drawing.Point(278, 19);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(121, 27);
            this.cmbEmployees.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "医生";
            // 
            // dgvMedsInfo
            // 
            this.dgvMedsInfo.AllowUserToAddRows = false;
            this.dgvMedsInfo.AllowUserToDeleteRows = false;
            this.dgvMedsInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedsInfo.ContextMenuStrip = this.cmsCopy;
            this.dgvMedsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedsInfo.Location = new System.Drawing.Point(0, 107);
            this.dgvMedsInfo.Name = "dgvMedsInfo";
            this.dgvMedsInfo.ReadOnly = true;
            this.dgvMedsInfo.RowHeadersWidth = 11;
            this.dgvMedsInfo.RowTemplate.Height = 23;
            this.dgvMedsInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedsInfo.Size = new System.Drawing.Size(1093, 482);
            this.dgvMedsInfo.TabIndex = 2;
            // 
            // cmsCopy
            // 
            this.cmsCopy.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.cmsCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbCopy});
            this.cmsCopy.Name = "cmsCopy";
            this.cmsCopy.Size = new System.Drawing.Size(126, 26);
            // 
            // cmbCopy
            // 
            this.cmbCopy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCopy.Name = "cmbCopy";
            this.cmbCopy.Size = new System.Drawing.Size(125, 22);
            this.cmbCopy.Text = "复制选中";
            this.cmbCopy.Click += new System.EventHandler(this.cmbCopy_Click);
            // 
            // FrmServerpatMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMedsInfo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmServerpatMed";
            this.Size = new System.Drawing.Size(1093, 589);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedsInfo)).EndInit();
            this.cmsCopy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMoneySum;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.ComboBox cmbEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMedsInfo;
        private System.Windows.Forms.ComboBox cmbPations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMedicines;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsCopy;
        private System.Windows.Forms.ToolStripMenuItem cmbCopy;
    }
}
