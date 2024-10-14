using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IReservation_Repository
    {
        Task<IEnumerable<Reservation>> GetAllreservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task CreateReservationAsync(int User_ID, int Laboratory_ID, int ReservationE_ID, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID, Reservation reservation);
        Task UpdateReservationAsync(int id, int User_ID, int Laboratory_ID, int ReservationE_ID, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID);
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

        public async Task CreateReservationAsync(int User_ID, int Laboratory_ID, int ReservationE_ID, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID, Reservation reservation)
        {
            var User = await _context.users.FindAsync(User_ID) ?? throw new Exception("User not found");
            var Laboratory = await _context.laboratories.FindAsync(Laboratory_ID) ?? throw new Exception("Laboratory not found");
            var ReservationEquipment = await _context.reservations_equipment.FindAsync(ReservationE_ID) ?? throw new Exception("ReservationEquipment not found");
            var Status = await _context.status_reservations.FindAsync(StatusR_ID) ?? throw new Exception("Status not found");
            


            reservation.User = User;
            reservation.Laboratory = Laboratory;
            reservation.Reservation_Equipment = ReservationEquipment;
            reservation.Reservation_date = Reservation_date;
            reservation.Start_time = Start_time;
            reservation.End_time = End_time;
            reservation.Status_Reservation = Status;
            

            _context.reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateReservationAsync(int id, int User_ID, int Laboratory_ID, int ReservationE_ID, DateOnly Reservation_date, TimeOnly Start_time, TimeOnly End_time, int StatusR_ID)
        {
            var reservation = await _context.reservations.FindAsync(id) ?? throw new Exception("Reservation not found");
            var User = await _context.users.FindAsync(User_ID) ?? throw new Exception("User not found");
            var Laboratory = await _context.laboratories.FindAsync(Laboratory_ID) ?? throw new Exception("Laboratory not found");
            var ReservationEquipment = await _context.reservations_equipment.FindAsync(ReservationE_ID) ?? throw new Exception("ReservationEquipment not found");
            var Status = await _context.status_reservations.FindAsync(StatusR_ID) ?? throw new Exception("Status not found");



            reservation.User = User;
            reservation.Laboratory = Laboratory;
            reservation.Reservation_Equipment = ReservationEquipment;
            reservation.Reservation_date = Reservation_date;
            reservation.Start_time = Start_time;
            reservation.End_time = End_time;
            reservation.Status_Reservation = Status;

            _context.reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
