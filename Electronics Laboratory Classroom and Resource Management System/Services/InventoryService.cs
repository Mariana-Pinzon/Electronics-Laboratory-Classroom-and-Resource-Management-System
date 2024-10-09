using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllinventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task CreateInventoryAsync(int userTypeId, int userPermissionId, Inventory inventory);
        Task UpdateInventoryAsync(int userTypeId, int userPermissionId, Inventory inventory);
        Task SoftDeleteInventoryAsync(int userTypeId, int userPermissionId, int id);
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

        public async Task CreateInventoryAsync(int userTypeId, int userPermissionId, Inventory inventory)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 2); //Crear Inventario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear inventarios.");
            }
            await _inventoryRepository.CreateInventoryAsync(inventory);
        }

        public async Task UpdateInventoryAsync(int userTypeId, int userPermissionId, Inventory inventory)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 2); //Crear Inventario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar inventarios.");
            }
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }

        public async Task SoftDeleteInventoryAsync(int userTypeId, int userPermissionId, int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 2); //Crear Inventario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar inventarios.");
            }
            await _inventoryRepository.SoftDeleteInventoryAsync(id);
        }
    }
}
