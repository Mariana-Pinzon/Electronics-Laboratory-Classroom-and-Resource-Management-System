using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;


namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IUser_PermissionService
    {
        Task<IEnumerable<User_Permission>> GetAlluser_permissionsAsync();
        Task<User_Permission> GetUser_PermissionByIdAsync(int id);
        Task CreateUser_PermissionAsync(User_Permission user_permission);
        Task UpdateUser_PermissionAsync(User_Permission user_permission);
        Task SoftDeleteUser_PermissionAsync(int id);
    }
    public class User_PermissionService : IUser_PermissionService
    {
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public User_PermissionService(IUser_Permission_Repository userPermissionRepository)
        {
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<User_Permission>> GetAlluser_permissionsAsync()
        {
            return await _userPermissionRepository.GetAlluser_permissionsAsync();
        }

        public async Task<User_Permission> GetUser_PermissionByIdAsync(int id)
        {
            return await _userPermissionRepository.GetUser_PermissionByIdAsync(id);
        }

        public async Task CreateUser_PermissionAsync(User_Permission user_Permission)
        {
            await _userPermissionRepository.CreateUser_PermissionAsync(user_Permission);
        }

        public async Task UpdateUser_PermissionAsync(User_Permission user_Permission)
        {
            await _userPermissionRepository.UpdateUser_PermissionAsync(user_Permission);
        }

        public async Task SoftDeleteUser_PermissionAsync(int id)
        {
            await _userPermissionRepository.SoftDeleteUser_PermissionAsync(id);
        }
    }
}
