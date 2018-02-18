using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ENotify.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public ValuesController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Message msg)
        {
            if(msg.Type == "Notify")
            {
                _hubContext.Clients.All.BroadcastMessage(msg.Type, msg.Payload);
                return "Success";
            }

            return "Failed";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
