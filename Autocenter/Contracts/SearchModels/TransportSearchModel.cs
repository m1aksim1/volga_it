using DataModels;
using DataModels.Enums;

namespace Contracts.SearchModels
{
    public class TransportSearchModel
    {
        public bool CanBeRented { get; set; }

        public TypeTransport? Type { get; set; }

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public string identifier { get; set; } = string.Empty;

        public string? description { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double? minutePrice { get; set; }

        public double? dayPrice { get; set; }

        public long? Id { get; set; }

        public double Radius { get; set; }
    }
}
