using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DataModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public RentViewModel GetRent(long id)
        {
            return _rentLogic.ReadElement(new RentSearchModel { Id = id });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{userId}")]
        public List<RentViewModel> UserHistory(long userId)
        {
            return _rentLogic.ReadList(new RentSearchModel
            {
                PersonId = Convert.ToInt64(User.Identity.Name)
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{transportId}")]
        public List<RentViewModel> TransportHistory(long transportId)
        {
            return _rentLogic.ReadList(new RentSearchModel
            {
                TransportId = transportId
            });
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Rent(RentBindingModel model)
        {
            _rentLogic.Create(model);
        }
    }
}