using CCWin.SkinClass;
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
    public partial class user_front : Form
    {
        public user_front()
        {
            InitializeComponent();
            getinfo();
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

        //为后续的读者卡信息做准备
        private void getinfo()
        {
            string sql1 = $"select * from t_user where id = '{Info.UID}'";
            string sql2 = $"select count(*) from t_borrow where uid = '{Info.UID}'";
            DBConnect dBConnect = new DBConnect();
            SqlDataReader dc = dBConnect.read(sql1);
            if (dc.Read())
            {
                Info.sex = dc["sex"].ToString();
                Info.money = Convert.ToDecimal(dc["money"]);
            }
            dc.Close();

            dc = dBConnect.read(sql2);
            if (dc.Read())
            {
                Info.bookNum = dc[0].ToInt32();
            }

           
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


        private void uiButton2_Click(object sender, EventArgs e)//借书功能
        {
            UserControl1 uc1 = new UserControl1();
            uc1.Dock = DockStyle.Fill;
            uiPanel3.Controls.Clear();
            uiPanel3.Controls.Add(uc1);
        }

        private void uiButton1_Click(object sender, EventArgs e)//还书
        {
            user_check uc1 = new user_check();
            uc1.Dock = DockStyle.Fill;
            uiPanel3.Controls.Clear();
            uiPanel3.Controls.Add(uc1);
        }

        private void uiButton8_Click(object sender, EventArgs e)//首页
        {
            user_back uc1 = new user_back();
            uc1.Dock = DockStyle.Fill;

            uiPanel3.Controls.Clear();
            uiPanel3.Controls.Add(uc1);
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void uiButton7_Click(object sender, EventArgs e)//读者卡
        {
            user_info uc1 = new user_info();
            uc1.Dock = DockStyle.Fill;

            uiPanel3.Controls.Clear();  
            uiPanel3.Controls.Add(uc1);
        }

        private void uiButton4_Click(object sender, EventArgs e)//充值
        {
            user_charge uc1 = new user_charge();
            uc1.Dock = DockStyle.Fill;

            uiPanel3.Controls.Clear();
            uiPanel3.Controls.Add(uc1);
        }

        private void uiButton5_Click(object sender, EventArgs e)//联系管理员
        {
            user_touch uc1 = new user_touch();
            uc1.Dock = DockStyle.Fill;

            uiPanel3.Controls.Clear();
            uiPanel3.Controls.Add(uc1);
        }

        private void uiButton6_Click(object sender, EventArgs e)//修改密码
        {
            user_change uc1 = new user_change();
            uc1.Dock = DockStyle.Fill;

            uiPanel3.Controls.Clear();
            uiPanel3.Controls.Add(uc1);
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
