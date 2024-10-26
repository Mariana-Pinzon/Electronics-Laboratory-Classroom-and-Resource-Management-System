using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllpermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(string PermissionName);
        Task UpdatePermissionAsync(int id, string PermissionName);
        Task SoftDeletePermissionAsync(int id);
    }
    public class PermissionService : IPermissionService
    {
        private readonly IPermission_Repository _permissionRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public PermissionService(IUser_Permission_Repository userPermissionRepository, IPermission_Repository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<Permission>> GetAllpermissionsAsync()
        {
            return await _permissionRepository.GetAllpermissionsAsync();
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _permissionRepository.GetPermissionByIdAsync(id);
        }

        public async Task CreatePermissionAsync(string PermissionName)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1, 4)
                || await _userPermissionRepository.HasPermissions(2, 4);//Crear Permiso/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear permisos.");
            }
            await _permissionRepository.CreatePermissionAsync(PermissionName);
        }

        public async Task UpdatePermissionAsync(int id, string PermissionName)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,4)
                || await _userPermissionRepository.HasPermissions(2, 4);//Crear Permiso/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar permisos.");
            }
            await _permissionRepository.UpdatePermissionAsync(id, PermissionName);
        }

        public async Task SoftDeletePermissionAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,4)
                || await _userPermissionRepository.HasPermissions(2, 4);//Crear Permiso/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar permisos.");
            }
            await _permissionRepository.SoftDeletePermissionAsync(id);
        }
    }
}
