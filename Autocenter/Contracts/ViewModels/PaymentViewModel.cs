using DataModels;

namespace Contracts.ViewModels
{
    public class PaymentViewModel : IPaymentModel
    {
        public double Sum { get; set; }
        public int CarByPurchaseId { get; set; }
        public int Id { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
