using System;
using System.Collections.Generic;
using System.Text;

namespace ticket_reserve.DAL.Entities
{
    class ticket
    {
        public int ticketID { get; set; }
        public string ticketDate { get; set; }
        public int cost { get; set; }
        public string ticketPlace { get; set; }
    }
}
