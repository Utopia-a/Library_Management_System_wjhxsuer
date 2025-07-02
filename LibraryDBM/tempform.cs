using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryDBM
{
    /// <summary>
    /// ToastForm: 一个无按钮自动消失的提示窗体
    /// </summary>
    public partial class ToastForm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">显示的提示信息</param>
        /// <param name="delayMs">自动关闭延时，单位毫秒</param>
        public ToastForm(string message, int delayMs = 3000)
        {
            // Label
            Label label = new Label();
            label.Text = message;
            label.AutoSize = true;
            label.Font = new Font("微软雅黑", 12);
            label.ForeColor = Color.White;
            label.BackColor = Color.Black;
            label.Padding = new Padding(10);

            this.Controls.Add(label);

            // 无边框 + 背景
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // 定时器
            Timer timer = new Timer();
            timer.Interval = delayMs;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                this.Close();
            };
            timer.Start();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ToastForm
            // 
            this.ClientSize = new System.Drawing.Size(410, 147);
            this.Name = "ToastForm";
            this.ResumeLayout(false);

        }
    }
}
