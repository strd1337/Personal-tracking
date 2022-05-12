using System;
using System.Collections.Generic;

namespace PersonalTrackingWPF.DB
{
    public partial class Permission
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime PermissionStartDate { get; set; }
        public DateTime PermissionEndDate { get; set; }
        public int PermissionState { get; set; }
        public string? PermissionExplanation { get; set; }
        public int PermissionDay { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual PermissionState PermissionStateNavigation { get; set; } = null!;
    }
}
