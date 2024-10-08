﻿using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IUser_Permission_Repository
    {
        Task<IEnumerable<User_Permission>> GetAlluser_permissionsAsync();
        Task<User_Permission> GetUser_PermissionByIdAsync(int id);
        Task CreateUser_PermissionAsync(User_Permission user_permission);
        Task UpdateUser_PermissionAsync(User_Permission user_permission);
        Task SoftDeleteUser_PermissionAsync(int id);
        Task<bool> HasPermissions(int UserTypeId, int permissionId);
        
    }
    public class User_Permission_Repository : IUser_Permission_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public User_Permission_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User_Permission>> GetAlluser_permissionsAsync()
        {
            return await _context.user_permissions
                .Where(up => !up.IsDeleted)
                .ToListAsync();
        }
        public async Task<User_Permission> GetUser_PermissionByIdAsync(int id)
        {
            return await _context.user_permissions
                .FirstOrDefaultAsync(up => up.UserP_ID == id && !up.IsDeleted);
        }

        public async Task SoftDeleteUser_PermissionAsync(int id)
        {
            var user_permission = await _context.user_permissions.FindAsync(id);
            if (user_permission != null)
            {
                user_permission.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }


        public async Task CreateUser_PermissionAsync(User_Permission user_permission)
        {
            _context.user_permissions.Add(user_permission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser_PermissionAsync(User_Permission user_permission)
        {
            _context.user_permissions.Update(user_permission);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasPermissions(int UserTypeId, int permissionId)
        {
            User_Permission? up = await _context.user_permissions
                .Where(up => up.Permission.Permission_ID == permissionId &&
                 up.User_Type.User_Type_ID == UserTypeId
                ).FirstOrDefaultAsync();

            return up != null? true: false;
        }
    }
}
