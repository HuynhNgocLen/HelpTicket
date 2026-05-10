using System.Globalization;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using HelpTicket.Common;
using HelpTicket.DAL;
using HelpTicket.Models;

namespace HelpTicket.Forms;

public partial class FrmDashboard : Form
{
    private readonly TicketDAL _dal = new();
    private readonly Panel _panelCharts = new();
    private readonly Chart _chartTrangThai = new();
    private readonly Chart _chartUuTien = new();
    private readonly Chart _chartXuHuong = new();
    private readonly Label _lblMeta = new();
    private readonly Button _btnSaoChep = new();
    private DuLieuDashBoardDayDu? _lanTaiCuoi;

    public FrmDashboard()
    {
        InitializeComponent();
        StyleValueLabel(lblValTong);
        StyleValueLabel(lblValMo);
        StyleValueLabel(lblValDangXuLy);
        StyleValueLabel(lblValHoanThanh);
        StyleValueLabel(lblValHuy);
        tableCards.Controls.Add(MakeCard("Tổng số", lblValTong, UiTheme.AccentTeal), 0, 0);
        tableCards.Controls.Add(MakeCard("Mở", lblValMo, UiTheme.AccentAmber), 1, 0);
        tableCards.Controls.Add(MakeCard("Đang xử lý", lblValDangXuLy, Color.FromArgb(37, 99, 235)), 2, 0);
        tableCards.Controls.Add(MakeCard("Hoàn thành", lblValHoanThanh, Color.FromArgb(5, 150, 105)), 3, 0);
        tableCards.Controls.Add(MakeCard("Huỷ", lblValHuy, Color.FromArgb(220, 38, 38)), 4, 0);

        _lblMeta.AutoSize = true;
        _lblMeta.Font = UiTheme.FontUi(9.25F);
        _lblMeta.ForeColor = UiTheme.TextMuted;

        _btnSaoChep.Text = "Sao chép tóm tắt";
        _btnSaoChep.AutoSize = true;
        _btnSaoChep.Padding = new Padding(14, 9, 14, 9);
        _btnSaoChep.FlatStyle = FlatStyle.Flat;
        _btnSaoChep.FlatAppearance.BorderColor = UiTheme.BorderHairline;
        _btnSaoChep.BackColor = UiTheme.Surface;
        _btnSaoChep.ForeColor = UiTheme.PrimaryInk;
        _btnSaoChep.Font = UiTheme.FontUi(9.75F, FontStyle.Bold);
        _btnSaoChep.Cursor = Cursors.Hand;
        _btnSaoChep.Click += (_, _) => SaoChepTomTat();

        KhoiTaoBangBieuDo();
        panelRoot.Controls.Add(_panelCharts);
        panelRoot.Controls.Add(_lblMeta);
        panelRoot.Controls.Add(_btnSaoChep);
        _panelCharts.SendToBack();
        _lblMeta.BringToFront();
        btnRefresh.BringToFront();
        _btnSaoChep.BringToFront();
        lblTitle.BringToFront();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LayoutRoot();
        TaiLai();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (IsHandleCreated)
        {
            LayoutRoot();
        }
    }

    private void LayoutRoot()
    {
        var padL = panelRoot.Padding.Left;
        var padT = panelRoot.Padding.Top;
        var padR = panelRoot.Padding.Right;
        var padB = panelRoot.Padding.Bottom;

        lblTitle.Location = new Point(padL, padT);
        _lblMeta.Location = new Point(padL, lblTitle.Bottom + 6);

        btnRefresh.Left = Math.Max(padL + 200, panelRoot.ClientSize.Width - btnRefresh.Width - padR);
        btnRefresh.Top = padT + 2;
        _btnSaoChep.PerformLayout();
        _btnSaoChep.Left = btnRefresh.Left - _btnSaoChep.Width - 10;
        _btnSaoChep.Top = btnRefresh.Top + (btnRefresh.Height - _btnSaoChep.Height) / 2;

        var gap = 14;
        var top = _lblMeta.Bottom + gap;
        var w = Math.Max(200, panelRoot.ClientSize.Width - padL - padR);
        const int cardStripHeight = 154;
        tableCards.SetBounds(padL, top, w, cardStripHeight);

        var chartTop = tableCards.Bottom + gap;
        var chartH = Math.Max(240, panelRoot.ClientSize.Height - padB - chartTop);
        _panelCharts.SetBounds(padL, chartTop, w, chartH);
    }

    private void BtnRefresh_Click(object? sender, EventArgs e) => TaiLai();

