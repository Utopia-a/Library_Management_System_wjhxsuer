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
    public partial class admin2_alter : Form
    {
       
        public admin2_alter()
        {
            InitializeComponent();
        }
        public admin2_alter(string id,string name,string author,string press,string stock)
        {
            InitializeComponent();
        
            label6.Text = id;
            label7.Text = name;
            label8.Text = author;
            label9.Text = press;
            label10.Text = stock;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {

                string sql = $"update t_book set id = '{textBox1.Text}', [name] = '{textBox2.Text}', author = '{textBox3.Text}' , press = '{textBox4.Text}',stock = {textBox5.Text} where id = '{label6.Text}'";
                DBConnect dBConnect = new DBConnect();
                int n = dBConnect.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
                else MessageBox.Show("修改失败，重新输入");


            }
            else
            {
                MessageBox.Show("修改值不能为空");
            }
        }

        private void admin2_alter_Load(object sender, EventArgs e)
        {
         
        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

    }
}
