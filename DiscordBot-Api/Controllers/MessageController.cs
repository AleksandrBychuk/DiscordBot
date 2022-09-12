using DiscordBot_Api.Models;
using DiscordBot_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/<MessageController>
        [HttpGet]
        public async Task<IEnumerable<Message>> GetMessageList()
        {
            return await _messageService.GetProductList();
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<Message> GetMessageByOwnerId(int id)
        {
            return await _messageService.GetMessageByOwnerId(id);
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<Message> AddMessage([FromBody] Message message)
        {
            return await _messageService.AddMessage(message);
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public async Task<Message> UpdateMessage ([FromBody] Message message)
        {
            return await _messageService.UpdateMessage(message);
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteMessagesByOwnerId(int id)
        {
            return await _messageService.DeleteMessagesByOwnerId(id);
        }
    }
}
