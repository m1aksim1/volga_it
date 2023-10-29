using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class PersonStorage : IPersonStorage
    {
        private void CheckSearchModel(PersonSearchModel model)
        {
            if (model == null) 
                throw new ArgumentNullException("Передаваемая модель для поиска равна нулю", nameof(model));
            if (!model.Id.HasValue && string.IsNullOrEmpty(model.Login) && string.IsNullOrEmpty(model.Password))
                throw new ArgumentException("Все передаваемые поля поисковой модели оказались пусты или равны null");
        }
        public PersonViewModel? GetElement(PersonSearchModel model)
        {
            CheckSearchModel(model);
            using var context = new AutocenterDB();
           
            return context.Persons.FirstOrDefault(x => x.Login.Equals(model.Login) && (string.IsNullOrEmpty(model.Password) || x.Password.Equals(model.Password)))?.GetViewModel;
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
    }
}
