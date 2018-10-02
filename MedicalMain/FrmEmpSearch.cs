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
    public partial class FrmEmpSearch : UserControl
    {
        public FrmEmpSearch()
        {
            InitializeComponent();
            DgvColumns();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvEmployee.DataSource = null;
            dgvEmployee.AutoGenerateColumns = false; 
            DataTable dtTable = ErpServer.GetEmployeeInfo( $@" and (DocName like '%{txtKey.Text.Trim()}%' or DocID like '%{txtKey.Text.Trim()}%')").Tables[0];
            dgvEmployee.DataSource = dtTable;
        }

        private void DgvColumns()
        {
            dgvEmployee.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"DocID", DataPropertyName = @"DocID", HeaderText = @"员工ID", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"DocName", DataPropertyName = @"DocName", HeaderText = @"员工姓名", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"DocPassword", DataPropertyName = @"DocPassword", HeaderText = @"密码", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"DocSex", DataPropertyName = @"DocSex", HeaderText = @"性别", Width = 80 },
                new DataGridViewTextBoxColumn { Name = @"DocAge", DataPropertyName = @"DocAge", HeaderText = @"年龄", Width = 80 },
                new DataGridViewTextBoxColumn { Name = @"DocDutyID", DataPropertyName = @"DocDutyID", HeaderText = @"职称ID", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"Name", DataPropertyName = @"Name", HeaderText = @"职称名称", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"DocTel", DataPropertyName = @"DocTel", HeaderText = @"电话号码", Width = 100 }
                );
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmEmployee frmEmployee = new FrmEmployee(string.Empty);
            frmEmployee.ShowDialog();
            btnSearch_Click(null, null);
        }

        private void 修改员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnChange_Click(null,null);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow != null)
            {
                FrmEmployee frmEmployee = new FrmEmployee(dgvEmployee.CurrentRow.Cells["DocID"].Value.ToString());
                frmEmployee.ShowDialog();
                btnSearch_Click(null,null);
            }
            else
            {
                MessageBox.Show(@"请选择需要修改的员工！");
            }
        }

        private void 删除员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null,null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow != null)
            {
                if (ErpServer.DeleteEmp(dgvEmployee.CurrentRow.Cells["DocID"].Value.ToString().Trim()))
                {
                    MessageBox.Show(@"删除成功！");
                    dgvEmployee.Rows.Remove(dgvEmployee.CurrentRow);
                }
                else
                {
                    MessageBox.Show(@"删除失败，检查后重试！");
                }
            }
            else
            {
                MessageBox.Show(@"请选择需要删除的员工！");
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
