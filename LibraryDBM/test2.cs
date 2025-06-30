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
    public partial class test2 : Form
    {
        public test2()
        {
            InitializeComponent();
        }



        public void Table1(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
            string sql = "select * from view_book";
            IDataReader dc = dBConnect.read(sql);
            while (dc.Read())
            {
                string a0 = dc[0].ToString();
                string a1 = dc[1].ToString();
                string a2 = dc[2].ToString();
                string a3 = dc[3].ToString();
                string a4 = dc[4].ToString();

                string[] table = { a0, a1, a2, a3, a4 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
        }
        public void Table2(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
            string sql = $"SELECT bid, name, author, press, rdate from t_borrow,t_book where uid = '{Info.UID}' and (t_borrow.bid = t_book.id)";
            IDataReader dc = dBConnect.read(sql);
            string a0, a1, a2, a3, a4;
            while (dc.Read())
            {
                a0 = dc["bid"].ToString();
                a1 = dc["name"].ToString();
                a2 = dc["author"].ToString();
                a3 = dc["press"].ToString();
                a4 = dc["rdate"].ToString();

                string[] table = { a0, a1, a2, a3, a4 };
                dataGridView1.Rows.Add(table);

            }
            dc.Close();
        }


        private void uiButton1_Click(object sender, EventArgs e)
        {
      
        }
        private void uiUserControl1_Click(object sender, EventArgs e)
        {

        }

      


        private void test2_Load(object sender, EventArgs e)
        {

        }




        private void uiButton8_Click_1(object sender, EventArgs e)
        {
           
            UserControl1 uc1 = new UserControl1();
            uc1.Dock = DockStyle.Fill;

            uiPanel2.Controls.Clear();
            uiPanel2.Controls.Add(uc1);
        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {
 
        }

        private void uiPanel2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
