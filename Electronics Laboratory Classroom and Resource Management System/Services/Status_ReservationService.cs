using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IStatus_ReservationService
    {
        Task<IEnumerable<Status_Reservation>> GetAllstatus_reservationsAsync();
        Task<Status_Reservation> GetStatus_ReservationByIdAsync(int id);
        Task CreateStatus_ReservationAsync(int userTypeId, int userPermissionId,Status_Reservation status_reservation);
        Task UpdateStatus_ReservationAsync(Status_Reservation status_reservation);
        Task SoftDeleteStatus_ReservationAsync(int userTypeId, int userPermissionId,int id);
    }
    public class Status_ReservationService : IStatus_ReservationService
    {
        private readonly IStatus_Reservation_Repository _status_reservationRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public Status_ReservationService(IUser_Permission_Repository userPermissionRepository, IStatus_Reservation_Repository status_reservationRepository)
        {
            _status_reservationRepository = status_reservationRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<Status_Reservation>> GetAllstatus_reservationsAsync()
        {
            return await _status_reservationRepository.GetAllstatus_reservationsAsync();
        }

        public async Task<Status_Reservation> GetStatus_ReservationByIdAsync(int id)
        {
            return await _status_reservationRepository.GetStatus_ReservationByIdAsync(id);
        }

        public async Task CreateStatus_ReservationAsync(int userTypeId, int userPermissionId, Status_Reservation status_reservation)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 8); //Crear Status de Reservación/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear un status de Reservación.");
            }
            await _status_reservationRepository.CreateStatus_ReservationAsync(status_reservation);
        }

        public async Task UpdateStatus_ReservationAsync(Status_Reservation status_reservation)
        {
            await _status_reservationRepository.UpdateStatus_ReservationAsync(status_reservation);
        }

        public async Task SoftDeleteStatus_ReservationAsync(int userTypeId, int userPermissionId, int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 8); //Crear Status de Reservación/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar un status de Reservación.");
            }
            await _status_reservationRepository.SoftDeleteStatus_ReservationAsync(id);
        }
    }
}

