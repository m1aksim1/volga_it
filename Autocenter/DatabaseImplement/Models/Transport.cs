using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DataModels;
using DataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
    public class Transport : ITransportModel
    {
        [Required]
        public bool CanBeRented { get; set; }
        [Required]
        public TypeTransport TypeTransport { get; set; }
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;
        [Required]
        public string identifier { get; set; } = string.Empty;
        [Required]
        public string description { get; set; } = string.Empty;
        [Required]
        public double latitude { get; set; }
        [Required]
        public double longitude { get; set; }
        [Required]
        public double minutePrice { get; set; }
        [Required]
        public double dayPrice { get; set; }
        [Required]
        public int Id { get; set; }

        public static Transport Create(TransportBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Transport()
            {
                CanBeRented = model.CanBeRented,
                TypeTransport = model.TypeTransport,
                Model = model.Model,
                Color = model.Color,
                identifier = model.identifier,
                description = model.description,  
                latitude = model.latitude,
                longitude = model.longitude,
                minutePrice = model.minutePrice,
                dayPrice = model.dayPrice,
                Id = model.Id
            };
        }

        public TransportViewModel GetViewModel => new()
        {
            CanBeRented =  CanBeRented, 
            TypeTransport = TypeTransport,
            Model = Model,
            Color = Color,
            identifier = identifier,
            description = description,
            latitude = latitude,
            longitude = longitude,
            minutePrice = minutePrice,
            dayPrice = dayPrice,
            Id = Id
        };

        public void Update(TransportBindingModel model)
        {
            CanBeRented = CanBeRented;
            TypeTransport = TypeTransport;
            Model = Model;
            Color = Color;
            identifier = identifier;
            description = description;
            latitude = latitude;
            longitude = longitude;
            minutePrice = minutePrice;
            dayPrice = dayPrice;
        }
    }
}
