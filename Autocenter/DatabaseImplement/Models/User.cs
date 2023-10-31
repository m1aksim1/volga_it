using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    [Index("Username", IsUnique = true)]
    public class User : IUserModel
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public double Balance { get; set; }

        public static User Create(UserBindingModel model)
        {
			if (model == null)
			{
				return null;
			}
			return new User()
            {
                Username = model.Username,
                Password = model.Password,
                Id = model.Id,
                IsAdmin = model.IsAdmin,
                Balance = model.Balance,
            };
        }
        public void Update(UserBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Username = model.Username;
            Password = model.Password;
            IsAdmin = model.IsAdmin;
            Balance = model.Balance;
        }

        public UserViewModel GetViewModel => new()
        {
            Username = Username,
            Password = Password,
            Id = Id,
            IsAdmin = IsAdmin,
            Balance = Balance,
        };
    }
}
