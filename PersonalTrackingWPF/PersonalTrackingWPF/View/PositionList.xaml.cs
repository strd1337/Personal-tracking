using Microsoft.EntityFrameworkCore;
using PersonalTrackingWPF.DB;
using PersonalTrackingWPF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PersonalTrackingWPF.View
{
    public partial class PositionList : UserControl
    {
        public PositionList()
        {
            InitializeComponent();
        }

        private PersonalTrackingContext db = new PersonalTrackingContext();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillGrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PositionPage positionPage = new PositionPage();
            positionPage.ShowDialog();
            FillGrid();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            PositionModel positionModel = (PositionModel)gridPosition.SelectedItem;
            if (positionModel != null && positionModel.Id != 0)
            {
                PositionPage positionPage = new PositionPage();
                positionPage.model = positionModel;
                positionPage.ShowDialog();
                FillGrid();
            }
        }

        private void FillGrid()
        {
            var list = db.Positions.Include(x => x.Department).Select(a => new
            {
                positionId = a.Id,
                PositionName = a.PositionName,
                departmentId = a.DepartmentId,
                departmentName = a.Department.DepartmentName
            }).OrderBy(x => x.PositionName).ToList();

            List<PositionModel> modelList = new List<PositionModel>();
            foreach (var item in list)
            {
                PositionModel model = new PositionModel();
                model.Id = item.positionId;
                model.PositionName = item.PositionName;
                model.DepartmentName = item.departmentName;
                model.DepartmentId = item.departmentId;
                modelList.Add(model);
            }
            gridPosition.ItemsSource = modelList;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PositionModel positionModel = (PositionModel)gridPosition.SelectedItem;

            if (positionModel != null && positionModel.Id != 0)
            {
                if (positionModel != null && positionModel.Id != 0)
                {
                    if (MessageBox.Show("Are you sure to delete?", "Question", MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Position? position = db.Positions.Find(positionModel.Id);
                        db.Positions.Remove(position);
                        db.SaveChanges();

                        MessageBox.Show("Employee was deleted.");
                        FillGrid();
                    }
                }
            }
        }  
    }
}
