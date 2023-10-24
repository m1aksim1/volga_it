using DataModels.HelperInterfaces;

namespace DataModels.ProxyModels
{
    public class RentModel : IId
    {
        public virtual int Id { get; set; }
        public virtual int TransportId { get; set; }
        public virtual int PersonId { get; set; }
        public virtual DateOnly Duration { get; set; }
        public virtual DateOnly DateStart { get; set; }
    }
}