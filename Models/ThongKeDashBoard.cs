namespace HelpTicket.Models;

/// <summary>Thống kê nhanh cho màn Tổng quan (theo phạm vi quyền: user chỉ thấy ticket của mình).</summary>
public sealed class ThongKeDashBoard
{
    public int Tong { get; init; }
    public int Mo { get; init; }
    public int DangXuLy { get; init; }
    public int HoanThanh { get; init; }
    public int Huy { get; init; }
}
