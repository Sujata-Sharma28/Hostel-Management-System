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
    public partial class Student_FeesForm : Form
    {
        public Student_FeesForm()
        {
            InitializeComponent();
        }

        private void Student_FeesForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            datetimepickerMonth.Format = DateTimePickerFormat.Custom;
            datetimepickerMonth.CustomFormat = "MMMM yyyy";
        }
        private void dgvFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                DataSet ds = Connection.GetData("Select name, email, room_no from mst_students where mobile = '" + txtMobile.Text + "' ");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtRoomNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    setDataGrid(Int64.Parse(txtMobile.Text));
                }
                else
                {
                    MessageBox.Show("No Record Exist..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void setDataGrid(Int64 mobile)
        {
            DataSet ds1 = Connection.GetData("Select * from mst_fee where mobile = '" + mobile + "' ");
            dgvFees.DataSource = ds1.Tables[0];
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(txtMobile.Text != "" && txtAmount.Text != "")
            {
                DataSet ds = Connection.GetData("Select * from mst_fee where mobile = '" + Int64.Parse(txtMobile.Text)+ "' and month = '" + datetimepickerMonth.Text + "' ");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    String month = datetimepickerMonth.Text;
                    Int64 amount = Int64.Parse(txtAmount.Text);
                    DataSet ds1 = Connection.GetData("Insert into mst_fee (mobile, month, amount) values ('" + mobile + "', '" + month + "', '" + amount + "')");
                    MessageBox.Show("Fees Paid");
                    clearAll();
                }
                else
                {
                    MessageBox.Show("No dues of '" + datetimepickerMonth.Text + "' Left.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            txtAmount.Clear();
            txtRoomNo.Clear();
            txtEmail.Clear();
            dgvFees.DataSource = 0;
        }
    }
}
    