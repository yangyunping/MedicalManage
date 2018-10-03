using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmServerpatMed : UserControl
    {
        public FrmServerpatMed()
        {
            InitializeComponent();
            DgvColumn();
            IniteData();
        }

        private void IniteData()
        {
            DataTable dtTable = BllEmployee.GetEmployeeInfo(string.Empty).Tables[0];
            DataRow drRow1 = dtTable.NewRow();
            drRow1["DocName"] = @"全部";
            drRow1["DocID"] = @"-1";
            dtTable.Rows.InsertAt(drRow1, 0);
            cmbEmployees.DataSource = dtTable;
            cmbEmployees.DisplayMember = @"DocName";
            cmbEmployees.ValueMember = @"DocID";

            DataTable dtStyle = ErpServer.GetConfigInfo(CommonInfo.ConfigStyle.药品类别.SafeDbValue<int>()).Tables[0];
            DataRow drRow2 = dtStyle.NewRow();
            drRow2["SignID"] = @"-1";
            drRow2["Name"] = @"全部";
            dtStyle.Rows.InsertAt(drRow2, 0);
            cmbStyle.ValueMember = @"SignID";
            cmbStyle.DisplayMember = @"Name";
            cmbStyle.DataSource = dtStyle;

            DataTable dtPat = BllPations.GetPationes(string.Empty);
            DataRow drRow3 = dtPat.NewRow();
            drRow3["PatID"] = @"-1";
            drRow3["PatName"] = @"全部";
            dtPat.Rows.InsertAt(drRow3, 0);
            cmbPations.DataSource = dtPat;
            cmbPations.ValueMember = @"PatID";
            cmbPations.DisplayMember = @"PatName";
        }

        private void DgvColumn()
        {//om.MedID,MedBarCode,om.MedName,OutQuantity,MedUnit,MedStandard,MedStyle,DocName,PatName,MedUnitPrice,MedPrice,LookDate,Useage ,Frequency ,OneTimeUse,Days ,TimesUse--用法
            dgvMedsInfo.Columns.AddRange(
                 new DataGridViewTextBoxColumn { Name = @"ID", DataPropertyName = @"ID", HeaderText = @"序号", Width = 60, ReadOnly = true },
                  new DataGridViewTextBoxColumn { Name = @"SpliteNum", DataPropertyName = @"SpliteNum", HeaderText = @"分组", Width = 60, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedID", DataPropertyName = @"MedID", HeaderText = @"药品编号", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedName", DataPropertyName = @"MedName", HeaderText = @"药品名称", Width = 120, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedStyle", DataPropertyName = @"MedStyle", HeaderText = @"类别", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"Useage", DataPropertyName = @"Useage", HeaderText = @"用法", Width = 80, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"Frequency", DataPropertyName = @"Frequency", HeaderText = @"频率", Width = 80, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"OneTimeUse", DataPropertyName = @"OneTimeUse", HeaderText = @"单量", Width = 80, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"Days", DataPropertyName = @"Days", HeaderText = @"天数", Width = 80, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"TimesUse", DataPropertyName = @"TimesUse", HeaderText = @"总量", Width = 80, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"DocName", DataPropertyName = @"DocName", HeaderText = @"医生姓名", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"PatName", DataPropertyName = @"PatName", HeaderText = @"病人姓名", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"LookDate", DataPropertyName = @"LookDate", HeaderText = @"看病时间", Width = 120, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedUnit", DataPropertyName = @"MedUnit", HeaderText = @"单位", Width = 80, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedStandard", DataPropertyName = @"MedStandard", HeaderText = @"规格", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedUnitPrice", DataPropertyName = @"MedUnitPrice", HeaderText = @"药品单价", Width = 120, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedPrice", DataPropertyName = @"MedPrice", HeaderText = @"总价", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedBarCode", DataPropertyName = @"MedBarCode", HeaderText = @"药品条码", Width = 100, ReadOnly = true }
            );
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = string.Empty;
            if (chkDate.Checked)
            {
                sSql += $@" and DATEDIFF(dd,LookDate,'{dtpBegin.Value}')<=0 and DATEDIFF(dd,LookDate,'{dtpEnd.Value}')>=0";
            }
            if (!string.IsNullOrEmpty(cmbEmployees.Text) && !cmbEmployees.Text.Equals(@"全部"))
            {
                sSql += $@" and DocID = '{cmbEmployees.SelectedValue}'";
            }
            if (!string.IsNullOrEmpty(cmbPations.Text) && !cmbPations.Text.Equals(@"全部"))
            {
                sSql += $@" and  PatID = '{cmbPations.SelectedValue}'";
            }
            if (!string.IsNullOrEmpty(cmbStyle.Text) && !cmbStyle.Text.Equals(@"全部"))
            {
                sSql += $@" and SignID = '{cmbStyle.SelectedValue}'";
            }
            if (!string.IsNullOrEmpty(cmbMedicines.Text) && !cmbMedicines.Text.Equals(@"全部"))
            {
                sSql += $@" and  MedID = '{cmbMedicines.SelectedValue}'";
            }

            if (!string.IsNullOrEmpty(txtKey.Text.Trim()))
            {
                sSql += $@" and  (PatName like '%{txtKey.Text.Trim()}%' or  DocName like '%{txtKey.Text.Trim()}%' or  MedName like '%{txtKey.Text.Trim()}%' or  MedSpellFirst like '%{txtKey.Text.Trim()}%')";
            }

            DataTable dtMedTable = ErpServer.GetMedOutInfo(sSql).Tables[0];
            dgvMedsInfo.AutoGenerateColumns = false;
            dgvMedsInfo.DataSource = dtMedTable;
            lblMoneySum.Text = @"数量：" + dtMedTable.Rows.Count;
            dtMedTable.Dispose();
        }

        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMedicines.DataSource = null;
            if (cmbStyle.SelectedValue != null)
            {
                string sSql = $@" and MedTypeID = '{cmbStyle.SelectedValue}'";
                DataTable dtMedicines = ErpServer.GetMedInfo(sSql, CommonInfo.ConfigStyle.药品类别.SafeDbValue<int>()).Tables[0];
                DataRow drRow = dtMedicines.NewRow();
                drRow["MedID"] = @"-1";
                drRow["MedName"] = @"全部";
                dtMedicines.Rows.InsertAt(drRow, 0);
                cmbMedicines.DataSource = dtMedicines;
                cmbMedicines.ValueMember = @"MedID";
                cmbMedicines.DisplayMember = @"MedName";
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpBegin.Enabled = dtpEnd.Enabled = chkDate.Checked;
        }

        private void cmbPations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtPat = ErpServer.GetPationes($@" and  PatName like '{cmbPations.Text}%'").Tables[0];
                DataRow drRow = dtPat.NewRow();
                drRow["PatID"] = @"-1";
                drRow["PatName"] = @"全部";
                dtPat.Rows.InsertAt(drRow, 0);
                cmbPations.DataSource = dtPat;
                cmbPations.ValueMember = @"PatID";
                cmbPations.DisplayMember = @"PatName";
            }
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null,null);
            }
        }

        private void cmbCopy_Click(object sender, EventArgs e)
        {
            Information.CopyPlanInfo = new DataTable();
            List<string> medIdLstList = new List<string>();
            if (dgvMedsInfo.SelectedRows.Count > 0)
            {
                medIdLstList.AddRange(from DataGridViewRow medRow in dgvMedsInfo.SelectedRows select medRow.Cells["ID"].Value.ToString());
                DataTable newTable = dgvMedsInfo.DataSource as DataTable;
                if (newTable != null)
                    Information.CopyPlanInfo =
                        newTable.Select($@"ID in({@"'" + string.Join(@"','", medIdLstList.ToArray()) + @"'"})").CopyToDataTable();
                MessageBox.Show(@"复制成功！");
                this.Parent?.Hide();
            }
            else
            {
                MessageBox.Show(@"没有选中需要复制的行！");
            }
        }
    }
}
