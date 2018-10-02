namespace UI
{
    partial class FrmConfig
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
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.cmsMenues = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加到治疗单Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.取消治疗单打印Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddStyle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.txtType = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.cmsMenues.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbStyle
            // 
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(53, 23);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(125, 27);
            this.cmbStyle.TabIndex = 0;
            this.cmbStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "类别";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(53, 75);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(125, 24);
            this.txtContent.TabIndex = 2;
            this.txtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContent_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAdd.Location = new System.Drawing.Point(184, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 28);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新 增";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDelete.Location = new System.Drawing.Point(321, 73);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 28);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删 除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.AllowUserToDeleteRows = false;
            this.dgvShow.BackgroundColor = System.Drawing.Color.White;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.ContextMenuStrip = this.cmsMenues;
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvShow.Location = new System.Drawing.Point(0, 117);
            this.dgvShow.MultiSelect = false;
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.RowHeadersWidth = 11;
            this.dgvShow.RowTemplate.Height = 23;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(440, 340);
            this.dgvShow.TabIndex = 5;
            this.dgvShow.Click += new System.EventHandler(this.dgvShow_Click);
            // 
            // cmsMenues
            // 
            this.cmsMenues.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加到治疗单Tsm,
            this.取消治疗单打印Tsm});
            this.cmsMenues.Name = "cmsMenues";
            this.cmsMenues.Size = new System.Drawing.Size(161, 48);
            // 
            // 添加到治疗单Tsm
            // 
            this.添加到治疗单Tsm.Name = "添加到治疗单Tsm";
            this.添加到治疗单Tsm.Size = new System.Drawing.Size(160, 22);
            this.添加到治疗单Tsm.Text = "添加治疗单打印";
            this.添加到治疗单Tsm.Click += new System.EventHandler(this.添加到治疗单Tsm_Click);
            // 
            // 取消治疗单打印Tsm
            // 
            this.取消治疗单打印Tsm.Name = "取消治疗单打印Tsm";
            this.取消治疗单打印Tsm.Size = new System.Drawing.Size(160, 22);
            this.取消治疗单打印Tsm.Text = "取消治疗单打印";
            this.取消治疗单打印Tsm.Click += new System.EventHandler(this.取消治疗单打印Tsm_Click);
            // 
            // btnAddStyle
            // 
            this.btnAddStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddStyle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnAddStyle.Location = new System.Drawing.Point(184, 23);
            this.btnAddStyle.Name = "btnAddStyle";
            this.btnAddStyle.Size = new System.Drawing.Size(67, 27);
            this.btnAddStyle.TabIndex = 6;
            this.btnAddStyle.Text = "新增类别";
            this.btnAddStyle.UseVisualStyleBackColor = false;
            this.btnAddStyle.Click += new System.EventHandler(this.btnAddStyle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "输入";
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnModify.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnModify.Location = new System.Drawing.Point(257, 73);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(58, 28);
            this.btnModify.TabIndex = 9;
            this.btnModify.Text = "修 改";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(257, 24);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(122, 24);
            this.txtType.TabIndex = 10;
            this.txtType.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnClose.Location = new System.Drawing.Point(384, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 28);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "取 消";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(440, 457);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddStyle);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStyle);
            this.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "要素添加";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.cmsMenues.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.Button btnAddStyle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ContextMenuStrip cmsMenues;
        private System.Windows.Forms.ToolStripMenuItem 添加到治疗单Tsm;
        private System.Windows.Forms.ToolStripMenuItem 取消治疗单打印Tsm;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnClose;
    }
}