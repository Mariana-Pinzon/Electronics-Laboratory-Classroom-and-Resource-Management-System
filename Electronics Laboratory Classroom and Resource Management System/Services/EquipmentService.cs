using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetAllequipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task CreateEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task SoftDeleteEquipmentAsync(int id);
    }

    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipment_Repository _equipmentRepository;

        public EquipmentService(IEquipment_Repository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IEnumerable<Equipment>> GetAllequipmentsAsync()
        {
            return await _equipmentRepository.GetAllequipmentsAsync();
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            return await _equipmentRepository.GetEquipmentByIdAsync(id);
        }

        public async Task CreateEquipmentAsync(Equipment equipment)
        {
            await _equipmentRepository.CreateEquipmentAsync(equipment);
        }

        public async Task UpdateEquipmentAsync(Equipment equipment)
        {
            await _equipmentRepository.UpdateEquipmentAsync(equipment);
        }

        public async Task SoftDeleteEquipmentAsync(int id)
        {
            await _equipmentRepository.SoftDeleteEquipmentAsync(id);
        }
    }
}