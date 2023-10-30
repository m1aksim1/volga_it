using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    [Index("Username", IsUnique = true)]
    public class Person : IPersonModel
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public double Money { get; set; }

        public static Person Create(PersonBindingModel model)
        {
			if (model == null)
			{
				return null;
			}
			return new Person()
            {
                Username = model.Username,
                Password = model.Password,
                Id = model.Id,
                IsAdmin = model.IsAdmin,
                Money = model.Money,
            };
        }
        public void Update(PersonBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Username = model.Username;
            Password = model.Password;
            IsAdmin = model.IsAdmin;
            Money = model.Money;
        }

        public PersonViewModel GetViewModel => new()
        {
            Username = Username,
            Password = Password,
            Id = Id,
            IsAdmin = IsAdmin,
            Money = Money,
        };
    }
}
