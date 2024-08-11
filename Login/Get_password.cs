using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Get_password : Form
    {
        public Get_password()
        {
            InitializeComponent();
            btnGetmk.Visible = false;
        }
        int time = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                lblTime.Text = $"Vui lòng chờ trong {time} giây";
                --time;
            }
            else
            {
                lblTime.Visible = false;
                btnGetmk.Visible = true;
                timer1.Enabled = false;
            }
        }

        private void btnMk_Click(object sender, EventArgs e)
        {
            errorProvider3.Clear();
            if(rtxtPhone.Text.Length != 10)
            {
                errorProvider3.SetError(rtxtPhone, "Số điện thoại không hợp lệ");
                return;
            }
            if (time > 0)
            {
                timer1.Enabled = true;
                lblTime.Visible = true;
            }
            else
            {
                GetPass pass = new GetPass(rtxtPhone.Text);
                pass.ConnectToSqlServer("Server=.;Database=DATA_USER;Trusted_Connection=True;TrustServerCertificate=True;");
                if (pass.password == null)
                {
                    MessageBox.Show("Số điện thoại không tồn tại!", "Error ⊙﹏⊙∥", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnGetmk.Visible = false;
                    btnMk.Visible = false;
                    lblMatKhau.Text = $"Mật khẩu của bạn là:\n {pass.password}";
                }
            }
        }

        private void btnGetmk_Click(object sender, EventArgs e)
        {
            btnMk.PerformClick();
        }

    }
    public class GetPass : IConnectDatabase
    {
        private string phone;
        public GetPass(string phone)
        {
            this.phone = phone;
        }
        public string password { get; set; }
        public void ConnectToSqlServer(string connectionstring)
        {
            using (SqlConnection connect = new SqlConnection(connectionstring))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT MATKHAU FROM ACCOUNT_USER WHERE SDT = @PHONE", connect);
                cmd.Parameters.Add(new SqlParameter("@PHONE", SqlDbType.VarChar, 10)).Value = phone;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        password = reader.GetString(0);
                    }
                }
            }
        }
    }
}
