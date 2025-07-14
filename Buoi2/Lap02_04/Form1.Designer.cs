namespace Lap02_04
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Stk = new System.Windows.Forms.TextBox();
            this.txt_Tenkh = new System.Windows.Forms.TextBox();
            this.txt_Diachi = new System.Windows.Forms.TextBox();
            this.txt_Sotien = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Out = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Tongtien = new System.Windows.Forms.TextBox();
            this.lv_Accounts = new System.Windows.Forms.ListView();
            this.colSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelInputs = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.panelInputs.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(175, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(693, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN NGÂN HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(65, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(65, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên khách hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(65, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa chỉ khách hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(65, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số tiền trong tài khoản:";
            // 
            // txt_Stk
            // 
            this.txt_Stk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Stk.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Stk.Location = new System.Drawing.Point(300, 32);
            this.txt_Stk.Name = "txt_Stk";
            this.txt_Stk.Size = new System.Drawing.Size(380, 32);
            this.txt_Stk.TabIndex = 5;
            // 
            // txt_Tenkh
            // 
            this.txt_Tenkh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Tenkh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tenkh.Location = new System.Drawing.Point(300, 82);
            this.txt_Tenkh.Name = "txt_Tenkh";
            this.txt_Tenkh.Size = new System.Drawing.Size(380, 32);
            this.txt_Tenkh.TabIndex = 6;
            // 
            // txt_Diachi
            // 
            this.txt_Diachi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Diachi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Diachi.Location = new System.Drawing.Point(300, 132);
            this.txt_Diachi.Name = "txt_Diachi";
            this.txt_Diachi.Size = new System.Drawing.Size(380, 32);
            this.txt_Diachi.TabIndex = 7;
            // 
            // txt_Sotien
            // 
            this.txt_Sotien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Sotien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Sotien.Location = new System.Drawing.Point(300, 183);
            this.txt_Sotien.Name = "txt_Sotien";
            this.txt_Sotien.Size = new System.Drawing.Size(380, 32);
            this.txt_Sotien.TabIndex = 8;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(300, 15);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(140, 40);
            this.btn_Add.TabIndex = 9;
            this.btn_Add.Text = "Thêm/Cập nhật";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(460, 15);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(140, 40);
            this.btn_Delete.TabIndex = 10;
            this.btn_Delete.Text = "Xóa";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Out
            // 
            this.btn_Out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btn_Out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Out.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Out.ForeColor = System.Drawing.Color.White;
            this.btn_Out.Location = new System.Drawing.Point(620, 15);
            this.btn_Out.Name = "btn_Out";
            this.btn_Out.Size = new System.Drawing.Size(140, 40);
            this.btn_Out.TabIndex = 11;
            this.btn_Out.Text = "Thoát";
            this.btn_Out.UseVisualStyleBackColor = false;
            this.btn_Out.Click += new System.EventHandler(this.btn_Out_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(675, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 28);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tổng tiền:";
            // 
            // txt_Tongtien
            // 
            this.txt_Tongtien.BackColor = System.Drawing.Color.White;
            this.txt_Tongtien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Tongtien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tongtien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.txt_Tongtien.Location = new System.Drawing.Point(800, 17);
            this.txt_Tongtien.Name = "txt_Tongtien";
            this.txt_Tongtien.ReadOnly = true;
            this.txt_Tongtien.Size = new System.Drawing.Size(200, 34);
            this.txt_Tongtien.TabIndex = 14;
            this.txt_Tongtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lv_Accounts
            // 
            this.lv_Accounts.BackColor = System.Drawing.Color.White;
            this.lv_Accounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_Accounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSTT,
            this.colStk,
            this.colTenKH,
            this.colDiaChi,
            this.colSoTien});
            this.lv_Accounts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_Accounts.FullRowSelect = true;
            this.lv_Accounts.GridLines = true;
            this.lv_Accounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_Accounts.HideSelection = false;
            this.lv_Accounts.Location = new System.Drawing.Point(15, 15);
            this.lv_Accounts.Name = "lv_Accounts";
            this.lv_Accounts.Size = new System.Drawing.Size(998, 220);
            this.lv_Accounts.TabIndex = 15;
            this.lv_Accounts.UseCompatibleStateImageBehavior = false;
            this.lv_Accounts.View = System.Windows.Forms.View.Details;
            this.lv_Accounts.SelectedIndexChanged += new System.EventHandler(this.lv_Accounts_SelectedIndexChanged);
            // 
            // colSTT
            // 
            this.colSTT.Text = "STT";
            // 
            // colStk
            // 
            this.colStk.Text = "Số tài khoản";
            this.colStk.Width = 160;
            // 
            // colTenKH
            // 
            this.colTenKH.Text = "Tên khách hàng";
            this.colTenKH.Width = 220;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Text = "Địa chỉ";
            this.colDiaChi.Width = 300;
            // 
            // colSoTien
            // 
            this.colSoTien.Text = "Số tiền";
            this.colSoTien.Width = 150;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1068, 70);
            this.panelHeader.TabIndex = 100;
            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelInputs.Controls.Add(this.label2);
            this.panelInputs.Controls.Add(this.txt_Stk);
            this.panelInputs.Controls.Add(this.label3);
            this.panelInputs.Controls.Add(this.txt_Tenkh);
            this.panelInputs.Controls.Add(this.label4);
            this.panelInputs.Controls.Add(this.txt_Diachi);
            this.panelInputs.Controls.Add(this.label5);
            this.panelInputs.Controls.Add(this.txt_Sotien);
            this.panelInputs.Location = new System.Drawing.Point(20, 90);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(1028, 240);
            this.panelInputs.TabIndex = 101;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btn_Add);
            this.panelButtons.Controls.Add(this.btn_Delete);
            this.panelButtons.Controls.Add(this.btn_Out);
            this.panelButtons.Location = new System.Drawing.Point(20, 350);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1028, 70);
            this.panelButtons.TabIndex = 102;
            // 
            // panelData
            // 
            this.panelData.BackColor = System.Drawing.Color.White;
            this.panelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelData.Controls.Add(this.lv_Accounts);
            this.panelData.Location = new System.Drawing.Point(20, 440);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1028, 250);
            this.panelData.TabIndex = 103;
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelSummary.Controls.Add(this.label6);
            this.panelSummary.Controls.Add(this.txt_Tongtien);
            this.panelSummary.Location = new System.Drawing.Point(20, 710);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1028, 60);
            this.panelSummary.TabIndex = 104;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1068, 785);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản ngân hàng";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelData.ResumeLayout(false);
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        // Thêm các biến Panel vào class
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelInputs;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panelSummary;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Stk;
        private System.Windows.Forms.TextBox txt_Tenkh;
        private System.Windows.Forms.TextBox txt_Diachi;
        private System.Windows.Forms.TextBox txt_Sotien;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Out;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Tongtien;
        private System.Windows.Forms.ColumnHeader colSTT;
        private System.Windows.Forms.ColumnHeader colStk;
        private System.Windows.Forms.ColumnHeader colTenKH;
        private System.Windows.Forms.ColumnHeader colDiaChi;
        private System.Windows.Forms.ColumnHeader colSoTien;

        private System.Windows.Forms.ListView lv_Accounts;
    }
}

