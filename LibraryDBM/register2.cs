using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryDBM
{
    public partial class register2 : Form
    {
        public register2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("不能存在空值");
            }
            else
            {
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("两次输入密码不同");
                }
                else
                {
                    string sql = $"insert into t_admin (id, password) values ('{textBox1.Text}','{textBox2.Text}');";
                    DBConnect dBConnect = new DBConnect();
                    int n = dBConnect.Execute(sql);
                    if (n > 0)
                    {
                        MessageBox.Show("注册成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("系统bug，联系管理员");
                    }
                }
            }
        }
    }
}