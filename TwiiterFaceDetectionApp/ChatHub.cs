using BusinessObjectLayer;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwiiterFaceDetectionApp
{
    public class ChatHub : Hub
    {
      
    }

    public  class HubManager
    {
        private readonly IHubContext<ChatHub> _IHubContext;
        public HubManager(IHubContext<ChatHub> IHubContext)
        {
            _IHubContext = IHubContext;
        }

        public async Task InvokeAsync(string funcName, string data)
        {
           await _IHubContext.Clients.All.InvokeAsync(funcName, data);
        }
    }
}
