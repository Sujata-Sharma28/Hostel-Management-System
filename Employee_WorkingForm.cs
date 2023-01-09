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
    public partial class Employee_WorkingForm : Form
    {
        public Employee_WorkingForm()
        {
            InitializeComponent();
        }

        private void Employee_WorkingForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DataSet ds = Connection.GetData("Select * from mst_employee where working = 'Yes' ");
            dgvEmployeeWorking.DataSource = ds.Tables[0];
        }
    }
}
