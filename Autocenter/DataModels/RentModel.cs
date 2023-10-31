using DataModels.HelperInterfaces;
using DataModels.Enums;

namespace DataModels
{
    public interface IRentModel : IId
    {
        long TransportId { get; }
        long UserId { get; }
        DateTime DateStart { get; }
        DateTime? DateEnd { get; }
        TypeRent PriceType { get; }
        double PriceOfUnit { get; }
        double FinalPrice { get; }
    }
}