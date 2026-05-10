using HelpTicket.Common;
using HelpTicket.Models;
using Microsoft.Data.SqlClient;

namespace HelpTicket.DAL;

public class TicketDAL
{
    /// <summary>
    /// Tìm kiếm ticket theo nhiều tiêu chí.
    /// </summary>
    /// <param name="maNguoiPhuTrach">
    /// null = không lọc theo người phụ trách;
    /// 0    = chỉ ticket chưa phân công (MaNguoiPhuTrach IS NULL);
    /// &gt;0 = ticket do đúng kỹ thuật viên này hỗ trợ.
    /// </param>
    public List<Ticket> TimKiem(string? tuKhoaTieuDe, int? maKhoaPhong, string? trangThai, int? maNguoiPhuTrach = null)
    {
        var user = AppSession.CurrentUser ?? throw new InvalidOperationException("Chưa đăng nhập.");
        var sql = @"
SELECT t.MaTicket, t.TieuDe, t.NoiDung, t.TrangThai, t.MaNguoiTao, t.MaNguoiPhuTrach, t.MaKhoaPhong,
       t.NgayTao, t.NgayCapNhat, t.DoUuTien,
       nt.HoTen AS TenNguoiTao, nv.HoTen AS TenNguoiPhuTrach, kp.TenKhoaPhong
FROM dbo.Ticket t
INNER JOIN dbo.NguoiDung nt ON nt.MaNguoiDung = t.MaNguoiTao
LEFT JOIN dbo.NguoiDung nv ON nv.MaNguoiDung = t.MaNguoiPhuTrach
INNER JOIN dbo.KhoaPhong kp ON kp.MaKhoaPhong = t.MaKhoaPhong
WHERE 1 = 1";

        if (user.MaVaiTro == VaiTroCodes.NguoiDung)
        {
            sql += " AND t.MaNguoiTao = @me";
        }

        if (!string.IsNullOrWhiteSpace(tuKhoaTieuDe))
        {
            sql += " AND t.TieuDe LIKE @td";
        }

        if (maKhoaPhong.HasValue && maKhoaPhong.Value > 0)
        {
            sql += " AND t.MaKhoaPhong = @kp";
        }

        if (!string.IsNullOrWhiteSpace(trangThai))
        {
            sql += " AND t.TrangThai = @tt";
        }

        if (maNguoiPhuTrach.HasValue)
        {
            sql += maNguoiPhuTrach.Value <= 0
                ? " AND t.MaNguoiPhuTrach IS NULL"
                : " AND t.MaNguoiPhuTrach = @pt";
        }

        sql += " ORDER BY t.NgayTao DESC";

        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        if (user.MaVaiTro == VaiTroCodes.NguoiDung)
        {
            cmd.Parameters.AddWithValue("@me", user.MaNguoiDung);
        }

        if (!string.IsNullOrWhiteSpace(tuKhoaTieuDe))
        {
            cmd.Parameters.AddWithValue("@td", "%" + tuKhoaTieuDe.Trim() + "%");
        }

        if (maKhoaPhong.HasValue && maKhoaPhong.Value > 0)
        {
            cmd.Parameters.AddWithValue("@kp", maKhoaPhong.Value);
        }

        if (!string.IsNullOrWhiteSpace(trangThai))
        {
            cmd.Parameters.AddWithValue("@tt", trangThai!);
        }

        if (maNguoiPhuTrach.HasValue && maNguoiPhuTrach.Value > 0)
        {
            cmd.Parameters.AddWithValue("@pt", maNguoiPhuTrach.Value);
        }

        var list = new List<Ticket>();
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(Map(rd));
        }

