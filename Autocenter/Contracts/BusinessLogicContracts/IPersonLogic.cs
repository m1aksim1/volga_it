using Contracts.SearchModels;
using Contracts.ViewModels;
using Contracts.BindingModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IPersonLogic
    {
        List<PersonViewModel> ReadList(PersonSearchModel? model = null);
        PersonViewModel? ReadElement(PersonSearchModel model);
        bool Create(PersonBindingModel model);
        bool Update(PersonBindingModel model);
        bool Delete(PersonBindingModel model);
    }
}
