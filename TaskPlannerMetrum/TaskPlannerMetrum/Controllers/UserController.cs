using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using TaskPlannerMetrum.Business;
using TaskPlannerMetrum.Data.VO;
using TaskPlannerMetrum.Model;

namespace TaskPlannerMetrum.Controllers
{
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        // Declaration of the service used
        private IUserBusiness _userBusiness;

        // Injection of an instance of IPersonService
        // when creating an instance of PersonController
        public UserController(ILogger<UserController> logger, IUserBusiness userBusiness)
        {
            _logger = logger;
            _userBusiness = userBusiness;

        }

        // Maps GET requests to https://localhost:{port}/api/person
        // Get no parameters for FindAll -> Search All
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<UserVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_userBusiness.FindAll());
        }

        // Maps GET requests to https://localhost:{port}/api/person/{id}
        // receiving an ID as in the Request Path
        // Get with parameters for FindById -> Search by ID
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(UserVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var user = _userBusiness.FindByID(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // Maps POST requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object sent in the request body
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(UserVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] UserVO user)
        {
            if (user == null) return BadRequest();
            return Ok(_userBusiness.Create(user));
        }

        // Maps PUT requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object sent in the request body
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(UserVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] UserVO user)
        {
            if (user == null) return BadRequest();
            return Ok(_userBusiness.Update(user));
        }

        // Maps DELETE requests to https://localhost:{port}/api/person/{id}
        // receiving an ID as in the Request Path
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _userBusiness.Delete(id);
            return NoContent();
        }
    }
}
