using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface IMatch_Repository
    {
        Task<IEnumerable<Match>> GetAllmatchesAsync();
        Task<Match> GetMatchByIdAsync(int id);
        Task CreateMatchAsync(int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore);
        Task UpdateMatchAsync(int id, int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore);
        Task SoftDeleteMatchAsync(int id);

    }
    public class Match_Repository : IMatch_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Match_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Match>> GetAllmatchesAsync()
        {
            return await _context.matches
                .Include(m => m.User)
                .Where(m => !m.IsDeleted)
                .ToListAsync();
        }
        public async Task<Match> GetMatchByIdAsync(int id)
        {
            return await _context.matches 
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Match_ID == id && !m.IsDeleted);
        }

        public async Task SoftDeleteMatchAsync(int id)
        {
            var match = await _context.matches.FindAsync(id);
            if (match != null)
            {
                match.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateMatchAsync(int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore)
        {
            var User = await _context.users.FindAsync(User_ID) ?? throw new Exception("User not found");

            var match = new Match

            {
                User = User,
                StartDate = StartDate,
                IsFinished = IsFinished,
                PositionX = PositionX,
                PositionY = PositionY,
                PositionZ = PositionZ,
                CurrentScore = CurrentScore,
            };

            _context.matches.Add(match);
            await _context.SaveChangesAsync();


        }


        public async Task UpdateMatchAsync(int id, int User_ID, DateTime StartDate, bool IsFinished, float PositionX, float PositionY, float PositionZ, int CurrentScore)
        {
            var Match = await _context.matches.FindAsync(id) ?? throw new Exception("Match not found");
            var User = await _context.users.FindAsync(User_ID) ?? throw new Exception("User not found");

            Match.User = User;
            Match.StartDate = StartDate;
            Match.IsFinished = IsFinished;
            Match.PositionX = PositionX;
            Match.PositionY = PositionY;
            Match.PositionZ = PositionZ;
            Match.CurrentScore = CurrentScore;
            try
            {
                _context.matches.Update(Match);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
