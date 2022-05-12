using PersonalTrackingWPF.DB;
using PersonalTrackingWPF.Models;
using PersonalTrackingWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace PersonalTrackingWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblWindowName.Content = "Task List";
            DataContext = new TaskViewModel();
        }

        private void btnDepartment_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Department List";
            DataContext = new DepartmentViewModel();
        }

        private void btnPosition_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Position List";
            DataContext = new PositionViewModel();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (!UserStatic.IsAdmin)
            {
                PersonalTrackingContext db = new PersonalTrackingContext();
                Employee? employee = db.Employees.Find(UserStatic.EmployeeId);
                EmployeeDetailModel model = new EmployeeDetailModel();
                
                model.Adress = employee.Adress;
                model.Birthday = employee.Birthday;
                model.DepartmentId = employee.DepartmentId;
                model.Id = employee.Id;
                model.ImagePath = employee.ImagePath;
                model.isAdmin = employee.IsAdmin;
                model.Name = employee.Name;
                model.Password = employee.Password;
                model.PositionId = employee.PositionId;
                model.Salary = employee.Salary;
                model.Surname = employee.Surname;
                model.UserNumber = employee.UserNumber;

                EmployeePage employeePage = new EmployeePage();
                employeePage.model = model;
                employeePage.ShowDialog();
            }
            else
            {
                lblWindowName.Content = "Employee List";
                DataContext = new EmployeeViewModel();
            }
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Task List";
            DataContext = new TaskViewModel();
        }

        private void btnSalary_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Salary List";
            DataContext = new SalaryViewModel();
        }

        private void btnPermission_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Permission List";
            DataContext = new PermissionViewModel();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PersonalMainWindow_Closed(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void PersonalMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!UserStatic.IsAdmin)
            {
                stackDepartment.Visibility = Visibility.Hidden;
                stackPosition.Visibility = Visibility.Hidden;
                stackLogout.SetValue(Grid.RowProperty, 5);
                stackExit.SetValue(Grid.RowProperty, 6);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
