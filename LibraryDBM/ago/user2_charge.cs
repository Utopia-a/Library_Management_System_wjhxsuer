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
    public partial class user2_charge : Form
    {
        public user2_charge()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_user set money = money + {textBox1.Text} where id = '{Info.UID}'";
            DBConnect dBConnect = new DBConnect();
            int n = dBConnect.Execute(sql);
            if(n > 0)
            {
                MessageBox.Show("充值成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("充值失败");
            }

        }

        private void user2_charge_Load(object sender, EventArgs e)
        {

        }
    }
}
