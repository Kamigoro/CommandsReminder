using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommandsReminder.Database;
using CommandsReminder.Models;
using AutoMapper;
using CommandsReminder.DTO;

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

        // GET: api/Commands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandReadDTO>>> GetCommands()
        {
            var commands = await _context.Commands
                .Include(c => c.Platforms)
                .Include(c => c.Parameters)
                .ToListAsync();
            if(commands != null)
            {
                return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
            }
            return NotFound();
        }

        // GET: api/Commands/5
        [HttpGet("{id}", Name="GetCommand")]
        public async Task<ActionResult<CommandReadDTO>> GetCommand(int id)
        {
            var command = await _context.Commands
                .Include(c => c.Platforms)
                .Include(c => c.Parameters)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(command));
            }

            return NotFound();
        }

        // PUT: api/Commands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommand(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Commands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommandReadDTO>> PostCommand(CommandCreateDTO commandCreateDTO)
        {
            var command = _mapper.Map<Command>(commandCreateDTO);
            await _context.Commands.AddAsync(command);
            var platforms = _context.Platforms.Where(p => commandCreateDTO.PlatformsId.Contains(p.Id));
            if(platforms != null)
            {
                await platforms.ForEachAsync(p => p.Commands.Add(command));
            }
                
            int result = await _context.SaveChangesAsync();

            if(result > 0)
            {
                var createdCommand = await _context.Commands.FirstOrDefaultAsync(c => c.Equals(command));
                return CreatedAtRoute(nameof(GetCommand), new { Id = createdCommand.Id}, _mapper.Map<CommandReadDTO>(createdCommand));
            }

            return BadRequest();
        }

        // DELETE: api/Commands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            var command = await _context.Commands.FindAsync(id);
            if (command == null)
            {
                return NotFound();
            }

            _context.Commands.Remove(command);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandExists(int id)
        {
            return _context.Commands.Any(e => e.Id == id);
        }
    }
}
