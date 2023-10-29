using DataModels;
using DataModels.Enums;

namespace Contracts.ViewModels
{
    public class TransportViewModel : ITransportModel
    {
        public string Name { get; set; } = string.Empty;
        public double RentCost { get; set; }
        public TypeTransport TypeTransport { get; set; }
        public int Id { get; set; }
    }
}