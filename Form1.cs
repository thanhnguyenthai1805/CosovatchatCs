using Microsoft.Data.SqlClient;
using System.Data;

namespace QuanLyCoSoVatChat
{
    public partial class Form1 : Form
    {
        private string TaoMa()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        private int tim = 0;
        private string chon = "";
        public Form1()
        {   

            InitializeComponent();
            loadLoai();
            loadData();
            onOff(false);
        }
        private void clearForm()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtSoluong.Clear();
            txtNgaynhap.Clear();
            txtPhong.Clear();
            txtGhichu.Clear();
            cboLoai.SelectedIndex = -1;
            cboLoai.Text = "";
            cboTinhtrang.SelectedIndex = -1;
            chon = "";
            dgvCosovatchat.ClearSelection();
        }
        private bool kiemtraten(string ten)
        {
            string sql;
            if (tim == 1)
            {
                sql = "select count(*) from cosovatchat where ten = @ten";
            }
            else
            {
                sql = "select count(*) from cosovatchat where ten = @ten and ma <> @ma ";
            }
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", ten.Trim());
                    if (tim == -1)
                    {
                        cmd.Parameters.AddWithValue("@ma", chon);
                    }
                    int dem = Convert.ToInt32(cmd.ExecuteScalar());
                    return dem > 0;
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvCosovatchat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvCosovatchat.SelectedRows.Count == 0 || chon == "")
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!");
                return;
            }

            string ma = Convert.ToString(
                dgvCosovatchat.CurrentRow.Cells["colma"].Value
            );

            if (MessageBox.Show("Bạn có chắc muốn xóa không?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "DELETE FROM CoSoVatChat WHERE Ma = @Ma";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Ma", SqlDbType.VarChar, 30).Value = ma;

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Xóa thành công!");
            chon = "";
            loadData();
            clearForm();
        }

        private void dgvCosovatchat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvCosovatchat.Rows[e.RowIndex];
            chon = Convert.ToString(row.Cells["colma"].Value);
            txtMa.Text = row.Cells["colma"].Value?.ToString() ?? "";
            txtTen.Text = row.Cells["colTen"].Value?.ToString() ?? "";
            cboLoai.Text = row.Cells["colLoai"].Value?.ToString() ?? "";
            txtPhong.Text = row.Cells["colPhong"].Value?.ToString() ?? "";
            txtSoluong.Text = row.Cells["colSoluong"].Value?.ToString() ?? "";
            cboTinhtrang.Text = row.Cells["colTinhtrang"].Value?.ToString() ?? "";
            if (row.Cells["colNgaynhap"].Value != null &&
                row.Cells["colNgaynhap"].Value != DBNull.Value)
            {
                txtNgaynhap.Text = Convert.ToDateTime(row.Cells["colNgaynhap"].Value).ToString("yyyy-MM-dd");
            }
            else
            {
                txtNgaynhap.Clear();
            }
            txtGhichu.Text = row.Cells["colGhichu"].Value?.ToString() ?? "";

        }

        private void btnLamtrong_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            clearForm();
            onOff(true);
            tim = 1;

            txtTen.Focus();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (dgvCosovatchat.SelectedRows.Count == 0 || chon == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
                return;
            }
            DataGridViewRow row = dgvCosovatchat.CurrentRow;

            chon = Convert.ToString(row.Cells["colma"].Value);

            txtTen.Text = row.Cells["colTen"].Value?.ToString() ?? "";
            cboLoai.Text = row.Cells["colLoai"].Value?.ToString() ?? "";
            txtPhong.Text = row.Cells["colPhong"].Value?.ToString() ?? "";
            txtSoluong.Text = row.Cells["colSoluong"].Value?.ToString() ?? "";
            cboTinhtrang.Text = row.Cells["colTinhtrang"].Value?.ToString() ?? "";

            object giaTriNgay = row.Cells["colNgaynhap"].Value;

            if (giaTriNgay != null && giaTriNgay != DBNull.Value)
            {
                txtNgaynhap.Text =
                    Convert.ToDateTime(giaTriNgay).ToString("yyyy-MM-dd");
            }
            else
            {
                txtNgaynhap.Clear();
            }
            txtGhichu.Text = dgvCosovatchat.CurrentRow.Cells["colghichu"].Value?.ToString();
            tim = -1;
            MessageBox.Show("Đã chọn dữ liệu hãy sửa thông tin rồi ấn lưu");
            onOff(true);
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {

        }
        private void onOff(Boolean a)
        {
            btnThem.Enabled = !a;
            btnCapnhat.Enabled = !a;
            btnLamtrong.Enabled = !a;
            btnXoa.Enabled = !a;
            btnLuu.Enabled = a;
            btnThoat.Enabled = a;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên cơ sở vật chất!");
                txtTen.Focus();
                return;
            }

            // 2. Chỉ kiểm tra trùng tên khi thêm mới
            if (tim == 1)
            {
                if (kiemtraten(txtTen.Text.Trim()))
                {
                    MessageBox.Show("Tên cơ sở vật chất đã tồn tại!");
                    txtTen.Focus();
                    return;
                }
            }

            // 3. Kiểm tra loại
            if (cboLoai.SelectedIndex == -1 ||
                cboLoai.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại cơ sở vật chất!");
                cboLoai.Focus();
                return;
            }

            // Lấy mã loại từ ComboBox
            string maLoai = Convert.ToString(cboLoai.SelectedValue);
            try
            {
                maLoai = Convert.ToString(cboLoai.SelectedValue);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn loại hợp lệ!");
                cboLoai.Focus();
                return;
            }

            // 4. Kiểm tra số lượng
            if (!int.TryParse(txtSoluong.Text, out int soLuong) ||
                soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm!");
                txtSoluong.Focus();
                return;
            }

            // 5. Kiểm tra tình trạng
            if (cboTinhtrang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tình trạng!");
                cboTinhtrang.Focus();
                return;
            }

            // 6. Kiểm tra ngày nhập
            DateTime? ngayNhap = null;

            if (!string.IsNullOrWhiteSpace(txtNgaynhap.Text))
            {
                if (!DateTime.TryParseExact(
                    txtNgaynhap.Text.Trim(),
                    "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime ngay))
                {
                    MessageBox.Show(
                        "Ngày không hợp lệ! Vui lòng nhập theo dạng yyyy-MM-dd.");
                    txtNgaynhap.Focus();
                    return;
                }

                ngayNhap = ngay;
            }

            // 7. Kiểm tra chế độ Thêm hoặc Cập nhật
            if (tim != 1 && tim != -1)
            {
                MessageBox.Show(
                    "Vui lòng nhấn Thêm hoặc Cập nhật trước khi Lưu!");
                return;
            }

            if (tim == -1 && string.IsNullOrWhiteSpace(chon))
            {
                MessageBox.Show("Vui lòng chọn cơ sở vật chất cần cập nhật!");
                return;
            }

            // 8. Câu SQL: dùng MaLoai thay cho Loai
           
            string ma = "";
            

            if (tim == 1)
            {
                ma = TaoMa();
            }
            else
            {
                // Cập nhật thì giữ nguyên mã cũ
                ma = chon;
            }
            string sql;
            if (tim == 1)
            {
                sql = @"
            INSERT INTO CoSoVatChat
                (ma,Ten, MaLoai, PhongKhuVuc, SoLuong,
                 TinhTrang, NgayNhap, GhiChu)
            VALUES
                (@ma,@Ten, @MaLoai, @PhongKhuVuc, @SoLuong,
                 @TinhTrang, @NgayNhap, @GhiChu)";
                
            }
            else
            {
                sql = @"
            UPDATE CoSoVatChat
            SET Ten = @Ten,
                MaLoai = @MaLoai,
                PhongKhuVuc = @PhongKhuVuc,
                SoLuong = @SoLuong,
                TinhTrang = @TinhTrang,
                NgayNhap = @NgayNhap,
                GhiChu = @GhiChu
            WHERE Ma = @Ma";
               
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Ma", SqlDbType.VarChar, 30)
                             .Value = ma;
                        // 9. Truyền tham số vào câu SQL
                        cmd.Parameters.AddWithValue(
                            "@Ten", txtTen.Text.Trim());
                        // Quan trọng: lưu mã loại, không lưu tên loại
                        cmd.Parameters.Add("@MaLoai", SqlDbType.VarChar, 30)
                                          .Value = maLoai;

                        cmd.Parameters.AddWithValue(
                            "@PhongKhuVuc",
                            string.IsNullOrWhiteSpace(txtPhong.Text)
                                ? (object)DBNull.Value
                                : txtPhong.Text.Trim());

                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);

                        cmd.Parameters.AddWithValue(
                            "@TinhTrang", cboTinhtrang.Text);

                        cmd.Parameters.Add("@NgayNhap", SqlDbType.Date).Value =
                            ngayNhap.HasValue
                                ? (object)ngayNhap.Value.Date
                                : DBNull.Value;

                        cmd.Parameters.AddWithValue(
                            "@GhiChu",
                            string.IsNullOrWhiteSpace(txtGhichu.Text)
                                ? (object)DBNull.Value
                                : txtGhichu.Text.Trim());

                        // 10. Thực thi câu lệnh
                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                tim == 1
                                    ? "Thêm cơ sở vật chất thành công!"
                                    : "Cập nhật cơ sở vật chất thành công!");

                            // Tải lại bảng
                            loadData();

                            // Xóa dữ liệu và trở về trạng thái ban đầu
                            clearForm();
                            tim = 0;
                            chon = "";
                            onOff(false);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy dữ liệu cần cập nhật!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            clearForm();
            tim = 0;
            chon = "";
            onOff(false);
        }

        private void btnLoadtable_Click(object sender, EventArgs e)
        {
            loadData();
            clearForm();
            txtTimkiem.Clear();
        }
        private void timkiem()
        {
            string sql = @"
            select ma, ten,tenloai as loai,phongkhuvuc,soluong,tinhtrang,ngaynhap,ghichu
            from cosovatchat
            where ten like @tukhoa or
                    loai like @tukhoa or
                    phongkhuvuc like @tukhoa
             order by ma asc
";
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TuKhoa",
                            "%" + txtTimkiem.Text.Trim() + "%"
                        );

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvCosovatchat.DataSource = dt;

                        if (dgvCosovatchat.Columns.Contains("NgayNhap"))
                        {
                            dgvCosovatchat.Columns["NgayNhap"]
                                .DefaultCellStyle.Format = "yyyy-MM-dd";
                        }

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu phù hợp!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            timkiem();
        }

        private void btnThemloai_Click(object sender, EventArgs e)
        {
            using (LoaiCoSoVatChat loaics = new LoaiCoSoVatChat())
            {
                loaics.ShowDialog();
            }
            loadLoai();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }

}
