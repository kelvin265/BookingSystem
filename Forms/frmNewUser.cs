using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookingSystem.Helpers;
using BookingSystem.Classes;

namespace BookingSystem.Forms
{
    public partial class frmNewUser : Form
    {
        database db = new database();
        public frmNewUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" || txtFullName.Text != "" || txtEmail.Text != "" || txtPhone.Text != "" || txtPassword.Text != "" || cmbType.Text != "")
            {


                user user = new user(db.codeGenerator("user"), txtUsername.Text, txtFullName.Text, txtEmail.Text, txtPhone.Text, cmbType.Text, txtPassword.Text);
                if (user.addUser(user))
                {
                    MessageBox.Show("User registered successfully as a customer", "Register info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Failed to register the user !", "Register error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
    }
}
