using CCWin.SkinClass;
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
using static System.Windows.Forms.AxHost;

namespace LibraryDBM
{
    public partial class user_check : UserControl
    {
        private Timer timer;
        public user_check()
        {
            InitializeComponent();
            showinfo();
            Table();

            // Timer: 定时移动
            timer = new Timer();
            timer.Interval = 30; // 速度（ms）
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        public void showinfo()//显示信息
        {

            label1.Text = Info.UID;
            label2.Text = Info.UName;

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

     
        private void Timer_Tick(object sender, EventArgs e)//跑马灯
        {
            uiLabel1.Left -= 2; // 每次向左移动 2 像素

            // 如果完全滚出左边，就重新从右边开始
            if (uiLabel1.Right < 0)
            {
                uiLabel1.Left = uiLabel1.Width;
            }
        }


        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        //还书逻辑，还书前判断是否产生了罚款，若是余额小于罚款，还书失败，否则还书成功
        //规则：一旦借书，就会产生0.1元的借书费用，若是余额不足，还书失败
        private void uiButton8_Click(object sender, EventArgs e)//还书按钮

        {
            string bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            string sql_ = $"SELECT date, rdate FROM t_borrow WHERE bid = '{bid}'";
            string sql = $"delete from t_borrow where bid = '{bid}' ";
            
            
            DBConnect dBConnect = new DBConnect();
            SqlDataReader dc = dBConnect.read(sql_);
            int days = 0;
            
            if (dc.Read())
            {
                DateTime rdate = (DateTime)dc["rdate"];//截止时间
                DateTime ndate = DateTime.Now;
                days = (ndate - rdate).Days;
            }
            else
            {
                throw new Exception("未找到借书记录");
            }

            dc.Close ();

            if (days < 0) days = 1;  // 没逾期，不罚款

            decimal fine = (decimal)days * 0.1m;
            decimal money = Info.money;

            if(fine > money)
            {
                MessageBox.Show("余额不足，无法还书,请充值后重试");
            }

            int n = dBConnect.Execute(sql);
            if (n > 0)
            {
                MessageBox.Show("还书成功");
            }
            else
            {
                MessageBox.Show("系统出错，联系管理员");
            }

            //将新的余额写入数据库
            string sql_1 = $"update t_user set money = money - {fine} where id = '{Info.UID}';";
            dBConnect.Execute(sql_1);
            
            Info.money = money - fine;

            Table();
            dBConnect.DaoClose();
        }



        private void uiPanel1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
           
        }
    }
}
