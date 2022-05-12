using System;
using System.Collections.Generic;

namespace PersonalTrackingWPF.DB
{
    public partial class Month
    {
        public Month()
        {
            Salaries = new HashSet<Salary>();
        }

        public int Id { get; set; }
        public string Month1 { get; set; } = null!;

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
