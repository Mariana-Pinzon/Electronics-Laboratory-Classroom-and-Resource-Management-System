using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IReservation_EquipmentService
    {
        Task<IEnumerable<Reservation_Equipment>> GetAllreservations_equipmentAsync();
        Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id);
        Task CreateReservation_EquipmentAsync(int Equipment_ID, int Quantity);//Todos los usuarios pueden crear la reserva de equipos
        Task UpdateReservation_EquipmentAsync(int id, int Equipment_ID, int Quantity);
        Task SoftDeleteReservation_EquipmentAsync( int id);
    }
    public class Reservation_EquipmentService : IReservation_EquipmentService
    {
        private readonly IReservation_Equipment_Repository _reservation_equipmentRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;
      

        public Reservation_EquipmentService(IUser_Permission_Repository userPermissionRepository, IReservation_Equipment_Repository reservation_equipmentRepository)
        {
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

        public async Task CreateReservation_EquipmentAsync(int Equipment_ID, int Quantity)
        {
            await _reservation_equipmentRepository.CreateReservation_EquipmentAsync(Equipment_ID, Quantity);
        }

        public async Task UpdateReservation_EquipmentAsync(int id, int Equipment_ID, int Quantity)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 5); //Actualizar Reserva de Equipos/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar la reserva de equipos.");
            }
            await _reservation_equipmentRepository.UpdateReservation_EquipmentAsync(id, Equipment_ID, Quantity);
        }

        public async Task SoftDeleteReservation_EquipmentAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(UserTypeId:1, permissionId: 5); //Actualizar Reserva de Equipos/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar la reserva de equipos.");
            }
            await _reservation_equipmentRepository.SoftDeleteReservation_EquipmentAsync(id);
        }
    }
}
    

