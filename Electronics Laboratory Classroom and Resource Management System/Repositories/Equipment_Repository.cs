using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IEquipment_Repository
    {
        Task<IEnumerable<Equipment>> GetAllequipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task CreateEquipmentAsync(string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID, Equipment equipment);
        Task UpdateEquipmentAsync(int id,string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID);
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

        public async Task CreateEquipmentAsync(string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID, Equipment equipment)
        {
            var Status = await _context.status_equipments.FindAsync(StatusE_ID) ?? throw new Exception("Status not found");
            var Laboratory = await _context.laboratories.FindAsync(Laboratory_ID) ?? throw new Exception("Laboratory not found");

            equipment.Equipment_Name = Equipment_Name;
            equipment.Description = Description;
            equipment.Status_Equipment = Status;
            equipment.Acquisition_date = Acquisition_date;
            equipment.Laboratory = Laboratory;
           
          
            _context.equipments.Add(equipment);
             await _context.SaveChangesAsync();
           

        }


        public async Task UpdateEquipmentAsync(int id, string Equipment_Name, string Description, int StatusE_ID, DateOnly Acquisition_date, int Laboratory_ID)
        {
            var Equipment = await _context.equipments.FindAsync(id) ?? throw new Exception("Equipment not found");
            var Status = await _context.status_equipments.FindAsync(StatusE_ID) ?? throw new Exception("Status not found");
            var Laboratory = await _context.laboratories.FindAsync(Laboratory_ID) ?? throw new Exception("Laboratory not found");

            Equipment.Equipment_Name = Equipment_Name;
            Equipment.Description = Description;
            Equipment.Status_Equipment = Status;
            Equipment.Acquisition_date = Acquisition_date;
            Equipment.Laboratory = Laboratory;
            try
            {
                _context.equipments.Update(Equipment);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}