using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security
{
    public static class SecurityContext
    {
        static seller _Seller = null;

        public static seller GetSeller()
        {
            return _Seller;
        }

        public static void SetSeller(seller Seller)
        {
            _Seller = Seller;
        }
    }
}
