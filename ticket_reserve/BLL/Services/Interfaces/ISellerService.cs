using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface ISellerService
    {
        
        IEnumerable<sellerDTO> GetSellers(int page);
    }
}
