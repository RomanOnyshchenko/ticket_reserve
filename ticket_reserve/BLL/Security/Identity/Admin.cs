using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Security.Identity
{
    public class Admin
        : seller
    {
        public Admin(int sellersId, string name, string login, string password)
            : base(sellersId, name, login, password)
        {
        }
    }
}
