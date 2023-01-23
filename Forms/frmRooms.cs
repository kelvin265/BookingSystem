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
    public partial class frmRooms : Form
    {
        database db = new database();
        public static int roomId;
        public static float price;
        public frmRooms()
        {
            InitializeComponent();
        }

        private void frmRooms_Load(object sender, EventArgs e)
        {
            viewRooms();
        }

        public void viewRooms()
        {
            string query = "select * from room";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvRooms.Rows.Clear();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int n = dgvRooms.Rows.Add();
                    dgvRooms.Rows[n].Cells[0].Value = dr.ItemArray.GetValue(0).ToString();
                    dgvRooms.Rows[n].Cells[1].Value = dr.ItemArray.GetValue(1).ToString();
                    dgvRooms.Rows[n].Cells[2].Value = dr.ItemArray.GetValue(2).ToString();
                    dgvRooms.Rows[n].Cells[3].Value = dr.ItemArray.GetValue(3).ToString();
                    dgvRooms.Rows[n].Cells[4].Value = dr.ItemArray.GetValue(4).ToString();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            viewRooms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            int index = 0;
            int count = dgvRooms.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i <= count - 1; i++)
                {
                    if (dgvRooms.Rows[i].Cells[5].Value != null)
                    {
                        if (row == 0)
                        {
                            row++;
                            index = i;
                        }
                        else
                        {

                            MessageBox.Show("Please select 1 room to book ", "Booking info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvRooms.Rows.Clear();
                            viewRooms();
                            return;
                        }


                    }
                }
                if (row != 0)
                {
                    if (dgvRooms.Rows[index].Cells[4].Value.ToString() == "Available")
                    {
                        roomId = int.Parse(dgvRooms.Rows[index].Cells[0].Value.ToString());
                        price = float.Parse(dgvRooms.Rows[index].Cells[3].Value.ToString());
                        frmNewRoomBooking frm = new frmNewRoomBooking();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please select a room that is available ", "Booking error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
