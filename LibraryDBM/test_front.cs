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
    public partial class test_front : Form
    {
        public test_front()
        {
            InitializeComponent();

        }

     
        public void Table()//显示表格
        {
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
            string sql = "select * from view_book";
            IDataReader dc = dBConnect.read(sql);
            string a0, a1, a2, a3, a4;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();

                string[] table = { a0, a1, a2, a3, a4 };
                dataGridView1.Rows.Add(table);

            }
            dc.Close();
        }


        private void test_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Properties.Resources.图书;
            Table();
            Label2.Text = "[ 欢迎 " + Info.UName + " 登录系统 ]";
        }//

        private void uiTableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void uiButton2_Click(object sender, EventArgs e)//借书功能实现函数
        {
            UserControl1 uc1 = new UserControl1();
            uc1.Dock = DockStyle.Fill;

            uiPanel3.Controls.Clear();
            uiPanel3.Controls.Add(uc1);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
      
        }

        private void uiButton8_Click(object sender, EventArgs e)
        {
            user_back uc1 = new user_back();
            uc1.Dock = DockStyle.Fill;

            uiPanel3.Controls.Clear();
            uiPanel3.Controls.Add(uc1);
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
