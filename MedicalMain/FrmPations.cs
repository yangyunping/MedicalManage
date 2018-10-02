using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace UI
{
    public partial class FrmPations : UserControl
    {
        public FrmPations()
        {
            InitializeComponent();
            DgvCloumn();
            DataTable dtPat = ErpServer.GetPationes(string.Empty).Tables[0];
            DataRow drRow = dtPat.NewRow();
            drRow["PatID"] = @"-1";
            drRow["PatName"] = @"全部";
            dtPat.Rows.InsertAt(drRow, 0);
            cmbPatName.DataSource = dtPat;
            cmbPatName.ValueMember = @"PatID";
            cmbPatName.DisplayMember = @"PatName";
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
            if (!string.IsNullOrEmpty(cmbPatName.Text) && !cmbPatName.Text.Equals(@"全部"))
            {
                sSql += $@" and  PatName = '{cmbPatName.Text}'";
            }
            if (!string.IsNullOrEmpty(txtKey.Text))
            {
                sSql += $@" and PatName like '%{cmbPatName.Text}%'";
            }
            DataTable dtPat = ErpServer.GetPationes(sSql).Tables[0];
            dgvPat.AutoGenerateColumns = false;
            dgvPat.DataSource = dtPat;
            dtPat.Dispose();
        }
    }
}
