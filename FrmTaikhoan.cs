using Microsoft.Data.SqlClient;
using System.Data;

namespace QuanLyCoSoVatChat
{
    public partial class FrmTaikhoan : Form
    {
        private string vaiTroDangNhap;
        private int trangThai = 0;
        private string maChon = "";
        private string tendangnhaptk;
        public FrmTaikhoan(String vaitro, string tendangnhap)
        {
            InitializeComponent();
            vaiTroDangNhap = vaitro;
            if (vaiTroDangNhap != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập");
                this.Load += (s, e) => this.Close();
                return;
            }
            tendangnhaptk = tendangnhap;
            cboVaitro.Items.Clear();
            cboVaitro.Items.Add("Admin");
            cboVaitro.Items.Add("User");
            cboVaitro.DropDownStyle = ComboBoxStyle.DropDownList;

            txtMataikhoan.ReadOnly = true;
            txtNgaytao.ReadOnly = true;

            txtMataikhoan.UseSystemPasswordChar = false;
            txtMatkhau.UseSystemPasswordChar = false;

            dgvTaikhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaikhoan.MultiSelect = false;
            dgvTaikhoan.ReadOnly = true;
            dgvTaikhoan.AllowUserToAddRows = false;

            loadTaikhoan();
            lamTrong();
            onOff(true);
        }
        private string TaoMaTaiKhoan(SqlConnection conn)
        {
            int so = 1;

            while (true)
            {
                string ma = "TK" + so.ToString("D3");

                string sql = @"
            SELECT COUNT(*)
            FROM TaiKhoan
            WHERE MaTaiKhoan = @MaTaiKhoan";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaTaiKhoan", SqlDbType.VarChar, 10)
                        .Value = ma;

                    int tonTai = Convert.ToInt32(cmd.ExecuteScalar());

                    if (tonTai == 0)
                    {
                        return ma;
                    }
                }

