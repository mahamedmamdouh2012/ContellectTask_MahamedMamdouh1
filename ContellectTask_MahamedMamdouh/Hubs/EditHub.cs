using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace ContellectTask_MahamedMamdouh.Hubs
{
    public class EditHub : Hub
    {
        public async Task LockEdit(int ContactId ,int status)
        {
            await Clients.All.SendAsync("LockContact", ContactId, status);
        }
    }
}
