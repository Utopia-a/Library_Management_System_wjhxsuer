using System.Windows.Forms;

namespace LibraryDBM
{
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        private void admin1_Load(object sender, System.EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, System.EventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
           
        }

        private void ToolStripMenuItem3_Click(object sender, System.EventArgs e)
        {
          
        }

        private void uiButton2_Click(object sender, System.EventArgs e)//图书管理
        {
            admin2 admin = new admin2();
            admin.ShowDialog();
        }

        private void uiButton1_Click(object sender, System.EventArgs e)
        {
            admin1_check admin1_ = new admin1_check();
            this.Hide();
            admin1_.ShowDialog();
            this.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void menuStrip1_BackColorChanged(object sender, System.EventArgs e)
        {

        }
    }
}
