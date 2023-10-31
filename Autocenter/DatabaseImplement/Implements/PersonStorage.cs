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
    public class UserStorage : IUserStorage
    {
        private void CheckSearchModel(UserSearchModel model)
        {
            if (model == null) 
                throw new ArgumentNullException("Передаваемая модель для поиска равна нулю", nameof(model));
            if (!model.Id.HasValue && string.IsNullOrEmpty(model.Username) && string.IsNullOrEmpty(model.Password))
                throw new ArgumentException("Все передаваемые поля поисковой модели оказались пусты или равны null");
        }

        public List<UserViewModel> GetFilteredList(UserSearchModel model)
        {
            using var context = new AutocenterDB();
            if (model.start.HasValue && model.count.HasValue)
            {
                return context.Users
               .Skip((int)model.start).Take((int)model.count)
               .Select(x => x.GetViewModel)
               .ToList();
            }
            return context.Users
               .Select(x => x.GetViewModel)
               .ToList();
        }
        public List<UserViewModel> GetFullList()
        {
            using var context = new AutocenterDB();
            return context.Users
                .Select(x => x.GetViewModel)
                .ToList();
        }
        public UserViewModel? GetElement(UserSearchModel model)
        {
            CheckSearchModel(model);
            using var context = new AutocenterDB();
            if(model.Username == "" && model.Password == "")
            {
                return context.Users.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
            }
            return context.Users.FirstOrDefault(x => x.Username.Equals(model.Username) 
                                                    && (string.IsNullOrEmpty(model.Password) 
                                                    || x.Password.Equals(model.Password)
                                                    || (model.Id.HasValue 
                                                    && x.Id == model.Id)))?.GetViewModel;
        }
        public UserViewModel? Insert(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var newUser = User.Create(model);
            using var context = new AutocenterDB();
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser.GetViewModel;
        }
        public UserViewModel? Update(UserBindingModel model)
        {
            using var context = new AutocenterDB();
            var res = context.Users.FirstOrDefault(x => x.Id == model.Id);
            res?.Update(model);
            context.SaveChanges();
            return res?.GetViewModel;
        }
        public UserViewModel? Delete(UserBindingModel model)
        {
            using var context = new AutocenterDB();
            var element = context.Users.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                context.Users.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
