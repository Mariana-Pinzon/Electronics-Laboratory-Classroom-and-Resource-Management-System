using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IStatus_ReservationService
    {
        Task<IEnumerable<Status_Reservation>> GetAllStatus_ReservationAsync();
        Task<Status_Reservation> GetStatus_ReservationByIdAsync(int id);
        Task CreateStatus_ReservationAsync(Status_Reservation status_reservation);
        Task UpdateStatus_ReservationAsync(Status_Reservation status_reservation);
        Task SoftDeleteStatus_ReservationAsync(int id);
    }
    public class Status_ReservationService : IStatus_ReservationService
    {
        private readonly IStatus_Reservation_Repository _status_reservationRepository;

        public Status_ReservationService(IStatus_Reservation_Repository status_reservationRepository)
        {
            _status_reservationRepository = status_reservationRepository;
        }

        public async Task<IEnumerable<Status_Reservation>> GetAllStatus_ReservationAsync()
        {
            return await _status_reservationRepository.GetAllStatus_ReservationAsync();
        }

        public async Task<Status_Reservation> GetStatus_ReservationByIdAsync(int StatusR_ID)
        {
            return await _status_reservationRepository.GetStatus_ReservationByIdAsync(StatusR_ID);
        }

        public async Task CreateStatus_ReservationAsync(Status_Reservation status_reservation)
        {
            await _status_reservationRepository.CreateStatus_ReservationAsync(status_reservation);
        }

        public async Task UpdateStatus_ReservationAsync(Status_Reservation status_reservation)
        {
            await _status_reservationRepository.UpdateStatus_ReservationAsync(status_reservation);
        }

        public async Task SoftDeleteReservation_Status_ReservationAsync(int StatusR_ID)
        {
            await _status_reservationRepository.SoftDeleteStatus_ReservationAsync(StatusR_ID);
        }

        public Task SoftDeleteStatus_ReservationAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

