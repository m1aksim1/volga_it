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
        public void CheckModel(RentBindingModel model) 
        {
            var transport = _transportStorage.GetElement(new TransportSearchModel { Id = model.TransportId });
            if (model == null)
            {
                throw new ArgumentNullException($"модель пустая");
            }
            else if (!transport.CanBeRented)
            {
                throw new ArgumentNullException($"Транспорт уже арендован");
            }
            else if (model.PersonId == transport.OwnerId)
            {
                throw new ArgumentNullException($"нельзя брать в аренду собственный транспорт");
            }
        }
        public bool Create(RentBindingModel model)
        {
            try
            {
                CheckModel(model);
  
                var result = _rentStorage.Insert(model);
                if (result == null)
                {
                    throw new ArgumentNullException($"Клиент не создался");
                }
                var transport = _transportStorage.GetElement(new TransportSearchModel { Id = model.TransportId });
                _transportStorage.Update(new TransportBindingModel 
                {
                    Id = transport.Id,
                    CanBeRented = false,
                    Color = transport.Color,
                    DayPrice = transport.DayPrice,
                    Description = transport.Description,
                    Identifier = transport.Identifier,
                    Latitude = transport.Latitude,
                    Longitude = transport.Longitude,
                    MinutePrice = transport.MinutePrice,
                    Model = transport.Model,
                    OwnerId = transport.OwnerId,
                    TypeTransport = transport.TypeTransport
                });
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
                    throw new ArgumentNullException($"Не получилось получить элемент с id {model.Id}");
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
                TypeRent.Days => diff.TotalDays + 1,
                TypeRent.Minutes => diff.TotalMinutes + 1,
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
                DateEnd = DateTime.UtcNow,     
                FinalPrice = price,
            });
            return true;
        }
    }
}
