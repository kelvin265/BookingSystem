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

namespace BookingSystem.Forms
{
    public partial class frmHome : Form
    {
        database db = new database();

        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            GenerateDynamicUserControl();
        }

        #region Function To Generate Dynamic User Controls

        private void GenerateDynamicUserControl()
        {
            flowLayoutPanel1.Controls.Clear();

            List<ucReview> ucReviews = new List<ucReview>();

            string query = "select * from reviews";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {


                    ucReview uc = new ucReview();
                    uc.Id = int.Parse(dr.ItemArray.GetValue(0).ToString());
                    uc.Username = getUsername(int.Parse(dr.ItemArray.GetValue(1).ToString()));
                    uc.BookingId = int.Parse(dr.ItemArray.GetValue(2).ToString());
                    uc.Date = dr.ItemArray.GetValue(3).ToString();
                    uc.Review = dr.ItemArray.GetValue(4).ToString();

                    flowLayoutPanel1.Controls.Add(uc);


                }

            }

        }
        #endregion


        private string getUsername(int id)
        {

            string name = "";
            string query = "select * from user where id='" + id + "'";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    name = ds.Tables[0].Rows[i][1].ToString();
                }

            }
            return name;

        }
    }
}
