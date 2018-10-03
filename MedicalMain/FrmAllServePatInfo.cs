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

namespace UI
{
    public partial class FrmAllServePatInfo : UserControl
    {
        public FrmAllServePatInfo()
        {
            InitializeComponent();
            //btnNumSearch.Visible = Information.UsePower.ContainsKey(CommonInfo.UserPowers.高级权限.SafeDbValue<int>());
        }

        private void btnServePatSearch_Click(object sender, EventArgs e)
        {
            FrmServerpatMed frmServerpatMed = new FrmServerpatMed() {Dock = DockStyle.Fill};
            CreatNewPag(btnServePatSearch.Text, frmServerpatMed);
        }

        private void btnNumSearch_Click(object sender, EventArgs e)
        {
            FrmPrescription frmMedOut = new FrmPrescription() {Dock = DockStyle.Fill};
            CreatNewPag(btnNumSearch.Text,frmMedOut);
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
