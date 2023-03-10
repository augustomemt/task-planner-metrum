using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TaskPlannerMetrum.Business;
using TaskPlannerMetrum.Model;
using TaskPlannerMetrum.Model.DTO;

namespace TaskPlannerMetrum.Controllers
{

    [ApiController]   
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;

        // Declaration of the service used
        private IProjectsBusiness _projectBusiness;

        public ProjectsController(ILogger<ProjectsController> logger, IProjectsBusiness projectBusiness)
        {
            _logger = logger;
            _projectBusiness = projectBusiness;

        }

        // Maps GET requests to https://localhost:{port}/api/person
        // Get no parameters for FindAll -> Search All
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            
            return Ok(_projectBusiness.FindAll());
        }


        [HttpGet("ManagerPlanner")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetManagerPlanner()
        {

            return Ok(_projectBusiness.FindPlannerManager());
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create(ProjectDTO project)
        {

            return Ok(_projectBusiness.Create(project));
        }


    }
}
