using Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmMedicine : UserControl
    {
        public FrmMedicine()
        {
            InitializeComponent();
        }

        private void SbtnAddMed_Click(object sender, EventArgs e)
        {
            FrmMedInfo frmMedInfo = new FrmMedInfo()
            {
                Dock = DockStyle.Fill
            };
            CreatNewPag(tsmMedSearch.Text, frmMedInfo);
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
        private void sBtnMedSearch_Click(object sender, EventArgs e)
        {
            FrmStockSearch frmStock = new FrmStockSearch() { Dock = DockStyle.Fill };
            CreatNewPag(tsmMedStockSearch.Text, frmStock);
        }

        private void sbtnCreate_Click(object sender, EventArgs e)
        {
            FrmCreateMed frmCreateMed = new FrmCreateMed();
            frmCreateMed.ShowDialog();
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
                    btnButton.BackColor = SystemColors.GradientInactiveCaption;
                }
            }
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
    }
}
