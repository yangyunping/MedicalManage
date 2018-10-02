using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmSkinChange : UserControl
    {
        public FrmSkinChange()
        {
            InitializeComponent();

        }

        private void lstbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sunisoft.IrisSkin.SkinEngine skinEngine = new Sunisoft.IrisSkin.SkinEngine();
        }
    }
}
