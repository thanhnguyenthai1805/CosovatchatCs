using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCoSoVatChat
{
    public partial class FrmDangnhap : Form
    {
        private object sqlDbType;

        public FrmDangnhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTendangnhap.Text.Trim();
            string matkhau = txtMatkhau.Text.Trim();
            if (string.IsNullOrWhiteSpace(tendangnhap) || string.IsNullOrWhiteSpace(matkhau))
            {
                MessageBox.Show("Nhập đầy đủ tài khoản và mật khẩu");
                return;
            }
            string sql = @"select vaitro from taikhoan where tendangnhap =@tendangnhap and matkhau =@matkhau";
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
                        cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 100).Value = matkhau;
                        object ketqua = cmd.ExecuteScalar();
                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            string vaiTro = ketqua.ToString();

                            // Chỉ chấp nhận hai loại quyền hợp lệ
                            if (vaiTro != "Admin" && vaiTro != "User")
                            {
                                MessageBox.Show("Quyền tài khoản không hợp lệ!");
                                return;
                            }

                            MessageBox.Show("Đăng nhập thành công!");

                            // 3. Ẩn Form đăng nhập
                            this.Hide();

                            // 4. Mở Form chính và truyền quyền
                            using (Form1 f = new Form1(vaiTro))
                            {
                                f.ShowDialog();
                            }

                            // 5. Khi Form chính đóng, hiện lại Form đăng nhập
                            this.Show();
                            txtMatkhau.Clear();
                            txtTendangnhap.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");

                            txtMatkhau.Clear();
                            txtMatkhau.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private void btnThoatdangnhap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTendangnhap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
