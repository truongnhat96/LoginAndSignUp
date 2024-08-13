using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }
        public App(string Tennguoidung, string AccountName)
        {
            InitializeComponent();
            this.Tennguoidung = Tennguoidung;
            this.AccountName = AccountName;

            toolTip1.SetToolTip(lblDatabaseview, "Chỉ quản trị viên");
        }
        private void App_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Xin chào {Tennguoidung}";
        }

        private void lblContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/profile.php?id=100031933698842");
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Tài khoản hiện tại sẽ đăng xuất!\nBạn có chắc muốn thoát?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r == DialogResult.OK) e.Cancel = false;
            else e.Cancel = true;
        }

        private void lblDatabaseview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(AccountName == "ADMIN123")
            {
                DataBase csdl = new DataBase();
                csdl.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền làm việc này!\nVui lòng liên hệ admin để biết thêm thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
