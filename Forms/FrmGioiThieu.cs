using System.Reflection;

namespace HelpTicket.Forms;

public partial class FrmGioiThieu : Form
{
    public FrmGioiThieu()
    {
        InitializeComponent();
        var ver = Assembly.GetExecutingAssembly().GetName().Version;
        lblVersion.Text = ver is null ? "" : $"Phiên bản {ver.Major}.{ver.Minor}.{ver.Build}";
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        LayoutGioiThieu();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LayoutGioiThieu();
    }

    private void LayoutGioiThieu()
    {
        if (!IsHandleCreated)
        {
            return;
        }

        var p = panelRoot.Padding;
        lblTitle.Location = new Point(p.Left, p.Top);
        lblVersion.Location = new Point(p.Left, lblTitle.Bottom + 8);
        var y = lblVersion.Bottom + 16;
        lblBody.Location = new Point(p.Left, y);
        lblBody.Size = new Size(
            Math.Max(100, panelRoot.ClientSize.Width - p.Horizontal),
            Math.Max(80, panelRoot.ClientSize.Height - y - p.Bottom));
    }
}
