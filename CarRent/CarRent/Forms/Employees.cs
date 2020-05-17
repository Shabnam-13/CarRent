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
    public partial class Employees : Form
    {
        private CarRentEntities db;
        private int Id;
        public Employees()
        {
            InitializeComponent();
            this.db = new CarRentEntities();
            fillDgv(db.Employees.ToList());
        }

        private void fillDgv(List<Employee> emp)
        {
            dgvEmp.Rows.Clear();

            foreach (Employee item in emp)
            {
                dgvEmp.Rows.Add(item.Id, item.FirstName, item.LastName,item.UserName,
                    "******",item.Age, item.Position, item.Phone, item.Email != null ? item.Email : "", 
                    item.Address != null ? item.Address : "", item.AddedDate.Value.ToString("dd.MM.yyyy"));
            }
        }

        private void Reset()
        {
            txtName.Text = "";
            txtSname.Text = "";
            txtUname.Text = "";
            txtPass.Text = "";
            numAge.Value = 0;
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPos.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtSname.Text)
                && !string.IsNullOrWhiteSpace(txtPhone.Text) && numAge.Value!=0 && !string.IsNullOrWhiteSpace(txtPos.Text)
                && !string.IsNullOrWhiteSpace(txtUname.Text) && !string.IsNullOrWhiteSpace(txtPass.Text))
            {
                if (db.Employees.FirstOrDefault(u => u.UserName == txtUname.Text) == null)
                {
                    Employee emp = new Employee();
                    emp.FirstName = txtName.Text;
                    emp.LastName = txtSname.Text;
                    emp.UserName = txtUname.Text;
                    emp.Age = Convert.ToInt32(numAge.Value);
                    emp.Position = txtPos.Text;
                    emp.Phone = txtPhone.Text;
                    emp.Email = txtEmail.Text;
                    emp.Address = txtAddress.Text;
                    emp.AddedDate = DateTime.Now;
                    emp.Password = txtPass.Text;

                    db.Employees.Add(emp);
                    db.SaveChanges();
                    MessageBox.Show("Employee added successfully!");
                    Reset();
                    fillDgv(db.Employees.ToList());
                }
                else
                {
                    lblError.Text = "This user name already exists";
                }
            }
            else
            {
                lblError.Text = "Please fill all required(*) data!";
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Employee employee = db.Employees.Find(Id);

            employee.FirstName = txtName.Text;
            employee.LastName = txtSname.Text;
            employee.UserName = txtUname.Text;
            employee.Age = Convert.ToInt32(numAge.Value);
            employee.Position = txtPos.Text;
            employee.Phone = txtPhone.Text;
            employee.Email = txtEmail.Text;
            employee.Address = txtAddress.Text;

            db.SaveChanges();
            fillDgv(db.Employees.ToList());
            Reset();
        }

        private void dgvEmp_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Reset();
            Id = Convert.ToInt32(dgvEmp.Rows[e.RowIndex].Cells[0].Value);
            txtName.Text = dgvEmp.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSname.Text = dgvEmp.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtUname.Text = dgvEmp.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPass.Text = dgvEmp.Rows[e.RowIndex].Cells[4].Value.ToString();
            numAge.Value = Convert.ToInt32(dgvEmp.Rows[e.RowIndex].Cells[5].Value);
            txtPos.Text = dgvEmp.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPhone.Text = dgvEmp.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtEmail.Text = dgvEmp.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtAddress.Text = dgvEmp.Rows[e.RowIndex].Cells[9].Value.ToString();

            lblChangePass.Visible = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Employee employee = db.Employees.Find(Id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            fillDgv(db.Employees.ToList());
            Reset();
        }

        private void lblChangePass_Click(object sender, EventArgs e)
        {
            Change_password pass = new Change_password(Id);
            pass.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Employee> employees = db.Employees.Where(s => (s.FirstName.Contains(txtName.Text)) &&
                                                             (s.LastName.Contains(txtSname.Text)) &&
                                                             (s.UserName.Contains(txtUname.Text)) &&
                                                             (s.Phone.Contains(txtPhone.Text)) &&
                                                             (s.Position.Contains(txtPos.Text)) &&
                                                             (numAge.Value!=0 ? s.Age.Value==numAge.Value :true) &&
                                                             (!string.IsNullOrEmpty(txtEmail.Text) ? s.Email.Contains(txtEmail.Text) : true) &&
                                                             (!string.IsNullOrEmpty(txtAddress.Text) ? s.Address.Contains(txtAddress.Text) : true)
                                                             ).ToList();
            fillDgv(employees);
        }
    }
}

