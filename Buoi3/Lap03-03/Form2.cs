using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap03_03
{
    public partial class Form2 : Form
    {
        Form1 fgirpview1;
        public Form2(Form1 f1)
        {
            this.fgirpview1 = f1;
            InitializeComponent();


        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMssv.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã số sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMssv.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }
            if (cmb_Khoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Khoa.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDTB.Text))
            {
                MessageBox.Show("Vui lòng nhập Điểm trung bình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDTB.Focus();
                return;
            }

            fgirpview1.dataGridView1.Rows.Add(txtMssv.Text, txtTen.Text, cmb_Khoa.Text, txtDTB.Text);
            txtMssv.Clear();
            txtTen.Clear();
            txtDTB.Clear();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
