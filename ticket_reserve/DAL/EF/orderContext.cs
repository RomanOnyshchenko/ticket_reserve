using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ticket_reserve.DAL.Entities;

namespace DAL.EF
{
    public class orderContext
        : DbContext
    {
        public DbSet<ticket> Tickets { get; set; }
        public DbSet<clients> Clients { get; set; }
        public DbSet<ticket_order> Ticket_Orders { get; set; }
        public DbSet<seller> Sellers { get; set; }
        public orderContext(DbContextOptions options)
            : base(options) { }
    }
}
