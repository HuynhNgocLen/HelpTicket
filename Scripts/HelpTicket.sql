-- ============================================================
-- HelpTicket - SQL Server schema + seed data
-- Server (local): DESKTOP-ANOQA7D\SQLEXPRESS
-- Chạy script này trên SSMS (hoặc sqlcmd) để tạo DB và dữ liệu mẫu.
-- ============================================================

IF DB_ID(N'HelpTicketDB') IS NULL
BEGIN
    CREATE DATABASE HelpTicketDB;
END
GO

USE HelpTicketDB;
GO

-- Xóa theo thứ tự phụ thuộc khóa ngoại
IF OBJECT_ID(N'dbo.Ticket', N'U') IS NOT NULL DROP TABLE dbo.Ticket;
IF OBJECT_ID(N'dbo.NguoiDung', N'U') IS NOT NULL DROP TABLE dbo.NguoiDung;
IF OBJECT_ID(N'dbo.KhoaPhong', N'U') IS NOT NULL DROP TABLE dbo.KhoaPhong;
IF OBJECT_ID(N'dbo.VaiTro', N'U') IS NOT NULL DROP TABLE dbo.VaiTro;
GO

-- ---------- Bảng vai trò (3 lớp phân quyền) ----------

CREATE TABLE dbo.VaiTro (
    MaVaiTro      TINYINT       NOT NULL PRIMARY KEY,
    TenVaiTro     NVARCHAR(50)  NOT NULL,
    MoTa          NVARCHAR(200) NULL
);
GO

INSERT INTO dbo.VaiTro (MaVaiTro, TenVaiTro, MoTa) VALUES
(1, N'Quản trị',      N'Quản lý toàn hệ thống, ticket, người dùng'),
(2, N'Kỹ thuật viên', N'Tiếp nhận và xử lý ticket được phân công'),
(3, N'Người dùng',    N'Gửi ticket, theo dõi ticket của mình');
GO

-- ---------- Khoa / Phòng ----------
IF OBJECT_ID(N'dbo.KhoaPhong', N'U') IS NOT NULL DROP TABLE dbo.KhoaPhong;
GO

CREATE TABLE dbo.KhoaPhong (
    MaKhoaPhong   INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TenKhoaPhong  NVARCHAR(150)  NOT NULL,
    GhiChu        NVARCHAR(500)  NULL
);
GO

SET IDENTITY_INSERT dbo.KhoaPhong ON;
INSERT INTO dbo.KhoaPhong (MaKhoaPhong, TenKhoaPhong, GhiChu) VALUES
(1, N'Phòng Công nghệ thông tin', N'Hỗ trợ hệ thống, mạng, phần mềm'),
(2, N'Phòng Hành chính',          N'Hỗ trợ văn phòng, tài sản'),
(3, N'Khoa Y',                     N'Hỗ trợ chuyên môn y khoa'),
(4, N'Ban Giám hiệu',             N'Ưu tiên cao');
SET IDENTITY_INSERT dbo.KhoaPhong OFF;
GO

-- ---------- Người dùng ----------
IF OBJECT_ID(N'dbo.NguoiDung', N'U') IS NOT NULL DROP TABLE dbo.NguoiDung;
GO

CREATE TABLE dbo.NguoiDung (
    MaNguoiDung    INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TenDangNhap    NVARCHAR(50)   NOT NULL UNIQUE,
    MatKhau        NVARCHAR(200)  NOT NULL,
    HoTen          NVARCHAR(150)  NOT NULL,
    Email          NVARCHAR(150)  NULL,
    MaKhoaPhong    INT            NULL,
    MaVaiTro       TINYINT        NOT NULL,
    HoatDong       BIT            NOT NULL CONSTRAINT DF_NguoiDung_HoatDong DEFAULT (1),
    CONSTRAINT FK_NguoiDung_KhoaPhong FOREIGN KEY (MaKhoaPhong) REFERENCES dbo.KhoaPhong(MaKhoaPhong),
    CONSTRAINT FK_NguoiDung_VaiTro    FOREIGN KEY (MaVaiTro)    REFERENCES dbo.VaiTro(MaVaiTro)
);
GO

CREATE INDEX IX_NguoiDung_TenDangNhap ON dbo.NguoiDung(TenDangNhap);
GO

