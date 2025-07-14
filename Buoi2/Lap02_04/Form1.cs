using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lap02_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lv_Accounts.View = View.Details;
            this.Resize += Form1_Resize; // ✅ GÁN SỰ KIỆN Resize

            lv_Accounts.View = View.Details;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string stk = txt_Stk.Text.Trim();
            string ten = txt_Tenkh.Text.Trim();
            string diachi = txt_Diachi.Text.Trim();
            string sotienText = txt_Sotien.Text.Trim();

            // ✅ Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(stk) || string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(diachi) || string.IsNullOrWhiteSpace(sotienText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(sotienText, out decimal soTien))
            {
                MessageBox.Show("Số tiền phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Kiểm tra trùng số tài khoản để cập nhật
            bool isUpdated = false;
            foreach (ListViewItem item in lv_Accounts.Items)
            {
                if (item.SubItems[1].Text == stk)
                {
                    item.SubItems[2].Text = ten;
                    item.SubItems[3].Text = diachi;
                    item.SubItems[4].Text = soTien.ToString("N0");
                    isUpdated = true;
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo");
                    break;
                }
            }

            // ✅ Nếu chưa có thì thêm mới
            if (!isUpdated)
            {
                int stt = lv_Accounts.Items.Count + 1;
                ListViewItem newItem = new ListViewItem(stt.ToString());
                newItem.SubItems.Add(stk);
                newItem.SubItems.Add(ten);
                newItem.SubItems.Add(diachi);
                newItem.SubItems.Add(soTien.ToString("N0"));
                lv_Accounts.Items.Add(newItem);
                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo");
            }

            TinhTongTien();

            txt_Stk.Clear();
            txt_Tenkh.Clear();
            txt_Diachi.Clear();
            txt_Sotien.Clear();
            txt_Stk.Focus();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string stk = txt_Stk.Text.Trim();
            if (string.IsNullOrWhiteSpace(stk))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem itemToRemove = null;

            foreach (ListViewItem item in lv_Accounts.Items)
            {
                if (item.SubItems[1].Text == stk)
                {
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản {stk}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        itemToRemove = item;
                    }
                    break;
                }
            }

            if (itemToRemove != null)
            {
                lv_Accounts.Items.Remove(itemToRemove);
                CapNhatSTT();
                TinhTongTien();
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lv_Accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_Accounts.SelectedItems.Count > 0)
            {
                ListViewItem item = lv_Accounts.SelectedItems[0];
                txt_Stk.Text = item.SubItems[1].Text;
                txt_Tenkh.Text = item.SubItems[2].Text;
                txt_Diachi.Text = item.SubItems[3].Text;
                if (decimal.TryParse(item.SubItems[4].Text.Replace(",", "").Replace(".", ""), out decimal tien))
                {
                    txt_Sotien.Text = tien.ToString("N0");
                }

            }
        }

        private void CapNhatSTT()
        {
            for (int i = 0; i < lv_Accounts.Items.Count; i++)
            {
                lv_Accounts.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (ListViewItem item in lv_Accounts.Items)
            {
                if (decimal.TryParse(item.SubItems[4].Text.Replace(",", "").Replace(".", ""), out decimal tien))
                {
                    tong += tien;
                }
            }
            txt_Tongtien.Text = tong.ToString("N0") + " đ";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeColumns();
        }
        private void ResizeColumns()
        {
            int totalWidth = lv_Accounts.ClientSize.Width;

            colSTT.Width = (int)(totalWidth * 0.08);
            colStk.Width = (int)(totalWidth * 0.18);
            colTenKH.Width = (int)(totalWidth * 0.25);
            colDiaChi.Width = (int)(totalWidth * 0.30);
            colSoTien.Width = (int)(totalWidth * 0.19);
        }




    }
}
