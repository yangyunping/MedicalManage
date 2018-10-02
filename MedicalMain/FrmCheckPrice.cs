using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using DAL;

namespace UI
{
    public partial class FrmCheckPrice : Form
    {
        public FrmCheckPrice()
        {
            InitializeComponent();

            DataTable dtCheck = ErpServer.GetConfigInfo(CommonInfo.ConfigStyle.辅助检查.SafeDbValue<int>()).Tables[0];
            cmbCheckStyle.ValueMember = @"SignID";
            cmbCheckStyle.DisplayMember = @"Name";
            cmbCheckStyle.DataSource = dtCheck;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ErpServer.AddExamine(cmbCheckStyle.SelectedValue.ToString(),cmbCheckStyle.Text.Trim(),Convert.ToDecimal(txtPrice.Text.Trim())))
            {
                MessageBox.Show(@"修改保存成功！");
                cmbCheckStyle.SelectedIndex = 0;
            }
        }

        private void cmbCheckStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtCheck = ErpServer.GetExamineInfo($@"  and CheckID = '{cmbCheckStyle.SelectedValue}'").Tables[0];
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
