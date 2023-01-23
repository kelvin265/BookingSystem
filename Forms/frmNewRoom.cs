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
    public partial class frmNewRoom : Form
    {
        database db = new database();
        public frmNewRoom()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRoomNumber.Text != "" || txtType.Text != "" || cmbStatus.Text != "" || txtPrice.Text != "")
            {
                room room = new room(db.codeGenerator("room"), txtRoomNumber.Text, txtType.Text, cmbStatus.Text, float.Parse(txtPrice.Text));


                if (room.addRoom(room))
                {
                    MessageBox.Show("Room registered successfully", "Register info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to register room!", "Register error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
