using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IUser_Repository
    {
        Task<IEnumerable<User>> GetAllusersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(string First_Name, string Last_Name, string Email, string Password, int User_Type_ID);
        Task UpdateUserAsync(int id, string First_Name, string Last_Name, string Email, string Password, int User_Type_ID);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string Email, string Password);
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


        public async Task CreateUserAsync(string First_Name, string Last_Name, string Email, string Password, int User_Type_ID)
        {
            // Fetch the UserType
            var UserType = await _context.user_types.FindAsync(User_Type_ID) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(null, Password);

            // Create a new User object
            var users = new User
            {
                First_Name = First_Name,
                Last_Name = Last_Name,
                Email = Email,
                Password = hashedPassword,
                User_Type = UserType
            };

            try
            {
                await _context.users.AddAsync(users);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateUserAsync(int id, string First_Name, string Last_Name, string Email, string Password, int User_Type_ID)
        {
            // Find the existing user by ID
            var user = await _context.users.FindAsync(id) ?? throw new Exception("User not found");

            // Fetch the User object based on userId and attendantId
            var UserType = await _context.user_types.FindAsync(User_Type_ID) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(user, Password);

            // Update
            user.First_Name = First_Name;
            user.Last_Name = Last_Name;
            user.Email = Email;
            user.Password = hashedPassword;
            user.User_Type = UserType;


            try
            {
                _context.users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;

            }
        }

        // Check user password and email
        public async Task<bool> ValidateUserAsync(string Email, string Password)
        {
            // Fetch the user by email
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == Email) ?? throw new Exception("User not found");

            // User does not exist
            if (user == null) return false;

            // Initialize PasswordHasher
            var passwordHasher = new PasswordHasher<User>();

            // Verify the password
            var userVerification = passwordHasher.VerifyHashedPassword(user, user.Password, Password);

            // Check if password is correct
            if (userVerification == PasswordVerificationResult.Success) return true;

            // Password is invalid
            return false;
        }
    }
}
