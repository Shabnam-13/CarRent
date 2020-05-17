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
    public partial class Booking : Form
    {
        private CarRentEntities db;
        private int carId;
        private decimal rate;
        private int cusId;
        public Booking(int CarId, decimal Rate, int CusId)
        {
            InitializeComponent();
            this.db = new CarRentEntities();

            this.carId = CarId;
            this.cusId = CusId;
            this.rate = Rate;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
                TimeSpan diff = dtpReturn.Value.Subtract(dtpOut.Value);
                int days = Convert.ToInt32(diff.TotalDays);

                Order order = new Order();
                order.CarId = this.carId;
                order.CustomerId = this.cusId;
                order.IsActive = true;
                order.OutDate = dtpOut.Value;
                order.ReturnedDate = dtpReturn.Value;
                order.ReserveDate = DateTime.Now;
                order.TotalPrice = this.rate * days;

                Car car = db.Cars.Find(this.carId);
                car.IsAviable = false;

                db.Orders.Add(order);
                db.SaveChanges();
                this.Close();
                MessageBox.Show("The order was accepted");
        }
    }
}
