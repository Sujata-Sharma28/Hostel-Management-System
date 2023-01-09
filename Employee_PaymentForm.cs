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
    public partial class Employee_PaymentForm : Form
    {
        public Employee_PaymentForm()
        {
            InitializeComponent();
        }

        private void Employee_PaymentForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            datetimepickerMonth.Format = DateTimePickerFormat.Custom;
            datetimepickerMonth.CustomFormat = "MMMM yyyy";
        }
        public void setDataGrid(Int64 mobile)
        {
            DataSet ds1 = Connection.GetData("Select * from et_emppayment where mobile = '" + mobile + "' ");
            dgvEmployeePayment.DataSource = ds1.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                DataSet ds = Connection.GetData("Select name, email, designation from mst_employee where mobile = '" + txtMobile.Text + "' ");
                if (ds.Tables[0].Rows.Count != 0)
                {

                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDesignation.Text = ds.Tables[0].Rows[0][2].ToString();

                    setDataGrid(Int64.Parse(txtMobile.Text));


                }
                else
                {
                    MessageBox.Show("No Record Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                MessageBox.Show("Enter some data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtDesignation.Clear();
            txtEmail.Clear();
            dgvEmployeePayment.DataSource = 0;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtAmount.Text != "")
            {
                DataSet ds = Connection.GetData("Select * from et_emppayment where  mobile = '" + txtMobile.Text + "' and month = '" + datetimepickerMonth.Text + "'  ");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string mobile = txtMobile.Text;
                    string month = datetimepickerMonth.Text;
                    Int64 amount = Int64.Parse(txtAmount.Text);
                    String error = Connection.SetData("Insert into et_emppayment (mobile, month, amount) values ('" + mobile + "','" + month + "', " + amount + ")");
                    if (error == "")
                    {
                        MessageBox.Show("Salary for month. '" + datetimepickerMonth.Text + "' Paid ");
                        setDataGrid(Int64.Parse(txtMobile.Text));
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Error in saving " + error);
                    }

                }
                else
                {
                    MessageBox.Show("Payment of '" + datetimepickerMonth.Text + "' Done.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
    


