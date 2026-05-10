namespace HelpTicket.Models;

/// <summary>Khớp bảng VaiTro.</summary>
public class VaiTro
{
    public byte MaVaiTro { get; set; }
    public string TenVaiTro { get; set; } = string.Empty;
    public string? MoTa { get; set; }
}

public static class VaiTroCodes
{
    public const byte QuanTri = 1;
    public const byte KyThuatVien = 2;
    public const byte NguoiDung = 3;

    public static string TenHienThi(byte maVaiTro) => maVaiTro switch
    {
        QuanTri => "Quản trị",
        KyThuatVien => "Kỹ thuật viên",
        NguoiDung => "Người dùng",
        _ => "Khác"
    };
}
