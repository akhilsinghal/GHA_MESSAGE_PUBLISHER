using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ebay.Message.BroadcastHelper;
using Microsoft.AspNetCore.Mvc;

namespace Ebay.Message.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IBroadcastHelper messagePusher;
        public MessageController(IBroadcastHelper helper)
        {
            this.messagePusher = helper;
        }

        // POST api/message
        [HttpPost]
        public bool Post([FromBody] string message)
        {
            return messagePusher.SendMessage(message);
        }
    }
}
