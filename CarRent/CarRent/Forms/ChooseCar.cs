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
using System.Drawing.Drawing2D;

namespace CarRent.Forms
{
    public partial class ChooseCar : Form
    {
        private CarRentEntities db;
        private int customerId { get; set; }
        private int markId;
        public ChooseCar(int customerId)
        {
            InitializeComponent();
            this.db = new CarRentEntities();
            this.customerId = customerId;

            fillType();
            fillMark();
            fillColor();
            fillDgv(db.Cars.Where(s=>s.IsAviable==true).ToList());
        }

        private void fillType()
        {
            cbType.Items.Clear();
            cbType.Items.Add("Choose");
            cbType.SelectedItem = "Choose";
            foreach(carType item in db.carTypes.ToList())
            {
                cbType.Items.Add(item.Name);
            }
        }

        private void fillMark()
        {
            cbMark.Items.Clear();
            cbMark.Items.Add("Choose");
            cbMark.SelectedItem = "Choose";
            foreach (carMark item in db.carMarks.ToList())
            {
                cbMark.Items.Add(item.Name);
            }
        }

        private void fillModel(int markId)
        {
            cbModel.Items.Clear();
            cbModel.Items.Add("Choose");
            cbModel.SelectedItem = "Choose";
            List<carModel> models = db.carModels.Where(i => i.MarkId == markId).ToList();
            foreach (carModel item in models)
            {
                cbModel.Items.Add(item.Name);
            }
        }

        //private void cbMark_SelectedIndexChanged(object sender, EventArgs e)
        //{    
        //    markId = db.carMarks.FirstOrDefault(m => m.Name == cbMark.Text).Id;
            
        //    fillModel(markId);
        //}

        private void fillColor()
        {
            cbColor.Items.Clear();
            cbColor.Items.Add("Choose");
            cbColor.SelectedItem = "Choose";
            foreach (carColor item in db.carColors.ToList())
            {
                cbColor.Items.Add(item.Name);
            }
        }

        private void fillDgv(List<Car> cars)
        {
            dgvCars.Rows.Clear();
            foreach(Car item in cars)
            {
                dgvCars.Rows.Add(item.Id, item.carType.Name, item.carMark.Name,
                    item.carModel.Name, item.carColor.Name, item.Year, item.SeatCapacity,
                    item.Plate, item.Rate.Value.ToString("#.00"), item.IsAviable != true ? item.IsAviable.Value.ToString() : "Available");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int TypeId = 0;
            if (db.carTypes.FirstOrDefault(r => r.Name == cbType.Text) != null)
            {
                TypeId = db.carTypes.FirstOrDefault(r => r.Name == cbType.Text).Id;
            }

            int makeId = 0;
            if (db.carMarks.FirstOrDefault(r => r.Name == cbMark.Text) != null)
            {
                makeId = db.carMarks.FirstOrDefault(r => r.Name == cbMark.Text).Id;
            }

            int modelId = 0;
            if (db.carModels.FirstOrDefault(r => r.Name == cbModel.Text) != null)
            {
                modelId = db.carModels.FirstOrDefault(r => r.Name == cbModel.Text).Id;
            }

            int colorId = 0;
            if (db.carColors.FirstOrDefault(r => r.Name == cbColor.Text) != null)
            {
                colorId = db.carColors.FirstOrDefault(r => r.Name == cbColor.Text).Id;
            }

            List<Car> cars = db.Cars.Where(a => (TypeId!=0 ? a.TypeId == TypeId : true) &&
                                                (makeId!=0 ? a.MarkId==makeId :true)&&
                                                (modelId!=0 ? a.ModelId==modelId :true)&&
                                                (colorId!=0 ? a.ColorId==colorId :true)&
                                                (a.Rate.ToString().Contains(txtRate.Text)&&
                                                (a.Year.ToString().Contains(txtYear.Text))&&
                                                (numCap.Value !=0 ? a.SeatCapacity==numCap.Value : true))
                                               ).ToList();
            fillDgv(cars);
        }

        private void dgvCars_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CarId = Convert.ToInt32(dgvCars.Rows[e.RowIndex].Cells[0].Value);
            decimal Rate = Convert.ToDecimal(dgvCars.Rows[e.RowIndex].Cells[8].Value);
            
            Booking booking = new Booking(CarId, Rate, this.customerId);
            booking.Show();
        }

        
    }
}
