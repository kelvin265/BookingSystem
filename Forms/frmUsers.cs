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
    public partial class frmUsers : Form
    {
        database db = new database();
        public static int userId = 0;
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            viewUsers();
        }

        public void viewUsers()
        {
            string query = "select * from user";
            DataSet ds = db.select(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvUsers.Rows.Clear();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int n = dgvUsers.Rows.Add();
                    dgvUsers.Rows[n].Cells[0].Value = dr.ItemArray.GetValue(0).ToString();
                    dgvUsers.Rows[n].Cells[1].Value = dr.ItemArray.GetValue(1).ToString();
                    dgvUsers.Rows[n].Cells[2].Value = dr.ItemArray.GetValue(2).ToString();
                    dgvUsers.Rows[n].Cells[3].Value = dr.ItemArray.GetValue(3).ToString();
                    dgvUsers.Rows[n].Cells[4].Value = dr.ItemArray.GetValue(4).ToString();
                    dgvUsers.Rows[n].Cells[5].Value = dr.ItemArray.GetValue(5).ToString();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewUser frm = new frmNewUser();
            frm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int count = dgvUsers.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (dgvUsers.Rows[i].Cells[6].Value != null)
                    {
                        userId = int.Parse(dgvUsers.Rows[i].Cells[0].Value.ToString());
                        frmUpdateUser frm = new frmUpdateUser();
                        frm.Show();

                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query;
            int count = dgvUsers.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i <= count - 1; i++)
                {
                    if (dgvUsers.Rows[i].Cells[6].Value != null)
                    {
                        userId = int.Parse(dgvUsers.Rows[i].Cells[0].Value.ToString());
                        query = "delete from user where id=" + userId + "";
                        if (db.delete(query))
                        {

                            MessageBox.Show("User '" + dgvUsers.Rows[i].Cells[1].Value.ToString() + "' has been successfully removed ", "Delete info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvUsers.Rows.Clear();
                        }


                    }
                }
                viewUsers();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            viewUsers();
        }
    }
    
}
