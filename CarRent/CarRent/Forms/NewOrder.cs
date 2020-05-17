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
    public partial class NewOrder : Form
    {
        Dashboard _dash;
        CarRentEntities db;
        public NewOrder(Dashboard dash)
        {
            this._dash = dash;
            InitializeComponent();
            this.db = new CarRentEntities();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtSname.Text))
            {
                if (db.Customers.FirstOrDefault(s => s.FirstName.ToLower() == txtName.Text.ToLower() && s.LastName.ToLower() == txtSname.Text.ToLower()) != null) 
                {
                    int customerId = db.Customers.FirstOrDefault(s => s.FirstName.ToLower() == txtName.Text.ToLower() && s.LastName.ToLower() == txtSname.Text.ToLower()).Id;
                    ChooseCar car = new ChooseCar(customerId);
                    car.Show();
                }
                else
                {
                    MessageBox.Show("This customer not found. PLease register now");
                }

            }
            else
            {
                lblRegOrError.Text = "Please fill all required(*) data";
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
    }
}
