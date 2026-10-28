using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace QuanLyCoSoVatChat
{
    partial class Form1
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

        private void loadData()
        {
            string sql = @"
        SELECT
            c.Ma,
            c.Ten,
            c.MaLoai,
            l.TenLoai AS Loai,
            c.PhongKhuVuc,
            c.SoLuong,
            c.TinhTrang,
            c.NgayNhap,
            c.GhiChu
        FROM CoSoVatChat c
        INNER JOIN LoaiCoSoVatChat l
            ON c.MaLoai = l.MaLoai
        ORDER BY c.Ma";
           
            try
            {
                using(SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCosovatchat.DataSource = dt;
                }
                if (dgvCosovatchat.Columns.Contains("MaLoai"))
                {
                    dgvCosovatchat.Columns["MaLoai"].Visible = false;
                }

                // Định dạng ngày nhập
                if (dgvCosovatchat.Columns.Contains("NgayNhap"))
                {
                    dgvCosovatchat.Columns["NgayNhap"]
                        .DefaultCellStyle.Format = "yyyy-MM-dd";
                }

                // Bỏ chọn dòng sau khi tải dữ liệu
                dgvCosovatchat.ClearSelection();
                dgvCosovatchat.CurrentCell = null;
            }
            catch(
            Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu" + ex.Message);
            }
            dgvCosovatchat.ClearSelection();
            dgvCosovatchat.CurrentCell = null;
            dgvCosovatchat.Columns["colNgaynhap"].DefaultCellStyle.Format = "yyyy-MM-dd";

        }
        private void loadLoai()
        {
            string sql = @"select maloai,tenloai from loaicosovatchat order by maloai asc";
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboLoai.DataSource = dt;
                    cboLoai.DisplayMember = "TenLoai";
                    cboLoai.ValueMember = "MaLoai";
                    cboLoai.SelectedIndex = -1;
                }
               
            }
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            panel1 = new Panel();
            label12 = new Label();
            panel2 = new Panel();
            dgvCosovatchat = new DataGridView();
            colma = new DataGridViewTextBoxColumn();
            colTen = new DataGridViewTextBoxColumn();
            colLoai = new DataGridViewTextBoxColumn();
            colPhong = new DataGridViewTextBoxColumn();
            ColSoluong = new DataGridViewTextBoxColumn();
            colTinhtrang = new DataGridViewTextBoxColumn();
            ColNgaynhap = new DataGridViewTextBoxColumn();
            ColGhichu = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            txtMa = new TextBox();
            label13 = new Label();
            btnThemloai = new Button();
            btnCapnhat = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnThoat = new Button();
            btnLamtrong = new Button();
            btnThem = new Button();
            txtGhichu = new TextBox();
            cboTinhtrang = new ComboBox();
            cboLoai = new ComboBox();
            txtPhong = new TextBox();
            txtNgaynhap = new TextBox();
            txtSoluong = new TextBox();
            txtTen = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtTimkiem = new TextBox();
            btnTimkiem = new Button();
            btnLoadtable = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCosovatchat).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(828, 60);
            label1.TabIndex = 0;
            label1.Text = "HỆ THỐNG QUẢN LÝ CƠ SỞ VẬT CHẤT";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label1);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(12, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(1222, 125);
            panel1.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(14, 79);
            label12.Name = "label12";
            label12.Size = new Size(556, 31);
            label12.TabIndex = 2;
            label12.Text = "Theo dõi phòng học, thiết bị và tình trạng sử dụng";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(dgvCosovatchat);
            panel2.Location = new Point(12, 245);
            panel2.Name = "panel2";
            panel2.Size = new Size(692, 534);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // dgvCosovatchat
            // 
            dgvCosovatchat.AllowUserToAddRows = false;
            dgvCosovatchat.AllowUserToDeleteRows = false;
            dgvCosovatchat.AllowUserToResizeColumns = false;
            dgvCosovatchat.AllowUserToResizeRows = false;
            dgvCosovatchat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCosovatchat.BackgroundColor = SystemColors.ButtonHighlight;
            dgvCosovatchat.BorderStyle = BorderStyle.Fixed3D;
            dgvCosovatchat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCosovatchat.Columns.AddRange(new DataGridViewColumn[] { colma, colTen, colLoai, colPhong, ColSoluong, colTinhtrang, ColNgaynhap, ColGhichu });
            dgvCosovatchat.Dock = DockStyle.Fill;
            dgvCosovatchat.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCosovatchat.GridColor = SystemColors.ControlDarkDark;
            dgvCosovatchat.Location = new Point(0, 0);
            dgvCosovatchat.MultiSelect = false;
            dgvCosovatchat.Name = "dgvCosovatchat";
            dgvCosovatchat.ReadOnly = true;
            dgvCosovatchat.RowHeadersVisible = false;
            dgvCosovatchat.RowHeadersWidth = 51;
            dgvCosovatchat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCosovatchat.Size = new Size(688, 530);
            dgvCosovatchat.TabIndex = 1;
            dgvCosovatchat.CellClick += dgvCosovatchat_CellClick;
            dgvCosovatchat.CellContentClick += dgvCosovatchat_CellContentClick;
            // 
            // colma
            // 
            colma.DataPropertyName = "ma";
            colma.FillWeight = 50F;
            colma.HeaderText = "Mã";
            colma.MinimumWidth = 6;
            colma.Name = "colma";
            colma.ReadOnly = true;
            colma.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTen
            // 
            colTen.DataPropertyName = "ten";
            colTen.HeaderText = "Tên cơ sở";
            colTen.MinimumWidth = 6;
            colTen.Name = "colTen";
            colTen.ReadOnly = true;
            colTen.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colLoai
            // 
            colLoai.DataPropertyName = "loai";
            colLoai.HeaderText = "Loại";
            colLoai.MinimumWidth = 6;
            colLoai.Name = "colLoai";
            colLoai.ReadOnly = true;
            colLoai.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colPhong
            // 
            colPhong.DataPropertyName = "phongkhuvuc";
            colPhong.HeaderText = "Phòng / Khu vực";
            colPhong.MinimumWidth = 6;
            colPhong.Name = "colPhong";
            colPhong.ReadOnly = true;
            colPhong.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSoluong
            // 
            ColSoluong.DataPropertyName = "soluong";
            ColSoluong.FillWeight = 50F;
            ColSoluong.HeaderText = "Số lượng";
            ColSoluong.MinimumWidth = 6;
            ColSoluong.Name = "ColSoluong";
            ColSoluong.ReadOnly = true;
            ColSoluong.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colTinhtrang
            // 
            colTinhtrang.DataPropertyName = "tinhtrang";
            colTinhtrang.HeaderText = "Tình trạng";
            colTinhtrang.MinimumWidth = 6;
            colTinhtrang.Name = "colTinhtrang";
            colTinhtrang.ReadOnly = true;
            colTinhtrang.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColNgaynhap
            // 
            ColNgaynhap.DataPropertyName = "ngaynhap";
            ColNgaynhap.HeaderText = "Ngày nhập";
            ColNgaynhap.MinimumWidth = 6;
            ColNgaynhap.Name = "ColNgaynhap";
            ColNgaynhap.ReadOnly = true;
            ColNgaynhap.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColGhichu
            // 
            ColGhichu.DataPropertyName = "ghichu";
            ColGhichu.HeaderText = "Ghi chú";
            ColGhichu.MinimumWidth = 6;
            ColGhichu.Name = "ColGhichu";
            ColGhichu.ReadOnly = true;
            ColGhichu.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(txtMa);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(btnThemloai);
            panel3.Controls.Add(btnCapnhat);
            panel3.Controls.Add(btnXoa);
            panel3.Controls.Add(btnLuu);
            panel3.Controls.Add(btnThoat);
            panel3.Controls.Add(btnLamtrong);
            panel3.Controls.Add(btnThem);
            panel3.Controls.Add(txtGhichu);
            panel3.Controls.Add(cboTinhtrang);
            panel3.Controls.Add(cboLoai);
            panel3.Controls.Add(txtPhong);
            panel3.Controls.Add(txtNgaynhap);
            panel3.Controls.Add(txtSoluong);
            panel3.Controls.Add(txtTen);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(734, 245);
            panel3.Name = "panel3";
            panel3.Size = new Size(500, 534);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // txtMa
            // 
            txtMa.Location = new Point(177, 21);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(307, 27);
            txtMa.TabIndex = 29;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(32, 28);
            label13.Name = "label13";
            label13.Size = new Size(37, 20);
            label13.TabIndex = 28;
            label13.Text = "Mã :";
            // 
            // btnThemloai
            // 
            btnThemloai.Location = new Point(452, 119);
            btnThemloai.Name = "btnThemloai";
            btnThemloai.Size = new Size(32, 28);
            btnThemloai.TabIndex = 27;
            btnThemloai.Text = "+";
            btnThemloai.UseVisualStyleBackColor = true;
            btnThemloai.Click += btnThemloai_Click;
            // 
            // btnCapnhat
            // 
            btnCapnhat.Location = new Point(169, 437);
            btnCapnhat.Name = "btnCapnhat";
            btnCapnhat.Size = new Size(94, 29);
            btnCapnhat.TabIndex = 26;
            btnCapnhat.Text = "Cập nhật";
            btnCapnhat.UseVisualStyleBackColor = true;
            btnCapnhat.Click += btnCapnhat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(291, 437);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 25;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(41, 482);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 24;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(169, 482);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 23;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnLamtrong
            // 
            btnLamtrong.Location = new Point(291, 482);
            btnLamtrong.Name = "btnLamtrong";
            btnLamtrong.Size = new Size(94, 29);
            btnLamtrong.TabIndex = 22;
            btnLamtrong.Text = "Làm trống";
            btnLamtrong.UseVisualStyleBackColor = true;
            btnLamtrong.Click += btnLamtrong_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(41, 437);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 21;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtGhichu
            // 
            txtGhichu.Location = new Point(177, 375);
            txtGhichu.Name = "txtGhichu";
            txtGhichu.Size = new Size(309, 27);
            txtGhichu.TabIndex = 20;
            // 
            // cboTinhtrang
            // 
            cboTinhtrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhtrang.FormattingEnabled = true;
            cboTinhtrang.Items.AddRange(new object[] { "Đang sử dụng", "Cần sửa chữa", "Hỏng", "Thanh lý" });
            cboTinhtrang.Location = new Point(177, 272);
            cboTinhtrang.Name = "cboTinhtrang";
            cboTinhtrang.Size = new Size(309, 28);
            cboTinhtrang.TabIndex = 16;
            // 
            // cboLoai
            // 
            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoai.FormattingEnabled = true;
            cboLoai.Location = new Point(177, 119);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(275, 28);
            cboLoai.TabIndex = 15;
            cboLoai.SelectedIndexChanged += cboPhong_SelectedIndexChanged;
            // 
            // txtPhong
            // 
            txtPhong.Location = new Point(177, 166);
            txtPhong.Name = "txtPhong";
            txtPhong.Size = new Size(309, 27);
            txtPhong.TabIndex = 14;
            // 
            // txtNgaynhap
            // 
            txtNgaynhap.Location = new Point(177, 325);
            txtNgaynhap.Name = "txtNgaynhap";
            txtNgaynhap.Size = new Size(309, 27);
            txtNgaynhap.TabIndex = 11;
            // 
            // txtSoluong
            // 
            txtSoluong.Location = new Point(177, 218);
            txtSoluong.Name = "txtSoluong";
            txtSoluong.Size = new Size(309, 27);
            txtSoluong.TabIndex = 9;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(177, 70);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(309, 27);
            txtTen.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(31, 77);
            label9.Name = "label9";
            label9.Size = new Size(39, 20);
            label9.TabIndex = 7;
            label9.Text = "Tên :";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(31, 122);
            label8.Name = "label8";
            label8.Size = new Size(44, 20);
            label8.TabIndex = 6;
            label8.Text = "Loại :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 173);
            label7.Name = "label7";
            label7.Size = new Size(122, 20);
            label7.TabIndex = 5;
            label7.Text = "Phòng / khu vực :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 225);
            label6.Name = "label6";
            label6.Size = new Size(80, 20);
            label6.TabIndex = 4;
            label6.Text = "Số lượng : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 280);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 3;
            label5.Text = "Tình trạng : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 332);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 2;
            label4.Text = "Ngày nhập :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 375);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 1;
            label3.Text = "Ghi chú :";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(724, 213);
            label2.Name = "label2";
            label2.Size = new Size(176, 28);
            label2.TabIndex = 0;
            label2.Text = "Thông tin bản ghi";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 213);
            label10.Name = "label10";
            label10.Size = new Size(270, 31);
            label10.TabIndex = 0;
            label10.Text = "Danh sách cơ sở vật chất";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(12, 164);
            label11.Name = "label11";
            label11.Size = new Size(393, 31);
            label11.TabIndex = 4;
            label11.Text = "Tìm kiếm theo tên, loại hoặc phòng :";
            // 
            // txtTimkiem
            // 
            txtTimkiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimkiem.Location = new Point(411, 161);
            txtTimkiem.Name = "txtTimkiem";
            txtTimkiem.Size = new Size(620, 34);
            txtTimkiem.TabIndex = 5;
            txtTimkiem.TextChanged += txtTimkiem_TextChanged;
            // 
            // btnTimkiem
            // 
            btnTimkiem.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTimkiem.Location = new Point(1037, 166);
            btnTimkiem.Name = "btnTimkiem";
            btnTimkiem.Size = new Size(94, 29);
            btnTimkiem.TabIndex = 6;
            btnTimkiem.Text = "Tìm kiếm";
            btnTimkiem.UseVisualStyleBackColor = true;
            btnTimkiem.Click += btnTimkiem_Click;
            // 
            // btnLoadtable
            // 
            btnLoadtable.Location = new Point(1140, 166);
            btnLoadtable.Name = "btnLoadtable";
            btnLoadtable.Size = new Size(94, 29);
            btnLoadtable.TabIndex = 7;
            btnLoadtable.Text = "Load table";
            btnLoadtable.UseVisualStyleBackColor = true;
            btnLoadtable.Click += btnLoadtable_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1246, 813);
            Controls.Add(btnLoadtable);
            Controls.Add(btnTimkiem);
            Controls.Add(txtTimkiem);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Thái Thành";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCosovatchat).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtPhong;
        private TextBox txtNgaynhap;
        private TextBox txtSoluong;
        private TextBox txtTen;
        private ComboBox cboTinhtrang;
        private ComboBox cboLoai;
        private Button btnCapnhat;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnThoat;
        private Button btnLamtrong;
        private Button btnThem;
        private TextBox txtGhichu;
        private DataGridView dgvCosovatchat;
        private Label label10;
        private Label label12;
        private Label label11;
        private TextBox txtTimkiem;
        private Button btnTimkiem;
        private Button btnLoadtable;
        private Button btnThemloai;
        private DataGridViewTextBoxColumn colma;
        private DataGridViewTextBoxColumn colTen;
        private DataGridViewTextBoxColumn colLoai;
        private DataGridViewTextBoxColumn colPhong;
        private DataGridViewTextBoxColumn ColSoluong;
        private DataGridViewTextBoxColumn colTinhtrang;
        private DataGridViewTextBoxColumn ColNgaynhap;
        private DataGridViewTextBoxColumn ColGhichu;
        private Label label13;
        private TextBox txtMa;
        private ContextMenuStrip contextMenuStrip1;
    }
}
