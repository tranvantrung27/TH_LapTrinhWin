using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab05.BUS;
using Lab05.DAL;

namespace Lab05.GUI
{
    public partial class frmStudent: Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private string avatarFilePath = string.Empty;




        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            dgvStudent.Columns.Add("colStudentID", "MSSV");
            dgvStudent.Columns.Add("colFullName", "Họ Tên");
            dgvStudent.Columns.Add("colFaculty", "Khoa");
            dgvStudent.Columns.Add("colAverageScore", "DTB");
            dgvStudent.Columns.Add("colMajor", "Chuyên ngành");

            try
            {
                setGridViewStyle(dgvStudent);
                var listFacultys = facultyService.GetAll();
                var listStudents = studentService.GetAll();
                FillFalcultyCombobox(listFacultys);
                BindGrid(listStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillFalcultyCombobox(List<Faculty> listFacultys)
        {
            listFacultys.Insert(0, new Faculty());
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }
        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();

            if (dgvStudent.Columns.Count == 0)
            {
                dgvStudent.Columns.Clear();

                dgvStudent.Columns.Add("colStudentID", "Mã SV");
                dgvStudent.Columns.Add("colFullName", "Họ tên");
                dgvStudent.Columns.Add("colFaculty", "Khoa");
                dgvStudent.Columns.Add("colAverageScore", "Điểm TB");
                dgvStudent.Columns.Add("colMajor", "Chuyên ngành");

                dgvStudent.Columns["colAverageScore"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvStudent.Columns["colAverageScore"].DefaultCellStyle.Format = "0.0";
            }

            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells["colStudentID"].Value = item.StudentID;
                dgvStudent.Rows[index].Cells["colFullName"].Value = item.FullName;
                dgvStudent.Rows[index].Cells["colFaculty"].Value = item.Faculty?.FacultyName ?? "";
                dgvStudent.Rows[index].Cells["colAverageScore"].Value = item.AverageScore;
                dgvStudent.Rows[index].Cells["colMajor"].Value = item.Major?.Name ?? "";

                LoadAvatar(item.StudentID);
            }

            dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudent.AllowUserToAddRows = false;
        }

        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle =
DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        avatarFilePath = openFileDialog.FileName;
                        using (var fs = new FileStream(avatarFilePath, FileMode.Open, FileAccess.Read))
                        {
                            picAvata.Image = Image.FromStream(fs);
                            picAvata.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở ảnh. Chi tiết: " + ex.Message);
                    }
                }
            }
        }


        private string SaveAvatar(string sourceFilePath, string studentID)
        {
            try
            {
                string folderPath = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileExtension = Path.GetExtension(sourceFilePath);
                string targetFilePath = Path.Combine(folderPath, $"{studentID}{fileExtension}");

                if (!File.Exists(sourceFilePath))
                {
                    throw new FileNotFoundException($"Không tìm thấy file: {sourceFilePath}");
                }

                File.Copy(sourceFilePath, targetFilePath, true);
                return $"{studentID}{fileExtension}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving avatar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void LoadAvatar(string studentID)
        {
            string folderPath = Path.Combine(Application.StartupPath, "Images");
            var student = studentService.FindStudentById(studentID);
            if (student != null && !string.IsNullOrEmpty(student.Avatar))
            {
                string avatarFilePath = Path.Combine(folderPath, student.Avatar);
                if (File.Exists(avatarFilePath))
                {
                    picAvata.Image = Image.FromFile(avatarFilePath);
                    picAvata.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    picAvata.Image = null;
                }
            }
            else
            {
                picAvata.Image = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                var student = studentService.FindStudentById(txtStudentID.Text) ?? new Student();

                // Cập nhật thông tin sinh viên từ các điều khiển trên form
                student.StudentID = txtStudentID.Text;
                student.FullName = txtFullName.Text;
                student.AverageScore = double.Parse(txtGPA.Text);
                student.FacultyID = int.Parse(cmbFaculty.SelectedValue.ToString());

                // Kiểm tra nếu có chọn ảnh và lưu vào thư mục, gán tên file vào student.Avatar
                if (!string.IsNullOrEmpty(avatarFilePath))
                {
                    string avatarFileName = SaveAvatar(avatarFilePath, txtStudentID.Text);
                    if (!string.IsNullOrEmpty(avatarFileName))
                    {
                        student.Avatar = avatarFileName;
                    }
                }

                // Thêm hoặc cập nhật sinh viên vào cơ sở dữ liệu
                studentService.InsertOrUpdateStudent(student);

                // Cập nhật lại danh sách hiển thị
                BindGrid(studentService.GetAll());

                // Xóa dữ liệu nhập và đường dẫn ảnh
                ClearData();
                avatarFilePath = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }
            return true;
        }

        private void ClearData()
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtGPA.Clear();
            cmbFaculty.SelectedIndex = 0;
            picAvata.Image = null;
        }



        private void chkUnregisterMajor_CheckedChanged_1(object sender, EventArgs e)
        {
            {
                var listStudents = new List<Student>();
                if (this.chkUnregisterMajor.Checked)
                    listStudents = studentService.GetAllHasNoMajor();
                else
                    listStudents = studentService.GetAll();
                BindGrid(listStudents);
            }

        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
            Hide();
        }

        private void menu_qlychuyenganh_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
            Hide();
        }
    }
}
