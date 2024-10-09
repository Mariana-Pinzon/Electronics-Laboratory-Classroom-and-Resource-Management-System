using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllpermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task SoftDeletePermissionAsync(int id);
    }
    public class PermissionService : IPermissionService
    {
        private readonly IPermission_Repository _permissionRepository;

        public PermissionService(IPermission_Repository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<Permission>> GetAllpermissionsAsync()
        {
            return await _permissionRepository.GetAllpermissionsAsync();
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _permissionRepository.GetPermissionByIdAsync(id);
        }

        public async Task CreatePermissionAsync(Permission permission)
        {
            await _permissionRepository.CreatePermissionAsync(permission);
        }

        public async Task UpdatePermissionAsync(Permission permission)
        {
            await _permissionRepository.UpdatePermissionAsync(permission);
        }

        public async Task SoftDeletePermissionAsync(int id)
        {
            await _permissionRepository.SoftDeletePermissionAsync(id);
        }
    }
}
