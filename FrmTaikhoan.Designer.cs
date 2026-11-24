namespace QuanLyCoSoVatChat
{
    partial class FrmTaikhoan
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
            panel1 = new Panel();
            dgvTaikhoan = new DataGridView();
            panel2 = new Panel();
            BtnThoatTk = new Button();
            BtnLuuTk = new Button();
            BtnLamtrongTk = new Button();
            BTnXoaTk = new Button();
            BtnSuaTk = new Button();
            BtnThemTK = new Button();
            cboVaitro = new ComboBox();
            txtMatkhau = new TextBox();
            txtTendangnhap = new TextBox();
            txtNgaytao = new TextBox();
            txtMataikhoan = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            panel4 = new Panel();
            label1 = new Label();
            label9 = new Label();
            panel5 = new Panel();
            colMataikhoan = new DataGridViewTextBoxColumn();
            colTendangnhap = new DataGridViewTextBoxColumn();
            colMatkhau = new DataGridViewTextBoxColumn();
            colVaitro = new DataGridViewTextBoxColumn();
            colNgaytao = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaikhoan).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dgvTaikhoan);
            panel1.Location = new Point(12, 122);
            panel1.Name = "panel1";
            panel1.Size = new Size(493, 430);
            panel1.TabIndex = 0;
            // 
            // dgvTaikhoan
            // 
            dgvTaikhoan.AllowUserToAddRows = false;
            dgvTaikhoan.AllowUserToDeleteRows = false;
            dgvTaikhoan.AllowUserToOrderColumns = true;
            dgvTaikhoan.AllowUserToResizeColumns = false;
            dgvTaikhoan.AllowUserToResizeRows = false;
            dgvTaikhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaikhoan.BackgroundColor = SystemColors.ButtonHighlight;
            dgvTaikhoan.BorderStyle = BorderStyle.Fixed3D;
            dgvTaikhoan.ColumnHeadersHeight = 29;
            dgvTaikhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTaikhoan.Columns.AddRange(new DataGridViewColumn[] { colMataikhoan, colTendangnhap, colMatkhau, colVaitro, colNgaytao });
            dgvTaikhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTaikhoan.Location = new Point(3, 3);
            dgvTaikhoan.MultiSelect = false;
            dgvTaikhoan.Name = "dgvTaikhoan";
            dgvTaikhoan.ReadOnly = true;
            dgvTaikhoan.RowHeadersVisible = false;
            dgvTaikhoan.RowHeadersWidth = 51;
            dgvTaikhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaikhoan.Size = new Size(493, 427);
            dgvTaikhoan.TabIndex = 0;
            dgvTaikhoan.CellClick += dgvTaikhoan_CellClick;
            dgvTaikhoan.CellContentClick += dgvTaikhoan_CellClick;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(BtnThoatTk);
            panel2.Controls.Add(BtnLuuTk);
            panel2.Controls.Add(BtnLamtrongTk);
            panel2.Controls.Add(BTnXoaTk);
            panel2.Controls.Add(BtnSuaTk);
            panel2.Controls.Add(BtnThemTK);
            panel2.Controls.Add(cboVaitro);
            panel2.Controls.Add(txtMatkhau);
            panel2.Controls.Add(txtTendangnhap);
            panel2.Controls.Add(txtNgaytao);
            panel2.Controls.Add(txtMataikhoan);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(524, 122);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 430);
            panel2.TabIndex = 1;
            // 
            // BtnThoatTk
            // 
            BtnThoatTk.Location = new Point(119, 360);
            BtnThoatTk.Name = "BtnThoatTk";
            BtnThoatTk.Size = new Size(94, 29);
            BtnThoatTk.TabIndex = 18;
            BtnThoatTk.Text = "Thoát";
            BtnThoatTk.UseVisualStyleBackColor = true;
            BtnThoatTk.Click += BtnThoatTk_Click;
            // 
            // BtnLuuTk
            // 
            BtnLuuTk.Location = new Point(10, 360);
            BtnLuuTk.Name = "BtnLuuTk";
            BtnLuuTk.Size = new Size(94, 29);
            BtnLuuTk.TabIndex = 17;
            BtnLuuTk.Text = "Lưu";
            BtnLuuTk.UseVisualStyleBackColor = true;
            BtnLuuTk.Click += BtnLuuTk_Click;
            // 
            // BtnLamtrongTk
            // 
            BtnLamtrongTk.Location = new Point(331, 308);
            BtnLamtrongTk.Name = "BtnLamtrongTk";
            BtnLamtrongTk.Size = new Size(94, 29);
            BtnLamtrongTk.TabIndex = 16;
            BtnLamtrongTk.Text = "Làm trống";
            BtnLamtrongTk.UseVisualStyleBackColor = true;
            BtnLamtrongTk.Click += BtnLamtrongTk_Click;
            // 
            // BTnXoaTk
            // 
            BTnXoaTk.Location = new Point(229, 308);
            BTnXoaTk.Name = "BTnXoaTk";
            BTnXoaTk.Size = new Size(94, 29);
            BTnXoaTk.TabIndex = 15;
            BTnXoaTk.Text = "Xóa";
            BTnXoaTk.UseVisualStyleBackColor = true;
            BTnXoaTk.Click += BTnXoaTk_Click;
            // 
            // BtnSuaTk
            // 
            BtnSuaTk.Location = new Point(119, 308);
            BtnSuaTk.Name = "BtnSuaTk";
            BtnSuaTk.Size = new Size(94, 29);
            BtnSuaTk.TabIndex = 14;
            BtnSuaTk.Text = "Sửa";
            BtnSuaTk.UseVisualStyleBackColor = true;
            BtnSuaTk.Click += BtnSuaTk_Click;
            // 
            // BtnThemTK
            // 
            BtnThemTK.Location = new Point(10, 308);
            BtnThemTK.Name = "BtnThemTK";
            BtnThemTK.Size = new Size(94, 29);
            BtnThemTK.TabIndex = 13;
            BtnThemTK.Text = "Thêm";
            BtnThemTK.UseVisualStyleBackColor = true;
            BtnThemTK.Click += BtnThemTK_Click;
            // 
            // cboVaitro
            // 
            cboVaitro.FormattingEnabled = true;
            cboVaitro.Location = new Point(151, 176);
            cboVaitro.Name = "cboVaitro";
            cboVaitro.Size = new Size(227, 28);
            cboVaitro.TabIndex = 12;
            // 
            // txtMatkhau
            // 
            txtMatkhau.Location = new Point(151, 131);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.Size = new Size(227, 27);
            txtMatkhau.TabIndex = 9;
            // 
            // txtTendangnhap
            // 
            txtTendangnhap.Location = new Point(151, 73);
            txtTendangnhap.Name = "txtTendangnhap";
            txtTendangnhap.Size = new Size(227, 27);
            txtTendangnhap.TabIndex = 8;
            txtTendangnhap.TextChanged += txtTendangnhap_TextChanged;
            // 
            // txtNgaytao
            // 
            txtNgaytao.Location = new Point(151, 228);
            txtNgaytao.Name = "txtNgaytao";
            txtNgaytao.Size = new Size(227, 27);
            txtNgaytao.TabIndex = 7;
            // 
            // txtMataikhoan
            // 
            txtMataikhoan.Location = new Point(151, 15);
            txtMataikhoan.Name = "txtMataikhoan";
            txtMataikhoan.Size = new Size(227, 27);
            txtMataikhoan.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 235);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 5;
            label7.Text = "Ngày tạo :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 184);
            label6.Name = "label6";
            label6.Size = new Size(63, 20);
            label6.TabIndex = 4;
            label6.Text = "Vai trò : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 194);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 138);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 2;
            label4.Text = "Mật khẩu :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 76);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 1;
            label3.Text = "Tên đăng nhập : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 22);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã tài khoản :";
            // 
            // panel3
            // 
            panel3.Controls.Add(label8);
            panel3.Location = new Point(12, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(493, 36);
            panel3.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 8);
            label8.Name = "label8";
            label8.Size = new Size(197, 28);
            label8.TabIndex = 0;
            label8.Text = "Danh sách tài khoản";
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Location = new Point(524, 80);
            panel4.Name = "panel4";
            panel4.Size = new Size(428, 36);
            panel4.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(192, 28);
            label1.TabIndex = 0;
            label1.Text = "Thông tin tài khoản";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(23, 11);
            label9.Name = "label9";
            label9.Size = new Size(402, 38);
            label9.TabIndex = 4;
            label9.Text = "Quản lý Tài khoản đăng nhập";
            label9.Click += label9_Click;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveCaption;
            panel5.Controls.Add(label9);
            panel5.Location = new Point(12, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(938, 64);
            panel5.TabIndex = 5;
            // 
            // colMataikhoan
            // 
            colMataikhoan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMataikhoan.DataPropertyName = "mataikhoan";
            colMataikhoan.FillWeight = 45.17598F;
            colMataikhoan.HeaderText = "Mã tài khoản";
            colMataikhoan.MinimumWidth = 6;
            colMataikhoan.Name = "colMataikhoan";
            colMataikhoan.ReadOnly = true;
            colMataikhoan.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTendangnhap
            // 
            colTendangnhap.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTendangnhap.DataPropertyName = "tendangnhap";
            colTendangnhap.FillWeight = 161.216141F;
            colTendangnhap.HeaderText = "Tên đăng nhập";
            colTendangnhap.MinimumWidth = 6;
            colTendangnhap.Name = "colTendangnhap";
            colTendangnhap.ReadOnly = true;
            colTendangnhap.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colMatkhau
            // 
            colMatkhau.DataPropertyName = "matkhau";
            colMatkhau.HeaderText = "Mật khẩu";
            colMatkhau.MinimumWidth = 6;
            colMatkhau.Name = "colMatkhau";
            colMatkhau.ReadOnly = true;
            colMatkhau.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colVaitro
            // 
            colVaitro.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colVaitro.DataPropertyName = "vaitro";
            colVaitro.FillWeight = 105.614952F;
            colVaitro.HeaderText = "Vai trò";
            colVaitro.MinimumWidth = 6;
            colVaitro.Name = "colVaitro";
            colVaitro.ReadOnly = true;
            colVaitro.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colNgaytao
            // 
            colNgaytao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNgaytao.DataPropertyName = "ngaytao";
            colNgaytao.FillWeight = 82.992836F;
            colNgaytao.HeaderText = "Ngày Tạo";
            colNgaytao.MinimumWidth = 6;
            colNgaytao.Name = "colNgaytao";
            colNgaytao.ReadOnly = true;
            colNgaytao.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmTaikhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 564);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Name = "FrmTaikhoan";
            Text = "Quản lý tài khoản";
            Load += FrmTaikhoan_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTaikhoan).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private void txtTendangnhap_TextChanged(object sender, EventArgs e)
        {

        }
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private DataGridView dgvTaikhoan;
        private TextBox txtMatkhau;
        private TextBox txtTendangnhap;
        private TextBox txtNgaytao;
        private TextBox txtMataikhoan;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cboVaitro;
        private Button BtnLamtrongTk;
        private Button BTnXoaTk;
        private Button BtnSuaTk;
        private Button BtnThemTK;
        private Button BtnThoatTk;
        private Button BtnLuuTk;
        private Label label8;
        private Label label9;
        private Panel panel5;
        private DataGridViewTextBoxColumn colMataikhoan;
        private DataGridViewTextBoxColumn colTendangnhap;
        private DataGridViewTextBoxColumn colMatkhau;
        private DataGridViewTextBoxColumn colVaitro;
        private DataGridViewTextBoxColumn colNgaytao;
    }
}