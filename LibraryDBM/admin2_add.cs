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
    public partial class admin2_add : Form
    {
        
        public admin2_add()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                string sql = $"insert into t_book(id, name, author, press, stock) values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}',{textBox5.Text})";
                DBConnect dBConnect = new DBConnect();
                int n = dBConnect.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功");

                }
                else MessageBox.Show("添加失败，重新输入");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                this.Close();
            }
            else MessageBox.Show("不能有空值");
           


        }

        private void admin2_add_Load(object sender, EventArgs e)
        {

        }
    }
}
