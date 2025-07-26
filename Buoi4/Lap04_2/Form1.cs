using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lap04_2.Models;
using System.Data.Entity; // cần cho DbFunctions

namespace Lap04_2
{
    public partial class Form1 : Form
    {
        private ProductOrderInvoice db = new ProductOrderInvoice();

        public Form1()
        {
            InitializeComponent();
        }

        // Khi Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập DateTimePicker về ngày hiện hành
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            // Cấu hình DataGridView
            SetupDataGridView();

            // Hiển thị dữ liệu ban đầu
            LoadData();
        }

        // Cấu hình DataGridView
        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("InvoiceNo", "Mã Hóa Đơn");
            dataGridView1.Columns.Add("OrderDate", "Ngày Đặt Hàng");
            dataGridView1.Columns.Add("DeliveryDate", "Ngày Giao");
            dataGridView1.Columns.Add("Note", "Ghi Chú");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
        }

        // Hàm load dữ liệu theo khoảng thời gian
        private void LoadData()
        {
            try
            {
                DateTime startDate = dateTimePicker1.Value.Date;
                DateTime endDate = dateTimePicker2.Value.Date;

                // Lấy dữ liệu từ DB
                var filtered = db.Invoice
                                .Where(i => DbFunctions.TruncateTime(i.OrderDate) >= startDate &&
                                            DbFunctions.TruncateTime(i.OrderDate) <= endDate)
                                .ToList();

                // Xóa dữ liệu cũ
                dataGridView1.Rows.Clear();

                // Đổ dữ liệu vào DataGridView
                foreach (var inv in filtered)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = inv.InvoiceNo;
                    dataGridView1.Rows[index].Cells[1].Value = inv.OrderDate.ToString("dd/MM/yyyy");
                    dataGridView1.Rows[index].Cells[2].Value = inv.DeliveryDate.ToString("dd/MM/yyyy");
                    dataGridView1.Rows[index].Cells[3].Value = inv.Note;
                }

                // Hiển thị tổng số hóa đơn
                textBox1.Text = filtered.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    DateTime now = DateTime.Now;
                    DateTime firstDay = new DateTime(now.Year, now.Month, 1);
                    DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);

                    dateTimePicker1.Value = firstDay;
                    dateTimePicker2.Value = lastDay;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý CheckBox: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào một dòng
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
