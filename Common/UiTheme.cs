using System.Drawing.Drawing2D;

namespace HelpTicket.Common;

/// <summary>Giao diện chung: nền ấm, sidebar đậm, nhấn teal (hỗ trợ) / hổ phách (cảnh báo nhẹ).</summary>
public static class UiTheme
{
    public static readonly Color BgCanvas = Color.FromArgb(245, 242, 235);
    public static readonly Color BgSidebar = Color.FromArgb(10, 22, 42);
    public static readonly Color BgSidebarHeader = Color.FromArgb(7, 16, 32);
    public static readonly Color BgSidebarFooter = Color.FromArgb(7, 16, 32);
    public static readonly Color NavIdle = Color.FromArgb(22, 48, 72);
    public static readonly Color NavHover = Color.FromArgb(30, 62, 92);
    public static readonly Color AccentTeal = Color.FromArgb(13, 148, 136);
    public static readonly Color AccentTealBright = Color.FromArgb(45, 212, 191);
    public static readonly Color AccentAmber = Color.FromArgb(217, 119, 6);
    public static readonly Color PrimaryInk = Color.FromArgb(15, 23, 42);
    public static readonly Color TextMuted = Color.FromArgb(91, 103, 122);
    public static readonly Color TextOnDark = Color.FromArgb(248, 250, 252);
    public static readonly Color TextMutedOnDark = Color.FromArgb(148, 163, 184);
    public static readonly Color Surface = Color.White;
    public static readonly Color SurfaceElevated = Color.FromArgb(255, 253, 249);
    public static readonly Color BorderHairline = Color.FromArgb(218, 212, 202);
    public static readonly Color GridHeaderBg = Color.FromArgb(228, 224, 214);
    public static readonly Color GridLine = Color.FromArgb(210, 205, 196);
    public static readonly Color RowSelectTeal = Color.FromArgb(204, 251, 241);

    public static Font FontDisplay(float emSize, FontStyle style = FontStyle.Bold) =>
        new("Cambria", emSize, style, GraphicsUnit.Point);

    public static Font FontUi(float emSize, FontStyle style = FontStyle.Regular) =>
        new("Bahnschrift", emSize, style, GraphicsUnit.Point);

    public static void PaintSoftGradient(Panel panel, PaintEventArgs e, Color topLeft, Color bottomRight)
    {
        try
        {
            using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                panel.ClientRectangle,
                topLeft,
                bottomRight,
                135f);
            e.Graphics.FillRectangle(brush, panel.ClientRectangle);
        }
        catch
        {
            using var b = new SolidBrush(BgCanvas);
            e.Graphics.FillRectangle(b, panel.ClientRectangle);
        }
    }

    public static void PaintSidebarAccent(Graphics g, Rectangle bounds)
    {
        using var brush = new SolidBrush(AccentTealBright);
        g.FillRectangle(brush, 0, 0, 4, bounds.Height);
    }
}
