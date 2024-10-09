using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IEquipment_Repository
    {
        Task<IEnumerable<Equipment>> GetAllequipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task CreateEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task SoftDeleteEquipmentAsync(int id);
    }
    public class Equipment_Repository : IEquipment_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Equipment_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Equipment>> GetAllequipmentsAsync()
        {
            return await _context.equipments
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }
        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            return await _context.equipments
                .FirstOrDefaultAsync(e => e.Equipment_ID == id && !e.IsDeleted);
        }

        public async Task SoftDeleteEquipmentAsync(int id)
        {
            var equipment = await _context.equipments.FindAsync(id);
            if (equipment != null)
            {
                equipment.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateEquipmentAsync(Equipment equipment)
        {

            _context.equipments.Add(equipment);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateEquipmentAsync(Equipment equipment)
        {
            _context.equipments.Update(equipment);
            await _context.SaveChangesAsync();
        }
    }
}