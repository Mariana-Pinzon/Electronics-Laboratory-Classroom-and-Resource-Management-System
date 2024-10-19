using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllreservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task CreateReservationAsync(int User_ID, int Laboratory_ID, List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID);
        Task UpdateReservationAsync(int id, int User_ID, int Laboratory_ID, List<int> rRservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID);
        Task SoftDeleteReservationAsync(int id);
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

        public async Task CreateReservationAsync(int User_ID, int Laboratory_ID, List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID)
        {
            await _reservationRepository.CreateReservationAsync(User_ID, Laboratory_ID, Reservation_Equipments, Reservation_date, Start_time, End_time, StatusR_ID);
        }

        public async Task UpdateReservationAsync(int id, int User_ID, int Laboratory_ID, List<int> Reservation_Equipments, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,6); //Actualizar Reservación/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar la reservación.");
            }
            await _reservationRepository.UpdateReservationAsync(id, User_ID, Laboratory_ID, Reservation_Equipments, Reservation_date, Start_time, End_time, StatusR_ID);
        }

        public async Task SoftDeleteReservationAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,6); //Actualizar Reservación/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar la reservación.");
            }
            await _reservationRepository.SoftDeleteReservationAsync(id);
        }
    }
}

