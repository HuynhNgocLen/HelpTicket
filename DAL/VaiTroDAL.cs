using HelpTicket.Models;
using Microsoft.Data.SqlClient;

namespace HelpTicket.DAL;

public class VaiTroDAL
{
    public List<VaiTro> GetAll()
    {
        var list = new List<VaiTro>();
        using var cmd = new SqlCommand(
            "SELECT MaVaiTro, TenVaiTro, MoTa FROM dbo.VaiTro ORDER BY MaVaiTro",
            Database.Instance.GetConnection());
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(new VaiTro
            {
                MaVaiTro = rd.GetByte(0),
                TenVaiTro = rd.GetString(1),
                MoTa = rd.IsDBNull(2) ? null : rd.GetString(2)
            });
        }

        return list;
    }
}
