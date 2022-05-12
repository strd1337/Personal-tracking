using System;
using System.Collections.Generic;

namespace PersonalTrackingWPF.DB
{
    public partial class Employee
    {
        public Employee()
        {
            Permissions = new HashSet<Permission>();
            Salaries = new HashSet<Salary>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string UserNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime Birthday { get; set; } 
        public string Adress { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int Salary { get; set; }
        public string ImagePath { get; set; } = null!;
        public bool IsAdmin { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Position Position { get; set; } = null!;
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
