using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;

namespace BusinessLogics
{
    public class TransportLogic : ITransportLogic
    {
        private readonly ITransportStorage _transportStorage;
        public TransportLogic(ITransportStorage transportStorage)
        {
            _transportStorage = transportStorage;
        }
        public bool Create(TransportBindingModel model)
        {
            try
            {
                //CheckModel(model);
                var result = _transportStorage.Insert(model);
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

        public bool Delete(TransportBindingModel model)
        {
            try
            {
                var result = _transportStorage.Delete(model);
                if (result == null)
                {
                    throw new ArgumentNullException($"Не получилось удалить машину");
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public TransportViewModel ReadElement(TransportSearchModel model)
        {
            try
            {
                var result = _transportStorage.GetElement(model);
                if (result == null)
                {
                    throw new ArgumentNullException($"Не получилось получить эдемент с id {model.Id}");
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<TransportViewModel> ReadList(TransportSearchModel? model = null)
        {
            try
            {
                var results = model != null ? _transportStorage.GetFilteredList(model) : _transportStorage.GetFullList();
                return results;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Update(TransportBindingModel model)
        {
            try
            {
                var result = _transportStorage.Update(model);
                if (result == null)
                {
                    throw new ArgumentNullException($"Результат обновления машин оказался нулевым");
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
