using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;

namespace BusinessLogics
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IPersonStorage _personStorage;
        public PersonLogic(IPersonStorage clientStorage)
        {
            _personStorage = clientStorage;
        }
        public bool Create(PersonBindingModel model)
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

        public PersonViewModel ReadElement(PersonSearchModel model)
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

        public List<PersonViewModel> ReadList(PersonSearchModel? model = null)
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

        public bool Update(PersonBindingModel model)
        {
            //CheckModel(model);
            if (_personStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(PersonBindingModel model)
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
