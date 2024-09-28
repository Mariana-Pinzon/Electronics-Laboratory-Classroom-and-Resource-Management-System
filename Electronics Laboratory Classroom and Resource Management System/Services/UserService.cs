using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repository;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUser_Repository _userRepository;

        public UserService(IUser_Repository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _userRepository.GetAllUserAsync();
        }

        public async Task<User> GetUserByIdAsync(int User_ID)
        {
            return await _userRepository.GetUserByIdAsync(User_ID);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task SoftDeleteUserAsync(int User_ID)
        {
            await _userRepository.SoftDeleteUserAsync(User_ID);
        }
    }
}
