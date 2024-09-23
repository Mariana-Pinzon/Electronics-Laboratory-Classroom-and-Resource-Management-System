using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repository;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IUser_TypeService
    {
        Task<IEnumerable<User_Type>> GetAllUser_TypeAsync();
        Task<User_Type> GetUser_TypeByIdAsync(int id);
        Task CreateUser_TypeAsync(User_Type user_type);
        Task UpdateUser_TypeAsync(User_Type user_type);
        Task SoftDeleteUser_TypeAsync(int id);
    }
    public class User_TypeService : IUser_TypeService
    {
        private readonly IUser_Type_Repository _userTypeRepository;

        public User_TypeService(IUser_Type_Repository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<IEnumerable<User_Type>> GetAllUser_TypeAsync()
        {
            return await _userTypeRepository.GetAllUser_TypeAsync();
        }

        public async Task<User_Type> GetUser_TypeByIdAsync(int User_Type_ID)
        {
            return await _userTypeRepository.GetUser_TypeByIdAsync(User_Type_ID);
        }

        public async Task CreateUser_TypeAsync(User_Type user_Type)
        {
            await _userTypeRepository.CreateUser_TypeAsync(user_Type);
        }

        public async Task UpdateUser_TypeAsync(User_Type user_Type)
        {
            await _userTypeRepository.UpdateUser_TypeAsync(user_Type);
        }

        public async Task SoftDeleteUser_TypeAsync(int User_Type_ID)
        {
            await _userTypeRepository.SoftDeleteUser_TypeAsync(User_Type_ID);
        }
    }
}
