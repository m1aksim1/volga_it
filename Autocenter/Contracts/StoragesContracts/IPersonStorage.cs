using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.StoragesContracts
{
    public interface IPersonStorage
    {
        PersonViewModel? GetElement(PersonSearchModel model);
        PersonViewModel? Insert(PersonBindingModel model);
        PersonViewModel? Update(PersonBindingModel model);
        PersonViewModel? Delete(PersonBindingModel model);
    }
}