        return list;
    }

    /// <summary>Đếm ticket theo trạng thái; người dùng thường chỉ thấy ticket do họ tạo.</summary>
    public ThongKeDashBoard LayThongKeDashBoard()
    {
        var user = AppSession.CurrentUser ?? throw new InvalidOperationException("Chưa đăng nhập.");
        var sql = @"
SELECT
  COUNT(1),
  ISNULL(SUM(CASE WHEN t.TrangThai = N'Mo' THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.TrangThai = N'DangXuLy' THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.TrangThai = N'HoanThanh' THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.TrangThai = N'Huy' THEN 1 ELSE 0 END), 0)
FROM dbo.Ticket t
WHERE 1 = 1";

        if (user.MaVaiTro == VaiTroCodes.NguoiDung)
        {
            sql += " AND t.MaNguoiTao = @me";
        }

        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        if (user.MaVaiTro == VaiTroCodes.NguoiDung)
        {
            cmd.Parameters.AddWithValue("@me", user.MaNguoiDung);
        }

        using var rd = cmd.ExecuteReader();
        if (!rd.Read())
        {
            return new ThongKeDashBoard();
        }

        static int Col(SqlDataReader r, int i) => r.IsDBNull(i) ? 0 : Convert.ToInt32(r.GetValue(i), System.Globalization.CultureInfo.InvariantCulture);

        return new ThongKeDashBoard
        {
            Tong = Col(rd, 0),
            Mo = Col(rd, 1),
            DangXuLy = Col(rd, 2),
            HoanThanh = Col(rd, 3),
            Huy = Col(rd, 4)
        };
    }

    /// <summary>Thống kê mở rộng cho biểu đồ và chỉ số phụ (cùng phạm vi quyền như <see cref="LayThongKeDashBoard"/>).</summary>
    public DuLieuDashBoardDayDu LayDuLieuDashBoardDayDu()
    {
        var user = AppSession.CurrentUser ?? throw new InvalidOperationException("Chưa đăng nhập.");
        var filterNguoiTao = user.MaVaiTro == VaiTroCodes.NguoiDung ? " AND t.MaNguoiTao = @me" : "";

        var sqlMain = $@"
SELECT
  COUNT(1),
  ISNULL(SUM(CASE WHEN t.TrangThai = N'Mo' THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.TrangThai = N'DangXuLy' THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.TrangThai = N'HoanThanh' THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.TrangThai = N'Huy' THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.DoUuTien = 1 THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.DoUuTien = 2 THEN 1 ELSE 0 END), 0),
  ISNULL(SUM(CASE WHEN t.DoUuTien = 3 THEN 1 ELSE 0 END), 0)
FROM dbo.Ticket t
WHERE 1 = 1{filterNguoiTao}";

        var conn = Database.Instance.GetConnection();
        ThongKeDashBoard tk;
        int u1, u2, u3;

        using (var cmd = new SqlCommand(sqlMain, conn))
        {
            if (user.MaVaiTro == VaiTroCodes.NguoiDung)
            {
                cmd.Parameters.AddWithValue("@me", user.MaNguoiDung);
            }

            using var rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                return new DuLieuDashBoardDayDu();
            }

            static int Col(SqlDataReader r, int i) => r.IsDBNull(i) ? 0 : Convert.ToInt32(r.GetValue(i), System.Globalization.CultureInfo.InvariantCulture);

            tk = new ThongKeDashBoard
            {
                Tong = Col(rd, 0),
                Mo = Col(rd, 1),
                DangXuLy = Col(rd, 2),
                HoanThanh = Col(rd, 3),
                Huy = Col(rd, 4)
            };
            u1 = Col(rd, 5);
            u2 = Col(rd, 6);
            u3 = Col(rd, 7);
        }

        var startUtc = DateTime.UtcNow.Date.AddDays(-6);
        var sqlNgay = $@"
SELECT CAST(t.NgayTao AS DATE), COUNT(1)
FROM dbo.Ticket t
WHERE 1 = 1{filterNguoiTao}
  AND t.NgayTao >= @tu
