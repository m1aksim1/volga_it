using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IUserLogic _logic;
        public PaymentController(IUserLogic logic)
        {
            _logic = logic;
        }
        [HttpPost]
        [Authorize]
        public void Hesoyam(int id)
        {
            if (User.IsInRole("Admin") || Convert.ToInt32(User.Identity.Name) == id)
            {
                var model = _logic.ReadElement(new UserSearchModel
                {
                    Id = id
                });
                _logic.Update(new UserBindingModel
                {
                    Id = model.Id,
                    Username = model.Username,
                    Password = model.Password,
                    IsAdmin = model.IsAdmin,
                    Balance = model.Balance + 250000
                });
            }        
        }
    }
}
