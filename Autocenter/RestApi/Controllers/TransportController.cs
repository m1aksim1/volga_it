﻿using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransportController : Controller
    {
        private readonly ITransportLogic _logic;
        public TransportController(ITransportLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        [Route("{id}")]
        public TransportViewModel? TransportGet(int id)
        {
            try
            {
                return _logic.ReadElement(new TransportSearchModel { Id = id });
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        [HttpPost]
        public void TransportCreate(TransportBindingModel model)
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
        public void TransportUpdate(int id,TransportBindingModel model)
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
        public void TransportDelete(int id)
        {
            try
            {
                TransportBindingModel Model = new TransportBindingModel();
                Model.Id = id;
                _logic.Delete(Model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
