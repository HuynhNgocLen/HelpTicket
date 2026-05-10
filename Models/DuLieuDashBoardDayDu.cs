namespace HelpTicket.Models;

/// <summary>Dữ liệu đầy đủ cho màn Tổng quan: trạng thái, ưu tiên và xu hướng theo ngày.</summary>
public sealed class DuLieuDashBoardDayDu
{
    public ThongKeDashBoard TheoTrangThai { get; init; } = new();

    public int UuTienCao { get; init; }
    public int UuTienTrungBinh { get; init; }
    public int UuTienThap { get; init; }

    /// <summary>7 ngày liên tiếp (UTC, từ cũ đến mới), số ticket tạo mỗi ngày.</summary>
    public IReadOnlyList<int> SoLuongTaoTheoNgay { get; init; } = Array.Empty<int>();

    /// <summary>Ngày tương ứng với <see cref="SoLuongTaoTheoNgay"/> (chỉ phần ngày).</summary>
    public IReadOnlyList<DateTime> CacNgay { get; init; } = Array.Empty<DateTime>();
}
