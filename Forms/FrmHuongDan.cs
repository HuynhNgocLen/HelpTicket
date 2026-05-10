namespace HelpTicket.Forms;

public partial class FrmHuongDan : Form
{
    public FrmHuongDan()
    {
        InitializeComponent();
        rtb.Text = NoiDungHuongDan;
    }

    private static string NoiDungHuongDan =>
        """
        HƯỚNG DẪN SỬ DỤNG HELPTICKET


        0. Cài đặt trước khi chạy
        • Cần .NET 8 (Windows) và SQL Server (LocalDB / Express / bản đầy đủ đều được).
        • Mở SQL Server Management Studio (hoặc sqlcmd), chạy toàn bộ file Scripts\HelpTicket.sql để tạo CSDL HelpTicketDB và dữ liệu mẫu.
        • Mở mã nguồn, trong DAL\Database.cs chỉnh thuộc tính ConnectionString: đổi Server=... cho khớp instance SQL trên máy bạn; giữ Database=HelpTicketDB và Integrated Security nếu đăng nhập Windows.
        • Build và chạy project HelpTicket; nếu không kết nối được SQL, ứng dụng sẽ báo lỗi trong hộp thoại.


        Tài khoản demo (sau khi chạy script)
        • admin / admin123 — Quản trị
        • kythuat01 hoặc kythuat02 / kt@123 — Kỹ thuật viên
        • gvnguyen, svtran, nhanvienhc / user@123 — Người dùng
        (Đây là mật khẩu dạng plain text phục vụ học tập; môi trường thật nên băm mật khẩu và đổi ngay.)


        1. Đăng nhập và phiên làm việc
        • Chỉ tài khoản có cờ hoạt động (HoatDong = 1) mới đăng nhập được.
        • Có thể bật «Hiện mật khẩu» để kiểm tra khi gõ.
        • Trên màn hình chính: tên và vai trò ở thanh trên; sidebar có dòng gợi ý theo quyền của bạn.
        • Nên «Đăng xuất» khi dùng máy chung.


        2. Điều hướng (sidebar)
        • Tổng quan — thẻ số liệu và biểu đồ ticket theo trạng thái (Mở, Đang xử lý, Hoàn thành, Hủy), trong phạm vi quyền của bạn.
        • Quản lý ticket — tạo, lọc, sửa, xóa, xuất CSV.
        • Khoa / phòng — chỉ Quản trị và Kỹ thuật viên thấy mục này: tra cứu danh mục; chỉ Quản trị được thêm / sửa / xóa đơn vị.
        • Danh bạ — danh sách tài khoản (không hiển thị mật khẩu). Quản trị: thêm, sửa, xóa, bật/tắt hoạt động và lọc theo vai trò/trạng thái đầy đủ. Kỹ thuật viên và Người dùng: chỉ xem, mặc định chỉ thấy tài khoản đang hoạt động.
        • Hướng dẫn — trang này.
        • Giới thiệu — mô tả ngắn và phiên bản ứng dụng.


        3. Quản lý ticket
        • Lọc theo tiêu đề (gần đúng), khoa/phòng, trạng thái; bấm «Lọc» hoặc Enter trong ô tiêu đề.
        • Chọn một dòng trong lưới để xem/chỉnh chi tiết bên dưới.
        • Thêm: tiêu đề, nội dung, khoa/phòng, mức ưu tiên; trạng thái mặc định là Mở. Quản trị và Kỹ thuật viên có thể gán người phụ trách và đổi trạng thái ngay khi tạo.
        • Sửa: Quản trị / Kỹ thuật viên cập nhật đầy đủ (phân công, trạng thái, …). Người dùng chỉ sửa ticket do mình tạo; không đổi người phụ trách và trạng thái.
        • Xóa: Người dùng chỉ xóa ticket của mình khi trạng thái còn Mở. Quản trị và Kỹ thuật viên xóa trong phạm vi quản lý (có xác nhận).
        • Xuất CSV — xuất các cột đang hiển thị trên lưới (theo bộ lọc hiện tại) ra file mở được bằng Excel.


        4. Phím tắt (màn Quản lý ticket)
        • Enter trong ô lọc tiêu đề — chạy lọc.
        • Ctrl+F — focus ô lọc tiêu đề và chọn hết nội dung.


        5. Tóm tắt ba vai trò (ticket & dashboard)
        • Quản trị — xem mọi ticket; phân công, đổi trạng thái, sửa/xóa; thống kê trên toàn bộ ticket.
        • Kỹ thuật viên — như Quản trị về phạm vi ticket (xem tất cả, phân công, cập nhật trạng thái).
        • Người dùng — chỉ thấy ticket do mình tạo; tạo và sửa nội dung/khoa/ưu tiên; chỉ xóa khi còn Mở.

        Nếu ô phân công, combo trạng thái bị vô hiệu hoặc thiếu nút trên Danh bạ / Khoa phòng — đó là do vai trò không được phép.


        6. Lưu ý
        • Luôn đảm bảo SQL Server chạy và chuỗi kết nối trong Database.cs đúng với máy bạn.
        • Dữ liệu mẫu và mật khẩu demo chỉ dùng cho mục đích học tập; triển khai thật cần harden bảo mật CSDL và ứng dụng.
        """;

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        LayoutHuongDan();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LayoutHuongDan();
    }

    private void LayoutHuongDan()
    {
        if (!IsHandleCreated)
        {
            return;
        }

        var p = panelRoot.Padding;
        lblTitle.Location = new Point(p.Left, p.Top);
        var y = lblTitle.Bottom + 12;
        rtb.Location = new Point(p.Left, y);
        rtb.Size = new Size(
            Math.Max(100, panelRoot.ClientSize.Width - p.Horizontal),
            Math.Max(100, panelRoot.ClientSize.Height - y - p.Bottom));
    }
}
