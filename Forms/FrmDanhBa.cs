using HelpTicket.Common;
using HelpTicket.DAL;
using HelpTicket.Models;

namespace HelpTicket.Forms;

public partial class FrmDanhBa : Form
{
    private readonly NguoiDungDAL _dal = new();
    private List<NguoiDung> _danhSachDayDu = new();

    private int _trangHienTai = 1;
    private int _kichThuocTrang = 10;

    private bool LaQuanTri => AppSession.CurrentUser?.MaVaiTro == VaiTroCodes.QuanTri;

    public FrmDanhBa()
    {
        InitializeComponent();
        panelContent.Resize += (_, _) => SapXepChieuCaoLuoi();
        dgv.DataBindingComplete += (_, _) => SapXepChieuCaoLuoi();
        dgv.CellFormatting += Dgv_CellFormatting;
        cboKichThuocTrang.SelectedIndex = 0;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        // Stat cards
        FrmDanhBa.BuildStatCard(cardTotal, lblTotalLabel, lblTotalValue, lblTotalSub,
            "TỔNG SỐ TÀI KHOẢN", "0", "trong danh bạ", Color.FromArgb(24, 95, 165));
        FrmDanhBa.BuildStatCard(cardActive, lblActiveLabel, lblActiveValue, lblActiveSub,
            "ĐANG HOẠT ĐỘNG", "0", "tài khoản có thể đăng nhập", Color.FromArgb(13, 148, 136));
        FrmDanhBa.BuildStatCard(cardPaused, lblPausedLabel, lblPausedValue, lblPausedSub,
            "ĐÃ TẮT", "0", "tài khoản tạm dừng", Color.FromArgb(180, 83, 9));

        NapBoLoc();
        KhoiTaoCotLuoi();
        ApDungPhanQuyen();
        TaiDuLieu();
        SapXepLayoutFooter();
        SapXepChieuCaoLuoi();
    }

    // ──────────────────────────────────────────────
    // Bộ lọc
    // ──────────────────────────────────────────────
    private void NapBoLoc()
    {
        cboLocVaiTro.Items.Clear();
        cboLocVaiTro.Items.Add(new BoLocItem("Tất cả vai trò", null));
        cboLocVaiTro.Items.Add(new BoLocItem("Quản trị", (byte)VaiTroCodes.QuanTri));
        cboLocVaiTro.Items.Add(new BoLocItem("Kỹ thuật viên", (byte)VaiTroCodes.KyThuatVien));
        cboLocVaiTro.Items.Add(new BoLocItem("Người dùng", (byte)VaiTroCodes.NguoiDung));
        cboLocVaiTro.SelectedIndex = 0;

        cboLocTrangThai.Items.Clear();
        cboLocTrangThai.Items.Add(new BoLocItem("Tất cả trạng thái", (object?)null));
        cboLocTrangThai.Items.Add(new BoLocItem("Đang hoạt động", true));
        cboLocTrangThai.Items.Add(new BoLocItem("Đã tắt", false));

        // KTV / User chỉ xem tài khoản đang hoạt động
        if (LaQuanTri)
        {
            cboLocTrangThai.SelectedIndex = 0;
        }
        else
        {
            cboLocTrangThai.SelectedIndex = 1;
            cboLocTrangThai.Enabled = false;
        }
    }

    // ──────────────────────────────────────────────
    // Phân quyền
    // ──────────────────────────────────────────────
    private void ApDungPhanQuyen()
    {
        var quanTri = LaQuanTri;

        btnAdd.Enabled = quanTri;
        btnEdit.Enabled = quanTri;
        btnDelete.Enabled = quanTri;
        btnToggle.Enabled = quanTri;
        btnAdd.Visible = quanTri;
        btnEdit.Visible = quanTri;
        btnDelete.Visible = quanTri;
        btnToggle.Visible = quanTri;

        // Tooltip phụ trợ
        var tip = new ToolTip();
        if (!quanTri)
        {
            const string hint = "Chỉ tài khoản Quản trị mới được phép thêm / sửa / xóa / khóa tài khoản.";
            tip.SetToolTip(btnAdd, hint);
            tip.SetToolTip(btnEdit, hint);
            tip.SetToolTip(btnDelete, hint);
            tip.SetToolTip(btnToggle, hint);
            lblSubtitle.Text = "Danh bạ tài khoản — bạn chỉ có quyền xem.";
        }
        else
        {
            tip.SetToolTip(btnAdd, "Tạo tài khoản mới");
            tip.SetToolTip(btnEdit, "Sửa tài khoản đang chọn");
            tip.SetToolTip(btnDelete, "Xóa tài khoản (không khả dụng nếu đã có ticket)");
            tip.SetToolTip(btnToggle, "Bật / tắt hoạt động");
            lblSubtitle.Text = "Quản lý tài khoản người dùng hệ thống.";
        }
    }

