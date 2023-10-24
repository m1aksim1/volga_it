using DataModels.HelperInterfaces;

namespace DataModels
{
    public interface IPaymentModel : IId
    {
        double Sum { get; }
		int CarByPurchaseId { get; }
        DateOnly Date { get; }
    }
}