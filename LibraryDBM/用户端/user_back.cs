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
    public partial class user_back : UserControl
    {
        public user_back()
        {
            InitializeComponent();
            Table();
            Label2.Text = "[ 欢迎 " + Info.UName + " 登录系统 ]";
        }
        public void Table()//显示表格
        {
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
            string sql = "select * from vw_book_info";
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
        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
