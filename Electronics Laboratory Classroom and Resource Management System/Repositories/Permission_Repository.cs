using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IPermission_Repository
    {
        Task<IEnumerable<Permission>> GetAllpermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task SoftDeletePermissionAsync(int id);
    }
    public class Permission_Repository : IPermission_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Permission_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Permission>> GetAllpermissionsAsync()
        {
            return await _context.permissions
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }
        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _context.permissions
                .FirstOrDefaultAsync(p => p.Permission_ID == id && !p.IsDeleted);
        }

        public async Task SoftDeletePermissionAsync(int id)
        {
            var permission = await _context.permissions.FindAsync(id);
            if (permission != null)
            {
                permission.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreatePermissionAsync(Permission permission)
        {
            _context.permissions.Add(permission);
            await _context.SaveChangesAsync();
        }


        public async Task UpdatePermissionAsync(Permission permission)
        {
            _context.permissions.Update(permission);
            await _context.SaveChangesAsync();
        }
    }
}