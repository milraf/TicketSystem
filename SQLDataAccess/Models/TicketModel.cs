using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int RequestorId { get; set; }
        public string DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int? SolvedById { get; set; }
    }
}
