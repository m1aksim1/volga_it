using DataModels.HelperInterfaces;

namespace DataModels
{
    public interface IPersonModel : IId
    {
        string Username { get;}
        string Password { get;}
        bool IsAdmin { get;}
        double Balance { get;}
    }
}