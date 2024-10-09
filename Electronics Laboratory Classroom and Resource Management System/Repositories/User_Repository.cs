using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IUser_Repository
    {
        Task<IEnumerable<User>> GetAllusersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string email, string password);
    }
    public class User_Repository : IUser_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public User_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllusersAsync()
        {
            return await _context.users
                .Where(u => !u.IsDeleted)
                .ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.users.AsNoTracking()
                .Include(u => u.User_Type)
                .FirstOrDefaultAsync(ut => ut.User_Type_ID == id && !ut.IsDeleted);
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


        public async Task CreateUserAsync(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateUserAsync(int id, string name, string lastName, string email, string password, string identification, int userTypeId)
        {
            // Find the existing user by ID
            var user = await _context.users.FindAsync(id) ?? throw new Exception("User not found");

            // Fetch the User object based on userId and attendantId
            var userType = await _context.user_types.FindAsync(userTypeId) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(user, password);

            // Update
            user.First_Name = name;
            user.Last_Name = lastName;
            user.Email = email;
            user.Password = hashedPassword;
            user.User_Type = userType;


            try
            {
                _context.users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
             var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email)
                 ?? throw new Exception("User not found");

            if (user == null) return false;
                var passwordHasher = new PasswordHasher<User>();
                var userVerification = passwordHasher.VerifyHashedPassword(user, user.Password, password);
                if (userVerification == PasswordVerificationResult.Success) return true;
                return false;
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
