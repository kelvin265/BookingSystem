using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingSystem
{
    public partial class ucReview : UserControl
    {
        public ucReview()
        {
            InitializeComponent();
        }

        #region Getter $ Setter for Labels
        private string _username;
        private string _date;
        private int _bookingId;
        private int _id;
        private string _review;


        [Category("Custom Props")]

        public string Username
        {
            get { return _username; }
            set { _username = value; lblUser.Text = value; }
        }

        [Category("Custom Props")]

        public string Date
        {
            get { return _date; }
            set { _date = value; lblDate.Text = value; }
        }

        [Category("Custom Props")]

        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        [Category("Custom Props")]

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Category("Custom Props")]

        public string Review
        {
            get { return _review; }
            set { _review = value; textBox1.Text = value; }
        }

        #endregion

        #region Hover effect

        private void ucReview_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(217, 229, 242);
        }

        private void ucReview_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        #endregion
    }
}
