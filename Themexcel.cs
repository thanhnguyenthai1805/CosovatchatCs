
using Microsoft.Data.SqlClient;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCoSoVatChat
{
    public partial class Themexcel : Form
    {
        private DataTable dtExcel;

        public Themexcel()
        {
            InitializeComponent();
            CheDoXem();
            // Thiết lập giao diện
            txtDuongdan.ReadOnly = true;
            txtThongbao.ReadOnly = true;

            txtTongsodong.ReadOnly = true;
            txtHople.ReadOnly = true;
            txtKhonghople.ReadOnly = true;

            btnLuuExcel.Enabled = false;

            // Gắn sự kiện
            dgvExcel.CellClick += dgvExcel_CellClick;
            btnDong.Click += btnDong_Click;

            dgvExcel.AutoGenerateColumns = false;
            dgvExcel.AllowUserToAddRows = false;
        }
        private void KiemTraLaiBang()
        {
            int tong = 0;
            int hopLe = 0;
            int khongHopLe = 0;

            var danhSachLoai = LayDanhSachLoai();
            var danhSachTinhTrang = LayDanhSachTinhTrang();

            foreach (DataRow row in dtExcel.Rows)
            {
                string loi = "";

                string ten = Convert.ToString(row["Ten"])?.Trim();
                string loai = Convert.ToString(row["Loai"])?.Trim();
                string phong = Convert.ToString(row["PhongKhuVuc"])?.Trim();
                string soLuong = Convert.ToString(row["SoLuong"])?.Trim();
                string tinhTrang = Convert.ToString(row["TinhTrang"])?.Trim();

                if (string.IsNullOrWhiteSpace(ten))
                    loi += "Thiếu tên; ";

                if (string.IsNullOrWhiteSpace(loai) ||
                    !danhSachLoai.ContainsKey(loai))
                    loi += "Loại không tồn tại; ";

                if (string.IsNullOrWhiteSpace(phong))
                    loi += "Thiếu phòng/khu vực; ";

                if (!int.TryParse(soLuong, out int sl) || sl < 0)
                    loi += "Số lượng không hợp lệ; ";

                if (string.IsNullOrWhiteSpace(tinhTrang) ||
                    !danhSachTinhTrang.Contains(tinhTrang))
                    loi += "Tình trạng không tồn tại; ";

                row["Loi"] = string.IsNullOrEmpty(loi)
     ? "Hợp lệ"
     : loi.Trim().TrimEnd(';');

                tong++;

                if (string.IsNullOrEmpty(loi))
                    hopLe++;
                else
                    khongHopLe++;
            }

            // Cập nhật kết quả kiểm tra
            txtTongsodong.Text = tong.ToString();
            txtHople.Text = hopLe.ToString();
            txtKhonghople.Text = khongHopLe.ToString();

            // Cập nhật thông báo
            if (khongHopLe == 0 && tong > 0)
            {
                txtThongbao.Text = "Tất cả dữ liệu đều hợp lệ!";
            }
            else
            {
                txtThongbao.Text = $"Có {khongHopLe} dòng không hợp lệ. Vui lòng kiểm tra cột Lỗi!";
            }

            dgvExcel.Refresh();

            btnLuuExcel.Enabled = tong > 0 && khongHopLe == 0;
        }

        private void CheDoXem()
        {
            btnSuaexcel.Visible = true;
            btnLuusua.Visible = false;

            dgvExcel.ReadOnly = true;
        }

        private void CheDoSua()
        {
            btnSuaexcel.Visible = false;
            btnLuusua.Visible = true;

            dgvExcel.ReadOnly = false;

            // Không cho sửa cột báo lỗi
            if (dgvExcel.Columns.Contains("colLoi"))
            {
                dgvExcel.Columns["colloiexcel"].ReadOnly = true;
            }
        }
        private static DateTime thoiGianCuoi = DateTime.MinValue;

        private string TaoMaTuDong()
        {
            DateTime hienTai = DateTime.Now;

            // Tránh tạo mã trùng khi nhập nhiều dòng liên tiếp
            if (hienTai <= thoiGianCuoi)
            {
                hienTai = thoiGianCuoi.AddMilliseconds(1);
            }

            thoiGianCuoi = hienTai;

            return hienTai.ToString("yyyyMMddHHmmssfff");
        }

        // 1. Lấy danh sách loại từ SQL
        private Dictionary<string, string> LayDanhSachLoai()
        {
            Dictionary<string, string> danhSach =
                new Dictionary<string, string>(
                    StringComparer.OrdinalIgnoreCase);

            string sql = "SELECT MaLoai, TenLoai FROM LoaiCoSoVatChat";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ma = reader["MaLoai"].ToString();
                        string ten = reader["TenLoai"].ToString().Trim();

                        danhSach[ten] = ma;
                    }
                }
            }

            return danhSach;
        }

        // 2. Lấy danh sách tình trạng từ SQL
        private HashSet<string> LayDanhSachTinhTrang()
        {
            HashSet<string> danhSach =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            string sql =
                "SELECT TenTinhTrang FROM TinhTrangCoSoVatChat";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(
                            reader["TenTinhTrang"].ToString().Trim());
                    }
                }
            }

            return danhSach;
        }

        // 3. Kiểm tra dữ liệu của một dòng Excel
        private List<string> KiemTraDuLieu(
            DataRow row,
            Dictionary<string, string> danhSachLoai,
            HashSet<string> danhSachTinhTrang)
        {
            List<string> loi = new List<string>();

            string ten = row["Ten"].ToString().Trim();
            string loai = row["Loai"].ToString().Trim();
            string phong = row["PhongKhuVuc"].ToString().Trim();
            string soLuongText = row["SoLuong"].ToString().Trim();
            string tinhTrang = row["TinhTrang"].ToString().Trim();

            if (string.IsNullOrWhiteSpace(ten))
                loi.Add("Tên không được để trống");

            if (!danhSachLoai.ContainsKey(loai))
                loi.Add("Loại không tồn tại trong SQL");

            if (string.IsNullOrWhiteSpace(phong))
                loi.Add("Phòng/Khu vực không được để trống");

            if (!int.TryParse(soLuongText, out int soLuong)
                || soLuong < 0)
            {
                loi.Add("Số lượng phải là số nguyên không âm");
            }

            if (!danhSachTinhTrang.Contains(tinhTrang))
                loi.Add("Tình trạng không tồn tại trong SQL");

            return loi;
        }

        // 4. Chọn và đọc file Excel
        private void btnchonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Title = "Chọn file Excel";
                openFile.Filter = "Excel Files|*.xlsx;*.xls";

                if (openFile.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    // Xóa dữ liệu cũ
                    dtExcel = null;
                    dgvExcel.DataSource = null;

                    btnLuuExcel.Enabled = false;

                    txtDuongdan.Text = openFile.FileName;
                    txtThongbao.Clear();

                    txtTongsodong.Clear();
                    txtHople.Clear();
                    txtKhonghople.Clear();

                    // Đọc file Excel
                    Encoding.RegisterProvider(
                        CodePagesEncodingProvider.Instance);

                    using (var stream = File.Open(
                        openFile.FileName,
                        FileMode.Open,
                        FileAccess.Read))
                    using (var reader =
                        ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(
                            new ExcelDataSetConfiguration
                            {
                                ConfigureDataTable = _ =>
                                    new ExcelDataTableConfiguration
                                    {
                                        UseHeaderRow = true
                                    }
                            });

                        if (result.Tables.Count == 0)
                            throw new Exception("File Excel không có dữ liệu.");

                        dtExcel = result.Tables[0];
                    }

                    // Kiểm tra tên các cột
                    string[] cotBatBuoc =
                    {
                        "Ten",
                        "Loai",
                        "PhongKhuVuc",
                        "SoLuong",
                        "TinhTrang",
                        "GhiChu"
                    };

                    foreach (string cot in cotBatBuoc)
                    {
                        if (!dtExcel.Columns.Contains(cot))
                        {
                            throw new Exception(
                                "File Excel thiếu cột: " + cot);
                        }
                    }

                    if (dtExcel.Rows.Count == 0)
                        throw new Exception("File Excel không có dòng dữ liệu.");

                    // Lấy dữ liệu từ SQL
                    Dictionary<string, string> danhSachLoai =
                        LayDanhSachLoai();

                    HashSet<string> danhSachTinhTrang =
                        LayDanhSachTinhTrang();

                    // Thêm cột thông báo lỗi
                    if (!dtExcel.Columns.Contains("Loi"))
                    {
                        dtExcel.Columns.Add("Loi", typeof(string));
                    }

                    int hopLe = 0;
                    int khongHopLe = 0;

                    // Kiểm tra từng dòng
                    foreach (DataRow row in dtExcel.Rows)
                    {
                        List<string> loi = KiemTraDuLieu(
                            row,
                            danhSachLoai,
                            danhSachTinhTrang);

                        if (loi.Count == 0)
                        {
                            row["Loi"] = "Hợp lệ";
                            hopLe++;
                        }
                        else
                        {
                            row["Loi"] = string.Join("; ", loi);
                            khongHopLe++;
                        }
                    }

                    // Hiển thị dữ liệu lên bảng
                    dgvExcel.DataSource = dtExcel;

                    // Đặt tên hiển thị cho các cột
                    dgvExcel.Columns["coltenexcel"].HeaderText = "Tên cơ sở";
                    dgvExcel.Columns["colloaiexcel"].HeaderText = "Loại";
                    dgvExcel.Columns["colphongexcel"].HeaderText = "Phòng/Khu vực";
                    dgvExcel.Columns["colsoluongexcel"].HeaderText = "Số lượng";
                    dgvExcel.Columns["coltinhtrangexcel"].HeaderText = "Tình trạng";
                    dgvExcel.Columns["colghichuexcel"].HeaderText = "Ghi chú";
                    dgvExcel.Columns["colloiexcel"].HeaderText = "Kết quả kiểm tra";

                    // Hiển thị số liệu thống kê
                    txtTongsodong.Text = dtExcel.Rows.Count.ToString();
                    txtHople.Text = hopLe.ToString();
                    txtKhonghople.Text = khongHopLe.ToString();

                    // Tô màu dòng hợp lệ và không hợp lệ
                    foreach (DataGridViewRow row in dgvExcel.Rows)
                    {
                        string loi = row.Cells["colloiexcel"].Value?.ToString();

                        if (loi == "Hợp lệ")
                        {
                            row.DefaultCellStyle.BackColor = Color.Honeydew;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.MistyRose;
                        }
                    }

                    // Chỉ cho lưu khi tất cả dòng đều hợp lệ
                    btnLuuExcel.Enabled =
                        hopLe > 0 && khongHopLe == 0;

                    if (khongHopLe == 0)
                    {
                        txtThongbao.ForeColor = Color.Green;
                        txtThongbao.Text =
                            "Tất cả dữ liệu hợp lệ. Có thể lưu vào SQL.";
                    }
                    else
                    {
                        txtThongbao.ForeColor = Color.Red;
                        txtThongbao.Text =
                            "Có " + khongHopLe +
                            " dòng không hợp lệ. Vui lòng kiểm tra lại.";
                    }
                }
                catch (Exception ex)
                {
                    dtExcel = null;
                    dgvExcel.DataSource = null;

                    btnLuuExcel.Enabled = false;

                    txtThongbao.ForeColor = Color.Red;
                    txtThongbao.Text = "Đọc file thất bại.";

                    MessageBox.Show(
                        ex.Message,
                        "Lỗi đọc Excel",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        // 5. Khi chọn một dòng trong bảng
        private void dgvExcel_CellClick(
           object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string loi = dgvExcel.Rows[e.RowIndex]
                .Cells["colLoiExcel"].Value?.ToString() ?? "";

            if (loi == "Hợp lệ")
            {
                txtThongbao.ForeColor = Color.Green;
                txtThongbao.Text =
                    "Dòng " + (e.RowIndex + 1) +
                    " hợp lệ. Có thể lưu vào SQL.";
            }
            else
            {
                txtThongbao.ForeColor = Color.Red;
                txtThongbao.Text =
                    "Dòng " + (e.RowIndex + 1) +
                    " không hợp lệ: " + loi;
            }
        }

        // 6. Lưu dữ liệu Excel vào SQL
        private void btnLuuExcel_Click(object sender, EventArgs e)
        {
            if (dtExcel == null || dtExcel.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn file Excel!");
                return;
            }

            // Không lưu nếu còn dòng lỗi
            foreach (DataRow row in dtExcel.Rows)
            {
                if (row["Loi"].ToString() != "Hợp lệ")
                {
                    MessageBox.Show(
                        "Vui lòng sửa tất cả lỗi trước khi lưu!");
                    return;
                }
            }

            if (MessageBox.Show(
                "Bạn có chắc muốn lưu dữ liệu vào hệ thống?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Lấy lại danh sách loại để tìm MaLoai
                Dictionary<string, string> danhSachLoai =
                    LayDanhSachLoai();

                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string sql = @"
                                INSERT INTO CoSoVatChat
                                (
                                    Ma, Ten, MaLoai, PhongKhuVuc,
                                    SoLuong, TinhTrang, NgayNhap, GhiChu
                                )
                                VALUES
                                (
                                    @Ma, @Ten, @MaLoai, @PhongKhuVuc,
                                    @SoLuong, @TinhTrang, @NgayNhap, @GhiChu
                                )";

                            foreach (DataRow row in dtExcel.Rows)
                            {
                                string ten = row["Ten"].ToString().Trim();
                                string loai = row["Loai"].ToString().Trim();
                                string phong = row["PhongKhuVuc"].ToString().Trim();
                                int soLuong = Convert.ToInt32(row["SoLuong"]);
                                string tinhTrang = row["TinhTrang"].ToString().Trim();
                                string ghiChu = row["GhiChu"].ToString().Trim();

                                // Tìm mã loại tương ứng
                                string maLoai = danhSachLoai[loai];

                                // Tạo mã tự động
                                string ma = TaoMaTuDong();

                                using (SqlCommand cmd =
                                    new SqlCommand(sql, conn, transaction))
                                {
                                    cmd.Parameters.Add("@Ma", SqlDbType.VarChar, 30)
                                        .Value = ma;

                                    cmd.Parameters.Add("@Ten", SqlDbType.NVarChar, 200)
                                        .Value = ten;

                                    cmd.Parameters.Add("@MaLoai", SqlDbType.VarChar, 30)
                                        .Value = maLoai;

                                    cmd.Parameters.Add("@PhongKhuVuc", SqlDbType.NVarChar, 200)
                                        .Value = phong;

                                    cmd.Parameters.Add("@SoLuong", SqlDbType.Int)
                                        .Value = soLuong;

                                    cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar, 100)
                                        .Value = tinhTrang;

                                    cmd.Parameters.Add("@NgayNhap", SqlDbType.Date)
                                        .Value = DateTime.Today;

                                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 500)
                                        .Value = string.IsNullOrWhiteSpace(ghiChu)
                                            ? (object)DBNull.Value
                                            : ghiChu;

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Nhập dữ liệu Excel thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Báo cho Form1 biết đã lưu thành công
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi lưu dữ liệu: " + ex.Message,
                    "Lỗi SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // 7. Đóng form
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Giữ lại sự kiện đang được Designer sử dụng
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaexcel_Click(object sender, EventArgs e)
        {
            if (dgvExcel.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để sửa!");
                return;
            }

            CheDoSua();
        }

        private void btnLuusua_Click(object sender, EventArgs e)
        {
            dgvExcel.EndEdit();

            // Cập nhật dữ liệu đang sửa
            this.BindingContext[dgvExcel.DataSource].EndCurrentEdit();

            // Kiểm tra lại dữ liệu
            KiemTraLaiBang();

            // Khóa bảng sau khi sửa
            CheDoXem();

            // Cập nhật lại màu sắc
            foreach (DataGridViewRow row in dgvExcel.Rows)
            {
                string loi = row.Cells["colLoiExcel"].Value?.ToString();

                if (loi == "Hợp lệ")
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                else
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
            }

            MessageBox.Show("Đã lưu chỉnh sửa và cập nhật kết quả kiểm tra!");
        }

        private void dgvExcel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
