using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IReservation_EquipmentService
    {
        Task<IEnumerable<Reservation_Equipment>> GetAllreservations_equipmentAsync();
        Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id);
        Task CreateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment);
        Task UpdateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment);
        Task SoftDeleteReservation_EquipmentAsync(int id);
    }
    public class Reservation_EquipmentService : IReservation_EquipmentService
    {
        private readonly IReservation_Equipment_Repository _reservation_equipmentRepository;

        public Reservation_EquipmentService(IReservation_Equipment_Repository reservation_equipmentRepository)
        {
            _reservation_equipmentRepository = reservation_equipmentRepository;
        }

        public async Task<IEnumerable<Reservation_Equipment>> GetAllreservations_equipmentAsync()
        {
            return await _reservation_equipmentRepository.GetAllreservations_equipmentAsync();
        }

        public async Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id)
        {
            return await _reservation_equipmentRepository.GetReservation_EquipmentByIdAsync(id);
        }

        public async Task CreateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment)
        {
            await _reservation_equipmentRepository.CreateReservation_EquipmentAsync(reservation_equipment);
        }

        public async Task UpdateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment)
        {
            await _reservation_equipmentRepository.UpdateReservation_EquipmentAsync(reservation_equipment);
        }

        public async Task SoftDeleteReservation_EquipmentAsync(int id)
        {
            await _reservation_equipmentRepository.SoftDeleteReservation_EquipmentAsync(id);
        }
    }
}
    

