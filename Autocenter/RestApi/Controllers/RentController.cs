using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DataModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.SchemaModels;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentController : Controller
    {
        private readonly IRentLogic _rentLogic;
        private readonly ITransportLogic _transportLogic;
        public RentController(IRentLogic rentlogic, ITransportLogic transportLogic)
        {
            _rentLogic = rentlogic;
            _transportLogic = transportLogic;
        }
        
        [HttpGet]
        public List<TransportViewModel> Transport(double lat, double longitude, double radius, TransportType? type)
        {
            return _transportLogic.ReadList(new TransportSearchModel {
                Latitude = lat,
                Longitude = longitude,
                Radius = radius,
                Type = type
            }
            );
        }
       
        [HttpGet]
        [Route("{rentId}")]
        public RentViewModel Rent(long rentId)
        {
            return _rentLogic.ReadElement(new RentSearchModel { Id = rentId, UserRoleId = Convert.ToInt32(User.Identity.Name)});
        }
       
        [HttpGet]
        public List<RentViewModel> MyHistory()
        {
            return _rentLogic.ReadList(new RentSearchModel
            {
                UserId = Convert.ToInt64(User.Identity.Name)
            });
        }
        
        [HttpGet]
        [Route("{transportId}")]
        public List<RentViewModel> TransportHistory(long transportId)
        {
            return _rentLogic.ReadList(new RentSearchModel
            {
                TransportId = transportId,
            });
        }
        
        [HttpPost]
        [Authorize]
        [Route("{transportId}")]
        public void New(long transportId,TypeRent rentType)
        {
            _rentLogic.Create(new RentBindingModel
            {
                UserId = Convert.ToInt32(User.Identity.Name),
                TransportId = transportId,
                PriceType = rentType,
            });
        }
        
        [HttpPost]
        [Authorize]
        [Route("{rentId}")]
        public void End(long rentId,RentEndSchemaModel model)
        {
            var rent = _rentLogic.ReadElement(new RentSearchModel { Id = rentId, UserRoleId = Convert.ToInt32(User.Identity.Name) });
            _rentLogic.End(rent.Id, Convert.ToInt32(User.Identity.Name));
            
            var transport = _transportLogic.ReadElement(new TransportSearchModel { Id = rent.TransportId });
            _transportLogic.Update(new TransportBindingModel
            {
                Id = transport.Id,
                CanBeRented = true,
                Color = transport.Color,
                DayPrice = transport.DayPrice,
                Description = transport.Description,
                Identifier = transport.Identifier,
                Latitude = model.lat,
                Longitude = model.longitude,
                MinutePrice = transport.MinutePrice,
                Model = transport.Model,
                OwnerId = transport.OwnerId,
                TransportType = transport.TransportType
            });
        }
    }
}