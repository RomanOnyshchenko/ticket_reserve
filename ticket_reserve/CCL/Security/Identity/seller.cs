using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Security.Identity
{
    public abstract class seller
    {
        public seller(int sellersId, string name, string login, string password)
        {
            SellerID = sellersId;
            Name = name;
            Login  = login;
            Password = password;
        }
        public int SellerID { get; }
        public string Name { get; }
        public string Login { get; }
        public string Password { get; }
    }
}
