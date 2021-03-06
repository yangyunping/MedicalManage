﻿using BLL;
using DAL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmMedInfo : UserControl
    {
        BllConfig bllConfig = new BllConfig();
        public FrmMedInfo()
        {
            InitializeComponent();
            InitData();
            DgvColumn();
        }

        private void InitData()
        {
            //权限
            btnSearch.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.药品查询.SafeDbValue<int>());
            btnAddNewMed.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.药品新增.SafeDbValue<int>());
            btnModify.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.药品修改.SafeDbValue<int>());
            btnDelete.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.药品删除.SafeDbValue<int>());
            btnAdd.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.库存新增.SafeDbValue<int>());

            DataTable dtStyle = bllConfig.GetConfigInfo(CommonInfo.ConfigStyle.药品类别.SafeDbValue<int>()).Tables[0];
            DataRow drRow = dtStyle.NewRow();
            drRow["SignID"] = @"-1";
            drRow["Name"] = @"全部";
            dtStyle.Rows.InsertAt(drRow, 0);
            cmbStyle.DataSource = dtStyle;
            cmbStyle.ValueMember = @"SignID";
            cmbStyle.DisplayMember = @"Name";
        }

        private void DgvColumn()
        {
            dgvMedicine.Columns.AddRange(
                 new DataGridViewTextBoxColumn { Name = @"MedID", DataPropertyName = @"MedID", HeaderText = @"药品编号", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedName", DataPropertyName = @"MedName", HeaderText = @"药品名称", Width = 150, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedSpellFirst", DataPropertyName = @"MedSpellFirst", HeaderText = @"药名首拼", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedTypeID", DataPropertyName = @"MedTypeID", HeaderText = @"类别编号", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"StyleName", DataPropertyName = @"StyleName", HeaderText = @"类别名", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedUnit", DataPropertyName = @"MedUnit", HeaderText = @"单位", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedStandard", DataPropertyName = @"MedStandard", HeaderText = @"药品规格", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"MedApproval", DataPropertyName = @"MedApproval", HeaderText = @"批准文号", Width = 100, ReadOnly = true }
            );
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = string.Empty;
            if (!string.IsNullOrEmpty(cmbStyle.Text)  && !cmbStyle.Text.Equals(@"全部"))
            {
                sSql += $@" and  MedTypeID = '{cmbStyle.SelectedValue}'";
            }
            if (!string.IsNullOrEmpty(txtKeys.Text))
            {
                sSql += $@" and (MedName like '%{txtKeys.Text}%'  or  MedID like '%{txtKeys.Text}%' or  MedSpellFirst like '%{txtKeys.Text}%') ";
            }
            DataTable drTable = ErpServer.GetMedcine(sSql).Tables[0];
            dgvMedicine.AutoGenerateColumns = false;
            dgvMedicine.DataSource = drTable;
            lblMedSum.Text = @"药品总数量：" + drTable.Rows.Count;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMedInfo();
            FrmAddMedStock frmAddMed = new FrmAddMedStock(@"添加",null,null);
            frmAddMed.ShowDialog();
        }

        private void AddMedInfo()
        {
            if (dgvMedicine.CurrentRow == null)
            {
                MessageBox.Show(@"请选择需要操作的药品！");
                return;
            }
            DataTable dtTable = dgvMedicine.DataSource as DataTable;
            if (dtTable != null)
                Information.Medicine =
                    dtTable.Select($@" MedID ='{dgvMedicine.CurrentRow.Cells["MedID"].Value.ToString()}'")[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.CurrentRow == null)
            {
                MessageBox.Show(@"请选择需要操作的药品！");
                return;
            }
            if (MessageBox.Show(@"确定删除该药品？", @"消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MessageBox.Show(ErpServer.DeleteMedicine(dgvMedicine.CurrentRow.Cells["MedID"].Value.ToString())
               ? @"删除成功！"
               : @"删除失败！");
                btnSearch_Click(null, null);
            }
        }

        private void 删除药品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.CurrentRow == null)
            {
                MessageBox.Show(@"请选择需要操作的药品！");
                return;
            }
            if (MessageBox.Show(@"确定删除该药品？", @"消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MessageBox.Show(ErpServer.DeleteMedicine(dgvMedicine.CurrentRow.Cells["MedID"].Value.ToString())
                    ? @"删除成功！"
                    : @"删除失败！");
                btnSearch_Click(null, null);
            }
        }

        private void 增加药品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(null,null);
        }

        private void 修改药品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnModify_Click(null,null);
        }

        private void txtKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null,null);
            }
        }

        private void btnCheckAdd_Click(object sender, EventArgs e)
        {
            FrmCheckPrice frmCheckPrice = new FrmCheckPrice();
            frmCheckPrice.ShowDialog();
        }

        private void btnAddNewMed_Click(object sender, EventArgs e)
        {
            FrmCreateMed frmCreateMed = new FrmCreateMed();
            frmCreateMed.ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.CurrentRow != null)
            {
                Medicine medicine = new Medicine()
                {
                    MedId = dgvMedicine.CurrentRow.Cells["MedID"].Value.ToString(),
                    MedName = dgvMedicine.CurrentRow.Cells["MedName"].Value.ToString(),
                    MedStandard = dgvMedicine.CurrentRow.Cells["MedStandard"].Value.ToString(),
                    MedTypeId = dgvMedicine.CurrentRow.Cells["MedTypeID"].Value.ToString(),
                    MedUnit = dgvMedicine.CurrentRow.Cells["MedUnit"].Value.ToString(),
                    MedApproval = dgvMedicine.CurrentRow.Cells["MedApproval"].Value.ToString(),
                    MedSpellFirst = dgvMedicine.CurrentRow.Cells["MedSpellFirst"].Value.ToString()
                };
                FrmCreateMed frmCreateMed = new FrmCreateMed(medicine);
                frmCreateMed.ShowDialog();
                btnSearch_Click(null, null);
            }
            else
            {
                MessageBox.Show(@"请选择需要操作的药品！");
            }
        }
    }
}
