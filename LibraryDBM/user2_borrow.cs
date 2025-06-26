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
    public partial class user2_borrow : Form
    {
        public user2_borrow()
        {
            InitializeComponent();
            Table();
            showinfo();
        }

        private void user2_borrow_Load(object sender, EventArgs e)
        {
            label7.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        public void showinfo()//显示信息
        {
            string sql = $"select * from t_user where id = '{Info.UID}'";
            DBConnect dBConnect = new DBConnect();
            IDataReader dc = dBConnect.read(sql);
            if (dc.Read())
            {
                label3.Text = dc["money"].ToString();
                label1.Text = Info.UID;
                label2.Text = Info.UName;
            }
            else
            {
                MessageBox.Show("找不到用户信息");
            }
        }


        public void Table()//显示表格
        {
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
            string sql = "select * from t_book";
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


        private void button1_Click(object sender, EventArgs e)//借书按钮
        {



            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//书本id

            
            string stockss = $"select stock from t_book where id = '{id}'";
            DBConnect dBConnect = new DBConnect();
            SqlDataReader dc = dBConnect.read(stockss);

            int stock = 0;
            if (dc.Read())
            {
                stock = (int)dc["stock"];
            }
            else
            {
                MessageBox.Show("未找到该书本");
            }

            dc.Close();


            string moneyss = $"select money from t_user where id = '{Info.UID}'";
            dc = dBConnect.read(moneyss);
            int money = 0;
            if (dc.Read())
            {
                money = (int)dc["money"];
                dc.Close() ;
            }


            string is_borrow = $"select count(*) from t_borrow where uid = '{Info.UID}' and bid = '{id}'";
            dc = dBConnect.read(is_borrow);
            int count = 0;
            if (dc.Read())
            {
                count = (int)dc[0];
                dc.Close() ;
            }

            //---------


            if (stock <= 0)
            {
                MessageBox.Show("库存不足，请联系管理员");
            }
            else if (money <= 0)
            {
                MessageBox.Show("余额不足，请充值");
            }
            else if(count > 0)
            {
                MessageBox.Show("这本书已经借过了");
            }
            else
            {
                // 都满足，执行借书
                string sql_stock = $"update t_book set stock = stock - 1 where id = '{id}'";
                string sql_lend = $"insert into t_borrow(uid,bid,date,rdate) values('{Info.UID}', '{id}', getdate(), DATEADD(DAY, 30, GETDATE()));";

                dBConnect.Execute(sql_stock);
                dBConnect.Execute(sql_lend);
                MessageBox.Show("借书成功！");
                Table();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//每次选中书本显示
        {
            label7.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
        private void button2_Click(object sender, EventArgs e)//借书按钮
        {
            this.Close();
        }
    }
}
