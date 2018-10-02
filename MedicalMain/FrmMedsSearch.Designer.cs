namespace UI
{
    partial class FrmMedInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMedSum = new System.Windows.Forms.Label();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeys = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvMedicine = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加药品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改药品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除药品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(0, 509);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 84);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "     单击右键，在弹出菜单中选择不同选择项进行类别的增加、删除、修改。";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMedSum);
            this.panel1.Controls.Add(this.cmbStyle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKeys);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 69);
            this.panel1.TabIndex = 2;
            // 
            // lblMedSum
            // 
            this.lblMedSum.AutoSize = true;
            this.lblMedSum.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblMedSum.Location = new System.Drawing.Point(733, 47);
            this.lblMedSum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMedSum.Name = "lblMedSum";
            this.lblMedSum.Size = new System.Drawing.Size(74, 19);
            this.lblMedSum.TabIndex = 8;
            this.lblMedSum.Text = "药品数量：";
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(79, 18);
            this.cmbStyle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(113, 28);
            this.cmbStyle.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label2.Location = new System.Drawing.Point(14, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "药品类别";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnSearch.Location = new System.Drawing.Point(387, 17);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 31);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查 询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeys
            // 
            this.txtKeys.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeys.Location = new System.Drawing.Point(267, 19);
            this.txtKeys.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtKeys.Name = "txtKeys";
            this.txtKeys.Size = new System.Drawing.Size(99, 26);
            this.txtKeys.TabIndex = 4;
            this.txtKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeys_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(202, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "药品搜索";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnAdd.Location = new System.Drawing.Point(471, 17);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(78, 31);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "库存增加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvMedicine
            // 
            this.dgvMedicine.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvMedicine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedicine.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicine.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicine.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvMedicine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicine.EnableHeadersVisualStyles = false;
            this.dgvMedicine.Location = new System.Drawing.Point(0, 69);
            this.dgvMedicine.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvMedicine.MultiSelect = false;
            this.dgvMedicine.Name = "dgvMedicine";
            this.dgvMedicine.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicine.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMedicine.RowHeadersWidth = 10;
            this.dgvMedicine.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvMedicine.RowTemplate.Height = 23;
            this.dgvMedicine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicine.Size = new System.Drawing.Size(907, 524);
            this.dgvMedicine.TabIndex = 3;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加药品ToolStripMenuItem,
            this.修改药品ToolStripMenuItem,
            this.删除药品ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 70);
            // 
            // 增加药品ToolStripMenuItem
            // 
            this.增加药品ToolStripMenuItem.Name = "增加药品ToolStripMenuItem";
            this.增加药品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加药品ToolStripMenuItem.Text = "库存增加";
            this.增加药品ToolStripMenuItem.Click += new System.EventHandler(this.增加药品ToolStripMenuItem_Click);
            // 
            // 修改药品ToolStripMenuItem
            // 
            this.修改药品ToolStripMenuItem.Name = "修改药品ToolStripMenuItem";
            this.修改药品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改药品ToolStripMenuItem.Text = "修改药品";
            this.修改药品ToolStripMenuItem.Click += new System.EventHandler(this.修改药品ToolStripMenuItem_Click);
            // 
            // 删除药品ToolStripMenuItem
            // 
            this.删除药品ToolStripMenuItem.Name = "删除药品ToolStripMenuItem";
            this.删除药品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除药品ToolStripMenuItem.Text = "删除药品";
            this.删除药品ToolStripMenuItem.Click += new System.EventHandler(this.删除药品ToolStripMenuItem_Click);
            // 
            // FrmMedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMedicine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMedInfo";
            this.Size = new System.Drawing.Size(907, 593);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMedicine;
        private System.Windows.Forms.TextBox txtKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 增加药品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改药品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除药品ToolStripMenuItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMedSum;
    }
}
