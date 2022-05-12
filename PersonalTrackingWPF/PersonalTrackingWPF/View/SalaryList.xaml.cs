using Microsoft.EntityFrameworkCore;
using PersonalTrackingWPF.DB;
using PersonalTrackingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PersonalTrackingWPF.View
{
    public partial class SalaryList : UserControl
    {
        public SalaryList()
        {
            InitializeComponent();
        }

        private List<SalaryModel> salaries = new List<SalaryModel>();
        private PersonalTrackingContext db = new PersonalTrackingContext();
        private List<Position> positions = new List<Position>();
        private SalaryModel salaryModel = new SalaryModel();

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SalaryPage salaryPage = new SalaryPage();
            salaryPage.ShowDialog();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            salaries = db.Salaries.Include(x => x.Employee).Include(x => x.Month).
                Select(x => new SalaryModel()
                {
                    UserNumber = x.Employee.UserNumber,
                    Name = x.Employee.Name,
                    Surname = x.Employee.Surname,
                    Amount = x.Amount,
                    EmployeeId = x.EmployeeId,
                    Id = x.Id,
                    MonthId = x.MonthId,
                    MonthName = x.Month.Month1,
                    Year = x.Year,
                    PositionId = x.Employee.PositionId,
                    DepartmentId = x.Employee.DepartmentId
                }).OrderByDescending(x => x.Year).OrderByDescending(x => x.MonthId).ToList();

            if (!UserStatic.IsAdmin)
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                salaries = salaries.Where(x => x.EmployeeId == UserStatic.EmployeeId).ToList();
                txtUserNumber.IsEnabled = false;
                txtName.IsEnabled = false;
                txtSurname.IsEnabled = false;
                cmbDepartment.IsEnabled = false;
                cmbPosition.IsEnabled = false;
            }

            gridSalary.ItemsSource = salaries;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<SalaryModel> search = salaries;
            if (txtUserNumber.Text.Trim() != "")
                search = search.Where(x => Convert.ToInt32(x.UserNumber) == Convert.ToInt32(txtUserNumber.Text)).ToList();
            if (txtName.Text.Trim() != "")
                search = search.Where(x => x.Name.Contains(txtName.Text)).ToList();
            if (txtSurname.Text.Trim() != "")
                search = search.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();
            if (cmbDepartment.SelectedIndex != -1)
                search = search.Where(x => x.DepartmentId == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            if (cmbPosition.SelectedIndex != -1)
                search = search.Where(x => x.PositionId == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            if (txtYear.Text.Trim() != "")
                search = search.Where(x => x.Year == Convert.ToInt32(txtYear.Text)).ToList();
            if (cmbMonth.SelectedIndex != -1)
                search = search.Where(x => x.MonthId == Convert.ToInt32(cmbMonth.SelectedValue)).ToList();
            if (txtSalary.Text.Trim() != "")
            {
                if (rbMore.IsChecked == true)
                    search = search.Where(x => x.Amount > Convert.ToInt32(txtSalary.Text)).ToList();
                else if (rbLess.IsChecked == true)
                    search = search.Where(x => x.Amount < Convert.ToInt32(txtSalary.Text)).ToList();
                else
                    search = search.Where(x => x.Amount == Convert.ToInt32(txtSalary.Text)).ToList();
            }

            gridSalary.ItemsSource = search;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtSalary.Clear();
            txtSurname.Clear();
            txtUserNumber.Clear();
            txtYear.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            rbEquals.IsChecked = false;
            rbLess.IsChecked = false;
            rbMore.IsChecked = false;
            gridSalary.ItemsSource = salaries;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SalaryPage salaryPage = new SalaryPage();
            salaryPage.salaryModel = salaryModel;
            salaryPage.ShowDialog();
            FillDataGrid();
        }

        private void gridSalary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            salaryModel = (SalaryModel)gridSalary.SelectedItem;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete", "Question", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (salaryModel.Id != 0)
                {
                    SalaryModel model = (SalaryModel)gridSalary.SelectedItem;
                    Salary? salary = db.Salaries.Find(model.Id);
                    db.Salaries.Remove(salary);
                    db.SaveChanges();
                    MessageBox.Show("Salary was deleted.");
                    FillDataGrid();
                }
            }
        }
    }
}
