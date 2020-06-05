using System;
using System.Collections.Generic;
using System.Text;

namespace ticket_reserve.DAL.Entities
{
    public class seller
    {
        public int sellerID { get; set; }
        public int TicketID { get; set; }
        public string sellerName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        
    }
}
