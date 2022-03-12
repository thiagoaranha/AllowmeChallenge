using AllowmeChallenge.Application.Model;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AllowmeChallenge.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BillingController : Controller
    {
        private readonly IBillingsService _billingsService;
        private readonly IMapper _mapper;

        public BillingController(IBillingsService billingsService,
                                    IMapper mapper)
        {
            _billingsService = billingsService;
            _mapper = mapper;
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<IActionResult> Get(DateTime startDate, DateTime endDate)
        {
            var billing = _mapper.Map<Billings, BillingsModel>(await _billingsService.CreateBilling(startDate, endDate));

            return Ok(billing);
        }
    }
}
