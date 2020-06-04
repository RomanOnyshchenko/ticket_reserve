using System;
using System.Collections.Generic;
using System.Text;
using ticket_reserve.DAL.Entities;
using ticket_reserve.DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;

namespace DAL.EF
{
    public class EUnitOfWork
        : IUnitOfWork
    {
        private orderContext db;
        private clientsRepository ClientsRepository;
        private sellersRepository SellersRepository;
        private ticket_ordersRepository Ticket_OrdersRepository;
        private ticketsRepository TicketsRepository;

        public EUnitOfWork(orderContext context)
        {
            db = context;
        }
        public IclientRepository clients
        {
            get
            {
                if (ClientsRepository == null)
                    ClientsRepository = new clientsRepository(db);
                return ClientsRepository;
            }
        }
        public IsellerRepository sellers
        {
            get
            {
                if (SellersRepository == null)
                    SellersRepository = new sellersRepository(db);
                return SellersRepository;
            }
        }

        public IorderRepository orders
        {
            get
            {
                if (Ticket_OrdersRepository == null)
                    Ticket_OrdersRepository = new ticket_ordersRepository(db);
                return Ticket_OrdersRepository;
            }
        }

        public IticketRepository tickets 
        {
            get
            {
                if (TicketsRepository == null)
                    TicketsRepository = new ticketsRepository(db);
                return TicketsRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
