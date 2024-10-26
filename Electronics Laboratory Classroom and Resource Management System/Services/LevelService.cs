using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface ILevelService
    {
        Task<IEnumerable<Level>> GetAlllevelsAsync();
        Task<Level> GetLevelByIdAsync(int id);
        Task CreateLevelAsync(string Level_Name, int ScorePerLevel);
        Task UpdateLevelAsync(int id, string Level_Name, int ScorePerLevel);
        Task SoftDeleteLevelAsync(int id);
    }
    public class LevelService : ILevelService
    {
        private readonly ILevel_Repository _levelRepository;

        public LevelService(ILevel_Repository levelRepository)
        {
            _levelRepository = levelRepository;

        }

        public async Task<IEnumerable<Level>> GetAlllevelsAsync()
        {
            return await _levelRepository.GetAlllevelsAsync();
        }

        public async Task<Level> GetLevelByIdAsync(int id)
        {
            return await _levelRepository.GetLevelByIdAsync(id);
        }

        public async Task CreateLevelAsync(string Level_Name, int ScorePerLevel)
        {
            await _levelRepository.CreateLevelAsync(Level_Name, ScorePerLevel);
        }

        public async Task UpdateLevelAsync(int id, string Level_Name, int ScorePerLevel)
        {
            await _levelRepository.UpdateLevelAsync(id, Level_Name, ScorePerLevel);
        }

        public async Task SoftDeleteLevelAsync(int id)
        {
            await _levelRepository.SoftDeleteLevelAsync(id);
        }
    }
}
