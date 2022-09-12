using DiscordBot_Api.Data;
using DiscordBot_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot_Api.Services
{
    public interface IMessageService 
    {
        Task<IEnumerable<Message>> GetProductList();
        Task<Message> GetMessageByOwnerId(int id);
        Task<Message> AddMessage(Message message);
        Task<Message> UpdateMessage(Message message);
        Task<bool> DeleteMessagesByOwnerId(int id);
    }

    public class MessageService : IMessageService
    {
        private readonly DbContextClass _dbContext;

        public MessageService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Message> AddMessage(Message message)
        {
            var result = _dbContext.Messages.Add(message);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteMessagesByOwnerId(int id)
        {
            var data = await _dbContext.Messages.FirstOrDefaultAsync(_ => _.OwnerId == id);
            var result = _dbContext.Messages.Remove(data);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<Message> GetMessageByOwnerId(int id)
        {
            return await _dbContext.Messages.FirstOrDefaultAsync(_ => _.OwnerId == id);
        }

        public async Task<IEnumerable<Message>> GetProductList()
        {
            return await _dbContext.Messages.ToListAsync();
        }

        public async Task<Message> UpdateMessage(Message message)
        {
            var result = _dbContext.Messages.Update(message);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
