using PersonalTrackingWPF.DB;
using PersonalTrackingWPF.Models;
using System;
using System.Linq;
using System.Windows;

namespace PersonalTrackingWPF
{
    public partial class PositionPage : Window
    {
        public PositionPage()
        {
            InitializeComponent();
        }

        private PersonalTrackingContext db = new PersonalTrackingContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = db.Departments.OrderBy(x => x.DepartmentName).ToList();
            cmbDepartment.ItemsSource = list;
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;
            if (model != null && model.Id != 0)
            {
                cmbDepartment.SelectedValue = model.DepartmentId;
                txtPositionName.Text = model.PositionName;
            }
        }

        public PositionModel ? model;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDepartment.SelectedIndex == -1 || txtPositionName.Text.Trim() == "")
            {
                MessageBox.Show("Please, fill areas.");
            }
            else
            {
                if (model != null && model.Id != 0)
                {
                    Position position = new Position();
                    position.DepartmentId = (int)cmbDepartment.SelectedValue;
                    position.Id = model.Id;
                    position.PositionName = txtPositionName.Text;
                    db.Positions.Update(position);
                    db.SaveChanges();
                    MessageBox.Show("Position was updated.");
                }
                else
                {
                    Position position = new Position();
                    position.PositionName = txtPositionName.Text;
                    position.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                    db.Positions.Add(position);
                    db.SaveChanges();
                    cmbDepartment.SelectedIndex = -1;
                    txtPositionName.Clear();
                    MessageBox.Show("Position was added.");
                } 
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
