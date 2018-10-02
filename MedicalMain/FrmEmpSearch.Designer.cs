namespace UI
{
    partial class FrmEmpSearch
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改员工信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除员工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 69);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelete.Location = new System.Drawing.Point(483, 21);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 31);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除员工";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnChange.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnChange.Location = new System.Drawing.Point(401, 21);
            this.btnChange.Margin = new System.Windows.Forms.Padding(0);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(72, 31);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "修改员工";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCreate.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCreate.Location = new System.Drawing.Point(317, 21);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 31);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "创建员工";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSearch.Location = new System.Drawing.Point(235, 21);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 31);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查  询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "关键字";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtKey.Location = new System.Drawing.Point(75, 25);
            this.txtKey.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(148, 23);
            this.txtKey.TabIndex = 0;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployee.Location = new System.Drawing.Point(0, 69);
            this.dgvEmployee.Margin = new System.Windows.Forms.Padding(0);
            this.dgvEmployee.MultiSelect = false;
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ReadOnly = true;
            this.dgvEmployee.RowHeadersWidth = 10;
            this.dgvEmployee.RowTemplate.Height = 23;
            this.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.Size = new System.Drawing.Size(1192, 571);
            this.dgvEmployee.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改员工信息ToolStripMenuItem,
            this.删除员工ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // 修改员工信息ToolStripMenuItem
            // 
            this.修改员工信息ToolStripMenuItem.Name = "修改员工信息ToolStripMenuItem";
            this.修改员工信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改员工信息ToolStripMenuItem.Text = "修改员工";
            this.修改员工信息ToolStripMenuItem.Click += new System.EventHandler(this.修改员工信息ToolStripMenuItem_Click);
            // 
            // 删除员工ToolStripMenuItem
            // 
            this.删除员工ToolStripMenuItem.Name = "删除员工ToolStripMenuItem";
            this.删除员工ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除员工ToolStripMenuItem.Text = "删除员工";
            this.删除员工ToolStripMenuItem.Click += new System.EventHandler(this.删除员工ToolStripMenuItem_Click);
            // 
            // FrmEmpSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.Name = "FrmEmpSearch";
            this.Size = new System.Drawing.Size(1192, 640);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改员工信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除员工ToolStripMenuItem;
        private System.Windows.Forms.Button btnDelete;
    }
}
