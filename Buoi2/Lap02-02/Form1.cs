using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap02_02
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cbb_chuyennganh.SelectedIndex = 0;
            optFemale.Checked = true;
            UpdateStudentCount();



            cbb_chuyennganh.SelectedIndex = 0; // Mặc định chọn QTKD
            optFemale.Checked = true;     // Mặc định chọn Nữ
            UpdateStudentCount();         // Cập nhật số lượng ban đầu
        }


        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtAverageScore.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!float.TryParse(txtAverageScore.Text, out float score) || score < 0 || score > 10)
            {
                MessageBox.Show("Điểm trung bình không hợp lệ! Nhập số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value?.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void InsertUpdate(int selectedRow)
        {
            dgvStudent.Rows[selectedRow].Cells[0].Value = txtStudentID.Text;
            dgvStudent.Rows[selectedRow].Cells[1].Value = txtFullName.Text;
            dgvStudent.Rows[selectedRow].Cells[2].Value = optFemale.Checked ? "Nữ" : "Nam";
            dgvStudent.Rows[selectedRow].Cells[3].Value = float.Parse(txtAverageScore.Text).ToString("0.00");
            dgvStudent.Rows[selectedRow].Cells[4].Value = cbb_chuyennganh.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            int row = GetSelectedRow(txtStudentID.Text); // Tìm dòng có MSSV

            if (row == -1)
            {
                // Thêm mới sinh viên vào DataGridView
                int newRow = dgvStudent.Rows.Add();
                InsertUpdate(newRow);  // Chèn dữ liệu vào dòng mới
                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cập nhật sinh viên đã có
                InsertUpdate(row);
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateStudentCount(); // Cập nhật số lượng sinh viên
            ClearInputFields();
        }
        private void ClearInputFields()
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtAverageScore.Clear();
            cbb_chuyennganh.SelectedIndex = 0;
            optFemale.Checked = true;

            txtStudentID.Focus(); // Đưa con trỏ về ô MSSV để nhập mới
        }
    
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int row = GetSelectedRow(txtStudentID.Text); // Tìm dòng có MSSV
            if (row == -1)
            {
                MessageBox.Show("Không tìm thấy MSSV cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cảnh báo xóa
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dgvStudent.Rows.RemoveAt(row);  // Xóa dòng sinh viên
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStudentCount(); // Cập nhật lại số lượng sinh viên
            }
        }


        private void optMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtStudentID.Text = dgvStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFullName.Text = dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
                string gender = dgvStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
                optMale.Checked = (gender == "Nam");
                optFemale.Checked = (gender == "Nữ");
                txtAverageScore.Text = dgvStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbb_chuyennganh.Text = dgvStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
        private void UpdateStudentCount()
        {
            int male = 0, female = 0;
            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                if (row.IsNewRow) continue;
                string gender = row.Cells[2].Value?.ToString();
                if (gender == "Nam") male++;
                else if (gender == "Nữ") female++;
            }

            txtMaleCount.Text = male.ToString();
            txtFemaleCount.Text = female.ToString();
        }

        private void optFemale_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