    // ──────────────────────────────────────────────
    // Lưới dữ liệu
    // ──────────────────────────────────────────────
    private void KhoiTaoCotLuoi()
    {
        dgv.AutoGenerateColumns = false;
        dgv.Columns.Clear();
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(NguoiDung.MaNguoiDung),
            HeaderText = "Mã",
            MinimumWidth = 52,
            FillWeight = 6
        });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(NguoiDung.TenDangNhap),
            HeaderText = "Tài khoản",
            MinimumWidth = 110,
            FillWeight = 14
        });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(NguoiDung.HoTen),
            HeaderText = "Họ tên",
            MinimumWidth = 140,
            FillWeight = 18
        });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(NguoiDung.Email),
            HeaderText = "Email",
            MinimumWidth = 160,
            FillWeight = 20
        });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(NguoiDung.TenKhoaPhong),
            HeaderText = "Khoa / phòng",
            MinimumWidth = 130,
            FillWeight = 16
        });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(NguoiDung.MaVaiTro),
            HeaderText = "Vai trò",
            MinimumWidth = 100,
            FillWeight = 12
        });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(NguoiDung.HoatDong),
            HeaderText = "Trạng thái",
            MinimumWidth = 90,
            FillWeight = 10
        });
    }

    private static void Dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (sender is not DataGridView grid || e.ColumnIndex < 0)
        {
            return;
        }

        var name = grid.Columns[e.ColumnIndex].DataPropertyName;
        if (name == nameof(NguoiDung.MaVaiTro) && e.Value is byte bt)
        {
            e.Value = VaiTroCodes.TenHienThi(bt);
            e.FormattingApplied = true;
        }
        else if (name == nameof(NguoiDung.HoatDong) && e.Value is bool hd)
        {
            e.Value = hd ? "Hoạt động" : "Đã tắt";
            e.FormattingApplied = true;
            e.CellStyle!.ForeColor = hd
                ? Color.FromArgb(13, 148, 136)
                : Color.FromArgb(180, 83, 9);
        }
    }

    private void TaiDuLieu()
    {
        try
        {
            var kw = string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text.Trim();
            byte? vt = null;
            bool? hd = null;

            if (cboLocVaiTro.SelectedItem is BoLocItem v && v.Value is byte b)
            {
                vt = b;
            }

            if (cboLocTrangThai.SelectedItem is BoLocItem t && t.Value is bool tb)
            {
                hd = tb;
            }

            // KTV / User: ép chỉ xem tài khoản hoạt động
            if (!LaQuanTri)
            {
                hd = true;
            }

            _danhSachDayDu = _dal.GetTatCa(kw, hd, vt);
            _trangHienTai = 1;
            HienThiTrang();
            CapNhatThongKe();
            CapNhatTrangThaiNutHanhDong();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Danh bạ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void HienThiTrang()
    {
        var tongSo = _danhSachDayDu.Count;
        var tongTrang = Math.Max(1, (int)Math.Ceiling(tongSo / (double)_kichThuocTrang));
        if (_trangHienTai > tongTrang)
        {
            _trangHienTai = tongTrang;
        }

        if (_trangHienTai < 1)
        {
            _trangHienTai = 1;
        }

        var trang = _danhSachDayDu
            .Skip((_trangHienTai - 1) * _kichThuocTrang)
            .Take(_kichThuocTrang)
            .ToList();

        dgv.DataSource = null;
        dgv.DataSource = trang;
        dgv.ClearSelection();

        lblTrang.Text = $"Trang {_trangHienTai} / {tongTrang}";

        var tu = tongSo == 0 ? 0 : (_trangHienTai - 1) * _kichThuocTrang + 1;
        var den = Math.Min(tongSo, _trangHienTai * _kichThuocTrang);
        lblFooterInfo.Text = tongSo == 0
            ? "Không có tài khoản nào"
            : $"Hiển thị {tu}–{den} trong tổng số {tongSo} tài khoản";

        btnTrangDau.Enabled = _trangHienTai > 1;
        btnTrangTruoc.Enabled = _trangHienTai > 1;
        btnTrangSau.Enabled = _trangHienTai < tongTrang;
        btnTrangCuoi.Enabled = _trangHienTai < tongTrang;
    }

    private void CapNhatThongKe()
    {
        var tong = _danhSachDayDu.Count;
        var hd = _danhSachDayDu.Count(n => n.HoatDong);
        var off = tong - hd;

        lblTotalValue.Text = tong.ToString();
        lblActiveValue.Text = hd.ToString();
        lblPausedValue.Text = off.ToString();
    }

    private void CapNhatTrangThaiNutHanhDong()
    {
        var coDong = dgv.CurrentRow?.DataBoundItem is NguoiDung;
        var quanTri = LaQuanTri;
        btnEdit.Enabled = quanTri && coDong;
        btnDelete.Enabled = quanTri && coDong;
        btnToggle.Enabled = quanTri && coDong;

        if (coDong && dgv.CurrentRow!.DataBoundItem is NguoiDung n)
        {
            btnToggle.Text = n.HoatDong ? "⏻  Tắt" : "⏻  Bật";
        }
        else
        {
            btnToggle.Text = "⏻  Tắt";
        }
    }

    // ──────────────────────────────────────────────
    // Sự kiện toolbar
    // ──────────────────────────────────────────────
    private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            TaiDuLieu();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.Escape)
        {
            txtSearch.Clear();
            TaiDuLieu();
        }
    }

    private void TxtSearch_TextChanged(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtSearch.Text))
        {
            TaiDuLieu();
        }
    }

    private void CboLoc_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (IsHandleCreated)
        {
            TaiDuLieu();
        }
    }

    private void BtnRefresh_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        TaiDuLieu();
    }

    private void Dgv_SelectionChanged(object? sender, EventArgs e)
    {
        CapNhatTrangThaiNutHanhDong();
    }

    private void Dgv_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || !LaQuanTri)
        {
            return;
        }

        BtnEdit_Click(sender, EventArgs.Empty);
    }

    // ──────────────────────────────────────────────
    // Phân trang
    // ──────────────────────────────────────────────
    private void BtnTrangDau_Click(object? sender, EventArgs e)
    {
        if (_trangHienTai != 1)
        {
            _trangHienTai = 1;
            HienThiTrang();
        }
    }

    private void BtnTrangTruoc_Click(object? sender, EventArgs e)
    {
        if (_trangHienTai > 1)
        {
            _trangHienTai--;
            HienThiTrang();
        }
    }

    private void BtnTrangSau_Click(object? sender, EventArgs e)
    {
        var tongTrang = Math.Max(1, (int)Math.Ceiling(_danhSachDayDu.Count / (double)_kichThuocTrang));
        if (_trangHienTai < tongTrang)
        {
            _trangHienTai++;
            HienThiTrang();
        }
    }

    private void BtnTrangCuoi_Click(object? sender, EventArgs e)
    {
        var tongTrang = Math.Max(1, (int)Math.Ceiling(_danhSachDayDu.Count / (double)_kichThuocTrang));
        if (_trangHienTai != tongTrang)
        {
            _trangHienTai = tongTrang;
            HienThiTrang();
        }
    }

    private void CboKichThuocTrang_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cboKichThuocTrang.SelectedItem is string s && int.TryParse(s, out var n) && n > 0)
        {
            _kichThuocTrang = n;
            _trangHienTai = 1;
            if (dgv.Columns.Count > 0)
            {
                HienThiTrang();
            }
        }
    }

    // ──────────────────────────────────────────────
    // CRUD
    // ──────────────────────────────────────────────
    private void BtnAdd_Click(object? sender, EventArgs e)
    {
        if (!KiemTraQuyenQuanTri())
        {
            return;
        }

        using var dlg = new FrmDanhBaEdit();
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            TaiDuLieu();
            if (dlg.KetQua is { } moi)
            {
                ChonDongTheoMa(moi.MaNguoiDung);
            }
        }
    }

    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        if (!KiemTraQuyenQuanTri())
        {
            return;
        }

        if (dgv.CurrentRow?.DataBoundItem is not NguoiDung dong)
        {
            MessageBox.Show("Hãy chọn một tài khoản để sửa.", "Sửa tài khoản",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dlg = new FrmDanhBaEdit(dong);
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            TaiDuLieu();
            ChonDongTheoMa(dong.MaNguoiDung);
        }
    }

    private void BtnToggle_Click(object? sender, EventArgs e)
    {
        if (!KiemTraQuyenQuanTri())
        {
            return;
        }

        if (dgv.CurrentRow?.DataBoundItem is not NguoiDung dong)
        {
            MessageBox.Show("Hãy chọn một tài khoản.", "Bật / tắt hoạt động",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (AppSession.CurrentUser?.MaNguoiDung == dong.MaNguoiDung)
        {
            MessageBox.Show("Không thể tự khoá tài khoản đang đăng nhập.",
                "Bật / tắt hoạt động", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var trangThaiMoi = !dong.HoatDong;
        var hanhDong = trangThaiMoi ? "BẬT" : "TẮT";
        var xacNhan = MessageBox.Show(
            $"{hanhDong} hoạt động cho tài khoản \"{dong.HoTen}\" ({dong.TenDangNhap})?",
            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (xacNhan != DialogResult.Yes)
        {
            return;
        }

        try
        {
            _dal.DatHoatDong(dong.MaNguoiDung, trangThaiMoi);
            TaiDuLieu();
            ChonDongTheoMa(dong.MaNguoiDung);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (!KiemTraQuyenQuanTri())
        {
            return;
        }

        if (dgv.CurrentRow?.DataBoundItem is not NguoiDung dong)
        {
            MessageBox.Show("Hãy chọn một tài khoản để xóa.", "Xóa tài khoản",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (AppSession.CurrentUser?.MaNguoiDung == dong.MaNguoiDung)
        {
            MessageBox.Show("Không thể xóa tài khoản đang đăng nhập.",
                "Xóa tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            if (_dal.DangDuocSuDung(dong.MaNguoiDung))
            {
                MessageBox.Show(
                    $"Tài khoản \"{dong.HoTen}\" đã có ticket liên quan, không thể xóa.\n" +
                    "Bạn nên TẮT hoạt động thay vì xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show(
                $"Xóa vĩnh viễn tài khoản \"{dong.HoTen}\" ({dong.TenDangNhap})?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            _dal.Xoa(dong.MaNguoiDung);
            TaiDuLieu();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool KiemTraQuyenQuanTri()
    {
        if (LaQuanTri)
        {
            return true;
        }

        MessageBox.Show("Bạn không có quyền thực hiện thao tác này.\nVui lòng liên hệ Quản trị.",
            "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }

    private void ChonDongTheoMa(int ma)
    {
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (row.DataBoundItem is NguoiDung n && n.MaNguoiDung == ma)
            {
                row.Selected = true;
                dgv.CurrentCell = row.Cells[0];
                break;
            }
        }
    }

    // ──────────────────────────────────────────────
    // Layout
    // ──────────────────────────────────────────────
    private void PanelFooter_Resize(object? sender, EventArgs e) => SapXepLayoutFooter();

    private void SapXepLayoutFooter()
    {
        if (panelFooter is null || cboKichThuocTrang is null)
        {
            return;
        }

        var w = panelFooter.ClientSize.Width;
        var h = panelFooter.ClientSize.Height;
        const int pad = 12;
        const int gap = 4;
        var y = (h - 26) / 2;

        var x = w - pad - cboKichThuocTrang.Width;
        cboKichThuocTrang.Location = new Point(x, (h - cboKichThuocTrang.Height) / 2);

        lblKichThuocTrang.Location = new Point(x - lblKichThuocTrang.Width - 6,
            (h - lblKichThuocTrang.Height) / 2);

        x = lblKichThuocTrang.Left - 16;
        x -= btnTrangCuoi.Width;
        btnTrangCuoi.Location = new Point(x, y);
        x -= btnTrangSau.Width + gap;
        btnTrangSau.Location = new Point(x, y);
        x -= btnTrangTruoc.Width + gap;
        btnTrangTruoc.Location = new Point(x, y);
        x -= btnTrangDau.Width + gap;
        btnTrangDau.Location = new Point(x, y);

        x -= lblTrang.Width + 8;
        lblTrang.Location = new Point(x, (h - lblTrang.Height) / 2);
    }

    private void SapXepChieuCaoLuoi()
    {
        if (!IsHandleCreated || dgv.Columns.Count == 0)
        {
            return;
        }

        var chFooter = panelFooter.Visible ? panelFooter.Height : 0;
        var maxH = Math.Max(80, panelContent.ClientSize.Height - chFooter);
        var headerH = dgv.ColumnHeadersVisible ? dgv.ColumnHeadersHeight : 0;
        var rowsH = 0;
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (row.Visible)
            {
                rowsH += row.Height;
            }
        }

        var preferred = headerH + rowsH + 6;
        dgv.Width = panelContent.ClientSize.Width;
        dgv.Height = Math.Min(Math.Max(preferred, 72), maxH);
        dgv.Location = new Point(0, 0);
        dgv.ScrollBars = preferred > maxH ? ScrollBars.Vertical : ScrollBars.None;
    }

    /// <summary>Phần tử cho ComboBox lọc.</summary>
    private sealed class BoLocItem
    {
        public string Text { get; }
        public object? Value { get; }
        public BoLocItem(string text, object? value)
        {
            Text = text;
            Value = value;
        }
        public override string ToString() => Text;
    }
}
