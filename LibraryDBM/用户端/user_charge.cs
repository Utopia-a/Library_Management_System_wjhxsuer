using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBM
{
    public partial class user_charge : UserControl
    {
        private Timer timer;
        public user_charge()
        {
            InitializeComponent();

            // Timer: 定时移动
            timer = new Timer();
            timer.Interval = 30; // 速度（ms）
            timer.Tick += Timer_Tick;
            timer.Start();
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

        private void uiButton2_Click_1(object sender, EventArgs e)
        {
            decimal money;
            if (!decimal.TryParse(textBox1.Text.Trim(), out money) || money <= 0)//第一个函数是检查textbox中的数字的合法性
            {
                MessageBox.Show("请输入有效的正数金额！");
                return;
            }

            string sql = "update t_user set money = money + @money where id = @id";
            DBConnect dBConnect = new DBConnect();
            SqlConnection conn = dBConnect.connect();


            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@money", money);
            cmd.Parameters.AddWithValue("@id", Info.UID);


            int n = cmd.ExecuteNonQuery();

            if (n > 0)
            {
                MessageBox.Show("充值成功");
            }
            else
            {
                MessageBox.Show("充值失败");
            }
        }
    }
}
