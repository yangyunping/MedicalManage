using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Model;

namespace UI
{
    public partial class FrmMedBuyInfo : UserControl
    {
        public FrmMedBuyInfo()
        {
            InitializeComponent();
            DgvColumns();

            //权限
           btnSearch.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.购买查询.SafeDbValue<int>());
        }

        private void DgvColumns()
        {
            dgvShow.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"ID", DataPropertyName = @"ID", HeaderText = @"编号",Width = 60},
                 new DataGridViewTextBoxColumn { Name = @"OperType", DataPropertyName = @"OperType", HeaderText = @"操作类型", Width = 100 },
                  new DataGridViewTextBoxColumn { Name = @"Notes", DataPropertyName = @"Notes", HeaderText = @"详细记录", Width = 500 },
                   new DataGridViewTextBoxColumn { Name = @"DocID", DataPropertyName = @"DocID", HeaderText = @"操作人ID", Width = 100 },
                    new DataGridViewTextBoxColumn { Name = @"DocName", DataPropertyName = @"DocName", HeaderText = @"操作人", Width = 100 },
                     new DataGridViewTextBoxColumn { Name = @"OperateTime", DataPropertyName = @"OperateTime", HeaderText = @"操作时间", Width = 150 }
                );
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = string.Empty;
            if (chkDate.Checked)
            {
                sSql += $@" and (DATEDIFF(dd,OperateTime,'{dtpBegin.Value}')<=0 and DATEDIFF(dd,OperateTime,'{dtpEnd.Value}')>=0)";
            }
            if (chkInMed.Checked)
            {
                sSql += $@" and  OperType = '药品进货'";
            }
            dgvShow.AutoGenerateColumns = false;
            DataTable dtMedIndo = ErpServer.GetMedBuyInfo(sSql).Tables[0];
            dgvShow.DataSource = dtMedIndo;
            lblSum.Text = "总数：" + dtMedIndo.Rows.Count;
            dtMedIndo.Dispose();
        }
    }
}
