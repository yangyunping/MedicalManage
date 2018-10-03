using Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmAllServePatInfo : UserControl
    {
        public FrmAllServePatInfo()
        {
            InitializeComponent();
            //权限
            btnServerSearch.Visible = Information.UsePower.ContainsKey(CommonInfo.UserPowers.门诊量查询.SafeDbValue<int>());
        }

        private void btnServePatSearch_Click(object sender, EventArgs e)
        {
            FrmServerPatSearch frmServerpatMed = new FrmServerPatSearch() {Dock = DockStyle.Fill};
            CreatNewPag(btnServePatSearch.Text, frmServerpatMed);
        }

        private void btnNumSearch_Click(object sender, EventArgs e)
        {
            FrmPrescription frmMedOut = new FrmPrescription() {Dock = DockStyle.Fill};
            CreatNewPag(btnServerSearch.Text,frmMedOut);
        }
        private void CreatNewPag(string name, Control control)
        {
            foreach (TabPage tabPage in tbContent.TabPages)
            {
                if (tabPage.Name == name)
                {
                    tbContent.SelectedTab = tabPage;
                    return;
                }
            }
            TabPage tbPage = new TabPage()
            {
                Name = name,
                Text = name,
                Dock = DockStyle.Fill
            };
            tbPage.Controls.Add(control);
            tbContent.TabPages.Add(tbPage);
            tbContent.SelectedTab = tbPage;
        }

        private void tbContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            Point pt = new Point(e.X, e.Y);
            for (int i = 0; i < tbContent.TabCount; i++)
            {
                Rectangle rectangle = tbContent.GetTabRect(i);
                if (rectangle.Contains(pt))
                {
                    TabPage tabPage = tbContent.SelectedTab;
                    int selectIndex = tbContent.SelectedIndex;
                    tbContent.TabPages.Remove(tabPage);
                    if (selectIndex != 0)
                    {
                        tbContent.SelectTab(selectIndex - 1);
                    }
                    return;
                }
            }
        }

        private void trButton_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripButton btnButton in trButton.Items)
            {
                if (btnButton.Text == e.ClickedItem.Text)
                {
                    btnButton.BackColor = Color.BurlyWood;
                }
                else
                {
                    btnButton.BackColor = Color.Transparent;
                }
            }
        }

        private void tsMedBuyInfo_Click(object sender, EventArgs e)
        {
            FrmMedBuyInfo frmMedBuy = new FrmMedBuyInfo() { Dock = DockStyle.Fill };
            CreatNewPag(tsMedBuyInfo.Text, frmMedBuy);
        }
    }
}
