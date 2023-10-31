using DataModels.HelperInterfaces;

namespace DataModels
{
    public interface IUserModel : IId
    {
        string Username { get;}
        string Password { get;}
        bool IsAdmin { get;}
        double Balance { get;}
    }
}