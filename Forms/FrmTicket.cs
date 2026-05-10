using System.Text;
using HelpTicket.Common;
using HelpTicket.DAL;
using HelpTicket.Models;

namespace HelpTicket.Forms;

public partial class FrmTicket : Form
{
    private sealed class TrangThaiViewItem
    {
        public string? Ma { get; init; }
        public required string Ten { get; init; }
        public override string ToString() => Ten;
    }

    /// <summary>
    /// Mục lọc theo người phụ trách.
    /// MaNguoiDung == null: tất cả; == 0: chưa phân công; &gt; 0: KTV cụ thể.
    /// </summary>
    private sealed class NguoiPhuTrachLocItem
    {
        public int? MaNguoiDung { get; init; }
        public required string HoTen { get; init; }
        public override string ToString() => HoTen;
    }

    private readonly TicketDAL _ticketDal = new();
    private readonly KhoaPhongDAL _khoaDal = new();
    private readonly NguoiDungDAL _nguoiDal = new();

    private List<Ticket> _danhSachDayDu = new();
    private int _trangHienTai = 1;
    private int _kichThuocTrang = 10;

    public FrmTicket()
    {
        InitializeComponent();
        dgv.CellFormatting += Dgv_CellFormatting;
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        txtLocTieuDe.KeyDown += TxtLocTieuDe_KeyDown;
        cboKichThuocTrang.SelectedIndex = 0;
    }

