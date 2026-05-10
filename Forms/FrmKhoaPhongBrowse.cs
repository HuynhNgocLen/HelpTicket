using HelpTicket.Common;
using HelpTicket.DAL;
using HelpTicket.Models;

namespace HelpTicket.Forms;

public partial class FrmKhoaPhongBrowse : Form
{
    private readonly KhoaPhongDAL _dal = new();
    private List<KhoaPhong> _danhSachDayDu = new();

    private int _trangHienTai = 1;
    private int _kichThuocTrang = 10;

    public FrmKhoaPhongBrowse()
    {
        InitializeComponent();
        panelContent.Resize += (_, _) => SapXepChieuCaoLuoi();
        dgv.DataBindingComplete += (_, _) => SapXepChieuCaoLuoi();
        cboKichThuocTrang.SelectedIndex = 0;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        // Tra cứu danh mục cho mọi vai trò; CRUD chỉ Quản trị (ApDungPhanQuyen).
        var ma = AppSession.CurrentUser?.MaVaiTro ?? 0;
        if (ma != VaiTroCodes.QuanTri && ma != VaiTroCodes.KyThuatVien && ma != VaiTroCodes.NguoiDung)
        {
            MessageBox.Show(
                "Bạn không có quyền truy cập danh mục Khoa / phòng.",
                "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            BeginInvoke(Close);
            return;
        }

        KhoiTaoCotLuoi();
        ApDungPhanQuyen();
        TaiDuLieu(null);
        SapXepLayoutFooter();
        SapXepChieuCaoLuoi();
    }

    // ──────────────────────────────────────────────
    // Phân quyền
    // ──────────────────────────────────────────────
    private void ApDungPhanQuyen()
    {
        var ma = AppSession.CurrentUser?.MaVaiTro ?? 0;
        var laQuanTri = ma == VaiTroCodes.QuanTri;

        btnAdd.Enabled = laQuanTri;
        btnEdit.Enabled = laQuanTri;
        btnDelete.Enabled = laQuanTri;

        toolTip1 ??= new ToolTip();
        if (laQuanTri)
        {
            toolTip1.SetToolTip(btnAdd, "Thêm khoa / phòng mới");
            toolTip1.SetToolTip(btnEdit, "Sửa dòng đang chọn");
            toolTip1.SetToolTip(btnDelete, "Xóa dòng đang chọn");
        }
        else
        {
            const string hint = "Chỉ tài khoản Quản trị mới được phép thêm / sửa / xóa khoa, phòng.";
            toolTip1.SetToolTip(btnAdd, hint);
            toolTip1.SetToolTip(btnEdit, hint);
            toolTip1.SetToolTip(btnDelete, hint);

            btnAdd.BackColor = Color.FromArgb(226, 232, 240);
            btnAdd.ForeColor = Color.FromArgb(148, 163, 184);
        }
    }

    private ToolTip? toolTip1;

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
            DataPropertyName = nameof(KhoaPhong.MaKhoaPhong),
            HeaderText = "Mã",
            MinimumWidth = 72,
            FillWeight = 18
        });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(KhoaPhong.TenKhoaPhong),
            HeaderText = "Tên khoa / phòng",
            MinimumWidth = 160,
            FillWeight = 42
        });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(KhoaPhong.GhiChu),
            HeaderText = "Ghi chú",
            MinimumWidth = 120,
            FillWeight = 40
        });
    }

    private void TaiDuLieu(string? tuKhoa)
    {
        try
        {
            _danhSachDayDu = _dal.TimKiem(tuKhoa);
            _trangHienTai = 1;
            HienThiTrang();
            CapNhatThongKe();
            CapNhatTrangThaiNutHanhDong();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Khoa / Phòng", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ? "Không có đơn vị nào"
            : $"Hiển thị {tu}–{den} trong tổng số {tongSo} đơn vị";

        btnTrangDau.Enabled = _trangHienTai > 1;
        btnTrangTruoc.Enabled = _trangHienTai > 1;
        btnTrangSau.Enabled = _trangHienTai < tongTrang;
        btnTrangCuoi.Enabled = _trangHienTai < tongTrang;
    }

    private void CapNhatThongKe()
    {
        var tong = _danhSachDayDu.Count;
        lblTotalLabel.Text = "TỔNG SỐ ĐƠN VỊ";
        lblTotalValue.Text = tong.ToString();
        lblTotalSub.Text = "đơn vị trong danh mục";

        lblActiveLabel.Text = "CÓ GHI CHÚ";
        lblActiveValue.Text = _danhSachDayDu.Count(k => !string.IsNullOrWhiteSpace(k.GhiChu)).ToString();
        lblActiveSub.Text = "đơn vị có mô tả";

        lblPausedLabel.Text = "KẾT QUẢ HIỂN THỊ";
        lblPausedValue.Text = tong.ToString();
        lblPausedSub.Text = "dòng theo bộ lọc";
    }

    private void CapNhatTrangThaiNutHanhDong()
    {
        var laQuanTri = AppSession.CurrentUser?.MaVaiTro == VaiTroCodes.QuanTri;
        var coDong = dgv.CurrentRow?.DataBoundItem is KhoaPhong;
        btnEdit.Enabled = laQuanTri && coDong;
        btnDelete.Enabled = laQuanTri && coDong;
    }

    // ──────────────────────────────────────────────
    // Sự kiện toolbar
    // ──────────────────────────────────────────────
    private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BtnFilter_Click(sender, EventArgs.Empty);
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.Escape)
        {
            txtSearch.Clear();
            BtnFilter_Click(sender, EventArgs.Empty);
        }
    }

    private void TxtSearch_TextChanged(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtSearch.Text))
        {
            TaiDuLieu(null);
        }
    }

    private void BtnFilter_Click(object? sender, EventArgs e)
    {
        var kw = txtSearch.Text.Trim();
        TaiDuLieu(string.IsNullOrEmpty(kw) ? null : kw);
    }

    private void BtnRefresh_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        TaiDuLieu(null);
    }

    private void Dgv_SelectionChanged(object? sender, EventArgs e)
    {
        CapNhatTrangThaiNutHanhDong();
    }

    private void Dgv_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        if (AppSession.CurrentUser?.MaVaiTro != VaiTroCodes.QuanTri)
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

        using var dlg = new FrmKhoaPhongEdit();
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            TaiDuLieu(string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text.Trim());
            if (dlg.KetQua is { } moi)
            {
                ChonDongTheoMa(moi.MaKhoaPhong);
            }
        }
    }

    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        if (!KiemTraQuyenQuanTri())
        {
            return;
        }

        if (dgv.CurrentRow?.DataBoundItem is not KhoaPhong dong)
        {
            MessageBox.Show("Hãy chọn một dòng để sửa.", "Sửa khoa / phòng",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dlg = new FrmKhoaPhongEdit(dong);
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            TaiDuLieu(string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text.Trim());
            ChonDongTheoMa(dong.MaKhoaPhong);
        }
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (!KiemTraQuyenQuanTri())
        {
            return;
        }

        if (dgv.CurrentRow?.DataBoundItem is not KhoaPhong dong)
        {
            MessageBox.Show("Hãy chọn một dòng để xóa.", "Xóa khoa / phòng",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            if (_dal.DangDuocSuDung(dong.MaKhoaPhong))
            {
                MessageBox.Show(
                    $"Khoa / phòng \"{dong.TenKhoaPhong}\" đang được dùng cho người dùng hoặc ticket nên không thể xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show(
                $"Xóa khoa / phòng \"{dong.TenKhoaPhong}\"?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            _dal.Xoa(dong.MaKhoaPhong);
            TaiDuLieu(string.IsNullOrWhiteSpace(txtSearch.Text) ? null : txtSearch.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool KiemTraQuyenQuanTri()
    {
        if (AppSession.CurrentUser?.MaVaiTro == VaiTroCodes.QuanTri)
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
            if (row.DataBoundItem is KhoaPhong k && k.MaKhoaPhong == ma)
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
        var pad = 12;

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
}