                so++;
            }
        }
        private void loadTaikhoan()
        {
            string sql = @"
        SELECT MaTaiKhoan, TenDangNhap, MatKhau, VaiTro, NgayTao
        FROM TaiKhoan
        ORDER BY MaTaiKhoan ASC";

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvTaikhoan.AutoGenerateColumns = false;
                        dgvTaikhoan.DataSource = dt;
                    }
                }

                dgvTaikhoan.Columns["colNgayTao"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                dgvTaikhoan.ClearSelection();
                dgvTaikhoan.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tài khoản: " + ex.Message);
            }

        }
        private void onOff(Boolean a)
        {
            BtnThemTK.Enabled = a;
            BtnSuaTk.Enabled = a;
            BTnXoaTk.Enabled = a;
            BtnLamtrongTk.Enabled = a;

            BtnLuuTk.Enabled = !a;
            BtnThoatTk.Enabled = !a;

            txtTendangnhap.ReadOnly = a;
            txtMatkhau.ReadOnly = a;
            cboVaitro.Enabled = !a;

            txtMataikhoan.ReadOnly = true;
            txtNgaytao.ReadOnly = true;
        }
        private void lamTrong()
        {
            txtMataikhoan.Clear();
            txtTendangnhap.Clear();
            txtMatkhau.Clear();
            txtNgaytao.Clear();

            cboVaitro.SelectedIndex = -1;

            maChon = "";

            dgvTaikhoan.ClearSelection();
            dgvTaikhoan.CurrentCell = null;
        }

        private void FrmTaikhoan_Load(object sender, EventArgs e)
        {

        }

        private void dgvTaikhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvTaikhoan.Rows[e.RowIndex];

            txtMataikhoan.Text =
                row.Cells["MaTaiKhoan"].Value.ToString();

            txtTendangnhap.Text =
                row.Cells["TenDangNhap"].Value.ToString();

            cboVaitro.Text =
                row.Cells["VaiTro"].Value.ToString();

            txtNgaytao.Text =
                Convert.ToDateTime(row.Cells["NgayTao"].Value)
                .ToString("dd/MM/yyyy HH:mm");

            // Không tải mật khẩu ra giao diện
            txtMatkhau.Clear();

            maChon = row.Cells["colMaTaiKhoan"].Value?.ToString() ?? "";
        }

        private void BtnThemTK_Click(object sender, EventArgs e)
        {
            lamTrong();

            trangThai = 1;

            onOff(false);

            txtTendangnhap.Focus();
        }

        private void BtnSuaTk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maChon))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
                return;
            }

            trangThai = -1;

            onOff(false);

            txtTendangnhap.Focus();
        }

        private void BTnXoaTk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maChon))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                return;
            }

            // Không cho xóa chính tài khoản đang đăng nhập
            if (txtTendangnhap.Text == tendangnhaptk)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài khoản này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string sql = @"
                DELETE FROM TaiKhoan
                WHERE MaTaiKhoan = @MaTaiKhoan";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaTaiKhoan", SqlDbType.VarChar, 10)
                     .Value = maChon;

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show("Xóa tài khoản thành công!");

                            loadTaikhoan();
                            lamTrong();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa tài khoản: " + ex.Message);
            }
        }

        private void BtnLuuTk_Click(object sender, EventArgs e)
        {

            string tenDangNhap = txtTendangnhap.Text.Trim();
            string matKhau = txtMatkhau.Text;
            string vaiTro = cboVaitro.Text;

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                txtTendangnhap.Focus();
                return;
            }

            // Kiểm tra mật khẩu khi thêm mới
            if (trangThai == 1 && string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatkhau.Focus();
                return;
            }

            if (cboVaitro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vai trò!");
                cboVaitro.Focus();
                return;
            }

            if (trangThai != 1 && trangThai != -1)
            {
                MessageBox.Show("Vui lòng nhấn Thêm hoặc Sửa trước!");
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string sql;

                    if (trangThai == 1)
                    {
                        // Thêm tài khoản
                        sql = @"
                        INSERT INTO TaiKhoan
                        (MaTaiKhoan, TenDangNhap, MatKhau, VaiTro)
                        VALUES
                        (@MaTaiKhoan, @TenDangNhap, @MatKhau, @VaiTro)";
                    }
                    else
                    {
                        // Cập nhật thông tin
                        if (string.IsNullOrWhiteSpace(matKhau))
                        {
                            // Không đổi mật khẩu
                            sql = @"
                        UPDATE TaiKhoan
                        SET TenDangNhap = @TenDangNhap,
                            VaiTro = @VaiTro
                        WHERE MaTaiKhoan = @MaTaiKhoan";
                        }
                        else
                        {
                            // Có nhập mật khẩu mới
                            sql = @"
                        UPDATE TaiKhoan
                        SET TenDangNhap = @TenDangNhap,
                            MatKhau = @MatKhau,
                            VaiTro = @VaiTro
                        WHERE MaTaiKhoan = @MaTaiKhoan";
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50)
                            .Value = tenDangNhap;

                        cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 20)
                            .Value = vaiTro;

                        // Chỉ thêm tham số mật khẩu nếu cần
                        if (trangThai == 1 ||
                            !string.IsNullOrWhiteSpace(matKhau))
                        {
                            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 255)
                                .Value = matKhau;
                        }

                        if (trangThai == 1)
                        {
                            // Tạo mã tài khoản chưa được sử dụng
                            string maMoi = TaoMaTaiKhoan(conn);

                            cmd.Parameters.Add("@MaTaiKhoan", SqlDbType.VarChar, 10)
                                .Value = maMoi;
                        }
                        else if (trangThai == -1)
                        {
                            // Mã tài khoản đang được chọn
                            cmd.Parameters.Add("@MaTaiKhoan", SqlDbType.VarChar, 10)
                                .Value = maChon;
                        }

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                trangThai == 1
                                ? "Thêm tài khoản thành công!"
                                : "Cập nhật tài khoản thành công!");

                            trangThai = 0;

                            loadTaikhoan();
                            lamTrong();
                            onOff(true);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản cần cập nhật!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu tài khoản: " + ex.Message);
            }
        }

        private void BtnLamtrongTk_Click(object sender, EventArgs e)
        {
            lamTrong();

            trangThai = 0;

            onOff(true);
        }

        private void BtnThoatTk_Click(object sender, EventArgs e)
        {
            lamTrong();
            trangThai = 0;
            onOff(true);
        }

        private void dgvTaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvTaikhoan.Rows[e.RowIndex];

            
            txtMataikhoan.Text =
                row.Cells["colMaTaiKhoan"].Value?.ToString() ?? "";

            txtTendangnhap.Text =
                row.Cells["colTenDangNhap"].Value?.ToString() ?? "";

            txtMatkhau.Text =
                row.Cells["colMatKhau"].Value?.ToString() ?? "";

            cboVaitro.Text =
                row.Cells["colVaiTro"].Value?.ToString() ?? "";

            if (row.Cells["colNgayTao"].Value != null &&
                row.Cells["colNgayTao"].Value != DBNull.Value)
            {
                txtNgaytao.Text = Convert.ToDateTime(
                    row.Cells["colNgayTao"].Value
                ).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                txtNgaytao.Clear();
            }


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
