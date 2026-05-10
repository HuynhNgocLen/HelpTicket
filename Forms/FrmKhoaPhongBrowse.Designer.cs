namespace HelpTicket.Forms;

partial class FrmKhoaPhongBrowse
{
    private System.ComponentModel.IContainer components = null!;

    // Layout
    private Panel panelRoot = null!;
    private Panel panelHeader = null!;
    private Panel panelStats = null!;
    private Panel panelToolbar = null!;
    private TableLayoutPanel tableToolbar = null!;
    private TableLayoutPanel tableStats = null!;
    private Panel panelContent = null!;

    // Header
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;

    // Stat cards
    private Panel cardTotal = null!;
    private Label lblTotalValue = null!;
    private Label lblTotalLabel = null!;
    private Label lblTotalSub = null!;

    private Panel cardActive = null!;
    private Label lblActiveValue = null!;
    private Label lblActiveLabel = null!;
    private Label lblActiveSub = null!;

    private Panel cardPaused = null!;
    private Label lblPausedValue = null!;
    private Label lblPausedLabel = null!;
    private Label lblPausedSub = null!;

    // Toolbar
    private TextBox txtSearch = null!;
    private Label lblSearchIcon = null!;
    private Panel panelSearch = null!;
    private Button btnFilter = null!;
    private Button btnRefresh = null!;
    private Button btnAdd = null!;
    private Button btnEdit = null!;
    private Button btnDelete = null!;

    // Grid
    private DataGridView dgv = null!;

