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
    public partial class Manage_RoomForm : Form
    {
        public Manage_RoomForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manage_RoomForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            lblRoom.Visible = false;
            lblRoomExist.Visible = false;
            DataSet ds = Connection.GetData("Select * from mst_addroom");
            dgvAllRooms.DataSource = ds.Tables[0];
        }

        private void dgvAllRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from mst_addroom where room_no = '"+ txtRoomNo1.Text +"' ");
            if(ds.Tables[0].Rows.Count == 0)
            {
                String status;
                if(CheckBox1.Checked)
                {
                    status = "Yes";
                }
                else
                {
                    status = "No";
                }
                lblRoomExist.Visible = false;
                Connection.SetData("Insert into mst_addroom(room_no, room_status) values('" + txtRoomNo1.Text + "', '" + status + "')");
               // DataSet ds1 = Connection.GetData("Insert into mst_addroom(room_no, room_status) values('" + txtRoomNo1.Text + "', '" + status + "')");
                MessageBox.Show("Room Added");
                Manage_RoomForm_Load(this, null);
            }
            else 
            {
                lblRoomExist.Text = "Room All Ready Exist.";
                lblRoomExist.Visible = true;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from mst_addroom where room_no = '" + txtRoomNo2.Text + "' ");
            if(ds.Tables[0].Rows.Count == 0)
            {
                lblRoom.Text = "No Room Exist.";
                lblRoom.Visible = true;
                CheckBox2.Checked = false;
            }
            else
            {
                lblRoom.Text = "Room Found.";
                lblRoom.Visible = true;
                if(ds.Tables[0].Rows[0][1].ToString() == "Yes")
                {
                    CheckBox2.Checked = true;
                }
                else
                {
                    CheckBox2.Checked = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String status;
            if(CheckBox2.Checked)
            {
                status = "Yes";
                
            }
            else 
            {
                status = "No";

            }
            DataSet ds = Connection.GetData("Update mst_addroom set room_status = '" + status + "' where room_no = '" + txtRoomNo2.Text + "'");
            MessageBox.Show("Details Updated.");
            Manage_RoomForm_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lblRoom.Text == "Room Found.")
            {
                DataSet ds = Connection.GetData("Delete from mst_addroom where room_no = '" + txtRoomNo2.Text + "'");
                MessageBox.Show("Room Details Deleted.");
                Manage_RoomForm_Load(this, null);

            }
            else
            {
                MessageBox.Show("Trying to delete which doesn't Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
