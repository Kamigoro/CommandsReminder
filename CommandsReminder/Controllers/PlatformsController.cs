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
    public class PlatformsController : ControllerBase
    {

        private readonly CommandsDbContext _context;
        private readonly IMapper _mapper;

        public PlatformsController(CommandsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<PlatformsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformDTO>>> GetAsync()
        {


            return null;
        }

        // GET api/<PlatformsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatformDTO>> GetAsync(int id)
        {
            var platform = await _context.Platforms.FirstOrDefaultAsync(p => p.PlatformId == id);

            if (platform != null)
            {
                var commandPlatforms = await _context.CommandPlatforms
                    .Include(cp => cp.Command)
                    .ThenInclude(c => c.Parameters)
                    .Where(cp => cp.PlatformId == platform.PlatformId)
                    .ToListAsync();

                List<Command> commands = new List<Command>();
                foreach (var commandPlatform in commandPlatforms)
                {
                    commands.Add(commandPlatform.Command);
                }
                PlatformDTO platformDTO = _mapper.Map<PlatformDTO>(platform);
                platformDTO.Commands = commands;

                return Ok(platformDTO);
            }
            return NotFound();
        }

        // POST api/<PlatformsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlatformsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlatformsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
