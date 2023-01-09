using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class UpdateDeleteStudents_Form : Form
    {
        public UpdateDeleteStudents_Form()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from mst_students where mobile = '" + txtMobile.Text + "'");
            if(ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFatherName.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMotherName.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPermanentAddress.Text = ds.Tables[0].Rows[0][6].ToString();
                txtCollageName.Text = ds.Tables[0].Rows[0][7].ToString();
                txtIDProof.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoomNo.Text = ds.Tables[0].Rows[0][9].ToString();
                cmbLiving.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            else
            {
                clearAll();
                MessageBox.Show("No Record with this Mobile No Exist..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateDeleteStudents_Form_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
        }
        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFatherName.Clear();
            txtMotherName.Clear();
            txtEmail.Clear();
            txtPermanentAddress.Clear();
            txtCollageName.Clear();
            txtIDProof.Clear();
            txtRoomNo.Clear();
            cmbLiving.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String name = txtName.Text;
            String fname = txtFatherName.Text;
            String mname = txtMotherName.Text;
            String email = txtEmail.Text;
            String paddress = txtPermanentAddress.Text;
            String collage = txtCollageName.Text;
            String idproof = txtIDProof.Text;
            Int64 room_no = Int64.Parse(txtRoomNo.Text);
            String living = cmbLiving.Text;
            String error = Connection.SetData("Update mst_students set name = '" + name + "', fname = '" + fname + "', mname = '" + mname + "',"+
                " email = '" + email + "', paddress = '" + paddress + "', collage = '" + collage + "', idproof = '" + idproof + "', room_no = '" + room_no + "',"+
                " living = '" + living + "' where mobile = '" + mobile + "' ");
            if (error == "")
            {
                error = Connection.SetData(" update mst_addroom set booked = '" + living + "' where room_no = '" + room_no + "' ");
                MessageBox.Show("Data Updation Successfull...");
                clearAll();
            }
            else
            {
                MessageBox.Show("Error in updating: " + error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataSet ds = Connection.GetData("Delete from mst_students where mobile = '" + txtMobile.Text + "' ");
                MessageBox.Show("Student Record Deleted...");
                clearAll();
            }
        }
    }
}
