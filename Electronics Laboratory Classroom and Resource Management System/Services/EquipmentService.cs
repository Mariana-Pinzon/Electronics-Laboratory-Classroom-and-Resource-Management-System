using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetAllequipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task CreateEquipmentAsync(string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID);
        Task UpdateEquipmentAsync(int id, string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID);
        Task SoftDeleteEquipmentAsync(int id);
    }

    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipment_Repository _equipmentRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public EquipmentService(IUser_Permission_Repository userPermissionRepository, IEquipment_Repository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<Equipment>> GetAllequipmentsAsync()
        {
            return await _equipmentRepository.GetAllequipmentsAsync();
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            return await _equipmentRepository.GetEquipmentByIdAsync(id);
        }

        public async Task CreateEquipmentAsync(string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 1); //Crear Equipo/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear equipos.");
            }

                await _equipmentRepository.CreateEquipmentAsync(Equipment_Name, Description, StatusE_ID, Acquisition_date, Laboratory_ID);
        }

        public async Task UpdateEquipmentAsync(int id, string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 1); //Crear Equipo/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar equipos.");
            }
            await _equipmentRepository.UpdateEquipmentAsync(id, Equipment_Name, Description, StatusE_ID, Acquisition_date, Laboratory_ID);
        }

        public async Task SoftDeleteEquipmentAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 1); //Crear Equipo/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar equipos.");
            }
                await _equipmentRepository.SoftDeleteEquipmentAsync(id);
        }
    }
}