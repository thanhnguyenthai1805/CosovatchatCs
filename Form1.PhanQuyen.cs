namespace QuanLyCoSoVatChat
{
    public partial class Form1
    {
        // Đặt true nếu muốn User cũng được dùng ô tìm kiếm
        private const bool USER_DUOC_TIMKIEM = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PhanQuyenTheoTaiKhoan();
        }

        private void PhanQuyenTheoTaiKhoan()
        {
            this.Text = "Quản lý cơ sở vật chất - " + PhienDangNhap.TenDangNhap
                        + " (" + PhienDangNhap.VaiTro + ")";

            if (PhienDangNhap.LaAdmin) return;

            // ===== User: chỉ xem =====
            btnThem.Visible = false;
            btnCapnhat.Visible = false;
            btnXoa.Visible = false;
            btnLuu.Visible = false;
            btnThoat.Visible = false;
            btnLamtrong.Visible = false;
            btnThemloai.Visible = false;

            btnTimkiem.Visible = USER_DUOC_TIMKIEM;
            txtTimkiem.Visible = USER_DUOC_TIMKIEM;
            label11.Visible = USER_DUOC_TIMKIEM;

            txtMa.ReadOnly = true;
            txtTen.ReadOnly = true;
            txtSoluong.ReadOnly = true;
            txtNgaynhap.ReadOnly = true;
            txtPhong.ReadOnly = true;
            txtGhichu.ReadOnly = true;
            cboLoai.Enabled = false;
            cboTinhtrang.Enabled = false;

            dgvCosovatchat.ReadOnly = true;
            dgvCosovatchat.AllowUserToAddRows = false;
            dgvCosovatchat.AllowUserToDeleteRows = false;
        }
    }
}