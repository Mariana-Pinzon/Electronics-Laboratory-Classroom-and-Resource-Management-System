using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IReservation_EquipmentService
    {
        Task<IEnumerable<Reservation_Equipment>> GetAllreservations_equipmentAsync();
        Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id);
        Task CreateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment);//Todos los usuarios pueden crear la reserva de equipos
        Task UpdateReservation_EquipmentAsync(int userTypeId, int userPermissionId, Reservation_Equipment reservation_equipment);
        Task SoftDeleteReservation_EquipmentAsync(int userTypeId, int userPermissionId, int id);
    }
    public class Reservation_EquipmentService : IReservation_EquipmentService
    {
        private readonly IInventory_Repository _inventory_Repository;
        private readonly IReservation_Equipment_Repository _reservation_equipmentRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;
      

        public Reservation_EquipmentService(IUser_Permission_Repository userPermissionRepository, IInventory_Repository inventory_Repository, IReservation_Equipment_Repository reservation_equipmentRepository)
        {
            _inventory_Repository = inventory_Repository;
            _reservation_equipmentRepository = reservation_equipmentRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<Reservation_Equipment>> GetAllreservations_equipmentAsync()
        {
            return await _reservation_equipmentRepository.GetAllreservations_equipmentAsync();
        }

        public async Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id)
        {
            return await _reservation_equipmentRepository.GetReservation_EquipmentByIdAsync(id);
        }

        public async Task CreateReservation_EquipmentAsync( Reservation_Equipment reservation_equipment)
        {
            int availableQuantity = await _inventory_Repository.GetAvailableQuantityAsync(reservation_equipment.Equipment.Equipment_ID);

            // Verificar si hay suficientes equipos
            if (availableQuantity < reservation_equipment.Quantity)
            {
                throw new InvalidOperationException("No hay suficientes equipos disponibles.");
            }

            // Si hay suficientes equipos, continuar con la reserva
            await _reservation_equipmentRepository.CreateReservation_EquipmentAsync(reservation_equipment);
        }

        public async Task UpdateReservation_EquipmentAsync(int userTypeId, int userPermissionId, Reservation_Equipment reservation_equipment)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 5); //Actualizar Reserva de Equipos/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar la reserva de equipos.");
            }
            await _reservation_equipmentRepository.UpdateReservation_EquipmentAsync(reservation_equipment);
        }

        public async Task SoftDeleteReservation_EquipmentAsync(int userTypeId, int userPermissionId, int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 5); //Actualizar Reserva de Equipos/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar la reserva de equipos.");
            }
            await _reservation_equipmentRepository.SoftDeleteReservation_EquipmentAsync(id);
        }
    }
}
    

