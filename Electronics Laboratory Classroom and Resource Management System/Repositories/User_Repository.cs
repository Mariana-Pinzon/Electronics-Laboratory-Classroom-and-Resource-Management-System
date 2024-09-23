using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IUser_Repository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
    }
    public class User_Repository : IUser_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public User_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.users
                .Where(u => !u.IsDeleted)
                .ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.users
                .FirstOrDefaultAsync(u => u.User_ID == id && !u.IsDeleted);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        // Implementación del método para crear un nuevo tipo de usuario
        public async Task CreateUserAsync(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }

        // Implementación del método para actualizar un tipo de usuario
        public async Task UpdateUserAsync(User user)
        {
            _context.users.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}
