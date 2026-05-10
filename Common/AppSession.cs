using HelpTicket.Models;

namespace HelpTicket.Common;

/// <summary>Phiên đăng nhập hiện tại — dùng cho phân quyền 3 lớp.</summary>
public static class AppSession
{
    public static NguoiDung? CurrentUser { get; set; }

    public static bool IsLoggedIn => CurrentUser != null;

    public static void Clear() => CurrentUser = null;
}
