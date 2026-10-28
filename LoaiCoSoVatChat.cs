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
    public partial class LoaiCoSoVatChat : Form
    {
        private string TaoMaLoai()
        {
            return "LOAI" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        private int trangthai = 0;
        private string machon = "";
        public LoaiCoSoVatChat()
        {
            InitializeComponent();
            loadLoai();

            onOff(true);
        }

        private void onOff(Boolean a)
        {
            btnThemloai.Enabled = a;
            btnCapnhatloai.Enabled = a;
            btnLamtrong.Enabled = a;
            btnXoaloai.Enabled = a;

            btnLuuloai.Enabled = !a;
            btnThoatloai.Enabled = !a;
        }
        private void lamtrong()
        {
            txtMaloai.Clear();
            txtTenloai.Clear();
            machon = "";
            dgvLoaicosovatchat.ClearSelection();
            dgvLoaicosovatchat.CurrentCell = null;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvLoaicosovatchat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLoaicosovatchat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvLoaicosovatchat.Rows[e.RowIndex];
            txtMaloai.Text = row.Cells["colMaloai"].Value?.ToString();
            txtTenloai.Text = row.Cells["colTenloai"].Value?.ToString();
            machon = txtMaloai.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            onOff(true);
        }

        private void btnThemloai_Click(object sender, EventArgs e)
        {

            lamtrong();
            trangthai = 1;
            onOff(false);
            txtTenloai.Focus();
        }

        private void btnCapnhatloai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaloai.Text))
            {
                MessageBox.Show("Vui lòng chọn loại cần cập nhật!");
                return;
            }
            trangthai = -1;
            onOff(false);
            txtTenloai.Focus();
        }

        private void btnLuuloai_Click(object sender, EventArgs e)
        {
            string tenLoai = txtTenloai.Text.Trim();

            // 1. Kiểm tra dữ liệu
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

            // 2. Chọn câu SQL theo chế độ
            string sql;

            if (trangthai == 1)
            {
                sql = @"
            INSERT INTO LoaiCoSoVatChat (TenLoai)
            VALUES (@TenLoai)";
            }
            else
            {
                sql = @"
            UPDATE LoaiCoSoVatChat
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
                        cmd.Parameters.Add("@TenLoai", SqlDbType.NVarChar, 100)
                            .Value = tenLoai;

                        if (trangthai == -1)
                        {
                            cmd.Parameters.Add("@MaLoai", SqlDbType.Int)
                                .Value = Convert.ToInt32(txtMaloai.Text);
                        }

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
            //2601: thường liên quan đến việc chèn giá trị trùng vào chỉ mục duy nhất.
            //2627: vi phạm ràng buộc PRIMARY KEY hoặc UNIQUE.
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show("Tên loại này đã tồn tại!");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnXoaloai_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaloai.Text.Trim();

            if (string.IsNullOrWhiteSpace(maLoai))
            {
                MessageBox.Show("Vui lòng chọn loại cần xóa!");
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa loại này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra loại có đang được cơ sở vật chất sử dụng không
                    string sqlKiemTra = @"
                SELECT COUNT(*)
                FROM CoSoVatChat
                WHERE MaLoai = @MaLoai";

                    using (SqlCommand cmdKiemTra =
                           new SqlCommand(sqlKiemTra, conn))
                    {
                        cmdKiemTra.Parameters.Add(
                            "@MaLoai", SqlDbType.VarChar, 30).Value = maLoai;

                        int soLuong = Convert.ToInt32(cmdKiemTra.ExecuteScalar());

                        if (soLuong > 0)
                        {
                            MessageBox.Show(
                                "Không thể xóa vì loại này đang được cơ sở vật chất sử dụng!");
                            return;
                        }
                    }

                    // Xóa loại khi không có bản ghi nào sử dụng
                    string sqlXoa = @"
                DELETE FROM LoaiCoSoVatChat
                WHERE MaLoai = @MaLoai";

                    using (SqlCommand cmdXoa = new SqlCommand(sqlXoa, conn))
                    {
                        cmdXoa.Parameters.Add(
                            "@MaLoai", SqlDbType.VarChar, 30).Value = maLoai;

                        int ketQuaXoa = cmdXoa.ExecuteNonQuery();

                        if (ketQuaXoa > 0)
                        {
                            MessageBox.Show("Xóa loại thành công!");

                            loadLoai();
                            lamtrong();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy loại cần xóa!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa loại: " + ex.Message);
            }
        }

        private void btnLamtrong_Click(object sender, EventArgs e)
        {
            txtMaloai.Clear();
            txtTenloai.Clear();
        }
    }
}

