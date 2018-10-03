using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmConfig : Form
    {
        BllConfig bllConfig = new BllConfig();
        BllTreatment bllTreatment = new BllTreatment();
        public FrmConfig()
        {
            InitializeComponent();
            IniteData();
            DgvColumns();
        }

        private void IniteData()
        {
            IEnumerable<Config> configs = bllConfig.GetConfigStyleInfo();
            DataTable dtConfig  = Information.ListToDataTable(configs);
            cmbStyle.ValueMember = "SignID";
            cmbStyle.DisplayMember = "Name";
            cmbStyle.DataSource = dtConfig;
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
            txtContent.Clear();
            if (string.IsNullOrEmpty(cmbStyle.Text))
            {
                return;
            }
            添加到治疗单Tsm.Visible = 取消治疗单打印Tsm.Visible = cmbStyle.SelectedValue.Equals(CommonInfo.ConfigStyle.用法.SafeDbValue<int>());
            dgvShow.AutoGenerateColumns = false;
            DataTable dtInfo = bllConfig.GetConfigInfo(cmbStyle.SelectedValue.SafeDbValue<int>()).Tables[0];
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
                Config config = new Config()
                {
                    Name = txtContent.Text,
                    StyleID = Convert.ToInt32(cmbStyle.SelectedValue)
                };

                if (bllConfig.AddConfig(config))
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
            if (dgvShow.CurrentRow != null)
            {
                try
                {
                    Config config = new Config()
                    {
                        SignID = Convert.ToInt32(dgvShow.CurrentRow.Cells["SignID"].Value),
                        Name = dgvShow.CurrentRow.Cells["Name"].Value.ToString(),
                        StyleID = Convert.ToInt32(dgvShow.CurrentRow.Cells["StyleID"].Value)
                    };
                    if (bllConfig.DeleteConfig(config))
                    {
                        MessageBox.Show(@"删除成功！");
                        dgvShow.Rows.Remove(dgvShow.CurrentRow);
                    }
                }
                catch { }
            }
        }

        private void btnAddStyle_Click(object sender, EventArgs e)
        {
            switch (btnAddStyle.Text)
            {
                case "新增类别":
                    txtType.Visible = btnClose.Visible = true;
                    btnAddStyle.Text = "保存类别";
                    break;
                case "保存类别":
                    if (string.IsNullOrEmpty(txtType.Text))
                    {
                        MessageBox.Show(@"请填写需要添加的类别！");
                        return;
                    }
                    foreach (DataRowView item in cmbStyle.Items)
                    {
                        if (item["Name"].ToString().Equals(txtType.Text.Trim()))
                        {
                            MessageBox.Show(@"该类别已添加");
                            return;
                        }
                    }
                    Config config = new Config()
                    {
                        Name = cmbStyle.Text.Trim(),
                        StyleID = 10000
                    };
                    if (bllConfig.AddConfig(config))
                    {
                        MessageBox.Show(@"添加成功！");
                        IniteData();
                    }
                    else
                    {
                        MessageBox.Show(@"添加失败，检查后重试！");
                    }
                    txtType.Visible = btnClose.Visible = false;
                    btnAddStyle.Text = "新增类别";
                    break;
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
                MessageBox.Show("请选中指定行！");
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(cmbStyle.Text) || string.IsNullOrEmpty(txtContent.Text.Trim()))
                {
                    MessageBox.Show(@"请补充完成的信息！");
                    return;
                }
                Config config = new Config()
                {
                    SignID = Convert.ToInt32(dgvShow.CurrentRow.Cells["SignID"].Value),
                    Name = txtContent.Text,
                    StyleID = Convert.ToInt32(dgvShow.CurrentRow.Cells["StyleID"].Value)
                };
                if (bllConfig.ModifyConfig(config))
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
            try
            {
                if (dgvShow.CurrentRow != null)
                {
                    Treatment treatment = new Treatment()
                    {
                        SignID = dgvShow.CurrentRow.Cells["SignID"].Value.ToString(),
                        SignName = dgvShow.CurrentRow.Cells["Name"].Value.ToString()
                    };
                    if (bllTreatment.AddTreatment(treatment))
                    {
                        MessageBox.Show("添加成功!");
                    }
                    else
                    {
                        MessageBox.Show("已添加!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 取消治疗单打印Tsm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvShow.CurrentRow != null)
                {
                    Treatment treatment = new Treatment()
                    {
                        SignID = dgvShow.CurrentRow.Cells["SignID"].Value.ToString(),
                        SignName = dgvShow.CurrentRow.Cells["Name"].Value.ToString()
                    };
                    if (bllTreatment.DeleteTreatment(treatment))
                    {
                        MessageBox.Show("取消成功!");
                    }
                    else
                    {
                        MessageBox.Show("已取消!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtType.Clear();
            btnAddStyle.Text = "新增类别";
            txtType.Visible = btnClose.Visible = false;
        }
    }
}
