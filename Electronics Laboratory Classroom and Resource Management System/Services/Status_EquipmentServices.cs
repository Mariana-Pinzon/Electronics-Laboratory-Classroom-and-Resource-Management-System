using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IStatus_EquipmentService
    {
        Task<IEnumerable<Status_Equipment>> GetAllStatus_EquipmentAsync();
        Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int id);
        Task CreateStatus_EquipmentAsync(Status_Equipment status_equipment);
        Task UpdateStatus_EquipmentAsync(Status_Equipment status_equipment);
        Task SoftDeleteStatus_EquipmentAsync(int id);
        Task CreateStatus_EquipmentAsync(Model.Status_Equipment status_equipment);
        Task UpdateStatus_EquipmentAsync(Model.Status_Equipment status_equipment);

    }
    public class Status_Equipment : IStatus_Equipment
    {
        private readonly IStatus_Equipment _inventoryRepository;
        private IStatus_Equipment _status_equipmentRepository;

        public Status_Equipment(IStatus_Equipment status_equipmentRepository)
        {
            _status_equipmentRepository = status_equipmentRepository;
        }

        public async Task<IEnumerable<Status_Equipment>> GetAllStatus_EquipmentAsync()
        {
            return await _status_equipmentRepository.GetAllStatus_EquipmentAsync();
        }

        public async Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int StatusE_ID)
        {
            return await _status_equipmentRepository.GetStatus_EquipmentByIdAsync(StatusE_ID);
        }

        public async Task CreateStatus_EquipmentAsync(Status_Equipment status_equipment)
        {
            await _status_equipmentRepository.Createstatus_equipmentAsync(status_equipment);
        }

        public async Task UpdateStatus_EquipmentAsync(Status_Equipment status_equipment)
        {
            await _status_equipmentRepository.UpdateequipmentAsync(status_equipment);
        }

        public async Task SoftDeleteStatus_EquipmentAsync(int StatusE_ID)
        {
            await _status_equipmentRepository.SoftDeletestatus_equipmentAsync(StatusE_ID);
        }

        public Task Createstatus_equipmentAsync(Status_Equipment status_equipment)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeletestatus_equipmentAsync(int statusE_ID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateequipmentAsync(Status_Equipment status_equipment)
        {
            throw new NotImplementedException();
        }
    }

    public interface IStatus_Equipment
    {
        Task Createstatus_equipmentAsync(Status_Equipment status_equipment);
        Task<IEnumerable<Status_Equipment>> GetAllStatus_EquipmentAsync();
        Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int statusE_ID);
        Task SoftDeletestatus_equipmentAsync(int statusE_ID);
        Task UpdateequipmentAsync(Status_Equipment status_equipment);
    }
}
