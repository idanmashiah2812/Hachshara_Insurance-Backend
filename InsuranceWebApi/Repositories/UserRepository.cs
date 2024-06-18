using InsuranceWebApi.AppDbContextEntity;
using InsuranceWebApi.Interfaces;
using InsuranceWebApi.Models;

namespace InsuranceWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteUserById(int userId)
        {
            var userToDelte = await _dbContext.Users.FindAsync(userId);
            _dbContext.Users.Remove(userToDelte);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            var users = _dbContext.Users;
            return users;
        }

        public async Task<UserModel?> GetUserById(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<bool> InsertUser(UserModel userToInsert)
        {
            await _dbContext.Users.AddAsync(userToInsert);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUser(UserModel userToUpdate)
        {
            var updatedUser = _dbContext.Users.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();
            return userToUpdate.Equals(updatedUser);
        }
    }
}
