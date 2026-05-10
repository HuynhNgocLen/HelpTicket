using HelpTicket.Models;
using Microsoft.Data.SqlClient;

namespace HelpTicket.DAL;

public class NguoiDungDAL
{
    /// <summary>Đăng nhập theo tài khoản + mật khẩu (HoatDong = 1).</summary>
    public NguoiDung? DangNhap(string tenDangNhap, string matKhau)
    {
        using var cmd = new SqlCommand(@"
SELECT n.MaNguoiDung, n.TenDangNhap, n.MatKhau, n.HoTen, n.Email, n.MaKhoaPhong, n.MaVaiTro, n.HoatDong,
       k.TenKhoaPhong
FROM dbo.NguoiDung n
LEFT JOIN dbo.KhoaPhong k ON k.MaKhoaPhong = n.MaKhoaPhong
WHERE n.TenDangNhap = @u AND n.MatKhau = @p AND n.HoatDong = 1", Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@u", tenDangNhap);
        cmd.Parameters.AddWithValue("@p", matKhau);
        using var rd = cmd.ExecuteReader();
        if (!rd.Read())
        {
            return null;
        }

        return Map(rd);
    }

    public NguoiDung? GetById(int maNguoiDung)
    {
        using var cmd = new SqlCommand(@"
SELECT n.MaNguoiDung, n.TenDangNhap, n.MatKhau, n.HoTen, n.Email, n.MaKhoaPhong, n.MaVaiTro, n.HoatDong,
       k.TenKhoaPhong
FROM dbo.NguoiDung n
LEFT JOIN dbo.KhoaPhong k ON k.MaKhoaPhong = n.MaKhoaPhong
WHERE n.MaNguoiDung = @id", Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@id", maNguoiDung);
        using var rd = cmd.ExecuteReader();
        return rd.Read() ? Map(rd) : null;
    }

    /// <summary>Danh sách kỹ thuật viên + quản trị (để gán Người phụ trách).</summary>
    public List<NguoiDung> GetNguoiCoThePhuTrach()
    {
        var list = new List<NguoiDung>();
        using var cmd = new SqlCommand(@"
SELECT n.MaNguoiDung, n.TenDangNhap, n.MatKhau, n.HoTen, n.Email, n.MaKhoaPhong, n.MaVaiTro, n.HoatDong,
       k.TenKhoaPhong
FROM dbo.NguoiDung n
LEFT JOIN dbo.KhoaPhong k ON k.MaKhoaPhong = n.MaKhoaPhong
WHERE n.HoatDong = 1 AND n.MaVaiTro IN (1, 2)
ORDER BY n.HoTen", Database.Instance.GetConnection());
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(Map(rd));
        }

        return list;
    }

    /// <summary>Danh bạ liên hệ (không trả về mật khẩu từ SQL).</summary>
    public List<NguoiDung> GetDanhBaHoatDong()
    {
        var list = new List<NguoiDung>();
        using var cmd = new SqlCommand(@"
SELECT n.MaNguoiDung, n.TenDangNhap, n.HoTen, n.Email, n.MaKhoaPhong, n.MaVaiTro, n.HoatDong,
       k.TenKhoaPhong
FROM dbo.NguoiDung n
LEFT JOIN dbo.KhoaPhong k ON k.MaKhoaPhong = n.MaKhoaPhong
WHERE n.HoatDong = 1
ORDER BY n.MaVaiTro, n.HoTen", Database.Instance.GetConnection());
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(new NguoiDung
            {
                MaNguoiDung = rd.GetInt32(0),
                TenDangNhap = rd.GetString(1),
                MatKhau = string.Empty,
                HoTen = rd.GetString(2),
                Email = rd.IsDBNull(3) ? null : rd.GetString(3),
                MaKhoaPhong = rd.IsDBNull(4) ? null : rd.GetInt32(4),
                MaVaiTro = rd.GetByte(5),
                HoatDong = rd.GetBoolean(6),
                TenKhoaPhong = rd.IsDBNull(7) ? null : rd.GetString(7)
            });
        }

        return list;
    }

    /// <summary>Toàn bộ danh bạ (kể cả tài khoản đã tắt) – cho Quản trị quản lý.</summary>
    public List<NguoiDung> GetTatCa(string? tuKhoa = null, bool? hoatDong = null, byte? maVaiTro = null)
    {
        var list = new List<NguoiDung>();
        var sql = @"
SELECT n.MaNguoiDung, n.TenDangNhap, n.HoTen, n.Email, n.MaKhoaPhong, n.MaVaiTro, n.HoatDong,
       k.TenKhoaPhong
FROM dbo.NguoiDung n
LEFT JOIN dbo.KhoaPhong k ON k.MaKhoaPhong = n.MaKhoaPhong
WHERE (@kw IS NULL
       OR n.TenDangNhap LIKE @kwLike
       OR n.HoTen LIKE @kwLike
       OR ISNULL(n.Email, N'') LIKE @kwLike
       OR ISNULL(k.TenKhoaPhong, N'') LIKE @kwLike)
  AND (@hd IS NULL OR n.HoatDong = @hd)
  AND (@vt IS NULL OR n.MaVaiTro = @vt)
ORDER BY n.MaVaiTro, n.HoTen";

        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        if (string.IsNullOrWhiteSpace(tuKhoa))
        {
            cmd.Parameters.AddWithValue("@kw", DBNull.Value);
            cmd.Parameters.AddWithValue("@kwLike", DBNull.Value);
        }
        else
        {
            var kw = tuKhoa.Trim();
            cmd.Parameters.AddWithValue("@kw", kw);
            cmd.Parameters.AddWithValue("@kwLike", "%" + kw + "%");
        }

        cmd.Parameters.AddWithValue("@hd", (object?)hoatDong ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@vt", (object?)maVaiTro ?? DBNull.Value);

        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(new NguoiDung
            {
                MaNguoiDung = rd.GetInt32(0),
                TenDangNhap = rd.GetString(1),
                MatKhau = string.Empty,
                HoTen = rd.GetString(2),
                Email = rd.IsDBNull(3) ? null : rd.GetString(3),
                MaKhoaPhong = rd.IsDBNull(4) ? null : rd.GetInt32(4),
                MaVaiTro = rd.GetByte(5),
                HoatDong = rd.GetBoolean(6),
                TenKhoaPhong = rd.IsDBNull(7) ? null : rd.GetString(7)
            });
        }

        return list;
    }

