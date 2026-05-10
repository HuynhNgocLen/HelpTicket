using Microsoft.Data.SqlClient;

namespace HelpTicket.DAL;

/// <summary>
/// Singleton quản lý một <see cref="SqlConnection"/> dùng chung cho ADO.NET.
/// </summary>
public sealed class Database
{
    private static readonly Lazy<Database> _instance = new(() => new Database());

    private SqlConnection? _connection;

    /// <summary>
    /// Chuỗi kết nối — chỉnh Server/Data Source cho máy của bạn.
    /// </summary>
    public static string ConnectionString { get; set; } =
        @"Server=DESKTOP-ANOQA7D\SQLEXPRESS;Database=HelpTicketDB;Integrated Security=True;TrustServerCertificate=True;";

    private Database() { }

    public static Database Instance => _instance.Value;

    /// <summary>Trả về kết nối mở (tạo lại nếu đã đóng).</summary>
    public SqlConnection GetConnection()
    {
        if (_connection is null)
        {
            _connection = new SqlConnection(ConnectionString);
        }

        if (_connection.State == System.Data.ConnectionState.Broken)
        {
            _connection.Close();
        }

        if (_connection.State == System.Data.ConnectionState.Closed)
        {
            _connection.Open();
        }

        return _connection;
    }

    /// <summary>Đóng và giải phóng kết nối (gọi khi thoát ứng dụng).</summary>
    public void CloseConnection()
    {
        if (_connection is null)
        {
            return;
        }

        if (_connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
        }

        _connection.Dispose();
        _connection = null;
    }
}
