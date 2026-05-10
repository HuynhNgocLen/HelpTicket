using HelpTicket.Common;

namespace HelpTicket.Forms;

partial class FrmLogin
{
    private System.ComponentModel.IContainer components = null!;
    private Panel panelBackdrop = null!;
    private Panel panelCard = null!;
    private Label lblTitle = null!;
    private Label lblUser = null!;
    private TextBox txtUser = null!;
    private Label lblPass = null!;
    private TextBox txtPass = null!;
    private Button btnLogin = null!;
    private Button btnExit = null!;
    private Label lblHint = null!;
    private CheckBox chkHienMatKhau = null!;
    private Label lblBadge = null!;

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
        panelBackdrop = new Panel();
        panelCard = new Panel();
        lblBadge = new Label();
        chkHienMatKhau = new CheckBox();
        lblHint = new Label();
        btnExit = new Button();
        btnLogin = new Button();
        txtPass = new TextBox();
        lblPass = new Label();
        txtUser = new TextBox();
        lblUser = new Label();
        lblTitle = new Label();
        panelCard.SuspendLayout();
        SuspendLayout();
        // 
        // panelBackdrop
        // 
        panelBackdrop.Dock = DockStyle.Fill;
        panelBackdrop.Location = new Point(0, 0);
        panelBackdrop.Margin = new Padding(3, 4, 3, 4);
        panelBackdrop.Name = "panelBackdrop";
        panelBackdrop.Size = new Size(986, 725);
        panelBackdrop.TabIndex = 2;
        panelBackdrop.Paint += PanelBackdrop_Paint;
        // 
        // panelCard
        // 
        panelCard.Anchor = AnchorStyles.None;
        panelCard.BackColor = Color.FromArgb(255, 253, 249);
        panelCard.Controls.Add(lblBadge);
        panelCard.Controls.Add(chkHienMatKhau);
        panelCard.Controls.Add(lblHint);
        panelCard.Controls.Add(btnExit);
        panelCard.Controls.Add(btnLogin);
        panelCard.Controls.Add(txtPass);
        panelCard.Controls.Add(lblPass);
        panelCard.Controls.Add(txtUser);
        panelCard.Controls.Add(lblUser);
        panelCard.Controls.Add(lblTitle);
        panelCard.Location = new Point(276, 98);
        panelCard.Margin = new Padding(3, 4, 3, 4);
        panelCard.Name = "panelCard";
        panelCard.Padding = new Padding(46, 48, 46, 40);
        panelCard.Size = new Size(480, 560);
        panelCard.TabIndex = 0;
        panelCard.Paint += PanelCard_Paint;
        // 
        // lblBadge
        // 
        lblBadge.AutoSize = true;
        lblBadge.BackColor = Color.FromArgb(13, 148, 136);
        lblBadge.Font = new Font("Bahnschrift", 8.25F, FontStyle.Bold);
        lblBadge.ForeColor = Color.White;
        lblBadge.Location = new Point(49, 29);
        lblBadge.Name = "lblBadge";
        lblBadge.Padding = new Padding(14, 8, 14, 8);
        lblBadge.Size = new Size(106, 33);
        lblBadge.TabIndex = 8;
        lblBadge.Text = "HELPDESK";
        // 
        // chkHienMatKhau
        // 
        chkHienMatKhau.AutoSize = true;
        chkHienMatKhau.ForeColor = Color.FromArgb(91, 103, 122);
        chkHienMatKhau.Location = new Point(49, 364);
        chkHienMatKhau.Margin = new Padding(3, 4, 3, 4);
        chkHienMatKhau.Name = "chkHienMatKhau";
        chkHienMatKhau.Size = new Size(127, 24);
        chkHienMatKhau.TabIndex = 3;
        chkHienMatKhau.Text = "Hiện mật khẩu";
        chkHienMatKhau.UseVisualStyleBackColor = true;
        chkHienMatKhau.CheckedChanged += ChkHienMatKhau_CheckedChanged;
        // 
        // lblHint
        // 
        lblHint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblHint.ForeColor = Color.FromArgb(91, 103, 122);
        lblHint.Location = new Point(91, 995);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(549, 64);
        lblHint.TabIndex = 6;
        // 
        // btnExit
        // 
        btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnExit.Cursor = Cursors.Hand;
        btnExit.FlatAppearance.BorderColor = Color.FromArgb(218, 212, 202);
        btnExit.FlatStyle = FlatStyle.Flat;
        btnExit.ForeColor = Color.FromArgb(91, 103, 122);
        btnExit.Location = new Point(55, 483);
        btnExit.Margin = new Padding(3, 4, 3, 4);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(376, 48);
        btnExit.TabIndex = 5;
        btnExit.Text = "Thoát";
        btnExit.UseVisualStyleBackColor = true;
        btnExit.Click += BtnExit_Click;
        // 
        // btnLogin
        // 
        btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnLogin.BackColor = Color.FromArgb(13, 148, 136);
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 110, 100);
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Bahnschrift SemiBold", 11F);
        btnLogin.ForeColor = Color.White;
        btnLogin.Location = new Point(49, 419);
        btnLogin.Margin = new Padding(3, 4, 3, 4);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(376, 56);
        btnLogin.TabIndex = 4;
        btnLogin.Text = "Đăng nhập";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += BtnLogin_Click;
        // 
        // txtPass
        // 
        txtPass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtPass.BorderStyle = BorderStyle.None;
        txtPass.Font = new Font("Segoe UI", 10.5F);
        txtPass.Location = new Point(49, 299);
        txtPass.Margin = new Padding(7, 8, 7, 8);
        txtPass.Name = "txtPass";
        txtPass.PasswordChar = '●';
        txtPass.Size = new Size(376, 24);
        txtPass.TabIndex = 2;
        // 
        // lblPass
        // 
        lblPass.AutoSize = true;
        lblPass.ForeColor = Color.FromArgb(91, 103, 122);
        lblPass.Location = new Point(49, 254);
        lblPass.Name = "lblPass";
        lblPass.Size = new Size(70, 20);
        lblPass.TabIndex = 3;
        lblPass.Text = "Mật khẩu";
        // 
        // txtUser
        // 
        txtUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtUser.BorderStyle = BorderStyle.None;
        txtUser.Font = new Font("Segoe UI", 10.5F);
        txtUser.Location = new Point(49, 194);
        txtUser.Margin = new Padding(7, 8, 7, 8);
        txtUser.Name = "txtUser";
        txtUser.Size = new Size(376, 24);
        txtUser.TabIndex = 1;
        // 
        // lblUser
        // 
        lblUser.AutoSize = true;
        lblUser.ForeColor = Color.FromArgb(91, 103, 122);
        lblUser.Location = new Point(49, 149);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(107, 20);
        lblUser.TabIndex = 1;
        lblUser.Text = "Tên đăng nhập";
        // 
        // lblTitle
        // 
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Bahnschrift SemiBold", 15.75F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblTitle.Location = new Point(149, 80);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(143, 33);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Đăng nhập";
        // 
        // FrmLogin
        // 
        AcceptButton = btnLogin;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 242, 235);
        ClientSize = new Size(986, 725);
        Controls.Add(panelCard);
        Controls.Add(panelBackdrop);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        KeyPreview = true;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "HelpTicket — Đăng nhập";
        KeyDown += FrmLogin_KeyDown;
        Resize += FrmLogin_Resize;
        panelCard.ResumeLayout(false);
        panelCard.PerformLayout();
        ResumeLayout(false);
    }

    private void PanelBackdrop_Paint(object sender, PaintEventArgs e)
    {
        if (sender is not Panel p)
        {
            return;
        }

        UiTheme.PaintSoftGradient(p, e, Color.FromArgb(7, 26, 46), UiTheme.BgCanvas);
        
        using var brush = new SolidBrush(Color.FromArgb(28, UiTheme.AccentTeal));
        var w = Math.Min(380, p.Width / 2 + 40);
        e.Graphics.FillEllipse(brush, -120, p.Height - 280, w + 200, 360);
        
        using var brushLight = new SolidBrush(Color.FromArgb(20, UiTheme.AccentTeal));
        e.Graphics.FillEllipse(brushLight, p.Width - 150, -100, 280, 280);
    }

    private void PanelCard_Paint(object sender, PaintEventArgs e)
    {
        if (sender is not Panel card)
        {
            return;
        }

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        
        var radius = 12;
        var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
        
        using var path = new System.Drawing.Drawing2D.GraphicsPath();
        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
        path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
        path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
        path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
        path.CloseFigure();
        
        // Vẽ border rounded
        using var pen = new Pen(UiTheme.BorderHairline, 1.5F);
        e.Graphics.DrawPath(pen, path);
    }
}
