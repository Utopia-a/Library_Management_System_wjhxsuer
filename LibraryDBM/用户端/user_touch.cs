using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBM
{
    public partial class user_touch : UserControl
    {
        public user_touch()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.微信名片;
            pictureBox2.Image = Properties.Resources.收款码;
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
