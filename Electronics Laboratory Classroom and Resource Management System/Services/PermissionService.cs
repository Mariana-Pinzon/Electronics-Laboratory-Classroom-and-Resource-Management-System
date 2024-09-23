using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repository;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllPermissionAsync();
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

        public async Task<IEnumerable<Permission>> GetAllPermissionAsync()
        {
            return await _permissionRepository.GetAllPermissionAsync();
        }

        public async Task<Permission> GetPermissionByIdAsync(int Permission_ID)
        {
            return await _permissionRepository.GetPermissionByIdAsync(Permission_ID);
        }

        public async Task CreatePermissionAsync(Permission permission)
        {
            await _permissionRepository.CreatePermissionAsync(permission);
        }

        public async Task UpdatePermissionAsync(Permission permission)
        {
            await _permissionRepository.UpdatePermissionAsync(permission);
        }

        public async Task SoftDeletePermissionAsync(int Permission_ID)
        {
            await _permissionRepository.SoftDeletePermissionAsync(Permission_ID);
        }
    }
}
