
using AllowmeChallenge.Application.Model;
using AllowmeChallenge.Domain.Entity;
using AllowmeChallenge.Domain.Interfaces.Service;
using AllowmeChallenge.Recurring.ExternalServices.DTO.Weather;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace AllowmeChallenge.Recurring.ExternalServices
{
    public class WeatherApiService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IServicesService _servicesService;
        private readonly IServiceRequestsService _serviceRequestsService;

        public WeatherApiService(IMapper mapper,
                                    ILogger logger,
                                    IServicesService servicesService,
                                    IServiceRequestsService serviceRequestsService)
        {
            _mapper = mapper;
            _logger = logger;
            _servicesService = servicesService;
            _serviceRequestsService = serviceRequestsService;
        }

        public async Task CheckRecifeWeather()
        {
            var weatherService = _mapper.Map<Services, ServicesModel>(await _servicesService.GetWeatherService());

            var requestParameters = string.Format("/?city={0},{1}", "Recife", "pernambuco"); ;
            var responseContent = await ServiceRequest(weatherService, requestParameters);
                        
            City cityWeatherResponse;

            try
            {
                cityWeatherResponse = JsonConvert.DeserializeObject<City>(responseContent);

            }catch(Exception ex)
            {
                _logger.LogError("Deserialize Weather response error: " + ex.Message);
                return;
            }

            if(cityWeatherResponse != null && cityWeatherResponse.cod == 200)
            {
                await CheckCityGeolocation(cityWeatherResponse.coord.lat, cityWeatherResponse.coord.lon);
            }
        }

        public async Task CheckSaoPauloWeather()
        {
            var weatherService = _mapper.Map<Services, ServicesModel>(await _servicesService.GetWeatherService());

            var requestParameters = string.Format("/?city={0},{1}", "Sao Paulo", "sao paulo"); ;
            var responseContent = await ServiceRequest(weatherService, requestParameters);

            City cityWeatherResponse;

            try
            {
                cityWeatherResponse = JsonConvert.DeserializeObject<City>(responseContent);

            }
            catch (Exception ex)
            {
                _logger.LogError("Deserialize Weather response error: " + ex.Message);
                return;
            }

            if (cityWeatherResponse != null && cityWeatherResponse.cod == 200)
            {
                await CheckCityGeolocation(cityWeatherResponse.coord.lat, cityWeatherResponse.coord.lon);
            }
        }

        public async Task CheckCityGeolocation(double lat, double lon)
        {
            var geolocationService = _mapper.Map<Services, ServicesModel>(await _servicesService.GetGeolactionService());

            var requestParameters = string.Format("?lat={0}&lon={1}", lat, lon); 
            await ServiceRequest(geolocationService, requestParameters);
        }


        private async Task<string> ServiceRequest(ServicesModel servicesModel, string requestParameters)
        {
            var client = new RestClient(servicesModel.Endpoint);
            var requestPath = string.Format("{0}{1}", servicesModel.Path, requestParameters);
            var request = new RestRequest(requestPath, Method.Get);

            var response = await client.ExecuteAsync(request);

            var serviceRequest = new ServiceRequests()
            {
                ServiceId = servicesModel.Id,
                CreatedAt = DateTime.Now,
                StatusCode = (int)response?.StatusCode
            };

            await _serviceRequestsService.AddAsync(serviceRequest);

            return response.Content;
        }
    }
}
