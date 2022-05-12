using PersonalTrackingWPF.DB;
using PersonalTrackingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalTrackingWPF
{
    public partial class SalaryPage : Window
    {
        public SalaryPage()
        {
            InitializeComponent();
        }
        private PersonalTrackingContext db = new PersonalTrackingContext();
        private int EmployeeId = 0;
        private List<Position> positions = new List<Position>();
        private List<Employee> employeeList = new List<Employee>();
        public SalaryModel? salaryModel;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employeeList = db.Employees.ToList();
            gridEmployee.ItemsSource = employeeList;

            cmbDepartment.ItemsSource = db.Departments.ToList();
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;

            positions = db.Positions.ToList();
            cmbPosition.ItemsSource = positions;
            cmbPosition.DisplayMemberPath = "PositionName";
            cmbPosition.SelectedValuePath = "Id";
            cmbPosition.SelectedIndex = -1;

            List<Month> months = db.Months.ToList();
            cmbMonth.ItemsSource = months;
            cmbMonth.DisplayMemberPath = "Month1";
            cmbMonth.SelectedValuePath = "Id";
            cmbMonth.SelectedIndex = -1;

            if (salaryModel != null && salaryModel.Id != 0)
            {
                txtName.Text = salaryModel.Name;
                txtSalary.Text = salaryModel.Amount.ToString();
                txtSurname.Text = salaryModel.Surname;
                txtUserNumber.Text = salaryModel.UserNumber;
                txtYear.Text = salaryModel.Year.ToString();
                EmployeeId = salaryModel.EmployeeId;
                cmbMonth.SelectedValue = salaryModel.MonthId;
            }
        }

        private void gridEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employee = (Employee)gridEmployee.SelectedItem;
            txtUserNumber.Text = employee.UserNumber;
            txtName.Text = employee.Name;
            txtSurname.Text = employee.Surname;
            txtYear.Text = DateTime.Now.Year.ToString();
            txtSalary.Text = employee.Salary.ToString();
            txtSurname.Text = employee.Surname;
            EmployeeId = employee.Id;
        }

        private void cmbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
            if (cmbDepartment.SelectedIndex != -1)
            {
                cmbPosition.ItemsSource = positions.Where(x => x.DepartmentId == DepartmentId).ToList();
                cmbPosition.DisplayMemberPath = "PositionName";
                cmbPosition.SelectedValuePath = "Id";
                cmbPosition.SelectedIndex = -1;
            } 
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtSalary.Text.Trim() == "" || txtYear.Text.Trim() == ""
                || cmbMonth.SelectedIndex == -1)
                MessageBox.Show("Please, fill the areas.");
            else
            {
                if (salaryModel != null && salaryModel.Id != 0)
                {
                    Salary? salary = db.Salaries.Find(salaryModel.Id);
                    int oldSalary = salary.Amount;
                    salary.Amount = Convert.ToInt32(txtSalary.Text);
                    salary.EmployeeId = EmployeeId;
                    salary.MonthId = Convert.ToInt32(cmbMonth.SelectedValue);
                    salary.Year = Convert.ToInt32(txtYear.Text);
                    db.SaveChanges();

                    if (oldSalary < salary.Amount)
                    {
                        Employee? employee = db.Employees.Find(EmployeeId);
                        employee.Salary = salary.Amount;
                        db.SaveChanges();
                    }

                    MessageBox.Show("Salary was updated.");
                }
                else
                {
                    if (EmployeeId == 0)
                        MessageBox.Show("Please, select an employee.");
                    else
                    {
                        Salary salary = new Salary();
                        salary.EmployeeId = EmployeeId;
                        salary.Amount = Convert.ToInt32(txtSalary.Text);
                        salary.MonthId = Convert.ToInt32(cmbMonth.SelectedValue);
                        salary.Year = Convert.ToInt32(txtYear.Text);
                        db.Salaries.Add(salary);
                        db.SaveChanges();
                        MessageBox.Show("Salary was added");

                        EmployeeId = 0;
                        txtName.Clear();
                        txtSalary.Clear();
                        cmbMonth.SelectedIndex = -1;
                        txtSurname.Clear();
                        txtYear.Text = DateTime.Now.Year.ToString();
                        gridEmployee.ItemsSource = employeeList;
                        cmbDepartment.SelectedIndex = -1;
                        cmbPosition.SelectedIndex = -1;
                        txtUserNumber.Clear();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
