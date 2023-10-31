using DataModels;
using DataModels.Enums;

namespace Contracts.BindingModels
{
    public class RentBindingModel : IRentModel
    {
        public long TransportId { get; set; }

        public long UserId { get; set; }

        public DateTime DateStart { get; set; } = DateTime.UtcNow;

        public DateTime? DateEnd { get; set; }

        public TypeRent PriceType { get; set; }

        public double PriceOfUnit { get; set; }

        public double FinalPrice { get; set; }

        public long Id { get; set; }

    }
}
