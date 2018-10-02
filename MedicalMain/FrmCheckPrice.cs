using BLL;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmCheckPrice : Form
    {
        BllConfig bllConfig = new BllConfig();
        public FrmCheckPrice()
        {
            InitializeComponent();
            DataTable dtCheck = bllConfig.GetConfigInfo(CommonInfo.ConfigStyle.辅助检查.SafeDbValue<int>()).Tables[0];
            cmbCheckStyle.ValueMember = @"SignID";
            cmbCheckStyle.DisplayMember = @"Name";
            cmbCheckStyle.DataSource = dtCheck;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbCheckStyle.Text.Trim()))
            {
                ExaminePrice examinePrice = new ExaminePrice()
                {
                    CheckID = cmbCheckStyle.SelectedValue.ToString(),
                    CheckName = cmbCheckStyle.Text.Trim(),
                    CheckPrice = Convert.ToDecimal(txtPrice.Text.Trim())
                };
                if (BllExaminePrice.AddExamine(examinePrice))
                {
                    MessageBox.Show(@"修改保存成功！");
                    cmbCheckStyle.SelectedIndex = 0;
                }
            }
        }

        private void cmbCheckStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtCheck = BllExaminePrice.GetExamineInfo().Select($@" CheckID = '{cmbCheckStyle.SelectedValue}'").CopyToDataTable();
            if (dtCheck.Rows.Count > 0)
            {
                txtPrice.Text = dtCheck.Rows[0]["CheckPrice"].ToString();
            }
            else
            {
                txtPrice.Text = @"0.00";
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(null,null);
            }
        }
    }
}
