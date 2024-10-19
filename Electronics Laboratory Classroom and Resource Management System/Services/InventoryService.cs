using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllinventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task CreateInventoryAsync(int Equipment_ID, int Available_quantity, int Laboratory_ID);
        Task UpdateInventoryAsync(int id, int Equipment_ID, int Available_quantity, int Laboratory_ID);
        Task SoftDeleteInventoryAsync(int id);
    }
    public class InventoryService : IInventoryService
    {
        private readonly IInventory_Repository _inventoryRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public InventoryService(IUser_Permission_Repository userPermissionRepository, IInventory_Repository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
            _userPermissionRepository = userPermissionRepository;

        }

        public async Task<IEnumerable<Inventory>> GetAllinventoriesAsync()
        {
            return await _inventoryRepository.GetAllinventoriesAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _inventoryRepository.GetInventoryByIdAsync(id);
        }

        public async Task CreateInventoryAsync(int Equipment_ID, int Available_quantity, int Laboratory_ID)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,2); //Crear Inventario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear inventarios.");
            }
            await _inventoryRepository.CreateInventoryAsync(Equipment_ID, Available_quantity, Laboratory_ID);
        }

        public async Task UpdateInventoryAsync(int id, int Equipment_ID, int Available_quantity, int Laboratory_ID)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1, 2); //Crear Inventario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar inventarios.");
            }
            await _inventoryRepository.UpdateInventoryAsync(id, Equipment_ID, Available_quantity, Laboratory_ID);
        }

        public async Task SoftDeleteInventoryAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,2); //Crear Inventario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar inventarios.");
            }
            await _inventoryRepository.SoftDeleteInventoryAsync(id);
        }
    }
}
