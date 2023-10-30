using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;
using DataModels.Enums;

namespace DatabaseImplement.Implements
{
    public class RentStorage : IRentStorage
    {
       
        public RentViewModel? Delete(RentBindingModel model)
        {
            using var context = new AutocenterDB();
            var element = context.Rents.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                context.Rents.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public RentViewModel? GetElement(RentSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new AutocenterDB();
            return context.Rents.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)?.GetViewModel;
        }

        public List<RentViewModel> GetFilteredList(RentSearchModel model)
        {
            if (model.Id.HasValue)
            {
                var res = GetElement(model);
                return res != null ? new() { res } : new();
            }
            using var context = new AutocenterDB();
            var query = context.Rents;
            return new();
        }

        public List<RentViewModel> GetFullList()
        {
            using var context = new AutocenterDB();
            return context.Rents
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public RentViewModel? Insert(RentBindingModel model)
        {
            var newRent = Rent.Create(model);
            if (newRent == null)
            {
                return null;
            }
            using var context = new AutocenterDB();
            var transport = context.Transports.FirstOrDefault(x => x.Id == model.TransportId);
            if(newRent.PriceType == TypeRent.Дни)
            {
                newRent.PriceOfUnit = transport.DayPrice;
            }
            else if(newRent.PriceType == TypeRent.Минуты)
            {
                newRent.PriceOfUnit = transport.MinutePrice;
            }
            context.Rents.Add(newRent);
            context.SaveChanges();
            return newRent.GetViewModel;
        }

        public RentViewModel? Update(RentBindingModel model)
        {
            using var context = new AutocenterDB();
            var rent = context.Rents.FirstOrDefault(x => x.Id == model.Id);
            if (rent == null)
            {
                return null;
            }
            rent.Update(model);
            context.SaveChanges();
            return rent.GetViewModel;
        }
    }
}
