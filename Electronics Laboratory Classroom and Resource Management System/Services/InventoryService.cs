using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllinventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task CreateInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task SoftDeleteInventoryAsync(int id);
    }
    public class InventoryService : IInventoryService
    {
        private readonly IInventory_Repository _inventoryRepository;

        public InventoryService(IInventory_Repository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> GetAllinventoriesAsync()
        {
            return await _inventoryRepository.GetAllinventoriesAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _inventoryRepository.GetInventoryByIdAsync(id);
        }

        public async Task CreateInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.CreateInventoryAsync(inventory);
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }

        public async Task SoftDeleteInventoryAsync(int id)
        {
            await _inventoryRepository.SoftDeleteInventoryAsync(id);
        }
    }
}
