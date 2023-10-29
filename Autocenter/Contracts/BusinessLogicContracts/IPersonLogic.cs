using Contracts.SearchModels;
using Contracts.ViewModels;
using Contracts.BindingModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IPersonLogic
    {
        PersonViewModel? ReadElement(PersonSearchModel model);
        bool Create(PersonBindingModel model);
        bool Update(PersonBindingModel model);
    }
}
