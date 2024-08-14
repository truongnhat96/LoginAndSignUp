using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Login.login;

namespace Login
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeenPass.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
        }


        private void lblForgetpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Get_password gp = new Get_password();
            gp.ShowDialog();
        }

        private void lblSign_in_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register_acc acc = new register_acc();
            acc.ShowDialog();
        }

        private void btnLog_in_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtUsername.Text == "Username" || txtPassword.Text == "Password")
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không được để trống!", "Error ╯︿╰", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User_SignIn user = new User_SignIn(txtUsername.Text, txtPassword.Text);
            user.ConnectToSqlServer(ConnectionStrings.Name);
            errorProvider1.Clear();
            if(user.User_name != "")
            {
                if(user.User_name != txtUsername.Text)
                {
                    Console.WriteLine(user.User_name);
                    errorProvider1.SetError(txtUsername, "Tên tài khoản không tồn tại");
                    return;
                }
                if(user.Password != txtPassword.Text)
                {
                    errorProvider1.SetError(txtPassword, "Sai mật khẩu! Vui lòng thử lại");
                    return;
                }
                DialogResult r = MessageBox.Show("Đăng nhập thành công\nBạn có muốn mở ứng dụng ngay bây giờ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if(r == DialogResult.OK)
                {
                    this.Hide();
                    App app = new App(user.Name, user.User_name);
                    app.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tài khoản không tồn tại!\nĐăng ký tài khoản mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    register_acc acc = new register_acc();
                    acc.ShowDialog();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

    }

    public interface IConnectDatabase
    {
        void ConnectToSqlServer(string ConnectionString);
    }

    public class User_SignIn : IConnectDatabase
    {
        private string user_name;
        private string password;
        public User_SignIn(string user_name, string password)
        {
            this.user_name = user_name;
            this.password = password;
        }

        public string Name { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }

        public void ConnectToSqlServer(string connectionString)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd1 = new SqlCommand(@"SELECT USERNAME,NAME FROM ACCOUNT_USER JOIN INFOR_USER ON ACCOUNT_USER.PHONE = INFOR_USER.PHONE WHERE USERNAME = @ACCOUNT", connect);
                cmd1.Parameters.Add(new SqlParameter("@ACCOUNT", SqlDbType.VarChar, 100)).Value = this.user_name;
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User_name = reader.GetString(0);
                        Name = reader.GetString(1);
                    }
                    else User_name = "";
                    
                }
                SqlCommand cmd2 = new SqlCommand("SELECT PASSWORD FROM ACCOUNT_USER WHERE USERNAME = @ACC",connect);
                cmd2.Parameters.Add(new SqlParameter("@ACC", SqlDbType.VarChar, 100)).Value = User_name;
                using (SqlDataReader Reader = cmd2.ExecuteReader())
                {
                    if(Reader.Read()) Password = Reader.GetString(0);
                }
            }
        }
    }

}
