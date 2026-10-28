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
            string sql = @"select count(*) from taikhoan where tendangnhap =@tendangnhap and matkhau =@matkhau";
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
                        int ketqua = Convert.ToInt32(cmd.ExecuteScalar());
                        if (ketqua > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!");

                            this.Hide();
                            Form1 f = new Form1();
                            f.ShowDialog();
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

        private void btnThoatdangnhap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
