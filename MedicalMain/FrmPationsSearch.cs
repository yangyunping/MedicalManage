using BLL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmPationsSearch : UserControl
    {
        BllPations bllPations = new BllPations();
        public FrmPationsSearch()
        {
            InitializeComponent();
            DgvCloumn();

            //权限
            btnSearch.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.病人查询.SafeDbValue<int>());
            btnDelete.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.病人删除.SafeDbValue<int>());
            //DataTable dtPat = bllPations.GetPationes(string.Empty);
            //DataRow drRow = dtPat.NewRow();
            //drRow["PatID"] = @"-1";
            //drRow["PatName"] = @"全部";
            //dtPat.Rows.InsertAt(drRow, 0);
            //cmbPatName.DataSource = dtPat;
            //cmbPatName.ValueMember = @"PatID";
            //cmbPatName.DisplayMember = @"PatName";
        }

        public void DgvCloumn()
        {
            dgvPat.Columns.AddRange(
              new DataGridViewTextBoxColumn { Name = @"PatID", DataPropertyName = @"PatID", HeaderText = @"病人编号", Width = 100, ReadOnly = true },
              new DataGridViewTextBoxColumn { Name = @"PatName", DataPropertyName = @"PatName", HeaderText = @"病人姓名", Width = 100, ReadOnly = true },
              new DataGridViewTextBoxColumn { Name = @"Age", DataPropertyName = @"Age", HeaderText = @"年龄", Width = 80, ReadOnly = true },
              new DataGridViewTextBoxColumn { Name = @"Gender", DataPropertyName = @"Gender", HeaderText = @"性别", Width = 70, ReadOnly = true },
              new DataGridViewTextBoxColumn { Name = @"TelPhone", DataPropertyName = @"TelPhone", HeaderText = @"联系方式", Width = 150, ReadOnly = true },
              new DataGridViewTextBoxColumn { Name = @"Addresses", DataPropertyName = @"Addresses", HeaderText = @"住址", Width = 400, ReadOnly = true }
         );
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvPat.DataSource = null;
            string sSql = string.Empty;
            //if (!string.IsNullOrEmpty(cmbPatName.Text) && !cmbPatName.Text.Equals(@"全部"))
            //{
            //    sSql += $@" and  PatName = '{cmbPatName.Text}'";
            //}
            if (!string.IsNullOrEmpty(txtKey.Text))
            {
                sSql += $@" and PatName like '%{txtKey.Text}%'";
            }
            DataTable dtPat = bllPations.GetPationes(sSql);
            dgvPat.AutoGenerateColumns = false;
            dgvPat.DataSource = dtPat;
            lblSum.Text = "总数：" + dtPat.Rows.Count;
            dtPat.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPat.CurrentRow != null)
            {
                if (bllPations.DeletePationes(dgvPat.CurrentRow.Cells["PatID"].Value.ToString()))
                {
                    MessageBox.Show("删除成功！");
                }
            }
        }

        private void dgvPat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvPat.CurrentRow != null)
            {
                Information.PatId = dgvPat.CurrentRow.Cells["PatID"].Value.ToString();
                if (this.Parent is Form)
                {
                    ((Form)this.Parent).Close();
                }
            }
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null,null);
            }
        }
    }
}
