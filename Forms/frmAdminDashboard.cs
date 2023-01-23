using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingSystem.Forms
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
            lblTitle.Text = "Customer Reviews";
            btnHome.BackColor = Color.Transparent;
            this.pnlFormLoader.Controls.Clear();
            frmHome frmHome_vrb = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmHome_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmHome_vrb);
            frmHome_vrb.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Customer Reviews";

            btnHome.BackColor = Color.FromArgb(46, 51, 73);

            this.pnlFormLoader.Controls.Clear();
            frmHome frmHome_vrb = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmHome_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmHome_vrb);
            frmHome_vrb.Show();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Rooms";

            btnRooms.BackColor = Color.FromArgb(46, 51, 73);
            this.pnlFormLoader.Controls.Clear();
            frmAdminRooms frmAdminCamps_vrb = new frmAdminRooms() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmAdminCamps_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmAdminCamps_vrb);
            frmAdminCamps_vrb.Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Bookings";

            btnBookings.BackColor = Color.FromArgb(46, 51, 73);

            this.pnlFormLoader.Controls.Clear();
            frmAllBookings frmAllBookings_vrb = new frmAllBookings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmAllBookings_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmAllBookings_vrb);
            frmAllBookings_vrb.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Users";

            btnProfile.BackColor = Color.FromArgb(46, 51, 73);

            this.pnlFormLoader.Controls.Clear();
            frmUsers frmUsers_vrb = new frmUsers() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmUsers_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmUsers_vrb);
            frmUsers_vrb.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            btnLogout.BackColor = Color.FromArgb(46, 51, 73);
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void btnHome_Leave(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.Transparent;
        }

        private void btnRooms_Leave(object sender, EventArgs e)
        {
            btnRooms.BackColor = Color.Transparent;
        }

        private void btnProfile_Leave(object sender, EventArgs e)
        {
            btnProfile.BackColor = Color.Transparent;
        }

        private void btnLogout_Leave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.Transparent;
        }

        private void btnBookings_Leave(object sender, EventArgs e)
        {
            btnBookings.BackColor = Color.Transparent;
        }
    }
}
