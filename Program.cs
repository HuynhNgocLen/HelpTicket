using HelpTicket.DAL;
using HelpTicket.Forms;

namespace HelpTicket;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.ApplicationExit += (_, _) => Database.Instance.CloseConnection();

        try
        {
            Database.Instance.GetConnection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không kết nối được SQL Server.\r\nKiểm tra đã chạy Scripts\\HelpTicket.sql và Server trong DAL\\Database.cs.\r\n\r\n" + ex.Message,
                "HelpTicket — Lỗi kết nối",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        Application.Run(new FrmLogin());
    }
}
