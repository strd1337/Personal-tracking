using PersonalTrackingWPF.DB;
using PersonalTrackingWPF.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PersonalTrackingWPF
{
    public partial class PermissionPage : Window
    {
        public PermissionPage()
        {
            InitializeComponent();
        }

        private TimeSpan timeMissionDay = new TimeSpan();
        private PersonalTrackingContext db = new PersonalTrackingContext();
        public PermissionModel? permissionModel;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserNumber.Text = UserStatic.UserNumber;
            if (permissionModel != null && permissionModel.Id != 0)
            {
                txtUserNumber.Text = permissionModel.UserNumber;
                txtDayAmount.Text = permissionModel.DayAmount.ToString();
                txtExplanation.Text = permissionModel.Explanation;
                dpEnd.SelectedDate = permissionModel.EndDate;
                dpStart.SelectedDate = permissionModel.StartDate;
            }
        }

        private void dpStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpEnd.SelectedDate != null)
            {
                timeMissionDay = (TimeSpan)(dpEnd.SelectedDate - dpStart.SelectedDate);
                txtDayAmount.Text = timeMissionDay.TotalDays.ToString();
            }
        }

        private void dpEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpStart.SelectedDate != null)
            {
                timeMissionDay = (TimeSpan)(dpEnd.SelectedDate - dpStart.SelectedDate);
                txtDayAmount.Text = timeMissionDay.TotalDays.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtDayAmount.Text.Trim() == "")
                MessageBox.Show("Please, select start and end dates.");
            else if (Convert.ToInt32(txtDayAmount.Text) <= 0)
                MessageBox.Show("Permission day must be bigger than zero.");
            else if (txtExplanation.Text.Trim() == "")
                MessageBox.Show("Please, write your permission reason.");
            else
            {
                if (permissionModel != null && permissionModel.Id != 0)
                {
                    Permission permission = db.Permissions.Find(permissionModel.Id);
                    permission.PermissionStartDate = (DateTime)dpStart.SelectedDate;
                    permission.PermissionEndDate = (DateTime)dpEnd.SelectedDate;
                    permission.PermissionDay = Convert.ToInt32(txtDayAmount.Text);
                    permission.PermissionExplanation = txtExplanation.Text;
                    db.SaveChanges();
                    MessageBox.Show("Permission was updated.");
                }
                else
                {
                    Permission permission = new Permission();
                    permission.EmployeeId = UserStatic.EmployeeId;
                    permission.PermissionState = (int)Definitions.PermissionStates.OnAdmin;
                    permission.PermissionStartDate = (DateTime)dpStart.SelectedDate;
                    permission.PermissionEndDate = (DateTime)dpEnd.SelectedDate;
                    permission.PermissionExplanation = txtExplanation.Text;
                    permission.PermissionDay = Convert.ToInt16(txtDayAmount.Text);
                    db.Permissions.Add(permission);
                    db.SaveChanges();
                    MessageBox.Show("Permission was added");

                    dpEnd.SelectedDate = DateTime.Today;
                    dpStart.SelectedDate = DateTime.Today;
                    txtDayAmount.Clear();
                    txtExplanation.Clear();
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
