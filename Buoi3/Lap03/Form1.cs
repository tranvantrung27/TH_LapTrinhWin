using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap03
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại mở file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Lọc hiển thị các loại file
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.wmv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Mở video với Windows Media Player
                axWindowsMediaPlayer1.URL = openFileDialog.FileName; // Lấy tên file cần mở
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // Cập nhật mỗi 1 giây
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            this.toolStripStatusLabel1.Text = string.Format($"Hôm nay là ngày: {date} – Bây giờ là {time}");
        }
    }
}
