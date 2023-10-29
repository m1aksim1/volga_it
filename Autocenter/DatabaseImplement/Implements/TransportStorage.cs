using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Implements
{
    public class TransportStorage : ITransportStorage
    {
        private void CheckSearchModel(TransportSearchModel model)
        {
            if (model == null)
                throw new ArgumentNullException("Передаваемая модель для поиска равна нулю", nameof(model));
        }

        public TransportViewModel? Delete(TransportBindingModel model)
        {
            using var context = new AutocenterDB();
            var element = context.Transports.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                context.Transports.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public TransportViewModel? GetElement(TransportSearchModel model)
        {
            CheckSearchModel(model);
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new AutocenterDB();
            return context.Transports.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)?.GetViewModel;
        }

        public List<TransportViewModel> GetFilteredList(TransportSearchModel model)
        {
            CheckSearchModel(model);
            if (model.Id.HasValue)
            {
                var res = GetElement(model);
                return res != null ? new() { res } : new();
            }
            using var context = new AutocenterDB();
            var query = context.Transports;
            return new();
        }

        public List<TransportViewModel> GetFullList()
        {
            using var context = new AutocenterDB();
            return context.Transports
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public TransportViewModel? Insert(TransportBindingModel model)
        {
            var newTransport = Transport.Create(model);
            if (newTransport == null)
            {
                return null;
            }
            using var context = new AutocenterDB();
            context.Transports.Add(newTransport);
            context.SaveChanges();
            return newTransport.GetViewModel;
        }

        public TransportViewModel? Update(TransportBindingModel model)
        {
            using var context = new AutocenterDB();
            var car = context.Transports.FirstOrDefault(x => x.Id == model.Id);
            if (car == null)
            {
                return null;
            }
            car.Update(model);
            context.SaveChanges();
            return car.GetViewModel;
        }
    }
}
