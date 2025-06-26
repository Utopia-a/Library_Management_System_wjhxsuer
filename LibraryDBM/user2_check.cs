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
    public partial class user2_check : Form
    {
        public user2_check()
        {
            InitializeComponent();
            Table();
            showinfo();
     
        }

        public void Table()//显示表格
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

        public void showinfo()//显示信息
        {
          
                label1.Text = Info.UID;
                label2.Text = Info.UName;

        }

        private void user2_check_Load(object sender, EventArgs e)
        {
            string sql = $"SELECT COUNT(*) FROM t_borrow;";
            DBConnect dBConnect = new DBConnect();
            SqlDataReader dc = dBConnect.read(sql);
            int count = 0;
            if (dc.Read())
            {
                count = (int)dc[0];
            }

            if (count != 0 && dataGridView1.SelectedRows.Count > 0)//当借书表中没有记录，特殊处理
            {
                dataGridView1.Rows[0].Selected = true; // 自动选中第一行
                var row = dataGridView1.SelectedRows[0];
                if (row.Cells.Count >= 2)
                {
                    label7.Text = row.Cells[0].Value.ToString() + row.Cells[1].Value.ToString();
                }
            }

            dBConnect.DaoClose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string sql = $"delete from t_borrow where bid = '{id}' ";
            DBConnect dBConnect = new DBConnect();
            int n = dBConnect.Execute(sql);

            // string sql2 = $"update t_book set stock = stock + 1 where id = '{id}'";
            //n += dBConnect.Execute(sql2);

            if (n > 0)
            {
                MessageBox.Show("还书成功");
            }
            else
            {
                MessageBox.Show("系统出错，联系管理员");
            }
            Table();
            dBConnect.DaoClose();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
