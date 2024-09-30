using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllreservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task CreateReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
        Task SoftDeleteReservationAsync(int id);
    }
    public class ReservationService : IReservationService
    {
        private readonly IReservation_Repository _reservationRepository;

        public ReservationService(IReservation_Repository reservationRepository)
        {
            _reservationRepository = reservationRepository;
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

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateReservationAsync(reservation);
        }

        public async Task SoftDeleteReservationAsync(int id)
        {
            await _reservationRepository.SoftDeleteReservationAsync(id);
        }
    }
}

