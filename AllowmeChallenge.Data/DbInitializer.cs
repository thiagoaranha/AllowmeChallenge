using AllowmeChallenge.Data.Context;
using AllowmeChallenge.Domain.Entity;
using System.Linq;

namespace AllowmeChallenge.Data
{
    public class DbInitializer
    {
        public static void Initialize(AllowmeContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return;   
            }

            var services = new Services[]
            {
                new Services{ Name = "Weather - API", Endpoint = "https://weather.contrateumdev.com.br/api", Path = "/weather/city", PricePerRequest = decimal.Parse("0.95035") },
                new Services{ Name = "Geolocalização - API", Endpoint = "https://geolocation.contrateumdev.com.br/api", Path = "/geocode", PricePerRequest = decimal.Parse("19.1203") }
            };

            foreach(var service in services)
            {
                context.Services.Add(service);
            }

            var user = new User { Username = "allowme", Password = "password" };

            context.User.Add(user);


            context.SaveChanges();
        }

    }
}
