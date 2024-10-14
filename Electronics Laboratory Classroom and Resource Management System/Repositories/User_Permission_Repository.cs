using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IUser_Permission_Repository
    {
        Task<IEnumerable<User_Permission>> GetAlluser_permissionsAsync();
        Task<User_Permission> GetUser_PermissionByIdAsync(int id);
        Task CreateUser_PermissionAsync(int UserTypeId, int permissionId);
        Task UpdateUser_PermissionAsync(int id, int UserTypeId, int permissionId);
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

                .Where(up => !up.IsDeleted) // Avoid deleted items
                .Include(up => up.User_Type)
                .Include(up => up.Permission)
                .ToListAsync();
        }
        public async Task<User_Permission> GetUser_PermissionByIdAsync(int id)
        {
            return await _context.user_permissions
                .Include(up => up.User_Type)
                .Include(up => up.Permission)
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


        public async Task CreateUser_PermissionAsync(int UserTypeId, int permissionId)
        {
            var UserType = await _context.user_types.FindAsync(UserTypeId) ?? throw new Exception("UserType not found");
            var Permission = await _context.permissions.FindAsync(permissionId) ?? throw new Exception("Permission not found");

            var userPermission = new User_Permission
            {
                Permission = Permission,
                User_Type = UserType
            };
            _context.user_permissions.Add(userPermission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser_PermissionAsync(int id, int UserTypeId, int permissionId)
        {
            var permissionUser = await _context.user_permissions.FindAsync(id) ?? throw new Exception("User permission not found");

            // Fetch foreing keys if exists
            var UserType = await _context.user_types.FindAsync(UserTypeId) ?? throw new Exception("UserType not found");
            var Permission = await _context.permissions.FindAsync(permissionId) ?? throw new Exception("Permission not found");

            permissionUser.Permission = Permission;
            permissionUser.User_Type = UserType;


            try
            {
                _context.user_permissions.Update(permissionUser);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw;

            }
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
