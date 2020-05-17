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
using ClosedXML.Excel;
using System.IO;

namespace CarRent.Forms
{
    public partial class All_orders : Form
    {
        private CarRentEntities db;
        List<Order> orders;
        public All_orders()
        {
            InitializeComponent();
            this.db = new CarRentEntities();
            fillDgv(db.Orders.ToList());
            orders = db.Orders.ToList();
        }

        private void fillDgv(List<Order> orders)
        {
            dgvOrders.Rows.Clear();
            foreach(Order order in orders)
            {
                dgvOrders.Rows.Add(order.Id, order.Customer.FirstName + " " + order.Customer.LastName,
                                   order.Car.carMark.Name + " " + order.Car.carModel.Name, order.Car.Plate, order.OutDate.Value.ToString("dd.MM.yyyy"),
                                   order.ReturnedDate.Value.ToString("dd.MM.yyyy"), order.TotalPrice.Value.ToString("#.00"),
                                   order.IsActive.Value.ToString(), order.ReserveDate.Value.ToString("dd.MM.yyyy")
                                   );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                orders = db.Orders.Where(s => (s.Customer.FirstName + " " + s.Customer.LastName).Contains(txtSearch.Text) ||
                                              (s.Car.carMark.Name + " " + s.Car.carModel.Name).Contains(txtSearch.Text) ||
                                              (s.Car.Plate.Contains(txtSearch.Text)) 
                                              ).ToList();
            fillDgv(orders);
        }

        private void btnSearchDateNum_Click(object sender, EventArgs e)
        {
            orders = db.Orders.Where(s => (numStart.Value != 0 ? s.TotalPrice.Value >= numStart.Value : true) &&
                                              (numEnd.Value != 0 ? s.TotalPrice.Value <= numEnd.Value : true) ||
                                              (s.ReserveDate.Value >= dtpStart.Value) &&
                                              (s.ReserveDate.Value <= dtpEnd.Value)
                                             ).ToList();
            fillDgv(orders);
        }

        private void downloadToExcel()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Order list");

            ws.Row(1).Height = 3;
            ws.Row(2).Height = 35;
            ws.Row(3).Height = 25;

            ws.Column("A").Width = 0.1;
            ws.Column("B").Width = 5;
            ws.Column("C").Width = 20;
            ws.Column("D").Width = 20;
            ws.Column("E").Width = 15;
            ws.Column("F").Width = 15;
            ws.Column("G").Width = 15;
            ws.Column("H").Width = 15;
            ws.Column("I").Width = 20;

            ws.Column("B").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
            ws.Column("B").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Column("C").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Column("C").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Column("D").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Column("D").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Column("E").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Column("E").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Column("F").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Column("F").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Column("G").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Column("G").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Column("H").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Column("H").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Column("I").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Column("I").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

            ws.Range("B3:I3").Style.Fill.BackgroundColor = XLColor.SkyBlue;
            ws.Range("B3:I3").Style.Font.FontColor = XLColor.White;

            ws.Cell("B3").Value = "Id";
            ws.Cell("B3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("B3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Cell("C3").Value = "Customer";
            ws.Cell("C3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("C3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Cell("D3").Value = "Car";
            ws.Cell("D3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("D3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Cell("E3").Value = "Out date";
            ws.Cell("E3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("E3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("E3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("E3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Cell("F3").Value = "Returned date";
            ws.Cell("F3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("F3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("F3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("F3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Cell("G3").Value = "Total price";
            ws.Cell("G3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("G3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("G3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("G3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Cell("H3").Value = "Activate";
            ws.Cell("H3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("H3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("H3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("H3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Cell("I3").Value = "Added date";
            ws.Cell("I3").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Cell("I3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell("I3").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell("I3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Range("B2:I2").Merge();
            ws.Range("B2:I2").Value = "Order List";
            ws.Range("B2:I2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.Range("B2:I2").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            ws.Range("B2:I2").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("B2:I2").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("B2:I2").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("B2:I2").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("B2:I2").Style.Fill.BackgroundColor = XLColor.BlueGray;
            ws.Range("B2:I2").Style.Font.FontColor = XLColor.White;
            ws.Range("B2:I2").Style.Font.Bold = true;

            int i = 4;
            foreach (Order item in orders)
            {
                ws.Cell("B" + i + "").Value = item.Id;
                ws.Cell("B" + i + "").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + i + "").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + i + "").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Cell("B" + i + "").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                ws.Cell("C" + i + "").Value = item.Customer.FirstName + " " + item.Customer.LastName; ;
                ws.Cell("C" + i + "").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + i + "").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + i + "").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Cell("C" + i + "").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                ws.Cell("D" + i + "").Value = item.Car.carMark.Name + " " + item.Car.carModel.Name;
                ws.Cell("D" + i + "").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + i + "").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + i + "").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Cell("D" + i + "").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                ws.Cell("E" + i + "").Value = item.OutDate.Value.ToString("dd.MM.yyyy");
                ws.Cell("E" + i + "").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("E" + i + "").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("E" + i + "").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Cell("E" + i + "").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                ws.Cell("F" + i + "").Value = item.ReturnedDate.Value.ToString("dd.MM.yyyy");
                ws.Cell("F" + i + "").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("F" + i + "").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("F" + i + "").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Cell("F" + i + "").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                ws.Cell("G" + i + "").Value = item.TotalPrice.Value.ToString("#.00");
                ws.Cell("G" + i + "").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("G" + i + "").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("G" + i + "").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Cell("G" + i + "").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                ws.Cell("H" + i + "").Value = item.IsActive.ToString();
                ws.Cell("H" + i + "").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("H" + i + "").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("H" + i + "").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Cell("H" + i + "").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                ws.Cell("I" + i + "").Value = item.ReserveDate;
                ws.Cell("I" + i + "").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cell("I" + i + "").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell("I" + i + "").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Cell("I" + i + "").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                i++;
            }
            wb.SaveAs(@"C:\Users\PC\Desktop\Order List.xlsx");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            downloadToExcel();
        }

        private void btnSviewName_Click(object sender, EventArgs e)
        {
            btnSviewName.Visible = false;
            btnSviewNum.Visible = false;
            gbNameS.Visible = true;
        }

        private void btnSviewNum_Click(object sender, EventArgs e)
        {
            btnSviewName.Visible = false;
            btnSviewNum.Visible = false;
            gbSNum.Visible = true;
        }
    }
}
