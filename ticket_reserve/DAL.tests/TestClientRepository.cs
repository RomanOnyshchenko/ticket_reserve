using System;
using System.Collections.Generic;
using System.Text;
using ticket_reserve.DAL.Entities;
using ticket_reserve.DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.Repositories.Impl;

namespace DAL.tests
{
    class TestClientRepository 
        : BaseRepository<clients>
    {
        public TestClientRepository(DbContext context)
        : base(context)
        {
        }
    }
}
