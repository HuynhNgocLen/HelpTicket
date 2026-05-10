using HelpTicket.Common;
using HelpTicket.DAL;

namespace HelpTicket.Forms;

public partial class FrmLogin : Form
{
    private Panel? _underlineUser;
    private Panel? _underlinePass;

    public FrmLogin()
    {
        InitializeComponent();
        CenterCard();
        SetupControls();
    }

    private void SetupControls()
    {
        // Tạo bottom border cho TextBox (luôn hiện)
        _underlineUser = CreateUnderline(txtUser, 260 + 30 + 4);
        _underlinePass = CreateUnderline(txtPass, 365 + 30 + 4);
        
        panelCard.Controls.Add(_underlineUser);
        panelCard.Controls.Add(_underlinePass);
        
        // Cải thiện appearance của TextBox
        SetTextBoxStyle(txtUser, _underlineUser);
        SetTextBoxStyle(txtPass, _underlinePass);
        
        // Setup button hover effects
        SetupButtonHover(btnLogin, Color.FromArgb(13, 148, 136), Color.FromArgb(10, 110, 100));
        SetupButtonHover(btnExit, Color.FromArgb(255, 253, 249), Color.FromArgb(240, 240, 240));
    }

    private Panel CreateUnderline(TextBox textBox, int top)
    {
        var underline = new Panel
        {
            Height = 1,
            BackColor = Color.FromArgb(200, 200, 200),
            Location = new Point(91, top),
            Width = 376,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            Visible = true
        };
        return underline;
    }

    private void SetTextBoxStyle(TextBox textBox, Panel underline)
    {
        textBox.BackColor = Color.White;
        textBox.ForeColor = Color.FromArgb(15, 23, 42);
        textBox.BorderStyle = BorderStyle.None;
        
        textBox.Enter += (s, e) =>
        {
            underline.BackColor = Color.FromArgb(13, 148, 136);
            underline.Height = 2;
        };
        
        textBox.Leave += (s, e) =>
        {
            underline.BackColor = Color.FromArgb(200, 200, 200);
            underline.Height = 1;
        };
    }

    private void SetupButtonHover(Button btn, Color normalColor, Color hoverColor)
    {
        btn.BackColor = normalColor;
        btn.MouseEnter += (s, e) =>
        {
            btn.BackColor = hoverColor;
        };
        btn.MouseLeave += (s, e) =>
        {
            btn.BackColor = normalColor;
        };
    }

    private void FrmLogin_Resize(object? sender, EventArgs e) => CenterCard();

    private void CenterCard()
    {
        panelCard.Left = Math.Max(0, (ClientSize.Width - panelCard.Width) / 2);
        panelCard.Top = Math.Max(0, (ClientSize.Height - panelCard.Height) / 2);
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        var u = txtUser.Text.Trim();
        var p = txtPass.Text;
        if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
        {
            MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            var dal = new NguoiDungDAL();
            var nd = dal.DangNhap(u, p);
            if (nd is null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppSession.CurrentUser = nd;
            Hide();
            using var main = new FrmMain();
            main.ShowDialog();
            AppSession.Clear();
            Show();
            txtPass.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnExit_Click(object? sender, EventArgs e) => Close();

    private void ChkHienMatKhau_CheckedChanged(object? sender, EventArgs e)
    {
        txtPass.PasswordChar = chkHienMatKhau.Checked ? '\0' : '●';
    }

    private void FrmLogin_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BtnLogin_Click(sender, e);
        }
    }
}
