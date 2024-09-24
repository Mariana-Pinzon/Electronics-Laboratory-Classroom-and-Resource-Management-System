using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetAllEquipmentAsync();
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task CreateEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task SoftDeleteEquipmentAsync(int id);
        public class EquipmentService : IEquipmentService
        {
            private readonly IEquipment_Repository _equipmentRepository;

            public EquipmentService(IEquipment_Repository equipmentRepository)
            {
                _equipmentRepository = equipmentRepository;
            }

            public async Task<IEnumerable<Equipment>> GetAllEquipmentAsync()
            {
                return await _equipmentRepository.GetAllEquipmentAsync();
            }

            public async Task<Equipment> GetEquipmentByIdAsync(int Equipment_ID)
            {
                return await _equipmentRepository.GetEquipmentByIdAsync(Equipment_ID);
            }

            public async Task CreateEquipmentAsync(Equipment equipment)
            {
                await _equipmentRepository.CreateEquipmentAsync(equipment);
            }

            public async Task UpdateEquipmentAsync(Equipment equipment)
            {
                await _equipmentRepository.UpdateEquipmentAsync(equipment);
            }

            public async Task SoftDeleteEquipmentAsync(int Equipment_ID)
            {
                await _equipmentRepository.SoftDeleteEquipmentAsync(Equipment_ID);
            }
        }
    }
}