    /// <summary>Kiểm tra trùng tên đăng nhập (case-insensitive), bỏ qua chính nó khi sửa.</summary>
    public bool TonTaiTenDangNhap(string tenDangNhap, int? bỏQua = null)
    {
        const string sql = @"
SELECT COUNT(1) FROM dbo.NguoiDung
WHERE LOWER(TenDangNhap) = LOWER(@u)
  AND (@id IS NULL OR MaNguoiDung <> @id)";
        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@u", tenDangNhap);
        cmd.Parameters.AddWithValue("@id", (object?)bỏQua ?? DBNull.Value);
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    /// <summary>Người dùng đang được tham chiếu bởi ticket (người tạo / người phụ trách)?</summary>
    public bool DangDuocSuDung(int maNguoiDung)
    {
        const string sql = @"
SELECT
    (SELECT COUNT(1) FROM dbo.Ticket WHERE MaNguoiTao        = @id)
  + (SELECT COUNT(1) FROM dbo.Ticket WHERE MaNguoiPhuTrach   = @id)";
        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@id", maNguoiDung);
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public int Them(NguoiDung nd)
    {
        const string sql = @"
INSERT INTO dbo.NguoiDung (TenDangNhap, MatKhau, HoTen, Email, MaKhoaPhong, MaVaiTro, HoatDong)
OUTPUT INSERTED.MaNguoiDung
VALUES (@u, @p, @ht, @em, @kp, @vt, @hd)";
        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@u", nd.TenDangNhap);
        cmd.Parameters.AddWithValue("@p", nd.MatKhau);
        cmd.Parameters.AddWithValue("@ht", nd.HoTen);
        cmd.Parameters.AddWithValue("@em", (object?)nd.Email ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@kp", (object?)nd.MaKhoaPhong ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@vt", nd.MaVaiTro);
        cmd.Parameters.AddWithValue("@hd", nd.HoatDong);
        return (int)cmd.ExecuteScalar();
    }

    /// <summary>Cập nhật thông tin chính. Chỉ đổi mật khẩu khi <paramref name="matKhauMoi"/> không null/empty.</summary>
    public void CapNhat(NguoiDung nd, string? matKhauMoi = null)
    {
        var sql = @"
UPDATE dbo.NguoiDung
SET TenDangNhap = @u,
    HoTen       = @ht,
    Email       = @em,
    MaKhoaPhong = @kp,
    MaVaiTro    = @vt,
    HoatDong    = @hd";

        if (!string.IsNullOrEmpty(matKhauMoi))
        {
            sql += ", MatKhau = @p";
        }

        sql += " WHERE MaNguoiDung = @id";

        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@u", nd.TenDangNhap);
        cmd.Parameters.AddWithValue("@ht", nd.HoTen);
        cmd.Parameters.AddWithValue("@em", (object?)nd.Email ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@kp", (object?)nd.MaKhoaPhong ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@vt", nd.MaVaiTro);
        cmd.Parameters.AddWithValue("@hd", nd.HoatDong);
        cmd.Parameters.AddWithValue("@id", nd.MaNguoiDung);
        if (!string.IsNullOrEmpty(matKhauMoi))
        {
            cmd.Parameters.AddWithValue("@p", matKhauMoi);
        }

        cmd.ExecuteNonQuery();
    }

    /// <summary>Bật / tắt hoạt động (khoá mềm).</summary>
    public void DatHoatDong(int maNguoiDung, bool hoatDong)
    {
        using var cmd = new SqlCommand(
            "UPDATE dbo.NguoiDung SET HoatDong = @hd WHERE MaNguoiDung = @id",
            Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@hd", hoatDong);
        cmd.Parameters.AddWithValue("@id", maNguoiDung);
        cmd.ExecuteNonQuery();
    }

    public void Xoa(int maNguoiDung)
    {
        using var cmd = new SqlCommand(
            "DELETE FROM dbo.NguoiDung WHERE MaNguoiDung = @id",
            Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@id", maNguoiDung);
        cmd.ExecuteNonQuery();
    }

    private static NguoiDung Map(SqlDataReader rd)
    {
        return new NguoiDung
        {
            MaNguoiDung = rd.GetInt32(0),
            TenDangNhap = rd.GetString(1),
            MatKhau = rd.GetString(2),
            HoTen = rd.GetString(3),
            Email = rd.IsDBNull(4) ? null : rd.GetString(4),
            MaKhoaPhong = rd.IsDBNull(5) ? null : rd.GetInt32(5),
            MaVaiTro = rd.GetByte(6),
            HoatDong = rd.GetBoolean(7),
            TenKhoaPhong = rd.IsDBNull(8) ? null : rd.GetString(8)
        };
    }
}
