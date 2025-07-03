using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBM
{
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            Table();
            dataGridView1.Rows[0].Selected = true; // 自动选中第一行
         
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
        public void Table()//显示表格
        {
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
            string sql = "select * from vw_book_info";
            IDataReader dc = dBConnect.read(sql);
            string a0,a1,a2,a3,a4;  
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
            dBConnect.DaoClose();
        }

        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            admin2_add admin = new admin2_add();
            admin.ShowDialog();
            Table();

        }

        //刷新
        private void button4_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        //删除

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认要删除吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_book where id = '{id}'";
                    DBConnect dBConnect = new DBConnect();
                    if (dBConnect.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else 
                    {
                        MessageBox.Show("删除失败" + sql);

                    }
                    dBConnect.DaoClose();
                }
                
            }
            catch 
            { 
                MessageBox.Show("请先选中要删除的书本","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //修改图书
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string press = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string stock = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                admin2_alter ad = new admin2_alter( id, name, author, press, stock);
                ad.ShowDialog();
                Table();

            }
            catch
            {
                MessageBox.Show("ERROR");
            }
           
        }
        //书号查询
        private void button5_Click(object sender, EventArgs e)
        {
            string sql = $"select * from t_book where id = '{textBox1.Text}'";
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
            IDataReader dc = dBConnect.read(sql);
            string a0,a1,a2,a3,a4;
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
            dBConnect.DaoClose();
        }
        //书名查询
        private void button6_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM t_book WHERE name LIKE '%{textBox2.Text}%'";
            dataGridView1.Rows.Clear();
            DBConnect dBConnect = new DBConnect();
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
            dBConnect.DaoClose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
