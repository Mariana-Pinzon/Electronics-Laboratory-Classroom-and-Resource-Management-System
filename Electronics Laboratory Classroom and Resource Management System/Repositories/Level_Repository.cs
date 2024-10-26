using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface ILevel_Repository
    {
        Task<IEnumerable<Level>> GetAlllevelsAsync();
        Task<Level> GetLevelByIdAsync(int id);
        Task CreateLevelAsync(string Level_Name, int ScorePerLevel);
        Task UpdateLevelAsync(int id, string Level_Name, int ScorePerLevel);
        Task SoftDeleteLevelAsync(int id);
    }
    public class Level_Repository : ILevel_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Level_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Level>> GetAlllevelsAsync()
        {
            try
            {
                return await _context.levels
                .Where(le => !le.IsDeleted)
                .ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public async Task<Level> GetLevelByIdAsync(int id)
        {
            return await _context.levels
                .FirstOrDefaultAsync(le => le.Level_ID == id && !le.IsDeleted);
        }

        public async Task SoftDeleteLevelAsync(int id)
        {
            var level = await _context.levels.FindAsync(id);
            if (level != null)
            {
                level.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateLevelAsync(string Level_Name, int ScorePerLevel)
        {
            var level = new Level
            {
                Level_Name = Level_Name,
                ScorePerLevel = ScorePerLevel,
            };
            _context.levels.Add(level);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateLevelAsync(int id, string Level_Name, int ScorePerLevel)
        {
            var Level = await _context.levels.FindAsync(id) ?? throw new Exception("Level not found");

            Level.Level_Name = Level_Name;
            Level.ScorePerLevel = ScorePerLevel;

            try
            {
                _context.levels.Update(Level);
                await _context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw;
            }

        }
    }
}