-- Mật khẩu demo: plain text (học phần — production nên hash bcrypt/Argon2)
SET IDENTITY_INSERT dbo.NguoiDung ON;
INSERT INTO dbo.NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, HoTen, Email, MaKhoaPhong, MaVaiTro, HoatDong) VALUES
(1, N'admin',      N'admin123',    N'Nguyễn Quản Trị',   N'admin@school.edu.vn',    4, 1, 1),
(2, N'kythuat01',  N'kt@123',      N'Trần Kỹ Thuật',     N'kt01@school.edu.vn',   1, 2, 1),
(3, N'kythuat02',  N'kt@123',      N'Lê Hỗ Trợ',         N'kt02@school.edu.vn',   1, 2, 1),
(4, N'gvnguyen',   N'user@123',    N'Giảng viên Nguyễn', N'gv.nguyen@school.edu.vn', 2, 3, 1),
(5, N'svtran',     N'user@123',    N'Sinh viên Trần',    N'sv.tran@school.edu.vn',   3, 3, 1),
(6, N'nhanvienhc', N'user@123',    N'NV Hành chính',     N'nvhc@school.edu.vn',      2, 3, 1);
SET IDENTITY_INSERT dbo.NguoiDung OFF;
GO

-- ---------- Ticket ----------
IF OBJECT_ID(N'dbo.Ticket', N'U') IS NOT NULL DROP TABLE dbo.Ticket;
GO

CREATE TABLE dbo.Ticket (
    MaTicket          INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TieuDe            NVARCHAR(200)  NOT NULL,
    NoiDung           NVARCHAR(MAX)  NULL,
    TrangThai         NVARCHAR(30)   NOT NULL,
    MaNguoiTao        INT            NOT NULL,
    MaNguoiPhuTrach   INT            NULL,
    MaKhoaPhong       INT            NOT NULL,
    NgayTao           DATETIME2(0)   NOT NULL CONSTRAINT DF_Ticket_NgayTao DEFAULT (SYSUTCDATETIME()),
    NgayCapNhat       DATETIME2(0)   NULL,
    DoUuTien          TINYINT        NOT NULL CONSTRAINT DF_Ticket_DoUuTien DEFAULT (2),
    CONSTRAINT FK_Ticket_NguoiTao      FOREIGN KEY (MaNguoiTao)      REFERENCES dbo.NguoiDung(MaNguoiDung),
    CONSTRAINT FK_Ticket_NguoiPhuTrach FOREIGN KEY (MaNguoiPhuTrach) REFERENCES dbo.NguoiDung(MaNguoiDung),
    CONSTRAINT FK_Ticket_KhoaPhong     FOREIGN KEY (MaKhoaPhong)     REFERENCES dbo.KhoaPhong(MaKhoaPhong),
    CONSTRAINT CK_Ticket_TrangThai CHECK (TrangThai IN (N'Mo', N'DangXuLy', N'HoanThanh', N'Huy'))
);
GO

CREATE INDEX IX_Ticket_TrangThai     ON dbo.Ticket(TrangThai);
CREATE INDEX IX_Ticket_MaKhoaPhong   ON dbo.Ticket(MaKhoaPhong);
CREATE INDEX IX_Ticket_NguoiPhuTrach ON dbo.Ticket(MaNguoiPhuTrach);
CREATE INDEX IX_Ticket_NguoiTao      ON dbo.Ticket(MaNguoiTao);
GO

SET IDENTITY_INSERT dbo.Ticket ON;
INSERT INTO dbo.Ticket (MaTicket, TieuDe, NoiDung, TrangThai, MaNguoiTao, MaNguoiPhuTrach, MaKhoaPhong, NgayTao, NgayCapNhat, DoUuTien) VALUES
(1, N'Không vào được Wi-Fi',           N'Máy tính báo limited connectivity.',                    N'DangXuLy',  4, 2, 1, DATEADD(DAY, -3, SYSUTCDATETIME()), DATEADD(HOUR, -5, SYSUTCDATETIME()), 2),
(2, N'Cài đặt Office cho máy phòng 301', N'Cần Office 365 cho giảng dạy.',                     N'Mo',        5, NULL, 1, DATEADD(DAY, -1, SYSUTCDATETIME()), NULL, 3),
(3, N'In ấn tài liệu họp',             N'Máy in phòng hành chính kẹt giấy.',                   N'HoanThanh', 6, 3, 2, DATEADD(DAY, -10, SYSUTCDATETIME()), DATEADD(DAY, -8, SYSUTCDATETIME()), 1),
(4, N'Ưu tiên: máy chủ phản hồi chậm', N'Server nội bộ lag giờ cao điểm.',                      N'Mo',        4, NULL, 4, DATEADD(HOUR, -12, SYSUTCDATETIME()), NULL, 1),
(5, N'Đổi mật khẩu email',             N'Quên mật khẩu email công vụ.',                       N'DangXuLy',  5, 2, 1, DATEADD(DAY, -2, SYSUTCDATETIME()), DATEADD(HOUR, -1, SYSUTCDATETIME()), 2);
SET IDENTITY_INSERT dbo.Ticket OFF;
GO

PRINT N'HelpTicketDB đã được tạo và nạp dữ liệu mẫu.';
GO
