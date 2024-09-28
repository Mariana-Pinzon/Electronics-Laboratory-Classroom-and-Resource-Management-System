using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repository
{
    public interface IUser_Type_Repository
    {
        Task<IEnumerable<User_Type>> GetAllUser_TypeAsync();
        Task<User_Type> GetUser_TypeByIdAsync(int id);
        Task CreateUser_TypeAsync(User_Type user_type);
        Task UpdateUser_TypeAsync(User_Type user_type);
        Task SoftDeleteUser_TypeAsync(int id);
    }
    public class User_Type_Repository : IUser_Type_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public User_Type_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User_Type>> GetAllUser_TypeAsync()
        {
            return await _context.user_types
                .Where(ut => !ut.IsDeleted)
                .ToListAsync();
        }
        public async Task<User_Type> GetUser_TypeByIdAsync(int id)
        {
            return await _context.user_types
                .FirstOrDefaultAsync(ut => ut.User_Type_ID == id && !ut.IsDeleted);
        }

        public async Task SoftDeleteUser_TypeAsync(int id)
        {
            var user_type = await _context.user_types.FindAsync(id);
            if (user_type != null)
            {
                user_type.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        // Implementación del método para crear un nuevo tipo de usuario
        public async Task CreateUser_TypeAsync(User_Type user_type)
        {
            _context.user_types.Add(user_type);
            await _context.SaveChangesAsync();
        }

        // Implementación del método para actualizar un tipo de usuario
        public async Task UpdateUser_TypeAsync(User_Type user_type)
        {
            _context.user_types.Update(user_type);
            await _context.SaveChangesAsync();
        }
    }
}
