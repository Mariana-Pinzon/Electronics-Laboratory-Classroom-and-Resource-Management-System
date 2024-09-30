using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IReservation_Equipment_Repository
    {
        Task<IEnumerable<Reservation_Equipment>> GetAllreservations_equipmentAsync();
        Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id);
        Task CreateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment);
        Task UpdateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment);
        Task SoftDeleteReservation_EquipmentAsync(int id);
    }
    public class Reservation_Equipment_Repository : IReservation_Equipment_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Reservation_Equipment_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reservation_Equipment>> GetAllreservations_equipmentAsync()
        {
            return await _context.reservations_equipment
                .Where(se => !se.IsDeleted)
                .ToListAsync();
        }
        public async Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id)
        {
            return await _context.reservations_equipment
                .FirstOrDefaultAsync(se => se.ReservationE_ID == id && !se.IsDeleted);
        }

        public async Task SoftDeleteReservation_EquipmentAsync(int id)
        {
            var reservation_equipment = await _context.reservations_equipment.FindAsync(id);
            if (reservation_equipment != null)
            {
                reservation_equipment.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

       
        public async Task CreateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment)
        {
            _context.reservations_equipment.Add(reservation_equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservation_EquipmentAsync(Reservation_Equipment reservation_equipment)
        {
            _context.reservations_equipment.Update(reservation_equipment);
            await _context.SaveChangesAsync();
        }
    }
}
