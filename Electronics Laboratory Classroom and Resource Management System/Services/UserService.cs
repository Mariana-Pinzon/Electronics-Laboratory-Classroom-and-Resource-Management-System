using Electronics_Laboratory_Classroom_and_Resource_Management_System.Model;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllusersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(string First_Name, string Last_Name, string Email, string Password, int User_Type_ID);
        Task UpdateUserAsync(int id, string First_Name, string Last_Name, string Email, string Password, int User_Type_ID);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string Email, string Password);

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

        public async Task<IEnumerable<User>> GetAllusersAsync()
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,11)
                || await _userPermissionRepository.HasPermissions(2, 11);//Ver Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para ver los demás usuarios.");
            }
            return await _userRepository.GetAllusersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,11)
                || await _userPermissionRepository.HasPermissions(2, 11);//Ver Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para ver los demás usuarios.");
            }
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task CreateUserAsync(string First_Name, string Last_Name, string Email, string Password, int User_Type_ID)
        {
            await _userRepository.CreateUserAsync(First_Name,Last_Name, Email, Password, User_Type_ID);
        }

        public async Task UpdateUserAsync(int id, string First_Name, string Last_Name, string Email, string Password, int User_Type_ID)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,11)
                || await _userPermissionRepository.HasPermissions(2, 11);//Ver Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para actualizar usuarios.");
            }
            await _userRepository.UpdateUserAsync(id, First_Name, Last_Name, Email, Password, User_Type_ID);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            bool hasPermission = await _userPermissionRepository.HasPermissions(1,11)
                || await _userPermissionRepository.HasPermissions(2, 11);//Ver Usuario/Actualizar/Borrar
            if (!hasPermission)
            {
                throw new UnauthorizedAccessException("No tienes permiso para eliminar usuarios.");
            }
            await _userRepository.SoftDeleteUserAsync(id);
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            {
                try
                {
                    return await _userRepository.ValidateUserAsync(email, password);
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }
    }
}
