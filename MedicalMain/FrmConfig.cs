using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace MedicalManage
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
            IniteData();
            DgvColumns();
        }

        private void IniteData()
        {
            DataTable dtTable = ErpServer.GetConfigStyleInfo().Tables[0];
            cmbStyle.ValueMember = @"SignID";
            cmbStyle.DisplayMember = @"Name";
            cmbStyle.DataSource = dtTable;
        }

        private void DgvColumns()
        {
            dgvShow.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"SignID", DataPropertyName = @"SignID", HeaderText = @"编号ID", Width = 80 },
                 new DataGridViewTextBoxColumn { Name = @"Name", DataPropertyName = @"Name", HeaderText = @"名称", Width = 130 },
                  new DataGridViewTextBoxColumn { Name = @"StyleID", DataPropertyName = @"StyleID", HeaderText = @"类别编号", Width = 100 }
                    );
        }

        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvShow.DataSource = null;
            if (string.IsNullOrEmpty(cmbStyle.Text))
            {
                return;
            }
            添加到治疗单Tsm.Visible = 取消治疗单打印Tsm.Visible = cmbStyle.Text.Equals(Config.ConfigStyle.用法.ToString());
            dgvShow.AutoGenerateColumns = false;
            DataTable dtInfo = BllConfig.GetConfigInfo(cmbStyle.Text.ToString()).Tables[0];
            dgvShow.DataSource = dtInfo;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbStyle.Text) || string.IsNullOrEmpty(txtContent.Text.Trim()))
                {
                    MessageBox.Show(@"请补充完成的信息！");
                    return;
                }

                foreach (DataGridViewRow item in dgvShow.Rows)
                {
                    if (item.Cells["Name"].Value.ToString().Equals(txtContent.Text.Trim()))
                    {
                        MessageBox.Show("已存在，请勿重复添加！");
                        return;
                    }
                }
                if (ErpServer.AddConfig(txtContent.Text, cmbStyle.SelectedValue.ToString()))
                {
                    MessageBox.Show(@"添加修改成功！");
                    txtContent.Clear();
                    cmbStyle_SelectedIndexChanged(null, null);
                }
                else
                {
                    MessageBox.Show(@"添加修改失败，请检查！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvShow.SelectedRows.Count; i++)
                {
                    try
                    {
                        if (ErpServer.DeleteConfig(dgvShow.SelectedRows[i].Cells["Name"].Value.ToString(), dgvShow.SelectedRows[i].Cells["SignID"].Value.ToString(), Information.CurrentUser.Id))
                        {
                            MessageBox.Show(@"删除成功！");
                            dgvShow.Rows.Remove(dgvShow.SelectedRows[i]);
                        }
                    }
                    catch { continue; }
                }
            }
        }

        private void btnAddStyle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbStyle.Text))
            {
                MessageBox.Show(@"请填写需要添加的类别！");
                return;
            }
            if (cmbStyle.SelectedValue != null)
            {
                MessageBox.Show(@"该类别已添加！");
                return;
            }
            foreach (DataRowView item in cmbStyle.Items)
            {
                if (item["Name"].ToString().Equals(cmbStyle.Text.Trim()))
                {
                    MessageBox.Show(@"该类别已添加");
                    return;
                }
            }
            if (ErpServer.AddConfig(cmbStyle.Text.Trim(), @"10000"))
            {
                MessageBox.Show(@"添加成功！");
                IniteData();
            }
            else
            {
                MessageBox.Show(@"添加失败，检查后重试！");
            }
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(null,null);
            }
        }

        private void dgvShow_Click(object sender, EventArgs e)
        {
            if (dgvShow.CurrentRow != null)
            {
                cmbStyle.SelectedValue = dgvShow.CurrentRow.Cells["StyleID"].Value.ToString();
                txtContent.Text = dgvShow.CurrentRow.Cells["Name"].Value.ToString();
            }
        }
         
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvShow.CurrentRow == null)
            {
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(cmbStyle.Text) || string.IsNullOrEmpty(txtContent.Text.Trim()))
                {
                    MessageBox.Show(@"请补充完成的信息！");
                    return;
                }
                if (ErpServer.ModifyConfig(dgvShow.CurrentRow.Cells["SignID"].Value.ToString(),txtContent.Text))
                {
                    MessageBox.Show(@"添加修改成功！");
                    txtContent.Clear();
                    cmbStyle_SelectedIndexChanged(null, null);
                }
                else
                {
                    MessageBox.Show(@"添加修改失败，请检查！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 添加到治疗单Tsm_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                Dictionary<string, string> treatments = new Dictionary<string, string>();
                for (int i = 0; i < dgvShow.SelectedRows.Count; i++)
                {
                    treatments.Add(dgvShow.SelectedRows[i].Cells["SignID"].Value.ToString(), dgvShow.SelectedRows[i].Cells["Name"].Value.ToString());
                }
                if (ErpServer.AddTreatment(treatments))
                {
                    MessageBox.Show("添加成功!");
                }
                else
                {
                    MessageBox.Show("已添加!");
                }
            }
        }

        private void 取消治疗单打印Tsm_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                List<string> signIds = new List<string>();
                for (int i = 0; i < dgvShow.SelectedRows.Count; i++)
                {
                    signIds.Add(dgvShow.SelectedRows[i].Cells["SignID"].Value.ToString());
                }
                if (ErpServer.DeleteTreatment(signIds))
                {
                    MessageBox.Show("取消成功!");
                }
            }
        }
    }
}
