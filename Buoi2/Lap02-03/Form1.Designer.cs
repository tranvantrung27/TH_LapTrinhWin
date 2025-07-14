using System.Drawing;
using System.Windows.Forms;

namespace Lap02_03
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pn_vephim = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Thanhtien = new System.Windows.Forms.TextBox();
            this.btn_Chon = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_End = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pn_vephim
            // 
            this.pn_vephim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pn_vephim.Location = new System.Drawing.Point(40, 100);
            this.pn_vephim.Name = "pn_vephim";
            this.pn_vephim.Size = new System.Drawing.Size(620, 320);
            this.pn_vephim.TabIndex = 1;
            this.pn_vephim.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_vephim_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(40, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "💰 Thành Tiền:";
            // 
            // txt_Thanhtien
            // 
            this.txt_Thanhtien.BackColor = System.Drawing.Color.White;
            this.txt_Thanhtien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Thanhtien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txt_Thanhtien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.txt_Thanhtien.Location = new System.Drawing.Point(234, 433);
            this.txt_Thanhtien.Name = "txt_Thanhtien";
            this.txt_Thanhtien.ReadOnly = true;
            this.txt_Thanhtien.Size = new System.Drawing.Size(200, 39);
            this.txt_Thanhtien.TabIndex = 3;
            this.txt_Thanhtien.Text = "0 đ";
            this.txt_Thanhtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Chon
            // 
            this.btn_Chon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_Chon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Chon.FlatAppearance.BorderSize = 0;
            this.btn_Chon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(56)))));
            this.btn_Chon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Chon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Chon.ForeColor = System.Drawing.Color.White;
            this.btn_Chon.Location = new System.Drawing.Point(40, 490);
            this.btn_Chon.Name = "btn_Chon";
            this.btn_Chon.Size = new System.Drawing.Size(140, 45);
            this.btn_Chon.TabIndex = 4;
            this.btn_Chon.Text = "✓ Chọn";
            this.btn_Chon.UseVisualStyleBackColor = false;
            this.btn_Chon.Click += new System.EventHandler(this.btn_Chon_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btn_Huy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Huy.FlatAppearance.BorderSize = 0;
            this.btn_Huy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(176)))), ((int)(((byte)(0)))));
            this.btn_Huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Huy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Huy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btn_Huy.Location = new System.Drawing.Point(200, 490);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(140, 45);
            this.btn_Huy.TabIndex = 5;
            this.btn_Huy.Text = "↺ Hủy bỏ";
            this.btn_Huy.UseVisualStyleBackColor = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_End
            // 
            this.btn_End.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_End.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_End.FlatAppearance.BorderSize = 0;
            this.btn_End.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btn_End.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_End.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_End.ForeColor = System.Drawing.Color.White;
            this.btn_End.Location = new System.Drawing.Point(360, 490);
            this.btn_End.Name = "btn_End";
            this.btn_End.Size = new System.Drawing.Size(140, 45);
            this.btn_End.TabIndex = 6;
            this.btn_End.Text = "✕ Kết thúc";
            this.btn_End.UseVisualStyleBackColor = false;
            this.btn_End.Click += new System.EventHandler(this.btn_End_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(700, 80);
            this.label3.TabIndex = 7;
            this.label3.Text = "🎬 MÀN ẢNH CHIẾU PHIM";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(700, 560);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_End);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_Chon);
            this.Controls.Add(this.txt_Thanhtien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pn_vephim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🎟️ CINEMA TICKET BOOKING";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Các method cần thiết (thêm vào class Form1)
        private void label1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            System.Windows.Forms.Label label = sender as System.Windows.Forms.Label;
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new System.Drawing.Point(0, 0),
                new System.Drawing.Point(0, label.Height),
                System.Drawing.Color.FromArgb(50, 50, 93),
                System.Drawing.Color.FromArgb(20, 20, 30)
            );
            e.Graphics.FillRectangle(brush, label.ClientRectangle);
            brush.Dispose();
        }

        private void pn_vephim_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            System.Windows.Forms.Panel panel = sender as System.Windows.Forms.Panel;

            // Vẽ viền bo góc
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(200, 200, 220), 2);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 15;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            e.Graphics.DrawPath(pen, path);

            pen.Dispose();
            path.Dispose();
        }


        private void CreateSeats()
        {
            int rows = 4;
            int cols = 5;
            int gheSo = 1;

            int padding = 20;
            int spacing = 10;

            pn_vephim.Controls.Clear();
            gheButtons.Clear();

            int availableWidth = pn_vephim.Width - 2 * padding - (cols - 1) * spacing;
            int availableHeight = pn_vephim.Height - 2 * padding - (rows - 1) * spacing;

            int btnWidth = availableWidth / cols;
            int btnHeight = availableHeight / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btnGhe = new Button();
                    btnGhe.Text = gheSo.ToString();
                    btnGhe.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    btnGhe.FlatStyle = FlatStyle.Flat;
                    btnGhe.FlatAppearance.BorderSize = 1;
                    btnGhe.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
                    btnGhe.BackColor = Color.White;
                    btnGhe.ForeColor = Color.Black;
                    btnGhe.Cursor = Cursors.Hand;
                    btnGhe.Tag = gheSo;
                    btnGhe.Size = new Size(btnWidth, btnHeight);
                    btnGhe.Location = new Point(
                        padding + j * (btnWidth + spacing),
                        padding + i * (btnHeight + spacing)
                    );

                    // 👉 Gán sự kiện click
                    btnGhe.Click += BtnGhe_Click;

                    // 👉 Tooltip theo số ghế
                    string giaVe = "";
                    if (gheSo >= 1 && gheSo <= 5)
                        giaVe = "30.000đ";
                    else if (gheSo >= 6 && gheSo <= 10)
                        giaVe = "40.000đ";
                    else if (gheSo >= 11 && gheSo <= 15)
                        giaVe = "50.000đ";
                    else
                        giaVe = "80.000đ";

                    tooltip.SetToolTip(btnGhe, $"Ghế {gheSo} - Giá vé: {giaVe}");

                    // 👉 Lưu vào danh sách và hiển thị
                    gheButtons.Add(btnGhe);
                    pn_vephim.Controls.Add(btnGhe);

                    gheSo++;
                }
            }
        }



        private void SeatButton_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Button seatButton = sender as System.Windows.Forms.Button;

            if (seatButton.Tag.ToString() == "available")
            {
                // Ghế trống -> Chọn
                seatButton.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
                seatButton.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
                seatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 176, 0);
                seatButton.Tag = "selected";
            }
            else if (seatButton.Tag.ToString() == "selected")
            {
                // Ghế đã chọn -> Hủy chọn
                seatButton.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
                seatButton.ForeColor = System.Drawing.Color.White;
                seatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(90, 98, 104);
                seatButton.Tag = "available";
            }

            // Tính toán thành tiền
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            int selectedSeats = 0;
            foreach (System.Windows.Forms.Control control in pn_vephim.Controls)
            {
                if (control is System.Windows.Forms.Button button &&
                    button.Tag.ToString() == "selected")
                {
                    selectedSeats++;
                }
            }

            int pricePerSeat = 60000;
            int total = selectedSeats * pricePerSeat;
            txt_Thanhtien.Text = total.ToString("N0") + " đ";
        }


        #endregion
        private System.Windows.Forms.Panel pn_vephim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Thanhtien;
        private System.Windows.Forms.Button btn_Chon;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_End;
        private System.Windows.Forms.Label label3;
    }
}

