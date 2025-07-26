using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;
using Lap04.Models;

namespace Lap04
{
    public partial class frmFalculty : Form
    {
        public frmFalculty()
        {
            InitializeComponent();
        }

        private void frmFalculty_Load(object sender, EventArgs e)
        {
            LoadFacultyData();
        }

        private void LoadFacultyData()
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                List<Faculty> listFaculty = db.Faculty.ToList();

                if (gdv_danhsach.Columns.Count == 0)
                {
                    gdv_danhsach.Columns.Add("FacultyID", "Mã Khoa");
                    gdv_danhsach.Columns.Add("FacultyName", "Tên Khoa");
                    gdv_danhsach.Columns.Add("TotalProfessor", "Tổng số GS");
                }

                BindGrid(listFaculty);
                FormatGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormatGridView()
        {
            gdv_danhsach.EnableHeadersVisualStyles = false;
            gdv_danhsach.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
            gdv_danhsach.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            gdv_danhsach.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            gdv_danhsach.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gdv_danhsach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gdv_danhsach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gdv_danhsach.MultiSelect = false;
            gdv_danhsach.ReadOnly = true;
            gdv_danhsach.AllowUserToAddRows = false;
        }

        private void BindGrid(List<Faculty> listFaculty)
        {
            gdv_danhsach.Rows.Clear();
            foreach (var item in listFaculty)
            {
                int index = gdv_danhsach.Rows.Add();
                gdv_danhsach.Rows[index].Cells[0].Value = item.FacultyID;
                gdv_danhsach.Rows[index].Cells[1].Value = item.FacultyName;
                gdv_danhsach.Rows[index].Cells[2].Value = item.TotalProfessor;
            }
        }

        private void ClearInput()
        {
            txt_makhoa.Text = "";
            txt_tenkhoa.Text = "";
            txt_tonggs.Text = "";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB db = new StudentContextDB();

                if (string.IsNullOrWhiteSpace(txt_makhoa.Text) || string.IsNullOrWhiteSpace(txt_tenkhoa.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã Khoa và Tên Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (db.Faculty.Any(f => f.FacultyID.ToString() == txt_makhoa.Text))
                {
                    MessageBox.Show("Mã Khoa đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newFaculty = new Faculty
                {
                    FacultyID = int.Parse(txt_makhoa.Text),
                    FacultyName = txt_tenkhoa.Text,
                    TotalProfessor = string.IsNullOrWhiteSpace(txt_tonggs.Text) ? (int?)null : int.Parse(txt_tonggs.Text)
                };

                db.Faculty.Add(newFaculty);
                db.SaveChanges();
                BindGrid(db.Faculty.ToList());

                MessageBox.Show("Thêm Khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput(); // Xóa trắng sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                var faculty = db.Faculty.FirstOrDefault(f => f.FacultyID.ToString() == txt_makhoa.Text);

                if (faculty != null)
                {
                    faculty.FacultyName = txt_tenkhoa.Text;
                    faculty.TotalProfessor = string.IsNullOrWhiteSpace(txt_tonggs.Text) ? (int?)null : int.Parse(txt_tonggs.Text);
                    db.SaveChanges();
                    BindGrid(db.Faculty.ToList());

                    MessageBox.Show("Cập nhật Khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput(); // Xóa trắng sau khi sửa
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB db = new StudentContextDB();
                var faculty = db.Faculty.FirstOrDefault(f => f.FacultyID.ToString() == txt_makhoa.Text);

                if (faculty != null)
                {
                    db.Faculty.Remove(faculty);
                    db.SaveChanges();
                    BindGrid(db.Faculty.ToList());

                    MessageBox.Show("Xóa Khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput(); 
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }


        private void gdv_danhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gdv_danhsach.Rows[e.RowIndex];
                txt_makhoa.Text = row.Cells[0].Value?.ToString();
                txt_tenkhoa.Text = row.Cells[1].Value?.ToString();
                txt_tonggs.Text = row.Cells[2].Value?.ToString();
            }
        }

        private void btn_trove_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
