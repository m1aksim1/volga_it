using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.StoragesContracts
{
    public interface ITransportStorage
    {
        List<TransportViewModel> GetFullList();
        List<TransportViewModel> GetFilteredList(TransportSearchModel model);
        TransportViewModel? GetElement(TransportSearchModel model);
        TransportViewModel? Insert(TransportBindingModel model);
        TransportViewModel? Update(TransportBindingModel model);
        TransportViewModel? Delete(TransportBindingModel model);
    }
}