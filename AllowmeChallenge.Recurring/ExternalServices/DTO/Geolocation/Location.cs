using System.Collections.Generic;

namespace AllowmeChallenge.Recurring.ExternalServices.DTO.Geolocation
{
    public class Location
    {
        public Address address { get; set; }
        public List<string> boundingbox { get; set; }
        public string display_name { get; set; }
        public string lat { get; set; }
        public string licence { get; set; }
        public string lon { get; set; }
        public string osm_id { get; set; }
        public string osm_type { get; set; }
        public string place_id { get; set; }
    }
}
