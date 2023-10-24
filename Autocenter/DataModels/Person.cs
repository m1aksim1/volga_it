using DataModels.HelperInterfaces;

namespace DataModels
{
    public interface Person : IId
    {
        public string Login { get;}
        public string Password { get;}
        public string Role { get;}
    }
}