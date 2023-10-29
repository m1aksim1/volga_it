using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IPaymentLogic
    {
        List<PaymentViewModel> ReadList(PaymentSearchModel model);
        PaymentViewModel ReadElement(PaymentSearchModel model);
        bool Create(PaymentBindingModel model);
    }
}