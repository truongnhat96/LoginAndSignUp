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

namespace Login
{
    public partial class DataBase : Form
    {
        DataUser_Entities data = new DataUser_Entities();
        Random random = new Random();
        public DataBase()
        {
            InitializeComponent();
            load();
            BindingUpdate();
            dataGridView1.GridColor = Color.Blue;
            dataGridView1.ForeColor = Color.DarkMagenta;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void load()
        {
            var result = from db in data.ACCOUNT_USER
                         select db;
            dataGridView1.DataSource = result.ToList();
        }
        void BindingUpdate()
        {
            txtUsername.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "USERNAME", true, DataSourceUpdateMode.Never));
            txtPass.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "PASSWORD", true, DataSourceUpdateMode.Never));
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ACCOUNT_USER acc = new ACCOUNT_USER() { USERNAME = txtUsername.Text, PASSWORD = txtPass.Text, PHONE = "SDT" + random.Next(1, 1000).ToString() };
            string sdt = acc.PHONE;
            INFOR_USER in4 = new INFOR_USER() { NAME = "User" + random.Next(1, 1000).ToString(), PHONE = sdt };
            data.INFOR_USER.Add(in4);
            data.ACCOUNT_USER.Add(acc);
            data.SaveChanges();
        }

        private void btnSeeall_Click(object sender, EventArgs e)
        {
            var ansq = from db in data.ACCOUNT_USER
                       select new
                       {
                           id = db.INFOR_USER.ID,
                           name = db.INFOR_USER.NAME,
                           account = db.USERNAME,
                           pass = db.PASSWORD,
                           sdt = db.PHONE,
                           email = db.INFOR_USER.EMAIL
                       };
            dataGridView1.DataSource = ansq.ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var result = from db in data.ACCOUNT_USER
                         select db;
            dataGridView1.DataSource = result.ToList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedCells[0].OwningRow.Cells["PHONE"].Value.ToString();
                ACCOUNT_USER acc = data.ACCOUNT_USER.Find(id);
                INFOR_USER in4 = data.INFOR_USER.Find(id);
                data.ACCOUNT_USER.Remove(acc);
                data.INFOR_USER.Remove(in4);
                data.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DataBase", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedCells[0].OwningRow.Cells["PHONE"].Value.ToString();
            ACCOUNT_USER account = data.ACCOUNT_USER.Find(id);
            account.USERNAME = txtUsername.Text;
            account.PASSWORD = txtPass.Text;
            data.SaveChanges();
        }
    }
}
