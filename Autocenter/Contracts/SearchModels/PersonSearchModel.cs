using DataModels;
using DataModels.Enums;

namespace Contracts.SearchModels
{
    public class UserSearchModel
    {
        public long TransportId { get; set; }
        public long UserId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public TypeRent rentType { get; set; }
        public long? Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? start { get; set; }
        public int? count { get; set; }
    }
}