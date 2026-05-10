namespace HelpTicket.Models;

public static class TrangThaiTicket
{
    public const string Mo = "Mo";
    public const string DangXuLy = "DangXuLy";
    public const string HoanThanh = "HoanThanh";
    public const string Huy = "Huy";

    public static IReadOnlyList<string> TatCa => new[] { Mo, DangXuLy, HoanThanh, Huy };

    public static string HienThi(string ma)
    {
        return ma switch
        {
            Mo => "Mở",
            DangXuLy => "Đang xử lý",
            HoanThanh => "Hoàn thành",
            Huy => "Hủy",
            _ => ma
        };
    }
}

public class Ticket
{
    public int MaTicket { get; set; }
    public string TieuDe { get; set; } = string.Empty;
    public string? NoiDung { get; set; }
    public string TrangThai { get; set; } = TrangThaiTicket.Mo;
    public int MaNguoiTao { get; set; }
    public int? MaNguoiPhuTrach { get; set; }
    public int MaKhoaPhong { get; set; }
    public DateTime NgayTao { get; set; }
    public DateTime? NgayCapNhat { get; set; }
    public byte DoUuTien { get; set; } = 2;

    public string? TenNguoiTao { get; set; }
    public string? TenNguoiPhuTrach { get; set; }
    public string? TenKhoaPhong { get; set; }

    public static string TenDoUuTien(byte u) => u switch
    {
        1 => "Cao",
        2 => "Trung bình",
        3 => "Thấp",
        _ => u.ToString()
    };
}
