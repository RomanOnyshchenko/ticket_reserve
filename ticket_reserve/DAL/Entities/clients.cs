using System;
using System.Collections.Generic;
using System.Text;

namespace ticket_reserve.DAL.Entities
{
    public class clients
    {
        public int clientID { get; set; }
        public string clientName { get; set; }
        public int clientAge { get; set; }
        public bool registration { get; set; }
        public string registration_date { get; set; }

    }
}
