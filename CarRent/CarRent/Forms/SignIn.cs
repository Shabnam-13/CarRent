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


namespace CarRent.Forms
{
    public partial class SignIn : Form
    {
        CarRentEntities db;
        public SignIn()
        {
            InitializeComponent();
            this.db = new CarRentEntities();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUname.Text) && !string.IsNullOrWhiteSpace(txtPass.Text))
            {
                if(db.Employees.FirstOrDefault(u=>u.UserName==txtUname.Text && u.Password == txtPass.Text) != null)
                {
                    Dashboard dash = new Dashboard(this);
                    dash.Show();
                }
                else
                {
                    lblError.Text = "Please type correct username or password!";
                }
            }
            else
            {
                lblError.Text = "Please fill all required(*) data!";
            }

             
        }
    }
}
