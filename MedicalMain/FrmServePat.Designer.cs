namespace UI
{
    partial class FrmServePat
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPayCheck = new System.Windows.Forms.TextBox();
            this.btnPrintCheck = new System.Windows.Forms.Button();
            this.cmtPrint = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打印处方ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印治疗单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddCheck = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbExamination = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddMed = new System.Windows.Forms.Button();
            this.btnMemary = new System.Windows.Forms.Button();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPlanSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUnites = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.cmbMedicines = new System.Windows.Forms.ComboBox();
            this.txtSingular = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDayCnt = new System.Windows.Forms.TextBox();
            this.txtSumUse = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbUseWay = new System.Windows.Forms.ComboBox();
            this.cmbEachTimes = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPatSearch = new System.Windows.Forms.Button();
            this.lnl = new System.Windows.Forms.Label();
            this.txtPastHistory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.btnPlan = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSumPrice = new System.Windows.Forms.TextBox();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.cmsMenues = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.粘贴方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除药品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocumentUK = new System.Drawing.Printing.PrintDocument();
            this.printDocumentCH = new System.Drawing.Printing.PrintDocument();
            this.printDocumentInject = new System.Drawing.Printing.PrintDocument();
            this.printDocumentExamination = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cmtPrint.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.cmsMenues.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 329);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPayCheck);
            this.groupBox3.Controls.Add(this.btnPrintCheck);
            this.groupBox3.Controls.Add(this.btnAddCheck);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.cmbExamination);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(984, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 126);
            this.groupBox3.TabIndex = 70;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检查信息";
            // 
            // txtPayCheck
            // 
            this.txtPayCheck.Location = new System.Drawing.Point(179, 34);
            this.txtPayCheck.Name = "txtPayCheck";
            this.txtPayCheck.Size = new System.Drawing.Size(55, 26);
            this.txtPayCheck.TabIndex = 70;
            this.txtPayCheck.Text = "0.00";
            // 
            // btnPrintCheck
            // 
            this.btnPrintCheck.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrintCheck.ContextMenuStrip = this.cmtPrint;
            this.btnPrintCheck.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnPrintCheck.Location = new System.Drawing.Point(160, 81);
            this.btnPrintCheck.Name = "btnPrintCheck";
            this.btnPrintCheck.Size = new System.Drawing.Size(74, 35);
            this.btnPrintCheck.TabIndex = 69;
            this.btnPrintCheck.Text = "打印检查";
            this.btnPrintCheck.UseVisualStyleBackColor = false;
            this.btnPrintCheck.Click += new System.EventHandler(this.btnPrintCheck_Click);
            // 
            // cmtPrint
            // 
            this.cmtPrint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmtPrint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印处方ToolStripMenuItem,
            this.打印治疗单ToolStripMenuItem});
            this.cmtPrint.Name = "contextMenuStrip2";
            this.cmtPrint.Size = new System.Drawing.Size(161, 48);
            // 
            // 打印处方ToolStripMenuItem
            // 
            this.打印处方ToolStripMenuItem.Name = "打印处方ToolStripMenuItem";
            this.打印处方ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.打印处方ToolStripMenuItem.Text = "打印处方";
            this.打印处方ToolStripMenuItem.Click += new System.EventHandler(this.打印处方ToolStripMenuItem_Click);
            // 
            // 打印治疗单ToolStripMenuItem
            // 
            this.打印治疗单ToolStripMenuItem.Name = "打印治疗单ToolStripMenuItem";
            this.打印治疗单ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.打印治疗单ToolStripMenuItem.Text = "打印注射治疗单";
            this.打印治疗单ToolStripMenuItem.Click += new System.EventHandler(this.打印治疗单ToolStripMenuItem_Click);
            // 
            // btnAddCheck
            // 
            this.btnAddCheck.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddCheck.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnAddCheck.Location = new System.Drawing.Point(70, 81);
            this.btnAddCheck.Name = "btnAddCheck";
            this.btnAddCheck.Size = new System.Drawing.Size(77, 35);
            this.btnAddCheck.TabIndex = 68;
            this.btnAddCheck.Text = "添加检查";
            this.btnAddCheck.UseVisualStyleBackColor = false;
            this.btnAddCheck.Click += new System.EventHandler(this.btnAddCheck_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label19.Location = new System.Drawing.Point(6, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 19);
            this.label19.TabIndex = 66;
            this.label19.Text = "辅助检查";
            // 
            // cmbExamination
            // 
            this.cmbExamination.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbExamination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExamination.FormattingEnabled = true;
            this.cmbExamination.Location = new System.Drawing.Point(72, 33);
            this.cmbExamination.Name = "cmbExamination";
            this.cmbExamination.Size = new System.Drawing.Size(103, 28);
            this.cmbExamination.TabIndex = 67;
            this.cmbExamination.SelectedIndexChanged += new System.EventHandler(this.cmbExamination_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnAddMed);
            this.groupBox2.Controls.Add(this.btnMemary);
            this.groupBox2.Controls.Add(this.cmbStyle);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnPlanSearch);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtUnites);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.txtUnit);
            this.groupBox2.Controls.Add(this.cmbMedicines);
            this.groupBox2.Controls.Add(this.txtSingular);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDayCnt);
            this.groupBox2.Controls.Add(this.txtSumUse);
            this.groupBox2.Controls.Add(this.txtStock);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cmbUseWay);
            this.groupBox2.Controls.Add(this.cmbEachTimes);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 126);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "药品信息";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label8.Location = new System.Drawing.Point(27, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 19);
            this.label8.TabIndex = 32;
            this.label8.Text = "药品类别";
            // 
            // btnAddMed
            // 
            this.btnAddMed.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddMed.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnAddMed.Location = new System.Drawing.Point(802, 81);
            this.btnAddMed.Name = "btnAddMed";
            this.btnAddMed.Size = new System.Drawing.Size(77, 35);
            this.btnAddMed.TabIndex = 9;
            this.btnAddMed.Text = "添加药品";
            this.btnAddMed.UseVisualStyleBackColor = false;
            this.btnAddMed.Click += new System.EventHandler(this.btnAddMed_Click);
            this.btnAddMed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAddMed_KeyDown);
            // 
            // btnMemary
            // 
            this.btnMemary.BackColor = System.Drawing.Color.LightGray;
            this.btnMemary.Location = new System.Drawing.Point(708, 32);
            this.btnMemary.Name = "btnMemary";
            this.btnMemary.Size = new System.Drawing.Size(77, 30);
            this.btnMemary.TabIndex = 65;
            this.btnMemary.Text = "历史记录";
            this.btnMemary.UseVisualStyleBackColor = false;
            this.btnMemary.Click += new System.EventHandler(this.btnMemary_Click);
            // 
            // cmbStyle
            // 
            this.cmbStyle.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(94, 33);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(146, 28);
            this.cmbStyle.TabIndex = 33;
            this.cmbStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            this.cmbStyle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStyle_KeyDown);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.ContextMenuStrip = this.cmtPrint;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnPrint.Location = new System.Drawing.Point(896, 81);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 35);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "打印处方";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPrint_MouseClick);
            // 
            // btnPlanSearch
            // 
            this.btnPlanSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnPlanSearch.Location = new System.Drawing.Point(802, 32);
            this.btnPlanSearch.Name = "btnPlanSearch";
            this.btnPlanSearch.Size = new System.Drawing.Size(77, 30);
            this.btnPlanSearch.TabIndex = 64;
            this.btnPlanSearch.Text = "查看方案";
            this.btnPlanSearch.UseVisualStyleBackColor = false;
            this.btnPlanSearch.Click += new System.EventHandler(this.btnPlanSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label9.Location = new System.Drawing.Point(27, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 34;
            this.label9.Text = "药品名称";
            // 
            // txtUnites
            // 
            this.txtUnites.Location = new System.Drawing.Point(761, 85);
            this.txtUnites.Name = "txtUnites";
            this.txtUnites.Size = new System.Drawing.Size(30, 26);
            this.txtUnites.TabIndex = 63;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(603, 34);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(81, 26);
            this.txtPrice.TabIndex = 15;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(513, 85);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(30, 26);
            this.txtUnit.TabIndex = 62;
            // 
            // cmbMedicines
            // 
            this.cmbMedicines.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbMedicines.FormattingEnabled = true;
            this.cmbMedicines.Location = new System.Drawing.Point(94, 84);
            this.cmbMedicines.Name = "cmbMedicines";
            this.cmbMedicines.Size = new System.Drawing.Size(146, 28);
            this.cmbMedicines.TabIndex = 35;
            this.cmbMedicines.SelectedValueChanged += new System.EventHandler(this.cmbMedicines_SelectedValueChanged);
            this.cmbMedicines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMedicines_KeyDown);
            // 
            // txtSingular
            // 
            this.txtSingular.Location = new System.Drawing.Point(463, 85);
            this.txtSingular.Name = "txtSingular";
            this.txtSingular.Size = new System.Drawing.Size(53, 26);
            this.txtSingular.TabIndex = 61;
            this.txtSingular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSingular_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label3.Location = new System.Drawing.Point(562, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "单价";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label4.Location = new System.Drawing.Point(422, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 19);
            this.label4.TabIndex = 60;
            this.label4.Text = "单量";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label10.Location = new System.Drawing.Point(422, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 19);
            this.label10.TabIndex = 40;
            this.label10.Text = "库存";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label16.Location = new System.Drawing.Point(554, 89);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 19);
            this.label16.TabIndex = 58;
            this.label16.Text = "用";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label12.Location = new System.Drawing.Point(651, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 19);
            this.label12.TabIndex = 43;
            this.label12.Text = "总量";
            // 
            // txtDayCnt
            // 
            this.txtDayCnt.Location = new System.Drawing.Point(578, 85);
            this.txtDayCnt.Name = "txtDayCnt";
            this.txtDayCnt.Size = new System.Drawing.Size(42, 26);
            this.txtDayCnt.TabIndex = 57;
            this.txtDayCnt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDayCnt_KeyDown);
            // 
            // txtSumUse
            // 
            this.txtSumUse.Location = new System.Drawing.Point(689, 85);
            this.txtSumUse.Name = "txtSumUse";
            this.txtSumUse.Size = new System.Drawing.Size(76, 26);
            this.txtSumUse.TabIndex = 50;
            this.txtSumUse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSumUse_KeyDown);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(463, 34);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(81, 26);
            this.txtStock.TabIndex = 56;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label13.Location = new System.Drawing.Point(254, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 19);
            this.label13.TabIndex = 51;
            this.label13.Text = "用  法";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label15.Location = new System.Drawing.Point(617, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 19);
            this.label15.TabIndex = 55;
            this.label15.Text = "天";
            // 
            // cmbUseWay
            // 
            this.cmbUseWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUseWay.FormattingEnabled = true;
            this.cmbUseWay.Location = new System.Drawing.Point(303, 33);
            this.cmbUseWay.Name = "cmbUseWay";
            this.cmbUseWay.Size = new System.Drawing.Size(97, 28);
            this.cmbUseWay.TabIndex = 52;
            this.cmbUseWay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUseWay_KeyDown);
            // 
            // cmbEachTimes
            // 
            this.cmbEachTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEachTimes.FormattingEnabled = true;
            this.cmbEachTimes.Location = new System.Drawing.Point(303, 84);
            this.cmbEachTimes.Name = "cmbEachTimes";
            this.cmbEachTimes.Size = new System.Drawing.Size(97, 28);
            this.cmbEachTimes.TabIndex = 54;
            this.cmbEachTimes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEachTimes_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label14.Location = new System.Drawing.Point(254, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 19);
            this.label14.TabIndex = 53;
            this.label14.Text = "频  率";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnPatSearch);
            this.groupBox1.Controls.Add(this.lnl);
            this.groupBox1.Controls.Add(this.txtPastHistory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbGender);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDiagnosis);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1224, 203);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病人信息";
            // 
            // btnPatSearch
            // 
            this.btnPatSearch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPatSearch.Location = new System.Drawing.Point(254, 32);
            this.btnPatSearch.Name = "btnPatSearch";
            this.btnPatSearch.Size = new System.Drawing.Size(43, 25);
            this.btnPatSearch.TabIndex = 68;
            this.btnPatSearch.Text = "查找";
            this.btnPatSearch.UseVisualStyleBackColor = true;
            this.btnPatSearch.Click += new System.EventHandler(this.btnPatSearch_Click);
            // 
            // lnl
            // 
            this.lnl.AutoSize = true;
            this.lnl.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lnl.Location = new System.Drawing.Point(48, 35);
            this.lnl.Name = "lnl";
            this.lnl.Size = new System.Drawing.Size(61, 19);
            this.lnl.TabIndex = 26;
            this.lnl.Text = "病人姓名";
            // 
            // txtPastHistory
            // 
            this.txtPastHistory.Location = new System.Drawing.Point(356, 132);
            this.txtPastHistory.Multiline = true;
            this.txtPastHistory.Name = "txtPastHistory";
            this.txtPastHistory.Size = new System.Drawing.Size(330, 54);
            this.txtPastHistory.TabIndex = 67;
            this.txtPastHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPastHistoryKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label1.Location = new System.Drawing.Point(471, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "年  龄";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label18.Location = new System.Drawing.Point(305, 132);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 19);
            this.label18.TabIndex = 66;
            this.label18.Text = "现病史";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(525, 31);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(130, 26);
            this.txtAge.TabIndex = 8;
            this.txtAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAge_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label2.Location = new System.Drawing.Point(48, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "联系方式";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(119, 78);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(129, 26);
            this.txtPhone.TabIndex = 13;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label6.Location = new System.Drawing.Point(305, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 19);
            this.label6.TabIndex = 28;
            this.label6.Text = "性  别";
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cmbGender.Location = new System.Drawing.Point(356, 30);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(86, 28);
            this.cmbGender.TabIndex = 29;
            this.cmbGender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGender_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label7.Location = new System.Drawing.Point(305, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "住  址";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(356, 78);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(326, 26);
            this.txtAddress.TabIndex = 31;
            this.txtAddress.Text = "重庆市铜梁区平滩镇";
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label5.Location = new System.Drawing.Point(48, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "临床诊断";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(119, 132);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(129, 55);
            this.txtDiagnosis.TabIndex = 37;
            this.txtDiagnosis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiagnosis_KeyDown);
            // 
            // txtName
            // 
            this.txtName.FormattingEnabled = true;
            this.txtName.Location = new System.Drawing.Point(119, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(129, 28);
            this.txtName.TabIndex = 42;
            this.txtName.SelectedIndexChanged += new System.EventHandler(this.txtName_SelectedIndexChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtName.MouseEnter += new System.EventHandler(this.txtName_MouseEnter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(288, -219);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(108, 26);
            this.textBox2.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(244, -216);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "姓名：";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.cmbPlan);
            this.panel2.Controls.Add(this.btnPlan);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtSumPrice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 584);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1224, 76);
            this.panel2.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(218, 18);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(64, 30);
            this.btnUpdate.TabIndex = 36;
            this.btnUpdate.Text = "刷新";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label17.Location = new System.Drawing.Point(319, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 17);
            this.label17.TabIndex = 35;
            this.label17.Text = "方案类别";
            // 
            // cmbPlan
            // 
            this.cmbPlan.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(380, 19);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(129, 28);
            this.cmbPlan.TabIndex = 34;
            // 
            // btnPlan
            // 
            this.btnPlan.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPlan.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnPlan.Location = new System.Drawing.Point(522, 13);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Size = new System.Drawing.Size(88, 40);
            this.btnPlan.TabIndex = 20;
            this.btnPlan.Text = "保存方案";
            this.btnPlan.UseVisualStyleBackColor = false;
            this.btnPlan.Click += new System.EventHandler(this.btnPlan_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnSave.Location = new System.Drawing.Point(622, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存信息";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label11.Location = new System.Drawing.Point(32, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "门诊金额";
            // 
            // txtSumPrice
            // 
            this.txtSumPrice.Location = new System.Drawing.Point(94, 20);
            this.txtSumPrice.Name = "txtSumPrice";
            this.txtSumPrice.Size = new System.Drawing.Size(117, 26);
            this.txtSumPrice.TabIndex = 17;
            this.txtSumPrice.Text = "0.00";
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.ContextMenuStrip = this.cmsMenues;
            this.dgvMedicines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicines.Location = new System.Drawing.Point(0, 329);
            this.dgvMedicines.MultiSelect = false;
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.RowHeadersWidth = 20;
            this.dgvMedicines.RowTemplate.Height = 23;
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMedicines.Size = new System.Drawing.Size(1224, 255);
            this.dgvMedicines.TabIndex = 2;
            this.dgvMedicines.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicines_CellEndEdit);
            // 
            // cmsMenues
            // 
            this.cmsMenues.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmsMenues.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.粘贴方案ToolStripMenuItem,
            this.删除药品ToolStripMenuItem});
            this.cmsMenues.Name = "contextMenuStrip1";
            this.cmsMenues.Size = new System.Drawing.Size(149, 48);
            // 
            // 粘贴方案ToolStripMenuItem
            // 
            this.粘贴方案ToolStripMenuItem.Name = "粘贴方案ToolStripMenuItem";
            this.粘贴方案ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.粘贴方案ToolStripMenuItem.Text = "粘贴方案";
            this.粘贴方案ToolStripMenuItem.Click += new System.EventHandler(this.粘贴方案ToolStripMenuItem_Click);
            // 
            // 删除药品ToolStripMenuItem
            // 
            this.删除药品ToolStripMenuItem.Name = "删除药品ToolStripMenuItem";
            this.删除药品ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除药品ToolStripMenuItem.Text = "删除选中药品";
            this.删除药品ToolStripMenuItem.Click += new System.EventHandler(this.删除药品ToolStripMenuItem_Click);
            // 
            // printDocumentUK
            // 
            this.printDocumentUK.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentUK_PrintPage);
            // 
            // printDocumentCH
            // 
            this.printDocumentCH.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentCH_PrintPage);
            // 
            // printDocumentInject
            // 
            this.printDocumentInject.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentInject_PrintPage);
            // 
            // printDocumentExamination
            // 
            this.printDocumentExamination.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentOthers_PrintPage);
            // 
            // FrmServePat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmServePat";
            this.Size = new System.Drawing.Size(1224, 660);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.cmtPrint.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.cmsMenues.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAddMed;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lnl;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMedicines;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip cmsMenues;
        private System.Windows.Forms.ToolStripMenuItem 删除药品ToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSumPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox txtName;
        private System.Drawing.Printing.PrintDocument printDocumentUK;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSumUse;
        private System.Windows.Forms.TextBox txtUnites;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtSingular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDayCnt;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbEachTimes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbUseWay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPlan;
        private System.Drawing.Printing.PrintDocument printDocumentCH;
        private System.Drawing.Printing.PrintDocument printDocumentInject;
        private System.Windows.Forms.ContextMenuStrip cmtPrint;
        private System.Windows.Forms.ToolStripMenuItem 打印处方ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印治疗单ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Button btnPlanSearch;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolStripMenuItem 粘贴方案ToolStripMenuItem;
        private System.Windows.Forms.Button btnMemary;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPastHistory;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnPatSearch;
        private System.Drawing.Printing.PrintDocument printDocumentExamination;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbExamination;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPrintCheck;
        private System.Windows.Forms.Button btnAddCheck;
        private System.Windows.Forms.TextBox txtPayCheck;
    }
}
