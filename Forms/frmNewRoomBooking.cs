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
    public partial class frmNewRoomBooking : Form
    {
        database db = new database();
        public frmNewRoomBooking()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewRoomBooking_Load(object sender, EventArgs e)
        {
            txtRoomId.Text = frmRooms.roomId.ToString();
            txtPrice.Text = frmRooms.price.ToString();
        }

        private void txtTotalDays_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTotalDays.Text != "")
            {
                float result = float.Parse(txtTotalDays.Text) * float.Parse(txtPrice.Text);
                txtTotalCost.Text = result.ToString();
            }
        }

        public string DateFormatFixing(string date)
        {
            string sysFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            return date = DateTime.ParseExact(date, sysFormat, System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRoomId.Text != "" || txtPrice.Text != "" || txtTotalCost.Text != "" || txtTotalDays.Text != "")
            {
                string dob = DateFormatFixing(dtpODate.Value.ToShortDateString());
                booking booking = new booking(db.codeGenerator("bookings"), frmLogin.userId, int.Parse(txtRoomId.Text), dob, int.Parse(txtTotalDays.Text), float.Parse(txtTotalCost.Text), "On-going");
                if (booking.addBooking(booking))
                {
                    string query = "update room set status='Not Available' where id=" + frmRooms.roomId + "";
                    if (db.update(query))
                    {
                        MessageBox.Show("Booking made successfully", "Booking info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Failed to book room!", "Booking error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
