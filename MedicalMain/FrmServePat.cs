using BLL;
using DAL;
using MedicalManage.Temple;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MedicalManage
{
    public partial class FrmServePat : UserControl
    {
        private decimal _allMedBid = Decimal.Zero;//总成本
        private decimal _oneMedBid = Decimal.Zero;//单个成本
        private DataTable _dtPat = new DataTable();//病人门诊数据
        private string _medBarCode = string.Empty;
        private string _medStandard = string.Empty;
        private string _medStyleName = string.Empty;
        public FrmServePat()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            DataTable dtStyle = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.药品类别.SafeDbValue<int>()).Tables[0];
            DataRow drRow = dtStyle.NewRow();
            drRow["SignID"] = @"-1";
            drRow["Name"] = @"全部";
            dtStyle.Rows.InsertAt(drRow, 0);
            cmbStyle.ValueMember = @"SignID";
            cmbStyle.DisplayMember = @"Name";
            cmbStyle.DataSource = dtStyle;

            DataTable dtUseWay = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.用法.SafeDbValue<int>()).Tables[0];
            cmbUseWay.ValueMember = @"SignID";
            cmbUseWay.DisplayMember = @"Name";
            cmbUseWay.DataSource = dtUseWay;
            cmbUseWay.SelectedIndex = -1;

            DataTable dtEachTimes = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.频率.SafeDbValue<int>()).Tables[0];
            cmbEachTimes.ValueMember = @"SignID";
            cmbEachTimes.DisplayMember = @"Name";
            cmbEachTimes.DataSource = dtEachTimes;
            cmbEachTimes.SelectedIndex = -1;

            DataTable dtPlan = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.方案类别.SafeDbValue<int>()).Tables[0];
            cmbPlan.ValueMember = @"SignID";
            cmbPlan.DisplayMember = @"Name";
            cmbPlan.DataSource = dtPlan;
            cmbPlan.SelectedIndex = -1;

            DataTable dtExamination = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.辅助检查.SafeDbValue<int>()).Tables[0];
            cmbExamination.ValueMember = @"SignID";
            cmbExamination.DisplayMember = @"Name";
            cmbExamination.DataSource = dtExamination;

            dgvMedicines.Columns.AddRange(
               new DataGridViewTextBoxColumn { Name = @"SpliteNum", DataPropertyName = @"SpliteNum", HeaderText = @"分组", Width = 60, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"MedID", DataPropertyName = @"MedID", HeaderText = @"药品编号", Width = 100, ReadOnly = true },
               new DataGridViewTextBoxColumn { Name = @"MedName", DataPropertyName = @"MedName", HeaderText = @"药品名称", Width = 100, ReadOnly = true },
               new DataGridViewTextBoxColumn { Name = @"UseAge", DataPropertyName = @"UseAge", HeaderText = @"用法", Width = 80, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"Frequency", DataPropertyName = @"Frequency", HeaderText = @"频率", Width = 80, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"OneTimeUse", DataPropertyName = @"OneTimeUse", HeaderText = @"单量", Width = 70, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"Days", DataPropertyName = @"Days", HeaderText = @"天数", Width = 70, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"TimesUse", DataPropertyName = @"TimesUse", HeaderText = @"总量", Width = 70, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"MedUnitPrice", DataPropertyName = @"MedUnitPrice", HeaderText = @"单价", Width = 80, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"MedPrice", DataPropertyName = @"MedPrice", HeaderText = @"总价", Width = 80, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"MedUnit", DataPropertyName = @"MedUnit", HeaderText = @"计量单位", Width = 100, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"MedStyle", DataPropertyName = @"MedStyle", HeaderText = @"类别", Width = 100, ReadOnly = true },
               new DataGridViewTextBoxColumn { Name = @"MedStandard", DataPropertyName = @"MedStandard", HeaderText = @"药品规格", Width = 100, ReadOnly = true },
               new DataGridViewTextBoxColumn { Name = @"MedBarCode", DataPropertyName = @"MedBarCode", HeaderText = @"药品条码", Width = 100, ReadOnly = true },
               new DataGridViewTextBoxColumn { Name = @"Remarks", DataPropertyName = @"Remarks", HeaderText = @"备注", Width = 100, ReadOnly = false },
               new DataGridViewTextBoxColumn { Name = @"MedBid", DataPropertyName = @"MedBid", HeaderText = @"成本", Width = 100, ReadOnly = true,Visible = false}
          );
        }

        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMedicines.DataSource = null;
            txtStock.Text = txtSingular.Text = txtPrice.Text = cmbMedicines.Text = txtPrice.Text = txtDayCnt.Text
                  = txtSumUse.Text = txtUnit.Text = txtUnites.Text = cmbEachTimes.Text = cmbUseWay.Text = string.Empty;
            if (cmbStyle.SelectedValue == null)
            {
                return;
            }
            string sSql = string.Empty;
            if (!cmbStyle.Text.Equals(@"全部"))
            {
                sSql = $@" and MedTypeID = '{cmbStyle.SelectedValue}'";
            }
            DataTable dtMedicines = ErpServer.GetMedInfo(sSql, CommonInfo.ConfigStyle.药品类别.ToString()).Tables[0];
            cmbMedicines.ValueMember = @"MedID";
            cmbMedicines.DisplayMember = @"MedName";
            cmbMedicines.DataSource = dtMedicines;
        }

        private DataTable _dtNewMed = null;
        private void btnAddMed_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStock.Text == string.Empty || txtSingular.Text == string.Empty ||
                    txtPrice.Text == string.Empty || cmbMedicines.Text == string.Empty || txtPrice.Text == string.Empty ||
                    txtDayCnt.Text == string.Empty || txtSumUse.Text == string.Empty || txtUnit.Text == string.Empty || txtUnites.Text == string.Empty)
                {
                    MessageBox.Show(@"请完善需要添加的药品信息！");
                    return;
                }
                if (_dtNewMed == null)
                {
                    _dtNewMed = new DataTable();
                    _dtNewMed.Columns.Add("SpliteNum");//分组
                    _dtNewMed.Columns.Add("MedID");
                    _dtNewMed.Columns.Add("MedName");
                    _dtNewMed.Columns.Add("MedUnitPrice"); //单价
                    _dtNewMed.Columns.Add("MedPrice"); //药品总价
                    _dtNewMed.Columns.Add("UseAge"); //用法
                    _dtNewMed.Columns.Add("Frequency"); //频率
                    _dtNewMed.Columns.Add("OneTimeUse"); //单量
                    _dtNewMed.Columns.Add("Days"); //天数
                    _dtNewMed.Columns.Add("TimesUse"); //总量
                    _dtNewMed.Columns.Add("MedUnit"); //计量单位
                    _dtNewMed.Columns.Add("MedBarCode"); //条码
                    _dtNewMed.Columns.Add("MedStandard"); //规格
                    _dtNewMed.Columns.Add("MedStyle"); //类别
                    _dtNewMed.Columns.Add("Remarks"); //其他备注
                    _dtNewMed.Columns.Add("MedBid"); //成本
                }
                DataRow drNewRow = _dtNewMed.NewRow();
                _dtNewMed.Rows.Add(drNewRow);
                drNewRow["SpliteNum"] = @"0";
                drNewRow["MedID"] = _medValues;
                drNewRow["MedName"] = cmbMedicines.Text.Trim();
                drNewRow["MedUnitPrice"] = txtPrice.Text.Trim();
                drNewRow["UseAge"] = cmbUseWay.Text.Trim();
                drNewRow["MedPrice"] = Convert.ToDecimal(Convert.ToDecimal(txtPrice.Text.Trim()) * Convert.ToDecimal(txtSumUse.Text.Trim()));
                drNewRow["Frequency"] = cmbEachTimes.Text.Trim();
                drNewRow["OneTimeUse"] = txtSingular.Text.Trim();
                drNewRow["Days"] = txtDayCnt.Text.Trim();
                drNewRow["TimesUse"] = txtSumUse.Text.Trim();
                drNewRow["MedUnit"] = txtUnit.Text.Trim();
                drNewRow["MedBarCode"] = _medBarCode;
                drNewRow["MedStandard"] = _medStandard;
                drNewRow["MedStyle"] = _medStyleName;
                drNewRow["MedBid"] = _oneMedBid;
                dgvMedicines.AutoGenerateColumns = false;
                dgvMedicines.DataSource = _dtNewMed;
                txtSumPrice.Text = (Convert.ToDecimal(txtSumPrice.Text.Trim()) + Convert.ToDecimal(txtPrice.Text.Trim()) * Convert.ToDecimal(txtSumUse.Text.Trim())).ToString(CultureInfo.InvariantCulture);
                txtStock.Text = txtSingular.Text = txtPrice.Text = cmbMedicines.Text = txtPrice.Text = txtDayCnt.Text
                    = txtSumUse.Text = txtUnit.Text = txtUnites.Text = string.Empty;
                cmbMedicines.SelectedIndex = cmbEachTimes.SelectedIndex = cmbUseWay.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"输入有误，请核对药品基本信息是否输入正确！" + ex);
            }
        }

        private void 删除药品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow != null)
            {
                txtSumPrice.Text = (Convert.ToDecimal(txtSumPrice.Text.Trim()) -
                 dgvMedicines.CurrentRow.Cells["MedPrice"].Value.SafeDbValue<decimal>()).ToString(CultureInfo.InvariantCulture);
                dgvMedicines.Rows.RemoveAt(dgvMedicines.CurrentRow.Index);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show(@"输入病人信息！");
                    return;
                }
               
                if (dgvMedicines.Rows.Count == 0)
                {
                    MessageBox.Show(@"请添加药品后操作！");
                    return;
                }
                SavePatient();//保存病人信息

                //已添加药品信息
                List<List<string>> medList = new List<List<string>>();

                //已添加检查信息
                List<List<string>> CheckList = new List<List<string>>();

                _allMedBid = Decimal.Zero;
                for (int i = 0; i < dgvMedicines.Rows.Count; i++)
                {
                    if (dgvMedicines.Rows[i].Cells["MedStyle"].Value.ToString().Equals("辅助检查"))
                    {
                        List<string> check = new List<string>() {
                            dgvMedicines.Rows[i].Cells["MedID"].Value.ToString(),
                            dgvMedicines.Rows[i].Cells["MedName"].Value.ToString(),
                            dgvMedicines.Rows[i].Cells["MedPrice"].Value.ToString()
                        };
                        CheckList.Add(check);
                        continue;
                    }
                    var medId = dgvMedicines.Rows[i].Cells["MedID"].Value.ToString();
                    var medName = dgvMedicines.Rows[i].Cells["MedName"].Value.ToString();
                    var onePrice = dgvMedicines.Rows[i].Cells["MedUnitPrice"].Value.ToString();
                    var price = dgvMedicines.Rows[i].Cells["MedPrice"].Value.ToString();
                    var useAge = dgvMedicines.Rows[i].Cells["UseAge"].Value.ToString();
                    var eachTimes = dgvMedicines.Rows[i].Cells["Frequency"].Value.ToString();
                    var oneTimeUse = dgvMedicines.Rows[i].Cells["OneTimeUse"].Value.ToString();
                    var days = dgvMedicines.Rows[i].Cells["Days"].Value.ToString();
                    var timesUse = dgvMedicines.Rows[i].Cells["TimesUse"].Value.ToString();
                    var medBarCode = dgvMedicines.Rows[i].Cells["MedBarCode"].Value.ToString();
                    var spliteNum = dgvMedicines.Rows[i].Cells["SpliteNum"].Value == null ? string.Empty:dgvMedicines.Rows[i].Cells["SpliteNum"].Value.ToString();
                    _allMedBid +=  Convert.ToDecimal(dgvMedicines.Rows[i].Cells["MedBid"].Value)* Convert.ToDecimal(dgvMedicines.Rows[i].Cells["TimesUse"].Value);
                    string[] medStrings = { medId, medBarCode, medName, timesUse, onePrice, price, useAge, eachTimes, days, oneTimeUse, spliteNum };
                    List<string> medicine = new List<string>();
                    medicine.AddRange(medStrings);
                    medList.Add(medicine);
                }
                if (CheckList.Count > 0)
                {
                    ErpServer.SaveCheckInfo(CheckList, Information.CurrentUser.Id, txtAge.Text.Trim(), txtName.Text.Trim());
                }
                if (medList.Count > 0)
                {
                    if (ErpServer.SavePrescriptionInfo(medList, Information.CurrentUser.Id, txtAge.Text.Trim(), Convert.ToDecimal(txtSumPrice.Text.Trim()),
                        _allMedBid, txtDiagnosis.Text.Trim(), txtName.Text.Trim(), OperateType.门诊信息保存.ToString(), txtPastHistory.Text.Trim()))
                    {
                        MessageBox.Show(@"保存成功！");
                        txtName.Text =
                            txtAddress.Text =
                                txtAge.Text = txtDiagnosis.Text = txtPhone.Text = string.Empty;
                        txtSumPrice.Text = txtSumUse.Text = txtPrice.Text = txtStock.Text = txtSingular.Text = txtPayCheck.Text = @"0.00";
                        cmbMedicines.SelectedIndex = cmbExamination.SelectedIndex = -1;
                        while (dgvMedicines.Rows.Count > 0)
                        {
                            dgvMedicines.Rows.RemoveAt(0);
                        }
                        _dtNewMed = null;
                    }
                    else
                    {
                        MessageBox.Show(@"保存失败,请检查后重试！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"保存失败，重试后再试！" + ex);
            }
        }
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            Information.PatId = string.Empty;
            if (e.KeyCode == Keys.Enter)
            {
                _dtPat = ErpServer.GetPationes($@" and  PatName like '%{txtName.Text.Trim()}%'").Tables[0];
                txtName.DataSource = _dtPat;
                txtName.ValueMember = @"PatID";
                txtName.DisplayMember = @"PatName";
            }
            if (e.KeyCode == Keys.Space)
            {
                txtName.SelectionLength = 0;
                cmbGender.Focus();
            }
        }
        /// <summary>
        /// 保存病人信息
        /// </summary>
        private void SavePatient()
        {
            Patient patient = new Patient()
            {
                PatID = Information.PatId,
                PatName = txtName.Text.Trim(),
                Age = txtAge.Text.Trim(),
                Gender = cmbGender.Text.Trim(),
                TelPhone = txtPhone.Text.Trim(),
                Addresses = txtAddress.Text.Trim()
            };
            MedLog medLog = new MedLog
            {
                OperType = "病人信息保存",
                Notes = txtName.Text.Trim() + "  " + txtAge.Text.Trim() + "  " + cmbGender.Text.Trim() + "  " + txtPhone.Text.Trim() + "  " + txtAddress.Text.Trim(),
                OperateEmpID = Information.CurrentUser.Id
            };
            if (!BllPations.InsertPation(patient, medLog))
            {
                MessageBox.Show(@"信息有误，请核对病人信息！");
                return;
            }
        }
        private void txtName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] drRows = _dtPat.Select($@"PatName = '{txtName.Text.Trim()}'");
            if (drRows.Length == 0)
            {
                return;
            }
            DataTable dtTable = drRows.CopyToDataTable();
            cmbGender.Text = dtTable.Rows[0]["Gender"].ToString();
            txtAge.Text = dtTable.Rows[0]["Age"].ToString();
            txtPhone.Text = dtTable.Rows[0]["TelPhone"].ToString();
            txtAddress.Text = dtTable.Rows[0]["Addresses"].ToString();
        }

        private void printDocumentUK_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                DataTable dtSouce = dgvMedicines.DataSource as DataTable;
                float widthPaper = 520f;
                float heightPaper = 750f; // 总大小 13cm*18cm
                e.Graphics.DrawString(@"铜梁区熊测勇诊所", new Font("微软雅黑", 14), Brushes.Black, widthPaper / 3 + 120,
                    heightPaper * 0.1f / 20);
                e.Graphics.DrawString(@"姓名：" + txtName.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"性别：" + cmbGender.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper * 4 / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"年龄：" + txtAge.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper * 8 / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"住址：" + txtAddress.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper / 13 + 120, heightPaper * 1.6f / 20);
                e.Graphics.DrawString(@"日期：" + DateTime.Now.ToShortDateString(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper * 8 / 13 + 120, heightPaper * 1.6f / 20);
                e.Graphics.DrawString(@"临床诊断：" + txtDiagnosis.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper / 13 + 120, heightPaper * 2.2f / 20);
                e.Graphics.DrawLine(new Pen(Color.Black), widthPaper * 0.5f / 13 + 120, heightPaper * 2.7f / 20,
                    widthPaper * 12.5f / 13 + 120, heightPaper * 2.7f / 20);
                e.Graphics.DrawString(@"Rp.", new Font("微软雅黑", 12), Brushes.Black, widthPaper / 13 + 90, heightPaper * 2.7f / 20);

                float distanceY = heightPaper / 20;
                float beginX = widthPaper / 13 + 120;
                float beginY = heightPaper * 2.5f / 20;

                if (dtSouce != null)
                {
                    string treatments = ErpServer.GetTreatmentInfo().ToString();
                    string useAge = string.Empty;
                    if (!string.IsNullOrEmpty(treatments))
                    {
                        useAge = "'" + treatments.Substring(0, treatments.Length - 1).Replace(",", "','") + "'";
                    }
                    DataTable newDt =
                        dtSouce.Select($@"MedStyle <> '中药' and  UseAge not in({useAge})")
                            .CopyToDataTable();
                    beginY += distanceY / 2;
                    for (int i = 0; i < newDt.Rows.Count; i++)
                    {
                        e.Graphics.DrawString((i + 1) + ". " + newDt.Rows[i]["MedName"], new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX, beginY);
                        e.Graphics.DrawString(newDt.Rows[i]["MedStandard"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 4 / 13, beginY);
                        e.Graphics.DrawString(@"×  " + newDt.Rows[i]["TimesUse"] +@"  "+ newDt.Rows[i]["MedUnit"],
                            new Font("微软雅黑", 9.5f), Brushes.Black, beginX + widthPaper * 6.5f / 13, beginY);
                        beginY += distanceY / 2;
                        e.Graphics.DrawString(@"Sig：" + newDt.Rows[i]["OneTimeUse"]+ @"  " + newDt.Rows[i]["MedUnit"],
                            new Font("微软雅黑", 9.5f), Brushes.Black, beginX + widthPaper * 4 / 13, beginY);
                        e.Graphics.DrawString(newDt.Rows[i]["Frequency"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 8 / 13, beginY);
                        if (!newDt.Rows[i]["UseAge"].Equals(@"口服"))
                        {
                            e.Graphics.DrawString(newDt.Rows[i]["UseAge"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 10 / 13, beginY);
                        }
                        beginY += distanceY * 2 / 3;
                    }
                }
                dtSouce?.Dispose();
                e.Graphics.DrawLine(new Pen(Color.Black), widthPaper * 0.5f / 13 + 120, heightPaper * 18.4f / 20,
                    widthPaper * 12.5f / 13 + 120, heightPaper * 18.4f / 20);
                if (Information.CurrentUser.Name.Equals("熊测勇"))
                {
                    e.Graphics.DrawString(@"医师 ", new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 0.5f / 13 + 120, heightPaper * 18.5f / 20);
                    e.Graphics.DrawImage(Properties.Resources.XiongNameSmall, widthPaper * 0.5f / 13 + 155, heightPaper * 18.5f / 20);
                }
                else
                {
                    e.Graphics.DrawString(@"医师：" + Information.CurrentUser.Name, new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper / 13 + 120, heightPaper * 18.5f / 20);
                }
                e.Graphics.DrawString(@"药品金额：" + txtSumPrice.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper * 9 / 13 + 120, heightPaper * 18.5f / 20);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtSingular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtSingular.SelectionLength = 0;
                txtDayCnt.Focus();
            }
        }

        private void txtDayCnt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                try
                {
                    txtDayCnt.SelectionLength = 0;
                    txtSumUse.Text =
                        (Convert.ToDecimal(
                            cmbEachTimes.Text.Trim().Replace("Qd", "1")
                                .Replace("qd", "1")
                                .Replace("Bid", "2")
                                .Replace("bid", "2")
                                .Replace("Tid", "3")
                                .Replace("tid", "3")
                                .Replace("Qid", "4")
                                .Replace("qid", "4")
                                .Replace("Qod", "0.5")
                                .Replace("qod", "0.5")) * Convert.ToDecimal(txtSingular.Text.Trim()) *
                         Convert.ToInt32(txtDayCnt.Text.Trim())).ToString(CultureInfo.InvariantCulture);
                    btnAddMed.Focus();
                }
                catch
                {
                    MessageBox.Show(@"输入有误！");
                }
            }
        }

        private void txtSumUse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtSumUse.SelectionLength = 0;
                btnAddMed.Focus();
            }
        }

        private void btnAddMed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                btnAddMed_Click(null, null);
                cmbMedicines.Focus();
            }
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbPlan.Text.Trim()))
                {
                    MessageBox.Show(@"请选择方案类别");
                    return;
                }
                SavePatient();//保存病人信息

                //方案信息
                List<List<string>> medPlans = new List<List<string>>();
                for (int i = 0; i < dgvMedicines.Rows.Count; i++)
                {
                    if (dgvMedicines.Rows[i].Cells["MedStyle"].Value.ToString().Equals("辅助检查"))
                    {
                        continue;
                    }
                    List<string> rowInfo = new List<string>();
                    rowInfo.Add(dgvMedicines.Rows[i].Cells["MedID"].Value.ToString());
                    rowInfo.Add(Information.CurrentUser.Id);
                    rowInfo.Add(dgvMedicines.Rows[i].Cells["Useage"].Value.ToString());
                    rowInfo.Add(dgvMedicines.Rows[i].Cells["Frequency"].Value.ToString());
                    rowInfo.Add(dgvMedicines.Rows[i].Cells["OneTimeUse"].Value.ToString());
                    rowInfo.Add(dgvMedicines.Rows[i].Cells["Days"].Value.ToString());
                    rowInfo.Add(dgvMedicines.Rows[i].Cells["TimesUse"].Value.ToString());
                    rowInfo.Add(cmbPlan.Text.Trim());
                    rowInfo.Add(dgvMedicines.Rows[i].Cells["SpliteNum"].Value == null ? string.Empty: dgvMedicines.Rows[i].Cells["SpliteNum"].Value.ToString());
                    medPlans.Add(rowInfo);
                }
                if (ErpServer.InsertMedPlan(medPlans, txtName.Text.Trim(), txtAge.Text.Trim()))
                {
                    MessageBox.Show(@"保存方案成功！");
                }
                else
                {
                    MessageBox.Show(@"保存方案失败，请检查后重试！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"信息错误！" + ex);
            }
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtAge.Focus();
                txtAge.SelectionLength = 0;
            }
            if (e.KeyCode == Keys.D1)
            {
                cmbGender.SelectedIndex = 0;
            }
            if (e.KeyCode == Keys.D2)
            {
                cmbGender.SelectedIndex = 1;
            }
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtAge.SelectionLength = 0;
                txtPhone.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtAddress.SelectionLength = 0;
                txtDiagnosis.Focus();
            }
        }

        private void txtDiagnosis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtDiagnosis.SelectionLength = 0;
                txtPastHistory.Focus();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtPhone.SelectionLength = 0;
                txtAddress.Focus();
            }
        }

        private void printDocumentCH_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                DataTable dtSouce = dgvMedicines.DataSource as DataTable;
                float widthPaper = 520f;
                float heightPaper = 750f;// 总大小 13cm*18cm
                e.Graphics.DrawString(@"铜梁区熊测勇诊所", new Font("微软雅黑", 14), Brushes.Black, widthPaper / 3 + 120, heightPaper * 0.1f / 20);
                e.Graphics.DrawString(@"姓名：" + txtName.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"性别：" + cmbGender.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 4 / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"年龄：" + txtAge.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 8 / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"住址：" + txtAddress.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper / 13 + 120, heightPaper * 1.6f / 20);
                e.Graphics.DrawString(@"日期：" + DateTime.Now.ToShortDateString(), new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 8 / 13 + 120, heightPaper * 1.6f / 20);
                e.Graphics.DrawString(@"临床诊断：" + txtDiagnosis.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper / 13 + 120, heightPaper * 2.2f / 20);
                e.Graphics.DrawLine(new Pen(Color.Black), widthPaper * 0.5f / 13 + 120, heightPaper * 2.7f / 20, widthPaper * 12.5f / 13 + 120, heightPaper * 2.7f / 20);
                e.Graphics.DrawString(@"Rp.", new Font("微软雅黑", 12), Brushes.Black, widthPaper / 13 + 100, heightPaper * 2.7f / 20);

                float distanceY = heightPaper / 20;
                float beginX = widthPaper / 13 + 120;
                float beginY = heightPaper * 2.5f / 20;
                if (dtSouce != null)
                {
                    DataTable newDt = dtSouce.Select(@"MedStyle = '中药'").CopyToDataTable();
                    for (int i = 0; i < newDt.Rows.Count; i++)
                    {
                        if (i%3==0)
                        { 
                            beginY += distanceY;
                        }
                        e.Graphics.DrawString(newDt.Rows[i]["MedName"].ToString(), new Font("微软雅黑", 10.5f), Brushes.Black, beginX + widthPaper * 4 / 13 * (i % 3), beginY);
                        e.Graphics.DrawString(newDt.Rows[i]["TimesUse"]+newDt.Rows[i]["MedUnit"].ToString(), new Font("微软雅黑", 10.5f), Brushes.Black, beginX +widthPaper*1.5f / 13 + widthPaper * 4 / 13 * (i % 3), beginY);
                    }
                }
                e.Graphics.DrawLine(new Pen(Color.Black), widthPaper * 0.5f / 13 + 120, heightPaper * 18.4f / 20, widthPaper * 12.5f / 13 + 120, heightPaper * 18.4f / 20);
                if (Information.CurrentUser.Name.Equals("熊测勇"))
                {
                    e.Graphics.DrawString(@"医师 ", new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 0.5f / 13 + 120, heightPaper * 18.5f / 20);
                    e.Graphics.DrawImage(Properties.Resources.XiongNameSmall, widthPaper * 0.5f / 13 + 155, heightPaper * 18.5f / 20);
                }
                else
                {
                    e.Graphics.DrawString(@"医师：" + Information.CurrentUser.Name, new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper / 13 + 120, heightPaper * 18.5f / 20);
                }
                e.Graphics.DrawString(@"药品金额：" + txtSumPrice.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 6 / 13 + 120, heightPaper * 18.5f / 20);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 打印处方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSouce = dgvMedicines.DataSource as DataTable;
                string treatments = ErpServer.GetTreatmentInfo().ToString();
                string useAge = string.Empty;
                if (!string.IsNullOrEmpty(treatments))
                {
                    useAge = "'" + treatments.Substring(0, treatments.Length - 1).Replace(",", "','") + "'";
                }
                if (dtSouce != null && dtSouce.Select($@"MedStyle <> '中药'  and  UseAge not in({useAge})").Any())
                {
                    //西药
                    PrintPreviewDialog frmPreviewUk = new PrintPreviewDialog()
                    { Document = printDocumentUK };
                    frmPreviewUk.ShowDialog();
                }

                if (dtSouce != null && dtSouce.Select(@"MedStyle = '中药'").Any())
                {
                    //中药
                    PrintPreviewDialog frmPreviewCh = new PrintPreviewDialog()
                    { Document = printDocumentCH };
                    frmPreviewCh.ShowDialog();
                }
                dtSouce?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }

        private void 打印治疗单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSouce = dgvMedicines.DataSource as DataTable;
                string treatments = ErpServer.GetTreatmentInfo().ToString();
                string useAge = string.Empty;
                if (!string.IsNullOrEmpty(treatments))
                {
                    useAge = "'" + treatments.Substring(0, treatments.Length - 1).Replace(",", "','") + "'";
                }
                if (dtSouce != null && dtSouce.Select($@"UseAge in({useAge})").Any())
                {
                    PrintPreviewDialog frmPreviewDialog = new PrintPreviewDialog()
                    { Document = printDocumentInject };
                    frmPreviewDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show(@"没有需要打印的信息！");
                }
                dtSouce?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
        private void printDocumentInject_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                DataTable dtSouce = dgvMedicines.DataSource as DataTable;
                float widthPaper = 520f;
                float heightPaper = 750f;// 总大小 13cm*19cm  *40
                e.Graphics.DrawString(@"铜梁区熊测勇诊所", new Font("微软雅黑", 12), Brushes.Black, widthPaper / 3+120, 5);
                e.Graphics.DrawString(@"注射治疗单", new Font("微软雅黑", 10), Brushes.Black, widthPaper / 3 + 150, heightPaper * 0.8f / 20);
                e.Graphics.DrawString(@"姓名：" + txtName.Text.Trim(), new Font("微软雅黑", 10), Brushes.Black, widthPaper / 13 + 120, heightPaper * 1.5f / 20);
                e.Graphics.DrawString(@"性别：" + cmbGender.Text.Trim(), new Font("微软雅黑", 10), Brushes.Black, widthPaper * 4 / 13 + 120, heightPaper * 1.5f / 20);
                e.Graphics.DrawString(@"年龄：" + txtAge.Text.Trim(), new Font("微软雅黑", 10), Brushes.Black, widthPaper * 8 / 13 + 120, heightPaper * 1.5f / 20);
                e.Graphics.DrawLine(new Pen(Color.Black), widthPaper * 0.5f / 13 + 120, heightPaper * 2.2f / 20, widthPaper * 12.5f / 13 + 120, heightPaper * 2.2f / 20);

                float distanceY = heightPaper / 20;
                float beginX = widthPaper / 13 + 120;
                float beginY = heightPaper * 2 / 20;
                //分组，暂时最多5组
                if (dtSouce != null)
                {
                    string treatments = ErpServer.GetTreatmentInfo().ToString();
                    string useAge = string.Empty;
                    if (!string.IsNullOrEmpty(treatments))
                    {
                        useAge = "'" + treatments.Substring(0, treatments.Length - 1).Replace(",", "','") + "'";
                    }
                    DataTable dtNewSouce = dtSouce.Select($@"UseAge in({useAge})").CopyToDataTable();
                    DataTable newDt0 = null, newDt1 = null, newDt2 = null, newDt3 = null, newDt4 = null, newDt5 = null;
                    if (dtNewSouce.Select(@" SpliteNum is null or SpliteNum = 0").Any())
                    {
                        newDt0 = dtNewSouce.Select(@" SpliteNum is null or SpliteNum = 0").CopyToDataTable();
                    }
                    if (dtNewSouce.Select(@" SpliteNum = 1").Any())
                    {
                        newDt1 = dtNewSouce.Select(@" SpliteNum = 1").CopyToDataTable();
                    }
                    if (dtNewSouce.Select(@"SpliteNum = 2").Any())
                    {
                        newDt2 = dtNewSouce.Select(@"SpliteNum = 2").CopyToDataTable();
                    }
                    if (dtNewSouce.Select(@"SpliteNum = 3").Any())
                    {
                        newDt3 = dtNewSouce.Select(@" SpliteNum = 3").CopyToDataTable();
                    }
                    if (dtNewSouce.Select(@"SpliteNum = 4").Any())
                    {
                        newDt4 = dtNewSouce.Select(@"SpliteNum = 4").CopyToDataTable();
                    }
                    if (dtNewSouce.Select(@" SpliteNum = 5").Any())
                    {
                        newDt5 = dtNewSouce.Select(@" SpliteNum = 5").CopyToDataTable();
                    }

                    if (newDt0 != null)
                    {
                        beginY += distanceY/2;
                        for (int i = 0; i < newDt0.Rows.Count; i++)
                        {
                            e.Graphics.DrawString(newDt0.Rows[i]["MedName"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX, beginY);
                            e.Graphics.DrawString(newDt0.Rows[i]["MedStandard"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 4 / 13, beginY);
                            e.Graphics.DrawString(@"×  " + newDt0.Rows[i]["TimesUse"] + newDt0.Rows[i]["MedUnit"],
                                new Font("微软雅黑", 9.5f), Brushes.Black, beginX + widthPaper * 6 / 13, beginY);

                            e.Graphics.DrawString(newDt0.Rows[i]["Frequency"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 8.5f / 13, beginY);
                            e.Graphics.DrawString(newDt0.Rows[i]["UseAge"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 9.5f / 13, beginY);
                            if (!string.IsNullOrEmpty(newDt0.Rows[i]["Remarks"].ToString()) && newDt0.Rows[i]["Remarks"] != null)
                            {
                                e.Graphics.DrawString(newDt0.Rows[i]["Remarks"].ToString(), new Font("微软雅黑", 9.5f),
                                    Brushes.Black, beginX + widthPaper * 11f / 13, beginY);
                            }
                            beginY += distanceY;
                        }
                    }
                    if (newDt1 != null)
                    {
                        float bgY = beginY + distanceY / 2;
                        e.Graphics.DrawString(newDt1.Rows[0]["Frequency"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 8.5f / 13, bgY);
                        e.Graphics.DrawString(newDt1.Rows[0]["UseAge"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 9.5f / 13, bgY);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, bgY - 3, beginX + widthPaper * 8 / 13 + 5, bgY - 3);
                        beginY += distanceY / 2;
                        for (int i = 0; i < newDt1.Rows.Count; i++)
                        {
                            e.Graphics.DrawString((i + 1) + ". " + newDt1.Rows[i]["MedName"], new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX, beginY);
                            e.Graphics.DrawString(newDt1.Rows[i]["MedStandard"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 4 / 13, beginY);
                            e.Graphics.DrawString(@"×  " + newDt1.Rows[i]["TimesUse"] + newDt1.Rows[i]["MedUnit"],
                                new Font("微软雅黑", 9.5f), Brushes.Black, beginX + widthPaper * 6 / 13, beginY);
                            if (!string.IsNullOrEmpty(newDt1.Rows[i]["Remarks"].ToString()) && newDt1.Rows[i]["Remarks"] != null)
                            {
                                e.Graphics.DrawString(newDt1.Rows[i]["Remarks"].ToString(), new Font("微软雅黑", 9.5f),
                                    Brushes.Black, beginX + widthPaper * 11f / 13, beginY);
                            }
                            beginY += distanceY;
                        }
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, beginY - distanceY + 15, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13 + 5, bgY-3, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                    }
                    if (newDt2 != null)
                    {
                        float bgY = beginY + distanceY / 2;
                        e.Graphics.DrawString(newDt2.Rows[0]["Frequency"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 8.5f / 13, bgY);
                        e.Graphics.DrawString(newDt2.Rows[0]["UseAge"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 9.5f / 13, bgY);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, bgY - 3, beginX + widthPaper * 8 / 13 + 5, bgY - 3);
                        beginY += distanceY / 2;
                        for (int i = 0; i < newDt2.Rows.Count; i++)
                        {
                            e.Graphics.DrawString((i + 1) + ". " + newDt2.Rows[i]["MedName"], new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX, beginY);
                            e.Graphics.DrawString(newDt2.Rows[i]["MedStandard"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 4 / 13, beginY);
                            e.Graphics.DrawString(@"×  " + newDt2.Rows[i]["TimesUse"] + newDt2.Rows[i]["MedUnit"],
                                new Font("微软雅黑", 9.5f), Brushes.Black, beginX + widthPaper * 6 / 13, beginY);
                            if (!string.IsNullOrEmpty(newDt2.Rows[i]["Remarks"].ToString()) && newDt2.Rows[i]["Remarks"] != null)
                            {
                                e.Graphics.DrawString(newDt2.Rows[i]["Remarks"].ToString(), new Font("微软雅黑", 9.5f),
                                    Brushes.Black, beginX + widthPaper * 11f / 13, beginY);
                            }
                            beginY += distanceY;
                        }
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, beginY - distanceY + 15, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13 + 5, bgY - 3, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                    }
                    if (newDt3 != null)
                    {
                        float bgY = beginY + distanceY / 2;
                        e.Graphics.DrawString(newDt3.Rows[0]["Frequency"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 8.5f / 13, bgY);
                        e.Graphics.DrawString(newDt3.Rows[0]["UseAge"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 9.5f / 13, bgY);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, bgY - 3, beginX + widthPaper * 8 / 13 + 5, bgY - 3);
                        beginY += distanceY / 2;
                        for (int i = 0; i < newDt3.Rows.Count; i++)
                        {
                            e.Graphics.DrawString((i + 1) + ". " + newDt3.Rows[i]["MedName"], new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX, beginY);
                            e.Graphics.DrawString(newDt3.Rows[i]["MedStandard"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 4 / 13, beginY);
                            e.Graphics.DrawString(@"×  " + newDt3.Rows[i]["TimesUse"] + newDt3.Rows[i]["MedUnit"],
                                new Font("微软雅黑", 9.5f), Brushes.Black, beginX + widthPaper * 6 / 13, beginY);
                            if (!string.IsNullOrEmpty(newDt3.Rows[i]["Remarks"].ToString()) && newDt3.Rows[i]["Remarks"] != null)
                            {
                                e.Graphics.DrawString(newDt3.Rows[i]["Remarks"].ToString(), new Font("微软雅黑", 9.5f),
                                    Brushes.Black, beginX + widthPaper * 11f / 13, beginY);
                            }
                            beginY += distanceY;
                        }
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, beginY - distanceY + 15, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13 + 5, bgY - 3, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                    }
                    if (newDt4 != null)
                    {
                        float bgY = beginY + distanceY / 2;
                        e.Graphics.DrawString(newDt4.Rows[0]["Frequency"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 8.5f / 13, bgY);
                        e.Graphics.DrawString(newDt4.Rows[0]["UseAge"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 9.5f / 13, bgY);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, bgY - 3, beginX + widthPaper * 8 / 13 + 5, bgY - 3);
                        beginY += distanceY / 2;
                        for (int i = 0; i < newDt4.Rows.Count; i++)
                        {
                            e.Graphics.DrawString((i + 1) + ". " + newDt4.Rows[i]["MedName"], new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX, beginY);
                            e.Graphics.DrawString(newDt4.Rows[i]["MedStandard"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 4 / 13, beginY);
                            e.Graphics.DrawString(@"×  " + newDt4.Rows[i]["TimesUse"] + newDt4.Rows[i]["MedUnit"],
                                new Font("微软雅黑", 9.5f), Brushes.Black, beginX + widthPaper * 6 / 13, beginY);
                            if (!string.IsNullOrEmpty(newDt4.Rows[i]["Remarks"].ToString()) && newDt4.Rows[i]["Remarks"] != null)
                            {
                                e.Graphics.DrawString(newDt4.Rows[i]["Remarks"].ToString(), new Font("微软雅黑", 9.5f),
                                    Brushes.Black, beginX + widthPaper * 11f / 13, beginY);
                            }
                            beginY += distanceY;
                        }
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, beginY - distanceY + 15, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13 + 5, bgY - 3, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                    }
                    if (newDt5 != null)
                    {
                        float bgY = beginY + distanceY / 2;
                        e.Graphics.DrawString(newDt5.Rows[0]["Frequency"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 8.5f / 13, bgY);
                        e.Graphics.DrawString(newDt5.Rows[0]["UseAge"].ToString(), new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX + widthPaper * 9.5f / 13, bgY);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, bgY - 3, beginX + widthPaper * 8 / 13 + 5, bgY - 3);
                        beginY += distanceY / 2;
                        for (int i = 0; i < newDt5.Rows.Count; i++)
                        {
                            e.Graphics.DrawString((i + 1) + ". " + newDt5.Rows[i]["MedName"], new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX, beginY);
                            e.Graphics.DrawString(newDt5.Rows[i]["MedStandard"].ToString(), new Font("微软雅黑", 9.5f),
                                Brushes.Black, beginX + widthPaper * 4 / 13, beginY);
                            e.Graphics.DrawString(@"×  " + newDt5.Rows[i]["TimesUse"] + newDt5.Rows[i]["MedUnit"],
                                new Font("微软雅黑", 9.5f), Brushes.Black, beginX + widthPaper * 6 / 13, beginY);
                            if (!string.IsNullOrEmpty(newDt5.Rows[i]["Remarks"].ToString()) && newDt5.Rows[i]["Remarks"] != null)
                            {
                                e.Graphics.DrawString(newDt5.Rows[i]["Remarks"].ToString(), new Font("微软雅黑", 9.5f),
                                    Brushes.Black, beginX + widthPaper * 11f / 13, beginY);
                            }
                            beginY += distanceY;
                        }
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13, beginY - distanceY + 15, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                        e.Graphics.DrawLine(new Pen(Color.Black), beginX + widthPaper * 8 / 13 + 5, bgY - 3, beginX + widthPaper * 8 / 13 + 5, beginY - distanceY + 15);
                    }
                    newDt0?.Dispose();
                    newDt1?.Dispose();
                    newDt2?.Dispose();
                    newDt3?.Dispose();
                    newDt4?.Dispose();
                    newDt5?.Dispose();
                }
                e.Graphics.DrawLine(new Pen(Color.Black), widthPaper * 0.5f / 13 + 120, heightPaper * 18.4f / 20, widthPaper * 12.5f / 13 + 120, heightPaper * 18.4f / 20);
                if (Information.CurrentUser.Name.Equals("熊测勇"))
                {
                    e.Graphics.DrawString(@"医师 ", new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 0.5f / 13 + 120, heightPaper * 18.5f / 20);
                    e.Graphics.DrawImage(Properties.Resources.XiongNameSmall, widthPaper * 0.5f / 13 + 155, heightPaper * 18.5f / 20);
                }
                else
                {
                    e.Graphics.DrawString(@"医师：" + Information.CurrentUser.Name, new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 0.5f / 13 + 120, heightPaper * 18.5f / 20);
                }
                e.Graphics.DrawString(@"护士：______", new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 3.5f / 13 + 120, heightPaper * 18.5f / 20);
                e.Graphics.DrawString(@"日期：" + DateTime.Now.ToShortDateString(), new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 6.5f / 13 + 120, heightPaper * 18.5f / 20);
                e.Graphics.DrawString(@"金额：" + txtSumPrice.Text, new Font("微软雅黑", 9.5f), Brushes.Black, widthPaper * 10 / 13 + 120, heightPaper * 18.5f / 20);
                dtSouce.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPrint_MouseClick(object sender, MouseEventArgs e)
        {
            cmtPrint.Show(btnPrint, new Point(e.X, e.Y));
        }

        private void cmbEachTimes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtSingular.Focus();
            }
            if (e.KeyCode == Keys.D1 && cmbEachTimes.Items.Count >= 1)
            {
                cmbEachTimes.SelectedIndex = 0;
            }
            if (e.KeyCode == Keys.D2 && cmbEachTimes.Items.Count >= 2)
            {
                cmbEachTimes.SelectedIndex = 1;
            }
            if (e.KeyCode == Keys.D3 && cmbEachTimes.Items.Count >= 3)
            {
                cmbEachTimes.SelectedIndex = 2;
            }
            if (e.KeyCode == Keys.D4 && cmbEachTimes.Items.Count >= 4)
            {
                cmbEachTimes.SelectedIndex = 3;
            }
            if (e.KeyCode == Keys.D5 && cmbEachTimes.Items.Count >= 5)
            {
                cmbEachTimes.SelectedIndex = 4;
            }
            if (e.KeyCode == Keys.D6 && cmbEachTimes.Items.Count >= 6)
            {
                cmbEachTimes.SelectedIndex = 5;
            }
            if (e.KeyCode == Keys.D7 && cmbEachTimes.Items.Count >= 7)
            {
                cmbEachTimes.SelectedIndex = 6;
            }
            if (e.KeyCode == Keys.D8 && cmbEachTimes.Items.Count >= 8)
            {
                cmbEachTimes.SelectedIndex = 7;
            }
            if (e.KeyCode == Keys.D9 && cmbEachTimes.Items.Count >= 9)
            {
                cmbEachTimes.SelectedIndex = 8;
            }
        }

        private void cmbUseWay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbEachTimes.Focus();
            }
            if (e.KeyCode == Keys.D1 && cmbUseWay.Items.Count >= 1)
            {
                cmbUseWay.SelectedIndex = 0;
            }
            if (e.KeyCode == Keys.D2 && cmbUseWay.Items.Count >= 2)
            {
                cmbUseWay.SelectedIndex = 1;
            }
            if (e.KeyCode == Keys.D3 && cmbUseWay.Items.Count >= 3)
            {
                cmbUseWay.SelectedIndex = 2;
            }
            if (e.KeyCode == Keys.D4 && cmbUseWay.Items.Count >= 4)
            {
                cmbUseWay.SelectedIndex = 3;
            }
            if (e.KeyCode == Keys.D5 && cmbUseWay.Items.Count >= 5)
            {
                cmbUseWay.SelectedIndex = 4;
            }
            if (e.KeyCode == Keys.D6 && cmbUseWay.Items.Count >= 6)
            {
                cmbUseWay.SelectedIndex = 5;
            }
            if (e.KeyCode == Keys.D7 && cmbUseWay.Items.Count >= 7)
            {
                cmbUseWay.SelectedIndex = 6;
            }
            if (e.KeyCode == Keys.D8 && cmbUseWay.Items.Count >= 8)
            {
                cmbUseWay.SelectedIndex = 7;
            }
            if (e.KeyCode == Keys.D9 && cmbUseWay.Items.Count >= 9)
            {
                cmbUseWay.SelectedIndex = 8;
            }
        }

        private void cmbMedicines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbUseWay.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtStock.Text = txtPrice.Text = string.Empty;
                string sSql = string.Empty;
                if (!cmbStyle.Text.Trim().Equals(@"全部") && !string.IsNullOrEmpty(cmbStyle.Text.Trim()))
                {
                    sSql += $@" and MedTypeID = '{cmbStyle.SelectedValue}'";
                }
                if (!string.IsNullOrEmpty(cmbMedicines.Text.Trim()))
                {
                    sSql += $@" and  (MedName like '%{cmbMedicines.Text.Trim()}%' or MedSpellFirst like '%{cmbMedicines.Text.Trim()}%')";
                }

                if (string.IsNullOrEmpty(sSql))
                {
                    MessageBox.Show(@"请输入内容精确进行查询！");
                    return;
                }
                DataTable dtMedicines = ErpServer.GetMedInfo(sSql, CommonInfo.ConfigStyle.药品类别.ToString()).Tables[0];
                cmbMedicines.ValueMember = @"MedID";
                cmbMedicines.DisplayMember = @"MedName";
                cmbMedicines.DataSource = dtMedicines;
            }
        }

        private void cmbStyle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                cmbMedicines.Focus();
            }
            if (e.KeyCode == Keys.D1 && cmbStyle.Items.Count >= 1)
            {
                cmbStyle.SelectedIndex = 0;
            }
            if (e.KeyCode == Keys.D2 && cmbStyle.Items.Count >= 2)
            {
                cmbStyle.SelectedIndex = 1;
            }
            if (e.KeyCode == Keys.D3 && cmbStyle.Items.Count >= 3)
            {
                cmbStyle.SelectedIndex = 2;
            }
            if (e.KeyCode == Keys.D4 && cmbStyle.Items.Count >= 4)
            {
                cmbStyle.SelectedIndex = 3;
            }
            if (e.KeyCode == Keys.D5 && cmbStyle.Items.Count >= 5)
            {
                cmbStyle.SelectedIndex = 4;
            }
            if (e.KeyCode == Keys.D6 && cmbStyle.Items.Count >= 6)
            {
                cmbStyle.SelectedIndex = 5;
            }
            if (e.KeyCode == Keys.D7 && cmbStyle.Items.Count >= 7)
            {
                cmbStyle.SelectedIndex = 6;
            }
            if (e.KeyCode == Keys.D8 && cmbStyle.Items.Count >= 8)
            {
                cmbStyle.SelectedIndex = 7;
            }
            if (e.KeyCode == Keys.D9 && cmbStyle.Items.Count >= 9)
            {
                cmbStyle.SelectedIndex = 8;
            }
        }

        private string _medValues;
        private void cmbMedicines_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dtMedicine = null;
            string sSql = string.Empty;
            cmbUseWay.SelectedIndex = cmbEachTimes.SelectedIndex = -1;
            txtStock.Text = txtSingular.Text = txtPrice.Text = txtPrice.Text = txtDayCnt.Text
                  = txtSumUse.Text = txtUnit.Text = txtUnites.Text = cmbEachTimes.Text = cmbUseWay.Text = string.Empty;
            if (!string.IsNullOrEmpty(cmbMedicines.Text))
            {
                sSql = $@" and m.MedID = '{cmbMedicines.SelectedValue}'";
                _medValues = cmbMedicines.SelectedValue.ToString().Trim();
            }
            dtMedicine = ErpServer.GetMedInfo(sSql, CommonInfo.ConfigStyle.药品类别.ToString()).Tables[0];
            if (dtMedicine != null && dtMedicine.Rows.Count != 0)
            {
                _medBarCode = dtMedicine.Rows[0]["MedBarCode"].SafeDbValue<string>();
                txtPrice.Text = dtMedicine.Rows[0]["MedUnitPrice"].SafeDbValue<string>();
                txtStock.Text = dtMedicine.Rows[0]["Quantity"].SafeDbValue<string>();
                txtUnit.Text = txtUnites.Text = dtMedicine.Rows[0]["MedUnit"].SafeDbValue<string>();
                _oneMedBid = string.IsNullOrEmpty(dtMedicine.Rows[0]["MedBid"].ToString()) ? decimal.Zero : dtMedicine.Rows[0]["MedBid"].SafeDbValue<decimal>();
                _medStandard = dtMedicine.Rows[0]["MedStandard"].SafeDbValue<string>();
                _medStyleName = dtMedicine.Rows[0]["StyleName"].SafeDbValue<string>();
            }
            if (!string.IsNullOrEmpty(txtStock.Text.Trim()) && !string.IsNullOrEmpty(cmbMedicines.Text.Trim()))
            {
                if (Convert.ToDecimal(txtStock.Text.Trim()) <= 30)
                {
                    MessageBox.Show(@"存在药品库存不足，请及时购入库存！");
                }
            }
            dtMedicine?.Dispose();
        }

        private void btnPlanSearch_Click(object sender, EventArgs e)
        {
            FrmPlan frmPlan = new FrmPlan();
            frmPlan.Show();
        }

        private void 粘贴方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Information.CopyPlanInfo != null)
                {
                    foreach (DataRow rowInfo in Information.CopyPlanInfo.Rows)
                    {
                        DataTable dtTable =
                            ErpServer.GetMedInfo($@" and ms.MedID = {rowInfo["MedID"]}", CommonInfo.ConfigStyle.药品类别.ToString())
                                .Tables[0];
                        if (dtTable.Rows.Count == 0)
                        {
                            continue;
                        }
                        if (_dtNewMed == null)
                        {
                            _dtNewMed = new DataTable();
                            _dtNewMed.Columns.Add("SpliteNum");
                            _dtNewMed.Columns.Add("MedID");
                            _dtNewMed.Columns.Add("MedName");
                            _dtNewMed.Columns.Add("MedUnitPrice"); //单价
                            _dtNewMed.Columns.Add("MedPrice"); //药品总价
                            _dtNewMed.Columns.Add("UseAge"); //用法
                            _dtNewMed.Columns.Add("Frequency"); //频率
                            _dtNewMed.Columns.Add("OneTimeUse"); //单量
                            _dtNewMed.Columns.Add("Days"); //天数
                            _dtNewMed.Columns.Add("TimesUse"); //总量
                            _dtNewMed.Columns.Add("Stock"); //库存
                            _dtNewMed.Columns.Add("MedUnit"); //计量单位
                            _dtNewMed.Columns.Add("MedBarCode"); //条码
                            _dtNewMed.Columns.Add("MedStandard"); //规格
                            _dtNewMed.Columns.Add("MedStyle"); //类别
                            _dtNewMed.Columns.Add("Remarks"); //备注
                            _dtNewMed.Columns.Add("MedBid"); //成本
                        }
                        DataRow drNewRow = _dtNewMed.NewRow();
                        drNewRow["SpliteNum"] = rowInfo["SpliteNum"]== null ? @"0" : rowInfo["SpliteNum"].ToString();
                        drNewRow["MedID"] = rowInfo["MedID"];
                        drNewRow["MedName"] = rowInfo["MedName"];
                        drNewRow["MedUnitPrice"] = dtTable.Rows[0]["MedUnitPrice"].SafeDbValue<string>();
                        drNewRow["UseAge"] = rowInfo["UseAge"];
                        drNewRow["MedPrice"] = Convert.ToDecimal(dtTable.Rows[0]["MedUnitPrice"]) * Convert.ToDecimal(rowInfo["TimesUse"]);
                        drNewRow["Frequency"] = rowInfo["Frequency"];
                        drNewRow["OneTimeUse"] = rowInfo["OneTimeUse"];
                        drNewRow["Days"] = rowInfo["Days"];
                        drNewRow["TimesUse"] = rowInfo["TimesUse"];
                        drNewRow["MedUnit"] = rowInfo["MedUnit"];
                        drNewRow["MedBarCode"] = dtTable.Rows[0]["MedBarCode"].SafeDbValue<string>();
                        drNewRow["MedStandard"] = rowInfo["MedStandard"];
                        drNewRow["MedStyle"] = rowInfo["MedStyle"];
                        drNewRow["MedBid"] = Convert.ToDecimal(Convert.ToDecimal(dtTable.Rows[0]["MedBid"]));
                        dgvMedicines.AutoGenerateColumns = false;
                        txtSumPrice.Text =
                            (Convert.ToDecimal(txtSumPrice.Text.Trim()) +
                             Convert.ToDecimal(dtTable.Rows[0]["MedUnitPrice"]) * Convert.ToDecimal(rowInfo["TimesUse"]))
                                .ToString(CultureInfo.InvariantCulture);
                        _dtNewMed.Rows.Add(drNewRow);
                        dgvMedicines.DataSource = _dtNewMed;
                        dtTable.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show(@"没有复制的方案！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnMemary_Click(object sender, EventArgs e)
        {
            FrmServerpatMed frmServerpatMed = new FrmServerpatMed();
            FrmBase frmBase = new FrmBase();
            frmBase.Controls.Add(frmServerpatMed);
            frmBase.Text = frmServerpatMed.Text;
            frmServerpatMed.Dock = DockStyle.Fill;
            frmBase.Show();
        }

        private void dgvMedicines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMedicines.Rows.Count > 0 && dgvMedicines.Columns.Count > 0)
            {
                foreach (DataGridViewRow eachRow in dgvMedicines.Rows)
                {
                    eachRow.Cells["MedPrice"].Value = Convert.ToDecimal(eachRow.Cells["MedUnitPrice"].Value) *
                                              Convert.ToDecimal(eachRow.Cells["TimesUse"].Value);
                }
            }
        }
        private void TxtPastHistoryKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtDiagnosis.SelectionLength = 0;
                cmbStyle.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtSumPrice.Text = @"0.00";
            foreach (DataGridViewRow eachRow in dgvMedicines.Rows)
            {
                eachRow.Cells["MedPrice"].Value = Convert.ToDecimal(eachRow.Cells["MedUnitPrice"].Value) *
                                                  Convert.ToDecimal(eachRow.Cells["TimesUse"].Value);
                txtSumPrice.Text = (Convert.ToDecimal(txtSumPrice.Text.Trim()) +
                                    Convert.ToDecimal(eachRow.Cells["MedPrice"].Value)).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void btnPatSearch_Click(object sender, EventArgs e)
        {
            Information.PatId = string.Empty;
            FrmPrescription frmPrescription = new FrmPrescription();
            FrmBase frmBase = new FrmBase();
            frmPrescription.Dock = DockStyle.Fill;
            frmBase.Text = @"门诊病人记录";
            frmBase.Controls.Add(frmPrescription);
            frmBase.ShowDialog();
            _dtPat = ErpServer.GetPationes($@" and  PatID like '%{ Information.PatId}%'").Tables[0];
            txtName.DataSource = _dtPat;
            txtName.ValueMember = @"PatID";
            txtName.DisplayMember = @"PatName";
        }

        private void txtName_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Information.PatId))
            {
                _dtPat = ErpServer.GetPationes($@" and (PatID like '%{Information.PatId}%')").Tables[0];
                txtName.DataSource = _dtPat;
                txtName.ValueMember = @"PatID";
                txtName.DisplayMember = @"PatName";
            }
        }

        private void printDocumentOthers_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                DataTable dtSouce = dgvMedicines.DataSource as DataTable;
                float widthPaper = 520f;
                float heightPaper = 750f; // 总大小 13cm*18cm
                e.Graphics.DrawString(@"铜梁区熊测勇诊所", new Font("微软雅黑", 14), Brushes.Black, widthPaper / 3 + 120,
                    heightPaper * 0.1f / 20);
                e.Graphics.DrawString(@"姓名：" + txtName.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"性别：" + cmbGender.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper * 4 / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"年龄：" + txtAge.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper * 8 / 13 + 120, heightPaper / 20);
                e.Graphics.DrawString(@"住址：" + txtAddress.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper / 13 + 120, heightPaper * 1.6f / 20);
                e.Graphics.DrawString(@"日期：" + DateTime.Now.ToShortDateString(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper * 8 / 13 + 120, heightPaper * 1.6f / 20);
                e.Graphics.DrawString(@"临床诊断：" + txtDiagnosis.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper / 13 + 120, heightPaper * 2.2f / 20);
                e.Graphics.DrawLine(new Pen(Color.Black), widthPaper * 0.5f / 13 + 120, heightPaper * 2.7f / 20,
                    widthPaper * 12.5f / 13 + 120, heightPaper * 2.7f / 20);
                e.Graphics.DrawString(@"Rp.", new Font("微软雅黑", 12), Brushes.Black, widthPaper / 13 + 100, heightPaper * 2.7f / 20);

                float distanceY = heightPaper / 20;
                float beginX = widthPaper*2.5f / 13 + 120;
                float beginY = heightPaper * 2.5f / 20;

                if (dtSouce != null)
                {
                    DataTable newDt =
                        dtSouce.Select("MedStyle = '辅助检查'").CopyToDataTable();
                    beginY += distanceY / 2;
                    for (int i = 0; i < newDt.Rows.Count; i++)
                    {
                        e.Graphics.DrawString((i + 1) + ". " + newDt.Rows[i]["MedName"], new Font("微软雅黑", 9.5f),
                            Brushes.Black, beginX, beginY);
                        beginY += distanceY * 2 / 3;
                    }
                    newDt.Dispose();
                }
                e.Graphics.DrawLine(new Pen(Color.Black), widthPaper * 0.5f / 13 + 120, heightPaper * 18.4f / 20,
                    widthPaper * 12.5f / 13 + 120, heightPaper * 18.4f / 20);
                e.Graphics.DrawString(@"医师：" + Information.CurrentUser.Name, new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper / 13 + 120, heightPaper * 18.5f / 20);
                e.Graphics.DrawString(@"药品金额：" + txtSumPrice.Text.Trim(), new Font("微软雅黑", 9.5f), Brushes.Black,
                    widthPaper * 9 / 13 + 120, heightPaper * 18.5f / 20);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPrintCheck_Click(object sender, EventArgs e)
        {
            DataTable dtSouce = dgvMedicines.DataSource as DataTable;
            if (dtSouce != null && dtSouce.Select(@"MedStyle = '辅助检查'").Any())
            {
                //西药
                PrintPreviewDialog frmPreviewExamination = new PrintPreviewDialog()
                { Document = printDocumentExamination };
                frmPreviewExamination.ShowDialog();
            }
            dtSouce?.Dispose();
        }

        private void btnAddCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbExamination.Text))
            {
                return;
            }
            if (_dtNewMed == null)
            {
                _dtNewMed = new DataTable();
                _dtNewMed.Columns.Add("SpliteNum");//分组
                _dtNewMed.Columns.Add("MedID");
                _dtNewMed.Columns.Add("MedName");
                _dtNewMed.Columns.Add("MedUnitPrice"); //单价
                _dtNewMed.Columns.Add("MedPrice"); //药品总价
                _dtNewMed.Columns.Add("UseAge"); //用法
                _dtNewMed.Columns.Add("Frequency"); //频率
                _dtNewMed.Columns.Add("OneTimeUse"); //单量
                _dtNewMed.Columns.Add("Days"); //天数
                _dtNewMed.Columns.Add("TimesUse"); //总量
                _dtNewMed.Columns.Add("MedUnit"); //计量单位
                _dtNewMed.Columns.Add("MedBarCode"); //条码
                _dtNewMed.Columns.Add("MedStandard"); //规格
                _dtNewMed.Columns.Add("MedStyle"); //类别
                _dtNewMed.Columns.Add("Remarks"); //其他备注
                _dtNewMed.Columns.Add("MedBid"); //成本
            }
            DataRow drNewRow = _dtNewMed.NewRow();
            _dtNewMed.Rows.Add(drNewRow);
            drNewRow["MedID"] = cmbExamination.SelectedValue.ToString();
            drNewRow["MedName"] = cmbExamination.Text.Trim();
            drNewRow["MedPrice"] = txtPayCheck.Text.Trim();
            drNewRow["MedStyle"] = @"辅助检查";
            dgvMedicines.AutoGenerateColumns = false;
            dgvMedicines.DataSource = _dtNewMed;
            txtSumPrice.Text = (Convert.ToDecimal(txtSumPrice.Text.Trim()) + Convert.ToDecimal(txtPayCheck.Text.Trim())).ToString(CultureInfo.InvariantCulture);
            cmbExamination.SelectedIndex = -1;
            txtPayCheck.Text = @"0.00";
        }

        private void cmbExamination_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtCheck = ErpServer.GetExamineInfo($@"  and CheckID = '{cmbExamination.SelectedValue}'").Tables[0];
            if (dtCheck.Rows.Count > 0)
            {
                txtPayCheck.Text = dtCheck.Rows[0]["CheckPrice"].ToString();
            }
            else
            {
                txtPayCheck.Text = @"0.00";
            }
        }
    }
}
