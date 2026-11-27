namespace QuanLyCoSoVatChat
{
    partial class Themexcel
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
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            dgvExcel = new DataGridView();
            coltenexcel = new DataGridViewTextBoxColumn();
            colloaiexcel = new DataGridViewTextBoxColumn();
            colphongexcel = new DataGridViewTextBoxColumn();
            colsoluongexcel = new DataGridViewTextBoxColumn();
            coltinhtrangexcel = new DataGridViewTextBoxColumn();
            colghichuexcel = new DataGridViewTextBoxColumn();
            colloiexcel = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            label8 = new Label();
            label3 = new Label();
            txtThongbao = new TextBox();
            txtDuongdan = new TextBox();
            btnchonFile = new Button();
            panel4 = new Panel();
            btnLuusua = new Button();
            btnSuaexcel = new Button();
            txtTongsodong = new TextBox();
            label9 = new Label();
            label7 = new Label();
            txtKhonghople = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtHople = new TextBox();
            label4 = new Label();
            btnLuuExcel = new Button();
            btnDong = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExcel).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1164, 103);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(70, 66);
            label2.Name = "label2";
            label2.Size = new Size(569, 27);
            label2.TabIndex = 1;
            label2.Text = "Chọn file Excel , kiểm tra dữ liệu và lưu vào hệ thống";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(70, 12);
            label1.Name = "label1";
            label1.Size = new Size(457, 51);
            label1.TabIndex = 0;
            label1.Text = "Nhập dữ liệu từ Excel";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvExcel);
            panel2.Location = new Point(12, 245);
            panel2.Name = "panel2";
            panel2.Size = new Size(1164, 244);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // dgvExcel
            // 
            dgvExcel.AllowUserToAddRows = false;
            dgvExcel.AllowUserToResizeColumns = false;
            dgvExcel.AllowUserToResizeRows = false;
            dgvExcel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExcel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExcel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvExcel.BackgroundColor = SystemColors.ButtonHighlight;
            dgvExcel.BorderStyle = BorderStyle.Fixed3D;
            dgvExcel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExcel.Columns.AddRange(new DataGridViewColumn[] { coltenexcel, colloaiexcel, colphongexcel, colsoluongexcel, coltinhtrangexcel, colghichuexcel, colloiexcel });
            dgvExcel.Location = new Point(3, 3);
            dgvExcel.MultiSelect = false;
            dgvExcel.Name = "dgvExcel";
            dgvExcel.ReadOnly = true;
            dgvExcel.RowHeadersVisible = false;
            dgvExcel.RowHeadersWidth = 51;
            dgvExcel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExcel.Size = new Size(1158, 238);
            dgvExcel.TabIndex = 0;
            dgvExcel.CellContentClick += dgvExcel_CellContentClick;
            // 
            // coltenexcel
            // 
            coltenexcel.DataPropertyName = "ten";
            coltenexcel.HeaderText = "Tên";
            coltenexcel.MinimumWidth = 6;
            coltenexcel.Name = "coltenexcel";
            coltenexcel.ReadOnly = true;
            coltenexcel.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colloaiexcel
            // 
            colloaiexcel.DataPropertyName = "loai";
            colloaiexcel.HeaderText = "Loại";
            colloaiexcel.MinimumWidth = 6;
            colloaiexcel.Name = "colloaiexcel";
            colloaiexcel.ReadOnly = true;
            colloaiexcel.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colphongexcel
            // 
            colphongexcel.DataPropertyName = "phongkhuvuc";
            colphongexcel.HeaderText = "Phòng/Khu vực";
            colphongexcel.MinimumWidth = 6;
            colphongexcel.Name = "colphongexcel";
            colphongexcel.ReadOnly = true;
            colphongexcel.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colsoluongexcel
            // 
            colsoluongexcel.DataPropertyName = "soluong";
            colsoluongexcel.HeaderText = "Số lượng";
            colsoluongexcel.MinimumWidth = 6;
            colsoluongexcel.Name = "colsoluongexcel";
            colsoluongexcel.ReadOnly = true;
            colsoluongexcel.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // coltinhtrangexcel
            // 
            coltinhtrangexcel.DataPropertyName = "tinhtrang";
            coltinhtrangexcel.HeaderText = "Tình trạng";
            coltinhtrangexcel.MinimumWidth = 6;
            coltinhtrangexcel.Name = "coltinhtrangexcel";
            coltinhtrangexcel.ReadOnly = true;
            coltinhtrangexcel.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colghichuexcel
            // 
            colghichuexcel.DataPropertyName = "ghichu";
            colghichuexcel.HeaderText = "Ghi chú";
            colghichuexcel.MinimumWidth = 6;
            colghichuexcel.Name = "colghichuexcel";
            colghichuexcel.ReadOnly = true;
            colghichuexcel.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colloiexcel
            // 
            colloiexcel.DataPropertyName = "loi";
            colloiexcel.HeaderText = "Lỗi";
            colloiexcel.MinimumWidth = 6;
            colloiexcel.Name = "colloiexcel";
            colloiexcel.ReadOnly = true;
            colloiexcel.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtThongbao);
            panel3.Controls.Add(txtDuongdan);
            panel3.Controls.Add(btnchonFile);
            panel3.Location = new Point(12, 121);
            panel3.Name = "panel3";
            panel3.Size = new Size(1164, 118);
            panel3.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(281, 79);
            label8.Name = "label8";
            label8.Size = new Size(150, 28);
            label8.TabIndex = 4;
            label8.Text = "Thông báo lỗi :";
            label8.Click += label8_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(298, 43);
            label3.Name = "label3";
            label3.Size = new Size(133, 28);
            label3.TabIndex = 3;
            label3.Text = "File đã chọn :";
            // 
            // txtThongbao
            // 
            txtThongbao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtThongbao.Location = new Point(437, 79);
            txtThongbao.Name = "txtThongbao";
            txtThongbao.Size = new Size(700, 34);
            txtThongbao.TabIndex = 2;
            // 
            // txtDuongdan
            // 
            txtDuongdan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDuongdan.Location = new Point(437, 34);
            txtDuongdan.Name = "txtDuongdan";
            txtDuongdan.Size = new Size(700, 38);
            txtDuongdan.TabIndex = 1;
            // 
            // btnchonFile
            // 
            btnchonFile.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnchonFile.Location = new Point(118, 34);
            btnchonFile.Name = "btnchonFile";
            btnchonFile.Size = new Size(174, 44);
            btnchonFile.TabIndex = 0;
            btnchonFile.Text = "Chọn file Excel";
            btnchonFile.UseVisualStyleBackColor = true;
            btnchonFile.Click += btnchonFile_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLight;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(btnLuusua);
            panel4.Controls.Add(btnSuaexcel);
            panel4.Controls.Add(txtTongsodong);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(txtKhonghople);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txtHople);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(15, 495);
            panel4.Name = "panel4";
            panel4.Size = new Size(1164, 164);
            panel4.TabIndex = 3;
            // 
            // btnLuusua
            // 
            btnLuusua.Location = new Point(195, 121);
            btnLuusua.Name = "btnLuusua";
            btnLuusua.Size = new Size(94, 29);
            btnLuusua.TabIndex = 9;
            btnLuusua.Text = "Lưu sửa";
            btnLuusua.UseVisualStyleBackColor = true;
            btnLuusua.Click += btnLuusua_Click;
            // 
            // btnSuaexcel
            // 
            btnSuaexcel.Location = new Point(81, 121);
            btnSuaexcel.Name = "btnSuaexcel";
            btnSuaexcel.Size = new Size(94, 29);
            btnSuaexcel.TabIndex = 8;
            btnSuaexcel.Text = "Sửa";
            btnSuaexcel.UseVisualStyleBackColor = true;
            btnSuaexcel.Click += btnSuaexcel_Click;
            // 
            // txtTongsodong
            // 
            txtTongsodong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTongsodong.Location = new Point(195, 46);
            txtTongsodong.Name = "txtTongsodong";
            txtTongsodong.Size = new Size(40, 34);
            txtTongsodong.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(81, 56);
            label9.Name = "label9";
            label9.Size = new Size(112, 20);
            label9.TabIndex = 6;
            label9.Text = "Tổng số dòng : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(370, 54);
            label7.Name = "label7";
            label7.Size = new Size(98, 20);
            label7.TabIndex = 5;
            label7.Text = "Không hợp lệ";
            // 
            // txtKhonghople
            // 
            txtKhonghople.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtKhonghople.Location = new Point(474, 40);
            txtKhonghople.Name = "txtKhonghople";
            txtKhonghople.Size = new Size(41, 34);
            txtKhonghople.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(264, 56);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 3;
            label6.Text = "Hợp lệ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(81, 88);
            label5.Name = "label5";
            label5.Size = new Size(333, 20);
            label5.TabIndex = 2;
            label5.Text = "Vui lòng sửa các lỗi (nếu có) trước khi lưu dữ liệu";
            // 
            // txtHople
            // 
            txtHople.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtHople.Location = new Point(324, 42);
            txtHople.Name = "txtHople";
            txtHople.Size = new Size(40, 34);
            txtHople.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(81, 9);
            label4.Name = "label4";
            label4.Size = new Size(163, 28);
            label4.TabIndex = 0;
            label4.Text = "Kiểm tra kết quả";
            // 
            // btnLuuExcel
            // 
            btnLuuExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuuExcel.Location = new Point(825, 665);
            btnLuuExcel.Name = "btnLuuExcel";
            btnLuuExcel.Size = new Size(202, 51);
            btnLuuExcel.TabIndex = 4;
            btnLuuExcel.Text = "Lưu dữ liệu Excel";
            btnLuuExcel.UseVisualStyleBackColor = true;
            btnLuuExcel.Click += btnLuuExcel_Click;
            // 
            // btnDong
            // 
            btnDong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDong.Location = new Point(1033, 665);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(117, 51);
            btnDong.TabIndex = 5;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click_1;
            // 
            // Themexcel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 729);
            Controls.Add(btnDong);
            Controls.Add(btnLuuExcel);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Themexcel";
            Text = "Themexcel";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExcel).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
        private Label label3;
        private TextBox txtThongbao;
        private TextBox txtDuongdan;
        private Button btnchonFile;
        private DataGridView dgvExcel;
        private Label label4;
        private Button btnLuuExcel;
        private Button btnDong;
        private Label label5;
        private TextBox txtHople;
        private TextBox txtTongsodong;
        private Label label9;
        private Label label7;
        private TextBox txtKhonghople;
        private Label label6;
        private DataGridViewTextBoxColumn colten;
        private DataGridViewTextBoxColumn colPhong;
        private DataGridViewTextBoxColumn colsoluong;
        private DataGridViewTextBoxColumn coltinhtrang;
        private DataGridViewTextBoxColumn colghichu;
        private DataGridViewTextBoxColumn colloi;
        private DataGridViewTextBoxColumn colloai;
        private Label label8;
        private Button btnLuusua;
        private Button btnSuaexcel;
        private DataGridViewTextBoxColumn coltenexcel;
        private DataGridViewTextBoxColumn colloaiexcel;
        private DataGridViewTextBoxColumn colphongexcel;
        private DataGridViewTextBoxColumn colsoluongexcel;
        private DataGridViewTextBoxColumn coltinhtrangexcel;
        private DataGridViewTextBoxColumn colghichuexcel;
        private DataGridViewTextBoxColumn colloiexcel;
    }
}