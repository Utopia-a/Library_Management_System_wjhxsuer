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
    public partial class admin1_check : Form
    {
        public admin1_check()
        {
            InitializeComponent();
            
        }

        public void Table()//显示表格
        {
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
            string sql = $"SELECT bid, name, author, press, rdate from t_borrow,t_book where uid = '{textBox1.Text}' and (t_borrow.bid = t_book.id)";
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


        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();

            string id = textBox1.Text.Trim(); 

            DBConnect dBConnect = new DBConnect();
            string sql = $"SELECT count(*) FROM t_borrow WHERE uid = '{textBox1.Text}'";
            IDataReader dc = dBConnect.read(sql);


            if (dc.Read())
            {
                int count = (int)dc[0];
                label6.Text = "借阅数量：" + count.ToString();
            }

            string sql2 = $"SELECT id, name, money FROM t_user WHERE id = '{textBox1.Text}'";
            dc = dBConnect.read(sql2);

            if (dc.Read())
            {
                label7.Text = "用户号：" + dc["id"].ToString();
                label8.Text = "姓名：" + dc["name"].ToString();
                label9.Text = "余额：" + dc["money"].ToString() + " 元";
            }
            else
            {
                MessageBox.Show("未找到该用户！");
            }
            dc.Close();


            string sql3 = $"EXEC dbo.sp_GetBorrowInfoByUserId @UserId = '{id}';";
            dc = dc = dBConnect.read(sql3);
            string a0, a1, a2, a3, a4;
            while (dc.Read())
            {
                a0 = dc["UserName"].ToString();
                a1 = dc["BookName"].ToString();
                a2 = dc["BorrowDate"].ToString();
                a3 = dc["ReturnDate"].ToString();
                a4 = dc["Fine"].ToString();

                string[] table = { a0, a1, a2, a3, a4 };
                dataGridView1.Rows.Add(table);

            }

        }

        private void admin1_check_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
