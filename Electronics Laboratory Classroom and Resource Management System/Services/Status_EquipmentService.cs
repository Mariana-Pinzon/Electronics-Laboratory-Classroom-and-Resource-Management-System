using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IStatus_EquipmentService
    {
        Task<IEnumerable<Status_Equipment>> GetAllstatus_equipmentsAsync();
        Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int id);
        Task CreateStatus_EquipmentAsync(Status_Equipment status_Equipment);
        Task UpdateStatus_EquipmentAsync(Status_Equipment status_Equipment);
        Task SoftDeleteStatus_EquipmentAsync(int id);
    }
    public class Status_EquipmentService : IStatus_EquipmentService
    {
        private readonly IStatus_Equipment_Repository _status_equipmentRepository;

        public Status_EquipmentService(IStatus_Equipment_Repository status_equipmentRepository)
        {
            _status_equipmentRepository = status_equipmentRepository;
        }

        public async Task<IEnumerable<Status_Equipment>> GetAllstatus_equipmentsAsync()
        {
            return await _status_equipmentRepository.GetAllstatus_equipmentsAsync();
        }

        public async Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int id)
        {
            return await _status_equipmentRepository.GetStatus_EquipmentByIdAsync(id);
        }

        public async Task CreateStatus_EquipmentAsync(Status_Equipment status_equipment)
        {
            await _status_equipmentRepository.CreateStatus_EquipmentAsync(status_equipment);
        }

        public async Task UpdateStatus_EquipmentAsync(Status_Equipment status_equipment)
        {
            await _status_equipmentRepository.UpdateStatus_EquipmentAsync(status_equipment);
        }

        public async Task SoftDeleteStatus_EquipmentAsync(int id)
        {
            await _status_equipmentRepository.SoftDeleteStatus_EquipmentAsync(id);
        }
    }
}