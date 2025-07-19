// File: Form1.cs - Phiên bản hoàn chỉnh bài Lab03-02
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace Lap03_02
{
    public partial class Form1 : Form
    {
        private string path = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewVanBan();
        }

        private void NewVanBan()
        {
            txtphongchu.Items.Clear();
            foreach (FontFamily font in new InstalledFontCollection().Families)
                txtphongchu.Items.Add(font.Name);

            txtcochu.Items.Clear();
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
                txtcochu.Items.Add(size);

            txtphongchu.SelectedItem = "Tahoma";
            txtcochu.SelectedItem = 14;
            richText.Font = new Font("Tahoma", 14);
            path = string.Empty;
        }

        private void UpdateFont()
        {
            if (txtphongchu.SelectedItem != null && txtcochu.SelectedItem != null)
            {
                string selectedFont = txtphongchu.SelectedItem.ToString();
                int selectedSize = Convert.ToInt32(txtcochu.SelectedItem);
                FontStyle style = FontStyle.Regular;
                if (toolStripButton3.Checked) style |= FontStyle.Bold;
                if (toolStripButton4.Checked) style |= FontStyle.Italic;
                if (toolStripButton5.Checked) style |= FontStyle.Underline;

                richText.SelectionFont = new Font(selectedFont, selectedSize, style);
            }
        }



        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "rtf";
                saveFileDialog.Filter = "Rich Text Format|*.rtf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    richText.SaveFile(path);
                    MessageBox.Show("Lưu file thành công.", "Thông báo");
                }
            }
            else
            {
                richText.SaveFile(path);
                MessageBox.Show("Đã lưu vào file hiện tại.", "Thông báo");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripButton3.Checked = !toolStripButton3.Checked;
            UpdateFont();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripButton4.Checked = !toolStripButton4.Checked;
            UpdateFont();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStripButton5.Checked = !toolStripButton5.Checked;
            UpdateFont();
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.SelectionColor = fontDlg.Color;
                richText.SelectionFont = fontDlg.Font;
            }
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) { }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richText.Clear();
            NewVanBan();
        }

        private void txtphongchu_Click(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void txtcochu_Click(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog.FileName).ToLower();
                if (ext == ".rtf")
                {
                    richText.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richText.Text = File.ReadAllText(openFileDialog.FileName);
                }
                path = openFileDialog.FileName;
            }
        }


        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "rtf";
                saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text files (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            string ext = Path.GetExtension(path).ToLower();
            if (ext == ".rtf")
            {
                richText.SaveFile(path, RichTextBoxStreamType.RichText);
            }
            else
            {
                File.WriteAllText(path, richText.Text);
            }

            MessageBox.Show("Lưu thành công!", "Thông báo");
        }


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e); // Gọi hàm tạo mới
        }
    }
}
