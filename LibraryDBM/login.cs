using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBM
{
    public partial class login : Form
    {
       
        public login()
        {
            InitializeComponent();
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("用户名或者密码不能为空");
            }
        }

        public void Login()
        {
            //用户
            if (radioButtonUser.Checked == true)
            {
                DBConnect dBConnect = new DBConnect();
                string sql = $"select * from t_user where id = '{textBox1.Text}'and password='{textBox2.Text}'";
                IDataReader dc = dBConnect.read(sql);
                if (dc.Read())
                {
                    Info.UID = dc["id"].ToString();
                    Info.UName = dc["name"].ToString();


                    MessageBox.Show("登录成功");
                   
                    user_front user = new user_front();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                    dc.Close();

                }
                else
                {
                    MessageBox.Show("用户名或者密码输入有误");
                }
                dBConnect.DaoClose();
            }

            //管理员端口的进入
            if (radioButtonAdmin.Checked == true)
            {
                DBConnect dBConnect = new DBConnect();
                string sql = $"select * from t_admin where id = '{textBox1.Text}'and password='{textBox2.Text}'";
                IDataReader dc = dBConnect.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    admin1 admin = new admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("用户名或者密码输入有误");
                }
                dBConnect.DaoClose();
            }
        }

        private void button3_Click(object sender, EventArgs e)//注册
        {
            if (radioButtonAdmin.Checked == true) 
            { 
                register2 register21 = new register2();
                this.Hide();
                register21.ShowDialog();
                register21.Close();
                this.Show();
            }
            else
            {
                register register12 = new register();
                this.Hide();
                register12.ShowDialog();
                this.Show();

            }
        }
        private void login_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Properties.Resources.西安石油大学logo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
