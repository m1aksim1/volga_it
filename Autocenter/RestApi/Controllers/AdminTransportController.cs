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
    public class AdminTransportController : Controller
    {
        private readonly ITransportLogic _logic;
        public AdminTransportController(ITransportLogic logic)
        {
            _logic = logic;
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<TransportViewModel>? Transport(int start = 0,int count = 10,TransportType? type = null)
        {
            try
            {
                return _logic.ReadList(new TransportSearchModel {Start = start,Count = count, Type = type });
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public TransportViewModel? Transport(int id)
        {
            try
            {
                return _logic.ReadElement(new TransportSearchModel { Id = id});
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Transport(TransportBindingModel model)
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
        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Transport(int id, TransportBindingModel model)
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
        
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public void TransportDelete(int id)
        {
            try
            {
                _logic.Delete(new TransportBindingModel { Id = id });
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