    private void TaiLai()
    {
        try
        {
            var d = _dal.LayDuLieuDashBoardDayDu();
            _lanTaiCuoi = d;
            var t = d.TheoTrangThai;
            lblValTong.Text = t.Tong.ToString();
            lblValMo.Text = t.Mo.ToString();
            lblValDangXuLy.Text = t.DangXuLy.ToString();
            lblValHoanThanh.Text = t.HoanThanh.ToString();
            lblValHuy.Text = t.Huy.ToString();

            var vi = CultureInfo.GetCultureInfo("vi-VN");
            var tyLe = t.Tong > 0 ? (100.0 * t.HoanThanh / t.Tong).ToString("0.#", vi) : "—";
            var luc = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy", vi);
            _lblMeta.Text = $"Tỷ lệ hoàn thành (trên tổng phiếu): {tyLe}%   ·   Dữ liệu lúc {luc}";

            CapNhatBieuDo(d);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tổng quan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaoChepTomTat()
    {
        if (_lanTaiCuoi is null)
        {
            return;
        }

        var vi = CultureInfo.GetCultureInfo("vi-VN");
        var t = _lanTaiCuoi.TheoTrangThai;
        var tyLe = t.Tong > 0 ? (100.0 * t.HoanThanh / t.Tong).ToString("0.#", vi) : "—";
        var sb = new StringBuilder();
        sb.AppendLine("TỔNG QUAN TICKET — HelpTicket");
        sb.AppendLine($"Tỷ lệ hoàn thành: {tyLe}%");
        sb.AppendLine($"Tổng: {t.Tong} | Mở: {t.Mo} | Đang xử lý: {t.DangXuLy} | Hoàn thành: {t.HoanThanh} | Huỷ: {t.Huy}");
        sb.AppendLine(
            $"Ưu tiên — Cao: {_lanTaiCuoi.UuTienCao}, Trung bình: {_lanTaiCuoi.UuTienTrungBinh}, Thấp: {_lanTaiCuoi.UuTienThap}");
        sb.AppendLine("Ticket mới 7 ngày (UTC):");
        for (var i = 0; i < _lanTaiCuoi.CacNgay.Count; i++)
        {
            var ngay = _lanTaiCuoi.CacNgay[i].ToString("dd/MM/yyyy", vi);
            var sl = _lanTaiCuoi.SoLuongTaoTheoNgay[i];
            sb.AppendLine($"  {ngay}: {sl}");
        }

        try
        {
            Clipboard.SetText(sb.ToString());
            MessageBox.Show("Đã sao chép tóm tắt vào clipboard.", "Tổng quan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tổng quan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void KhoiTaoBangBieuDo()
    {
        _panelCharts.BackColor = UiTheme.BgCanvas;
        var grid = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0),
            Margin = new Padding(0),
            ColumnCount = 2,
            RowCount = 2
        };
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        grid.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
        grid.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));

        GanKieuBieuDoTron(_chartTrangThai, "Theo trạng thái");
        GanKieuBieuDoCot(_chartUuTien, "Theo độ ưu tiên");
        GanKieuBieuDoDuong(_chartXuHuong, "Ticket tạo mới (7 ngày, UTC)");

        _chartTrangThai.Dock = DockStyle.Fill;
        _chartUuTien.Dock = DockStyle.Fill;
        _chartXuHuong.Dock = DockStyle.Fill;

        grid.Controls.Add(_chartTrangThai, 0, 0);
        grid.Controls.Add(_chartUuTien, 1, 0);
        grid.Controls.Add(_chartXuHuong, 0, 1);
        grid.SetColumnSpan(_chartXuHuong, 2);

        _panelCharts.Controls.Add(grid);
    }

    private static void GanKieuBieuDoTron(Chart chart, string tieuDe)
    {
        chart.ChartAreas.Clear();
        chart.Series.Clear();
        chart.Legends.Clear();
        chart.Titles.Clear();
        chart.BackColor = UiTheme.Surface;
        chart.AntiAliasing = AntiAliasingStyles.All;

        var vung = new ChartArea("main")
        {
            BackColor = UiTheme.Surface
        };
        chart.ChartAreas.Add(vung);

        var chuGiai = new Legend("lg")
        {
            Docking = Docking.Bottom,
            Alignment = StringAlignment.Center,
            BackColor = Color.Transparent,
            Font = UiTheme.FontUi(8.5F)
        };
        chart.Legends.Add(chuGiai);

        var day = new Series("TrangThai")
        {
            ChartType = SeriesChartType.Doughnut,
            Legend = "lg",
            IsValueShownAsLabel = true,
            Font = UiTheme.FontUi(8.5F)
        };
        chart.Series.Add(day);

        chart.Titles.Add(new Title(tieuDe)
        {
            Font = UiTheme.FontUi(10F, FontStyle.Bold),
            ForeColor = UiTheme.PrimaryInk
        });
    }

    private static void GanKieuBieuDoCot(Chart chart, string tieuDe)
    {
        chart.ChartAreas.Clear();
        chart.Series.Clear();
        chart.Legends.Clear();
        chart.Titles.Clear();
        chart.BackColor = UiTheme.Surface;
        chart.AntiAliasing = AntiAliasingStyles.All;
        chart.Palette = ChartColorPalette.None;

        var vung = new ChartArea("main") { BackColor = UiTheme.Surface };
        vung.AxisX.MajorGrid.Enabled = false;
        vung.AxisX.LabelStyle.Font = UiTheme.FontUi(8.5F);
        vung.AxisX.Interval = 1;
        vung.AxisX.IsLabelAutoFit = false;
        vung.AxisY.MajorGrid.LineColor = UiTheme.BorderHairline;
        vung.AxisY.LabelStyle.Font = UiTheme.FontUi(8.5F);
        vung.AxisY.Minimum = 0;
        chart.ChartAreas.Add(vung);

        var day = new Series("UuTien")
        {
            ChartType = SeriesChartType.Column,
            IsValueShownAsLabel = true,
            Font = UiTheme.FontUi(8.5F),
            LabelFormat = "#0",
            IsXValueIndexed = true
        };
        day["PointWidth"] = "0.55";
        chart.Series.Add(day);

        chart.Titles.Add(new Title(tieuDe)
        {
            Font = UiTheme.FontUi(10F, FontStyle.Bold),
            ForeColor = UiTheme.PrimaryInk
        });
    }

    private static void GanKieuBieuDoDuong(Chart chart, string tieuDe)
    {
        chart.ChartAreas.Clear();
        chart.Series.Clear();
        chart.Legends.Clear();
        chart.Titles.Clear();
        chart.BackColor = UiTheme.Surface;
        chart.AntiAliasing = AntiAliasingStyles.All;

        var vung = new ChartArea("main") { BackColor = UiTheme.Surface };
        vung.AxisX.MajorGrid.Enabled = false;
        vung.AxisX.LabelStyle.Font = UiTheme.FontUi(8.5F);
        vung.AxisX.Interval = 1;
        vung.AxisX.IsLabelAutoFit = false;
        vung.AxisY.MajorGrid.LineColor = UiTheme.BorderHairline;
        vung.AxisY.LabelStyle.Font = UiTheme.FontUi(8.5F);
        vung.AxisY.Minimum = 0;
        chart.ChartAreas.Add(vung);

        var day = new Series("SoLuong")
        {
            ChartType = SeriesChartType.Line,
            BorderWidth = 2,
            MarkerStyle = MarkerStyle.Circle,
            MarkerSize = 7,
            Color = Color.FromArgb(37, 99, 235),
            MarkerColor = Color.FromArgb(37, 99, 235),
            IsValueShownAsLabel = true,
            Font = UiTheme.FontUi(8.5F),
            LabelFormat = "#0",
            IsXValueIndexed = true
        };
        chart.Series.Add(day);

        chart.Titles.Add(new Title(tieuDe)
        {
            Font = UiTheme.FontUi(10F, FontStyle.Bold),
            ForeColor = UiTheme.PrimaryInk
        });
    }

    private void CapNhatBieuDo(DuLieuDashBoardDayDu d)
    {
        var t = d.TheoTrangThai;
        var sTron = _chartTrangThai.Series["TrangThai"];
        sTron.Points.Clear();
        if (t.Tong == 0)
        {
            var ix = sTron.Points.AddXY("—", 1);
            var p = sTron.Points[ix];
            p.LegendText = "Chưa có ticket";
            p.Color = Color.FromArgb(200, 200, 200);
            p.Label = "";
        }
        else
        {
            ThemLop(sTron, "Mở", t.Mo, UiTheme.AccentAmber);
            ThemLop(sTron, "Đang xử lý", t.DangXuLy, Color.FromArgb(37, 99, 235));
            ThemLop(sTron, "Hoàn thành", t.HoanThanh, Color.FromArgb(5, 150, 105));
            ThemLop(sTron, "Huỷ", t.Huy, Color.FromArgb(220, 38, 38));
        }

        var sCot = _chartUuTien.Series["UuTien"];
        sCot.Points.Clear();

        var ten = new[] { "Cao", "Trung bình", "Thấp" };
        var giaTri = new[] { d.UuTienCao, d.UuTienTrungBinh, d.UuTienThap };
        var mau = new[]
        {
            Color.FromArgb(220, 38, 38),
            UiTheme.AccentAmber,
            Color.FromArgb(5, 150, 105)
        };

        for (var i = 0; i < ten.Length; i++)
        {
            var ix = sCot.Points.AddXY(i + 1, giaTri[i]);
            var p = sCot.Points[ix];
            p.AxisLabel = ten[i];
            p.Color = mau[i];
            p.Label = giaTri[i].ToString(CultureInfo.InvariantCulture);
        }

        var sLine = _chartXuHuong.Series["SoLuong"];
        sLine.Points.Clear();
        var vi = CultureInfo.GetCultureInfo("vi-VN");
        for (var i = 0; i < d.CacNgay.Count; i++)
        {
            var ix = sLine.Points.AddXY(i + 1, d.SoLuongTaoTheoNgay[i]);
            sLine.Points[ix].AxisLabel = d.CacNgay[i].ToString("dd/MM", vi);
        }

        _chartTrangThai.Invalidate();
        _chartUuTien.Invalidate();
        _chartXuHuong.Invalidate();
    }

    private static void ThemLop(Series s, string ten, int giaTri, Color mau)
    {
        if (giaTri <= 0)
        {
            return;
        }

        var ix = s.Points.AddXY(ten, giaTri);
        var p = s.Points[ix];
        p.LegendText = ten;
        p.Color = mau;
        p.Label = giaTri.ToString(CultureInfo.InvariantCulture);
    }
}
