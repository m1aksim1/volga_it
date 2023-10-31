using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.StoragesContracts
{
    public interface IUserStorage
    {
        List<UserViewModel> GetFullList();
        List<UserViewModel> GetFilteredList(UserSearchModel model);
        UserViewModel? GetElement(UserSearchModel model);
        UserViewModel? Insert(UserBindingModel model);
        UserViewModel? Update(UserBindingModel model);
        UserViewModel? Delete(UserBindingModel model);
    }
}
