using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Login.login;

namespace Login
{
    public partial class register_acc : Form
    {
        public register_acc()
        {
            InitializeComponent();
            toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            toolTip1.ToolTipTitle = "Chú ý";
            toolTip1.UseAnimation = true;
            toolTip1.SetToolTip(lblNotifyUser, "Các trường hợp không được bỏ trống");
            toolTip1.SetToolTip(lblNotifyName, "Các trường hợp không được bỏ trống");
            toolTip1.SetToolTip(lblNotifyphone, "Các trường hợp không được bỏ trống");
            toolTip1.SetToolTip(lblNotifyconfirmPass, "Các trường hợp không được bỏ trống");
            toolTip1.SetToolTip(lblNotifypass, "Các trường hợp không được bỏ trống");
        }

        private void register_acc_Load(object sender, EventArgs e)
        {

        }

        private void chkSeen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeen.Checked)
               txtConfirmPass.PasswordChar = txtPassworduser.PasswordChar = '\0';
            else txtConfirmPass.PasswordChar = txtPassworduser.PasswordChar = '*';
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNameAcc.Text = txtUserName.Text = txtPassworduser.Text = txtConfirmPass.Text = txtEmail.Text = txtSdt.Text = "";
            errorProvider2.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {   
            errorProvider2.Clear();

            string tk = txtNameAcc.Text;
            if(tk == "" || !tk.Any(char.IsDigit) || !tk.Any(char.IsLetter) || tk.Any(char.IsWhiteSpace))
            {
                errorProvider2.SetError(txtNameAcc, "Tên tài khoản phải có ít nhất 1 chữ hoặc 1 số và không có khoảng trắng, không được để trống!");
                return;
            }

            if(txtUserName.Text == "")
            {
                errorProvider2.SetError(txtUserName, "Họ tên không được để trống!");
                return;
            }

            string sdt = txtSdt.Text;
            if(sdt == "" || sdt.Length != 10)
            {
                errorProvider2.SetError(txtSdt, "Số điện thoại không hợp lệ!");
                return;
            }

            string email = txtEmail.Text;
            if (email == "") email = null;
            else if (!email.Contains(".com") || email.Any(char.IsWhiteSpace) || email.Any(char.IsPunctuation))
            {
                if (email.Count(c => c == '@') != 1)
                {
                    errorProvider2.SetError(txtEmail, " Tên Email không hợp lệ!");
                    return;
                }
            }

            string mk = txtPassworduser.Text;
            if(!mk.Any(char.IsLetter) || !mk.Any(c => c == '!' || c == '@' || c == '#' || c == '$' || c == '%' || c == '^' || c == '&' || c == '*' || c == '(' || c == ')' || c == '-' || c == '_' || c == '+' || c == '=' || c == '[' || c == ']' || c == '{' || c == '}' || c == ':' || c == ';' || c == '"' || c == '\'' || c == '?' || c == '/' || c == '\\') || mk.Any(char.IsWhiteSpace) || mk.Length < 8)
            {
                errorProvider2.SetError(txtPassworduser, "Mật khẩu cần có ít nhất 8 ký tự\nMật khẩu phải bao gồm ít nhất 1 số, chữ cái và ký tự đặc biệt!");
                return;
            }

            if (txtConfirmPass.Text != txtPassworduser.Text)
            {
                errorProvider2.SetError(txtConfirmPass, "Dữ liệu mật khẩu không trùng khớp!");
                return;
            }

            ExitAccount account = new ExitAccount(txtNameAcc.Text, txtSdt.Text);
            account.ConnectToSqlServer("Server=.;Database=DATA_USER;Trusted_Connection=True;TrustServerCertificate=True;");
            if(account.GetAccounts.Count > 0)
            {
                foreach (ExitAccount acc in account.GetAccounts)
                {
                    if (acc.Username == txtNameAcc.Text) errorProvider2.SetError(txtNameAcc, "Tên tài khoản đã được sử dụng");
                    if (acc.Phonenumber == txtSdt.Text) MessageBox.Show("Số điện thoại đã tồn tại!", "Error ಥ_ಥ", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
                return;
            } 

            DialogResult result = MessageBox.Show("Xác nhận tạo tài khoản", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                InsertInfor user = new InsertInfor(txtNameAcc.Text, txtPassworduser.Text, txtSdt.Text, txtUserName.Text, email);
                user.ConnectToSqlServer("Server=.;Database=DATA_USER;Trusted_Connection=True;TrustServerCertificate=True;");
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }

    public class InsertInfor : IConnectDatabase
    {
        private string account;
        private string password;
        private string phone;
        private string name;
        private string email;
        public InsertInfor(string account, string password, string phone, string name, string email)
        {
            this.account = account;
            this.password = password;
            this.phone = phone;
            this.name = name;
            this.email = email;
        }
        //  public InsertInfor() { }
        public void ConnectToSqlServer(string ConnectionString)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                connect.Open();
                if (email != null)
                {
                    SqlCommand command = new SqlCommand(@"
                      INSERT INTO INFOR_USER
                      VALUES (@HOTEN, @PHONE, @EMAIL)
                      INSERT INTO ACCOUNT_USER
                      VALUES (@TENTK, @MATKHAU, @SDT) ", connect);
                    command.Parameters.Add(new SqlParameter("@HOTEN", SqlDbType.NVarChar, 100)).Value = this.name;
                    command.Parameters.Add(new SqlParameter("@PHONE", SqlDbType.VarChar, 10)).Value = this.phone;
                    command.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 50)).Value = this.email;
                    command.Parameters.Add(new SqlParameter("@TENTK", SqlDbType.VarChar, 100)).Value = this.account;
                    command.Parameters.Add(new SqlParameter("@MATKHAU", SqlDbType.VarChar, 100)).Value = this.password;
                    command.Parameters.Add(new SqlParameter("@SDT", SqlDbType.VarChar, 10)).Value = this.phone;
                    command.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand command = new SqlCommand(@"
                      INSERT INTO INFOR_USER
                      VALUES (@HOTEN, @PHONE, NULL)
                      INSERT INTO ACCOUNT_USER
                      VALUES (@TENTK, @MATKHAU, @SDT) ", connect);
                    command.Parameters.Add(new SqlParameter("@HOTEN", SqlDbType.NVarChar, 100)).Value = this.name;
                    command.Parameters.Add(new SqlParameter("@PHONE", SqlDbType.VarChar, 10)).Value = this.phone;
                    command.Parameters.Add(new SqlParameter("@TENTK", SqlDbType.VarChar, 100)).Value = this.account;
                    command.Parameters.Add(new SqlParameter("@MATKHAU", SqlDbType.VarChar, 100)).Value = this.password;
                    command.Parameters.Add(new SqlParameter("@SDT", SqlDbType.VarChar, 10)).Value = this.phone;
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class ExitAccount : IConnectDatabase
    {
        private string username;
        private string phonenumber;
        public ExitAccount(string username, string phonenumber)
        {
            this.Username = username;
            this.Phonenumber = phonenumber;
        }
        public ExitAccount() { }

        public List<ExitAccount> GetAccounts {get; set;}

        public string Username { get => username; set => username = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }

        public void ConnectToSqlServer(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"SELECT TENTK, SDT FROM ACCOUNT_USER
                                                    WHERE TENTK = @ACC OR SDT = @PHONE", connection);
                command.Parameters.Add(new SqlParameter("@ACC", SqlDbType.VarChar,100)).Value = this.Username;
                command.Parameters.Add(new SqlParameter("@PHONE",SqlDbType.VarChar, 10)).Value=this.Phonenumber;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GetAccounts = new List<ExitAccount>();
                    while (reader.Read())
                    {
                        GetAccounts.Add(new ExitAccount(reader.GetString(0), reader.GetString(1)));
                    }
                }
            }
        }
    }
}
