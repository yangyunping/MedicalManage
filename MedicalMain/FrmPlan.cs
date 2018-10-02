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
    public partial class FrmPlan : Form
    {
        public FrmPlan()
        {
            InitializeComponent();
            DgvColumns();
            DataTable dtTable = BllEmployee.GetEmployeeInfo(string.Empty).Tables[0];
            DataRow drRow = dtTable.NewRow();
            drRow["DocName"] = "全部";
            drRow["DocID"] = "0";
            dtTable.Rows.InsertAt(drRow, 0);
            cmbEmployees.DataSource = dtTable;
            cmbEmployees.DisplayMember = @"DocName";
            cmbEmployees.ValueMember = @"DocID";

            DataTable dtUseWay = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.方案类别.SafeDbValue<int>()).Tables[0];
            DataRow drRows = dtUseWay.NewRow();
            drRows["Name"] = "全部";
            drRows["SignID"] = "0";
            dtUseWay.Rows.InsertAt(drRows, 0);
            cmbPlan.DataSource = dtUseWay;
            cmbPlan.ValueMember = @"SignID";
            cmbPlan.DisplayMember = @"Name";
        }
        private void DgvColumns()
        {
            dgvPlan.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"SignID", DataPropertyName = @"SignID", HeaderText = @"方案编号", Width = 90 },
                new DataGridViewTextBoxColumn { Name = @"DocName", DataPropertyName = @"DocName", HeaderText = @"医生姓名", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"PatName", DataPropertyName = @"PatName", HeaderText = @"病人姓名", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"StyleName", DataPropertyName = @"StyleName", HeaderText = @"方案类型", Width = 140 }
                );
            dgvDetail.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = @"SpliteNum", DataPropertyName = @"SpliteNum", HeaderText = @"分组", Width = 60, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"MedID", DataPropertyName = @"MedID", HeaderText = @"药品编号", Width = 100, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"MedName", DataPropertyName = @"MedName", HeaderText = @"药品名称", Width = 120, ReadOnly = true },     
            new DataGridViewTextBoxColumn { Name = @"Useage", DataPropertyName = @"UseAge", HeaderText = @"用法", Width = 80, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"Frequency", DataPropertyName = @"Frequency", HeaderText = @"频率", Width = 70, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"OneTimeUse", DataPropertyName = @"OneTimeUse", HeaderText = @"单量", Width = 70, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"Days", DataPropertyName = @"Days", HeaderText = @"天数", Width = 70, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"TimesUse", DataPropertyName = @"TimesUse", HeaderText = @"总量", Width = 70, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"MedUnit", DataPropertyName = @"MedUnit", HeaderText = @"计量单位", Width = 100, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"MedStyle", DataPropertyName = @"MedStyle", HeaderText = @"类别", Width = 70, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"MedStandard", DataPropertyName = @"MedStandard", HeaderText = @"药品规格", Width = 120, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = @"ID", DataPropertyName = @"ID", HeaderText = @"序号", Width = 70, ReadOnly = true }
       );
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = @" and newRow = 1";
            if (!string.IsNullOrEmpty(cmbEmployees.Text) && !cmbEmployees.Text.Equals(@"全部"))
            {
                sSql += $@" and b.DocName = '{cmbEmployees.Text}'";
            }
            if (!string.IsNullOrEmpty(cmbPlan.Text) && !cmbPlan.Text.Equals(@"全部"))
            {
                sSql += $@" and a.StyleName = '{cmbPlan.Text}'";
            }
            DataTable dtTable = ErpServer.GetMedPlans(sSql).Tables[0];
            dgvPlan.AutoGenerateColumns = false;
            dgvPlan.DataSource = dtTable;
        }

        private void dgvPlan_Click(object sender, EventArgs e)
        {
            if(dgvPlan.CurrentRow != null)
            {
                string sSql = $@" and a.SignId= '{dgvPlan.CurrentRow.Cells["SignId"].Value}'";
                DataTable dtTable = ErpServer.GetMedPlans(sSql).Tables[0];
                dgvDetail.AutoGenerateColumns = false;
                dgvDetail.DataSource = dtTable;
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information.CopyPlanInfo = new DataTable();
            List<string> medIdLstList = new List<string>();
            if (dgvDetail.SelectedRows.Count > 0)
            {
                medIdLstList.AddRange(from DataGridViewRow medRow in dgvDetail.SelectedRows select medRow.Cells["MedID"].Value.ToString());
                DataTable newTable = dgvDetail.DataSource as DataTable;
                if (newTable != null)
                    Information.CopyPlanInfo =
                        newTable.Select($@" MedID in({@"'"+ string.Join(@"','", medIdLstList.ToArray())+ @"'"})").CopyToDataTable();
                MessageBox.Show(@"复制成功！");
                this.Hide();
            }
            else
            {
                MessageBox.Show(@"没有选中需要复制的行！");
            }
        }

        private void tmsDeletePro_Click(object sender, EventArgs e)
        {
            if (dgvPlan.CurrentRow != null)
            {
                if (DAL.ErpServer.DeletePlan(dgvPlan.CurrentRow.Cells["SignID"].Value.ToString()))
                {
                    MessageBox.Show(@"删除成功！");
                    dgvPlan.Rows.Remove(dgvPlan.CurrentRow);
                }
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (dgvDetail.CurrentRow != null)
            {
                if (DAL.ErpServer.DeletePlanMed(dgvDetail.CurrentRow.Cells["ID"].Value.ToString()))
                {
                    MessageBox.Show(@"删除成功！");
                    dgvDetail.Rows.Remove(dgvDetail.CurrentRow);
                }
            }
        }
    }
}
