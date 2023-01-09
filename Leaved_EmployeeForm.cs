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
    public partial class Leaved_EmployeeForm : Form
    {
        public Leaved_EmployeeForm()
        {
            InitializeComponent();
        }

        private void Leaved_EmployeeForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DataSet ds = Connection.GetData("Select * from mst_employee where working = 'No' ");
            dgvLeavedEmployee.DataSource = ds.Tables[0];
        }

        private void dgvLeavedEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
