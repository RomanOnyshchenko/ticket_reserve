using System;
using System.Collections.Generic;
using System.Text;

namespace ticket_reserve.DAL.Entities
{
    class ticket_order
    {
        public int ticketOrderID { get; set; }
        public List<ticket> tickets { get; set; }
        public List<seller> sellers { get; set; }
        public List<clients> clients { get; set; }
    }
}
