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

namespace BookingSystem.Forms
{
    public partial class frmUpdateUser : Form
    {
        database db = new database();
        int id;
        public frmUpdateUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" || txtFullName.Text != "" || txtEmail.Text != "" || txtPhone.Text != "" || txtPassword.Text != "" || cmbType.Text != "")
            {


                user user = new user(id, txtUsername.Text, txtFullName.Text, txtEmail.Text, txtPhone.Text, cmbType.Text, txtPassword.Text);
                if (user.updateUser(user))
                {
                    MessageBox.Show("User updated successfully", "Update info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update user!", "Update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();

            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
            if (frmUsers.userId == 0)
            {
                id = frmLogin.userId;
                cmbType.Enabled = false;
            }
            else
            {
                id = frmUsers.userId;
            }
            selectUser();
        }

        private void selectUser()
        {
            string query = "select * from user where id = " + id + "";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                txtUsername.Text = dr.ItemArray.GetValue(1).ToString();
                txtFullName.Text = dr.ItemArray.GetValue(2).ToString();
                txtEmail.Text = dr.ItemArray.GetValue(3).ToString();
                txtPhone.Text = dr.ItemArray.GetValue(4).ToString();
                cmbType.Text = dr.ItemArray.GetValue(5).ToString();
                txtPassword.Text = dr.ItemArray.GetValue(6).ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
