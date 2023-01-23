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
    public partial class frmProfile : Form
    {
        database db = new database();
        public frmProfile()
        {
            InitializeComponent();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            viewProfile();
        }

        public void viewProfile()
        {
            string query = "select * from user where id='" + frmLogin.userId + "'";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            int count = dgvUsers.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (dgvUsers.Rows[i].Cells[6].Value != null)
                    {
                        frmUpdateUser frm = new frmUpdateUser();
                        frm.Show();

                    }
                }
            }
        }
    

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            viewProfile();
        }
    }
}
