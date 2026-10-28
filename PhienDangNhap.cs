namespace QuanLyCoSoVatChat
{
    public static class PhienDangNhap
    {
        public static string TenDangNhap { get; set; } = "";
        public static string VaiTro { get; set; } = "";
        public static bool LaAdmin => VaiTro == "Admin";

        public static void DangXuat()
        {
            TenDangNhap = "";
            VaiTro = "";
        }
    }
}