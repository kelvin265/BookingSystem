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
    public partial class frmNewReview : Form
    {
        public int customerId, bookingId;
        database db = new database();
        public frmNewReview()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtReview.Text != "")
            {
                string date = DateFormatFixing(DateTime.Now.ToShortDateString());
                review review = new review(db.codeGenerator("reviews"), customerId, bookingId, date, txtReview.Text);


                if (review.addReview(review))
                {
                    string query = "update bookings set status='Complete' where id=" + bookingId + "";
                    if (db.update(query))
                    {
                        selectBoooking(bookingId);
                        MessageBox.Show("Feedback imserted successfully", "Review info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("Failed to insert feedback", "Update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
        void selectBoooking(int bookingId)
        {
            string query = "select * from bookings where id = " + bookingId + "";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                string query1 = "update room set status='Available' where id=" + int.Parse(ds.Tables[0].Rows[0][2].ToString()) + "";
                if (db.update(query1))
                {

                }
               
            }
        }

        private void frmNewReview_Load(object sender, EventArgs e)
        {
            customerId = frmLogin.userId;
            bookingId = frmMyBookings.bookingId;
        }
        public string DateFormatFixing(string date)
        {
            string sysFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            return date = DateTime.ParseExact(date, sysFormat, System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
