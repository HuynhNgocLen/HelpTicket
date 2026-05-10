using HelpTicket.Models;
using Microsoft.Data.SqlClient;

namespace HelpTicket.DAL;

public class KhoaPhongDAL
{
    public List<KhoaPhong> GetAll()
    {
        var list = new List<KhoaPhong>();
        using var cmd = new SqlCommand(
            "SELECT MaKhoaPhong, TenKhoaPhong, GhiChu FROM dbo.KhoaPhong ORDER BY MaKhoaPhong",
            Database.Instance.GetConnection());
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(new KhoaPhong
            {
                MaKhoaPhong = rd.GetInt32(0),
                TenKhoaPhong = rd.GetString(1),
                GhiChu = rd.IsDBNull(2) ? null : rd.GetString(2)
            });
        }

        return list;
    }

    /// <summary>Tìm theo từ khóa trong tên hoặc ghi chú.</summary>
    public List<KhoaPhong> TimKiem(string? tuKhoa)
    {
        var list = new List<KhoaPhong>();
        var sql = @"
SELECT MaKhoaPhong, TenKhoaPhong, GhiChu
FROM dbo.KhoaPhong
WHERE (@kw IS NULL OR TenKhoaPhong LIKE @kwLike OR ISNULL(GhiChu, N'') LIKE @kwLike)
ORDER BY MaKhoaPhong";

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

        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(new KhoaPhong
            {
                MaKhoaPhong = rd.GetInt32(0),
                TenKhoaPhong = rd.GetString(1),
                GhiChu = rd.IsDBNull(2) ? null : rd.GetString(2)
            });
        }

        return list;
    }

    public KhoaPhong? GetById(int maKhoaPhong)
    {
        using var cmd = new SqlCommand(
            "SELECT MaKhoaPhong, TenKhoaPhong, GhiChu FROM dbo.KhoaPhong WHERE MaKhoaPhong = @id",
            Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@id", maKhoaPhong);
        using var rd = cmd.ExecuteReader();
        if (!rd.Read())
        {
            return null;
        }

        return new KhoaPhong
        {
            MaKhoaPhong = rd.GetInt32(0),
            TenKhoaPhong = rd.GetString(1),
            GhiChu = rd.IsDBNull(2) ? null : rd.GetString(2)
        };
    }

    /// <summary>Kiểm tra trùng tên (không phân biệt hoa thường), bỏ qua chính nó khi sửa.</summary>
    public bool TonTaiTen(string tenKhoaPhong, int? bỏQua = null)
    {
        var sql = @"
SELECT COUNT(1) FROM dbo.KhoaPhong
WHERE LOWER(TenKhoaPhong) = LOWER(@ten)
  AND (@id IS NULL OR MaKhoaPhong <> @id)";
        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@ten", tenKhoaPhong);
        cmd.Parameters.AddWithValue("@id", (object?)bỏQua ?? DBNull.Value);
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    /// <summary>Khoa/phòng đang được tham chiếu bởi NguoiDung hoặc Ticket?</summary>
    public bool DangDuocSuDung(int maKhoaPhong)
    {
        const string sql = @"
SELECT
    (SELECT COUNT(1) FROM dbo.NguoiDung WHERE MaKhoaPhong = @id)
  + (SELECT COUNT(1) FROM dbo.Ticket    WHERE MaKhoaPhong = @id)";
        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@id", maKhoaPhong);
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public int Them(KhoaPhong kp)
    {
        const string sql = @"
INSERT INTO dbo.KhoaPhong (TenKhoaPhong, GhiChu)
OUTPUT INSERTED.MaKhoaPhong
VALUES (@ten, @gc)";
        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@ten", kp.TenKhoaPhong);
        cmd.Parameters.AddWithValue("@gc", (object?)kp.GhiChu ?? DBNull.Value);
        return (int)cmd.ExecuteScalar();
    }

    public void CapNhat(KhoaPhong kp)
    {
        const string sql = @"
UPDATE dbo.KhoaPhong
SET TenKhoaPhong = @ten,
    GhiChu       = @gc
WHERE MaKhoaPhong = @id";
        using var cmd = new SqlCommand(sql, Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@ten", kp.TenKhoaPhong);
        cmd.Parameters.AddWithValue("@gc", (object?)kp.GhiChu ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@id", kp.MaKhoaPhong);
        cmd.ExecuteNonQuery();
    }

    public void Xoa(int maKhoaPhong)
    {
        using var cmd = new SqlCommand(
            "DELETE FROM dbo.KhoaPhong WHERE MaKhoaPhong = @id",
            Database.Instance.GetConnection());
        cmd.Parameters.AddWithValue("@id", maKhoaPhong);
        cmd.ExecuteNonQuery();
    }
}
