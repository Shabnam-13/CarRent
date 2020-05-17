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
    public partial class Customers : Form
    {
        private CarRentEntities db;
        private int Id;
        public Customers()
        {
            InitializeComponent();
            this.db = new CarRentEntities();
            fillDgv(db.Customers.ToList());
        }

        private void fillDgv(List<Customer> customer)
        {
            dgvCustomer.Rows.Clear();

            foreach(Customer item in customer)
            {
                dgvCustomer.Rows.Add(item.Id, item.FirstName, item.LastName, 
                            item.Identification, item.Phone, item.Email != null ? item.Email : "",
                            item.Address != null ? item.Address : "", item.AddedDate.Value.ToString("dd.MM.yyyy"));
            }
        }


        private void Reset()
        {
            txtName.Text = "";
            txtSname.Text = "";
            txtPhone.Text = "";
            txtIden.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Customer customer = db.Customers.Find(Id);

            customer.FirstName = txtName.Text;
            customer.LastName = txtSname.Text;
            customer.Phone = txtPhone.Text;
            customer.Identification = txtIden.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;

            db.SaveChanges();
            fillDgv(db.Customers.ToList());
            Reset();
        }

        private void dgvCustomer_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Reset();
            Id = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells[0].Value);
            txtName.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSname.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtIden.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtEmail.Text = dgvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtAddress.Text = dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Customer customer = db.Customers.Find(Id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            fillDgv(db.Customers.ToList());
            Reset();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            List<Customer> customers = db.Customers.Where(s => (s.FirstName.Contains(txtName.Text)) &&
                                                              (s.LastName.Contains(txtSname.Text)) &&
                                                              (s.Identification.Contains(txtIden.Text)) &&
                                                              (s.Phone.Contains(txtPhone.Text)) &&
                                                              (!string.IsNullOrEmpty(txtEmail.Text) ? s.Email.Contains(txtEmail.Text) : true) &&
                                                              (!string.IsNullOrEmpty(txtAddress.Text) ? s.Address.Contains(txtAddress.Text) : true)
                                                              ).ToList();
            fillDgv(customers);
        }

    }
}
