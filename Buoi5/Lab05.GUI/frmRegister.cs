using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab05.BUS;
using Lab05.DAL;

namespace Lab05.GUI
{
    public partial class frmRegister : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();

        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                var listFacultys = facultyService.GetAll();
                FillFalcultyCombobox(listFacultys);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillMajorCombobox(List<Major> listMajors)
        {
            comboBox2.DataSource = null; // Clear old data
            comboBox2.DataSource = listMajors;
            comboBox2.DisplayMember = "Name";       // Hiển thị tên chuyên ngành
            comboBox2.ValueMember = "MajorID";      // Giá trị lưu trữ là ID
        }

        private void FillFalcultyCombobox(List<Faculty> listFacultys)
        {
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }

        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty selectedFaculty = cmbFaculty.SelectedItem as Faculty;
            if (selectedFaculty != null)
            {
                var listMajor = majorService.GetAllByFaculty(selectedFaculty.FacultyID);
                FillMajorCombobox(listMajor);
                var listStudents = studentService.GetAllHasNoMajor(selectedFaculty.FacultyID);
                BindGrid(listStudents);
            }
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();

            // Xóa & thiết lập lại cột nếu chưa có hoặc chưa đầy đủ
            if (dgvStudent.Columns.Count == 0)
            {
                dgvStudent.Columns.Clear();

                // Cột chọn
                var chk = new DataGridViewCheckBoxColumn
                {
                    Name = "colCheck",
                    HeaderText = "Chọn",
                    Width = 50,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgvStudent.Columns.Add(chk);

                // Các cột thông tin
                dgvStudent.Columns.Add("colStudentID", "Mã SV");
                dgvStudent.Columns.Add("colFullName", "Họ tên");
                dgvStudent.Columns.Add("colFaculty", "Khoa");
                dgvStudent.Columns.Add("colScore", "Điểm TB");
                dgvStudent.Columns.Add("colMajor", "Chuyên ngành");

                dgvStudent.Columns["colScore"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvStudent.Columns["colScore"].DefaultCellStyle.Format = "0.0";
            }

            // Thêm dữ liệu
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells["colCheck"].Value = false;
                dgvStudent.Rows[index].Cells["colStudentID"].Value = item.StudentID;
                dgvStudent.Rows[index].Cells["colFullName"].Value = item.FullName;
                dgvStudent.Rows[index].Cells["colFaculty"].Value = item.Faculty?.FacultyName ?? "";
                dgvStudent.Rows[index].Cells["colScore"].Value = item.AverageScore;
                dgvStudent.Rows[index].Cells["colMajor"].Value = item.Major?.Name ?? "";
            }

            dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudent.AllowUserToAddRows = false;
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!(comboBox2.SelectedItem is Major selectedMajor))
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành.");
                return;
            }


            int count = 0;
            foreach (DataGridViewRow row in dgvStudent.Rows)
            {
                bool isChecked = row.Cells["colCheck"]?.Value as bool? == true;

                if (isChecked)
                {
                    string studentID = row.Cells[1].Value.ToString();
                    Student student = studentService.FindStudentById(studentID);
                    if (student != null)
                    {
                        student.MajorID = selectedMajor.MajorID;
                        studentService.InsertOrUpdateStudent(student);
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                MessageBox.Show($"Đã đăng ký chuyên ngành '{selectedMajor.Name}' cho {count} sinh viên.");
                // Refresh lại danh sách
                Faculty selectedFaculty = cmbFaculty.SelectedItem as Faculty;
                if (selectedFaculty != null)
                {
                    var listStudents = studentService.GetAllHasNoMajor(selectedFaculty.FacultyID);
                    BindGrid(listStudents);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sinh viên.");
            }
        }

        private void btn_trove_Click(object sender, EventArgs e)
        {
            frmStudent form = new frmStudent();  // nếu frmStudent là một Form
            form.Show();                         // mở form
            Hide();
        }
    }
}
