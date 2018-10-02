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
    public partial class FrmEmpPassWord : Form
    {
        public FrmEmpPassWord()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!txtNewPass.Text.Equals(txtRetry.Text))
            {
                MessageBox.Show(@"两次输入的密码不一致！");
                return;
            }
            if (ErpServer.UpdatePassWord(txtNewPass.Text,Information.CurrentUser.Id))
            {
                MessageBox.Show(@"修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show(@"修改失败");
            }
        }

        private void txtOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtOldPass.Text.Equals(Information.CurrentUser.PassWord))
                {
                    txtNewPass.Enabled = txtRetry.Enabled = btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show(@"密码错误，请重新输入！");
                }
            }
        }
    }
}
