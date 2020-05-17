using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CarRent.Models;

namespace CarRent.Forms
{
    public partial class Cars : Form
    {
        private CarRentEntities db;
        private int Id;
        public Cars()
        {
            InitializeComponent();
            this.db = new CarRentEntities();
            fillDgv(db.Cars.ToList());
        }
        private void fillDgv(List<Car> cars)
        {
            dgvCars.Rows.Clear();

            foreach (Car item in cars)
            {
                dgvCars.Rows.Add(item.Id, item.carType.Name, item.carMark.Name,
                    item.carModel.Name, item.carColor.Name, item.Year, item.SeatCapacity,
                    item.Plate, item.Rate.Value.ToString("#.00"), item.AddedDate,
                    item.IsAviable != true ? item.IsAviable.Value.ToString() : "Available",
                    item.IsAviable != false ? item.IsAviable.Value.ToString() : "Unavailable");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtType.Text) && !string.IsNullOrWhiteSpace(txtMark.Text)&& 
                !string.IsNullOrWhiteSpace(txtModel.Text) && !string.IsNullOrWhiteSpace(txtPlate.Text)&&
                !string.IsNullOrWhiteSpace(txtColor.Text) && !string.IsNullOrWhiteSpace(txtRate.Text)&&
                !string.IsNullOrWhiteSpace(txtYear.Text) && numCap.Value != 0)
            {
                if (db.carTypes.FirstOrDefault(t => t.Name.ToLower() == txtType.Text.ToLower()) == null)
                {
                    carType type = new carType();
                    type.Name = txtType.Text;

                    db.carTypes.Add(type);
                    db.SaveChanges();
                }

                if (db.carMarks.FirstOrDefault(t => t.Name.ToLower() == txtMark.Text.ToLower()) == null)
                {
                    carMark mark = new carMark();
                    mark.Name = txtMark.Text;

                    db.carMarks.Add(mark);
                    db.SaveChanges();
                }

                if (db.carModels.FirstOrDefault(t => t.Name.ToLower() == txtModel.Text.ToLower()) == null)
                {
                    carModel model = new carModel();
                    model.Name = txtModel.Text;
                    model.MarkId = db.carMarks.FirstOrDefault(m => m.Name == txtMark.Text).Id;

                    db.carModels.Add(model);
                    db.SaveChanges();
                }

                if (db.carColors.FirstOrDefault(t => t.Name.ToLower() == txtColor.Text.ToLower()) == null)
                {
                    carColor color = new carColor();
                    color.Name = txtColor.Text;

                    db.carColors.Add(color);
                    db.SaveChanges();
                }

                if (db.Cars.FirstOrDefault(p => p.Plate == txtPlate.Text) == null)
                {
                    Car car = new Car();
                    car.MarkId = db.carMarks.FirstOrDefault(m => m.Name == txtMark.Text).Id;
                    car.ModelId = db.carModels.FirstOrDefault(mo => mo.Name == txtModel.Text).Id;
                    car.TypeId = db.carTypes.FirstOrDefault(t => t.Name == txtType.Text).Id;
                    car.ColorId = db.carColors.FirstOrDefault(c => c.Name == txtColor.Text).Id;
                    car.Year = Convert.ToInt32(txtYear.Text);
                    car.SeatCapacity = Convert.ToInt32(numCap.Value);
                    car.Rate = Convert.ToDecimal(txtRate.Text);
                    car.Plate = txtPlate.Text;
                    car.IsAviable = true;
                    car.Note = rtbNote.Text;
                    car.AddedDate = DateTime.Now;

                    db.Cars.Add(car);
                    db.SaveChanges();
                    MessageBox.Show("Car added sucessfully!");
                    fillDgv(db.Cars.ToList());

                    Reset();
                }
                else
                {
                    lblError.Text = "This plate already exists.";
                }
            }
            else
            {
                lblError.Text = "Please fill all required(*) data!";
            }
        }

        private void Reset()
        {
            txtType.Text = "";
            txtPlate.Text = "";
            txtModel.Text = "";
            txtMark.Text = "";
            txtColor.Text = "";
            numCap.Value = 0;
            txtRate.Text = "";
            txtYear.Text = "";
            rtbNote.Text = "";
        }

        private void rtbNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (rtbNote.Text.Length >= 100)
            {
                lblError.Text = "You can write only 100 characters";
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Car car = db.Cars.Find(Id);

            car.TypeId = db.carTypes.FirstOrDefault(T => T.Name == txtType.Text).Id;
            car.MarkId = db.carMarks.FirstOrDefault(M => M.Name == txtMark.Text).Id;
            car.ModelId = db.carModels.FirstOrDefault(m => m.Name == txtModel.Text).Id;
            car.ColorId = db.carColors.FirstOrDefault(C => C.Name == txtColor.Text).Id;
            car.Year = Convert.ToInt32(txtYear.Text);
            car.SeatCapacity = Convert.ToInt32(numCap.Value);
            car.Rate = Convert.ToDecimal(txtRate.Text);
            car.Plate = txtPlate.Text;


            db.SaveChanges();
            fillDgv(db.Cars.ToList());
            Reset();

        }

        private void dgvCars_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Reset();
            Id = Convert.ToInt32(dgvCars.Rows[e.RowIndex].Cells[0].Value);
            txtType.Text = dgvCars.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMark.Text = dgvCars.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtModel.Text = dgvCars.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtColor.Text = dgvCars.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtYear.Text = dgvCars.Rows[e.RowIndex].Cells[5].Value.ToString();
            numCap.Text = dgvCars.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPlate.Text = dgvCars.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtRate.Text = dgvCars.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Car car = db.Cars.Find(Id);
            db.Cars.Remove(car);
            db.SaveChanges();
            fillDgv(db.Cars.ToList());
            Reset();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            List<Car> cars = db.Cars.Where(s => s.carType.Name.Contains(txtType.Text) &&
                                                s.carMark.Name.Contains(txtMark.Text) &&
                                                s.carModel.Name.Contains(txtModel.Text) &&
                                                s.carColor.Name.Contains(txtColor.Text) &&
                                                s.Plate.Contains(txtPlate.Text) &&
                                                s.Year.Value.ToString().Contains(txtYear.Text) &&
                                                s.Rate.Value.ToString().Contains(txtRate.Text) &&
                                                (numCap.Value!=0 ? s.SeatCapacity==numCap.Value :true)).ToList();
            
            fillDgv(cars);
        }
    }
}
