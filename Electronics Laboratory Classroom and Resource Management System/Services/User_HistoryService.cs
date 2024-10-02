using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IUser_HistoryService
    {
        Task<IEnumerable<User_History>> GetAllusers_historyAsync();
        Task<User_History> GetUser_HistoryByIdAsync(int id);
        Task CreateUser_HistoryAsync(User_History user_history);
        Task UpdateUser_HistoryAsync(User_History user_history);
        Task SoftDeleteUser_HistoryAsync(int id);
    }
    public class User_HistoryService : IUser_HistoryService
    {
        private readonly IUser_History_Repository _user_historyRepository;

        public User_HistoryService(IUser_History_Repository user_historyRepository)
        {
            _user_historyRepository = user_historyRepository;
        }

        public async Task<IEnumerable<User_History>> GetAllusers_historyAsync()
        {
            return await _user_historyRepository.GetAllusers_historyAsync();
        }

        public async Task<User_History> GetUser_HistoryByIdAsync(int id)
        {
            return await _user_historyRepository.GetUser_HistoryByIdAsync(id);
        }

        public async Task CreateUser_HistoryAsync(User_History user_history)
        {
            await _user_historyRepository.CreateUser_HistoryAsync(user_history);
        }

        public async Task UpdateUser_HistoryAsync(User_History user_history)
        {
            await _user_historyRepository.UpdateUser_HistoryAsync(user_history);
        }

        public async Task SoftDeleteUser_HistoryAsync(int id)
        {
            await _user_historyRepository.SoftDeleteUser_HistoryAsync(id);
        }
    }
}
