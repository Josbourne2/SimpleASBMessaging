using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASBMessaging.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageHandler _handler;

        public MessageController(IMessageHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            await _handler.SendAsync(message);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ReceiveMessage(string message)
        {
            string result = await _handler.ReceiveAsync();
            return Content(result);
        }
    }
}