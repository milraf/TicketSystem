using SQLDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess
{
    public class TicketData
    {
        private readonly SqlDataAccess db;
        private string database = "dbo.Tickets";

        public TicketData(SqlDataAccess db)
        {
            this.db = db;
        }

        public Task<List<TicketModel>> GetTickets()
        {
            string sql = $"SELECT * FROM {database};";
            return db.LoadData<TicketModel, dynamic>(sql, new { });
        }

        public async Task<TicketModel?> GetTicket(int id)
        {
            string sql = $"SELECT * FROM {database} WHERE Id = {id};";
            var v = await db.LoadData<TicketModel, dynamic>(sql, new { Id = id });
            return v.FirstOrDefault();
        }

        public Task InsertTicket(TicketModel ticket)
        {
            string sql = $@"INSERT INTO {database} (RequestorId, DateTime, Title, Description, Status, SolvedById) VALUES (@RequestorId, @DateTime, @Title, @Description, @Status, @SolvedById);";
            return db.SaveData(sql, ticket);
        }

        public Task UpdateTicket(TicketModel ticket)
        {
            string sql = $@"UPDATE {database} SET DateTime = @DateTime, Title = @Title, Description = @Description, Status = @Status, SolvedById = @SolvedById WHERE Id = @Id;";
            return db.SaveData(sql, ticket);
        }
    }
}
