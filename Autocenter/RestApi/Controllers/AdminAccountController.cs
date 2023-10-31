using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestApi.SchemaModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminAccountController : Controller
    {
        private readonly IUserLogic _logic;
        public AdminAccountController(IUserLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<UserViewModel> Account(int start = 0, int count = 5)
        {
            try
            {
                return _logic.ReadList(new UserSearchModel { start = start, count = count});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public UserViewModel Account(int id)
        {
            try
            {
                return _logic.ReadElement(new UserSearchModel { Id = id });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Account(AdminAccountSchema model)
        {
            try
            {
                _logic.Create(new UserBindingModel { 
                    IsAdmin = model.isAdmin,
                    Balance = model.balance,
                    Password = model.password,
                    Username = model.username,
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult Account(int id, AdminAccountSchema model)
        {
            try
            {
                _logic.Update(new UserBindingModel
                {
                    Id = id,
                    IsAdmin = model.isAdmin,
                    Balance = model.balance,
                    Password = model.password,
                    Username = model.username,
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            try
            {
                _logic.Delete(new UserBindingModel { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}