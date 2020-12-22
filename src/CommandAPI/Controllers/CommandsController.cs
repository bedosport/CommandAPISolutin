using System.Collections.Generic;
using CommandAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        public CommandsController(ICommandAPIRepo repository){
            _repository = repository;
        }
 

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_repository.GetAllCommands());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(commandItem);
        }
    }
}