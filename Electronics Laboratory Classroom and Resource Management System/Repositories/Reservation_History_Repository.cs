using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IReservation_History_Repository
    {
        Task<IEnumerable<Reservation_History>> GetAllReservation_HistoryAsync();
        Task<Reservation_History> GetReservation_HistoryByIdAsync(int id);
        Task CreateReservation_HistoryAsync(Reservation_History reservation_history);
        Task UpdateReservation_HistoryAsync(Reservation_History reservation_history);
        Task SoftDeleteReservation_HistoryAsync(int id);
    }
    public class Reservation_History_Repository : IReservation_History_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Reservation_History_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reservation_History>> GetAllReservation_HistoryAsync()
        {
            return await _context.reservations_history
                .Where(rh => !rh.IsDeleted)
                .ToListAsync();
        }
        public async Task<Reservation_History> GetReservation_HistoryByIdAsync(int id)
        {
            return await _context.reservations_history
                .FirstOrDefaultAsync(rh => rh. History_ID == id && !rh.IsDeleted);
        }

        public async Task SoftDeleteReservation_HistoryAsync(int id)
        {
            var Reservation_History = await _context.reservations_history.FindAsync(id);
            if (Reservation_History != null)
            {
                Reservation_History.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateReservation_HistoryAsync(Reservation_History reservation_history)
        {
            _context.reservations_history.Add(reservation_history);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateReservation_HistoryAsync(Reservation_History reservation_history)
        {
            _context.reservations_history.Update(reservation_history);
            await _context.SaveChangesAsync();
        }

    }
}

    

