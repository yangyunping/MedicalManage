namespace UI
{
    partial class FrmPations
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbPatName = new System.Windows.Forms.ComboBox();
            this.lnl = new System.Windows.Forms.Label();
            this.dgvPat = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbPatName);
            this.panel1.Controls.Add(this.lnl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 63);
            this.panel1.TabIndex = 0;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(309, 20);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(125, 24);
            this.txtKey.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(255, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "关键字";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(459, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 30);
            this.btnSearch.TabIndex = 45;
            this.btnSearch.Text = "查   询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbPatName
            // 
            this.cmbPatName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatName.FormattingEnabled = true;
            this.cmbPatName.Location = new System.Drawing.Point(98, 19);
            this.cmbPatName.Name = "cmbPatName";
            this.cmbPatName.Size = new System.Drawing.Size(129, 27);
            this.cmbPatName.TabIndex = 44;
            // 
            // lnl
            // 
            this.lnl.AutoSize = true;
            this.lnl.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lnl.Location = new System.Drawing.Point(27, 24);
            this.lnl.Name = "lnl";
            this.lnl.Size = new System.Drawing.Size(56, 17);
            this.lnl.TabIndex = 43;
            this.lnl.Text = "病人姓名";
            // 
            // dgvPat
            // 
            this.dgvPat.AllowUserToAddRows = false;
            this.dgvPat.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPat.Location = new System.Drawing.Point(0, 63);
            this.dgvPat.Name = "dgvPat";
            this.dgvPat.ReadOnly = true;
            this.dgvPat.RowTemplate.Height = 23;
            this.dgvPat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPat.Size = new System.Drawing.Size(872, 494);
            this.dgvPat.TabIndex = 1;
            // 
            // FrmPations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPat);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPations";
            this.Size = new System.Drawing.Size(872, 557);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPat;
        private System.Windows.Forms.ComboBox cmbPatName;
        private System.Windows.Forms.Label lnl;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
    }
}
