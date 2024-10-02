using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IInventory_History_Repository
    {
        Task<IEnumerable<Inventory_History>> GetAllinventories_historyAsync();
        Task<Inventory_History> GetInventory_HistoryByIdAsync(int id);
        Task CreateInventory_HistoryAsync(Inventory_History inventory_history);
        Task UpdateInventory_HistoryAsync(Inventory_History inventory_history);
        Task SoftDeleteInventory_HistoryAsync(int id);
    }
    public class Inventory_History_Repository : IInventory_History_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Inventory_History_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inventory_History>> GetAllinventories_historyAsync()
        {
            return await _context.inventories_history
                .Where(ih => !ih.IsDeleted)
                .ToListAsync();
        }
        public async Task<Inventory_History> GetInventory_HistoryByIdAsync(int id)
        {
            return await _context.inventories_history
                .FirstOrDefaultAsync(ih => ih.Inventory_History_ID == id && !ih.IsDeleted);
        }

        public async Task SoftDeleteInventory_HistoryAsync(int id)
        {
            var Inventory_History = await _context.inventories_history.FindAsync(id);
            if (Inventory_History != null)
            {
                Inventory_History.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateInventory_HistoryAsync(Inventory_History inventory_history)
        {
            _context.inventories_history.Add(inventory_history);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateInventory_HistoryAsync(Inventory_History inventory_history)
        {
            _context.inventories_history.Update(inventory_history);
            await _context.SaveChangesAsync();
        }
    }
}
