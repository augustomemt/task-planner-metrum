using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TaskPlannerMetrum.Business;
using TaskPlannerMetrum.Model;

namespace TaskPlannerMetrum.Controllers
{
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ActiviesScopeListController: ControllerBase
    {
        private readonly IActiviesScopeBusiness _activiesScopeBusiness;
        private readonly ILogger<ActiviesScopeListController> _logger;
        public ActiviesScopeListController(IActiviesScopeBusiness activiesScopeBusiness, ILogger<ActiviesScopeListController> logger ) 
        {
            _logger= logger;
            _activiesScopeBusiness = activiesScopeBusiness;


        }

        // Maps GET requests to https://localhost:{port}/api/person
        // Get no parameters for FindAll -> Search All
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get( string projectId)
        {
            return Ok(_activiesScopeBusiness.GetActivesScopeByProject(projectId));
        }



    }
}