    // Footer
    private Panel panelFooter = null!;
    private Label lblFooterInfo = null!;
    private Label lblTrang = null!;
    private Button btnTrangDau = null!;
    private Button btnTrangTruoc = null!;
    private Button btnTrangSau = null!;
    private Button btnTrangCuoi = null!;
    private ComboBox cboKichThuocTrang = null!;
    private Label lblKichThuocTrang = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        panelRoot = new Panel();
        panelContent = new Panel();
        panelFooter = new Panel();
        btnTrangCuoi = new Button();
        btnTrangSau = new Button();
        btnTrangTruoc = new Button();
        btnTrangDau = new Button();
        lblTrang = new Label();
        cboKichThuocTrang = new ComboBox();
        lblKichThuocTrang = new Label();
        lblFooterInfo = new Label();
        dgv = new DataGridView();
        panelToolbar = new Panel();
        tableToolbar = new TableLayoutPanel();
        panelSearch = new Panel();
        txtSearch = new TextBox();
        lblSearchIcon = new Label();
        btnFilter = new Button();
        btnRefresh = new Button();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        panelStats = new Panel();
        tableStats = new TableLayoutPanel();
        cardTotal = new Panel();
        cardActive = new Panel();
        cardPaused = new Panel();
        panelHeader = new Panel();
        lblSubtitle = new Label();
        lblTitle = new Label();
        lblTotalLabel = new Label();
        lblTotalValue = new Label();
        lblTotalSub = new Label();
        lblActiveLabel = new Label();
        lblActiveValue = new Label();
        lblActiveSub = new Label();
        lblPausedLabel = new Label();
        lblPausedValue = new Label();
        lblPausedSub = new Label();
        panelRoot.SuspendLayout();
        panelContent.SuspendLayout();
        panelFooter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        panelToolbar.SuspendLayout();
        tableToolbar.SuspendLayout();
        panelSearch.SuspendLayout();
        panelStats.SuspendLayout();
        tableStats.SuspendLayout();
        panelHeader.SuspendLayout();
        SuspendLayout();
        // 
        // panelRoot
        // 
        panelRoot.BackColor = Color.FromArgb(245, 242, 235);
        panelRoot.Controls.Add(panelContent);
        panelRoot.Controls.Add(panelToolbar);
        panelRoot.Controls.Add(panelStats);
        panelRoot.Controls.Add(panelHeader);
        panelRoot.Dock = DockStyle.Fill;
        panelRoot.Location = new Point(0, 0);
        panelRoot.Name = "panelRoot";
        panelRoot.Padding = new Padding(24);
        panelRoot.Size = new Size(1100, 660);
        panelRoot.TabIndex = 0;
        // 
        // panelContent
        // 
        panelContent.BackColor = Color.White;
        panelContent.BorderStyle = BorderStyle.FixedSingle;
        panelContent.Controls.Add(panelFooter);
        panelContent.Controls.Add(dgv);
        panelContent.Dock = DockStyle.Fill;
        panelContent.Location = new Point(24, 228);
        panelContent.Name = "panelContent";
        panelContent.Size = new Size(1052, 408);
        panelContent.TabIndex = 0;
        // 
        // panelFooter
        // 
        panelFooter.BackColor = Color.FromArgb(255, 253, 249);
        panelFooter.Controls.Add(lblFooterInfo);
        panelFooter.Controls.Add(lblTrang);
        panelFooter.Controls.Add(btnTrangDau);
        panelFooter.Controls.Add(btnTrangTruoc);
        panelFooter.Controls.Add(btnTrangSau);
        panelFooter.Controls.Add(btnTrangCuoi);
        panelFooter.Controls.Add(lblKichThuocTrang);
        panelFooter.Controls.Add(cboKichThuocTrang);
        panelFooter.Dock = DockStyle.Bottom;
        panelFooter.Location = new Point(0, 362);
        panelFooter.Name = "panelFooter";
        panelFooter.Padding = new Padding(12, 6, 12, 6);
        panelFooter.Size = new Size(1050, 48);
        panelFooter.TabIndex = 0;
        panelFooter.Visible = true;
        panelFooter.Resize += PanelFooter_Resize;
        // 
        // lblFooterInfo
        // 
        lblFooterInfo.AutoSize = false;
        lblFooterInfo.Dock = DockStyle.Left;
        lblFooterInfo.Font = new Font("Segoe UI", 8.5F);
        lblFooterInfo.ForeColor = Color.FromArgb(100, 116, 139);
        lblFooterInfo.Name = "lblFooterInfo";
        lblFooterInfo.Size = new Size(280, 32);
        lblFooterInfo.TabIndex = 0;
        lblFooterInfo.Text = "Hiển thị 0 đơn vị";
        lblFooterInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cboKichThuocTrang
        // 
        cboKichThuocTrang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        cboKichThuocTrang.DropDownStyle = ComboBoxStyle.DropDownList;
        cboKichThuocTrang.FlatStyle = FlatStyle.Flat;
        cboKichThuocTrang.Font = new Font("Segoe UI", 9F);
        cboKichThuocTrang.Items.AddRange(new object[] { "10", "20", "50", "100" });
        cboKichThuocTrang.Name = "cboKichThuocTrang";
        cboKichThuocTrang.Size = new Size(64, 24);
        cboKichThuocTrang.TabIndex = 7;
        cboKichThuocTrang.SelectedIndexChanged += CboKichThuocTrang_SelectedIndexChanged;
        // 
        // lblKichThuocTrang
        // 
        lblKichThuocTrang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblKichThuocTrang.AutoSize = true;
        lblKichThuocTrang.Font = new Font("Segoe UI", 8.5F);
        lblKichThuocTrang.ForeColor = Color.FromArgb(100, 116, 139);
        lblKichThuocTrang.Name = "lblKichThuocTrang";
        lblKichThuocTrang.Text = "Cỡ trang:";
        lblKichThuocTrang.TabIndex = 6;
        // 
        // btnTrangCuoi
        // 
        btnTrangCuoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnTrangCuoi.BackColor = Color.White;
        btnTrangCuoi.Cursor = Cursors.Hand;
        btnTrangCuoi.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnTrangCuoi.FlatStyle = FlatStyle.Flat;
        btnTrangCuoi.Font = new Font("Segoe UI", 9F);
        btnTrangCuoi.ForeColor = Color.FromArgb(71, 85, 105);
        btnTrangCuoi.Name = "btnTrangCuoi";
        btnTrangCuoi.Size = new Size(34, 26);
        btnTrangCuoi.TabIndex = 5;
        btnTrangCuoi.Text = "⏭";
        btnTrangCuoi.UseVisualStyleBackColor = false;
        btnTrangCuoi.Click += BtnTrangCuoi_Click;
        // 
        // btnTrangSau
        // 
        btnTrangSau.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnTrangSau.BackColor = Color.White;
        btnTrangSau.Cursor = Cursors.Hand;
        btnTrangSau.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnTrangSau.FlatStyle = FlatStyle.Flat;
        btnTrangSau.Font = new Font("Segoe UI", 9F);
        btnTrangSau.ForeColor = Color.FromArgb(71, 85, 105);
        btnTrangSau.Name = "btnTrangSau";
        btnTrangSau.Size = new Size(34, 26);
        btnTrangSau.TabIndex = 4;
        btnTrangSau.Text = "▶";
        btnTrangSau.UseVisualStyleBackColor = false;
        btnTrangSau.Click += BtnTrangSau_Click;
        // 
        // btnTrangTruoc
        // 
        btnTrangTruoc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnTrangTruoc.BackColor = Color.White;
        btnTrangTruoc.Cursor = Cursors.Hand;
        btnTrangTruoc.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnTrangTruoc.FlatStyle = FlatStyle.Flat;
        btnTrangTruoc.Font = new Font("Segoe UI", 9F);
        btnTrangTruoc.ForeColor = Color.FromArgb(71, 85, 105);
        btnTrangTruoc.Name = "btnTrangTruoc";
        btnTrangTruoc.Size = new Size(34, 26);
        btnTrangTruoc.TabIndex = 3;
        btnTrangTruoc.Text = "◀";
        btnTrangTruoc.UseVisualStyleBackColor = false;
        btnTrangTruoc.Click += BtnTrangTruoc_Click;
        // 
        // btnTrangDau
        // 
        btnTrangDau.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnTrangDau.BackColor = Color.White;
        btnTrangDau.Cursor = Cursors.Hand;
        btnTrangDau.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnTrangDau.FlatStyle = FlatStyle.Flat;
        btnTrangDau.Font = new Font("Segoe UI", 9F);
        btnTrangDau.ForeColor = Color.FromArgb(71, 85, 105);
        btnTrangDau.Name = "btnTrangDau";
        btnTrangDau.Size = new Size(34, 26);
        btnTrangDau.TabIndex = 2;
        btnTrangDau.Text = "⏮";
        btnTrangDau.UseVisualStyleBackColor = false;
        btnTrangDau.Click += BtnTrangDau_Click;
        // 
        // lblTrang
        // 
        lblTrang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTrang.AutoSize = false;
        lblTrang.Font = new Font("Segoe UI Semibold", 9F);
        lblTrang.ForeColor = Color.FromArgb(30, 41, 59);
        lblTrang.Name = "lblTrang";
        lblTrang.Size = new Size(140, 26);
        lblTrang.TabIndex = 1;
        lblTrang.Text = "Trang 1 / 1";
        lblTrang.TextAlign = ContentAlignment.MiddleRight;
        // 
        // dgv
        // 
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AllowUserToResizeRows = false;
        dgv.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dgv.BackgroundColor = Color.White;
        dgv.BorderStyle = BorderStyle.None;
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(228, 224, 214);
        dataGridViewCellStyle1.Font = new Font("Bahnschrift SemiBold", 9.25F);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(228, 224, 214);
        dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
        dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgv.ColumnHeadersHeight = 36;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.White;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(15, 23, 42);
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 251, 241);
        dataGridViewCellStyle2.SelectionForeColor = Color.Black;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgv.DefaultCellStyle = dataGridViewCellStyle2;
        dgv.EnableHeadersVisualStyles = false;
        dgv.GridColor = Color.FromArgb(210, 205, 196);
        dgv.Location = new Point(0, 0);
        dgv.MultiSelect = false;
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.RowHeadersVisible = false;
        dgv.RowHeadersWidth = 51;
        dgv.RowTemplate.Height = 36;
        dgv.ScrollBars = ScrollBars.Vertical;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.ShowCellToolTips = false;
        dgv.Size = new Size(1050, 200);
        dgv.TabIndex = 0;
        dgv.CellDoubleClick += Dgv_CellDoubleClick;
        dgv.SelectionChanged += Dgv_SelectionChanged;
        // 
        // panelToolbar
        // 
        panelToolbar.BackColor = Color.Transparent;
        panelToolbar.Controls.Add(tableToolbar);
        panelToolbar.Dock = DockStyle.Top;
        panelToolbar.Location = new Point(24, 176);
        panelToolbar.Name = "panelToolbar";
        panelToolbar.Padding = new Padding(0, 8, 0, 8);
        panelToolbar.Size = new Size(1052, 52);
        panelToolbar.TabIndex = 1;
        // 
        // tableToolbar
        // 
        tableToolbar.ColumnCount = 6;
        tableToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
        tableToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        tableToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
        tableToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
        tableToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
        tableToolbar.Controls.Add(panelSearch, 0, 0);
        tableToolbar.Controls.Add(btnFilter, 1, 0);
        tableToolbar.Controls.Add(btnRefresh, 2, 0);
        tableToolbar.Controls.Add(btnAdd, 3, 0);
        tableToolbar.Controls.Add(btnEdit, 4, 0);
        tableToolbar.Controls.Add(btnDelete, 5, 0);
        tableToolbar.Dock = DockStyle.Fill;
        tableToolbar.Location = new Point(0, 8);
        tableToolbar.Margin = new Padding(0);
        tableToolbar.Name = "tableToolbar";
        tableToolbar.RowCount = 1;
        tableToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableToolbar.Size = new Size(1052, 36);
        tableToolbar.TabIndex = 0;
        // 
        // panelSearch
        // 
        panelSearch.BackColor = Color.FromArgb(255, 253, 249);
        panelSearch.BorderStyle = BorderStyle.FixedSingle;
        panelSearch.Controls.Add(txtSearch);
        panelSearch.Controls.Add(lblSearchIcon);
        panelSearch.Dock = DockStyle.Fill;
        panelSearch.Location = new Point(0, 0);
        panelSearch.Margin = new Padding(0, 0, 10, 0);
        panelSearch.MinimumSize = new Size(120, 34);
        panelSearch.Name = "panelSearch";
        panelSearch.Size = new Size(544, 36);
        panelSearch.TabIndex = 0;
        // 
        // txtSearch
        // 
        txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtSearch.BorderStyle = BorderStyle.None;
        txtSearch.Font = new Font("Segoe UI", 9F);
        txtSearch.ForeColor = Color.FromArgb(30, 41, 59);
        txtSearch.Location = new Point(30, 8);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Tìm kiếm khoa, phòng...";
        txtSearch.Size = new Size(424, 20);
        txtSearch.TabIndex = 0;
        txtSearch.TextChanged += TxtSearch_TextChanged;
        txtSearch.KeyDown += TxtSearch_KeyDown;
        // 
        // lblSearchIcon
        // 
        lblSearchIcon.Font = new Font("Segoe UI", 10F);
        lblSearchIcon.ForeColor = Color.FromArgb(148, 163, 184);
        lblSearchIcon.Location = new Point(6, 7);
        lblSearchIcon.Name = "lblSearchIcon";
        lblSearchIcon.Size = new Size(20, 20);
        lblSearchIcon.TabIndex = 1;
        lblSearchIcon.Text = "🔍";
        // 
        // btnFilter
        // 
        btnFilter.BackColor = Color.White;
        btnFilter.Cursor = Cursors.Hand;
        btnFilter.Dock = DockStyle.Fill;
        btnFilter.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnFilter.FlatStyle = FlatStyle.Flat;
        btnFilter.Font = new Font("Segoe UI", 9F);
        btnFilter.ForeColor = Color.FromArgb(100, 116, 139);
        btnFilter.Location = new Point(554, 0);
        btnFilter.Margin = new Padding(0, 0, 8, 0);
        btnFilter.Name = "btnFilter";
        btnFilter.Size = new Size(84, 36);
        btnFilter.TabIndex = 1;
        btnFilter.Text = "⚙  Lọc";
        btnFilter.UseVisualStyleBackColor = false;
        btnFilter.Click += BtnFilter_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.BackColor = Color.White;
        btnRefresh.Cursor = Cursors.Hand;
        btnRefresh.Dock = DockStyle.Fill;
        btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnRefresh.FlatStyle = FlatStyle.Flat;
        btnRefresh.Font = new Font("Segoe UI", 9F);
        btnRefresh.ForeColor = Color.FromArgb(100, 116, 139);
        btnRefresh.Location = new Point(646, 0);
        btnRefresh.Margin = new Padding(0, 0, 8, 0);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(102, 36);
        btnRefresh.TabIndex = 2;
        btnRefresh.Text = "↻  Làm mới";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += BtnRefresh_Click;
        // 
        // btnAdd
        // 
        btnAdd.BackColor = Color.FromArgb(24, 95, 165);
        btnAdd.Cursor = Cursors.Hand;
        btnAdd.Dock = DockStyle.Fill;
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.FlatStyle = FlatStyle.Flat;
        btnAdd.Font = new Font("Segoe UI Semibold", 9F);
        btnAdd.ForeColor = Color.FromArgb(230, 241, 251);
        btnAdd.Location = new Point(756, 0);
        btnAdd.Margin = new Padding(0, 0, 8, 0);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(104, 36);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "+  Thêm mới";
        btnAdd.UseVisualStyleBackColor = false;
        btnAdd.Click += BtnAdd_Click;
        // 
        // btnEdit
        // 
        btnEdit.BackColor = Color.White;
        btnEdit.Cursor = Cursors.Hand;
        btnEdit.Dock = DockStyle.Fill;
        btnEdit.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnEdit.FlatStyle = FlatStyle.Flat;
        btnEdit.Font = new Font("Segoe UI Semibold", 9F);
        btnEdit.ForeColor = Color.FromArgb(24, 95, 165);
        btnEdit.Location = new Point(868, 0);
        btnEdit.Margin = new Padding(0, 0, 8, 0);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(84, 36);
        btnEdit.TabIndex = 4;
        btnEdit.Text = "✎  Sửa";
        btnEdit.UseVisualStyleBackColor = false;
        btnEdit.Click += BtnEdit_Click;
        // 
        // btnDelete
        // 
        btnDelete.BackColor = Color.White;
        btnDelete.Cursor = Cursors.Hand;
        btnDelete.Dock = DockStyle.Fill;
        btnDelete.FlatAppearance.BorderColor = Color.FromArgb(252, 165, 165);
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.Font = new Font("Segoe UI Semibold", 9F);
        btnDelete.ForeColor = Color.FromArgb(190, 18, 60);
        btnDelete.Location = new Point(960, 0);
        btnDelete.Margin = new Padding(0);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(92, 36);
        btnDelete.TabIndex = 5;
        btnDelete.Text = "🗑  Xóa";
        btnDelete.UseVisualStyleBackColor = false;
        btnDelete.Click += BtnDelete_Click;
        // 
        // panelStats
        // 
        panelStats.BackColor = Color.Transparent;
        panelStats.Controls.Add(tableStats);
        panelStats.Dock = DockStyle.Top;
        panelStats.Location = new Point(24, 84);
        panelStats.Name = "panelStats";
        panelStats.Padding = new Padding(0, 8, 0, 8);
        panelStats.Size = new Size(1052, 92);
        panelStats.TabIndex = 2;
        // 
        // tableStats
        // 
        tableStats.BackColor = Color.Transparent;
        tableStats.ColumnCount = 3;
        tableStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        tableStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        tableStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
        tableStats.Controls.Add(cardTotal, 0, 0);
        tableStats.Controls.Add(cardActive, 1, 0);
        tableStats.Controls.Add(cardPaused, 2, 0);
        tableStats.Dock = DockStyle.Fill;
        tableStats.Location = new Point(0, 8);
        tableStats.Margin = new Padding(0);
        tableStats.Name = "tableStats";
        tableStats.RowCount = 1;
        tableStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableStats.Size = new Size(1052, 76);
        tableStats.TabIndex = 0;
        // 
        // cardTotal
        // 
        cardTotal.Location = new Point(3, 3);
        cardTotal.Name = "cardTotal";
        cardTotal.Size = new Size(200, 70);
        cardTotal.TabIndex = 0;
        // 
        // cardActive
        // 
        cardActive.Location = new Point(353, 3);
        cardActive.Name = "cardActive";
        cardActive.Size = new Size(200, 70);
        cardActive.TabIndex = 1;
        // 
        // cardPaused
        // 
        cardPaused.Location = new Point(700, 0);
        cardPaused.Margin = new Padding(0);
        cardPaused.Name = "cardPaused";
        cardPaused.Size = new Size(200, 76);
        cardPaused.TabIndex = 2;
        // 
        // panelHeader
        // 
        panelHeader.BackColor = Color.Transparent;
        panelHeader.Controls.Add(lblSubtitle);
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(24, 24);
        panelHeader.Name = "panelHeader";
        panelHeader.Padding = new Padding(0, 0, 0, 8);
        panelHeader.Size = new Size(1052, 60);
        panelHeader.TabIndex = 3;
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9F);
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtitle.Location = new Point(2, 32);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(271, 20);
        lblSubtitle.TabIndex = 0;
        lblSubtitle.Text = "Quản lý thông tin đơn vị trong hệ thống";
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI Semibold", 13F);
        lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitle.Location = new Point(0, 4);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(255, 30);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "Danh mục khoa / phòng";
        // 
        // lblTotalLabel
        // 
        lblTotalLabel.Location = new Point(0, 0);
        lblTotalLabel.Name = "lblTotalLabel";
        lblTotalLabel.Size = new Size(100, 23);
        lblTotalLabel.TabIndex = 0;
        // 
        // lblTotalValue
        // 
        lblTotalValue.Location = new Point(0, 0);
        lblTotalValue.Name = "lblTotalValue";
        lblTotalValue.Size = new Size(100, 23);
        lblTotalValue.TabIndex = 0;
        // 
        // lblTotalSub
        // 
        lblTotalSub.Location = new Point(0, 0);
        lblTotalSub.Name = "lblTotalSub";
        lblTotalSub.Size = new Size(100, 23);
        lblTotalSub.TabIndex = 0;
        // 
        // lblActiveLabel
        // 
        lblActiveLabel.Location = new Point(0, 0);
        lblActiveLabel.Name = "lblActiveLabel";
        lblActiveLabel.Size = new Size(100, 23);
        lblActiveLabel.TabIndex = 0;
        // 
        // lblActiveValue
        // 
        lblActiveValue.Location = new Point(0, 0);
        lblActiveValue.Name = "lblActiveValue";
        lblActiveValue.Size = new Size(100, 23);
        lblActiveValue.TabIndex = 0;
        // 
        // lblActiveSub
        // 
        lblActiveSub.Location = new Point(0, 0);
        lblActiveSub.Name = "lblActiveSub";
        lblActiveSub.Size = new Size(100, 23);
        lblActiveSub.TabIndex = 0;
        // 
        // lblPausedLabel
        // 
        lblPausedLabel.Location = new Point(0, 0);
        lblPausedLabel.Name = "lblPausedLabel";
        lblPausedLabel.Size = new Size(100, 23);
        lblPausedLabel.TabIndex = 0;
        // 
        // lblPausedValue
        // 
        lblPausedValue.Location = new Point(0, 0);
        lblPausedValue.Name = "lblPausedValue";
        lblPausedValue.Size = new Size(100, 23);
        lblPausedValue.TabIndex = 0;
        // 
        // lblPausedSub
        // 
        lblPausedSub.Location = new Point(0, 0);
        lblPausedSub.Name = "lblPausedSub";
        lblPausedSub.Size = new Size(100, 23);
        lblPausedSub.TabIndex = 0;
        // 
        // FrmKhoaPhongBrowse
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 660);
        Controls.Add(panelRoot);
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(720, 520);
        Name = "FrmKhoaPhongBrowse";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Khoa / Phòng";
        panelRoot.ResumeLayout(false);
        panelContent.ResumeLayout(false);
        panelFooter.ResumeLayout(false);
        panelFooter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        panelToolbar.ResumeLayout(false);
        tableToolbar.ResumeLayout(false);
        panelSearch.ResumeLayout(false);
        panelSearch.PerformLayout();
        panelStats.ResumeLayout(false);
        tableStats.ResumeLayout(false);
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ResumeLayout(false);
    }

    // ──────────────────────────────────────────────
    // Helpers
    // ──────────────────────────────────────────────
    private static void BuildStatCard(
        Panel card, Label lblLabel, Label lblValue, Label lblSub,
        string labelText, string valueText, string subText,
        Color valueColor)
    {
        card.BackColor = Color.FromArgb(255, 253, 249);
        card.BorderStyle = BorderStyle.FixedSingle;
        card.Dock = DockStyle.Fill;
        card.Margin = new Padding(0, 0, 10, 0);
        card.MinimumSize = new Size(100, 72);
        card.Padding = new Padding(14, 10, 14, 10);
        card.Controls.Add(lblSub);
        card.Controls.Add(lblValue);
        card.Controls.Add(lblLabel);

        lblLabel.AutoSize = true;
        lblLabel.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        lblLabel.ForeColor = Color.FromArgb(100, 116, 139);
        lblLabel.Location = new Point(14, 10);
        lblLabel.Text = labelText;

        lblValue.AutoSize = true;
        lblValue.Font = new Font("Segoe UI Semibold", 16F);
        lblValue.ForeColor = valueColor;
        lblValue.Location = new Point(14, 26);
        lblValue.Text = valueText;

        lblSub.AutoSize = true;
        lblSub.Font = new Font("Segoe UI", 8F);
        lblSub.ForeColor = Color.FromArgb(148, 163, 184);
        lblSub.Location = new Point(14, 52);
        lblSub.Text = subText;
    }

    private static void BuildPageBtn(Button btn, string text, bool active, Point location, DockStyle dock)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderColor = active
            ? Color.FromArgb(24, 95, 165)
            : Color.FromArgb(226, 232, 240);
        btn.FlatAppearance.BorderSize = 1;
        btn.BackColor = active ? Color.FromArgb(24, 95, 165) : Color.White;
        btn.ForeColor = active ? Color.FromArgb(230, 241, 251) : Color.FromArgb(100, 116, 139);
        btn.Font = new Font("Segoe UI", 9F);
        btn.Size = new Size(28, 28);
        btn.Dock = dock;
        btn.Margin = new Padding(2, 0, 0, 0);
        btn.Text = text;
        btn.Cursor = Cursors.Hand;
    }
}