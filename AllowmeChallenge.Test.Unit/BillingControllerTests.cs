using AllowmeChallenge.WebApi.Controllers;
using AllowmeChallenge.Application.Configuration;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Service;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace AllowmeChallenge.Test.Unit
{
    [TestClass]
    public class BillingControllerTests
    {
        private Billings GetTestBilling()
        {
            return new Billings
            {
                CreatedAt = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 0
            };
        }

        private IEnumerable<ServiceRequests> GetTestServiceRequests()
        {
            List<ServiceRequests> serviceRequests = new List<ServiceRequests>();
            serviceRequests.Add(new ServiceRequests { CreatedAt = DateTime.Now });
            serviceRequests.Add(new ServiceRequests { CreatedAt = DateTime.Now });
            serviceRequests.Add(new ServiceRequests { CreatedAt = DateTime.Now });

            return serviceRequests;
        }

        [Fact]
        public async Task Billing_Can_Get_Result()
        {

            var mockService = new Mock<IBillingsService>();
            mockService.Setup(repo => repo.GetBillingsSumary(GetTestServiceRequests()));

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperConfig());
            });
            var mapper = mockMapper.CreateMapper();

            var controller = new BillingController(mockService.Object, mapper);

            var result = await controller.Get(DateTime.MinValue, DateTime.MinValue);

            Assert.NotNull(result);
        }
    }
}
