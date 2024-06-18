using InsuranceWebApi.Interfaces;
using InsuranceWebApi.Models;

namespace InsuranceWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteUserById(int userId)
        {
            return await _userRepository.DeleteUserById(userId);
        }

        public IEnumerable<UserModel?> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public async Task<UserModel?> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<bool> InsertUser(UserModel userToInsert)
        {
            return await _userRepository.InsertUser(userToInsert);
        }

        public async Task<bool> UpdateUser(UserModel userToUpdate)
        {
            return await _userRepository.UpdateUser(userToUpdate);
        }
    }
}
