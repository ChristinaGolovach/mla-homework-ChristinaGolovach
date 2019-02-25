using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MLA_task.BLL.Interface;
using MLA_task.BLL.Interface.Exceptions;
using DemoError = MLA_task.BLL.Interface.Exceptions.DemoServiceException.ErrorType;
using MLA_task.BLL.Interface.Models;
using NLog;

namespace MLA_task.Controllers
{
    public class DemoController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IDemoModelService _demoModelService;

        public DemoController(ILogger logger, IDemoModelService demoModelService)
        {
            _logger = logger;
            _demoModelService = demoModelService;
        }

        public async Task<IHttpActionResult> Get()
        {          
            _logger.Info("Receiving all DemoDbModels");

            var models = await _demoModelService.GetAllDemoModelsAsync();

            return Ok(models);           
        }

        // GET: Demo
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info($"Receiving item with id {id}");

            try
            {
                var model = await _demoModelService.GetDemoModelByIdAsync(id);

                _logger.Info($"Item with id {id} has been received.");

                return Ok(model);
            }
            catch (DemoServiceException ex)
            {
                if (ex.Error == DemoError.WrongId) 
                {
                    _logger.Info(ex, $"Wrong ID {id} has been requested");
                    return BadRequest("Wrong ID");
                }

                throw;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Server error occured while trying to get item with id {id}");
                return InternalServerError(ex);
            }
        }

        //TODO change to filter
        public async Task<IHttpActionResult> Post([FromBody]CreateUpdateDemoModel model)
        {
            _logger.Info($"Adding model with name {model.Name}");

            if (model == null)
            {
                return BadRequest($"The {nameof(model)} can not be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newModel = await _demoModelService.CreateDemoModelAsync(model);

                //return Created<DemoModel>(newModel);
                return Ok(newModel);
            }
            catch (DemoServiceException exception)
            {
                if (exception.Error == DemoError.WrongName)
                {
                    _logger.Info($"Wrong model name {model.Name} detected");

                    return BadRequest($"The wrong name {model.Name}.");
                }

                throw;
            }
            catch (Exception exception)
            {
                _logger.Error(exception, $"Server error occured while trying to add item with name {model.Name}");

                return InternalServerError();
            }
        }

        //TODO filter
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            _logger.Info($"Deleting model with {id}");

            try
            {
                await _demoModelService.DeleteDemoModelAsync(id);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
            }
            catch (DemoServiceException exception)
            {
                if (exception.Error == DemoError.WrongId)
                {
                    _logger.Info($"Wrong model id {id} detected");

                    return BadRequest($"The wrong id {id}.");
                }

                throw;

            }
            catch (Exception exception)
            {
                _logger.Error(exception, $"Server error occured while trying to delete item with id {id}");

                return InternalServerError();
            }       
        }
    }
}