
namespace PersonalTrackingWPF.Models
{
    public class SalaryModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? UserNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Amount { get; set; }
        public string? MonthName { get; set; }
        public int MonthId { get; set; }
        public int Year { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
    }
}
