using HelpTicket.Common;

namespace HelpTicket.Forms;

partial class FrmMain
{
    private System.ComponentModel.IContainer components = null!;
    private Panel panelSidebar = null!;
    private Panel panelSideHeader = null!;
    private Label lblBrand = null!;
    private Label lblSideSubtitle = null!;
    private Label lblNavCaption = null!;
    private Panel panelNavScroll = null!;
    private TableLayoutPanel tableNav = null!;
    private Button btnNavDashboard = null!;
    private Button btnNavTickets = null!;
    private Button btnNavKhoa = null!;
    private Button btnNavDanhBa = null!;
    private Button btnNavHuongDan = null!;
    private Button btnNavAbout = null!;
    private Panel panelSideFooter = null!;
    private Label lblNavHint = null!;
    private Button btnLogout = null!;
    private Panel panelTop = null!;
    private Label lblUser = null!;
    private Label lblRole = null!;
    private Label lblBreadcrumb = null!;
    private Label lblBreadcrumbSub = null!;
    private TableLayoutPanel tableTopBar = null!;
    private Panel panelContent = null!;

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
        panelSidebar = new Panel();
        lblNavCaption = new Label();
        panelNavScroll = new Panel();
        tableNav = new TableLayoutPanel();
        btnNavDashboard = new Button();
        btnNavTickets = new Button();
        btnNavKhoa = new Button();
        btnNavDanhBa = new Button();
        btnNavHuongDan = new Button();
        btnNavAbout = new Button();
        panelSideFooter = new Panel();
        lblNavHint = new Label();
        btnLogout = new Button();
        panelSideHeader = new Panel();
        lblSideSubtitle = new Label();
        lblBrand = new Label();
        panelTop = new Panel();
        tableTopBar = new TableLayoutPanel();
        lblBreadcrumb = new Label();
        lblBreadcrumbSub = new Label();
        lblUser = new Label();
        lblRole = new Label();
        panelContent = new Panel();
        panelSidebar.SuspendLayout();
        panelNavScroll.SuspendLayout();
        tableNav.SuspendLayout();
        panelSideFooter.SuspendLayout();
        panelSideHeader.SuspendLayout();
        panelTop.SuspendLayout();
        tableTopBar.SuspendLayout();
        SuspendLayout();
        // 
        // panelSidebar
        // 
        panelSidebar.BackColor = Color.FromArgb(10, 22, 42);
        panelSidebar.Controls.Add(lblNavCaption);
        panelSidebar.Controls.Add(panelNavScroll);
        panelSidebar.Controls.Add(panelSideFooter);
        panelSidebar.Controls.Add(panelSideHeader);
        panelSidebar.Dock = DockStyle.Left;
        panelSidebar.Location = new Point(0, 0);
        panelSidebar.Margin = new Padding(3, 4, 3, 4);
        panelSidebar.Name = "panelSidebar";
        panelSidebar.Padding = new Padding(16);
        panelSidebar.Size = new Size(268, 679);
        panelSidebar.TabIndex = 0;
        panelSidebar.Paint += panelSidebar_Paint;
        // 
        // lblNavCaption
        // 
        lblNavCaption.AutoSize = true;
        lblNavCaption.Font = new Font("Bahnschrift", 7.25F, FontStyle.Bold);
        lblNavCaption.ForeColor = Color.FromArgb(148, 163, 184);
        lblNavCaption.Location = new Point(165, 9);
        lblNavCaption.Name = "lblNavCaption";
        lblNavCaption.Size = new Size(84, 16);
        lblNavCaption.TabIndex = 0;
        lblNavCaption.Text = "ĐIỀU HƯỚNG";
        lblNavCaption.Click += lblNavCaption_Click;
        // 
        // panelNavScroll
        // 
        panelNavScroll.AutoScroll = true;
        panelNavScroll.BackColor = Color.FromArgb(10, 22, 42);
        panelNavScroll.Controls.Add(tableNav);
        panelNavScroll.Dock = DockStyle.Fill;
        panelNavScroll.Location = new Point(16, 104);
        panelNavScroll.Margin = new Padding(3, 4, 3, 4);
        panelNavScroll.Name = "panelNavScroll";
        panelNavScroll.Padding = new Padding(0, 11, 0, 11);
        panelNavScroll.Size = new Size(236, 410);
        panelNavScroll.TabIndex = 1;
        // 
        // tableNav
        // 
        tableNav.AutoSize = true;
        tableNav.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tableNav.BackColor = Color.FromArgb(10, 22, 42);
        tableNav.ColumnCount = 1;
        tableNav.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableNav.Controls.Add(btnNavDashboard, 0, 0);
        tableNav.Controls.Add(btnNavTickets, 0, 1);
        tableNav.Controls.Add(btnNavKhoa, 0, 2);
        tableNav.Controls.Add(btnNavDanhBa, 0, 3);
        tableNav.Controls.Add(btnNavHuongDan, 0, 4);
        tableNav.Controls.Add(btnNavAbout, 0, 5);
        tableNav.Dock = DockStyle.Top;
        tableNav.Location = new Point(0, 11);
        tableNav.Margin = new Padding(3, 4, 3, 4);
        tableNav.Name = "tableNav";
        tableNav.RowCount = 6;
        tableNav.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        tableNav.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        tableNav.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        tableNav.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        tableNav.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        tableNav.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
        tableNav.Size = new Size(215, 414);
        tableNav.TabIndex = 0;
        // 
        // btnNavDashboard
        // 
        btnNavDashboard.Location = new Point(3, 4);
        btnNavDashboard.Margin = new Padding(3, 4, 3, 4);
        btnNavDashboard.Name = "btnNavDashboard";
        btnNavDashboard.Size = new Size(86, 31);
        btnNavDashboard.TabIndex = 0;
        // 
        // btnNavTickets
        // 
        btnNavTickets.Location = new Point(3, 73);
        btnNavTickets.Margin = new Padding(3, 4, 3, 4);
        btnNavTickets.Name = "btnNavTickets";
        btnNavTickets.Size = new Size(86, 31);
        btnNavTickets.TabIndex = 1;
        // 
        // btnNavKhoa
        // 
        btnNavKhoa.Location = new Point(3, 142);
        btnNavKhoa.Margin = new Padding(3, 4, 3, 4);
        btnNavKhoa.Name = "btnNavKhoa";
        btnNavKhoa.Size = new Size(86, 31);
        btnNavKhoa.TabIndex = 2;
        // 
        // btnNavDanhBa
        // 
        btnNavDanhBa.Location = new Point(3, 211);
        btnNavDanhBa.Margin = new Padding(3, 4, 3, 4);
        btnNavDanhBa.Name = "btnNavDanhBa";
        btnNavDanhBa.Size = new Size(86, 31);
        btnNavDanhBa.TabIndex = 3;
        // 
        // btnNavHuongDan
        // 
        btnNavHuongDan.Location = new Point(3, 280);
        btnNavHuongDan.Margin = new Padding(3, 4, 3, 4);
        btnNavHuongDan.Name = "btnNavHuongDan";
        btnNavHuongDan.Size = new Size(86, 31);
        btnNavHuongDan.TabIndex = 4;
        // 
        // btnNavAbout
        // 
        btnNavAbout.Location = new Point(3, 349);
        btnNavAbout.Margin = new Padding(3, 4, 3, 4);
        btnNavAbout.Name = "btnNavAbout";
        btnNavAbout.Size = new Size(86, 31);
        btnNavAbout.TabIndex = 5;
        // 
        // panelSideFooter
        // 
        panelSideFooter.BackColor = Color.FromArgb(7, 16, 32);
        panelSideFooter.Controls.Add(lblNavHint);
        panelSideFooter.Controls.Add(btnLogout);
        panelSideFooter.Dock = DockStyle.Bottom;
        panelSideFooter.Location = new Point(16, 514);
        panelSideFooter.Margin = new Padding(3, 4, 3, 4);
        panelSideFooter.Name = "panelSideFooter";
        panelSideFooter.Padding = new Padding(11, 11, 11, 13);
        panelSideFooter.Size = new Size(236, 149);
        panelSideFooter.TabIndex = 2;
        // 
        // lblNavHint
        // 
        lblNavHint.Dock = DockStyle.Top;
        lblNavHint.ForeColor = Color.FromArgb(148, 163, 184);
        lblNavHint.Location = new Point(11, 11);
        lblNavHint.Name = "lblNavHint";
        lblNavHint.Padding = new Padding(0, 0, 0, 11);
        lblNavHint.Size = new Size(214, 69);
        lblNavHint.TabIndex = 0;
        lblNavHint.Text = "Gợi ý theo vai trò.";
        // 
        // btnLogout
        // 
        btnLogout.BackColor = Color.FromArgb(22, 48, 72);
        btnLogout.Dock = DockStyle.Bottom;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 62, 92);
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.Font = new Font("Bahnschrift SemiBold", 10F);
        btnLogout.ForeColor = Color.FromArgb(248, 250, 252);
        btnLogout.Location = new Point(11, 80);
        btnLogout.Margin = new Padding(3, 4, 3, 4);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(214, 56);
        btnLogout.TabIndex = 1;
        btnLogout.Text = "Đăng xuất";
        btnLogout.UseVisualStyleBackColor = false;
        btnLogout.Click += BtnLogout_Click;
        // 
        // panelSideHeader
        // 
        panelSideHeader.BackColor = Color.FromArgb(7, 16, 32);
        panelSideHeader.Controls.Add(lblSideSubtitle);
        panelSideHeader.Controls.Add(lblBrand);
        panelSideHeader.Dock = DockStyle.Top;
        panelSideHeader.Location = new Point(16, 16);
        panelSideHeader.Margin = new Padding(3, 4, 3, 4);
        panelSideHeader.Name = "panelSideHeader";
        panelSideHeader.Padding = new Padding(14, 19, 14, 16);
        panelSideHeader.Size = new Size(236, 88);
        panelSideHeader.TabIndex = 0;
        // 
        // lblSideSubtitle
        // 
        lblSideSubtitle.AutoSize = true;
        lblSideSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblSideSubtitle.Location = new Point(14, 56);
        lblSideSubtitle.Name = "lblSideSubtitle";
        lblSideSubtitle.Size = new Size(158, 20);
        lblSideSubtitle.TabIndex = 1;
        lblSideSubtitle.Text = "Hệ thống ticket nội bộ";
        // 
        // lblBrand
        // 
        lblBrand.AutoSize = true;
        lblBrand.ForeColor = Color.FromArgb(248, 250, 252);
        lblBrand.Location = new Point(14, 19);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(80, 20);
        lblBrand.TabIndex = 2;
        lblBrand.Text = "HelpTicket";
        // 
        // panelTop
        // 
        panelTop.BackColor = Color.FromArgb(255, 253, 249);
        panelTop.Controls.Add(tableTopBar);
        panelTop.Dock = DockStyle.Top;
        panelTop.Location = new Point(268, 0);
        panelTop.Margin = new Padding(3, 4, 3, 4);
        panelTop.Name = "panelTop";
        panelTop.Padding = new Padding(27, 19, 27, 16);
        panelTop.Size = new Size(857, 104);
        panelTop.TabIndex = 1;
        panelTop.Paint += panelTop_Paint;
        // 
        // tableTopBar
        // 
        tableTopBar.ColumnCount = 2;
        tableTopBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableTopBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 252F));
        tableTopBar.Controls.Add(lblBreadcrumb, 0, 0);
        tableTopBar.Controls.Add(lblBreadcrumbSub, 0, 1);
        tableTopBar.Controls.Add(lblUser, 1, 0);
        tableTopBar.Controls.Add(lblRole, 1, 1);
        tableTopBar.Dock = DockStyle.Fill;
        tableTopBar.Location = new Point(27, 19);
        tableTopBar.Margin = new Padding(0);
        tableTopBar.Name = "tableTopBar";
        tableTopBar.RowCount = 2;
        tableTopBar.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        tableTopBar.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tableTopBar.Size = new Size(803, 69);
        tableTopBar.TabIndex = 0;
        // 
        // lblBreadcrumb
        // 
        lblBreadcrumb.Dock = DockStyle.Fill;
        lblBreadcrumb.Font = new Font("Bahnschrift SemiBold", 12F);
        lblBreadcrumb.ForeColor = Color.FromArgb(15, 23, 42);
        lblBreadcrumb.Location = new Point(0, 0);
        lblBreadcrumb.Margin = new Padding(0, 0, 11, 0);
        lblBreadcrumb.Name = "lblBreadcrumb";
        lblBreadcrumb.Size = new Size(540, 34);
        lblBreadcrumb.TabIndex = 2;
        lblBreadcrumb.Text = "Trang";
        lblBreadcrumb.TextAlign = ContentAlignment.BottomLeft;
        lblBreadcrumb.Click += lblBreadcrumb_Click;
        // 
        // lblBreadcrumbSub
        // 
        lblBreadcrumbSub.Dock = DockStyle.Fill;
        lblBreadcrumbSub.ForeColor = Color.FromArgb(91, 103, 122);
        lblBreadcrumbSub.Location = new Point(0, 36);
        lblBreadcrumbSub.Margin = new Padding(0, 2, 11, 0);
        lblBreadcrumbSub.Name = "lblBreadcrumbSub";
        lblBreadcrumbSub.Size = new Size(540, 33);
        lblBreadcrumbSub.TabIndex = 3;
        // 
        // lblUser
        // 
        lblUser.Dock = DockStyle.Fill;
        lblUser.Font = new Font("Bahnschrift SemiBold", 10.5F);
        lblUser.ForeColor = Color.FromArgb(15, 23, 42);
        lblUser.Location = new Point(551, 0);
        lblUser.Margin = new Padding(0);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(252, 34);
        lblUser.TabIndex = 0;
        lblUser.Text = "Họ tên";
        lblUser.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblRole
        // 
        lblRole.Dock = DockStyle.Fill;
        lblRole.ForeColor = Color.FromArgb(91, 103, 122);
        lblRole.Location = new Point(551, 36);
        lblRole.Margin = new Padding(0, 2, 0, 0);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(252, 33);
        lblRole.TabIndex = 1;
        lblRole.Text = "Vai trò";
        lblRole.TextAlign = ContentAlignment.MiddleRight;
        // 
        // panelContent
        // 
        panelContent.BackColor = Color.FromArgb(245, 242, 235);
        panelContent.Dock = DockStyle.Fill;
        panelContent.Location = new Point(268, 104);
        panelContent.Margin = new Padding(3, 4, 3, 4);
        panelContent.Name = "panelContent";
        panelContent.Padding = new Padding(14, 16, 14, 16);
        panelContent.Size = new Size(857, 575);
        panelContent.TabIndex = 2;
        panelContent.Paint += panelContent_Paint;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1125, 679);
        Controls.Add(panelContent);
        Controls.Add(panelTop);
        Controls.Add(panelSidebar);
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MinimumSize = new Size(1100, 750);
        Name = "FrmMain";
        StartPosition = FormStartPosition.Manual;
        Text = "HelpTicket";
        Load += FrmMain_Load;
        panelSidebar.ResumeLayout(false);
        panelSidebar.PerformLayout();
        panelNavScroll.ResumeLayout(false);
        panelNavScroll.PerformLayout();
        tableNav.ResumeLayout(false);
        panelSideFooter.ResumeLayout(false);
        panelSideHeader.ResumeLayout(false);
        panelSideHeader.PerformLayout();
        panelTop.ResumeLayout(false);
        tableTopBar.ResumeLayout(false);
        ResumeLayout(false);
    }

    private static void StyleNavButton(Button b, string text)
    {
        b.BackColor = UiTheme.NavIdle;
        b.Dock = DockStyle.Fill;
        b.FlatAppearance.BorderSize = 0;
        b.FlatAppearance.MouseOverBackColor = UiTheme.NavHover;
        b.FlatStyle = FlatStyle.Flat;
        b.Font = UiTheme.FontUi(10.25F);
        b.ForeColor = UiTheme.TextOnDark;
        b.Margin = new Padding(0, 0, 0, 8);
        b.TabIndex = 0;
        b.Text = text;
        b.TextAlign = ContentAlignment.MiddleLeft;
        b.UseVisualStyleBackColor = false;
    }
}
