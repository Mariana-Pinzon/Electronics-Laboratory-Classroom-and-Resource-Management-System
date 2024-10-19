using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;


namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IUser_TypeService
    {
        Task<IEnumerable<User_Type>> GetAlluser_typesAsync();
        Task<User_Type> GetUser_TypeByIdAsync(int id);
        Task CreateUser_TypeAsync(string UserType);
        Task UpdateUser_TypeAsync(int id, string UserType);
        Task SoftDeleteUser_TypeAsync(int id);
    }
    public class User_TypeService : IUser_TypeService
    {
        private readonly IUser_Type_Repository _userTypeRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public User_TypeService(IUser_Permission_Repository userPermissionRepository, IUser_Type_Repository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<User_Type>> GetAlluser_typesAsync()
        {
            return await _userTypeRepository.GetAlluser_typesAsync();
        }

        public async Task<User_Type> GetUser_TypeByIdAsync(int id)
        {
            return await _userTypeRepository.GetUser_TypeByIdAsync(id);
        }

        public async Task CreateUser_TypeAsync(string UserType)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,10); //Crear Tipo de Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para crear tipo de usuario.");
            }
            await _userTypeRepository.CreateUser_TypeAsync(UserType);
        }

        public async Task UpdateUser_TypeAsync(int id, string UserType)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,10); //Crear Tipo de Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar tipo de usuario.");
            }
            await _userTypeRepository.UpdateUser_TypeAsync(id, UserType);
        }

        public async Task SoftDeleteUser_TypeAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,10); //Crear Tipo de Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar tipo de usuario.");
            }
            await _userTypeRepository.SoftDeleteUser_TypeAsync(id);
        }
    }
}
