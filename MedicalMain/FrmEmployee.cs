﻿using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MedicalManage
{
    public partial class FrmEmployee : Form
    {
        private readonly string EmpId;
        public FrmEmployee(string empId)
        {
            InitializeComponent();
            EmpId = empId;
            IniteData();
        }

        private void IniteData()
        {
            DataTable dtDuty = BllConfig.GetConfigInfo(Config.ConfigStyle.职称类别.ToString()).Tables[0];
            cmbDuty.DataSource = dtDuty;
            cmbDuty.ValueMember = @"SignID";
            cmbDuty.DisplayMember = @"Name";

            DataTable dtPower = BllConfig.GetConfigInfo(Config.ConfigStyle.用户权限.ToString()).Tables[0];
            for (int i = 0; i < dtPower.Rows.Count; i++)
            {
                twPower.Nodes.Add(dtPower.Rows[i]["SignID"].SafeDbValue<string>(), dtPower.Rows[i]["Name"].SafeDbValue<string>());
            }
            dtPower.Dispose();

            if (string.IsNullOrEmpty(EmpId))
            {
                cmbDuty.SelectedIndex = -1;
            }
            else
            {
                DataTable dtTable = ErpServer.GetEmployeeInfo($@"and DocID ='{EmpId}'").Tables[0];
                if (dtTable.Rows.Count > 0)
                {
                    cmbDuty.SelectedValue = dtTable.Rows[0]["DocDutyID"].SafeDbValue<string>();
                    txtID.Text = dtTable.Rows[0]["DocID"].SafeDbValue<string>();
                    txtName.Text = dtTable.Rows[0]["DocName"].SafeDbValue<string>();
                    txtPassword.Text = dtTable.Rows[0]["DocPassword"].SafeDbValue<string>();
                    txtPhoneNum.Text = dtTable.Rows[0]["DocTel"].SafeDbValue<string>();
                    cmbGender.Text = dtTable.Rows[0]["DocSex"].SafeDbValue<string>();
                    txtAge.Text = dtTable.Rows[0]["DocAge"].SafeDbValue<string>();
                }
                dtTable.Dispose();

                DataRow[] dtEmpPower = ErpServer.GetEmpPower(EmpId).Tables[0].Select();
                foreach (DataRow t in dtEmpPower)
                {
                    foreach (TreeNode treeNode in twPower.Nodes)
                    {
                        if (treeNode.Name == t["PowerID"].SafeDbValue<string>())
                        {
                            treeNode.Checked = true;
                        }
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text) ||  string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(cmbDuty.Text))
            {
                MessageBox.Show(@"请完善人员全部信息！");
                return;
            }
            try
            {
                List<string> lstEmp = (from TreeNode treeNode in twPower.Nodes where treeNode.Checked select treeNode.Name).ToList();
                if (lstEmp.Count==0)
                {
                    MessageBox.Show(@"请勾选该员工的权限后保存！");
                    return;
                }
                ErpServer.DeletePower(txtID.Text);
                if (ErpServer.InsertEmpInfo(txtID.Text, txtName.Text, txtPassword.Text, cmbGender.Text, txtAge.Text, txtPhoneNum.Text,
                    cmbDuty.SelectedValue.ToString(), lstEmp))
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
            tabControl1.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void twPower_AfterSelect(object sender, TreeViewEventArgs e)
        {
            twPower.SelectedNode.Checked = !twPower.SelectedNode.Checked;
        }
    }
}
