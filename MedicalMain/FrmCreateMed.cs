using BLL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmCreateMed : Form
    {
        private readonly string _operteType;//操作类型
        BllConfig bllConfig = new BllConfig();
        private string medId = string.Empty;
        public FrmCreateMed(Medicine medicine)
        {
            InitializeComponent();
            IniteData();
            medId = medicine.MedId;
            txtName.Text = medicine.MedName;
            txtStandard.Text = medicine.MedStandard;
            cmbUnits.Text = medicine.MedUnit;
            cmbType.SelectedValue = medicine.MedTypeId;
            txtMedApproval.Text = medicine.MedApproval;
            txtSpellFirst.Text = medicine.MedSpellFirst;
        }
        public FrmCreateMed()
        {
            InitializeComponent();
            IniteData();
        }
        private void IniteData()
        {
            DataTable dtUnit = bllConfig.GetConfigInfo(CommonInfo.ConfigStyle.计量单位.SafeDbValue<int>()).Tables[0];
            cmbUnits.DataSource = dtUnit;
            cmbUnits.ValueMember = @"SignID";
            cmbUnits.DisplayMember = @"Name";
            cmbUnits.SelectedIndex = -1;

            DataTable dtStyle = bllConfig.GetConfigInfo(CommonInfo.ConfigStyle.药品类别.SafeDbValue<int>()).Tables[0];
            cmbType.DataSource = dtStyle;
            cmbType.ValueMember = @"SignID";
            cmbType.DisplayMember = @"Name";
            cmbType.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtStandard.Text) || string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrEmpty(cmbUnits.Text) || string.IsNullOrEmpty(txtMedApproval.Text) || string.IsNullOrEmpty(txtSpellFirst.Text))
            {
                MessageBox.Show(@"请完善药品信息！");
                return;
            }
            if (!string.IsNullOrEmpty(medId))
            {
                Medicine medicine = new Medicine();
                medicine.MedId = medId;
                medicine.MedName = txtName.Text.Trim();
                medicine.MedApproval = txtMedApproval.Text.Trim();
                medicine.MedStandard = txtStandard.Text.Trim();
                medicine.MedUnit = cmbUnits.Text.Trim();
                medicine.MedTypeId = cmbType.SelectedValue.ToString().Trim();
                medicine.MedSpellFirst = txtSpellFirst.Text.Trim();
                if (BllMedicine.InsertMedicine(medicine))
                {
                    MessageBox.Show(@"修改成功!");
                    Information.Medicine = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"修改失败，检查后重试！");
                }
            }
            else
            {
                Medicine medicine = new Medicine();
                medicine.MedId = string.Empty;
                medicine.MedName = txtName.Text.Trim();
                medicine.MedApproval = txtMedApproval.Text.Trim();
                medicine.MedStandard = txtStandard.Text.Trim();
                medicine.MedUnit = cmbUnits.Text.Trim();
                medicine.MedTypeId = cmbType.SelectedValue.ToString().Trim();
                medicine.MedSpellFirst = txtSpellFirst.Text.Trim();
                if (BllMedicine.InsertMedicine(medicine))
                {
                    MessageBox.Show(@"创建成功！");
                    txtName.Text = txtStandard.Text = cmbUnits.Text = cmbType.Text = txtMedApproval.Text = txtSpellFirst.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show(@"创建失败，检查后重试！");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
