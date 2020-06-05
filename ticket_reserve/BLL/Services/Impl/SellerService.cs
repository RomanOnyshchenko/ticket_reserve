using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ticket_reserve.DAL.Entities;
using ticket_reserve.DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using BLL.DTO;
using CCL.Security;
using System.Security.Permissions;
using CCL.Security.Identity;
using AutoMapper;


namespace BLL.Services.Impl
{
    public class SellerService
        : ISellerService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        public SellerService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<sellerDTO> GetSellers(int pageNumber)
        {
            var seller = SecurityContext.GetSeller();
            var login = seller.GetType();
            if (login != typeof(Owner))
            {
                throw new MethodAccessException();
            }
            var ticketId = seller.TicketID;
            var ticketEntities =
                _database
                    .tickets
                    .Find(z => z.ticketID == ticketId, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<ticket, ticketDTO>()
                    ).CreateMapper();
            var ticketsDTO =
                mapper
                    .Map<IEnumerable<ticket>, List<ticketDTO>>(
                        ticketEntities);
            return (IEnumerable<sellerDTO>)ticketsDTO;



        }
    }
}
