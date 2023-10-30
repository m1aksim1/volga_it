using DataModels;

namespace Contracts.SearchModels
{
    public class RentSearchModel
    {
        public long TransportId { get; set; }
        public long PersonId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public double Money { get; set; }
        public long? Id { get; set; }
    }
}
