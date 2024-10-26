using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IMatchLevel_Repository
    {
        Task<IEnumerable<MatchLevel>> GetAllMatchesLevelAsync();
        Task<MatchLevel> GetMatchLevelByIdAsync(int id);
        Task CreateMatchLevelAsync(int Match_ID, int Level_ID, int PointsEarned);
        Task UpdateMatchLevelAsync(int id, int Match_ID, int Level_ID, int PointsEarned);
        Task SoftDeleteMatchLevelAsync(int id);

    }
    public class MatchLevel_Repository : IMatchLevel_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public MatchLevel_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MatchLevel>> GetAllMatchesLevelAsync()
        {
            return await _context.MatchesLevel
                .Include(ml => ml.Match)
                .Include(ml => ml.Level)
                .Where(ml => !ml.IsDeleted)
                .ToListAsync();
        }
        public async Task<MatchLevel> GetMatchLevelByIdAsync(int id)
        {
            return await _context.MatchesLevel
                .Include(ml => ml.Match)
                .Include(ml => ml.Level)
                .FirstOrDefaultAsync(ml => ml.MatchLevel_ID == id && !ml.IsDeleted);
        }

        public async Task SoftDeleteMatchLevelAsync(int id)
        {
            var matchlevel = await _context.MatchesLevel.FindAsync(id);
            if (matchlevel != null)
            {
                matchlevel.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateMatchLevelAsync(int Match_ID, int Level_ID, int PointsEarned)
        {
            var Match = await _context.matches.FindAsync(Match_ID) ?? throw new Exception("Match not found");
            var Level = await _context.levels.FindAsync(Level_ID) ?? throw new Exception("Level not found");

            var matchlevel = new MatchLevel

            {
                Match = Match,
                Level = Level,
                PointsEarned = PointsEarned,
            };

            _context.MatchesLevel.Add(matchlevel);
            await _context.SaveChangesAsync();

        }


        public async Task UpdateMatchLevelAsync(int id, int Match_ID, int Level_ID, int PointsEarned)
        {
            var MatchLevel = await _context.MatchesLevel.FindAsync(id) ?? throw new Exception("MatchLevel not found");
            var Match = await _context.matches.FindAsync(Match_ID) ?? throw new Exception("Match not found");
            var Level = await _context.levels.FindAsync(Level_ID) ?? throw new Exception("Level not found");

            MatchLevel.Match = Match;
            MatchLevel.Level = Level;
            MatchLevel.PointsEarned = PointsEarned;
            try
            {
                _context.MatchesLevel.Update(MatchLevel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
