namespace HelpTicket.Forms;

partial class FrmDanhBaEdit
{
    private System.ComponentModel.IContainer components = null!;

    private Panel panelRoot = null!;
    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;

    private TableLayoutPanel tableForm = null!;

    private Label lblMa = null!;
    private TextBox txtMa = null!;

    private Label lblTenDangNhap = null!;
    private TextBox txtTenDangNhap = null!;

    private Label lblHoTen = null!;
    private TextBox txtHoTen = null!;

    private Label lblEmail = null!;
    private TextBox txtEmail = null!;

    private Label lblKhoaPhong = null!;
    private ComboBox cboKhoaPhong = null!;

    private Label lblVaiTro = null!;
    private ComboBox cboVaiTro = null!;

    private Label lblMatKhau = null!;
    private TextBox txtMatKhau = null!;

    private Label lblXacNhan = null!;
    private TextBox txtXacNhan = null!;

    private Label lblHoatDong = null!;
    private CheckBox chkHoatDong = null!;

    private Panel panelFooter = null!;
    private Button btnLuu = null!;
    private Button btnHuy = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelRoot = new Panel();
        tableForm = new TableLayoutPanel();
        lblMa = new Label();
        txtMa = new TextBox();
        lblTenDangNhap = new Label();
        txtTenDangNhap = new TextBox();
        lblHoTen = new Label();
        txtHoTen = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblKhoaPhong = new Label();
        cboKhoaPhong = new ComboBox();
        lblVaiTro = new Label();
        cboVaiTro = new ComboBox();
        lblMatKhau = new Label();
        txtMatKhau = new TextBox();
        lblXacNhan = new Label();
        txtXacNhan = new TextBox();
        lblHoatDong = new Label();
        chkHoatDong = new CheckBox();
        panelFooter = new Panel();
        btnLuu = new Button();
        btnHuy = new Button();
        panelHeader = new Panel();
        lblSubtitle = new Label();
        lblTitle = new Label();
        panelRoot.SuspendLayout();
        tableForm.SuspendLayout();
        panelFooter.SuspendLayout();
        panelHeader.SuspendLayout();
        SuspendLayout();
        // 
        // panelRoot
        // 
        panelRoot.BackColor = Color.White;
        panelRoot.Controls.Add(tableForm);
        panelRoot.Controls.Add(panelFooter);
        panelRoot.Controls.Add(panelHeader);
        panelRoot.Dock = DockStyle.Fill;
        panelRoot.Padding = new Padding(20);
        panelRoot.Size = new Size(720, 560);
        // 
        // panelHeader
        // 
        panelHeader.Controls.Add(lblSubtitle);
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Size = new Size(680, 56);
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI Semibold", 13F);
        lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitle.Location = new Point(0, 0);
        lblTitle.Text = "Thêm tài khoản";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9F);
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtitle.Location = new Point(2, 30);
        lblSubtitle.Text = "Nhập thông tin tài khoản. Các trường có dấu (*) bắt buộc.";
        // 
        // tableForm
        // 
        tableForm.ColumnCount = 2;
        tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableForm.Controls.Add(lblMa, 0, 0);
        tableForm.Controls.Add(txtMa, 1, 0);
        tableForm.Controls.Add(lblTenDangNhap, 0, 1);
        tableForm.Controls.Add(txtTenDangNhap, 1, 1);
        tableForm.Controls.Add(lblHoTen, 0, 2);
        tableForm.Controls.Add(txtHoTen, 1, 2);
        tableForm.Controls.Add(lblEmail, 0, 3);
        tableForm.Controls.Add(txtEmail, 1, 3);
        tableForm.Controls.Add(lblKhoaPhong, 0, 4);
        tableForm.Controls.Add(cboKhoaPhong, 1, 4);
        tableForm.Controls.Add(lblVaiTro, 0, 5);
        tableForm.Controls.Add(cboVaiTro, 1, 5);
        tableForm.Controls.Add(lblMatKhau, 0, 6);
        tableForm.Controls.Add(txtMatKhau, 1, 6);
        tableForm.Controls.Add(lblXacNhan, 0, 7);
        tableForm.Controls.Add(txtXacNhan, 1, 7);
        tableForm.Controls.Add(lblHoatDong, 0, 8);
        tableForm.Controls.Add(chkHoatDong, 1, 8);
        tableForm.Dock = DockStyle.Fill;
        tableForm.Padding = new Padding(0, 8, 0, 8);
        tableForm.RowCount = 9;
        for (int i = 0; i < 9; i++)
            tableForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        tableForm.Size = new Size(680, 408);

        ConfigLabel(lblMa, "Mã");
        ConfigText(txtMa);
        txtMa.ReadOnly = true;
        txtMa.BackColor = Color.FromArgb(241, 245, 249);
        txtMa.Text = "(tự sinh)";

        ConfigLabel(lblTenDangNhap, "Tên đăng nhập *");
        ConfigText(txtTenDangNhap);
        txtTenDangNhap.MaxLength = 50;

        ConfigLabel(lblHoTen, "Họ tên *");
        ConfigText(txtHoTen);
        txtHoTen.MaxLength = 100;

        ConfigLabel(lblEmail, "Email");
        ConfigText(txtEmail);
        txtEmail.MaxLength = 120;

        ConfigLabel(lblKhoaPhong, "Khoa / phòng");
        ConfigCombo(cboKhoaPhong);

        ConfigLabel(lblVaiTro, "Vai trò *");
        ConfigCombo(cboVaiTro);

        ConfigLabel(lblMatKhau, "Mật khẩu *");
        ConfigText(txtMatKhau);
        txtMatKhau.UseSystemPasswordChar = true;
        txtMatKhau.MaxLength = 100;

        ConfigLabel(lblXacNhan, "Xác nhận MK *");
        ConfigText(txtXacNhan);
        txtXacNhan.UseSystemPasswordChar = true;
        txtXacNhan.MaxLength = 100;

        ConfigLabel(lblHoatDong, "Hoạt động");
        chkHoatDong.Anchor = AnchorStyles.Left;
        chkHoatDong.AutoSize = true;
        chkHoatDong.Checked = true;
        chkHoatDong.Font = new Font("Segoe UI", 9.5F);
        chkHoatDong.ForeColor = Color.FromArgb(30, 41, 59);
        chkHoatDong.Margin = new Padding(0, 12, 0, 5);
        chkHoatDong.Text = "Cho phép đăng nhập";
        // 
        // panelFooter
        // 
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Padding = new Padding(0, 12, 0, 0);
        panelFooter.Size = new Size(680, 60);
        // 
        // btnLuu
        // 
        btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLuu.BackColor = Color.FromArgb(24, 95, 165);
        btnLuu.Cursor = Cursors.Hand;
        btnLuu.FlatAppearance.BorderSize = 0;
        btnLuu.FlatStyle = FlatStyle.Flat;
        btnLuu.Font = new Font("Segoe UI Semibold", 9F);
        btnLuu.ForeColor = Color.White;
        btnLuu.Location = new Point(560, 14);
        btnLuu.Size = new Size(112, 34);
        btnLuu.Text = "Lưu";
        btnLuu.UseVisualStyleBackColor = false;
        btnLuu.Click += BtnLuu_Click;
        // 
        // btnHuy
        // 
        btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnHuy.BackColor = Color.White;
        btnHuy.Cursor = Cursors.Hand;
        btnHuy.DialogResult = DialogResult.Cancel;
        btnHuy.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnHuy.FlatStyle = FlatStyle.Flat;
        btnHuy.Font = new Font("Segoe UI", 9F);
        btnHuy.ForeColor = Color.FromArgb(71, 85, 105);
        btnHuy.Location = new Point(450, 14);
        btnHuy.Size = new Size(96, 34);
        btnHuy.Text = "Hủy";
        btnHuy.UseVisualStyleBackColor = false;
        // 
        // FrmDanhBaEdit
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnHuy;
        ClientSize = new Size(720, 560);
        Controls.Add(panelRoot);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmDanhBaEdit";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Tài khoản";

        panelRoot.ResumeLayout(false);
        tableForm.ResumeLayout(false);
        tableForm.PerformLayout();
        panelFooter.ResumeLayout(false);
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ResumeLayout(false);
    }

    private static void ConfigLabel(Label l, string text)
    {
        l.Anchor = AnchorStyles.Left;
        l.AutoSize = true;
        l.Font = new Font("Segoe UI", 9F);
        l.ForeColor = Color.FromArgb(71, 85, 105);
        l.Text = text;
    }

    private static void ConfigText(TextBox t)
    {
        t.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        t.Font = new Font("Segoe UI", 10F);
        t.Margin = new Padding(0, 6, 0, 6);
    }

    private static void ConfigCombo(ComboBox c)
    {
        c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        c.DropDownStyle = ComboBoxStyle.DropDownList;
        c.FlatStyle = FlatStyle.Flat;
        c.Font = new Font("Segoe UI", 10F);
        c.Margin = new Padding(0, 6, 0, 6);
    }
}
