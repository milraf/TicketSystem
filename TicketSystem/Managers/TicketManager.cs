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
         
        public async Task<List<TicketModel>> LoadTickets()
        {
            return await TicketDb.GetTickets();
        }

        public TicketModel? GetTicketById(int id)
        {
            return ticketModels.FirstOrDefault(x => x.Id == id);
        }

        public async Task CreateTicket(DisplayUserTicketModel model)
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

        public async Task EditTicketUser(DisplayUserTicketModel model, int ticketId)
        {
            var ticket = ticketModels.FirstOrDefault(x => x.Id == ticketId);
            ticket.Title = model.Title;
            ticket.Description = model.Description;

            await TicketDb.UpdateTicket(ticket);
        }

        public async Task EditTicketAdmin(DisplayAdminTicketModel model, int ticketId)
        {
            var ticket = ticketModels.FirstOrDefault(x => x.Id == ticketId);
            ticket.Title = model.Title;
            ticket.Description = model.Description;
            ticket.Status = (int)model.Status;

            await TicketDb.UpdateTicket(ticket);
        }

        public async Task EditTicketAdmin(DisplayUserTicketModel model, int ticketId)
        {
            var ticket = ticketModels.FirstOrDefault(x => x.Id == ticketId);
            ticket.Title = model.Title;
            ticket.Description = model.Description;
            //Add admin add stuff
            await TicketDb.UpdateTicket(ticket);
        }

        public async Task DeleteTicketById(int id)
        {
            var ticket = ticketModels.FirstOrDefault(x => x.Id == id);
            await TicketDb.RemoveTicket(ticket);
            ticketModels.Remove(ticket);
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
