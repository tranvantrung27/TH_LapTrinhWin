using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lap02_03
{
    public partial class Form1 : Form
    {
        List<Button> gheButtons = new List<Button>();
        HashSet<int> gheDaBan = new HashSet<int>();
        HashSet<int> gheDangChon = new HashSet<int>();
        ToolTip tooltip = new ToolTip();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateSeats();
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int soGhe = (int)btn.Tag;

            if (gheDaBan.Contains(soGhe))
            {
                MessageBox.Show($"Ghế số {soGhe} đã được bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gheDangChon.Contains(soGhe))
            {
                gheDangChon.Remove(soGhe);
                btn.BackColor = Color.White;
            }
            else
            {
                gheDangChon.Add(soGhe);
                btn.BackColor = Color.LightGreen;
            }
        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            if (gheDangChon.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn ghế nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tongTien = 0;

            foreach (int soGhe in gheDangChon)
            {
                gheDaBan.Add(soGhe);

                if (soGhe >= 1 && soGhe <= 5)
                    tongTien += 30000;
                else if (soGhe >= 6 && soGhe <= 10)
                    tongTien += 40000;
                else if (soGhe >= 11 && soGhe <= 15)
                    tongTien += 50000;
                else if (soGhe >= 16 && soGhe <= 20)
                    tongTien += 80000;

                gheButtons[soGhe - 1].BackColor = Color.Gold;
            }

            txt_Thanhtien.Text = tongTien.ToString("N0") + " đ";
            gheDangChon.Clear();

            int gheConLai = 20 - gheDaBan.Count;
            MessageBox.Show($"Đã bán: {gheDaBan.Count} ghế\nCòn lại: {gheConLai} ghế", "Tình trạng ghế", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            foreach (int soGhe in gheDangChon)
            {
                gheButtons[soGhe - 1].BackColor = Color.White;
            }

            gheDangChon.Clear();
            txt_Thanhtien.Text = "0";
        }

        private void btn_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
