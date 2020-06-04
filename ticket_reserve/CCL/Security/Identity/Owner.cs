using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Owner
        : seller
    {
        public Owner(int sellersId, int ticket_id, string name, string login, string password)
           : base(sellersId, ticket_id, name, nameof(Owner), password)
        {
        }
    }
}
