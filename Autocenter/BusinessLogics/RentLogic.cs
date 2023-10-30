using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DataModels.Enums;

namespace BusinessLogics
{
    public class RentLogic : IRentLogic
    {
        private readonly IRentStorage _rentStorage;
        private readonly ITransportStorage _transportStorage;

        public RentLogic(IRentStorage rentStorage, ITransportStorage transportStorage)
        {
            _rentStorage = rentStorage;
            _transportStorage = transportStorage;
        }
        public bool CheckModel(RentBindingModel model) 
        {
            var transport = _transportStorage.GetElement(new TransportSearchModel { Id = model.TransportId });
            if (model == null)
            {
                return false;
            }
            else if (model.PersonId == transport.OwnerId)
            {
                return false;
            }
            return true;
        }
        public bool Create(RentBindingModel model)
        {
            try
            {
                if (CheckModel(model))
                {
                    throw new ArgumentNullException($"нельзя брать в аренду собственный транспорт");
                }
                var result = _rentStorage.Insert(model);
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

        public bool Delete(RentBindingModel model)
        {
            try
            {
                var result = _rentStorage.Delete(model);
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

        public RentViewModel ReadElement(RentSearchModel model)
        {
            try
            {
                var result = _rentStorage.GetElement(model);
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

        public List<RentViewModel> ReadList(RentSearchModel? model = null)
        {
            try
            {
                var results = model != null ? _rentStorage.GetFilteredList(model) : _rentStorage.GetFullList();
                return results;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Update(RentBindingModel model)
        {
            try
            {
                var result = _rentStorage.Update(model);
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
        public bool End(long id)
        {
            var element = _rentStorage.GetElement(new RentSearchModel { Id = id });
            var diff = DateTime.UtcNow - element.DateStart;
            
            var price = element.PriceOfUnit * element.RentType switch
            {
                TypeRent.Дни => diff.TotalDays + 1,
                TypeRent.Минуты => diff.TotalMinutes + 1,
                _ => 0
            };
            _rentStorage.Update(new RentBindingModel 
            { 
                Id = id,
                PersonId = element.PersonId,
                PriceType = element.RentType,
                DateStart = element.DateStart,
                PriceOfUnit = element.PriceOfUnit,
                TransportId = element.TransportId,
                DateEnd = DateTime.Now,     
                FinalPrice = price,
            });
            return true;
        }
    }
}
