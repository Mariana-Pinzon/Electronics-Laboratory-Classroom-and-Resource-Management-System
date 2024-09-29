using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IReservation_HistoryService
    {
        Task<IEnumerable<Reservation_History>> GetAllreservations_historyAsync();
        Task<Reservation_History> GetReservation_HistoryByIdAsync(int id);
        Task CreateReservation_HistoryAsync(Reservation_History reservation_history);
        Task UpdateReservation_HistoryAsync(Reservation_History reservation_history);
        Task SoftDeleteReservation_HistoryAsync(int id);
    }
    public class Reservation_HistoryService : IReservation_HistoryService
    {
        private readonly IReservation_History_Repository _reservation_historyRepository;

        public Reservation_HistoryService(IReservation_History_Repository reservation_historyRepository)
        {
            _reservation_historyRepository = reservation_historyRepository;
        }

        public async Task<IEnumerable<Reservation_History>> GetAllreservations_historyAsync()
        {
            return await _reservation_historyRepository.GetAllreservations_historyAsync();
        }

        public async Task<Reservation_History> GetReservation_HistoryByIdAsync(int id)
        {
            return await _reservation_historyRepository.GetReservation_HistoryByIdAsync(id);
        }

        public async Task CreateReservation_HistoryAsync(Reservation_History reservation_history)
        {
            await _reservation_historyRepository.CreateReservation_HistoryAsync(reservation_history);
        }

        public async Task UpdateReservation_HistoryAsync(Reservation_History reservation_history)
        {
            await _reservation_historyRepository.UpdateReservation_HistoryAsync(reservation_history);
        }

        public async Task SoftDeleteReservation_HistoryAsync(int id)
        {
            await _reservation_historyRepository.SoftDeleteReservation_HistoryAsync(id);
        }
    }
}

    

