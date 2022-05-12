using PersonalTrackingWPF.DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PersonalTrackingWPF.View
{
    public partial class DepartmentList : UserControl
    {
        public DepartmentList()
        {
            InitializeComponent();

            InitializeDb();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DepartmentPage departmentPage = new DepartmentPage();
            departmentPage.ShowDialog();
            InitializeDb();
        }

        private void InitializeDb()
        {
            using (PersonalTrackingContext db = new PersonalTrackingContext())
            {
                List<Department> departments = db.Departments.OrderBy(x => x.DepartmentName).ToList();
                gridDepartment.ItemsSource = departments;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Department dprt = (Department)gridDepartment.SelectedItem;
            if (dprt != null && dprt.Id != 0)
            {
                DepartmentPage departmentPage = new DepartmentPage();
                departmentPage.department = dprt;
                departmentPage.ShowDialog();
                using (PersonalTrackingContext db = new PersonalTrackingContext())
                {
                    gridDepartment.ItemsSource = db.Departments.OrderBy(x => x.DepartmentName).ToList();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Department dprt = (Department)gridDepartment.SelectedItem;
            if (dprt != null && dprt.Id != 0)
            {
                if (MessageBox.Show("Are you sure to delete?", "Question", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    PersonalTrackingContext db = new PersonalTrackingContext();
                    List<Position> positions = db.Positions.Where(x => x.DepartmentId == dprt.Id).ToList();
                    foreach (var item in positions)
                        db.Positions.Remove(item);

                    Department? department = db.Departments.Find(dprt.Id);
                    db.Departments.Remove(department);
                    db.SaveChanges();

                    MessageBox.Show("Department was deleted.");
                    gridDepartment.ItemsSource = db.Departments.ToList();
                }
            }
        }
    }
}
