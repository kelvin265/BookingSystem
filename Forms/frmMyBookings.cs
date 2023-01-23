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
    public partial class frmMyBookings : Form
    {
        database db = new database();
        public static int bookingId;
        public static string type;
        public frmMyBookings()
        {
            InitializeComponent();
        }

        private void frmMyBookings_Load(object sender, EventArgs e)
        {
            viewBookings();
        }

        public void viewBookings()
        {
            string query = "select * from bookings where customerId='" + frmLogin.userId + "'";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvBookings.Rows.Clear();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int n = dgvBookings.Rows.Add();
                    dgvBookings.Rows[n].Cells[0].Value = dr.ItemArray.GetValue(0).ToString();

                    dgvBookings.Rows[n].Cells[1].Value = dr.ItemArray.GetValue(1).ToString();
                    dgvBookings.Rows[n].Cells[2].Value = dr.ItemArray.GetValue(2).ToString();
                    dgvBookings.Rows[n].Cells[3].Value = dr.ItemArray.GetValue(3).ToString();
                    dgvBookings.Rows[n].Cells[4].Value = dr.ItemArray.GetValue(4).ToString();
                    dgvBookings.Rows[n].Cells[5].Value = dr.ItemArray.GetValue(5).ToString();
                    dgvBookings.Rows[n].Cells[6].Value = dr.ItemArray.GetValue(6).ToString();

                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            viewBookings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int index = 0;
            int count = dgvBookings.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i <= count - 1; i++)
                {
                    if (dgvBookings.Rows[i].Cells[7].Value != null)
                    {
                        if (row == 0)
                        {
                            row++;
                            index = i;
                        }
                        else
                        {

                            MessageBox.Show("Please select 1 booking to amend", "Booking info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvBookings.Rows.Clear();
                            viewBookings();
                            return;
                        }


                    }
                }
                if (row != 0)
                {

                    bookingId = int.Parse(dgvBookings.Rows[index].Cells[0].Value.ToString());
                    type = "customer";
                    frmAmendBooking frm = new frmAmendBooking();
                    frm.Show();


                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = dgvBookings.Rows.Count;
            int row = 0;
            if (count > 0)
            {
                for (int i = 0; i <= count - 1; i++)
                {
                    if (dgvBookings.Rows[i].Cells[7].Value != null)
                    {
                        row++;
                        booking booking = new booking(int.Parse(dgvBookings.Rows[i].Cells[0].Value.ToString()), frmLogin.userId, int.Parse(dgvBookings.Rows[i].Cells[1].Value.ToString()), dgvBookings.Rows[i].Cells[3].Value.ToString(), int.Parse(dgvBookings.Rows[i].Cells[4].Value.ToString()), float.Parse(dgvBookings.Rows[i].Cells[5].Value.ToString()), "Canceled");

                        if (booking.updateBooking(booking))
                        {

                        }
                    }
                }

            }
            if(row == 0)
            {
                MessageBox.Show("No bookings selected", "Booking error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
            viewBookings();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            int row = 0;
            int index = 0;
            int count = dgvBookings.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i <= count - 1; i++)
                {
                    if (dgvBookings.Rows[i].Cells[7].Value != null)
                    {
                        if (row == 0)
                        {
                            row++;
                            index = i;
                        }
                        else
                        {

                            MessageBox.Show("Please select 1 booking to check out", "Booking info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvBookings.Rows.Clear();
                            viewBookings();
                            return;
                        }


                    }
                }
                if (row != 0)
                {
                    if (dgvBookings.Rows[index].Cells[6].Value.ToString() == "On-going")
                    {
                        bookingId = int.Parse(dgvBookings.Rows[index].Cells[0].Value.ToString());

                        frmNewReview frm = new frmNewReview();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please select a booking that is on going ", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
