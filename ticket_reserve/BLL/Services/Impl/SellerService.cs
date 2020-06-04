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
            if (login != typeof(Admin)
                && login != typeof(Owner))
            {
                throw new MethodAccessException();
            }
            var ticketId = seller.TicketID;
            var ticket_ordersEntities =
                _database
                    .orders
                    .Find(z => z.ticketOrderID == ticketId, pageNumber, pageSize);
            var mapper = new MapperConfiguration(
                    cfg => cfg.CreateMap<ticket_order, ticket_orderDTO>()
                    ).CreateMapper();
            var ticketsOrderDTO =
                mapper
                    .Map<IEnumerable<ticket_order>, List<ticket_orderDTO>>(
                        ticket_ordersEntities);
            return (IEnumerable<sellerDTO>)ticketsOrderDTO;



        }
    }
}
