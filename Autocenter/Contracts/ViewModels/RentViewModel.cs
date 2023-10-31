using DataModels.Enums;

namespace Contracts.ViewModels
{
    public class RentViewModel
    {
        public long TransportId { get; set; }

        public long PersonId { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public TypeRent RentType { get; set; }

        public double PriceOfUnit { get; set; }

        public TypeRent PriceType { get; set; }

        public long Id { get; set; }
    }
}