using AllowmeChallenge.Application.Model;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllowmeChallenge.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ServiceRequestsController : Controller
    {
        private readonly IServiceRequestsService _serviceRequestsService;
        private readonly IMapper _mapper;

        public ServiceRequestsController(IServiceRequestsService serviceRequestsService, IMapper mapper)
        {
            _serviceRequestsService = serviceRequestsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var servicesRequests = _mapper.Map<IEnumerable<ServiceRequests>, IEnumerable<ServiceRequestsModel>>(await _serviceRequestsService.GetAllAsync());

            return Ok(servicesRequests);
        }
    }
}
