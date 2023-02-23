using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskPlannerMetrum.Business;
using TaskPlannerMetrum.Model;

namespace TaskPlannerMetrum.Controllers
{
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ActivityPlanController : ControllerBase
    {
        private readonly IActivityPlanBusiness _activityPlanBusiness;
        private readonly ILogger<ActivityPlanController> _logger;
        public ActivityPlanController(IActivityPlanBusiness activityPlanBusiness , ILogger<ActivityPlanController> logger)
        {
            _logger= logger;
            _activityPlanBusiness = activityPlanBusiness;
        }


        [HttpGet("ExecutorPlannerList")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetExecutorPlanner(string projectId)
        {

            return Ok(_activityPlanBusiness.GetExecutorPlan(projectId));
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create(ActivityPlan activityPlan)
        {

            return Ok(_activityPlanBusiness.Create(activityPlan));
        }
        [HttpGet("TasksByProject")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindTask(string projectId)
        {

            return Ok(_activityPlanBusiness.TasksByProject(projectId));
        }

    }
}
