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
    public partial class Students_LivingForm : Form
    {
        public Students_LivingForm()
        {
            InitializeComponent();
        }

        private void Students_LivingForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DataSet ds = Connection.GetData("Select * from mst_students where living = 'Yes' ");
            dgvStudentsInHostel.DataSource = ds.Tables[0];
        }

        private void dgvStudentsInHostel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
