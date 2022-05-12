using PersonalTrackingWPF.DB;
using System.Windows;

namespace PersonalTrackingWPF
{
    public partial class DepartmentPage : Window
    {
        public DepartmentPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Department ? department;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtDepartmentName.Text.Trim() == "")
            {
                MessageBox.Show("Please, fill the area.");
            }
            else
            {
                using (PersonalTrackingContext db = new PersonalTrackingContext())
                {
                    if (department != null && department.Id != 0)
                    {
                        Department update = new Department();
                        update.DepartmentName = txtDepartmentName.Text;
                        update.Id = department.Id;
                        db.Departments.Update(update);
                        db.SaveChanges();
                        MessageBox.Show("Update was successful.");
                    } 
                    else
                    {
                        Department department = new Department();
                        department.DepartmentName = txtDepartmentName.Text;
                        db.Departments.Add(department);
                        db.SaveChanges();
                        txtDepartmentName.Clear();
                        MessageBox.Show("Department was added.");
                    }
                    
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (department != null && department.Id != 0)
            {
                txtDepartmentName.Text = department.DepartmentName;
            }
        }
    }
}
