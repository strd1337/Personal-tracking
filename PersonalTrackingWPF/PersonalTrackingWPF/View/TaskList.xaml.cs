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
    public partial class TaskList : UserControl
    {
        public TaskList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TaskPage taskPage = new TaskPage();
            taskPage.ShowDialog();
            FillDataGrid();
        }

        private PersonalTrackingContext db = new PersonalTrackingContext();
        private List<TaskModel> taskList = new List<TaskModel>();
        private List<TaskModel> searchList = new List<TaskModel>();
        private List<Position> positions = new List<Position>();
        private TaskModel taskModel = new TaskModel();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();

            if (!UserStatic.IsAdmin)
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                btnApprove.SetValue(Grid.ColumnProperty, 3);
                btnApprove.Content = "Delivery";
            }
        }

        private void FillDataGrid()
        {
            taskList = db.Tasks.Include(x => x.TaskStateNavigation).Include(x => x.Employee)
                .ThenInclude(x => x.Department).ThenInclude(x => x.Positions)
                .Select(x => new TaskModel()
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    Name = x.Employee.Name,
                    StateName = x.TaskStateNavigation.StateName,
                    Surname = x.Employee.Surname,
                    TaskContent = x.TaskContent,
                    TaskDeliveryDate = x.TaskDeliveryDate,
                    TaskStartDate = x.TaskStartDate,
                    TaskState = x.TaskState,
                    TaskTitle = x.TaskTitle,
                    UserNumber = x.Employee.UserNumber,
                    DepartmentId = x.Employee.DepartmentId,
                    PositionId = x.Employee.PositionId
                }).ToList();

            if (!UserStatic.IsAdmin)
            {
                taskList = taskList.Where(x => x.EmployeeId == UserStatic.EmployeeId).ToList();
                txtUserNumber.IsEnabled = false;
                txtSurname.IsEnabled = false;
                txtName.IsEnabled = false;
                cmbDepartment.IsEnabled = false;
                cmbPosition.IsEnabled = false;
            }

            gridTask.ItemsSource = taskList;
            searchList = taskList;

            cmbDepartment.ItemsSource = db.Departments.ToList();
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;

            positions = db.Positions.ToList();
            cmbPosition.ItemsSource = positions;
            cmbPosition.DisplayMemberPath = "PositionName";
            cmbPosition.SelectedValuePath = "Id";
            cmbPosition.SelectedIndex = -1;

            List<TaskState> taskStates = db.TaskStates.ToList();
            cmbState.ItemsSource = taskStates;
            cmbState.DisplayMemberPath = "StateName";
            cmbState.SelectedValuePath = "Id";
            cmbState.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<TaskModel> search = searchList;

            if (txtUserNumber.Text.Trim() != "")
                search = search.Where(x => Convert.ToInt32(x.UserNumber)
                == Convert.ToInt32(txtUserNumber.Text)).ToList();
            if (txtName.Text.Trim() != "")
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                search = search.Where(x => x.Name.Contains(txtName.Text)).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (txtSurname.Text.Trim() != "")
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                search = search.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (cmbDepartment.SelectedIndex != -1)
                search = search.Where(x => x.DepartmentId == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            if (cmbPosition.SelectedIndex != -1)
                search = search.Where(x => x.PositionId == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            if (cmbState.SelectedIndex != -1)
                search = search.Where(x => x.TaskState == Convert.ToInt32(cmbState.SelectedValue)).ToList();
            if (rbStart.IsChecked == true)
                search = search.Where(x => x.TaskStartDate > dpStart.SelectedDate
                && x.TaskStartDate < dpDelivery.SelectedDate).ToList();
            if (rbDelivery.IsChecked == true)
                search = search.Where(x => x.TaskDeliveryDate > dpStart.SelectedDate
                    && x.TaskDeliveryDate < dpDelivery.SelectedDate).ToList();

            gridTask.ItemsSource = search;
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserNumber.Clear();
            txtName.Clear();
            txtSurname.Clear();
            dpDelivery.SelectedDate = DateTime.Today;
            dpStart.SelectedDate = DateTime.Today;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbState.SelectedIndex = -1;
            cmbPosition.ItemsSource = positions;
            rbDelivery.IsChecked = false;
            rbStart.IsChecked = false;
            gridTask.ItemsSource = taskList;
        }

        private void gridTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            taskModel = (TaskModel)gridTask.SelectedItem;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            TaskPage taskPage = new TaskPage();
            taskPage.taskModel = taskModel;
            taskPage.ShowDialog();
            FillDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete", "Question", MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (taskModel.Id != 0)
                {
                    TaskModel model = (TaskModel)gridTask.SelectedItem;
                    DB.Task? task = db.Tasks.First(t => t.Id == model.Id);
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                    MessageBox.Show("Task was deleted.");
                    FillDataGrid();
                }
            }
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (taskModel != null && taskModel.Id != 0)
            {
                if (UserStatic.IsAdmin && taskModel.TaskState == (int)Definitions.TaskStates.OnEmployee)
                    MessageBox.Show("Before approve a task, task must be delivered.");
                else if (UserStatic.IsAdmin && taskModel.TaskState == (int)Definitions.TaskStates.Approved)
                    MessageBox.Show("This task is already approved.");
                else if (!UserStatic.IsAdmin && taskModel.TaskState == (int)Definitions.TaskStates.Delivered)
                    MessageBox.Show("This task is already delivered.");
                else if (!UserStatic.IsAdmin && taskModel.TaskState == (int)Definitions.TaskStates.Approved)
                    MessageBox.Show("This task is already approved.");
                else
                {
                    DB.Task? task = db.Tasks.Find(taskModel.Id);
                    if (UserStatic.IsAdmin)
                        task.TaskState = (int)Definitions.TaskStates.Approved;
                    else
                    {
                        task.TaskState = (int)Definitions.TaskStates.Delivered;
                        task.TaskDeliveryDate = DateTime.Now;
                    }

                    db.SaveChanges();
                    MessageBox.Show("Task was updated.");
                    FillDataGrid();
                }
            }
        }
    }
}
