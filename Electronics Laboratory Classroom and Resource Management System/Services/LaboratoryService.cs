using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface ILaboratoryService
    {
        Task<IEnumerable<Laboratory>> GetAlllaboratoriesAsync();
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

        public async Task<IEnumerable<Laboratory>> GetAlllaboratoriesAsync()
        {
            return await _laboratoryRepository.GetAlllaboratoriesAsync();
        }

        public async Task<Laboratory> GetLaboratoryByIdAsync(int id)
        {
            return await _laboratoryRepository.GetLaboratoryByIdAsync(id);
        }

        public async Task CreateLaboratoryAsync(Laboratory laboratory)
        {
            await _laboratoryRepository.CreateLaboratoryAsync(laboratory);
        }

        public async Task UpdateLaboratoryAsync(Laboratory laboratory)
        {
            await _laboratoryRepository.UpdateLaboratoryAsync(laboratory);
        }

        public async Task SoftDeleteLaboratoryAsync(int id)
        {
            await _laboratoryRepository.SoftDeleteLaboratoryAsync(id);
        }
    }
}
