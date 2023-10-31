using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;

namespace BusinessLogics
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserStorage _personStorage;
        public UserLogic(IUserStorage clientStorage)
        {
            _personStorage = clientStorage;
        }
        public bool Create(UserBindingModel model)
        {
            try
            {
                //CheckModel(model);
                var result = _personStorage.Insert(model);
                if (result == null)
                {
                    throw new ArgumentNullException($"Клиент не создался");
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserViewModel ReadElement(UserSearchModel model)
        {
            try
            {
                var result = _personStorage.GetElement(model);
                if (result == null)
                {
                    throw new ArgumentNullException($"Результат получения элемента с id {model.Id} оказался нулевым");
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserViewModel> ReadList(UserSearchModel? model = null)
        {
            try
            {
                var results = model != null ? _personStorage.GetFilteredList(model) : _personStorage.GetFullList();
                return results;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Update(UserBindingModel model)
        {
            //CheckModel(model);
            if (_personStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(UserBindingModel model)
        {
            //CheckModel(model);
            if (_personStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }

    }
}
