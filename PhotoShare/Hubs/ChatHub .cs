using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PhotoShare.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, int i)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message, i);
        }
    }
}