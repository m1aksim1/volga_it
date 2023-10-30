using DataModels;

namespace Contracts.ViewModels
{
    public class PersonViewModel : IPersonModel
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public double Money { get; set; }
        public int Id { get; set; }
    }
}