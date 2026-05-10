using HelpTicket.Common;

namespace HelpTicket.Forms;

partial class FrmDashboard
{
    private System.ComponentModel.IContainer components = null!;
    private Panel panelRoot = null!;
    private Label lblTitle = null!;
    private Button btnRefresh = null!;
    private TableLayoutPanel tableCards = null!;
    private Label lblValTong = null!;
    private Label lblValMo = null!;
    private Label lblValDangXuLy = null!;
    private Label lblValHoanThanh = null!;
    private Label lblValHuy = null!;

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
        tableCards = new TableLayoutPanel();
        btnRefresh = new Button();
        lblTitle = new Label();
        lblValTong = new Label();
        lblValMo = new Label();
        lblValDangXuLy = new Label();
        lblValHoanThanh = new Label();
        lblValHuy = new Label();
        panelRoot.SuspendLayout();
        SuspendLayout();
        // 
        // panelRoot
        // 
        panelRoot.BackColor = Color.FromArgb(245, 242, 235);
        panelRoot.Controls.Add(tableCards);
        panelRoot.Controls.Add(btnRefresh);
        panelRoot.Controls.Add(lblTitle);
        panelRoot.Dock = DockStyle.Fill;
        panelRoot.Location = new Point(0, 0);
        panelRoot.Margin = new Padding(3, 4, 3, 4);
        panelRoot.Name = "panelRoot";
        panelRoot.Padding = new Padding(23, 27, 23, 27);
        panelRoot.Size = new Size(1018, 685);
        panelRoot.TabIndex = 0;
        // 
        // tableCards
        // 
        tableCards.ColumnCount = 5;
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.33816F));
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.6142712F));
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.7849026F));
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.16546F));
        tableCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.097208F));
        tableCards.Location = new Point(26, 85);
        tableCards.Margin = new Padding(3, 4, 3, 4);
        tableCards.Name = "tableCards";
        tableCards.RowCount = 1;
        tableCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableCards.Size = new Size(967, 154);
        tableCards.TabIndex = 0;
        // 
        // btnRefresh
        // 
        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRefresh.BackColor = Color.FromArgb(13, 148, 136);
        btnRefresh.Cursor = Cursors.Hand;
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 118, 110);
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Bahnschrift SemiBold", 9.75F);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.Location = new Point(846, 31);
        btnRefresh.Margin = new Padding(3, 4, 3, 4);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(137, 45);
        btnRefresh.TabIndex = 1;
        btnRefresh.Text = "Làm mới";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += BtnRefresh_Click;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblTitle.Location = new Point(46, 53);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(120, 20);
        lblTitle.TabIndex = 2;
        lblTitle.Text = "Tổng quan ticket";
        // 
        // lblValTong
        // 
        lblValTong.Location = new Point(0, 0);
        lblValTong.Name = "lblValTong";
        lblValTong.Size = new Size(100, 23);
        lblValTong.TabIndex = 0;
        // 
        // lblValMo
        // 
        lblValMo.Location = new Point(0, 0);
        lblValMo.Name = "lblValMo";
        lblValMo.Size = new Size(100, 23);
        lblValMo.TabIndex = 0;
        // 
        // lblValDangXuLy
        // 
        lblValDangXuLy.Location = new Point(0, 0);
        lblValDangXuLy.Name = "lblValDangXuLy";
        lblValDangXuLy.Size = new Size(100, 23);
        lblValDangXuLy.TabIndex = 0;
        // 
        // lblValHoanThanh
        // 
        lblValHoanThanh.Location = new Point(0, 0);
        lblValHoanThanh.Name = "lblValHoanThanh";
        lblValHoanThanh.Size = new Size(100, 23);
        lblValHoanThanh.TabIndex = 0;
        // 
        // lblValHuy
        // 
        lblValHuy.Location = new Point(0, 0);
        lblValHuy.Name = "lblValHuy";
        lblValHuy.Size = new Size(100, 23);
        lblValHuy.TabIndex = 0;
        // 
        // FrmDashboard
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1018, 685);
        Controls.Add(panelRoot);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(720, 360);
        Name = "FrmDashboard";
        Text = "Tổng quan";
        panelRoot.ResumeLayout(false);
        panelRoot.PerformLayout();
        ResumeLayout(false);
    }

    private static void StyleValueLabel(Label lbl)
    {
        lbl.AutoSize = false;
        lbl.Dock = DockStyle.Top;
        lbl.Font = new Font("Bahnschrift SemiBold", 24F);
        lbl.ForeColor = UiTheme.PrimaryInk;
        lbl.Height = 48;
        lbl.Text = "0";
        lbl.TextAlign = ContentAlignment.MiddleCenter;
    }

    private Panel MakeCard(string caption, Label valueLbl, Color accentStripe)
    {
        var p = new Panel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(7),
            BackColor = UiTheme.Surface,
            Padding = new Padding(14, 16, 14, 14)
        };
        p.Paint += (_, e) =>
        {
            using var pen = new Pen(UiTheme.BorderHairline, 1);
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            using var b = new SolidBrush(accentStripe);
            e.Graphics.FillRectangle(b, 0, 0, 5, p.Height);
        };
        var cap = new Label
        {
            Dock = DockStyle.Top,
            Font = UiTheme.FontUi(9F),
            ForeColor = UiTheme.TextMuted,
            Height = 24,
            Text = caption,
            TextAlign = ContentAlignment.MiddleCenter
        };
        valueLbl.Dock = DockStyle.Fill;
        p.Controls.Add(cap);
        p.Controls.Add(valueLbl);
        return p;
    }
}
