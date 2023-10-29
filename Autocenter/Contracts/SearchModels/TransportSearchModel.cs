using DataModels;
using DataModels.Enums;

namespace Contracts.SearchModels
{
    public class TransportSearchModel
    {
        public string Name { get; set; } = string.Empty;
        public double RentCost { get; set; }
        public TypeTransport TypeTransport { get; set; }
        public int Id { get; set; }
    }
}
