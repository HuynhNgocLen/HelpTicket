using HelpTicket.Common;
using HelpTicket.Models;

namespace HelpTicket.Forms;

public partial class FrmMain : Form
{
    private Form? _hostedForm;
    private readonly Color _navIdle = UiTheme.NavIdle;
    private readonly Color _navActive = UiTheme.AccentTeal;
    private readonly Button[] _navButtons;

    public FrmMain()
    {
        InitializeComponent();

        FitToWorkingArea();

        StyleNavButton(btnNavDashboard, "Tổng quan");
        StyleNavButton(btnNavTickets, "Quản lý ticket");
        StyleNavButton(btnNavKhoa, "Khoa / phòng");
        StyleNavButton(btnNavDanhBa, "Danh bạ");
        StyleNavButton(btnNavHuongDan, "Hướng dẫn");
        StyleNavButton(btnNavAbout, "Giới thiệu");

        _navButtons =
        [
            btnNavDashboard,
            btnNavTickets,
            btnNavKhoa,
            btnNavDanhBa,
            btnNavHuongDan,
            btnNavAbout
        ];

        foreach (var b in _navButtons)
        {
            b.Click += NavButton_Click;
        }

        panelNavScroll.Resize += PanelNavScroll_Resize;
        ApplyRoleUi();
        lblUser.Text = AppSession.CurrentUser?.HoTen ?? "";
        lblRole.Text = TenVaiTro(AppSession.CurrentUser?.MaVaiTro);
        OpenTickets();
        SetActiveNav(btnNavTickets);
        PanelNavScroll_Resize(null, EventArgs.Empty);
    }

    private void PanelNavScroll_Resize(object? sender, EventArgs e)
    {
        var w = panelNavScroll.ClientSize.Width - panelNavScroll.Padding.Horizontal;
        if (w < 120)
        {
            w = 120;
        }

        tableNav.Width = w;
    }

    private static string TenVaiTro(byte? ma) => ma is byte b ? VaiTroCodes.TenHienThi(b) : "";

    private void ApplyRoleUi()
    {
        var u = AppSession.CurrentUser;
        if (u is null)
        {
            return;
        }

        // Chỉ Quản trị (1) và Kỹ thuật viên (2) mới được vào danh mục Khoa / phòng.
        var duocVaoKhoaPhong = u.MaVaiTro == VaiTroCodes.QuanTri
                            || u.MaVaiTro == VaiTroCodes.KyThuatVien;
        btnNavKhoa.Visible = duocVaoKhoaPhong;

        lblNavHint.Text = u.MaVaiTro switch
        {
            VaiTroCodes.NguoiDung => "Bạn đang dùng quyền Người dùng: trên màn Ticket chỉ thấy ticket do bạn tạo.",
            VaiTroCodes.KyThuatVien => "Kỹ thuật viên: xem mọi ticket, phân công và đổi trạng thái xử lý. Khoa / phòng chỉ xem.",
            VaiTroCodes.QuanTri => "Quản trị: toàn quyền dữ liệu ticket và tra cứu, quản lý danh mục Khoa / phòng.",
            _ => ""
        };
    }

    private void NavButton_Click(object? sender, EventArgs e)
    {
        if (sender is not Button b)
        {
            return;
        }

        SetActiveNav(b);
        if (ReferenceEquals(b, btnNavDashboard))
        {
            OpenHost(new FrmDashboard(), "Tổng quan", "Số liệu theo trạng thái (theo phạm vi quyền của bạn).");
        }
        else if (ReferenceEquals(b, btnNavTickets))
        {
            OpenHost(new FrmTicket(), "Quản lý ticket", "Tạo mới, lọc, cập nhật và xóa ticket theo quyền.");
        }
        else if (ReferenceEquals(b, btnNavKhoa))
        {
            var ma = AppSession.CurrentUser?.MaVaiTro ?? 0;
            if (ma != VaiTroCodes.QuanTri && ma != VaiTroCodes.KyThuatVien)
            {
                MessageBox.Show(
                    "Chỉ Quản trị và Kỹ thuật viên mới được truy cập danh mục Khoa / phòng.",
                    "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetActiveNav(btnNavTickets);
                return;
            }

            OpenHost(new FrmKhoaPhongBrowse(), "Khoa / phòng", "Danh mục đơn vị nhận yêu cầu hỗ trợ.");
        }
        else if (ReferenceEquals(b, btnNavDanhBa))
        {
            OpenHost(new FrmDanhBa(), "Danh bạ liên hệ", "Tài khoản đang hoạt động — không hiển thị mật khẩu.");
        }
        else if (ReferenceEquals(b, btnNavHuongDan))
        {
            OpenHost(new FrmHuongDan(), "Hướng dẫn", "Phím tắt và quy tắc sử dụng nhanh.");
        }
        else if (ReferenceEquals(b, btnNavAbout))
        {
            OpenHost(new FrmGioiThieu(), "Giới thiệu", "Thông tin phiên bản và mục đích ứng dụng.");
        }
    }

    private void SetActiveNav(Button active)
    {
        foreach (var b in _navButtons)
        {
            var on = ReferenceEquals(b, active);
            b.BackColor = on ? _navActive : _navIdle;
            b.ForeColor = Color.White;
            b.Font = on ? new Font("Bahnschrift SemiBold", 10.25F) : UiTheme.FontUi(10.25F);
        }
    }

    private void OpenTickets() => OpenHost(new FrmTicket(), "Quản lý ticket", "Tạo mới, lọc, cập nhật và xóa ticket theo quyền.");

    private void OpenHost(Form f, string breadcrumb, string sub)
    {
        ClearContent();
        _hostedForm = f;
        f.TopLevel = false;
        f.FormBorderStyle = FormBorderStyle.None;
        f.Dock = DockStyle.Fill;
        panelContent.Controls.Add(f);
        f.Show();
        lblBreadcrumb.Text = breadcrumb;
        lblBreadcrumbSub.Text = sub;
    }

    private void ClearContent()
    {
        while (panelContent.Controls.Count > 0)
        {
            var c = panelContent.Controls[0];
            panelContent.Controls.Remove(c);
            c.Dispose();
        }

        _hostedForm = null;
    }

    private void BtnLogout_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show("Đăng xuất khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            Close();
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        ClearContent();
        base.OnFormClosed(e);
    }

    private void panelContent_Paint(object? sender, PaintEventArgs e)
    {
        if (sender is not Panel p)
        {
            return;
        }

        UiTheme.PaintSoftGradient(p, e, UiTheme.BgCanvas, Color.FromArgb(252, 249, 243));
    }

    private void panelSidebar_Paint(object? sender, PaintEventArgs e)
    {
        UiTheme.PaintSidebarAccent(e.Graphics, panelSidebar.ClientRectangle);
    }

    private void panelTop_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(UiTheme.BorderHairline, 1);
        e.Graphics.DrawLine(pen, 0, panelTop.Height - 1, panelTop.Width, panelTop.Height - 1);
    }

    private void lblBreadcrumb_Click(object sender, EventArgs e)
    {

    }

    private void lblNavCaption_Click(object sender, EventArgs e)
    {

    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
        FitToWorkingArea();
    }

    private void FitToWorkingArea()
    {
        var wa = Screen.FromControl(this).WorkingArea;
        StartPosition = FormStartPosition.Manual;
        Bounds = wa;
    }
}
