using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface ILaboratoryService
    {
        Task<IEnumerable<Laboratory>> GetAlllaboratoriesAsync();
        Task<Laboratory> GetLaboratoryByIdAsync(int id);
        Task CreateLaboratoryAsync(int Laboratory_Num, int Capacity, Laboratory laboratory);
        Task UpdateLaboratoryAsync(int id, int Laboratory_Num, int Capacity);
        Task SoftDeleteLaboratoryAsync(int id);
    }
    public class LaboratoryService : ILaboratoryService
    {
        private readonly ILaboratory_Repository _laboratoryRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public LaboratoryService(IUser_Permission_Repository userPermissionRepository,ILaboratory_Repository laboratoryRepository)
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

        public async Task CreateLaboratoryAsync(int Laboratory_Num, int Capacity, Laboratory laboratory)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 3); //Crear Laboratorio/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear laboratorios.");
            }
            await _laboratoryRepository.CreateLaboratoryAsync(Laboratory_Num, Capacity, laboratory);
        }

        public async Task UpdateLaboratoryAsync(int id, int Laboratory_Num, int Capacity)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 3); //Crear Laboratorio/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar laboratorios.");
            }
            await _laboratoryRepository.UpdateLaboratoryAsync(id,Laboratory_Num,Capacity);
        }

        public async Task SoftDeleteLaboratoryAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId: 1, permissionId: 3); //Crear Laboratorio/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar laboratorios.");
            }
            await _laboratoryRepository.SoftDeleteLaboratoryAsync(id);
        }
    }
}
