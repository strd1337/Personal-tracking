using PersonalTrackingWPF.DB;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace PersonalTrackingWPF
{
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private PersonalTrackingContext db = new PersonalTrackingContext();

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserNumber.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                MessageBox.Show("Please, fill the user number and password");
            else
            {
                Employee? employee = db.Employees.FirstOrDefault(x => Convert.ToInt32(x.UserNumber)
                    == Convert.ToInt32(txtUserNumber.Text) && x.Password.Equals(txtPassword.Text));

                if (employee != null && employee.Id != 0)
                {
                    this.Visibility = Visibility.Collapsed;
                    MainWindow main = new MainWindow();

                    UserStatic.EmployeeId = employee.Id;
                    UserStatic.IsAdmin = employee.IsAdmin;
                    UserStatic.Name = employee.Name;
                    UserStatic.Surname = employee.Surname;
                    UserStatic.UserNumber = employee.UserNumber;

                    main.ShowDialog();

                    txtPassword.Clear();
                    txtUserNumber.Clear();
                    this.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Please, make sure that your user number and password is true.");
                }
            }
        }

        private void txtUserNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
