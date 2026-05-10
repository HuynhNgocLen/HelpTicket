using HelpTicket.DAL;
using HelpTicket.Models;

namespace HelpTicket.Forms;

public partial class FrmDanhBaEdit : Form
{
    private readonly NguoiDungDAL _dal = new();
    private readonly KhoaPhongDAL _khoaPhongDal = new();
    private readonly NguoiDung? _entity;

    public NguoiDung? KetQua { get; private set; }

    private bool LaThem => _entity is null;

    public FrmDanhBaEdit(NguoiDung? entity = null)
    {
        InitializeComponent();
        _entity = entity;

        NapKhoaPhong();
        NapVaiTro();

        if (LaThem)
        {
            Text = "Thêm tài khoản";
            lblTitle.Text = "Thêm tài khoản";
            lblSubtitle.Text = "Tạo mới tài khoản người dùng cho hệ thống.";
            txtMa.Text = "(tự sinh)";
            cboVaiTro.SelectedValue = (byte)VaiTroCodes.NguoiDung;
            chkHoatDong.Checked = true;
        }
        else
        {
            Text = "Sửa tài khoản";
            lblTitle.Text = "Sửa tài khoản";
            lblSubtitle.Text = "Cập nhật thông tin. Bỏ trống mật khẩu nếu không đổi.";
            txtMa.Text = _entity!.MaNguoiDung.ToString();
            txtTenDangNhap.Text = _entity.TenDangNhap;
            txtHoTen.Text = _entity.HoTen;
            txtEmail.Text = _entity.Email ?? string.Empty;
            cboKhoaPhong.SelectedValue = (object?)_entity.MaKhoaPhong ?? 0;
            cboVaiTro.SelectedValue = _entity.MaVaiTro;
            chkHoatDong.Checked = _entity.HoatDong;

            lblMatKhau.Text = "Mật khẩu mới";
            lblXacNhan.Text = "Xác nhận MK";
        }
    }

    private void NapKhoaPhong()
    {
        var ds = _khoaPhongDal.GetAll();
        ds.Insert(0, new KhoaPhong { MaKhoaPhong = 0, TenKhoaPhong = "(không chọn)" });
        cboKhoaPhong.DisplayMember = nameof(KhoaPhong.TenKhoaPhong);
        cboKhoaPhong.ValueMember = nameof(KhoaPhong.MaKhoaPhong);
        cboKhoaPhong.DataSource = ds;
        cboKhoaPhong.SelectedValue = 0;
    }

    private void NapVaiTro()
    {
        var ds = new List<VaiTro>
        {
            new() { MaVaiTro = VaiTroCodes.QuanTri, TenVaiTro = "Quản trị" },
            new() { MaVaiTro = VaiTroCodes.KyThuatVien, TenVaiTro = "Kỹ thuật viên" },
            new() { MaVaiTro = VaiTroCodes.NguoiDung, TenVaiTro = "Người dùng" }
        };
        cboVaiTro.DisplayMember = nameof(VaiTro.TenVaiTro);
        cboVaiTro.ValueMember = nameof(VaiTro.MaVaiTro);
        cboVaiTro.DataSource = ds;
    }

    private void BtnLuu_Click(object? sender, EventArgs e)
    {
        var tdn = txtTenDangNhap.Text.Trim();
        var ht = txtHoTen.Text.Trim();
        var em = txtEmail.Text.Trim();
        var mk = txtMatKhau.Text;
        var xn = txtXacNhan.Text;

        if (string.IsNullOrEmpty(tdn))
        {
            CanhBao("Vui lòng nhập tên đăng nhập.", txtTenDangNhap);
            return;
        }

        if (tdn.Length < 3)
        {
            CanhBao("Tên đăng nhập tối thiểu 3 ký tự.", txtTenDangNhap);
            return;
        }

        if (string.IsNullOrEmpty(ht))
        {
            CanhBao("Vui lòng nhập họ tên.", txtHoTen);
            return;
        }

        if (!string.IsNullOrEmpty(em) && !em.Contains('@'))
        {
            CanhBao("Email không hợp lệ.", txtEmail);
            return;
        }

        if (LaThem)
        {
            if (string.IsNullOrEmpty(mk))
            {
                CanhBao("Vui lòng nhập mật khẩu.", txtMatKhau);
                return;
            }

            if (mk.Length < 4)
            {
                CanhBao("Mật khẩu tối thiểu 4 ký tự.", txtMatKhau);
                return;
            }
        }
        else if (!string.IsNullOrEmpty(mk) && mk.Length < 4)
        {
            CanhBao("Mật khẩu mới tối thiểu 4 ký tự.", txtMatKhau);
            return;
        }

        if (!string.IsNullOrEmpty(mk) && mk != xn)
        {
            CanhBao("Mật khẩu xác nhận không khớp.", txtXacNhan);
            return;
        }

        if (cboVaiTro.SelectedValue is not byte vt)
        {
            CanhBao("Vui lòng chọn vai trò.", cboVaiTro);
            return;
        }

        int? maKhoaPhong = null;
        if (cboKhoaPhong.SelectedValue is int kp && kp > 0)
        {
            maKhoaPhong = kp;
        }

        try
        {
            var bỏQua = LaThem ? (int?)null : _entity!.MaNguoiDung;
            if (_dal.TonTaiTenDangNhap(tdn, bỏQua))
            {
                CanhBao("Tên đăng nhập đã tồn tại.", txtTenDangNhap);
                txtTenDangNhap.SelectAll();
                return;
            }

            if (LaThem)
            {
                var moi = new NguoiDung
                {
                    TenDangNhap = tdn,
                    MatKhau = mk,
                    HoTen = ht,
                    Email = string.IsNullOrEmpty(em) ? null : em,
                    MaKhoaPhong = maKhoaPhong,
                    MaVaiTro = vt,
                    HoatDong = chkHoatDong.Checked
                };
                moi.MaNguoiDung = _dal.Them(moi);
                KetQua = moi;
            }
            else
            {
                var capNhat = new NguoiDung
                {
                    MaNguoiDung = _entity!.MaNguoiDung,
                    TenDangNhap = tdn,
                    MatKhau = string.Empty,
                    HoTen = ht,
                    Email = string.IsNullOrEmpty(em) ? null : em,
                    MaKhoaPhong = maKhoaPhong,
                    MaVaiTro = vt,
                    HoatDong = chkHoatDong.Checked
                };
                _dal.CapNhat(capNhat, string.IsNullOrEmpty(mk) ? null : mk);
                KetQua = capNhat;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static void CanhBao(string message, Control? focus = null)
    {
        MessageBox.Show(message, "Kiểm tra dữ liệu",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        focus?.Focus();
    }
}
