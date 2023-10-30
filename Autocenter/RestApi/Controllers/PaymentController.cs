using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPersonLogic _logic;
        public PaymentController(IPersonLogic logic)
        {
            _logic = logic;
        }
        [HttpPost]
        public void Hesoyam(int id)
        {
            var model = _logic.ReadElement(new PersonSearchModel
            {
                Id = id
            });
            _logic.Update(new PersonBindingModel
            {
                Username = model.Username, 
                Password = model.Password, 
                IsAdmin = model.IsAdmin, 
                Money = model.Money+250000
        });         
        }
    }
}
