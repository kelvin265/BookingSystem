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
    public partial class frmAmendBooking : Form
    {
        database db = new database();
        int id;
        public frmAmendBooking()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.Text != "" || txtRoomId.Text != "" || txtOpenDate.Text != "" || txtTotalDays.Text != "" || txtTotalCost.Text != "" || cmbStatus.Text != "")
            {
                booking booking = new booking(id, int.Parse(txtCustomerId.Text), int.Parse(txtRoomId.Text), txtOpenDate.Text, int.Parse(txtTotalDays.Text), float.Parse(txtTotalCost.Text), cmbStatus.Text);


                if (booking.updateBooking(booking))
                {
                    MessageBox.Show("Booking amended successfully", "Update info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to amend booking!", "Update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        private void frmAmendBooking_Load(object sender, EventArgs e)
        {
            if (frmAllBookings.type == "admin")
            {
                id = frmAllBookings.bookingId;
            }
            else if (frmMyBookings.type == "customer")
            {
                id = frmMyBookings.bookingId;
            }
            selectBooking();
        }

        private void selectBooking()
        {
            string query = "select * from bookings where id = " + id + "";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow dr = ds.Tables[0].Rows[0];
                txtCustomerId.Text = dr.ItemArray.GetValue(1).ToString();
                txtRoomId.Text = dr.ItemArray.GetValue(2).ToString();
                txtOpenDate.Text = dr.ItemArray.GetValue(3).ToString();
                txtTotalDays.Text = dr.ItemArray.GetValue(4).ToString();
                txtTotalCost.Text = dr.ItemArray.GetValue(5).ToString();
                cmbStatus.Text = dr.ItemArray.GetValue(6).ToString();
            }
        }
    }
}
