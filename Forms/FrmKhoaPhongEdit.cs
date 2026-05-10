using HelpTicket.DAL;
using HelpTicket.Models;

namespace HelpTicket.Forms;

public partial class FrmKhoaPhongEdit : Form
{
    private readonly KhoaPhongDAL _dal = new();
    private readonly KhoaPhong? _entity;

    public KhoaPhong? KetQua { get; private set; }

    private bool LaThem => _entity is null;

    public FrmKhoaPhongEdit(KhoaPhong? entity = null)
    {
        InitializeComponent();
        _entity = entity;

        if (LaThem)
        {
            Text = "Thêm khoa / phòng";
            lblTitle.Text = "Thêm khoa / phòng";
            lblSubtitle.Text = "Nhập tên đơn vị (bắt buộc) và ghi chú nếu cần.";
            txtMa.Text = "(tự sinh)";
        }
        else
        {
            Text = "Sửa khoa / phòng";
            lblTitle.Text = "Sửa khoa / phòng";
            lblSubtitle.Text = "Cập nhật tên hoặc ghi chú cho đơn vị.";
            txtMa.Text = _entity!.MaKhoaPhong.ToString();
            txtTen.Text = _entity.TenKhoaPhong;
            txtGhiChu.Text = _entity.GhiChu ?? string.Empty;
        }
    }

    private void BtnLuu_Click(object? sender, EventArgs e)
    {
        var ten = txtTen.Text.Trim();
        if (string.IsNullOrEmpty(ten))
        {
            MessageBox.Show("Vui lòng nhập tên khoa / phòng.", "Thiếu dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTen.Focus();
            return;
        }

        try
        {
            var bỏQua = LaThem ? (int?)null : _entity!.MaKhoaPhong;
            if (_dal.TonTaiTen(ten, bỏQua))
            {
                MessageBox.Show("Tên khoa / phòng đã tồn tại.", "Trùng dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                txtTen.SelectAll();
                return;
            }

            var ghiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

            if (LaThem)
            {
                var moi = new KhoaPhong { TenKhoaPhong = ten, GhiChu = ghiChu };
                moi.MaKhoaPhong = _dal.Them(moi);
                KetQua = moi;
            }
            else
            {
                var capNhat = new KhoaPhong
                {
                    MaKhoaPhong = _entity!.MaKhoaPhong,
                    TenKhoaPhong = ten,
                    GhiChu = ghiChu
                };
                _dal.CapNhat(capNhat);
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
}
