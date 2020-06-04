using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Admin
        : seller
    {
        public Admin(int sellersId, int ticket_id, string name, string login, string password)
            : base(sellersId, ticket_id, name, nameof(Admin), password)
        {
        }
    }
}
