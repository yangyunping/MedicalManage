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
    public partial class FrmCreateMed : Form
    {
        private readonly string _operteType;

        public FrmCreateMed(string operteType)
        {
            _operteType = operteType;
            InitializeComponent();
            IniteData();
        }

        private void IniteData()
        {
            DataTable dtUnit = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.计量单位.SafeDbValue<int>()).Tables[0];
            cmbUnits.DataSource = dtUnit;
            cmbUnits.ValueMember = @"SignID";
            cmbUnits.DisplayMember = @"Name";
            cmbUnits.SelectedIndex = -1;

            DataTable dtStyle = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.药品类别.SafeDbValue<int>()).Tables[0];
            cmbType.DataSource = dtStyle;
            cmbType.ValueMember = @"SignID";
            cmbType.DisplayMember = @"Name";
            cmbType.SelectedIndex = -1;

            if (_operteType == @"修改药品")
            {
                txtName.Text = Information.Medicine.MedName;
                txtStandard.Text = Information.Medicine.MedStandard;
                cmbUnits.Text = Information.Medicine.MedUnit;
                cmbType.SelectedValue = Information.Medicine.MedTypeId;
                txtMedApproval.Text = Information.Medicine.MedApproval;
                txtSpellFirst.Text = Information.Medicine.MedSpellFirst;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtStandard.Text) || string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrEmpty(cmbUnits.Text) || string.IsNullOrEmpty(txtMedApproval.Text) || string.IsNullOrEmpty(txtSpellFirst.Text))
            {
                MessageBox.Show(@"请完善药品信息！");
                return;
            }
            if (_operteType == @"修改药品")
            {
                Medicine medicine = new Medicine();
                medicine.MedId = Information.Medicine.MedId;
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
            else if (_operteType == @"创建药品")
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
