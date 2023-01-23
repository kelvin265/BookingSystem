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
    public partial class frmUpdateRoom : Form
    {
        database db = new database();
        int id;
        public frmUpdateRoom()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void selectRoom()
        {
            string query = "select * from room where id = " + id + "";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                txtRoomNumber.Text = dr.ItemArray.GetValue(1).ToString();
                txtType.Text = dr.ItemArray.GetValue(2).ToString();
                txtPrice.Text = dr.ItemArray.GetValue(3).ToString();
                cmbStatus.Text = dr.ItemArray.GetValue(4).ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRoomNumber.Text != "" || txtType.Text != "" || cmbStatus.Text != "" || txtPrice.Text != "")
            {

                room room = new room(id, txtRoomNumber.Text, txtType.Text, cmbStatus.Text, float.Parse(txtPrice.Text));


                if (room.updateRoom(room))
                {
                    MessageBox.Show("Room updated successfully", "Update info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update room!", "Update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        private void frmUpdateRoom_Load(object sender, EventArgs e)
        {
            id = frmAdminRooms.roomId;
            selectRoom();
        }
    }
}
