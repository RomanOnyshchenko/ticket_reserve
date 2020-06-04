using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public abstract class seller
    {
        public seller(int sellersId, int ticket_id, string name, string login, string password)
        {
            SellerID = sellersId;
            TicketID = ticket_id;
            Name = name;
            Login  = login;
            Password = password;
        }
        public int SellerID { get; }
        public int TicketID { get; }
        public string Name { get; }
        protected string Login { get; }
        public string Password { get; }
    }
}
