using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IStatus_EquipmentService
    {
        Task<IEnumerable<Status_Equipment>> GetAllstatus_equipmentsAsync();
        Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int id);
        Task CreateStatus_EquipmentAsync(string Status);
        Task UpdateStatus_EquipmentAsync(int id, string Status);
        Task SoftDeleteStatus_EquipmentAsync(int id);
    }
    public class Status_EquipmentService : IStatus_EquipmentService
    {
        private readonly IStatus_Equipment_Repository _status_equipmentRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public Status_EquipmentService(IUser_Permission_Repository userPermissionRepository, IStatus_Equipment_Repository status_equipmentRepository)
        {
            _status_equipmentRepository = status_equipmentRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<Status_Equipment>> GetAllstatus_equipmentsAsync()
        {
            return await _status_equipmentRepository.GetAllstatus_equipmentsAsync();
        }

        public async Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int id)
        {
            return await _status_equipmentRepository.GetStatus_EquipmentByIdAsync(id);
        }

        public async Task CreateStatus_EquipmentAsync(string Status)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 7); //Crear Status de Equipo/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear un status de equipo.");
            }
            await _status_equipmentRepository.CreateStatus_EquipmentAsync(Status);
        }

        public async Task UpdateStatus_EquipmentAsync(int id, string Status)
        {
            await _status_equipmentRepository.UpdateStatus_EquipmentAsync(id, Status);
        }

        public async Task SoftDeleteStatus_EquipmentAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 7); //Crear Status de Equipo/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar un status de equipo.");
            }
            await _status_equipmentRepository.SoftDeleteStatus_EquipmentAsync(id);
        }
    }
}