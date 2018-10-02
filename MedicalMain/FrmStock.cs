using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using DAL;
using BLL;

namespace UI
{
    public partial class FrmStock : UserControl
    {
        public FrmStock()
        {
            InitializeComponent();
            IniteData();
        }

        private void IniteData()
        {
            DataTable dtStyle = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.药品类别.SafeDbValue<int>()).Tables[0];
            DataRow drRow = dtStyle.NewRow();
            drRow["SignID"] = @"-1";
            drRow["Name"] = @"全部";
            dtStyle.Rows.InsertAt(drRow,0);
            cmbStyle.DataSource = dtStyle;
            cmbStyle.ValueMember = @"SignID";
            cmbStyle.DisplayMember = @"Name";
         
            dgvMedicine.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"MedID", DataPropertyName = @"MedID", HeaderText = @"药品编号", Width = 120 },
                 new DataGridViewTextBoxColumn { Name = @"MedName", DataPropertyName = @"MedName", HeaderText = @"药品名称", Width = 120 },
                  new DataGridViewTextBoxColumn { Name = @"MedBarCode", DataPropertyName = @"MedBarCode", HeaderText = @"药品条码", Width = 120 },
                   new DataGridViewTextBoxColumn { Name = @"Production", DataPropertyName = @"Production", HeaderText = @"生产厂商", Width = 120 },
                     new DataGridViewTextBoxColumn { Name = @"ProduteDate", DataPropertyName = @"ProduteDate", HeaderText = @"生产日期", Width = 140 },
                     new DataGridViewTextBoxColumn { Name = @"DueDate", DataPropertyName = @"DueDate", HeaderText = @"到期日期", Width = 120 },
                      new DataGridViewTextBoxColumn { Name = @"InDate", DataPropertyName = @"InDate", HeaderText = @"入库时间", Width = 140 },
                      new DataGridViewTextBoxColumn { Name = @"ReleaseDay", DataPropertyName = @"ReleaseDay", HeaderText = @"保质期", Width = 80 },
                       new DataGridViewTextBoxColumn { Name = @"Quantity", DataPropertyName = @"Quantity", HeaderText = @"库存", Width = 100 },
                        new DataGridViewTextBoxColumn { Name = @"MedBid", DataPropertyName = @"MedBid", HeaderText = @"进价", Width = 70 },
                         new DataGridViewTextBoxColumn { Name = @"MedUnitPrice", DataPropertyName = @"MedUnitPrice", HeaderText = @"售价", Width = 70 },
                          new DataGridViewTextBoxColumn { Name = @"MedUnit", DataPropertyName = @"MedUnit", HeaderText = @"单位", Width = 70 },
                           new DataGridViewTextBoxColumn { Name = @"MedStandard", DataPropertyName = @"MedStandard", HeaderText = @"规格", Width = 120 },
                            new DataGridViewTextBoxColumn { Name = @"StyleName", DataPropertyName = @"StyleName", HeaderText = @"类别", Width = 80 },
                             new DataGridViewTextBoxColumn { Name = @"Memary", DataPropertyName = @"Memary", HeaderText = @"备注", Width = 120 },
                             new DataGridViewTextBoxColumn { Name = @"MedApproval", DataPropertyName = @"MedApproval", HeaderText = @"标准", Width = 120 }
                );
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpBegin.Enabled = dtpEnd.Enabled = chkDate.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMedicine.DataSource = null;
            string sSql = string.Empty;
            if (chkDate.Checked)
            {
                sSql += $@" and DATEDIFF(dd,InDate,'{dtpBegin.Value}') <=0 and DATEDIFF(dd,InDate,'{dtpEnd.Value}') >=0";
            }
            if (!string.IsNullOrEmpty(cmbStyle.Text) &&  !cmbStyle.Text.Equals(@"全部"))
            {
                sSql += $@" and  MedTypeID = '{cmbStyle.SelectedValue}'";
            }
            if (!string.IsNullOrEmpty(txtKeys.Text))
            {
                sSql += $@" and  (MedName like '%{txtKeys.Text}%' or MedSpellFirst like '%{txtKeys.Text}%')";
            }
            DataTable drInMed = ErpServer.GetInMedDataSet(sSql).Tables[0];
            dgvMedicine.AutoGenerateColumns = false;
            dgvMedicine.DataSource = drInMed;
            lblSum.Text = @"数量：" + drInMed.Rows.Count;
            drInMed.Dispose();
        }

        private void 修改库存信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.CurrentRow == null)
            {
                MessageBox.Show(@"请选择需要修改的行！");
                return;
            }
            AddMedicine addMedicine = new AddMedicine();
            addMedicine.MedID = dgvMedicine.CurrentRow.Cells["MedID"].Value.ToString();
            addMedicine.MedName = dgvMedicine.CurrentRow.Cells["MedName"].Value.ToString();
            addMedicine.MedBarCode = dgvMedicine.CurrentRow.Cells["MedBarCode"].Value.ToString();
            addMedicine.Production = dgvMedicine.CurrentRow.Cells["Production"].Value.ToString();
            addMedicine.ProduteDate = dgvMedicine.CurrentRow.Cells["ProduteDate"].Value.SafeDbDateTime();
            addMedicine.ReleaseDay = dgvMedicine.CurrentRow.Cells["ReleaseDay"].Value.SafeDbInt32();
            addMedicine.Quantity = dgvMedicine.CurrentRow.Cells["Quantity"].Value.SafeDbInt32();
            addMedicine.MedBid = dgvMedicine.CurrentRow.Cells["MedBid"].Value.SafeDbDecimal();
            addMedicine.MedUnitPrice = dgvMedicine.CurrentRow.Cells["MedUnitPrice"].Value.SafeDbDecimal();
            addMedicine.Memary = dgvMedicine.CurrentRow.Cells["Memary"].Value.ToString();
            addMedicine.DueDate = dgvMedicine.CurrentRow.Cells["DueDate"].Value.SafeDbDateTime();

            Medicine medicine = new Medicine();
            medicine.MedUnit = dgvMedicine.CurrentRow.Cells["MedUnit"].Value.ToString();
            medicine.MedStandard = dgvMedicine.CurrentRow.Cells["MedStandard"].Value.ToString();
            medicine.MedTypeId = dgvMedicine.CurrentRow.Cells["StyleName"].Value.ToString();
            medicine.MedApproval = dgvMedicine.CurrentRow.Cells["MedApproval"].Value.ToString();
            FrmAddMed frmAddMed = new FrmAddMed(@"修改", addMedicine, medicine);
            frmAddMed.ShowDialog();
            btnSearch_Click(null,null);
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
