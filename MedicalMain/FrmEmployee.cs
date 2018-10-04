using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmEmployee : Form
    {
        BllConfig bllConfig = new BllConfig();
        BllEmployee bllEmployee = new BllEmployee();
        BllEmpPower bllEmpPower = new BllEmpPower();
        public FrmEmployee(Doctor doctor)
        {
            InitializeComponent();
            txtID.Enabled = false;
            cmbDuty.SelectedValue = doctor.DutyId;
            txtID.Text = doctor.Id;
            txtName.Text = doctor.Name;
            txtPassword.Text = doctor.PassWord;
            txtPhoneNum.Text = doctor.PhoneNumber;
            cmbGender.Text = doctor.Gender;
            txtAge.Text = doctor.DocAge;
            IniteData();//初始化数据
            twPower.ExpandAll();
        }
        public FrmEmployee()
        {
            InitializeComponent();
            IniteData();//初始化数据
            twPower.ExpandAll();
        }
        private void IniteData()
        {
            try
            {
                DataTable dtDuty = bllConfig.GetConfigInfo(CommonInfo.ConfigStyle.职称类别.SafeDbValue<int>()).Tables[0];
                cmbDuty.DataSource = dtDuty;
                cmbDuty.ValueMember = @"SignID";
                cmbDuty.DisplayMember = @"Name";

                DataTable dtPower = bllConfig.GetConfigInfo(CommonInfo.ConfigStyle.用户权限.SafeDbValue<int>()).Tables[0];
                for (int i = 0; i < dtPower.Rows.Count; i++)//第一级
                {
                    TreeNode treeNode = new TreeNode()
                    {
                        Name = dtPower.Rows[i]["SignID"].SafeDbValue<string>(),
                        Text = dtPower.Rows[i]["Name"].SafeDbValue<string>()
                    };
                    DataTable dtPower1 = bllConfig.GetConfigInfo(dtPower.Rows[i]["SignID"].SafeDbValue<int>()).Tables[0];
                    for (int j = 0; j < dtPower1.Rows.Count; j++)//第二级
                    {
                        TreeNode treeNode1 = new TreeNode()
                        {
                            Name = dtPower1.Rows[j]["SignID"].SafeDbValue<string>(),
                            Text = dtPower1.Rows[j]["Name"].SafeDbValue<string>()
                        };
                        DataTable dtPower2 = bllConfig.GetConfigInfo(dtPower1.Rows[j]["SignID"].SafeDbValue<int>()).Tables[0];
                        for (int h = 0; h < dtPower2.Rows.Count; h++)//第三级
                        {
                            treeNode1.Nodes.Add(dtPower2.Rows[i]["SignID"].SafeDbValue<string>(), dtPower2.Rows[i]["Name"].SafeDbValue<string>());
                        }
                        treeNode.Nodes.Add(treeNode1);
                        dtPower2.Dispose();
                    }
                    twPower.Nodes.Add(treeNode);
                    dtPower1.Dispose();
                }
                dtPower.Dispose();

                if (!string.IsNullOrEmpty(txtID.Text.Trim()))
                {
                    //勾选员工已有的权限
                    DataTable dtPowerInfo = bllEmpPower.GetEmpPower(txtID.Text.Trim());
                    Dictionary<string, string> keyValues = new Dictionary<string, string>();
                    foreach (DataRow row in dtPowerInfo.Rows)
                    {
                        keyValues.Add(row["PowerID"].ToString(), row["DocID"].ToString());
                    }
                    foreach (TreeNode treeNode in twPower.Nodes)
                    {
                        //if (keyValues.ContainsKey(treeNode.Name))
                        //{
                        //    treeNode.Checked = true;
                        //}
                        foreach (TreeNode item in treeNode.Nodes)
                        {
                            if (keyValues.ContainsKey(item.Name))
                            {
                                item.Checked = true;
                            }
                            foreach (TreeNode item1 in item.Nodes)
                            {
                                if (keyValues.ContainsKey(item1.Name))
                                {
                                    item1.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveEmp()
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text) ||  string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(cmbDuty.Text))
            {
                MessageBox.Show(@"请完善人员全部信息！");
                return;
            }
            try
            {

                List<EmpPower> lstEmp = new List<EmpPower>();
                foreach (TreeNode treeNode in twPower.Nodes)//第一级节点
                {
                    if (treeNode.Checked)
                    {
                        EmpPower empPowers = new EmpPower();
                        empPowers.DocID = txtID.Text.Trim();
                        empPowers.PowerID = treeNode.Name;
                        lstEmp.Add(empPowers);
                    }
                    foreach (TreeNode item in treeNode.Nodes)//第二级节点
                    {
                        if (item.Checked)
                        {
                            EmpPower empPowers = new EmpPower();
                            empPowers.DocID = txtID.Text.Trim();
                            empPowers.PowerID = item.Name;
                            lstEmp.Add(empPowers);
                        }
                        foreach (TreeNode item1 in item.Nodes)//第三级节点
                        {
                            if (item1.Checked)
                            {
                                EmpPower empPowers = new EmpPower();
                                empPowers.DocID = txtID.Text.Trim();
                                empPowers.PowerID = item1.Name;
                                lstEmp.Add(empPowers);
                            }
                        }
                    }
                }
                if (lstEmp.Count==0)
                {
                    MessageBox.Show(@"请勾选该员工的权限后保存！");
                    return;
                }
                ErpServer.DeletePower(txtID.Text);//删除权限
                Doctor doctor = new Doctor();
                doctor.Id = txtID.Text;
                doctor.Name = txtName.Text;
                doctor.PassWord = txtPassword.Text;
                doctor.Gender = cmbGender.Text;
                doctor.DocAge = txtAge.Text;
                doctor.PhoneNumber = txtPhoneNum.Text;
                doctor.DutyId = cmbDuty.SelectedValue.ToString();
                if (ErpServer.InsertEmpInfo(doctor, lstEmp))
                {
                    MessageBox.Show(@"保存成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"保存失败，检查后重试！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"年龄、电话号码都为纯数字，请检查!" + ex);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEmp();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void twPower_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (twPower.SelectedNode != null )
            {
                twPower.SelectedNode.Checked = !twPower.SelectedNode.Checked;
            }
        }
        /// <summary>
        /// 勾选父级别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twPower_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                foreach (TreeNode item in e.Node.Nodes)
                {
                    item.Checked = e.Node.Checked;
                }
                //if (e.Node.Parent != null)
                //{
                //    if (!e.Node.Parent.Checked)
                //    {
                //        foreach (TreeNode item in e.Node.Parent.Nodes)
                //        {
                //            if (!item.Checked)
                //            {
                //                return;
                //            }
                //        }
                //        e.Node.Parent.Checked = true;
                //    }
                //    else
                //    {
                //        foreach (TreeNode item in e.Node.Parent.Nodes)
                //        {
                //            if (!item.Checked)
                //            {
                //                e.Node.Parent.Checked = false;
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
