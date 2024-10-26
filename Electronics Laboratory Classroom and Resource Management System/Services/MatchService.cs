using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IMatchService
    {
        Task<IEnumerable<Match>> GetAllmatchesAsync();
        Task<Match> GetMatchByIdAsync(int id);
        Task CreateMatchAsync(int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore);
        Task UpdateMatchAsync(int id, int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore);
        Task SoftDeleteMatchAsync(int id);
    }
    public class MatchService : IMatchService
    {
        private readonly IMatch_Repository _matchRepository;

        public MatchService(IMatch_Repository matchRepository)
        {
            _matchRepository = matchRepository;

        }

        public async Task<IEnumerable<Match>> GetAllmatchesAsync()
        {
            return await _matchRepository.GetAllmatchesAsync();
        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            return await _matchRepository.GetMatchByIdAsync(id);
        }

        public async Task CreateMatchAsync(int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore)
        {
            await _matchRepository.CreateMatchAsync(User_ID, StartDate, IsFinished, PositionX, PositionY, PositionZ, CurrentScore);
        }

        public async Task UpdateMatchAsync(int id, int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore)
        {
            await _matchRepository.UpdateMatchAsync(id, User_ID, StartDate, IsFinished, PositionX, PositionY, PositionZ, CurrentScore);
        }

        public async Task SoftDeleteMatchAsync(int id)
        {
            await _matchRepository.SoftDeleteMatchAsync(id);
        }
    }
}
