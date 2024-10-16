using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories
{
    public interface ILaboratory_Repository
    {
        Task<IEnumerable<Laboratory>> GetAlllaboratoriesAsync();
        Task<Laboratory> GetLaboratoryByIdAsync(int id);
        Task CreateLaboratoryAsync(int Laboratory_Num, int Capacity);
        Task UpdateLaboratoryAsync(int id, int Laboratory_Num, int Capacity);
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

        public async Task CreateLaboratoryAsync(int Laboratory_Num, int Capacity)
        {
            var laboratory = new Laboratory
            {
                Laboratory_Num = Laboratory_Num,
                Capacity = Capacity,
            };
            _context.laboratories.Add(laboratory);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateLaboratoryAsync(int id, int Laboratory_Num, int Capacity)
        {
            var Laboratory = await _context.laboratories.FindAsync(id) ?? throw new Exception("Laboratory not found");

            Laboratory.Laboratory_Num = Laboratory_Num;
            Laboratory.Capacity = Capacity;

            try
            {
                _context.laboratories.Update(Laboratory);
                await _context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                throw;
            }

        }


    }
}
