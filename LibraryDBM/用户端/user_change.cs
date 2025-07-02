using CCWin;
using Sunny.UI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryDBM
{
    public partial class user_change : UserControl
    {
        public user_change()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.修改密码;
        }

        private async void uiButton2_Click(object sender, EventArgs e)
        {
            string password = null;
            DBConnect dBConnect1 = new DBConnect();
            string sql1 = $"select * from t_user where id = '{Info.UID}'";
            SqlDataReader dc = dBConnect1.read(sql1);
            if (dc.Read())
            {
                password = dc["password"].ToString().Trim();
            }

            MessageBox.Show(password);

            if (uiTextBox1.Text == "" || uiTextBox2.Text == "" || uiTextBox3.Text == "")
            {
                MessageBox.Show("不能存在空值");
            }
            else
            {
                if (uiTextBox2.Text != uiTextBox3.Text)
                {
                    MessageBox.Show("两次输入密码不同");
                }
                else if(password != uiTextBox1.Text)
                {
                    MessageBox.Show("旧密码错误，请检查后重试");
                }
                else
                {
                    string sql = $"UPDATE t_user SET password = '{uiTextBox2.Text}' WHERE id = '{Info.UID}'; ";
                    DBConnect dBConnect = new DBConnect();
                    int n = dBConnect.Execute(sql);
                    if (n > 0)
                    {
                        ToastForm toast = new ToastForm("修改成功！3秒后自动返回登录");
                        toast.Show();
                        await Task.Delay(3000);
                        login newForm = new login();
                        newForm.Show();

                        Application.Restart();
                    }
                    else
                    {
                        MessageBox.Show("系统bug，联系管理员");
                    }
                }

            }
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
