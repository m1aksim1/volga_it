using DataModels;
using DataModels.Enums;
using DataModels.HelperInterfaces;

namespace Contracts.ViewModels
{
    public class TransportViewModel : ITransportModel
    {
        public bool CanBeRented { get; set; }

        public TypeTransport TypeTransport { get; set; }

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public string Identifier { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double MinutePrice { get; set; }

        public double DayPrice { get; set; }

        public long Id { get; set; }

        public long OwnerId { get; set; }
    }
}