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
    public partial class NewStudent_Form : Form
    {
        public NewStudent_Form()
        {
            InitializeComponent();
        }

        private void NewStudent_Form_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DataSet ds = Connection.GetData("Select room_no from mst_addroom where room_status = 'Yes' and booked = 'No' ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Int64 room = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                cmbRoom.Items.Add(room);
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
            txtCollageName.Clear();
            txtIDProof.Clear();
            cmbRoom.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtFatherName.Text != "" && txtMotherName.Text != "" && txtEmail.Text != "" && txtPermanentAddress.Text != "" && txtCollageName.Text != "" && txtIDProof.Text != "" && cmbRoom.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String fname = txtFatherName.Text;
                String mname = txtMotherName.Text;
                String email = txtEmail.Text;
                String paddress = txtPermanentAddress.Text;
                String collage = txtCollageName.Text;
                String idproof = txtIDProof.Text;
                Int64 room_no = Int64.Parse(cmbRoom.Text);
                string error = Connection.SetData("Insert into mst_students (mobile, name, fname, mname, email, paddress, collage, idproof, room_no) values "+
                    " ('" + mobile + "', '" + name + "', '" + fname + "', '" + mname + "', '" + email + "', '" + paddress + "', '" + collage + "',"+
                    " '" + idproof + "', '" + room_no + "') ");
                if (error == "")
                {
                    error = Connection.SetData(" update mst_addroom set booked = 'Yes' where room_no = '" + room_no + "' ");
                    MessageBox.Show("Student Registration Successfull.");
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Error in saving: " + error);
                }
            }
            else
            {
                MessageBox.Show("Fill All Empty Space.", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
    
