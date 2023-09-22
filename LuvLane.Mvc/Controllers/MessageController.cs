using LuvLane.Models.Message;
using LuvLane.Services.MessageService;
using Microsoft.AspNetCore.Mvc;

namespace LuvLane.Mvc.Controllers;

public class MessageController : Controller
{
    private readonly IMessageService _messageService;
    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Create(MessageCreate model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _messageService.CreateMessageAsync(model);
        return RedirectToAction(nameof(Index));
    }
}
