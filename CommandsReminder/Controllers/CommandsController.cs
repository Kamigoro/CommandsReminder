using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandsReminder.Database;
using CommandsReminder.DTO;
using CommandsReminder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommandsReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandsDbContext _context;
        private readonly IMapper _mapper;

        public CommandsController(CommandsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<CommandsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandDTO>>> GetAsync()
        {
            var commands = await _context.Commands.Include(c => c.Parameters).ToListAsync();

            if(commands != null)
            {
                var commandPlatforms = await _context.CommandPlatforms.Include(cp => cp.Platform).ToListAsync();

                foreach (var command in commands)
                {
                    foreach (var commandPlatform in commandPlatforms)
                    {
                        if (commandPlatform.CommandId == command.CommandId)
                        {
                            command.Platforms.Add(commandPlatform.Platform);
                        }
                    }
                }
                IEnumerable<CommandDTO> commandDTOs = _mapper.Map<IEnumerable<CommandDTO>>(commands);
                return Ok(commandDTOs);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<CommandsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommandDTO>> GetAsync(int id)
        {
            //Retrieve command with the specified Id
            var command = await _context.Commands.Include(c => c.Parameters).FirstOrDefaultAsync(c => c.CommandId == id);

            if(command != null)
            {
                //Finding all the platforms that the command contains via the joint table
                var commandPlatforms = await _context.CommandPlatforms.Include(cp => cp.Platform).Where(cp => cp.CommandId == command.CommandId).ToListAsync();
                List<Platform> platforms = new List<Platform>();
                foreach (var commandPlatform in commandPlatforms)
                {
                    platforms.Add(commandPlatform.Platform);
                }
                CommandDTO commandDTO = _mapper.Map<CommandDTO>(command);
                commandDTO.Platforms = platforms;
                return Ok(commandDTO);
            }
            else
            {
                return NotFound();
            }
                       
        }

        // POST api/<CommandsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
