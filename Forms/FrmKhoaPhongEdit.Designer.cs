namespace HelpTicket.Forms;

partial class FrmKhoaPhongEdit
{
    private System.ComponentModel.IContainer components = null!;

    private Panel panelRoot = null!;
    private Panel panelHeader = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;

    private TableLayoutPanel tableForm = null!;
    private Label lblMa = null!;
    private TextBox txtMa = null!;
    private Label lblTen = null!;
    private TextBox txtTen = null!;
    private Label lblGhiChu = null!;
    private TextBox txtGhiChu = null!;

    private Panel panelFooter = null!;
    private Button btnHuy = null!;
    private Button btnLuu = null!;

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
        lblTen = new Label();
        txtTen = new TextBox();
        lblGhiChu = new Label();
        txtGhiChu = new TextBox();
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
        panelRoot.Location = new Point(0, 0);
        panelRoot.Name = "panelRoot";
        panelRoot.Padding = new Padding(20);
        panelRoot.Size = new Size(1045, 588);
        panelRoot.TabIndex = 0;
        // 
        // tableForm
        // 
        tableForm.ColumnCount = 2;
        tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableForm.Controls.Add(lblMa, 0, 0);
        tableForm.Controls.Add(txtMa, 1, 0);
        tableForm.Controls.Add(lblTen, 0, 1);
        tableForm.Controls.Add(txtTen, 1, 1);
        tableForm.Controls.Add(lblGhiChu, 0, 2);
        tableForm.Controls.Add(txtGhiChu, 1, 2);
        tableForm.Dock = DockStyle.Fill;
        tableForm.Location = new Point(20, 76);
        tableForm.Name = "tableForm";
        tableForm.Padding = new Padding(0, 8, 0, 8);
        tableForm.RowCount = 3;
        tableForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        tableForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        tableForm.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableForm.Size = new Size(1005, 436);
        tableForm.TabIndex = 0;
        // 
        // lblMa
        // 
        lblMa.Anchor = AnchorStyles.Left;
        lblMa.AutoSize = true;
        lblMa.Font = new Font("Segoe UI", 9F);
        lblMa.ForeColor = Color.FromArgb(71, 85, 105);
        lblMa.Location = new Point(3, 17);
        lblMa.Name = "lblMa";
        lblMa.Size = new Size(30, 20);
        lblMa.TabIndex = 0;
        lblMa.Text = "Mã";
        // 
        // txtMa
        // 
        txtMa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtMa.BackColor = Color.FromArgb(241, 245, 249);
        txtMa.Font = new Font("Segoe UI", 10F);
        txtMa.Location = new Point(110, 13);
        txtMa.Margin = new Padding(0, 5, 0, 5);
        txtMa.Name = "txtMa";
        txtMa.ReadOnly = true;
        txtMa.Size = new Size(895, 30);
        txtMa.TabIndex = 1;
        // 
        // lblTen
        // 
        lblTen.Anchor = AnchorStyles.Left;
        lblTen.AutoSize = true;
        lblTen.Font = new Font("Segoe UI", 9F);
        lblTen.ForeColor = Color.FromArgb(71, 85, 105);
        lblTen.Location = new Point(3, 55);
        lblTen.Name = "lblTen";
        lblTen.Size = new Size(42, 20);
        lblTen.TabIndex = 2;
        lblTen.Text = "Tên *";
        // 
        // txtTen
        // 
        txtTen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtTen.Font = new Font("Segoe UI", 10F);
        txtTen.Location = new Point(110, 51);
        txtTen.Margin = new Padding(0, 5, 0, 5);
        txtTen.MaxLength = 100;
        txtTen.Name = "txtTen";
        txtTen.Size = new Size(895, 30);
        txtTen.TabIndex = 3;
        // 
        // lblGhiChu
        // 
        lblGhiChu.AutoSize = true;
        lblGhiChu.Font = new Font("Segoe UI", 9F);
        lblGhiChu.ForeColor = Color.FromArgb(71, 85, 105);
        lblGhiChu.Location = new Point(3, 92);
        lblGhiChu.Margin = new Padding(3, 8, 3, 0);
        lblGhiChu.Name = "lblGhiChu";
        lblGhiChu.Size = new Size(58, 20);
        lblGhiChu.TabIndex = 4;
        lblGhiChu.Text = "Ghi chú";
        // 
        // txtGhiChu
        // 
        txtGhiChu.Dock = DockStyle.Fill;
        txtGhiChu.Font = new Font("Segoe UI", 10F);
        txtGhiChu.Location = new Point(110, 89);
        txtGhiChu.Margin = new Padding(0, 5, 0, 5);
        txtGhiChu.MaxLength = 500;
        txtGhiChu.Multiline = true;
        txtGhiChu.Name = "txtGhiChu";
        txtGhiChu.ScrollBars = ScrollBars.Vertical;
        txtGhiChu.Size = new Size(895, 334);
        txtGhiChu.TabIndex = 5;
        // 
        // panelFooter
        // 
        panelFooter.Controls.Add(btnLuu);
        panelFooter.Controls.Add(btnHuy);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(20, 512);
        panelFooter.Name = "panelFooter";
        panelFooter.Padding = new Padding(0, 12, 0, 0);
        panelFooter.Size = new Size(1005, 56);
        panelFooter.TabIndex = 1;
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
        btnLuu.Location = new Point(1005, 12);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(112, 34);
        btnLuu.TabIndex = 0;
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
        btnHuy.Location = new Point(1005, 12);
        btnHuy.Name = "btnHuy";
        btnHuy.Size = new Size(96, 34);
        btnHuy.TabIndex = 1;
        btnHuy.Text = "Hủy";
        btnHuy.UseVisualStyleBackColor = false;
        // 
        // panelHeader
        // 
        panelHeader.Controls.Add(lblSubtitle);
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(20, 20);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(1005, 56);
        panelHeader.TabIndex = 2;
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9F);
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtitle.Location = new Point(2, 30);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(317, 20);
        lblSubtitle.TabIndex = 0;
        lblSubtitle.Text = "Nhập tên đơn vị (bắt buộc) và ghi chú nếu cần.";
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI Semibold", 13F);
        lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitle.Location = new Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(210, 30);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "Thêm khoa / phòng";
        // 
        // FrmKhoaPhongEdit
        // 
        AcceptButton = btnLuu;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnHuy;
        ClientSize = new Size(1045, 588);
        Controls.Add(panelRoot);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmKhoaPhongEdit";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Khoa / Phòng";
        panelRoot.ResumeLayout(false);
        tableForm.ResumeLayout(false);
        tableForm.PerformLayout();
        panelFooter.ResumeLayout(false);
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ResumeLayout(false);
    }
}
