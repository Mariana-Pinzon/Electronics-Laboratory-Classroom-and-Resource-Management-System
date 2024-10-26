using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IMatchLevelService
    {
        Task<IEnumerable<MatchLevel>> GetAllMatchesLevelAsync();
        Task<MatchLevel> GetMatchLevelByIdAsync(int id);
        Task CreateMatchLevelAsync(int Match_ID, int Level_ID, int PointsEarned);
        Task UpdateMatchLevelAsync(int id, int Match_ID, int Level_ID, int PointsEarned);
        Task SoftDeleteMatchLevelAsync(int id);
    }
    public class MatchLevelService : IMatchLevelService
    {
        private readonly IMatchLevel_Repository _matchlevelRepository;

        public MatchLevelService(IMatchLevel_Repository matchlevelRepository)
        {
            _matchlevelRepository = matchlevelRepository;

        }

        public async Task<IEnumerable<MatchLevel>> GetAllMatchesLevelAsync()
        {
            return await _matchlevelRepository.GetAllMatchesLevelAsync();
        }

        public async Task<MatchLevel> GetMatchLevelByIdAsync(int id)
        {
            return await _matchlevelRepository.GetMatchLevelByIdAsync(id);
        }

        public async Task CreateMatchLevelAsync(int Match_ID, int Level_ID, int PointsEarned)
        {
            await _matchlevelRepository.CreateMatchLevelAsync(Match_ID, Level_ID, PointsEarned);
        }

        public async Task UpdateMatchLevelAsync(int id, int Match_ID, int Level_ID, int PointsEarned)
        {
            await _matchlevelRepository.UpdateMatchLevelAsync(id, Match_ID, Level_ID, PointsEarned);
        }

        public async Task SoftDeleteMatchLevelAsync(int id)
        {
            await _matchlevelRepository.SoftDeleteMatchLevelAsync(id);
        }
    }
}
