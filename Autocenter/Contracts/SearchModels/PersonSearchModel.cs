using DataModels;
using DataModels.Enums;

namespace Contracts.SearchModels
{
    public class PersonSearchModel
    {
        public int TransportId { get; set; }
        public int PersonId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public TypeRent rentType { get; set; }
        public int? Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}