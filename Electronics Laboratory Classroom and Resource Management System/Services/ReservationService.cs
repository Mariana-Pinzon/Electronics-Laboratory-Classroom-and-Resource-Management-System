using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllreservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task CreateReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(int userTypeId, int userPermissionId, Reservation reservation);
        Task SoftDeleteReservationAsync(int userTypeId, int userPermissionId, int id);
    }
    public class ReservationService : IReservationService
    {
        private readonly IReservation_Repository _reservationRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public ReservationService(IUser_Permission_Repository userPermissionRepository, IReservation_Repository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllreservationsAsync()
        {
            return await _reservationRepository.GetAllreservationsAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetReservationByIdAsync(id);
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.CreateReservationAsync(reservation);
        }

        public async Task UpdateReservationAsync(int userTypeId, int userPermissionId, Reservation reservation)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 6); //Actualizar Reservación/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar la reservación.");
            }
            await _reservationRepository.UpdateReservationAsync(reservation);
        }

        public async Task SoftDeleteReservationAsync(int userTypeId, int userPermissionId, int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 6); //Actualizar Reservación/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar la reservación.");
            }
            await _reservationRepository.SoftDeleteReservationAsync(id);
        }
    }
}
