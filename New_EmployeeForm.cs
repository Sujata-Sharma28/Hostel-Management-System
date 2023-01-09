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
    public partial class New_EmployeeForm : Form
    {
        public New_EmployeeForm()
        {
            InitializeComponent();
        }

        private void New_EmployeeForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtFatherName.Text != "" && txtMotherName.Text != "" && txtEmail.Text != "" && txtPermanentAddress.Text != "" && txtUniqueID.Text != "" && cmbDesignation.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String fname = txtFatherName.Text;
                String mname = txtMotherName.Text;
                String email = txtEmail.Text;
                String address = txtPermanentAddress.Text;
                String uniqueid = txtUniqueID.Text;
                String designation = cmbDesignation.Text;
                string error = Connection.SetData("Insert into mst_employee (mobile, name, fname, mname, email, address, uniqueid, designation) values " +
                    " ('" + mobile + "', '" + name + "', '" + fname + "', '" + mname + "', '" + email + "', '" + address + "'," +
                    " '" + uniqueid + "', '" + designation + "'); ");
                if (error == "")
                {
                    error = Connection.SetData(" update mst_employee set working = 'Yes' where designation = '" + designation + "' ");
                    MessageBox.Show("Employee Registration Successfull.");
                    clearAll();
                }

                else
                {
                    MessageBox.Show("Error in saving: " + error);
                }
            

            }
            else
            {
                MessageBox.Show("Fill All Required Data..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cmbDesignation.SelectedIndex = -1;
        }
    }
}
