using CCWin.SkinClass;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBM
{
    public partial class user_info : UserControl
    {
        public user_info()
        {
            InitializeComponent();
        }

        private void user_info_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Properties.Resources.下载;
            label1.Text = Info.UID;
            label2.Text = Info.UName;
            label3.Text = Info.sex;
            label4.Text = Info.money.ToString();
            label5.Text = Info.bookNum.ToString();
        }
        
        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
