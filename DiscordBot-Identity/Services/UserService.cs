using DiscordBot_Identity.Data;
using DiscordBot_Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot_Identity.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersList();
        Task<User> GetUserById(Guid id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUserById(Guid id);
    }
    public class UserService : IUserService
    {
        private readonly DbContextClass _dbContext;
        public UserService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            var result = _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteUserById(Guid id)
        {
            var data = await _dbContext.Users.FirstOrDefaultAsync(_ => _.Id == id);
            var result = _dbContext.Users.Remove(data);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersList()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
