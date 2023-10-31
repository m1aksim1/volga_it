using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;
using System;
using System.Linq;
using System.Xml.Linq;

namespace DatabaseImplement.Implements
{
    public class PersonStorage : IPersonStorage
    {
        private void CheckSearchModel(PersonSearchModel model)
        {
            if (model == null) 
                throw new ArgumentNullException("Передаваемая модель для поиска равна нулю", nameof(model));
            if (!model.Id.HasValue && string.IsNullOrEmpty(model.Username) && string.IsNullOrEmpty(model.Password))
                throw new ArgumentException("Все передаваемые поля поисковой модели оказались пусты или равны null");
        }

        public List<PersonViewModel> GetFilteredList(PersonSearchModel model)
        {
            using var context = new AutocenterDB();
            if (model.start.HasValue && model.count.HasValue)
            {
                return context.Persons
               .Skip((int)model.start).Take((int)model.count)
               .Select(x => x.GetViewModel)
               .ToList();
            }
            return context.Persons
               .Select(x => x.GetViewModel)
               .ToList();
        }
        public List<PersonViewModel> GetFullList()
        {
            using var context = new AutocenterDB();
            return context.Persons
                .Select(x => x.GetViewModel)
                .ToList();
        }
        public PersonViewModel? GetElement(PersonSearchModel model)
        {
            CheckSearchModel(model);
            using var context = new AutocenterDB();
            if(model.Username == "" && model.Password == "")
            {
                return context.Persons.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
            }
            return context.Persons.FirstOrDefault(x => x.Username.Equals(model.Username) 
                                                    && (string.IsNullOrEmpty(model.Password) 
                                                    || x.Password.Equals(model.Password)
                                                    || (model.Id.HasValue 
                                                    && x.Id == model.Id)))?.GetViewModel;
        }
        public PersonViewModel? Insert(PersonBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var newPerson = Person.Create(model);
            using var context = new AutocenterDB();
            context.Persons.Add(newPerson);
            context.SaveChanges();
            return newPerson.GetViewModel;
        }
        public PersonViewModel? Update(PersonBindingModel model)
        {
            using var context = new AutocenterDB();
            var res = context.Persons.FirstOrDefault(x => x.Id == model.Id);
            res?.Update(model);
            context.SaveChanges();
            return res?.GetViewModel;
        }
        public PersonViewModel? Delete(PersonBindingModel model)
        {
            using var context = new AutocenterDB();
            var element = context.Persons.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                context.Persons.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
