using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IStatus_Reservation_Repository
    {
        Task<IEnumerable<Status_Reservation>> GetAllStatus_ReservationAsync();
        Task<Status_Reservation> GetStatus_ReservationByIdAsync(int id);
        Task CreateStatus_ReservationAsync(Status_Reservation status_reservation);
        Task UpdateStatus_ReservationAsync(Status_Reservation status_reservation);
        Task SoftDeleteStatus_ReservationAsync(int id);
        public class Status_Reservation_Repository : IStatus_Reservation_Repository
        {
            private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
            public Status_Reservation_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Status_Reservation>> GetAllStatus_ReservationAsync()
            {
                return await _context.status_reservations
                    .Where(sr => !sr.IsDeleted)
                    .ToListAsync();
            }
            public async Task<Status_Reservation> GetStatus_ReservationByIdAsync(int id)
            {
                return await _context.status_reservations
                    .FirstOrDefaultAsync(sr => sr.StatusR_ID == id && !sr.IsDeleted);
            }

            public async Task SoftDeleteStatus_ReservationAsync(int id)
            {
                var status_reservation = await _context.status_reservations.FindAsync(id);
                if (status_reservation != null)
                {
                    status_reservation.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
            }


            public async Task CreateStatus_ReservationAsync(Status_Reservation status_reservation)
            {
                _context.status_reservations.Add(status_reservation);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateStatus_ReservationAsync(Status_Reservation status_reservation)
            {
                _context.status_reservations.Update(status_reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}

