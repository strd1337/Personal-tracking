using PersonalTrackingWPF.DB;
using PersonalTrackingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace PersonalTrackingWPF
{
    public partial class TaskPage : Window
    {
        public TaskPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private PersonalTrackingContext db = new PersonalTrackingContext();
        private List<Employee> employeeList = new List<Employee>();
        private int EmployeeId = 0;
        private List<Position> positions = new List<Position>();
        public TaskModel? taskModel;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employeeList = db.Employees.OrderBy(x => x.Name).ToList();
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

            if (taskModel != null && taskModel.Id != 0)
            {
                txtUserNumber.Text = taskModel.UserNumber;
                txtName.Text = taskModel.Name;
                txtSurname.Text = taskModel.Surname;
                txtTitle.Text = taskModel.TaskTitle;
                txtContent.Text = taskModel.TaskContent;
            }
        }

        private void gridEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employee = (Employee)gridEmployee.SelectedItem;
            txtUserNumber.Text = employee.UserNumber.ToString();
            txtName.Text = employee.Name;
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
            if (txtTitle.Text.Trim() == "" || txtContent.Text.Trim() == "")
                MessageBox.Show("Please, fill the areas.");
            else
            {
                if (taskModel != null && taskModel.Id != 0)
                {
                    DB.Task? task = db.Tasks.Find(taskModel.Id);

                    if (EmployeeId != 0)
                        task.EmployeeId = EmployeeId;

                    task.TaskTitle = txtTitle.Text;
                    task.TaskContent = txtContent.Text;
                    db.SaveChanges();
                    MessageBox.Show("Task was updated.");
                }
                else
                {
                    if (EmployeeId == 0)
                    {
                        MessageBox.Show("Please, select an employee from table.");
                    }
                    else
                    {
                        DB.Task task = new DB.Task();
                        task.EmployeeId = EmployeeId;
                        task.TaskStartDate = DateTime.Now;
                        task.TaskTitle = txtTitle.Text;
                        task.TaskContent = txtContent.Text;
                        task.TaskState = (int)Definitions.TaskStates.OnEmployee;
                        db.Tasks.Add(task);
                        db.SaveChanges();
                        MessageBox.Show("Task was added");

                        EmployeeId = 0;
                        txtContent.Clear();
                        txtTitle.Clear();
                        txtUserNumber.Clear();
                        txtName.Clear();
                        txtSurname.Clear();
                    }
                }
            }
        }
    }
}
