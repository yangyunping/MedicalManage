using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MedicalManage
{
    public partial class FrmAddMed : Form
    {
        private readonly string _operateStyle;
        private readonly AddMedicine _addMedicine;
        private readonly Medicine _medicine;
        public FrmAddMed(string operateStyle,AddMedicine addMedicine,Medicine medicine)
        {
            InitializeComponent();
            _operateStyle = operateStyle;
            _addMedicine = addMedicine;
            _medicine = medicine;
            IniteData();
        }

        private void IniteData()
        {
            try
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


                DataTable dtProduct = BllConfig.GetConfigInfo(CommonInfo.ConfigStyle.生产厂商.SafeDbValue<int>()).Tables[0];
                cmbProduce.DataSource = dtProduct;
                cmbProduce.ValueMember = @"SignID";
                cmbProduce.DisplayMember = @"Name";
                cmbProduce.SelectedIndex = -1;

                if (_operateStyle.Equals(@"修改"))
                {
                    txtMedId.ReadOnly = txtBarcode.ReadOnly = true;
                    txtMedId.Text = _addMedicine.MedID;
                    txtName.Text = _addMedicine.MedName;
                    txtBarcode.Text = _addMedicine.MedBarCode.ToString();
                    cmbProduce.Text = _addMedicine.Production;
                    dtpProDate.Value = _addMedicine.ProduteDate;
                    numSum.Value = _addMedicine.Quantity;
                    numBid.Text = _addMedicine.MedBid.ToString();
                    numSale.Text = _addMedicine.MedUnitPrice.ToString();
                    cmbUnits.Text = _medicine.MedUnit;
                    txtStandard.Text = _medicine.MedStandard;
                    cmbType.Text = _medicine.MedTypeId;
                    txtMemary.Text = _addMedicine.Memary;
                    txtMedApproval.Text = _medicine.MedApproval;
                    dtpDue.Value = _addMedicine.DueDate;
                }
                else if (_operateStyle.Equals(@"添加"))
                {
                    txtBarcode.ReadOnly = false;
                    txtMedId.Text = Information.Medicine.MedId;
                    txtName.Text = Information.Medicine.MedName;
                    txtStandard.Text = Information.Medicine.MedStandard;
                    cmbUnits.Text = Information.Medicine.MedUnit;
                    cmbType.SelectedValue = Information.Medicine.MedTypeId;
                    txtMedApproval.Text = Information.Medicine.MedApproval;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan sp = dtpDue.Value.Subtract(dtpProDate.Value);
                AddMedicine addMedicine = new AddMedicine();
                addMedicine.MedID = txtMedId.Text.Trim();
                addMedicine.MedName = txtName.Text.Trim();
                addMedicine.Production = cmbProduce.Text.Trim();
                addMedicine.ProduteDate = dtpProDate.Value;
                addMedicine.DueDate = dtpDue.Value;
                addMedicine.ReleaseDay = Convert.ToInt32(sp.Days);
                addMedicine.Quantity = Convert.ToInt32(numSum.Value);
                addMedicine.MedBid = Convert.ToDecimal(numBid.Text);
                addMedicine.MedUnitPrice = Convert.ToDecimal(numSale.Text.Trim());
                addMedicine.Memary = txtMemary.Text.Trim();
                if (BllMedicine.InsertInMed(addMedicine))
                {
                    MessageBox.Show(@"添加成功！");
                    Information.Medicine = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"添加失败，请检查后重试！");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"需要输入纯数字的地方是否正确输入！"+ ex);
                return;
            }
        }
    }
}
