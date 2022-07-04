using Microsoft.AspNetCore.Components;
using SQLDataAccess;
using SQLDataAccess.Models;
using TicketSystem.Models;

namespace TicketSystem.Managers
{
    public class TicketManager
    {
        private readonly TicketData TicketDb;
        private readonly UserManager UserManager;
        public TicketManager(TicketData ticketDb, UserManager userManager)
        {
            TicketDb = ticketDb;
            UserManager = userManager;
        }

        private List<TicketModel> ticketModels = new List<TicketModel>();
         
        public async Task CreateTicket(DisplayTicketModel model)
        {
            TicketModel ticket = new TicketModel()
            {
                DateTime = DateTime.Now.ToString(),
                Title = model.Title,
                Description = model.Description,
                RequestorId = UserManager.CurrentUser.Id,
                Status = (int)TicketStatus.Open,
                SolvedById = null
            };

            await TicketDb.InsertTicket(ticket);
            ticketModels = await TicketDb.GetTickets();
        }

        public async Task Initialize()
        {
            ticketModels = await TicketDb.GetTickets();
        }
    }

    public enum TicketStatus
    {
        Open = 1,
        Urgent = 2,
        CurrentlyProcessed = 3,
        Solved = 4
    }
}
