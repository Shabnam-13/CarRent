using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRent.Models;
using CarRent.Forms;

namespace CarRent.Forms
{
    public partial class Change_password : Form
    {
        private CarRentEntities db;
        private int empId;
        public Change_password(int EmpId)
        {
            InitializeComponent();
            this.db = new CarRentEntities();
            this.empId = EmpId;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtOldPass.Text) && !string.IsNullOrWhiteSpace(txtNewPass.Text))
            {
                if (db.Employees.FirstOrDefault(a => a.Id == this.empId && a.Password == txtOldPass.Text) != null)
                {
                    Employee emp = db.Employees.Find(this.empId);
                    emp.Password = txtNewPass.Text;

                    db.SaveChanges();
                    MessageBox.Show("Passwor changed successfully"+this.empId);
                }
                else
                {
                    lblError.Text = "Please type correct password";
                }
            }
            else
            {
                lblError.Text = "Please fill all required data";
            }
            
        }
    }
}
