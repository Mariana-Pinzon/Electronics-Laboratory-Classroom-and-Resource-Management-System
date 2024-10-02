using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IInventory_HistoryService
    {
        Task<IEnumerable<Inventory_History>> GetAllinventories_historyAsync();
        Task<Inventory_History> GetInventory_HistoryByIdAsync(int id);
        Task CreateInventory_HistoryAsync(Inventory_History inventory_history);
        Task UpdateInventory_HistoryAsync(Inventory_History inventory_history);
        Task SoftDeleteInventory_HistoryAsync(int id);
    }
    public class Inventory_HistoryService : IInventory_HistoryService
    {
        private readonly IInventory_History_Repository _inventory_historyRepository;

        public Inventory_HistoryService(IInventory_History_Repository inventory_historyRepository)
        {
            _inventory_historyRepository = inventory_historyRepository;
        }

        public async Task<IEnumerable<Inventory_History>> GetAllinventories_historyAsync()
        {
            return await _inventory_historyRepository.GetAllinventories_historyAsync();
        }

        public async Task<Inventory_History> GetInventory_HistoryByIdAsync(int id)
        {
            return await _inventory_historyRepository.GetInventory_HistoryByIdAsync(id);
        }

        public async Task CreateInventory_HistoryAsync(Inventory_History inventory_history)
        {
            await _inventory_historyRepository.CreateInventory_HistoryAsync(inventory_history);
        }

        public async Task UpdateInventory_HistoryAsync(Inventory_History inventory_history)
        {
            await _inventory_historyRepository.UpdateInventory_HistoryAsync(inventory_history);
        }

        public async Task SoftDeleteInventory_HistoryAsync(int id)
        {
            await _inventory_historyRepository.SoftDeleteInventory_HistoryAsync(id);
        }
    }
}
