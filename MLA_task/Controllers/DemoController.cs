using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
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
            //var models = await _context.DemoDbModels.ToListAsync();

            //return Ok(models.Select(model => new { Id = model.Id, Name = model.Name, InfoId = model.DemoCommonInfoModelId, Info = model.DemoCommonInfoModel.CommonInfo }));

            _logger.Info("receiving all DemoDbModels");

            var models = await _demoModelService.GetAllDemoModelsAsync();

            return Ok(models);
           
        }

        // GET: Demo
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info($"receiving item with id {id}");

            try
            {
                var model = await _demoModelService.GetDemoModelByIdAsync(id);

                _logger.Info($"item with id {id} has been received.");

                return Ok(model);
            }
            catch (DemoServiceException ex)
            {
                if (ex.Error == DemoError.WrongId) 
                {
                    _logger.Info(ex, $"Wrong ID {id} has been requested");
                    return this.BadRequest("Wrong ID");
                }

                throw;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Server error occured while trying to get item with id {id}");
                return this.InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> Post([FromBody]CreateUpdateDemoModel model)
        {
            _logger.Info($"adding model with name {model.Name}");

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
                var newModel = await _demoModelService.CraeteDemoModelAsync(model);

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
    }
}