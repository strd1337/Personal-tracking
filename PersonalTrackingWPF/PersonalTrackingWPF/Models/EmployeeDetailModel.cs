using System;

namespace PersonalTrackingWPF.Models
{
    public class EmployeeDetailModel
    {
        public int Id { get; set; }
        public string? UserNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PositionName { get; set; }
        public int PositionId { get; set; }
        public string? DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
        public bool isAdmin { get; set; }
        public DateTime Birthday { get; set; }
        public string? Adress { get; set; }
        public string? Password { get; set; }
        public string? ImagePath { get; set; }
    }
}
