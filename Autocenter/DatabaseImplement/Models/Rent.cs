using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels;
using DataModels.Enums;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace DatabaseImplement.Models
{
    public class Rent : IRentModel
    {
        public long TransportId { get; set; }
        public long PersonId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public TypeRent PriceType { get; set; }
        public double PriceOfUnit { get; set; }
        public double FinalPrice { get; set; }
        public long Id { get; set; }

        public static Rent Create(RentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Rent()
            {
                Id = model.Id,
                TransportId = model.TransportId,
                PersonId = model.PersonId,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                PriceType = model.PriceType,
            };
        }
        public void Update(RentBindingModel model)
        {
            DateEnd = model.DateEnd;
        }
        public RentViewModel GetViewModel => new()
        {
            Id = Id,
            TransportId = TransportId,
            PersonId = PersonId,
            DateStart = DateStart,
            DateEnd = DateEnd,
            PriceType = PriceType,
        };
    }
}