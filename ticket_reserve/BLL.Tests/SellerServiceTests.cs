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

namespace BLL.Tests
{
    public class SellerServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new SellerService(nullUnitOfWork));
        }

        [Fact]
        public void GetSellers_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            seller Seller = new Owner(1, 1, "Roman", nameof(Owner), "pass");
            SecurityContext.SetSeller(Seller);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ISellerService sellerService = new SellerService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => sellerService.GetSellers(0));
        }

    }
}
