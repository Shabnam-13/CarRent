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
    public partial class Dashboard : Form
    {
        SignIn _signIn;
        CarRentEntities db;
        public Dashboard(SignIn signIn)
        {
            this._signIn = signIn;
            InitializeComponent();
            this.db = new CarRentEntities();
            fillDgv(db.Orders.ToList());
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewOrder order = new NewOrder(this);
            order.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers custom = new Customers();
            custom.Show();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cars car = new Cars();
            car.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            emp.Show();
        }
        
        private void fillDgv(List<Order> orders)
        {
            dgvOrders.Rows.Clear();

            foreach(Order order in orders)
            {
                dgvOrders.Rows.Add(order.Id, order.Customer.FirstName + " " + order.Customer.LastName,
                order.Car.carMark.Name + " " + order.Car.carModel.Name, order.OutDate.Value.ToString("dd.MM.yyyy"),
                order.ReturnedDate.Value.ToString("dd.MM.yyyy"), order.ReserveDate.Value.ToString("dd.MM.yyyy"),
                order.TotalPrice.Value.ToString("#.00"), order.IsActive.Value.ToString()
                );
            }
         
        }


        private void oldOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOrder closeOrder = new CloseOrder();
            closeOrder.Show();
        }

        private void allOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            All_orders orders = new All_orders();
            orders.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dgvOrders.RowCount = 10;
            dgvOrders.Sort(dgvOrders.Columns[5], ListSortDirection.Descending);
        }
    }
}
