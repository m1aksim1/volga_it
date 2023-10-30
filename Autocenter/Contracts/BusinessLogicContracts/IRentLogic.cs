using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IRentLogic
    {
        List<RentViewModel> ReadList(RentSearchModel? model = null);
        RentViewModel ReadElement(RentSearchModel model);
        bool Create(RentBindingModel model);
        bool Update(RentBindingModel model);
        bool Delete(RentBindingModel model);
        bool End(long id);   
    }
}