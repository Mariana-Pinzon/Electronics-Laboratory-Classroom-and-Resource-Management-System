using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using System.Security.Cryptography.X509Certificates;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repository
{
    public class User_Type_Repository
    {
        public interface IUser_Type_Repository
        {
            Task<IEnumerable<User_Type>> GetAllUser_TypeAsync();
            Task<User_Type> GetUser_TypeByIdAsync(int ID);
            Task CreateUser_TypeAsync(User_Type user_Type);
            Task UpdateUser_TypeAsync(User_Type user_Type);
            Task SoftDeleteUser_TypeAsync(int ID);

        }
    }
}
