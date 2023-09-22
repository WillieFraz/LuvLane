using LuvLane.Models.Message;

namespace LuvLane.Services.MessageService;

    public interface IMessageService
    {
                Task<bool> CreateMessageAsync(MessageCreate model);

    }
