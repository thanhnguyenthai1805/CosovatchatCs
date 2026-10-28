using Microsoft.Data.SqlClient;
using System.Data;

namespace QuanLyCoSoVatChat
{
    public partial class FrmDangnhap
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnDangnhap.Click -= btnDangnhap_Click;
            btnDangnhap.Click += btnDangnhapPhanQuyen_Click;
            AcceptButton = btnDangnhap;
        }

        private void btnDangnhapPhanQuyen_Click(object? sender, EventArgs e)
        {
            string tendangnhap = txtTendangnhap.Text.Trim();
            string matkhau = txtMatkhau.Text.Trim();
            if (string.IsNullOrWhiteSpace(tendangnhap) || string.IsNullOrWhiteSpace(matkhau))
            {
                MessageBox.Show("Nhập đầy đủ tài khoản và mật khẩu");
                return;
            }

            string sql = @"select vaitro from taikhoan
                           where tendangnhap = @tendangnhap and matkhau = @matkhau";
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@tendangnhap", SqlDbType.NVarChar, 50).Value = tendangnhap;
                        cmd.Parameters.Add("@matkhau", SqlDbType.NVarChar, 100).Value = matkhau;
                        object? ketqua = cmd.ExecuteScalar();

                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            PhienDangNhap.TenDangNhap = tendangnhap;
                            PhienDangNhap.VaiTro = ketqua.ToString() ?? "User";

                            MessageBox.Show("Đăng nhập thành công! Quyền: " + PhienDangNhap.VaiTro);

                            this.Hide();
                            Form1 f = new Form1();
                            f.ShowDialog();
                            PhienDangNhap.DangXuat();
                            this.Show();
                            txtMatkhau.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                            txtMatkhau.Clear();
                            txtTendangnhap.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }
    }
}