using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IReservation_Repository
    {
        Task<IEnumerable<Reservation>> GetAllreservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task CreateReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
        Task SoftDeleteReservationAsync(int id);
    }
    public class Reservation_Repository : IReservation_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Reservation_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reservation>> GetAllreservationsAsync()
        {
            return await _context.reservations
                .Where(r => !r.IsDeleted)
                .ToListAsync();
        }
        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.reservations
                .FirstOrDefaultAsync(r => r.Reservation_ID == id && !r.IsDeleted);
        }

        public async Task SoftDeleteReservationAsync(int id)
        {
            var reservation = await _context.reservations.FindAsync(id);
            if (reservation != null)
            {
                reservation.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            _context.reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}