﻿using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IInventory_Repository
    {
        Task<IEnumerable<Inventory>> GetAllinventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task CreateInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task SoftDeleteInventoryAsync(int id);
        Task<int> GetAvailableQuantityAsync(int equipmentId);
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
                .Where(i => !i.IsDeleted)
                .ToListAsync();
        }
        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _context.inventories
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

        public async Task CreateInventoryAsync(Inventory inventory)
        {
            _context.inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            _context.inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetAvailableQuantityAsync(int equipmentId)
        {
            var inventory = await _context.inventories
                .FirstOrDefaultAsync(i => i.Equipment.Equipment_ID == equipmentId && !i.IsDeleted);

            return inventory?.Available_quantity ?? 0;  // Si no existe el inventario, retorna 0.
        }
    }
}
