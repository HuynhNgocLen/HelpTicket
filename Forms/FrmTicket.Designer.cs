using HelpTicket.Common;

namespace HelpTicket.Forms;

partial class FrmTicket
{
    private System.ComponentModel.IContainer components = null!;
    private Panel panelRoot = null!;
    private Panel panelFilter = null!;
    private TableLayoutPanel tableFilter = null!;
    private Label lblLocTitle = null!;
    private TextBox txtLocTieuDe = null!;
    private ComboBox cboLocKhoa = null!;
    private ComboBox cboLocTrang = null!;
    private ComboBox cboLocKyThuat = null!;
    private Button btnLoc = null!;
    private Button btnXuatCsv = null!;
    private FlowLayoutPanel panelFilterBtns = null!;
    private Label lblThongKe = null!;
    private DataGridView dgv = null!;
    private Panel panelDetail = null!;
    private TableLayoutPanel tableDetail = null!;
    private Label lblMa = null!;
    private TextBox txtMa = null!;
    private Label lblTieuDe = null!;
    private TextBox txtTieuDe = null!;
    private Label lblNoiDung = null!;
    private TextBox txtNoiDung = null!;
    private Label lblKhoa = null!;
    private ComboBox cboKhoaChiTiet = null!;
    private Label lblTrangThai = null!;
    private ComboBox cboTrangThaiChiTiet = null!;
    private Label lblPhuTrach = null!;
    private ComboBox cboNguoiPhuTrach = null!;
    private Label lblUuTien = null!;
    private NumericUpDown numDoUuTien = null!;
    private FlowLayoutPanel panelActions = null!;
    private Button btnThem = null!;
    private Button btnSua = null!;
    private Button btnXoa = null!;
    private Button btnLamMoi = null!;
    private Panel panelPaging = null!;
    private Button btnTrangDau = null!;
    private Button btnTrangTruoc = null!;
    private Button btnTrangSau = null!;
    private Button btnTrangCuoi = null!;
    private Label lblTrang = null!;
    private Label lblKichThuocTrang = null!;
    private ComboBox cboKichThuocTrang = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        panelRoot = new Panel();
        dgv = new DataGridView();
        panelPaging = new Panel();
        lblTrang = new Label();
        btnTrangDau = new Button();
        btnTrangTruoc = new Button();
        btnTrangSau = new Button();
        btnTrangCuoi = new Button();
        lblKichThuocTrang = new Label();
        cboKichThuocTrang = new ComboBox();
        panelDetail = new Panel();
        panelActions = new FlowLayoutPanel();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        tableDetail = new TableLayoutPanel();
        lblMa = new Label();
        txtMa = new TextBox();
        lblTieuDe = new Label();
        txtTieuDe = new TextBox();
        lblKhoa = new Label();
        cboKhoaChiTiet = new ComboBox();
        lblTrangThai = new Label();
        cboTrangThaiChiTiet = new ComboBox();
        lblNoiDung = new Label();
        cboNguoiPhuTrach = new ComboBox();
        txtNoiDung = new TextBox();
        lblUuTien = new Label();
        lblPhuTrach = new Label();
        numDoUuTien = new NumericUpDown();
        panelFilter = new Panel();
        tableFilter = new TableLayoutPanel();
        lblLocTitle = new Label();
        txtLocTieuDe = new TextBox();
        cboLocKhoa = new ComboBox();
        cboLocTrang = new ComboBox();
        cboLocKyThuat = new ComboBox();
        panelFilterBtns = new FlowLayoutPanel();
        btnLoc = new Button();
        btnXuatCsv = new Button();
        lblThongKe = new Label();
        panelRoot.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        panelPaging.SuspendLayout();
        panelDetail.SuspendLayout();
        panelActions.SuspendLayout();
        tableDetail.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numDoUuTien).BeginInit();
        panelFilter.SuspendLayout();
        tableFilter.SuspendLayout();
        panelFilterBtns.SuspendLayout();
        SuspendLayout();
        // 
        // panelRoot
        // 
        panelRoot.BackColor = Color.FromArgb(245, 242, 235);
        panelRoot.Controls.Add(dgv);
        panelRoot.Controls.Add(panelPaging);
        panelRoot.Controls.Add(panelDetail);
        panelRoot.Controls.Add(panelFilter);
        panelRoot.Dock = DockStyle.Fill;
        panelRoot.Location = new Point(0, 0);
        panelRoot.Margin = new Padding(3, 4, 3, 4);
        panelRoot.Name = "panelRoot";
        panelRoot.Padding = new Padding(0, 0, 0, 11);
        panelRoot.Size = new Size(1077, 770);
        panelRoot.TabIndex = 0;
        // 
        // dgv
        // 
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.BackgroundColor = Color.White;
        dgv.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(228, 224, 214);
        dataGridViewCellStyle1.Font = new Font("Bahnschrift SemiBold", 9.25F);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(228, 224, 214);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
        dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgv.ColumnHeadersHeight = 36;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 251, 241);
        dataGridViewCellStyle2.SelectionForeColor = Color.Black;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgv.DefaultCellStyle = dataGridViewCellStyle2;
        dgv.Dock = DockStyle.Fill;
        dgv.EnableHeadersVisualStyles = false;
        dgv.GridColor = Color.FromArgb(210, 205, 196);
        dgv.Location = new Point(0, 147);
        dgv.Margin = new Padding(3, 4, 3, 4);
        dgv.MultiSelect = false;
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.RowHeadersVisible = false;
        dgv.RowHeadersWidth = 51;
        dgv.RowTemplate.Height = 28;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.Size = new Size(1077, 214);
        dgv.TabIndex = 1;
        dgv.CellDoubleClick += Dgv_CellDoubleClick;
        dgv.SelectionChanged += Dgv_SelectionChanged;
        // 
        // panelPaging
        // 
        panelPaging.BackColor = Color.FromArgb(255, 253, 249);
        panelPaging.Controls.Add(lblTrang);
        panelPaging.Controls.Add(btnTrangDau);
        panelPaging.Controls.Add(btnTrangTruoc);
        panelPaging.Controls.Add(btnTrangSau);
        panelPaging.Controls.Add(btnTrangCuoi);
        panelPaging.Controls.Add(lblKichThuocTrang);
        panelPaging.Controls.Add(cboKichThuocTrang);
        panelPaging.Dock = DockStyle.Bottom;
        panelPaging.Location = new Point(0, 361);
        panelPaging.Margin = new Padding(3, 4, 3, 4);
        panelPaging.Name = "panelPaging";
        panelPaging.Padding = new Padding(18, 8, 18, 8);
        panelPaging.Size = new Size(1077, 46);
        panelPaging.TabIndex = 2;
        // 
        // lblTrang
        // 
        lblTrang.Font = new Font("Bahnschrift SemiBold", 9.5F);
        lblTrang.ForeColor = Color.FromArgb(15, 23, 42);
        lblTrang.Location = new Point(364, 10);
        lblTrang.Name = "lblTrang";
        lblTrang.Size = new Size(312, 30);
        lblTrang.TabIndex = 2;
        lblTrang.Text = "Trang 1 / 1";
        lblTrang.TextAlign = ContentAlignment.MiddleCenter;
        lblTrang.Click += lblTrang_Click;
        // 
        // btnTrangDau
        // 
        btnTrangDau.Cursor = Cursors.Hand;
        btnTrangDau.FlatAppearance.BorderColor = Color.FromArgb(218, 212, 202);
        btnTrangDau.FlatStyle = FlatStyle.Flat;
        btnTrangDau.Font = new Font("Bahnschrift SemiBold", 9.5F);
        btnTrangDau.Location = new Point(224, 8);
        btnTrangDau.Margin = new Padding(0);
        btnTrangDau.Name = "btnTrangDau";
        btnTrangDau.Size = new Size(60, 32);
        btnTrangDau.TabIndex = 0;
        btnTrangDau.Text = "« Đầu";
        btnTrangDau.UseVisualStyleBackColor = true;
        btnTrangDau.Click += BtnTrangDau_Click;
        // 
        // btnTrangTruoc
        // 
        btnTrangTruoc.Cursor = Cursors.Hand;
        btnTrangTruoc.FlatAppearance.BorderColor = Color.FromArgb(218, 212, 202);
        btnTrangTruoc.FlatStyle = FlatStyle.Flat;
        btnTrangTruoc.Font = new Font("Bahnschrift SemiBold", 9.5F);
        btnTrangTruoc.Location = new Point(288, 8);
        btnTrangTruoc.Margin = new Padding(0);
        btnTrangTruoc.Name = "btnTrangTruoc";
        btnTrangTruoc.Size = new Size(70, 32);
        btnTrangTruoc.TabIndex = 1;
        btnTrangTruoc.Text = "‹ Trước";
        btnTrangTruoc.UseVisualStyleBackColor = true;
        btnTrangTruoc.Click += BtnTrangTruoc_Click;
        // 
        // btnTrangSau
        // 
        btnTrangSau.Cursor = Cursors.Hand;
        btnTrangSau.FlatAppearance.BorderColor = Color.FromArgb(218, 212, 202);
        btnTrangSau.FlatStyle = FlatStyle.Flat;
        btnTrangSau.Font = new Font("Bahnschrift SemiBold", 9.5F);
        btnTrangSau.Location = new Point(679, 8);
        btnTrangSau.Margin = new Padding(0);
        btnTrangSau.Name = "btnTrangSau";
        btnTrangSau.Size = new Size(70, 32);
        btnTrangSau.TabIndex = 3;
        btnTrangSau.Text = "Sau ›";
        btnTrangSau.UseVisualStyleBackColor = true;
        btnTrangSau.Click += BtnTrangSau_Click;
        // 
        // btnTrangCuoi
        // 
        btnTrangCuoi.Cursor = Cursors.Hand;
        btnTrangCuoi.FlatAppearance.BorderColor = Color.FromArgb(218, 212, 202);
        btnTrangCuoi.FlatStyle = FlatStyle.Flat;
        btnTrangCuoi.Font = new Font("Bahnschrift SemiBold", 9.5F);
        btnTrangCuoi.Location = new Point(753, 8);
        btnTrangCuoi.Margin = new Padding(0);
        btnTrangCuoi.Name = "btnTrangCuoi";
        btnTrangCuoi.Size = new Size(60, 32);
        btnTrangCuoi.TabIndex = 4;
        btnTrangCuoi.Text = "Cuối »";
        btnTrangCuoi.UseVisualStyleBackColor = true;
        btnTrangCuoi.Click += BtnTrangCuoi_Click;
        // 
        // lblKichThuocTrang
        // 
        lblKichThuocTrang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblKichThuocTrang.AutoSize = true;
        lblKichThuocTrang.ForeColor = Color.FromArgb(91, 103, 122);
        lblKichThuocTrang.Location = new Point(870, 14);
        lblKichThuocTrang.Name = "lblKichThuocTrang";
        lblKichThuocTrang.Size = new Size(109, 20);
        lblKichThuocTrang.TabIndex = 5;
        lblKichThuocTrang.Text = "Số dòng/trang:";
        // 
        // cboKichThuocTrang
        // 
        cboKichThuocTrang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        cboKichThuocTrang.DropDownStyle = ComboBoxStyle.DropDownList;
        cboKichThuocTrang.FormattingEnabled = true;
        cboKichThuocTrang.Items.AddRange(new object[] { "10", "20", "50", "100" });
        cboKichThuocTrang.Location = new Point(975, 10);
        cboKichThuocTrang.Margin = new Padding(0);
        cboKichThuocTrang.Name = "cboKichThuocTrang";
        cboKichThuocTrang.Size = new Size(80, 28);
        cboKichThuocTrang.TabIndex = 6;
        cboKichThuocTrang.SelectedIndexChanged += CboKichThuocTrang_SelectedIndexChanged;
        // 
        // panelDetail
        // 
        panelDetail.BackColor = Color.FromArgb(255, 253, 249);
        panelDetail.Controls.Add(panelActions);
        panelDetail.Controls.Add(tableDetail);
        panelDetail.Dock = DockStyle.Bottom;
        panelDetail.Location = new Point(0, 407);
        panelDetail.Margin = new Padding(3, 4, 3, 4);
        panelDetail.Name = "panelDetail";
        panelDetail.Padding = new Padding(18, 21, 18, 21);
        panelDetail.Size = new Size(1077, 352);
        panelDetail.TabIndex = 1;
        // 
        // panelActions
        // 
        panelActions.AutoSize = true;
        panelActions.Controls.Add(btnThem);
        panelActions.Controls.Add(btnSua);
        panelActions.Controls.Add(btnXoa);
        panelActions.Controls.Add(btnLamMoi);
        panelActions.Dock = DockStyle.Bottom;
        panelActions.Location = new Point(18, 247);
        panelActions.Margin = new Padding(3, 4, 3, 4);
        panelActions.Name = "panelActions";
        panelActions.Padding = new Padding(0, 13, 0, 0);
        panelActions.Size = new Size(1041, 84);
        panelActions.TabIndex = 0;
        // 
        // btnThem
        // 
        btnThem.AutoSize = true;
        btnThem.BackColor = Color.FromArgb(5, 140, 105);
        btnThem.Cursor = Cursors.Hand;
        btnThem.FlatAppearance.BorderSize = 0;
        btnThem.FlatAppearance.MouseOverBackColor = Color.FromArgb(4, 110, 82);
        btnThem.FlatStyle = FlatStyle.Flat;
        btnThem.Font = new Font("Bahnschrift SemiBold", 10F);
        btnThem.ForeColor = Color.White;
        btnThem.Location = new Point(0, 13);
        btnThem.Margin = new Padding(0, 0, 11, 0);
        btnThem.Name = "btnThem";
        btnThem.Padding = new Padding(16, 8, 16, 8);
        btnThem.Size = new Size(158, 60);
        btnThem.TabIndex = 0;
        btnThem.Text = "Thêm ticket";
        btnThem.UseVisualStyleBackColor = false;
        btnThem.Click += BtnThem_Click;
        // 
        // btnSua
        // 
        btnSua.AutoSize = true;
        btnSua.BackColor = Color.FromArgb(13, 148, 136);
        btnSua.Cursor = Cursors.Hand;
        btnSua.FlatAppearance.BorderSize = 0;
        btnSua.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 118, 110);
        btnSua.FlatStyle = FlatStyle.Flat;
        btnSua.Font = new Font("Bahnschrift SemiBold", 10F);
        btnSua.ForeColor = Color.White;
        btnSua.Location = new Point(169, 13);
        btnSua.Margin = new Padding(0, 0, 11, 0);
        btnSua.Name = "btnSua";
        btnSua.Padding = new Padding(16, 8, 16, 8);
        btnSua.Size = new Size(166, 60);
        btnSua.TabIndex = 1;
        btnSua.Text = "Lưu thay đổi";
        btnSua.UseVisualStyleBackColor = false;
        btnSua.Click += BtnSua_Click;
        // 
        // btnXoa
        // 
        btnXoa.AutoSize = true;
        btnXoa.FlatAppearance.BorderColor = Color.FromArgb(218, 212, 202);
        btnXoa.FlatStyle = FlatStyle.Flat;
        btnXoa.Location = new Point(346, 13);
        btnXoa.Margin = new Padding(0, 0, 11, 0);
        btnXoa.Name = "btnXoa";
        btnXoa.Padding = new Padding(16, 8, 16, 8);
        btnXoa.Size = new Size(90, 63);
        btnXoa.TabIndex = 2;
        btnXoa.Text = "Xóa";
        btnXoa.Click += BtnXoa_Click;
        // 
        // btnLamMoi
        // 
        btnLamMoi.AutoSize = true;
        btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(218, 212, 202);
        btnLamMoi.FlatStyle = FlatStyle.Flat;
        btnLamMoi.Location = new Point(450, 17);
        btnLamMoi.Margin = new Padding(3, 4, 3, 4);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Padding = new Padding(16, 8, 16, 8);
        btnLamMoi.Size = new Size(179, 63);
        btnLamMoi.TabIndex = 3;
        btnLamMoi.Text = "Làm mới form";
        btnLamMoi.Click += BtnLamMoi_Click;
        // 
        // tableDetail
        // 
        tableDetail.ColumnCount = 4;
        tableDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97F));
        tableDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
        tableDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableDetail.Controls.Add(lblMa, 0, 0);
        tableDetail.Controls.Add(txtMa, 1, 0);
        tableDetail.Controls.Add(lblTieuDe, 2, 0);
        tableDetail.Controls.Add(txtTieuDe, 3, 0);
        tableDetail.Controls.Add(lblKhoa, 0, 1);
        tableDetail.Controls.Add(cboKhoaChiTiet, 1, 1);
        tableDetail.Controls.Add(lblTrangThai, 2, 1);
        tableDetail.Controls.Add(cboTrangThaiChiTiet, 3, 1);
        tableDetail.Controls.Add(lblNoiDung, 0, 2);
        tableDetail.Controls.Add(cboNguoiPhuTrach, 1, 3);
        tableDetail.Controls.Add(txtNoiDung, 1, 2);
        tableDetail.Controls.Add(lblUuTien, 2, 3);
        tableDetail.Controls.Add(lblPhuTrach, 0, 3);
        tableDetail.Controls.Add(numDoUuTien, 3, 3);
        tableDetail.Dock = DockStyle.Fill;
        tableDetail.Location = new Point(18, 21);
        tableDetail.Margin = new Padding(3, 4, 3, 4);
        tableDetail.Name = "tableDetail";
        tableDetail.Padding = new Padding(0, 0, 0, 11);
        tableDetail.RowCount = 4;
        tableDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        tableDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        tableDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 101F));
        tableDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        tableDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableDetail.Size = new Size(1041, 310);
        tableDetail.TabIndex = 1;
        tableDetail.Paint += tableDetail_Paint;
        // 
        // lblMa
        // 
        lblMa.Anchor = AnchorStyles.Left;
        lblMa.AutoSize = true;
        lblMa.ForeColor = Color.FromArgb(91, 103, 122);
        lblMa.Location = new Point(3, 12);
        lblMa.Name = "lblMa";
        lblMa.Size = new Size(70, 20);
        lblMa.TabIndex = 0;
        lblMa.Text = "Mã ticket";
        // 
        // txtMa
        // 
        txtMa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtMa.Location = new Point(100, 4);
        txtMa.Margin = new Padding(3, 4, 3, 4);
        txtMa.Name = "txtMa";
        txtMa.ReadOnly = true;
        txtMa.Size = new Size(397, 27);
        txtMa.TabIndex = 1;
        // 
        // lblTieuDe
        // 
        lblTieuDe.Anchor = AnchorStyles.Left;
        lblTieuDe.AutoSize = true;
        lblTieuDe.ForeColor = Color.FromArgb(91, 103, 122);
        lblTieuDe.Location = new Point(503, 12);
        lblTieuDe.Name = "lblTieuDe";
        lblTieuDe.Size = new Size(58, 20);
        lblTieuDe.TabIndex = 2;
        lblTieuDe.Text = "Tiêu đề";
        // 
        // txtTieuDe
        // 
        txtTieuDe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtTieuDe.Location = new Point(640, 4);
        txtTieuDe.Margin = new Padding(3, 4, 3, 4);
        txtTieuDe.Name = "txtTieuDe";
        txtTieuDe.Size = new Size(398, 27);
        txtTieuDe.TabIndex = 3;
        // 
        // lblKhoa
        // 
        lblKhoa.Anchor = AnchorStyles.Left;
        lblKhoa.AutoSize = true;
        lblKhoa.ForeColor = Color.FromArgb(91, 103, 122);
        lblKhoa.Location = new Point(3, 57);
        lblKhoa.Name = "lblKhoa";
        lblKhoa.Size = new Size(91, 20);
        lblKhoa.TabIndex = 4;
        lblKhoa.Text = "Khoa/Phòng";
        // 
        // cboKhoaChiTiet
        // 
        cboKhoaChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboKhoaChiTiet.DropDownStyle = ComboBoxStyle.DropDownList;
        cboKhoaChiTiet.FormattingEnabled = true;
        cboKhoaChiTiet.Location = new Point(100, 49);
        cboKhoaChiTiet.Margin = new Padding(3, 4, 3, 4);
        cboKhoaChiTiet.Name = "cboKhoaChiTiet";
        cboKhoaChiTiet.Size = new Size(397, 28);
        cboKhoaChiTiet.TabIndex = 5;
        // 
        // lblTrangThai
        // 
        lblTrangThai.Anchor = AnchorStyles.Left;
        lblTrangThai.AutoSize = true;
        lblTrangThai.ForeColor = Color.FromArgb(91, 103, 122);
        lblTrangThai.Location = new Point(503, 57);
        lblTrangThai.Name = "lblTrangThai";
        lblTrangThai.Size = new Size(75, 20);
        lblTrangThai.TabIndex = 6;
        lblTrangThai.Text = "Trạng thái";
        // 
        // cboTrangThaiChiTiet
        // 
        cboTrangThaiChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboTrangThaiChiTiet.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTrangThaiChiTiet.FormattingEnabled = true;
        cboTrangThaiChiTiet.Location = new Point(640, 49);
        cboTrangThaiChiTiet.Margin = new Padding(3, 4, 3, 4);
        cboTrangThaiChiTiet.Name = "cboTrangThaiChiTiet";
        cboTrangThaiChiTiet.Size = new Size(398, 28);
        cboTrangThaiChiTiet.TabIndex = 7;
        // 
        // lblNoiDung
        // 
        lblNoiDung.AutoSize = true;
        lblNoiDung.ForeColor = Color.FromArgb(91, 103, 122);
        lblNoiDung.Location = new Point(3, 90);
        lblNoiDung.Name = "lblNoiDung";
        lblNoiDung.Size = new Size(71, 20);
        lblNoiDung.TabIndex = 8;
        lblNoiDung.Text = "Nội dung";
        // 
        // cboNguoiPhuTrach
        // 
        cboNguoiPhuTrach.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboNguoiPhuTrach.DropDownStyle = ComboBoxStyle.DropDownList;
        cboNguoiPhuTrach.FormattingEnabled = true;
        cboNguoiPhuTrach.Location = new Point(100, 195);
        cboNguoiPhuTrach.Margin = new Padding(3, 4, 3, 4);
        cboNguoiPhuTrach.Name = "cboNguoiPhuTrach";
        cboNguoiPhuTrach.Size = new Size(397, 28);
        cboNguoiPhuTrach.TabIndex = 11;
        // 
        // txtNoiDung
        // 
        txtNoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tableDetail.SetColumnSpan(txtNoiDung, 3);
        txtNoiDung.Location = new Point(99, 93);
        txtNoiDung.Margin = new Padding(2, 3, 2, 3);
        txtNoiDung.Multiline = true;
        txtNoiDung.Name = "txtNoiDung";
        txtNoiDung.ScrollBars = ScrollBars.Vertical;
        txtNoiDung.Size = new Size(940, 95);
        txtNoiDung.TabIndex = 9;
        txtNoiDung.TextChanged += txtNoiDung_TextChanged;
        // 
        // lblUuTien
        // 
        lblUuTien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblUuTien.AutoSize = true;
        lblUuTien.ForeColor = Color.FromArgb(91, 103, 122);
        lblUuTien.Location = new Point(503, 191);
        lblUuTien.Name = "lblUuTien";
        lblUuTien.Size = new Size(131, 108);
        lblUuTien.TabIndex = 12;
        lblUuTien.Text = "Ưu tiên (1–3)";
        // 
        // lblPhuTrach
        // 
        lblPhuTrach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblPhuTrach.AutoSize = true;
        lblPhuTrach.ForeColor = Color.FromArgb(91, 103, 122);
        lblPhuTrach.Location = new Point(3, 191);
        lblPhuTrach.Name = "lblPhuTrach";
        lblPhuTrach.Size = new Size(91, 108);
        lblPhuTrach.TabIndex = 10;
        lblPhuTrach.Text = "Người phụ trách";
        // 
        // numDoUuTien
        // 
        numDoUuTien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        numDoUuTien.Location = new Point(640, 195);
        numDoUuTien.Margin = new Padding(3, 4, 3, 4);
        numDoUuTien.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
        numDoUuTien.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numDoUuTien.Name = "numDoUuTien";
        numDoUuTien.Size = new Size(398, 27);
        numDoUuTien.TabIndex = 13;
        numDoUuTien.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // panelFilter
        // 
        panelFilter.BackColor = Color.FromArgb(255, 253, 249);
        panelFilter.Controls.Add(tableFilter);
        panelFilter.Dock = DockStyle.Top;
        panelFilter.Location = new Point(0, 0);
        panelFilter.Margin = new Padding(3, 4, 3, 4);
        panelFilter.Name = "panelFilter";
        panelFilter.Padding = new Padding(18, 16, 18, 16);
        panelFilter.Size = new Size(1077, 147);
        panelFilter.TabIndex = 0;
        // 
        // tableFilter
        // 
        tableFilter.ColumnCount = 4;
        tableFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
        tableFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
        tableFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
        tableFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
        tableFilter.Controls.Add(lblLocTitle, 0, 0);
        tableFilter.Controls.Add(txtLocTieuDe, 0, 1);
        tableFilter.Controls.Add(cboLocKhoa, 1, 1);
        tableFilter.Controls.Add(cboLocTrang, 2, 1);
        tableFilter.Controls.Add(cboLocKyThuat, 3, 1);
        tableFilter.Controls.Add(panelFilterBtns, 0, 2);
        tableFilter.Controls.Add(lblThongKe, 0, 3);
        tableFilter.Dock = DockStyle.Fill;
        tableFilter.Location = new Point(18, 16);
        tableFilter.Margin = new Padding(0);
        tableFilter.Name = "tableFilter";
        tableFilter.RowCount = 4;
        tableFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        tableFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
        tableFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        tableFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 123F));
        tableFilter.Size = new Size(1041, 115);
        tableFilter.TabIndex = 0;
        // 
        // lblLocTitle
        // 
        tableFilter.SetColumnSpan(lblLocTitle, 4);
        lblLocTitle.Dock = DockStyle.Fill;
        lblLocTitle.Font = new Font("Bahnschrift SemiBold", 10.25F);
        lblLocTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblLocTitle.Location = new Point(0, 0);
        lblLocTitle.Margin = new Padding(0, 0, 0, 5);
        lblLocTitle.Name = "lblLocTitle";
        lblLocTitle.Size = new Size(1041, 30);
        lblLocTitle.TabIndex = 0;
        lblLocTitle.Text = "Lọc ticket  ·  Enter áp dụng  ·  Ctrl+F ô tìm";
        lblLocTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtLocTieuDe
        // 
        txtLocTieuDe.Dock = DockStyle.Fill;
        txtLocTieuDe.Location = new Point(0, 35);
        txtLocTieuDe.Margin = new Padding(0, 0, 9, 0);
        txtLocTieuDe.Name = "txtLocTieuDe";
        txtLocTieuDe.PlaceholderText = "Tiêu đề chứa…";
        txtLocTieuDe.Size = new Size(365, 27);
        txtLocTieuDe.TabIndex = 1;
        // 
        // cboLocKhoa
        // 
        cboLocKhoa.Dock = DockStyle.Fill;
        cboLocKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocKhoa.FormattingEnabled = true;
        cboLocKhoa.Location = new Point(374, 35);
        cboLocKhoa.Margin = new Padding(0, 0, 9, 0);
        cboLocKhoa.Name = "cboLocKhoa";
        cboLocKhoa.Size = new Size(391, 28);
        cboLocKhoa.TabIndex = 2;
        // 
        // cboLocTrang
        // 
        cboLocTrang.Dock = DockStyle.Fill;
        cboLocTrang.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocTrang.FormattingEnabled = true;
        cboLocTrang.Location = new Point(774, 35);
        cboLocTrang.Margin = new Padding(0, 0, 9, 0);
        cboLocTrang.Name = "cboLocTrang";
        cboLocTrang.Size = new Size(258, 28);
        cboLocTrang.TabIndex = 3;
        // 
        // cboLocKyThuat
        // 
        cboLocKyThuat.Dock = DockStyle.Fill;
        cboLocKyThuat.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocKyThuat.FormattingEnabled = true;
        cboLocKyThuat.Location = new Point(1041, 35);
        cboLocKyThuat.Margin = new Padding(0, 0, 0, 0);
        cboLocKyThuat.Name = "cboLocKyThuat";
        cboLocKyThuat.Size = new Size(240, 28);
        cboLocKyThuat.TabIndex = 4;
        // 
        // panelFilterBtns
        // 
        panelFilterBtns.AutoSize = true;
        panelFilterBtns.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tableFilter.SetColumnSpan(panelFilterBtns, 4);
        panelFilterBtns.Controls.Add(btnLoc);
        panelFilterBtns.Controls.Add(btnXuatCsv);
        panelFilterBtns.Dock = DockStyle.Right;
        panelFilterBtns.FlowDirection = FlowDirection.RightToLeft;
        panelFilterBtns.Location = new Point(754, 66);
        panelFilterBtns.Margin = new Padding(0);
        panelFilterBtns.Name = "panelFilterBtns";
        panelFilterBtns.Padding = new Padding(0, 2, 0, 0);
        panelFilterBtns.Size = new Size(287, 56);
        panelFilterBtns.TabIndex = 11;
        panelFilterBtns.WrapContents = false;
        // 
        // btnLoc
        // 
        btnLoc.BackColor = Color.FromArgb(13, 148, 136);
        btnLoc.Cursor = Cursors.Hand;
        btnLoc.FlatAppearance.BorderSize = 0;
        btnLoc.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 118, 110);
        btnLoc.FlatStyle = FlatStyle.Flat;
        btnLoc.Font = new Font("Bahnschrift SemiBold", 10.25F);
        btnLoc.ForeColor = Color.White;
        btnLoc.Location = new Point(135, 2);
        btnLoc.Margin = new Padding(0);
        btnLoc.Name = "btnLoc";
        btnLoc.Size = new Size(152, 40);
        btnLoc.TabIndex = 5;
        btnLoc.Text = "Áp dụng lọc";
        btnLoc.UseVisualStyleBackColor = false;
        btnLoc.Click += BtnLoc_Click;
        // 
        // btnXuatCsv
        // 
        btnXuatCsv.FlatAppearance.BorderColor = Color.FromArgb(218, 212, 202);
        btnXuatCsv.FlatStyle = FlatStyle.Flat;
        btnXuatCsv.ForeColor = Color.FromArgb(15, 23, 42);
        btnXuatCsv.Location = new Point(11, 2);
        btnXuatCsv.Margin = new Padding(11, 0, 0, 0);
        btnXuatCsv.Name = "btnXuatCsv";
        btnXuatCsv.Size = new Size(124, 40);
        btnXuatCsv.TabIndex = 4;
        btnXuatCsv.Text = "Xuất CSV…";
        btnXuatCsv.UseVisualStyleBackColor = true;
        btnXuatCsv.Click += BtnXuatCsv_Click;
        // 
        // lblThongKe
        // 
        tableFilter.SetColumnSpan(lblThongKe, 4);
        lblThongKe.Dock = DockStyle.Fill;
        lblThongKe.ForeColor = Color.FromArgb(91, 103, 122);
        lblThongKe.Location = new Point(0, 126);
        lblThongKe.Margin = new Padding(0, 4, 0, 0);
        lblThongKe.Name = "lblThongKe";
        lblThongKe.Size = new Size(1041, 119);
        lblThongKe.TabIndex = 10;
        lblThongKe.Text = "—";
        lblThongKe.TextAlign = ContentAlignment.MiddleLeft;
        lblThongKe.Click += lblThongKe_Click;
        // 
        // FrmTicket
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1077, 770);
        Controls.Add(panelRoot);
        KeyPreview = true;
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(880, 520);
        Name = "FrmTicket";
        Text = "Ticket";
        KeyDown += FrmTicket_KeyDown;
        panelRoot.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        panelPaging.ResumeLayout(false);
        panelPaging.PerformLayout();
        panelDetail.ResumeLayout(false);
        panelDetail.PerformLayout();
        panelActions.ResumeLayout(false);
        panelActions.PerformLayout();
        tableDetail.ResumeLayout(false);
        tableDetail.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numDoUuTien).EndInit();
        panelFilter.ResumeLayout(false);
        tableFilter.ResumeLayout(false);
        tableFilter.PerformLayout();
        panelFilterBtns.ResumeLayout(false);
        ResumeLayout(false);
    }
}
