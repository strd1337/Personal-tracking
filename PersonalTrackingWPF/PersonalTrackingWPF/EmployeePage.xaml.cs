using Microsoft.Win32;
using PersonalTrackingWPF.DB;
using PersonalTrackingWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PersonalTrackingWPF
{ 
    public partial class EmployeePage : Window
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private PersonalTrackingContext db = new PersonalTrackingContext();
        private List<Position> positions = new List<Position>();
        private OpenFileDialog dialog = new OpenFileDialog();
        public EmployeeDetailModel? model;

        private void Window_Loaded(object sender, RoutedEventArgs e)
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

            pickerOne.SelectedDate = DateTime.Today;

            if (model != null && model.Id != 0)
            {
                cmbDepartment.SelectedValue = model.DepartmentId;
                cmbPosition.SelectedValue = model.PositionId;
                txtUserNumber.Text = model.UserNumber;
                txtPassword.Text = model.Password;
                txtName.Text = model.Name;
                txtSurname.Text = model.Surname;
                txtSalary.Text = model.Salary.ToString();
                txtAdress.AppendText(model.Adress);
                pickerOne.SelectedDate = model.Birthday;
                chkisAdmin.IsChecked = model.isAdmin;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"Images/" + model.ImagePath, UriKind.RelativeOrAbsolute);
                image.EndInit();
                imgEmployee.Source = image;
            }

            if (!UserStatic.IsAdmin)
            {
                chkisAdmin.IsEnabled = false;
                txtUserNumber.IsEnabled = false;
                txtSalary.IsEnabled = false;
                cmbDepartment.IsEnabled = false;
                cmbPosition.IsEnabled = false;
            }
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

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            if (dialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(dialog.FileName);
                image.EndInit();
                imgEmployee.Source = image;
                txtImage.Text = dialog.FileName;
            }
        }

        private void txtUserNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserNumber.Text.Trim() == "" || txtPassword.Text.Trim() == ""
                || txtName.Text.Trim() == "" || txtSurname.Text.Trim() == ""
                || txtSalary.Text.Trim() == "" || cmbDepartment.SelectedIndex == -1
                || cmbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Please, fill the areas.");
            }
            else
            {
                Employee employee = new Employee();
                employee.UserNumber = txtUserNumber.Text;
                employee.Password = txtPassword.Text;
                employee.Name = txtName.Text;
                employee.Surname = txtSurname.Text;
                employee.Salary = Convert.ToInt32(txtSalary.Text);
                employee.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                employee.PositionId = Convert.ToInt32(cmbPosition.SelectedValue);
                TextRange text = new TextRange(txtAdress.Document.ContentStart, txtAdress.Document.ContentEnd);
                employee.Adress = text.Text;

#pragma warning disable CS8629 // Nullable value type may be null.
                employee.Birthday = (DateTime)pickerOne.SelectedDate;
#pragma warning restore CS8629 // Nullable value type may be null.

#pragma warning disable CS8629 // Nullable value type may be null.
                employee.IsAdmin = (bool)chkisAdmin.IsChecked;
#pragma warning restore CS8629 // Nullable value type may be null.

                string filename = "";
                string unique = Guid.NewGuid().ToString();
                filename += unique + dialog.SafeFileName;
                employee.ImagePath = filename;

                db.Employees.Add(employee);
                db.SaveChanges();

                File.Copy(txtImage.Text, @"Images//" + filename);
                MessageBox.Show("Employee was added");

                txtUserNumber.Clear();
                txtPassword.Clear();
                txtName.Clear();
                txtSurname.Clear();
                txtSalary.Clear();
                pickerOne.SelectedDate = DateTime.Today;
                cmbDepartment.SelectedIndex = -1;
                cmbPosition.ItemsSource = positions;
                cmbPosition.SelectedIndex = -1;
                txtAdress.Document.Blocks.Clear();
                chkisAdmin.IsChecked = false;
                imgEmployee.Source = new BitmapImage();
                txtImage.Clear();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtSalary_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
