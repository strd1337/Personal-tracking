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
    public partial class PermissionList : UserControl
    {
        public PermissionList()
        {
            InitializeComponent();
        }

        private PersonalTrackingContext db = new PersonalTrackingContext();
        private List<PermissionModel> permissions = new List<PermissionModel>();
        private List<Position> positions = new List<Position>();
        private PermissionModel permissionModel = new PermissionModel();

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PermissionPage permissionPage = new PermissionPage();
            permissionPage.ShowDialog();
            FillDataGrid();
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

            List<PermissionState> states = db.PermissionStates.ToList();
            cmbState.ItemsSource = states;
            cmbState.DisplayMemberPath = "PermissionState";
            cmbState.SelectedValuePath = "Id";
            cmbState.SelectedIndex = -1;
        }

        private void FillDataGrid()
        {
            permissions = db.Permissions.Include(x => x.Employee).Include(x => x.PermissionStateNavigation)
                .Select(x => new PermissionModel()
                {
                    DayAmount = x.PermissionDay,
                    DepartmentId = x.Employee.DepartmentId,
                    EmployeeId = x.EmployeeId,
                    EndDate = x.PermissionEndDate,
                    StartDate = x.PermissionStartDate,
                    Explanation = x.PermissionExplanation,
                    Id = x.Id,
                    Name = x.Employee.Name,
                    PositionId = x.Employee.PositionId,
                    StateName = x.PermissionStateNavigation.StateName,
                    Surname = x.Employee.Surname,
                    UserNumber = x.Employee.UserNumber,
                    PermissionState = x.PermissionState
                }).OrderByDescending(x => x.StartDate).ToList();

            if (!UserStatic.IsAdmin)
            {
                permissions = permissions.Where(x => x.EmployeeId == UserStatic.EmployeeId).ToList();
                txtUserNumber.IsEnabled = false;
                txtName.IsEnabled = false;
                txtSurname.IsEnabled = false;
                cmbDepartment.IsEnabled = false;
                cmbPosition.IsEnabled = false;
                btnDelete.Visibility = Visibility.Hidden;
                btnApprove.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Hidden;   
                btnDisapprove.Visibility = Visibility.Hidden;
                btnAdd.SetValue(Grid.ColumnProperty, 4);
            }

            gridPermission.ItemsSource = permissions;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<PermissionModel> search = permissions;

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
            if (rbStart.IsChecked == true)
                search = search.Where(x => x.StartDate > dpStart.SelectedDate
                    && x.StartDate < dpEnd.SelectedDate).ToList();
            if (rbEnd.IsChecked == true)
                search = search.Where(x => x.EndDate > dpStart.SelectedDate
                    && x.EndDate < dpEnd.SelectedDate).ToList();
            if (cmbState.SelectedIndex != -1)
                search = search.Where(x => x.PermissionState == Convert.ToInt32(cmbState.SelectedValue)).ToList();
            if (txtDayAmount.Text.Trim() != "")
                search = search.Where(x => x.DayAmount == Convert.ToInt32(txtDayAmount.Text)).ToList();
            gridPermission.ItemsSource = search;

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDayAmount.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtUserNumber.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbState.SelectedIndex = -1;
            cmbPosition.ItemsSource = positions;
            dpEnd.SelectedDate = DateTime.Today;
            dpStart.SelectedDate = DateTime.Today;
            rbEnd.IsChecked = false;
            rbStart.IsChecked = false;
            gridPermission.ItemsSource = permissions;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (permissionModel != null && permissionModel.Id != 0)
            {
                PermissionPage permissionPage = new PermissionPage();
                permissionPage.permissionModel = permissionModel;
                permissionPage.ShowDialog();
                FillDataGrid();
            }
            else
                MessageBox.Show("Please, select a permission from table.");
        }

        private void gridPermission_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            permissionModel = (PermissionModel)gridPermission.SelectedItem;

        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (permissionModel != null && permissionModel.Id != 0 
                && permissionModel.PermissionState == (int)Definitions.PermissionStates.OnAdmin)
            {
                Permission? permission = db.Permissions.Find(permissionModel.Id);
                permission.PermissionState = (int)Definitions.PermissionStates.Approved;
                db.SaveChanges();
                MessageBox.Show("Permission was approved.");
                FillDataGrid();
            }
        }

        private void btnDisapprove_Click(object sender, RoutedEventArgs e)
        {
            if (permissionModel != null && permissionModel.Id != 0
                && permissionModel.PermissionState == (int)Definitions.PermissionStates.OnAdmin)
            {
                Permission? permission = db.Permissions.Find(permissionModel.Id);
                permission.PermissionState = (int)Definitions.PermissionStates.Disapproved;
                db.SaveChanges();
                MessageBox.Show("Permission was disapproved.");
                FillDataGrid();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete", "Question", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (permissionModel.Id != 0)
                {
                    PermissionModel model = (PermissionModel)gridPermission.SelectedItem;
                    Permission? permission = db.Permissions.Find(model.Id);
                    db.Permissions.Remove(permission);
                    db.SaveChanges();
                    MessageBox.Show("Salary was deleted.");
                    FillDataGrid();
                }
            }
        }
    }
}
