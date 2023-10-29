using DataModels.HelperInterfaces;

namespace DataModels
{
    public interface IPaymentModel : IId
    {
        double Sum { get; }
		int TransportByPurchaseId { get; }
        DateOnly Date { get; }
    }
}