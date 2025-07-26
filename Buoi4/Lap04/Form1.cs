using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lap04.Models;

namespace Lap04
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB context = new StudentContextDB();
                List<Faculty> listFalcultys = context.Faculty.ToList(); // Lấy danh sách khoa
                                                                        // Include("Faculty") để load thông tin khoa đi kèm sinh viên
                List<Student> listStudent = context.Student.Include("Faculty").ToList();

                FillFalcultyCombobox(listFalcultys);

                if (dgvStudent.Columns.Count == 0)
                {
                    dgvStudent.Columns.Add("StudentID", "Mã SV");
                    dgvStudent.Columns.Add("FullName", "Họ tên");
                    dgvStudent.Columns.Add("Gender", "Giới tính");
                    dgvStudent.Columns.Add("AverageScore", "Điểm TB");
                    dgvStudent.Columns.Add("FacultyName", "Khoa");
                }

                BindGrid(listStudent);
                // Đổi màu header
dgvStudent.EnableHeadersVisualStyles = false;
dgvStudent.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
dgvStudent.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
dgvStudent.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

// Căn giữa nội dung các cell
dgvStudent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

// Auto resize để hiển thị đẹp hơn
dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
dgvStudent.MultiSelect = false;
dgvStudent.ReadOnly = true;
dgvStudent.AllowUserToAddRows = false;

            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }


        private void FillFalcultyCombobox(List<Faculty> listFalcultys)
        {
            this.cmbFaculty.DataSource = listFalcultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                dgvStudent.Rows[index].Cells[2].Value = item.Gender;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
                dgvStudent.Rows[index].Cells[4].Value = item.Faculty?.FacultyName ?? "N/A";
            }
        }
        private void ClearInputFields()
        {
            txtStudentId.Text = "";
            txtFullname.Text = "";
            txtAverageScore.Text = "";
            rdMale.Checked = true;
           
        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                List<Student> studentLst = db.Student.ToList();

                if (studentLst.Any(s => s.StudentID.ToString() == txtStudentId.Text))
                {
                    MessageBox.Show("Mã SV đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newStudent = new Student
                {
                    StudentID = txtStudentId.Text,
                    // nếu bạn muốn nhập tay
                    FullName = txtFullname.Text,
                    Gender = rdMale.Checked ? "Male" : "Female",
                    FacultyID = int.Parse(cmbFaculty.SelectedValue.ToString()),
                    AverageScore = double.Parse(txtAverageScore.Text)
                };


                db.Student.Add(newStudent);
                db.SaveChanges();

                BindGrid(db.Student.Include("Faculty").ToList());

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields(); // thêm dòng này

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show($"Property: {ve.PropertyName} - Error: {ve.ErrorMessage}");
                    }
                }
            }

        }


        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                List<Student> students = db.Student.ToList();
                var student = students.FirstOrDefault(s => s.StudentID == txtStudentId.Text);


                if (student != null)
                {
                    if (students.Any(s => s.StudentID.ToString() == txtStudentId.Text && s.StudentID != student.StudentID))
                    {
                        MessageBox.Show("Mã SV đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    student.FullName = txtFullname.Text;
                    student.Gender = rdMale.Checked ? "Male" : "Female";
                    student.FacultyID = int.Parse(cmbFaculty.SelectedValue.ToString());
                    student.AverageScore = double.Parse(txtAverageScore.Text);

                    db.SaveChanges();
                    BindGrid(db.Student.Include("Faculty").ToList());

                    MessageBox.Show("Chỉnh sửa thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields(); // thêm dòng này

                }
                else
                {
                    MessageBox.Show("Sinh viên không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                List<Student> studentList = db.Student.ToList();
                var student = studentList.FirstOrDefault(s => s.StudentID == txtStudentId.Text);


                if (student != null)
                {
                    db.Student.Remove(student);
                    db.SaveChanges();

                    BindGrid(db.Student.Include("Faculty").ToList());

                    MessageBox.Show("Sinh viên đã được xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sinh viên không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xoá dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvStudent.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvStudent.Rows[e.RowIndex];

                txtStudentId.Text = selectedRow.Cells[0].Value?.ToString();
                txtFullname.Text = selectedRow.Cells[1].Value?.ToString();
                txtAverageScore.Text = selectedRow.Cells[3].Value?.ToString();

                string gender = selectedRow.Cells[2].Value?.ToString();
                rdMale.Checked = gender == "Male";
                rdFemale.Checked = gender == "Female";

                string facultyName = selectedRow.Cells[4].Value?.ToString();
                cmbFaculty.SelectedIndex = cmbFaculty.FindStringExact(facultyName);
            }
        }





        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFalculty frmFalculty = new frmFalculty();
            frmFalculty.Show();
            Hide();
        }



        private void menu_qlykhoa_Click(object sender, EventArgs e)
        {
            frmFalculty frmFalculty = new frmFalculty();
            frmFalculty.Show();
            Hide();
        }

        private void menu_timkiem_Click(object sender, EventArgs e)
        {
            frmTimkiem frmTimkiem = new frmTimkiem();
            frmTimkiem.Show();
            Hide();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimkiem frmTimkiem = new frmTimkiem();
            frmTimkiem.Show();
            Hide();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
