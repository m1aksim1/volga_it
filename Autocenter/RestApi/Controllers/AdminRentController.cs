using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DataModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.SchemaModels;
using System.Data;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminRentController : Controller
    {
        private readonly IRentLogic _rentLogic;
        private readonly ITransportLogic _transportLogic;
        public AdminRentController(IRentLogic rentlogic, ITransportLogic transportLogic)
        {
            _rentLogic = rentlogic;
            _transportLogic = transportLogic;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public RentViewModel Rent(long id)
        {
            return _rentLogic.ReadElement(new RentSearchModel { Id = id, UserRoleId = Convert.ToInt32(User.Identity.Name) });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{userId}")]
        public List<RentViewModel> UserHistory(long userId)
        {
            return _rentLogic.ReadList(new RentSearchModel
            {
                UserId = userId,
                UserRoleId = Convert.ToInt32(User.Identity.Name)
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{transportId}")]
        public List<RentViewModel> TransportHistory(long transportId)
        {
            return _rentLogic.ReadList(new RentSearchModel
            {
                TransportId = transportId,
                UserRoleId = Convert.ToInt32(User.Identity.Name),
            });
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Rent(RentBindingModel model)
        {
            _rentLogic.Create(model);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("{rentId}")]
        public void End(long rentId, RentEndSchemaModel model)
        {
            var rent = _rentLogic.ReadElement(new RentSearchModel { Id = rentId });
            _rentLogic.End(rent.Id, Convert.ToInt32(User.Identity.Name));

            var transport = _transportLogic.ReadElement(new TransportSearchModel { Id = rent.TransportId});
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
        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{rentId}")]
        public void Rent(long rentId, RentBindingModel model)
        {
            model.Id = rentId;
            var rent = _rentLogic.Update(model);
        }
       
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{rentId}")]
        public void DeleteRent(long rentId)
        {
            var rent = _rentLogic.Delete(new RentBindingModel { Id = rentId });
        }
    }
}