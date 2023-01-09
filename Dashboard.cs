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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        Boolean labelVisible = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(labelVisible == true)
            {
                lblhms.Visible = true;
                labelVisible = false;
            }
            else
            {
                lblhms.Visible = false;
                labelVisible = true;
            }    
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            Manage_RoomForm mr = new Manage_RoomForm();
            mr.Show();
        }

        private void btnNewStudents_Click(object sender, EventArgs e)
        {
            NewStudent_Form n = new NewStudent_Form();
            n.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Delete_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudents_Form uds = new UpdateDeleteStudents_Form();
            uds.Show();
        }

        private void btnStudentFees_Click(object sender, EventArgs e)
        {
            Student_FeesForm sf = new Student_FeesForm();
            sf.Show();
        }

        private void btnStudentsLiving_Click(object sender, EventArgs e)
        {
            Students_LivingForm sl = new Students_LivingForm();
            sl.Show();
        }

        private void btnLeavedStudents_Click(object sender, EventArgs e)
        {
            Leaved_StudentsForm ls = new Leaved_StudentsForm();
            ls.Show();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            New_EmployeeForm ne = new New_EmployeeForm();
            ne.Show();
        }

        private void btnUpdateDeleteEmployee_Click(object sender, EventArgs e)
        {
            UpdateDeleteEmployeeForm ude = new UpdateDeleteEmployeeForm();
            ude.Show();
        }

        private void btnEmployeePayment_Click(object sender, EventArgs e)
        {
            Employee_PaymentForm ep = new Employee_PaymentForm();
            ep.Show();
        }

        private void btnEmployeeWorking_Click(object sender, EventArgs e)
        {
            Employee_WorkingForm ew = new Employee_WorkingForm();
            ew.Show();
        }

        private void btnleavedEmployee_Click(object sender, EventArgs e)
        {
            Leaved_EmployeeForm le = new Leaved_EmployeeForm();
            le.Show();
        }
    }
}
