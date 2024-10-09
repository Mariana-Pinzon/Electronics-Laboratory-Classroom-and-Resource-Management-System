using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;

namnamespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class User_Permission
{
    public int UserP_ID { get; set; }
    public virtual required User_Type User_Type { get; set; }
    public virtual required Permission Permission { get; set; }
    public bool IsDeleted { get; set; } = false;
}
}