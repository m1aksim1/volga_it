using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    public class Person : IPersonModel
    {
        public int Id { get; set; }
  
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string Password { get; private set; } = string.Empty;
        [Required]
        public string Role { get; private set; } = string.Empty;
        [Required]
        public double Money { get; private set; }

        public static Person Create(PersonBindingModel model)
        {
			if (model == null)
			{
				return null;
			}
			return new Person()
            {
                Login = model.Login,
                Password = model.Password,
                Id = model.Id,
                Role = model.Role,
                Money = model.Money,
            };
        }
        public void Update(PersonBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Login = model.Login;
            Password = model.Password;
            Role = model.Role;
            Money = model.Money;
        }

        public PersonViewModel GetViewModel => new()
        {
            Login = Login,
            Password = Password,
            Id = Id,
            Role = Role,
            Money = Money,
        };
    }
}
