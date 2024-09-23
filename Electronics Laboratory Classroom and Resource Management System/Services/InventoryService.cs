using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllInventoryAsync();
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

        public async Task<IEnumerable<Inventory>> GetAllInventoryAsync()
        {
            return await _inventoryRepository.GetAllInventoryAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int Inventory_ID)
        {
            return await _inventoryRepository.GetInventoryByIdAsync(Inventory_ID);
        }

        public async Task CreateInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.CreateInventoryAsync(inventory);
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }

        public async Task SoftDeleteInventoryAsync(int Inventory_ID)
        {
            await _inventoryRepository.SoftDeleteInventoryAsync(Inventory_ID);
        }
    }
}
