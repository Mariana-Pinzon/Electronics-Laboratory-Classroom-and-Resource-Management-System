using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IReservation_Equipment_Repository
    {
        Task<IEnumerable<Reservation_Equipment>> GetAllreservations_equipmentAsync();
        Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id);
        Task CreateReservation_EquipmentAsync(int Equipment_ID, int Quantity);
        Task UpdateReservation_EquipmentAsync(int id, int Equipment_ID, int Quantity);
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
                .Where(re => !re.IsDeleted)
                .ToListAsync();
        }
        public async Task<Reservation_Equipment> GetReservation_EquipmentByIdAsync(int id)
        {
            return await _context.reservations_equipment
                .FirstOrDefaultAsync(re => re.ReservationE_ID == id && !re.IsDeleted);
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

       
        public async Task CreateReservation_EquipmentAsync(int Equipment_ID, int Quantity)
        {
            var Equipment = await _context.equipments.FindAsync(Equipment_ID) ?? throw new Exception("Equipment not found");

            var inventory = await _context.inventories
            .FirstOrDefaultAsync(i => i.Equipment.Equipment_ID == Equipment_ID)
            ?? throw new Exception("Inventory not found for the equipment.");

            // Verificar si la cantidad solicitada es menor o igual a la cantidad disponible en Inventory
            if (Quantity > inventory.Available_quantity)
            {
                throw new Exception("The quantity requested exceeds the quantity available in inventory.");
            }
            var reservation_equipment = new Reservation_Equipment
            {
                Equipment = Equipment,
                Quantity = Quantity,
            };

            _context.reservations_equipment.Add(reservation_equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservation_EquipmentAsync(int id, int Equipment_ID, int Quantity)
        {
            var ReservationEquipment = await _context.reservations_equipment.FindAsync(id) ?? throw new Exception("ReservationEquipment not found");
            var Equipment = await _context.equipments.FindAsync(Equipment_ID) ?? throw new Exception("Equipment not found");

            var inventory = await _context.inventories
            .FirstOrDefaultAsync(i => i.Equipment.Equipment_ID == Equipment_ID)
            ?? throw new Exception("Inventory not found for the equipment.");

            // Verificar si la cantidad solicitada es menor o igual a la cantidad disponible en Inventory
            if (Quantity > inventory.Available_quantity)
            {
                throw new Exception("The quantity requested exceeds the quantity available in inventory.");
            }

            ReservationEquipment.Equipment = Equipment;
            ReservationEquipment.Quantity = Quantity;


            _context.reservations_equipment.Add(ReservationEquipment);
            await _context.SaveChangesAsync();

        }
    }
}
