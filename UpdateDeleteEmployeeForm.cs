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
    public partial class UpdateDeleteEmployeeForm : Form
    {
        public UpdateDeleteEmployeeForm()
        {
            InitializeComponent();
        }

        private void UpdateDeleteEmployeeForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from mst_employee where mobile = '" + txtMobile.Text + "'");
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFatherName.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMotherName.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPermanentAddress.Text = ds.Tables[0].Rows[0][6].ToString();
                txtUniqueID.Text = ds.Tables[0].Rows[0][7].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[0][8].ToString();
                cmbWorkingStatus.Text = ds.Tables[0].Rows[0][9].ToString();
            }
            else
            {
                clearAll();
                MessageBox.Show("No Record with this Mobile No Exist..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFatherName.Clear();
            txtMotherName.Clear();
            txtEmail.Clear();
            txtPermanentAddress.Clear();
            txtUniqueID.Clear();
            txtDesignation.Clear();
            cmbWorkingStatus.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataSet ds = Connection.GetData("Delete from mst_employee where mobile = '" + txtMobile.Text + "' ");
                MessageBox.Show("Employee Record Deleted...");
                clearAll();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String mobile = txtMobile.Text;
            String name = txtName.Text;
            String fname = txtFatherName.Text;
            String mname = txtMotherName.Text;
            String email = txtEmail.Text;
            String address = txtPermanentAddress.Text;
            String uniqueid = txtUniqueID.Text;
            String designation = txtDesignation.Text;
            String working = cmbWorkingStatus.Text;
            String error = Connection.SetData("Update mst_employee set name = '" + name + "', fname = '" + fname + "', mname = '" + mname + "', email = '" + email + "',address = '" + address + "', uniqueid = '" + uniqueid + "', designation ='" + designation + "', working = '" + working + "' where mobile = '" + mobile + "' ");
            if (error == "")
            {
                MessageBox.Show("Data Updation Successful..");
                clearAll();

            }
            else
            {
                MessageBox.Show("Error in Message.." + error);
            }
        }
    }
}
