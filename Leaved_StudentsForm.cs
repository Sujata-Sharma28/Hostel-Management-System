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
    public partial class Leaved_StudentsForm : Form
    {
        public Leaved_StudentsForm()
        {
            InitializeComponent();
        }

        private void Leaved_StudentsForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DataSet ds = Connection.GetData("Select * from mst_students where living = 'No' ");
            dgvLeavedStudents.DataSource = ds.Tables[0];
        }
    }
}
