using DAL;
using Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UI.Properties;

namespace UI
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 配置文件存放路径
        /// </summary>
        private readonly string _configPath = Application.StartupPath + @"\\" + @"Config.ini";
        public FrmMain()
        {
            InitializeComponent();
            InitiData();
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        private void InitiData()
        {
            try
            {
                //主界面控件各类事件
                Image.GetThumbnailImageAbort callBack = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                picShow.Image = Resources.MedicalLogo.GetThumbnailImage(picShow.Width, picShow.Height, callBack, IntPtr.Zero);
                this.Closing += (sender, args) => Application.Exit();
                tsmSettingMenues.DropDownOpened += (sender, args) => tsmSettingMenues.ForeColor = Color.Black;
                tsmSettingMenues.DropDownClosed += (sender, args) => tsmSettingMenues.ForeColor = Color.White;

                //权限
              // btnPations.Enabled = tsBtnLookPat.Enabled = sbtnMedicine.Enabled  = Information.UsePower.ContainsKey(CommonInfo.UserPowers.一般权限.SafeDbValue<int>());
              // tsmCheckSetting.Enabled = tsmSetting.Enabled = Information.UsePower.ContainsKey(CommonInfo.UserPowers.高级权限.SafeDbValue<int>());

                //加载底部信息栏
                JsonRead jsonRead = new JsonRead();
                try
                {
                    string weatherAddress = CallWebPage.CallWeb("http://www.weather.com.cn/data/cityinfo/101040100.html", 60000, Encoding.UTF8);
                    Weather weather = jsonRead.JsonReadInfo(weatherAddress);
                    lblWeather.Text = "城市: " + weather.city + "   天气: " + weather.weather + "   温度: " + weather.temp1 + "-" + weather.temp2;
                }
                catch { }
                lblWelcome.Text = @"欢迎 " + Information.CurrentUser.Name + "  " + Information.CurrentUser.DutyName + "         ";

                //提示到期、库存少的药品
                DataTable drInMed = ErpServer.GetInMedDataSet(null).Tables[0];
                string StockMedicines = string.Empty;
                string DueDateMedicines = string.Empty;
                DataRow[] rowsStock = drInMed.Select("Quantity <= 30");//库存少于30
                for (int i = 0; i < rowsStock.Length; i++)
                {
                    StockMedicines += ", " + rowsStock[i]["MedName"].ToString();
                }
                DataRow[] rowsDate = drInMed.Select($@"DueDate <= '{DateTime.Now}'");//药品到了保质期
                for (int i = 0; i < rowsStock.Length; i++)
                {
                    DueDateMedicines += ", " + rowsStock[i]["MedName"].ToString();
                }
                string medicinesInfo = string.Empty;
                if (!string.IsNullOrEmpty(DueDateMedicines))
                {
                    medicinesInfo += "库存少于30的药品：" + DueDateMedicines;
                }
                if (!string.IsNullOrEmpty(DueDateMedicines))
                {
                    medicinesInfo += "\r\n" + "到了保质期的药品：" + DueDateMedicines;
                }
                if (!string.IsNullOrEmpty(medicinesInfo))
                {
                    MessageBox.Show(medicinesInfo, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                drInMed.Dispose();


                //时间实时刷新
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("主界面初始化数据加载失败！"+ex.ToString());
            }
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
        /// <summary>
        /// 在TabPage加载指定界面
        /// </summary>
        /// <param name="name"></param>
        /// <param name="control"></param>
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
        /// <summary>
        /// 双击关闭当前TabPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            FrmPationsSearch frmPations = new FrmPationsSearch() { Dock = DockStyle.Fill };
            CreatNewPag(btnPations.Text, frmPations);
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
        /// <summary>
        /// 时间实时刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text ="  时间:"+ DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
        }

        private void tsmThemes_Click(object sender, EventArgs e)
        {
            pnlThemes.Visible = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                string skinPath = Application.StartupPath + @"\Skins";
                lstbThemes.DataSource = new DirectoryInfo(skinPath).GetFiles();
                lstbThemes.DisplayMember = "Name";
                //加载皮肤
                StringBuilder selectOrder = new StringBuilder(255);
                Information.GetPrivateProfileString("SkinPath", "SkinPathValue", " ", selectOrder, 255,
                    _configPath);
                if (!string.IsNullOrEmpty(selectOrder.ToString()))
                {
                    string skinName = selectOrder.ToString();
                    skinEngine.SkinFile = skinName;
                    skinEngine.SkinAllForm = true;
                    skinEngine.DisableTag = 9999;
                }
                else
                {
                    skinEngine.Active = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 主题皮肤切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbThemes.SelectedItem != null)
            {
                skinEngine.SkinFile = (lstbThemes.SelectedItem as FileInfo).FullName;
                skinEngine.Active = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string skinType = (lstbThemes.SelectedItem as FileInfo).FullName;
            if (!string.IsNullOrEmpty(skinType))
            {
                Information.WritePrivateProfileString("SkinPath", "SkinPathValue", skinType, _configPath);
                pnlThemes.Visible = false;
            }
        }

        private void btnCloseTheme_Click(object sender, EventArgs e)
        {
            pnlThemes.Visible = false;
        }
        /// <summary>
        /// 恢复默认主题皮肤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemeOrigal_Click(object sender, EventArgs e)
        {
            skinEngine.Active = false;
            Information.WritePrivateProfileString("SkinPath", "SkinPathValue", null, _configPath);
        }
    }
}
