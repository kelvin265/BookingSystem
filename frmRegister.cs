using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookingSystem.Classes;
using BookingSystem.Helpers;
using BookingSystem.Forms;

namespace BookingSystem
{
    public partial class frmRegister : Form
    {
        database db = new database();
        public static string username;
        public static int userId;
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" || txtFullname.Text != "" || txtEmail.Text != "" || txtPhone.Text != "" ||  txtPassword.Text != "")
            {
                userId = db.codeGenerator("user");

                user user = new user(userId, txtUsername.Text, txtFullname.Text, txtEmail.Text, txtPhone.Text,"customer", txtPassword.Text);
                if (user.addUser(user))
                {
                    MessageBox.Show("User registered successfully as a customer", "Register info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmCustomerDashboard frm = new frmCustomerDashboard();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Failed to register the user !", "Register error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
    }
}
