using HelpTicket.Common;

namespace HelpTicket.Forms;

partial class FrmGioiThieu
{
    private System.ComponentModel.IContainer components = null!;
    private Panel panelRoot = null!;
    private Label lblTitle = null!;
    private Label lblVersion = null!;
    private Label lblBody = null!;

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
        panelRoot = new Panel();
        lblTitle = new Label();
        lblVersion = new Label();
        lblBody = new Label();
        panelRoot.SuspendLayout();
        SuspendLayout();
        panelRoot.BackColor = UiTheme.BgCanvas;
        panelRoot.Controls.Add(lblBody);
        panelRoot.Controls.Add(lblVersion);
        panelRoot.Controls.Add(lblTitle);
        panelRoot.Dock = DockStyle.Fill;
        panelRoot.Padding = new Padding(28);
        lblTitle.AutoSize = true;
        lblTitle.Font = UiTheme.FontDisplay(16F);
        lblTitle.ForeColor = UiTheme.PrimaryInk;
        lblTitle.Location = new Point(28, 28);
        lblTitle.Text = "HelpTicket";
        lblVersion.AutoSize = true;
        lblVersion.Font = UiTheme.FontUi(9.25F);
        lblVersion.ForeColor = UiTheme.AccentTeal;
        lblVersion.Location = new Point(28, 60);
        lblVersion.Name = "lblVersion";
        lblVersion.Text = "Phiên bản";
        lblBody.Anchor = AnchorStyles.None;
        lblBody.AutoSize = false;
        lblBody.Font = UiTheme.FontUi(10.25F);
        lblBody.ForeColor = UiTheme.TextMuted;
        lblBody.Location = new Point(28, 100);
        lblBody.Size = new Size(700, 200);
        lblBody.Text = "Ứng dụng WinForms quản lý ticket helpdesk nội bộ (đăng nhập, phân quyền 3 lớp, CRUD ticket theo quyền).\r\n\r\n"
            + "Dự án thực hành Lập trình Windows — kết nối SQL Server qua Microsoft.Data.SqlClient.";
        panelRoot.ResumeLayout(false);
        panelRoot.PerformLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(panelRoot);
        Font = UiTheme.FontUi(9.25F);
        MinimumSize = new Size(480, 320);
        Name = "FrmGioiThieu";
        Text = "Giới thiệu";
        ResumeLayout(false);
    }
}
