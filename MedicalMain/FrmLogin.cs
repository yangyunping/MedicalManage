using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using UI.Properties;

namespace UI
{
    public partial class FrmLogin : Form
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        private string empID = string.Empty;
        /// <summary>
        /// 鼠标位置
        /// </summary>
        private Point _mousePoint;
        /// <summary>
        /// 最多允许记录的用户名个数
        /// </summary>
        private const int MaxLoginNameSaveCount = 10;
        /// <summary>
        /// 记录的用户名用到的注册表信息键值
        /// </summary>
        private const string RegisterValueName = @"LoginName";
        /// <summary>
        /// 记录的用户名用到的注册表信息路径
        /// </summary>
        private static readonly Registry ResistryKey = new Registry(@"HKEY_CURRENT_USER\software\MedicalManage\");
        public FrmLogin()
        {
            InitializeComponent();
            InitiLogin();
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        private void InitiLogin()
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            picLogo.Image = Resources.MedicalLogo.GetThumbnailImage(picLogo.Width, picLogo.Height, myCallback, IntPtr.Zero);


            this.MouseDown += (sender, e) => _mousePoint = e.Location;
            lblClose.MouseMove += (sender, args) => lblClose.BackColor = Color.Red;
            lblClose.MouseLeave += (sender, args) => lblClose.BackColor = Color.Transparent;
            this.AcceptButton = btnLogin;
            this.MouseMove += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Location = new Point(Location.X + e.X - _mousePoint.X, Location.Y + e.Y - _mousePoint.Y);
                }
            };
            string[] registry = ResistryKey.GetRegistry(RegisterValueName);
            if (null == registry)
            {
                cmbEmpID.Focus();
                return;
            }
            cmbEmpID.Items.AddRange(registry);
            cmbEmpID.SelectedIndex = 0;
            txtPassword.Focus();
        }

        private void FrmLogin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            LinearGradientBrush myBrush = new LinearGradientBrush(ClientRectangle, Color.LightSkyBlue, Color.White, LinearGradientMode.Vertical);
            g.FillRectangle(myBrush, ClientRectangle);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbEmpID.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(@"请输入账号和密码！");
                    return;
                }
                try
                {
                    BllEmployee bllEmployee = new BllEmployee();
                    using (DataTable dsUser = bllEmployee.GetEmployeeInfo(cmbEmpID.Text.Trim()))
                    {
                        if (dsUser == null)
                        {
                            MessageBox.Show(@"工号输入错误或不存在该人员工号！");
                            cmbEmpID.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            cmbEmpID.Focus();
                            return;
                        }
                        if (dsUser.Rows.Count == 0)
                        {
                            MessageBox.Show(@"没有创建该用户！");
                            cmbEmpID.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            cmbEmpID.Focus();
                            return;
                        }
                        if (!dsUser.Rows[0]["DocPassword"].SafeDbValue<string>().Equals(txtPassword.Text))
                        {
                            MessageBox.Show(@"密码错误，请重新输入！");
                            txtPassword.Text = string.Empty;
                            txtPassword.Focus();
                            return;
                        }
                        //保存登录用户信息
                        Information.CurrentUser = dsUser.Rows[0];
                        dsUser.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"数据库无法访问！" + ex.ToString());
                }
                empID = this.cmbEmpID.Text.Trim();
                //记住用户名
                if (chkRemenber.Checked)
                {
                    List<string> lstLoginName = new List<string>
                                            {
                                                    empID
                                            };
                    string[] registry = ResistryKey.GetRegistry(RegisterValueName);
                    if (null != registry)
                    {
                        foreach (string name in registry.TakeWhile(name => lstLoginName.Count < MaxLoginNameSaveCount).Where(name => 0 != StringComparer.CurrentCulture.Compare(empID.ToUpper(), name.ToUpper())))
                            lstLoginName.Add(name);
                    }
                    ResistryKey.SetRegistry(RegisterValueName, lstLoginName.ToArray());
                }

                //用户权限
                DataTable dtPower = BllEmpPower.GetEmpPower(empID);
                for (int i = 0; i < dtPower.Rows.Count; i++)
                {
                    Information.UsePower.Add(Convert.ToInt32(dtPower.Rows[i]["PowerID"]), dtPower.Rows[i]["DocID"].ToString());
                }

                //主界面
                FrmMain frmMain = new FrmMain();
                this.Hide();
                frmMain.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GC.Collect();
                Application.Exit();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
