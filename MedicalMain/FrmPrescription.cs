using BLL;
using DAL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmPrescription : UserControl
    {
        BllEmployee bllEmployee = new BllEmployee();
        public FrmPrescription()
        {
            InitializeComponent();
            DgvColumn();
            
            DataTable dtTable = bllEmployee.GetEmployeeInfo(string.Empty);
            DataRow drRow = dtTable.NewRow();
            drRow["DocName"] = "全部";
            drRow["DocID"] = "0";
            dtTable.Rows.InsertAt(drRow, 0);
            cmbEmployees.DataSource = dtTable;
            cmbEmployees.DisplayMember = @"DocName";
            cmbEmployees.ValueMember = @"DocID";
        }
        private void DgvColumn()
        {
            dgvServePats.Columns.AddRange(
                 new DataGridViewTextBoxColumn { Name = @"ID", DataPropertyName = @"ID", HeaderText = @"门诊号", Width = 80, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"PatID", DataPropertyName = @"PatID", HeaderText = @"病人编号", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"PatName", DataPropertyName = @"PatName", HeaderText = @"病人姓名", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"Diagnosis", DataPropertyName = @"Diagnosis", HeaderText = @"临床诊断", Width = 150, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"PastHistory", DataPropertyName = @"PastHistory", HeaderText = @"现病史", Width = 150, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"DocID", DataPropertyName = @"DocID", HeaderText = @"医生编号", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"DocName", DataPropertyName = @"DocName", HeaderText = @"医生姓名", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedCost", DataPropertyName = @"MedCost", HeaderText = @"成本", Width = 120, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedPrice", DataPropertyName = @"MedPrice", HeaderText = @"费用", Width = 120, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"CreateDate", DataPropertyName = @"CreateDate", HeaderText = @"诊断时间", Width = 120, ReadOnly = true }
            );
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = string.Empty;
            if (chkDate.Checked)
            {
                sSql += $@" and DATEDIFF(dd,CreateDate,'{dtpBegin.Value}')<=0 and DATEDIFF(dd,CreateDate,'{dtpEnd.Value}')>=0";
            }
            if (!string.IsNullOrEmpty(cmbEmployees.Text) && !cmbEmployees.Text.Equals(@"全部"))
            {
                sSql += $@" and DocID = '{cmbEmployees.SelectedValue}'";
            }
            if (!string.IsNullOrEmpty(txtKeys.Text.Trim()))
            {
                sSql += $@" and (Diagnosis like '%{txtKeys.Text.Trim()}%' or PatName like '%{txtKeys.Text.Trim()}%')";
            }
            dgvServePats.AutoGenerateColumns = false;
            DataTable dtTable = ErpServer.GetPrescription(sSql).Tables[0];
            dgvServePats.DataSource = dtTable;
            decimal inCost = 0, outPrice = 0;
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                inCost += dtTable.Rows[i]["MedCost"].SafeDbValue<decimal>();
                outPrice += dtTable.Rows[i]["MedPrice"].SafeDbValue<decimal>();
            }
            lblNum.Text = @"数量：" + dtTable.Rows.Count;
            lblMoneySum.Text = @"总成本：" + inCost + @"     " + @"总售价：" + outPrice  +@"     " + @"总利润：" + (outPrice - inCost);
            dtTable.Dispose();
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpBegin.Enabled = dtpEnd.Enabled = chkDate.Checked;
        }

        private void dgvServePats_DoubleClick(object sender, EventArgs e)
        {
            if (dgvServePats.CurrentRow != null)
            {
                Information.PatId = dgvServePats.CurrentRow.Cells["PatID"].Value.ToString();
                if (this.Parent is Form)
                {
                    ((Form) this.Parent).Close();
                }
            }
        }

        private void txtKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null,null);
            }
        }
    }
}
