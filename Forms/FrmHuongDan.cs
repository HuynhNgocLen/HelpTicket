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


        1. Đăng nhập và phiên làm việc
        • Nhập tài khoản và mật khẩu do quản trị cấp; chỉ tài khoản đang hoạt động (Hoạt động = 1) mới đăng nhập được.
        • Có thể bật «Hiện mật khẩu» để kiểm tra khi gõ.
        • Sau khi vào màn hình chính, tên và vai trò hiển thị trên thanh trên; dòng gợi ý bên sidebar nhắc phạm vi quyền của bạn.
        • Đăng xuất khi dùng máy chung để tránh người khác thao tác thay.


        2. Điều hướng (sidebar)
        • Tổng quan — biểu đồ và số liệu ticket theo trạng thái; dữ liệu chỉ trong phạm vi quyền của bạn (xem mục 5).
        • Quản lý ticket — tạo, lọc, sửa, xóa ticket.
        • Khoa / phòng — tra cứu danh mục đơn vị.
        • Danh bạ — danh sách tài khoản đang hoạt động (không hiển thị mật khẩu).
        • Hướng dẫn — trang này.
        • Giới thiệu — thông tin phiên bản.


        3. Quản lý ticket
        • Lọc theo tiêu đề (gần đúng), khoa/phòng, trạng thái; bấm «Lọc» hoặc nhấn Enter trong ô tiêu đề để áp dụng.
        • Chọn một dòng trong lưới để xem/chỉnh chi tiết bên dưới.
        • Thêm: nhập tiêu đề, nội dung, chọn khoa/phòng và mức ưu tiên; trạng thái mặc định là Mở. Quản trị và kỹ thuật viên có thể gán người phụ trách và đổi trạng thái ngay khi tạo.
        • Sửa: quản trị / kỹ thuật viên cập nhật đầy đủ (kể cả phân công và trạng thái). Người dùng thường chỉ sửa được ticket do chính mình tạo, và không đổi người phụ trách hay trạng thái.
        • Xóa: người dùng thường chỉ xóa được ticket của mình khi trạng thái còn «Mở». Quản trị và kỹ thuật viên có thể xóa ticket trong phạm vi quản lý (sau khi xác nhận).


        4. Phím tắt (màn Quản lý ticket)
        • Enter trong ô lọc tiêu đề — chạy lọc.
        • Ctrl+F — đưa con trỏ vào ô lọc tiêu đề và chọn toàn bộ nội dung ô.


        5. Phân quyền (ba vai trò)
        Hệ thống dựa vào «Mã vai trò» trên tài khoản của bạn.

        • Quản trị — xem mọi ticket; phân công, đổi trạng thái, sửa/xóa đầy đủ; thống kê tổng quan trên toàn bộ ticket.
        • Kỹ thuật viên — giống quản trị về phạm vi ticket (xem tất cả, phân công, cập nhật trạng thái xử lý); dùng để tiếp nhận và xử lý yêu cầu.
        • Người dùng — chỉ thấy và thống kê các ticket do chính mình tạo; có thể tạo ticket và sửa nội dung/khoa/ưu tiên của ticket đó; chỉ xóa được ticket của mình khi còn trạng thái Mở.

        Nếu thiếu thao tác trên giao diện (ví dụ: combo người phụ trách, trạng thái bị mờ), đó là do vai trò của bạn không được phép thao tác đó.


        6. Lưu ý
        • Cần kết nối đúng tới SQL Server theo cấu hình ứng dụng; lỗi kết nối sẽ hiện trong hộp thoại.
        • Mật khẩu trong cơ sở dữ liệu là trách nhiệm bảo mật của đơn vị triển khai; nên đổi mật khẩu mặc định trước khi đưa vào dùng thật.
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
