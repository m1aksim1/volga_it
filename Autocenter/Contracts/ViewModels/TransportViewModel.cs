using DataModels;
using DataModels.Enums;

namespace Contracts.ViewModels
{
    public class TransportViewModel : ITransportModel
    {
        public bool CanBeRented { get; set; }

        public TypeTransport TypeTransport { get; set; }

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public string identifier { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public double latitude { get; set; }

        public double longitude { get; set; }

        public double minutePrice { get; set; }

        public double dayPrice { get; set; }

        public int Id { get; set; }
    }
}