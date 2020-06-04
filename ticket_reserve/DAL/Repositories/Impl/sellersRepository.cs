using System;
using System.Collections.Generic;
using System.Text;
using ticket_reserve.DAL.Entities;
using ticket_reserve.DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class sellersRepository
    : BaseRepository<seller>, IsellerRepository
    {
        internal sellersRepository(orderContext context)
            : base(context)
        {

        }
    }
}
