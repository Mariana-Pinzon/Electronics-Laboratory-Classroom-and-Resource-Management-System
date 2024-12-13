﻿using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IStatus_Equipment_Repository
    {
        Task<IEnumerable<Status_Equipment>> GetAllstatus_equipmentsAsync();
        Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int id);
        Task CreateStatus_EquipmentAsync(string Status);
        Task UpdateStatus_EquipmentAsync(int id, string Status);
        Task SoftDeleteStatus_EquipmentAsync(int id);
    }
    public class Status_Equipment_Repository : IStatus_Equipment_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Status_Equipment_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Status_Equipment>> GetAllstatus_equipmentsAsync()
        {
            return await _context.status_equipments
                .Where(se => !se.IsDeleted)
                .ToListAsync();
        }
        public async Task<Status_Equipment> GetStatus_EquipmentByIdAsync(int id)
        {
            return await _context.status_equipments
                .FirstOrDefaultAsync(se => se.StatusE_ID == id && !se.IsDeleted);
        }

        public async Task SoftDeleteStatus_EquipmentAsync(int id)
        {
            var status_equipment = await _context.status_equipments.FindAsync(id);
            if (status_equipment != null)
            {
                status_equipment.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateStatus_EquipmentAsync(string Status)
        {
            var status_equipment = new Status_Equipment
            { Status = Status };
            _context.status_equipments.Add(status_equipment);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateStatus_EquipmentAsync(int id, string Status)
        {
            var StatusE = await _context.status_equipments.FindAsync(id) ?? throw new Exception("Status not found");

            StatusE.Status = Status;

            try
            {
                _context.status_equipments.Update(StatusE);
                await _context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw;
            }
        }

    }
}
