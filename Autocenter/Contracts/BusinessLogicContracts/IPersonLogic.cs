using Contracts.SearchModels;
using Contracts.ViewModels;
using Contracts.BindingModels;

namespace Contracts.BusinessLogicContracts
{
    public interface IUserLogic
    {
        List<UserViewModel> ReadList(UserSearchModel? model = null);
        UserViewModel? ReadElement(UserSearchModel model);
        bool Create(UserBindingModel model);
        bool Update(UserBindingModel model);
        bool Delete(UserBindingModel model);
    }
}
