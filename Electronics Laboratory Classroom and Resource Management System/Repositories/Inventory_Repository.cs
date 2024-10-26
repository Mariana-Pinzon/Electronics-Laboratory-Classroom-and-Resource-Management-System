using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IInventory_Repository
    {
        Task<IEnumerable<Inventory>> GetAllinventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task CreateInventoryAsync(int Equipment_ID, int Available_quantity, int Laboratory_ID);
        Task UpdateInventoryAsync(int id, int Equipment_ID, int Available_quantity, int Laboratory_ID);
        Task SoftDeleteInventoryAsync(int id);
    }
    public class Inventory_Repository : IInventory_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Inventory_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inventory>> GetAllinventoriesAsync()
        {
            return await _context.inventories
                .Include(i => i.Equipment)
                .Include(i => i.Laboratory)
                .Where(i => !i.IsDeleted)
                .ToListAsync();
        }
        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _context.inventories
                .Include(i => i.Equipment)
                .Include(i => i.Laboratory)
                .FirstOrDefaultAsync(i => i.Inventory_ID == id && !i.IsDeleted);
        }

        public async Task SoftDeleteInventoryAsync(int id)
        {
            var inventory = await _context.inventories.FindAsync(id);
            if (inventory != null)
            {
                inventory.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateInventoryAsync(int Equipment_ID, int Available_quantity, int Laboratory_ID)
        {
            var Equipment = await _context.equipments.FindAsync(Equipment_ID) ?? throw new Exception("Equipment not found");
            var Laboratory = await _context.laboratories.FindAsync(Laboratory_ID) ?? throw new Exception("Laboratory not found");

            var inventory = new Inventory
            {
                Equipment = Equipment,
                Available_quantity = Available_quantity,
                Laboratory = Laboratory,
            };

            try
            {
                _context.inventories.Add(inventory);
                await _context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw;
            }

        }


        public async Task UpdateInventoryAsync(int id, int Equipment_ID, int Available_quantity, int Laboratory_ID)
        {
            var inventory = await _context.inventories.FindAsync(id) ?? throw new Exception("Inventory not found");
            var Equipment = await _context.equipments.FindAsync(Equipment_ID) ?? throw new Exception("Equipment not found");
            var Laboratory = await _context.laboratories.FindAsync(Laboratory_ID) ?? throw new Exception("Laboratory not found");

            inventory.Equipment = Equipment;
            inventory.Available_quantity = Available_quantity;
            inventory.Laboratory = Laboratory;
            try
            {
                _context.inventories.Update(inventory);
                await _context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw;
            }
            
        }


    }
}
