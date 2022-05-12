using System;
using System.Collections.Generic;

namespace PersonalTrackingWPF.DB
{
    public partial class PermissionState
    {
        public PermissionState()
        {
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string StateName { get; set; } = null!;

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
