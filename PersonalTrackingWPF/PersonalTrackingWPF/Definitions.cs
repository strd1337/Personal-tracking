
namespace PersonalTrackingWPF
{
    public static class Definitions
    {
        public enum TaskStates : int
        {
            OnEmployee = 1,
            Delivered = 2,
            Approved = 3,
        }

        public enum PermissionStates : int
        {
            OnAdmin = 1,
            Approved = 2,
            Disapproved = 3,
        }
    }
}
