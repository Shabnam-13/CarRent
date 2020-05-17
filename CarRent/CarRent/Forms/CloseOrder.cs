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
    public partial class CloseOrder : Form
    {
        private CarRentEntities db;
        private int OrderId;
        public CloseOrder()
        {
            InitializeComponent();
            this.db = new CarRentEntities();
            fillDgv(db.Orders.Where(a=>a.IsActive==true).ToList());
        }

        private void fillDgv(List<Order> orders)
        {
            dgvOrders.Rows.Clear();

            foreach(Order order in orders)
            {
                dgvOrders.Rows.Add(order.Id, order.Customer.FirstName + " " + order.Customer.LastName,
                                   order.Car.carMark.Name + " " + order.Car.carModel.Name, 
                                   order.OutDate.Value.ToString("dd.MM.yyyy"), 
                                   order.ReturnedDate.Value.ToString("dd.MM.yyyy"), order.ReserveDate, 
                                   order.IsActive != true ? order.IsActive.Value.ToString() : "Active");
            }
        }

        private void dgvOrders_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnClose.Visible = true;
            OrderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Order order = db.Orders.Find(OrderId);
            order.Car.IsAviable = true;
            order.IsActive = false;
        
            if(db.Orders.FirstOrDefault(a=>a.Id==OrderId && a.ReturnedDate < DateTime.Now) != null)
            {
                TimeSpan diff = DateTime.Now.Subtract(order.ReturnedDate.Value);
                int days = Convert.ToInt32(diff.TotalDays) - 1;

                order.TotalPrice = (order.Car.Rate * 20 / 100) * days + order.TotalPrice;
                MessageBox.Show("Delay " + days + "day. Total price is " + order.TotalPrice);
            }

            db.SaveChanges();
            fillDgv(db.Orders.Where(a => a.IsActive == true).ToList());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Order> orders = db.Orders.Where(s => s.IsActive==true && s.Customer.FirstName.Contains(txtSearch.Text) ||
                                                    s.Customer.LastName.Contains(txtSearch.Text) ||
                                                    (s.Customer.FirstName + " " + s.Customer.LastName).Contains(txtSearch.Text) ||
                                                    s.Car.carMark.Name.Contains(txtSearch.Text) ||
                                                    s.Car.carModel.Name.Contains(txtSearch.Text) ||
                                                    (s.Car.carMark.Name + " " + s.Car.carModel.Name).Contains(txtSearch.Text)
                                                    ).ToList();
            fillDgv(orders);
        }        
    }
}