    private void TxtLocTieuDe_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BtnLoc_Click(null, EventArgs.Empty);
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }

    private void FrmTicket_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            txtLocTieuDe.Focus();
            txtLocTieuDe.SelectAll();
            e.Handled = true;
        }
    }

    private void Dgv_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        txtTieuDe.Focus();
    }

    private void Dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0)
        {
            return;
        }

        var col = dgv.Columns[e.ColumnIndex];
        if (col.DataPropertyName == nameof(Ticket.TrangThai) && e.Value is string raw)
        {
            e.Value = TrangThaiTicket.HienThi(raw);
            e.FormattingApplied = true;
            if (e.CellStyle != null)
            {
                e.CellStyle.BackColor = MauNenTheoTrangThai(raw);
                e.CellStyle.SelectionBackColor = Color.FromArgb(208, 232, 255);
            }
        }
        else if (col.DataPropertyName == nameof(Ticket.DoUuTien) && e.Value != null)
        {
            e.Value = Ticket.TenDoUuTien(Convert.ToByte(e.Value));
            e.FormattingApplied = true;
        }
    }

    private static Color MauNenTheoTrangThai(string ma) => ma switch
    {
        TrangThaiTicket.HoanThanh => Color.FromArgb(236, 253, 245),
        TrangThaiTicket.Mo => Color.FromArgb(254, 249, 231),
        TrangThaiTicket.DangXuLy => Color.FromArgb(235, 244, 255),
        TrangThaiTicket.Huy => Color.FromArgb(241, 241, 241),
        _ => Color.White
    };

    private static void CapNhatThongKe(Label lbl, List<Ticket> list)
    {
        var nMo = list.Count(t => t.TrangThai == TrangThaiTicket.Mo);
        var nDx = list.Count(t => t.TrangThai == TrangThaiTicket.DangXuLy);
        var nHt = list.Count(t => t.TrangThai == TrangThaiTicket.HoanThanh);
        var nHuy = list.Count(t => t.TrangThai == TrangThaiTicket.Huy);
        lbl.Text = $"Hiển thị {list.Count} ticket   ·   Mở: {nMo}   ·   Đang xử lý: {nDx}   ·   Hoàn thành: {nHt}   ·   Hủy: {nHuy}";
    }

    private void BtnXuatCsv_Click(object? sender, EventArgs e)
    {
        if (_danhSachDayDu.Count == 0)
        {
            MessageBox.Show("Không có dòng để xuất.", "Xuất CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dlg = new SaveFileDialog
        {
            Filter = "CSV cho Excel (*.csv)|*.csv",
            FileName = $"HelpTicket_{DateTime.Now:yyyyMMdd_HHmm}.csv",
            Title = "Xuất danh sách ticket ra CSV"
        };

        if (dlg.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        try
        {
            const char sep = ',';
            var sb = new StringBuilder();
            var exportColumns = dgv.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .ToList();

            sb.Append(EscapeCsv("STT", sep));
            foreach (var col in exportColumns)
            {
                sb.Append(sep);
                sb.Append(EscapeCsv(col.HeaderText, sep));
            }

            sb.AppendLine();

            var stt = 0;
            foreach (var ticket in _danhSachDayDu)
            {
                stt++;
                sb.Append(stt);

                foreach (var col in exportColumns)
                {
                    sb.Append(sep);
                    var v = LayGiaTriCsv(ticket, col);
                    sb.Append(EscapeCsv(v, sep));
                }

                sb.AppendLine();
            }

            File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

            if (MessageBox.Show(
                    $"Đã xuất {stt} dòng ra file:\n{dlg.FileName}\n\nMở file ngay?",
                    "Xuất CSV",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = dlg.FileName,
                    UseShellExecute = true
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static string LayGiaTriCsv(Ticket ticket, DataGridViewColumn col)
    {
        return col.DataPropertyName switch
        {
            nameof(Ticket.MaTicket) => ticket.MaTicket.ToString(),
            nameof(Ticket.TieuDe) => ticket.TieuDe,
            nameof(Ticket.TenKhoaPhong) => ticket.TenKhoaPhong ?? "",
            nameof(Ticket.TrangThai) => TrangThaiTicket.HienThi(ticket.TrangThai),
            nameof(Ticket.DoUuTien) => Ticket.TenDoUuTien(ticket.DoUuTien),
            nameof(Ticket.TenNguoiPhuTrach) => ticket.TenNguoiPhuTrach ?? "",
            nameof(Ticket.TenNguoiTao) => ticket.TenNguoiTao ?? "",
            nameof(Ticket.NgayTao) => ticket.NgayTao.ToString("dd/MM/yyyy HH:mm"),
            _ => ""
        };
    }

    private static string EscapeCsv(string s, char sep)
    {
        return "\"" + s.Replace("\"", "\"\"", StringComparison.Ordinal) + "\"";
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        NapBoLoc();
        PhanQuyenGiaoDien();
        BtnLoc_Click(null, EventArgs.Empty);
        LamTrangChiTiet();
        panelDetail.Visible = true;
    }

    private void PhanQuyenGiaoDien()
    {
        var u = AppSession.CurrentUser;
        if (u is null)
        {
            return;
        }

        var laQtOrKt = u.MaVaiTro == VaiTroCodes.QuanTri || u.MaVaiTro == VaiTroCodes.KyThuatVien;
        cboNguoiPhuTrach.Enabled = laQtOrKt;
        cboTrangThaiChiTiet.Enabled = laQtOrKt;
        btnXoa.Enabled = laQtOrKt || u.MaVaiTro == VaiTroCodes.NguoiDung;
    }

    private void NapBoLoc()
    {
        var khoa = _khoaDal.GetAll();
        khoa.Insert(0, new KhoaPhong { MaKhoaPhong = 0, TenKhoaPhong = "(Tất cả khoa/phòng)" });
        cboLocKhoa.DataSource = khoa;
        cboLocKhoa.DisplayMember = nameof(KhoaPhong.TenKhoaPhong);
        cboLocKhoa.ValueMember = nameof(KhoaPhong.MaKhoaPhong);

        cboLocTrang.Items.Clear();
        cboLocTrang.Items.Add(new TrangThaiViewItem { Ma = null, Ten = "(Tất cả trạng thái)" });
        foreach (var ma in TrangThaiTicket.TatCa)
        {
            cboLocTrang.Items.Add(new TrangThaiViewItem { Ma = ma, Ten = TrangThaiTicket.HienThi(ma) });
        }

        cboLocTrang.SelectedIndex = 0;

        cboLocKyThuat.Items.Clear();
        cboLocKyThuat.Items.Add(new NguoiPhuTrachLocItem { MaNguoiDung = null, HoTen = "(Tất cả người phụ trách)" });
        cboLocKyThuat.Items.Add(new NguoiPhuTrachLocItem { MaNguoiDung = 0, HoTen = "(Chưa phân công)" });
        foreach (var kt in _nguoiDal.GetNguoiCoThePhuTrach())
        {
            var nhan = $"{kt.HoTen} — {VaiTroCodes.TenHienThi(kt.MaVaiTro)}";
            cboLocKyThuat.Items.Add(new NguoiPhuTrachLocItem { MaNguoiDung = kt.MaNguoiDung, HoTen = nhan });
        }

        cboLocKyThuat.SelectedIndex = 0;

        var khoaChiTiet = _khoaDal.GetAll();
        cboKhoaChiTiet.DataSource = khoaChiTiet;
        cboKhoaChiTiet.DisplayMember = nameof(KhoaPhong.TenKhoaPhong);
        cboKhoaChiTiet.ValueMember = nameof(KhoaPhong.MaKhoaPhong);

        var ttChiTiet = TrangThaiTicket.TatCa
            .Select(ma => new TrangThaiViewItem { Ma = ma, Ten = TrangThaiTicket.HienThi(ma) })
            .ToList();
        cboTrangThaiChiTiet.DataSource = ttChiTiet;
        cboTrangThaiChiTiet.DisplayMember = nameof(TrangThaiViewItem.Ten);
        cboTrangThaiChiTiet.ValueMember = nameof(TrangThaiViewItem.Ma);

        var nv = _nguoiDal.GetNguoiCoThePhuTrach();
        nv.Insert(0, new NguoiDung { MaNguoiDung = 0, HoTen = "(Chưa phân công)" });
        cboNguoiPhuTrach.DataSource = nv;
        cboNguoiPhuTrach.DisplayMember = nameof(NguoiDung.HoTen);
        cboNguoiPhuTrach.ValueMember = nameof(NguoiDung.MaNguoiDung);
    }

    private void BtnLoc_Click(object? sender, EventArgs e)
    {
        try
        {
            var kw = txtLocTieuDe.Text.Trim();
            int? mk = null;
            if (cboLocKhoa.SelectedValue is int ma && ma > 0)
            {
                mk = ma;
            }

            string? tt = null;
            if (cboLocTrang.SelectedItem is TrangThaiViewItem loc && loc.Ma is not null)
            {
                tt = loc.Ma;
            }

            int? mpt = null;
            if (cboLocKyThuat.SelectedItem is NguoiPhuTrachLocItem locPt && locPt.MaNguoiDung.HasValue)
            {
                mpt = locPt.MaNguoiDung;
            }

            _danhSachDayDu = _ticketDal.TimKiem(string.IsNullOrEmpty(kw) ? null : kw, mk, tt, mpt);
            _trangHienTai = 1;
            DungCotLuoi();
            HienThiTrang();
            panelDetail.Visible = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DungCotLuoi()
    {
        if (dgv.Columns.Count > 0)
        {
            return;
        }

        dgv.AutoGenerateColumns = false;
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Ticket.MaTicket), HeaderText = "Mã", MinimumWidth = 44, FillWeight = 60 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Ticket.TieuDe), HeaderText = "Tiêu đề", MinimumWidth = 140, FillWeight = 280 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Ticket.TenKhoaPhong), HeaderText = "Khoa/Phòng", MinimumWidth = 96, FillWeight = 160 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Ticket.TrangThai), HeaderText = "Trạng thái", MinimumWidth = 96, FillWeight = 120 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Ticket.DoUuTien), HeaderText = "Ưu tiên", MinimumWidth = 72, FillWeight = 70 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Ticket.TenNguoiPhuTrach), HeaderText = "Người phụ trách", MinimumWidth = 100, FillWeight = 160 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Ticket.TenNguoiTao), HeaderText = "Người tạo", MinimumWidth = 96, FillWeight = 140 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Ticket.NgayTao),
            HeaderText = "Ngày tạo",
            MinimumWidth = 118,
            FillWeight = 130,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
        });
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

        lblTrang.Text = $"Trang {_trangHienTai} / {tongTrang}   ·   {tongSo} dòng";
        btnTrangDau.Enabled = _trangHienTai > 1;
        btnTrangTruoc.Enabled = _trangHienTai > 1;
        btnTrangSau.Enabled = _trangHienTai < tongTrang;
        btnTrangCuoi.Enabled = _trangHienTai < tongTrang;

        CapNhatThongKe(lblThongKe, _danhSachDayDu);
    }

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

    private void Dgv_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgv.CurrentRow?.DataBoundItem is not Ticket t)
        {
            return;
        }

        panelDetail.Visible = true;
        txtMa.Text = t.MaTicket.ToString();
        txtTieuDe.Text = t.TieuDe;
        txtNoiDung.Text = t.NoiDung ?? "";
        numDoUuTien.Value = Math.Clamp(t.DoUuTien, (byte)1, (byte)3);

        if (cboKhoaChiTiet.Items.Count > 0)
        {
            cboKhoaChiTiet.SelectedValue = t.MaKhoaPhong;
        }

        cboTrangThaiChiTiet.SelectedValue = t.TrangThai;
        if (cboTrangThaiChiTiet.SelectedIndex < 0)
        {
            cboTrangThaiChiTiet.SelectedValue = TrangThaiTicket.Mo;
        }

        var pt = t.MaNguoiPhuTrach ?? 0;
        cboNguoiPhuTrach.SelectedValue = pt;
    }

    private void BtnThem_Click(object? sender, EventArgs e)
    {
        try
        {
            if (cboKhoaChiTiet.SelectedValue is not int mk)
            {
                MessageBox.Show("Chọn khoa/phòng.", "Thêm ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var entity = new Ticket
            {
                TieuDe = txtTieuDe.Text.Trim(),
                NoiDung = txtNoiDung.Text.Trim(),
                MaKhoaPhong = mk,
                DoUuTien = (byte)numDoUuTien.Value,
                TrangThai = TrangThaiTicket.Mo
            };

            if (string.IsNullOrWhiteSpace(entity.TieuDe))
            {
                MessageBox.Show("Nhập tiêu đề.", "Thêm ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var u = AppSession.CurrentUser!;
            if (u.MaVaiTro == VaiTroCodes.QuanTri || u.MaVaiTro == VaiTroCodes.KyThuatVien)
            {
                if (cboNguoiPhuTrach.SelectedValue is int p && p > 0)
                {
                    entity.MaNguoiPhuTrach = p;
                }

                if (cboTrangThaiChiTiet.SelectedValue is string tt && !string.IsNullOrEmpty(tt))
                {
                    entity.TrangThai = tt;
                }
            }

            _ticketDal.Them(entity);
            BtnLoc_Click(null, EventArgs.Empty);
            MessageBox.Show("Đã tạo ticket.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnSua_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtMa.Text, out var id) || id <= 0)
            {
                MessageBox.Show("Chọn một ticket trong lưới.", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var current = _ticketDal.GetById(id);
            if (current is null)
            {
                MessageBox.Show("Không tìm thấy ticket.", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_ticketDal.CoQuyenXem(current))
            {
                MessageBox.Show("Bạn không có quyền sửa ticket này.", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var u = AppSession.CurrentUser!;
            if (u.MaVaiTro == VaiTroCodes.QuanTri || u.MaVaiTro == VaiTroCodes.KyThuatVien)
            {
                if (cboKhoaChiTiet.SelectedValue is not int mk)
                {
                    return;
                }

                int? pt = null;
                if (cboNguoiPhuTrach.SelectedValue is int p && p > 0)
                {
                    pt = p;
                }

                var tt = cboTrangThaiChiTiet.SelectedValue as string ?? TrangThaiTicket.Mo;
                _ticketDal.CapNhatDayDu(new Ticket
                {
                    MaTicket = id,
                    TieuDe = txtTieuDe.Text.Trim(),
                    NoiDung = txtNoiDung.Text.Trim(),
                    MaKhoaPhong = mk,
                    DoUuTien = (byte)numDoUuTien.Value,
                    MaNguoiPhuTrach = pt,
                    TrangThai = tt
                });
            }
            else
            {
                if (current.MaNguoiTao != u.MaNguoiDung)
                {
                    MessageBox.Show("Chỉ sửa được ticket do bạn tạo.", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboKhoaChiTiet.SelectedValue is not int mk2)
                {
                    return;
                }

                _ticketDal.CapNhatDayDu(new Ticket
                {
                    MaTicket = id,
                    TieuDe = txtTieuDe.Text.Trim(),
                    NoiDung = txtNoiDung.Text.Trim(),
                    MaKhoaPhong = mk2,
                    DoUuTien = (byte)numDoUuTien.Value,
                    MaNguoiPhuTrach = current.MaNguoiPhuTrach,
                    TrangThai = current.TrangThai
                });
            }

            BtnLoc_Click(null, EventArgs.Empty);
            MessageBox.Show("Đã cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnXoa_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtMa.Text, out var id) || id <= 0)
            {
                MessageBox.Show("Chọn ticket cần xóa.", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var current = _ticketDal.GetById(id);
            if (current is null)
            {
                return;
            }

            var u = AppSession.CurrentUser!;
            if (u.MaVaiTro == VaiTroCodes.NguoiDung)
            {
                if (current.MaNguoiTao != u.MaNguoiDung || current.TrangThai != TrangThaiTicket.Mo)
                {
                    MessageBox.Show("Chỉ xóa được ticket của bạn ở trạng thái Mở.", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (MessageBox.Show("Xóa ticket này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            _ticketDal.Xoa(id);
            LamTrangChiTiet();
            panelDetail.Visible = true;
            BtnLoc_Click(null, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnLamMoi_Click(object? sender, EventArgs e)
    {
        LamTrangChiTiet();
        panelDetail.Visible = true;
    }

    private void LamTrangChiTiet()
    {
        txtMa.Clear();
        txtTieuDe.Clear();
        txtNoiDung.Clear();
        numDoUuTien.Value = 2;
        if (cboKhoaChiTiet.Items.Count > 0)
        {
            cboKhoaChiTiet.SelectedIndex = 0;
        }

        cboTrangThaiChiTiet.SelectedValue = TrangThaiTicket.Mo;
        cboNguoiPhuTrach.SelectedValue = 0;
    }

    private void txtNoiDung_TextChanged(object sender, EventArgs e)
    {

    }

    private void lblThongKe_Click(object sender, EventArgs e)
    {

    }

    private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void tableDetail_Paint(object sender, PaintEventArgs e)
    {

    }

    private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void lblTrang_Click(object sender, EventArgs e)
    {

    }
}
