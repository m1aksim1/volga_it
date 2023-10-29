using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonLogic _logic;
        public PersonController(IPersonLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public PersonViewModel? Login(string login, string password)
        {
            try
            {
                return _logic.ReadElement(new PersonSearchModel
                {
                    Login = login,
                    Password = password
                });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public void Register(PersonBindingModel model)
        {
            try
            {
               _logic.Create(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public void UpdateData(PersonBindingModel model)
        {
            try
            {
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public void me()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
