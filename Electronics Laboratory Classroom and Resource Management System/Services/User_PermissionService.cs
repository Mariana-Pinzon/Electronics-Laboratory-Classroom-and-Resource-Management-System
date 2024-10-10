using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;


namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IUser_PermissionService
    {
        Task<IEnumerable<User_Permission>> GetAlluser_permissionsAsync();
        Task<User_Permission> GetUser_PermissionByIdAsync(int id);
        Task CreateUser_PermissionAsync(int userTypeId, int userPermissionId, User_Permission user_permission);
        Task UpdateUser_PermissionAsync(int userTypeId, int userPermissionId, User_Permission user_permission);
        Task SoftDeleteUser_PermissionAsync(int userTypeId, int userPermissionId, int id);
        Task<bool> HasPermissionsAsync(int userTypeId, int permissionId);
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

        public async Task CreateUser_PermissionAsync(int userTypeId, int userPermissionId, User_Permission user_Permission)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 9); //Crear Permiso de Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear permiso de Usuario.");
            }
            await _userPermissionRepository.CreateUser_PermissionAsync(user_Permission);
        }

        public async Task UpdateUser_PermissionAsync(int userTypeId, int userPermissionId, User_Permission user_Permission)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 9); //Crear Permiso de Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar permiso de Usuario.");
            }
            await _userPermissionRepository.UpdateUser_PermissionAsync(user_Permission);
        }

        public async Task SoftDeleteUser_PermissionAsync(int userTypeId, int userPermissionId, int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 9); //Crear Permiso de Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar permiso de Usuario.");
            }
            await _userPermissionRepository.SoftDeleteUser_PermissionAsync(id);
        }

        public async Task<bool> HasPermissionsAsync(int userTypeId, int permissionId)
        {
            return await _userPermissionRepository.HasPermissions(userTypeId, permissionId);
        }
    }
}
