using Contracts.BindingModels;
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
        public TransportViewModel? TransportGet(int id)
        {
            try
            {
                TransportSearchModel Model = new TransportSearchModel();
                Model.Id = id;
                return _logic.ReadElement(Model);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        [HttpGet]
        public List<TransportViewModel>? TransportFullList()
        {
            try
            {
                return _logic.ReadList(null);
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
