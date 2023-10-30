using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.StoragesContracts
{
    public interface IRentStorage
    {
        List<RentViewModel> GetFullList();
        List<RentViewModel> GetFilteredList(RentSearchModel model);
        RentViewModel? GetElement(RentSearchModel model);
        RentViewModel? Insert(RentBindingModel model);
        RentViewModel? Update(RentBindingModel model);
        RentViewModel? Delete(RentBindingModel model);
    }
}