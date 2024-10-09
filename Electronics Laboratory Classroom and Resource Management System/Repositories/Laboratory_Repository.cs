using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface ILaboratory_Repository
    {
        Task<IEnumerable<Laboratory>> GetAlllaboratoriesAsync();
        Task<Laboratory> GetLaboratoryByIdAsync(int id);
        Task CreateLaboratoryAsync(Laboratory laboratory);
        Task UpdateLaboratoryAsync(Laboratory laboratory);
        Task SoftDeleteLaboratoryAsync(int id);
    }
    public class Laboratory_Repository : ILaboratory_Repository
    {
        private readonly ElectronicsLaboratoryClassroomandResourceDBContext _context;
        public Laboratory_Repository(ElectronicsLaboratoryClassroomandResourceDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Laboratory>> GetAlllaboratoriesAsync()
        {
            return await _context.laboratories
                .Where(l => !l.IsDeleted)
                .ToListAsync();
        }
        public async Task<Laboratory> GetLaboratoryByIdAsync(int id)
        {
            return await _context.laboratories
                .FirstOrDefaultAsync(l => l.Laboratory_ID == id && !l.IsDeleted);
        }

        public async Task SoftDeleteLaboratoryAsync(int id)
        {
            var laboratory = await _context.laboratories.FindAsync(id);
            if (laboratory != null)
            {
                laboratory.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateLaboratoryAsync(Laboratory laboratory)
        {
            _context.laboratories.Add(laboratory);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateLaboratoryAsync(Laboratory laboratory)
        {
            _context.laboratories.Update(laboratory);
            await _context.SaveChangesAsync();
        }
    }
}