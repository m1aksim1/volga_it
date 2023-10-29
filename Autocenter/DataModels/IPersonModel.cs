using DataModels.HelperInterfaces;

namespace DataModels
{
    public interface IPersonModel : IId
    {
        string Login { get;}
        string Password { get;}
        string Role { get;}
    }
}