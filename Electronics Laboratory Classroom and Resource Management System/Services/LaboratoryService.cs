using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface ILaboratoryService
    {
        Task<IEnumerable<Laboratory>> GetAlllaboratoriesAsync();
        Task<Laboratory> GetLaboratoryByIdAsync(int id);
        Task CreateLaboratoryAsync(int userTypeId, int userPermissionId, Laboratory laboratory);
        Task UpdateLaboratoryAsync(int userTypeId, int userPermissionId, Laboratory laboratory);
        Task SoftDeleteLaboratoryAsync(int userTypeId, int userPermissionId, int id);
    }
    public class LaboratoryService : ILaboratoryService
    {
        private readonly ILaboratory_Repository _laboratoryRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public LaboratoryService(IUser_Permission_Repository userPermissionRepository, ILaboratory_Repository laboratoryRepository)
        {
            _laboratoryRepository = laboratoryRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<Laboratory>> GetAlllaboratoriesAsync()
        {
            return await _laboratoryRepository.GetAlllaboratoriesAsync();
        }

        public async Task<Laboratory> GetLaboratoryByIdAsync(int id)
        {
            return await _laboratoryRepository.GetLaboratoryByIdAsync(id);
        }

        public async Task CreateLaboratoryAsync(int userTypeId, int userPermissionId, Laboratory laboratory)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 3); //Crear Laboratorio/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear laboratorios.");
            }
            await _laboratoryRepository.CreateLaboratoryAsync(laboratory);
        }

        public async Task UpdateLaboratoryAsync(int userTypeId, int userPermissionId, Laboratory laboratory)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 3); //Crear Laboratorio/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar laboratorios.");
            }
            await _laboratoryRepository.UpdateLaboratoryAsync(laboratory);
        }

        public async Task SoftDeleteLaboratoryAsync(int userTypeId, int userPermissionId, int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 3); //Crear Laboratorio/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar laboratorios.");
            }
            await _laboratoryRepository.SoftDeleteLaboratoryAsync(id);
        }
    }
}