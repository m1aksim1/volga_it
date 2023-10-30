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
    public class PersonController : Controller
    {
        private readonly IPersonLogic _logic;
        public PersonController(IPersonLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        [Authorize]
        public PersonViewModel Me()
        {
            try
            {
                return _logic.ReadElement(new PersonSearchModel
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
                var account = _logic.ReadElement(new PersonSearchModel
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
                _logic.Create(new PersonBindingModel
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
        public IActionResult Update(PersonBindingModel model)
        {
            try
            {
                _logic.Update(model);
                return Ok();    
            }
            catch (Exception ex)
            {
                return BadRequest(" нельзя использовать уже используемые в системе username");
            }
        }

        
    }
}
