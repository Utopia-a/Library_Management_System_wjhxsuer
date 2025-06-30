using System.Data;
using System.Windows.Forms;

namespace LibraryDBM
{
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
            showinfo();
        }

        public void showinfo()//显示信息
        {
            string sql = $"select * from t_user where id = '{Info.UID}'";
            DBConnect dBConnect = new DBConnect();
            IDataReader dc = dBConnect.read(sql);
            if (dc.Read())  // <-- 必须有这一步
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


        private void user1_Load(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            test_front user  = new test_front();
            this.Hide();
            user.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
      
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            user2_charge user2_Charge = new user2_charge();
            this.Hide();
            user2_Charge.ShowDialog();
            showinfo();//更新
            this.Show();
        }
    }
}
