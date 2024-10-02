using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IUser_History_Repository
    {
        Task<IEnumerable<User_History>> GetAllusers_historyAsync();
        Task<User_History> GetUser_HistoryByIdAsync(int id);
        Task CreateUser_HistoryAsync(User_History user_history);
        Task UpdateUser_HistoryAsync(User_History user_history);
        Task SoftDeleteUser_HistoryAsync(int id);
    }
    public class User_History_Repository : IUser_History_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public User_History_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User_History>> GetAllusers_historyAsync()
        {
            return await _context.users_history
                .Where(uh => !uh.IsDeleted)
                .ToListAsync();
        }
        public async Task<User_History> GetUser_HistoryByIdAsync(int id)
        {
            return await _context.users_history
                .FirstOrDefaultAsync(uh => uh.User_History_ID == id && !uh.IsDeleted);
        }

        public async Task SoftDeleteUser_HistoryAsync(int id)
        {
            var User_History = await _context.users_history.FindAsync(id);
            if (User_History != null)
            {
                User_History.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateUser_HistoryAsync(User_History user_history)
        {
            _context.users_history.Add(user_history);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateUser_HistoryAsync(User_History user_history)
        {
            _context.users_history.Update(user_history);
            await _context.SaveChangesAsync();
        }
    }
}
