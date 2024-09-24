using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface ILaboratoryService
    {
        Task<IEnumerable<Laboratory>> GetAllLaboratoryAsync();
        Task<Laboratory> GetLaboratoryByIdAsync(int id);
        Task CreateLaboratoryAsync(Laboratory laboratory);
        Task UpdateLaboratoryAsync(Laboratory laboratory);
        Task SoftDeleteLaboratoryAsync(int id);
    }
    public class LaboratoryService : ILaboratoryService
    {
        private readonly ILaboratory_Repository _laboratoryRepository;

        public LaboratoryService(ILaboratory_Repository laboratoryRepository)
        {
            _laboratoryRepository = laboratoryRepository;
        }

        public async Task<IEnumerable<Laboratory>> GetAllLaboratoryAsync()
        {
            return await _laboratoryRepository.GetAllLaboratoryAsync();
        }

        public async Task<Laboratory> GetLaboratoryByIdAsync(int Laboratory_ID)
        {
            return await _laboratoryRepository.GetLaboratoryByIdAsync(Laboratory_ID);
        }

        public async Task CreateLaboratoryAsync(Laboratory laboratory)
        {
            await _laboratoryRepository.CreateLaboratoryAsync(laboratory);
        }

        public async Task UpdateLaboratoryAsync(Laboratory laboratory)
        {
            await _laboratoryRepository.UpdateLaboratoryAsync(laboratory);
        }

        public async Task SoftDeleteLaboratoryAsync(int Laboratory_ID)
        {
            await _laboratoryRepository.SoftDeleteLaboratoryAsync(Laboratory_ID);
        }
    }
}
