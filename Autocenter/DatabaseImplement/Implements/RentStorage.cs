using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;
using DataModels.Enums;
using System.Diagnostics.Metrics;

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
            var user = context.Users.FirstOrDefault(x => x.Id == model.UserRoleId);
            var Rent = context.Rents.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id || model.Id == null && x.TransportId == model.TransportId)?.GetViewModel;
            var Transport = context.Transports.FirstOrDefault(x => x.Id == Rent.TransportId);
            if (model.UserRoleId == Rent.UserId || model.UserRoleId == Transport.OwnerId || user.IsAdmin) 
            {
                return Rent;
            }
            return null;
        }

        public List<RentViewModel> GetFilteredList(RentSearchModel model)
        {
            using var context = new AutocenterDB();
            return context.Rents
                .Where(x => x.TransportId == model.TransportId || x.UserId == model.UserId)
                .Select(x => x.GetViewModel)
                .ToList();
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
            if(newRent.PriceType == TypeRent.Days)
            {
                newRent.PriceOfUnit = transport.DayPrice;
            }
            else if(newRent.PriceType == TypeRent.Minutes)
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
