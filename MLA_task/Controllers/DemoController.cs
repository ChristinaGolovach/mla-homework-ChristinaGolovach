using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MLA_task.BLL.Interface;
using MLA_task.BLL.Interface.Models;
using MLA_task.ExceptionFilters;
using NLog;

namespace MLA_task.Controllers
{
    [RoutePrefix("api/demo")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [DemoExceptionFilter]
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

            var model = await _demoModelService.GetDemoModelByIdAsync(id);

            _logger.Info($"Item with id {id} has been received.");

            return Ok(model);           

        }

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

            var newModel = await _demoModelService.CreateDemoModelAsync(model);

            return Ok(newModel);
        }

        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            _logger.Info($"Deleting model with {id}");

            await _demoModelService.DeleteDemoModelAsync(id);

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));           
        }
    }
}