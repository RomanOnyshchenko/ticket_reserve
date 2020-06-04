using System;
using System.Collections.Generic;
using System.Text;
using ticket_reserve.DAL.Entities;
using ticket_reserve.DAL.Repositories.Interfaces;

namespace DAL.Repositories.Interfaces
{
    public interface IticketRepository
        : IRepository<ticket>
    {
    }
}
