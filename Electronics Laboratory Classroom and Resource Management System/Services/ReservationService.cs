using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservationAsync();
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

        public async Task<IEnumerable<Reservation>> GetAllReservationAsync()
        {
            return await _reservationRepository.GetAllReservationAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int Reservation_ID)
        {
            return await _reservationRepository.GetReservationByIdAsync(Reservation_ID);
        }

        public async Task CreateReservationAsync(Reservation reservations)
        {
            await _reservationRepository.CreateReservationAsync(reservations);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateReservationAsync(reservation);
        }

        public async Task SoftDeleteReservationAsync(int Reservation_ID)
        {
            await _reservationRepository.SoftDeleteReservationAsync(Reservation_ID);
        }
    }
}

