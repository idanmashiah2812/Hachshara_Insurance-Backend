using InsuranceWebApi.Models;

namespace InsuranceWebApi.Interfaces
{
    /// <summary>
    /// The interface defines User functionallity among a db repository
    /// </summary>
    public interface IUserRepository
    {
        Task<UserModel?> GetUserById(int userId);
        IEnumerable<UserModel?> GetAllUsers();
        Task<bool> InsertUser(UserModel userToInsert);
        Task<bool> UpdateUser(UserModel userToUpdate);
        Task<bool> DeleteUserById(int userId);
    }
}
