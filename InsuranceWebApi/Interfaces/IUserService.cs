using InsuranceWebApi.Models;

namespace InsuranceWebApi.Interfaces
{
    /// <summary>
    /// The interface defines User functionallity which has been called and invoked by the api
    /// </summary>
    public interface IUserService
    {
        Task<UserModel?> GetUserById(int userId);
        IEnumerable<UserModel?> GetAllUsers();
        Task<bool> InsertUser(UserModel userToInsert);
        Task<bool> UpdateUser(UserModel userToUpdate);
        Task<bool> DeleteUserById(int userId);
    }
}
