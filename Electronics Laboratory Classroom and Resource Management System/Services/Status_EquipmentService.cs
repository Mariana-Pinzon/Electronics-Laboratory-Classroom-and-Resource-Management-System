using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IStatus_EquipmentService
    {
        Task<IEnumerable<Status_Equipment>> GetAllstatus_equipmentsAsync();
        Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int id);
        Task SoftDeleteStatus_EquipmentAsync(int id);
        Task CreateStatus_EquipmentAsync(Model.Status_Equipment status_equipment);
        Task UpdateStatus_EquipmentAsync(Model.Status_Equipment status_equipment);

    }
    public class Status_EquipmentService : IStatus_EquipmentService
    {

        {
            _status_equipmentRepository = status_equipmentRepository;
        }

        {
        }

        {
        }

        public async Task CreateStatus_EquipmentAsync(Status_Equipment status_equipment)
        {
        }

        public async Task UpdateStatus_EquipmentAsync(Status_Equipment status_equipment)
        {
        }

        {
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
