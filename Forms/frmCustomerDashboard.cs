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
    public partial class frmCustomerDashboard : Form
    {
        public frmCustomerDashboard()
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
            lblTitle.Text = "Available Rooms";
         
            btnRooms.BackColor = Color.FromArgb(46, 51, 73);
            this.pnlFormLoader.Controls.Clear();
            frmRooms frmCamps_vrb = new frmRooms() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmCamps_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmCamps_vrb);
            frmCamps_vrb.Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Made Bookings";
         
            btnBookings.BackColor = Color.FromArgb(46, 51, 73);

            this.pnlFormLoader.Controls.Clear();
            frmMyBookings frmMyBookings_vrb = new frmMyBookings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmMyBookings_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmMyBookings_vrb);
            frmMyBookings_vrb.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "User Profile";
         
            btnProfile.BackColor = Color.FromArgb(46, 51, 73);

            this.pnlFormLoader.Controls.Clear();
            frmProfile frmProfile_vrb = new frmProfile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmProfile_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmProfile_vrb);
            frmProfile_vrb.Show();
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

        private void btnBookings_Leave(object sender, EventArgs e)
        {
            btnBookings.BackColor = Color.Transparent;
        }

        private void btnProfile_Leave(object sender, EventArgs e)
        {
            btnProfile.BackColor = Color.Transparent;
        }

        private void btnLogout_Leave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.Transparent;
        }

        private void frmCustomerDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
