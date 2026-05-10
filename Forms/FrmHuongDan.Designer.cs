using HelpTicket.Common;

namespace HelpTicket.Forms;

partial class FrmHuongDan
{
    private System.ComponentModel.IContainer components = null!;
    private Panel panelRoot = null!;
    private Label lblTitle = null!;
    private RichTextBox rtb = null!;

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
        rtb = new RichTextBox();
        panelRoot.SuspendLayout();
        SuspendLayout();
        panelRoot.BackColor = UiTheme.BgCanvas;
        panelRoot.Controls.Add(rtb);
        panelRoot.Controls.Add(lblTitle);
        panelRoot.Dock = DockStyle.Fill;
        panelRoot.Padding = new Padding(24, 24, 24, 20);
        lblTitle.AutoSize = true;
        lblTitle.Font = UiTheme.FontDisplay(13F);
        lblTitle.ForeColor = UiTheme.PrimaryInk;
        lblTitle.Location = new Point(20, 20);
        lblTitle.Text = "Hướng dẫn sử dụng";
        rtb.Anchor = AnchorStyles.None;
        rtb.BackColor = UiTheme.SurfaceElevated;
        rtb.BorderStyle = BorderStyle.None;
        rtb.Font = UiTheme.FontUi(10.25F);
        rtb.ForeColor = UiTheme.PrimaryInk;
        rtb.Location = new Point(20, 56);
        rtb.ReadOnly = true;
        rtb.Size = new Size(720, 420);
        rtb.TabStop = false;
        rtb.Text = "";
        panelRoot.ResumeLayout(false);
        panelRoot.PerformLayout();
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(panelRoot);
        Font = UiTheme.FontUi(9.25F);
        MinimumSize = new Size(560, 360);
        Name = "FrmHuongDan";
        Text = "Hướng dẫn";
        ResumeLayout(false);
    }
}
