using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using BLL.DTO;
using CCL.Security;
using System.Security.Permissions;
using CCL.Security.Identity;
using AutoMapper;
using Xunit;
using BLL.Services.Impl;
using Moq;
using DAL.Repositories.Interfaces;
using ticket_reserve.DAL.Entities;
using seller = ticket_reserve.DAL.Entities.seller;

namespace BLL.Tests
{
    public class SellerServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            IUnitOfWork nullUnitOfWork = null;

            Assert.Throws<ArgumentNullException>(() => new SellerService(nullUnitOfWork));
        }
        [Fact]
        public void GetSellers_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            CCL.Security.Identity.seller Seller = new Admin(1, 1, "test", nameof(Admin), "pass");
            SecurityContext.SetSeller(Seller);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ISellerService sellerService = new SellerService(mockUnitOfWork.Object);
            
            Assert.Throws<MethodAccessException>(() => sellerService.GetSellers(0));
        }

        [Fact]
        public void GetSellers_sellerFromDAL_CorrectMappingToSellerDTO()
        {
            // Arrange
            CCL.Security.Identity.seller Seller = new Owner(1, 1, "test", nameof(Owner), "pass");
            SecurityContext.SetSeller(Seller);
            var sellerService = GetSellerService();

            // Act
            var actualSellerDtO = sellerService.GetSellers(0).First();

            // Assert
            Assert.True(
                actualSellerDtO.sellerID == 1
                && actualSellerDtO.ticketID == 1
                && actualSellerDtO.Name == "testN"
                && actualSellerDtO.Login == nameof(seller)
                
            );
        }

        ISellerService GetSellerService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedSeller = new seller() { sellerID = 1, TicketID = 1, sellerName = "testN", login = nameof(seller)};
            var mockDbSet = new Mock<IsellerRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<seller, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<seller>() { expectedSeller }
                    );
            mockContext
                .Setup(context =>
                    context.sellers)
                .Returns(mockDbSet.Object);

            ISellerService streetService = new SellerService(mockContext.Object);

            return streetService;
        }
    }
}
