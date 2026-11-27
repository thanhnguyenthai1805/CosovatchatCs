using Microsoft.Data.SqlClient;
using System.Data;

namespace QuanLyCoSoVatChat
{
    partial class LoaiCoSoVatChat
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void loadLoai()
        {
            string sql = @"
    SELECT MaLoai, TenLoai
    FROM LoaiCoSoVatChat
    ORDER BY TRY_CONVERT(INT, SUBSTRING(MaLoai, 5, 10)) ASC";
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgvLoaicosovatchat.AutoGenerateColumns = false;
                        dgvLoaicosovatchat.DataSource = dt;

                        dgvLoaicosovatchat.ClearSelection();
                        dgvLoaicosovatchat.CurrentCell = null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải loại cơ sở vật chất: " + ex.Message);
            }

        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            dgvLoaicosovatchat = new DataGridView();
            colMaloai = new DataGridViewTextBoxColumn();
            colTenloai = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            txtTenloai = new TextBox();
            txtMaloai = new TextBox();
            btnLamtrong = new Button();
            btnThoatloai = new Button();
            btnLuuloai = new Button();
            btnXoaloai = new Button();
            btnCapnhatloai = new Button();
            btnThemloai = new Button();
            label3 = new Label();
            label2 = new Label();
            btnThoatdangnhap = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaicosovatchat).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(dgvLoaicosovatchat);
            panel1.Location = new Point(12, 173);
            panel1.Name = "panel1";
            panel1.Size = new Size(549, 439);
            panel1.TabIndex = 0;
            // 
            // dgvLoaicosovatchat
            // 
            dgvLoaicosovatchat.AllowUserToAddRows = false;
            dgvLoaicosovatchat.AllowUserToOrderColumns = true;
            dgvLoaicosovatchat.AllowUserToResizeColumns = false;
            dgvLoaicosovatchat.AllowUserToResizeRows = false;
            dgvLoaicosovatchat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaicosovatchat.BackgroundColor = SystemColors.ButtonHighlight;
            dgvLoaicosovatchat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoaicosovatchat.Columns.AddRange(new DataGridViewColumn[] { colMaloai, colTenloai });
            dgvLoaicosovatchat.Dock = DockStyle.Fill;
            dgvLoaicosovatchat.GridColor = SystemColors.HighlightText;
            dgvLoaicosovatchat.Location = new Point(0, 0);
            dgvLoaicosovatchat.MultiSelect = false;
            dgvLoaicosovatchat.Name = "dgvLoaicosovatchat";
            dgvLoaicosovatchat.RowHeadersVisible = false;
            dgvLoaicosovatchat.RowHeadersWidth = 51;
            dgvLoaicosovatchat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaicosovatchat.Size = new Size(545, 435);
            dgvLoaicosovatchat.TabIndex = 0;
            dgvLoaicosovatchat.CellClick += dgvLoaicosovatchat_CellClick;
            dgvLoaicosovatchat.CellContentClick += dgvLoaicosovatchat_CellContentClick;
            // 
            // colMaloai
            // 
            colMaloai.DataPropertyName = "maloai";
            colMaloai.FillWeight = 30F;
            colMaloai.HeaderText = "Mã";
            colMaloai.MinimumWidth = 6;
            colMaloai.Name = "colMaloai";
            colMaloai.ReadOnly = true;
            // 
            // colTenloai
            // 
            colTenloai.DataPropertyName = "tenloai";
            colTenloai.HeaderText = "Tên loại";
            colTenloai.MinimumWidth = 6;
            colTenloai.Name = "colTenloai";
            colTenloai.ReadOnly = true;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(1059, 144);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(3, 28);
            label1.Name = "label1";
            label1.Size = new Size(604, 54);
            label1.TabIndex = 0;
            label1.Text = "Quản lý loại cơ sở vật chất";
            label1.Click += label1_Click;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(btnThoatdangnhap);
            panel3.Controls.Add(txtTenloai);
            panel3.Controls.Add(txtMaloai);
            panel3.Controls.Add(btnLamtrong);
            panel3.Controls.Add(btnThoatloai);
            panel3.Controls.Add(btnLuuloai);
            panel3.Controls.Add(btnXoaloai);
            panel3.Controls.Add(btnCapnhatloai);
            panel3.Controls.Add(btnThemloai);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(567, 173);
            panel3.Name = "panel3";
            panel3.Size = new Size(504, 437);
            panel3.TabIndex = 2;
            // 
            // txtTenloai
            // 
            txtTenloai.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTenloai.Location = new Point(107, 109);
            txtTenloai.Name = "txtTenloai";
            txtTenloai.Size = new Size(378, 38);
            txtTenloai.TabIndex = 9;
            txtTenloai.TextChanged += textBox2_TextChanged;
            // 
            // txtMaloai
            // 
            txtMaloai.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMaloai.Location = new Point(107, 46);
            txtMaloai.Name = "txtMaloai";
            txtMaloai.Size = new Size(378, 38);
            txtMaloai.TabIndex = 8;
            // 
            // btnLamtrong
            // 
            btnLamtrong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLamtrong.Location = new Point(359, 280);
            btnLamtrong.Name = "btnLamtrong";
            btnLamtrong.Size = new Size(143, 54);
            btnLamtrong.TabIndex = 7;
            btnLamtrong.Text = "Làm trống";
            btnLamtrong.UseVisualStyleBackColor = true;
            btnLamtrong.Click += btnLamtrong_Click;
            // 
            // btnThoatloai
            // 
            btnThoatloai.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThoatloai.Location = new Point(205, 280);
            btnThoatloai.Name = "btnThoatloai";
            btnThoatloai.Size = new Size(143, 54);
            btnThoatloai.TabIndex = 6;
            btnThoatloai.Text = "Thoát";
            btnThoatloai.UseVisualStyleBackColor = true;
            btnThoatloai.Click += button5_Click;
            // 
            // btnLuuloai
            // 
            btnLuuloai.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLuuloai.Location = new Point(30, 280);
            btnLuuloai.Name = "btnLuuloai";
            btnLuuloai.Size = new Size(143, 54);
            btnLuuloai.TabIndex = 5;
            btnLuuloai.Text = "Lưu";
            btnLuuloai.UseVisualStyleBackColor = true;
            btnLuuloai.Click += btnLuuloai_Click;
            // 
            // btnXoaloai
            // 
            btnXoaloai.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoaloai.Location = new Point(359, 191);
            btnXoaloai.Name = "btnXoaloai";
            btnXoaloai.Size = new Size(143, 54);
            btnXoaloai.TabIndex = 4;
            btnXoaloai.Text = "Xóa";
            btnXoaloai.UseVisualStyleBackColor = true;
            btnXoaloai.Click += btnXoaloai_Click;
            // 
            // btnCapnhatloai
            // 
            btnCapnhatloai.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCapnhatloai.Location = new Point(205, 191);
            btnCapnhatloai.Name = "btnCapnhatloai";
            btnCapnhatloai.Size = new Size(143, 54);
            btnCapnhatloai.TabIndex = 3;
            btnCapnhatloai.Text = "Cập nhật";
            btnCapnhatloai.UseVisualStyleBackColor = true;
            btnCapnhatloai.Click += btnCapnhatloai_Click;
            // 
            // btnThemloai
            // 
            btnThemloai.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThemloai.Location = new Point(30, 191);
            btnThemloai.Name = "btnThemloai";
            btnThemloai.Size = new Size(143, 54);
            btnThemloai.TabIndex = 2;
            btnThemloai.Text = "Thêm mới";
            btnThemloai.UseVisualStyleBackColor = true;
            btnThemloai.Click += btnThemloai_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 121);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 1;
            label3.Text = "Tên Loại :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 64);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã :";
            label2.Click += label2_Click;
            // 
            // btnThoatdangnhap
            // 
            btnThoatdangnhap.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoatdangnhap.Location = new Point(359, 372);
            btnThoatdangnhap.Name = "btnThoatdangnhap";
            btnThoatdangnhap.Size = new Size(138, 46);
            btnThoatdangnhap.TabIndex = 10;
            btnThoatdangnhap.Text = "Thoát";
            btnThoatdangnhap.UseVisualStyleBackColor = true;
            btnThoatdangnhap.Click += btnThoatdangnhap_Click;
            // 
            // LoaiCoSoVatChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 624);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "LoaiCoSoVatChat";
            Text = "LoaiCoSoVatChat";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoaicosovatchat).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private DataGridView dgvLoaicosovatchat;
        private TextBox txtTenloai;
        private TextBox txtMaloai;
        private Button btnLamtrong;
        private Button btnThoatloai;
        private Button btnLuuloai;
        private Button btnXoaloai;
        private Button btnCapnhatloai;
        private Button btnThemloai;
        private Label label3;
        private Label label2;
        private DataGridViewTextBoxColumn colMaloai;
        private DataGridViewTextBoxColumn colTenloai;
        private Button btnThoatdangnhap;
    }
}