GROUP BY CAST(t.NgayTao AS DATE)";

        var theoNgay = new Dictionary<DateTime, int>();
        using (var cmd2 = new SqlCommand(sqlNgay, conn))
        {
            cmd2.Parameters.AddWithValue("@tu", startUtc);
            if (user.MaVaiTro == VaiTroCodes.NguoiDung)
            {
                cmd2.Parameters.AddWithValue("@me", user.MaNguoiDung);
            }

            using var rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                var d = rd2.GetDateTime(0).Date;
                var c = rd2.IsDBNull(1) ? 0 : Convert.ToInt32(rd2.GetValue(1), System.Globalization.CultureInfo.InvariantCulture);
                theoNgay[d] = c;
            }
        }

        var days = new List<DateTime>(7);
        var counts = new List<int>(7);
        for (var i = 0; i < 7; i++)
        {
            var d = startUtc.AddDays(i);
            days.Add(d);
            counts.Add(theoNgay.TryGetValue(d, out var n) ? n : 0);
        }

        return new DuLieuDashBoardDayDu
        {
            TheoTrangThai = tk,
            UuTienCao = u1,
            UuTienTrungBinh = u2,
            UuTienThap = u3,
            SoLuongTaoTheoNgay = counts,
            CacNgay = days
        };
    }

    public Ticket? GetById(int maTicket)
    {
        using var cmd = new SqlCommand(@"
SELECT t.MaTicket, t.TieuDe, t.NoiDung, t.TrangThai, t.MaNguoiTao, t.MaNguoiPhuTrach, t.MaKhoaPhong,
       t.NgayTao, t.NgayCapNhat, t.DoUuTien,
       nt.HoTen AS TenNguoiTao, nv.HoTen AS TenNguoiPhuTrach, kp.TenKhoaPhong
FROM dbo.Ticket t
INNER JOIN dbo.NguoiDung nt ON nt.MaNguoiDung = t.MaNguoiTao
LEFT JOIN dbo.NguoiDung nv ON nv.MaNguoiDung = t.MaNguoiPhuTrach
INNER JOIN dbo.KhoaPhong kp ON kp.MaKhoaPhong = t.MaKhoaPhong
WHERE t.MaTicket = @id", Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@id", maTicket);
        using var rd = cmd.ExecuteReader();
        return rd.Read() ? Map(rd) : null;
    }

    public bool CoQuyenXem(Ticket t)
    {
        var user = AppSession.CurrentUser ?? throw new InvalidOperationException("Chưa đăng nhập.");
        if (user.MaVaiTro == VaiTroCodes.QuanTri || user.MaVaiTro == VaiTroCodes.KyThuatVien)
        {
            return true;
        }

        return t.MaNguoiTao == user.MaNguoiDung;
    }

    public int Them(Ticket entity)
    {
        var user = AppSession.CurrentUser ?? throw new InvalidOperationException("Chưa đăng nhập.");
        using var cmd = new SqlCommand(@"
INSERT INTO dbo.Ticket (TieuDe, NoiDung, TrangThai, MaNguoiTao, MaNguoiPhuTrach, MaKhoaPhong, NgayTao, DoUuTien)
VALUES (@td, @nd, @tt, @tao, @pt, @kp, SYSUTCDATETIME(), @uu);
SELECT CAST(SCOPE_IDENTITY() AS INT);", Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@td", entity.TieuDe);
        cmd.Parameters.AddWithValue("@nd", (object?)entity.NoiDung ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@tt", string.IsNullOrEmpty(entity.TrangThai) ? TrangThaiTicket.Mo : entity.TrangThai);
        cmd.Parameters.AddWithValue("@tao", user.MaNguoiDung);
        cmd.Parameters.AddWithValue("@pt", (object?)entity.MaNguoiPhuTrach ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@kp", entity.MaKhoaPhong);
        cmd.Parameters.AddWithValue("@uu", entity.DoUuTien);
        var scalar = cmd.ExecuteScalar();
        return Convert.ToInt32(scalar);
    }

    public int CapNhatPhanCongVaTrangThai(int maTicket, int? maNguoiPhuTrach, string trangThai)
    {
        using var cmd = new SqlCommand(@"
UPDATE dbo.Ticket
SET MaNguoiPhuTrach = @pt, TrangThai = @tt, NgayCapNhat = SYSUTCDATETIME()
WHERE MaTicket = @id", Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@pt", (object?)maNguoiPhuTrach ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@tt", trangThai);
        cmd.Parameters.AddWithValue("@id", maTicket);
        return cmd.ExecuteNonQuery();
    }

    public int CapNhatDayDu(Ticket entity)
    {
        using var cmd = new SqlCommand(@"
UPDATE dbo.Ticket
SET TieuDe = @td, NoiDung = @nd, TrangThai = @tt, MaNguoiPhuTrach = @pt, MaKhoaPhong = @kp,
    NgayCapNhat = SYSUTCDATETIME(), DoUuTien = @uu
WHERE MaTicket = @id", Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@td", entity.TieuDe);
        cmd.Parameters.AddWithValue("@nd", (object?)entity.NoiDung ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@tt", entity.TrangThai);
        cmd.Parameters.AddWithValue("@pt", (object?)entity.MaNguoiPhuTrach ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@kp", entity.MaKhoaPhong);
        cmd.Parameters.AddWithValue("@uu", entity.DoUuTien);
        cmd.Parameters.AddWithValue("@id", entity.MaTicket);
        return cmd.ExecuteNonQuery();
    }

    public int Xoa(int maTicket)
    {
        using var cmd = new SqlCommand("DELETE FROM dbo.Ticket WHERE MaTicket = @id", Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@id", maTicket);
        return cmd.ExecuteNonQuery();
    }

    private static Ticket Map(SqlDataReader rd)
    {
        return new Ticket
        {
            MaTicket = rd.GetInt32(0),
            TieuDe = rd.GetString(1),
            NoiDung = rd.IsDBNull(2) ? null : rd.GetString(2),
            TrangThai = rd.GetString(3),
            MaNguoiTao = rd.GetInt32(4),
            MaNguoiPhuTrach = rd.IsDBNull(5) ? null : rd.GetInt32(5),
            MaKhoaPhong = rd.GetInt32(6),
            NgayTao = rd.GetDateTime(7),
            NgayCapNhat = rd.IsDBNull(8) ? null : rd.GetDateTime(8),
            DoUuTien = rd.GetByte(9),
            TenNguoiTao = rd.IsDBNull(10) ? null : rd.GetString(10),
            TenNguoiPhuTrach = rd.IsDBNull(11) ? null : rd.GetString(11),
            TenKhoaPhong = rd.IsDBNull(12) ? null : rd.GetString(12)
        };
    }
}
