using AllowmeChallenge.Application.Model;
using AllowmeChallenge.Domain.Entity;
using AutoMapper;

namespace AllowmeChallenge.Application.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Services, ServicesModel>().ReverseMap();
            CreateMap<Billings, BillingsModel>().ReverseMap();
            CreateMap<ServiceRequests, ServiceRequestsModel>().ReverseMap();
            CreateMap<BillingSumary, BillingSumaryModel>().ReverseMap();
        }
    }
}
