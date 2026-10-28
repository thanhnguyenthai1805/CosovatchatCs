using Microsoft.Data.SqlClient;
using System.Data;

namespace QuanLyCoSoVatChat
{
    public partial class LoaiCoSoVatChat
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnLuuloai.Click -= btnLuuloai_Click;
            btnLuuloai.Click += btnLuuloaiPhanQuyen_Click;
        }

        private void btnLuuloaiPhanQuyen_Click(object? sender, EventArgs e)
        {
            if (!PhienDangNhap.LaAdmin) return;

            string tenLoai = txtTenloai.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập tên loại!");
                txtTenloai.Focus();
                return;
            }

            if (trangthai != 1 && trangthai != -1)
            {
                MessageBox.Show("Vui lòng nhấn Thêm hoặc Cập nhật trước!");
                return;
            }

            string sql;
            if (trangthai == 1)
            {
                sql = @"INSERT INTO LoaiCoSoVatChat (MaLoai, TenLoai)
                        VALUES (@MaLoai, @TenLoai)";
            }
            else
            {
                sql = @"UPDATE LoaiCoSoVatChat
                        SET TenLoai = @TenLoai
                        WHERE MaLoai = @MaLoai";
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        string maLoai = (trangthai == 1) ? TaoMaLoai() : machon;

                        cmd.Parameters.Add("@MaLoai", SqlDbType.VarChar, 30).Value = maLoai;
                        cmd.Parameters.Add("@TenLoai", SqlDbType.NVarChar, 100).Value = tenLoai;

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                trangthai == 1
                                    ? "Thêm loại thành công!"
                                    : "Cập nhật loại thành công!");

                            trangthai = 0;
                            loadLoai();
                            lamtrong();
                            onOff(true);
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được thay đổi!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                    MessageBox.Show("Tên loại này đã tồn tại!");
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }
    }
}