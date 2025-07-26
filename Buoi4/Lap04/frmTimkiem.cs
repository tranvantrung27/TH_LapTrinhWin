using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lap04.Models;

namespace Lap04
{
    public partial class frmTimkiem : Form
    {
        StudentContextDB db = new StudentContextDB(); // DbContext cho toàn form

        public frmTimkiem()
        {
            InitializeComponent();
        }

        // Khi nhấn nút Tìm kiếm
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtStudentId.Text.Trim();
                string name = txtFullname.Text.Trim().ToLower();
                int facultyId = cmbFaculty.SelectedIndex != -1 ? (int)cmbFaculty.SelectedValue : -1;

                // Lấy danh sách sinh viên từ DB
                var students = db.Student.Include("Faculty").ToList();

                // Lọc theo Mã SV
                if (!string.IsNullOrEmpty(id))
                    students = students.Where(s => s.StudentID.ToLower().Contains(id.ToLower())).ToList();

                // Lọc theo tên
                if (!string.IsNullOrEmpty(name))
                    students = students.Where(s => s.FullName.ToLower().Contains(name)).ToList();

                // Lọc theo Khoa
                if (facultyId != -1)
                    students = students.Where(s => s.FacultyID == facultyId).ToList();

                // Cập nhật DataGridView
                BindGrid(students);

                // Hiển thị số kết quả
                txt_ketqua.Text = students.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Nút Xóa kết quả (Reset)
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullname.Clear();
            cmbFaculty.SelectedIndex = -1;
            txt_ketqua.Text = "0";
        }


        // Nút Trở về
        private void btn_trove_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        // Bind dữ liệu lên DataGridView
        private void BindGrid(List<Student> students)
        {
            dataGridView1.Rows.Clear();
            foreach (var s in students)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = s.StudentID;
                dataGridView1.Rows[index].Cells[1].Value = s.FullName;
                dataGridView1.Rows[index].Cells[2].Value = s.Gender;
                dataGridView1.Rows[index].Cells[3].Value = s.AverageScore;
                dataGridView1.Rows[index].Cells[4].Value = s.Faculty != null ? s.Faculty.FacultyName : "N/A";
            }
        }

        // Khi load form
        private void frmTimkiem_Load(object sender, EventArgs e)
        {
            try
            {
                // Load danh sách khoa
                var faculties = db.Faculty.ToList();
                cmbFaculty.DataSource = faculties;
                cmbFaculty.DisplayMember = "FacultyName";
                cmbFaculty.ValueMember = "FacultyID";
                cmbFaculty.SelectedIndex = -1;

                // Cấu hình DataGridView
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("StudentID", "Mã SV");
                    dataGridView1.Columns.Add("FullName", "Họ Tên");
                    dataGridView1.Columns.Add("Gender", "Giới Tính");
                    dataGridView1.Columns.Add("AverageScore", "Điểm TB");
                    dataGridView1.Columns.Add("FacultyName", "Khoa");
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.AllowUserToAddRows = false;

                // Nạp danh sách sinh viên ban đầu
                BindGrid(db.Student.Include("Faculty").ToList());
                txt_ketqua.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi Load form: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
