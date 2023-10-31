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
    public class AccountController : Controller
    {
        private readonly IUserLogic _logic;
        public AccountController(IUserLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        [Authorize]
        public UserViewModel Me()
        {
            try
            {
                return _logic.ReadElement(new UserSearchModel
                {
                    Id = Convert.ToInt32(User.Identity.Name)
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public IActionResult SignIn(AccountSchemaModel model)
        {
            try
            {
                var account = _logic.ReadElement(new UserSearchModel
                {
                    Username = model.Username,
                    Password = model.Password
                });
                var claims = new List<Claim>
                {
                    new(ClaimsIdentity.DefaultNameClaimType, account.Id.ToString()),
                    new(ClaimsIdentity.DefaultRoleClaimType, account.IsAdmin ? "Admin" : "User"),
                };
                ClaimsIdentity claimsIdentity = new(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claimsIdentity.Claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var jwtToken = "Bearer " + new JwtSecurityTokenHandler().WriteToken(jwt);
                Response.Cookies.Append("token", jwtToken);
                return Ok(jwtToken);
;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult SignUp(AccountSchemaModel model)
        {
            try
            {
                _logic.Create(new UserBindingModel
                {
                    Username = model.Username,
                    Password = model.Password,
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("нельзя создать пользователя с существующим username");
            }
        }
        
        [HttpPost]
        [Authorize]
        public void SignOut()
        {
            Response.Cookies.Delete("token");
        }
        [HttpPost]
        [Authorize]
        public IActionResult Update(AccountSchemaModel model)
        {
            try
            {
                _logic.Update(new UserBindingModel{Id = Convert.ToInt32(User.Identity.Name), Username = model.Username, Password = model.Password});
                return Ok();    
            }
            catch (Exception ex)
            {
                return BadRequest(" нельзя использовать уже используемые в системе username");
            }
        }

        
    }
}
