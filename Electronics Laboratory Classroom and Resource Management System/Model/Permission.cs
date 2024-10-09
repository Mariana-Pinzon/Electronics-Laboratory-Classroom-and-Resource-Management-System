namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Permission
    {
        public int Permission_ID { get; set; }
        public required string PermissionName { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}