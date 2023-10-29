using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
    public interface ICarLogic
    {
        List<TransportViewModel> ReadList(TransportSearchModel? model = null);
        TransportViewModel ReadElement(TransportSearchModel model);
        bool Create(TransportBindingModel model);
        bool Update(TransportBindingModel model);
        bool Delete(TransportBindingModel model);
    }
}