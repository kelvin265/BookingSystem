using BookingSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;
using BookingSystem.Forms;

namespace BookingSystem
{
    public partial class frmLogin : Form
    {
        database db = new database();
        public static string username;
        public static int userId;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtLUsername.Text != "" && txtLPassword.Text != "")
            {
                db.openConnection();
                string query = "select * from user where username='" + txtLUsername.Text + "' AND password='" + txtLPassword.Text + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, db.Con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.closeConnection();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string type = ds.Tables[0].Rows[0][5].ToString();
                    userId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    username = txtLUsername.Text;

                    if (type == "admin")
                    {
                        this.Hide();
                        frmAdminDashboard frm = new frmAdminDashboard();
                        frm.Show();
                    }
                    else
                    {
                        this.Hide();
                        frmCustomerDashboard frm = new frmCustomerDashboard();
                        frm.Show();
                    }
                }
                else
                {

                    MessageBox.Show("failed  to login into the system", "Wrong Password or Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill the empty fields", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRegister frm = new frmRegister();
            frm.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
