namespace HelpTicket.Models;

public class NguoiDung
{
    public int MaNguoiDung { get; set; }
    public string TenDangNhap { get; set; } = string.Empty;
    public string MatKhau { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string? Email { get; set; }
    public int? MaKhoaPhong { get; set; }
    public byte MaVaiTro { get; set; }
    public bool HoatDong { get; set; } = true;

    /// <summary>Tên khoa (JOIN), không có trong bảng.</summary>
    public string? TenKhoaPhong { get; set; }

    public bool LaQuanTri => MaVaiTro == VaiTroCodes.QuanTri;
    public bool LaKyThuat => MaVaiTro == VaiTroCodes.KyThuatVien;
    public bool LaNguoiDungCuoi => MaVaiTro == VaiTroCodes.NguoiDung;
}
