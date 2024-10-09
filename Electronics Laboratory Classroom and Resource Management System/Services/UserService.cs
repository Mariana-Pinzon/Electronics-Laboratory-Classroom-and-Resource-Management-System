using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllusersAsync(int userTypeId, int userPermissionId);
        Task<User> GetUserByIdAsync(int userTypeId, int userPermissionId,int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(int userTypeId, int userPermissionId, User user);
        Task SoftDeleteUserAsync(int userTypeId, int userPermissionId,int id);
        Task<bool> ValidateUserAsync(string email, string password);

    }
    public class UserService : IUserService
    {
        private readonly IUser_Repository _userRepository;
        private readonly IUser_Permission_Repository _userPermissionRepository;

        public UserService(IUser_Permission_Repository userPermissionRepository, IUser_Repository userRepository)
        {
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<IEnumerable<User>> GetAllusersAsync(int userTypeId, int userPermissionId)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 11); //Ver Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para ver los demás usuarios.");
            }
            return await _userRepository.GetAllusersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userTypeId, int userPermissionId,int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 11); //Ver Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para ver los demás usuarios.");
            }
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(int userTypeId, int userPermissionId, User user)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 11); //Ver Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar usuarios.");
            }
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task SoftDeleteUserAsync(int userTypeId, int userPermissionId,int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(userTypeId, permissionId: 11); //Ver Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar usuarios.");
            }
            await _userRepository.SoftDeleteUserAsync(id);
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user == null) return false;

            // Verifica la contraseña proporcionada con la contraseña hasheada almacenada en la base de datos
            var passwordHasher = new PasswordHasher<User>();
            var userVerification = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            // Si la verificación es exitosa, devuelve verdadero (autenticado)
            return userVerification == PasswordVerificationResult.Success;
        }
    }
}
