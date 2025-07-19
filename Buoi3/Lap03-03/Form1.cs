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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(
                    (e.RowIndex + 1).ToString(),
                    dataGridView1.Font,
                    b,
                    e.RowBounds.Location.X + 10,
                    e.RowBounds.Location.Y + 4
                );
            }
        }


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tenCanTim = txtTimkiem.Text.Trim();


            if (string.IsNullOrWhiteSpace(tenCanTim))
            {
                MessageBox.Show("Vui lòng nhập tên cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            bool timThay = false;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TenSV"].Value != null && row.Cells["TenSV"].Value.ToString().Equals(tenCanTim, StringComparison.OrdinalIgnoreCase))
                {

                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    timThay = true;
                    break;
                }
            }


            if (!timThay)
            {
                MessageBox.Show("Không tìm thấy sinh viên với tên: " + tenCanTim, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
