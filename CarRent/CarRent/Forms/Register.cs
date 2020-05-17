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
    public partial class Register : Form
    {
        private CarRentEntities db;
        private int CustomerId;
        public Register()
        {
            InitializeComponent();
            this.db = new CarRentEntities();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtSname.Text)
               && !string.IsNullOrWhiteSpace(txtPhone.Text) && !string.IsNullOrWhiteSpace(txtIden.Text))
            {
                if (db.Customers.FirstOrDefault(id => id.Identification == txtIden.Text) == null)
                {
                    Customer customer = new Customer();
                    customer.FirstName = txtName.Text;
                    customer.LastName = txtSname.Text;
                    customer.Phone = txtPhone.Text;
                    customer.Email = txtEmail.Text;
                    customer.Identification = txtIden.Text;
                    customer.Address = txtAddress.Text;
                    customer.AddedDate = DateTime.Now;

                    CustomerId = customer.Id;

                    db.Customers.Add(customer);
                    db.SaveChanges();
                    MessageBox.Show("Customer added successfully!");
                    btnChooseCar.Visible = true;
                }
                else
                {
                    lblError.Text = "This customer already exists.";
                }
            }
            else
            {
                lblError.Text = "Please fill all required(*) data!";
            }
        }

        private void btnChooseCar_Click(object sender, EventArgs e)
        {
            ChooseCar car = new ChooseCar(CustomerId);
            car.Show();
        }
    }
}
