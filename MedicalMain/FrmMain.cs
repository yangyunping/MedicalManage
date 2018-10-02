using DAL;
using Model;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UI.Properties;

namespace UI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InitiLoad();
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        private void InitiLoad()
        {
            Image.GetThumbnailImageAbort callBack = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            picShow.Image = Resources.MedicalLogo.GetThumbnailImage(picShow.Width, picShow.Height, callBack, IntPtr.Zero);
            this.Closing += (sender, args) => Application.Exit();
            tsmSetting.DropDownOpened += (sender, args) => tsmSetting.ForeColor = Color.Black;
            tsmSetting.DropDownClosed += (sender, args) => tsmSetting.ForeColor = Color.White;
            JsonRead jsonRead = new JsonRead();
            try
            {
                string weatherAddress = CallWebPage.CallWeb("http://www.weather.com.cn/data/cityinfo/101040100.html", 60000, Encoding.UTF8);
                Weather weather = jsonRead.JsonReadInfo(weatherAddress);
                lblWeather.Text ="城市: " +weather.city + "   天气: "+ weather.weather + "   温度: " + weather.temp1+"-" + weather.temp2;
            }
            catch { }

            lblWelcome.Text = @"欢迎 " + Information.CurrentUser.Name +"  "+ Information.CurrentUser.DutyName + "         ";

            //dgvMedInfo.Columns.AddRange(
            //    new DataGridViewTextBoxColumn { Name = @"MedName", DataPropertyName = @"MedName", HeaderText = @"药名", Width = 90 },
            //       new DataGridViewTextBoxColumn { Name = @"Quantity", DataPropertyName = @"Quantity", HeaderText = @"库存", Width = 60 },
            //          new DataGridViewTextBoxColumn { Name = @"DueDate", DataPropertyName = @"DueDate", HeaderText = @"到期时间", Width = 100 }
            //             );
            //dgvMedInfo.AutoGenerateColumns = false;
            DataTable drInMed = ErpServer.GetInMedDataSet(null).Tables[0];
            string MedStock = string.Empty;
            string MedDate = string.Empty;
            DataRow[] rowsStock = drInMed.Select("Quantity <= 30");//库存少于30
            for (int i = 0; i < rowsStock.Length; i++)
            {
                MedStock += ", " + rowsStock[i]["MedName"].ToString();
            }
            DataRow[] rowsDate = drInMed.Select($@"DueDate <= '{DateTime.Now}'");//药品到了保质期
            for (int i = 0; i < rowsStock.Length; i++)
            {
                MedDate += ", " + rowsStock[i]["MedName"].ToString();
            }
            MessageBox.Show("库存少于30的药品："+ MedDate + "\r\n" + "到了保质期的药品："+ MedDate,"提示",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            drInMed.Dispose();
            timer1.Start();
        }

        private void sbtnEmployee_Click(object sender, EventArgs e)
        {
            FrmEmpSearch frmEmpSearch = new FrmEmpSearch()
            {
                Name = sbtnEmployee.Text,
                Text = sbtnEmployee.Text,
                Dock = DockStyle.Fill
            };
            CreatNewPag(sbtnEmployee.Text, frmEmpSearch);
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

        private void sbtnMedicine_Click(object sender, EventArgs e)
        {
            FrmMedicine frmMedicine = new FrmMedicine()
            {
                Name = sbtnMedicine.Text,
                Text = sbtnMedicine.Text,
                Dock = DockStyle.Fill
            };
            CreatNewPag(sbtnMedicine.Text, frmMedicine);
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tsBtnLookPat_Click(object sender, EventArgs e)
        {
            FrmServePat frmServePat = new FrmServePat() { Dock = DockStyle.Fill };
            CreatNewPag(tsBtnLookPat.Text, frmServePat);
        }

        private void btnStaticsSearch_Click(object sender, EventArgs e)
        {
            FrmAllServePatInfo frmAllServePatInfo = new FrmAllServePatInfo() { Dock = DockStyle.Fill };
            CreatNewPag(btnStaticsSearch.Text, frmAllServePatInfo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }

        private void btnPations_Click(object sender, EventArgs e)
        {
            FrmPations frmPations = new FrmPations() { Dock = DockStyle.Fill };
            CreatNewPag(btnPations.Text, frmPations);
        }

        private void 要素设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.ShowDialog();
        }

        private void 基础设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.ShowDialog();
        }

        private void 检查费调整ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCheckPrice frmCheckPrice = new FrmCheckPrice();
            frmCheckPrice.ShowDialog();
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpPassWord frmEmpPassWord = new FrmEmpPassWord();
            frmEmpPassWord.ShowDialog();
        }

        private void tsButtons_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem item in tsButtons.Items)
            {
                item.BackColor = Color.Transparent;
            }
            if (!e.ClickedItem.Text.Equals("设置"))
            {
                e.ClickedItem.BackColor = Color.BurlyWood;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text ="  时间:"+ DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            //lblTime.Invoke(new Action(()=>
            //    {
            //        lblTime.Text = DateTime.Now.ToLongTimeString();
            //    }
            //    ));
        }

        private void tsmThemes_Click(object sender, EventArgs e)
        {
            FrmSkinChange frmSkinChange = new FrmSkinChange()
            {
                Name = tsmThemes.Text,
                Text = tsmThemes.Text,
                Dock = DockStyle.Fill
            };
            CreatNewPag(tsmThemes.Text, frmSkinChange);
        }
    }
}
