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

    public partial class frmNewRoomAdminBooking : Form
    {
        database db = new database();
        int customerId, roomId;
        
        public frmNewRoomAdminBooking()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRoomId.Text != "" || txtPrice.Text != "" || txtTotalCost.Text != "" || txtTotalDays.Text != "" || cmbCustomer.Text != "")
            {
                string dob = DateFormatFixing(dtpODate.Value.ToShortDateString());
                booking booking = new booking(db.codeGenerator("bookings"), customerId, int.Parse(txtRoomId.Text),  dob, int.Parse(txtTotalDays.Text), float.Parse(txtTotalCost.Text), "On-going");
                if (booking.addBooking(booking))
                {
                    string query = "update room set status='Not Available' where id=" + roomId + "";
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
        private void selectUsers()
        {
            string query = "select * from user where type= 'customer'";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    
                    cmbCustomer.Items.Add(dr.ItemArray.GetValue(1).ToString());
                    cmbCustomer.DisplayMember = dr.ItemArray.GetValue(1).ToString();
                    cmbCustomer.ValueMember = dr.ItemArray.GetValue(0).ToString();
                }
            }
                
        }
        public string DateFormatFixing(string date)
        {
            string sysFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            return date = DateTime.ParseExact(date, sysFormat, System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
        }

        private void cmbCustomer_TabIndexChanged(object sender, EventArgs e)
        {
            string query = "select * from user where username='" + cmbCustomer.SelectedItem + "'";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow dr = ds.Tables[0].Rows[0];

                customerId = int.Parse(dr.ItemArray.GetValue(0).ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTotalDays_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTotalDays.Text != "")
            {
                float result = float.Parse(txtTotalDays.Text) * float.Parse(txtPrice.Text);
                txtTotalCost.Text = result.ToString();
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select * from user where username='" + cmbCustomer.SelectedItem + "'";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow dr = ds.Tables[0].Rows[0];

                customerId = int.Parse(dr.ItemArray.GetValue(0).ToString());
            }
        }

        private void frmNewRoomAdminBooking_Load(object sender, EventArgs e)
        {
            selectUsers();
            roomId = frmAdminRooms.roomId;
            txtRoomId.Text = frmAdminRooms.roomId.ToString();
            txtPrice.Text = frmAdminRooms.price.ToString();
        }
    }
}
