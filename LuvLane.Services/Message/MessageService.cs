using LuvLane.Data;
using LuvLane.Data.Entities;
using LuvLane.Models.Message;

namespace LuvLane.Services.MessageService;

    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMessageAsync(MessageCreate model)
        {
            Messages message = new()
            {
                UserSenderId = model.UserId,
                MessageText = model.MessageText,
                MessageDate = model.MessageDate
            };

            _context.Message.Add(message);
            return await _context.SaveChangesAsync() == 1;
        }
    }
