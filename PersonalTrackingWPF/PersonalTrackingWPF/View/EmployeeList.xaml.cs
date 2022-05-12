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
    public partial class EmployeeList : UserControl
    {
        public EmployeeList()
        {
            InitializeComponent();
        }

        private PersonalTrackingContext db = new PersonalTrackingContext();
        private List<Position> positions = new List<Position>();
        private List<EmployeeDetailModel> list = new List<EmployeeDetailModel>();

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage employeePage = new EmployeePage();
            employeePage.ShowDialog();
            FillDataGrid();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            cmbDepartment.ItemsSource = db.Departments.ToList();
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;

            positions = db.Positions.ToList();
            cmbPosition.ItemsSource = positions;
            cmbPosition.DisplayMemberPath = "PositionName";
            cmbPosition.SelectedValuePath = "Id";
            cmbPosition.SelectedIndex = -1;

            list = db.Employees.Include(x => x.Position).Include(x => x.Department).Select(x => new EmployeeDetailModel
            {
                Id = x.Id,
                Name = x.Name,
                Adress = x.Adress,
                Birthday = x.Birthday,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName,
                isAdmin = x.IsAdmin,
                Password = x.Password,
                PositionId = x.PositionId,
                PositionName = x.Position.PositionName,
                Salary = x.Salary,
                Surname = x.Surname,
                UserNumber = x.UserNumber,
                ImagePath = x.ImagePath
            }).ToList();

            gridEmployee.ItemsSource = list;
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
            List<EmployeeDetailModel> searchList = list;
            if (txtUserNumber.Text.Trim() != "")
                searchList = searchList.Where(x => Convert.ToInt32(x.UserNumber) == Convert.ToInt32(txtUserNumber.Text)).ToList();
            if (txtName.Text.Trim() != "")
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                searchList = searchList.Where(x => x.Name.Contains(txtName.Text)).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (txtSurname.Text.Trim() != "")
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                searchList = searchList.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (cmbPosition.SelectedIndex != -1)
                searchList = searchList.Where(x => x.PositionId == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            if (cmbDepartment.SelectedIndex != -1)
                searchList = searchList.Where(x => x.DepartmentId == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();

            gridEmployee.ItemsSource = searchList;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtSurname.Clear();
            txtUserNumber.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.ItemsSource = positions;
            cmbPosition.SelectedIndex = -1;
            gridEmployee.ItemsSource = list;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDetailModel employeeModel = (EmployeeDetailModel)gridEmployee.SelectedItem;

            if (employeeModel != null && employeeModel.Id != 0)
            {
                if (MessageBox.Show("Are you sure to delete?", "Question", MessageBoxButton.YesNo, 
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Employee? employee = db.Employees.Find(employeeModel.Id);
                    db.Employees.Remove(employee);
                    db.SaveChanges();

                    MessageBox.Show("Employee was deleted.");
                    FillDataGrid();
                }
            }
        }
    }
}
