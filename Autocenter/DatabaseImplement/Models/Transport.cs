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
        public bool CanBeRented { get; set; }
        public TypeTransport TypeTransport { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double MinutePrice { get; set; }
        public double DayPrice { get; set; }
        public long Id { get; set; }
        public long OwnerId { get; set; }

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
                Identifier = model.Identifier,
                Description = model.Description,  
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                MinutePrice = model.MinutePrice,
                DayPrice = model.DayPrice,
                Id = model.Id,
                OwnerId = model.OwnerId
            };
        }

        public TransportViewModel GetViewModel => new()
        {
            CanBeRented =  CanBeRented, 
            TypeTransport = TypeTransport,
            Model = Model,
            Color = Color,
            Identifier = Identifier,
            Description = Description,
            Latitude = Latitude,
            Longitude = Longitude,
            MinutePrice = MinutePrice,
            DayPrice = DayPrice,
            Id = Id,
            OwnerId = OwnerId,
        };


        public void Update(TransportBindingModel model)
        {
            CanBeRented = CanBeRented;
            TypeTransport = TypeTransport;
            Model = Model;
            Color = Color;
            Identifier = Identifier;
            Description = Description;
            Latitude = Latitude;
            Longitude = Longitude;
            MinutePrice = MinutePrice;
            DayPrice = DayPrice;
            OwnerId = OwnerId;
        }
    }
}
